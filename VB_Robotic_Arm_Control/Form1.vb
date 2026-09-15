Imports System.IO.Ports
Imports System.Runtime.InteropServices
Imports System.Threading.Tasks

Public Class Form1
    Private isConnected As Boolean = False
    Private isHandshakeComplete As Boolean = False

    ' Throttling state for smooth trackbar updates
    Private pendingX As Boolean = False
    Private pendingS As Boolean = False
    Private pendingG As Boolean = False

    ' 3 joints default to 90° center (Base D3, Shoulder D6, Gripper D9)
    Private targetX As Integer = 90
    Private targetS As Integer = 90
    Private targetG As Integer = 90

    ' Win32 API to detect physical key states (specifically Right Shift vs Left Shift)
    <DllImport("user32.dll")>
    Private Shared Function GetAsyncKeyState(vKey As Integer) As Short
    End Function

    Private Const VK_SHIFT As Integer = &H10
    Private Const VK_RSHIFT As Integer = &HA1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        cb_Baud.SelectedIndex = 0 ' 115200
        RefreshComPorts()
        SetControlsEnabled(False)
        UpdateGripControlState()
        UpdateAngleLabels()
        AppendLog("[SYSTEM]", "Robotic Arm Controller ready (3-DOF Mode).")
        AppendLog("[HARDWARE]", "Configured: Base (Pin D3) | Shoulder (Pin D6) | Gripper (Pin D9)")
        AppendLog("[CONTROLS]", "Keyboard: ◄/► Base | ▲/▼ Shoulder | Enter: Close (180°) | R-Shift: Open (90°)")
        AppendLog("[CONTROLS]", "Mouse: Drag or scroll wheel over any slider to adjust angles directly.")
    End Sub

    Private Sub RefreshComPorts()
        Try
            Dim previousSelection As String = If(cb_Ports.SelectedItem IsNot Nothing, cb_Ports.SelectedItem.ToString(), "")
            cb_Ports.Items.Clear()
            Dim portNames() As String = SerialPort.GetPortNames()

            If portNames.Length > 0 Then
                Array.Sort(portNames)
                cb_Ports.Items.AddRange(portNames)

                ' Prefer previous port, or COM8, or first port
                If Not String.IsNullOrEmpty(previousSelection) AndAlso cb_Ports.Items.Contains(previousSelection) Then
                    cb_Ports.SelectedItem = previousSelection
                ElseIf cb_Ports.Items.Contains("COM8") Then
                    cb_Ports.SelectedItem = "COM8"
                Else
                    cb_Ports.SelectedIndex = 0
                End If
                btn_Connect.Enabled = True
            Else
                cb_Ports.Items.Add("No Ports Found")
                cb_Ports.SelectedIndex = 0
                btn_Connect.Enabled = False
            End If
        Catch ex As Exception
            AppendLog("[ERROR]", "Error discovering COM ports: " & ex.Message)
        End Try
    End Sub

    Private Sub btn_Refresh_Click(sender As Object, e As EventArgs) Handles btn_Refresh.Click
        If Not isConnected Then
            RefreshComPorts()
            AppendLog("[SYSTEM]", "Scanned for available COM ports.")
        End If
    End Sub

    Private Async Sub btn_Connect_Click(sender As Object, e As EventArgs) Handles btn_Connect.Click
        If Not isConnected Then
            Try
                If cb_Ports.SelectedItem Is Nothing OrElse cb_Ports.SelectedItem.ToString() = "No Ports Found" Then
                    MessageBox.Show("Please plug in the Arduino USB cable and click Scan.", "No Port Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                Dim selectedPort As String = cb_Ports.SelectedItem.ToString()
                Dim selectedBaud As Integer = 115200
                If cb_Baud.SelectedItem IsNot Nothing Then
                    Integer.TryParse(cb_Baud.SelectedItem.ToString(), selectedBaud)
                End If

                SerialPort1.PortName = selectedPort
                SerialPort1.BaudRate = selectedBaud
                SerialPort1.DataBits = 8
                SerialPort1.Parity = Parity.None
                SerialPort1.StopBits = StopBits.One
                SerialPort1.NewLine = vbLf
                SerialPort1.ReadTimeout = 1000
                SerialPort1.WriteTimeout = 1000

                ' DTR and RTS are MANDATORY for Arduino CH340 / USB UART to communicate properly
                SerialPort1.DtrEnable = True
                SerialPort1.RtsEnable = True

                AppendLog("[SYSTEM]", "Opening " & selectedPort & " at " & selectedBaud & " baud...")
                SerialPort1.Open()
                isConnected = True
                isHandshakeComplete = False

                btn_Connect.Text = "Disconnect"
                btn_Connect.BackColor = Color.FromArgb(217, 83, 79)
                lbl_Status.Text = "● Initializing (Waiting for Bootloader)..."
                lbl_Status.ForeColor = Color.DarkOrange
                cb_Ports.Enabled = False
                cb_Baud.Enabled = False
                btn_Refresh.Enabled = False

                AppendLog("[SYSTEM]", "Port opened. Waiting 1.8s for Arduino bootloader initialization...")

                ' Allow bootloader to finish without freezing UI thread
                Await Task.Delay(1800)

                If isConnected AndAlso SerialPort1.IsOpen Then
                    isHandshakeComplete = True
                    lbl_Status.Text = "● Connected (" & selectedPort & " - " & selectedBaud & " Baud)"
                    lbl_Status.ForeColor = Color.FromArgb(40, 167, 69)
                    SetControlsEnabled(True)
                    tmr_Throttle.Start()

                    AppendLog("[SYSTEM]", "Handshake ready. Synchronizing 3 joints at 90° default...")
                    SendCommandImmediate("X", tb_Base.Value)
                    Await Task.Delay(40)
                    SendCommandImmediate("S", tb_Shoulder.Value)

                    ' Only synchronize Gripper if explicitly enabled by user
                    If chk_GripEnable.Checked Then
                        Await Task.Delay(40)
                        SendCommandImmediate("G", tb_Grip.Value)
                    Else
                        SendRawCommand("DETACH:G")
                        AppendLog("[SAFETY]", "Gripper servo detached on Pin D9 (Safe mode).")
                    End If
                End If

            Catch ex As Exception
                DisconnectPort()
                MessageBox.Show("Failed to open " & cb_Ports.Text & ":" & vbCrLf & ex.Message & vbCrLf & vbCrLf &
                                "Tip: Check that the Arduino is plugged into USB and close any other Serial Monitors.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                AppendLog("[ERROR]", "Connection failed: " & ex.Message)
            End Try
        Else
            DisconnectPort()
        End If
    End Sub

    Private Sub DisconnectPort()
        tmr_Throttle.Stop()
        isHandshakeComplete = False

        Try
            If SerialPort1.IsOpen Then
                Try
                    SerialPort1.Write("RELAX" & vbLf)
                Catch
                End Try
                SerialPort1.Close()
            End If
        Catch ex As Exception
            ' Ignore close error
        Finally
            isConnected = False
            btn_Connect.Text = "Connect"
            btn_Connect.BackColor = Color.FromArgb(46, 117, 182)
            lbl_Status.Text = "● Disconnected"
            lbl_Status.ForeColor = Color.Firebrick
            cb_Ports.Enabled = True
            cb_Baud.Enabled = True
            btn_Refresh.Enabled = True
            SetControlsEnabled(False)
            AppendLog("[SYSTEM]", "Disconnected from serial port.")
        End Try
    End Sub

    Private Sub SetControlsEnabled(enabled As Boolean)
        gb_Base.Enabled = enabled
        gb_Shoulder.Enabled = enabled
        gb_Keyboard.Enabled = enabled
        btn_HomeAll.Enabled = enabled
        btn_RelaxAll.Enabled = enabled
        btn_Ping.Enabled = enabled
        btn_QueryStatus.Enabled = enabled

        gb_Grip.Enabled = enabled
        UpdateGripControlState()
    End Sub

    Private Sub UpdateGripControlState()
        Dim gripActive As Boolean = isConnected AndAlso chk_GripEnable.Checked
        tb_Grip.Enabled = gripActive
        btn_GripOpen.Enabled = gripActive
        btn_GripMid.Enabled = gripActive
        btn_GripClose.Enabled = gripActive
    End Sub

    Private Sub chk_GripEnable_CheckedChanged(sender As Object, e As EventArgs) Handles chk_GripEnable.CheckedChanged
        UpdateGripControlState()

        If isConnected AndAlso SerialPort1.IsOpen Then
            If chk_GripEnable.Checked Then
                AppendLog("[SAFETY]", "Gripper enabled on Pin D9. Attaching servo...")
                SendRawCommand("ATTACH:G")
                SendCommandImmediate("G", tb_Grip.Value)
            Else
                AppendLog("[SAFETY]", "Gripper disabled. Detaching servo to stop current draw & heat...")
                SendRawCommand("DETACH:G")
            End If
        End If
    End Sub

    Private Sub SerialPort1_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        Try
            While SerialPort1.IsOpen AndAlso SerialPort1.BytesToRead > 0
                Dim line As String = SerialPort1.ReadLine()
                If Not String.IsNullOrEmpty(line) Then
                    line = line.Trim()
                    If line.Length > 0 Then
                        Me.BeginInvoke(Sub()
                                           AppendLog("[RX]", line)
                                           If line.Contains("READY:") Then
                                               lbl_Status.Text = "● Connected (" & SerialPort1.PortName & " - " & SerialPort1.BaudRate & " Baud)"
                                               lbl_Status.ForeColor = Color.FromArgb(40, 167, 69)
                                           End If
                                       End Sub)
                    End If
                End If
            End While
        Catch ex As Exception
            ' Disconnection or read timeout
        End Try
    End Sub

    Private Sub SendCommandImmediate(axis As String, angle As Integer)
        If isConnected AndAlso SerialPort1.IsOpen Then
            Try
                angle = Math.Max(0, Math.Min(180, angle))
                Dim cmd As String = axis.ToUpper() & ":" & angle.ToString()
                SerialPort1.Write(cmd & vbLf)
                AppendLog("[TX]", cmd)
            Catch ex As Exception
                AppendLog("[ERROR]", "Write error: " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub SendRawCommand(cmd As String)
        If isConnected AndAlso SerialPort1.IsOpen Then
            Try
                SerialPort1.Write(cmd.Trim() & vbLf)
                AppendLog("[TX]", cmd.Trim())
            Catch ex As Exception
                AppendLog("[ERROR]", "Write error: " & ex.Message)
            End Try
        End If
    End Sub

    ' Throttle timer prevents serial flooding during fast slider movements or key repeats
    Private Sub tmr_Throttle_Tick(sender As Object, e As EventArgs) Handles tmr_Throttle.Tick
        If Not isConnected OrElse Not isHandshakeComplete Then Return

        If pendingX Then
            pendingX = False
            SendCommandImmediate("X", targetX)
            Return
        End If
        If pendingS Then
            pendingS = False
            SendCommandImmediate("S", targetS)
            Return
        End If
        If pendingG AndAlso chk_GripEnable.Checked Then
            pendingG = False
            SendCommandImmediate("G", targetG)
            Return
        End If
    End Sub

    Private Sub AppendLog(prefix As String, message As String)
        Dim timestamp As String = DateTime.Now.ToString("HH:mm:ss.fff")
        Dim logLine As String = String.Format("[{0}] {1} {2}", timestamp, prefix, message)

        If txt_Log.TextLength > 30000 Then
            txt_Log.Text = txt_Log.Text.Substring(10000)
        End If

        txt_Log.AppendText(logLine & Environment.NewLine)

        If chk_AutoScroll.Checked Then
            txt_Log.SelectionStart = txt_Log.TextLength
            txt_Log.ScrollToCaret()
        End If
    End Sub

    Private Sub UpdateAngleLabels()
        lbl_BaseAngle.Text = tb_Base.Value.ToString() & "°"
        lbl_ShoulderAngle.Text = tb_Shoulder.Value.ToString() & "°"
        lbl_GripAngle.Text = tb_Grip.Value.ToString() & "°"
    End Sub

    ' ========================================================
    ' KEYBOARD SHORTCUT & CONTROL ACTIONS
    ' ========================================================
    Private Sub AdjustBase(delta As Integer)
        If Not isConnected Then Return
        Dim newVal As Integer = Math.Max(tb_Base.Minimum, Math.Min(tb_Base.Maximum, tb_Base.Value + delta))
        If newVal <> tb_Base.Value Then
            tb_Base.Value = newVal
            lbl_BaseAngle.Text = newVal.ToString() & "°"
            targetX = newVal
            pendingX = True
        End If
    End Sub

    Private Sub AdjustShoulder(delta As Integer)
        If Not isConnected Then Return
        Dim newVal As Integer = Math.Max(tb_Shoulder.Minimum, Math.Min(tb_Shoulder.Maximum, tb_Shoulder.Value + delta))
        If newVal <> tb_Shoulder.Value Then
            tb_Shoulder.Value = newVal
            lbl_ShoulderAngle.Text = newVal.ToString() & "°"
            targetS = newVal
            pendingS = True
        End If
    End Sub

    Private Sub SetGripper(targetAngle As Integer)
        If Not isConnected OrElse Not chk_GripEnable.Checked Then Return
        Dim newVal As Integer = Math.Max(tb_Grip.Minimum, Math.Min(tb_Grip.Maximum, targetAngle))
        tb_Grip.Value = newVal
        lbl_GripAngle.Text = newVal.ToString() & "°"
        targetG = newVal
        pendingG = True
    End Sub

    ' ProcessCmdKey intercepts navigation keys (Arrow keys, Enter) across all controls
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If isConnected Then
            Dim keyOnly As Keys = (keyData And Keys.KeyCode)
            Select Case keyOnly
                Case Keys.Left
                    AdjustBase(-5)
                    Return True
                Case Keys.Right
                    AdjustBase(5)
                    Return True
                Case Keys.Up
                    AdjustShoulder(5)
                    Return True
                Case Keys.Down
                    AdjustShoulder(-5)
                    Return True
                Case Keys.Enter, Keys.Return
                    SetGripper(180) ' Close (180°)
                    Return True
            End Select
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    ' Form KeyDown captures Right Shift reliably
    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If isConnected Then
            If e.KeyCode = Keys.RShiftKey OrElse (e.KeyCode = Keys.ShiftKey AndAlso (GetAsyncKeyState(VK_RSHIFT) And &H8000) <> 0) Then
                SetGripper(90) ' Open (90°)
                e.Handled = True
            End If
        End If
    End Sub

    ' WndProc fallback ensuring Right Shift is never missed even if child controls have focus
    Protected Overrides Sub WndProc(ByRef m As Message)
        Const WM_KEYDOWN As Integer = &H100
        Const WM_SYSKEYDOWN As Integer = &H104

        If isConnected AndAlso (m.Msg = WM_KEYDOWN OrElse m.Msg = WM_SYSKEYDOWN) Then
            Dim vkey As Integer = m.WParam.ToInt32()
            If vkey = VK_RSHIFT OrElse (vkey = VK_SHIFT AndAlso (GetAsyncKeyState(VK_RSHIFT) And &H8000) <> 0) Then
                SetGripper(90) ' Open (90°)
            End If
        End If

        MyBase.WndProc(m)
    End Sub

    ' ========================================================
    ' BASE AXIS (SERVO X - PIN D3) CONTROLS [Default: 90°]
    ' Mouse wheel scrolling on tb_Base is natively supported
    ' ========================================================
    Private Sub tb_Base_Scroll(sender As Object, e As EventArgs) Handles tb_Base.Scroll
        lbl_BaseAngle.Text = tb_Base.Value.ToString() & "°"
        targetX = tb_Base.Value
        pendingX = True
    End Sub

    Private Sub tb_Base_MouseUp(sender As Object, e As MouseEventArgs) Handles tb_Base.MouseUp
        pendingX = False
        SendCommandImmediate("X", tb_Base.Value)
    End Sub

    Private Sub btn_BaseDec_Click(sender As Object, e As EventArgs) Handles btn_BaseDec.Click
        AdjustBase(-5)
    End Sub

    Private Sub btn_BaseInc_Click(sender As Object, e As EventArgs) Handles btn_BaseInc.Click
        AdjustBase(5)
    End Sub

    Private Sub btn_BaseCenter_Click(sender As Object, e As EventArgs) Handles btn_BaseCenter.Click
        tb_Base.Value = 90
        lbl_BaseAngle.Text = "90°"
        pendingX = False
        SendCommandImmediate("X", 90)
    End Sub

    ' ========================================================
    ' SHOULDER JOINT (SERVO S - PIN D6) [Default: 90°]
    ' Mouse wheel scrolling on tb_Shoulder is natively supported
    ' ========================================================
    Private Sub tb_Shoulder_Scroll(sender As Object, e As EventArgs) Handles tb_Shoulder.Scroll
        lbl_ShoulderAngle.Text = tb_Shoulder.Value.ToString() & "°"
        targetS = tb_Shoulder.Value
        pendingS = True
    End Sub

    Private Sub tb_Shoulder_MouseUp(sender As Object, e As MouseEventArgs) Handles tb_Shoulder.MouseUp
        pendingS = False
        SendCommandImmediate("S", tb_Shoulder.Value)
    End Sub

    Private Sub btn_ShoulderDec_Click(sender As Object, e As EventArgs) Handles btn_ShoulderDec.Click
        AdjustShoulder(-5)
    End Sub

    Private Sub btn_ShoulderInc_Click(sender As Object, e As EventArgs) Handles btn_ShoulderInc.Click
        AdjustShoulder(5)
    End Sub

    Private Sub btn_ShoulderCenter_Click(sender As Object, e As EventArgs) Handles btn_ShoulderCenter.Click
        tb_Shoulder.Value = 90
        lbl_ShoulderAngle.Text = "90°"
        pendingS = False
        SendCommandImmediate("S", 90)
    End Sub

    ' ========================================================
    ' GRIPPER / CLAW (SERVO G - PIN D9) [Default: 90° Center]
    ' Mouse wheel scrolling on tb_Grip is natively supported
    ' ========================================================
    Private Sub tb_Grip_Scroll(sender As Object, e As EventArgs) Handles tb_Grip.Scroll
        UpdateAngleLabels()
        targetG = tb_Grip.Value
        pendingG = True
    End Sub

    Private Sub tb_Grip_MouseUp(sender As Object, e As MouseEventArgs) Handles tb_Grip.MouseUp
        If chk_GripEnable.Checked Then
            pendingG = False
            SendCommandImmediate("G", tb_Grip.Value)
        End If
    End Sub

    Private Sub btn_GripOpen_Click(sender As Object, e As EventArgs) Handles btn_GripOpen.Click
        SetGripper(90)
    End Sub

    Private Sub btn_GripMid_Click(sender As Object, e As EventArgs) Handles btn_GripMid.Click
        SetGripper(135)
    End Sub

    Private Sub btn_GripClose_Click(sender As Object, e As EventArgs) Handles btn_GripClose.Click
        SetGripper(180)
    End Sub

    ' ========================================================
    ' GLOBAL RESET TO HOME (All 3 joints to 90° Center)
    ' ========================================================
    Private Sub btn_HomeAll_Click(sender As Object, e As EventArgs) Handles btn_HomeAll.Click
        pendingX = False
        pendingS = False
        pendingG = False

        tb_Base.Value = 90
        tb_Shoulder.Value = 90
        tb_Grip.Value = 90
        UpdateAngleLabels()

        If chk_GripEnable.Checked Then
            SendRawCommand("HOME")
        Else
            SendCommandImmediate("X", 90)
            SendCommandImmediate("S", 90)
        End If
    End Sub

    ' ========================================================
    ' RELAX / EMERGENCY TORQUE CUT (COOLS SERVOS IMMEDIATELY)
    ' ========================================================
    Private Sub btn_RelaxAll_Click(sender As Object, e As EventArgs) Handles btn_RelaxAll.Click
        pendingX = False
        pendingS = False
        pendingG = False

        SendRawCommand("RELAX")
        AppendLog("[SAFETY]", "All servos relaxed / detached. Holding torque cut to cool motors.")
    End Sub

    ' ========================================================
    ' DIAGNOSTICS & TELEMETRY CONTROLS
    ' ========================================================
    Private Sub btn_Ping_Click(sender As Object, e As EventArgs) Handles btn_Ping.Click
        SendRawCommand("PING")
    End Sub

    Private Sub btn_QueryStatus_Click(sender As Object, e As EventArgs) Handles btn_QueryStatus.Click
        SendRawCommand("STATUS")
    End Sub

    Private Sub btn_ClearLog_Click(sender As Object, e As EventArgs) Handles btn_ClearLog.Click
        txt_Log.Clear()
        AppendLog("[SYSTEM]", "Telemetry log cleared.")
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        DisconnectPort()
    End Sub
End Class

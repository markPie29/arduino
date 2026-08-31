Imports System.IO.Ports

Public Class Form1
    Private isConnected As Boolean = False

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshComPorts()
        SetControlsEnabled(False)
        UpdateAngleLabels()
    End Sub

    Private Sub RefreshComPorts()
        Try
            cb_Ports.Items.Clear()
            Dim portNames() As String = SerialPort.GetPortNames()
            If portNames.Length > 0 Then
                cb_Ports.Items.AddRange(portNames)
                cb_Ports.SelectedIndex = 0
                btn_Connect.Enabled = True
            Else
                cb_Ports.Items.Add("No Ports Found")
                cb_Ports.SelectedIndex = 0
                btn_Connect.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show("Error discovering COM ports: " & ex.Message, "Port Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btn_Refresh_Click(sender As Object, e As EventArgs) Handles btn_Refresh.Click
        If Not isConnected Then
            RefreshComPorts()
        End If
    End Sub

    Private Sub btn_Connect_Click(sender As Object, e As EventArgs) Handles btn_Connect.Click
        If Not isConnected Then
            ' Attempt to Connect
            Try
                If cb_Ports.SelectedItem Is Nothing OrElse cb_Ports.SelectedItem.ToString() = "No Ports Found" Then
                    MessageBox.Show("Please select a valid COM port.", "No Port Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                SerialPort1.PortName = cb_Ports.SelectedItem.ToString()
                SerialPort1.BaudRate = 115200
                SerialPort1.DataBits = 8
                SerialPort1.Parity = Parity.None
                SerialPort1.StopBits = StopBits.One
                SerialPort1.ReadTimeout = 1000
                SerialPort1.WriteTimeout = 1000

                SerialPort1.Open()
                isConnected = True

                ' Update UI
                btn_Connect.Text = "Disconnect"
                btn_Connect.BackColor = Color.FromArgb(217, 83, 79) ' Soft red
                lbl_Status.Text = "● Connected (" & SerialPort1.PortName & ")"
                lbl_Status.ForeColor = Color.FromArgb(40, 167, 69) ' Green
                cb_Ports.Enabled = False
                btn_Refresh.Enabled = False
                SetControlsEnabled(True)

                ' Send initial sync after small delay
                Threading.Thread.Sleep(200)
                SendCommand("X", tb_Base.Value)
                SendCommand("Y", tb_Arm.Value)
                SendCommand("G", tb_Grip.Value)

            Catch ex As Exception
                isConnected = False
                MessageBox.Show("Failed to open " & cb_Ports.Text & ":" & vbCrLf & ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                lbl_Status.Text = "● Connection Failed"
                lbl_Status.ForeColor = Color.Firebrick
                SetControlsEnabled(False)
            End Try
        Else
            ' Disconnect
            DisconnectPort()
        End If
    End Sub

    Private Sub DisconnectPort()
        Try
            If SerialPort1.IsOpen Then
                SerialPort1.Close()
            End If
        Catch ex As Exception
            ' Ignore close error
        Finally
            isConnected = False
            btn_Connect.Text = "Connect"
            btn_Connect.BackColor = Color.FromArgb(46, 117, 182) ' Blue
            lbl_Status.Text = "● Disconnected"
            lbl_Status.ForeColor = Color.Firebrick
            cb_Ports.Enabled = True
            btn_Refresh.Enabled = True
            SetControlsEnabled(False)
        End Try
    End Sub

    Private Sub SetControlsEnabled(enabled As Boolean)
        gb_Base.Enabled = enabled
        gb_Arm.Enabled = enabled
        gb_Grip.Enabled = enabled
        btn_HomeAll.Enabled = enabled
    End Sub

    Private Sub SendCommand(axis As String, angle As Integer)
        If isConnected AndAlso SerialPort1.IsOpen Then
            Try
                angle = Math.Max(0, Math.Min(180, angle))
                Dim cmd As String = axis.ToUpper() & ":" & angle.ToString() & vbLf
                SerialPort1.Write(cmd)
            Catch ex As Exception
                ' Port write timeout or disconnection
            End Try
        End If
    End Sub

    Private Sub SendHomeCommand()
        If isConnected AndAlso SerialPort1.IsOpen Then
            Try
                SerialPort1.Write("HOME" & vbLf)
            Catch ex As Exception
                ' Port write timeout or disconnection
            End Try
        End If
    End Sub

    Private Sub UpdateAngleLabels()
        lbl_BaseAngle.Text = tb_Base.Value.ToString() & "°"
        lbl_ArmAngle.Text = tb_Arm.Value.ToString() & "°"
        lbl_GripAngle.Text = tb_Grip.Value.ToString() & "°"
    End Sub

    ' ========================================================
    ' BASE AXIS (SERVO X) CONTROLS
    ' ========================================================
    Private Sub tb_Base_Scroll(sender As Object, e As EventArgs) Handles tb_Base.Scroll
        lbl_BaseAngle.Text = tb_Base.Value.ToString() & "°"
        SendCommand("X", tb_Base.Value)
    End Sub

    Private Sub btn_BaseDec_Click(sender As Object, e As EventArgs) Handles btn_BaseDec.Click
        tb_Base.Value = Math.Max(tb_Base.Minimum, tb_Base.Value - 5)
        lbl_BaseAngle.Text = tb_Base.Value.ToString() & "°"
        SendCommand("X", tb_Base.Value)
    End Sub

    Private Sub btn_BaseInc_Click(sender As Object, e As EventArgs) Handles btn_BaseInc.Click
        tb_Base.Value = Math.Min(tb_Base.Maximum, tb_Base.Value + 5)
        lbl_BaseAngle.Text = tb_Base.Value.ToString() & "°"
        SendCommand("X", tb_Base.Value)
    End Sub

    Private Sub btn_BaseCenter_Click(sender As Object, e As EventArgs) Handles btn_BaseCenter.Click
        tb_Base.Value = 90
        lbl_BaseAngle.Text = "90°"
        SendCommand("X", 90)
    End Sub

    ' ========================================================
    ' ARM AXIS (SERVO Y) CONTROLS
    ' ========================================================
    Private Sub tb_Arm_Scroll(sender As Object, e As EventArgs) Handles tb_Arm.Scroll
        lbl_ArmAngle.Text = tb_Arm.Value.ToString() & "°"
        SendCommand("Y", tb_Arm.Value)
    End Sub

    Private Sub btn_ArmDec_Click(sender As Object, e As EventArgs) Handles btn_ArmDec.Click
        tb_Arm.Value = Math.Max(tb_Arm.Minimum, tb_Arm.Value - 5)
        lbl_ArmAngle.Text = tb_Arm.Value.ToString() & "°"
        SendCommand("Y", tb_Arm.Value)
    End Sub

    Private Sub btn_ArmInc_Click(sender As Object, e As EventArgs) Handles btn_ArmInc.Click
        tb_Arm.Value = Math.Min(tb_Arm.Maximum, tb_Arm.Value + 5)
        lbl_ArmAngle.Text = tb_Arm.Value.ToString() & "°"
        SendCommand("Y", tb_Arm.Value)
    End Sub

    Private Sub btn_ArmCenter_Click(sender As Object, e As EventArgs) Handles btn_ArmCenter.Click
        tb_Arm.Value = 90
        lbl_ArmAngle.Text = "90°"
        SendCommand("Y", 90)
    End Sub

    ' ========================================================
    ' GRIPPER (SERVO GRIP) CONTROLS
    ' ========================================================
    Private Sub tb_Grip_Scroll(sender As Object, e As EventArgs) Handles tb_Grip.Scroll
        lbl_GripAngle.Text = tb_Grip.Value.ToString() & "°"
        SendCommand("G", tb_Grip.Value)
    End Sub

    Private Sub btn_GripMin_Click(sender As Object, e As EventArgs) Handles btn_GripMin.Click
        tb_Grip.Value = 0
        lbl_GripAngle.Text = "0°"
        SendCommand("G", 0)
    End Sub

    Private Sub btn_GripOpen_Click(sender As Object, e As EventArgs) Handles btn_GripOpen.Click
        tb_Grip.Value = 90
        lbl_GripAngle.Text = "90°"
        SendCommand("G", 90)
    End Sub

    Private Sub btn_GripClose_Click(sender As Object, e As EventArgs) Handles btn_GripClose.Click
        tb_Grip.Value = 180
        lbl_GripAngle.Text = "180°"
        SendCommand("G", 180)
    End Sub

    ' ========================================================
    ' GLOBAL RESET TO HOME
    ' ========================================================
    Private Sub btn_HomeAll_Click(sender As Object, e As EventArgs) Handles btn_HomeAll.Click
        tb_Base.Value = 90
        tb_Arm.Value = 90
        tb_Grip.Value = 90
        UpdateAngleLabels()
        SendHomeCommand()
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        DisconnectPort()
    End Sub
End Class

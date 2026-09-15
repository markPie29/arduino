<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.tmr_Throttle = New System.Windows.Forms.Timer(Me.components)
        Me.pnl_Header = New System.Windows.Forms.Panel()
        Me.lbl_SubTitle = New System.Windows.Forms.Label()
        Me.lbl_Title = New System.Windows.Forms.Label()
        Me.gb_Connection = New System.Windows.Forms.GroupBox()
        Me.lbl_Baud = New System.Windows.Forms.Label()
        Me.cb_Baud = New System.Windows.Forms.ComboBox()
        Me.lbl_Status = New System.Windows.Forms.Label()
        Me.btn_Connect = New System.Windows.Forms.Button()
        Me.btn_Refresh = New System.Windows.Forms.Button()
        Me.cb_Ports = New System.Windows.Forms.ComboBox()
        Me.lbl_PortSelect = New System.Windows.Forms.Label()
        Me.gb_Base = New System.Windows.Forms.GroupBox()
        Me.btn_BaseCenter = New System.Windows.Forms.Button()
        Me.btn_BaseInc = New System.Windows.Forms.Button()
        Me.btn_BaseDec = New System.Windows.Forms.Button()
        Me.lbl_BaseAngle = New System.Windows.Forms.Label()
        Me.tb_Base = New System.Windows.Forms.TrackBar()
        Me.gb_Keyboard = New System.Windows.Forms.GroupBox()
        Me.lbl_KeyBase = New System.Windows.Forms.Label()
        Me.lbl_KeyShoulder = New System.Windows.Forms.Label()
        Me.lbl_KeyGripClose = New System.Windows.Forms.Label()
        Me.lbl_KeyGripOpen = New System.Windows.Forms.Label()
        Me.gb_Shoulder = New System.Windows.Forms.GroupBox()
        Me.btn_ShoulderCenter = New System.Windows.Forms.Button()
        Me.btn_ShoulderInc = New System.Windows.Forms.Button()
        Me.btn_ShoulderDec = New System.Windows.Forms.Button()
        Me.lbl_ShoulderAngle = New System.Windows.Forms.Label()
        Me.tb_Shoulder = New System.Windows.Forms.TrackBar()
        Me.gb_Grip = New System.Windows.Forms.GroupBox()
        Me.chk_GripEnable = New System.Windows.Forms.CheckBox()
        Me.btn_GripClose = New System.Windows.Forms.Button()
        Me.btn_GripMid = New System.Windows.Forms.Button()
        Me.btn_GripOpen = New System.Windows.Forms.Button()
        Me.lbl_GripAngle = New System.Windows.Forms.Label()
        Me.tb_Grip = New System.Windows.Forms.TrackBar()
        Me.btn_HomeAll = New System.Windows.Forms.Button()
        Me.btn_RelaxAll = New System.Windows.Forms.Button()
        Me.gb_Console = New System.Windows.Forms.GroupBox()
        Me.lbl_PinsInfo = New System.Windows.Forms.Label()
        Me.chk_AutoScroll = New System.Windows.Forms.CheckBox()
        Me.btn_ClearLog = New System.Windows.Forms.Button()
        Me.btn_QueryStatus = New System.Windows.Forms.Button()
        Me.btn_Ping = New System.Windows.Forms.Button()
        Me.txt_Log = New System.Windows.Forms.TextBox()
        Me.pnl_Header.SuspendLayout()
        Me.gb_Connection.SuspendLayout()
        Me.gb_Base.SuspendLayout()
        CType(Me.tb_Base, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb_Keyboard.SuspendLayout()
        Me.gb_Shoulder.SuspendLayout()
        CType(Me.tb_Shoulder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb_Grip.SuspendLayout()
        CType(Me.tb_Grip, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb_Console.SuspendLayout()
        Me.SuspendLayout()
        '
        'tmr_Throttle
        '
        Me.tmr_Throttle.Interval = 35
        '
        'pnl_Header
        '
        Me.pnl_Header.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(47, Byte), Integer))
        Me.pnl_Header.Controls.Add(Me.lbl_SubTitle)
        Me.pnl_Header.Controls.Add(Me.lbl_Title)
        Me.pnl_Header.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnl_Header.Location = New System.Drawing.Point(0, 0)
        Me.pnl_Header.Name = "pnl_Header"
        Me.pnl_Header.Size = New System.Drawing.Size(1034, 70)
        Me.pnl_Header.TabIndex = 0
        '
        'lbl_SubTitle
        '
        Me.lbl_SubTitle.AutoSize = True
        Me.lbl_SubTitle.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_SubTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(178, Byte), Integer), CType(CType(190, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.lbl_SubTitle.Location = New System.Drawing.Point(22, 42)
        Me.lbl_SubTitle.Name = "lbl_SubTitle"
        Me.lbl_SubTitle.Size = New System.Drawing.Size(433, 15)
        Me.lbl_SubTitle.TabIndex = 1
        Me.lbl_SubTitle.Text = "Real-Time Motion Control & Telemetry (Base D3, Shoulder D6, Gripper D9)"
        '
        'lbl_Title
        '
        Me.lbl_Title.AutoSize = True
        Me.lbl_Title.Font = New System.Drawing.Font("Segoe UI Semibold", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Title.ForeColor = System.Drawing.Color.White
        Me.lbl_Title.Location = New System.Drawing.Point(20, 10)
        Me.lbl_Title.Name = "lbl_Title"
        Me.lbl_Title.Size = New System.Drawing.Size(437, 30)
        Me.lbl_Title.TabIndex = 0
        Me.lbl_Title.Text = "🦾 Arduino 3-DOF Robotic Arm Dashboard"
        '
        'gb_Connection
        '
        Me.gb_Connection.Controls.Add(Me.lbl_Baud)
        Me.gb_Connection.Controls.Add(Me.cb_Baud)
        Me.gb_Connection.Controls.Add(Me.lbl_Status)
        Me.gb_Connection.Controls.Add(Me.btn_Connect)
        Me.gb_Connection.Controls.Add(Me.btn_Refresh)
        Me.gb_Connection.Controls.Add(Me.cb_Ports)
        Me.gb_Connection.Controls.Add(Me.lbl_PortSelect)
        Me.gb_Connection.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb_Connection.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(43, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.gb_Connection.Location = New System.Drawing.Point(20, 78)
        Me.gb_Connection.Name = "gb_Connection"
        Me.gb_Connection.Size = New System.Drawing.Size(490, 82)
        Me.gb_Connection.TabIndex = 1
        Me.gb_Connection.TabStop = False
        Me.gb_Connection.Text = "Serial Connection (CH340 / USB UART)"
        '
        'lbl_Baud
        '
        Me.lbl_Baud.AutoSize = True
        Me.lbl_Baud.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Baud.Location = New System.Drawing.Point(175, 26)
        Me.lbl_Baud.Name = "lbl_Baud"
        Me.lbl_Baud.Size = New System.Drawing.Size(37, 15)
        Me.lbl_Baud.TabIndex = 6
        Me.lbl_Baud.Text = "Baud:"
        '
        'cb_Baud
        '
        Me.cb_Baud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Baud.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_Baud.FormattingEnabled = True
        Me.cb_Baud.Items.AddRange(New Object() {"115200", "57600", "9600"})
        Me.cb_Baud.Location = New System.Drawing.Point(216, 23)
        Me.cb_Baud.Name = "cb_Baud"
        Me.cb_Baud.Size = New System.Drawing.Size(78, 23)
        Me.cb_Baud.TabIndex = 5
        '
        'lbl_Status
        '
        Me.lbl_Status.AutoSize = True
        Me.lbl_Status.Font = New System.Drawing.Font("Segoe UI Bold", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Status.ForeColor = System.Drawing.Color.Firebrick
        Me.lbl_Status.Location = New System.Drawing.Point(12, 55)
        Me.lbl_Status.Name = "lbl_Status"
        Me.lbl_Status.Size = New System.Drawing.Size(107, 17)
        Me.lbl_Status.TabIndex = 4
        Me.lbl_Status.Text = "● Disconnected"
        '
        'btn_Connect
        '
        Me.btn_Connect.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(117, Byte), Integer), CType(CType(182, Byte), Integer))
        Me.btn_Connect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Connect.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Connect.ForeColor = System.Drawing.Color.White
        Me.btn_Connect.Location = New System.Drawing.Point(385, 20)
        Me.btn_Connect.Name = "btn_Connect"
        Me.btn_Connect.Size = New System.Drawing.Size(95, 28)
        Me.btn_Connect.TabIndex = 3
        Me.btn_Connect.Text = "Connect"
        Me.btn_Connect.UseVisualStyleBackColor = False
        '
        'btn_Refresh
        '
        Me.btn_Refresh.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.btn_Refresh.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btn_Refresh.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Refresh.Location = New System.Drawing.Point(302, 20)
        Me.btn_Refresh.Name = "btn_Refresh"
        Me.btn_Refresh.Size = New System.Drawing.Size(75, 28)
        Me.btn_Refresh.TabIndex = 2
        Me.btn_Refresh.Text = "🔄 Scan"
        Me.btn_Refresh.UseVisualStyleBackColor = False
        '
        'cb_Ports
        '
        Me.cb_Ports.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Ports.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_Ports.FormattingEnabled = True
        Me.cb_Ports.Location = New System.Drawing.Point(52, 23)
        Me.cb_Ports.Name = "cb_Ports"
        Me.cb_Ports.Size = New System.Drawing.Size(115, 23)
        Me.cb_Ports.TabIndex = 1
        '
        'lbl_PortSelect
        '
        Me.lbl_PortSelect.AutoSize = True
        Me.lbl_PortSelect.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_PortSelect.Location = New System.Drawing.Point(12, 26)
        Me.lbl_PortSelect.Name = "lbl_PortSelect"
        Me.lbl_PortSelect.Size = New System.Drawing.Size(32, 15)
        Me.lbl_PortSelect.TabIndex = 0
        Me.lbl_PortSelect.Text = "Port:"
        '
        'gb_Base
        '
        Me.gb_Base.Controls.Add(Me.btn_BaseCenter)
        Me.gb_Base.Controls.Add(Me.btn_BaseInc)
        Me.gb_Base.Controls.Add(Me.btn_BaseDec)
        Me.gb_Base.Controls.Add(Me.lbl_BaseAngle)
        Me.gb_Base.Controls.Add(Me.tb_Base)
        Me.gb_Base.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb_Base.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(43, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.gb_Base.Location = New System.Drawing.Point(20, 168)
        Me.gb_Base.Name = "gb_Base"
        Me.gb_Base.Size = New System.Drawing.Size(490, 92)
        Me.gb_Base.TabIndex = 2
        Me.gb_Base.TabStop = False
        Me.gb_Base.Text = "Base Rotation (Servo X - Pin D3) [Center: 90°]"
        '
        'btn_BaseCenter
        '
        Me.btn_BaseCenter.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_BaseCenter.Location = New System.Drawing.Point(395, 55)
        Me.btn_BaseCenter.Name = "btn_BaseCenter"
        Me.btn_BaseCenter.Size = New System.Drawing.Size(82, 26)
        Me.btn_BaseCenter.TabIndex = 4
        Me.btn_BaseCenter.Text = "Center (90°)"
        Me.btn_BaseCenter.UseVisualStyleBackColor = True
        '
        'btn_BaseInc
        '
        Me.btn_BaseInc.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_BaseInc.Location = New System.Drawing.Point(342, 55)
        Me.btn_BaseInc.Name = "btn_BaseInc"
        Me.btn_BaseInc.Size = New System.Drawing.Size(48, 26)
        Me.btn_BaseInc.TabIndex = 3
        Me.btn_BaseInc.Text = "+5°"
        Me.btn_BaseInc.UseVisualStyleBackColor = True
        '
        'btn_BaseDec
        '
        Me.btn_BaseDec.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_BaseDec.Location = New System.Drawing.Point(288, 55)
        Me.btn_BaseDec.Name = "btn_BaseDec"
        Me.btn_BaseDec.Size = New System.Drawing.Size(48, 26)
        Me.btn_BaseDec.TabIndex = 2
        Me.btn_BaseDec.Text = "-5°"
        Me.btn_BaseDec.UseVisualStyleBackColor = True
        '
        'lbl_BaseAngle
        '
        Me.lbl_BaseAngle.Font = New System.Drawing.Font("Segoe UI Bold", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_BaseAngle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(117, Byte), Integer), CType(CType(182, Byte), Integer))
        Me.lbl_BaseAngle.Location = New System.Drawing.Point(395, 16)
        Me.lbl_BaseAngle.Name = "lbl_BaseAngle"
        Me.lbl_BaseAngle.Size = New System.Drawing.Size(82, 32)
        Me.lbl_BaseAngle.TabIndex = 1
        Me.lbl_BaseAngle.Text = "90°"
        Me.lbl_BaseAngle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tb_Base
        '
        Me.tb_Base.LargeChange = 15
        Me.tb_Base.Location = New System.Drawing.Point(12, 22)
        Me.tb_Base.Maximum = 180
        Me.tb_Base.Name = "tb_Base"
        Me.tb_Base.Size = New System.Drawing.Size(370, 45)
        Me.tb_Base.SmallChange = 5
        Me.tb_Base.TabIndex = 0
        Me.tb_Base.TickFrequency = 15
        Me.tb_Base.Value = 90
        '
        'gb_Shoulder
        '
        Me.gb_Shoulder.Controls.Add(Me.btn_ShoulderCenter)
        Me.gb_Shoulder.Controls.Add(Me.btn_ShoulderInc)
        Me.gb_Shoulder.Controls.Add(Me.btn_ShoulderDec)
        Me.gb_Shoulder.Controls.Add(Me.lbl_ShoulderAngle)
        Me.gb_Shoulder.Controls.Add(Me.tb_Shoulder)
        Me.gb_Shoulder.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb_Shoulder.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(43, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.gb_Shoulder.Location = New System.Drawing.Point(20, 268)
        Me.gb_Shoulder.Name = "gb_Shoulder"
        Me.gb_Shoulder.Size = New System.Drawing.Size(490, 92)
        Me.gb_Shoulder.TabIndex = 3
        Me.gb_Shoulder.TabStop = False
        Me.gb_Shoulder.Text = "Shoulder Joint (Servo S - Pin D6) [Center: 90°]"
        '
        'btn_ShoulderCenter
        '
        Me.btn_ShoulderCenter.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ShoulderCenter.Location = New System.Drawing.Point(395, 55)
        Me.btn_ShoulderCenter.Name = "btn_ShoulderCenter"
        Me.btn_ShoulderCenter.Size = New System.Drawing.Size(82, 26)
        Me.btn_ShoulderCenter.TabIndex = 4
        Me.btn_ShoulderCenter.Text = "Center (90°)"
        Me.btn_ShoulderCenter.UseVisualStyleBackColor = True
        '
        'btn_ShoulderInc
        '
        Me.btn_ShoulderInc.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ShoulderInc.Location = New System.Drawing.Point(342, 55)
        Me.btn_ShoulderInc.Name = "btn_ShoulderInc"
        Me.btn_ShoulderInc.Size = New System.Drawing.Size(48, 26)
        Me.btn_ShoulderInc.TabIndex = 3
        Me.btn_ShoulderInc.Text = "+5°"
        Me.btn_ShoulderInc.UseVisualStyleBackColor = True
        '
        'btn_ShoulderDec
        '
        Me.btn_ShoulderDec.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ShoulderDec.Location = New System.Drawing.Point(288, 55)
        Me.btn_ShoulderDec.Name = "btn_ShoulderDec"
        Me.btn_ShoulderDec.Size = New System.Drawing.Size(48, 26)
        Me.btn_ShoulderDec.TabIndex = 2
        Me.btn_ShoulderDec.Text = "-5°"
        Me.btn_ShoulderDec.UseVisualStyleBackColor = True
        '
        'lbl_ShoulderAngle
        '
        Me.lbl_ShoulderAngle.Font = New System.Drawing.Font("Segoe UI Bold", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ShoulderAngle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(117, Byte), Integer), CType(CType(182, Byte), Integer))
        Me.lbl_ShoulderAngle.Location = New System.Drawing.Point(395, 16)
        Me.lbl_ShoulderAngle.Name = "lbl_ShoulderAngle"
        Me.lbl_ShoulderAngle.Size = New System.Drawing.Size(82, 32)
        Me.lbl_ShoulderAngle.TabIndex = 1
        Me.lbl_ShoulderAngle.Text = "90°"
        Me.lbl_ShoulderAngle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tb_Shoulder
        '
        Me.tb_Shoulder.LargeChange = 15
        Me.tb_Shoulder.Location = New System.Drawing.Point(12, 22)
        Me.tb_Shoulder.Maximum = 180
        Me.tb_Shoulder.Name = "tb_Shoulder"
        Me.tb_Shoulder.Size = New System.Drawing.Size(370, 45)
        Me.tb_Shoulder.SmallChange = 5
        Me.tb_Shoulder.TabIndex = 0
        Me.tb_Shoulder.TickFrequency = 15
        Me.tb_Shoulder.Value = 90
        '
        'gb_Grip
        '
        Me.gb_Grip.Controls.Add(Me.chk_GripEnable)
        Me.gb_Grip.Controls.Add(Me.btn_GripClose)
        Me.gb_Grip.Controls.Add(Me.btn_GripMid)
        Me.gb_Grip.Controls.Add(Me.btn_GripOpen)
        Me.gb_Grip.Controls.Add(Me.lbl_GripAngle)
        Me.gb_Grip.Controls.Add(Me.tb_Grip)
        Me.gb_Grip.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb_Grip.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(43, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.gb_Grip.Location = New System.Drawing.Point(20, 368)
        Me.gb_Grip.Name = "gb_Grip"
        Me.gb_Grip.Size = New System.Drawing.Size(490, 100)
        Me.gb_Grip.TabIndex = 4
        Me.gb_Grip.TabStop = False
        Me.gb_Grip.Text = "Gripper / Claw (Servo G - Pin D9) [0°-180° | 90° Center]"
        '
        'gb_Keyboard
        '
        Me.gb_Keyboard.Controls.Add(Me.lbl_KeyGripOpen)
        Me.gb_Keyboard.Controls.Add(Me.lbl_KeyGripClose)
        Me.gb_Keyboard.Controls.Add(Me.lbl_KeyShoulder)
        Me.gb_Keyboard.Controls.Add(Me.lbl_KeyBase)
        Me.gb_Keyboard.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb_Keyboard.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(43, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.gb_Keyboard.Location = New System.Drawing.Point(20, 476)
        Me.gb_Keyboard.Name = "gb_Keyboard"
        Me.gb_Keyboard.Size = New System.Drawing.Size(490, 93)
        Me.gb_Keyboard.TabIndex = 5
        Me.gb_Keyboard.TabStop = False
        Me.gb_Keyboard.Text = "⌨️ Keyboard Controls & Shortcuts"
        '
        'lbl_KeyBase
        '
        Me.lbl_KeyBase.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_KeyBase.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(117, Byte), Integer), CType(CType(182, Byte), Integer))
        Me.lbl_KeyBase.Location = New System.Drawing.Point(14, 25)
        Me.lbl_KeyBase.Name = "lbl_KeyBase"
        Me.lbl_KeyBase.Size = New System.Drawing.Size(225, 26)
        Me.lbl_KeyBase.TabIndex = 0
        Me.lbl_KeyBase.Text = "◀ / ▶  Left / Right  ➔  Base Rotate"
        '
        'lbl_KeyShoulder
        '
        Me.lbl_KeyShoulder.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_KeyShoulder.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(117, Byte), Integer), CType(CType(182, Byte), Integer))
        Me.lbl_KeyShoulder.Location = New System.Drawing.Point(245, 25)
        Me.lbl_KeyShoulder.Name = "lbl_KeyShoulder"
        Me.lbl_KeyShoulder.Size = New System.Drawing.Size(235, 26)
        Me.lbl_KeyShoulder.TabIndex = 1
        Me.lbl_KeyShoulder.Text = "▲ / ▼  Up / Down  ➔  Shoulder Tilt"
        '
        'lbl_KeyGripClose
        '
        Me.lbl_KeyGripClose.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_KeyGripClose.ForeColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.lbl_KeyGripClose.Location = New System.Drawing.Point(14, 55)
        Me.lbl_KeyGripClose.Name = "lbl_KeyGripClose"
        Me.lbl_KeyGripClose.Size = New System.Drawing.Size(225, 26)
        Me.lbl_KeyGripClose.TabIndex = 2
        Me.lbl_KeyGripClose.Text = "↵ Enter  ➔  Close Gripper (180°)"
        '
        'lbl_KeyGripOpen
        '
        Me.lbl_KeyGripOpen.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_KeyGripOpen.ForeColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.lbl_KeyGripOpen.Location = New System.Drawing.Point(245, 55)
        Me.lbl_KeyGripOpen.Name = "lbl_KeyGripOpen"
        Me.lbl_KeyGripOpen.Size = New System.Drawing.Size(235, 26)
        Me.lbl_KeyGripOpen.TabIndex = 3
        Me.lbl_KeyGripOpen.Text = "⇧ Right Shift  ➔  Open Gripper (90°)"
        '
        'chk_GripEnable
        '
        Me.chk_GripEnable.AutoSize = True
        Me.chk_GripEnable.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_GripEnable.ForeColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.chk_GripEnable.Location = New System.Drawing.Point(300, 0)
        Me.chk_GripEnable.Name = "chk_GripEnable"
        Me.chk_GripEnable.Size = New System.Drawing.Size(175, 19)
        Me.chk_GripEnable.TabIndex = 5
        Me.chk_GripEnable.Text = "🔌 Enable Gripper (Pin D9)"
        Me.chk_GripEnable.UseVisualStyleBackColor = True
        '
        'btn_GripClose
        '
        Me.btn_GripClose.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_GripClose.Location = New System.Drawing.Point(395, 62)
        Me.btn_GripClose.Name = "btn_GripClose"
        Me.btn_GripClose.Size = New System.Drawing.Size(82, 26)
        Me.btn_GripClose.TabIndex = 4
        Me.btn_GripClose.Text = "Close (180°)"
        Me.btn_GripClose.UseVisualStyleBackColor = True
        '
        'btn_GripMid
        '
        Me.btn_GripMid.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_GripMid.Location = New System.Drawing.Point(305, 62)
        Me.btn_GripMid.Name = "btn_GripMid"
        Me.btn_GripMid.Size = New System.Drawing.Size(85, 26)
        Me.btn_GripMid.TabIndex = 3
        Me.btn_GripMid.Text = "Half (135°)"
        Me.btn_GripMid.UseVisualStyleBackColor = True
        '
        'btn_GripOpen
        '
        Me.btn_GripOpen.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_GripOpen.Location = New System.Drawing.Point(218, 62)
        Me.btn_GripOpen.Name = "btn_GripOpen"
        Me.btn_GripOpen.Size = New System.Drawing.Size(82, 26)
        Me.btn_GripOpen.TabIndex = 2
        Me.btn_GripOpen.Text = "Center (90°)"
        Me.btn_GripOpen.UseVisualStyleBackColor = True
        '
        'lbl_GripAngle
        '
        Me.lbl_GripAngle.Font = New System.Drawing.Font("Segoe UI Bold", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_GripAngle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(117, Byte), Integer), CType(CType(182, Byte), Integer))
        Me.lbl_GripAngle.Location = New System.Drawing.Point(375, 20)
        Me.lbl_GripAngle.Name = "lbl_GripAngle"
        Me.lbl_GripAngle.Size = New System.Drawing.Size(105, 32)
        Me.lbl_GripAngle.TabIndex = 1
        Me.lbl_GripAngle.Text = "90°"
        Me.lbl_GripAngle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tb_Grip
        '
        Me.tb_Grip.LargeChange = 15
        Me.tb_Grip.Location = New System.Drawing.Point(12, 26)
        Me.tb_Grip.Maximum = 180
        Me.tb_Grip.Minimum = 0
        Me.tb_Grip.Name = "tb_Grip"
        Me.tb_Grip.Size = New System.Drawing.Size(360, 45)
        Me.tb_Grip.SmallChange = 5
        Me.tb_Grip.TabIndex = 0
        Me.tb_Grip.TickFrequency = 15
        Me.tb_Grip.Value = 90
        '
        'btn_HomeAll
        '
        Me.btn_HomeAll.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btn_HomeAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_HomeAll.Font = New System.Drawing.Font("Segoe UI Bold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_HomeAll.ForeColor = System.Drawing.Color.White
        Me.btn_HomeAll.Location = New System.Drawing.Point(20, 580)
        Me.btn_HomeAll.Name = "btn_HomeAll"
        Me.btn_HomeAll.Size = New System.Drawing.Size(240, 40)
        Me.btn_HomeAll.TabIndex = 6
        Me.btn_HomeAll.Text = "🏠 Home All (All 90° Center)"
        Me.btn_HomeAll.UseVisualStyleBackColor = False
        '
        'btn_RelaxAll
        '
        Me.btn_RelaxAll.BackColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.btn_RelaxAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_RelaxAll.Font = New System.Drawing.Font("Segoe UI Bold", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_RelaxAll.ForeColor = System.Drawing.Color.White
        Me.btn_RelaxAll.Location = New System.Drawing.Point(270, 580)
        Me.btn_RelaxAll.Name = "btn_RelaxAll"
        Me.btn_RelaxAll.Size = New System.Drawing.Size(240, 40)
        Me.btn_RelaxAll.TabIndex = 7
        Me.btn_RelaxAll.Text = "⚡ Relax / Cut Torque (Cool Down)"
        Me.btn_RelaxAll.UseVisualStyleBackColor = False
        '
        'gb_Console
        '
        Me.gb_Console.Controls.Add(Me.lbl_PinsInfo)
        Me.gb_Console.Controls.Add(Me.chk_AutoScroll)
        Me.gb_Console.Controls.Add(Me.btn_ClearLog)
        Me.gb_Console.Controls.Add(Me.btn_QueryStatus)
        Me.gb_Console.Controls.Add(Me.btn_Ping)
        Me.gb_Console.Controls.Add(Me.txt_Log)
        Me.gb_Console.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb_Console.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(43, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.gb_Console.Location = New System.Drawing.Point(525, 78)
        Me.gb_Console.Name = "gb_Console"
        Me.gb_Console.Size = New System.Drawing.Size(485, 542)
        Me.gb_Console.TabIndex = 8
        Me.gb_Console.TabStop = False
        Me.gb_Console.Text = "Live Serial Telemetry & Diagnostics"
        '
        'lbl_PinsInfo
        '
        Me.lbl_PinsInfo.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.lbl_PinsInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl_PinsInfo.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_PinsInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lbl_PinsInfo.Location = New System.Drawing.Point(15, 498)
        Me.lbl_PinsInfo.Name = "lbl_PinsInfo"
        Me.lbl_PinsInfo.Size = New System.Drawing.Size(455, 34)
        Me.lbl_PinsInfo.TabIndex = 5
        Me.lbl_PinsInfo.Text = "Hardware: D3 (Base) | D5 (Arm Elevation) | D6 (Shoulder) | D9 (Gripper)" & vbCrLf & "💡 All 4 servos calibrated to 90° center. External 5V 2A-3A power recommended."
        Me.lbl_PinsInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chk_AutoScroll
        '
        Me.chk_AutoScroll.AutoSize = True
        Me.chk_AutoScroll.Checked = True
        Me.chk_AutoScroll.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_AutoScroll.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_AutoScroll.Location = New System.Drawing.Point(260, 26)
        Me.chk_AutoScroll.Name = "chk_AutoScroll"
        Me.chk_AutoScroll.Size = New System.Drawing.Size(83, 19)
        Me.chk_AutoScroll.TabIndex = 4
        Me.chk_AutoScroll.Text = "Auto-scroll"
        Me.chk_AutoScroll.UseVisualStyleBackColor = True
        '
        'btn_ClearLog
        '
        Me.btn_ClearLog.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ClearLog.Location = New System.Drawing.Point(395, 22)
        Me.btn_ClearLog.Name = "btn_ClearLog"
        Me.btn_ClearLog.Size = New System.Drawing.Size(75, 26)
        Me.btn_ClearLog.TabIndex = 3
        Me.btn_ClearLog.Text = "Clear Log"
        Me.btn_ClearLog.UseVisualStyleBackColor = True
        '
        'btn_QueryStatus
        '
        Me.btn_QueryStatus.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_QueryStatus.Location = New System.Drawing.Point(115, 22)
        Me.btn_QueryStatus.Name = "btn_QueryStatus"
        Me.btn_QueryStatus.Size = New System.Drawing.Size(100, 26)
        Me.btn_QueryStatus.TabIndex = 2
        Me.btn_QueryStatus.Text = "Query Status"
        Me.btn_QueryStatus.UseVisualStyleBackColor = True
        '
        'btn_Ping
        '
        Me.btn_Ping.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Ping.Location = New System.Drawing.Point(15, 22)
        Me.btn_Ping.Name = "btn_Ping"
        Me.btn_Ping.Size = New System.Drawing.Size(90, 26)
        Me.btn_Ping.TabIndex = 1
        Me.btn_Ping.Text = "⚡ Test Ping"
        Me.btn_Ping.UseVisualStyleBackColor = True
        '
        'txt_Log
        '
        Me.txt_Log.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.txt_Log.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Log.ForeColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.txt_Log.Location = New System.Drawing.Point(15, 55)
        Me.txt_Log.Multiline = True
        Me.txt_Log.Name = "txt_Log"
        Me.txt_Log.ReadOnly = True
        Me.txt_Log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_Log.Size = New System.Drawing.Size(455, 435)
        Me.txt_Log.TabIndex = 0
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1034, 635)
        Me.Controls.Add(Me.gb_Console)
        Me.Controls.Add(Me.btn_RelaxAll)
        Me.Controls.Add(Me.btn_HomeAll)
        Me.Controls.Add(Me.gb_Keyboard)
        Me.Controls.Add(Me.gb_Grip)
        Me.Controls.Add(Me.gb_Shoulder)
        Me.Controls.Add(Me.gb_Base)
        Me.Controls.Add(Me.gb_Connection)
        Me.Controls.Add(Me.pnl_Header)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Arduino 3-DOF Robotic Arm Dashboard"
        Me.pnl_Header.ResumeLayout(False)
        Me.pnl_Header.PerformLayout()
        Me.gb_Connection.ResumeLayout(False)
        Me.gb_Connection.PerformLayout()
        Me.gb_Base.ResumeLayout(False)
        Me.gb_Base.PerformLayout()
        CType(Me.tb_Base, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb_Keyboard.ResumeLayout(False)
        Me.gb_Shoulder.ResumeLayout(False)
        Me.gb_Shoulder.PerformLayout()
        CType(Me.tb_Shoulder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb_Grip.ResumeLayout(False)
        Me.gb_Grip.PerformLayout()
        CType(Me.tb_Grip, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb_Console.ResumeLayout(False)
        Me.gb_Console.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SerialPort1 As IO.Ports.SerialPort
    Friend WithEvents tmr_Throttle As Timer
    Friend WithEvents pnl_Header As Panel
    Friend WithEvents lbl_Title As Label
    Friend WithEvents lbl_SubTitle As Label
    Friend WithEvents gb_Connection As GroupBox
    Friend WithEvents lbl_PortSelect As Label
    Friend WithEvents cb_Ports As ComboBox
    Friend WithEvents lbl_Baud As Label
    Friend WithEvents cb_Baud As ComboBox
    Friend WithEvents btn_Refresh As Button
    Friend WithEvents btn_Connect As Button
    Friend WithEvents lbl_Status As Label
    Friend WithEvents gb_Base As GroupBox
    Friend WithEvents tb_Base As TrackBar
    Friend WithEvents lbl_BaseAngle As Label
    Friend WithEvents btn_BaseDec As Button
    Friend WithEvents btn_BaseInc As Button
    Friend WithEvents btn_BaseCenter As Button
    Friend WithEvents gb_Keyboard As GroupBox
    Friend WithEvents lbl_KeyBase As Label
    Friend WithEvents lbl_KeyShoulder As Label
    Friend WithEvents lbl_KeyGripClose As Label
    Friend WithEvents lbl_KeyGripOpen As Label
    Friend WithEvents gb_Shoulder As GroupBox
    Friend WithEvents tb_Shoulder As TrackBar
    Friend WithEvents lbl_ShoulderAngle As Label
    Friend WithEvents btn_ShoulderDec As Button
    Friend WithEvents btn_ShoulderInc As Button
    Friend WithEvents btn_ShoulderCenter As Button
    Friend WithEvents gb_Grip As GroupBox
    Friend WithEvents chk_GripEnable As CheckBox
    Friend WithEvents tb_Grip As TrackBar
    Friend WithEvents lbl_GripAngle As Label
    Friend WithEvents btn_GripOpen As Button
    Friend WithEvents btn_GripMid As Button
    Friend WithEvents btn_GripClose As Button
    Friend WithEvents btn_HomeAll As Button
    Friend WithEvents btn_RelaxAll As Button
    Friend WithEvents gb_Console As GroupBox
    Friend WithEvents txt_Log As TextBox
    Friend WithEvents btn_Ping As Button
    Friend WithEvents btn_QueryStatus As Button
    Friend WithEvents btn_ClearLog As Button
    Friend WithEvents chk_AutoScroll As CheckBox
    Friend WithEvents lbl_PinsInfo As Label

End Class

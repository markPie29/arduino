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
        Me.pnl_Header = New System.Windows.Forms.Panel()
        Me.lbl_SubTitle = New System.Windows.Forms.Label()
        Me.lbl_Title = New System.Windows.Forms.Label()
        Me.gb_Connection = New System.Windows.Forms.GroupBox()
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
        Me.gb_Arm = New System.Windows.Forms.GroupBox()
        Me.btn_ArmCenter = New System.Windows.Forms.Button()
        Me.btn_ArmInc = New System.Windows.Forms.Button()
        Me.btn_ArmDec = New System.Windows.Forms.Button()
        Me.lbl_ArmAngle = New System.Windows.Forms.Label()
        Me.tb_Arm = New System.Windows.Forms.TrackBar()
        Me.gb_Grip = New System.Windows.Forms.GroupBox()
        Me.btn_GripClose = New System.Windows.Forms.Button()
        Me.btn_GripOpen = New System.Windows.Forms.Button()
        Me.btn_GripMin = New System.Windows.Forms.Button()
        Me.lbl_GripAngle = New System.Windows.Forms.Label()
        Me.tb_Grip = New System.Windows.Forms.TrackBar()
        Me.btn_HomeAll = New System.Windows.Forms.Button()
        Me.pnl_Header.SuspendLayout()
        Me.gb_Connection.SuspendLayout()
        Me.gb_Base.SuspendLayout()
        CType(Me.tb_Base, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb_Arm.SuspendLayout()
        CType(Me.tb_Arm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb_Grip.SuspendLayout()
        CType(Me.tb_Grip, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnl_Header
        '
        Me.pnl_Header.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(43, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.pnl_Header.Controls.Add(Me.lbl_SubTitle)
        Me.pnl_Header.Controls.Add(Me.lbl_Title)
        Me.pnl_Header.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnl_Header.Location = New System.Drawing.Point(0, 0)
        Me.pnl_Header.Name = "pnl_Header"
        Me.pnl_Header.Size = New System.Drawing.Size(684, 70)
        Me.pnl_Header.TabIndex = 0
        '
        'lbl_SubTitle
        '
        Me.lbl_SubTitle.AutoSize = True
        Me.lbl_SubTitle.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_SubTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(178, Byte), Integer), CType(CType(190, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.lbl_SubTitle.Location = New System.Drawing.Point(22, 42)
        Me.lbl_SubTitle.Name = "lbl_SubTitle"
        Me.lbl_SubTitle.Size = New System.Drawing.Size(262, 15)
        Me.lbl_SubTitle.TabIndex = 1
        Me.lbl_SubTitle.Text = "Real-Time 3-DOF Servo Motion Control (115200 Baud)"
        '
        'lbl_Title
        '
        Me.lbl_Title.AutoSize = True
        Me.lbl_Title.Font = New System.Drawing.Font("Segoe UI Semibold", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Title.ForeColor = System.Drawing.Color.White
        Me.lbl_Title.Location = New System.Drawing.Point(20, 10)
        Me.lbl_Title.Name = "lbl_Title"
        Me.lbl_Title.Size = New System.Drawing.Size(377, 30)
        Me.lbl_Title.TabIndex = 0
        Me.lbl_Title.Text = "🦾 Arduino Robotic Arm Controller"
        '
        'gb_Connection
        '
        Me.gb_Connection.Controls.Add(Me.lbl_Status)
        Me.gb_Connection.Controls.Add(Me.btn_Connect)
        Me.gb_Connection.Controls.Add(Me.btn_Refresh)
        Me.gb_Connection.Controls.Add(Me.cb_Ports)
        Me.gb_Connection.Controls.Add(Me.lbl_PortSelect)
        Me.gb_Connection.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb_Connection.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(43, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.gb_Connection.Location = New System.Drawing.Point(25, 85)
        Me.gb_Connection.Name = "gb_Connection"
        Me.gb_Connection.Size = New System.Drawing.Size(635, 75)
        Me.gb_Connection.TabIndex = 1
        Me.gb_Connection.TabStop = False
        Me.gb_Connection.Text = "Serial Connection"
        '
        'lbl_Status
        '
        Me.lbl_Status.AutoSize = True
        Me.lbl_Status.Font = New System.Drawing.Font("Segoe UI Bold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Status.ForeColor = System.Drawing.Color.Firebrick
        Me.lbl_Status.Location = New System.Drawing.Point(475, 34)
        Me.lbl_Status.Name = "lbl_Status"
        Me.lbl_Status.Size = New System.Drawing.Size(121, 19)
        Me.lbl_Status.TabIndex = 4
        Me.lbl_Status.Text = "● Disconnected"
        '
        'btn_Connect
        '
        Me.btn_Connect.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(117, Byte), Integer), CType(CType(182, Byte), Integer))
        Me.btn_Connect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Connect.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Connect.ForeColor = System.Drawing.Color.White
        Me.btn_Connect.Location = New System.Drawing.Point(340, 28)
        Me.btn_Connect.Name = "btn_Connect"
        Me.btn_Connect.Size = New System.Drawing.Size(115, 30)
        Me.btn_Connect.TabIndex = 3
        Me.btn_Connect.Text = "Connect"
        Me.btn_Connect.UseVisualStyleBackColor = False
        '
        'btn_Refresh
        '
        Me.btn_Refresh.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.btn_Refresh.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btn_Refresh.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Refresh.Location = New System.Drawing.Point(235, 28)
        Me.btn_Refresh.Name = "btn_Refresh"
        Me.btn_Refresh.Size = New System.Drawing.Size(90, 30)
        Me.btn_Refresh.TabIndex = 2
        Me.btn_Refresh.Text = "🔄 Refresh"
        Me.btn_Refresh.UseVisualStyleBackColor = False
        '
        'cb_Ports
        '
        Me.cb_Ports.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Ports.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_Ports.FormattingEnabled = True
        Me.cb_Ports.Location = New System.Drawing.Point(95, 31)
        Me.cb_Ports.Name = "cb_Ports"
        Me.cb_Ports.Size = New System.Drawing.Size(125, 25)
        Me.cb_Ports.TabIndex = 1
        '
        'lbl_PortSelect
        '
        Me.lbl_PortSelect.AutoSize = True
        Me.lbl_PortSelect.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_PortSelect.Location = New System.Drawing.Point(25, 34)
        Me.lbl_PortSelect.Name = "lbl_PortSelect"
        Me.lbl_PortSelect.Size = New System.Drawing.Size(66, 17)
        Me.lbl_PortSelect.TabIndex = 0
        Me.lbl_PortSelect.Text = "COM Port:"
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
        Me.gb_Base.Location = New System.Drawing.Point(25, 175)
        Me.gb_Base.Name = "gb_Base"
        Me.gb_Base.Size = New System.Drawing.Size(635, 110)
        Me.gb_Base.TabIndex = 2
        Me.gb_Base.TabStop = False
        Me.gb_Base.Text = "Base Rotation (Servo X - Pin 3)"
        '
        'btn_BaseCenter
        '
        Me.btn_BaseCenter.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_BaseCenter.Location = New System.Drawing.Point(525, 68)
        Me.btn_BaseCenter.Name = "btn_BaseCenter"
        Me.btn_BaseCenter.Size = New System.Drawing.Size(85, 28)
        Me.btn_BaseCenter.TabIndex = 4
        Me.btn_BaseCenter.Text = "Center (90°)"
        Me.btn_BaseCenter.UseVisualStyleBackColor = True
        '
        'btn_BaseInc
        '
        Me.btn_BaseInc.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_BaseInc.Location = New System.Drawing.Point(460, 68)
        Me.btn_BaseInc.Name = "btn_BaseInc"
        Me.btn_BaseInc.Size = New System.Drawing.Size(55, 28)
        Me.btn_BaseInc.TabIndex = 3
        Me.btn_BaseInc.Text = "+5°"
        Me.btn_BaseInc.UseVisualStyleBackColor = True
        '
        'btn_BaseDec
        '
        Me.btn_BaseDec.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_BaseDec.Location = New System.Drawing.Point(395, 68)
        Me.btn_BaseDec.Name = "btn_BaseDec"
        Me.btn_BaseDec.Size = New System.Drawing.Size(55, 28)
        Me.btn_BaseDec.TabIndex = 2
        Me.btn_BaseDec.Text = "-5°"
        Me.btn_BaseDec.UseVisualStyleBackColor = True
        '
        'lbl_BaseAngle
        '
        Me.lbl_BaseAngle.Font = New System.Drawing.Font("Segoe UI Bold", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_BaseAngle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(117, Byte), Integer), CType(CType(182, Byte), Integer))
        Me.lbl_BaseAngle.Location = New System.Drawing.Point(515, 20)
        Me.lbl_BaseAngle.Name = "lbl_BaseAngle"
        Me.lbl_BaseAngle.Size = New System.Drawing.Size(95, 40)
        Me.lbl_BaseAngle.TabIndex = 1
        Me.lbl_BaseAngle.Text = "90°"
        Me.lbl_BaseAngle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tb_Base
        '
        Me.tb_Base.LargeChange = 15
        Me.tb_Base.Location = New System.Drawing.Point(20, 30)
        Me.tb_Base.Maximum = 180
        Me.tb_Base.Name = "tb_Base"
        Me.tb_Base.Size = New System.Drawing.Size(480, 45)
        Me.tb_Base.SmallChange = 5
        Me.tb_Base.TabIndex = 0
        Me.tb_Base.TickFrequency = 15
        Me.tb_Base.Value = 90
        '
        'gb_Arm
        '
        Me.gb_Arm.Controls.Add(Me.btn_ArmCenter)
        Me.gb_Arm.Controls.Add(Me.btn_ArmInc)
        Me.gb_Arm.Controls.Add(Me.btn_ArmDec)
        Me.gb_Arm.Controls.Add(Me.lbl_ArmAngle)
        Me.gb_Arm.Controls.Add(Me.tb_Arm)
        Me.gb_Arm.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb_Arm.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(43, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.gb_Arm.Location = New System.Drawing.Point(25, 295)
        Me.gb_Arm.Name = "gb_Arm"
        Me.gb_Arm.Size = New System.Drawing.Size(635, 110)
        Me.gb_Arm.TabIndex = 3
        Me.gb_Arm.TabStop = False
        Me.gb_Arm.Text = "Arm Elevation (Servo Y - Pin 5)"
        '
        'btn_ArmCenter
        '
        Me.btn_ArmCenter.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ArmCenter.Location = New System.Drawing.Point(525, 68)
        Me.btn_ArmCenter.Name = "btn_ArmCenter"
        Me.btn_ArmCenter.Size = New System.Drawing.Size(85, 28)
        Me.btn_ArmCenter.TabIndex = 4
        Me.btn_ArmCenter.Text = "Center (90°)"
        Me.btn_ArmCenter.UseVisualStyleBackColor = True
        '
        'btn_ArmInc
        '
        Me.btn_ArmInc.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ArmInc.Location = New System.Drawing.Point(460, 68)
        Me.btn_ArmInc.Name = "btn_ArmInc"
        Me.btn_ArmInc.Size = New System.Drawing.Size(55, 28)
        Me.btn_ArmInc.TabIndex = 3
        Me.btn_ArmInc.Text = "+5°"
        Me.btn_ArmInc.UseVisualStyleBackColor = True
        '
        'btn_ArmDec
        '
        Me.btn_ArmDec.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ArmDec.Location = New System.Drawing.Point(395, 68)
        Me.btn_ArmDec.Name = "btn_ArmDec"
        Me.btn_ArmDec.Size = New System.Drawing.Size(55, 28)
        Me.btn_ArmDec.TabIndex = 2
        Me.btn_ArmDec.Text = "-5°"
        Me.btn_ArmDec.UseVisualStyleBackColor = True
        '
        'lbl_ArmAngle
        '
        Me.lbl_ArmAngle.Font = New System.Drawing.Font("Segoe UI Bold", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ArmAngle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(117, Byte), Integer), CType(CType(182, Byte), Integer))
        Me.lbl_ArmAngle.Location = New System.Drawing.Point(515, 20)
        Me.lbl_ArmAngle.Name = "lbl_ArmAngle"
        Me.lbl_ArmAngle.Size = New System.Drawing.Size(95, 40)
        Me.lbl_ArmAngle.TabIndex = 1
        Me.lbl_ArmAngle.Text = "90°"
        Me.lbl_ArmAngle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tb_Arm
        '
        Me.tb_Arm.LargeChange = 15
        Me.tb_Arm.Location = New System.Drawing.Point(20, 30)
        Me.tb_Arm.Maximum = 180
        Me.tb_Arm.Name = "tb_Arm"
        Me.tb_Arm.Size = New System.Drawing.Size(480, 45)
        Me.tb_Arm.SmallChange = 5
        Me.tb_Arm.TabIndex = 0
        Me.tb_Arm.TickFrequency = 15
        Me.tb_Arm.Value = 90
        '
        'gb_Grip
        '
        Me.gb_Grip.Controls.Add(Me.btn_GripClose)
        Me.gb_Grip.Controls.Add(Me.btn_GripOpen)
        Me.gb_Grip.Controls.Add(Me.btn_GripMin)
        Me.gb_Grip.Controls.Add(Me.lbl_GripAngle)
        Me.gb_Grip.Controls.Add(Me.tb_Grip)
        Me.gb_Grip.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb_Grip.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(43, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.gb_Grip.Location = New System.Drawing.Point(25, 415)
        Me.gb_Grip.Name = "gb_Grip"
        Me.gb_Grip.Size = New System.Drawing.Size(635, 110)
        Me.gb_Grip.TabIndex = 4
        Me.gb_Grip.TabStop = False
        Me.gb_Grip.Text = "Gripper Claw (Servo Grip - Pin 6)"
        '
        'btn_GripClose
        '
        Me.btn_GripClose.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_GripClose.Location = New System.Drawing.Point(520, 68)
        Me.btn_GripClose.Name = "btn_GripClose"
        Me.btn_GripClose.Size = New System.Drawing.Size(95, 28)
        Me.btn_GripClose.TabIndex = 4
        Me.btn_GripClose.Text = "Tighten (180°)"
        Me.btn_GripClose.UseVisualStyleBackColor = True
        '
        'btn_GripOpen
        '
        Me.btn_GripOpen.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_GripOpen.Location = New System.Drawing.Point(420, 68)
        Me.btn_GripOpen.Name = "btn_GripOpen"
        Me.btn_GripOpen.Size = New System.Drawing.Size(95, 28)
        Me.btn_GripOpen.TabIndex = 3
        Me.btn_GripOpen.Text = "Open (90°)"
        Me.btn_GripOpen.UseVisualStyleBackColor = True
        '
        'btn_GripMin
        '
        Me.btn_GripMin.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_GripMin.Location = New System.Drawing.Point(340, 68)
        Me.btn_GripMin.Name = "btn_GripMin"
        Me.btn_GripMin.Size = New System.Drawing.Size(75, 28)
        Me.btn_GripMin.TabIndex = 2
        Me.btn_GripMin.Text = "Min (0°)"
        Me.btn_GripMin.UseVisualStyleBackColor = True
        '
        'lbl_GripAngle
        '
        Me.lbl_GripAngle.Font = New System.Drawing.Font("Segoe UI Bold", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_GripAngle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(117, Byte), Integer), CType(CType(182, Byte), Integer))
        Me.lbl_GripAngle.Location = New System.Drawing.Point(515, 20)
        Me.lbl_GripAngle.Name = "lbl_GripAngle"
        Me.lbl_GripAngle.Size = New System.Drawing.Size(95, 40)
        Me.lbl_GripAngle.TabIndex = 1
        Me.lbl_GripAngle.Text = "90°"
        Me.lbl_GripAngle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tb_Grip
        '
        Me.tb_Grip.LargeChange = 15
        Me.tb_Grip.Location = New System.Drawing.Point(20, 30)
        Me.tb_Grip.Maximum = 180
        Me.tb_Grip.Name = "tb_Grip"
        Me.tb_Grip.Size = New System.Drawing.Size(480, 45)
        Me.tb_Grip.SmallChange = 5
        Me.tb_Grip.TabIndex = 0
        Me.tb_Grip.TickFrequency = 15
        Me.tb_Grip.Value = 90
        '
        'btn_HomeAll
        '
        Me.btn_HomeAll.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btn_HomeAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_HomeAll.Font = New System.Drawing.Font("Segoe UI Bold", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_HomeAll.ForeColor = System.Drawing.Color.White
        Me.btn_HomeAll.Location = New System.Drawing.Point(25, 540)
        Me.btn_HomeAll.Name = "btn_HomeAll"
        Me.btn_HomeAll.Size = New System.Drawing.Size(635, 42)
        Me.btn_HomeAll.TabIndex = 5
        Me.btn_HomeAll.Text = "🏠 Reset All to Home Position (90°, 90°, 90°)"
        Me.btn_HomeAll.UseVisualStyleBackColor = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(684, 605)
        Me.Controls.Add(Me.btn_HomeAll)
        Me.Controls.Add(Me.gb_Grip)
        Me.Controls.Add(Me.gb_Arm)
        Me.Controls.Add(Me.gb_Base)
        Me.Controls.Add(Me.gb_Connection)
        Me.Controls.Add(Me.pnl_Header)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Arduino 3-DOF Robotic Arm Controller"
        Me.pnl_Header.ResumeLayout(False)
        Me.pnl_Header.PerformLayout()
        Me.gb_Connection.ResumeLayout(False)
        Me.gb_Connection.PerformLayout()
        Me.gb_Base.ResumeLayout(False)
        Me.gb_Base.PerformLayout()
        CType(Me.tb_Base, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb_Arm.ResumeLayout(False)
        Me.gb_Arm.PerformLayout()
        CType(Me.tb_Arm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb_Grip.ResumeLayout(False)
        Me.gb_Grip.PerformLayout()
        CType(Me.tb_Grip, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SerialPort1 As IO.Ports.SerialPort
    Friend WithEvents pnl_Header As Panel
    Friend WithEvents lbl_Title As Label
    Friend WithEvents lbl_SubTitle As Label
    Friend WithEvents gb_Connection As GroupBox
    Friend WithEvents lbl_PortSelect As Label
    Friend WithEvents cb_Ports As ComboBox
    Friend WithEvents btn_Refresh As Button
    Friend WithEvents btn_Connect As Button
    Friend WithEvents lbl_Status As Label
    Friend WithEvents gb_Base As GroupBox
    Friend WithEvents tb_Base As TrackBar
    Friend WithEvents lbl_BaseAngle As Label
    Friend WithEvents btn_BaseDec As Button
    Friend WithEvents btn_BaseInc As Button
    Friend WithEvents btn_BaseCenter As Button
    Friend WithEvents gb_Arm As GroupBox
    Friend WithEvents tb_Arm As TrackBar
    Friend WithEvents lbl_ArmAngle As Label
    Friend WithEvents btn_ArmDec As Button
    Friend WithEvents btn_ArmInc As Button
    Friend WithEvents btn_ArmCenter As Button
    Friend WithEvents gb_Grip As GroupBox
    Friend WithEvents tb_Grip As TrackBar
    Friend WithEvents lbl_GripAngle As Label
    Friend WithEvents btn_GripMin As Button
    Friend WithEvents btn_GripOpen As Button
    Friend WithEvents btn_GripClose As Button
    Friend WithEvents btn_HomeAll As Button

End Class

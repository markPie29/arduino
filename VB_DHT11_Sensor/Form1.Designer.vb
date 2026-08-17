<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.pnlConnection = New System.Windows.Forms.Panel()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.btnConnect = New System.Windows.Forms.Button()
        Me.cbBaudRate = New System.Windows.Forms.ComboBox()
        Me.lblBaudRate = New System.Windows.Forms.Label()
        Me.cbPort = New System.Windows.Forms.ComboBox()
        Me.btnScan = New System.Windows.Forms.Button()
        Me.lblConnectionTitle = New System.Windows.Forms.Label()
        Me.pnlHumidity = New System.Windows.Forms.Panel()
        Me.lblHumidityTitle = New System.Windows.Forms.Label()
        Me.pnlTemperature = New System.Windows.Forms.Panel()
        Me.lblTemperatureTitle = New System.Windows.Forms.Label()
        Me.pnlHumidityChart = New System.Windows.Forms.Panel()
        Me.pnlTempChart = New System.Windows.Forms.Panel()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.tmrWatchdog = New System.Windows.Forms.Timer(Me.components)
        Me.pnlConnection.SuspendLayout()
        Me.pnlHumidity.SuspendLayout()
        Me.pnlTemperature.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlConnection
        '
        Me.pnlConnection.BackColor = System.Drawing.Color.White
        Me.pnlConnection.Controls.Add(Me.lblStatus)
        Me.pnlConnection.Controls.Add(Me.btnConnect)
        Me.pnlConnection.Controls.Add(Me.cbBaudRate)
        Me.pnlConnection.Controls.Add(Me.lblBaudRate)
        Me.pnlConnection.Controls.Add(Me.cbPort)
        Me.pnlConnection.Controls.Add(Me.btnScan)
        Me.pnlConnection.Controls.Add(Me.lblConnectionTitle)
        Me.pnlConnection.Location = New System.Drawing.Point(12, 12)
        Me.pnlConnection.Name = "pnlConnection"
        Me.pnlConnection.Size = New System.Drawing.Size(425, 150)
        Me.pnlConnection.TabIndex = 0
        '
        'lblStatus
        '
        Me.lblStatus.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblStatus.ForeColor = System.Drawing.Color.Gray
        Me.lblStatus.Location = New System.Drawing.Point(15, 128)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(395, 16)
        Me.lblStatus.TabIndex = 6
        Me.lblStatus.Text = "Status: Disconnected"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnConnect
        '
        Me.btnConnect.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConnect.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnConnect.ForeColor = System.Drawing.Color.White
        Me.btnConnect.Location = New System.Drawing.Point(15, 85)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(395, 38)
        Me.btnConnect.TabIndex = 5
        Me.btnConnect.Text = "Connect"
        Me.btnConnect.UseVisualStyleBackColor = False
        '
        'cbBaudRate
        '
        Me.cbBaudRate.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.cbBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbBaudRate.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.cbBaudRate.ForeColor = System.Drawing.Color.White
        Me.cbBaudRate.FormattingEnabled = True
        Me.cbBaudRate.Items.AddRange(New Object() {"9600", "19200", "38400", "57600", "115200"})
        Me.cbBaudRate.Location = New System.Drawing.Point(310, 48)
        Me.cbBaudRate.Name = "cbBaudRate"
        Me.cbBaudRate.Size = New System.Drawing.Size(100, 23)
        Me.cbBaudRate.TabIndex = 4
        '
        'lblBaudRate
        '
        Me.lblBaudRate.AutoSize = True
        Me.lblBaudRate.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblBaudRate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.lblBaudRate.Location = New System.Drawing.Point(230, 51)
        Me.lblBaudRate.Name = "lblBaudRate"
        Me.lblBaudRate.Size = New System.Drawing.Size(74, 15)
        Me.lblBaudRate.TabIndex = 3
        Me.lblBaudRate.Text = "Baud Rate :"
        '
        'cbPort
        '
        Me.cbPort.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.cbPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPort.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.cbPort.ForeColor = System.Drawing.Color.White
        Me.cbPort.FormattingEnabled = True
        Me.cbPort.Location = New System.Drawing.Point(120, 48)
        Me.cbPort.Name = "cbPort"
        Me.cbPort.Size = New System.Drawing.Size(100, 23)
        Me.cbPort.TabIndex = 2
        '
        'btnScan
        '
        Me.btnScan.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.btnScan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnScan.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnScan.ForeColor = System.Drawing.Color.White
        Me.btnScan.Location = New System.Drawing.Point(15, 45)
        Me.btnScan.Name = "btnScan"
        Me.btnScan.Size = New System.Drawing.Size(95, 28)
        Me.btnScan.TabIndex = 1
        Me.btnScan.Text = "Scan Port"
        Me.btnScan.UseVisualStyleBackColor = False
        '
        'lblConnectionTitle
        '
        Me.lblConnectionTitle.AutoSize = True
        Me.lblConnectionTitle.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblConnectionTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.lblConnectionTitle.Location = New System.Drawing.Point(152, 10)
        Me.lblConnectionTitle.Name = "lblConnectionTitle"
        Me.lblConnectionTitle.Size = New System.Drawing.Size(121, 28)
        Me.lblConnectionTitle.TabIndex = 0
        Me.lblConnectionTitle.Text = "Connection"
        '
        'pnlHumidity
        '
        Me.pnlHumidity.BackColor = System.Drawing.Color.White
        Me.pnlHumidity.Controls.Add(Me.lblHumidityTitle)
        Me.pnlHumidity.Location = New System.Drawing.Point(12, 172)
        Me.pnlHumidity.Name = "pnlHumidity"
        Me.pnlHumidity.Size = New System.Drawing.Size(205, 220)
        Me.pnlHumidity.TabIndex = 1
        '
        'lblHumidityTitle
        '
        Me.lblHumidityTitle.AutoSize = True
        Me.lblHumidityTitle.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblHumidityTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblHumidityTitle.Location = New System.Drawing.Point(52, 12)
        Me.lblHumidityTitle.Name = "lblHumidityTitle"
        Me.lblHumidityTitle.Size = New System.Drawing.Size(101, 28)
        Me.lblHumidityTitle.TabIndex = 0
        Me.lblHumidityTitle.Text = "Humidity"
        '
        'pnlTemperature
        '
        Me.pnlTemperature.BackColor = System.Drawing.Color.White
        Me.pnlTemperature.Controls.Add(Me.lblTemperatureTitle)
        Me.pnlTemperature.Location = New System.Drawing.Point(232, 172)
        Me.pnlTemperature.Name = "pnlTemperature"
        Me.pnlTemperature.Size = New System.Drawing.Size(205, 220)
        Me.pnlTemperature.TabIndex = 2
        '
        'lblTemperatureTitle
        '
        Me.lblTemperatureTitle.AutoSize = True
        Me.lblTemperatureTitle.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblTemperatureTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblTemperatureTitle.Location = New System.Drawing.Point(36, 12)
        Me.lblTemperatureTitle.Name = "lblTemperatureTitle"
        Me.lblTemperatureTitle.Size = New System.Drawing.Size(133, 28)
        Me.lblTemperatureTitle.TabIndex = 0
        Me.lblTemperatureTitle.Text = "Temperature"
        '
        'pnlHumidityChart
        '
        Me.pnlHumidityChart.BackColor = System.Drawing.Color.White
        Me.pnlHumidityChart.Location = New System.Drawing.Point(447, 12)
        Me.pnlHumidityChart.Name = "pnlHumidityChart"
        Me.pnlHumidityChart.Size = New System.Drawing.Size(445, 185)
        Me.pnlHumidityChart.TabIndex = 3
        '
        'pnlTempChart
        '
        Me.pnlTempChart.BackColor = System.Drawing.Color.White
        Me.pnlTempChart.Location = New System.Drawing.Point(447, 207)
        Me.pnlTempChart.Name = "pnlTempChart"
        Me.pnlTempChart.Size = New System.Drawing.Size(445, 185)
        Me.pnlTempChart.TabIndex = 4
        '
        'tmrWatchdog
        '
        Me.tmrWatchdog.Interval = 1000
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(904, 404)
        Me.Controls.Add(Me.pnlTempChart)
        Me.Controls.Add(Me.pnlHumidityChart)
        Me.Controls.Add(Me.pnlTemperature)
        Me.Controls.Add(Me.pnlHumidity)
        Me.Controls.Add(Me.pnlConnection)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "VB Net DHT11 Sensor"
        Me.pnlConnection.ResumeLayout(False)
        Me.pnlConnection.PerformLayout()
        Me.pnlHumidity.ResumeLayout(False)
        Me.pnlHumidity.PerformLayout()
        Me.pnlTemperature.ResumeLayout(False)
        Me.pnlTemperature.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlConnection As Panel
    Friend WithEvents lblConnectionTitle As Label
    Friend WithEvents btnScan As Button
    Friend WithEvents cbPort As ComboBox
    Friend WithEvents lblBaudRate As Label
    Friend WithEvents cbBaudRate As ComboBox
    Friend WithEvents btnConnect As Button
    Friend WithEvents lblStatus As Label
    Friend WithEvents pnlHumidity As Panel
    Friend WithEvents lblHumidityTitle As Label
    Friend WithEvents pnlTemperature As Panel
    Friend WithEvents lblTemperatureTitle As Label
    Friend WithEvents pnlHumidityChart As Panel
    Friend WithEvents pnlTempChart As Panel
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents tmrWatchdog As Timer
End Class

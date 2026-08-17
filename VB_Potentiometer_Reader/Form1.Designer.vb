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
        Me.btnScan = New System.Windows.Forms.Button()
        Me.btnConnect = New System.Windows.Forms.Button()
        Me.cbPort = New System.Windows.Forms.ComboBox()
        Me.cbBaudRate = New System.Windows.Forms.ComboBox()
        Me.lblBaudRate = New System.Windows.Forms.Label()
        Me.lblPotentiometerValue = New System.Windows.Forms.Label()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.SuspendLayout()
        '
        'btnScan
        '
        Me.btnScan.Location = New System.Drawing.Point(34, 38)
        Me.btnScan.Name = "btnScan"
        Me.btnScan.Size = New System.Drawing.Size(95, 34)
        Me.btnScan.TabIndex = 0
        Me.btnScan.Text = "Scan Port"
        Me.btnScan.UseVisualStyleBackColor = True
        '
        'btnConnect
        '
        Me.btnConnect.Location = New System.Drawing.Point(34, 91)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(95, 34)
        Me.btnConnect.TabIndex = 1
        Me.btnConnect.Text = "Connect"
        Me.btnConnect.UseVisualStyleBackColor = True
        '
        'cbPort
        '
        Me.cbPort.FormattingEnabled = True
        Me.cbPort.Location = New System.Drawing.Point(145, 45)
        Me.cbPort.Name = "cbPort"
        Me.cbPort.Size = New System.Drawing.Size(121, 23)
        Me.cbPort.TabIndex = 2
        '
        'cbBaudRate
        '
        Me.cbBaudRate.FormattingEnabled = True
        Me.cbBaudRate.Items.AddRange(New Object() {"9600", "14400", "19200", "38400", "57600", "115200"})
        Me.cbBaudRate.Location = New System.Drawing.Point(365, 45)
        Me.cbBaudRate.Name = "cbBaudRate"
        Me.cbBaudRate.Size = New System.Drawing.Size(121, 23)
        Me.cbBaudRate.TabIndex = 3
        Me.cbBaudRate.Text = "9600"
        '
        'lblBaudRate
        '
        Me.lblBaudRate.AutoSize = True
        Me.lblBaudRate.Location = New System.Drawing.Point(285, 48)
        Me.lblBaudRate.Name = "lblBaudRate"
        Me.lblBaudRate.Size = New System.Drawing.Size(66, 15)
        Me.lblBaudRate.TabIndex = 4
        Me.lblBaudRate.Text = "Baud Rate :"
        '
        'lblPotentiometerValue
        '
        Me.lblPotentiometerValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPotentiometerValue.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPotentiometerValue.Location = New System.Drawing.Point(54, 169)
        Me.lblPotentiometerValue.Name = "lblPotentiometerValue"
        Me.lblPotentiometerValue.Size = New System.Drawing.Size(432, 69)
        Me.lblPotentiometerValue.TabIndex = 5
        Me.lblPotentiometerValue.Text = "Potentiometer Value : 000"
        Me.lblPotentiometerValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(534, 281)
        Me.Controls.Add(Me.lblPotentiometerValue)
        Me.Controls.Add(Me.lblBaudRate)
        Me.Controls.Add(Me.cbBaudRate)
        Me.Controls.Add(Me.cbPort)
        Me.Controls.Add(Me.btnConnect)
        Me.Controls.Add(Me.btnScan)
        Me.Name = "Form1"
        Me.Text = "Serial"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnScan As System.Windows.Forms.Button
    Friend WithEvents btnConnect As System.Windows.Forms.Button
    Friend WithEvents cbPort As System.Windows.Forms.ComboBox
    Friend WithEvents cbBaudRate As System.Windows.Forms.ComboBox
    Friend WithEvents lblBaudRate As System.Windows.Forms.Label
    Friend WithEvents lblPotentiometerValue As System.Windows.Forms.Label
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
End Class

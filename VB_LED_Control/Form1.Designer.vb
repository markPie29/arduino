<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.CB_port = New System.Windows.Forms.ComboBox()
        Me.btn_On = New System.Windows.Forms.Button()
        Me.btn_Off = New System.Windows.Forms.Button()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'CB_port
        '
        Me.CB_port.FormattingEnabled = True
        Me.CB_port.Location = New System.Drawing.Point(82, 34)
        Me.CB_port.Name = "CB_port"
        Me.CB_port.Size = New System.Drawing.Size(121, 23)
        Me.CB_port.TabIndex = 0
        '
        'btn_On
        '
        Me.btn_On.Location = New System.Drawing.Point(40, 83)
        Me.btn_On.Name = "btn_On"
        Me.btn_On.Size = New System.Drawing.Size(75, 41)
        Me.btn_On.TabIndex = 1
        Me.btn_On.Text = "Turn ON"
        Me.btn_On.UseVisualStyleBackColor = True
        '
        'btn_Off
        '
        Me.btn_Off.Location = New System.Drawing.Point(145, 83)
        Me.btn_Off.Name = "btn_Off"
        Me.btn_Off.Size = New System.Drawing.Size(75, 41)
        Me.btn_Off.TabIndex = 2
        Me.btn_Off.Text = "Turn OFF"
        Me.btn_Off.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 15)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "COM Port:"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(262, 155)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_Off)
        Me.Controls.Add(Me.btn_On)
        Me.Controls.Add(Me.CB_port)
        Me.Name = "Form1"
        Me.Text = "Arduino LED Control"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CB_port As ComboBox
    Friend WithEvents btn_On As Button
    Friend WithEvents btn_Off As Button
    Friend WithEvents SerialPort1 As IO.Ports.SerialPort
    Friend WithEvents Label1 As Label
End Class

Imports System.IO.Ports

Public Class Form1
    Dim Myports As Array
    Delegate Sub SetTextCallback(ByVal [text] As String)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ScanPorts()
    End Sub

    Private Sub btnScan_Click(sender As Object, e As EventArgs) Handles btnScan.Click
        ScanPorts()
    End Sub

    Private Sub ScanPorts()
        Try
            cbPort.Items.Clear()
            Myports = IO.Ports.SerialPort.GetPortNames
            cbPort.Items.AddRange(Myports)
            If cbPort.Items.Count > 0 Then
                cbPort.SelectedItem = cbPort.Items(0)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Scanning Ports")
        End Try
    End Sub

    Private Sub btnConnect_Click(sender As Object, e As EventArgs) Handles btnConnect.Click
        If btnConnect.Text = "Connect" Then
            Try
                SerialPort1.PortName = cbPort.Text
                SerialPort1.BaudRate = CInt(cbBaudRate.Text)
                SerialPort1.Open()
                btnConnect.Text = "Disconnect"
                btnScan.Enabled = False
                cbPort.Enabled = False
                cbBaudRate.Enabled = False
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error Connecting")
            End Try
        Else
            Try
                SerialPort1.Close()
                btnConnect.Text = "Connect"
                btnScan.Enabled = True
                cbPort.Enabled = True
                cbBaudRate.Enabled = True
                lblPotentiometerValue.Text = "Potentiometer Value : 000"
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error Disconnecting")
            End Try
        End If
    End Sub

    Private Sub SerialPort1_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        Try
            Dim receivedData As String = SerialPort1.ReadLine().Trim()
            If Not String.IsNullOrEmpty(receivedData) Then
                Dim val As Integer
                If Integer.TryParse(receivedData, val) Then
                    Me.UpdateLabelText(val.ToString("D3"))
                End If
            End If
        Catch ex As Exception
            ' Ignore read timeout or thread abort errors
        End Try
    End Sub

    Private Sub UpdateLabelText(ByVal text As String)
        If Me.lblPotentiometerValue.InvokeRequired Then
            Dim d As New SetTextCallback(AddressOf UpdateLabelText)
            Me.Invoke(d, New Object() {text})
        Else
            Me.lblPotentiometerValue.Text = "Potentiometer Value : " & text
        End If
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If SerialPort1.IsOpen Then
            SerialPort1.Close()
        End If
    End Sub
End Class

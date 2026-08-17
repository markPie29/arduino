Public Class Form1
    Dim Myports As Array

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Myports = IO.Ports.SerialPort.GetPortNames
            CB_port.Items.AddRange(Myports)
            If CB_port.Items.Count > 0 Then
                CB_port.SelectedItem = CB_port.Items(0)
            End If
            SerialPort1.BaudRate = 9600
            SerialPort1.ReadTimeout = 2000
            SerialPort1.WriteTimeout = 2000
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Loading Ports")
        End Try
    End Sub

    Private Sub CB_port_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_port.SelectedIndexChanged
        Try
            SerialPort1.PortName = CB_port.Text
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Selecting Port")
        End Try
    End Sub

    Private Sub btn_On_Click(sender As Object, e As EventArgs) Handles btn_On.Click
        Try
            If Not SerialPort1.IsOpen Then
                SerialPort1.Open()
            End If
            SerialPort1.WriteLine("on")
            SerialPort1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Sending Data")
            If SerialPort1.IsOpen Then
                SerialPort1.Close()
            End If
        End Try
    End Sub

    Private Sub btn_Off_Click(sender As Object, e As EventArgs) Handles btn_Off.Click
        Try
            If Not SerialPort1.IsOpen Then
                SerialPort1.Open()
            End If
            SerialPort1.WriteLine("off")
            SerialPort1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Sending Data")
            If SerialPort1.IsOpen Then
                SerialPort1.Close()
            End If
        End Try
    End Sub
End Class

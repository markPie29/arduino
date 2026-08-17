Imports System.Drawing.Drawing2D
Imports System.IO.Ports

Public Class Form1
    Private Myports As Array
    Private lastDataTime As DateTime = DateTime.MinValue

    ' Current Sensor Readings
    Private currentHumidity As Double = 0
    Private currentTemperature As Double = 0

    ' Real-time Data History Queues for Charts (Max 30 data points)
    Private humidityHistory As New List(Of Double)()
    Private tempHistory As New List(Of Double)()
    Private Const MaxPoints As Integer = 30

    Delegate Sub UpdateDataCallback(ByVal humidity As String, ByVal temp As String)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Enable double buffering for smooth graphics rendering
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or ControlStyles.OptimizedDoubleBuffer, True)

        ScanPorts()
        If cbBaudRate.Items.Count > 0 Then
            cbBaudRate.SelectedIndex = 0 ' Default 9600
        End If

        ' Pre-fill chart initial flatline values as in screenshot
        For i As Integer = 0 To MaxPoints - 1
            humidityHistory.Add(0)
            tempHistory.Add(0)
        Next

        UpdateStatus("Status: Disconnected", Color.Gray)
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
                cbPort.SelectedIndex = 0
                UpdateStatus("Status: Ready to Connect", Color.DarkSlateGray)
            Else
                UpdateStatus("Status: No COM Ports Found", Color.Crimson)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Scanning Ports", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnConnect_Click(sender As Object, e As EventArgs) Handles btnConnect.Click
        If btnConnect.Text = "Connect" Then
            If cbPort.SelectedItem Is Nothing Then
                MessageBox.Show("Please select a COM Port first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim selectedPort As String = cbPort.Text

            Dim availablePorts As String() = SerialPort.GetPortNames()
            If Array.IndexOf(availablePorts, selectedPort) < 0 Then
                MessageBox.Show($"COM Port '{selectedPort}' is not detected. Please reconnect the Arduino USB cable.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ScanPorts()
                Return
            End If

            Try
                SerialPort1.PortName = selectedPort
                SerialPort1.BaudRate = CInt(cbBaudRate.Text)
                SerialPort1.Open()

                btnConnect.Text = "Disconnect"
                btnConnect.BackColor = Color.FromArgb(255, 89, 89) ' Red button when connected
                btnScan.Enabled = False
                cbPort.Enabled = False
                cbBaudRate.Enabled = False

                lastDataTime = DateTime.Now
                tmrWatchdog.Start()

                UpdateStatus("Status: Connected (Waiting for Data...)", Color.DarkOrange)
            Catch ex As Exception
                MessageBox.Show($"Could not open {selectedPort}. Make sure Arduino Serial Monitor is closed!" & vbCrLf & vbCrLf & "Error Details: " & ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                UpdateStatus("Status: Failed to Connect", Color.Red)
            End Try
        Else
            DisconnectArduino("Status: Disconnected", Color.Gray)
        End If
    End Sub

    Private Sub DisconnectArduino(ByVal statusMsg As String, ByVal statusColor As Color)
        Try
            tmrWatchdog.Stop()
            If SerialPort1.IsOpen Then
                SerialPort1.Close()
            End If
        Catch ex As Exception
        Finally
            btnConnect.Text = "Connect"
            btnConnect.BackColor = Color.FromArgb(46, 204, 113) ' Green button
            btnScan.Enabled = True
            cbPort.Enabled = True
            cbBaudRate.Enabled = True
            ResetUI()
            UpdateStatus(statusMsg, statusColor)
        End Try
    End Sub

    Private Sub ResetUI()
        currentHumidity = 0
        currentTemperature = 0
        pnlHumidity.Invalidate()
        pnlTemperature.Invalidate()
        pnlHumidityChart.Invalidate()
        pnlTempChart.Invalidate()
    End Sub

    Private Sub UpdateStatus(ByVal msg As String, ByVal col As Color)
        lblStatus.Text = msg
        lblStatus.ForeColor = col
    End Sub

    Private Sub SerialPort1_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        Try
            Dim rawLine As String = SerialPort1.ReadLine().Trim()
            If Not String.IsNullOrEmpty(rawLine) Then
                Dim parts() As String = rawLine.Split(","c)
                If parts.Length = 2 Then
                    Dim humidity As String = parts(0).Trim()
                    Dim temp As String = parts(1).Trim()
                    Me.InvokeUpdate(humidity, temp)
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub InvokeUpdate(ByVal humidity As String, ByVal temp As String)
        If Me.InvokeRequired Then
            Dim d As New UpdateDataCallback(AddressOf InvokeUpdate)
            Me.Invoke(d, New Object() {humidity, temp})
        Else
            lastDataTime = DateTime.Now

            Dim hVal As Double
            If Double.TryParse(humidity, hVal) Then
                currentHumidity = Math.Min(100, Math.Max(0, hVal))
                humidityHistory.Add(currentHumidity)
                If humidityHistory.Count > MaxPoints Then humidityHistory.RemoveAt(0)
            End If

            Dim tVal As Double
            If Double.TryParse(temp, tVal) Then
                currentTemperature = tVal
                tempHistory.Add(currentTemperature)
                If tempHistory.Count > MaxPoints Then tempHistory.RemoveAt(0)
            End If

            ' Redraw custom gauges and charts
            pnlHumidity.Invalidate()
            pnlTemperature.Invalidate()
            pnlHumidityChart.Invalidate()
            pnlTempChart.Invalidate()
        End If
    End Sub

    ' =========================================================================
    ' CUSTOM GDI+ RENDERING MATCHING THE EXACT SCREENSHOT DESIGN
    ' =========================================================================

    ''' <summary>
    ''' Render Circular Humidity Gauge & "80 %" Text
    ''' </summary>
    Private Sub pnlHumidity_Paint(sender As Object, e As PaintEventArgs) Handles pnlHumidity.Paint
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias

        Dim rect As New Rectangle(25, 55, 145, 145)
        Dim penWidth As Single = 22.0F

        ' Draw background gray ring
        Using basePen As New Pen(Color.FromArgb(235, 238, 242), penWidth)
            g.DrawEllipse(basePen, rect)
        End Using

        ' Draw active blue arc (#3399FF)
        Dim sweepAngle As Single = CSng((currentHumidity / 100.0) * 360.0)
        If sweepAngle > 0 Then
            Using bluePen As New Pen(Color.FromArgb(51, 153, 255), penWidth)
                g.DrawArc(bluePen, rect, -90, sweepAngle)
            End Using
        End If

        ' Center text "80 %"
        Dim displayText As String = Math.Round(currentHumidity).ToString("00") & " %"
        Using font As New Font("Segoe UI", 16.0F, FontStyle.Bold)
            Using brush As New SolidBrush(Color.FromArgb(51, 153, 255))
                Dim sf As New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center}
                g.DrawString(displayText, font, brush, New RectangleF(rect.X, rect.Y, rect.Width, rect.Height), sf)
            End Using
        End Using
    End Sub

    ''' <summary>
    ''' Render Vertical Temperature Gauge & "32.30 °C" Text
    ''' </summary>
    Private Sub pnlTemperature_Paint(sender As Object, e As PaintEventArgs) Handles pnlTemperature.Paint
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias

        ' Vertical bar location
        Dim barRect As New Rectangle(35, 55, 25, 145)

        ' Draw background gray bar
        Using baseBrush As New SolidBrush(Color.FromArgb(235, 238, 242))
            g.FillRectangle(baseBrush, barRect)
        End Using

        ' Calculate filled height (scale: -20 to 60 °C, range = 80)
        Dim tempRatio As Double = (currentTemperature - (-20)) / (60 - (-20))
        tempRatio = Math.Min(1.0, Math.Max(0.0, tempRatio))
        Dim fillHeight As Integer = CInt(tempRatio * barRect.Height)

        ' Draw filled orange bar (#FF9900)
        If fillHeight > 0 Then
            Dim fillRect As New Rectangle(barRect.X, barRect.Bottom - fillHeight, barRect.Width, fillHeight)
            Using orangeBrush As New SolidBrush(Color.FromArgb(255, 153, 0))
                g.FillRectangle(orangeBrush, fillRect)
            End Using
        End If

        ' Scale labels "60" and "-20"
        Using font As New Font("Segoe UI", 9.0F, FontStyle.Regular)
            Using brush As New SolidBrush(Color.FromArgb(160, 160, 160))
                g.DrawString("60", font, brush, barRect.Right + 5, barRect.Top - 3)
                g.DrawString("-20", font, brush, barRect.Right + 5, barRect.Bottom - 12)
            End Using
        End Using

        ' Temperature Value Text "32.30 °C"
        Dim displayText As String = currentTemperature.ToString("00.00") & " °C"
        Using font As New Font("Segoe UI", 15.0F, FontStyle.Bold)
            Using brush As New SolidBrush(Color.FromArgb(255, 153, 0))
                g.DrawString(displayText, font, brush, barRect.Right + 28, barRect.Y + (barRect.Height \ 2) - 14)
            End Using
        End Using
    End Sub

    ''' <summary>
    ''' Render Real-time Humidity Line Chart (-20 to 180 scale)
    ''' </summary>
    Private Sub pnlHumidityChart_Paint(sender As Object, e As PaintEventArgs) Handles pnlHumidityChart.Paint
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias

        Dim chartRect As New Rectangle(40, 15, 320, 150)
        DrawChartGrid(g, chartRect, {"180", "140", "100", "60", "20", "-20"})

        ' Draw Humidity curve (-20 to 180 scale)
        If humidityHistory.Count > 1 Then
            Dim points As New List(Of PointF)()
            Dim stepX As Single = CSng(chartRect.Width) / CSng(MaxPoints - 1)
            For i As Integer = 0 To humidityHistory.Count - 1
                Dim x As Single = chartRect.Left + (i * stepX)
                Dim valRatio As Single = CSng((humidityHistory(i) - (-20)) / (180 - (-20)))
                valRatio = Math.Min(1.0F, Math.Max(0.0F, valRatio))
                Dim y As Single = chartRect.Bottom - (valRatio * chartRect.Height)
                points.Add(New PointF(x, y))
            Next

            Using bluePen As New Pen(Color.FromArgb(51, 153, 255), 2.0F)
                g.DrawCurve(bluePen, points.ToArray())
            End Using
        End If

        ' Legend "― Humidity" & Water Drops Icon
        Using font As New Font("Segoe UI", 9.0F, FontStyle.Bold)
            Using brush As New SolidBrush(Color.FromArgb(51, 153, 255))
                g.DrawString("― Humidity", font, brush, chartRect.Right + 12, 15)
            End Using
        End Using

        ' Draw Water Drops Icon
        DrawWaterDropsIcon(g, chartRect.Right + 30, 45)
    End Sub

    ''' <summary>
    ''' Render Real-time Temperature Line Chart (30 to 40 scale)
    ''' </summary>
    Private Sub pnlTempChart_Paint(sender As Object, e As PaintEventArgs) Handles pnlTempChart.Paint
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias

        Dim chartRect As New Rectangle(40, 15, 320, 150)
        DrawChartGrid(g, chartRect, {"40", "38", "36", "34", "32", "30"})

        ' Draw Temperature curve (30 to 40 scale)
        If tempHistory.Count > 1 Then
            Dim points As New List(Of PointF)()
            Dim stepX As Single = CSng(chartRect.Width) / CSng(MaxPoints - 1)
            For i As Integer = 0 To tempHistory.Count - 1
                Dim x As Single = chartRect.Left + (i * stepX)
                Dim valRatio As Single = CSng((tempHistory(i) - 30.0) / (40.0 - 30.0))
                valRatio = Math.Min(1.0F, Math.Max(0.0F, valRatio))
                Dim y As Single = chartRect.Bottom - (valRatio * chartRect.Height)
                points.Add(New PointF(x, y))
            Next

            Using orangePen As New Pen(Color.FromArgb(255, 153, 0), 2.0F)
                g.DrawCurve(orangePen, points.ToArray())
            End Using
        End If

        ' Legend "― Temperature" & Thermometer Icon
        Using font As New Font("Segoe UI", 9.0F, FontStyle.Bold)
            Using brush As New SolidBrush(Color.FromArgb(255, 153, 0))
                g.DrawString("― Temperature", font, brush, chartRect.Right + 10, 15)
            End Using
        End Using

        ' Draw Thermometer Icon
        DrawThermometerIcon(g, chartRect.Right + 30, 45)
    End Sub

    ''' <summary>
    ''' Helper to draw grid lines & axis labels
    ''' </summary>
    Private Sub DrawChartGrid(g As Graphics, rect As Rectangle, labels As String())
        ' Outer Border
        Using borderPen As New Pen(Color.FromArgb(230, 230, 230), 1.0F)
            g.DrawRectangle(borderPen, rect)
        End Using

        ' Grid horizontal lines & labels
        Dim rows As Integer = labels.Length - 1
        Dim rowHeight As Single = CSng(rect.Height) / CSng(rows)
        Using gridPen As New Pen(Color.FromArgb(240, 242, 245), 1.0F),
              font As New Font("Segoe UI", 8.5F),
              brush As New SolidBrush(Color.FromArgb(170, 175, 185))
            For i As Integer = 0 To rows
                Dim y As Single = rect.Top + (i * rowHeight)
                If i > 0 And i < rows Then
                    g.DrawLine(gridPen, rect.Left, y, rect.Right, y)
                End If
                g.DrawString(labels(i), font, brush, rect.Left - 32, y - 6)
            Next
        End Using

        ' Vertical grid lines
        Dim cols As Integer = 6
        Dim colWidth As Single = CSng(rect.Width) / CSng(cols)
        Using gridPen As New Pen(Color.FromArgb(240, 242, 245), 1.0F)
            For j As Integer = 1 To cols - 1
                Dim x As Single = rect.Left + (j * colWidth)
                g.DrawLine(gridPen, x, rect.Top, x, rect.Bottom)
            Next
        End Using
    End Sub

    ''' <summary>
    ''' Vector graphic drawing for Water Drops Icon
    ''' </summary>
    Private Sub DrawWaterDropsIcon(g As Graphics, x As Integer, y As Integer)
        Using bluePen As New Pen(Color.FromArgb(51, 153, 255), 2.5F)
            ' Large Drop
            g.DrawArc(bluePen, x, y + 10, 18, 18, 0, 180)
            g.DrawLine(bluePen, x, y + 19, x + 9, y)
            g.DrawLine(bluePen, x + 18, y + 19, x + 9, y)

            ' Small Drop
            g.DrawArc(bluePen, x + 12, y + 25, 12, 12, 0, 180)
            g.DrawLine(bluePen, x + 12, y + 31, x + 18, y + 18)
            g.DrawLine(bluePen, x + 24, y + 31, x + 18, y + 18)
        End Using
    End Sub

    ''' <summary>
    ''' Vector graphic drawing for Thermometer Icon
    ''' </summary>
    Private Sub DrawThermometerIcon(g As Graphics, x As Integer, y As Integer)
        Using orangePen As New Pen(Color.FromArgb(255, 153, 0), 3.0F)
            Using orangeBrush As New SolidBrush(Color.FromArgb(255, 153, 0))
                ' Bulb at bottom
                g.FillEllipse(orangeBrush, x + 2, y + 25, 20, 20)
                ' Stem outline
                g.DrawRectangle(orangePen, x + 7, y, 10, 25)
                ' Mercury fill
                g.FillRectangle(orangeBrush, x + 9, y + 8, 6, 20)
            End Using
        End Using
    End Sub

    Private Sub tmrWatchdog_Tick(sender As Object, e As EventArgs) Handles tmrWatchdog.Tick
        If btnConnect.Text = "Disconnect" Then
            Dim ports As String() = SerialPort.GetPortNames()
            If Array.IndexOf(ports, SerialPort1.PortName) < 0 Then
                DisconnectArduino("Status: Arduino Unplugged", Color.Red)
                MessageBox.Show("Arduino USB cable was disconnected!", "Hardware Disconnected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim secondsSinceLastData As Double = (DateTime.Now - lastDataTime).TotalSeconds
            If secondsSinceLastData <= 3 Then
                UpdateStatus("Status: Connected & Receiving Data", Color.ForestGreen)
            Else
                UpdateStatus($"Status: Connected (No Data for {CInt(secondsSinceLastData)}s)", Color.OrangeRed)
            End If
        End If
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If SerialPort1.IsOpen Then
            SerialPort1.Close()
        End If
    End Sub
End Class

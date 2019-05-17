Public Class Form2
    Dim cx, cy, dx, dy As Single
    Dim bDrag, pause As Boolean
    Dim count = 0
    Private Sub Button1_MouseDown(sender As Object, e As MouseEventArgs) Handles Button1.MouseDown
        bDrag = True : dx = e.X : dy = e.Y : cx = Button1.Left : cy = Button1.Top
    End Sub

    Private Sub Button1_MouseUp(sender As Object, e As MouseEventArgs) Handles Button1.MouseUp
        bDrag = False
    End Sub

    Private Sub Button1_MouseMove(sender As Object, e As MouseEventArgs) Handles Button1.MouseMove
        If bDrag And pause = False Then
            cx = cx + e.X - dx : cy = cy + e.Y - dy
            Button1.Location = New Point(cx, cy)
        End If
    End Sub

    Dim dx1 As Integer = 4
    Dim dy1 As Integer = 6
    Dim size1 As Integer
    Dim x1, y1, x2, x3, x4, y2, y3, y4, dx2, dx3, dx4, dy2, dy3, dy4 As Integer

    Sub speedup()
        dx1 = dx1 * 1.5
        dy1 = dy1 * 1.5
        dx2 = dx2 * 1.4
        dy2 = dy2 * 1.4
        dx3 = dx3 * 1.3
        dy3 = dy3 * 1.3
        dx4 = dx4 * 1.2
        dy4 = dy4 * 1.2
    End Sub

    Sub crash()
        Timer1.Enabled = False
        Timer2.Enabled = False
        Beep()
        MsgBox("You've just crashed! Game Over. Your time is " & Format(time, "0.0") & " sec.")
        If System.IO.File.Exists("C:\Button Escape\Scores\BestScore.txt") Then
            System.IO.File.SetAttributes("C:\Button Escape\Scores\BestScore.txt", IO.FileAttributes.Normal)
        End If
        Dim OldBest As Double
        If System.IO.File.Exists("C:\Button Escape\Scores\BestScore.txt") Then
            Dim read As New System.IO.StreamReader("C:\Button Escape\Scores\BestScore.txt")
            If read.ReadLine <> "" And IsNumeric(read.ReadLine) Then
                OldBest = read.ReadLine
            End If
            read.Close()
        End If
        Dim record As New System.IO.StreamWriter("C:\Button Escape\Scores\BestScore.txt")
        If time < OldBest Then
            time = OldBest
        End If
        record.Write(Format(time, "0.0"))
        record.Close()
        System.IO.File.SetAttributes("C:\Button Escape\Scores\BestScore.txt", IO.FileAttributes.ReadOnly Or IO.FileAttributes.Hidden)
        Me.Close()
    End Sub

    Private Sub Form3_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Visible = False
        Form1.Visible = True
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles Me.Load
        size1 = Button2.Height
        x1 = Button2.Left
        y1 = Button2.Top
        x2 = Button3.Left
        y2 = Button3.Top
        x3 = Button4.Left
        y3 = Button4.Top
        x4 = Button5.Left
        y4 = Button5.Top
        dx2 = 4
        dx3 = 4
        dx4 = 4
        dy2 = 6
        dy3 = 6
        dy4 = 6
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        x1 = x1 + dx1
        y1 = y1 + dy1
        Button2.Left = x1
        Button2.Top = y1
        If x1 < 0 Or x1 > 500 - size1 - size1 + 30 Then dx1 = -dx1
        If y1 < 0 Or y1 > 400 - size1 - 4 Then dy1 = -dy1

        x2 = x2 - dx2
        y2 = y2 - dy2
        Button3.Left = x2
        Button3.Top = y2
        If x2 < 0 Or x2 > 500 - size1 - size1 + 30 Then dx2 = -dx2
        If y2 < 0 Or y2 > 400 - size1 - 4 Then dy2 = -dy2

        x3 = x3 + dx3
        y3 = y3 - dy3
        Button4.Left = x3
        Button4.Top = y3
        If x3 < 0 Or x3 > 500 - size1 - size1 + 30 Then dx3 = -dx3
        If y3 < 0 Or y3 > 400 - size1 - 4 Then dy3 = -dy3

        x4 = x4 - dx4
        y4 = y4 + dy4
        Button5.Left = x4
        Button5.Top = y4
        If x4 < 0 Or x4 > 500 - size1 - size1 + 30 Then dx4 = -dx4
        If y4 < 0 Or y4 > 400 - size1 - 4 Then dy4 = -dy4

        If Button1.Top > 350 Then Button1.Top = 350
        If Button1.Top < 0 Then Button1.Top = 0
        If Button1.Left > 450 Then Button1.Left = 450
        If Button1.Left < 0 Then Button1.Left = 0

        Dim r1 As New Rectangle(Button1.Location, Button1.Size)
        Dim r2 As New Rectangle(Button2.Location, Button2.Size)
        Dim r3 As New Rectangle(Button3.Location, Button2.Size)
        Dim r4 As New Rectangle(Button4.Location, Button2.Size)
        Dim r5 As New Rectangle(Button5.Location, Button2.Size)

        If r1.IntersectsWith(r2) Or r1.IntersectsWith(r3) Or r1.IntersectsWith(r4) Or r1.IntersectsWith(r5) Then
            crash()
        End If
    End Sub

    Private Sub Form3_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        bDrag = True : dx = e.X : dy = e.Y : cx = Me.Left : cy = Me.Top
    End Sub

    Private Sub Form3_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        If bDrag Then
            cx = cx + e.X - dx : cy = cy + e.Y - dy
            Me.Location = New Point(cx, cy)
        End If
    End Sub

    Private Sub Form3_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        bDrag = False
    End Sub

    Private Sub Form3_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim g As Graphics = Me.CreateGraphics
        g.DrawLine(Pens.Black, 0, 400, 500, 400)
        g.DrawLine(Pens.Black, 0, 0, Me.Width, 0)
        g.DrawLine(Pens.Black, 0, 0, 0, Me.Height)
        g.DrawLine(Pens.Black, Me.Width - 1, Me.Height, Me.Width - 1, 0)
        g.DrawLine(Pens.Black, 0, Me.Height - 1, Me.Width, Me.Height - 1)
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Timer1.Enabled = False
        Timer2.Enabled = False
        Me.Close()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Timer1.Enabled = True
        Timer2.Enabled = True
        Button1.Enabled = True
        Button6.Enabled = False
        Button6.Text = "Resume"
        Button7.Enabled = True
        Button7.Focus()
        pause = False
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Timer1.Enabled = False
        Timer2.Enabled = False
        Button7.Enabled = False
        Button6.Enabled = True
        Button6.Focus()
        pause = True
    End Sub

    Dim time As Double = 0

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        time = time + 0.1
        count = count + 1
        Label1.Text = "Time: " & Format(time, "0.0")
        Label1.Refresh()
        If count = 100 Then
            speedup()
            count = 0
        End If
    End Sub
End Class
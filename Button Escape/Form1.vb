Public Class Form1
    Dim bDrag As Boolean
    Dim cx, cy, dx, dy As Single
    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        bDrag = True : dx = e.X : dy = e.Y : cx = Me.Left : cy = Me.Top
    End Sub

    Private Sub Form1_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        If bDrag Then
            cx = cx + e.X - dx : cy = cy + e.Y - dy
            Me.Location = New Point(cx, cy)
        End If
    End Sub

    Private Sub Form1_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        bDrag = False
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        End
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Visible = False
        Form2.Visible = True
        System.IO.Directory.CreateDirectory("C:\Button Escape\Scores")
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If System.IO.File.Exists("C:\Button Escape\Scores\BestScore.txt") Then
            System.IO.File.SetAttributes("C:\Button Escape\Scores\BestScore.txt", IO.FileAttributes.Normal)
            Dim read As New System.IO.StreamReader("C:\Button Escape\Scores\BestScore.txt")
            Dim BestTime As Double
            If read.ReadLine <> "" And IsNumeric(CDbl(read.ReadLine)) Then
                BestTime = Val(read.ReadLine)
                MsgBox("Your best time is " & BestTime)
            Else
                MsgBox("Error! Something is wrong with our records.", MsgBoxStyle.Critical)
                read.Close()
                Exit Sub
            End If
            read.Close()
        Else
            MsgBox("You don't have any records yet.")
            Exit Sub
            System.IO.File.SetAttributes("C:\Button Escape\Scores\BestScore.txt", IO.FileAttributes.ReadOnly Or IO.FileAttributes.Hidden)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MsgBox("To start playing press 'Play!' and there will appear a window with five rectangles. Press 'Start' to play. Now you have to avoid red rectangles by moving green rectangle. To move green rectangle you have to press it and move. To exit you can press 'Back' and then press 'Exit'. To see your scores press 'Scores'. If you close the window while you're playing, your score won't be saved.", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
    End Sub

    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim g As Graphics = Me.CreateGraphics
        g.DrawLine(Pens.Black, 0, 0, Me.Width, 0)
        g.DrawLine(Pens.Black, 0, 0, 0, Me.Height)
        g.DrawLine(Pens.Black, Me.Width - 1, Me.Height, Me.Width - 1, 0)
        g.DrawLine(Pens.Black, 0, Me.Height - 1, Me.Width, Me.Height - 1)
    End Sub
End Class

Public Class Form9

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Process.Start("https://bebasid.github.io/")
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Process.Start("https://github.com/gvoze32/bebasid/blob/master/CHANGELOG.md")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Process.Start("https://github.com/gvoze32/bebasid/blob/master/raw.txt")
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs)
        IO.File.Delete("C:\Windows\System32\drivers\etc\hosts")
        IO.File.WriteAllBytes("C:\Windows\System32\drivers\etc\hosts", My.Resources.hosts_original)
        MsgBox("Sukses, hosts anda telah kembali ke awal", MsgBoxStyle.Information)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        Process.Start("https://github.com/gvoze32/bebasid/raw/master/UNBLOCKHOSTID.exe")
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Process.Start("https://github.com/gvoze32/bebasid/blob/master/SITES.md")
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Me.Close()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.WindowState = WindowState.Minimized
    End Sub

    Dim Pos2 As Point
    Private Sub Panel1_Paint(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Me.Location += Control.MousePosition - Pos2
        End If
        Pos2 = Control.MousePosition
    End Sub

    Private Sub Form9_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
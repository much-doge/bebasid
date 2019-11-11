Public Class baca

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()
    End Sub

    Private Sub baca_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.RichTextBox1.LoadFile("C:\Windows\System32\drivers\etc\hosts", RichTextBoxStreamType.PlainText)
    End Sub
End Class
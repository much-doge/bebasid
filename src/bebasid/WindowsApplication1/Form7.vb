Public Class Form7

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        WebBrowser1.Navigate("mailto:gvoze32@gmail.com?subject=Donasi UNBLOCKHOSTID&body=Halo, saya sudah mengirimkan donasi ke nomor yang tercantum, dan bukti transfer sudah saya masukkan ke attachment email ini. Untuk username dan passwordnya Username: & Password: . Saya tunggu updatenya. Terima kasih.")
    End Sub
End Class
Imports System.IO
Public Class blokir
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim FILE_NAME As String = "C:\Windows\System32\drivers\etc\hosts"
        If File.Exists(FILE_NAME) = True Then
            'Dim objWriter As New System.IO.StreamWriter(FILE_NAME, False)
            Dim objWriter As New StreamWriter(FILE_NAME, True)
            objWriter.Write(vbNewLine & TextBox1.Text & " " & TextBox2.Text)
            objWriter.Close()
            MsgBox("Berhasil ditambahkan", MsgBoxStyle.Information)
        Else
            MsgBox("Gagal menambahkan, file tidak ada", MsgBoxStyle.Information)
        End If

        Dim pasang As Button = DirectCast(sender, Button)
        pasang.Enabled = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim namafile As String = "C:\Windows\System32\drivers\etc\hosts"
        If File.Exists(namafile) = True Then
            'Dim objWriter As New System.IO.StreamWriter(FILE_NAME, False)
            Dim objWriter As New StreamWriter(namafile, True)
            objWriter.Write(vbNewLine & RichTextBox1.Text)
            objWriter.Close()
            MsgBox("Berhasil ditambahkan", MsgBoxStyle.Information)
        Else
            MsgBox("Gagal menambahkan, file tidak ada", MsgBoxStyle.Information)
        End If

        Dim pasang As Button = DirectCast(sender, Button)
        pasang.Enabled = False
    End Sub
End Class
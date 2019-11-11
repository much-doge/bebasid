Imports System.Data.OleDb
Imports System.IO

Public Class LoginForm1

    ' Sengaja di kasih public, biar konek ama Module1
    Public con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Windows\temp\dbu.mdb;Jet OLEDB:Database Password=l0k0nt0l;")

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim myfilename As String = "C:\Windows\Temp\dbu.mdb"
        IO.File.WriteAllBytes(myfilename, My.Resources.dbu)

        Dim cmd As OleDbCommand = New OleDbCommand("SELECT * FROM [Table1] WHERE [name] = '" & TextBox1.Text & "' AND [password] = '" & TextBox2.Text & "'", con)
        Dim user As String = ""
        Dim pass As String = ""

        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MsgBox("Harap isi form.", MsgBoxStyle.Information, "Informasi")
        Else
            con.Open()
            Dim sdr As OleDbDataReader = cmd.ExecuteReader
            If sdr.Read = True Then
                user = "username"
                pass = "password"
                Me.Visible = False
                MsgBox("Login Berhasil", MsgBoxStyle.Information)
                My.Settings.isLogin = True
                My.Settings.Save()
                Form2.Close()
            Else
                con.Close()
                MsgBox("Login Gagal", MsgBoxStyle.Information)
                TextBox1.Text = ""
                TextBox2.Text = ""
                TextBox1.Focus()
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        KeluarDariApp()
        End
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        Form7.Show()
    End Sub

    Private Sub LoginForm1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Default tombol Login
        Me.AcceptButton = Button1
        Button1.DialogResult = System.Windows.Forms.DialogResult.OK
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.WindowState = WindowState.Minimized
    End Sub

    Dim Pos As Point
    Private Sub Panel1_Paint(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Me.Location += Control.MousePosition - Pos
        End If
        Pos = Control.MousePosition
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Form7.Show()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class

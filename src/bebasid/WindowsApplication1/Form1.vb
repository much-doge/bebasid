Imports System.IO
Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Status.Text = "Program berhasil dijalankan"
        CheckBox1.Checked = False
        Timer1.Start()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Status.Text = "Info"
        Form9.ShowDialog()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Status.Text = "Options"
        Form2.ShowDialog()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim jawab As Integer
        If CheckBox1.Checked = True Then
            If My.Computer.FileSystem.FileExists("C:\Windows\System32\drivers\etc\hostsbackup") Then
                jawab = MsgBox("File sudah pernah di backup sebelumnya, ingin menimpa file backup lama dengan file backup baru?", vbYesNo + vbQuestion, "Backup Hosts")
                If jawab = vbYes Then
                    My.Computer.FileSystem.CopyFile("C:\Windows\System32\drivers\etc\hosts",
"C:\Windows\System32\drivers\etc\hostsbackup", FileIO.UIOption.OnlyErrorDialogs, FileIO.UICancelOption.DoNothing)
                End If
            Else
                My.Computer.FileSystem.CopyFile("C:\Windows\System32\drivers\etc\hosts",
"C:\Windows\System32\drivers\etc\hostsbackup", FileIO.UIOption.OnlyErrorDialogs, FileIO.UICancelOption.DoNothing)
            End If
        End If

        If My.Computer.FileSystem.FileExists("C:\Windows\System32\drivers\etc\hosts") Then
            Status.Text = "Mengecek file hosts"

            File.Delete("C:\Windows\System32\drivers\etc\hosts")
            Status.Text = "Memasang file hosts"

            File.WriteAllBytes("C:\Windows\System32\drivers\etc\hosts", My.Resources.hosts)
            MsgBox("Sukses, hosts telah terpasang", MsgBoxStyle.Information)
            Status.Text = "Sukses, hosts telah terpasang"

        Else
            Status.Text = "Memasang...."
            File.WriteAllBytes("C:\Windows\System32\drivers\etc\hosts", My.Resources.hosts)
            MsgBox("Sukses, hosts telah terpasang", MsgBoxStyle.Information)
            Status.Text = "Sukses, hosts telah terpasang"
        End If

        Dim pasang As Button = DirectCast(sender, Button)
        pasang.Enabled = False
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim paths As List(Of String) = New List(Of String)
        paths.Add("C:\Windows\Temp\flushdns.bat")
        paths.Add("C:\Windows\Temp\vpn.exe")
        paths.Add("C:\Windows\Temp\mac.exe")
        paths.Add("C:\Windows\Temp\fixfd.bat")
        paths.Add("C:\Windows\Temp\startupdate.bat")
        paths.Add("C:\Windows\Temp\stopupdate.bat")
        paths.Add("C:\Windows\Temp\defrag.bat")
        'Delete all file
        For Each loc As String In paths
            File.Delete(loc)
        Next

        ' For a folder
        Dim dir As New IO.DirectoryInfo("C:\Windows\Temp\goodbyedpi")
        If dir.Exists Then
            My.Computer.FileSystem.DeleteDirectory("C:\Windows\Temp\goodbyedpi",
            FileIO.DeleteDirectoryOption.DeleteAllContents)
        End If

        Dim dir2 As New IO.DirectoryInfo("C:\Windows\Temp\defrag")
        If dir2.Exists Then
            My.Computer.FileSystem.DeleteDirectory("C:\Windows\Temp\defrag",
            FileIO.DeleteDirectoryOption.DeleteAllContents)
        End If

        Dim dir3 As New IO.DirectoryInfo("C:\Windows\Temp\fixfd")
        If dir3.Exists Then
            My.Computer.FileSystem.DeleteDirectory("C:\Windows\Temp\fixfd",
            FileIO.DeleteDirectoryOption.DeleteAllContents)
        End If

        Status.Text = "Menutup Aplikasi"
        MsgBox("Risiko ditanggung sendiri, kami tidak bertanggung jawab atas dampak yang ditimbulkan dari penggunaan aplikasi ini tolong gunakan dengan bijak. Terima Kasih.", MsgBoxStyle.Information)
        Me.Close()
        End
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.WindowState = WindowState.Minimized
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Status.Text = "About"
        About.ShowDialog()
    End Sub

    Dim Pos As Point
    Private Sub Panel2_Paint(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Panel2.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Me.Location += Control.MousePosition - Pos
        End If
        Pos = Control.MousePosition
    End Sub

    Dim jawab2 As Integer
    Public Sub updatecheck()
        If IsConnectionAvailable() = True Then
            Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create("https://raw.githubusercontent.com/bebasid/bebasid.github.io/master/version.txt")
            Dim response As System.Net.HttpWebResponse = request.GetResponse()
            Dim sr As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream())
            Dim newestversion As String = sr.ReadToEnd()
            Dim currentversion As String = Application.ProductVersion
            If newestversion.Contains(currentversion) Then
                ''Sudah versi terbaru
            Else
                jawab2 = MsgBox("Versi baru telah tersedia, ingin download update?", vbYesNo + vbQuestion, "Update Checker")
                If jawab2 = vbYes Then
                    WebBrowser1.Navigate("https://github.com/gvoze32/bebasid/raw/master/BEBASID.exe")
                Else
                    ''Do nothing
                End If
            End If
        End If
    End Sub

    Public Function IsConnectionAvailable() As Boolean
        Dim objUrl As New System.Uri("http://www.google.com")
        Dim objWebReq As System.Net.WebRequest
        objWebReq = System.Net.WebRequest.Create(objUrl)
        Dim objresp As System.Net.WebResponse

        Try
            objresp = objWebReq.GetResponse
            objresp.Close()
            objresp = Nothing
            Return True

        Catch ex As Exception
            objresp = Nothing
            objWebReq = Nothing
            Return False
        End Try
    End Function

    Private Sub Timer1_Tick_1(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        updatecheck()
    End Sub
End Class
Public NotInheritable Class SplashScreen1
    Private Sub SplashScreen1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Timer1.Start()
        Timer2.Start()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        ProgressBar1.PerformStep()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If My.Settings.isAgree = False Then
            Form8.Show()
            Me.Close()
        Else
            Form1.Show()
            Me.Close()
        End If

        If My.Settings.isAgree = True Then
            Form1.Show()
            Me.Close()
        Else
            Form8.Show()
            Me.Close()
        End If
    End Sub
End Class

Public NotInheritable Class SplashScreen1


    Private Sub SplashScreen1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.VersionLabel.Text = "Version: " & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor
        Me.UserLabel.Text = My.User.Name & " " & FormatDateTime(Now, DateFormat.LongDate) & vbNewLine & "Public Domain Software" & vbNewLine & "National Park Service, " & Year(Now)

    End Sub

End Class

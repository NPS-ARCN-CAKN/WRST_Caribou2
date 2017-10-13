Public Class DatabaseConnectionForm
    Private Sub DatabaseConnectionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ConnectionStringTextBox.Text = My.Settings.WRST_CaribouConnectionString
    End Sub

    Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click
        MsgBox("edits not enabled yet")
    End Sub
End Class
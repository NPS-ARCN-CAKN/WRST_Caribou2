Public Class DatabaseConnectionForm
    Private Sub DatabaseConnectionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.PropertyGrid1.SelectedObject = My.Settings.WRST_CaribouConnectionString
    End Sub


End Class
Public Class Form1
    Private Sub CampaignsBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles CampaignsBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.CampaignsBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.WRST_CaribouDataSet)

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'WRST_CaribouDataSet.Campaigns' table. You can move, or remove it, as needed.
        Me.CampaignsTableAdapter.Fill(Me.WRST_CaribouDataSet.Campaigns)

    End Sub
End Class

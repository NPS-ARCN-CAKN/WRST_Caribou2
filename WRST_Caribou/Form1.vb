Imports Janus.Windows.GridEX
Public Class Form1
    Private Sub CampaignsBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        SaveDataset()
    End Sub

    Private Sub SaveDataset()
        Try
            If Me.WRST_CaribouDataSet.HasChanges = True Then
                If MsgBox("Save all changes to the database?", MsgBoxStyle.YesNo, "Save") = MsgBoxResult.Yes Then
                    Me.Validate()
                    Me.CompositionCountsBindingSource.EndEdit()
                    Me.PopulationEstimateBindingSource.EndEdit()
                    Me.RadioTrackingBindingSource.EndEdit()
                    Me.SurveyFlightsBindingSource.EndEdit()
                    Me.CampaignsBindingSource.EndEdit()
                    Me.TableAdapterManager.UpdateAll(Me.WRST_CaribouDataSet)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'load the dataset
        Me.RadioTrackingTableAdapter.Fill(Me.WRST_CaribouDataSet.RadioTracking)
        Me.PopulationEstimateTableAdapter.Fill(Me.WRST_CaribouDataSet.PopulationEstimate)
        Me.CompositionCountsTableAdapter.Fill(Me.WRST_CaribouDataSet.CompositionCounts)
        Me.SurveyFlightsTableAdapter.Fill(Me.WRST_CaribouDataSet.SurveyFlights)
        Me.CampaignsTableAdapter.Fill(Me.WRST_CaribouDataSet.Campaigns)

        'set up the GridEXs
        Dim Editable As InheritableBoolean = InheritableBoolean.True
        SetUpGridEX(Me.CampaignsGridEX, Editable)
        SetUpGridEX(Me.SurveyFlightsGridEX, Editable)
        SetUpGridEX(Me.CompositionCountsGridEX, Editable)
        SetUpGridEX(Me.PopulationEstimateGridEX, Editable)
        SetUpGridEX(Me.RadioTrackingGridEX, Editable)

        'load the herd column dropdown
        With Me.CampaignsGridEX.RootTable.Columns("Herd")
            .HasValueList = True
            .LimitToList = True
        End With
        Dim HerdList As GridEXValueListItemCollection = Me.CampaignsGridEX.RootTable.Columns("Herd").ValueList
        HerdList.Add("Chisana", "Chisana")
        HerdList.Add("Mentasta", "Mentasta")

        'maximize form
        Me.WindowState = FormWindowState.Maximized
    End Sub



    Private Sub SetUpGridEX(GridEX As GridEX, Editable As InheritableBoolean)
        Try
            Dim MyFont As New Font("Sans Serif", 10, FontStyle.Regular)
            With GridEX
                .AllowAddNew = Editable
                .AllowEdit = Editable
                .AllowDelete = Editable
                .AlternatingColors = True
                .AutomaticSort = True
                .CardBorders = False
                .ColumnAutoSizeMode = ColumnAutoSizeMode.AllCells
                .ColumnHeaders = InheritableBoolean.True
                .NewRowPosition = NewRowPosition.BottomRow
                .RecordNavigator = True
                .RowHeaders = InheritableBoolean.True
                .SelectOnExpand = False
                .TotalRowPosition = TotalRowPosition.BottomFixed
                .Font = MyFont
                .RowHeaders = InheritableBoolean.True
                .NewRowPosition = NewRowPosition.BottomRow
                .SelectOnExpand = False
            End With
        Catch ex As Exception
            Debug.Print(ex.Message)
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub

    Private Sub SaveChangesToDatabaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveChangesToDatabaseToolStripMenuItem.Click
        SaveDataset
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        SaveDataset()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub EditDatabaseConnectionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditDatabaseConnectionToolStripMenuItem.Click
        Dim DatabaseConnectionForm As New DatabaseConnectionForm
        DatabaseConnectionForm.ShowDialog()

    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        With My.Application.Info
            Debug.Print(.AssemblyName)
            Debug.Print(.CompanyName)
            Debug.Print(.Description)
            Debug.Print(.DirectoryPath)
            Debug.Print(.ProductName)
            Debug.Print(.Title)
            Debug.Print(.Version.Major & " minor versino " & .Version.Minor)
            Debug.Print(My.Settings.WRST_CaribouConnectionString)

        End With
    End Sub
End Class

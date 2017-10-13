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

        'Set up CampaignsGridEX
        With Me.CampaignsGridEX.RootTable.Columns("Herd")
            .HasValueList = True
            .LimitToList = True
        End With
        Dim HerdList As GridEXValueListItemCollection = Me.CampaignsGridEX.RootTable.Columns("Herd").ValueList
        HerdList.Add("Chisana", "Chisana")
        HerdList.Add("Mentasta", "Mentasta")

        'Set up Surveys GridEX
        'Herd
        With Me.SurveyFlightsGridEX.RootTable.Columns("Herd")
            .HasValueList = True
            .LimitToList = True
        End With
        Dim SurveysHerdList As GridEXValueListItemCollection = Me.SurveyFlightsGridEX.RootTable.Columns("Herd").ValueList
        SurveysHerdList.Add("Chisana", "Chisana")
        SurveysHerdList.Add("Mentasta", "Mentasta")

        SetUpSurveysGridEX()

        'maximize form
        Me.WindowState = FormWindowState.Maximized
    End Sub

    ''' <summary>
    ''' Sets up the SurveysGridEX default values and DropDowns/Combos
    ''' </summary>
    Private Sub SetUpSurveysGridEX()
        'Set up default values
        Dim Grid As GridEX = Me.SurveyFlightsGridEX
        Grid.RootTable.Columns("RecordInsertedDate").DefaultValue = Now
        Grid.RootTable.Columns("RecordInsertedBy").DefaultValue = My.User.Name
        Grid.RootTable.Columns("FlightID").DefaultValue = New Guid().ToString
        Dim MaxGroupNumber As Integer = 0
        For Each row As GridEXRow In Grid.GetRows()
            If row.Cells("CrewNumber").Value > MaxGroupNumber Then
                MaxGroupNumber = row.Cells("CrewNumber").Value
            End If
        Next
        Grid.RootTable.Columns("CrewNumber").DefaultValue = MaxGroupNumber + 1

        'Set up Pilot dropdown
        LoadGridEXDropDown(Me.SurveyFlightsGridEX, Me.WRST_CaribouDataSet.Tables("SurveyFlights"), "Pilot", "Pilot", False)
        LoadGridEXDropDown(Me.SurveyFlightsGridEX, Me.WRST_CaribouDataSet.Tables("SurveyFlights"), "TailNo", "TailNo", False)
        LoadGridEXDropDown(Me.SurveyFlightsGridEX, Me.WRST_CaribouDataSet.Tables("SurveyFlights"), "AircraftType", "AircraftType", False)
        LoadGridEXDropDown(Me.SurveyFlightsGridEX, Me.WRST_CaribouDataSet.Tables("SurveyFlights"), "Observer1", "Observer1", False)
        LoadGridEXDropDown(Me.SurveyFlightsGridEX, Me.WRST_CaribouDataSet.Tables("SurveyFlights"), "Observer2", "Observer2", False)
        LoadGridEXDropDown(Me.SurveyFlightsGridEX, Me.WRST_CaribouDataSet.Tables("SurveyFlights"), "SOPNumber", "SOPNumber", False)
        LoadGridEXDropDown(Me.SurveyFlightsGridEX, Me.WRST_CaribouDataSet.Tables("SurveyFlights"), "SOPVersion", "SOPVersion", False)
    End Sub

    ''' <summary>
    ''' Loads distinct items from a DataTable's DataColumn into a GridEX GridEXColumn's DropDown ValueList
    ''' </summary>
    ''' <param name="GridEX">The GridEX containing the GridEXColumn requiring a DropDown ValueList</param>
    ''' <param name="SourceDataTable">Name of the DataTable containing the DataColumn from which distinct values will be drawn</param>
    ''' <param name="SourceColumnName">Name of the source DataTable's DataColumn from which distinct values will be drawn</param>
    ''' <param name="GridEXColumnName">Name of the GridEX column into which to load dropdown values</param>
    Private Sub LoadGridEXDropDown(GridEX As GridEX, SourceDataTable As DataTable, SourceColumnName As String, GridEXColumnName As String, LimitToList As Boolean)
        Try
            'Ensure the GridEXColumn is configured for a DropDown
            With GridEX.RootTable.Columns(GridEXColumnName)
                .EditType = EditType.Combo
                .HasValueList = True
                .LimitToList = False
                .AllowSort = True
                .AutoComplete = True
            End With

            'Make a GridEXValueListItemCollection to hold the distinct items
            Dim ItemsList As GridEXValueListItemCollection = GridEX.RootTable.Columns(GridEXColumnName).ValueList

            'Get the distinct items from a DataTable
            Dim DistinctItemsDataTable As DataTable = SourceDataTable.DefaultView.ToTable(True, SourceColumnName)

            'Sort the DataView
            Dim DistinctItemsDataView As New DataView(DistinctItemsDataTable, "", SourceColumnName, DataRowState.Unchanged)

            'Add the distinct items from the DataView into the GridEXValueListItemCollection
            If DistinctItemsDataView.Table.Rows.Count > 0 Then
                For Each Row As DataRow In DistinctItemsDataView.Table.Rows
                    If Not IsDBNull(Row.Item(SourceColumnName)) Then
                        Dim Item As String = Row.Item(SourceColumnName)
                        ItemsList.Add(Item, Item)
                    End If
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
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
                .GroupByBoxVisible = False
                .FilterMode = FilterMode.None
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
        'With My.Application.Info
        '    Debug.Print(.AssemblyName)
        '    Debug.Print(.CompanyName)
        '    Debug.Print(.Description)
        '    Debug.Print(.DirectoryPath)
        '    Debug.Print(.ProductName)
        '    Debug.Print(.Title)
        '    Debug.Print(.Version.Major & " minor versino " & .Version.Minor)
        '    Debug.Print(My.Settings.WRST_CaribouConnectionString)

        'End With
    End Sub

    Private Sub SurveyFlightsGridEX_SelectionChanged(sender As Object, e As EventArgs) Handles SurveyFlightsGridEX.SelectionChanged
        SetUpSurveysGridEX()
    End Sub

    Private Sub SaveDatasetToolStripButton_Click(sender As Object, e As EventArgs) Handles SaveDatasetToolStripButton.Click
        SaveDataset()
    End Sub
End Class

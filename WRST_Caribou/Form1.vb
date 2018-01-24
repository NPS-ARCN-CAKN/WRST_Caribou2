﻿Imports System.Data.SqlClient
Imports System.IO
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
                    Me.XrefPopulationCaribouBindingSource.EndEdit()
                    Me.XrefCompCountCaribouBindingSource.EndEdit()
                    Me.XrefRadiotrackingCaribouBindingSource.EndEdit()
                    Me.TableAdapterManager.UpdateAll(Me.WRST_CaribouDataSet)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try

    End Sub

    Private Sub LoadDataset()
        Try
            'load the data
            Me.CampaignsTableAdapter.Fill(Me.WRST_CaribouDataSet.Campaigns)
            Me.SurveyFlightsTableAdapter.Fill(Me.WRST_CaribouDataSet.SurveyFlights)
            Me.XrefRadiotrackingCaribouTableAdapter.Fill(Me.WRST_CaribouDataSet.xrefRadiotrackingCaribou)
            Me.XrefPopulationCaribouTableAdapter.Fill(Me.WRST_CaribouDataSet.xrefPopulationCaribou)
            Me.XrefCompCountCaribouTableAdapter.Fill(Me.WRST_CaribouDataSet.xrefCompCountCaribou)
            Me.CapturesTableAdapter.Fill(Me.WRST_CaribouDataSet.Captures)
            Me.CaribouTableAdapter.Fill(Me.WRST_CaribouDataSet.Caribou)
            Me.RadioTrackingTableAdapter.Fill(Me.WRST_CaribouDataSet.RadioTracking)
            Me.PopulationEstimateTableAdapter.Fill(Me.WRST_CaribouDataSet.PopulationEstimate)
            Me.CompositionCountsTableAdapter.Fill(Me.WRST_CaribouDataSet.CompositionCounts)
             Me.XrefPopulationCaribouTableAdapter.Fill(Me.WRST_CaribouDataSet.xrefPopulationCaribou)
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'load the data from the WRST_Caribou Sql Server database
        LoadDataset()

        'set up the GridEXs
        Dim Editable As InheritableBoolean = InheritableBoolean.True
        SetUpGridEX(Me.CampaignsGridEX, Editable)
        SetUpGridEX(Me.SurveyFlightsGridEX, Editable)
        SetUpGridEX(Me.CompositionCountsGridEX, Editable)
        SetUpGridEX(Me.PopulationEstimateGridEX, Editable)
        SetUpGridEX(Me.RadioTrackingGridEX, Editable)
        SetUpGridEX(Me.XrefCompCountCaribouGridEX, Editable)
        SetUpGridEX(Me.XrefPopulationCaribouGridEX, Editable)
        SetUpGridEX(Me.XrefRadiotrackingCaribouGridEX, Editable)

        'Set up the Campaigns GridEX default values and dropdowns
        SetUpCampaignsGridEX()

        'Set up the SurveysGridEX default values and dropdowns
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
        Grid.RootTable.Columns("FlightID").DefaultValue = Guid.NewGuid.ToString
        Grid.RootTable.Columns("CertificationLevel").DefaultValue = "Provisional"

        'set up xrefpopulationsurveys default values
        'With Me.XrefPopulationCaribouGridEX
        '    .RootTable.Columns("ProjectID").DefaultValue = "WRST_Caribou"
        'End With

        'CrewNumber default value
        Dim MaxGroupNumber As Integer = 0
        For Each row As GridEXRow In Grid.GetRows()
            If row.Cells("CrewNumber").Value > MaxGroupNumber Then
                MaxGroupNumber = row.Cells("CrewNumber").Value
            End If
        Next
        Grid.RootTable.Columns("CrewNumber").DefaultValue = MaxGroupNumber + 1

        'SOPVersion default value
        Dim MaxSOPVersion As Integer = 0
        For Each row As GridEXRow In Grid.GetRows()
            If row.Cells("SOPVersion").Value > MaxSOPVersion Then
                MaxSOPVersion = row.Cells("SOPVersion").Value
            End If
        Next
        Grid.RootTable.Columns("SOPVersion").DefaultValue = MaxSOPVersion + 1

        'Set up dropdowns
        LoadGridEXDropDown(Me.SurveyFlightsGridEX, Me.WRST_CaribouDataSet.Tables("SurveyFlights"), "Pilot", "Pilot", False)
        LoadGridEXDropDown(Me.SurveyFlightsGridEX, Me.WRST_CaribouDataSet.Tables("SurveyFlights"), "TailNo", "TailNo", False)
        LoadGridEXDropDown(Me.SurveyFlightsGridEX, Me.WRST_CaribouDataSet.Tables("SurveyFlights"), "AircraftType", "AircraftType", False)
        LoadGridEXDropDown(Me.SurveyFlightsGridEX, Me.WRST_CaribouDataSet.Tables("SurveyFlights"), "Observer1", "Observer1", False)
        LoadGridEXDropDown(Me.SurveyFlightsGridEX, Me.WRST_CaribouDataSet.Tables("SurveyFlights"), "Observer2", "Observer2", False)
        LoadGridEXDropDown(Me.SurveyFlightsGridEX, Me.WRST_CaribouDataSet.Tables("SurveyFlights"), "SOPNumber", "SOPNumber", False)
        LoadGridEXDropDown(Me.SurveyFlightsGridEX, Me.WRST_CaribouDataSet.Tables("SurveyFlights"), "SOPVersion", "SOPVersion", False)

        'Set up non-database dropdowns

        'Herd dropdown
        With Grid.RootTable.Columns("Herd")
            .HasValueList = True
            .LimitToList = True
            .ValueList.Clear()
        End With
        Dim SurveysHerdList As GridEXValueListItemCollection = Me.SurveyFlightsGridEX.RootTable.Columns("Herd").ValueList
        SurveysHerdList.Add("Chisana", "Chisana")
        SurveysHerdList.Add("Mentasta", "Mentasta")

        'CertificationLevel dropdown
        With Grid.RootTable.Columns("CertificationLevel")
            .EditType = EditType.DropDownList
            .HasValueList = True
            .LimitToList = True
            .ValueList.Clear()
        End With
        Dim CertificationLevelList As GridEXValueListItemCollection = Grid.RootTable.Columns("CertificationLevel").ValueList
        CertificationLevelList.Add("Raw", "Raw")
        CertificationLevelList.Add("Provisional", "Provisional")
        CertificationLevelList.Add("Accepted", "Accepted")
        CertificationLevelList.Add("Certified", "Certified")
    End Sub

    ''' <summary>
    ''' Set up CampaignsGridEX dropdowns
    ''' </summary>
    Private Sub SetUpCampaignsGridEX()
        Try
            'Set up default values
            Dim Grid As GridEX = Me.CampaignsGridEX
            Grid.RootTable.Columns("RecordInsertedDate").DefaultValue = Now
            Grid.RootTable.Columns("RecordInsertedBy").DefaultValue = My.User.Name
            Grid.RootTable.Columns("CampaignID").DefaultValue = Guid.NewGuid.ToString

            'Set up non-database column dropdowns
            With Me.CampaignsGridEX.RootTable.Columns("Herd")
                .HasValueList = True
                .LimitToList = True
                .ValueList.Clear()
            End With
            Dim HerdList As GridEXValueListItemCollection = Me.CampaignsGridEX.RootTable.Columns("Herd").ValueList
            HerdList.Add("Chisana", "Chisana")
            HerdList.Add("Mentasta", "Mentasta")

            'Set up campaigns survey type dropdown
            With Me.CampaignsGridEX.RootTable.Columns("SurveyType")
                .HasValueList = True
                .LimitToList = True
                .ValueList.Clear()
            End With
            Dim SurveyTypeList As GridEXValueListItemCollection = Me.CampaignsGridEX.RootTable.Columns("SurveyType").ValueList
            SurveyTypeList.Add("Composition", "Composition")
            SurveyTypeList.Add("Population", "Population")
            SurveyTypeList.Add("Radiotracking", "Radiotracking")
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
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
                .ValueList.Clear()
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

    ''' <summary>
    ''' Standardizes the look, feel and function of a GridEX
    ''' </summary>
    ''' <param name="GridEX">The GridEX to set up</param>
    ''' <param name="Editable">Boolean.  Whether to make the GridEX editable or read-only</param>
    Private Sub SetUpGridEX(GridEX As GridEX, Editable As InheritableBoolean)
        Try
            Dim MyFont As New Font("Sans Serif", 10, FontStyle.Regular)
            With GridEX
                .AllowAddNew = Editable
                .AllowEdit = Editable
                .AllowDelete = Editable
                .AlternatingColors = True
                .AutoEdit = False
                .AutomaticSort = True
                .CardBorders = False
                .CardHeaders = True
                .ColumnAutoSizeMode = ColumnAutoSizeMode.AllCells
                .ColumnHeaders = InheritableBoolean.True
                .Font = MyFont
                .FilterMode = FilterMode.None
                '.GroupByBoxVisible = False
                .NewRowPosition = NewRowPosition.BottomRow
                .RecordNavigator = True
                .RowHeaders = InheritableBoolean.True
                '.TableHeaders = InheritableBoolean.True
                '.RootTable.TableHeader = InheritableBoolean.True
                .SelectionMode = SelectionMode.MultipleSelection
                .SelectOnExpand = False
                .TotalRowPosition = TotalRowPosition.BottomFixed
            End With
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub

    Private Sub SaveChangesToDatabaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveChangesToDatabaseToolStripMenuItem.Click
        SaveDataset()
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
        Dim AboutText As String = ""
        With My.Application.Info
            AboutText = AboutText & .AssemblyName & vbNewLine
            AboutText = AboutText & .CompanyName & vbNewLine
            AboutText = AboutText & .Description & vbNewLine
            AboutText = AboutText & .DirectoryPath & vbNewLine
            AboutText = AboutText & .ProductName & vbNewLine
            AboutText = AboutText & .Title & vbNewLine
            AboutText = AboutText & .Version.Major & " minor versino " & .Version.Minor & vbNewLine
            AboutText = AboutText & My.Settings.WRST_CaribouConnectionString & vbNewLine

        End With
        MsgBox(AboutText)
    End Sub

    Private Sub SurveyFlightsGridEX_SelectionChanged(sender As Object, e As EventArgs) Handles SurveyFlightsGridEX.SelectionChanged
        Try
            'get some information about the survey flight to put in the header label so users know which survey flight they are editing
            Me.FlightContextLabel.Text = "Data"
            Dim CurrentFlight As String = "Data"
            Dim CrewNumber As Integer = 0
            Dim TailNo As String = ""
            Dim Pilot As String = ""
            Dim Observer1 As String = ""
            Dim TimeDepart As Date = "1/1/1111"
            If Not Me.SurveyFlightsGridEX.CurrentRow Is Nothing Then
                If Not Me.SurveyFlightsGridEX.CurrentRow.Cells("CrewNumber") Is Nothing And Not Me.SurveyFlightsGridEX.CurrentRow.Cells("TailNo") Is Nothing And Not Me.SurveyFlightsGridEX.CurrentRow.Cells("Pilot") Is Nothing And Not Me.SurveyFlightsGridEX.CurrentRow.Cells("Observer1") Is Nothing And Not Me.SurveyFlightsGridEX.CurrentRow.Cells("TimeDepart") Is Nothing Then
                    If Not IsDBNull(Me.SurveyFlightsGridEX.CurrentRow.Cells("CrewNumber").Value) Then CrewNumber = Me.SurveyFlightsGridEX.CurrentRow.Cells("CrewNumber").Value
                    If Not IsDBNull(Me.SurveyFlightsGridEX.CurrentRow.Cells("Pilot").Value) Then Pilot = Me.SurveyFlightsGridEX.CurrentRow.Cells("Pilot").Value Else Pilot = ""
                    If Not IsDBNull(Me.SurveyFlightsGridEX.CurrentRow.Cells("TailNo").Value) Then TailNo = Me.SurveyFlightsGridEX.CurrentRow.Cells("TailNo").Value Else TailNo = ""
                    If Not IsDBNull(Me.SurveyFlightsGridEX.CurrentRow.Cells("Observer1").Value) Then Observer1 = Me.SurveyFlightsGridEX.CurrentRow.Cells("Observer1").Value Else Observer1 = ""
                    If Not IsDBNull(Me.SurveyFlightsGridEX.CurrentRow.Cells("TimeDepart").Value) Then TimeDepart = Me.SurveyFlightsGridEX.CurrentRow.Cells("TimeDepart").Value
                End If
                CurrentFlight = "Data: " & CrewNumber & " " & TailNo & " " & Pilot & " & " & Observer1 & " " & TimeDepart
                Me.FlightContextLabel.Text = CurrentFlight
            End If

            'set up the Survey Flight GridEX
            SetUpSurveysGridEX()

            'Set up default values
            Me.SurveyFlightsGridEX.RootTable.Columns("FlightID").DefaultValue = Guid.NewGuid.ToString
            Me.SurveyFlightsGridEX.RootTable.Columns("SOPNumber").DefaultValue = 0
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub

    Private Sub SaveDatasetToolStripButton_Click(sender As Object, e As EventArgs) Handles SaveDatasetToolStripButton.Click
        SaveDataset()
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Me.WRST_CaribouDataSet.HasChanges Then
            SaveDataset()
        End If
    End Sub

    Private Sub CampaignsGridEX_SelectionChanged(sender As Object, e As EventArgs) Handles CampaignsGridEX.SelectionChanged
        'user gets here when they select a campaign from the campaigns gridex
        Try
            'get the name of the survey campaign to put it into the survey flights header
            Me.CampaignContextLabel.Text = "Flights"
            Dim CurrentCampaign As String = "Flights"
            If Not Me.CampaignsGridEX.CurrentRow Is Nothing Then
                If Not Me.CampaignsGridEX.CurrentRow.Cells("Campaign") Is Nothing And Not IsDBNull(Me.CampaignsGridEX.CurrentRow.Cells("Campaign").Value) Then
                    CurrentCampaign = Me.CampaignsGridEX.CurrentRow.Cells("Campaign").Value
                    Me.CampaignContextLabel.Text = "Flights: " & CurrentCampaign
                Else
                    Me.CampaignContextLabel.Text = CurrentCampaign
                End If

                'set up the flight gridex's 'herd' column default value
                If Not Me.CampaignsGridEX.CurrentRow.Cells("Herd") Is Nothing And Not IsDBNull(Me.CampaignsGridEX.CurrentRow.Cells("Herd").Value) Then
                    Dim CampaignHerd As String = Me.CampaignsGridEX.CurrentRow.Cells("Herd").Value
                    Me.SurveyFlightsGridEX.RootTable.Columns("Herd").DefaultValue = CampaignHerd
                Else
                    Me.CampaignContextLabel.Text = CurrentCampaign
                End If
            End If

            'set up the gridexes for consistency
            SetUpCampaignsGridEX()

            'set the survey type tab control to the current survey type
            Dim CurrentSurveyType As String = ""
            If Not Me.CampaignsGridEX.CurrentRow.Cells("SurveyType") Is Nothing And Not IsDBNull(Me.CampaignsGridEX.CurrentRow.Cells("SurveyType").Value) Then
                CurrentSurveyType = Me.CampaignsGridEX.CurrentRow.Cells("SurveyType").Value

                'clear the results datagridview
                Me.ResultsDataGridView.DataSource = Nothing
                Select Case CurrentSurveyType
                    Case "Composition"
                        Me.SurveyDataTabControl.SelectedTab = Me.CompositionCountTabPage
                    Case "Population"
                        Me.SurveyDataTabControl.SelectedTab = Me.PopulationTabPage
                        'loads the results of the population survey into the Results GridEX
                        LoadPopulationEstimateSurveyResults(GetCurrentCampaignID)
                    Case "Radiotracking"
                        Me.SurveyDataTabControl.SelectedTab = Me.RadiotrackingTabPage
                    Case Else
                        Me.SurveyDataTabControl.SelectedTab = Me.CompositionCountTabPage
                End Select
            End If


        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub

    ''' <summary>
    ''' Returns the CampaignID of the currently selected Campaign
    ''' </summary>
    ''' <returns>CampaignID. String.</returns>
    Private Function GetCurrentCampaignID() As String
        Dim CampaignID As String = ""
        Try
            'get the current row of the VS GridEX
            If Not Me.CampaignsGridEX.CurrentRow Is Nothing Then
                Dim CurrentRow As GridEXRow = Me.CampaignsGridEX.CurrentRow
                'loop through the columns and look for the FilesDirectory columns
                For i As Integer = 0 To CurrentRow.Cells.Count - 1
                    If CurrentRow.Cells(i).Column.Key = "CampaignID" Then
                        'if there is a value
                        If Not IsDBNull(CurrentRow.Cells(i).Value) Then
                            CampaignID = CurrentRow.Cells(i).Value
                        End If
                    End If
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
        Return CampaignID
    End Function

    ''' <summary>
    ''' Runs the Sql Server view PE_ResultsByCampaign for the survey campaign and returns the results as a DataTable to the ResultsDataGridView
    ''' </summary>
    ''' <param name="CampaignID"></param>
    Private Sub LoadPopulationEstimateSurveyResults(CampaignID As String)
        Try
            Dim Sql As String = "SELECT *  FROM PE_ResultsByCampaign WHERE CampaignID = '" & CampaignID & "';"
            Dim ResultsDataTable As DataTable = GetDataTable(My.Settings.WRST_CaribouConnectionString, Sql)
            Me.ResultsDataGridView.DataSource = ResultsDataTable
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub

    ''' <summary>
    ''' Runs the query in Sql against the WRST_Caribou database using ConnectionString and returns the results as a DataTable
    ''' </summary>
    ''' <param name="ConnectionString"></param>
    ''' <param name="Sql"></param>
    ''' <returns>DataTable</returns>
    Private Function GetDataTable(ConnectionString As String, Sql As String) As DataTable
        'the DataTable to return
        Dim MyDataTable As New DataTable

        Try
            'make a SqlConnection using the supplied ConnectionString 
            Dim MySqlConnection As New SqlConnection(ConnectionString)
            Using MySqlConnection
                'make a query using the supplied Sql
                Dim MySqlCommand As SqlCommand = New SqlCommand(Sql, MySqlConnection)

                'open the connection
                MySqlConnection.Open()

                'create a DataReader and execute the SqlCommand
                Dim MyDataReader As SqlDataReader = MySqlCommand.ExecuteReader()

                'load the reader into the datatable
                MyDataTable.Load(MyDataReader)

                'clean up
                MyDataReader.Close()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try


        'return the datatable
        Return MyDataTable
    End Function

    ''' <summary>
    ''' Toggles GridEX between Card and TableView
    ''' </summary>
    ''' <param name="GridEX"></param>
    Private Sub ToggleGridEXTableCardView(GridEX As GridEX)
        Try
            If GridEX.View = View.TableView Then
                GridEX.View = View.CardView
            Else
                GridEX.View = View.TableView
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub

    Private Sub CampaignsGridEX_DoubleClick(sender As Object, e As EventArgs) Handles CampaignsGridEX.DoubleClick
        ToggleGridEXTableCardView(Me.CampaignsGridEX)
    End Sub

    Private Sub SurveyFlightsGridEX_DoubleClick(sender As Object, e As EventArgs) Handles SurveyFlightsGridEX.DoubleClick
        ToggleGridEXTableCardView(Me.SurveyFlightsGridEX)
    End Sub



    ''' <summary>
    ''' Allows the user to select a waypoints file as exported from DNRGPS and load it into the caribou datbase's population estimate table
    ''' </summary>
    Private Sub ImportPopulationSurveyWaypoints()
        Try
            'we must have a FlightID to create child records
            If Not Me.SurveyFlightsGridEX.CurrentRow.Cells("FlightID") Is Nothing And Not Me.SurveyFlightsGridEX.CurrentRow.Cells("Herd") Is Nothing Then
                If Not IsDBNull(Me.SurveyFlightsGridEX.CurrentRow.Cells("FlightID")) And Not IsDBNull(Me.SurveyFlightsGridEX.CurrentRow.Cells("Herd")) Then

                    'we also require a flightid and a herd from the survey record
                    Dim FlightID As String = Me.SurveyFlightsGridEX.CurrentRow.Cells("FlightID").Value
                    Dim Herd As String = Me.SurveyFlightsGridEX.CurrentRow.Cells("Herd").Value

                    'herd must be mentasta or chisana
                    Herd = Herd.Trim
                    If Herd <> "Mentasta" And Herd <> "Chisana" Then
                        MsgBox("Herd must be 'Mentasta' or 'Chisana'")
                        Exit Sub
                    End If

                    'get the excel file of waypoints
                    Dim WaypointsImportFile As String = GetWaypointsFile()

                    'make sure the file exists
                    If My.Computer.FileSystem.FileExists(WaypointsImportFile) Then

                        'get the waypoints file into a FileInfo to get more info about it
                        Dim WaypointsImportFileInfo As New FileInfo(WaypointsImportFile)

                        'load the waypoints to import into a datatable
                        Dim WaypointsImportDataTable As DataTable = WaypointFileToDataTable(WaypointsImportFileInfo.FullName)
                        Dim WaypointsPreviewDataTable As DataTable = Me.WRST_CaribouDataSet.Tables("PopulationEstimate").Clone()
                        WaypointsPreviewDataTable.Clear()

                        'Load the waypoints into a datatable
                        If Not WaypointsImportDataTable Is Nothing Then
                            If WaypointsImportDataTable.Rows.Count > 0 Then

                                'GroupNumber should be an autonumber column.  it's possible that the user will import more waypoints after already having done so
                                'get the max existing GroupNumber so we can increment by one
                                Dim GroupNumber As Integer = 1
                                'find out if there are existing waypoints, if so, set the groupnumber to the max value
                                Dim CurrentDataTable As DataTable = Me.WRST_CaribouDataSet.Tables("PopulationEstimate")
                                Dim Filter As String = "FlightID='" & FlightID & "'"
                                Dim MaxGroupNumberDataView As DataView = New DataView(CurrentDataTable, Filter, "", DataViewRowState.CurrentRows)
                                If MaxGroupNumberDataView.ToTable.Rows.Count > 0 Then
                                    GroupNumber = MaxGroupNumberDataView.ToTable.Compute("Max(GroupNumber)", Filter) + 1
                                End If


                                'loop through the records in the import file, extract values
                                For Each Row As DataRow In WaypointsImportDataTable.Rows
                                    'if we don't have a location then we have nothing for the row
                                    If Not IsDBNull(Row.Item("IDENT")) And Not IsDBNull(Row.Item("LAT")) And Not IsDBNull(Row.Item("LONG")) Then
                                        Dim Ident As String = ""
                                        Dim Latitude As Double = 0
                                        Dim Longitude As Double = 0
                                        Dim SightingDate As String = ""

                                        If Not IsDBNull(Row.Item("IDENT")) Then Ident = Row.Item("IDENT")
                                        If Not IsDBNull(Row.Item("LAT")) Then Latitude = Row.Item("LAT")
                                        If Not IsDBNull(Row.Item("LONG")) Then Longitude = Row.Item("LONG")

                                        'dnrgps always *cks up the date.  sometimes it's in the LTIME column, other times in the DESC
                                        Dim LTIME As DateTime
                                        If Not IsDBNull(Row.Item("LTIME")) And IsDate(Row.Item("LTIME")) Then
                                            LTIME = Row.Item("LTIME").ToString
                                        End If

                                        'Dim DESC As DateTime
                                        'If Not IsDBNull(Row.Item("DESC")) And IsDate(Row.Item("DESC")) Then
                                        '    DESC = Row.Item("DESC")
                                        'End If

                                        'determine if ltime is better than desc for a waypoint collection date
                                        If IsDate(LTIME) = True And DatePart(DateInterval.Year, LTIME) > 1980 Then
                                            SightingDate = LTIME.ToString
                                            'ElseIf IsDate(DESC) = True Then
                                            '    SightingDate = DESC
                                        End If

                                        'create a new row and add data to it
                                        Dim NewRow As DataRow = WaypointsPreviewDataTable.NewRow
                                        NewRow.Item("WaypointName") = Ident
                                        NewRow.Item("Lat") = Latitude
                                        NewRow.Item("Lon") = Longitude
                                        NewRow.Item("Herd") = Herd
                                        NewRow.Item("SearchArea") = "Alaska"
                                        NewRow.Item("GroupNumber") = GroupNumber
                                        NewRow.Item("WaypointName") = Ident
                                        NewRow.Item("SightingDate") = SightingDate
                                        NewRow.Item("SmallBull") = 0
                                        NewRow.Item("MediumBull") = 0
                                        NewRow.Item("LargeBull") = 0
                                        NewRow.Item("Cow") = 0
                                        NewRow.Item("Calf") = 0
                                        NewRow.Item("InOrOut") = 0
                                        NewRow.Item("Seen") = 0
                                        NewRow.Item("Marked") = 0
                                        NewRow.Item("Lat") = Latitude
                                        NewRow.Item("Lon") = Longitude
                                        NewRow.Item("SourceFilename") = WaypointsImportFileInfo.Name
                                        NewRow.Item("FlightID") = FlightID
                                        NewRow.Item("EID") = Guid.NewGuid.ToString
                                        NewRow.Item("RecordInsertedDate") = Now
                                        NewRow.Item("RecordInsertedBy") = My.User.Name

                                        'add the row to the preview datatable
                                        WaypointsPreviewDataTable.Rows.Add(NewRow)

                                        'increment the group number
                                        GroupNumber = GroupNumber + 1
                                    End If

                                Next

                                'show the imported waypoints in a form so the user can validate them for importing
                                Dim WaypointsPreviewForm As New WaypointsPreviewForm(WaypointsPreviewDataTable)
                                WaypointsPreviewForm.ShowDialog()
                                If WaypointsPreviewForm.CorrectCheckBox.Checked = True Then
                                    'finally, import the records!
                                    For Each WPRow As DataRow In WaypointsPreviewDataTable.Rows
                                        Me.WRST_CaribouDataSet.Tables("PopulationEstimate").ImportRow(WPRow)
                                    Next
                                    MsgBox("Waypoints imported successfully.")
                                End If
                            Else
                                MsgBox("No records.")
                            End If
                        Else
                            MsgBox("Waypoints input DataTable does not exist.")
                        End If
                    Else
                        MsgBox("Input file does not exist")
                    End If
                Else
                    MsgBox("FlightID and Herd are required parts of the Survey record.")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub



    ''' <summary>
    ''' Allows the user to select a waypoints file as exported from DNRGPS and load it into the caribou database's composition count table
    ''' </summary>
    Private Sub ImportCompositionCountDNRGarminWaypoints()
        Try
            'we must have a FlightID to create child records
            If Not Me.SurveyFlightsGridEX.CurrentRow.Cells("FlightID") Is Nothing And Not Me.SurveyFlightsGridEX.CurrentRow.Cells("Herd") Is Nothing Then
                If Not IsDBNull(Me.SurveyFlightsGridEX.CurrentRow.Cells("FlightID")) And Not IsDBNull(Me.SurveyFlightsGridEX.CurrentRow.Cells("Herd").Value) Then

                    'we also require a flightid and a herd from the survey record
                    Dim FlightID As String = Me.SurveyFlightsGridEX.CurrentRow.Cells("FlightID").Value
                    Dim Herd As String = Me.SurveyFlightsGridEX.CurrentRow.Cells("Herd").Value

                    'herd must be mentasta or chisana
                    If Herd.Trim <> "Mentasta" And Herd.Trim <> "Chisana" Then
                        MsgBox("Herd must be 'Mentasta' or 'Chisana'")
                        Exit Sub
                    End If

                    'get the excel file of waypoints
                    Dim WaypointsImportFile As String = GetWaypointsFile()

                    'make sure the file exists
                    If My.Computer.FileSystem.FileExists(WaypointsImportFile) Then

                        'get the waypoints file into a FileInfo to get more info about it
                        Dim WaypointsImportFileInfo As New FileInfo(WaypointsImportFile)

                        'load the waypoints to import into a datatable
                        Dim WaypointsImportDataTable As DataTable = WaypointFileToDataTable(WaypointsImportFileInfo.FullName)
                        Dim WaypointsPreviewDataTable As DataTable = Me.WRST_CaribouDataSet.Tables("CompositionCounts").Clone()
                        WaypointsPreviewDataTable.Clear()

                        'Load the waypoints into a datatable
                        If Not WaypointsImportDataTable Is Nothing Then
                            If WaypointsImportDataTable.Rows.Count > 0 Then

                                'GroupNumber should be an autonumber column.  it's possible that the user will import more waypoints after already having done so
                                'get the max existing GroupNumber so we can increment by one
                                Dim GroupNumber As Integer = 1
                                'find out if there are existing waypoints, if so, set the groupnumber to the max value
                                Dim CurrentDataTable As DataTable = Me.WRST_CaribouDataSet.Tables("CompositionCounts")
                                Dim Filter As String = "FlightID='" & FlightID & "'"
                                Dim MaxGroupNumberDataView As DataView = New DataView(CurrentDataTable, Filter, "", DataViewRowState.CurrentRows)
                                If MaxGroupNumberDataView.ToTable.Rows.Count > 0 Then
                                    GroupNumber = MaxGroupNumberDataView.ToTable.Compute("Max(GroupNumber)", Filter) + 1
                                End If

                                'loop through the records in the import file, extract values
                                For Each Row As DataRow In WaypointsImportDataTable.Rows
                                    'if we don't have a location then we have nothing for the row
                                    If Not IsDBNull(Row.Item("IDENT")) And Not IsDBNull(Row.Item("LAT")) And Not IsDBNull(Row.Item("LONG")) Then
                                        Dim Ident As String = ""
                                        Dim Latitude As Double = 0
                                        Dim Longitude As Double = 0
                                        Dim SightingDate As DateTime

                                        If Not IsDBNull(Row.Item("IDENT")) Then Ident = Row.Item("IDENT")
                                        'If Not IsDBNull(Row.Item("LATITUDE")) Then Latitude = Row.Item("LATITUDE")
                                        'If Not IsDBNull(Row.Item("LONGITUDE")) Then Longitude = Row.Item("LONGITUDE")
                                        If Not IsDBNull(Row.Item("LAT")) Then Latitude = Row.Item("LAT")
                                        If Not IsDBNull(Row.Item("LONG")) Then Longitude = Row.Item("LONG")

                                        'dnrgps always *cks up the date.  sometimes it's in the LTIME column, other times in the DESC
                                        Dim LTIME As DateTime
                                        If Not IsDBNull(Row.Item("LTIME")) And IsDate(Row.Item("LTIME")) Then
                                            LTIME = Row.Item("LTIME")
                                        End If

                                        'Dim DESC As String = ""
                                        'If Not Row.Item("DESC") Is Nothing Then
                                        '    If Not IsDBNull(Row.Item("DESC")) And IsDate(Row.Item("DESC")) Then
                                        '        DESC = Row.Item("DESC").ToString
                                        '    End If
                                        'End If

                                        'determine if ltime is better than desc for a waypoint collection date
                                        If IsDate(LTIME) = True And DatePart(DateInterval.Year, LTIME) > 1980 Then
                                            SightingDate = LTIME
                                            'ElseIf IsDate(DESC) = True Then
                                            '    SightingDate = DESC
                                        End If

                                        'create a new row and add data to it
                                        Dim NewRow As DataRow = WaypointsPreviewDataTable.NewRow
                                        NewRow.Item("Waypoint") = Ident
                                        NewRow.Item("Lat") = Latitude
                                        NewRow.Item("Lon") = Longitude
                                        NewRow.Item("Herd") = Herd
                                        NewRow.Item("SearchArea") = "Alaska"
                                        NewRow.Item("GroupNumber") = GroupNumber
                                        NewRow.Item("SightingDate") = SightingDate
                                        NewRow.Item("SmallBull") = 0
                                        NewRow.Item("MediumBull") = 0
                                        NewRow.Item("LargeBull") = 0
                                        NewRow.Item("Cow") = 0
                                        NewRow.Item("Calf") = 0
                                        NewRow.Item("Indeterminate") = 0
                                        NewRow.Item("Lat") = Latitude
                                        NewRow.Item("Lon") = Longitude
                                        NewRow.Item("SourceFilename") = WaypointsImportFileInfo.Name
                                        NewRow.Item("FlightID") = FlightID
                                        NewRow.Item("CCID") = Guid.NewGuid.ToString
                                        NewRow.Item("RecordInsertedDate") = Now
                                        NewRow.Item("RecordInsertedBy") = My.User.Name

                                        'add the row to the preview datatable
                                        WaypointsPreviewDataTable.Rows.Add(NewRow)

                                        'increment the group number
                                        GroupNumber = GroupNumber + 1
                                    End If

                                Next

                                'show the imported waypoints in a form so the user can validate them for importing
                                Dim WaypointsPreviewForm As New WaypointsPreviewForm(WaypointsPreviewDataTable)
                                WaypointsPreviewForm.ShowDialog()
                                If WaypointsPreviewForm.CorrectCheckBox.Checked = True Then
                                    'finally, import the records!
                                    For Each WPRow As DataRow In WaypointsPreviewDataTable.Rows
                                        Me.WRST_CaribouDataSet.Tables("CompositionCounts").ImportRow(WPRow)
                                    Next
                                    MsgBox("Waypoints imported successfully.")
                                End If
                            Else
                                MsgBox("No records.")
                            End If
                        Else
                            MsgBox("Waypoints input DataTable does not exist.")
                        End If
                    Else
                        MsgBox("Input file does not exist")
                    End If
                Else
                    MsgBox("FlightID and Herd are required parts of the Survey record.")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub



    ''' <summary>
    ''' Opens an OpenFileDialog to allow the user to select a DNRGPS waypoints file.
    ''' </summary>
    ''' <returns>The selected waypoints file. String</returns>
    Private Function GetWaypointsFile() As String
        Dim ExcelFile As String = ""
        Try
            Dim OFD As New OpenFileDialog
            With OFD
                .AddExtension = True
                .CheckFileExists = True
                .Filter = "DNRGPS file (Excel,DBF,CSV,TXT)|*.xlsx;*.xls;*.dbf;*.csv;*.txt"
                .Multiselect = False
                .Title = "Select an workbook to open"
            End With

            'show the ofd and get the filename and path
            If OFD.ShowDialog = DialogResult.OK Then
                ExcelFile = OFD.FileName
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
        Return ExcelFile
    End Function

    Private Sub ImportCompCountWaypointsToolStripButton_Click(sender As Object, e As EventArgs) Handles ImportCompCountWaypointsToolStripButton.Click
        ImportCompositionCountDNRGarminWaypoints()
    End Sub

    Private Sub ResultsByToolStripButton_Click(sender As Object, e As EventArgs)
        'loads the results of the population survey into the Results GridEX
        LoadPopulationEstimateSurveyResults(GetCurrentCampaignID)
    End Sub



    ''' <summary>
    ''' Queries the Animal_Movement database for deployed GPS collars during SightingDate and then loads the submitted GridEX's AnimalID column
    ''' with available collared animals based on collar frequency.
    ''' </summary>
    ''' <param name="GridEx">Parent GridEX</param>
    ''' <param name="ObservationDate">Results will be filtered by available GPS collars deployed on this date.</param>
    Private Sub LoadCollaredCaribouDropdown(GridEx As GridEX, ObservationDate As Date)
        'Caribou groups often contain GPS collared animals. 
        'When this event fires the user wants to associate a collared caribou with a group of caribou seen during a population survey.
        'The collar is detected by radio frequency.  We need to find out which collar was detected and which animal the collar was deployed on.
        'These data come from the Animal_Movement database.  Query based on survey date and frequency to determine which animal to associate with 
        ' the population survey group.

        Try
            'Ensure the GridEXColumn is configured for a DropDown
            With GridEx.RootTable.Columns("AnimalID")
                .EditType = EditType.Combo
                .HasValueList = True
                .LimitToList = False
                .AllowSort = True
                .AutoComplete = True
                .ValueList.Clear()
            End With

            'retrieve the animal associated with the collar that was deployed during the time of the survey.  i.e.:
            Dim Sql As String = "SELECT   Collars.Frequency, Animals.ProjectId, Animals.AnimalId,CollarDeployments.DeploymentDate, CollarDeployments.RetrievalDate
FROM            Animals INNER JOIN
                         CollarDeployments ON Animals.ProjectId = CollarDeployments.ProjectId AND Animals.AnimalId = CollarDeployments.AnimalId INNER JOIN
                         Collars ON CollarDeployments.CollarManufacturer = Collars.CollarManufacturer AND CollarDeployments.CollarId = Collars.CollarId
WHERE        (Animals.ProjectId = 'WRST_Caribou') And (DeploymentDate < '" & ObservationDate & "' And (RetrievalDate is NULL or RetrievalDate > '" & ObservationDate & "'))
ORDER BY Collars.Frequency"
            '            Dim Sql As String = "SELECT   Collars.Frequency,      Animals.ProjectId, Animals.AnimalId,CollarDeployments.DeploymentDate, CollarDeployments.RetrievalDate, Animals.Species, Animals.Gender, Animals.MortalityDate, Animals.GroupName, Animals.Description, CollarDeployments.CollarId, CollarDeployments.CollarManufacturer, 
            '                          Collars.CollarModel, Collars.Manager, Collars.Owner, Collars.SerialNumber, Collars.HasGps, Collars.Notes, 
            '                         Collars.DisposalDate
            'FROM            Animals INNER JOIN
            '                         CollarDeployments ON Animals.ProjectId = CollarDeployments.ProjectId AND Animals.AnimalId = CollarDeployments.AnimalId INNER JOIN
            '                         Collars ON CollarDeployments.CollarManufacturer = Collars.CollarManufacturer AND CollarDeployments.CollarId = Collars.CollarId
            'WHERE        (Animals.ProjectId = 'WRST_Caribou') And (DeploymentDate < '" & ObservationDate & "' And (RetrievalDate is NULL or RetrievalDate > '" & ObservationDate & "'))
            'ORDER BY Collars.Frequency"

            'get the filtered data into a datatable
            Dim PossibleCollaredAnimalsDataTable As DataTable = GetDataTable(My.Settings.Animal_MovementConnectionString, Sql)

            'Add the animalids into the GridEXValueListItemCollection
            If PossibleCollaredAnimalsDataTable.Rows.Count > 0 Then
                For Each Row As DataRow In PossibleCollaredAnimalsDataTable.Rows
                    If Not IsDBNull(Row.Item("AnimalID")) And Not IsDBNull(Row.Item("Frequency")) Then
                        Dim ValueItem As String = Row.Item("AnimalID")
                        Dim DisplayItem As String = Row.Item("AnimalID") & " Freq:" & Row.Item("Frequency")
                        GridEx.RootTable.Columns("AnimalID").ValueList.Add(ValueItem, DisplayItem)
                    End If
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub

    Private Sub PopulationEstimateGridEX_SelectionChanged(sender As Object, e As EventArgs) Handles PopulationEstimateGridEX.SelectionChanged
        'when the user clicks on a population survey caribou group, then load the xrefcariboupopulation gridex with available 
        'gps collars to allow the user to associate a collared caribou with the observed group

        Try
            'determine the EID, primary key of the caribou group record, and set the default value to the new xrefcariboupopulation record
            Dim EID As String = ""
            Dim SightingDate As Date

            'get the sighting date to use later, and get the EID to relate to any new xrefcariboupopulation records
            With PopulationEstimateGridEX
                If Not .CurrentRow Is Nothing Then
                    'get the SightingDate
                    If Not .CurrentRow.Cells("SightingDate") Is Nothing And Not IsDBNull(.CurrentRow.Cells("SightingDate")) Then
                        If Not IsDBNull(.CurrentRow.Cells("SightingDate").Value) Then SightingDate = .CurrentRow.Cells("SightingDate").Value
                    End If

                    'set up the EID primary key for syncing with the group
                    If Not .CurrentRow.Cells("EID") Is Nothing And Not IsDBNull(.CurrentRow.Cells("EID")) Then
                        If Not IsDBNull(.CurrentRow.Cells("EID").Value) Then
                            EID = .CurrentRow.Cells("EID").Value
                        End If
                        Me.XrefPopulationCaribouGridEX.RootTable.Columns("EID").DefaultValue = EID
                    End If
                End If
            End With

            'if we have a valid observation date and an EID then load the collar selector dropdown with available collars
            'If Not EID Is Nothing Then
            '    If IsDate(SightingDate) And EID.Trim.Length > 0 Then
            'load the AnimalID with a selection of collars that were deployed on the date the caribou group was observed
            LoadCollaredCaribouDropdown(Me.XrefPopulationCaribouGridEX, SightingDate)
            '    End If
            'End If
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub

    Private Sub XrefPopulationCaribouGridEX_SelectionChanged(sender As Object, e As EventArgs) Handles XrefPopulationCaribouGridEX.SelectionChanged
        Dim Grid As GridEX = Me.XrefPopulationCaribouGridEX
        Grid.RootTable.Columns("PCID").DefaultValue = Guid.NewGuid.ToString 'primary key
        Grid.RootTable.Columns("RecordInsertedDate").DefaultValue = Now
        Grid.RootTable.Columns("RecordInsertedBy").DefaultValue = My.User.Name
        Grid.RootTable.Columns("ProjectID").DefaultValue = "WRST_Caribou" 'always 'WRST_Caribou', primary key, with AnimalID in the Animal_Movement database for the GPS collar
    End Sub

    Private Sub ImportPopulationWaypointsToolStripButton_Click(sender As Object, e As EventArgs) Handles ImportPopulationWaypointsToolStripButton.Click
        ImportPopulationSurveyWaypoints()
    End Sub


End Class

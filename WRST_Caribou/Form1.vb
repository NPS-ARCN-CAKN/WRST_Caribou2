'todo animal_movement connectivity

Imports System.Data.SqlClient
Imports System.IO
Imports Janus.Windows.GridEX
Imports SkeeterDataTablesTranslator

Public Class Form1

    Dim ResultsDataTable As DataTable 'This reusable datatable will contain the data to be displayed in the Me.SurveyResultsDataGridView of the Results tab

    Private Sub CampaignsBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        SaveDataset()
    End Sub

    ''' <summary>
    ''' Save any pending changes in the in-memory Dataset, with confirmation, back to the database.
    ''' </summary>
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
                    Me.WRST_CaribouDataSet.AcceptChanges()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try

    End Sub



    Private Sub LoadDataset()
        Try
            'load the data
            Me.CampaignsTableAdapter.Fill(Me.WRST_CaribouDataSet.Campaigns)
            Me.SurveyFlightsTableAdapter.Fill(Me.WRST_CaribouDataSet.SurveyFlights)
            Me.CapturesTableAdapter.Fill(Me.WRST_CaribouDataSet.Captures)
            Me.CaribouTableAdapter.Fill(Me.WRST_CaribouDataSet.Caribou)
            Me.RadioTrackingTableAdapter.Fill(Me.WRST_CaribouDataSet.RadioTracking)
            Me.PopulationEstimateTableAdapter.Fill(Me.WRST_CaribouDataSet.PopulationEstimate)
            Me.CompositionCountsTableAdapter.Fill(Me.WRST_CaribouDataSet.CompositionCounts)
            Me.XrefPopulationCaribouTableAdapter.Fill(Me.WRST_CaribouDataSet.xrefPopulationCaribou)
            Me.XrefCompCountCaribouTableAdapter.Fill(Me.WRST_CaribouDataSet.xrefCompCountCaribou)
            Me.XrefRadiotrackingCaribouTableAdapter.Fill(Me.WRST_CaribouDataSet.xrefRadiotrackingCaribou)

            'load the animals inventory grid from animal_movement database
            LoadAnimalMovementsAnimalsGrid()

            'update the campaign header with info about the current campaign
            Me.CampaignHeaderLabel.Text = GetCurrentCampaignHeader()
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'set up the form
        Me.DatabaseViewNameToolStripLabel.Text = ""


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

        'Set up the RadiotrackingGridEX default values and dropdowns
        SetUpRadiotrackingGridEX()

        'Set up the population surveys grid default values and dropdowns
        SetUpPopulationEstimateGridEX()

        'Load the Campaign header 
        LoadCampaignHeader()

        'maximize form
        Me.WindowState = FormWindowState.Maximized

    End Sub

    ''' <summary>
    ''' Sets up the RadiotrackingGridEX with default values and other settings
    ''' </summary>
    Private Sub SetUpRadiotrackingGridEX()
        Try
            'Set up default values
            Dim Grid As GridEX = Me.RadioTrackingGridEX

            'Herd dropdown
            With Grid.RootTable.Columns("Herd")
                .HasValueList = True
                .LimitToList = True
                .ValueList.Clear()
            End With

            'Herd dropdown
            Dim SurveysHerdList As GridEXValueListItemCollection = Me.RadioTrackingGridEX.RootTable.Columns("Herd").ValueList
            SurveysHerdList.Add("Chisana", "Chisana")
            SurveysHerdList.Add("Mentasta", "Mentasta")

            'Mode dropdown
            With Grid.RootTable.Columns("Mode")
                .HasValueList = True
                .LimitToList = True
                .ValueList.Clear()
            End With
            Dim SurveysModeList As GridEXValueListItemCollection = Me.RadioTrackingGridEX.RootTable.Columns("Mode").ValueList
            SurveysModeList.Add("A", "Automatic")
            SurveysModeList.Add("M", "Manual")

            'Accuracy dropdown
            With Grid.RootTable.Columns("Accuracy")
                .HasValueList = True
                .LimitToList = True
                .ValueList.Clear()
            End With
            Dim SurveysAccuracyList As GridEXValueListItemCollection = Me.RadioTrackingGridEX.RootTable.Columns("Accuracy").ValueList
            SurveysAccuracyList.Add(1, 1)
            SurveysAccuracyList.Add(2, 2)
            SurveysAccuracyList.Add(3, 3)

            'load the radiotracking gridex search areas dropdown
            With Grid.RootTable.Columns("SearchArea")
                .HasValueList = True
                .LimitToList = True
                .ValueList.Clear()
            End With

            'this line loads the csv list of search areas from my.settings into a datatable
            Dim SearchAreasDataTable As DataTable = GetSearchAreasDataTable()
            'get a ref to the searchareas valuelist
            Dim SearchAreasList As GridEXValueListItemCollection = Me.RadioTrackingGridEX.RootTable.Columns("SearchArea").ValueList
            'load in the searcharea items into the combobox
            For Each Row As DataRow In SearchAreasDataTable.Rows
                Dim SearchArea As String = Row.Item("SearchArea")
                SearchAreasList.Add(SearchArea, SearchArea)
            Next
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub



    ''' <summary>
    ''' Sets up the SurveysGridEX default values and DropDowns/Combos
    ''' </summary>
    Private Sub SetUpSurveysGridEX()

        'Set up default values
        Dim Grid As GridEX = Me.SurveyFlightsGridEX
        Grid.RootTable.Columns("FlightID").DefaultValue = Guid.NewGuid.ToString
        Grid.RootTable.Columns("SOPNumber").DefaultValue = 0
        Grid.RootTable.Columns("RecordInsertedDate").DefaultValue = Now
        Grid.RootTable.Columns("RecordInsertedBy").DefaultValue = My.User.Name
        Grid.RootTable.Columns("CertificationLevel").DefaultValue = "Provisional"

        'CrewNumber default value
        Dim MaxCrewNumber As Integer = 0
        For Each row As GridEXRow In Grid.GetRows()
            If row.Cells("CrewNumber").Value > MaxCrewNumber Then
                MaxCrewNumber = row.Cells("CrewNumber").Value
            End If
        Next
        Grid.RootTable.Columns("CrewNumber").DefaultValue = MaxCrewNumber + 1

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
    ''' Sets up the SurveysGridEX default values and DropDowns/Combos
    ''' </summary>
    Private Sub SetUpPopulationEstimateGridEX()

        'Set up default values
        Dim Grid As GridEX = Me.PopulationEstimateGridEX
        Grid.RootTable.Columns("EID").DefaultValue = Guid.NewGuid.ToString
        Grid.RootTable.Columns("RecordInsertedDate").DefaultValue = Now
        Grid.RootTable.Columns("RecordInsertedBy").DefaultValue = My.User.Name

        'Herd dropdown
        With Grid.RootTable.Columns("Herd")
            .HasValueList = True
            .LimitToList = True
            .ValueList.Clear()
            .EditType = EditType.DropDownList
        End With
        Dim HerdList As GridEXValueListItemCollection = Grid.RootTable.Columns("Herd").ValueList
        HerdList.Add("Chisana", "Chisana")
        HerdList.Add("Mentasta", "Mentasta")

        'search areas dropdown
        'this line loads the csv list of search areas from my.settings into a datatable
        Dim SearchAreasDataTable As DataTable = GetSearchAreasDataTable()

        'set up the search area column to accept a dropdown
        With Grid.RootTable.Columns("SearchArea")
            .HasValueList = True
            .LimitToList = True
            .ValueList.Clear()
            .EditType = EditType.DropDownList
        End With

        'get a ref to the searchareas valuelist
        Dim SearchAreasList As GridEXValueListItemCollection = Grid.RootTable.Columns("SearchArea").ValueList
        'load in the searcharea items into the combobox
        For Each Row As DataRow In SearchAreasDataTable.Rows
            Dim SearchArea As String = Row.Item("SearchArea")
            SearchAreasList.Add(SearchArea, SearchArea)
        Next

    End Sub

    ''' <summary>
    ''' Set up CampaignsGridEX dropdowns
    ''' </summary>
    Private Sub SetUpCampaignsGridEX()
        Try
            'on startup set the flights and data gridexes invisible so user needs to explicitly select a campaign
            'if the campaign header is "" then set the tabcontrol invisible until a campaign is selected
            Me.CampaignTabControl.Visible = Not Me.CampaignHeaderLabel.Text = ""

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
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
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
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
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
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub

    Private Sub SaveChangesToDatabaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveChangesToDatabaseToolStripMenuItem.Click
        SaveDataset()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        SaveDataset()
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


    Private Function GetCurrentCampaignHeader() As String
        'get the name of the survey campaign to put it into the survey flights header
        Dim CurrentCampaign As String = "Flights"
        Try
            If Not Me.CampaignsGridEX.CurrentRow Is Nothing Then
                If Not Me.CampaignsGridEX.CurrentRow.Cells("Campaign") Is Nothing And Not IsDBNull(Me.CampaignsGridEX.CurrentRow.Cells("Campaign").Value) Then
                    CurrentCampaign = Me.CampaignsGridEX.CurrentRow.Cells("Campaign").Value
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
        Return CurrentCampaign
    End Function

    Private Sub LoadCampaignHeader()
        Try
            'get the name of the survey campaign to put it into the survey flights header
            Me.CampaignHeaderLabel.Text = "Flights"
            Dim CurrentCampaign As String = "Flights"
            If Not Me.CampaignsGridEX.CurrentRow Is Nothing Then
                'update the campaign header with info about the current campaign
                Me.CampaignHeaderLabel.Text = GetCurrentCampaignHeader()

                'set up the flight gridex's 'herd' column default value
                If Not Me.CampaignsGridEX.CurrentRow.Cells("Herd") Is Nothing And Not IsDBNull(Me.CampaignsGridEX.CurrentRow.Cells("Herd").Value) Then
                    Dim CampaignHerd As String = Me.CampaignsGridEX.CurrentRow.Cells("Herd").Value
                    Me.SurveyFlightsGridEX.RootTable.Columns("Herd").DefaultValue = CampaignHerd

                    'while we're here set up the Herd column in the radiotracking gridex to match what's in the campaign
                    Me.RadioTrackingGridEX.RootTable.Columns("Herd").DefaultValue = CampaignHerd
                Else
                    Me.CampaignHeaderLabel.Text = CurrentCampaign
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub

#Region "GridEX_SelectionChanged"
    Private Sub CampaignsGridEX_SelectionChanged(sender As Object, e As EventArgs) Handles CampaignsGridEX.SelectionChanged
        'user gets here when they select a campaign from the campaigns gridex

        'load the campaign header
        LoadCampaignHeader()

        'set up the gridexes for consistency
        SetUpCampaignsGridEX()
        Try
            'set the survey type tab control to the current survey type
            Dim CurrentSurveyType As String = ""
            If Not Me.CampaignsGridEX.CurrentRow Is Nothing Then

                If Not Me.CampaignsGridEX.CurrentRow.Cells("SurveyType") Is Nothing Then
                    If Not IsDBNull(Me.CampaignsGridEX.CurrentRow.Cells("SurveyType").Value) Then
                        CurrentSurveyType = Me.CampaignsGridEX.CurrentRow.Cells("SurveyType").Value

                        'clear the results datagridview
                        Me.ResultsDataGridView.DataSource = Nothing

                        'bring forward the correct data entry tab based on the survey type
                        Select Case CurrentSurveyType
                            Case "Composition"
                                Me.SurveyDataTabControl.SelectedTab = Me.CompositionCountTabPage
                                DisableUnneededTabs("Composition")

                                'summarize the campaign's results by querying the sql server and showing results in the resultsdatagridview
                                LoadCampaignResults(GetCurrentCampaignID, "CC_ResultsByCampaign")
                            Case "Population"
                                Me.SurveyDataTabControl.SelectedTab = Me.PopulationTabPage
                                DisableUnneededTabs("Population")
                                'summarize the campaign's results by querying the sql server and showing results in the resultsdatagridview
                                LoadCampaignResults(GetCurrentCampaignID, "PE_ResultsByCampaign")
                            Case "Radiotracking"
                                Me.SurveyDataTabControl.SelectedTab = Me.RadiotrackingTabPage
                                DisableUnneededTabs("Radiotracking")

                                'summarize the campaign's results by querying the sql server and showing results in the resultsdatagridview
                                LoadCampaignResults(GetCurrentCampaignID, "RT_ResultsByCampaign")
                            Case Else
                                Me.SurveyDataTabControl.SelectedTab = Me.CompositionCountTabPage
                        End Select
                    End If
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub

    Private Sub SurveyFlightsGridEX_SelectionChanged(sender As Object, e As EventArgs) Handles SurveyFlightsGridEX.SelectionChanged
        Try
            'get some information about the survey flight to put in the header label so users know which survey flight they are editing
            Me.FlightContextLabel.Text = "Caribou: "
            Dim CurrentFlight As String = "Caribou: "
            Dim CrewNumber As Integer = 0
            Dim TailNo As String = ""
            Dim Pilot As String = ""
            Dim Observer1 As String = ""
            Dim TimeDepart As Date = "1/1/1111"
            Dim FlightID As String = ""

            'set up default values for child tables and also set up a header for user context
            If Not Me.SurveyFlightsGridEX.CurrentRow Is Nothing Then
                If Not Me.SurveyFlightsGridEX.CurrentRow.Cells("FlightID") Is Nothing Then

                    'set up flightid default values for child tables
                    FlightID = Me.SurveyFlightsGridEX.CurrentRow.Cells("FlightID").Value
                    Me.RadioTrackingGridEX.RootTable.Columns("FlightID").DefaultValue = FlightID
                    Me.CompositionCountsGridEX.RootTable.Columns("FlightID").DefaultValue = FlightID
                    Me.PopulationEstimateGridEX.RootTable.Columns("FlightID").DefaultValue = FlightID

                    If Not Me.SurveyFlightsGridEX.CurrentRow.Cells("CrewNumber") Is Nothing And Not Me.SurveyFlightsGridEX.CurrentRow.Cells("TailNo") Is Nothing And Not Me.SurveyFlightsGridEX.CurrentRow.Cells("Pilot") Is Nothing And Not Me.SurveyFlightsGridEX.CurrentRow.Cells("Observer1") Is Nothing And Not Me.SurveyFlightsGridEX.CurrentRow.Cells("TimeDepart") Is Nothing Then
                        'set up header information
                        If Not IsDBNull(Me.SurveyFlightsGridEX.CurrentRow.Cells("CrewNumber").Value) Then CrewNumber = Me.SurveyFlightsGridEX.CurrentRow.Cells("CrewNumber").Value
                        If Not IsDBNull(Me.SurveyFlightsGridEX.CurrentRow.Cells("Pilot").Value) Then Pilot = Me.SurveyFlightsGridEX.CurrentRow.Cells("Pilot").Value Else Pilot = ""
                        If Not IsDBNull(Me.SurveyFlightsGridEX.CurrentRow.Cells("TailNo").Value) Then TailNo = Me.SurveyFlightsGridEX.CurrentRow.Cells("TailNo").Value Else TailNo = ""
                        If Not IsDBNull(Me.SurveyFlightsGridEX.CurrentRow.Cells("Observer1").Value) Then Observer1 = Me.SurveyFlightsGridEX.CurrentRow.Cells("Observer1").Value Else Observer1 = ""
                        If Not IsDBNull(Me.SurveyFlightsGridEX.CurrentRow.Cells("TimeDepart").Value) Then TimeDepart = Me.SurveyFlightsGridEX.CurrentRow.Cells("TimeDepart").Value
                        CurrentFlight = "Caribou: Crew " & CrewNumber & " " & TailNo & " " & Pilot & " & " & Observer1 & " " & TimeDepart
                        Me.FlightContextLabel.Text = CurrentFlight
                    End If
                End If
            End If


            'set up the Survey Flight GridEX
            SetUpSurveysGridEX()

            'load the GPS collared animals into the RadiotrackingGridEX's AnimalID combobox
            LoadCollaredCaribouDropdown(Me.RadioTrackingGridEX, TimeDepart)
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub

    Private Sub XrefRadiotrackingCaribouGridEX_SelectionChanged(sender As Object, e As EventArgs) Handles XrefRadiotrackingCaribouGridEX.SelectionChanged
        Dim Grid As GridEX = Me.XrefRadiotrackingCaribouGridEX
        Grid.RootTable.Columns("RTCID").DefaultValue = Guid.NewGuid.ToString 'primary key
        Grid.RootTable.Columns("RecordInsertedDate").DefaultValue = Now
        Grid.RootTable.Columns("RecordInsertedBy").DefaultValue = My.User.Name
        Grid.RootTable.Columns("ProjectID").DefaultValue = "WRST_Caribou" 'always 'WRST_Caribou', primary key, with AnimalID in the Animal_Movement database for the GPS collar
    End Sub

#End Region



    Private Sub SaveDatasetToolStripButton_Click(sender As Object, e As EventArgs) Handles SaveDatasetToolStripButton.Click
        SaveDataset()
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Me.WRST_CaribouDataSet.HasChanges Then
            SaveDataset()
        End If
    End Sub



    ''' <summary>
    ''' Disables all tab pages in the SurveyDataTabControl except any matching the EnabledTabPageText string.
    ''' </summary>
    ''' <param name="EnabledTabPageText">Text of the tab page to enable.  Others disabled.  String.</param>
    Private Sub DisableUnneededTabs(EnabledTabPageText As String)
        For Each TabPage As TabPage In Me.SurveyDataTabControl.TabPages
            If TabPage.Text = EnabledTabPageText Then
                TabPage.Enabled = True
            Else
                TabPage.Enabled = False
            End If
        Next
    End Sub

    ''' <summary>
    ''' Returns the CampaignID of the currently selected Campaign
    ''' </summary>
    ''' <returns>String</returns>
    Private Function GetCurrentCampaignID() As String
        Dim CampaignID As String = ""
        Try
            'get the current row of the VS GridEX
            If Not Me.CampaignsGridEX.CurrentRow Is Nothing Then
                Dim CurrentRow As GridEXRow = Me.CampaignsGridEX.CurrentRow
                'loop through the columns and look for the CampaignID columns
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
    ''' Returns the FlightID of the currently selected Flight
    ''' </summary>
    ''' <returns>String</returns>
    Private Function GetCurrentFlightID() As String
        Dim FlightID As String = ""
        Try
            'get the current row of the VS GridEX
            If Not Me.SurveyFlightsGridEX.CurrentRow Is Nothing Then
                Dim CurrentRow As GridEXRow = Me.SurveyFlightsGridEX.CurrentRow
                'loop through the columns and look for the FlightID columns
                For i As Integer = 0 To CurrentRow.Cells.Count - 1
                    If CurrentRow.Cells(i).Column.Key = "FlightID" Then
                        'if there is a value
                        If Not IsDBNull(CurrentRow.Cells(i).Value) Then
                            FlightID = CurrentRow.Cells(i).Value
                        End If
                    End If
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
        Return FlightID
    End Function

    ''' <summary>
    ''' Returns the Herd of the currently selected Flight
    ''' </summary>
    ''' <returns>String</returns>
    Private Function GetCurrentHerd() As String
        Dim Herd As String = ""
        Try
            'get the current row of the VS GridEX
            If Not Me.CampaignsGridEX.CurrentRow Is Nothing Then
                Dim CurrentRow As GridEXRow = Me.CampaignsGridEX.CurrentRow
                'loop through the columns and look for the Herd columns
                For i As Integer = 0 To CurrentRow.Cells.Count - 1
                    If CurrentRow.Cells(i).Column.Key = "Herd" Then
                        'if there is a value
                        If Not IsDBNull(CurrentRow.Cells(i).Value) Then
                            Herd = CurrentRow.Cells(i).Value
                        End If
                    End If
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
        Return Herd
    End Function

    ''' <summary>
    ''' Runs the Sql Server view PE_ResultsByCampaign for the survey campaign and returns the results as a DataTable to the ResultsDataGridView
    ''' </summary>
    ''' <param name="CampaignID"></param>
    Private Sub LoadCampaignResults(CampaignID As String, ViewName As String)
        Try
            'refresh the global database view name so we can access it from other tools like the refresh button
            Me.DatabaseViewNameToolStripLabel.Text = ViewName
            Dim Sql As String = "SELECT *  FROM " & ViewName & " WHERE CampaignID = '" & CampaignID & "';"
            Dim ResultsDataTable As DataTable = GetDataTable(My.Settings.WRST_CaribouConnectionString, Sql)
            Me.ResultsDataGridView.DataSource = ResultsDataTable
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub




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
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub

    Private Sub CampaignsGridEX_DoubleClick(sender As Object, e As EventArgs) Handles CampaignsGridEX.DoubleClick
        ToggleGridEXTableCardView(Me.CampaignsGridEX)
    End Sub

    Private Sub SurveyFlightsGridEX_DoubleClick(sender As Object, e As EventArgs) Handles SurveyFlightsGridEX.DoubleClick
        ToggleGridEXTableCardView(Me.SurveyFlightsGridEX)
    End Sub

#Region "Importing waypoints region"


    ''' <summary>
    ''' Allows the user to select a waypoints file as exported from DNRGPS and load it into one of the comp count, population or radiotracking database tables
    ''' </summary>
    Private Sub OpenWaypointsFile(DestinationTableName As String)
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

                    'get the  file of waypoints
                    Dim WaypointsImportFile As String = GetWaypointsFile()

                    'make sure the file exists
                    If My.Computer.FileSystem.FileExists(WaypointsImportFile) Then

                        'get the waypoints file into a FileInfo to get more info about it
                        Dim WaypointsImportFileInfo As New FileInfo(WaypointsImportFile)

                        'load the waypoints to import into a datatable
                        Dim WaypointsImportDataTable As DataTable = WaypointFileToDataTable(WaypointsImportFileInfo.FullName)
                        Dim WaypointsPreviewDataTable As DataTable = Me.WRST_CaribouDataSet.Tables(DestinationTableName).Clone()
                        WaypointsPreviewDataTable.Clear()

                        'Load the waypoints into a datatable
                        If Not WaypointsImportDataTable Is Nothing Then
                            If WaypointsImportDataTable.Rows.Count > 0 Then
                                'import the waypoint records to the proper dataset datatable based on tablename
                                If DestinationTableName = "Radiotracking" Then
                                    ImportRadiotrackingDNRGPSWaypoints(WaypointsImportDataTable, WaypointsPreviewDataTable, FlightID, Herd, WaypointsImportFileInfo)
                                ElseIf DestinationTableName = "PopulationEstimate" Then
                                    ImportPopulationSurveyDNRGPSWaypoints(WaypointsImportDataTable, WaypointsPreviewDataTable, FlightID, Herd, WaypointsImportFileInfo)
                                ElseIf DestinationTableName = "CompositionCounts" Then
                                    ImportCompositionCountDNRGPSWaypoints(WaypointsImportDataTable, WaypointsPreviewDataTable, FlightID, Herd, WaypointsImportFileInfo)
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
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub

    Private Sub ImportRadiotrackingDNRGPSWaypoints(WaypointsImportDataTable As DataTable, WaypointsPreviewDataTable As DataTable, FlightID As String, Herd As String, WaypointsImportFileInfo As FileInfo)
        Try
            'GroupNumber should be an autonumber column.  it's possible that the user will import more waypoints after already having done so
            Dim GroupNumber As Integer = GetMaximumGroupNumber(Me.WRST_CaribouDataSet.Tables("PopulationEstimate"), "FlightID='" & FlightID & "'")

            'loop through the records in the import file, extract values
            For Each Row As DataRow In WaypointsImportDataTable.Rows
                'if we don't have a location then we have nothing for the row
                If Not IsDBNull(Row.Item("IDENT")) And Not IsDBNull(Row.Item("LAT")) And Not IsDBNull(Row.Item("LONG")) Then
                    Dim Ident As String = ""
                    Dim Latitude As Double = 0
                    Dim Longitude As Double = 0
                    Dim SightingDate As String = ""
                    Dim Comment As String = ""

                    If Not IsDBNull(Row.Item("IDENT")) Then Ident = Row.Item("IDENT")
                    If Not IsDBNull(Row.Item("LAT")) Then Latitude = Row.Item("LAT")
                    If Not IsDBNull(Row.Item("LONG")) Then Longitude = Row.Item("LONG")
                    If Not IsDBNull(Row.Item("COMMENT")) Then Comment = Row.Item("COMMENT")

                    'dnrgps often *cks up the date.  sometimes it's in the LTIME column, other times in the DESC
                    Dim LTIME As DateTime
                    If Not IsDBNull(Row.Item("LTIME")) And IsDate(Row.Item("LTIME")) Then
                        LTIME = Row.Item("LTIME").ToString
                    End If

                    'determine if ltime is better than desc for a waypoint collection date
                    If IsDate(LTIME) = True And DatePart(DateInterval.Year, LTIME) > My.Settings.MinimumDNRGPSWaypointYear Then
                        SightingDate = LTIME.ToString
                        'ElseIf IsDate(DESC) = True Then
                        ' SightingDate = DESC
                    End If

                    'create a new row and add data to it
                    Dim NewRow As DataRow = WaypointsPreviewDataTable.NewRow
                    NewRow.Item("Herd") = Herd
                    NewRow.Item("GroupNumber") = GroupNumber
                    NewRow.Item("SightingDate") = SightingDate
                    NewRow.Item("Waypoint") = Ident
                    NewRow.Item("FlightID") = FlightID
                    NewRow.Item("RTID") = Guid.NewGuid.ToString
                    NewRow.Item("RecordInsertedDate") = Now
                    NewRow.Item("RecordInsertedBy") = My.User.Name
                    NewRow.Item("SourceFilename") = WaypointsImportFileInfo.Name
                    NewRow.Item("Comment") = Comment
                    NewRow.Item("Lat") = Latitude
                    NewRow.Item("Lon") = Longitude
                    NewRow.Item("ProjectID") = "WRST_Caribou"

                    'add the row to the preview datatable
                    WaypointsPreviewDataTable.Rows.Add(NewRow)

                    'increment the group number
                    GroupNumber = GroupNumber + 1
                End If

            Next

            'show the imported waypoints in a form so the user can validate them for importing
            Dim WaypointsPreviewForm As New WaypointsPreviewForm(WaypointsPreviewDataTable)
            WaypointsPreviewForm.ShowDialog()
            If WaypointsPreviewForm.ReadyToImport = True Then
                'finally, import the records
                For Each WPRow As DataRow In WaypointsPreviewDataTable.Rows
                    Me.WRST_CaribouDataSet.Tables("Radiotracking").ImportRow(WPRow)
                Next
                MsgBox("Waypoints imported successfully.")
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub

    ''' <summary>
    ''' Allows the user to select a waypoints file as exported from DNRGPS and load it into the caribou database's composition count table
    ''' </summary>
    Private Sub ImportCompositionCountDNRGPSWaypoints(WaypointsImportDataTable As DataTable, WaypointsPreviewDataTable As DataTable, FlightID As String, Herd As String, WaypointsImportFileInfo As FileInfo)
        Try
            Dim GroupNumber As Integer = GetMaximumGroupNumber(Me.WRST_CaribouDataSet.Tables("CompositionCounts"), "FlightID='" & FlightID & "'")

            'loop through the records in the import file, extract values
            For Each Row As DataRow In WaypointsImportDataTable.Rows
                'if we don't have a location then we have nothing for the row
                If Not IsDBNull(Row.Item("IDENT")) And Not IsDBNull(Row.Item("LAT")) And Not IsDBNull(Row.Item("LONG")) Then
                    Dim Ident As String = ""
                    Dim Latitude As Double = 0
                    Dim Longitude As Double = 0
                    Dim SightingDate As DateTime

                    If Not IsDBNull(Row.Item("IDENT")) Then Ident = Row.Item("IDENT")
                    If Not IsDBNull(Row.Item("LAT")) Then Latitude = Row.Item("LAT")
                    If Not IsDBNull(Row.Item("LONG")) Then Longitude = Row.Item("LONG")

                    'dnrgps always *cks up the date.  sometimes it's in the LTIME column, other times in the DESC
                    'Dim LTIME As DateTime
                    'If Not IsDBNull(Row.Item("LTIME")) And IsDate(Row.Item("LTIME")) Then
                    ' LTIME = Row.Item("LTIME")
                    'End If

                    'determine if ltime is better than desc for a waypoint collection date
                    If IsDate(Row.Item("LTIME")) = True And DatePart(DateInterval.Year, Row.Item("LTIME")) > My.Settings.MinimumDNRGPSWaypointYear Then
                        SightingDate = Row.Item("LTIME")
                    ElseIf IsDate(Row.Item("COMMENT")) = True And DatePart(DateInterval.Year, Row.Item("COMMENT")) > My.Settings.MinimumDNRGPSWaypointYear Then
                        SightingDate = Row.Item("COMMENT")
                    ElseIf IsDate(Row.Item("TIME")) = True And DatePart(DateInterval.Year, Row.Item("TIME")) > My.Settings.MinimumDNRGPSWaypointYear Then
                        SightingDate = Row.Item("TIME")
                    ElseIf IsDate(Row.Item("TIME").replace("-", " ")) = True And DatePart(DateInterval.Year, Row.Item("TIME").replace("-", " ")) > My.Settings.MinimumDNRGPSWaypointYear Then
                        SightingDate = Row.Item("TIME").replace("-", " ")
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
            If WaypointsPreviewForm.ReadyToImport = True Then
                'finally, import the records
                For Each WPRow As DataRow In WaypointsPreviewDataTable.Rows
                    Me.WRST_CaribouDataSet.Tables("CompositionCounts").ImportRow(WPRow)
                Next
                MsgBox("Waypoints imported successfully.")
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub

    ''' <summary>
    ''' Allows the user to select a waypoints file as exported from DNRGPS and load it into the caribou datbase's population estimate table
    ''' </summary>
    Private Sub ImportPopulationSurveyDNRGPSWaypoints(WaypointsImportDataTable As DataTable, WaypointsPreviewDataTable As DataTable, FlightID As String, Herd As String, WaypointsImportFileInfo As FileInfo)
        Try

            'GroupNumber should be an autonumber column.  it's possible that the user will import more waypoints after already having done so
            Dim GroupNumber As Integer = GetMaximumGroupNumber(Me.WRST_CaribouDataSet.Tables("PopulationEstimate"), "FlightID='" & FlightID & "'")

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
                    ' DESC = Row.Item("DESC")
                    'End If

                    'determine if ltime is better than desc for a waypoint collection date
                    If IsDate(LTIME) = True And DatePart(DateInterval.Year, LTIME) > My.Settings.MinimumDNRGPSWaypointYear Then
                        SightingDate = LTIME.ToString
                        'ElseIf IsDate(DESC) = True Then
                        ' SightingDate = DESC
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
            If WaypointsPreviewForm.ReadyToImport = True Then
                'finally, import the records!
                For Each WPRow As DataRow In WaypointsPreviewDataTable.Rows
                    Me.WRST_CaribouDataSet.Tables("PopulationEstimate").ImportRow(WPRow)
                Next
                MsgBox("Waypoints imported successfully.")
            End If

        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub
#End Region



    ''' <summary>
    ''' Returns the maximum GroupNumber from a DataTable based on Filter
    ''' </summary>
    ''' <param name="DataTableToQuery">A DataTable containing a column named GroupNumber. DataTable</param>
    ''' <param name="Filter">A filter to apply. String.</param>
    ''' <returns>Maximum GroupNumber. Integer.</returns>
    Private Function GetMaximumGroupNumber(DataTableToQuery As DataTable, Filter As String) As Integer
        'get the max existing GroupNumber for a flight so we can increment by one
        Dim MaxNumber As Integer = 1
        Try
            Dim MaxGroupNumberDataView As DataView = New DataView(DataTableToQuery, Filter, "", DataViewRowState.CurrentRows)
            If MaxGroupNumberDataView.ToTable.Rows.Count > 0 Then
                MaxNumber = MaxGroupNumberDataView.ToTable.Compute("Max(GroupNumber)", Filter) + 1
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
        Return MaxNumber
    End Function






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
                .Title = "Select a workbook to open"
            End With

            'show the ofd and get the filename and path
            If OFD.ShowDialog = DialogResult.OK Then
                ExcelFile = OFD.FileName
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
        Return ExcelFile
    End Function

    Private Sub ImportCompCountWaypointsToolStripButton_Click(sender As Object, e As EventArgs) Handles ImportCompCountWaypointsToolStripButton.Click
        OpenWaypointsFile("CompositionCounts")
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
FROM   Animals INNER JOIN
       CollarDeployments ON Animals.ProjectId = CollarDeployments.ProjectId AND Animals.AnimalId = CollarDeployments.AnimalId INNER JOIN
       Collars ON CollarDeployments.CollarManufacturer = Collars.CollarManufacturer AND CollarDeployments.CollarId = Collars.CollarId
WHERE  (Animals.ProjectId = 'WRST_Caribou') And (DeploymentDate < '" & ObservationDate & "' And (RetrievalDate is NULL or RetrievalDate > '" & ObservationDate & "'))
ORDER BY Collars.Frequency"

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
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub

    Private Sub PopulationEstimateGridEX_SelectionChanged(sender As Object, e As EventArgs) Handles PopulationEstimateGridEX.SelectionChanged
        'set default values for the new population record
        SetPopulationGridDefaultValues()

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
                    End If

                End If
            End With
            Me.XrefPopulationCaribouGridEX.RootTable.Columns("EID").DefaultValue = EID
            'if we have a valid observation date and an EID then load the collar selector dropdown with available collars
            'load the AnimalID with a selection of collars that were deployed on the date the caribou group was observed
            LoadCollaredCaribouDropdown(Me.XrefPopulationCaribouGridEX, SightingDate)
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub

    Private Sub SetPopulationGridDefaultValues()
        Try
            Dim GridEX As GridEX = Me.PopulationEstimateGridEX
            GridEX.RootTable.Columns("EID").DefaultValue = Guid.NewGuid.ToString
            GridEX.RootTable.Columns("RecordInsertedDate").DefaultValue = Now
            GridEX.RootTable.Columns("RecordInsertedBy").DefaultValue = My.User.Name
        Catch ex As Exception
            MsgBox(ex.Message & " " & System.Reflection.MethodBase.GetCurrentMethod.Name)
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
        OpenWaypointsFile("PopulationEstimate")
    End Sub

    Private Sub CompositionCountsGridEX_SelectionChanged(sender As Object, e As EventArgs) Handles CompositionCountsGridEX.SelectionChanged
        Try
            'default values
            With Me.CompositionCountsGridEX.RootTable
                .Columns("CCID").DefaultValue = Guid.NewGuid.ToString
                .Columns("RecordInsertedDate").DefaultValue = Now
                .Columns("RecordInsertedBy").DefaultValue = My.User.Name
                .Columns("Herd").DefaultValue = GetCurrentHerd()
            End With

            'when the user clicks on a composition survey caribou group, then load the xrefcariboucomposition gridex with available 
            'gps collars to allow the user to associate a collared caribou with the observed group
            'determine the CCID, primary key of the caribou group record, and set the default value to the new xrefcariboucomposition record
            Dim CCID As String = ""
            Dim SightingDate As Date

            'get the sighting date to use later, and get the CCID to relate to any new xrefcariboucomposition records
            With Me.CompositionCountsGridEX
                If Not .CurrentRow Is Nothing Then
                    'get the SightingDate
                    If Not .CurrentRow.Cells("SightingDate") Is Nothing And Not IsDBNull(.CurrentRow.Cells("SightingDate")) Then
                        If Not IsDBNull(.CurrentRow.Cells("SightingDate").Value) Then
                            SightingDate = .CurrentRow.Cells("SightingDate").Value
                        End If
                    End If

                    'set up the CCID primary key for syncing with the group
                    If Not .CurrentRow.Cells("CCID") Is Nothing And Not IsDBNull(.CurrentRow.Cells("CCID")) Then
                        If Not IsDBNull(.CurrentRow.Cells("CCID").Value) Then
                            CCID = .CurrentRow.Cells("CCID").Value
                        End If
                    End If
                End If
            End With

            'set up default values
            With Me.XrefCompCountCaribouGridEX.RootTable
                .Columns("CCID").DefaultValue = CCID
            End With

            'if we have a valid observation date and an EID then load the collar selector dropdown with available collars
            'load the AnimalID with a selection of collars that were deployed on the date the caribou group was observed
            LoadCollaredCaribouDropdown(Me.XrefCompCountCaribouGridEX, SightingDate)

        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub

    Private Sub XrefCompCountCaribouGridEX_SelectionChanged(sender As Object, e As EventArgs) Handles XrefCompCountCaribouGridEX.SelectionChanged
        Dim Grid As GridEX = Me.XrefCompCountCaribouGridEX
        Grid.RootTable.Columns("CCCID").DefaultValue = Guid.NewGuid.ToString 'primary key
        Grid.RootTable.Columns("RecordInsertedDate").DefaultValue = Now
        Grid.RootTable.Columns("RecordInsertedBy").DefaultValue = My.User.Name
        Grid.RootTable.Columns("ProjectID").DefaultValue = "WRST_Caribou" 'always 'WRST_Caribou', primary key, with AnimalID in the Animal_Movement database for the GPS collar
    End Sub

    Private Sub RadioTrackingGridEX_SelectionChanged(sender As Object, e As EventArgs) Handles RadioTrackingGridEX.SelectionChanged
        'when the user clicks on a radiotracking survey caribou group, then load the xrefcaribouradiotracking gridex with available 
        'gps collars to allow the user to associate a collared caribou with the observed group
        Try
            'GroupNumber default value
            Dim MaxGroupNumber As Integer = 0
            For Each Row As GridEXRow In Me.RadioTrackingGridEX.GetRows()
                If Row.Cells("GroupNumber").Value > MaxGroupNumber Then
                    MaxGroupNumber = Row.Cells("GroupNumber").Value
                End If
            Next
            Me.RadioTrackingGridEX.RootTable.Columns("GroupNumber").DefaultValue = MaxGroupNumber + 1

            'Set up default values
            Dim Grid As GridEX = Me.RadioTrackingGridEX
            Grid.RootTable.Columns("RTID").DefaultValue = Guid.NewGuid.ToString 'primary key
            Grid.RootTable.Columns("RecordInsertedDate").DefaultValue = Now
            Grid.RootTable.Columns("RecordInsertedBy").DefaultValue = My.User.Name

            'determine the RTID, primary key of the caribou group record, and set the default value to the new xrefcaribouRadiotracking record
            Dim RTID As String = ""
            Dim SightingDate As Date

            'get the sighting date to use later, and get the RTID to relate to any new xrefcaribouRadiotracking records
            With Me.RadioTrackingGridEX
                If Not .CurrentRow Is Nothing Then
                    'get the SightingDate
                    If Not .CurrentRow.Cells("SightingDate") Is Nothing And Not IsDBNull(.CurrentRow.Cells("SightingDate")) Then
                        If Not IsDBNull(.CurrentRow.Cells("SightingDate").Value) Then SightingDate = .CurrentRow.Cells("SightingDate").Value
                    End If

                    'set up the RTID primary key for syncing with the group
                    If Not .CurrentRow.Cells("RTID") Is Nothing And Not IsDBNull(.CurrentRow.Cells("RTID")) Then
                        If Not IsDBNull(.CurrentRow.Cells("RTID").Value) Then
                            RTID = .CurrentRow.Cells("RTID").Value
                        End If
                    End If

                End If
            End With
            Me.XrefRadiotrackingCaribouGridEX.RootTable.Columns("RTID").DefaultValue = RTID
            'if we have a valid observation date and an RTID then load the collar selector dropdown with available collars
            'load the AnimalID with a selection of collars that were deployed on the date the caribou group was observed
            LoadCollaredCaribouDropdown(Me.XrefRadiotrackingCaribouGridEX, SightingDate)



        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub

#Region "GridEX_Validated"
    Private Sub CampaignsGridEX_Validated(sender As Object, e As EventArgs) Handles CampaignsGridEX.Validated
        Me.CampaignsBindingSource.EndEdit()
    End Sub

    Private Sub SurveyFlightsGridEX_Validated(sender As Object, e As EventArgs) Handles SurveyFlightsGridEX.Validated
        Me.SurveyFlightsBindingSource.EndEdit()
    End Sub

    Private Sub CompositionCountsGridEX_Validated(sender As Object, e As EventArgs) Handles CompositionCountsGridEX.Validated
        Me.CompositionCountsBindingSource.EndEdit()
    End Sub

    Private Sub PopulationEstimateGridEX_Validated(sender As Object, e As EventArgs) Handles PopulationEstimateGridEX.Validated
        Me.PopulationEstimateBindingSource.EndEdit()
    End Sub

    Private Sub RadioTrackingGridEX_Validated(sender As Object, e As EventArgs) Handles RadioTrackingGridEX.Validated
        Me.RadioTrackingBindingSource.EndEdit()
    End Sub


#End Region
    Private Sub ImportRadiotrackingWaypointsToolStripButton_Click(sender As Object, e As EventArgs) Handles ImportRadiotrackingWaypointsToolStripButton.Click
        'open a DNRGPS waypoints file and load the waypoints into the radiotracking datatable
        OpenWaypointsFile("Radiotracking")
    End Sub

    Private Sub RefreshResultsToolStripButton_Click(sender As Object, e As EventArgs) Handles RefreshResultsToolStripButton.Click
        SaveDataset()
        LoadCampaignResults(GetCurrentCampaignID, Me.DatabaseViewNameToolStripLabel.Text)
    End Sub

#Region "Import waypoints from an arbitrary file"

    'import arbitrary waypoints to comp count
    Private Sub ImportCompCountXYFromFileToolStripButton_Click(sender As Object, e As EventArgs) Handles ImportCompCountXYFromFileToolStripButton.Click
        'get the structure of the destination datatable, we only need one record since the translator will clear all records anyway
        Dim Sql As String = "SELECT TOP (1) SightingDate, Herd, GroupNumber, SearchArea, SmallBull, MediumBull, LargeBull, Cow, Calf, Indeterminate, Waypoint, Frequencies, FlightID, CCID, RecordInsertedDate, RecordInsertedBy,        SourceFilename, Comment, Lat, Lon FROM   CompositionCounts"
        Dim DestinationDataTable As DataTable = GetDataTable(My.Settings.WRST_CaribouConnectionString, Sql)
        ImportSurveyDataFromFile(DestinationDataTable, SurveyType.CompositionCount)
    End Sub

    'import arbitrary waypoints to population
    Private Sub ImportPopulationSurveyWaypointsFromFileToolStripButton_Click(sender As Object, e As EventArgs) Handles ImportPopulationSurveyWaypointsFromFileToolStripButton.Click
        'get the structure of the destination datatable, we only need one record since the translator will clear all records anyway
        Dim Sql As String = "SELECT TOP 1 [Herd]        ,[SearchArea]        ,[GroupNumber]        ,[WaypointName]        ,[SightingDate], Bull        ,[SmallBull]        ,[MediumBull]        ,[LargeBull]        ,[Cow]        ,[Calf]        ,[InOrOut]        ,[Seen]        ,[Marked]        ,[FrequenciesInGroup]        ,[Lat]        ,[Lon]        ,[Comment]        ,[SourceFilename],[FlightID]        ,[EID]        ,[RecordInsertedDate]        ,[RecordInsertedBy]    FROM [WRST_Caribou].[dbo].[PopulationEstimate]"
        Dim DestinationDataTable As DataTable = GetDataTable(My.Settings.WRST_CaribouConnectionString, Sql)
        ImportSurveyDataFromFile(DestinationDataTable, SurveyType.PopulationEstimate)
    End Sub

    'import arbitrary waypoints to radiotracking
    Private Sub ImportRadiotrackingWaypointsFromFileToolStripButton_Click(sender As Object, e As EventArgs) Handles ImportRadiotrackingWaypointsFromFileToolStripButton.Click
        'get the structure of the destination datatable, we only need one record since the translator will clear all records anyway
        Dim Sql As String = "SELECT        TOP (1) Herd, GroupNumber, Frequency, VisualCollar, SightingDate, Mode, Accuracy, Bull, Cow, Calf, Adult, Unknown, Waypoint, RetainedAntler, DistendedUdders, CalvesAtHeel, Seen, FlightID, AnimalID, ProjectID, RTID, RecordInsertedDate, RecordInsertedBy, SearchArea, SourceFilename, Comment, Lat, Lon FROM            RadioTracking"
        Dim DestinationDataTable As DataTable = GetDataTable(My.Settings.WRST_CaribouConnectionString, Sql)
        ImportSurveyDataFromFile(DestinationDataTable, SurveyType.Radiotracking)
    End Sub

    ''' <summary>
    ''' Survey types
    ''' </summary>
    Public Enum SurveyType
        CompositionCount
        PopulationEstimate
        Radiotracking
    End Enum

    ''' <summary>
    ''' Loads a source file of waypoints and an intended destination DataTable, then opens a translator form to map the source columns into the destination datatable schema.
    ''' Finally, loads the transformed data into the DestinationDataTable.
    ''' </summary>
    ''' <param name="DestinationDataTable">DataTable. The DataTable schema into which the source DataTable's columns should be matched.</param>
    Private Sub ImportSurveyDataFromFile(DestinationDataTable As DataTable, SurveyType As SurveyType)
        Try
            'get the data fileinfo to import
            Dim SourceFileInfo As New FileInfo(GetFile("Select a data file to open. If Excel workbook the data to be imported must be in the first worksheet (tab).", "Survey data file (.csv;.xls;.xlsx)|*.csv;*.xls;*.xlsx|Comma separated values (.csv)|*.csv|Excel worksheet (.xlsx)|*.xlsx|Excel worksheet (.xls)|*.xls"))

            'convert the file into a datatable so we can work with it
            Dim InputDataTable As DataTable = Nothing

            'determine if the input file is csv or excel
            If SourceFileInfo.Extension = ".csv" Then
                'convert the data file into a datatable
                InputDataTable = GetDataTableFromDelimitedTextFile(SourceFileInfo, ",")
            ElseIf SourceFileInfo.Extension = ".xlsx" Then
                'convert the excel sheet into a datatable
                Dim ExcelConnectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & SourceFileInfo.FullName & ";Extended Properties=""Excel 12.0 Xml;HDR=YES"";"
                Dim ExcelDataset As DataSet = GetDatasetFromExcelWorkbook(ExcelConnectionString)
                InputDataTable = ExcelDataset.Tables(0) 'can only grab the first worksheet (tab)
            ElseIf SourceFileInfo.Extension = ".xls" Then
                'convert the excel sheet into a datatable
                Dim ExcelConnectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & SourceFileInfo.FullName & ";Extended Properties=""Excel 8.0;HDR=YES"";"
                Dim ExcelDataset As DataSet = GetDatasetFromExcelWorkbook(ExcelConnectionString)
                InputDataTable = ExcelDataset.Tables(0) 'first worksheet
            End If

            'make a list of desired default values to pass into the data tables translator form
            'these items will show up in the mappings datagridview's default values column to make things a little easier
            Dim DefaultValuesList As New List(Of String)
            With DefaultValuesList
                'add the search areas from my.settings to the default values
                For Each Item In My.Settings.SearchAreas.Split(",")
                    .Add(Item)
                Next

                'add radiotracking special default values
                If SurveyType = SurveyType.Radiotracking Then
                    .Add("WRST_Caribou")
                    .Add("Manual")
                    .Add("Automatic")
                End If

                'common default values
                .Add(GetCurrentFlightID) 'the primary key of the currently selected flight
                .Add(GetCurrentHerd) 'the currently selected herd in the campaigns table
                .Add(SourceFileInfo.Name) 'the import file name
                .Add(0) 'useful for filling in required but null animal counts.
            End With

            'open up a datatable translator form to allow the user to map fields from the csv file to the destination datatable
            Dim TranslatorForm As New SkeeterDataTablesTranslatorForm(InputDataTable, DestinationDataTable, "Import data", "Use the tool on the left to map the fields from your source data table to the destination data table.", DefaultValuesList)
            TranslatorForm.ShowDialog()

            'at this point we have transformed the csv into a clone of the destination datatable
            Dim ImportDataTable As DataTable = TranslatorForm.DestinationDataTable


            'the next step is to get the transformed data into the correct table
            'loop through the waypoints datatable and try to insert them into the datatable
            Dim TableName As String = SurveyType.ToString
            For Each Row As DataRow In ImportDataTable.Rows

                'make a new row
                Dim NewRow As DataRow = Me.WRST_CaribouDataSet.Tables(TableName).NewRow
                For Each Column As DataColumn In ImportDataTable.Columns
                    NewRow.Item(Column.ColumnName) = Row.Item(Column.ColumnName)
                Next

                'override any selections made on the translator form
                NewRow.Item("FlightID") = GetCurrentFlightID()
                NewRow.Item("RecordInsertedDate") = Now
                NewRow.Item("RecordInsertedBy") = My.User.Name
                NewRow.Item("Herd") = GetCurrentHerd()

                Select Case SurveyType
                    Case SurveyType.CompositionCount
                        NewRow.Item("CCID") = Guid.NewGuid.ToString
                    Case SurveyType.PopulationEstimate
                        NewRow.Item("EID") = Guid.NewGuid.ToString
                    Case SurveyType.Radiotracking
                        NewRow.Item("RTID") = Guid.NewGuid.ToString
                End Select

                'add the row
                Me.WRST_CaribouDataSet.Tables(TableName).Rows.Add(NewRow)

                'end the edit
                Select Case SurveyType
                    Case SurveyType.CompositionCount
                        Me.CompositionCountsBindingSource.EndEdit()
                    Case SurveyType.PopulationEstimate
                        Me.PopulationEstimateBindingSource.EndEdit()
                    Case SurveyType.Radiotracking
                        Me.RadioTrackingBindingSource.EndEdit()
                End Select

            Next

        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub

#End Region

    Private Sub RefreshDataToolStripButton_Click(sender As Object, e As EventArgs) Handles RefreshDataToolStripButton.Click
        SaveDataset()
        LoadDataset()
    End Sub

    Private Sub SelectSurveyTypeToolStripComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SelectSurveyTypeToolStripComboBox.SelectedIndexChanged
        LoadSurveyResultsGrid()
    End Sub


    ''' <summary>
    ''' Fetches the data from the submitted query and loads it into the SurveyResultsDataGridView
    ''' </summary>
    Private Sub LoadSurveyResultsGrid()
        Try
            Dim Sql As String = ""
            Select Case Me.SelectSurveyTypeToolStripComboBox.Text
                Case "Composition count"
                    Sql = "SELECT * FROM CC_Results_NoLocation"
                Case "Population"
                    Sql = "SELECT  * FROM PE_Results_NoLocation"
                Case "Radiotracking"
                    Sql = "SELECT  * FROM RT_Results_NoLocation"
                Case Else
                    Me.SurveyResultsBindingSource.DataSource = Nothing
            End Select

            If Sql.Trim.Length > 0 Then
                ResultsDataTable = GetDataTable(My.Settings.WRST_CaribouConnectionString, Sql)
            Else
                ResultsDataTable = Nothing
            End If

            Me.SurveyResultsBindingSource.DataSource = ResultsDataTable
            Me.SurveyResultsDataGridView.DataSource = Me.SurveyResultsBindingSource
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub

    Private Sub ExportResultsToCSVToolStripButton_Click(sender As Object, e As EventArgs) Handles ExportResultsToCSVToolStripButton.Click
        Dim SFD As New SaveFileDialog()
        With SFD
            .AddExtension = True
            .DefaultExt = ".csv"
            .FileName = "WRST_Caribou_Export.csv"
            .Filter = "Comma separated values text file|*.csv"
            .OverwritePrompt = True
            .Title = "Save data"
        End With
        If SFD.ShowDialog = DialogResult.OK Then
            Dim CSVFile As String = SFD.FileName
            My.Computer.FileSystem.WriteAllText(CSVFile, DataTableToCSV(ResultsDataTable, ","), False)
            Process.Start(CSVFile)
        End If

    End Sub

    Private Sub RefreshToolStripButton_Click(sender As Object, e As EventArgs) Handles RefreshToolStripButton.Click
        LoadSurveyResultsGrid()
    End Sub

    Private Sub XrefPopulationCaribouGridEX_DropDown(sender As Object, e As ColumnActionEventArgs) Handles XrefPopulationCaribouGridEX.DropDown
        LoadXrefPopulationCaribouGridEX_DropDown()
    End Sub

    Private Sub LoadXrefPopulationCaribouGridEX_DropDown()
        Try
            'query the animal movement database for a list of collared animals
            'Dim AnimalsQuery As String = "SELECT Convert(Varchar(20),Collars.Frequency) + ' - ' + Animals.AnimalId AS CollaredCaribou, Collars.Frequency, Animals.AnimalId, Animals.MortalityDate, CollarDeployments.DeploymentDate, CollarDeployments.RetrievalDate, Collars.HasGps, CollarDeployments.CollarId, Animals.ProjectId  FROM            Animals INNER JOIN                           CollarDeployments ON Animals.ProjectId = CollarDeployments.ProjectId AND Animals.AnimalId = CollarDeployments.AnimalId INNER JOIN                           Collars ON CollarDeployments.CollarManufacturer = Collars.CollarManufacturer AND CollarDeployments.CollarId = Collars.CollarId  WHERE        (Animals.ProjectId = 'WRST_Caribou')  ORDER BY Collars.Frequency, Animals.AnimalId"
            Dim AnimalsDataTable As DataTable = GetAM_AnimalsDataTable()

            'get a ref to the animalid valuelist
            Dim List As GridEXValueListItemCollection = Me.XrefPopulationCaribouGridEX.RootTable.Columns("AnimalID").ValueList
            'load in the items into the dropdown
            For Each Row As DataRow In AnimalsDataTable.Rows
                Dim AnimalID As String = Row.Item("AnimalID")
                Dim CollaredCaribou As String = Row.Item("CollaredCaribou")
                List.Add(AnimalID, CollaredCaribou)
            Next
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub

    Private Sub RefreshAMAnimalsInventoryToolStripButton_Click(sender As Object, e As EventArgs) Handles RefreshAMAnimalsInventoryToolStripButton.Click
        LoadAnimalMovementsAnimalsGrid()
    End Sub

    Private Sub LoadAnimalMovementsAnimalsGrid()
        Try
            'load the animals from animal_movement into the grid
            'Me.AnimalsBindingSource.DataSource = GetAM_AnimalsDataTable()
            Dim AnimalsDataTable As DataTable = GetAM_AnimalsDataTable()
            For Each row As DataRow In AnimalsDataTable.Rows
                Debug.Print(row.Item("AnimalID"))
            Next
            Me.AnimalsDataGridView.DataSource = AnimalsDataTable
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub

End Class

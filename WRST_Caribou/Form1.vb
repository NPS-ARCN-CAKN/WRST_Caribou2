'todo animal_movement connectivity

Imports System.Data.SqlClient
Imports System.IO
Imports Janus.Windows.GridEX
Imports SkeeterDataTablesTranslator

Public Class Form1

    Dim ResultsDataTable As DataTable 'This reusable datatable will contain the data to be displayed in the Me.SurveyResultsDataGridView of the Results tab

    'load the animals inventory grid from animal_movement database
    Dim AnimalMovementDataset As DataSet = GetAnimal_MovementDataset()

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'set up the form
        Me.DatabaseViewNameToolStripLabel.Text = ""


        'load the data from the WRST_Caribou Sql Server database
        LoadDataset()

        'make all gridexes read-only to start with. this is changed by the user clicking Me.EditCampaignsCheckBox
        ToggleGridEXReadOnly(Me.CampaignsGridEX, InheritableBoolean.False)
        ToggleGridEXReadOnly(Me.SurveyFlightsGridEX, InheritableBoolean.False)
        ToggleGridEXReadOnly(Me.RadioTrackingGridEX, InheritableBoolean.False)
        ToggleGridEXReadOnly(Me.PopulationEstimateGridEX, InheritableBoolean.False)
        ToggleGridEXReadOnly(Me.CompositionCountsGridEX, InheritableBoolean.False)

        'set up campaigns gridex
        FormatGridEX(Me.CampaignsGridEX) 'consistent look and feel
        SetCampaignsGridEXDefaultValues() 'set up default values
        SetCampaignsGridEXDropDowns() 'set up dropdowns


        'set up flights gridex
        FormatGridEX(Me.SurveyFlightsGridEX) 'consistent look and feel
        SetFlightsGridExDefaultValues() 'set up default values
        SetFlightsGridEXDropDowns 'set up dropdowns
        LoadFlightHeader() 'load the flight header with context information

        'set up population survey data gridex
        FormatGridEX(Me.PopulationEstimateGridEX) 'consistent look and feel
        SetPopulationGridEXDefaultValues()
        SetUpPopulationEstimateGridEXDropDowns()

        'set up comp count survey data gridex
        FormatGridEX(Me.CompositionCountsGridEX) 'consistent look and feel
        SetCompCountGridEXDefaultValues()
        SetUpCompCountGridEXDropDowns()

        'set up radiotracking survey data gridex
        FormatGridEX(Me.RadioTrackingGridEX) 'consistent look and feel
        SetRadioTrackingGridEXDefaultValues()
        SetUpRadiotrackingGridEXDropDowns()

        'set up the caribou groups/caribou cross reference gridexes
        FormatGridEX(Me.XrefCompCountCaribouGridEX) 'consistent look and feel
        FormatGridEX(Me.XrefPopulationCaribouGridEX) 'consistent look and feel
        FormatGridEX(Me.XrefRadiotrackingCaribouGridEX) 'consistent look and feel


        'Set up the various gridexes with default values and dropdowns

        'Load the Campaign header 
        LoadCampaignHeader()

        'on startup set the flights and data gridexes are invisible so user needs to explicitly select a campaign
        'if the campaign header is "" then set the tabcontrol invisible until a campaign is selected
        Me.CampaignTabControl.Visible = Not Me.CampaignHeaderLabel.Text = ""

        'maximize form
        Me.WindowState = FormWindowState.Maximized

        'load the Animal_Movement database grids
        LoadAnimalMovementGrids()


        'load a list of available database views into the results tab combobox so users can choose an analytical view
        LoadDatabaseViewsComboBox()


    End Sub


    ''' <summary>
    ''' Queries the database for a list of Views. Loads the View names into Me.DatabaseViewsToolStripComboBox
    ''' </summary>
    Private Sub LoadDatabaseViewsComboBox()
        Try
            Dim DatabaseViewsDataTable As DataTable = GetDataTable(My.Settings.WRST_CaribouConnectionString, "SELECT Name FROM sys.views ORDER BY Name")
            With Me.DatabaseViewsToolStripComboBox
                .Items.Clear()
                .Items.Add("")
                For Each Row As DataRow In DatabaseViewsDataTable.Rows
                    .Items.Add(Row.Item("Name"))
                Next
            End With
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub












#Region "Set up headers"
    ''' <summary>
    ''' Loads information into the Survey campaign's header label so the user can see which survey is currently selected
    ''' </summary>
    Private Sub LoadCampaignHeader()
        Try
            'get the name of the survey campaign to put it into the survey flights header
            Me.CampaignHeaderLabel.Text = "Flights"
            Dim CurrentCampaign As String = "Flights"
            If Not Me.CampaignsGridEX.CurrentRow Is Nothing Then
                'update the campaign header with info about the current campaign
                Me.CampaignHeaderLabel.Text = GetCurrentCampaignHeader()
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub

    ''' <summary>
    ''' Loads information into the Flight's header label so the user can see which flight is currently selected
    ''' </summary>
    Private Sub LoadFlightHeader()
        If Not Me.SurveyFlightsGridEX.CurrentRow Is Nothing Then
            If Not Me.SurveyFlightsGridEX.CurrentRow.Cells("FlightID") Is Nothing Then

                'set up flightid default values for child tables
                Dim FlightID As String = GetCurrentGridEXCellValue(Me.SurveyFlightsGridEX, "FlightID")

                'set up the flight header to show the user which flight is being edited
                'get some information about the survey flight to put in the header label so users know which survey flight they are editing
                Me.FlightContextLabel.Text = "Caribou groups seen: "
                Dim CurrentFlight As String = "Caribou groups seen: "
                Dim CrewNumber As Integer = 0
                Dim TailNo As String = ""
                Dim Pilot As String = ""
                Dim Observer1 As String = ""
                Dim TimeDepart As Date = "1/1/1111"



                'modify the flight context label
                If Not Me.SurveyFlightsGridEX.CurrentRow.Cells("CrewNumber") Is Nothing And Not Me.SurveyFlightsGridEX.CurrentRow.Cells("TailNo") Is Nothing And Not Me.SurveyFlightsGridEX.CurrentRow.Cells("Pilot") Is Nothing And Not Me.SurveyFlightsGridEX.CurrentRow.Cells("Observer1") Is Nothing And Not Me.SurveyFlightsGridEX.CurrentRow.Cells("TimeDepart") Is Nothing Then
                    If Not IsDBNull(Me.SurveyFlightsGridEX.CurrentRow.Cells("CrewNumber").Value) Then CrewNumber = Me.SurveyFlightsGridEX.CurrentRow.Cells("CrewNumber").Value
                    If Not IsDBNull(Me.SurveyFlightsGridEX.CurrentRow.Cells("Pilot").Value) Then Pilot = Me.SurveyFlightsGridEX.CurrentRow.Cells("Pilot").Value Else Pilot = ""
                    If Not IsDBNull(Me.SurveyFlightsGridEX.CurrentRow.Cells("TailNo").Value) Then TailNo = Me.SurveyFlightsGridEX.CurrentRow.Cells("TailNo").Value Else TailNo = ""
                    If Not IsDBNull(Me.SurveyFlightsGridEX.CurrentRow.Cells("Observer1").Value) Then Observer1 = Me.SurveyFlightsGridEX.CurrentRow.Cells("Observer1").Value Else Observer1 = ""
                    If Not IsDBNull(Me.SurveyFlightsGridEX.CurrentRow.Cells("TimeDepart").Value) Then TimeDepart = Me.SurveyFlightsGridEX.CurrentRow.Cells("TimeDepart").Value
                    CurrentFlight = "Caribou groups seen during flight: " & Pilot & "\" & Observer1 & " (Crew " & CrewNumber & ") " & TailNo & " " & TimeDepart.ToString("yyyy-MM-dd")
                    Me.FlightContextLabel.Text = CurrentFlight

                    'modify the flight header label
                    'Me.FlightHeaderLabel.Text = "Flight: " & TailNo & " " & Pilot & " " & Observer1 & " " & 
                End If
            End If
        End If
    End Sub

    ''' <summary>
    ''' Loads information into the Caption of the XrefPopulationEstimateCaribou GridEX for context on which caribou group is current
    ''' </summary>
    Private Sub LoadXrefPopulationEstimateCaribouHeader()
        Try
            Dim Grid As GridEX = Me.PopulationEstimateGridEX

            'when the user clicks on a composition survey caribou group, then load the xrefcariboucomposition gridex with available 
            'gps collars to allow the user to associate a collared caribou with the observed group
            'determine the EID, primary key of the caribou group record, and set the default value to the new xrefcariboucomposition record
            Dim EID As String = ""
            Dim SightingDate As Date
            Dim GroupNumber As Integer = 0
            Dim Waypoint As String = ""

            'get the sighting date to use later, and get the EID to relate to any new xrefcariboucomposition records
            With Grid
                If Not .CurrentRow Is Nothing Then
                    'get the SightingDate
                    If Not .CurrentRow.Cells("SightingDate") Is Nothing And Not IsDBNull(.CurrentRow.Cells("SightingDate")) Then
                        If Not IsDBNull(.CurrentRow.Cells("SightingDate").Value) Then
                            SightingDate = .CurrentRow.Cells("SightingDate").Value
                        End If
                    End If

                    'set up the EID primary key for syncing with the group
                    If Not .CurrentRow.Cells("EID") Is Nothing And Not IsDBNull(.CurrentRow.Cells("EID")) Then
                        If Not IsDBNull(.CurrentRow.Cells("EID").Value) Then
                            EID = .CurrentRow.Cells("EID").Value
                        End If
                    End If

                    'get the GroupNumber
                    If Not .CurrentRow.Cells("GroupNumber") Is Nothing And Not IsDBNull(.CurrentRow.Cells("GroupNumber")) Then
                        If Not IsDBNull(.CurrentRow.Cells("GroupNumber").Value) Then
                            GroupNumber = .CurrentRow.Cells("GroupNumber").Value
                        End If
                    End If

                    'get the Waypoint
                    If Not .CurrentRow.Cells("WaypointName") Is Nothing And Not IsDBNull(.CurrentRow.Cells("WaypointName")) Then
                        If Not IsDBNull(.CurrentRow.Cells("WaypointName").Value) Then
                            Waypoint = .CurrentRow.Cells("WaypointName").Value
                        End If
                    End If
                End If
            End With

            'modify the header
            Me.XrefPopulationCaribouGridEX.RootTable.Caption = "GPS collared caribou in group number " & GroupNumber & " (Waypoint " & Waypoint & ")"

        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub
#End Region




















#Region "Set up GridEX default values"

    ''' <summary>
    ''' Sets up the Campaigns grid's default values.
    ''' </summary>
    Private Sub SetCampaignsGridEXDefaultValues()
        'Set up default values
        Dim Grid As GridEX = Me.CampaignsGridEX
        Grid.RootTable.Columns("RecordInsertedDate").DefaultValue = Now
        Grid.RootTable.Columns("RecordInsertedBy").DefaultValue = My.User.Name
        Grid.RootTable.Columns("CampaignID").DefaultValue = Guid.NewGuid.ToString

        'set up the flight gridex's 'herd' column default value based on the Herd column of the survey campaigns grid current row
        If Not Grid.CurrentRow Is Nothing Then
            If Not Grid.CurrentRow.Cells("Herd") Is Nothing And Not IsDBNull(Grid.CurrentRow.Cells("Herd").Value) Then
                Dim CampaignHerd As String = Grid.CurrentRow.Cells("Herd").Value
                Dim CampaignID As String = Grid.CurrentRow.Cells("CampaignID").Value
                Me.SurveyFlightsGridEX.RootTable.Columns("Herd").DefaultValue = CampaignHerd
                Me.SurveyFlightsGridEX.RootTable.Columns("CampaignID").DefaultValue = CampaignID

                'while we're here set up the Herd column in the other gridexes to match 
                Me.SurveyFlightsGridEX.RootTable.Columns("Herd").DefaultValue = CampaignHerd
                Me.RadioTrackingGridEX.RootTable.Columns("Herd").DefaultValue = CampaignHerd
                Me.PopulationEstimateGridEX.RootTable.Columns("Herd").DefaultValue = CampaignHerd
                Me.CompositionCountsGridEX.RootTable.Columns("Herd").DefaultValue = CampaignHerd
            End If
        End If

    End Sub

    Private Sub SetFlightsGridExDefaultValues()

        'Set up default values
        Dim Grid As GridEX = Me.SurveyFlightsGridEX
        Grid.RootTable.Columns("FlightID").DefaultValue = Guid.NewGuid.ToString
        Grid.RootTable.Columns("Herd").DefaultValue = GetCurrentGridEXCellValue(Me.CampaignsGridEX, "Herd")
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

        'set up default values for child tables and also set up a header for user context
        If Not Me.SurveyFlightsGridEX.CurrentRow Is Nothing Then
            If Not Me.SurveyFlightsGridEX.CurrentRow.Cells("FlightID") Is Nothing Then

                'set up flightid default values for child tables
                Dim FlightID As String = GetCurrentGridEXCellValue(Me.SurveyFlightsGridEX, "FlightID")
                Me.RadioTrackingGridEX.RootTable.Columns("FlightID").DefaultValue = FlightID
                Me.CompositionCountsGridEX.RootTable.Columns("FlightID").DefaultValue = FlightID
                Me.PopulationEstimateGridEX.RootTable.Columns("FlightID").DefaultValue = FlightID
            End If
        End If
    End Sub


    Private Sub SetPopulationGridEXDefaultValues()
        Try
            Dim GridEX As GridEX = Me.PopulationEstimateGridEX
            GridEX.RootTable.Columns("EID").DefaultValue = Guid.NewGuid.ToString
            GridEX.RootTable.Columns("RecordInsertedDate").DefaultValue = Now
            GridEX.RootTable.Columns("RecordInsertedBy").DefaultValue = My.User.Name
            GridEX.RootTable.Columns("Herd").DefaultValue = GetCurrentGridEXCellValue(Me.CampaignsGridEX, "Herd")
        Catch ex As Exception
            MsgBox(ex.Message & " " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub

    Private Sub SetCompCountGridEXDefaultValues()
        Try
            Dim GridEX As GridEX = Me.CompositionCountsGridEX
            GridEX.RootTable.Columns("CCID").DefaultValue = Guid.NewGuid.ToString
            GridEX.RootTable.Columns("RecordInsertedDate").DefaultValue = Now
            GridEX.RootTable.Columns("RecordInsertedBy").DefaultValue = My.User.Name
            GridEX.RootTable.Columns("Herd").DefaultValue = GetCurrentGridEXCellValue(Me.CampaignsGridEX, "Herd")
        Catch ex As Exception
            MsgBox(ex.Message & " " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub

    Private Sub SetRadioTrackingGridEXDefaultValues()
        Try
            Dim GridEX As GridEX = Me.RadioTrackingGridEX
            GridEX.RootTable.Columns("RTID").DefaultValue = Guid.NewGuid.ToString
            GridEX.RootTable.Columns("RecordInsertedDate").DefaultValue = Now
            GridEX.RootTable.Columns("RecordInsertedBy").DefaultValue = My.User.Name
            GridEX.RootTable.Columns("Herd").DefaultValue = GetCurrentGridEXCellValue(Me.CampaignsGridEX, "Herd")
        Catch ex As Exception
            MsgBox(ex.Message & " " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub

    Private Sub SetXrefPopulationEstimateCaribouGridEXDefaultValues()

    End Sub

    Private Sub SetXrefCompCountCaribouGridEXDefaultValues()

    End Sub

    Private Sub SetXrefRadioTrackingCaribouGridEXDefaultValues()

    End Sub

#End Region










#Region "Set up GridEX dropdowns"


#End Region


















    ''' <summary>
    ''' Brings the correct SurveyType tab forward in the census type tab control based on the SurveyType selected in the Campaigns GridEX, i.e. if the user selected a population survey then this sub will bring the population survey data tab to the front and disable the comp count and radiotracking tabs
    ''' </summary>
    Private Sub BringSurveyTypeTabControlForward()
        Try
            'set the survey type tab control to the current survey type
            Dim CurrentSurveyType As String = GetCurrentGridEXCellValue(Me.CampaignsGridEX, "SurveyType")

            'if we have a survey type then bring the correct tab forward
            If Not IsDBNull(CurrentSurveyType) Then

                'clear the results datagridview
                Me.ResultsDataGridView.DataSource = Nothing

                'bring forward the correct data entry tab based on the survey type
                Select Case CurrentSurveyType
                    Case "Composition"
                        Me.SurveyDataTabControl.SelectedTab = Me.CompositionCountTabPage
                        DisableUnneededTabs("Composition")

                        'summarize the campaign's results by querying the sql server and showing results in the resultsdatagridview
                        LoadCampaignResults(GetCurrentGridEXCellValue(Me.CampaignsGridEX, "CampaignID"), "CC_ResultsByCampaign")
                    Case "Population"
                        Me.SurveyDataTabControl.SelectedTab = Me.PopulationTabPage
                        DisableUnneededTabs("Population")

                        'summarize the campaign's results by querying the sql server and showing results in the resultsdatagridview
                        LoadCampaignResults(GetCurrentGridEXCellValue(Me.CampaignsGridEX, "CampaignID"), "PE_ResultsByCampaign")
                    Case "Radiotracking"
                        Me.SurveyDataTabControl.SelectedTab = Me.RadiotrackingTabPage
                        DisableUnneededTabs("Radiotracking")

                        'summarize the campaign's results by querying the sql server and showing results in the resultsdatagridview
                        LoadCampaignResults(GetCurrentGridEXCellValue(Me.CampaignsGridEX, "CampaignID"), "RT_ResultsByCampaign")
                    Case Else
                        Me.SurveyDataTabControl.SelectedTab = Me.CompositionCountTabPage
                End Select
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub


    Private Sub LoadCampaignDatabaseView()
        Try
            'set the survey type tab control to the current survey type
            Dim Grid As GridEX = Me.CampaignsGridEX
            Dim CurrentSurveyType As String = GetCurrentGridEXCellValue(Grid, "CampaignID")

            If Not Grid.CurrentRow Is Nothing Then
                If Not Grid.CurrentRow.Cells("SurveyType") Is Nothing Then
                    If Not IsDBNull(Grid.CurrentRow.Cells("SurveyType").Value) Then
                        CurrentSurveyType = Grid.CurrentRow.Cells("SurveyType").Value

                        'clear the results datagridview
                        Me.ResultsDataGridView.DataSource = Nothing

                        'bring forward the correct data entry tab based on the survey type
                        Select Case CurrentSurveyType
                            Case "Composition"
                                Me.SurveyDataTabControl.SelectedTab = Me.CompositionCountTabPage
                                DisableUnneededTabs("Composition")

                                'summarize the campaign's results by querying the sql server and showing results in the resultsdatagridview
                                LoadCampaignResults(GetCurrentGridEXCellValue(Me.CampaignsGridEX, "CampaignID"), "CC_ResultsByCampaign")
                            Case "Population"
                                Me.SurveyDataTabControl.SelectedTab = Me.PopulationTabPage
                                DisableUnneededTabs("Population")

                                'summarize the campaign's results by querying the sql server and showing results in the resultsdatagridview
                                LoadCampaignResults(GetCurrentGridEXCellValue(Me.CampaignsGridEX, "CampaignID"), "PE_ResultsByCampaign")
                            Case "Radiotracking"
                                Me.SurveyDataTabControl.SelectedTab = Me.RadiotrackingTabPage
                                DisableUnneededTabs("Radiotracking")

                                'summarize the campaign's results by querying the sql server and showing results in the resultsdatagridview
                                LoadCampaignResults(GetCurrentGridEXCellValue(Me.CampaignsGridEX, "CampaignID"), "RT_ResultsByCampaign")
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


#Region "GridEX_SelectionChanged"
    Private Sub CampaignsGridEX_SelectionChanged(sender As Object, e As EventArgs) Handles CampaignsGridEX.SelectionChanged
        'user gets here when they select a campaign from the campaigns gridex

        'load the campaign header
        LoadCampaignHeader()

        'load the grid's default values
        SetCampaignsGridEXDefaultValues()

        'when the current survey campaign current record changes then re-set up the flights grid default values.
        SetFlightsGridExDefaultValues()

        'bring the selected surveytype tab forward, if population survey bring the population survey tab forward, etc.
        BringSurveyTypeTabControlForward()
    End Sub

    Private Sub SurveyFlightsGridEX_SelectionChanged(sender As Object, e As EventArgs) Handles SurveyFlightsGridEX.SelectionChanged
        Try
            'load the current flight info into the flight header label so the user can see which flight is currently selected
            LoadFlightHeader()
            SetFlightsGridEXDropDowns()
            SetFlightsGridExDefaultValues()
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

#Region "Set up GridEX DropDowns"

    ''' <summary>
    ''' Set up the CampaignsGridEX dropdowns
    ''' </summary>
    Private Sub SetCampaignsGridEXDropDowns()
        Try
            'Herd dropdown values
            With Me.CampaignsGridEX.RootTable.Columns("Herd")
                .HasValueList = True
                .LimitToList = True
                .ValueList.Clear()
            End With
            Dim HerdList As GridEXValueListItemCollection = Me.CampaignsGridEX.RootTable.Columns("Herd").ValueList
            HerdList.Add("Chisana", "Chisana")
            HerdList.Add("Mentasta", "Mentasta")

            'Survey type dropdown values
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

    Private Sub SetFlightsGridEXDropDowns()
        Dim Grid As GridEX = Me.SurveyFlightsGridEX
        'Set up dropdowns
        LoadGridEXDropDownWithDistinctDataTableValues(Grid, Me.WRST_CaribouDataSet.Tables("SurveyFlights"), "Pilot", "Pilot", False)
        LoadGridEXDropDownWithDistinctDataTableValues(Grid, Me.WRST_CaribouDataSet.Tables("SurveyFlights"), "TailNo", "TailNo", False)
        LoadGridEXDropDownWithDistinctDataTableValues(Grid, Me.WRST_CaribouDataSet.Tables("SurveyFlights"), "AircraftType", "AircraftType", False)
        LoadGridEXDropDownWithDistinctDataTableValues(Grid, Me.WRST_CaribouDataSet.Tables("SurveyFlights"), "Observer1", "Observer1", False)
        LoadGridEXDropDownWithDistinctDataTableValues(Grid, Me.WRST_CaribouDataSet.Tables("SurveyFlights"), "Observer2", "Observer2", False)
        LoadGridEXDropDownWithDistinctDataTableValues(Grid, Me.WRST_CaribouDataSet.Tables("SurveyFlights"), "SOPNumber", "SOPNumber", False)
        LoadGridEXDropDownWithDistinctDataTableValues(Grid, Me.WRST_CaribouDataSet.Tables("SurveyFlights"), "SOPVersion", "SOPVersion", False)

        'Herd dropdown
        With Grid.RootTable.Columns("Herd")
            .HasValueList = True
            .LimitToList = True
            .ValueList.Clear()
        End With
        Dim SurveysHerdList As GridEXValueListItemCollection = Grid.RootTable.Columns("Herd").ValueList
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
    ''' Sets up the RadiotrackingGridEX with default values and other settings
    ''' </summary>
    Private Sub SetUpRadiotrackingGridEXDropDowns()
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
    Private Sub SetUpPopulationEstimateGridEXDropDowns()

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

    Private Sub SetUpCompCountGridEXDropDowns()
        'Set up default values
        Dim Grid As GridEX = Me.CompositionCountsGridEX
        Grid.RootTable.Columns("CCID").DefaultValue = Guid.NewGuid.ToString
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
    ''' Loads distinct items from a DataTable's DataColumn into a GridEX GridEXColumn's DropDown ValueList
    ''' </summary>
    ''' <param name="GridEX">The GridEX containing the GridEXColumn requiring a DropDown ValueList</param>
    ''' <param name="SourceDataTable">Name of the DataTable containing the DataColumn from which distinct values will be drawn</param>
    ''' <param name="SourceColumnName">Name of the source DataTable's DataColumn from which distinct values will be drawn</param>
    ''' <param name="GridEXColumnName">Name of the GridEX column into which to load dropdown values</param>
    Private Sub LoadGridEXDropDownWithDistinctDataTableValues(GridEX As GridEX, SourceDataTable As DataTable, SourceColumnName As String, GridEXColumnName As String, LimitToList As Boolean)
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
#End Region















    ''' <summary>
    ''' Loads data from the Animal Movement Dataset into the main interface's GridEXes
    ''' </summary>
    Private Sub LoadAnimalMovementGrids()
        'bind the animals grid to the AnimalMovementDataset using a bindingsource
        Try
            Dim AnimalsBindingSource As New BindingSource(AnimalMovementDataset, "Animals")
            AnimalsDataGridView.DataSource = AnimalsBindingSource

            'bind the collardeployments grid to the AnimalMovementDataset using a bindingsource
            Dim CollarDeploymentsBindingSource As New BindingSource(AnimalsBindingSource, "Animals_CollarDeploymentsDataRelation") 'NOTE: Bound to the DataRelation of the AnimalsBindingSource, not the CollarDeploymentsDataTable
            CollarDeploymentsDataGridView.DataSource = CollarDeploymentsBindingSource
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub

    ''' <summary>
    ''' Save any pending changes in the in-memory Dataset, with confirmation, back to the database.
    ''' </summary>
    Private Sub SaveDataset()
        Try
            If Me.WRST_CaribouDataSet.HasChanges = True Then
                'If MsgBox("Save all changes to the database?", MsgBoxStyle.YesNo, "Save") = MsgBoxResult.Yes Then
                Me.Validate()
                Me.CampaignsBindingSource.EndEdit()
                Me.SurveyFlightsBindingSource.EndEdit()
                Me.CompositionCountsBindingSource.EndEdit()
                Me.PopulationEstimateBindingSource.EndEdit()
                Me.RadioTrackingBindingSource.EndEdit()
                Me.XrefPopulationCaribouBindingSource.EndEdit()
                Me.XrefCompCountCaribouBindingSource.EndEdit()
                Me.XrefRadiotrackingCaribouBindingSource.EndEdit()
                Me.TableAdapterManager.UpdateAll(Me.WRST_CaribouDataSet)
                Me.WRST_CaribouDataSet.AcceptChanges()
                'End If
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
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub


    ''' <summary>
    ''' Standardizes the look, feel and function of a GridEX
    ''' </summary>
    ''' <param name="GridEX">The GridEX to set up</param>
    Private Sub FormatGridEX(GridEX As GridEX)
        Try
            Dim MyFont As New Font("Sans Serif", 10, FontStyle.Regular)
            With GridEX
                'by default make grids readonly; toggle editability using ToggleGridEXReadOnly function
                .AllowAddNew = InheritableBoolean.False
                .AllowDelete = InheritableBoolean.False
                .AllowEdit = InheritableBoolean.False
                .AlternatingColors = True
                .AutoEdit = False
                .AutomaticSort = True
                .CardBorders = False
                .CardHeaders = True
                .ColumnAutoSizeMode = ColumnAutoSizeMode.AllCells
                .ColumnHeaders = InheritableBoolean.True
                .Font = MyFont
                .FilterMode = FilterMode.None
                .NewRowPosition = NewRowPosition.BottomRow
                .RecordNavigator = True
                .RowHeaders = InheritableBoolean.True
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

    Private Sub ToggleGridEXReadOnly(GridEX As GridEX, AllowEdits As InheritableBoolean)
        Try
            With GridEX.RootTable
                .AllowAddNew = AllowEdits
                .AllowEdit = AllowEdits
                .AllowDelete = AllowEdits
            End With
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
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
    ''' Returns the current value of the cell specified by GridEXColumnKey of the current row of GridEX.
    ''' </summary>
    ''' <param name="GridEX">GridEX to search. GridEX</param>
    ''' <param name="GridEXColumnKey">The key (name) of the GridEX column from which you would like the current value. String.</param>
    ''' <returns></returns>
    Private Function GetCurrentGridEXCellValue(GridEX As GridEX, GridEXColumnKey As String) As String
        Dim CellValue As String = ""
        Try
            'get the current row of the VS GridEX
            If Not GridEX.CurrentRow Is Nothing Then
                Dim CurrentRow As GridEXRow = GridEX.CurrentRow
                If Not CurrentRow.Cells(GridEXColumnKey) Is Nothing Then
                    If Not IsDBNull(CurrentRow.Cells(GridEXColumnKey)) Then
                        CellValue = CurrentRow.Cells(GridEXColumnKey).Value
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
        Return CellValue
    End Function

    '''' <summary>
    '''' Returns the CampaignID of the currently selected Campaign
    '''' </summary>
    '''' <returns>String</returns>
    ''Private Function GetCurrentCampaignID() As String
    '    Dim CampaignID As String = ""
    '    Try
    '        'get the current row of the VS GridEX
    '        If Not Me.CampaignsGridEX.CurrentRow Is Nothing Then
    '            Dim CurrentRow As GridEXRow = Me.CampaignsGridEX.CurrentRow
    '            'loop through the columns and look for the CampaignID columns
    '            For i As Integer = 0 To CurrentRow.Cells.Count - 1
    '                If CurrentRow.Cells(i).Column.Key = "CampaignID" Then
    '                    'if there is a value
    '                    If Not IsDBNull(CurrentRow.Cells(i).Value) Then
    '                        CampaignID = CurrentRow.Cells(i).Value
    '                    End If
    '                End If
    '            Next
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message & " " & System.Reflection.MethodBase.GetCurrentMethod.Name)
    '    End Try
    '    Return CampaignID
    'End Function

    '''' <summary>
    '''' Returns the FlightID of the currently selected Flight
    '''' </summary>
    '''' <returns>String</returns>
    'Private Function GetCurrentFlightID() As String
    '    Dim Grid As GridEX = Me.SurveyFlightsGridEX
    '    Dim FlightID As String = ""
    '    Try
    '        'get the current row of the VS GridEX
    '        If Not Grid.CurrentRow Is Nothing Then
    '            If Not Grid.CurrentRow.Cells("FlightID") Is Nothing Then
    '                If Not IsDBNull(Grid.CurrentRow.Cells("FlightID").Value) Then
    '                    FlightID = 
    '                End If
    '            End If

    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message & " " & System.Reflection.MethodBase.GetCurrentMethod.Name)
    '    End Try
    '    Return FlightID
    'End Function

    '''' <summary>
    '''' Returns the Herd of the currently selected Flight
    '''' </summary>
    '''' <returns>String</returns>
    'Private Function GetCurrentCampaignHerd() As String
    '    Dim Herd As String = ""
    '    Try
    '        'get the current row of the VS GridEX
    '        If Not Me.CampaignsGridEX.CurrentRow Is Nothing Then
    '            If Not IsDBNull(Me.CampaignsGridEX.CurrentRow.Cells("Herd").Value) Then
    '                Herd = Me.CampaignsGridEX.CurrentRow.Cells("Herd").Value
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message & " " & System.Reflection.MethodBase.GetCurrentMethod.Name)
    '    End Try
    '    Return Herd
    'End Function

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
            If Not Me.SurveyFlightsGridEX.CurrentRow Is Nothing Then
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
                    'NewRow.Item("SmallBull") = 0
                    'NewRow.Item("MediumBull") = 0
                    'NewRow.Item("LargeBull") = 0
                    'NewRow.Item("Cow") = 0
                    'NewRow.Item("Calf") = 0
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

                    'better to leave the animal count columns null
                    'If Herd = "Mentasta" Then
                    '    NewRow.Item("Bull") = 0
                    'ElseIf Herd = "Chisana" Then
                    '    NewRow.Item("SmallBull") = 0
                    '    NewRow.Item("MediumBull") = 0
                    '    NewRow.Item("LargeBull") = 0D
                    'End If
                    'NewRow.Item("Cow") = 0
                    'NewRow.Item("Calf") = 0
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







    Private Sub PopulationEstimateGridEX_SelectionChanged(sender As Object, e As EventArgs) Handles PopulationEstimateGridEX.SelectionChanged
        'set default values for the new population record
        SetPopulationGridEXDefaultValues()

        'reset the xrefpopulationcaribou gridex header
        LoadXrefPopulationEstimateCaribouHeader()
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
            SetCompCountGridEXDefaultValues()

            'when the user clicks on a composition survey caribou group, then load the xrefcariboucomposition gridex with available 
            'gps collars to allow the user to associate a collared caribou with the observed group
            'determine the CCID, primary key of the caribou group record, and set the default value to the new xrefcariboucomposition record
            Dim CCID As String = ""
            Dim SightingDate As Date
            Dim GroupNumber As Integer = 0
            Dim Waypoint As String = ""

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

                    'get the GroupNumber
                    If Not .CurrentRow.Cells("GroupNumber") Is Nothing And Not IsDBNull(.CurrentRow.Cells("GroupNumber")) Then
                        If Not IsDBNull(.CurrentRow.Cells("GroupNumber").Value) Then
                            GroupNumber = .CurrentRow.Cells("GroupNumber").Value
                        End If
                    End If

                    'get the Waypoint
                    If Not .CurrentRow.Cells("Waypoint") Is Nothing And Not IsDBNull(.CurrentRow.Cells("Waypoint")) Then
                        If Not IsDBNull(.CurrentRow.Cells("Waypoint").Value) Then
                            Waypoint = .CurrentRow.Cells("Waypoint").Value
                        End If
                    End If
                End If
            End With

            'set up default values
            With Me.XrefCompCountCaribouGridEX.RootTable
                .Columns("CCID").DefaultValue = CCID
                .Caption = "Collared caribou in group number " & GroupNumber & " (Waypoint " & Waypoint & ")"
            End With

            'if we have a valid observation date and an EID then load the collar selector dropdown with available collars
            'load the AnimalID with a selection of collars that were deployed on the date the caribou group was observed
            'LoadCollaredCaribouDropdown(Me.XrefCompCountCaribouGridEX, SightingDate)

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
            'LoadCollaredCaribouDropdown(Me.XrefRadiotrackingCaribouGridEX, SightingDate)



        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub

#Region "GridEX_Validated"
    'Private Sub CampaignsGridEX_Validated(sender As Object, e As EventArgs) Handles CampaignsGridEX.Validated
    '    Me.CampaignsBindingSource.EndEdit()
    'End Sub

    'Private Sub SurveyFlightsGridEX_Validated(sender As Object, e As EventArgs) Handles SurveyFlightsGridEX.Validated
    '    Me.SurveyFlightsBindingSource.EndEdit()
    'End Sub

    'Private Sub CompositionCountsGridEX_Validated(sender As Object, e As EventArgs) Handles CompositionCountsGridEX.Validated
    '    Me.CompositionCountsBindingSource.EndEdit()
    'End Sub

    'Private Sub PopulationEstimateGridEX_Validated(sender As Object, e As EventArgs) Handles PopulationEstimateGridEX.Validated
    '    Me.PopulationEstimateBindingSource.EndEdit()
    'End Sub

    'Private Sub RadioTrackingGridEX_Validated(sender As Object, e As EventArgs) Handles RadioTrackingGridEX.Validated
    '    Me.RadioTrackingBindingSource.EndEdit()
    'End Sub


#End Region
    Private Sub ImportRadiotrackingWaypointsToolStripButton_Click(sender As Object, e As EventArgs) Handles ImportRadiotrackingWaypointsToolStripButton.Click
        'open a DNRGPS waypoints file and load the waypoints into the radiotracking datatable
        OpenWaypointsFile("Radiotracking")
    End Sub

    Private Sub RefreshResultsToolStripButton_Click(sender As Object, e As EventArgs) Handles RefreshResultsToolStripButton.Click
        SaveDataset()
        LoadCampaignResults(GetCurrentGridEXCellValue(Me.CampaignsGridEX, "CampaignID"), Me.DatabaseViewNameToolStripLabel.Text)
    End Sub

#Region "Import waypoints from an arbitrary file"

    'import arbitrary waypoints to comp count
    Private Sub ImportCompCountXYFromFileToolStripButton_Click(sender As Object, e As EventArgs) Handles ImportCompCountXYFromFileToolStripButton.Click
        'get the structure of the destination datatable, we only need one record since the translator will clear all records anyway
        Dim Sql As String = "SELECT TOP (1) SightingDate, Herd, GroupNumber, SearchArea, SmallBull, MediumBull, LargeBull, Cow, Calf, Indeterminate, Waypoint, Frequencies, FlightID, CCID, RecordInsertedDate, RecordInsertedBy,        SourceFilename, Comment, Lat, Lon FROM   CompositionCounts"
        Dim DestinationDataTable As DataTable = GetDataTable(My.Settings.WRST_CaribouConnectionString, Sql)
        ImportSurveyDataFromFile(DestinationDataTable, SurveyType.CompositionCount, GetCurrentGridEXCellValue(Me.CampaignsGridEX, "Herd"), GetCurrentGridEXCellValue(Me.SurveyFlightsGridEX, "FlightID"))
    End Sub

    'import arbitrary waypoints to population
    Private Sub ImportPopulationSurveyWaypointsFromFileToolStripButton_Click(sender As Object, e As EventArgs) Handles ImportPopulationSurveyWaypointsFromFileToolStripButton.Click
        'get the structure of the destination datatable, we only need one record since the translator will clear all records anyway
        Dim Sql As String = "SELECT TOP 1 [Herd]        ,[SearchArea]        ,[GroupNumber]        ,[WaypointName]        ,[SightingDate], Bull        ,[SmallBull]        ,[MediumBull]        ,[LargeBull]        ,[Cow]        ,[Calf]        ,[InOrOut]        ,[Seen]        ,[Marked]        ,[FrequenciesInGroup]        ,[Lat]        ,[Lon]        ,[Comment]        ,[SourceFilename],[FlightID]        ,[EID]        ,[RecordInsertedDate]        ,[RecordInsertedBy]    FROM [WRST_Caribou].[dbo].[PopulationEstimate]"
        Dim DestinationDataTable As DataTable = GetDataTable(My.Settings.WRST_CaribouConnectionString, Sql)
        ImportSurveyDataFromFile(DestinationDataTable, SurveyType.PopulationEstimate, GetCurrentGridEXCellValue(Me.CampaignsGridEX, "Herd"), GetCurrentGridEXCellValue(Me.SurveyFlightsGridEX, "FlightID"))
    End Sub

    'import arbitrary waypoints to radiotracking
    Private Sub ImportRadiotrackingWaypointsFromFileToolStripButton_Click(sender As Object, e As EventArgs) Handles ImportRadiotrackingWaypointsFromFileToolStripButton.Click
        'get the structure of the destination datatable, we only need one record since the translator will clear all records anyway
        Dim Sql As String = "SELECT        TOP (1) Herd, GroupNumber, Frequency, VisualCollar, SightingDate, Mode, Accuracy, Bull, Cow, Calf, Adult, Unknown, Waypoint, RetainedAntler, DistendedUdders, CalvesAtHeel, Seen, FlightID, AnimalID, ProjectID, RTID, RecordInsertedDate, RecordInsertedBy, SearchArea, SourceFilename, Comment, Lat, Lon FROM            RadioTracking"
        Dim DestinationDataTable As DataTable = GetDataTable(My.Settings.WRST_CaribouConnectionString, Sql)
        ImportSurveyDataFromFile(DestinationDataTable, SurveyType.Radiotracking, GetCurrentGridEXCellValue(Me.CampaignsGridEX, "Herd"), GetCurrentGridEXCellValue(Me.SurveyFlightsGridEX, "FlightID"))
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
    Private Sub ImportSurveyDataFromFile(DestinationDataTable As DataTable, SurveyType As SurveyType, Herd As String, FlightID As String)
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
                .Add(GetCurrentGridEXCellValue(Me.SurveyFlightsGridEX, "FlightID")) 'the primary key of the currently selected flight
                .Add(GetCurrentGridEXCellValue(Me.CampaignsGridEX, "Herd")) 'the currently selected herd in the campaigns table
                .Add(SourceFileInfo.Name) 'the import file name
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
                NewRow.Item("FlightID") = FlightID
                NewRow.Item("RecordInsertedDate") = Now
                NewRow.Item("RecordInsertedBy") = My.User.Name
                NewRow.Item("Herd") = Herd


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
                        'Me.CompositionCountsGridEX.CurrentRow.EndEdit()
                    Case SurveyType.PopulationEstimate
                        Me.PopulationEstimateBindingSource.EndEdit()
                        'Me.PopulationEstimateGridEX.CurrentRow.EndEdit()
                    Case SurveyType.Radiotracking
                        Me.RadioTrackingBindingSource.EndEdit()
                        'Me.RadioTrackingGridEX.CurrentRow.EndEdit()
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

    Private Sub SelectSurveyTypeToolStripComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DatabaseViewsToolStripComboBox.SelectedIndexChanged
        If Not Me.DatabaseViewsToolStripComboBox.SelectedItem.ToString = "" Then
            LoadSurveyResultsGrid()
        Else
            MsgBox("Select a database View to load")
        End If

    End Sub


    ''' <summary>
    ''' Fetches the data from the View selected in Me.DatabaseViewsToolStripComboBox and loads it into the SurveyResultsDataGridView
    ''' </summary>
    Private Sub LoadSurveyResultsGrid()
        Try
            Dim ViewName As String = Me.DatabaseViewsToolStripComboBox.SelectedItem
            Dim Sql As String = "SELECT * FROM " & ViewName

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
        'refresh the list of database views
        LoadDatabaseViewsComboBox()

        'refresh the data in the results grid.
        LoadSurveyResultsGrid()
    End Sub

    Private Sub XrefPopulationCaribouGridEX_DropDown(sender As Object, e As ColumnActionEventArgs) Handles XrefPopulationCaribouGridEX.DropDown
        Try
            'get a ref to the animalid valuelist
            Dim Grid As GridEX = Me.XrefPopulationCaribouGridEX
            With Grid.RootTable.Columns("AnimalID")
                .EditType = EditType.DropDownList
                .HasValueList = True
                .LimitToList = True
                .ValueList.Clear()
            End With

            'get a reference to the AnimalID column's ValueList
            Dim List As GridEXValueListItemCollection = Grid.RootTable.Columns("AnimalID").ValueList

            'load in the items into the dropdown
            For Each Row As DataRow In AnimalMovementDataset.Tables("CollarDeployments").Rows
                Dim AnimalID As String = Row.Item("AnimalID")
                Dim CollaredCaribou As String = Row.Item("CollaredCaribou")
                List.Add(AnimalID, CollaredCaribou)
            Next
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub

    Private Sub CampaignsBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        SaveDataset()
    End Sub

    Private Sub EditCampaignsCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles EditCampaignsCheckBox.CheckedChanged
        'for some bizarre reason the checkbox does not return true or false, maybe because inheritableboolean? anyway, convert
        Dim Checked As InheritableBoolean = InheritableBoolean.False
        If Me.EditCampaignsCheckBox.Checked = True Then Checked = InheritableBoolean.True Else Checked = InheritableBoolean.False
        ToggleGridEXReadOnly(Me.CampaignsGridEX, Checked)
        ToggleGridEXReadOnly(Me.SurveyFlightsGridEX, Checked)
        ToggleGridEXReadOnly(Me.PopulationEstimateGridEX, Checked)
        ToggleGridEXReadOnly(Me.CompositionCountsGridEX, Checked)
        ToggleGridEXReadOnly(Me.RadioTrackingGridEX, Checked)
        ToggleGridEXReadOnly(Me.XrefPopulationCaribouGridEX, Checked)
        ToggleGridEXReadOnly(Me.XrefCompCountCaribouGridEX, Checked)
        ToggleGridEXReadOnly(Me.XrefRadiotrackingCaribouGridEX, Checked)
    End Sub


    ''' <summary>
    ''' Updates the SurveyTime_Min column of the Flights GridEX with the survey effort in minutes by caculating TimeReturn - TimeDepart.
    ''' </summary>
    Private Sub CalculateSearchEffortColumn()
        '   HAD TO ABANDON THIS IDEA BECAUSE THE .BEGINEDIT COMMAND ON THE ROW INTERFERED WITH THE BINDINGSOURCE AND NO EDITS GOT SENT BACK TO THE DATABASE.

        'loop through the flights grid and calculate the survey effort in minutes and put the result in the SurveyTime_Min cell
        'Dim Grid As GridEX = Me.SurveyFlightsGridEX
        'For Each Row As GridEXRow In Grid.GetRows()
        '    If Not IsDBNull(Row.Cells("TimeDepart").Value) And Not IsDBNull(Row.Cells("TimeReturn").Value) Then
        '        Row.BeginEdit()
        '        Row.Cells("SurveyTime_Min").Value = DateDiff(DateInterval.Minute, Row.Cells("TimeDepart").Value, Row.Cells("TimeReturn").Value)
        '        Row.EndEdit()
        '    End If
        'Next
    End Sub

    Private Sub CampaignsGridEX_RecordAdded(sender As Object, e As EventArgs) Handles CampaignsGridEX.RecordAdded
        SaveDataset()
    End Sub

    Private Sub SurveyFlightsGridEX_RecordAdded(sender As Object, e As EventArgs) Handles SurveyFlightsGridEX.RecordAdded
        SaveDataset()
    End Sub


    '''' <summary>
    '''' Returns the EID of the current row of XrefPopulationCaribouGridEX.
    '''' </summary>
    '''' <returns>String</returns>
    'Private Function GetCurrentEID() As String
    '    Dim GridEX As GridEX = Me.XrefPopulationCaribouGridEX
    '    Dim EID As String = ""
    '    Try
    '        'get the current row of the VS GridEX
    '        If Not GridEX.CurrentRow Is Nothing Then
    '            EID = GridEX.CurrentRow.Cells("EID").Value
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message & " " & System.Reflection.MethodBase.GetCurrentMethod.Name)
    '    End Try
    '    Return EID
    'End Function

    '''' <summary>
    '''' Returns the value of the column SightingDate of GridEX.
    '''' </summary>
    '''' <returns>String</returns>
    'Private Function GetCurrentSightingDate(GridEX As GridEX) As Date
    '    Dim SightingDate As Date
    '    Try
    '        'get the current row of the VS GridEX
    '        If Not GridEX Is Nothing Then
    '            If Not GridEX.CurrentRow Is Nothing Then
    '                SightingDate = GridEX.CurrentRow.Cells("SightingDate").Value
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message & " " & System.Reflection.MethodBase.GetCurrentMethod.Name)
    '    End Try
    '    Return SightingDate
    'End Function






#Region "After GridEX edits"

    Private Sub PopulationEstimateGridEX_RecordUpdated(sender As Object, e As EventArgs) Handles PopulationEstimateGridEX.RecordUpdated
        Me.PopulationEstimateGridEX.CurrentRow.EndEdit()
        'Me.PopulationEstimateBindingSource.EndEdit()
    End Sub

    Private Sub CompositionCountsGridEX_RecordUpdated(sender As Object, e As EventArgs) Handles CompositionCountsGridEX.RecordUpdated
        Me.CompositionCountsGridEX.CurrentRow.EndEdit()
    End Sub

    Private Sub RadioTrackingGridEX_RecordUpdated(sender As Object, e As EventArgs)
        Me.RadioTrackingGridEX.CurrentRow.EndEdit()
    End Sub

    Private Sub CampaignsGridEX_RecordUpdated(sender As Object, e As EventArgs) Handles CampaignsGridEX.RecordUpdated
        Me.CampaignsGridEX.CurrentRow.EndEdit()
    End Sub

    Private Sub SurveyFlightsGridEX_RecordUpdated(sender As Object, e As EventArgs) Handles SurveyFlightsGridEX.RecordUpdated
        Me.SurveyFlightsGridEX.CurrentRow.EndEdit()
    End Sub

    Private Sub XrefCompCountCaribouGridEX_RecordUpdated(sender As Object, e As EventArgs) Handles XrefCompCountCaribouGridEX.RecordUpdated
        Me.XrefCompCountCaribouGridEX.CurrentRow.EndEdit()
    End Sub

    Private Sub XrefPopulationCaribouGridEX_RecordUpdated(sender As Object, e As EventArgs) Handles XrefPopulationCaribouGridEX.RecordUpdated
        Me.XrefPopulationCaribouGridEX.CurrentRow.EndEdit()
    End Sub

    Private Sub XrefRadiotrackingCaribouGridEX_RecordUpdated(sender As Object, e As EventArgs) Handles XrefRadiotrackingCaribouGridEX.RecordUpdated
        Me.XrefRadiotrackingCaribouGridEX.CurrentRow.EndEdit()
    End Sub


#End Region




    ' <summary>
    ' Queries the Animal_Movement database for deployed GPS collars during SightingDate and then loads the submitted GridEX's AnimalID column
    ' with available collared animals based on collar frequency.
    ' </summary>
    ' <param name="GridEx">Parent GridEX</param>
    ' <param name="ObservationDate">Results will be filtered by available GPS collars deployed on this date.</param>
    'Private Sub LoadCollaredCaribouDropdown(GridEx As GridEX, ObservationDate As Date)

    '    'Caribou groups often contain GPS collared animals. 
    '    'When this event fires the user wants to associate a collared caribou with a group of caribou seen during a population survey.
    '    'The collar is detected by radio frequency.  We need to find out which collar was detected and which animal the collar was deployed on.
    '    'These data come from the Animal_Movement database.  Query based on survey date and frequency to determine which animal to associate with 
    '    ' the population survey group.

    '    'Try
    '    'Catch ex As Exception
    '    '    MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
    '    'End Try
    '    ''Ensure the GridEXColumn is configured for a DropDown
    '    'With GridEx.RootTable.Columns("AnimalID")
    '    '    .EditType = EditType.Combo
    '    '    .HasValueList = True
    '    '    .LimitToList = True
    '    '    .AllowSort = True
    '    '    .AutoComplete = True
    '    '    .ValueList.Clear()
    '    'End With

    '    ''retrieve the animal associated with the collar that was deployed during the time of the survey.  i.e.:
    '    'Dim Sql As String = "SELECT   Collars.Frequency, Animals.ProjectId, Animals.AnimalId,CollarDeployments.DeploymentDate, CollarDeployments.RetrievalDate
    '    '    FROM   Animals INNER JOIN
    '    '           CollarDeployments ON Animals.ProjectId = CollarDeployments.ProjectId AND Animals.AnimalId = CollarDeployments.AnimalId INNER JOIN
    '    '           Collars ON CollarDeployments.CollarManufacturer = Collars.CollarManufacturer AND CollarDeployments.CollarId = Collars.CollarId
    '    '    WHERE  (Animals.ProjectId = 'WRST_Caribou') And (DeploymentDate < '" & ObservationDate & "' And (RetrievalDate is NULL or RetrievalDate > '" & ObservationDate & "'))
    '    '    ORDER BY Collars.Frequency"

    '    ''get the filtered data into a datatable
    '    'Dim PossibleCollaredAnimalsDataTable As DataTable = GetDataTable(My.Settings.Animal_MovementConnectionString, Sql)

    '    ''Add the animalids into the GridEXValueListItemCollection
    '    'If Me.AnimalMovementDataset.Tables("Animals").Rows.Count > 0 Then
    '    '    For Each Row As DataRow In PossibleCollaredAnimalsDataTable.Rows
    '    '        If Not IsDBNull(Row.Item("AnimalID")) And Not IsDBNull(Row.Item("Frequency")) Then
    '    '            Dim ValueItem As String = Row.Item("AnimalID")
    '    '            Dim DisplayItem As String = Row.Item("AnimalID") & " Freq:" & Row.Item("Frequency")

    '    '            GridEx.RootTable.Columns("AnimalID").ValueList.Add(ValueItem, DisplayItem)
    '    '        End If
    '    '    Next
    '    'End If

    'End Sub

End Class

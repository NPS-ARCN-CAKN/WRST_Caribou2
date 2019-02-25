'todo animal_movement connectivity

Imports System.Data.SqlClient
Imports System.IO
Imports Janus.Windows.GridEX
Imports SkeeterDataTablesTranslator

Public Class Form1

    Dim ResultsDataTable As DataTable 'This reusable datatable will contain the data to be displayed in the Me.SurveyResultsDataGridView of the Results tab

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'set up the form
        Me.DatabaseViewNameToolStripLabel.Text = ""


        'load the data from the WRST_Caribou Sql Server database
        LoadDataset()



        'set up campaigns gridex
        FormatGridEX(Me.CampaignsGridEX) 'consistent look and feel
        SetCampaignsGridEXDefaultValues() 'set up default values
        SetCampaignsGridEXDropDowns() 'set up dropdowns


        'set up flights gridex
        FormatGridEX(Me.SurveyFlightsGridEX) 'consistent look and feel
        SetFlightsGridExDefaultValues() 'set up default values
        SetFlightsGridEXDropDowns() 'set up dropdowns
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


        'Load the Campaign header 
        LoadCampaignHeader()


        'on startup set the flights and data gridexes are invisible so user needs to explicitly select a campaign
        'if the campaign header is "" then set the tabcontrol invisible until a campaign is selected
        Me.CampaignTabControl.Visible = Not Me.CampaignHeaderLabel.Text = ""
        LoadFlightHeader()

        'maximize form
        Me.WindowState = FormWindowState.Maximized

        'load the Animal_Movement database grids
        LoadAnimalMovementGrids()


        'load a list of available database views into the results tab combobox so users can choose an analytical view
        LoadDatabaseViewsComboBox()

        'Caribou are isolated in the Animal_Movement database based on ProjectID and AnimalID. ProjectID always = 'WRST_Caribou' Set it here permanently
        Me.RadioTrackingGridEX.RootTable.Columns("ProjectID").DefaultValue = "WRST_Caribou" 'always 'WRST_Caribou', primary key, with AnimalID in the Animal_Movement database for the GPS collar


        'make all gridexes read-only to start with. this is changed by the user clicking Me.EditCampaignsCheckBox
        'make all the GridEXes readonly/editable
        AllowFormEdits(False)

        'check to see if the flight is certified, disable if so
        DoCertifiedFlightCheck()

        'disable editing on any campaigns with certified related flights



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
        Try
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
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub

    ''' <summary>
    ''' Loads information into the Caption of the XrefPopulationEstimateCaribou GridEX for context on which caribou group is current
    ''' </summary>
    Private Sub LoadXrefPopulationEstimateCaribouHeader()
        Try
            Dim Grid As GridEX = Me.PopulationEstimateGridEX

            'determine the EID, primary key of the caribou group record, and set the default value to the new xrefcariboucomposition record
            'Dim EID As String = ""
            'Dim SightingDate As Date
            Dim GroupNumber As Integer = 0
            'Dim Waypoint As String = ""
            Dim FrequenciesInGroup As String = ""

            'get the sighting date to use later, and get the EID to relate to any new xrefcariboucomposition records
            With Grid
                If Not .CurrentRow Is Nothing Then
                    'get the SightingDate
                    'If Not .CurrentRow.Cells("SightingDate") Is Nothing And Not IsDBNull(.CurrentRow.Cells("SightingDate")) Then
                    '    If Not IsDBNull(.CurrentRow.Cells("SightingDate").Value) Then
                    '        SightingDate = .CurrentRow.Cells("SightingDate").Value
                    '    End If
                    'End If

                    'set up the EID primary key for syncing with the group
                    'If Not .CurrentRow.Cells("EID") Is Nothing And Not IsDBNull(.CurrentRow.Cells("EID")) Then
                    '    If Not IsDBNull(.CurrentRow.Cells("EID").Value) Then
                    '        EID = .CurrentRow.Cells("EID").Value
                    '    End If
                    'End If

                    'get the GroupNumber
                    If Not .CurrentRow.Cells("GroupNumber") Is Nothing Then
                        If Not IsDBNull(.CurrentRow.Cells("GroupNumber").Value) Then
                            GroupNumber = .CurrentRow.Cells("GroupNumber").Value
                        End If
                    End If

                    'get the Waypoint
                    'If Not .CurrentRow.Cells("WaypointName") Is Nothing Then
                    '    If Not IsDBNull(.CurrentRow.Cells("WaypointName").Value) Then
                    '        Waypoint = .CurrentRow.Cells("WaypointName").Value
                    '    End If
                    'End If

                    'get the Waypoint
                    If Not .CurrentRow.Cells("FrequenciesInGroup") Is Nothing Then
                        If Not IsDBNull(.CurrentRow.Cells("FrequenciesInGroup").Value) Then
                            FrequenciesInGroup = .CurrentRow.Cells("FrequenciesInGroup").Value
                        End If
                    End If
                End If
            End With

            'modify the header
            If FrequenciesInGroup = "" Then
                FrequenciesInGroup = "NONE"
            End If
            Me.XrefPopulationCaribouGridEX.RootTable.Caption = "GPS collared caribou in group number " & GroupNumber & " (Frequencies: " & FrequenciesInGroup & ")"

        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub
#End Region




















#Region "Set up GridEX default values"

    ''' <summary>
    ''' Sets up the Campaigns GridEX's default values
    ''' </summary>
    Private Sub SetCampaignsGridEXDefaultValues()
        Try
            'Set up default values
            Dim Grid As GridEX = Me.CampaignsGridEX
            Grid.RootTable.Columns("RecordInsertedDate").DefaultValue = Now
            Grid.RootTable.Columns("RecordInsertedBy").DefaultValue = My.User.Name
            Grid.RootTable.Columns("CampaignID").DefaultValue = Guid.NewGuid.ToString

            'set up the flight gridex's 'herd' column default value based on the Herd column of the survey campaigns grid current row
            If Not Grid.CurrentRow Is Nothing Then
                If Not Grid.CurrentRow.Cells("Herd") Is Nothing And Not IsDBNull(Grid.CurrentRow.Cells("Herd").Value) Then
                    Dim CampaignHerd As String = GetCurrentGridEXCellValue(Me.CampaignsGridEX, "Herd")
                    Dim CampaignID As String = GetCurrentGridEXCellValue(Me.CampaignsGridEX, "CampaignID")
                    Me.SurveyFlightsGridEX.RootTable.Columns("Herd").DefaultValue = CampaignHerd
                    Me.SurveyFlightsGridEX.RootTable.Columns("CampaignID").DefaultValue = CampaignID

                    'while we're here set up the Herd column in the other gridexes to match 
                    Me.SurveyFlightsGridEX.RootTable.Columns("Herd").DefaultValue = CampaignHerd
                    Me.RadioTrackingGridEX.RootTable.Columns("Herd").DefaultValue = CampaignHerd
                    Me.PopulationEstimateGridEX.RootTable.Columns("Herd").DefaultValue = CampaignHerd
                    Me.CompositionCountsGridEX.RootTable.Columns("Herd").DefaultValue = CampaignHerd
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub

    ''' <summary>
    ''' Sets up the Flights GridEX's default values
    ''' </summary>
    Private Sub SetFlightsGridExDefaultValues()
        Try
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
            Grid.RootTable.Columns("SOPVersion").DefaultValue = MaxSOPVersion

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
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub


    ''' <summary>
    ''' Sets up the population data grid default values
    ''' </summary>
    Private Sub SetPopulationGridEXDefaultValues()
        Try
            Dim GridEX As GridEX = Me.PopulationEstimateGridEX
            GridEX.RootTable.Columns("EID").DefaultValue = Guid.NewGuid.ToString
            GridEX.RootTable.Columns("RecordInsertedDate").DefaultValue = Now
            GridEX.RootTable.Columns("RecordInsertedBy").DefaultValue = My.User.Name
            GridEX.RootTable.Columns("Herd").DefaultValue = GetCurrentGridEXCellValue(Me.CampaignsGridEX, "Herd")
            GridEX.RootTable.Columns("GroupNumber").DefaultValue = GetMaximumGroupNumber(GridEX) + 1
        Catch ex As Exception
            MsgBox(ex.Message & " " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub

    ''' <summary>
    ''' Sets up the comp count grid default values
    ''' </summary>
    Private Sub SetCompCountGridEXDefaultValues()
        Try
            Dim GridEX As GridEX = Me.CompositionCountsGridEX
            GridEX.RootTable.Columns("CCID").DefaultValue = Guid.NewGuid.ToString
            GridEX.RootTable.Columns("RecordInsertedDate").DefaultValue = Now
            GridEX.RootTable.Columns("RecordInsertedBy").DefaultValue = My.User.Name
            GridEX.RootTable.Columns("Herd").DefaultValue = GetCurrentGridEXCellValue(Me.CampaignsGridEX, "Herd")
            GridEX.RootTable.Columns("GroupNumber").DefaultValue = GetMaximumGroupNumber(GridEX) + 1
        Catch ex As Exception
            MsgBox(ex.Message & " " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub

    ''' <summary>
    ''' Sets up the radiotracking data grid's default values
    ''' </summary>
    Private Sub SetRadioTrackingGridEXDefaultValues()
        Try
            Dim GridEX As GridEX = Me.RadioTrackingGridEX
            GridEX.RootTable.Columns("RTID").DefaultValue = Guid.NewGuid.ToString
            GridEX.RootTable.Columns("RecordInsertedDate").DefaultValue = Now
            GridEX.RootTable.Columns("RecordInsertedBy").DefaultValue = My.User.Name
            GridEX.RootTable.Columns("Herd").DefaultValue = GetCurrentGridEXCellValue(Me.CampaignsGridEX, "Herd")
            GridEX.RootTable.Columns("GroupNumber").DefaultValue = GetMaximumGroupNumber(GridEX) + 1
        Catch ex As Exception
            MsgBox(ex.Message & " " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub

    ''' <summary>
    ''' Returns the maximum value of GridEX's column named GroupNumber. Used to increment GroupNumber as a default value for new records by adding 1.
    ''' </summary>
    ''' <returns></returns>
    Private Function GetMaximumGroupNumber(GridEX As GridEX) As Integer
        Dim MaxGroupNumber As Integer = 0
        If Not GridEX Is Nothing Then
            'determine the maximum group number
            For Each Row As GridEXRow In GridEX.GetRows()
                If Row.Cells("GroupNumber").Value > MaxGroupNumber Then
                    MaxGroupNumber = Row.Cells("GroupNumber").Value
                End If
            Next
        End If
        Return MaxGroupNumber
    End Function

    ''' <summary>
    ''' Sets up the population data to animals grid's default values
    ''' </summary>
    Private Sub SetXrefPopulationEstimateCaribouGridEXDefaultValues()
        Try
            Dim Grid As GridEX = Me.XrefPopulationCaribouGridEX
            Grid.RootTable.Columns("PCID").DefaultValue = Guid.NewGuid.ToString 'primary key
            Grid.RootTable.Columns("RecordInsertedDate").DefaultValue = Now
            Grid.RootTable.Columns("RecordInsertedBy").DefaultValue = My.User.Name
        Catch ex As Exception
            MsgBox(ex.Message & " " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub

    ''' <summary>
    '''  Sets up the comp count data to animals grid's default values
    ''' </summary>
    Private Sub SetXrefCompCountCaribouGridEXDefaultValues()
        Try
            Dim Grid As GridEX = Me.XrefCompCountCaribouGridEX
            Grid.RootTable.Columns("CCID").DefaultValue = Guid.NewGuid.ToString 'primary key
            Grid.RootTable.Columns("RecordInsertedDate").DefaultValue = Now
            Grid.RootTable.Columns("RecordInsertedBy").DefaultValue = My.User.Name
        Catch ex As Exception
            MsgBox(ex.Message & " " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub

    ''' <summary>
    '''  Sets up the radiotracking data to animals grid's default values
    ''' </summary>
    Private Sub SetXrefRadioTrackingCaribouGridEXDefaultValues()
        Try
            Dim Grid As GridEX = Me.XrefRadiotrackingCaribouGridEX
            Grid.RootTable.Columns("RTCID").DefaultValue = Guid.NewGuid.ToString 'primary key
            Grid.RootTable.Columns("RecordInsertedDate").DefaultValue = Now
            Grid.RootTable.Columns("RecordInsertedBy").DefaultValue = My.User.Name
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub

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


#Region "Open waypoints file for importing"
    Private Sub ImportPopulationWaypointsToolStripButton_Click(sender As Object, e As EventArgs) Handles ImportPopulationWaypointsToolStripButton.Click
        'open a waypoints file to import
        OpenWaypointsFile("PopulationEstimate")
    End Sub

    Private Sub ImportCompCountWaypointsToolStripButton_Click(sender As Object, e As EventArgs) Handles ImportCompCountWaypointsToolStripButton.Click
        'open a waypoints file to import
        OpenWaypointsFile("CompositionCounts")
    End Sub

    Private Sub ImportRadiotrackingWaypointsToolStripButton_Click(sender As Object, e As EventArgs) Handles ImportRadiotrackingWaypointsToolStripButton.Click
        'open a waypoints file to import
        OpenWaypointsFile("Radiotracking")
    End Sub
#End Region



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

    '''' <summary>
    '''' Checks to see if the Campaign has related certified flights. Disallows editing if found.
    '''' </summary>
    'Private Sub DoCertifiedCampaignCheck()
    '    If CampaignHasCertifiedRecords() = True Then
    '        'make all the GridEXes readonly
    '        AllowFormEdits(False)
    '        Me.EditCampaignsCheckBox.Enabled = False
    '        Me.EditCampaignsCheckBox.Text = "Allow edits (Related record[s] are certified"

    '    Else
    '        Me.EditCampaignsCheckBox.Enabled = True
    '        Me.EditCampaignsCheckBox.Text = "Allow edits"
    '        'determine if the application is in edit mode based on the edit checkbox
    '        'if edits are allowed then only allow edits on non-certified records
    '        If Me.EditCampaignsCheckBox.Checked = True Then
    '            'make all the GridEXes editable
    '            AllowFormEdits(True)
    '        End If
    '    End If
    'End Sub

    Private Sub DoCertifiedFlightCheck()

        'we are in edit mode
        If Me.EditCampaignsCheckBox.Checked = True And FlightRecordIsCertified() = True Then

            'form is editable but record is certified
            AllowFormEdits(False)
            Me.EditCampaignsCheckBox.Text = "Allow edits (Record is certified)"
            Me.EditCampaignsCheckBox.Enabled = False
        ElseIf Me.EditCampaignsCheckBox.Checked = True And FlightRecordIsCertified() = False Then

            'form is editable and record is uncertified
            AllowFormEdits(True)
            Me.EditCampaignsCheckBox.Text = "Allow edits"
            Me.EditCampaignsCheckBox.Enabled = True

        ElseIf Me.EditCampaignsCheckBox.Checked = False And FlightRecordIsCertified() = True Then

            'form is not editable and record is certified
            AllowFormEdits(False)
            Me.EditCampaignsCheckBox.Text = "Allow edits (Record is certified)"
            Me.EditCampaignsCheckBox.Enabled = False

        ElseIf Me.EditCampaignsCheckBox.Checked = False And FlightRecordIsCertified() = False Then
            'form is not editable and record is uncertified
            AllowFormEdits(False)
            Me.EditCampaignsCheckBox.Text = "Allow edits"
            Me.EditCampaignsCheckBox.Enabled = True

        End If
    End Sub

    Private Sub SurveyFlightsGridEX_SelectionChanged(sender As Object, e As EventArgs) Handles SurveyFlightsGridEX.SelectionChanged
        Try
            'load the current flight info into the flight header label so the user can see which flight is currently selected
            LoadFlightHeader()
            SetFlightsGridExDefaultValues()

            'check to see if the flight is certified, disable if so
            DoCertifiedFlightCheck()
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub


    ''' <summary>
    ''' Examines the value of the CertificationLevel of the SurveyFlightsGridEX. Returns true if the flight is 'Certified'.
    ''' </summary>
    ''' <returns>Boolean</returns>
    Private Function FlightRecordIsCertified() As Boolean
        Dim IsCertified As Boolean = False

        'determine if the current flight is certified
        If GetCurrentGridEXCellValue(Me.SurveyFlightsGridEX, "CertificationLevel") = "Certified" Then
            IsCertified = True
        End If

        Return IsCertified
    End Function

    Private Sub XrefRadiotrackingCaribouGridEX_SelectionChanged(sender As Object, e As EventArgs) Handles XrefRadiotrackingCaribouGridEX.SelectionChanged
        SetXrefRadioTrackingCaribouGridEXDefaultValues()
    End Sub


    Private Sub PopulationEstimateGridEX_SelectionChanged(sender As Object, e As EventArgs) Handles PopulationEstimateGridEX.SelectionChanged
        'set default values for the new population record
        SetPopulationGridEXDefaultValues()

        'reset the xrefpopulationcaribou gridex header
        LoadXrefPopulationEstimateCaribouHeader()
    End Sub


    Private Sub XrefPopulationCaribouGridEX_SelectionChanged(sender As Object, e As EventArgs) Handles XrefPopulationCaribouGridEX.SelectionChanged
        SetXrefPopulationEstimateCaribouGridEXDefaultValues()
    End Sub



    Private Sub CompositionCountsGridEX_SelectionChanged(sender As Object, e As EventArgs) Handles CompositionCountsGridEX.SelectionChanged
        SetCompCountGridEXDefaultValues()
    End Sub

    Private Sub XrefCompCountCaribouGridEX_SelectionChanged(sender As Object, e As EventArgs) Handles XrefCompCountCaribouGridEX.SelectionChanged
        SetXrefCompCountCaribouGridEXDefaultValues()
    End Sub

    Private Sub RadioTrackingGridEX_SelectionChanged(sender As Object, e As EventArgs) Handles RadioTrackingGridEX.SelectionChanged
        SetRadioTrackingGridEXDefaultValues()
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

    ''' <summary>
    ''' Sets up the Flights GridEX dropdowns
    ''' </summary>
    Private Sub SetFlightsGridEXDropDowns()
        Try
            Dim Grid As GridEX = Me.SurveyFlightsGridEX
            'Set up dropdowns
            LoadGridEXDropDownWithDistinctDataTableValues(Grid, Me.WRST_CaribouDataSet.Tables("SurveyFlights"), "Pilot", "Pilot", False)
            LoadGridEXDropDownWithDistinctDataTableValues(Grid, Me.WRST_CaribouDataSet.Tables("SurveyFlights"), "TailNo", "TailNo", False)
            LoadGridEXDropDownWithDistinctDataTableValues(Grid, Me.WRST_CaribouDataSet.Tables("SurveyFlights"), "AircraftType", "AircraftType", False)
            LoadGridEXDropDownWithDistinctDataTableValues(Grid, Me.WRST_CaribouDataSet.Tables("SurveyFlights"), "Observer1", "Observer1", False)
            LoadGridEXDropDownWithDistinctDataTableValues(Grid, Me.WRST_CaribouDataSet.Tables("SurveyFlights"), "Observer2", "Observer2", False)
            LoadGridEXDropDownWithDistinctDataTableValues(Grid, Me.WRST_CaribouDataSet.Tables("SurveyFlights"), "SOPNumber", "SOPNumber", False)
            LoadGridEXDropDownWithDistinctDataTableValues(Grid, Me.WRST_CaribouDataSet.Tables("SurveyFlights"), "SOPVersion", "SOPVersion", False)
            LoadGridEXDropDownWithDistinctDataTableValues(Grid, Me.WRST_CaribouDataSet.Tables("SurveyFlights"), "Pilot", "SpotterPlanePilot", False)
            LoadGridEXDropDownWithDistinctDataTableValues(Grid, Me.WRST_CaribouDataSet.Tables("SurveyFlights"), "TailNo", "SpotterPlaneTailNo", False)
            LoadGridEXDropDownWithDistinctDataTableValues(Grid, Me.WRST_CaribouDataSet.Tables("SurveyFlights"), "AircraftType", "SpotterPlaneType", False)

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

        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
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
    '''  <param name="LimitToList">Whether options for the dropdown should be limited to the list or not. Boolean.</param>
    Private Sub LoadGridEXDropDownWithDistinctDataTableValues(GridEX As GridEX, SourceDataTable As DataTable, SourceColumnName As String, GridEXColumnName As String, LimitToList As Boolean)
        Try
            'Ensure the GridEXColumn is configured for a DropDown
            With GridEX.RootTable.Columns(GridEXColumnName)
                .EditType = EditType.Combo
                .HasValueList = True
                .LimitToList = LimitToList
                .AllowSort = True
                .AutoComplete = True
                .ValueList.Clear()
            End With

            'Get the distinct items from a DataTable
            Dim DistinctItemsDataTable As DataTable = SourceDataTable.DefaultView.ToTable(True, SourceColumnName)

            'Sort the DataView
            Dim DistinctItemsDataView As New DataView(DistinctItemsDataTable, "", SourceColumnName, DataRowState.Unchanged)

            'Make a GridEXValueListItemCollection to hold the distinct items
            Dim ItemsList As GridEXValueListItemCollection = GridEX.RootTable.Columns(GridEXColumnName).ValueList

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
            Dim AnimalsBindingSource As New BindingSource
            AnimalsBindingSource.DataSource = GetCollarDeploymentsDataTable()
            Me.AnimalsBindingNavigator.BindingSource = AnimalsBindingSource
            AnimalsDataGridView.DataSource = AnimalsBindingSource
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub

    ''' <summary>
    ''' DID NOT WORK, don't know why
    ''' </summary>
    Private Sub FormatAnimalsDataGridView()

        For Each Row As DataGridViewRow In Me.AnimalsDataGridView.Rows
            Row.Cells("AnimalID").Style.BackColor = Color.AliceBlue
            If Not Row Is Nothing Then

                If Not Row.Cells("MortalityDate") Is Nothing Then
                    If Not IsDBNull(Row.Cells("MortalityDate").Value) Then
                        Row.Cells("AnimalID").Style.Font = New Font(Me.AnimalsDataGridView.Font, FontStyle.Italic)

                    End If
                End If
            End If
        Next
        Try
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub

    ''' <summary>
    ''' Save any pending changes in the in-memory Dataset, with confirmation, back to the database.
    ''' </summary>
    Private Sub SaveDataset()
        'end all bindingsource edits
        EndAllBindingSourceEdits

        'try to save
        If Me.WRST_CaribouDataSet.HasChanges = True Then
            Try
                Me.Validate()
                Me.TableAdapterManager.UpdateAll(Me.WRST_CaribouDataSet)
                Me.WRST_CaribouDataSet.AcceptChanges()
            Catch ex As Exception
                Dim Response As MsgBoxResult = MsgBox("There was an error saving your data to the database." & vbNewLine & ex.Message & vbNewLine & vbNewLine & "Click Yes to continue. Click No to abandon all edits since the last save. ", MsgBoxStyle.YesNo, "Save") = MsgBoxResult.Yes
                If Response = 0 Then 'No
                    'cancel all pending edits, last resort
                    Me.WRST_CaribouDataSet.RejectChanges()
                    SaveDataset()
                    LoadDataset()
                End If
            End Try

        End If
    End Sub

    ''' <summary>
    ''' Ends edits on all the application's BindingSources. Usually done before saving.
    ''' </summary>
    Private Sub EndAllBindingSourceEdits()
        Try
            Me.CampaignsBindingSource.EndEdit()
            Me.SurveyFlightsBindingSource.EndEdit()
            Me.CompositionCountsBindingSource.EndEdit()
            Me.PopulationEstimateBindingSource.EndEdit()
            Me.RadioTrackingBindingSource.EndEdit()
            Me.XrefPopulationCaribouBindingSource.EndEdit()
            Me.XrefCompCountCaribouBindingSource.EndEdit()
            Me.XrefRadiotrackingCaribouBindingSource.EndEdit()
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub

    Private Sub LoadDataset()
        Try
            If WRST_CaribouDataSet.HasChanges = True Then
                Dim Result As MsgBoxResult = MsgBox("The local dataset has changes that have not been pushed to the database server. If you do not save these edits they will be lost. Yes to save recent edits. No to lose edits and refresh the dataset. Cancel to abort.", MsgBoxStyle.YesNoCancel, "Save?")
                If Result = MsgBoxResult.Cancel Then
                    'abort the dataset reload
                    Exit Sub
                ElseIf Result = MsgBoxResult.Yes Then
                    'save the dataset
                    SaveDataset()
                End If
            End If

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
                .SelectedFormatStyle.BackColor = Color.SteelBlue
                .SelectedFormatStyle.ForeColor = Color.White
                .SelectedFormatStyle.FontBold = TriState.False
                .SelectedInactiveFormatStyle.BackColor = Color.SteelBlue
                .SelectedInactiveFormatStyle.ForeColor = Color.White
                .SelectedInactiveFormatStyle.FontBold = TriState.False
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
        'Disabled for now; too annoying and surprising to end user
        'Try
        '    If GridEX.View = View.TableView Then
        '        GridEX.View = View.CardView
        '    Else
        '        GridEX.View = View.TableView
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        'End Try
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
        ImportSurveyDataFromFile(DestinationDataTable, SurveyType.CompositionCounts, GetCurrentGridEXCellValue(Me.CampaignsGridEX, "Herd"), GetCurrentGridEXCellValue(Me.SurveyFlightsGridEX, "FlightID"))

        'save the dataset
        SaveDataset()

        'convert any animal counts of zero to null
        ExecuteStoredProcedure("SP_CaribouGroupsZeroesToNulls")

        'reload the corrected dataset
        LoadDataset()
    End Sub

    'import arbitrary waypoints to population
    Private Sub ImportPopulationSurveyWaypointsFromFileToolStripButton_Click(sender As Object, e As EventArgs) Handles ImportPopulationSurveyWaypointsFromFileToolStripButton.Click
        'get the structure of the destination datatable, we only need one record since the translator will clear all records anyway
        Dim Sql As String = "SELECT TOP 1 [Herd]        ,[SearchArea]        ,[GroupNumber]        ,[WaypointName]        ,[SightingDate], Bull        ,[SmallBull]        ,[MediumBull]        ,[LargeBull]        ,[Cow]        ,[Calf]        ,[InOrOut]        ,[Seen]        ,[Marked]        ,[FrequenciesInGroup]        ,[Lat]        ,[Lon]        ,[Comment]        ,[SourceFilename],[FlightID]        ,[EID]        ,[RecordInsertedDate]        ,[RecordInsertedBy]    FROM [WRST_Caribou].[dbo].[PopulationEstimate]"
        Dim DestinationDataTable As DataTable = GetDataTable(My.Settings.WRST_CaribouConnectionString, Sql)
        ImportSurveyDataFromFile(DestinationDataTable, SurveyType.PopulationEstimate, GetCurrentGridEXCellValue(Me.CampaignsGridEX, "Herd"), GetCurrentGridEXCellValue(Me.SurveyFlightsGridEX, "FlightID"))

        'save the dataset
        SaveDataset()

        'convert any animal counts of zero to null
        ExecuteStoredProcedure("SP_CaribouGroupsZeroesToNulls")

        'reload the corrected dataset
        LoadDataset()
    End Sub

    'import arbitrary waypoints to radiotracking
    Private Sub ImportRadiotrackingWaypointsFromFileToolStripButton_Click(sender As Object, e As EventArgs) Handles ImportRadiotrackingWaypointsFromFileToolStripButton.Click
        'get the structure of the destination datatable, we only need one record since the translator will clear all records anyway
        Dim Sql As String = "SELECT  TOP (1) Herd, GroupNumber, Frequency, VisualCollar, SightingDate, Mode, Accuracy, Bull, Cow, Calf, Adult, Unknown, Waypoint, RetainedAntler, DistendedUdders, CalvesAtHeel, Seen, FlightID, AnimalID, ProjectID, RTID, RecordInsertedDate, RecordInsertedBy, SearchArea, SourceFilename, Comment, Lat, Lon FROM            RadioTracking"
        Dim DestinationDataTable As DataTable = GetDataTable(My.Settings.WRST_CaribouConnectionString, Sql)
        ImportSurveyDataFromFile(DestinationDataTable, SurveyType.Radiotracking, GetCurrentGridEXCellValue(Me.CampaignsGridEX, "Herd"), GetCurrentGridEXCellValue(Me.SurveyFlightsGridEX, "FlightID"))

        'save the dataset
        SaveDataset()

        'convert any animal counts of zero to null
        ExecuteStoredProcedure("SP_CaribouGroupsZeroesToNulls")

        'reload the corrected dataset
        LoadDataset()
    End Sub

    ''' <summary>
    ''' Survey types
    ''' </summary>
    Public Enum SurveyType
        CompositionCounts
        PopulationEstimate
        Radiotracking
    End Enum

    ''' <summary>
    ''' Loads a source file of waypoints and an intended destination DataTable, then opens a translator form to map the source columns into the destination datatable schema.
    ''' Finally, loads the transformed data into the DestinationDataTable.
    ''' </summary>
    ''' <param name="DestinationDataTable">DataTable. The DataTable schema into which the source DataTable's columns should be matched.</param>
    Private Sub ImportSurveyDataFromFile(DestinationDataTable As DataTable, SurveyType As SurveyType, Herd As String, FlightID As String)
        If Not DestinationDataTable Is Nothing Then
            If SurveyType.ToString = "PopulationEstimate" Or SurveyType.ToString = "CompositionCounts" Or SurveyType.ToString = "Radiotracking" Then
                If Herd = "Mentasta" Or Herd = "Chisana" Then
                    If FlightID.Trim.Length > 0 Then
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
                                    Case SurveyType.CompositionCounts
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
                                    Case SurveyType.CompositionCounts
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
                    Else
                        MsgBox("FlightID is required")
                    End If
                Else
                    MsgBox("Herd must be Mentasta or Chisana")
                End If
            Else
                MsgBox("SurveyType must be PopulationEstimate Object CompositionCount Or Radiotracking")
            End If
        Else
            MsgBox("DestinationDataTable cannot be nothing.")
        End If

    End Sub

#End Region

    Private Sub RefreshDataToolStripButton_Click(sender As Object, e As EventArgs) Handles RefreshDataToolStripButton.Click
        SaveDataset()
        LoadDataset()
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


        'refresh the data in the results grid.
        LoadSurveyResultsGrid()

        'refresh the list of database views
        LoadDatabaseViewsComboBox()
    End Sub



    Private Sub CampaignsBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        SaveDataset()
    End Sub

    Private Sub EditCampaignsCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles EditCampaignsCheckBox.CheckedChanged
        'make all the GridEXes readonly/editable
        AllowFormEdits(Me.EditCampaignsCheckBox.Checked)
    End Sub

    ''' <summary>
    ''' Renders all the GridEXes in the application read only.
    ''' </summary>
    ''' <param name="AllowEdits">Make all the GridEXes read only. Boolean.</param>
    Private Sub AllowFormEdits(AllowEdits As Boolean)
        'for some bizarre reason the checkbox does not return true or false, maybe because inheritableboolean? anyway, convert
        Dim Checked As InheritableBoolean = InheritableBoolean.False
        If AllowEdits = True Then Checked = InheritableBoolean.True Else Checked = InheritableBoolean.False

        'toggle all the gridexes editability
        ToggleGridEXReadOnly(Me.CampaignsGridEX, Checked)
        ToggleGridEXReadOnly(Me.SurveyFlightsGridEX, Checked)
        ToggleGridEXReadOnly(Me.PopulationEstimateGridEX, Checked)
        ToggleGridEXReadOnly(Me.CompositionCountsGridEX, Checked)
        ToggleGridEXReadOnly(Me.RadioTrackingGridEX, Checked)
        ToggleGridEXReadOnly(Me.XrefPopulationCaribouGridEX, Checked)
        ToggleGridEXReadOnly(Me.XrefCompCountCaribouGridEX, Checked)
        ToggleGridEXReadOnly(Me.XrefRadiotrackingCaribouGridEX, Checked)

        'toggle toolstrips enabled
        Me.CompCountToolStrip.Enabled = AllowEdits
        Me.PopulationToolStrip.Enabled = AllowEdits
        Me.RadiotrackingToolStrip.Enabled = AllowEdits
    End Sub

    ''' <summary>
    ''' Enables/disables GridEX.
    ''' </summary>
    ''' <param name="GridEX">GridEX to modify. GridEX.</param>
    ''' <param name="AllowEdits">Allow edits. Boolean.</param>
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
















#Region "After GridEX edits"

    Private Sub PopulationEstimateGridEX_RecordUpdated(sender As Object, e As EventArgs) Handles PopulationEstimateGridEX.RecordUpdated
        Dim Grid As GridEX = Me.PopulationEstimateGridEX
        Grid.CurrentRow.EndEdit()

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

    Private Sub SurveyFlightsGridEX_EditingCell(sender As Object, e As EditingCellEventArgs) Handles SurveyFlightsGridEX.EditingCell
        SetFlightsGridEXDropDowns()
    End Sub









#End Region


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
            If ViewName.Trim.Length > 0 Then
                Try
                    Dim Filter As String = ""
                    If Me.QueryFilterToolStripTextBox.Text.Trim.Length > 0 Then
                        Filter = " WHERE " & Me.QueryFilterToolStripTextBox.Text.Trim.Replace("DELETE", "").Replace("UPDATE", "")
                    End If
                    Dim Sql As String = "SELECT * FROM " & ViewName.Trim & Filter
                    ResultsDataTable = GetDataTable(My.Settings.WRST_CaribouConnectionString, Sql)
                    Me.SurveyResultsBindingSource.DataSource = ResultsDataTable
                    Me.SurveyResultsDataGridView.DataSource = Me.SurveyResultsBindingSource
                Catch ex As Exception
                    MsgBox("Could not load the database view " & ViewName.Trim & ". " & ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & " a)")
                    Me.SurveyResultsBindingSource.DataSource = Nothing
                    Me.SurveyResultsDataGridView.DataSource = Nothing
                End Try
            Else
                MsgBox("Select a database view.", MsgBoxStyle.Information, "View not selected")
            End If
        Catch ex As Exception
            MsgBox("Query failed: " & ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
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

    Private Sub DatabaseViewsToolStripComboBox_Enter(sender As Object, e As EventArgs) Handles DatabaseViewsToolStripComboBox.Enter
        LoadDatabaseViewsComboBox()
    End Sub


    '''<summary>
    '''Queries the Animal_Movement database For deployed GPS collars during SightingDate And Then loads the submitted GridEX's AnimalID column
    '''With available collared animals based On collar frequency.
    ''' </summary>
    '''<param name = "GridEx" > Parent GridEX</param>
    '''<param name = "ObservationDate" > Results will be filtered by available GPS collars deployed On this Date.</param>
    Private Sub LoadCollaredCaribouDropdown(GridEx As GridEX, ObservationDate As Date)

        'Caribou groups often contain GPS collared animals. 
        'When this event fires the user wants to associate a collared caribou with a group of caribou seen during a population survey.
        'The collar is detected by radio frequency.  We need to find out which collar was detected and which animal the collar was deployed on.
        'These data come from the Animal_Movement database.  Query based on survey date and frequency to determine which animal to associate with 
        ' the population survey group.


        'Ensure the GridEXColumn is configured for a DropDown
        With GridEx.RootTable.Columns("AnimalID")
            .EditType = EditType.Combo
            .HasValueList = True
            .LimitToList = True
            .AllowSort = True
            .AutoComplete = True
            .ValueList.Clear()
        End With


        'get the filtered data into a datatable
        Dim DT As DataTable = GetCurrentCollarDeploymentsDataTable(ObservationDate)

        'Add the animalids into the GridEXValueListItemCollection
        For Each Row As DataRow In DT.Rows
            If Not IsDBNull(Row.Item("AnimalID")) And Not IsDBNull(Row.Item("Frequency")) Then

                Dim ValueItem As String = Row.Item("AnimalID")
                Dim Frequency As String = Row.Item("Frequency")

                Dim DeploymentDate As String = ""
                If Not IsDBNull(Row.Item("DeploymentDate")) = True And IsDate(Row.Item("DeploymentDate")) Then
                    DeploymentDate = Row.Item("DeploymentDate")
                End If


                Dim RetrievalDate As String = ""
                If Not IsDBNull(Row.Item("RetrievalDate")) = True And IsDate(Row.Item("RetrievalDate")) Then
                    RetrievalDate = Row.Item("RetrievalDate")
                End If

                Dim MortalityDate As String = ""
                If Not IsDBNull(Row.Item("MortalityDate")) = True And IsDate(Row.Item("MortalityDate")) Then
                    MortalityDate = Row.Item("MortalityDate")
                End If

                Dim Status As String = ""
                If MortalityDate.Trim.Length = 0 Then Status = "(Alive)" Else Status = "(Dead" & MortalityDate & ")"


                Dim DeploymentPeriod As String = ""
                If DeploymentDate.Trim.Length > 0 And RetrievalDate.Trim.Length = 0 Then
                    'still deployed
                    DeploymentPeriod = " Deployed on: " & DeploymentDate & " (Current)."
                ElseIf DeploymentDate.Trim.Length > 0 And RetrievalDate.Trim.Length > 0 Then
                    'deployed and later retrieved
                    DeploymentPeriod = " Deployed from: " & DeploymentDate & " to " & RetrievalDate & "."
                Else
                    'wierd situation where collar is neither deployed or retrieved
                    DeploymentPeriod = "ERROR: Cannot determine deployment status."
                End If


                Dim DisplayItem As String = Row.Item("AnimalID") & " " & Row.Item("Frequency") & " " & Status & " " & DeploymentPeriod
                GridEx.RootTable.Columns("AnimalID").ValueList.Add(ValueItem, DisplayItem)
            End If
        Next
        Try
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub

    Private Sub XrefPopulationCaribouGridEX_Enter(sender As Object, e As EventArgs) Handles XrefPopulationCaribouGridEX.Enter
        'refresh the list of frequencies in the animal frequencies GridEX chooser
        LoadCollaredCaribouDropdown(Me.XrefPopulationCaribouGridEX, GetCurrentSightingDate(Me.PopulationEstimateGridEX))
    End Sub

    Private Sub XrefCompCountCaribouGridEX_Enter(sender As Object, e As EventArgs) Handles XrefCompCountCaribouGridEX.Enter
        'save the dataset to avoid datarelation errors
        If Me.WRST_CaribouDataSet.HasChanges = True Then
            SaveDataset()
        End If

        'refresh the list of frequencies in the animal frequencies GridEX chooser
        LoadCollaredCaribouDropdown(Me.XrefCompCountCaribouGridEX, GetCurrentSightingDate(Me.CompositionCountsGridEX))
    End Sub

    Private Sub XrefRadiotrackingCaribouGridEX_Enter(sender As Object, e As EventArgs) Handles XrefRadiotrackingCaribouGridEX.Enter
        'save the dataset to avoid datarelation errors
        If Me.WRST_CaribouDataSet.HasChanges = True Then
            SaveDataset()
        End If

        'refresh the list of frequencies in the animal frequencies GridEX chooser
        LoadCollaredCaribouDropdown(Me.XrefRadiotrackingCaribouGridEX, GetCurrentSightingDate(Me.RadioTrackingGridEX))
    End Sub

    ''' <summary>
    ''' Returns the SightingDate for the current row of GridEX
    ''' </summary>
    ''' <param name="GridEX"></param>
    ''' <returns></returns>
    Private Function GetCurrentSightingDate(GridEX As GridEX) As Date
        'get the caribou group sighting date
        Dim SightingDate As Date = Nothing
        Try
            If Not GridEX.CurrentRow.Cells("SightingDate") Is Nothing Then
                If Not IsDBNull(GridEX.CurrentRow.Cells("SightingDate").Text) Then
                    If IsDate(GridEX.CurrentRow.Cells("SightingDate").Text) Then
                        'SurveyDate is the date the current caribou group was spotted
                        SightingDate = GridEX.CurrentRow.Cells("SightingDate").Text
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
        Return SightingDate
    End Function

    ''' <summary>
    ''' Returns the FrequenciesInGroup for the current row of GridEX
    ''' </summary>
    ''' <param name="GridEX"></param>
    ''' <returns>String</returns>
    Private Function GetCurrentFrequenciesInGroup(GridEX As GridEX) As String
        'get the caribou group frequencies
        Dim Frequencies As String = ""
        Try
            If Not GridEX.CurrentRow.Cells("FrequenciesInGroup") Is Nothing Then
                If Not IsDBNull(GridEX.CurrentRow.Cells("FrequenciesInGroup").Text) Then
                    'Collar frequencies detected in the current animal group
                    Frequencies = GridEX.CurrentRow.Cells("FrequenciesInGroup").Text
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
        Return Frequencies
    End Function

    Private Sub CampaignsGridEX_DeletingRecords(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles CampaignsGridEX.DeletingRecords
        FlightRecordIsCertified()
        'ask the user if they really want to delete the records and all related records
        Dim Result As DialogResult = MessageBox.Show("WARNING: You are about to delete one or more survey campaign records. This will cascade delete all related flights and survey data. This action cannot be undone." & vbNewLine & vbNewLine & " Click Yes to delete, No to cancel.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If Result = DialogResult.No Then
            'user selected No, cancel deleting the records.
            e.Cancel = True
        End If
    End Sub

    Private Sub SurveyFlightsGridEX_DeletingRecords(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SurveyFlightsGridEX.DeletingRecords
        'ask the user if they really want to delete the records and all related records
        Dim Result As DialogResult = MessageBox.Show("WARNING: You are about to delete one or more flight records. This will cascade delete all survey data related to the flight. This action cannot be undone." & vbNewLine & vbNewLine & " Click Yes to delete, No to cancel.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If Result = DialogResult.No Then
            'user selected No, cancel deleting the records.
            e.Cancel = True
        End If
    End Sub

    Private Sub AutoMatchPEFrequenciesToAnimalsToolStripButton_Click(sender As Object, e As EventArgs) Handles AutoMatchPEFrequenciesToAnimalsToolStripButton.Click
        Try
            Dim Explanation As String = "The application will cross reference the Group Frequencies for this flight with GPS collar deployments found in the Animal Movement database.
                Frequency records matching collar deployments will be inserted into the XrefPopulationCaribou table. 
                No existing records will be deleted. No duplicate records will be added.  
                Yes to Continue. No to cancel."
            If MsgBox(Explanation, MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
            AutomatchFrequenciesToAnimalsByFlight(SurveyType.PopulationEstimate, Me.PopulationEstimateGridEX)
        End If
        Catch ex As Exception
        MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub

    Private Sub AutoMatchCCFrequenciesToAnimalsToolStripButton_Click(sender As Object, e As EventArgs) Handles AutoMatchCCFrequenciesToAnimalsToolStripButton.Click
        Try
            Dim Explanation As String = "The application will cross reference the Group Frequencies for this flight with GPS collar deployments found in the Animal Movement database.
                Frequency records matching collar deployments will be inserted into the XrefCompCountCaribou table. 
                No existing records will be deleted. No duplicate records will be added.  
                Yes to Continue. No to cancel."
            If MsgBox(Explanation, MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
                AutomatchFrequenciesToAnimalsByFlight(SurveyType.CompositionCounts, Me.CompositionCountsGridEX)
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub

    Private Sub AutoMatchPEFrequenciesToAnimalsCurrentRecordToolStripButton_Click(sender As Object, e As EventArgs) Handles AutoMatchPEFrequenciesToAnimalsCurrentRecordToolStripButton.Click
        Dim Explanation As String = "The application will cross reference the Group Frequencies for this record with GPS collar deployments found in the Animal Movement database.
            Frequency records matching collar deployments will be inserted into the XrefPopulationCaribou table. 
            No existing records will be deleted. No duplicate records will be added.  
            Yes to Continue. No to cancel."
        If MsgBox(Explanation, MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
            Try
                'this arraylist will hold any frequencies not found in animal movement tool
                Dim MissingFrequenciesArrayList As New ArrayList
                Dim GridEX As GridEX = Me.PopulationEstimateGridEX
                If Not GridEX.CurrentRow Is Nothing Then
                    AutomatchFrequencyToAnimal(SurveyType.CompositionCounts, Me.CompositionCountsGridEX.CurrentRow, MissingFrequenciesArrayList)
                    ShowMissingFrequenciesList(MissingFrequenciesArrayList)
                Else
                    MsgBox("Select a row")
                End If
            Catch ex As Exception
                MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
            End Try
        End If
    End Sub

    Private Sub AutoMatchCCFrequenciesToAnimalsCurrentCCRecordToolStripButton_Click(sender As Object, e As EventArgs) Handles AutoMatchCCFrequenciesToAnimalsCurrentCCRecordToolStripButton.Click
        Dim Explanation As String = "The application will cross reference the Group Frequencies for this record with GPS collar deployments found in the Animal Movement database.
            Frequency records matching collar deployments will be inserted into the XrefPopulationCaribou table. 
            No existing records will be deleted. No duplicate records will be added.  
            Yes to Continue. No to cancel."
        If MsgBox(Explanation, MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
            Try
                'this arraylist will hold any frequencies not found in animal movement tool
                Dim MissingFrequenciesArrayList As New ArrayList
                Dim GridEX As GridEX = Me.CompositionCountsGridEX
                If Not GridEX.CurrentRow Is Nothing Then
                    AutomatchFrequencyToAnimal(SurveyType.CompositionCounts, Me.CompositionCountsGridEX.CurrentRow, MissingFrequenciesArrayList)
                    ShowMissingFrequenciesList(MissingFrequenciesArrayList)
                Else
                    MsgBox("Select a row")
                End If
            Catch ex As Exception
                MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
            End Try
        End If
    End Sub



    ''' <summary>
    ''' Loops through the PopulationEstimateGridEX rows and tries to match Group Frequencies to AnimalIDs in the Animal Movement database
    ''' </summary>
    Private Sub AutomatchFrequenciesToAnimalsByFlight(SurveyType As SurveyType, GridEX As GridEX)
        'this arraylist will hold any frequencies not found in animal movement tool
        Dim MissingFrequenciesArrayList As New ArrayList
        Try
            For Each Row As GridEXRow In GridEX.GetRows
                AutomatchFrequencyToAnimal(SurveyType, Row, MissingFrequenciesArrayList)
            Next
            ShowMissingFrequenciesList(MissingFrequenciesArrayList)
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub

    ''' <summary>
    ''' Helper Sub to show which GPS collar frequencies were not matched to animal groups, most likely because the collar is not registered or deployed in the Animal Movement database.
    ''' </summary>
    ''' <param name="MissingFrequenciesArrayList"></param>
    Private Sub ShowMissingFrequenciesList(MissingFrequenciesArrayList As ArrayList)
        If MissingFrequenciesArrayList.Count > 1 Then
            Dim Warning As String = "WARNING: The following Frequencies were not associated with any deployed collar on the date the caribou group was observed" & vbNewLine
            Dim Message As String = ""
            For Each Freq In MissingFrequenciesArrayList
                Message = Message & Freq & vbNewLine
            Next
            Message = Message & vbNewLine & vbNewLine & "Ctl-C to copy this message to your clipboard."
            MsgBox(Warning & Message, MsgBoxStyle.Exclamation, "WARNING")
        End If
    End Sub


    ''' <summary>
    ''' Auto-matches a GPS collar Frequency to an AnimalID in the Animal Movement database. Helper sub to process GridEX rows from AutomatchFrequenciesToAnimals()
    ''' </summary>
    ''' <param name="Row"></param>
    ''' <param name="MissingFrequenciesArrayList"></param>
    Private Sub AutomatchFrequencyToAnimal(SurveyType As SurveyType, Row As GridEXRow, MissingFrequenciesArrayList As ArrayList)
        Try
            'make sure we have a good table type
            If SurveyType.ToString = "PopulationEstimate" Or SurveyType.ToString = "CompositionCounts" Or SurveyType.ToString = "Radiotracking" Then

                'the purpose of this sub is to match animal groups from the pop est, comp count or radiotracking tables to the appropriate cross reference tables
                'XrefPopulationCaribou, XrefCompCountCaribou, XrefRadioTrackingCaribou
                'we need to know which kind of data we are dealing with and the key columns that will be used to match frequencies with animals in the animal movement database.
                Dim CaribouGroupToAnimalXrefTableName As String = ""
                Dim CaribouGroupPrimaryKeyColumnName As String = "" 'the column name of the cross refere
                Dim XrefTablePrimaryKeyColumnName As String = ""
                Dim FrequenciesColumnName As String = "" 'the frequencies in group column name differs between cross reference tables
                Select Case SurveyType.ToString
                    Case "PopulationEstimate"
                        CaribouGroupToAnimalXrefTableName = "XrefPopulationCaribou"
                        CaribouGroupPrimaryKeyColumnName = "EID"
                        XrefTablePrimaryKeyColumnName = "PCID"
                        FrequenciesColumnName = "FrequenciesInGroup"
                    Case "CompositionCounts"
                        CaribouGroupToAnimalXrefTableName = "XrefCompCountCaribou"
                        CaribouGroupPrimaryKeyColumnName = "CCID"
                        XrefTablePrimaryKeyColumnName = "CCCID"
                        FrequenciesColumnName = "Frequencies"
                    Case "Radiotracking"
                        CaribouGroupToAnimalXrefTableName = "XrefRadioTrackingCaribou"
                        CaribouGroupPrimaryKeyColumnName = "RTID"
                        XrefTablePrimaryKeyColumnName = "RTCID"
                        FrequenciesColumnName = "Frequency"
                End Select

                'extract the frequencies from the row's FrequenciesInGroup column and try to parse it, search for the correct animalid and insert it into the cross reference table
                If Not Row Is Nothing Then
                    If Not Row.Cells(FrequenciesColumnName) Is Nothing And Not Row.Cells("SightingDate") Is Nothing And Not Row.Cells(CaribouGroupPrimaryKeyColumnName) Is Nothing Then
                        If Not IsDBNull(Row.Cells(FrequenciesColumnName).Value) And Not IsDBNull(Row.Cells("SightingDate").Value) And Not IsDBNull(Row.Cells(CaribouGroupPrimaryKeyColumnName).Value) Then

                            'get caribou group row values into variables
                            Dim FrequenciesInGroup As String = Row.Cells(FrequenciesColumnName).Value
                            Dim SightingDate As String = Row.Cells("SightingDate").Value

                            'parse the comma separated frequencies so we can deal with them individually
                            For Each Frequency In FrequenciesInGroup.Split(",")
                                Frequency = Frequency.Trim
                                If IsNumeric(Frequency.Trim) = True Then
                                    Dim AnimalID As String = GetAnimalIDFromFrequencyAndObservationDate(Frequency, SightingDate)
                                    If AnimalID.Length = 0 Then
                                        'the collar was not found in the AM database, add to the list so we can inform the user of data quality issues.
                                        MissingFrequenciesArrayList.Add(Frequency & "," & SightingDate)
                                        AnimalID = "FRQ: " & Frequency
                                    End If

                                    'add the animalid to the XrefDataTable
                                    Dim XrefDataTable As DataTable = Me.WRST_CaribouDataSet.Tables(CaribouGroupToAnimalXrefTableName)
                                    'see if the AnimalID already exists
                                    Dim Filter As String = CaribouGroupPrimaryKeyColumnName & " = '" & Row.Cells(CaribouGroupPrimaryKeyColumnName).Value & "' And AnimalID='" & AnimalID & "'"
                                    Dim ExistenceCheck As DataRow() = XrefDataTable.Select(Filter)
                                    If ExistenceCheck.Count = 0 Then
                                        'the animalid does not exist for the animal group
                                        Dim XrefDataRow As DataRow = XrefDataTable.NewRow
                                        With XrefDataRow
                                            .Item("AnimalID") = AnimalID
                                            .Item(CaribouGroupPrimaryKeyColumnName) = Row.Cells(CaribouGroupPrimaryKeyColumnName).Value
                                            .Item("RecordInsertedBy") = My.User.Name
                                            .Item("RecordInsertedDate") = Now
                                            .Item("ProjectID") = "WRST_Caribou"
                                            .Item(XrefTablePrimaryKeyColumnName) = Guid.NewGuid.ToString
                                        End With
                                        XrefDataTable.Rows.Add(XrefDataRow)
                                        XrefPopulationCaribouBindingSource.EndEdit()
                                    End If
                                End If
                            Next
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub

    Private Sub PopulationEstimateGridEX_Validated(sender As Object, e As EventArgs) Handles PopulationEstimateGridEX.Validated
        'save the dataset
        SaveDataset()
    End Sub

    Private Sub CompositionCountsGridEX_Validated(sender As Object, e As EventArgs) Handles CompositionCountsGridEX.Validated
        'save the dataset
        SaveDataset()
    End Sub

    Private Sub RadioTrackingGridEX_Validated(sender As Object, e As EventArgs) Handles RadioTrackingGridEX.Validated
        'save the dataset
        SaveDataset()
    End Sub

    ''' <summary>
    ''' Returns True if the Campaign has associated Flights that have been certified.
    ''' </summary>
    ''' <returns>Boolean</returns>
    Private Function CampaignHasCertifiedRecords() As Boolean
        'find out if related flights are certified or not
        Dim CertifiedFlightsExist As Boolean = False
        Try
            Dim CurrentCampaignID As String = GetCurrentGridEXCellValue(Me.CampaignsGridEX, "CampaignID")
            If CurrentCampaignID.Trim.Length > 0 Then
                Dim Filter As String = "CampaignID = '" & CurrentCampaignID & "' And CertificationLevel = 'Certified'"
                Dim CertifiedFlightsDataRow As DataRow() = WRST_CaribouDataSet.Tables("SurveyFlights").Select(Filter)
                If CertifiedFlightsDataRow.Count > 0 Then
                    CertifiedFlightsExist = True
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
        Return CertifiedFlightsExist
    End Function

    Private Sub ExecuteStoredProcedure(ProcedureName As String)
        Try
            Dim MySqlConnection As New SqlConnection(My.Settings.WRST_CaribouConnectionString)
            MySqlConnection.Open()

            Dim MySqlCommand As New SqlCommand(ProcedureName, MySqlConnection)
            MySqlCommand.CommandType = CommandType.StoredProcedure
            MySqlCommand.ExecuteNonQuery()
            MySqlCommand.Dispose()
            MySqlConnection.Close()
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub

    Private Sub ResultsDataGridView_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles ResultsDataGridView.DataError
        Dim Row As Integer = e.RowIndex
        Dim Col As Integer = e.ColumnIndex
        Dim OffendingData As String = ""
        Dim Grid As DataGridView = Me.ResultsDataGridView
        If Not Grid Is Nothing Then
            If Not Grid.Rows(Row) Is Nothing Then
                If Not Grid.Rows(Row).Cells(Col) Is Nothing Then
                    If Not IsDBNull(Grid.Rows(Row).Cells(Col).Value) Then
                        OffendingData = "Row: " & Row & " Column: " & Grid.Columns(Col).Name & " Value: " & Grid.Rows(Row).Cells(Col).Value.ToString
                    End If
                End If
            End If
        End If
        MsgBox(e.Exception.Message & " " & OffendingData)
    End Sub

    Private Sub AnimalsDataGridView_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles AnimalsDataGridView.DataError
        Dim Row As Integer = e.RowIndex
        Dim Col As Integer = e.ColumnIndex
        Dim OffendingData As String = ""
        Dim Grid As DataGridView = Me.AnimalsDataGridView
        If Not Grid Is Nothing Then
            If Not Grid.Rows(Row) Is Nothing Then
                If Not Grid.Rows(Row).Cells(Col) Is Nothing Then
                    If Not IsDBNull(Grid.Rows(Row).Cells(Col).Value) Then
                        OffendingData = "Row: " & Row & " Column: " & Grid.Columns(Col).Name & " Value: " & Grid.Rows(Row).Cells(Col).Value.ToString
                    End If
                End If
            End If
        End If
        MsgBox(e.Exception.Message & " " & OffendingData)
    End Sub

    Private Sub SurveyResultsDataGridView_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles SurveyResultsDataGridView.DataError
        Dim Row As Integer = e.RowIndex
        Dim Col As Integer = e.ColumnIndex
        Dim OffendingData As String = ""
        Dim Grid As DataGridView = Me.SurveyResultsDataGridView
        If Not Grid Is Nothing Then
            If Not Grid.Rows(Row) Is Nothing Then
                If Not Grid.Rows(Row).Cells(Col) Is Nothing Then
                    If Not IsDBNull(Grid.Rows(Row).Cells(Col).Value) Then
                        OffendingData = "Row: " & Row & " Column: " & Grid.Columns(Col).Name & " Value: " & Grid.Rows(Row).Cells(Col).Value.ToString
                    End If
                End If
            End If
        End If
        MsgBox(e.Exception.Message & " " & OffendingData)
    End Sub
End Class

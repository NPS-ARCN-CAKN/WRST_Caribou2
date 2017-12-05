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
                    Me.TableAdapterManager.UpdateAll(Me.WRST_CaribouDataSet)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'WRST_CaribouDataSet.xrefRadiotrackingCaribou' table. You can move, or remove it, as needed.
        Me.CampaignsTableAdapter.Fill(Me.WRST_CaribouDataSet.Campaigns)
        Me.SurveyFlightsTableAdapter.Fill(Me.WRST_CaribouDataSet.SurveyFlights)
        Me.XrefRadiotrackingCaribouTableAdapter.Fill(Me.WRST_CaribouDataSet.xrefRadiotrackingCaribou)
        Me.XrefPopulationCaribouTableAdapter.Fill(Me.WRST_CaribouDataSet.xrefPopulationCaribou)
        Me.XrefCompCountCaribouTableAdapter.Fill(Me.WRST_CaribouDataSet.xrefCompCountCaribou)
        Me.CapturesTableAdapter.Fill(Me.WRST_CaribouDataSet.Captures)
        Me.CaribouTableAdapter.Fill(Me.WRST_CaribouDataSet.Caribou)

        'load the dataset
        Me.RadioTrackingTableAdapter.Fill(Me.WRST_CaribouDataSet.RadioTracking)
        Me.PopulationEstimateTableAdapter.Fill(Me.WRST_CaribouDataSet.PopulationEstimate)
        Me.CompositionCountsTableAdapter.Fill(Me.WRST_CaribouDataSet.CompositionCounts)


        'set up the GridEXs
        Dim Editable As InheritableBoolean = InheritableBoolean.True
        SetUpGridEX(Me.CampaignsGridEX, Editable)
        SetUpGridEX(Me.SurveyFlightsGridEX, Editable)
        SetUpGridEX(Me.CompositionCountsGridEX, Editable)
        SetUpGridEX(Me.PopulationEstimateGridEX, Editable)
        SetUpGridEX(Me.RadioTrackingGridEX, Editable)


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

        'get the name of the survey flight to put it into the data header
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

        SetUpSurveysGridEX()

        'Set up default values
        Dim Grid As GridEX = Me.SurveyFlightsGridEX
        'Grid.RootTable.Columns("RecordInsertedDate").DefaultValue = Now
        'Grid.RootTable.Columns("RecordInsertedBy").DefaultValue = My.User.Name
        Dim NewGuidString As String = Guid.NewGuid.ToString
        Grid.RootTable.Columns("FlightID").DefaultValue = NewGuidString
        Grid.RootTable.Columns("SOPNumber").DefaultValue = 0
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

        SetUpCampaignsGridEX()

        'set the survey type tab control to the current survey type
        Dim CurrentSurveyType As String = ""
        If Not Me.CampaignsGridEX.CurrentRow.Cells("SurveyType") Is Nothing And Not IsDBNull(Me.CampaignsGridEX.CurrentRow.Cells("SurveyType").Value) Then
            CurrentSurveyType = Me.CampaignsGridEX.CurrentRow.Cells("SurveyType").Value
            Select Case CurrentSurveyType
                Case "Composition"
                    Me.SurveyDataTabControl.SelectedTab = Me.CompositionCountTabPage
                Case "Population"
                    Me.SurveyDataTabControl.SelectedTab = Me.PopulationTabPage
                Case "Radiotracking"
                    Me.SurveyDataTabControl.SelectedTab = Me.RadiotrackingTabPage
                Case Else
                    Me.SurveyDataTabControl.SelectedTab = Me.CompositionCountTabPage
            End Select
        End If
    End Sub

    Private Sub ToggleGridEXTableCardView(GridEX As GridEX)
        If GridEX.View = View.TableView Then
            GridEX.View = View.CardView
        Else
            GridEX.View = View.TableView
        End If
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
                    Dim WaypointsImportFile As String = GetFile()

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
                                Dim GroupNumber As Integer = 1


                                'loop through the records in the import file, extract values
                                For Each Row As DataRow In WaypointsImportDataTable.Rows
                                    'if we don't have a location then we have nothing for the row
                                    If Not IsDBNull(Row.Item("IDENT")) And Not IsDBNull(Row.Item("LAT")) And Not IsDBNull(Row.Item("LONG")) Then
                                        Dim Ident As String = ""
                                        Dim Latitude As Double = 0
                                        Dim Longitude As Double = 0
                                        Dim SightingDate As String

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
                    Dim WaypointsImportFile As String = GetFile()

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
                                Dim GroupNumber As Integer = 1


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

    Private Sub ImportWaypointsToolStripButton_Click(sender As Object, e As EventArgs) Handles ImportPopulationWaypointsToolStripButton.Click
        ImportPopulationSurveyWaypoints()
    End Sub

    Private Function GetFile() As String
        Dim ExcelFile As String = ""
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
        Return ExcelFile
    End Function

    Private Sub ImportCompCountWaypointsToolStripButton_Click(sender As Object, e As EventArgs) Handles ImportCompCountWaypointsToolStripButton.Click
        ImportCompositionCountDNRGarminWaypoints()
    End Sub



End Class

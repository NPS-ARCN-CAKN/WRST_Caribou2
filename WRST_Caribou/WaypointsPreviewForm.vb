

Public Class WaypointsPreviewForm
    ''' <summary>
    ''' Waypoints are ready to import when True. Boolean.
    ''' </summary>
    Private _ReadyToImport As Boolean
    Public Property ReadyToImport() As Boolean
        Get
            Return _ReadyToImport
        End Get
        Set(ByVal value As Boolean)
            _ReadyToImport = value
        End Set
    End Property
    ''' <summary>
    ''' Creates a new WaypointsPreviewForm.
    ''' </summary>
    ''' <param name="WaypointsDataTable"></param>
    Public Sub New(WaypointsDataTable As DataTable)
        'initalize the controls
        InitializeComponent()



        'set up the form
        Try
            'form should open with readytoimport false and the import button disabled in order to allow us to ensure the data is good before allowing export.
            _ReadyToImport = False

            'disable the form
            EnableForm(False)

            'set the datatable
            _WaypointsDataTable = WaypointsDataTable

            'set the grid's datasource
            If Not _WaypointsDataTable Is Nothing Then
                'set up the binding source and navigator
                Me.WaypointsBindingSource.DataSource = _WaypointsDataTable
                Me.WaypointsBindingNavigator.BindingSource = Me.WaypointsBindingSource
                Me.PreviewDataGridView.DataSource = Me.WaypointsBindingSource
            End If

            'validate the data
            ValidateData()
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try

    End Sub

    Private _WaypointsDataTable As DataTable
    ''' <summary>
    ''' A DataTable of DNRGarmin waypoints
    ''' </summary>
    ''' <returns>DataTable</returns>
    Public Property WaypointsDataTable As DataTable
        Get
            Return _WaypointsDataTable
        End Get
        Set(ByVal value As DataTable)
            _WaypointsDataTable = value
        End Set
    End Property

    Private Sub SearchAreaComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SearchAreaComboBox.SelectedIndexChanged
        'this checkbox allows the user to change the SearchArea field based on the value of the selected item in the SearchAreaCombobox
        'loop through the waypoint rows and set the searcharea column to the combobox value
        Try
            If _WaypointsDataTable.Rows.Count > 0 Then
                For Each row As DataRow In Me._WaypointsDataTable.Rows
                    row.Item("SearchArea") = Me.SearchAreaComboBox.Text
                Next
                ValidateData()
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try

    End Sub


    ''' <summary>
    ''' This ValidateData function performs checks on the waypoints data and if all tests are passed enables the form, allowing waypoints to be imported.
    ''' </summary>
    Public Sub ValidateData()
        Try
            'make sure we have records
            If _WaypointsDataTable.Rows.Count > 0 Then
                'Test 1: make sure the search areas are all filled in
                Dim SearchAreasAreFilledIn As Boolean = True
                For Each Row As DataRow In Me._WaypointsDataTable.Rows
                    If IsDBNull(Row.Item("SearchArea")) Or Row.Item("SearchArea").ToString.Length = 0 Then
                        SearchAreasAreFilledIn = False
                    End If
                Next

                'if it passes the tests, then enable the form
                EnableForm(SearchAreasAreFilledIn)
            Else
                'disable the form
                EnableForm(False)
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub

    ''' <summary>
    ''' Enables the form, allowing waypoints to be imported. 
    ''' </summary>
    ''' <param name="Enable">Boolean. True enables the form. False disables the form.</param>
    Private Sub EnableForm(Enable As Boolean)
        Me.ImportWaypointsButton.Enabled = Enable
        Me.ReadyToImport = Enable
    End Sub

    Private Sub WaypointsPreviewForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'this line loads the csv list of search areas from my.settings into a datatable
        Dim SearchAreasDataTable As DataTable = GetSearchAreasDataTable()

        'load in the searcharea items into the combobox
        For Each Row As DataRow In SearchAreasDataTable.Rows
            Me.SearchAreaComboBox.Items.Add(Row.Item("SearchArea"))
        Next
    End Sub

    Private Sub ImportWaypointsButton_Click(sender As Object, e As EventArgs) Handles ImportWaypointsButton.Click
        Me.Close()
    End Sub
End Class
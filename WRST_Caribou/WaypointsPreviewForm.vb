

Public Class WaypointsPreviewForm

    Public Sub New(WaypointsDataTable As DataTable)
        'initalize the controls
        InitializeComponent()

        'set the datatable
        _WaypointsDataTable = WaypointsDataTable



        'set the grid's datasource
        If Not _WaypointsDataTable Is Nothing Then

            'set up the binding source and navigator
            Me.WaypointsBindingSource.DataSource = _WaypointsDataTable
            Me.WaypointsBindingNavigator.BindingSource = Me.WaypointsBindingSource
            Me.PreviewDataGridView.DataSource = Me.WaypointsBindingSource
        End If

        'default to false
        Me.CorrectCheckBox.Checked = False
    End Sub

    Private _WaypointsDataTable As DataTable
    Public Property WaypointsDataTable As DataTable
        Get
            Return _WaypointsDataTable
        End Get
        Set(ByVal value As DataTable)
            _WaypointsDataTable = value
        End Set
    End Property

    Private Sub CorrectCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles CorrectCheckBox.CheckedChanged
        Me.Close()
    End Sub

    Private Sub SearchAreaComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SearchAreaComboBox.SelectedIndexChanged
        For Each row As DataRow In Me._WaypointsDataTable.Rows
            row.Item("SearchArea") = Me.SearchAreaComboBox.Text
        Next
    End Sub

    Private Sub WaypointsPreviewForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'this line loads the csv list of search areas from my.settings into a datatable
        Dim SearchAreasDataTable As DataTable = GetSearchAreasDataTable()

        'load in the searcharea items into the combobox
        For Each Row As DataRow In SearchAreasDataTable.Rows
            Me.SearchAreaComboBox.Items.Add(Row.Item("SearchArea"))
        Next
    End Sub


End Class
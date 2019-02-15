Public Class FrequencyToAnimalMatcherForm

    'Private _FrequenciesArrayList As ArrayList
    'Public Property FrequenciesList() As ArrayList
    '    Get
    '        Return _FrequenciesArrayList
    '    End Get
    '    Set(ByVal value As ArrayList)
    '        _FrequenciesArrayList = value
    '    End Set
    'End Property

    'this is the datatable of collars that were deployed as of AsOfDate
    Dim CurrentCollarsDataTable As DataTable

    'matcher datatable
    Dim FrequenciesDataTable As New DataTable

    Public Sub New(FrequenciesList As ArrayList, AsOfDate As Date)
        InitializeComponent()

        MsgBox("This form is still Not working")

        'provide context
        Me.HeaderToolStripLabel.Text = "Collars that were deployed on " & AsOfDate

        'add columns to the frequencies datatable
        FrequenciesDataTable.Columns.Add("Frequency", GetType(String))
        FrequenciesDataTable.Columns.Add("AnimalID", GetType(String))

        'load the current frequencies into the frequenciesdatatable
        For Each Frequency As String In FrequenciesList
            Dim FrequencyDataRow As DataRow = FrequenciesDataTable.NewRow
            FrequencyDataRow.Item(0) = Frequency
            FrequenciesDataTable.Rows.Add(FrequencyDataRow)


        Next
        Me.GroupDataGridView.DataSource = FrequenciesDataTable


        CurrentCollarsDataTable = GetCurrentCollarDeploymentsDataTable(AsOfDate)
        Me.CurrentCollarsDataGridView.DataSource = CurrentCollarsDataTable

    End Sub


    Private Function GetDGVValue(DGV As DataGridView, ColumnName As String) As String
        Dim Value As String = ""
        If Not DGV.CurrentRow Is Nothing Then
            If Not DGV.CurrentRow.Cells(ColumnName) Is Nothing Then
                If Not IsDBNull(DGV.CurrentRow.Cells(ColumnName).Value) Then
                    Value = Me.CurrentCollarsDataGridView.CurrentRow.Cells(ColumnName).Value
                End If
            End If
        End If
        Return Value
    End Function


    Private Sub CurrentCollarsDataGridView_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles CurrentCollarsDataGridView.CellDoubleClick
        'MsgBox("doubleclick" & GetAnimalID())

    End Sub

    Private Sub CurrentCollarsDataGridView_SelectionChanged(sender As Object, e As EventArgs) Handles CurrentCollarsDataGridView.SelectionChanged
        Dim CurrentFrequency As String = GetDGVValue(Me.GroupDataGridView, "Frequency")
        Dim CurrentAnimalID As String = GetDGVValue(Me.CurrentCollarsDataGridView, "AnimalID")
        'Debug.Print(CurrentFrequency & " " & CurrentAnimalID)
        Me.FrequenciesDataTable.Rows(0).Item("AnimalID") = CurrentAnimalID
    End Sub


End Class
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



        'provide context
        Me.HeaderToolStripLabel.Text = "Collars that were deployed on " & AsOfDate

        'add columns to the frequencies datatable
        Dim FrequencyDataColumn As New DataColumn("Frequency", GetType(String))
        FrequencyDataColumn.ReadOnly = True
        FrequenciesDataTable.Columns.Add(FrequencyDataColumn)
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

        AutoMatch()

    End Sub

    Private Sub Match(Frequency As String, AnimalID As String)
        'find the  index of the frequency in the group datatable
        For Each Row As DataRow In FrequenciesDataTable.Rows
            If Row.Item("Frequency") = Frequency Then
                Row.Item("AnimalID") = AnimalID
            End If
        Next
    End Sub


    Private Function GetCurrentDGVValue(DGV As DataGridView, ColumnName As String) As String
        Dim Value As String = ""
        Try
            If Not DGV.CurrentRow Is Nothing Then
                If Not DGV.CurrentRow.Cells(ColumnName) Is Nothing Then
                    If Not IsDBNull(DGV.CurrentRow.Cells(ColumnName).Value) Then
                        Value = DGV.CurrentRow.Cells(ColumnName).Value
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
        Return Value
    End Function



    Private Sub GroupDataGridView_SelectionChanged(sender As Object, e As EventArgs) Handles GroupDataGridView.SelectionChanged
        'loop through the frequencies datatable and look for the frequency
        Dim Frequency As String = GetCurrentDGVValue(Me.GroupDataGridView, "Frequency")
        Match(Frequency, GetCurrentDGVValue(Me.GroupDataGridView, "AnimalID"))

        HighlightMatchedFrequencyRows(Frequency)
    End Sub

    Private Sub HighlightMatchedFrequencyRows(Frequency As String)
        'format matching rows between datagridviews
        For Each Row As DataGridViewRow In Me.CurrentCollarsDataGridView.Rows
            If Not Row Is Nothing Then
                If Not Row.Cells("Frequency") Is Nothing Then
                    If Not IsDBNull(Row.Cells("Frequency").Value) Then
                        If Row.Cells("Frequency").Value = Frequency Then
                            Row.DefaultCellStyle.BackColor = Color.LightGreen
                            Me.CurrentCollarsDataGridView.CurrentCell = Row.Cells("Frequency")
                        Else
                            Row.DefaultCellStyle.BackColor = Color.White
                        End If
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub AutoMatch()
        For Each Row As DataRow In FrequenciesDataTable.Rows
            Dim Frequency As String = Row.Item("Frequency")
            For Each CollarRow As DataRow In CurrentCollarsDataTable.Rows
                If Row.Item("Frequency") = CollarRow.Item("Frequency") Then
                    Match(Frequency, CollarRow.Item("AnimalID"))
                End If
            Next
        Next
    End Sub

    Private Sub CurrentCollarsDataGridView_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles CurrentCollarsDataGridView.CellDoubleClick
        Dim CurrentFrequency As String = GetCurrentDGVValue(Me.GroupDataGridView, "Frequency")
        Dim CurrentAnimalID As String = GetCurrentDGVValue(Me.CurrentCollarsDataGridView, "AnimalID")

        Match(CurrentFrequency, CurrentAnimalID)
    End Sub

    Private Sub FrequencyToAnimalMatcherForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'highlight frequencies
        Dim CurrentFrequency As String = GetCurrentDGVValue(Me.GroupDataGridView, "Frequency")
        HighlightMatchedFrequencyRows(CurrentFrequency)
    End Sub
End Class
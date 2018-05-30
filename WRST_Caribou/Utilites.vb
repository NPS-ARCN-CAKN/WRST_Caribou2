Imports System.IO
Module Utilites
    ''' <summary>
    ''' Returns the list of SearchAreas in My.Settings.SearchAreas as a DataTable
    ''' </summary>
    ''' <returns>DataTable of search areas</returns>
    Public Function GetSearchAreasDataTable() As DataTable
        ' Create new DataTable instance.
        Dim MyDataTable As New DataTable("SearchAreas")

        ' Create four typed columns in the DataTable.
        With MyDataTable
            .Columns.Add("SearchArea", GetType(String))
        End With

        Try
            ' Split string based on spaces and add them as rows to the datatable
            Dim SearchAreas As String() = My.Settings.SearchAreas.Split(",")
            For Each SearchArea In SearchAreas
                MyDataTable.Rows.Add(SearchArea)
            Next
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
        Return MyDataTable
    End Function

    ''' <summary>
    ''' Converts a tab delimited text file to a DataTable
    ''' </summary>
    ''' <param name="DelimitedTextFileInfo">Tab delimited text file. FileInfo.</param>
    ''' <returns>DataTable</returns>
    Public Function GetDataTableFromDelimitedTextFile(DelimitedTextFileInfo As FileInfo, Delimiter As String) As DataTable
        Dim TDVDataTable As New DataTable(DelimitedTextFileInfo.Name)
        Try
            Dim MyTextFileParser As New FileIO.TextFieldParser(DelimitedTextFileInfo.FullName)
            MyTextFileParser.Delimiters = New String() {Delimiter}
            TDVDataTable.Columns.AddRange(Array.ConvertAll(MyTextFileParser.ReadFields, Function(s) New DataColumn With {.Caption = s, .ColumnName = s}))
            Do While Not MyTextFileParser.EndOfData
                TDVDataTable.Rows.Add(MyTextFileParser.ReadFields)
            Loop
            MyTextFileParser.Close()
        Catch ex As Exception
            MsgBox(ex.Message & "  " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
        Return TDVDataTable
    End Function
End Module

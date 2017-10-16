Imports System.Data.OleDb
Imports System.IO

Module ImportWaypoints
    Public Function WaypointFileToDataTable(WaypointFile As String) As DataTable
        Dim InputDataTable As New DataTable()
        If My.Computer.FileSystem.FileExists(WaypointFile) Then
            Dim InputFileInfo As New FileInfo(WaypointFile)

            'determine file type
            If InputFileInfo.Extension = ".xlsx" Then

                'Excel file
                InputDataTable.TableName = InputFileInfo.Name
                Try
                    'load the file into the datatable
                    Dim Workbook As String = InputFileInfo.FullName 'the full path an name of the excel sheet
                    Dim Worksheet As String = "Waypoints" ' InputFileInfo.Name 'the name of the excel sheet
                    Dim Sql As String = "SELECT * FROM [" & Worksheet & "$]" 'assumes the excel tab is named the same as the workbook
                    Dim MyConnectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Workbook & ";Extended Properties='Excel 12.0 Xml;HDR=YES';"
                    Dim MyConnection As New OleDbConnection(MyConnectionString)
                    MyConnection.Open()
                    Dim MyCommand As New OleDbCommand(Sql, MyConnection)
                    Dim MyDataAdapter As New OleDbDataAdapter(MyCommand)
                    MyDataAdapter.Fill(InputDataTable)
                    MyConnection.Close()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try



            ElseIf InputFileInfo.Extension = ".csv" Then
                'CSV
                Dim lines = IO.File.ReadAllLines(InputFileInfo.FullName)
                'Dim tbl = New DataTable
                Dim colCount = lines.First.Split(","c).Length
                For i As Int32 = 1 To colCount
                    InputDataTable.Columns.Add(New DataColumn("Column_" & i, GetType(Int32)))
                Next
                For Each line In lines
                    Dim objFields = From field In line.Split(","c)
                                    Select CType(Int32.Parse(field), Object)
                    Dim newRow = InputDataTable.Rows.Add()
                    newRow.ItemArray = objFields.ToArray()
                Next

            End If
        End If
        Return InputDataTable
    End Function
End Module

Imports System.Data.OleDb
Imports System.IO

Module ImportWaypoints
    Public Function WaypointFileToDataTable(WaypointFile As String) As DataTable
        Dim InputDataTable As New DataTable()
        InputDataTable.Clear()

        If My.Computer.FileSystem.FileExists(WaypointFile) Then
            Dim InputFileInfo As New FileInfo(WaypointFile)
            InputDataTable.TableName = InputFileInfo.Name

            'determine file type
            If InputFileInfo.Extension = ".xlsx" Or InputFileInfo.Extension = ".xls" Then
                'Excel file
                Try
                    'load the file into the datatable
                    Dim Workbook As String = InputFileInfo.FullName 'the full path an name of the excel sheet
                    Dim Worksheet As String = InputFileInfo.Name.Replace(".xlsx", "").Replace(".xls", "") ' InputFileInfo.Name 'the name of the excel sheet
                    Dim Sql As String = "SELECT * FROM [" & Worksheet & "$]" 'assumes the excel tab is named the same as the workbook
                    Dim MyConnectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Workbook & ";Extended Properties='Excel 12.0 Xml;HDR=YES';"
                    Dim MyConnection As New OleDbConnection(MyConnectionString)
                    MyConnection.Open()
                    Dim MyCommand As New OleDbCommand(Sql, MyConnection)
                    Dim MyDataAdapter As New OleDbDataAdapter(MyCommand)
                    MyDataAdapter.Fill(InputDataTable)
                    MyConnection.Close()
                Catch ex As Exception
                    MsgBox("Could not import waypoints from Excel file. " & ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name)
                End Try
            ElseIf InputFileInfo.Extension = ".dbf" Then
                'dbf file
                Try
                    'we'll need the dbf filename and path separately so isolate them here
                    'Dim DBFFileInfo As New System.IO.FileInfo(InputFileInfo)
                    Dim DBFDirectory As String = InputFileInfo.DirectoryName 'the dbf directory

                    'NOTE: the dbf query won't work on long filenames so copy the dbf to a temporary file named zzzzzzzz.dbf and work with that
                    Dim TemporaryDBFFilename As String = "zzzzzzzz.dbf"
                    Dim TemporaryDBFFileFullName As String = DBFDirectory & "\" & TemporaryDBFFilename
                    My.Computer.FileSystem.CopyFile(InputFileInfo.FullName, TemporaryDBFFileFullName, True)

                    'connect to the temporary dbf and open the contents into a datareader
                    Dim MyConnectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & DBFDirectory & ";Extended Properties=dBASE IV;User ID=Admin;Password=;"
                    Dim MyConnection As New OleDbConnection(MyConnectionString)
                    MyConnection.Open()
                    Dim Sql As String = "SELECT * FROM [" & TemporaryDBFFilename.Replace(".dbf", "") & "]"
                    Dim MyCommand As New OleDbCommand(Sql, MyConnection)
                    Dim MyDataReader As OleDbDataReader = MyCommand.ExecuteReader()

                    'load the data from the datareader into the datatable
                    InputDataTable.Load(MyDataReader)

                    'close the connection
                    MyConnection.Close()

                    'delete the temporary dbf file
                    My.Computer.FileSystem.DeleteFile(TemporaryDBFFileFullName)
                Catch ex As Exception
                    MsgBox("Could not import waypoints from DBF file. " & ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name)
                End Try
            ElseIf InputFileInfo.Extension = ".csv" Or InputFileInfo.Extension = ".txt" Then
                Try
                    Dim ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & InputFileInfo.DirectoryName & ";Extended Properties=""text;HDR=Yes;FMT=Delimited"";"
                    Using Adp As New OleDbDataAdapter("select * from [" & InputFileInfo.Name & "]", ConnectionString)
                        Adp.Fill(InputDataTable)
                    End Using
                Catch ex As Exception
                    MsgBox("Could not import waypoints from CSV file. " & ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name)
                End Try
            End If
        End If
        Return InputDataTable
    End Function
End Module

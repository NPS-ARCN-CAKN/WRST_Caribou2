Imports System.IO
Imports System.Data.SqlClient
Imports System.Data.OleDb

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


    ''' <summary>
    ''' Runs the query in Sql against a database using ConnectionString and returns the results as a DataTable
    ''' </summary>
    ''' <param name="ConnectionString"></param>
    ''' <param name="Sql"></param>
    ''' <returns>DataTable</returns>
    Public Function GetDataTable(ConnectionString As String, Sql As String) As DataTable
        'the DataTable to return
        Dim MyDataTable As New DataTable

        Try
            'make a SqlConnection using the supplied ConnectionString 
            Dim MySqlConnection As New SqlConnection(ConnectionString)
            Using MySqlConnection
                'make a query using the supplied Sql
                Dim MySqlCommand As SqlCommand = New SqlCommand(Sql, MySqlConnection)

                'open the connection
                MySqlConnection.Open()

                'create a DataReader and execute the SqlCommand
                Dim MyDataReader As SqlDataReader = MySqlCommand.ExecuteReader()

                'load the reader into the datatable
                MyDataTable.Load(MyDataReader)

                'clean up
                MyDataReader.Close()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try

        'return the datatable
        Return MyDataTable
    End Function

#Region "Excel"

    ''' <summary>
    ''' Converts an Excel workbook into a DataSet. All worksheets become available as DataTables
    ''' </summary>
    ''' <param name="ExcelConnectionString">ExcelConnectionString</param>
    ''' <returns>Dataset</returns>
    Public Function GetDatasetFromExcelWorkbook(ExcelConnectionString As String) As DataSet
        Dim ExcelDataset As New DataSet()
        Try
            'Dim  = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & ExcelFileInfo.FullName & ";Extended Properties='Excel 12.0 Xml;HDR=YES';"
            Dim WorksheetsDataTable As DataTable = GetExcelWorksheets(ExcelConnectionString)
            For Each WorksheetRow As DataRow In WorksheetsDataTable.Rows
                Dim WorksheetName As String = WorksheetRow.Item("TABLE_NAME")
                Dim ExcelDataTable As New DataTable(WorksheetName)
                ExcelDataTable.TableName = WorksheetName
                Dim Sql As String = "SELECT * FROM [" & WorksheetName & "]"
                Dim MyConnection As New OleDbConnection(ExcelConnectionString)
                MyConnection.Open()
                Dim MyCommand As New OleDbCommand(Sql, MyConnection)
                Dim MyDataAdapter As New OleDbDataAdapter(MyCommand)
                MyDataAdapter.Fill(ExcelDataTable)
                ExcelDataset.Tables.Add(ExcelDataTable)
                MyConnection.Close()
            Next
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
        Return ExcelDataset
    End Function

    ''' <summary>
    ''' Returns a DataTable of worksheets in the submitted Excel workbook
    ''' </summary>
    ''' <param name="ExcelConnectionString"></param>
    ''' <returns>DataTable</returns>
    Public Function GetExcelWorksheets(ExcelConnectionString As String) As DataTable
        Dim ExcelWorksheetsDataTable As New DataTable
        Try
            Dim MyConnection As New OleDbConnection(ExcelConnectionString)
            MyConnection.Open()
            ExcelWorksheetsDataTable = MyConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
            MyConnection.Close()
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
        Return ExcelWorksheetsDataTable
    End Function
#End Region


    Public Function GetFile(Title As String, Filter As String) As String
        'allow user to open an openfiledialog to select a csv file
        Dim File As String = ""
        Dim OFD As New OpenFileDialog
        With OFD
            .AddExtension = True
            .CheckFileExists = True
            .Filter = Filter
            .Multiselect = False
            .Title = Title
        End With

        'show the ofd and get the filename and path
        If OFD.ShowDialog = DialogResult.OK Then
            File = OFD.FileName
        End If
        Return File
    End Function


End Module

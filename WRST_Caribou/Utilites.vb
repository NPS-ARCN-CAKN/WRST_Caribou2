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
    ''' Converts a DataTable to a string of delimited values such as CSV
    ''' </summary>
    ''' <param name="DataTable">DataTable to convert. DataTable</param>
    ''' <param name="Delimiter">Values separator</param>
    ''' <returns>String</returns>
    ''' <remarks></remarks>
    Public Function DataTableToCSV(DataTable As DataTable, Delimiter As String) As String
        Dim CSV As String = ""
        Try
            'output the headers
            For Each Column As DataColumn In DataTable.Columns
                CSV = CSV & Column.ColumnName & Delimiter
            Next
            CSV = CSV.Substring(0, CSV.Trim.Length - 1) & vbNewLine

            'output the rows
            For Each Row As DataRow In DataTable.Rows
                For Each Column As DataColumn In DataTable.Columns
                    CSV = CSV & Row.Item(Column.ColumnName) & Delimiter
                Next
                CSV = CSV.Substring(0, CSV.Trim.Length - 1) & vbNewLine
            Next
        Catch ex As Exception
            MsgBox(ex.Message & "  " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
        Return CSV
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


    ''' <summary>
    ''' Returns the path to a file.
    ''' </summary>
    ''' <param name="Title">Title.</param>
    ''' <param name="Filter">File filter. See documentation for OpenFileDialog.</param>
    ''' <returns>String. Path to the selected file.</returns>
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

    ''' <summary>
    ''' Returns a DataTable of the WRST caribou collar deployments from the Animal_Movement database
    ''' </summary>
    ''' <returns>DataTable</returns>
    Public Function GetCollarDeploymentsDataTable() As DataTable
        Dim CollarDeploymentsDataTable As New DataTable
        Try
            Dim Sql As String = "SELECT Collars.Frequency, CollarDeployments.DeploymentDate, Animals.MortalityDate, CollarDeployments.RetrievalDate, Collars.DisposalDate, Collars.HasGps, CollarDeployments.CollarManufacturer, Collars.CollarModel, Collars.SerialNumber, Animals.Species, Animals.Gender,                            Animals.GroupName, Animals.Description, Collars.Manager, Collars.Owner, Collars.Notes AS CollarNotes, CollarDeployments.CollarId, Animals.ProjectId, CollarDeployments.DeploymentId,Animals.AnimalId,        CONVERT(Varchar(20), Collars.Frequency) + ' - ' + Animals.AnimalId AS CollaredCaribou  FROM            Animals INNER JOIN                           CollarDeployments ON Animals.ProjectId = CollarDeployments.ProjectId AND Animals.AnimalId = CollarDeployments.AnimalId INNER JOIN                           Collars ON CollarDeployments.CollarManufacturer = Collars.CollarManufacturer AND CollarDeployments.CollarId = Collars.CollarId  WHERE        (Animals.ProjectId = 'WRST_Caribou')  ORDER BY Collars.Frequency, Animals.AnimalId"
            CollarDeploymentsDataTable = GetDataTable(My.Settings.Animal_MovementConnectionString, Sql)
            CollarDeploymentsDataTable.TableName = "CollarDeployments"
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
        Return CollarDeploymentsDataTable
    End Function


    ''' <summary>
    ''' Returns a DataTable of the WRST caribou animals from the Animal_Movement database
    ''' </summary>
    ''' <returns>DataTable</returns>
    Public Function GetAnimalsDataTable() As DataTable
        Dim AnimalsDataTable As New DataTable()
        Try
            'query the database and build the table
            Dim Sql As String = "SELECT AnimalId, Species, Gender, MortalityDate, GroupName, Description,        ProjectId FROM            Animals WHERE        (ProjectId = 'WRST_Caribou')"
            AnimalsDataTable = GetDataTable(My.Settings.Animal_MovementConnectionString, Sql)
            AnimalsDataTable.TableName = "Animals"

            'set up the primary key(s)
            Dim PrimaryKeyColumn(1) As DataColumn
            PrimaryKeyColumn(0) = AnimalsDataTable.Columns("AnimalID")
            AnimalsDataTable.PrimaryKey = PrimaryKeyColumn
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
        Return AnimalsDataTable
    End Function

    ''' <summary>
    ''' Returns a DataTable of the WRST caribou collars inventory from the Animal_Movement database.
    ''' </summary>
    ''' <returns>DataTable</returns>
    Public Function GetCollarsDataTable() As DataTable
        Dim CollarsDataTable As New DataTable()
        Try
            Dim Sql As String = "SELECT * FROM Collars ORDER BY Collars.Frequency"
            CollarsDataTable = GetDataTable(My.Settings.Animal_MovementConnectionString, Sql)
            CollarsDataTable.TableName = "Collars"
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
        Return CollarsDataTable
    End Function

    Public Function GetAnimal_MovementDataset() As DataSet
        Dim AMDataset As New DataSet("Animal_Movement")
        Try
            'build the datatables from the database
            Dim AnimalsDataTable As DataTable = GetAnimalsDataTable()
            Dim CollarsDatatable As DataTable = GetCollarsDataTable()
            Dim CollarDeploymentsDataTable As DataTable = GetCollarDeploymentsDataTable()

            'load the datatables into the animal movement dataset
            With AMDataset
                .Tables.Add(GetCollarsDataTable)
                .Tables.Add(GetAnimalsDataTable)
                .Tables.Add(GetCollarDeploymentsDataTable)
            End With

            'set up relationships to show the history of collar deployments per animal
            Dim AnimalsToCollarDeploymentsDataRelation As New DataRelation("Animals_CollarDeploymentsDataRelation", AMDataset.Tables("Animals").Columns("AnimalID"), AMDataset.Tables("CollarDeployments").Columns("AnimalID"))
            AMDataset.Relations.Add(AnimalsToCollarDeploymentsDataRelation)
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
        Return AMDataset
    End Function
End Module

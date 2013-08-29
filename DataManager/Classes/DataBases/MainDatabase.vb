Imports System.Data.SqlClient
Imports System.IO

Public Enum TableType

    QuestionnaireSetTable = 1
    Questionnaire = 2
    Section = 3

End Enum


Public Class MainDatabase

#Region " Private Members "

    Private _connection As SqlConnection
    Private _connectionStringMDF As String
    Private _outputFolder As String
    Private _errorMessageScriptWriterVariable As StreamWriter
    Private _dataBaseFullPath As String
    Private _dataBaseName As String
    Private _serverName As String
    Private _user As String
    Private _dataBaseGenerator As DatabaseGenerator

    Private _connectedToMDF As Boolean
    Private _SQLServer As String
    Private _SQLUser As String
    Private _SQLPassword As String
    Private _SQLIsTrustedConnection As Boolean
    Private _SQLDataBase As String
    Enum SQLProviders
        SQLSever = 1
        SQLLite = 2
        MDF = 3
    End Enum

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks>Used to store the error in the Import Process</remarks>
    Private Property _errorMessageScriptWriter() As StreamWriter
        Get

            If _errorMessageScriptWriterVariable Is Nothing Then
                If Not Directory.Exists(_outputFolder) Then
                    Directory.CreateDirectory(_outputFolder)
                End If
                _errorMessageScriptWriterVariable = New StreamWriter(String.Format("{0}\{1}.log", _outputFolder, _dataBaseName), True)
            End If
            Return _errorMessageScriptWriterVariable

        End Get
        Set(ByVal value As StreamWriter)

            _errorMessageScriptWriterVariable = value

        End Set
    End Property

#End Region

#Region " Public Members "

    Public Const MessageAbortUser As String = "Abort by User"


    Public ReadOnly Property Connected() As Boolean
        Get
            Dim value As Boolean = False

            If _connection IsNot Nothing Then

                value = (_connection.State = ConnectionState.Open)

            End If

            Return value
        End Get
    End Property


    Public ReadOnly Property DataBaseName() As String
        Get
            Return _dataBaseName
        End Get
    End Property


    Public ReadOnly Property ConnectedToMDF() As Boolean
        Get
            Return _connectedToMDF
        End Get
    End Property


    Public Property SQLServerName() As String
        Get
            Return _SQLServer
        End Get
        Set(ByVal value As String)
            _SQLServer = value
        End Set
    End Property


    Public Property SQLUserName() As String
        Get
            Return _SQLUser
        End Get
        Set(ByVal value As String)
            _SQLUser = value
        End Set
    End Property


    Public Property SQLPassword() As String
        Get
            Return _SQLPassword
        End Get
        Set(ByVal value As String)
            _SQLPassword = value
        End Set
    End Property


    Public Property SQLIsTrustedConnection() As Boolean
        Get
            Return _SQLIsTrustedConnection
        End Get
        Set(ByVal value As Boolean)
            _SQLIsTrustedConnection = value
        End Set
    End Property


    Public Property SQLDataBase() As String
        Get
            Return _SQLDataBase
        End Get
        Set(ByVal value As String)
            _SQLDataBase = value
        End Set
    End Property

#End Region

#Region " Public Methods "

    Public Sub Dispose()
        CloseConnection()
    End Sub


    Public Sub New(ByVal dataBaseName As String, ByVal currentFolder As String, ByVal outputFolder As String, _
                 ByVal serverName As String)

        _dataBaseGenerator = New DatabaseGenerator(currentFolder, Me)

        _outputFolder = outputFolder
        _dataBaseName = String.Format("{0}", dataBaseName)
        _dataBaseFullPath = String.Format("{0}\{1}.mdf", _outputFolder, _dataBaseName)
        _serverName = serverName

        _connection = New SqlConnection()

    End Sub


    ''' <summary>
    ''' Try to connect to MDF, if couldn't connecto to the MDF then show a connection Dialog
    ''' </summary>
    ''' <returns>True: The connection is successfull.  False: Can't connect to a database.</returns>
    ''' <remarks></remarks>
    Public Function ConnectToMDF() As Boolean

        _connection = New SqlConnection()
        _connectionStringMDF = String.Format("Data Source=.\{0}; User Instance=True; AttachDbFilename={1};" & _
                " Trusted_Connection=True", _serverName, _dataBaseFullPath)

        If File.Exists(_dataBaseFullPath) Then

            Try

                _connection.ConnectionString = _connectionStringMDF

                'Connect to the DataBase, If it can't connecto to the DataBase then it Needs a new connection String
                If _connection.State <> ConnectionState.Open Then _connection.Open()
                SetUser()
                Return True

            Catch ex As Exception

                ' Show a message with the problem
                MessageBox.Show(String.Format("Imposible to Connect to the database: {0}{1}", vbCrLf, ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' Show a dialog of connection.
                Return False

            End Try

        Else
            ' Create the Folder 
            DA.Functions.CreateFolder(_outputFolder)

            ' Create the DataBase File and Connect to the New MDF
            If CreateMDFDataBase(_serverName) Then
                SetUser()
                Return True
            Else
                Return False
            End If

        End If

    End Function


    Public Sub ExportToSAS(ByVal path As String)

        Dim script As String
        Dim e As System.Text.Encoding = System.Text.Encoding.GetEncoding(0)
        Dim fileWriter As New StreamWriter(path, False, e)

        Dim dataBaseName As String

        If _dataBaseName.IndexOf(" "c) < 0 Then
            dataBaseName = _dataBaseName
        Else
            dataBaseName = _dataBaseName.Substring(0, _dataBaseName.IndexOf(" "c))
        End If

        If _connectedToMDF Then

            script = String.Format(" libname {0} oledb ACCESS=READONLY init_string=""AttachDbFilename={1};" & _
                                    "Provider=SQLNCLI;Server=.\{2};Trusted_Connection=yes;"" SCHEMA=Analysis;", _
                                    dataBaseName, _dataBaseFullPath, _serverName)
        Else

            If SQLIsTrustedConnection Then

                script = String.Format(" libname {0} oledb ACCESS=READONLY init_string=""Provider=SQLNCLI;" & _
                                        "Server={1};Initial Catalog={2};Trusted_Connection=yes;"" SCHEMA=Analysis;", dataBaseName, _
                                        SQLServerName, SQLDataBase)

            Else


                script = String.Format(" libname {0} oledb ACCESS=READONLY init_string=""Provider=SQLNCLI;" & _
                                        "Server={1};Initial Catalog={2};User ID={3};Password={4}"" SCHEMA=Analysis;", dataBaseName, _
                                        SQLServerName, SQLDataBase, SQLUserName, SQLPassword)

            End If


        End If
        fileWriter.Write(script)

        fileWriter.Close()
        fileWriter.Dispose()

    End Sub


    Public Sub CloseConnection()

        If _connection IsNot Nothing Then
            _connection.Close()
            _connection.Dispose()
        End If

        If _errorMessageScriptWriter IsNot Nothing Then
            _errorMessageScriptWriter.Close()
            _errorMessageScriptWriter.Dispose()
            _errorMessageScriptWriter = Nothing
        End If

    End Sub


    ''' <summary>
    ''' Get the DataTable of a Select Query
    ''' </summary>
    ''' <param name="query"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetDataTable(ByVal query As String) As DataTable

        'Try

        Dim queryAdapter As New SqlDataAdapter(query, _connection)
        Dim queryTable As New DataTable()
        queryAdapter.Fill(queryTable)
        Return queryTable

        'Catch ex As Exception

        '    Throw New Exception(ex.Message)

        'MessageBox.Show(String.Format("Error: {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        '    Return Nothing
        'End Try
    End Function

    ''' <summary>
    ''' Import a Table to the MainDataDB
    ''' </summary>
    ''' <param name="externalTable"></param>
    ''' <param name="tableName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ImportTable(ByVal externalTable As DataTable, ByVal tableName As String, ByVal auditTableName As String) As TableStatistic

        Dim mainTable As New DataTable(tableName)
        Dim auditTable As New DataTable(auditTableName)
        Dim mainDataAdapter As New SqlDataAdapter(String.Format("Select * FROM {0}", tableName), _connection)
        Dim auditDataAdapter As New SqlDataAdapter(String.Format("Select top(1) * FROM {0}", auditTableName), _connection)
        Dim tableStatistics As New TableStatistic(tableName)

        Dim filter As String = ""
        Dim filteredMainTable As New DataTable(tableName)
        Dim filteredDataAdapter As SqlDataAdapter

        Dim useSubjectQuestionnaireInstanceID As Boolean = False


        ' Create the update and insert command

        Dim commandBuilder As New SqlCommandBuilder(auditDataAdapter)
        auditDataAdapter.UpdateCommand = commandBuilder.GetUpdateCommand()
        auditDataAdapter.InsertCommand = commandBuilder.GetInsertCommand()

        commandBuilder = New SqlCommandBuilder(mainDataAdapter)
        mainDataAdapter.UpdateCommand = commandBuilder.GetUpdateCommand()
        mainDataAdapter.InsertCommand = commandBuilder.GetInsertCommand()

        ' Get data 
        mainDataAdapter.Fill(mainTable)

        auditDataAdapter.Fill(auditTable)


        ' ----- Begin of the Import Algoritm- -------
        For Each externalRow As DataRow In externalTable.Rows

            ' check if PDALastModifDate is not null

            If externalRow("PDALastModifDate").GetType.ToString <> GetType(System.DBNull).ToString Then

                If mainTable.Columns.Contains("SubjectQuestionnaireInstanceID") Then
                    filter = String.Format(" [SubjectID] = '{0}' AND [SubjectQuestionnaireInstanceID] = '{1}' ", externalRow("SubjectID"), externalRow("SubjectQuestionnaireInstanceID"))
                    useSubjectQuestionnaireInstanceID = True
                Else
                    filter = String.Format(" [SubjectID] = '{0}'  ", externalRow("SubjectID"))
                    useSubjectQuestionnaireInstanceID = False
                End If

                filteredMainTable.Clear()
                filteredDataAdapter = New SqlDataAdapter(String.Format("Select * FROM {0} WHERE {1}", tableName, filter), _connection)
                filteredDataAdapter.Fill(filteredMainTable)

                'Data for error message
                Dim subjectID As String = ""
                Dim subjectQuestionnaireInstanceID As Integer = -1

                If filteredMainTable.Rows.Count > 0 Then
                    'Check if the row in the External Data Base is a new version of the row in the Main Data Base

                    If filteredMainTable.Rows(0)("PDALastModifDate").GetType.ToString = GetType(System.DBNull).ToString OrElse _
                            CDate(externalRow("PDALastModifDate")) > CDate(filteredMainTable.Rows(0)("PDALastModifDate")) Then

                        '------------ Update ------------------
                        Dim mainRow As DataRow = Nothing

                        ' get the row of the mainTable
                        For Each row As DataRow In mainTable.Rows

                            If useSubjectQuestionnaireInstanceID Then


                                If row("SubjectID").ToString = externalRow("SubjectID").ToString And _
                                        row("SubjectQuestionnaireInstanceID").ToString = externalRow("SubjectQuestionnaireInstanceID").ToString Then

                                    mainRow = row
                                    subjectID = row("SubjectID").ToString
                                    subjectQuestionnaireInstanceID = CInt(row("SubjectQuestionnaireInstanceID"))
                                    subjectQuestionnaireInstanceID = CInt(IIf(subjectQuestionnaireInstanceID > 0, subjectQuestionnaireInstanceID, -1))
                                    Exit For

                                End If

                            Else

                                If row("SubjectID").ToString = externalRow("SubjectID").ToString Then

                                    mainRow = row
                                    subjectID = row("SubjectID").ToString

                                    Exit For

                                End If

                            End If

                        Next

                        If mainRow IsNot Nothing Then

                            ' new Audit Row
                            Dim logRow As DataRow = auditTable.NewRow()



                            ' Fill new Audit Row
                            For idx As Integer = 0 To mainTable.Columns.Count - 1
                                Try
                                    logRow(mainTable.Columns(idx).ColumnName) = mainRow(mainTable.Columns(idx).ColumnName)
                                Catch ex As Exception

                                    If (mainTable.Columns(idx).ColumnName) <> "InsertUser" _
                                        And (mainTable.Columns(idx).ColumnName) <> "InsertMsg" _
                                        And (mainTable.Columns(idx).ColumnName) <> "InsertDate" Then

                                        _errorMessageScriptWriter.WriteLine(String.Format("Error (Update, Log) copy table {0}, column {1}:", tableName, mainTable.Columns(idx).ColumnName))
                                        _errorMessageScriptWriter.WriteLine(String.Format("""{0}""", ex.Message))
                                        'MessageBox.Show(ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                                        tableStatistics.AddError("Fill new Audit Row (Update)", ex.Message, subjectID, subjectQuestionnaireInstanceID)

                                    End If

                                End Try
                            Next

                            ' Fill Audit Columns
                            logRow("LogMsg") = "New Data"
                            logRow("LogUser") = _user
                            logRow("LogDate") = Now()

                            ' Update Audit Table
                            Dim logUpdated As Boolean = False
                            auditTable.Rows.Add(logRow)
                            Try
                                auditDataAdapter.Update(auditTable)
                                logUpdated = True
                            Catch ex As SqlClient.SqlException
                                logUpdated = False
                                _errorMessageScriptWriter.WriteLine(String.Format("Error (Update, Log) copy table {0}:", tableName))
                                _errorMessageScriptWriter.WriteLine(String.Format("""{0}""", ex.Message))

                                tableStatistics.AddError("Commiting update in Audit Table (Update)", ex.Message, subjectID, subjectQuestionnaireInstanceID)

                            End Try

                            ' check if the audit update was successfull
                            If (logUpdated) Then

                                ' Fill the main Row
                                For idx As Integer = 0 To externalTable.Columns.Count - 1
                                    Try
                                        mainRow(externalTable.Columns(idx).ColumnName) = externalRow.Item(externalTable.Columns(idx).ColumnName)
                                    Catch ex As Exception
                                        _errorMessageScriptWriter.WriteLine(String.Format("Error (Update) copy table {0}, column {1}:", tableName, externalTable.Columns(idx).ColumnName))
                                        _errorMessageScriptWriter.WriteLine(String.Format("""{0}""", ex.Message))

                                        tableStatistics.AddError("Update Main Row (Not Commited)", ex.Message, subjectID, subjectQuestionnaireInstanceID)

                                    End Try
                                Next
                                mainRow("DBModifMsg") = "New Data"
                                mainRow("DBModifDate") = Date.Now
                                mainRow("UpdateVersion") = 1 + CInt(mainRow("UpdateVersion"))
                                mainRow("DBModifUser") = _user

                                ' Update the main row
                                Try
                                    mainDataAdapter.Update(mainTable)

                                    tableStatistics.AddUpdated()

                                Catch ex As SqlClient.SqlException

                                    _errorMessageScriptWriter.WriteLine(String.Format("Error (Update) copy table {0}:", tableName))
                                    _errorMessageScriptWriter.WriteLine(String.Format("""{0}""", ex.Message))

                                    tableStatistics.AddError("Commiting Update (Update)", ex.Message, subjectID, subjectQuestionnaireInstanceID)
                                    'MessageBox.Show(ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                                End Try

                            End If
                        End If
                    End If


                Else
                    '-------------- Insert ------------

                    ' Create New Row
                    Dim newRow As DataRow = mainTable.NewRow

                    ' Get data for error messages
                    subjectID = externalRow("SubjectID").ToString

                    If externalRow.Table.Columns.Contains("SubjectQuestionnaireInstanceID") Then
                        subjectQuestionnaireInstanceID = CInt(externalRow("SubjectQuestionnaireInstanceID"))
                    Else
                        subjectQuestionnaireInstanceID = -1
                    End If


                    ' Fill new Row
                    For idx As Integer = 0 To externalTable.Columns.Count - 1
                        Try

                            newRow(externalTable.Columns(idx).ColumnName) = externalRow.Item(externalTable.Columns(idx).ColumnName)

                        Catch ex As Exception
                            _errorMessageScriptWriter.WriteLine(String.Format("Error (Insert) copy table {0}, column {1}:", tableName, externalTable.Columns(idx).ColumnName))
                            _errorMessageScriptWriter.WriteLine(String.Format("""{0}""", ex.Message))

                            tableStatistics.AddError("Fill New Main Row (Insert)", ex.Message, subjectID, subjectQuestionnaireInstanceID)

                            'MessageBox.Show(ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

                        End Try
                    Next

                    newRow("UpdateVersion") = 0
                    newRow("InsertMsg") = "Original Data"
                    newRow("InsertDate") = Date.Now
                    newRow("InsertUser") = _user
                    newRow("DBModifMsg") = "Original Data"
                    newRow("DBModifDate") = Date.Now
                    newRow("DBModifUser") = _user
                    newRow("forDeletion") = 0

                    mainTable.Rows.Add(newRow)

                    Try
                        mainDataAdapter.Update(mainTable)
                        tableStatistics.AddInserted()

                    Catch ex As SqlClient.SqlException
                        _errorMessageScriptWriter.WriteLine(String.Format("Error (Insert) copy table {0}:", tableName))
                        _errorMessageScriptWriter.WriteLine(String.Format("""{0}""", ex.Message))

                        tableStatistics.AddError("Commiting Insert (Insert)", ex.Message, subjectID, subjectQuestionnaireInstanceID)
                        'MessageBox.Show(ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    End Try

                End If
            End If
        Next

        Return tableStatistics

    End Function


    Public Sub ExecuteNonQuery(ByVal script As String)

        Dim command As New SqlCommand(script, GetConnection)
        command.ExecuteNonQuery()
        command.Dispose()

    End Sub


    Public Function VerifyDatabaseVersionAndStudy(ByVal autoBuildStructure As Boolean) As Boolean

        'Verify if the database is constructed
        Try

            Dim studyRow As DataRow = Me.GetDataTable("Select name,version,DesignerVersion from study").Rows(0)

            If studyRow("version").ToString <> BO.ContextClass.Study.Version Or _
                studyRow("name").ToString <> BO.ContextClass.Study.Name Then

                Select Case MessageBox.Show("The Study is incompatible with the DataBase." & vbCrLf & "Do you want to update the DataBase?", "Error", MessageBoxButtons.YesNo)

                    Case DialogResult.Yes
                        'CreateQMDC()
                        'We excecute El Oro

                        'Update LV Tables
                        UpdateLegalValuesTables()

                        Return True

                    Case DialogResult.No
                        Return False

                End Select

            End If

        Catch ex As Exception
            If autoBuildStructure Then
                _dataBaseGenerator.CreateDataBaseStructure()
                Return True
            Else
                'If not is constructed then construct the database
                If MessageBox.Show("Do you want to create the structure of the DataBase?", "DataBase", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
                    _dataBaseGenerator.CreateDataBaseStructure()
                    Return True
                Else
                    Return False
                End If
            End If
        End Try

        Return True

    End Function

#End Region

#Region " Private Methods "


    Private Sub CreateColumn(ByVal schema As String, ByVal table As String, ByVal column As String, ByVal columnType As String)

        Dim columnTable As DataTable = Me.GetDataTable(String.Format("SELECT TABLE_NAME,COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA = '{0}' AND TABLE_NAME = '{1}' AND COLUMN_NAME = '{2}'" _
                                                                        , schema, table, column))

        'check if the column Exist or not.
        If columnTable.Rows.Count = 0 Then

            Me.ExecuteNonQuery(String.Format("ALTER TABLE [{0}].[{1}] ADD [{2}] {3} NULL" _
                                                , schema _
                                                , table _
                                                , column _
                                                , columnType))

        End If

    End Sub


    Private Sub CreateLegalValueTable(ByVal table As String)


        Dim strContents As String = File.OpenText(Application.StartupPath & "\Scripts\Create Legal Value Table.sql").ReadToEnd()
        strContents = strContents.Replace("{tableName}", table).Replace("{LegalValueSchema}", BO.ContextClass.Study.LegalValuesTableSchema)
        Dim statements() As String = strContents.Split(";"c)

        For Each statement As String In statements
            If Not String.IsNullOrEmpty(statement.Trim) Then
                Me.ExecuteNonQuery(statement)
            End If
        Next

    End Sub


    Private Sub UpdateLegalValuesTables()

        For Each LegalValue As BO.LegalValuesTable In BO.Study.LegalValues

            Dim infoTable As DataTable = Me.GetDataTable(String.Format("SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = '{0}' AND TABLE_NAME = '{1}'" _
                                                                                    , BO.ContextClass.Study.LegalValuesTableSchema _
                                                                                    , LegalValue.Name))

            If infoTable.Rows.Count > 0 Then

                CreateColumn(BO.ContextClass.Study.LegalValuesTableSchema, LegalValue.Name, "Hidden", "BIT")
                CreateColumn(BO.ContextClass.Study.LegalValuesTableSchema, LegalValue.Name, "LegalValueItemGUID", "UNIQUEIDENTIFIER")


            Else

                CreateLegalValueTable(LegalValue.Name)

            End If


            Dim order As Integer = 1

            For Each lvItem As BO.LegalValueItem In LegalValue.LegalValues

                Dim lvItemTable As DataTable = Me.GetDataTable(String.Format("SELECT * FROM {0}.{1} WHERE Value = '{2}' AND NOT Value is NULL", BO.ContextClass.Study.LegalValuesTableSchema, LegalValue.Name, lvItem.Value.ToString))

                If lvItemTable.Rows.Count > 0 Then

                    'Update the LegalValueItem
                    Me.ExecuteNonQuery(String.Format("UPDATE {0}.{1} SET [Order] = '{2}',[Text] = '{3}',[ShortName] = '{4}',[Group] = '{5}',[Hidden] = '{6}', [LegalValueItemGUID] = '{7}' WHERE [Value] = '{8}'" _
                                                        , BO.ContextClass.Study.LegalValuesTableSchema _
                                                        , LegalValue.Name _
                                                        , order _
                                                        , lvItem.Text _
                                                        , lvItem.ShortName _
                                                        , lvItem.Group _
                                                        , IIf(lvItem.Hidden, 1, 0).ToString _
                                                        , lvItem.Guid.ToString _
                                                        , lvItem.Value))

                Else

                    'Insert the LegalValueItem
                    Dim strContents As String = File.OpenText(Application.StartupPath & "\Scripts\Insert Legal Value Item.sql").ReadToEnd()
                    strContents = strContents.Replace("{LegalValueSchema}", BO.ContextClass.Study.LegalValuesTableSchema)
                    strContents = strContents.Replace("{tableName}", LegalValue.Name)
                    strContents = strContents.Replace("{Value}", lvItem.Value.ToString)
                    strContents = strContents.Replace("{Order}", order.ToString)
                    strContents = strContents.Replace("{Hidden}", IIf(lvItem.Hidden, 1, 0).ToString)
                    strContents = strContents.Replace("{LegalValueItemGUID}", lvItem.Guid.ToString)

                    If String.IsNullOrEmpty(lvItem.Text.Trim) Then
                        strContents = strContents.Replace("'{Text}'", "NULL")
                    Else
                        strContents = strContents.Replace("{Text}", lvItem.Text)
                    End If
                    If String.IsNullOrEmpty(lvItem.ShortName.Trim) Then
                        strContents = strContents.Replace("'{ShortName}'", "NULL")
                    Else
                        strContents = strContents.Replace("{ShortName}", lvItem.ShortName)
                    End If
                    If String.IsNullOrEmpty(lvItem.Group.Trim) Then
                        strContents = strContents.Replace("'{Group}'", "NULL")
                    Else
                        strContents = strContents.Replace("{Group}", lvItem.Group)
                    End If

                    Dim statements() As String = strContents.Split(";"c)

                    For Each statement As String In statements
                        If Not String.IsNullOrEmpty(statement.Trim) Then
                            Me.ExecuteNonQuery(statement)
                        End If
                    Next

                End If

                order += 1

            Next

        Next

    End Sub


    Private Function CreateMDFDataBase(ByVal serverName As String) As Boolean

        ' Create folder

        DA.Functions.CreateFolder(_outputFolder)

        ' Copy mdf File

        If _connection.State = ConnectionState.Open Then

            _connection.Close()
            _connection.Dispose()

        End If


        'File.Copy(String.Format("{0}\Empty DataBase.mdf", Application.StartupPath), String.Format("{0}\{1}.mdf", _outputFolder, DBName), False)
        Dim x As New FileInfo(String.Format("{0}\Empty DataBase.mdf", Application.StartupPath))
        Try
            x.CopyTo(_dataBaseFullPath)
        Catch
        End Try
        x = Nothing

        ' Connect to mdf File
        Dim count As Integer = 0
        Dim message As String = ""

        While count < 10

            Threading.Thread.Sleep(1000)

            Try
                _connection.ConnectionString = _connectionStringMDF
                _connection.Open()
                count = 10
                message = ""
            Catch ex As Exception
                message = ex.Message & vbCrLf & ex.ToString
            End Try

            count += 1
        End While


        If _connection.State = ConnectionState.Open Then
            Return True
        Else
            MessageBox.Show(String.Format("Imposible to Connect to the database: {0}", message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False

        End If

    End Function


    Public Function ConnectToSQLServer(ByVal SQLServer As String, ByVal SQLDataBase As String, _
                            ByVal SQLIsTrustedConnection As Boolean, ByVal SQLUser As String, ByVal SQLPassword As String) As Boolean

        Dim connectionString As String

        _SQLServer = SQLServer
        _SQLDataBase = SQLDataBase
        _SQLIsTrustedConnection = SQLIsTrustedConnection
        _SQLUser = SQLUser
        _SQLPassword = SQLPassword

        If _SQLIsTrustedConnection Then
            connectionString = String.Format("Data Source={0}; Initial Catalog={1}; Trusted_Connection=True", _
                                _SQLServer, _SQLDataBase)
        Else
            connectionString = String.Format("Data Source={0}; Initial Catalog={1}; User Id={2};Password={3};", _
                                _SQLServer, _SQLDataBase, _SQLUser, _SQLPassword)
        End If

        Me.CloseConnection()

        _connection = New SqlConnection()
        _connection.ConnectionString = connectionString
        _connection.Open()
        SetUser()

        _connectedToMDF = False

    End Function


    Private Sub SetUser()
        Try

            Dim dataAdapter As New SqlDataAdapter(String.Format("Select suser_sname()"), _connection)
            Dim dataTableUser As New DataTable
            dataAdapter.Fill(dataTableUser)

            _user = dataTableUser.Rows(0)(0).ToString()

        Catch ex As Exception
            _user = ""
        End Try
    End Sub


    Private Function GetConnection() As SqlConnection

        If Not _connection.State = ConnectionState.Open Then _connection.Open()
        Return _connection

    End Function

#End Region

End Class
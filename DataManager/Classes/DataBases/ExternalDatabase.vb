Imports System.Data.SqlServerCe
Imports System.Data.SQLite
Imports OpenNETCF.Desktop.Communication

Public Class ExternalDatabase

#Region " Properties "

    Private _QMDConnection As SqlCeConnection
    Private _QMDConnectionSQLLite As SQLiteConnection
    Private _name As String
    Private _filePathPC As String
    Private _filePathPDA As String

    Private _Provider As MainDatabase.SQLProviders

    Public ReadOnly Property Connected() As Boolean
        Get
            If _Provider = MainDatabase.SQLProviders.SQLSever Then
                If Connection Is Nothing Then
                    Return False
                End If
                Return Connection.State = ConnectionState.Open
            ElseIf _Provider = MainDatabase.SQLProviders.SQLLite Then
                If ConnectionSQLLite Is Nothing Then
                    Return False
                End If
                Return ConnectionSQLLite.State = ConnectionState.Open
            End If
        End Get
    End Property

    Public ReadOnly Property Connection() As SqlCeConnection
        Get
            Return _QMDConnection
        End Get
    End Property
    Public ReadOnly Property ConnectionSQLLite() As SQLiteConnection
        Get
            Return _QMDConnectionSQLLite
        End Get
    End Property

    Public ReadOnly Property Name() As String
        Get

            If _Provider = MainDatabase.SQLProviders.SQLSever Then
                If Connection Is Nothing Then
                    Return ""
                End If

            ElseIf _Provider = MainDatabase.SQLProviders.SQLLite Then
                If ConnectionSQLLite Is Nothing Then
                    Return ""
                End If

            End If



            If Not Connected Then
                Return ""
            End If

            Return _name

        End Get
    End Property

#End Region

#Region " Public Members "

    Public Function GetConnection() As SqlCeConnection
        Return _QMDConnection
    End Function
    Public Function GetSQLLIteConnection() As SQLiteConnection
        Return _QMDConnectionSQLLite
    End Function

 

    ' Initializes the connection to the database.
    Public Sub SetConnectionParams(ByVal path As String, Optional ByVal password As String = Nothing)

        'Save the file name
        Dim fileInfo As New System.IO.FileInfo(path)
        _name = fileInfo.Name
        _filePathPC = fileInfo.FullName

        ' Build the connection string.
        Dim connectionString As String

        If _Provider = MainDatabase.SQLProviders.SQLSever Then
            connectionString = String.Format("DataSource={0};", path)
            If Not String.IsNullOrEmpty(password) Then connectionString &= String.Format("Password = {0};", password)
            ' Creates the connection object.

            _QMDConnection = New SqlCeConnection(connectionString)
            _QMDConnection.Open()
        ElseIf _Provider = MainDatabase.SQLProviders.SQLLite Then
            connectionString = String.Format("Data Source={0};", path)
            _QMDConnectionSQLLite = New SQLiteConnection()
            _QMDConnectionSQLLite.ConnectionString = connectionString
            _QMDConnectionSQLLite.Open()

        End If


        verifyDataAndDesignVersion()

    End Sub


    ''' <summary>
    ''' Sets the SQL providers: SQLServer or SQLLIte check ENUM MainDatabase.SQLProviders
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Public WriteOnly Property Provider() As MainDatabase.SQLProviders
        Set(ByVal value As MainDatabase.SQLProviders)
            _Provider = value

        End Set
    End Property

    'Open the connection with the PDA
    Public Sub openConnectionPDA(ByVal password As String, ByVal pathPDA As String)

        'Copy the SDF to a temporal file
        _filePathPC = System.IO.Path.GetTempFileName()
        DA.Functions.CopyFileFromPDAToPC(_filePathPC, pathPDA)

        'Save the file name
        _name = "PDA"

        ' Build the connection string.
        Dim connectionString As String = String.Format("DataSource={0};", _filePathPC)

        If _Provider = MainDatabase.SQLProviders.SQLSever Then
            If Not String.IsNullOrEmpty(password) Then connectionString &= String.Format("Password = {0};", password)
            ' Creates the connection object.
            _QMDConnection = New SqlCeConnection(connectionString)
            _QMDConnection.Open()
        ElseIf _Provider = MainDatabase.SQLProviders.SQLLite Then
            _QMDConnectionSQLLite = New SQLiteConnection(connectionString)
            _QMDConnectionSQLLite.Open()

        End If
        verifyDataAndDesignVersion()
    End Sub

    'Close the connection with the database
    Public Sub CloseConnection()

        If _Provider = MainDatabase.SQLProviders.SQLSever Then
            If _QMDConnection IsNot Nothing Then
                _QMDConnection.Close()
                _QMDConnection.Dispose()
            End If
        ElseIf _Provider = MainDatabase.SQLProviders.SQLLite Then
            If _QMDConnectionSQLLite IsNot Nothing Then
                _QMDConnectionSQLLite.Close()
                _QMDConnectionSQLLite.Dispose()
            End If

        End If

    End Sub

    'Get the table of a query
    Public Function GetDataTable(ByVal query As String) As DataTable
        Try

            Dim queryAdapter As SqlCeDataAdapter
            Dim queryAdapter_ As SQLiteDataAdapter
            Dim queryTable As New DataTable()

            If _Provider = MainDatabase.SQLProviders.SQLSever Then
                queryAdapter = New SqlCeDataAdapter(query, _QMDConnection)
                queryAdapter.Fill(queryTable)
            ElseIf _Provider = MainDatabase.SQLProviders.SQLLite Then
                queryAdapter_ = New SQLiteDataAdapter(query, _QMDConnectionSQLLite)
                queryAdapter_.Fill(queryTable)

            End If

            Return queryTable

        Catch ex As Exception

            MessageBox.Show(String.Format("Error: {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return Nothing

        End Try

    End Function


    Public Sub ExecuteNonQuery(ByVal script As String)


        If _Provider = MainDatabase.SQLProviders.SQLSever Then
            Dim command As New SqlCeCommand(script, GetConnection)
            command.ExecuteNonQuery()
            command.Dispose()

        ElseIf _Provider = MainDatabase.SQLProviders.SQLLite Then
            Dim command As New SQLiteCommand(script, GetSQLLIteConnection)
            command.ExecuteNonQuery()
            command.Dispose()

        End If

    End Sub

#End Region

#Region " Private Methods "

'verify the compatibility of  QMD with  QM
    Private Sub verifyDataAndDesignVersion()

        ' Retrieve the information from the study table.

        Dim studyDataAdapter As SqlCeDataAdapter
        Dim studyDataAdapter_ As SQLiteDataAdapter

        Dim studyTable As New DataTable
        Dim studyRow As DataRow

        If _Provider = MainDatabase.SQLProviders.SQLSever Then
            studyDataAdapter = New SqlCeDataAdapter("Select name,version,DesignerVersion from study", _QMDConnection)
            studyDataAdapter.Fill(studyTable)

        ElseIf _Provider = MainDatabase.SQLProviders.SQLLite Then
            studyDataAdapter_ = New SQLiteDataAdapter("Select name,version,DesignerVersion from study", _QMDConnectionSQLLite)
            studyDataAdapter_.Fill(studyTable)

        End If

        studyRow = studyTable.Rows(0)
        'Verify the compatibility between QM and QMD
        If studyRow("version").ToString <> BO.ContextClass.Study.Version Or _
            studyRow("name").ToString <> BO.ContextClass.Study.Name Then

            CloseConnection()

            Throw New Exception(String.Format("QMD isn't compatible with the Study." & vbCrLf & "Study Version: {0}, {1}" & vbCrLf & "QMD Version: {2}, {3}", BO.ContextClass.Study.Name, BO.ContextClass.Study.Version, studyRow("name").ToString, studyRow("version").ToString))

        End If

    End Sub

#End Region

End Class

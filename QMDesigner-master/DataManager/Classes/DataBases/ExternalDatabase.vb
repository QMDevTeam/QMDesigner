Imports System.Data.SqlServerCe
Imports OpenNETCF.Desktop.Communication

Public Class ExternalDatabase

#Region " Properties "

    Private _QMDConnection As SqlCeConnection
    Private _name As String
    Private _filePathPC As String
    Private _filePathPDA As String

    Public ReadOnly Property Connected() As Boolean
        Get
            If Connection Is Nothing Then
                Return False
            End If

            Return Connection.State = ConnectionState.Open

        End Get
    End Property

    Public ReadOnly Property Connection() As SqlCeConnection
        Get
            Return _QMDConnection
        End Get
    End Property

    Public ReadOnly Property Name() As String
        Get

            If Connection Is Nothing Then
                Return ""
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

    ' Initializes the connection to the database.
    Public Sub SetConnectionParams(ByVal path As String, Optional ByVal password As String = Nothing)

        'Save the file name
        Dim fileInfo As New System.IO.FileInfo(path)
        _name = fileInfo.Name
        _filePathPC = fileInfo.FullName

        ' Build the connection string.
        Dim connectionString As String = String.Format("DataSource={0};", path)
        If Not String.IsNullOrEmpty(password) Then connectionString &= String.Format("Password = {0};", password)

        ' Creates the connection object.
        _QMDConnection = New SqlCeConnection(connectionString)
        _QMDConnection.Open()

        verifyDataAndDesignVersion()

    End Sub

    'Open the connection with the PDA
    Public Sub openConnectionPDA(ByVal password As String, ByVal pathPDA As String)

        'Copy the SDF to a temporal file
        _filePathPC = System.IO.Path.GetTempFileName()
        DA.Functions.CopyFileFromPDAToPC(_filePathPC, pathPDA)

        'Save the file name
        _name = "PDA"

        ' Build the connection string.
        Dim connectionString As String = String.Format("DataSource={0};", _filePathPC)
        If Not String.IsNullOrEmpty(password) Then connectionString &= String.Format("Password = {0};", password)

        ' Creates the connection object.
        _QMDConnection = New SqlCeConnection(connectionString)
        _QMDConnection.Open()

        verifyDataAndDesignVersion()
    End Sub

    'Close the connection with the database
    Public Sub CloseConnection()
        If _QMDConnection IsNot Nothing Then
            _QMDConnection.Close()
            _QMDConnection.Dispose()
        End If
    End Sub

    'Get the table of a query
    Public Function GetDataTable(ByVal query As String) As DataTable
        Try

            Dim queryAdapter As New SqlCeDataAdapter(query, _QMDConnection)
            Dim queryTable As New DataTable()
            queryAdapter.Fill(queryTable)
            Return queryTable

        Catch ex As Exception

            MessageBox.Show(String.Format("Error: {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return Nothing

        End Try

    End Function


    Public Sub ExecuteNonQuery(ByVal script As String)

        Dim command As New SqlCeCommand(script, GetConnection)
        command.ExecuteNonQuery()
        command.Dispose()

    End Sub

#End Region

#Region " Private Methods "

    'verify the compatibility of  QMD with  QM
    Private Sub verifyDataAndDesignVersion()

        ' Retrieve the information from the study table.
        Dim studyDataAdapter As New SqlCeDataAdapter("Select name,version,DesignerVersion from study", _QMDConnection)
        Dim studyTable As New DataTable
        studyDataAdapter.Fill(studyTable)
        Dim studyRow As DataRow = studyTable.Rows(0)

        'Verify the compatibility between QM and QMD
        If studyRow("version").ToString <> BO.ContextClass.Study.Version Or _
            studyRow("name").ToString <> BO.ContextClass.Study.Name Then

            CloseConnection()

            Throw New Exception(String.Format("QMD isn't compatible with the Study." & vbCrLf & "Study Version: {0}, {1}" & vbCrLf & "QMD Version: {2}, {3}", BO.ContextClass.Study.Name, BO.ContextClass.Study.Version, studyRow("name").ToString, studyRow("version").ToString))

        End If

    End Sub

#End Region

End Class

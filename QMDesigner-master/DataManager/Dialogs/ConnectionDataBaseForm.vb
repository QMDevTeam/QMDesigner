
Public Class ConnectionDataBaseForm

    ''' <summary>
    ''' Registry Manager
    ''' </summary>
    ''' <remarks></remarks>
    Private _registry As RegistryManager

    ''' <summary>
    ''' Update the Form when the Authentication method is changed
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmbAuthentication_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAuthentication.SelectedIndexChanged

        Dim authenticationWindows As Boolean = (cmbAuthentication.SelectedIndex = 0)

        txtUsername.Enabled = Not authenticationWindows
        txtPassword.Enabled = Not authenticationWindows
        lblPassword.Enabled = Not authenticationWindows
        lblUsername.Enabled = Not authenticationWindows

    End Sub

    ''' <summary>
    ''' Save the data in the registry when the acept button is clicked.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub butAcept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butAcept.Click

        _registry.WriteSubKeyValue("ConnectToMDF", IIf(rbtConnectMDF.Checked, "1", "0").ToString)
        _registry.WriteSubKeyValue("Server_Name_DM", txtServerName.Text)
        _registry.WriteSubKeyValue("DataBase_DM", txtDataBase.Text)
        _registry.WriteSubKeyValue("UserName_DM", txtUsername.Text)
        _registry.WriteSubKeyValue("AuthenticationMethod_DM", cmbAuthentication.SelectedIndex)

    End Sub

    '''' <summary>
    '''' Open itself and get the connection string from the form.
    '''' </summary>
    '''' <returns></returns>
    '''' <remarks></remarks>
    'Public Function GetConnectionStringSQLServer() As String

    '    Dim connectionString As String = ""

    '    Select Case cmbAuthentication.SelectedIndex

    '        Case 0

    '            connectionString = String.Format("Data Source={0}; Initial Catalog={1}; Trusted_Connection=True", txtServerName.Text, txtDataBase.Text)

    '        Case 1

    '            connectionString = String.Format("Data Source={0}; Initial Catalog={1}; User Id={2};Password={3};", txtServerName.Text, txtDataBase.Text, txtUsername.Text, txtPassword.Text)

    '    End Select

    '    Return connectionString

    'End Function


    Public Function GetConnectToMDF() As Boolean
        Return rbtConnectMDF.Checked
    End Function


    Public Function GetConnectToSQLServer() As Boolean
        Return rbtConnectSQLServer.Checked
    End Function


    Public Function GetServerName() As String
        Return txtServerName.Text
    End Function


    Public Function GetDataBase() As String
        Return txtDataBase.Text
    End Function


    Public Function GetUserName() As String
        Return txtUsername.Text
    End Function


    Public Function IsTrustedConnection() As Boolean
        Return cmbAuthentication.SelectedIndex = 0
    End Function


    Public Function GetPassword() As String
        Return txtPassword.Text
    End Function

    ''' <summary>
    ''' Load the Connection String from the Registry
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ConnectionDataBaseForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim value As Object = Nothing
        Dim text As String
        _registry = New RegistryManager()

        'Read registry
        txtServerName.Text = _registry.ReadRegistryValue("Server_Name_DM", value)
        txtDataBase.Text = _registry.ReadRegistryValue("DataBase_DM", value)
        txtUsername.Text = _registry.ReadRegistryValue("UserName_DM", value)
        text = _registry.ReadRegistryValue("AuthenticationMethod_DM", value)

        cmbAuthentication.SelectedIndex = 0
        If Not String.IsNullOrEmpty(text) Then
            cmbAuthentication.SelectedIndex = Integer.Parse(text)
        End If

        If _registry.ReadRegistryValue("ConnectToMDF", value) = "1" Then
            rbtConnectMDF.Checked = True
        Else
            rbtConnectSQLServer.Checked = True
        End If

    End Sub

    Private Sub rbtConnectSQLServer_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtConnectSQLServer.CheckedChanged
        txtServerName.Enabled = rbtConnectSQLServer.Checked
        txtDataBase.Enabled = rbtConnectSQLServer.Checked
        cmbAuthentication.Enabled = rbtConnectSQLServer.Checked

        If rbtConnectSQLServer.Checked Then
            Dim authenticationWindows As Boolean = (cmbAuthentication.SelectedIndex = 0)

            txtUsername.Enabled = Not authenticationWindows
            txtPassword.Enabled = Not authenticationWindows
            lblPassword.Enabled = Not authenticationWindows
            lblUsername.Enabled = Not authenticationWindows
        Else
            txtUsername.Enabled = False
            txtPassword.Enabled = False
            lblPassword.Enabled = False
            lblUsername.Enabled = False

        End If
    End Sub
End Class
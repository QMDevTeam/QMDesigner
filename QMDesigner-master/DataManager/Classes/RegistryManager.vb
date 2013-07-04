Imports Microsoft.Win32

Public Class RegistryManager

    Private _mainKey As RegistryKey

    Public Sub New()
        'check to see if the subkey exists
        _mainKey = Registry.CurrentUser.OpenSubKey("Software\QM\Designer\" & BO.ContextClass.Study.Name.Replace("\", "_"), True)
        If _mainKey Is Nothing Then 'doesnt exist
            'create the subkey
            _mainKey = Registry.CurrentUser.CreateSubKey("Software\QM\Designer\" & BO.ContextClass.Study.Name.Replace("\", "_"), RegistryKeyPermissionCheck.ReadWriteSubTree)
        End If
    End Sub

#Region " Writing Methods "
    ''' <summary>
    ''' Writes a value in the Registry
    ''' </summary>
    ''' <param name="sKeyName">String -> Name of the value to create</param>
    ''' <param name="oNameValue">Object -> Value to be stored</param>
    ''' <returns>True (Succeedeed)/False (Failed)</returns>
    ''' <remarks>Created 23JUN05 -> Richard L. McCutchen</remarks>
    Public Function WriteSubKeyValue(ByVal sKeyName As String, _
                               ByVal oNameValue As Object) As Boolean
        Try
            'set the value of the subkey
            _mainKey.SetValue(sKeyName, oNameValue)
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error: Writing Registry Value", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
#End Region

#Region " Reading Methods "
    ''' <summary>
    ''' Function to read a value from the Registry
    ''' </summary>
    ''' <param name="sKeyName">String -> Name of the value you want to read</param>
    ''' <param name="oNameValue">Object -> The value to be read</param>
    ''' <returns>True (Succeeded)/False (Failed)</returns>
    ''' <remarks>Created 23JUN05 -> Richard L. McCutchen</remarks>
    Public Function ReadRegistryValue(ByVal sKeyName As String, _
                              ByRef oNameValue As Object) As String
        Dim Value As String = ""
        Try
            'get the value
            oNameValue = _mainKey.GetValue(sKeyName)
            If oNameValue Is Nothing Then
                oNameValue = ""
            End If
            Value = oNameValue.ToString
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error: Reading Registry Value", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Value
    End Function
#End Region

End Class


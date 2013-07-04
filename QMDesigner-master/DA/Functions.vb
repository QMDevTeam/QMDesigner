Public Class Functions

    ' Transforms Si, Yes, 1 into true, else false.
    Public Shared Function ToBoolean(ByVal param As String)
        param = param.ToLower.Trim.Replace("|", "")
        Return "SI|YES|1".Contains(param.ToUpper)
    End Function

    ' Transforms boolean into a yes/no string.
    Public Shared Function YesNo(ByVal param As Boolean)
        If param Then
            Return "Yes"
        Else
            Return "No"
        End If
    End Function

    ' Creates a folder if doesn't exists.
    Public Shared Function CreateFolder(ByVal path As String) As Boolean

        If IO.Directory.Exists(path) Then
            Return False
        Else
            IO.Directory.CreateDirectory(path)
            Return True
        End If

    End Function

    ' If string is null or empty returns DBNull.
    Public Shared Function NullableString(ByVal param As String)
        If String.IsNullOrEmpty(param) Then
            Return DBNull.Value
        Else
            Return param
        End If
    End Function


    ' If integer is null returns DBNull.
    Public Shared Function NullableInt(ByVal param As Object)
        If DBNull.Value.Equals(param) Then
            Return Nothing
        ElseIf String.IsNullOrEmpty(param) Then
            Return DBNull.Value
        Else
            Return Convert.ToInt32(param)
        End If
    End Function

    ' If GUID is empty returns DBNull.
    Public Shared Function NullableGuid(ByVal param As Guid)
        If Guid.Empty.Equals(param) Then
            Return DBNull.Value
        Else
            Return param
        End If
    End Function

    ' If datetime is null returns Now.
    Public Shared Function NowIfNullDateTime(ByVal param As String)
        If String.IsNullOrEmpty(param) Then
            Return DateTime.Now
        Else
            Return Convert.ToDateTime(param)
        End If
    End Function

    ' Converts a list into a coma separated string.
    Public Shared Function ListToString(ByVal listOfString As List(Of String), Optional ByVal separator As String = ", ")
        Dim returnString As String = ""


        For Each str As String In listOfString
            returnString = returnString & str.ToString & separator
        Next

        If Not returnString.Length = 0 Then
            returnString = returnString.Substring(0, returnString.Length - separator.Length)
        End If

        Return returnString
    End Function

    ' Copies a file from PDA to PC.
    Public Shared Function CopyFileFromPDAToPC(ByVal LocalPath As String, ByVal RemotePath As String) As Boolean

        Dim connectionToPDA As New OpenNETCF.Desktop.Communication.RAPI

        If connectionToPDA.DevicePresent Then
            connectionToPDA.Connect()
            If connectionToPDA.Connected Then
                If connectionToPDA.DeviceFileExists(RemotePath) Then

                    Dim systemInformation As New OpenNETCF.Desktop.Communication.OSVERSIONINFO
                    connectionToPDA.CopyFileFromDevice(LocalPath, RemotePath, True)
                    'connectiontoPDA.CopyFileToDevice(

                    connectionToPDA.Disconnect()
                    connectionToPDA.Dispose()

                    Return True

                Else
                    Throw New Exception("File dosen't exist")
                End If

            Else
                Throw New Exception("DataManager can't connect to the PDA")
            End If

        Else
            Throw New Exception("No Device Detected")
        End If

        Return False

    End Function


    Public Shared Function CopyFileFromPCToPDA(ByVal LocalPath As String, ByVal RemotePath As String) As Boolean

        Dim connectionToPDA As New OpenNETCF.Desktop.Communication.RAPI

        If connectionToPDA.DevicePresent Then
            connectionToPDA.Connect()
            If connectionToPDA.Connected Then
                If connectionToPDA.DeviceFileExists(RemotePath) Then

                    Dim systemInformation As New OpenNETCF.Desktop.Communication.OSVERSIONINFO
                    connectionToPDA.CopyFileToDevice(LocalPath, RemotePath, True)

                    connectionToPDA.Disconnect()
                    connectionToPDA.Dispose()

                    Return True

                Else
                    Throw New Exception("File dosen't exist")
                End If

            Else
                Throw New Exception("DataManager can't connect to the PDA")
            End If

        Else
            Throw New Exception("No Device Detected")
        End If

        Return False

    End Function


    ' Returns if the file is not reserved and is not a read only file.
    Public Shared Function CanTouchFile(ByVal fileName As String) As Boolean

        Try
            Dim fs As IO.FileStream = IO.File.Open(fileName, IO.FileMode.Append)
            fs.Close()
            fs.Dispose()
            Return (IO.File.GetAttributes(fileName) And IO.FileAttributes.ReadOnly) <> IO.FileAttributes.ReadOnly
        Catch
            Return False
        End Try


    End Function

End Class

Public Class CabBuilder


#Region "Properties"

    Private _outputFolder As String
    Private _files As List(Of String)
    Private _registryValues As Dictionary(Of String, Dictionary(Of String, Object))
    Private _shortName As String
    Private _regValueCount As Integer
    Private _infTempFile As String
    Private _rtfTempFile As String
    Private _studyRegistryKey As String

#End Region



#Region "Public Methods"

    Sub New(ByVal outputFolder As String, ByVal studyShortName As String)

        Me._outputFolder = outputFolder
        Me._shortName = studyShortName

        Me._files = New List(Of String)
        Me._files.Add(String.Format("{0}\{1}.qmd", outputFolder, Me._shortName))
        Me._files.Add(String.Format("{0}\{1}.qmc", outputFolder, Me._shortName))
        Me._files.Add(String.Format("{0}\{1}.QM.dll", outputFolder, Me._shortName))

        Me._studyRegistryKey = String.Format("HKLM\Software\QM\Studies\{0}", Me._shortName)
        Me._registryValues = New Dictionary(Of String, Dictionary(Of String, Object))
        Me._registryValues.Add(Me._studyRegistryKey, New Dictionary(Of String, Object))
        Me._registryValues(Me._studyRegistryKey).Add("SecurityFile", String.Format("\QM\{0}.qms", Me._shortName))
        Me._registryValues(Me._studyRegistryKey).Add("ConfigFile", String.Format("\QM\{0}.qmc", Me._shortName))
        Me._registryValues(Me._studyRegistryKey).Add("DataFile", String.Format("\QM\{0}.qmd", Me._shortName))
        Me._regValueCount = Me._registryValues.Count


    End Sub


    Sub BuildCab()

        ' Build the cab for set up.
        Me.buildSetupFile("")
        Me.buildMakecabFile(Me._shortName & ".QM Setup")
        Me.invokeMakecab()

        ' Build the cab for update.
        For Each file As String In Me._files

            If file.EndsWith(".qmd") Then
                Me._files.Remove(file)
                Exit For
            End If

        Next

        Me._registryValues(Me._studyRegistryKey).Remove("DataFile")
        Me._regValueCount = Me._registryValues.Count
        Me.buildSetupFile("Update")
        Me.buildMakecabFile(Me._shortName & ".QM Update")
        Me.invokeMakecab()

    End Sub


    Sub AddFile(ByVal fileName As String)

        Me._files.Add(fileName)

    End Sub


    Sub AddRegistryValue(ByVal key As String, ByVal valueName As String, ByVal value As Object)

        If Not Me._registryValues.ContainsKey(key) Then Me._registryValues.Add(key, New Dictionary(Of String, Object))

        If Me._registryValues(key).ContainsKey(valueName) Then
            Me._registryValues(key)(valueName) = value
            Me._regValueCount += 1
        Else
            Me._registryValues(key).Add(valueName, value)
        End If

    End Sub

#End Region



#Region "Private Methods"

    Private Sub buildSetupFile(ByVal appSufix As String)

        Dim setupXml As New Xml.XmlDocument()
        setupXml.Load(String.Format("{0}\PDA Files\{1}", My.Application.Info.DirectoryPath, "_setup.xml"))

        setupXml.SelectSingleNode("/wap-provisioningdoc/characteristic[@type=""Install""]/parm[@name=""AppName""]").Attributes("value").Value = Me._shortName & " QM " & appSufix
        setupXml.SelectSingleNode("/wap-provisioningdoc/characteristic[@type=""Install""]/parm[@name=""NumFiles""]").Attributes("value").Value = Me._files.Count.ToString()
        setupXml.SelectSingleNode("/wap-provisioningdoc/characteristic[@type=""Install""]/parm[@name=""NumRegKeys""]").Attributes("value").Value = Me._registryValues.Count.ToString()
        setupXml.SelectSingleNode("/wap-provisioningdoc/characteristic[@type=""Install""]/parm[@name=""NumRegVals""]").Attributes("value").Value = Me._regValueCount.ToString()
        Dim filesNode As Xml.XmlNode = setupXml.SelectSingleNode("/wap-provisioningdoc/characteristic[@type=""FileOperation""]/characteristic[@type=""\QM""]")
        For Each file As String In Me._files

            Dim fileNode As Xml.XmlElement = setupXml.CreateElement("characteristic")
            fileNode.Attributes.Append(setupXml.CreateAttribute("type")).Value = IO.Path.GetFileName(file)
            fileNode.Attributes.Append(setupXml.CreateAttribute("translation")).Value = "install"
            fileNode.AppendChild(setupXml.CreateElement("characteristic"))
            fileNode.ChildNodes(0).Attributes.Append(setupXml.CreateAttribute("type")).Value = "Extract"
            fileNode.ChildNodes(0).AppendChild(setupXml.CreateElement("parm"))
            fileNode.ChildNodes(0).ChildNodes(0).Attributes.Append(setupXml.CreateAttribute("name")).Value = "Source"
            fileNode.ChildNodes(0).ChildNodes(0).Attributes.Append(setupXml.CreateAttribute("value")).Value = IO.Path.GetFileName(file)
            filesNode.AppendChild(fileNode)

        Next

        Dim regNode As Xml.XmlNode = setupXml.SelectSingleNode("/wap-provisioningdoc/characteristic[@type=""Registry""]")
        For Each key As String In Me._registryValues.Keys

            Dim keyNode As Xml.XmlElement = setupXml.CreateElement("characteristic")
            keyNode.Attributes.Append(setupXml.CreateAttribute("type")).Value = key

            For Each valueName As String In Me._registryValues(key).Keys

                Dim valueNode As Xml.XmlElement = setupXml.CreateElement("parm")
                valueNode.Attributes.Append(setupXml.CreateAttribute("name")).Value = valueName
                valueNode.Attributes.Append(setupXml.CreateAttribute("value")).Value = Me._registryValues(key)(valueName).ToString()
                valueNode.Attributes.Append(setupXml.CreateAttribute("datatype")).Value = "string"
                keyNode.AppendChild(valueNode)

            Next
            regNode.AppendChild(keyNode)

        Next

        If IO.File.Exists(Me._outputFolder & "\_setup.xml") Then IO.File.Delete(Me._outputFolder & "\_setup.xml")
        setupXml.Save(Me._outputFolder & "\_setup.xml")

    End Sub


    Private Sub buildMakecabFile(ByVal cabFileName As String)

        Dim reader As New IO.StreamReader(My.Application.Info.DirectoryPath & "\PDA Files\makecab.inf")
        Dim content As String
        content = reader.ReadToEnd()
        reader.Close()
        reader.Dispose()

        Me._infTempFile = IO.Path.GetTempFileName
        Me._rtfTempFile = IO.Path.GetTempFileName
        content = content.Replace("{InfFileName}", Me._infTempFile)
        content = content.Replace("{RtfFileName}", Me._rtfTempFile)
        content = content.Replace("{OutputFolder}", Me._outputFolder)
        content = content.Replace("{CabFileName}", cabFileName)
        For Each file As String In Me._files
            content &= """" & file & """" & Environment.NewLine
        Next
        content &= """" & String.Format("{0}\_setup.xml", Me._outputFolder) & """"

        Dim writer As New IO.StreamWriter(Me._outputFolder & "\makecab.inf", False, Text.Encoding.ASCII)
        writer.Write(content)
        writer.Close()
        writer.Dispose()


    End Sub


    Private Sub invokeMakecab()

        Dim procInfo As New ProcessStartInfo(Environment.GetFolderPath(Environment.SpecialFolder.System) & "\makecab.exe")
        procInfo.Arguments = "/F """ & Me._outputFolder & "\makecab.inf"""
        procInfo.CreateNoWindow = True
        procInfo.UseShellExecute = False
        procInfo.RedirectStandardOutput = True
        procInfo.WorkingDirectory = _outputFolder

        Dim p As Process = Process.Start(procInfo)
        Dim output As String = p.StandardOutput.ReadToEnd()
        p.WaitForExit()

        If IO.File.Exists(Me._infTempFile) Then IO.File.Delete(Me._infTempFile)
        If IO.File.Exists(Me._rtfTempFile) Then IO.File.Delete(Me._rtfTempFile)

    End Sub

#End Region


End Class

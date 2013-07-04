Imports System.Xml
Imports System.Xml.Schema
Imports System.Web

<System.Runtime.InteropServices.ComVisibleAttribute(True)> _
Public Class PreviewControl

#Region " Public Methods "

    ''' <summary>
    ''' Show the preview from a XHTML file
    ''' </summary>
    ''' <param name="XMLPathFile">Path of the XHTML file</param>
    ''' <remarks></remarks>
    Public Sub PreviewFromFile(ByVal XMLPathFile As String)
        webPreview.Navigate(XMLPathFile)
    End Sub

    ''' <summary>
    ''' Save the HTML in a file
    ''' </summary>
    ''' <param name="pathFile"></param>
    ''' <remarks></remarks>
    Public Sub SavePreviewHTML(ByVal pathFile As String)
        If XHTML Is Nothing Then
            MessageBox.Show("Imposible to save.  There is no preview")
        Else
            Dim writer As New System.IO.StreamWriter(pathFile, False, New System.Text.UTF8Encoding())

            writer.Write(IndentXMLString(XHTML).Replace("amp;", ""))

            writer.Close()
            writer.Dispose()

        End If
    End Sub

    ''' <summary>
    ''' Show the preview from a variable
    ''' </summary>
    ''' <param name="currentMyTreeNode"></param>
    ''' <remarks></remarks>
    Public Sub Preview(ByVal currentMyTreeNode As AdvNode)

        UI.PreviewClass.InitPreviewClass()

        ' If there is no currentMyTreeNode then shows nothing
        If currentMyTreeNode Is Nothing Then
            MessageBox.Show("There is an unespected error.  Please select another node.")
            XHTML = New XmlDocument()

            'Must be a Section
        ElseIf currentMyTreeNode.TagType().Equals(GetType(BO.Section)) Then

            XHTML = UI.PreviewClass.GetPreviewOfSection(CType(currentMyTreeNode.Tag, BO.Section), _
                        ckbShowAssignedVariables.Checked, ckbShowVariableName.Checked, ckbShowValues.Checked, _
                        ckbShowConditions.Checked, ckbMetaData.Checked, ckbRoute.Checked, ckbPageBreak.Checked, _
                        ckbHiddenLV.Checked)

            'Or a Questionnaire
        ElseIf currentMyTreeNode.TagType().Equals(GetType(BO.Questionnaire)) Then

            XHTML = UI.PreviewClass.GetPreviewOfQuestionnaire(CType(currentMyTreeNode.Tag, BO.Questionnaire), _
                        ckbShowAssignedVariables.Checked, ckbShowVariableName.Checked, ckbShowValues.Checked, _
                        ckbShowConditions.Checked, ckbMetaData.Checked, ckbRoute.Checked, ckbPageBreak.Checked, _
                        ckbHiddenLV.Checked)

            'Or a SectionItem
        ElseIf currentMyTreeNode.TagType().BaseType.Equals(GetType(BO.SectionItem)) Then

            XHTML = UI.PreviewClass.GetPreviewOfSectionItem(CType(currentMyTreeNode.Tag, BO.SectionItem), _
                        ckbShowAssignedVariables.Checked, ckbShowVariableName.Checked, ckbShowValues.Checked, _
                        ckbShowConditions.Checked, ckbMetaData.Checked, ckbRoute.Checked, ckbPageBreak.Checked, _
                        ckbHiddenLV.Checked)

            'Or a QuestionnaireSet
        ElseIf currentMyTreeNode.TagType().Equals(GetType(BO.QuestionnaireSet)) Then

            XHTML = UI.PreviewClass.GetPreviewOfQuestionnaireSet(CType(currentMyTreeNode.Tag, BO.QuestionnaireSet), _
                        ckbShowAssignedVariables.Checked, ckbShowVariableName.Checked, ckbShowValues.Checked, _
                        ckbShowConditions.Checked, ckbMetaData.Checked, ckbRoute.Checked, ckbPageBreak.Checked, _
                        ckbHiddenLV.Checked)

            'Or a Study
        ElseIf currentMyTreeNode.TagType().Equals(GetType(BO.Study)) Then

            XHTML = UI.PreviewClass.GetPreviewOfStudy(CType(currentMyTreeNode.Tag, BO.Study), _
                        ckbShowAssignedVariables.Checked, ckbShowVariableName.Checked, ckbShowValues.Checked, _
                        ckbShowConditions.Checked, ckbMetaData.Checked, ckbRoute.Checked, ckbPageBreak.Checked, _
                        ckbHiddenLV.Checked)

        Else

            XHTML = New XmlDocument()

        End If

        webPreview.ObjectForScripting = Me
        webPreview.DocumentText = IndentXMLString(XHTML)

    End Sub

    ''' <summary>
    ''' Transform a XML Document to a Indented String of the XML
    ''' </summary>
    ''' <param name="doc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IndentXMLString(ByVal doc As XmlDocument) As String


        Dim outXml As String = String.Empty
        Dim ms As IO.MemoryStream = New IO.MemoryStream()

        ' Create a XMLTextWriter that will send its output to a memory stream (file)
        Dim xtw As XmlTextWriter = New XmlTextWriter(ms, System.Text.Encoding.Unicode)

        Try


            ' Set the formatting property of the XML Text Writer to indented
            ' the text writer is where the indenting will be performed
            xtw.Formatting = Formatting.Indented

            ' write dom xml to the xmltextwriter
            doc.WriteContentTo(xtw)
            ' Flush the contents of the text writer
            ' to the memory stream, which is simply a memory file
            xtw.Flush()

            ' set to start of the memory stream (file)
            ms.Seek(0, IO.SeekOrigin.Begin)
            ' create a reader to read the contents of 
            ' the memory stream (file)
            Dim sr As IO.StreamReader = New IO.StreamReader(ms)

            ' return the formatted string to caller
            Return sr.ReadToEnd().Replace("amp;", "")
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            Return String.Empty
        End Try

    End Function


#End Region


#Region " Private Members "

    Private XHTML As New XmlDocument()

#End Region


End Class

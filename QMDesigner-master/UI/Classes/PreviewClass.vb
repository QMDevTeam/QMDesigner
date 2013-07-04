Imports System.Xml
Imports System.Xml.Schema


Public Class PreviewClass

#Region " Private Members "

    ' Size of the Text
    Private Const _sizeSmallText As Integer = 10
    Private Const _sizeMediumText As Integer = 20

    ' Rows and Columns of the TextArea
    Private Const _rowsTextArea As Integer = 5
    Private Const _columnsTextArea As Integer = 50

    ' Main XML Document
    Private Shared _preview As XmlDocument

    ' Legal Values to Show
    Private Shared _listLegalValuesInPreveiw As List(Of BO.LegalValuesTable)

    ' Indent variables
    Private Const _indentString As String = "&nbsp;&nbsp;&nbsp;&nbsp;"
    Private Shared _indent As New System.Text.StringBuilder("")

    ' Title of Variables and MetaData
    Private Const _assignedVariablesTitle As String = "Assigned Varaibles"
    Private Const _metaDataTitle As String = "MetaData"

    ' Options
    Private Shared _showAssignedVariables As Boolean = False
    Private Shared _showVariables As Boolean = False
    Private Shared _showValues As Boolean = False
    Private Shared _showConditions As Boolean = False
    Private Shared _showMetadata As Boolean = False
    Private Shared _showRoute As Boolean = False
    Private Shared _showHiddenLV As Boolean = False
    Private Shared _pageBreak As Boolean = False

    ' List of Metadata
    Private Shared _listMetaDataQuestionnaireSet As List(Of String)
    Private Shared _listMetaDataQuestionnaire As List(Of String)
    Private Shared _listMetaDataSection As List(Of String)

#End Region

#Region " Public Methods "

    ''' <summary>
    ''' Fill the MetaData Lists
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub InitPreviewClass()

        _listMetaDataQuestionnaireSet = New List(Of String)
        _listMetaDataQuestionnaire = New List(Of String)
        _listMetaDataSection = New List(Of String)

        '  Metadata of QuestionnaireSet
        _listMetaDataQuestionnaireSet.Add("SubjectID")
        _listMetaDataQuestionnaireSet.Add("SubjectSiteID")
        _listMetaDataQuestionnaireSet.Add("SubjectCompletedStudy")
        _listMetaDataQuestionnaireSet.Add("PDAInsertUser")
        _listMetaDataQuestionnaireSet.Add("PDAInsertDate")
        _listMetaDataQuestionnaireSet.Add("PDAInsertVersion")
        _listMetaDataQuestionnaireSet.Add("PDAInsertSN")
        _listMetaDataQuestionnaireSet.Add("PDAInsertPDAName")
        _listMetaDataQuestionnaireSet.Add("PDALastModifUser")
        _listMetaDataQuestionnaireSet.Add("PDALastModifDate")
        _listMetaDataQuestionnaireSet.Add("PDALastModifVersion")
        _listMetaDataQuestionnaireSet.Add("PDALastModifSN")
        _listMetaDataQuestionnaireSet.Add("PDALastModifPDAName")
        _listMetaDataQuestionnaireSet.Add("PDALastUploadUser")
        _listMetaDataQuestionnaireSet.Add("PDALastUploadDate")
        _listMetaDataQuestionnaireSet.Add("PDALastUploadVersion")
        _listMetaDataQuestionnaireSet.Add("PDALastUploadSN")
        _listMetaDataQuestionnaireSet.Add("PDALastUploadPDAName")
        _listMetaDataQuestionnaireSet.Add("SubjectLastScreenID")
        _listMetaDataQuestionnaireSet.Add("SubjectStack")
        _listMetaDataQuestionnaireSet.Add("SASubjectID")
        _listMetaDataQuestionnaireSet.Add("ForDeletion")

        '  Metadata of Questionnaire
        _listMetaDataQuestionnaire.Add("SubjectID")
        _listMetaDataQuestionnaire.Add("SubjectQuestionnaireInstanceID")
        _listMetaDataQuestionnaire.Add("SubjectCompletedRecord")
        _listMetaDataQuestionnaire.Add("PDAInsertUser")
        _listMetaDataQuestionnaire.Add("PDAInsertDate")
        _listMetaDataQuestionnaire.Add("PDAInsertVersion")
        _listMetaDataQuestionnaire.Add("PDAInsertSN")
        _listMetaDataQuestionnaire.Add("PDAInsertPDAName")
        _listMetaDataQuestionnaire.Add("PDALastModifUser")
        _listMetaDataQuestionnaire.Add("PDALastModifDate")
        _listMetaDataQuestionnaire.Add("PDALastModifVersion")
        _listMetaDataQuestionnaire.Add("PDALastModifSN")
        _listMetaDataQuestionnaire.Add("PDALastModifPDAName")
        _listMetaDataQuestionnaire.Add("PDALastUploadUser")
        _listMetaDataQuestionnaire.Add("PDALastUploadDate")
        _listMetaDataQuestionnaire.Add("PDALastUploadVersion")
        _listMetaDataQuestionnaire.Add("PDALastUploadSN")
        _listMetaDataQuestionnaire.Add("PDALastUploadPDAName")
        _listMetaDataQuestionnaire.Add("ForDeletion")

        '  Metadata of Section
        _listMetaDataSection.Add("SubjectID")
        _listMetaDataSection.Add("SubjectQuestionnaireInstanceID")
        _listMetaDataSection.Add("SubjectCompletedRecord")
        _listMetaDataSection.Add("PDAInsertUser")
        _listMetaDataSection.Add("PDAInsertDate")
        _listMetaDataSection.Add("PDAInsertVersion")
        _listMetaDataSection.Add("PDAInsertSN")
        _listMetaDataSection.Add("PDAInsertPDAName")
        _listMetaDataSection.Add("PDALastModifUser")
        _listMetaDataSection.Add("PDALastModifDate")
        _listMetaDataSection.Add("PDALastModifVersion")
        _listMetaDataSection.Add("PDALastModifSN")
        _listMetaDataSection.Add("PDALastModifPDAName")
        _listMetaDataSection.Add("PDALastUploadUser")
        _listMetaDataSection.Add("PDALastUploadDate")
        _listMetaDataSection.Add("PDALastUploadVersion")
        _listMetaDataSection.Add("PDALastUploadSN")
        _listMetaDataSection.Add("PDALastUploadPDAName")
        _listMetaDataSection.Add("ForDeletion")

    End Sub

    ''' <summary>
    ''' Generate HTML Preview from a Study
    ''' </summary>
    ''' <param name="currentStudy"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetPreviewOfStudy(ByVal currentStudy As BO.Study, ByVal showAssignedVariables As Boolean, ByVal showVariables As Boolean, _
                ByVal showValues As Boolean, ByVal showConditions As Boolean, ByVal showMetadata As Boolean, ByVal showRoute As Boolean, _
                ByVal pageBreak As Boolean, ByVal showHiddenLV As Boolean) As XmlDocument

        _showAssignedVariables = showAssignedVariables
        _showVariables = showVariables
        _showValues = showValues
        _showConditions = showConditions
        _showMetadata = showMetadata
        _showRoute = showRoute
        _pageBreak = pageBreak
        _showHiddenLV = showHiddenLV

        Dim body As XmlElement = GetHeaderHTML(currentStudy.Name)


        body.AppendChild(StudyToHTML(currentStudy))
        body.AppendChild(GetFooterHTML)

        Return _preview

    End Function

    ''' <summary>
    ''' Get HTML Preview from QuestionnaireSet
    ''' </summary>
    ''' <param name="currentQuestionnaireSet"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetPreviewOfQuestionnaireSet(ByVal currentQuestionnaireSet As BO.QuestionnaireSet, ByVal showAssignedVariables As Boolean, ByVal showVariables As Boolean, _
                ByVal showValues As Boolean, ByVal showConditions As Boolean, ByVal showMetadata As Boolean, ByVal showRoute As Boolean, _
                ByVal pageBreak As Boolean, ByVal showHiddenLV As Boolean) As XmlDocument
        Dim body As XmlElement = GetHeaderHTML(currentQuestionnaireSet.Name)

        _showAssignedVariables = showAssignedVariables
        _showVariables = showVariables
        _showValues = showValues
        _showConditions = showConditions
        _showMetadata = showMetadata
        _showRoute = showRoute
        _pageBreak = pageBreak
        _showHiddenLV = showHiddenLV

        body.AppendChild(QuestionnaireSetToHTML(currentQuestionnaireSet))
        body.AppendChild(GetFooterHTML)

        Return _preview

    End Function

    ''' <summary>
    ''' Generate HTML Preview from a Questionnaire
    ''' </summary>
    ''' <param name="currentQuestionnaire"></param>
    ''' <returns>Preview in HTML</returns>
    ''' <remarks></remarks>
    Public Shared Function GetPreviewOfQuestionnaire(ByVal currentQuestionnaire As BO.Questionnaire, ByVal showAssignedVariables As Boolean, ByVal showVariables As Boolean, _
                ByVal showValues As Boolean, ByVal showConditions As Boolean, ByVal showMetadata As Boolean, ByVal showRoute As Boolean, _
                ByVal pageBreak As Boolean, ByVal showHiddenLV As Boolean) As XmlDocument

        Dim body As XmlElement = GetHeaderHTML(currentQuestionnaire.Name)

        _showAssignedVariables = showAssignedVariables
        _showVariables = showVariables
        _showValues = showValues
        _showConditions = showConditions
        _showMetadata = showMetadata
        _showRoute = showRoute
        _pageBreak = pageBreak
        _showHiddenLV = showHiddenLV

        body.AppendChild(QuestionnaireToHTML(currentQuestionnaire))
        body.AppendChild(GetFooterHTML)

        Return _preview

    End Function

    ''' <summary>
    '''  Generate HTML Previe from a Section
    ''' </summary>
    ''' <param name="currentSection"></param>
    ''' <returns>Preview in HTML</returns>
    ''' <remarks></remarks>
    Public Shared Function GetPreviewOfSection(ByVal currentSection As BO.Section, ByVal showAssignedVariables As Boolean, ByVal showVariables As Boolean, _
                ByVal showValues As Boolean, ByVal showConditions As Boolean, ByVal showMetadata As Boolean, ByVal showRoute As Boolean, _
                ByVal pageBreak As Boolean, ByVal showHiddenLV As Boolean) As XmlDocument
        Dim body As XmlElement = GetHeaderHTML(currentSection.Name)

        _showAssignedVariables = showAssignedVariables
        _showVariables = showVariables
        _showValues = showValues
        _showConditions = showConditions
        _showMetadata = showMetadata
        _showRoute = showRoute
        _pageBreak = pageBreak
        _showHiddenLV = showHiddenLV

        body.AppendChild(SectionToHTML(currentSection))
        body.AppendChild(GetFooterHTML)

        Return _preview

    End Function

    ''' <summary>
    '''  Generate HTML Preview of a SectionItem
    ''' </summary>
    ''' <param name="currentSectionItem"></param>
    ''' <returns>HTML</returns>
    ''' <remarks></remarks>
    Public Shared Function GetPreviewOfSectionItem(ByVal currentSectionItem As BO.SectionItem, ByVal showAssignedVariables As Boolean, ByVal showVariables As Boolean, _
                ByVal showValues As Boolean, ByVal showConditions As Boolean, ByVal showMetadata As Boolean, ByVal showRoute As Boolean, _
                ByVal pageBreak As Boolean, ByVal showHiddenLV As Boolean) As XmlDocument

        _showAssignedVariables = showAssignedVariables
        _showVariables = showVariables
        _showValues = showValues
        _showConditions = showConditions
        _showMetadata = showMetadata
        _showRoute = showRoute
        _pageBreak = pageBreak
        _showHiddenLV = showHiddenLV

        _preview = New XmlDocument()

        Dim body As XmlElement = GetHeaderHTML(currentSectionItem.Name)
        'Dim memory As New System.IO.MemoryStream()
        Dim Encoding As New System.Text.ASCIIEncoding()


        If (currentSectionItem.GetType().Equals(GetType(BO.Question))) Then
            body.AppendChild(QuestionToHTML(CType(currentSectionItem, BO.Question)))
        End If

        If (currentSectionItem.GetType().Equals(GetType(BO.Information))) Then
            body.AppendChild(InfoToHTML(CType(currentSectionItem, BO.Information)))
        End If

        If (currentSectionItem.GetType().Equals(GetType(BO.CheckPoint))) Then
            body.AppendChild(CheckPointToHTML(CType(currentSectionItem, BO.CheckPoint)))
        End If

        body.AppendChild(GetFooterHTML)

        Return _preview

    End Function

#End Region

#Region " Private Methods "

    ''' <summary>
    ''' Initialize preview XML object and return the reference of the html body
    ''' </summary>
    ''' <param name="titleString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function GetHeaderHTML(ByVal titleString As String) As XmlElement

        _preview = New XmlDocument()
        _listLegalValuesInPreveiw = New List(Of BO.LegalValuesTable)

        Dim html As XmlElement = _preview.CreateElement("html")
        Dim title As XmlElement = _preview.CreateElement("title")
        Dim style As XmlElement = _preview.CreateElement("style")
        Dim body As XmlElement = _preview.CreateElement("body")
        Dim head As XmlElement = _preview.CreateElement("head")
        Dim meta As XmlElement = _preview.CreateElement("meta")
        Dim div As XmlElement = _preview.CreateElement("div")
        Dim script As XmlElement = _preview.CreateElement("script")
        Dim tempAttribute As XmlAttribute

        _preview.AppendChild(html)
        html.AppendChild(head)
        html.AppendChild(body)
        title.InnerText = titleString
        head.AppendChild(title)

        'Stylesheet (CSS2)
        tempAttribute = _preview.CreateAttribute("type")
        tempAttribute.Value = "text/css"
        style.Attributes.Append(tempAttribute)
        style.InnerText = "th { text-align: left}" & _
                          "table { table-layout: fixed;" & _
                                   "border-collapse: collapse}" & _
                          "textarea { overflow: auto }"

        'Attributes of meta
        tempAttribute = _preview.CreateAttribute("http-equiv")
        tempAttribute.Value = "Content-Type"
        meta.Attributes.Append(tempAttribute)
        tempAttribute = _preview.CreateAttribute("content")
        tempAttribute.Value = "text/html;charset=UTF-16"
        meta.Attributes.Append(tempAttribute)

        'JavaScript
        tempAttribute = _preview.CreateAttribute("type")
        tempAttribute.Value = "text/javascript"
        script.Attributes.Append(tempAttribute)
        tempAttribute = _preview.CreateAttribute("language")
        tempAttribute.Value = "javascript"
        script.Attributes.Append(tempAttribute)
        script.InnerText = "function DisplayName(name)" & Environment.NewLine & _
                            "{" & Environment.NewLine & _
                                 "alert(""Welcome "" + name);" & Environment.NewLine & _
                            "}" & Environment.NewLine

        head.AppendChild(style)
        head.AppendChild(meta)
        head.AppendChild(script)

        'Attributes of html
        tempAttribute = _preview.CreateAttribute("xmlns")
        tempAttribute.Value = "http://www.w3.org/1999/xhtml"
        html.Attributes.Append(tempAttribute)
        tempAttribute = _preview.CreateAttribute("lang")
        tempAttribute.Value = "es"
        html.Attributes.Append(tempAttribute)
        tempAttribute = _preview.CreateAttribute("xml:lang")
        tempAttribute.Value = "es"
        html.Attributes.Append(tempAttribute)

        'Attributes of body
        tempAttribute = _preview.CreateAttribute("style")
        tempAttribute.Value = "width:800px;min-width:800px;max-width:800px"
        div.Attributes.Append(tempAttribute)
        body.AppendChild(div)

        'Reset indent levels
        _indent = New System.Text.StringBuilder("")

        Return div

    End Function


    ''' <summary>
    ''' Get the Footer of the HTML
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function GetFooterHTML() As XmlElement

        Dim returnXMLElement As XmlElement = _preview.CreateElement("span")
        Dim trMetaData As XmlElement = _preview.CreateElement("tr")
        Dim thMetaData As XmlElement = _preview.CreateElement("th")
        Dim tdMetaData As XmlElement = _preview.CreateElement("td")
        Dim tableMetaData As XmlElement = _preview.CreateElement("table")
        Dim hr As XmlElement = _preview.CreateElement("hr")
        Dim br As XmlElement = _preview.CreateElement("br")


        returnXMLElement.AppendChild(br)
        returnXMLElement.AppendChild(hr)

        '--Metadata--
        returnXMLElement.AppendChild(GetHTMLOfTitle(3, "Metadata of the Study"))

        'Designer Version
        thMetaData.InnerText = "Designer Version: "
        tdMetaData.InnerText = My.Application.Info.Version.ToString
        trMetaData.AppendChild(thMetaData)
        trMetaData.AppendChild(tdMetaData)
        tableMetaData.AppendChild(trMetaData)

        'Study Version
        thMetaData = _preview.CreateElement("th")
        tdMetaData = _preview.CreateElement("td")
        trMetaData = _preview.CreateElement("tr")

        thMetaData.InnerText = "Study Version: "
        tdMetaData.InnerText = BO.ContextClass.Study.Version
        trMetaData.AppendChild(thMetaData)
        trMetaData.AppendChild(tdMetaData)
        tableMetaData.AppendChild(trMetaData)

        'Date Modified
        thMetaData = _preview.CreateElement("th")
        tdMetaData = _preview.CreateElement("td")
        trMetaData = _preview.CreateElement("tr")

        thMetaData.InnerText = "Date Study Last Modified: "
        tdMetaData.InnerText = BO.ContextClass.Study.lastModification.ToString("MM/dd/yy hh:mm tt")
        trMetaData.AppendChild(thMetaData)
        trMetaData.AppendChild(tdMetaData)
        tableMetaData.AppendChild(trMetaData)

        'Date of Preview 
        thMetaData = _preview.CreateElement("th")
        tdMetaData = _preview.CreateElement("td")
        trMetaData = _preview.CreateElement("tr")

        thMetaData.InnerText = "Date Of Preview: "
        tdMetaData.InnerText = Date.Now.ToString("MM/dd/yy hh:mm tt")
        trMetaData.AppendChild(thMetaData)
        trMetaData.AppendChild(tdMetaData)
        tableMetaData.AppendChild(trMetaData)

        returnXMLElement.AppendChild(tableMetaData)

        If _listLegalValuesInPreveiw.Count > 0 Then

            hr = _preview.CreateElement("hr")
            br = _preview.CreateElement("br")
            returnXMLElement.AppendChild(br)
            returnXMLElement.AppendChild(hr)
            returnXMLElement.AppendChild(br)
            returnXMLElement.AppendChild(br)

            returnXMLElement.AppendChild(GetHTMLOfTitle(1, "LegalValues Tables"))

            _listLegalValuesInPreveiw.Sort(AddressOf CompareLegalValues)

            For Each currentLegalValues As BO.LegalValuesTable In _listLegalValuesInPreveiw

                Dim table As XmlElement = _preview.CreateElement("table")
                Dim borderAttribute As XmlAttribute = _preview.CreateAttribute("border")
                Dim tr As XmlElement = _preview.CreateElement("tr")
                Dim th As XmlElement = _preview.CreateElement("th")
                Dim legalValueCollection As List(Of BO.LegalValueItem) = GetSortedLegalValueCollection(currentLegalValues, AddressOf CompareLegalValueItemsByText)

                borderAttribute.Value = "1"
                table.Attributes.Append(borderAttribute)

                returnXMLElement.AppendChild(GetHTMLOfTitle(3, currentLegalValues.Name))

                th.InnerText = "Name"
                tr.AppendChild(th)
                th = _preview.CreateElement("th")
                th.InnerText = "Value"
                tr.AppendChild(th)
                table.AppendChild(tr)

                'legalValueCollection.Sort(AddressOf CompareLegalValueItemsByText)

                For Each currentLegalValueItem As BO.LegalValueItem In legalValueCollection

                    If _showHiddenLV OrElse Not currentLegalValueItem.Hidden Then

                        tr = _preview.CreateElement("tr")
                        Dim td As XmlElement = _preview.CreateElement("td")
                        Dim td2 As XmlElement = _preview.CreateElement("td")


                        td.InnerText = currentLegalValueItem.Text
                        td2.InnerText = currentLegalValueItem.Value.ToString
                        tr.AppendChild(td)
                        tr.AppendChild(td2)
                        table.AppendChild(tr)

                    End If

                Next
                returnXMLElement.AppendChild(table)

            Next

        End If

        Return returnXMLElement
    End Function


    ''' <summary>
    ''' Get a sorted collection of legalValuesItems
    ''' </summary>
    ''' <param name="currentLegalValues"></param>
    ''' <param name="comparison"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function GetSortedLegalValueCollection(ByVal currentLegalValues As BO.LegalValuesTable, ByVal comparison As System.Comparison(Of BO.LegalValueItem)) As List(Of BO.LegalValueItem)

        Dim legalValueCollection As List(Of BO.LegalValueItem) = New List(Of BO.LegalValueItem)

        For Each currentLegalValueItem As BO.LegalValueItem In currentLegalValues.LegalValues
            legalValueCollection.Add(currentLegalValueItem)
        Next

        legalValueCollection.Sort(comparison)

        Return legalValueCollection
    End Function


    ''' <summary>
    ''' Generate a list of Assigned Variables
    ''' </summary>
    ''' <param name="variables"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function AssignedVariablesToHTML(ByVal variables As List(Of BO.Variable)) As XmlElement
        Dim returnXMLElement As XmlElement = _preview.CreateElement("span")
        ' HTML of one variable
        Dim varHTML As XmlElement
        Dim br As XmlElement

        AddIndentLevel()

        For Each variable As BO.Variable In variables
            br = _preview.CreateElement("br")

            varHTML = _preview.CreateElement("span")
            varHTML.InnerText = String.Format("- {0}", variable.VariableName)

            returnXMLElement.AppendChild(GetIndentSpan())
            returnXMLElement.AppendChild(varHTML)
            returnXMLElement.AppendChild(br)
        Next

        RemoveIndentLevel()

        Return returnXMLElement
    End Function


    ''' <summary>
    ''' Generate a list of MetaData
    ''' </summary>
    ''' <param name="metaData"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function MetaDataToHTML(ByVal metaData As List(Of String)) As XmlElement
        Dim returnXMLElement As XmlElement = _preview.CreateElement("span")
        ' HTML of one variable
        Dim varHTML As XmlElement
        Dim br As XmlElement

        AddIndentLevel()

        For Each currentMetaData As String In metaData
            br = _preview.CreateElement("br")

            varHTML = _preview.CreateElement("span")
            varHTML.InnerText = String.Format("- {0}", currentMetaData)

            returnXMLElement.AppendChild(GetIndentSpan())
            returnXMLElement.AppendChild(varHTML)
            returnXMLElement.AppendChild(br)
        Next

        RemoveIndentLevel()

        Return returnXMLElement
    End Function


    ''' <summary>
    ''' 'Generate HTML Preview from a Study
    ''' </summary>
    ''' <param name="currentStudy"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function StudyToHTML(ByVal currentStudy As BO.Study) As XmlElement
        Dim returnXMLElement As XmlElement = _preview.CreateElement("span")
        Dim idAttribute As XmlAttribute = _preview.CreateAttribute("id")

        idAttribute.Value = String.Format("GUID_{0}", currentStudy.Guid.ToString.Replace("-", ""))
        returnXMLElement.Attributes.Append(idAttribute)

        returnXMLElement.AppendChild(GetIndentSpan())

        ' Name of the Study
        returnXMLElement.AppendChild(GetHTMLOfTitle(1, currentStudy.Name))

        'Add indent Level
        AddIndentLevel()

        ' Add all the QuestionnaireSets
        For Each currentQuestionnaireSet As BO.QuestionnaireSet In currentStudy.QuestionnarieSets

            Dim br As XmlElement = _preview.CreateElement("br")

            returnXMLElement.AppendChild(QuestionnaireSetToHTML(currentQuestionnaireSet))

            returnXMLElement.AppendChild(br)

        Next

        'Remove indent level
        RemoveIndentLevel()

        Return returnXMLElement

    End Function


    ''' <summary>
    ''' Generate HTML Preview from a QuestionnaireSet
    ''' </summary>
    ''' <param name="currentQuestionnaireSet"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function QuestionnaireSetToHTML(ByVal currentQuestionnaireSet As BO.QuestionnaireSet) As XmlElement
        Dim returnXMLElement As XmlElement = _preview.CreateElement("span")
        Dim idAttribute As XmlAttribute = _preview.CreateAttribute("id")

        idAttribute.Value = String.Format("GUID_{0}", currentQuestionnaireSet.Guid.ToString.Replace("-", ""))
        returnXMLElement.Attributes.Append(idAttribute)

        returnXMLElement.AppendChild(GetIndentSpan())

        ' Name of the Questionnaire Set
        returnXMLElement.AppendChild(GetHTMLOfTitle(2, currentQuestionnaireSet.Name))

        ' Add Variables
        If currentQuestionnaireSet.HasVariables And _showAssignedVariables And currentQuestionnaireSet.Variables.Count > 0 Then

            AddIndentLevel()

            returnXMLElement.AppendChild(GetIndentSpan())
            returnXMLElement.AppendChild(GetHTMLOfTitle(3, _assignedVariablesTitle))
            returnXMLElement.AppendChild(AssignedVariablesToHTML(currentQuestionnaireSet.Variables))

            RemoveIndentLevel()

        End If

        ' Add MetaData
        If _showMetadata Then

            AddIndentLevel()

            returnXMLElement.AppendChild(GetIndentSpan())
            returnXMLElement.AppendChild(GetHTMLOfTitle(3, _metaDataTitle))
            returnXMLElement.AppendChild(MetaDataToHTML(_listMetaDataQuestionnaireSet))

            RemoveIndentLevel()

        End If

        'Add indent level
        AddIndentLevel()

        'Add all questionnaires
        For Each currentQuestionnaire As BO.Questionnaire In currentQuestionnaireSet.Questionnaires

            Dim hr As XmlElement = _preview.CreateElement("hr")

            returnXMLElement.AppendChild(hr)
            returnXMLElement.AppendChild(QuestionnaireToHTML(currentQuestionnaire))

        Next

        'Remove Indent Level
        RemoveIndentLevel()

        Return returnXMLElement
    End Function


    ''' <summary>
    ''' Generate HTML Preview from a Questionnaire
    ''' </summary>
    ''' <param name="currentQuestionnaire"></param>
    ''' <returns>HTML</returns>
    ''' <remarks></remarks>
    Private Shared Function QuestionnaireToHTML(ByVal currentQuestionnaire As BO.Questionnaire) As XmlElement

        Dim returnXMLElement As XmlElement = _preview.CreateElement("span")
        Dim idAttribute As XmlAttribute = _preview.CreateAttribute("id")

        idAttribute.Value = String.Format("GUID_{0}", currentQuestionnaire.Guid.ToString.Replace("-", ""))
        returnXMLElement.Attributes.Append(idAttribute)

        returnXMLElement.AppendChild(GetIndentSpan())

        'Name of the Questionnaire
        returnXMLElement.AppendChild(GetHTMLOfTitle(3, currentQuestionnaire.Name))

        ' Assinged Variables
        If currentQuestionnaire.HasVariables And _showAssignedVariables And currentQuestionnaire.Variables.Count > 0 Then

            AddIndentLevel()

            returnXMLElement.AppendChild(GetIndentSpan())
            returnXMLElement.AppendChild(GetHTMLOfTitle(4, _assignedVariablesTitle))
            returnXMLElement.AppendChild(AssignedVariablesToHTML(currentQuestionnaire.Variables))

            RemoveIndentLevel()

        End If

        ' MetaData
        If _showMetadata Then

            AddIndentLevel()

            returnXMLElement.AppendChild(GetIndentSpan())
            returnXMLElement.AppendChild(GetHTMLOfTitle(4, _metaDataTitle))
            returnXMLElement.AppendChild(MetaDataToHTML(_listMetaDataQuestionnaire))

            RemoveIndentLevel()

        End If

        'Add indent Level
        AddIndentLevel()

        ' Add all the sections
        For Each currentSection As BO.Section In currentQuestionnaire.Sections

            returnXMLElement.AppendChild(SectionToHTML(currentSection))

        Next

        ' Remove indent level
        RemoveIndentLevel()

        Return returnXMLElement

    End Function


    ''' <summary>
    ''' Generate HTML Preview from a Section
    ''' </summary>
    ''' <param name="currentSection"></param>
    ''' <returns>HTML</returns>
    ''' <remarks></remarks>
    Private Shared Function SectionToHTML(ByVal currentSection As BO.Section) As XmlElement

        Dim returnXmlElement As XmlElement = _preview.CreateElement("span")
        Dim p As XmlElement = _preview.CreateElement("p")
        Dim classAttribute As XmlAttribute = _preview.CreateAttribute("style")
        Dim idAttribute As XmlAttribute = _preview.CreateAttribute("id")

        idAttribute.Value = String.Format("GUID_{0}", currentSection.Guid.ToString.Replace("-", ""))
        returnXmlElement.Attributes.Append(idAttribute)

        'Write the section's name
        returnXmlElement.AppendChild(GetIndentSpan())
        returnXmlElement.AppendChild(GetHTMLOfTitle(4, currentSection.Name))

        ' Assinged Variables
        If currentSection.HasVariables And _showAssignedVariables And currentSection.Variables.Count > 0 Then

            AddIndentLevel()

            returnXmlElement.AppendChild(GetIndentSpan())
            returnXmlElement.AppendChild(GetHTMLOfTitle(5, _assignedVariablesTitle))
            returnXmlElement.AppendChild(AssignedVariablesToHTML(currentSection.Variables))

            RemoveIndentLevel()

        End If


        ' MetaData
        If _showMetadata Then

            AddIndentLevel()

            returnXmlElement.AppendChild(GetIndentSpan())
            returnXmlElement.AppendChild(GetHTMLOfTitle(5, _metaDataTitle))
            returnXmlElement.AppendChild(MetaDataToHTML(_listMetaDataSection))

            RemoveIndentLevel()

        End If

        ' Body of the Section
        returnXmlElement.AppendChild(PhasesToHTML(currentSection.SectionItems))


        If _pageBreak Then

            classAttribute.Value = "page-break-before: always"
            p.Attributes.Append(classAttribute)
            returnXmlElement.AppendChild(p)

        End If

        Return returnXmlElement

    End Function


    ''' <summary>
    ''' Generate HTML Preview from a list of Phases
    ''' </summary>
    ''' <param name="Phases">List of Phases to use</param>
    ''' <returns>HTML</returns>
    ''' <remarks>It will have a indent of _indentPixels pixels</remarks>
    Private Shared Function PhasesToHTML(ByVal Phases As List(Of BO.SectionItem)) As XmlElement

        Dim returnXmlElement As XmlElement = _preview.CreateElement("span")

        ' Add a indent level
        AddIndentLevel()

        For Each currentPhase As BO.SectionItem In Phases

            'Verify if currentPhase is a Information
            If (currentPhase.GetType.Equals(GetType(BO.Information))) Then
                returnXmlElement.AppendChild(InfoToHTML(CType(currentPhase, BO.Information)))
            End If
            'Verify if currentPhase is a Question
            If (currentPhase.GetType.Equals(GetType(BO.Question))) Then
                returnXmlElement.AppendChild(QuestionToHTML(CType(currentPhase, BO.Question)))
            End If
            'Verify if currentPhase is a CheckPoint
            If (currentPhase.GetType.Equals(GetType(BO.CheckPoint))) Then
                returnXmlElement.AppendChild(CheckPointToHTML(CType(currentPhase, BO.CheckPoint)))
            End If

        Next

        RemoveIndentLevel()

        Return returnXmlElement

    End Function


    ''' <summary>
    ''' Generate HTML Preview from a Information
    ''' </summary>
    ''' <param name="currentInfo"></param>
    ''' <returns>HTML</returns>
    ''' <remarks>Only shows the MainText of the currentInfo</remarks>
    Private Shared Function InfoToHTML(ByVal currentInfo As BO.Information) As XmlElement

        Dim returnSpan As XmlElement = _preview.CreateElement("span")
        Dim route As XmlElement = _preview.CreateElement("span")
        Dim bold As XmlElement = _preview.CreateElement("b")
        Dim br As XmlElement = _preview.CreateElement("br")
        Dim idAttribute As XmlAttribute = _preview.CreateAttribute("id")

        idAttribute.Value = String.Format("GUID_{0}", currentInfo.Guid.ToString.Replace("-", ""))
        returnSpan.Attributes.Append(idAttribute)

        returnSpan.AppendChild(GetIndentSpan())

        If _showRoute Then
            route.AppendChild(TextToSmallGrayHTML(GetRoute(currentInfo)))
            returnSpan.AppendChild(route)
        End If

        bold.InnerText = String.Format("{0}) {1}", currentInfo.Number, TextToHTMLText(currentInfo.MainText))
        returnSpan.AppendChild(bold)

        returnSpan.AppendChild(br)

        Return returnSpan

    End Function


    ''' <summary>
    ''' Generate HTML Preview from a Question
    ''' </summary>
    ''' <param name="currentQuestion"></param>
    ''' <returns>HTML</returns>
    ''' <remarks>It use ScreenTemplateToHTML function</remarks>
    Private Shared Function QuestionToHTML(ByVal currentQuestion As BO.Question) As XmlElement

        Dim returnXmlElement As XmlElement = _preview.CreateElement("span")
        Dim route As XmlElement = _preview.CreateElement("span")
        Dim bold As XmlElement = _preview.CreateElement("b")
        Dim br As XmlElement = _preview.CreateElement("br")
        Dim variableName As XmlElement = _preview.CreateElement("span")
        Dim temp As XmlElement
        Dim idAttribute As XmlAttribute = _preview.CreateAttribute("id")

        idAttribute.Value = String.Format("GUID_{0}", currentQuestion.Guid.ToString.Replace("-", ""))
        returnXmlElement.Attributes.Append(idAttribute)

        returnXmlElement.AppendChild(GetIndentSpan())

        If _showRoute Then
            route.AppendChild(TextToSmallGrayHTML(GetRoute(currentQuestion)))
            returnXmlElement.AppendChild(route)
        End If

        bold.InnerText = String.Format("{0}) {1} {2} ", currentQuestion.Number, _
                        TextToHTMLText(currentQuestion.GroupText), TextToHTMLText(currentQuestion.MainText))
        returnXmlElement.AppendChild(bold)

        If (_showVariables And Not String.IsNullOrEmpty(currentQuestion.VariableName) And Not currentQuestion.ScreenTemplate.ToLower = "checkbox") AndAlso Not String.IsNullOrEmpty(currentQuestion.VariableName.Trim) Then
            variableName.AppendChild(TextToSmallGrayHTML(String.Format("({0})", currentQuestion.VariableName)))
            returnXmlElement.AppendChild(variableName)
        End If
        returnXmlElement.AppendChild(br)

        If (currentQuestion.Visible) Then
            temp = ScreenTemplateToHTML(currentQuestion)
            If temp IsNot Nothing Then
                returnXmlElement.AppendChild(temp)
                br = _preview.CreateElement("br")
                returnXmlElement.AppendChild(br)
            End If
        End If


        Return returnXmlElement

    End Function


    ''' <summary>
    ''' Generate HTML Preview from a CheckPoint
    ''' </summary>
    ''' <param name="currentCheckPoint"></param>
    ''' <returns>HTML</returns>
    ''' <remarks>Add a indent to the childs of the CheckPoint</remarks>
    Private Shared Function CheckPointToHTML(ByVal currentCheckPoint As BO.CheckPoint) As XmlElement

        Dim returnXmlElement As XmlElement = _preview.CreateElement("span")
        Dim route As XmlElement = _preview.CreateElement("span")
        Dim bold As XmlElement = _preview.CreateElement("b")
        Dim span As XmlElement = _preview.CreateElement("span")
        Dim condition As XmlElement = _preview.CreateElement("span")
        Dim br As XmlElement = _preview.CreateElement("br")
        Dim conditionString As String
        Dim idAttribute As XmlAttribute = _preview.CreateAttribute("id")

        idAttribute.Value = String.Format("GUID_{0}", currentCheckPoint.Guid.ToString.Replace("-", ""))
        returnXmlElement.Attributes.Append(idAttribute)

        returnXmlElement.AppendChild(GetIndentSpan())

        If _showRoute Then
            route.AppendChild(TextToSmallGrayHTML(GetRoute(currentCheckPoint)))
            returnXmlElement.AppendChild(route)
        End If

        bold.InnerText = String.Format("{0}) {1}", currentCheckPoint.Number, TextToHTMLText(currentCheckPoint.MainText))
        returnXmlElement.AppendChild(bold)

        If (_showConditions And Not String.IsNullOrEmpty(currentCheckPoint.Condition) _
        AndAlso Not String.IsNullOrEmpty(currentCheckPoint.Condition.Replace("@", "").Trim)) Then
            'Agregar Condition 
            conditionString = String.Format(" ({0})", currentCheckPoint.Condition.Replace("@", "").Trim)
            If Not currentCheckPoint.BranchIf Then

                conditionString &= " is False"

            End If

            condition.AppendChild(TextToSmallGrayHTML(conditionString))
            returnXmlElement.AppendChild(condition)
        End If

        returnXmlElement.AppendChild(br)

        span.AppendChild(PhasesToHTML(currentCheckPoint.SectionItems))
        returnXmlElement.AppendChild(span)

        Return returnXmlElement

    End Function


    ''' <summary>
    ''' Generate HTML Preview from the Template of the Question
    ''' </summary>
    ''' <param name="CurrentQuestion"></param>
    ''' <returns>HTML</returns>
    ''' <remarks></remarks>
    Private Shared Function ScreenTemplateToHTML(ByVal CurrentQuestion As BO.Question) As XmlElement

        Dim returnXmlElement As XmlElement = _preview.CreateElement("span")
        Dim currentLegalValues As BO.LegalValuesTable

        ' Add an indent level
        AddIndentLevel()

        Select Case CurrentQuestion.ScreenTemplate

            Case "GPSReading"
                If _showVariables Then

                    '--------Variable DecLat---------
                    returnXmlElement.AppendChild(GetIndentSpan)
                    returnXmlElement.AppendChild(TextToSmallGrayHTML(String.Format("- {0}DecLat", CurrentQuestion.VariableName)))
                    returnXmlElement.AppendChild(_preview.CreateElement("br"))
                    '--------------------------------

                    '--------Variable DecLon---------
                    returnXmlElement.AppendChild(GetIndentSpan)
                    returnXmlElement.AppendChild(TextToSmallGrayHTML(String.Format("- {0}DecLon", CurrentQuestion.VariableName)))
                    returnXmlElement.AppendChild(_preview.CreateElement("br"))
                    '--------------------------------

                    '--------Variable Lat---------
                    returnXmlElement.AppendChild(GetIndentSpan)
                    returnXmlElement.AppendChild(TextToSmallGrayHTML(String.Format("- {0}Lat", CurrentQuestion.VariableName)))
                    returnXmlElement.AppendChild(_preview.CreateElement("br"))
                    '--------------------------------

                    '--------Variable Lon---------
                    returnXmlElement.AppendChild(GetIndentSpan)
                    returnXmlElement.AppendChild(TextToSmallGrayHTML(String.Format("- {0}Lon", CurrentQuestion.VariableName)))
                    returnXmlElement.AppendChild(_preview.CreateElement("br"))
                    '--------------------------------

                    '--------Variable PDOP---------
                    returnXmlElement.AppendChild(GetIndentSpan)
                    returnXmlElement.AppendChild(TextToSmallGrayHTML(String.Format("- {0}PDOP", CurrentQuestion.VariableName)))
                    returnXmlElement.AppendChild(_preview.CreateElement("br"))
                    '--------------------------------

                    '--------Variable HDOP---------
                    returnXmlElement.AppendChild(GetIndentSpan)
                    returnXmlElement.AppendChild(TextToSmallGrayHTML(String.Format("- {0}HDOP", CurrentQuestion.VariableName)))
                    returnXmlElement.AppendChild(_preview.CreateElement("br"))
                    '--------------------------------

                    '--------Variable Sat---------
                    returnXmlElement.AppendChild(GetIndentSpan)
                    returnXmlElement.AppendChild(TextToSmallGrayHTML(String.Format("- {0}Sat", CurrentQuestion.VariableName)))
                    returnXmlElement.AppendChild(_preview.CreateElement("br"))
                    '--------------------------------

                End If

            Case "ViCoSubjectID"
                returnXmlElement.AppendChild(GetIndentSpan)
                returnXmlElement.AppendChild(GetInput("text", "", "", "", _sizeSmallText.ToString))

            Case "TextArea"
                returnXmlElement.AppendChild(GetIndentSpan)
                Dim textArea As XmlElement = _preview.CreateElement("textarea")
                Dim rows As XmlAttribute = _preview.CreateAttribute("rows")
                Dim cols As XmlAttribute = _preview.CreateAttribute("cols")

                rows.Value = _rowsTextArea.ToString
                cols.Value = _columnsTextArea.ToString

                textArea.Attributes.Append(rows)
                textArea.Attributes.Append(cols)
                textArea.InnerText = " "

                returnXmlElement.AppendChild(textArea)

            Case "TextBox"
                returnXmlElement.AppendChild(GetIndentSpan)
                returnXmlElement.AppendChild(GetMediumTextInput)

            Case "Integer"
                returnXmlElement.AppendChild(GetIndentSpan)
                returnXmlElement.AppendChild(GetMediumTextInput)

            Case "Decimal"
                returnXmlElement.AppendChild(GetIndentSpan)
                returnXmlElement.AppendChild(GetMediumTextInput)

            Case "Name"
                returnXmlElement.AppendChild(GetIndentSpan)
                returnXmlElement.AppendChild(GetMediumTextInput)

            Case "DropDown"
                returnXmlElement.AppendChild(GetIndentSpan)

                ' We get the information of legal values
                currentLegalValues = BO.Study.GetLegalValuesByName(CurrentQuestion.LegalValueTable)

                'Create the select tag and the span of the Legal Values
                Dim selectTag As XmlElement = _preview.CreateElement("select")
                Dim span As XmlElement = _preview.CreateElement("span")
                If Not currentLegalValues Is Nothing Then

                    'If it's a new LegaValue then add it to the list
                    If Not _listLegalValuesInPreveiw.Contains(currentLegalValues) Then
                        _listLegalValuesInPreveiw.Add(currentLegalValues)
                    End If


                    'The legal Value is the first option in the dropdown

                    Dim optionHtml As XmlElement = _preview.CreateElement("option")
                    Dim value As XmlAttribute = _preview.CreateAttribute("value")

                    value.Value = "-1"

                    optionHtml.InnerText = TextToHTMLText(currentLegalValues.Name)
                    optionHtml.Attributes.Append(value)

                    selectTag.AppendChild(optionHtml)

                    'Sort the options

                    'Dim legalValueCollection As List(Of BO.LegalValueItem) = GetLegalValueCollection(currentLegalValues)
                    ' legalValueCollection.Sort(AddressOf CompareLegalValueItemsByValue)

                    'Generate the options of the dropdown

                    For Each currentLegalValueItem As BO.LegalValueItem In currentLegalValues.LegalValues

                        If _showHiddenLV OrElse Not currentLegalValueItem.Hidden Then

                            optionHtml = _preview.CreateElement("option")
                            value = _preview.CreateAttribute("value")


                            value.Value = currentLegalValueItem.Value.ToString

                            If _showValues Then
                                optionHtml.InnerText = TextToHTMLText(String.Format("{0} - {1}", currentLegalValueItem.Text, currentLegalValueItem.Value.ToString))
                            Else
                                optionHtml.InnerText = TextToHTMLText(currentLegalValueItem.Text)

                            End If
                            optionHtml.Attributes.Append(value)

                            selectTag.AppendChild(optionHtml)

                        End If

                    Next
                    returnXmlElement.AppendChild(selectTag)
                    'span.InnerText = " (LegalValues Table " & TextToHTMLText(currentLegalValues.Name) & ")"
                    returnXmlElement.AppendChild(span)
                End If

            Case "RadioButtons"

                currentLegalValues = BO.Study.GetLegalValuesByName(CurrentQuestion.LegalValueTable)

                If currentLegalValues IsNot Nothing Then

                    'Generate the options of the dropdown

                    For Each currentLegalValueItem As BO.LegalValueItem In currentLegalValues.LegalValues

                        If _showHiddenLV OrElse Not currentLegalValueItem.Hidden Then

                            Dim span As XmlElement = _preview.CreateElement("span")

                            Dim br As XmlElement = _preview.CreateElement("br")


                            span.InnerText = TextToHTMLText(currentLegalValueItem.Text)
                            returnXmlElement.AppendChild(GetIndentSpan)
                            returnXmlElement.AppendChild(GetInput("radio", "", TextToHTMLText(currentLegalValues.Name), currentLegalValueItem.Value.ToString))
                            returnXmlElement.AppendChild(span)
                            If _showValues Then
                                returnXmlElement.AppendChild(TextToSmallGrayHTML(" - " & currentLegalValueItem.Value.ToString))
                            End If
                            returnXmlElement.AppendChild(br)

                        End If

                    Next
                End If
            Case "Date"
                returnXmlElement.AppendChild(GetIndentSpan)
                returnXmlElement.AppendChild(GetMediumTextInput)
            Case "DateTime"
                returnXmlElement.AppendChild(GetIndentSpan)
                returnXmlElement.AppendChild(GetMediumTextInput)
            Case "Time"
                returnXmlElement.AppendChild(GetIndentSpan)
                returnXmlElement.AppendChild(GetMediumTextInput)
            Case "CheckBox"
                currentLegalValues = BO.Study.GetLegalValuesByName(CurrentQuestion.LegalValueTable)

                If currentLegalValues IsNot Nothing Then

                    'Generate the options of the dropdown

                    For Each currentLegalValueItem As BO.LegalValueItem In currentLegalValues.LegalValues

                        If _showHiddenLV OrElse Not currentLegalValueItem.Hidden Then

                            Dim span As XmlElement = _preview.CreateElement("span")
                            Dim br As XmlElement = _preview.CreateElement("br")

                            span.InnerText = TextToHTMLText(currentLegalValueItem.Text)
                            returnXmlElement.AppendChild(GetIndentSpan)
                            returnXmlElement.AppendChild(GetInput("checkbox", "", "", currentLegalValueItem.ShortName.ToString))
                            returnXmlElement.AppendChild(span)
                            If _showVariables Then
                                returnXmlElement.AppendChild(TextToSmallGrayHTML(String.Format(" - {0}{1}", CurrentQuestion.VariableName, currentLegalValueItem.ShortName.ToString)))
                            End If
                            returnXmlElement.AppendChild(br)

                        End If
                    Next

                End If
            Case "Info"
                'Do nothing
            Case "SectionExitScreen"
                'Do nothing

        End Select

        'Remove indent level
        RemoveIndentLevel()

        Return returnXmlElement
    End Function


    ''' <summary>
    ''' Get a text input of medium size
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function GetMediumTextInput() As XmlElement

        Return GetInput("text", "", "", "", _sizeMediumText.ToString)

    End Function


    ''' <summary>
    ''' Get a input of any type
    ''' </summary>
    ''' <param name="typeString"></param>
    ''' <param name="idString"></param>
    ''' <param name="nameString"></param>
    ''' <param name="valueString"></param>
    ''' <param name="sizeString">Optional</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function GetInput(ByVal typeString As String, ByVal idString As String, ByVal nameString As String, ByVal valueString As String, Optional ByVal sizeString As String = "") As XmlElement

        Dim input As XmlElement = _preview.CreateElement("input")
        Dim type As XmlAttribute = _preview.CreateAttribute("type")
        Dim size As XmlAttribute = _preview.CreateAttribute("size")
        Dim name As XmlAttribute = _preview.CreateAttribute("name")
        Dim value As XmlAttribute = _preview.CreateAttribute("value")
        Dim id As XmlAttribute = _preview.CreateAttribute("id")


        type.Value = typeString
        size.Value = sizeString
        name.Value = nameString
        value.Value = valueString
        id.Value = idString


        input.Attributes.Append(type)
        input.Attributes.Append(value)
        input.Attributes.Append(name)
        input.Attributes.Append(id)
        If Not sizeString = "" Then
            input.Attributes.Append(size)
        End If

        Return input
    End Function


    ''' <summary>
    ''' Add an Indent Level to the paragraph
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared Sub AddIndentLevel()

        ' Add an indent level
        _indent.Append(_indentString)

    End Sub


    ''' <summary>
    ''' Remove an indent level
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared Sub RemoveIndentLevel()

        'Remove indent level
        RemoveChars(_indent, _indentString.Length)

    End Sub


    ''' <summary>
    ''' Get a XMLElement with the Indent white spaces.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function GetIndentSpan() As XmlElement
        Dim indentSpan As XmlElement = _preview.CreateElement("span")
        indentSpan.InnerText = _indent.ToString()
        Return indentSpan
    End Function


    ''' <summary>
    ''' Remove characters from a StringBuilder
    ''' </summary>
    ''' <param name="s"></param>
    ''' <param name="count"></param>
    ''' <remarks></remarks>
    Private Shared Sub RemoveChars(ByRef s As System.Text.StringBuilder, ByVal count As Integer)
        If s.Length > count Then
            s.Remove(s.Length - count, count)
        Else
            s.Remove(0, s.Length)
        End If
    End Sub


    ''' <summary>
    ''' Funtion used to Sort a collections of legalValues by the ToString
    ''' </summary>
    ''' <param name="legalValues1"></param>
    ''' <param name="legalValues2"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CompareLegalValues(ByVal legalValues1 As BO.LegalValuesTable, ByVal legalValues2 As BO.LegalValuesTable) As Integer
        Return legalValues1.ToString.CompareTo(legalValues2.ToString)
    End Function


    ''' <summary>
    ''' Function used to Sort a collections of legalValues by Text
    ''' </summary>
    ''' <param name="legalValueItems1"></param>
    ''' <param name="legalValueItems2"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CompareLegalValueItemsByText(ByVal legalValueItems1 As BO.LegalValueItem, ByVal legalValueItems2 As BO.LegalValueItem) As Integer
        Return legalValueItems1.Text.CompareTo(legalValueItems2.Text)
    End Function


    ''' <summary>
    ''' Function used to Sort a collection of legalValues by value
    ''' </summary>
    ''' <param name="legalValueItems1"></param>
    ''' <param name="legalValueItems2"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CompareLegalValueItemsByValue(ByVal legalValueItems1 As BO.LegalValueItem, ByVal legalValueItems2 As BO.LegalValueItem) As Integer
        Return legalValueItems1.Value.CompareTo(legalValueItems2.Value)
    End Function


    ''' <summary>
    ''' Convert the unfriendly-HTML Text to a friendly-HTML Text
    ''' </summary>
    ''' <param name="text"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function TextToHTMLText(ByVal text As String) As String

        Return System.Web.HttpUtility.HtmlEncode(text)

    End Function


    ''' <summary>
    ''' Get a HTML of a title
    ''' </summary>
    ''' <param name="h">the h# of the title</param>
    ''' <param name="title"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function GetHTMLOfTitle(ByVal h As Integer, ByVal title As String)

        Dim b As XmlElement = _preview.CreateElement("b")
        Dim font As XmlElement = _preview.CreateElement("font")
        Dim size As XmlAttribute = _preview.CreateAttribute("size")
        Dim br1 As XmlElement = _preview.CreateElement("br")
        Dim br2 As XmlElement = _preview.CreateElement("br")
        Dim returnXMLElement As XmlElement = _preview.CreateElement("span")
        Dim sizeValue As Integer = 7 - h

        size.Value = sizeValue.ToString
        font.Attributes.Append(size)
        b.InnerText = TextToHTMLText(title)
        font.AppendChild(b)
        returnXMLElement.AppendChild(font)
        returnXMLElement.AppendChild(br1)
        returnXMLElement.AppendChild(br2)

        Return returnXMLElement

    End Function


    ''' <summary>
    ''' Get the HTML of the variable name  (Color Gray and Small)
    ''' </summary>
    ''' <param name="text"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function TextToSmallGrayHTML(ByVal text As String) As XmlElement
        Dim returnHTML As XmlElement = _preview.CreateElement("font")
        Dim small As XmlElement = _preview.CreateElement("small")
        Dim color As XmlAttribute = _preview.CreateAttribute("color")

        color.Value = "gray"
        returnHTML.Attributes.Append(color)

        small.InnerText = TextToHTMLText(text)
        returnHTML.AppendChild(small)

        Return returnHTML
    End Function

    Private Shared Function GetRoute(ByVal phase As BO.SectionItem) As String

        Dim parent As BO.GenericObject = phase.Parent
        Dim route As String = " "

        While Not TypeOf parent Is BO.Study

            If TypeOf parent Is BO.Section Or _
               TypeOf parent Is BO.Questionnaire Or _
               TypeOf parent Is BO.QuestionnaireSet Then

                route = "-" & parent.Name & route

            End If

            parent = parent.Parent

        End While

        Return route.Substring(1)

    End Function

#End Region

End Class

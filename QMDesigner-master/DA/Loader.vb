Imports System.Data.SqlServerCe

Public Class Loader


#Region "Properties"

    Private Shared Conn As SqlCeConnection
    Private Shared sectionItemCollectionStack As Stack(Of List(Of BO.SectionItem))
    Private Shared parentStack As Stack(Of Object)
    Private Shared CompleteDictionary As Dictionary(Of Guid, Dictionary(Of String, Dictionary(Of Integer, String)))
    Private Shared checkDesignerVersion As Boolean
    Private Shared filename As String

    ' Current objects.
    Private Shared study As BO.Study
    Private Shared questionnaireSet As BO.QuestionnaireSet
    Private Shared questionnaire As BO.Questionnaire
    Private Shared section As BO.Section

#End Region



#Region "Methods"


    ''' <summary>
    ''' Set connection parameters.
    ''' </summary>
    ''' <param name="path"></param>
    ''' <param name="password"></param>
    ''' <remarks>Initializes the connection to the database.</remarks>

    Private Shared Sub InitConnection(ByVal path As String, ByVal password As String)

        ' Copy the file to a temp folder.
        filename = IO.Path.GetTempFileName()
        IO.File.Delete(filename)
        IO.File.Copy(path, filename)
        IO.File.SetAttributes(filename, IO.FileAttributes.Normal)

        ' Skip the designer version check if the qm file is empty study.
        checkDesignerVersion = Not IO.Path.GetFileName(path).Equals("Empty Study.sdf")

        ' Build the connection string.
        Dim connectionString As String = String.Format("DataSource={0};", filename)
        If Not String.IsNullOrEmpty(password) Then connectionString &= String.Format("Password = {0};", password)
        connectionString &= "Persist Security Info=False;"

        ' Creates the connection object.
        Conn = New SqlCeConnection(connectionString)
        Conn.Open()

    End Sub


    ''' <summary>
    ''' Closes the connection and deletes temp files.
    ''' </summary>
    ''' <remarks></remarks>

    Private Shared Sub EndConnection()

        Conn.Close()
        Conn.Dispose()
        IO.File.Delete(filename)

    End Sub


    ''' <summary>
    ''' Check Structure compatibility.
    ''' </summary>
    ''' <returns>True if the structures are compatible.</returns>
    ''' <remarks>Compares the designer version in the study with the current version.</remarks>

    Public Shared Function CheckStructureCompatibility() As Boolean

        Dim getVersion As New SqlCeCommand("SELECT DesignerVersion FROM Study", Conn)
        Dim studyVersion As String = getVersion.ExecuteScalar()
        If studyVersion <> My.Application.Info.Version.ToString Then

            Dim versionsMsg As String = "The QM file you are atempting to open was created by Designer " & studyVersion & "." & vbCrLf & _
            "Do you want to try to open it in Designer " & My.Application.Info.Version.ToString & "?"

            Return MessageBox.Show(versionsMsg, "warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes

        Else

            Return True

        End If
    End Function


    ''' <summary>
    ''' Loads the study info into a study.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Shared Function GetStudy(ByVal path As String, Optional ByVal password As String = Nothing) As BO.Study

        ' Start connection.
        InitConnection(path, password)

        ' Retrieve the information from the study table.
        Dim studyDataAdapter As New SqlCeDataAdapter("SELECT * FROM Study", Conn)
        Dim studyTable As New DataTable
        studyDataAdapter.Fill(studyTable)

        ' If the file is Empty Study, skip the structure compatibility check.
        If checkDesignerVersion AndAlso Not CheckStructureCompatibility() Then Return Nothing

        ' Set initial config to language collection.
        BO.Study.LanguageList = GetLanguageList()

        ' Load the dictionary from the database.
        LoadFullDictionary()

        ' Set the default language.
        Try
            BO.ContextClass.CurrentLanguage = BO.Study.LanguageList(studyTable.Rows(0)("currentLanguageID"))
        Catch exception As Exception
        End Try

        If studyTable.Rows.Count > 0 Then

            Dim studyRow As DataRow = studyTable.Rows(0)
            BO.Study.LegalValues = GetLegalValuesCollection()
            BO.Study.Methods = getMethodCollection()
            BO.Study.ScreenTemplates = getScreenTemplates()
            BO.Study.Sites = getSites()
            BO.Study.PDAUsers = getPDAUserList()
            BO.Study.Files = getFiles()
            BO.Study.Reports = getReports()

            ' Set the study properties.
            study = New BO.Study(True)
            study.Name = studyRow("name")
            study.Guid = studyRow("studyGuid")
            study.ShortName = studyRow("shortName").ToString()
            study.setVersion(studyRow("version"))
            study.Comment = studyRow("Comment").ToString
            study.setCreationDateTime(Functions.NowIfNullDateTime(studyRow("CreationDateTime").ToString))
            study.setLastModificationDateTime(Functions.NowIfNullDateTime(studyRow("LastModificationDateTime").ToString))
            study.NameDictionary = GetDictionary(study.Guid, "Name")
            study.DataTableSchema = studyRow("DataSchema").ToString
            study.LogTableSchema = studyRow("LogSchema").ToString
            study.LegalValuesTableSchema = studyRow("LVSchema").ToString
            study.AnalysisViewsSchema = studyRow("AnalysisSchema").ToString

            ' Add the questionnairesets.
            For Each qs As BO.QuestionnaireSet In GetQuestionnaireSetCollection()

                study.QuestionnarieSets.Add(qs)

            Next

        End If

        ' Sets the QMFileName.
        study.QMFileName = path

        ' Close connection.
        EndConnection()

        ' Return value.
        Return study

    End Function


    ''' <summary>
    ''' Gets the list of PDA users.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Private Shared Function getPDAUserList() As List(Of BO.PDAUser)

        ' Get the data.
        Dim getPDAUsers As New SqlCeDataAdapter("SELECT * FROM PDAUser ORDER BY [Order]", Conn)
        Dim usersTable As New DataTable
        getPDAUsers.Fill(usersTable)

        ' Build collection.
        Dim result As New List(Of BO.PDAUser)
        For Each row As DataRow In usersTable.Rows

            Dim usr As New BO.PDAUser
            usr.PDAUserName = row("PDAUserName").ToString()
            usr.PDAPassword = row("PDAPassword").ToString()
            usr.Name = row("Name").ToString()
            usr.RoleName = row("RoleName").ToString()
            usr.DefaultSiteID = Functions.NullableInt(row("DefaultSiteID"))
            result.Add(usr)

        Next

        ' Return.
        Return result

    End Function


    ''' <summary>
    ''' Gets the languageList collection from the database.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Private Shared Function GetLanguageList() As List(Of BO.Language)

        ' Get the data.
        Dim getLanguages As New SqlCeDataAdapter("SELECT * FROM languages ORDER BY languageId", Conn)
        Dim langTable As New DataTable
        getLanguages.Fill(langTable)

        ' Build collection.
        Dim result As New List(Of BO.Language)
        For Each row As DataRow In langTable.Rows
            result.Add(New BO.Language(row("languageID"), row("language")))
        Next

        ' return.
        Return result
    End Function


    ''' <summary>
    ''' Gets the legal values collection from the database.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Private Shared Function GetLegalValuesCollection() As List(Of BO.LegalValuesTable)

        Dim legalValuesDataAdapter As New SqlCeDataAdapter("SELECT * FROM LegalValueItem WHERE LegalValueTableGuid = @LegalValueTableGuid ORDER BY [order]", Conn)

        ' Retrieve the list of names from the database metadata.
        Dim legalValueTablesDA As New SqlCeDataAdapter("SELECT * FROM LegalValueTable", Conn)
        Dim legalValueTables As New DataTable
        legalValueTablesDA.Fill(legalValueTables)

        ' Build the collection.
        Dim legalValuesCollection As New List(Of BO.LegalValuesTable)
        For Each LegalValueTableRow As DataRow In legalValueTables.Rows

            Try
                ' Set the properties.
                Dim legalValues As New BO.LegalValuesTable
                legalValues.Name = LegalValueTableRow("Name")
                legalValues.Guid = LegalValueTableRow("LegalValueTableGuid")

                ' Get the data for each collection.
                With legalValuesDataAdapter.SelectCommand.Parameters
                    .Clear()
                    .Add("@LegalValueTableGuid", SqlDbType.UniqueIdentifier).Value = legalValues.Guid
                End With
                Dim legalValuesTable As New DataTable
                legalValuesDataAdapter.Fill(legalValuesTable)

                'Build the inner collection.
                For Each legalValueRow As DataRow In legalValuesTable.Rows

                    ' Set the properties.
                    Dim legalValue As New BO.LegalValueItem
                    legalValue.Guid = legalValueRow("LegalValueItemGuid")
                    legalValue.Value = legalValueRow("Value").ToString
                    legalValue.Text = legalValueRow("Text").ToString
                    legalValue.ShortName = legalValueRow("ShortName").ToString
                    legalValue.Group = legalValueRow("Group").ToString
                    legalValue.TextDictionary = GetDictionary(legalValue.Guid, "Text")
                    legalValue.Hidden = legalValueRow("hidden")

                    ' Add it to the inner collection.
                    legalValues.LegalValues.Add(legalValue)
                Next

                ' Add the legalValues to the collection.
                legalValuesCollection.Add(legalValues)

            Catch ex As Exception
                MessageBox.Show(String.Format("Legal value '{0}' can't be loaded. {1}{2}", LegalValueTableRow("Name"), vbCrLf, ex.Message))

            End Try
        Next

        ' Return the value.
        Return legalValuesCollection
    End Function


    ''' <summary>
    ''' Gets the methods from the database.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Private Shared Function getMethodCollection() As List(Of BO.Method)

        Dim methodCollection As New List(Of BO.Method)
        Dim methodDataAdapter As New SqlCeDataAdapter("SELECT * FROM method WHERE MethodGuid IS NOT NULL", Conn)
        Dim methodsTable As New DataTable
        methodDataAdapter.Fill(methodsTable)

        For Each methodRow As DataRow In methodsTable.Rows

            Dim method As New BO.Method()
            method.Guid = methodRow("MethodGuid")
            method.Name = methodRow("Name")
            'method.Type = methodRow("Type")
            method.Code = methodRow("Code")

            methodCollection.Add(method)

        Next

        Return methodCollection

    End Function


    ''' <summary>
    ''' Gets the screen templates from the database.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Private Shared Function getScreenTemplates() As List(Of BO.ScreenTemplate)

        ' Retrieve the template data from the database.
        Dim templateDataAdapter As New SqlCeDataAdapter("SELECT * FROM ScreenTemplate", Conn)
        Dim templateTable As New DataTable
        templateDataAdapter.Fill(templateTable)

        ' Build the collection.
        Dim screenTemplates As New List(Of BO.ScreenTemplate)
        For Each row As DataRow In templateTable.Rows

            ' Set the screen template properties.
            Dim template As New BO.ScreenTemplate
            template.Name = row("ScreenTemplateName").ToString
            template.DataType = row("DataType").ToString
            template.DotNetClassName = row("DotNetClassName").ToString
            template.DataBaseID = row("ScreenTemplateID")
            template.VariableNameRequired = row("VariableNameReq")

            ' Add the template to the collection.
            screenTemplates.Add(template)
        Next

        ' Return the collection.
        Return screenTemplates

    End Function


    ''' <summary>
    ''' Gets the sites information.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Private Shared Function getSites() As List(Of BO.Site)

        ' Retreve the data from the database.
        Dim siteDataAdapter As New SqlCeDataAdapter("SELECT * FROM Site", Conn)
        Dim siteTable As New DataTable
        siteDataAdapter.Fill(siteTable)

        ' Build Collection.
        Dim sites As New List(Of BO.Site)
        For Each row As DataRow In siteTable.Rows

            ' Set the site properties.
            Dim site As New BO.Site
            site.DataBaseID = row("SiteID")
            site.Name = row("Name")
            site.Code = row("Code")

            ' Add the site to the list.
            sites.Add(site)
        Next

        ' Return the collection.
        Return sites
    End Function


    ''' <summary>
    ''' Gets the file references from the database.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Private Shared Function getFiles() As List(Of BO.File)

        ' Retrieve the files data from the database.
        Dim fileDataAdapter As New SqlCeDataAdapter("SELECT * FROM [File]", Conn)
        Dim fileTable As New DataTable
        fileDataAdapter.Fill(fileTable)

        ' Build the collection.
        Dim files As New List(Of BO.File)
        For Each row As DataRow In fileTable.Rows

            ' Set the file properties.
            Dim file As New BO.File(row("FileGuid"))
            file.ReferencePath = row("ReferencePath").ToString
            file.Name = row("Name").ToString
            file.CodeNamespace = row("CodeNamespace").ToString

            ' Add the template to the collection.
            files.Add(file)
        Next

        ' Return the collection.
        Return files

    End Function


    ''' <summary>
    ''' Gets the reports from the database.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Private Shared Function getReports() As List(Of BO.Report)

        ' Data adapter for the report columns.
        Dim reportColDataAdapter As New SqlCeDataAdapter("SELECT * FROM ReportColumn WHERE ReportGuid = @ReportGuid", Conn)
        reportColDataAdapter.SelectCommand.Parameters.Add("ReportGuid", SqlDbType.UniqueIdentifier).Value = Nothing

        ' Data adapter for the report sites.
        Dim reportsiteDataAdapter As New SqlCeDataAdapter("SELECT * FROM ReportSite WHERE ReportGuid = @ReportGuid", Conn)
        reportsiteDataAdapter.SelectCommand.Parameters.Add("ReportGuid", SqlDbType.UniqueIdentifier).Value = Nothing

        ' Retrieve the reports from the database.
        Dim reportDataAdapter As New SqlCeDataAdapter("SELECT * FROM Report", Conn)
        Dim reportTable As New DataTable
        reportDataAdapter.Fill(reportTable)

        ' Build the collection.
        Dim reports As New List(Of BO.Report)
        For Each reportRow As DataRow In reportTable.Rows

            ' Set the report properties.
            Dim report As New BO.Report(reportRow("ReportGuid"))
            report.Name = reportRow("Name")
            report.ReportType = reportRow("ReportType")
            report.FormTypeName = reportRow("FormTypeName").ToString
            report.Query = reportRow("Query").ToString

            ' Get the report columns from the database.
            reportColDataAdapter.SelectCommand.Parameters.Item("ReportGuid").Value = report.Guid
            Dim reportColTable As New DataTable
            reportColDataAdapter.Fill(reportColTable)

            ' Build the column collection.
            For Each reportColRow As DataRow In reportColTable.Rows

                ' Set the report column properties.
                Dim reportCol As New BO.ReportColumn(reportColRow("ReportColumnGuid"))
                reportCol.Name = reportColRow("Name").ToString
                reportCol.HeaderText = reportColRow("HeaderText").ToString
                reportCol.Width = reportColRow("Width")
                reportCol.Format = reportColRow("Format").ToString

                ' Add the column to the report.
                report.Columns.Add(reportCol)

            Next

            ' Get the report sites from the database.
            reportsiteDataAdapter.SelectCommand.Parameters.Item("ReportGuid").Value = report.Guid
            Dim reportSiteTable As New DataTable
            reportsiteDataAdapter.Fill(reportSiteTable)

            ' Build the site collection.
            For Each siteColRow As DataRow In reportSiteTable.Rows

                ' Add the site to the report.
                report.SiteCodes.Add(siteColRow("SiteCode"))

            Next

            ' Add the report to the list.
            reports.Add(report)

        Next

        ' Return the list.
        Return reports

    End Function


    ''' <summary>
    ''' Loads the questionnaireSets collection to the study.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Private Shared Function GetQuestionnaireSetCollection() As List(Of BO.QuestionnaireSet)

        ' Retrieve the information from the questionnaireset table.
        Const Query As String = "SELECT * FROM QuestionnaireSet ORDER BY [Order]"
        Dim questionnaireSetDataAdapter As New SqlCeDataAdapter(Query, Conn)
        Dim questionnaireSetTable As New DataTable
        questionnaireSetDataAdapter.Fill(questionnaireSetTable)

        ' Build the questionnaireSet collection.
        Dim questionnaireSetCollection As New List(Of BO.QuestionnaireSet)
        For Each row As DataRow In questionnaireSetTable.Rows

            ' Set the questionnaire properties.
            questionnaireSet = New BO.QuestionnaireSet(row("QuestionnaireSetID"))
            questionnaireSet.Guid = row("QuestionnaireSetGuid")
            questionnaireSet.Name = row("Name")
            questionnaireSet.ShortName = row("ShortName")
            questionnaireSet.PreCondition = row("Precondition").ToString()
            questionnaireSet.SubjectSecondaryIdField = row("SubjectSecondaryIdField").ToString()
            questionnaireSet.SubjectAlternativeSearchField = row("SubjectAlternativeSearchField").ToString
            questionnaireSet.SubjectConfirmationFields = row("SubjectConfirmationFields").ToString()
            questionnaireSet.NewSubjectSectionID = Functions.NullableInt(row("NewSubjectSectionID"))
            questionnaireSet.OnNewSubject = row("OnNewSubject").ToString
            questionnaireSet.Comment = row("Comment").ToString
            questionnaireSet.NameDictionary = GetDictionary(questionnaireSet.Guid, "Name")
            questionnaireSet.DataTableName = row("dataTable").ToString
            questionnaireSet.LogTableName = row("logTable").ToString

            ' Update the contextClass.
            BO.ContextClass.CurrentQuestionnaireSet = questionnaireSet

            ' Get the questionnaires.
            For Each questionnaire As BO.Questionnaire In GetQuestionnaireCollection(questionnaireSet.DataBaseID)
                questionnaireSet.Questionnaires.Add(questionnaire)
            Next

            ' Add the questionnaireset to the collection.
            questionnaireSetCollection.Add(questionnaireSet)
        Next

        ' Return the value.
        Return questionnaireSetCollection
    End Function


    ''' <summary>
    ''' Loads the questionnaires collection to the study.
    ''' </summary>
    ''' <param name="QuestionnaireSetId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Private Shared Function GetQuestionnaireCollection(ByVal QuestionnaireSetId As Integer) As List(Of BO.Questionnaire)

        ' Retrieve the information from the questionnaire table.
        Const Query As String = "SELECT * FROM Questionnaire where QuestionnaireSetID = {0} order by [order]"
        Dim questionnaireDataAdapter As New SqlCeDataAdapter(String.Format(Query, QuestionnaireSetId), Conn)
        Dim questionnaireTable As New DataTable
        questionnaireDataAdapter.Fill(questionnaireTable)

        ' Build the questionnaire collection.
        Dim questionnaireCollection As New List(Of BO.Questionnaire)
        For Each row As DataRow In questionnaireTable.Rows

            ' Set the questionnaire properties.
            questionnaire = New BO.Questionnaire(row("QuestionnaireId"))
            questionnaire.Guid = row("QuestionnaireGuid")
            questionnaire.Name = row("Name").ToString
            questionnaire.ShortName = row("ShortName").ToString
            questionnaire.PreCondition = row("Precondition").ToString
            questionnaire.Comment = row("Comment").ToString
            questionnaire.MultipleInstances = row("MultipleInstances")
            questionnaire.InstanceSAIDField = row("InstanceSAIDField").ToString()
            questionnaire.InstanceSecondaryIDField = row("InstanceSecondaryIDField").ToString()
            questionnaire.OnNewRecord = row("OnNewRecord").ToString
            questionnaire.NameDictionary = GetDictionary(questionnaire.Guid, "Name")
            questionnaire.DataTableName = row("dataTable").ToString
            questionnaire.LogTableName = row("logTable").ToString
            ' Get the questionnare sections.
            For Each section As BO.Section In GetSectionCollection(questionnaire.DataBaseID, questionnaire.ShortName)
                questionnaire.Sections.Add(section)
            Next

            ' Add the questionnaire to the collection.
            questionnaireCollection.Add(questionnaire)
        Next

        ' Return the value.
        Return questionnaireCollection

    End Function


    ''' <summary>
    ''' Loads the sections from a questionnaire.
    ''' </summary>
    ''' <param name="questionnaireId"></param>
    ''' <param name="questionnaireShortName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Private Shared Function GetSectionCollection(ByVal questionnaireId As Integer, ByVal questionnaireShortName As String) As List(Of BO.Section)

        ' Retrieve the information from the section table.
        Const Query As String = "SELECT * FROM section WHERE QuestionnaireID = {0} ORDER BY [order]"
        Dim sectionDataAdapter As New SqlCeDataAdapter(String.Format(Query, questionnaireId), Conn)
        Dim sectionTable As New DataTable
        sectionDataAdapter.Fill(sectionTable)

        ' Build the section collection.
        Dim sectionCollection As New List(Of BO.Section)
        For Each row As DataRow In sectionTable.Rows

            ' Set the section properties.
            section = New BO.Section(row("SectionID"))
            section.Guid = row("SectionGuid")
            section.Name = row("Name").ToString
            section.ShortName = row("ShortName").ToString
            section.Modifiable = row("Modifiable").ToString
            section.PreCondition = row("PreCondition").ToString
            section.Comment = row("Comment").ToString
            section.OnNewRecord = row("OnNewRecord").ToString
            section.NameDictionary = GetDictionary(section.Guid, "Name")
            section.DataTableName = row("dataTable").ToString
            section.LogTableName = row("logTable").ToString
            ' Get the section items collection.
            Dim tableName As String = questionnaireShortName & section.ShortName
            For Each sectionItem As BO.SectionItem In GetSectionItemsCollection(section)
                section.SectionItems.Add(sectionItem)
            Next

            ' Add the section to the collection.
            sectionCollection.Add(section)
        Next

        ' Return the value.
        Return sectionCollection

    End Function


    ''' <summary>
    ''' Loads the section items from a section.
    ''' </summary>
    ''' <param name="section"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Private Shared Function GetSectionItemsCollection(ByVal section As BO.Section) As List(Of BO.SectionItem)

        ' Retreve the information from the "tableName" table.
        Dim questionDataAdapter As New SqlCeDataAdapter("SELECT * FROM SectionItem WHERE SectionID = @SectionID ORDER BY ordinal", Conn)

        questionDataAdapter.SelectCommand.Parameters.Add("@SectionID", SqlDbType.Int).Value = section.DataBaseID
        Dim questionTable As New DataTable
        questionDataAdapter.Fill(questionTable)

        ' Build the section items collection.
        Dim currentLevel As Integer = 1
        sectionItemCollectionStack = New Stack(Of List(Of BO.SectionItem))
        sectionItemCollectionStack.Push(New List(Of BO.SectionItem))
        parentStack = New Stack(Of Object)
        parentStack.Push(section)


        For Each row As DataRow In questionTable.Rows

            ' Set the current level.
            currentLevel = row("Level")
            Dim sectionItem As BO.SectionItem = Nothing

            Select Case row("type").ToString().ToLower
                Case "question"
                    ' Add question.
                    sectionItem = toQuestion(row)
                    AddSectionItem(sectionItem, currentLevel)

                    CType(sectionItem, BO.Question).HelpTextDictionary = GetDictionary(sectionItem.Guid, "HelpText")
                    CType(sectionItem, BO.Question).GroupTextDictionary = GetDictionary(sectionItem.Guid, "GroupText")
                    CType(sectionItem, BO.Question).CustomValidationFailMessageDictionary = GetDictionary(sectionItem.Guid, "CustomValidationFailMessage")

                Case "variable"
                    ' Set the variable properties.
                    Dim variable As New BO.Variable(toQuestion(row))
                    variable.MainTextDictionary = GetDictionary(variable.Guid, "MainText")
                    If variable.Scope = BO.VariableScopes.QuestionnaireSet Then
                        questionnaireSet.Variables.Add(variable)

                    ElseIf variable.Scope = BO.VariableScopes.Questionnaire Then
                        questionnaire.Variables.Add(variable)

                    ElseIf variable.Scope = BO.VariableScopes.Section Then
                        section.Variables.Add(variable)

                    End If

                Case "checkpoint"
                    ' Set the checkpoint properties.
                    Dim checkpoint As New BO.CheckPoint()
                    sectionItem = checkpoint
                    checkpoint.SetParent(parentStack.Peek())
                    checkpoint.Guid = row("SectionItemGuid")
                    checkpoint.MainText = row("MainText")
                    checkpoint.BranchIf = row("BranchIf")
                    checkpoint.Condition = row("Condition")
                    checkpoint.Comment = row("Comment").ToString
                    checkpoint.Number = row("Number").ToString
                    checkpoint.NameDictionary = GetDictionary(checkpoint.Guid, "Name")

                    ' Add checkpoint.
                    AddSectionItem(checkpoint, currentLevel)

                    ' Push the collection into the stack.
                    sectionItemCollectionStack.Push(checkpoint.SectionItems)
                    parentStack.Push(checkpoint)

                Case "info"
                    ' Set the info properties.
                    sectionItem = toInformation(row)
                    AddSectionItem(sectionItem, currentLevel)

                Case "beginning"
                    ' Beginning type.

                Case "end"
                    ' End type.
            End Select

            If sectionItem IsNot Nothing Then
                sectionItem.NameDictionary = GetDictionary(sectionItem.Guid, "Name")
                sectionItem.MainTextDictionary = GetDictionary(sectionItem.Guid, "MainText")
            End If

        Next

        ' Pops until having only one collection.
        While sectionItemCollectionStack.Count > 1

            sectionItemCollectionStack.Pop()
        End While

        ' Return the collection.
        Return sectionItemCollectionStack.Pop()
    End Function


    ''' <summary>
    ''' Converts a row into a BO.Question.
    ''' </summary>
    ''' <param name="row"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Shared Function toQuestion(ByVal row As DataRow)

        Dim question As New BO.Question()
        question.Guid = row("SectionItemGuid")
        question.Visible = IIf(DBNull.Value.Equals(row("visible")), False, row("visible"))
        question.MainText = row("MainText").ToString
        question.GroupMember = row("GroupMember")
        question.GroupText = row("GroupText").ToString
        question.SetVariableName(row("VariableName").ToString)
        question.ScreenTemplate = row("ScreenTemplate").ToString
        question.VariableScope = Convert.ToInt32(row("VariableScope"))
        question.Arguments = row("Arguments").ToString
        question.HelpText = row("HelpText").ToString
        question.Required = row("Required")
        question.AbsoluteMinimum = row("AbsMin").ToString
        question.AbsoluteMaximum = row("AbsMax").ToString
        question.PromptUnder = row("PromptUnder").ToString
        question.PromptOver = row("PromptOver").ToString
        question.LegalValueTable = row("LegalValueTable").ToString
        question.CustomValidation = row("CustomValidation").ToString
        question.CustomValidationFailMessage = row("CustomValidationFailMessage").ToString
        question.ConfirmChange = row("ConfirmChange")
        question.HideNext = row("HideNext")
        question.HideBack = row("HideBack")
        question.ConfirmNext = row("ConfirmNext")
        question.ConfirmBack = row("ConfirmBack")
        question.Comment = row("Comment").ToString
        question.Number = row("Number").ToString
        question.OnLoad = row("OnLoad").ToString
        question.OnUnload = row("OnUnload").ToString
        question.OnChange = row("OnChange").ToString

        Return question
    End Function


    ''' <summary>
    ''' Converts a row into a BO.Information.
    ''' </summary>
    ''' <param name="row"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Shared Function toInformation(ByVal row As DataRow)

        Dim info As New BO.Information()
        info.Guid = row("SectionItemGuid")
        'info.visible = row("visible")
        info.MainText = row("MainText").ToString
        info.HideNext = row("HideNext")
        info.HideBack = row("HideBack")
        info.Comment = row("Comment").ToString
        info.Number = row("Number").ToString
        info.OnLoad = row("OnLoad").ToString
        info.OnUnload = row("OnUnload").ToString

        Return info
    End Function


    ''' <summary>
    ''' Adds the section item into its corresponding level.
    ''' </summary>
    ''' <param name="sectionItem"></param>
    ''' <param name="currentLevel"></param>
    ''' <remarks></remarks>

    Private Shared Sub AddSectionItem(ByVal sectionItem As BO.SectionItem, ByVal currentLevel As Integer)

        While currentLevel < sectionItemCollectionStack.Count
            sectionItemCollectionStack.Pop()
            parentStack.Pop()
        End While

        sectionItem.SetParent(parentStack.Peek())
        sectionItemCollectionStack.Peek().Add(sectionItem)

    End Sub


    ''' <summary>
    ''' Gets the dictionary for an specific property.
    ''' </summary>
    ''' <param name="uniqueID"></param>
    ''' <param name="propertyName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Private Shared Function GetDictionary(ByVal uniqueID As Guid, ByVal propertyName As String) As Dictionary(Of Integer, String)

        If CompleteDictionary.ContainsKey(uniqueID) AndAlso CompleteDictionary(uniqueID).ContainsKey(propertyName) Then
            Return CompleteDictionary(uniqueID)(propertyName)
        Else
            Return New Dictionary(Of Integer, String)
        End If
    End Function


    ''' <summary>
    ''' Pre loads the full dictionary.
    ''' </summary>
    ''' <remarks></remarks>

    Private Shared Sub LoadFullDictionary()

        Dim dataAdapter As New SqlCeDataAdapter("SELECT * FROM dictionary", Conn)
        Dim dataTable As New DataTable
        dataAdapter.Fill(dataTable)

        CompleteDictionary = New Dictionary(Of Guid, Dictionary(Of String, Dictionary(Of Integer, String)))

        For Each row As DataRow In dataTable.Rows

            Dim guid As Guid = row("guid")
            Dim propertyName As String = row("propertyName")
            Dim languageId As Integer = row("languageId")
            Dim text As String = row("text")

            Dim propertyDictionary As Dictionary(Of String, Dictionary(Of Integer, String))

            If CompleteDictionary.ContainsKey(guid) Then
                propertyDictionary = CompleteDictionary(guid)
            Else
                propertyDictionary = New Dictionary(Of String, Dictionary(Of Integer, String))
                CompleteDictionary.Add(guid, propertyDictionary)
            End If

            Dim languageDictionary As Dictionary(Of Integer, String)

            If propertyDictionary.ContainsKey(propertyName) Then
                languageDictionary = propertyDictionary(propertyName)
            Else
                languageDictionary = New Dictionary(Of Integer, String)
                propertyDictionary.Add(propertyName, languageDictionary)
            End If

            languageDictionary.Item(languageId) = text

        Next

    End Sub


#End Region

End Class

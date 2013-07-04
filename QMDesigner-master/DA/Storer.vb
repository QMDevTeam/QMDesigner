Imports System.Data.SqlServerCe
Imports System.IO

Public Class Storer

    ' Variables.
    Private Shared Conn As SqlCeConnection
    Private Shared fileName As String
    Private Shared templateConnection As New SqlCeConnection(String.Format("DataSource={0}Empty Study.sdf", AppDomain.CurrentDomain.BaseDirectory))

    Private Shared QuestionnaireDA As SqlCeDataAdapter
    Private Shared SectionDA As SqlCeDataAdapter
    Private Shared SectionItemDA As SqlCeDataAdapter
    Private Shared DictionaryDA As SqlCeDataAdapter

    Private Shared QuestionnaireTable As DataTable
    Private Shared SectionTable As DataTable
    Private Shared SectionItemTable As DataTable
    Private Shared DictionaryTable As DataTable

    ''' <summary>
    ''' Creates the data adapter with all its internal configuration.
    ''' </summary>
    ''' <param name="tableName">Name of the table.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Private Shared Function CreateDataAdapter(ByVal tableName As String) As SqlCeDataAdapter

        Dim da As New SqlCeDataAdapter(String.Format("SELECT * FROM [{0}]", tableName), Conn)
        Dim cb As New SqlCeCommandBuilder(da)

        da.UpdateCommand = cb.GetUpdateCommand
        da.InsertCommand = cb.GetInsertCommand
        da.DeleteCommand = cb.GetDeleteCommand

        Return da

    End Function


    ' Initializes the connection to the database.
    Private Shared Sub SetConnectionParams(ByVal path As String, ByVal password As String)

        ' Build the connection string.
        Dim connectionString As String = String.Format("DataSource={0};", path)
        If Not String.IsNullOrEmpty(password) Then connectionString &= String.Format("Password = {0};", password)

        ' Creates the connection object.
        Conn = New SqlCeConnection(connectionString)

        ' Sets the fileName.
        fileName = path

    End Sub


    ' Saves the study info into a study.
    Public Shared Sub SaveStudy(ByVal study As BO.Study, ByVal filename As String, Optional ByVal password As String = Nothing)

        SetConnectionParams(filename, password)

        ' Change the last modification date time.
        study.setLastModificationDateTime(DateTime.Now)

        ' Creates the database.
        CreateDataBase()

        ' Open database connection.
        Conn.Open()

        ' Copy the empty data base.
        CopyEmptyDatabase()

        ' Create the structure data adapters.
        QuestionnaireTable = New DataTable()
        QuestionnaireDA = CreateDataAdapter("Questionnaire")
        QuestionnaireDA.FillSchema(QuestionnaireTable, SchemaType.Source)

        SectionTable = New DataTable()
        SectionDA = CreateDataAdapter("Section")
        SectionDA.FillSchema(SectionTable, SchemaType.Source)

        SectionItemTable = New DataTable()
        SectionItemDA = CreateDataAdapter("SectionItem")
        SectionItemDA.FillSchema(SectionItemTable, SchemaType.Source)

        DictionaryTable = New DataTable()
        DictionaryDA = CreateDataAdapter("Dictionary")
        DictionaryDA.FillSchema(DictionaryTable, SchemaType.Source)

        ' Insert the study into de database.
        InsertStudy(study)

        ' Sets the QMFileName.
        study.QMFileName = Conn.DataSource

        ' Commit changes.
        QuestionnaireDA.Update(QuestionnaireTable)
        SectionDA.Update(SectionTable)
        SectionItemDA.Update(SectionItemTable)
        DictionaryDA.Update(DictionaryTable)

        ' Send the connection to the logManager.
        Conn.Close()
        Conn.Dispose()

    End Sub


    ' Deletes the file if exists and creates the database.
    Private Shared Sub CreateDataBase()

        ' Deletes the file if exists.
        If File.Exists(fileName) Then System.IO.File.Delete(fileName)

        ' Creates the database.
        Dim engine As New SqlCeEngine(Conn.ConnectionString)
        engine.CreateDatabase()
        engine.Dispose()

    End Sub


#Region "Copy the database template."

    ' Creates an exact copy from the empty database into the new one.
    Private Shared Sub CopyEmptyDatabase()

        ' Create table query.
        Const createTableQuery As String = "CREATE TABLE [{0}]({1} {2})"

        ' List all the tables in the empty database.
        Dim tableDataAdapter As New SqlCeDataAdapter("select table_name as TableName from information_schema.tables where table_type = 'TABLE' and table_name not like 'LV_%'", templateConnection)
        Dim tableTable As New DataTable
        tableDataAdapter.Fill(tableTable)

        ' Build the CREATE TABLE queries.
        For Each tableRow As DataRow In tableTable.Rows

            ' Set the query params.
            Dim tableName As String = tableRow("TableName")

            ' Get columns and constraints.
            Dim columns As String = GetColumns(tableName)
            Dim constraints As String = GetConstraints(tableName)

            ' Build the table.
            Dim createTableCommand As New SqlCeCommand(String.Format(createTableQuery, tableName, columns, constraints), Conn)
            createTableCommand.ExecuteNonQuery()

        Next

    End Sub

    ' Gets all the column names and types from a single table.
    Private Shared Function GetColumns(ByVal tableName As String) As String

        Dim selectColumnsQuery As String = "select column_name, column_hasdefault, column_default, is_nullable, data_type, character_maximum_length from information_schema.columns where table_name = '{0}' order by ordinal_position"
        Dim columns As String = ""
        Dim columnDataAdapter As New SqlCeDataAdapter(String.Format(selectColumnsQuery, tableName), templateConnection)
        Dim columnTable As New DataTable
        columnDataAdapter.Fill(columnTable)

        ' Get the column list.
        For Each columnRow As DataRow In columnTable.Rows
            ' Column name.
            columns = columns & ", [" & columnRow("column_name").ToString & "] "

            If columnRow("data_type").ToString.ToLower.Equals("ntext") OrElse columnRow("character_maximum_length") Is System.DBNull.Value Then
                ' Column type without size.
                columns = columns & columnRow("data_type").ToString & " "
            Else
                ' Column type with size.
                columns = columns & columnRow("data_type").ToString & "(" & columnRow("character_maximum_length").ToString & ") "
            End If

            ' Column with default value.
            If columnRow("column_hasdefault") Then columns = columns & "Default " & columnRow("column_default")

            ' Column is nullable.
            If Not Functions.ToBoolean(columnRow("is_nullable")) Then columns = columns & "not null"
        Next

        Return columns.Remove(0, 2)
    End Function

    ' Gets all the constraints from a single table.
    Private Shared Function GetConstraints(ByVal tableName As String) As String

        Const selectConstraintsQuery As String = "select constraint_name, constraint_type, is_deferrable, initially_deferred from information_schema.table_constraints where table_name = '{0}'"
        Dim constraints As String = ""
        Dim constraintDataAdapter As New SqlCeDataAdapter(String.Format(selectConstraintsQuery, tableName), templateConnection)
        Dim constraintTable As New DataTable
        constraintDataAdapter.Fill(constraintTable)

        ' Build the constraints.
        For Each constraintRow As DataRow In constraintTable.Rows

            Dim constraintName As String = constraintRow("constraint_name")
            Dim constraintType As String = constraintRow("constraint_type")
            constraints = constraints & ", Constraint [" & constraintName & "] " & constraintType & " "

            ' Complete the constraint sentence by type.
            Select Case constraintRow("constraint_type")
                Case "PRIMARY KEY"
                    constraints = constraints & "(" & GetPrimaryKeyParams(constraintName) & ")"
            End Select
        Next

        ' Returns the value.
        Return constraints
    End Function

    ' Gets all the column names that belongs to a constraint.
    Private Shared Function GetPrimaryKeyParams(ByVal constraintName As String)

        Const selectConstraintsQuery As String = "select column_name from information_schema.key_column_usage where constraint_name = '{0}' order by ordinal_position"
        Dim params As String = ""
        Dim paramDataAdapter As New SqlCeDataAdapter(String.Format(selectConstraintsQuery, constraintName), templateConnection)
        Dim paramTable As New DataTable
        paramDataAdapter.Fill(paramTable)

        For Each paramRow As DataRow In paramTable.Rows
            params = params & ", [" & paramRow("column_name") & "]"
        Next

        Return params.Remove(0, 2)
    End Function

#End Region


#Region "Add the study data into the new database."

    ' Saves the study into the new database.
    Private Shared Sub InsertStudy(ByVal study As BO.Study)

        Dim studyDataAdapter As SqlCeDataAdapter = CreateDataAdapter("Study")
        Dim table As New DataTable
        Dim row As DataRow

        studyDataAdapter.FillSchema(table, SchemaType.Source)

        ' Add the row.
        row = table.NewRow()
        row("studyGuid") = study.Guid
        row("Name") = study.Name
        row("shortName") = Functions.NullableString(study.ShortName)
        row("version") = study.Version
        row("Comment") = Functions.NullableString(study.Comment)
        row("DesignerVersion") = My.Application.Info.Version.ToString
        row("CreationDateTime") = study.CreationDateTime
        row("LastModificationDateTime") = DateTime.Now
        row("MaxTransactionID") = study.MaxTransactionID
        row("CurrentLanguageID") = BO.Study.LanguageList.IndexOf(BO.ContextClass.CurrentLanguage)
        row("DataSchema") = Functions.NullableString(study.DataTableSchema)
        row("LogSchema") = Functions.NullableString(study.LogTableSchema)
        row("LVSchema") = Functions.NullableString(study.LegalValuesTableSchema)
        row("AnalysisSchema") = Functions.NullableString(study.AnalysisViewsSchema)
        table.Rows.Add(row)

        ' Commit.
        studyDataAdapter.Update(table)

        ' Add the screen templates.
        InsertScreenTemplates(BO.Study.ScreenTemplates)

        ' Add the sites.
        InsertSites(BO.Study.Sites)

        ' Add the language list.
        InsertLanguageList(BO.Study.LanguageList)

        ' Add the pda users list.
        InsertPDAUserList(BO.Study.PDAUsers)

        ' Add the legal values.
        InsertLegalValues(BO.Study.LegalValues)

        ' Add the files.
        InsertFiles(BO.Study.Files)

        ' Add the reports.
        InsertReports(BO.Study.Reports)

        ' Add the methods.
        InsertMethods(BO.Study.Methods)

        ' Add dictionaries.
        InsertTranslations(study.Guid, "Name", study.NameDictionary)

        ' Add the questionnaire list.
        InsertQuestionnaireSets(BO.ContextClass.Study.QuestionnarieSets)

    End Sub


    ' Saves the screen templates into the new database.
    Private Shared Sub InsertScreenTemplates(ByVal screenTemplates As List(Of BO.ScreenTemplate))

        ' Init objects.
        Dim screenTemplateDataAdapter As SqlCeDataAdapter = CreateDataAdapter("ScreenTemplate")
        Dim table As New DataTable
        Dim row As DataRow

        screenTemplateDataAdapter.FillSchema(table, SchemaType.Source)

        ' Add the rows to the table.
        For Each template As BO.ScreenTemplate In screenTemplates

            row = table.NewRow()
            row("ScreenTemplateID") = template.DataBaseID
            row("ScreenTemplateName") = template.Name
            row("DataType") = template.DataType
            row("DotNETClassName") = template.DotNetClassName
            row("VariableNameReq") = template.VariableNameRequired
            table.Rows.Add(row)

        Next

        ' Commit.
        screenTemplateDataAdapter.Update(table)

    End Sub


    ' Saves the site collection into the new database.
    Private Shared Sub InsertSites(ByVal sites As List(Of BO.Site))

        ' Init objects.
        Dim siteDataAdapter As SqlCeDataAdapter = CreateDataAdapter("Site")
        Dim table As New DataTable
        Dim row As DataRow

        siteDataAdapter.FillSchema(table, SchemaType.Source)

        ' Add the rows to the table.
        For Each site As BO.Site In sites

            row = table.NewRow()
            row("siteId") = site.DataBaseID
            row("Name") = site.Name
            row("Code") = site.Code
            table.Rows.Add(row)

        Next

        ' Commit.
        siteDataAdapter.Update(table)

    End Sub


    ' Saves the PDA Uuser list into the new database.
    Private Shared Sub InsertPDAUserList(ByVal users As List(Of BO.PDAUser))

        ' Create the sql command.
        Dim PDAUserDataAdapter As SqlCeDataAdapter = CreateDataAdapter("PDAUser")
        Dim table As New DataTable
        Dim row As DataRow

        PDAUserDataAdapter.FillSchema(table, SchemaType.Source)
        Dim order As Integer = 0

        ' Add rows to the table.
        For Each pdaUser As BO.PDAUser In BO.Study.PDAUsers

            order += 1
            row = table.NewRow()
            row("PDAUserName") = pdaUser.PDAUserName
            row("PDAPassword") = pdaUser.PDAPassword
            row("Name") = pdaUser.Name
            row("RoleName") = pdaUser.RoleName
            row("DefaultSiteID") = Functions.NullableInt(pdaUser.DefaultSiteID)
            row("Order") = order
            table.Rows.Add(row)

        Next

        ' Commit.
        PDAUserDataAdapter.Update(table)

    End Sub


    ' Saves the legal values collection into the new database.
    Private Shared Sub InsertLegalValues(ByVal legalValuesList As List(Of BO.LegalValuesTable))

        Dim LVTableDataAdapter As SqlCeDataAdapter = CreateDataAdapter("LegalValueTable")
        Dim LVTableTable As New DataTable

        LVTableDataAdapter.FillSchema(LVTableTable, SchemaType.Source)

        Dim LVItemDataAdapter As SqlCeDataAdapter = CreateDataAdapter("LegalValueItem")
        Dim LVItemTable As New DataTable

        LVItemDataAdapter.FillSchema(LVItemTable, SchemaType.Source)

        Dim row As DataRow
        Dim order As Integer

        For Each legalValueTable As BO.LegalValuesTable In legalValuesList

            ' Add legal value tables.
            row = LVTableTable.NewRow()
            row("legalValueTableGuid") = legalValueTable.Guid
            row("Name") = legalValueTable.Name
            LVTableTable.Rows.Add(row)

            ' Add legal value items.
            order = 1
            For Each legalValue As BO.LegalValueItem In legalValueTable.LegalValues

                row = LVItemTable.NewRow()
                row("LegalValueTableGuid") = legalValueTable.Guid
                row("LegalValueItemGuid") = legalValue.Guid
                row("Value") = legalValue.Value
                row("Order") = order
                row("Text") = legalValue.Text
                row("ShortName") = Functions.NullableString(legalValue.ShortName)
                row("Group") = Functions.NullableString(legalValue.Group)
                row("hidden") = legalValue.Hidden
                LVItemTable.Rows.Add(row)
                order += 1

                InsertTranslations(legalValue.Guid, "Text", legalValue.TextDictionary)
            Next
        Next

        ' Commit.
        LVTableDataAdapter.Update(LVTableTable)
        LVItemDataAdapter.Update(LVItemTable)

    End Sub


    ' Saves the methods into the new database.
    Private Shared Sub InsertMethods(ByVal methods As List(Of BO.Method))

        ' Init objects.
        Dim methodDataAdapter As SqlCeDataAdapter = CreateDataAdapter("Method")
        Dim table As New DataTable
        Dim row As DataRow

        methodDataAdapter.FillSchema(table, SchemaType.Source)

        ' Add rows.
        For Each method As BO.Method In methods

            row = table.NewRow()
            row("MethodGuid") = method.Guid
            row("Name") = method.Name
            row("Type") = method.Type
            row("Code") = method.Code
            table.Rows.Add(row)

        Next

        ' Commit.
        methodDataAdapter.Update(table)

    End Sub


    ' Saves the files into the new database.
    Private Shared Sub InsertFiles(ByVal files As List(Of BO.File))

        ' Init objects.
        Dim fileDataAdapter As SqlCeDataAdapter = CreateDataAdapter("File")
        Dim table As New DataTable
        Dim row As DataRow

        fileDataAdapter.FillSchema(table, SchemaType.Source)

        ' Add rows.
        For Each file As BO.File In files

            row = table.NewRow()
            row("FileGuid") = file.Guid
            row("Name") = file.Name
            row("ReferencePath") = file.ReferencePath
            row("CodeNamespace") = Functions.NullableString(file.CodeNamespace)
            table.Rows.Add(row)

        Next

        ' Commit.
        fileDataAdapter.Update(table)

    End Sub


    ' Save the reports into the new database.
    Private Shared Sub InsertReports(ByVal reports As List(Of BO.Report))

        ' Init objects.
        Dim reportDataAdapter As SqlCeDataAdapter = CreateDataAdapter("Report")
        Dim reportTable As New DataTable
        Dim reportRow As DataRow
        reportDataAdapter.FillSchema(reportTable, SchemaType.Source)

        Dim reportColDataAdapter As SqlCeDataAdapter = CreateDataAdapter("ReportColumn")
        Dim reportColTable As New DataTable
        Dim reportColRow As DataRow
        reportColDataAdapter.FillSchema(reportColTable, SchemaType.Source)

        Dim reportSiteDataAdapter As SqlCeDataAdapter = CreateDataAdapter("ReportColumn")
        Dim reportSiteTable As New DataTable
        Dim reportSiteRow As DataRow
        reportSiteDataAdapter.FillSchema(reportSiteTable, SchemaType.Source)

        ' Add reports.
        For Each report As BO.Report In reports

            reportRow = reportTable.NewRow()
            reportRow("ReportGuid") = report.Guid
            reportRow("Name") = report.Name
            reportRow("ReportType") = report.ReportType
            reportRow("FormTypeName") = report.FormTypeName
            reportRow("Query") = report.Query
            reportTable.Rows.Add(reportRow)

            ' Add columns.
            For Each reportCol As BO.ReportColumn In report.Columns

                reportColRow = reportColTable.NewRow()
                reportColRow("ReportGuid") = report.Guid
                reportColRow("ReportColumnGuid") = reportCol.Guid
                reportColRow("Name") = reportCol.Name
                reportColRow("HeaderText") = reportCol.HeaderText
                reportColRow("Width") = reportCol.Width
                reportColRow("Format") = reportCol.Format
                reportColTable.Rows.Add(reportColRow)

            Next

            ' Add sites.
            For Each reportSite As String In report.SiteCodes

                reportSiteRow = reportSiteTable.NewRow()
                reportSiteRow("SiteCode") = reportSite
                reportSiteTable.Rows.Add(reportSiteRow)

            Next

        Next

        ' Commit.
        reportDataAdapter.Update(reportTable)
        reportColDataAdapter.Update(reportColTable)
        reportSiteDataAdapter.Update(reportSiteTable)

    End Sub


    ' Saves the questionnaireset info into the new database.
    Private Shared Sub InsertQuestionnaireSets(ByVal QuestionnaireSets As List(Of BO.QuestionnaireSet))

        ' Init objects.
        Dim questionnaireSetDataAdapter As SqlCeDataAdapter = CreateDataAdapter("QuestionnaireSet")
        Dim table As New DataTable
        Dim row As DataRow

        questionnaireSetDataAdapter.FillSchema(table, SchemaType.Source)

        Dim i As Integer = 1

        ' Add each QuestionnaireSet.
        For Each questionnaireSet As BO.QuestionnaireSet In QuestionnaireSets

            row = table.NewRow()
            row("QuestionnaireSetGuid") = questionnaireSet.Guid
            row("QuestionnaireSetID") = questionnaireSet.DataBaseID
            row("Name") = questionnaireSet.Name
            row("ShortName") = questionnaireSet.ShortName
            row("Precondition") = Functions.NullableString(questionnaireSet.PreCondition)
            row("subjectSecondaryIdField") = Functions.NullableString(questionnaireSet.SubjectSecondaryIdField)
            row("SubjectAlternativeSearchField") = Functions.NullableString(questionnaireSet.SubjectAlternativeSearchField)
            row("SubjectConfirmationFields") = questionnaireSet.SubjectConfirmationFields
            row("NewSubjectSectionID") = Functions.NullableInt(questionnaireSet.NewSubjectSectionID)
            row("OnNewSubject") = Functions.NullableString(questionnaireSet.OnNewSubject)
            row("order") = i
            row("Comment") = Functions.NullableString(questionnaireSet.Comment)
            row("logTable") = Functions.NullableString(questionnaireSet.LogTableName)
            row("dataTable") = Functions.NullableString(questionnaireSet.DataTableName)
            table.Rows.Add(row)
            i += 1

            ' Add dictionaries.
            InsertTranslations(questionnaireSet.Guid, "Name", questionnaireSet.NameDictionary)

            ' Add Questionnaires.
            InsertQuestionnaires(questionnaireSet.Questionnaires, questionnaireSet.DataBaseID)

            ' Add variable rows.
            Dim ordinal As Integer = 3001
            InsertVariables(questionnaireSet.Questionnaire(0).Section(0).DataBaseID, questionnaireSet.Variables)

        Next

        questionnaireSetDataAdapter.Update(table)

    End Sub


    ' Saves the questionnaire info into the new database.
    Private Shared Sub InsertQuestionnaires(ByVal questionnaires As List(Of BO.Questionnaire), ByVal questionnaireSetID As Integer)

        Dim i As Integer = 1
        Dim row As DataRow

        ' Add each Questionnaire.
        For Each questionnaire As BO.Questionnaire In questionnaires

            ' Set query parameters.
            row = QuestionnaireTable.NewRow()
            row("QuestionnaireGuid") = questionnaire.Guid
            row("QuestionnaireId") = questionnaire.DataBaseID
            row("QuestionnaireSetID") = questionnaireSetID
            row("Order") = i
            row("ShortName") = Functions.NullableString(questionnaire.ShortName)
            row("Name") = Functions.NullableString(questionnaire.Name)
            row("Precondition") = Functions.NullableString(questionnaire.PreCondition)
            row("MultipleInstances") = questionnaire.MultipleInstances
            row("InstanceSAIDField") = Functions.NullableString(questionnaire.InstanceSAIDField)
            row("InstanceSecondaryIDField") = Functions.NullableString(questionnaire.InstanceSecondaryIDField)
            row("OnNewRecord") = Functions.NullableString(questionnaire.OnNewRecord)
            row("Comment") = Functions.NullableString(questionnaire.Comment)
            row("logTable") = Functions.NullableString(questionnaire.LogTableName)
            row("dataTable") = Functions.NullableString(questionnaire.DataTableName)
            QuestionnaireTable.Rows.Add(row)

            ' Add dictionaries.
            InsertTranslations(questionnaire.Guid, "Name", questionnaire.NameDictionary)

            ' Add sections.
            InsertSections(questionnaire.Sections, questionnaire.ShortName, questionnaire.DataBaseID)
            i += 1

            ' Add variable rows.
            Dim ordinal As Integer = 2001
            InsertVariables(questionnaire.Section(0).DataBaseID, questionnaire.Variables)

        Next
    End Sub


    ' Saves the sections info into the new database.
    Private Shared Sub InsertSections(ByVal sections As List(Of BO.Section), ByVal QuestionnaireShortName As String, ByVal QuestionnaireId As String)

        Dim row As DataRow
        Dim i As Integer = 1
       
        ' Add each Section.
        For Each section As BO.Section In sections

            row = SectionTable.NewRow()
            row("SectionGuid") = section.Guid
            row("SectionId") = section.DataBaseID
            row("QuestionnaireId") = QuestionnaireId
            row("Order") = i
            row("Modifiable") = Convert.ToInt16(section.Modifiable)
            row("ShortName") = section.ShortName
            row("Name") = section.Name
            row("Precondition") = Functions.NullableString(section.PreCondition)
            row("OnNewRecord") = Functions.NullableString(section.OnNewRecord)
            row("Comment") = Functions.NullableString(section.Comment)
            row("logTable") = Functions.NullableString(section.LogTableName)
            row("dataTable") = Functions.NullableString(section.DataTableName)
            SectionTable.Rows.Add(row)

            ' Add dictionaries.
            InsertTranslations(section.Guid, "Name", section.NameDictionary)

            ' Insert section items.
            InsertSectionItems(section.DataBaseID, section.SectionItems)
            i += 1

            ' Add variable rows.
            Dim ordinal As Integer = 1001
            InsertVariables(section.DataBaseID, section.Variables)

        Next
    End Sub


    ' Saves the variables into the new database.
    Private Shared Sub InsertVariables(ByVal sectionID As Integer, ByVal variables As List(Of BO.Variable))

        Dim row As DataRow

        For Each variable As BO.Variable In variables

            Dim q As BO.Question = variable.ToQuestion
            row = SectionItemTable.NewRow()
            row("SectionItemGuid") = q.Guid
            row("Type") = "Variable"
            row("Visible") = True
            row("Ordinal") = 0
            row("Level") = 0
            row("SectionID") = sectionID
            row("MainText") = q.MainText
            row("GroupMember") = q.GroupMember
            row("GroupText") = Functions.NullableString(q.GroupText)
            row("VariableName") = q.VariableName
            row("ScreenTemplate") = q.ScreenTemplate
            row("VariableScope") = q.VariableScope
            row("Required") = q.Required
            row("AbsMin") = Functions.NullableString(q.AbsoluteMinimum)
            row("AbsMax") = Functions.NullableString(q.AbsoluteMaximum)
            row("PromptUnder") = Functions.NullableString(q.PromptUnder)
            row("PromptOver") = Functions.NullableString(q.PromptOver)
            row("LegalValueTable") = Functions.NullableString(q.LegalValueTable)
            row("CustomValidation") = Functions.NullableString(q.CustomValidation)
            row("ConfirmChange") = q.ConfirmChange
            row("HideNext") = q.HideNext
            row("HideBack") = q.HideBack
            row("ConfirmNext") = q.ConfirmNext
            row("ConfirmBack") = q.ConfirmBack
            row("Arguments") = Functions.NullableString(q.Arguments)
            row("HelpText") = Functions.NullableString(q.HelpText)
            row("OnLoad") = Functions.NullableString(q.OnLoad)
            row("OnUnload") = Functions.NullableString(q.OnUnload)
            row("OnChange") = Functions.NullableString(q.OnChange)
            row("Comment") = Functions.NullableString(q.Comment)
            SectionItemTable.Rows.Add(row)

            ' Insert translations of the variable maintext.
            InsertTranslations(q.Guid, "MainText", q.MainTextDictionary)

        Next

    End Sub


    ' Saves the section items into the new database.
    Private Shared Sub InsertSectionItems(ByVal SectionID As Integer, ByVal sectionItems As List(Of BO.SectionItem))

        ' Poblate the table.
        Dim i As Integer = 1
        InsertSectionItemRow(SectionID, sectionItems, 1, i)

    End Sub


    ' Inserts section items recursivly.
    Private Shared Sub InsertSectionItemRow(ByVal SectionID As Integer, ByVal sectionItems As List(Of BO.SectionItem), ByVal level As Integer, ByRef ordinal As Integer)

        Dim row As DataRow

        ' Insert the list of section items.
        For Each sectionItem As BO.SectionItem In sectionItems

            row = SectionItemTable.NewRow()
            row("SectionItemGuid") = sectionItem.Guid
            row("SectionID") = SectionID
            row("Ordinal") = ordinal
            row("Level") = level
            row("Visible") = True
            row("Number") = Functions.NullableString(sectionItem.Number)
            row("MainText") = sectionItem.MainText
            row("Comment") = sectionItem.Comment
            InsertTranslations(sectionItem.Guid, "Name", sectionItem.NameDictionary)
            InsertTranslations(sectionItem.Guid, "MainText", sectionItem.MainTextDictionary)

            If sectionItem.GetType.Equals(GetType(BO.Question)) Then
                ' Question section item.
                Dim q As BO.Question = sectionItem
                row("Type") = "Question"
                row("Visible") = q.Visible
                row("GroupMember") = q.GroupMember
                row("GroupText") = Functions.NullableString(q.GroupText)
                row("VariableName") = q.VariableName
                row("ScreenTemplate") = q.ScreenTemplate
                row("VariableScope") = q.VariableScope
                row("Required") = q.Required
                row("AbsMin") = Functions.NullableString(q.AbsoluteMinimum)
                row("AbsMax") = Functions.NullableString(q.AbsoluteMaximum)
                row("PromptUnder") = Functions.NullableString(q.PromptUnder)
                row("PromptOver") = Functions.NullableString(q.PromptOver)
                row("LegalValueTable") = Functions.NullableString(q.LegalValueTable)
                row("CustomValidation") = Functions.NullableString(q.CustomValidation)
                row("CustomValidationFailMessage") = Functions.NullableString(q.CustomValidationFailMessage)
                row("ConfirmChange") = q.ConfirmChange
                row("HideNext") = q.HideNext
                row("HideBack") = q.HideBack
                row("ConfirmNext") = q.ConfirmNext
                row("ConfirmBack") = q.ConfirmBack
                row("Arguments") = Functions.NullableString(q.Arguments)
                row("HelpText") = Functions.NullableString(q.HelpText)
                row("OnLoad") = Functions.NullableString(q.OnLoad)
                row("OnUnload") = Functions.NullableString(q.OnUnload)
                row("OnChange") = Functions.NullableString(q.OnChange)

                ' Add dictionaries.
                InsertTranslations(q.Guid, "HelpText", q.HelpTextDictionary)
                InsertTranslations(q.Guid, "GroupText", q.GroupTextDictionary)
                InsertTranslations(q.Guid, "CustomValidationFailMessage", q.CustomValidationFailMessageDictionary)

            ElseIf sectionItem.GetType.Equals(GetType(BO.Information)) Then
                ' Info section item.
                Dim info As BO.Information = sectionItem
                row("Type") = "Info"
                row("Visible") = info.Visible
                row("HideNext") = info.HideNext
                row("HideBack") = info.HideBack
                row("OnLoad") = Functions.NullableString(info.OnLoad)
                row("OnUnload") = Functions.NullableString(info.OnUnload)
                
            ElseIf sectionItem.GetType.Equals(GetType(BO.CheckPoint)) Then
                ' Checkpoint section item.
                Dim cp As BO.CheckPoint = sectionItem
                row("Type") = "Checkpoint"
                row("Condition") = cp.Condition
                row("BranchIf") = Convert.ToInt16(cp.BranchIf)
                
                ' Recursive call.
                ordinal += 1
                InsertSectionItemRow(SectionID, cp.SectionItems, level + 1, ordinal)
            End If

            SectionItemTable.Rows.Add(row)
            ordinal += 1
        Next
    End Sub


    ' Insert the language list into the database.
    Private Shared Sub InsertLanguageList(ByVal languages As List(Of BO.Language))

        Dim languageDataAdapter As SqlCeDataAdapter = CreateDataAdapter("Languages")
        Dim table As New DataTable
        Dim row As DataRow

        languageDataAdapter.FillSchema(table, SchemaType.Source)

        For Each lang As BO.Language In languages

            row = table.NewRow
            row("LanguageId") = lang.LanguageID
            row("Language") = lang.Name
            table.Rows.Add(row)

        Next

        languageDataAdapter.Update(table)

    End Sub


    ' Insert translations into the dictionary.
    Private Shared Sub InsertTranslations(ByVal uniqueId As Guid, ByVal propertyName As String, ByVal dictionary As Dictionary(Of Integer, String))

        Dim row As DataRow

        For Each key As Integer In dictionary.Keys

            If Not String.IsNullOrEmpty(dictionary(key)) Then

                row = DictionaryTable.NewRow()
                row("Guid") = uniqueId
                row("PropertyName") = propertyName
                row("LanguageID") = key
                row("Text") = dictionary(key)
                DictionaryTable.Rows.Add(row)

            End If
        Next

    End Sub

#End Region

End Class

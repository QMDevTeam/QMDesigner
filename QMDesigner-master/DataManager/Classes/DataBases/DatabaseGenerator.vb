Imports System.Data.SqlServerCe
Imports System.Data.SqlClient
Imports System.IO
Imports DevComponents.DotNetBar

Public Class VariableDB
    Public VariableName As String
    Public DataType As String
    Public MainText As String
    Public LegalValueTable As String

    Public Overrides Function ToString() As String
        Return VariableName
    End Function

End Class

Public Class DatabaseGenerator

#Region " Private Members "

    ' Variables.
    Private _fileName As String
    Private _localDataDB As MainDatabase
    Private _currentFolder As String
    Private _databaseScriptWriter As IO.StreamWriter
    Private _targetDB As MainDatabase
    Private _mainQuery As String

#End Region

#Region " Properties "

    Public ReadOnly Property Connected() As Boolean
        Get
            Return _localDataDB.Connected
        End Get
    End Property

#End Region

#Region " Public Methods "

    Public Sub New(ByVal currentFolder As String, ByVal targetDB As MainDatabase)

        _currentFolder = currentFolder
        _targetDB = targetDB

    End Sub


    Public Sub CreateDataBaseStructure()

        _mainQuery = ""

        If String.IsNullOrEmpty(BO.ContextClass.Study.DataTableSchema) Then
            Throw New Exception("The DataTableSchema is empty.")
        End If
        If String.IsNullOrEmpty(BO.ContextClass.Study.AnalysisViewsSchema) Then
            Throw New Exception("The AnalysisViewsSchema is empty.")
        End If
        If String.IsNullOrEmpty(BO.ContextClass.Study.LegalValuesTableSchema) Then
            Throw New Exception("The LegalValuesTableSchema is empty.")
        End If
        If String.IsNullOrEmpty(BO.ContextClass.Study.LogTableSchema) Then
            Throw New Exception("The LogTableSchema is empty.")
        End If

        CreateSchema(BO.ContextClass.Study.AnalysisViewsSchema)
        CreateSchema(BO.ContextClass.Study.DataTableSchema)
        CreateSchema(BO.ContextClass.Study.LogTableSchema)
        CreateSchema(BO.ContextClass.Study.LegalValuesTableSchema)

        CreateStudyTable()
        GenearteStudyContent()

        CommitQuery()

    End Sub

#End Region

#Region " Private Methods "

    'Generate the database in SQLServer Express 2005 or better
    Private Sub GenearteStudyContent()


        InsertStudy(BO.ContextClass.Study)

        Dim subjectVariables As Dictionary(Of String, VariableDB)
        Dim sectionVariables As Dictionary(Of String, VariableDB)
        Dim questionnaireVariables As Dictionary(Of String, VariableDB)
        Dim fieldsQuestionnaireSetView As Dictionary(Of String, String)
        Dim tables As New Dictionary(Of String, String)
        Dim location As String = ""
        Dim tablesQuestionnaireSetView As String
        Dim errorMessage As String = ""
        Dim taskDialogInfo As TaskDialogInfo = New TaskDialogInfo("Warning - DataManager", eTaskDialogIcon.Exclamation, "Header", "Text", _
                                                                    eTaskDialogButton.Yes Or eTaskDialogButton.No, eTaskDialogBackgroundColor.Tan)
        Dim commandCheckBox As New Command()

        commandCheckBox.Text = "Remember Last Choice?"
        commandCheckBox.Checked = False
        taskDialogInfo.CheckBoxCommand = commandCheckBox

        Try

            '----QuestionnaireSets-----------
            For Each currentQuestionnaireSet As BO.QuestionnaireSet In BO.ContextClass.Study.QuestionnarieSets

                errorMessage = String.Format("Questionnaire Set: {0}", currentQuestionnaireSet.Name)

                subjectVariables = New Dictionary(Of String, VariableDB)()
                Dim subjectTableName As String = currentQuestionnaireSet.DataTableName
                Dim subjectLogTableName As String = currentQuestionnaireSet.LogTableName

                If String.IsNullOrEmpty(subjectTableName) Then
                    Throw New Exception("The name of the data table of a QuestionnaireSet is empty." & Environment.NewLine & "Location: " & errorMessage)
                ElseIf String.IsNullOrEmpty(subjectLogTableName) Then
                    Throw New Exception("The name of the log table of a QuestionnaireSet is empty." & Environment.NewLine & "Location: " & errorMessage)
                End If

                tablesQuestionnaireSetView = String.Format("[{0}].[{1}]" & Environment.NewLine, BO.ContextClass.Study.DataTableSchema, _
                                                subjectTableName)
                fieldsQuestionnaireSetView = New Dictionary(Of String, String)

                ' +++ Assign Variables of QuestionnaireSets +++ 
                If currentQuestionnaireSet.HasVariables Then
                    RegisterAssignVariables(currentQuestionnaireSet.Variables, subjectVariables, Nothing, Nothing, BO.VariableScopes.QuestionnaireSet)
                End If
                ' ++++++++++++++++++++++++++++++++++++++++++++++

                '~~~~~~~~Questionnaire~~~~~~~~~
                For Each currentQuestionnaire As BO.Questionnaire In currentQuestionnaireSet.Questionnaires

                    errorMessage = String.Format("Questionnaire Set: {0}, Questionnaire: {1}", currentQuestionnaireSet.Name, currentQuestionnaire.Name)

                    questionnaireVariables = New Dictionary(Of String, VariableDB)()
                    Dim questionnaireTableName As String = currentQuestionnaire.DataTableName
                    Dim questionnaireLogTableName As String = currentQuestionnaire.LogTableName

                    If String.IsNullOrEmpty(questionnaireTableName) Then
                        Throw New Exception("The name of the data table of a Questionnaire is empty." & Environment.NewLine & "Location: " & errorMessage)
                    ElseIf String.IsNullOrEmpty(questionnaireLogTableName) Then
                        Throw New Exception("The name of the log table of a Questionnaire is empty." & Environment.NewLine & "Location: " & errorMessage)
                    End If

                    tablesQuestionnaireSetView &= String.Format(" LEFT JOIN [{2}].[{0}] ON [{0}].SubjectID = [{1}].SubjectID ", questionnaireTableName, _
                                                    subjectTableName, BO.ContextClass.Study.DataTableSchema) & Environment.NewLine

                    ' ++++++ Assign Variables of Questionnaire +++++
                    If currentQuestionnaireSet.HasVariables Then
                        RegisterAssignVariables(currentQuestionnaire.Variables, subjectVariables, Nothing, questionnaireVariables, BO.VariableScopes.Questionnaire)
                    End If
                    ' +++++++++++++++++++++++++++++++++++++++++++++++

                    ' ####  Section  #####
                    For Each currentSection As BO.Section In currentQuestionnaire.Sections

                        sectionVariables = New Dictionary(Of String, VariableDB)()
                        errorMessage = String.Format("Questionnaire Set: {0}, Questionnaire: {1}, Section: {2} ", currentQuestionnaireSet.Name, currentQuestionnaire.Name, currentSection.Name)

                        ' +++ Assign Variables of Section +++ 
                        If currentQuestionnaireSet.HasVariables Then
                            RegisterAssignVariables(currentSection.Variables, subjectVariables, sectionVariables, questionnaireVariables, BO.VariableScopes.Section)
                        End If
                        '+++++++++++++++++++++++++++++++++++++

                        '--------Section Items---------
                        GenerateSectionOrCheckpointContent(currentSection, subjectVariables, sectionVariables, _
                                questionnaireVariables, errorMessage)

                        '---Build Query of Section
                        'Dim dataTableName As String = String.Format("D_{0}_{1}_{2}", currentQuestionnaireSet.DataBaseID, currentQuestionnaire.DataBaseID, currentSection.DataBaseID)
                        Dim sectionDataTableName As String = currentSection.DataTableName
                        Dim sectionLogTableName As String = currentSection.LogTableName

                        If String.IsNullOrEmpty(sectionDataTableName) Then
                            Throw New Exception("The name of the data table of a section is empty." & Environment.NewLine & "Location: " & errorMessage)
                        End If
                        If String.IsNullOrEmpty(sectionLogTableName) Then
                            Throw New Exception("The name of the log table of a section is empty." & Environment.NewLine & "Location: " & errorMessage)
                        End If

                        If currentQuestionnaire.MultipleInstances Then
                            tablesQuestionnaireSetView &= String.Format(" LEFT JOIN [{3}].[{0}] ON [{2}].subjectid = [{0}].subjectid AND [{1}].[SubjectQuestionnaireInstanceID] = [{0}].[SubjectQuestionnaireInstanceID] ", _
                                    sectionDataTableName, questionnaireTableName, subjectTableName, BO.ContextClass.Study.DataTableSchema) & Environment.NewLine
                        Else
                            tablesQuestionnaireSetView &= String.Format(" LEFT JOIN [{2}].[{0}] ON [{1}].subjectid = [{0}].subjectid ", _
                                    sectionDataTableName, subjectTableName, BO.ContextClass.Study.DataTableSchema) & Environment.NewLine
                        End If


                        'Create Section Table
                        If tables.TryGetValue(BO.ContextClass.Study.DataTableSchema & "." & sectionDataTableName, location)  Then

                            taskDialogInfo.Header = String.Format("Duplicate Table Name ""{0}""", sectionDataTableName)
                            taskDialogInfo.Text = String.Format("The Tables are the same:<br/>{0}<br/>and<br/><b>Location</b>: {1}<br/><b>Property</b>: DataTableName<br/><br/>Do you want to continue?<br/>.", _
                                                                    location, errorMessage)

                            If Not commandCheckBox.Checked AndAlso TaskDialog.Show(taskDialogInfo) = eTaskDialogResult.No Then
                                Throw New Exception("Aborted by user")
                            End If
                        Else
                            tables.Add(BO.ContextClass.Study.DataTableSchema & "." & sectionDataTableName, _
                                    "<b>Location</b>: " & errorMessage & "<br/><b>Property</b>: DataTableName")
                            CreateDataTable(sectionDataTableName, sectionVariables)
                        End If

                        'Create Section Audit Table
                        If tables.TryGetValue(BO.ContextClass.Study.LogTableSchema & "." & sectionLogTableName, location) Then

                            taskDialogInfo.Header = String.Format("Duplicate Table Name ""{0}""", sectionDataTableName)
                            taskDialogInfo.Text = String.Format("The Tables are the same:<br/>{0}<br/>and<br/><b>Location</b>: {1}<br/><b>Property</b>: LogTableName<br/><br/>Do you want to continue?<br/>.", _
                                                                    location, errorMessage)
                            If Not commandCheckBox.Checked AndAlso TaskDialog.Show(taskDialogInfo) = eTaskDialogResult.No Then
                                Throw New Exception("Aborted by user")
                            End If
                        Else
                            tables.Add(BO.ContextClass.Study.LogTableSchema & "." & sectionLogTableName, _
                                    "<b>Location</b>: " & errorMessage & "<br/><b>Property</b>: LogTableName")
                            CreateDataTableAuditTrail(sectionLogTableName, sectionVariables)
                        End If

                        AddVariablesToDictionary(fieldsQuestionnaireSetView, New List(Of VariableDB)(sectionVariables.Values), sectionDataTableName)

                    Next

                    errorMessage = String.Format("Questionnaire Set: {0}, Questionnaire: {1} ", currentQuestionnaireSet.Name, currentQuestionnaire.Name)

                    'Create Questionnaire Table
                    If tables.TryGetValue(BO.ContextClass.Study.DataTableSchema & "." & questionnaireTableName, location) Then

                        taskDialogInfo.Header = String.Format("Duplicate Table Name ""{0}""", questionnaireTableName)
                        taskDialogInfo.Text = String.Format("The Tables are the same:<br/>{0}<br/>and<br/><b>Location</b>: {1}<br/><b>Property</b>: DataTableName<br/><br/>Do you want to continue?<br/>.", _
                                                                location, errorMessage)

                        If Not commandCheckBox.Checked AndAlso TaskDialog.Show(taskDialogInfo) = eTaskDialogResult.No Then
                            Throw New Exception("Aborted by user")
                        End If
                    Else
                        tables.Add(BO.ContextClass.Study.DataTableSchema & "." & questionnaireTableName, _
                                "<b>Location</b>: " & errorMessage & Environment.NewLine & "<b>Property</b>: DataTableName")
                        CreateDataTable(questionnaireTableName, questionnaireVariables)
                    End If

                    'Create Questionnaire Audit Table
                    If tables.TryGetValue(BO.ContextClass.Study.LogTableSchema & "." & questionnaireLogTableName, location) Then

                        taskDialogInfo.Header = String.Format("Duplicate Table Name ""{0}""", questionnaireTableName)
                        taskDialogInfo.Text = String.Format("The Tables are the same:<br/>{0}<br/>and<br/><b>Location</b>: {1}<br/><b>Property</b>: LogTableName<br/><br/>Do you want to continue?<br/>.", _
                                                                location, errorMessage)
                        If Not commandCheckBox.Checked AndAlso TaskDialog.Show(taskDialogInfo) = eTaskDialogResult.No Then
                            Throw New Exception("Aborted by user")
                        End If
                    Else
                        tables.Add(BO.ContextClass.Study.LogTableSchema & "." & questionnaireLogTableName, _
                                "<b>Location</b>: " & errorMessage & Environment.NewLine & "<b>Property</b>: LogTableName")
                        CreateDataTableAuditTrail(questionnaireLogTableName, questionnaireVariables)
                    End If

                    AddVariablesToDictionary(fieldsQuestionnaireSetView, New List(Of VariableDB)(questionnaireVariables.Values), questionnaireTableName)

                Next

                errorMessage = String.Format("Questionnaire Set: {0}", currentQuestionnaireSet.Name)

                'Create the QuestionnaireSet Table
                If tables.TryGetValue(BO.ContextClass.Study.DataTableSchema & "." & subjectTableName, location)  Then

                    taskDialogInfo.Header = String.Format("Duplicate Table Name ""{0}""", subjectLogTableName)
                    taskDialogInfo.Text = String.Format("The Tables are the same:<br/>{0}<br/>and<br/><b>Location</b>: {1}<br/><b>Property</b>: DataTableName<br/><br/>Do you want to continue?<br/>.", _
                                                            location, errorMessage)
                    If Not commandCheckBox.Checked AndAlso TaskDialog.Show(taskDialogInfo) = eTaskDialogResult.No Then
                        Throw New Exception("Aborted by user")
                    End If
                Else

                    tables.Add(BO.ContextClass.Study.DataTableSchema & "." & subjectTableName, _
                            "<b>Location</b>: " & errorMessage & Environment.NewLine & "<b>Property</b>: DataTableName")
                    CreateQuestionnaireSetTable(subjectTableName, subjectVariables)

                End If

                'Create the QuestionnaireSet Audit Table
                If tables.TryGetValue(BO.ContextClass.Study.LogTableSchema & "." & subjectLogTableName, location) Then

                    taskDialogInfo.Header = String.Format("Duplicate Table Name ""{0}""", subjectLogTableName)
                    taskDialogInfo.Text = String.Format("The Tables are the same:<br/>{0}<br/>and<br/><b>Location</b>: {1}<br/><b>Property</b>: LogTableName<br/><br/>Do you want to continue?<br/>.", _
                                                            location, errorMessage)
                    If Not commandCheckBox.Checked AndAlso TaskDialog.Show(taskDialogInfo) = eTaskDialogResult.No Then
                        Throw New Exception("Aborted by user")
                    End If
                Else
                    tables.Add(BO.ContextClass.Study.LogTableSchema & "." & subjectLogTableName, _
                            "<b>Location</b>: " & errorMessage & Environment.NewLine & "<b>Property</b>: LogTableName")
                    CreateQuestionnaireSetTableAuditTrail(subjectLogTableName, subjectVariables)

                End If

                AddVariablesToDictionary(fieldsQuestionnaireSetView, _
                        New List(Of VariableDB)(subjectVariables.Values), subjectTableName)

                CreateQuestionnaireSetView( _
                        String.Format( _
                                "SELECT {0} FROM {1}", _
                                DA.Functions.ListToString(New List(Of String)(fieldsQuestionnaireSetView.Values), ", " & Environment.NewLine), _
                                tablesQuestionnaireSetView _
                            ), _
                        currentQuestionnaireSet.ShortName _
                    )

            Next

            CreateSchema("LegalValue")

            ' Creat and populate the tables of the LegalValues
            For Each legalValues As BO.LegalValuesTable In BO.Study.LegalValues
                CreateLegalValuesTable(legalValues)
            Next

        Catch ex As Exception

            'CloseScriptWriter()
            Throw New Exception(String.Format("Error in {0}" & Environment.NewLine & ex.Message, errorMessage))

        End Try
    End Sub


    ''' <summary>
    ''' Create the base of the DB
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CreateStudyTable()

        ' Create the structure of the data file
        Dim createScriptPath As String = _currentFolder + "\Scripts\Create Study Table.sql"
        Dim createScriptReader As StreamReader = File.OpenText(createScriptPath)
        For Each statement As String In createScriptReader.ReadToEnd().Split(";"c)
            statement = statement.Trim.Replace("{DataSchema}", BO.ContextClass.Study.DataTableSchema)
            If Not String.IsNullOrEmpty(statement.Trim) Then
                _mainQuery &= statement + ";" + Environment.NewLine
                'If Not String.IsNullOrEmpty(statement) Then _targetDB.ExecuteNonQuery(statement)
                '_databaseScriptWriter.WriteLine(statement + ";" + Environment.NewLine)
            End If
        Next
        createScriptReader.Close()
        createScriptReader.Dispose()

    End Sub


    Private Sub CreateSchema(ByVal schemaName As String)

        Dim strContents As String = File.OpenText(_currentFolder + "\Scripts\Create Schema.sql").ReadToEnd().Replace("{SchemaName}", schemaName.Replace("'", "''"))

        Dim statements() As String = strContents.Split(";"c)

        For Each statement As String In statements
            If Not String.IsNullOrEmpty(statement.Trim) Then
                _mainQuery &= statement + ";" + Environment.NewLine
                '_databaseScriptWriter.WriteLine(statement + ";" + Environment.NewLine)
                '_targetDB.ExecuteNonQuery(statement)
            End If
        Next

    End Sub


    Private Sub CreateLegalValuesTable(ByVal legalValue As BO.LegalValuesTable)

        Dim strContents As String = File.OpenText(_currentFolder + "\Scripts\Create Legal Value Table.sql").ReadToEnd()
        strContents = strContents.Replace("{tableName}", legalValue.Name).Replace("{LegalValueSchema}", BO.ContextClass.Study.LegalValuesTableSchema)
        Dim statements() As String = strContents.Split(";"c)

        For Each statement As String In statements
            If Not String.IsNullOrEmpty(statement.Trim) Then
                _mainQuery &= statement + ";" + Environment.NewLine
                '_databaseScriptWriter.WriteLine(statement + ";" + Environment.NewLine)
                '_targetDB.ExecuteNonQuery(statement)
            End If
        Next

        Dim order As Integer = 1

        For Each LVItem As BO.LegalValueItem In legalValue.LegalValues
            InsertLegalValueItem(legalValue.Name, LVItem, order)
            order += 1
        Next

    End Sub


    Private Sub InsertLegalValueItem(ByVal legalValuesName As String, ByVal LVitem As BO.LegalValueItem, ByVal order As Integer)

        Dim strContents As String = File.OpenText(_currentFolder + "\Scripts\Insert Legal Value Item.sql").ReadToEnd()


        strContents = strContents.Replace("{LegalValueSchema}", BO.ContextClass.Study.LegalValuesTableSchema)
        strContents = strContents.Replace("{tableName}", legalValuesName)
        strContents = strContents.Replace("{Value}", LVitem.Value.ToString.Replace("'", "''"))
        strContents = strContents.Replace("{Order}", order.ToString.Replace("'", "''"))
        strContents = strContents.Replace("{Hidden}", IIf(LVitem.Hidden, 1, 0).ToString.Replace("'", "''"))
        strContents = strContents.Replace("{LegalValueItemGUID}", LVitem.Guid.ToString.Replace("'", "''"))

        If String.IsNullOrEmpty(LVitem.Text) OrElse String.IsNullOrEmpty(LVitem.Text.Trim) Then
            strContents = strContents.Replace("'{Text}'", "NULL")
        Else
            strContents = strContents.Replace("{Text}", LVitem.Text.Replace("'", "''"))
        End If
        If String.IsNullOrEmpty(LVitem.ShortName) OrElse String.IsNullOrEmpty(LVitem.ShortName.Trim) Then
            strContents = strContents.Replace("'{ShortName}'", "NULL")
        Else
            strContents = strContents.Replace("{ShortName}", LVitem.ShortName.Replace("'", "''"))
        End If
        If String.IsNullOrEmpty(LVitem.Group) OrElse String.IsNullOrEmpty(LVitem.Group.Trim) Then
            strContents = strContents.Replace("'{Group}'", "NULL")
        Else
            strContents = strContents.Replace("{Group}", LVitem.Group.Replace("'", "''"))
        End If

        Dim statements() As String = strContents.Split(";"c)

        For Each statement As String In statements
            If Not String.IsNullOrEmpty(statement.Trim) Then
                _mainQuery &= statement + ";" + Environment.NewLine
            End If
        Next

    End Sub


    Private Sub CreateDataTable(ByVal tableName As String, ByVal variables As Dictionary(Of String, VariableDB))

        Dim strContents As String = File.OpenText(_currentFolder + "\Scripts\Create Data Table.sql").ReadToEnd().Replace("{tableName}", tableName)
        strContents = strContents.Replace("{DataSchema}", BO.ContextClass.Study.DataTableSchema)
        Dim statements() As String = strContents.Split(";"c)
        Dim createTableStatement As String = ""

        createTableStatement = CreateTableScript(statements(0), variables)
        statements(0) = createTableStatement


        For Each statement As String In statements
            If Not String.IsNullOrEmpty(statement.Trim) Then
                _mainQuery &= statement + ";" + Environment.NewLine
            End If
        Next


    End Sub


    Private Sub CreateDataTableAuditTrail(ByVal tableName As String, ByVal variables As Dictionary(Of String, VariableDB))

        Dim strContents As String = File.OpenText(_currentFolder + "\Scripts\Create Data Table Audit Trail.sql").ReadToEnd().Replace("{tableName}", tableName)
        strContents = strContents.Replace("{AuditSchema}", BO.ContextClass.Study.LogTableSchema)
        Dim statements() As String = strContents.Split(";"c)
        Dim createTableStatement As String = ""

        createTableStatement = CreateTableScript(statements(0), variables)
        statements(0) = createTableStatement


        For Each statement As String In statements
            If Not String.IsNullOrEmpty(statement.Trim) Then
                _mainQuery &= statement & ";" & Environment.NewLine
                '_databaseScriptWriter.WriteLine(statement + ";" + Environment.NewLine)
                '_targetDB.ExecuteNonQuery(statement)
            End If
        Next

    End Sub


    Private Sub CreateQuestionnaireSetTable(ByVal tableName As String, ByVal variables As Dictionary(Of String, VariableDB), Optional ByVal auditLogTable As Boolean = False)

        Dim strContents As String = File.OpenText(_currentFolder + "\Scripts\Create Subject Table.sql").ReadToEnd().Replace("{tableName}", tableName)
        strContents = strContents.Replace("{DataSchema}", BO.ContextClass.Study.DataTableSchema)
        Dim statements() As String = strContents.Split(";"c)
        Dim createTableStatement As String = CreateTableScript(statements(0), variables)
        statements(0) = createTableStatement


        For Each statement As String In statements
            If Not String.IsNullOrEmpty(statement.Trim) Then
                _mainQuery &= statement & ";" & Environment.NewLine
                '_databaseScriptWriter.WriteLine(statement + ";" + Environment.NewLine)
                '_targetDB.ExecuteNonQuery(statement)
            End If
        Next


    End Sub


    Private Sub CreateQuestionnaireSetView(ByVal selectQuery As String, ByVal viewName As String)

        Dim query As String = String.Format("CREATE VIEW [{0}].[{1}] AS {2} ", _
                                            BO.ContextClass.Study.AnalysisViewsSchema, viewName, selectQuery)

        _mainQuery &= query & ";" & Environment.NewLine

        '_databaseScriptWriter.WriteLine(query + ";" + Environment.NewLine)
        '_targetDB.ExecuteNonQuery(query)

    End Sub


    Private Sub CreateQuestionnaireSetTableAuditTrail(ByVal tableName As String, ByVal variables As Dictionary(Of String, VariableDB))

        Dim strContents As String = File.OpenText(_currentFolder + "\Scripts\Create Subject Table Audit Trail.sql").ReadToEnd().Replace("{tableName}", tableName)
        strContents = strContents.Replace("{AuditSchema}", BO.ContextClass.Study.LogTableSchema)
        Dim statements() As String = strContents.Split(";"c)
        Dim createTableStatement As String = CreateTableScript(statements(0), variables)
        statements(0) = createTableStatement

        For Each statement As String In statements
            If Not String.IsNullOrEmpty(statement.Trim) Then
                _mainQuery &= statement & ";" & Environment.NewLine
                '_databaseScriptWriter.WriteLine(statement + ";" + Environment.NewLine)
                '_targetDB.ExecuteNonQuery(statement)
            End If
        Next

    End Sub


    Private Function CreateTableScript(ByVal script As String, ByVal variables As Dictionary(Of String, VariableDB)) As String

        Dim scriptBuilder As New System.Text.StringBuilder(script.Trim.TrimEnd(")"c))

        For Each variable As VariableDB In variables.Values
            If variable.VariableName <> "SASubjectID" Then
                scriptBuilder.AppendLine(String.Format(",[{0}] {1}", variable.VariableName, variable.DataType + CStr(IIf(variable.DataType.Trim.ToLower = "numeric", "(18,2)", ""))))
            End If
        Next

        Return scriptBuilder.ToString + ")"

    End Function


    Private Sub CommitQuery()

        Dim outputFile As String = String.Format("{0}\data\{1}.qmd.sql", _currentFolder, _targetDB.DataBaseName)
        If System.IO.File.Exists(outputFile) Then System.IO.File.Delete(outputFile)
        _databaseScriptWriter = New StreamWriter(outputFile, False)

        For Each statement As String In _mainQuery.Split(";"c)
            statement = statement.Trim
            If Not String.IsNullOrEmpty(statement) Then

                _targetDB.ExecuteNonQuery(statement)
                _databaseScriptWriter.WriteLine(statement + ";")

            End If
        Next

        _databaseScriptWriter.Close()
        _databaseScriptWriter.Dispose()
    End Sub


    ''' <summary>
    ''' Add the Variable to the Dictionary
    ''' </summary>
    ''' <param name="variable"></param>
    ''' <param name="subjectVariables"></param>
    ''' <param name="sectionVariables"></param>
    ''' <param name="questionnaireVariables"></param>
    ''' <param name="variableScope"></param>
    ''' <remarks></remarks>
    Private Sub RegisterVariable(ByVal variable As VariableDB, ByVal subjectVariables As Dictionary(Of String, VariableDB), _
                                            ByVal sectionVariables As Dictionary(Of String, VariableDB), _
                                            ByVal questionnaireVariables As Dictionary(Of String, VariableDB), ByVal variableScope As BO.VariableScopes)
        If variable IsNot Nothing Then
            Select Case variableScope
                Case BO.VariableScopes.QuestionnaireSet
                    Try
                        subjectVariables.Add(variable.VariableName, variable)
                    Catch ex As System.ArgumentException
                    End Try
                Case BO.VariableScopes.Section
                    Try
                        sectionVariables.Add(variable.VariableName, variable)
                    Catch ex As System.ArgumentException
                    End Try
                Case BO.VariableScopes.Questionnaire
                    Try
                        questionnaireVariables.Add(variable.VariableName, variable)
                    Catch ex As System.ArgumentException
                    End Try
            End Select
        End If
    End Sub


    ''' <summary>
    ''' Register an Asigned variable
    ''' </summary>
    ''' <param name="variables"></param>
    ''' <param name="subjectVariables"></param>
    ''' <param name="sectionVariables"></param>
    ''' <param name="questionnaireVariables"></param>
    ''' <param name="variablesScope"></param>
    ''' <remarks></remarks>
    Private Sub RegisterAssignVariables(ByVal variables As List(Of BO.Variable), ByVal subjectVariables As Dictionary(Of String, VariableDB), _
                                            ByVal sectionVariables As Dictionary(Of String, VariableDB), _
                                    ByVal questionnaireVariables As Dictionary(Of String, VariableDB), ByVal variablesScope As BO.VariableScopes)

        Dim variable As VariableDB

        For Each currentVaraible As BO.Variable In variables

            If currentVaraible.VariableName.Trim <> "" Then
                ' Throw New Exception(String.Format("{0}, Question #{1}.  Variable name can't be empty ", errorMessage, currentQuestion.Number))

                variable = New VariableDB()

                variable.VariableName = currentVaraible.VariableName
                variable.DataType = currentVaraible.DataType
                variable.MainText = currentVaraible.MainText

                RegisterVariable(variable, subjectVariables, sectionVariables, questionnaireVariables, variablesScope)

            End If

        Next

    End Sub


    ''' <summary>
    ''' Populate the subjectVaraibles and the sectionVariables from the questions of the currentNode
    ''' </summary>
    ''' <param name="currentNode"></param>
    ''' <param name="subjectVariables"></param>
    ''' <param name="sectionVariables"></param>
    ''' <param name="errorMessage">Have to be "QuestionnaireSet, Questionnaire, Section"</param>
    ''' <remarks></remarks>
    Private Sub GenerateSectionOrCheckpointContent(ByVal currentNode As BO.GenericObject, _
                ByVal subjectVariables As Dictionary(Of String, VariableDB), ByVal sectionVariables As Dictionary(Of String, VariableDB), _
                ByVal questionnaireVariables As Dictionary(Of String, VariableDB), ByVal errorMessage As String)

        Dim listOfSectionItems As List(Of BO.SectionItem) = New List(Of BO.SectionItem)
        Dim variable As VariableDB
        Dim currentQuestion As BO.Question


        Select Case currentNode.GetType.ToString
            Case GetType(BO.Section).ToString
                listOfSectionItems = CType(currentNode, BO.Section).SectionItems
            Case GetType(BO.CheckPoint).ToString
                listOfSectionItems = CType(currentNode, BO.CheckPoint).SectionItems
        End Select

        For Each currentSectionItem As BO.SectionItem In listOfSectionItems

            Select Case currentSectionItem.GetType.ToString
                Case GetType(BO.Question).ToString

                    currentQuestion = CType(currentSectionItem, BO.Question)
                    variable = Nothing

                    '*******CheckBox***********
                    ' if it is a checkbox then we create a variable for each legal value.
                    If Not String.IsNullOrEmpty(currentQuestion.LegalValueTable) And _
                                (Not String.IsNullOrEmpty(currentQuestion.ScreenTemplate) _
                                AndAlso currentQuestion.ScreenTemplate.ToLower = "checkbox") Then

                        Dim legalValueTableTemp As BO.LegalValuesTable = BO.Study.GetLegalValuesByName(currentQuestion.LegalValueTable)

                        If legalValueTableTemp IsNot Nothing Then

                            For Each item As BO.LegalValueItem In legalValueTableTemp.LegalValues

                                variable = New VariableDB()

                                variable.VariableName = currentQuestion.VariableName & item.ShortName
                                variable.DataType = "bit"
                                variable.MainText = item.Text

                                RegisterVariable(variable, subjectVariables, sectionVariables, questionnaireVariables, currentQuestion.VariableScope)
                            Next

                        End If
                        '*************

                        '**********GPSReading***********
                    ElseIf (Not String.IsNullOrEmpty(currentQuestion.ScreenTemplate) _
                            AndAlso currentQuestion.ScreenTemplate.ToLower = "GPSReading".ToLower) Then


                        '--------Variable DecLat---------
                        variable = New VariableDB()

                        variable.VariableName = currentQuestion.VariableName & "DecLat"
                        variable.DataType = "float"
                        variable.MainText = currentQuestion.VariableName & "DecLat"

                        RegisterVariable(variable, subjectVariables, sectionVariables, questionnaireVariables, currentQuestion.VariableScope)
                        '--------------------------------

                        '--------Variable DecLon---------
                        variable = New VariableDB()

                        variable.VariableName = currentQuestion.VariableName & "DecLon"
                        variable.DataType = "float"
                        variable.MainText = currentQuestion.VariableName & "DecLon"

                        RegisterVariable(variable, subjectVariables, sectionVariables, questionnaireVariables, currentQuestion.VariableScope)
                        '--------------------------------

                        '--------Variable Lat---------
                        variable = New VariableDB()

                        variable.VariableName = currentQuestion.VariableName & "Lat"
                        variable.DataType = "nvarchar(50)"
                        variable.MainText = currentQuestion.VariableName & "Lat"

                        RegisterVariable(variable, subjectVariables, sectionVariables, questionnaireVariables, currentQuestion.VariableScope)
                        '--------------------------------

                        '--------Variable Lon---------
                        variable = New VariableDB()

                        variable.VariableName = currentQuestion.VariableName & "Lon"
                        variable.DataType = "nvarchar(50)"
                        variable.MainText = currentQuestion.VariableName & "Lon"

                        RegisterVariable(variable, subjectVariables, sectionVariables, questionnaireVariables, currentQuestion.VariableScope)
                        '--------------------------------

                        '--------Variable PDOP---------
                        variable = New VariableDB()

                        variable.VariableName = currentQuestion.VariableName & "PDOP"
                        variable.DataType = "float"
                        variable.MainText = currentQuestion.VariableName & "PDOP"

                        RegisterVariable(variable, subjectVariables, sectionVariables, questionnaireVariables, currentQuestion.VariableScope)
                        '--------------------------------

                        '--------Variable HDOP---------
                        variable = New VariableDB()

                        variable.VariableName = currentQuestion.VariableName & "HDOP"
                        variable.DataType = "float"
                        variable.MainText = currentQuestion.VariableName & "HDOP"

                        RegisterVariable(variable, subjectVariables, sectionVariables, questionnaireVariables, currentQuestion.VariableScope)
                        '--------------------------------

                        '--------Variable Sat---------
                        variable = New VariableDB()

                        variable.VariableName = currentQuestion.VariableName & "Sat"
                        variable.DataType = "integer"
                        variable.MainText = currentQuestion.VariableName & "Sat"

                        RegisterVariable(variable, subjectVariables, sectionVariables, questionnaireVariables, currentQuestion.VariableScope)
                        '--------------------------------

                        '********************************
                    ElseIf currentQuestion.VariableName.Trim <> "" Then
                        ' Throw New Exception(String.Format("{0}, Question #{1}.  Variable name can't be empty ", errorMessage, currentQuestion.Number))

                        variable = New VariableDB()

                        variable.DataType = currentQuestion.DataType
                        variable.LegalValueTable = currentQuestion.LegalValueTable
                        variable.MainText = currentQuestion.MainText
                        variable.VariableName = currentQuestion.VariableName

                        RegisterVariable(variable, subjectVariables, sectionVariables, questionnaireVariables, currentQuestion.VariableScope)

                    End If


                Case GetType(BO.CheckPoint).ToString
                    GenerateSectionOrCheckpointContent(currentSectionItem, subjectVariables, sectionVariables, questionnaireVariables, errorMessage)
            End Select

        Next

    End Sub


    ''' <summary>
    ''' Add a list of variables to the dictionary, the key is the VariableName
    ''' </summary>
    ''' <param name="fields"></param>
    ''' <param name="variables"></param>
    ''' <param name="tableName"></param>
    ''' <remarks></remarks>
    Private Sub AddVariablesToDictionary(ByVal fields As Dictionary(Of String, String), ByVal variables As List(Of VariableDB), ByVal tableName As String)

        If variables.Count > 0 Then

            For Each variable As VariableDB In variables

                Dim keyParameter As String = variable.VariableName
                Dim postfix As Integer = 1

                While fields.ContainsKey(keyParameter)
                    keyParameter = String.Format("{0}_{1}", variable.VariableName, postfix.ToString)
                    postfix += 1
                End While

                fields.Add(keyParameter, String.Format(" [{0}].[{1}] AS [{2}] ", tableName, variable.VariableName, keyParameter))

            Next

        End If

    End Sub


    Private Sub InsertStudy(ByVal study As BO.Study)
        Dim query As String

        query = String.Format("INSERT INTO [dbo].[Study] (ShortName, Name, Version, DesignerVersion,CreationDateTime," & _
                    " LastModificationDateTime) VALUES  ('{0}', '{1}', '{2}', '{3}', '{4}'," & _
                    " '{5}')", study.ShortName, study.Name, _
                    study.Version, My.Application.Info.Version.ToString, _
                    CType(study.CreationDateTime, DateTime).ToString("yyyyMMdd HH:mm:ss"), _
                    CType(study.lastModification, DateTime).ToString("yyyyMMdd HH:mm:ss"))

        _mainQuery &= query & ";" & Environment.NewLine
        '_databaseScriptWriter.WriteLine(query + ";" + Environment.NewLine)
        '_targetDB.ExecuteNonQuery(query)

    End Sub

#End Region

End Class

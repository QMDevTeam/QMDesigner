Imports system.Data.SqlServerCe

Public Class Generator

#Region "Properties"

    Private _inputFileName As String
    Private _outputFolder As String
    Private _scriptsFolder As String
    private _pdaFilesFolder as string

#End Region



#Region "Public methods"

    Public Sub Generate(ByVal inputFileName As String, ByVal outputFolder As String)

        Me._inputFileName = inputFileName
        Me._outputFolder = outputFolder
        Me._scriptsFolder = My.Application.Info.DirectoryPath & "\Scripts"
        Me._pdaFilesFolder = My.Application.Info.DirectoryPath & "\PDA Files"

        Dim source As Source.DA.Source = Nothing
        Dim configDB As DBCE.DA.ConfigDB = Nothing
        Dim dataDB As DBCE.DA.DataDB = Nothing
        Dim comp As Compiler
        Dim codeBuilder As CodeBuilder
        Dim cabBuilder As CabBuilder
        'Try
        source = New Source.DA.Source(String.Format("DataSource={0}; File Mode=Read Only;Persist Security Info=False;Temp Path={1};", _inputFileName, IO.Path.GetTempPath))
        configDB = New DBCE.DA.ConfigDB(source.CurrentStudy.ShortName, _scriptsFolder, _outputFolder)
        dataDB = New DBCE.DA.DataDB(source.CurrentStudy.ShortName, _scriptsFolder, _outputFolder)
        codeBuilder = New CodeBuilder(BO.ContextClass.Study)
        comp = New Compiler(codeBuilder.Namespaces, BO.ContextClass.Study.Version)
        cabBuilder = New CabBuilder(_outputFolder, BO.ContextClass.Study.ShortName)

        CopyFixedObjects(source, configDB)
        GenerateStudy(source, configDB, dataDB)

        configDB.ExecutePostGenerationScript()
        dataDB.ExecutePostGenerationScript()

        ' Add the files to the cab files and to the code references.
        For Each file As BO.File In BO.Study.Files

            cabBuilder.AddFile(file.ReferencePath)
            If Not String.IsNullOrEmpty(file.CodeNamespace) Then comp.References.Add(file.ReferencePath)

        Next

        Dim errors As String = Nothing
        comp.References.Add(Me._pdaFilesFolder & "\QM.PDA.BO.dll")
        comp.References.Add(Me._pdaFilesFolder & "\QM.PDA.DA.dll")
        comp.References.Add(Me._pdaFilesFolder & "\QM.PDA.Screens.dll")
        If Not comp.Compile(String.Format("{0}\{1}.QM.dll", _outputFolder, BO.ContextClass.Study.ShortName), errors) Then
            Throw New Exception(errors)
        End If

        'Catch ex As Exception

        'Dim errorMessage As String = "Error"
        'If source IsNot Nothing Then
        '    If source.CurrentStudy IsNot Nothing Then errorMessage &= " in " & source.CurrentStudy.ShortName
        '    If source.CurrentQuestionnaireSet IsNot Nothing Then errorMessage &= "\" & source.CurrentQuestionnaireSet.ShortName
        '    If source.CurrentQuestionnaire IsNot Nothing Then errorMessage &= "\" & source.CurrentQuestionnaire.ShortName
        '    If source.CurrentSection IsNot Nothing Then errorMessage &= "\" & source.CurrentSection.ShortName
        '    If source.CurrentSectionItem IsNot Nothing Then errorMessage &= String.Format("[{0}] {1}", IIf(source.CurrentSectionItem.Number IsNot Nothing, source.CurrentSectionItem.Number, source.CurrentSectionItem.Ordinal), source.CurrentSectionItem.MainText)
        'End If

        'Throw New ApplicationException(errorMessage, ex)

        'Finally

        If Not source Is Nothing Then source.Close()
        If Not configDB Is Nothing Then configDB.Close()
        If Not dataDB Is Nothing Then dataDB.Close()

        cabBuilder.BuildCab()

        'End Try

    End Sub

#End Region



#Region " Private Methods "

    Private Sub CopyFixedObjects(ByVal source As Source.DA.Source, ByVal configDB As DBCE.DA.ConfigDB)

        CopyTables(source.Connection, configDB.Connection, "ScreenTemplate", "[ScreenTemplateID], [DotNETClassName]")
        CopyTables(source.Connection, configDB.Connection, "Site", "*")
        CopyTables(source.Connection, configDB.Connection, "Report", "*")
        CopyTables(source.Connection, configDB.Connection, "ReportColumn", "*")
        CopyTables(source.Connection, configDB.Connection, "ReportSite", "*")
        CopyTables(source.Connection, configDB.Connection, "PDAUser", "*")
        
    End Sub


    Private Sub GenerateStudy(ByVal source As Source.DA.Source, ByVal configDB As DBCE.DA.ConfigDB, ByVal dataDB As DBCE.DA.DataDB)

        Dim screenId As Integer = 1

        Dim subjectVariables As Dictionary(Of String, Entities.Variable)
        Dim questionnaireVariables As Dictionary(Of String, Entities.Variable)
        Dim sectionVariables As Dictionary(Of String, Entities.Variable)

        Dim legalValueTables As New List(Of String)



        Dim study As Entities.Study = source.CurrentStudy
        study.GeneratorVersion = Reflection.Assembly.GetExecutingAssembly.GetName.Version.ToString
        study.GenerationDateTime = Now

        configDB.InsertStudy(source.CurrentStudy)
        dataDB.InsertStudy(source.CurrentStudy)


        While source.ReadNextQuestionnaireSet

            subjectVariables = New Collections.Generic.Dictionary(Of String, Entities.Variable)
            configDB.InsertQuestionnaireSet(source.CurrentQuestionnaireSet)


            While source.ReadNextQuestionnaire()

                questionnaireVariables = New Collections.Generic.Dictionary(Of String, Entities.Variable)
                configDB.InsertQuestionnaire(source.CurrentQuestionnaire)


                While source.ReadNextSection()

                    sectionVariables = New Collections.Generic.Dictionary(Of String, Entities.Variable)

                    source.CurrentSection.StartScreenID = screenId
                    GenerateSectionContent(source, configDB, subjectVariables, questionnaireVariables, sectionVariables, legalValueTables, screenId)
                    source.CurrentSection.ExitScreenID = screenId - 1
                    configDB.InsertSection(source.CurrentSection)

                    dataDB.CreateSectionTable(source.CurrentQuestionnaireSet.QuestionnaireSetID, source.CurrentQuestionnaire.QuestionnaireID, source.CurrentSection.SectionID, sectionVariables)

                End While

                dataDB.CreateQuestionnaireTable(source.CurrentQuestionnaireSet.QuestionnaireSetID, source.CurrentQuestionnaire.QuestionnaireID, questionnaireVariables)

            End While

            dataDB.CreateSubjectTable(source.CurrentQuestionnaireSet.QuestionnaireSetID, subjectVariables)

        End While

    End Sub


    Private Sub GenerateSectionContent(ByVal source As Source.DA.Source, ByVal configDB As DBCE.DA.ConfigDB, ByVal subjectVariables As Dictionary(Of String, Entities.Variable), ByVal questionnaireVariables As Dictionary(Of String, Entities.Variable), ByVal sectionVariables As Dictionary(Of String, Entities.Variable), ByVal legalValueTables As List(Of String), ByRef screenId As Integer)

        Dim currentScreen As Entities.Screen
        Dim previousScreen As Entities.Screen = Nothing
        Dim currentItem As Entities.SectionItem
        Dim methodNamesList As New List(Of String)

        Dim transitionToNextScreen As Entities.Transition = Nothing
        Dim bifurcations As New Stack(Of BifurcationPoint)
        Dim transitionsToStore As New List(Of Entities.Transition)


        While source.ReadNextSectionItem()

            currentItem = source.CurrentSectionItem


            Select Case currentItem.Type.ToLower

                Case "variable" ' If this item is a variable declaration, register the variable.
                    RegisterVariableFromSectionItem(source, configDB, subjectVariables, questionnaireVariables, sectionVariables, currentItem, Nothing, True)

                    ' Legal Values table
                    '----------------------------------------------------------------------------
                    If Not String.IsNullOrEmpty(currentItem.LegalValueTable) Then

                        Dim legalValueTableItems As List(Of Entities.LegalValueTableItem) = source.GetLegalValueTableItems(currentItem.LegalValueTable)

                        ' If the Legal Value Table doesn't exist yet, create it.
                        If Not legalValueTables.Contains(currentItem.LegalValueTable.ToLower) Then
                            configDB.InsertLegalValueTable(currentItem.LegalValueTable, legalValueTableItems)
                            legalValueTables.Add(currentItem.LegalValueTable.ToLower)
                        End If

                        ' If this section item will use the CheckBox screen template, then register each option as a variable.
                        If Not String.IsNullOrEmpty(currentItem.ScreenTemplate) AndAlso currentItem.ScreenTemplate.ToLower = "checkbox" Then
                            For Each item As Entities.LegalValueTableItem In legalValueTableItems
                                RegisterVariableForListItem(configDB, subjectVariables, questionnaireVariables, sectionVariables, currentItem, currentItem.VariableName + item.ShortName, "bit", item.Text)
                            Next
                        End If

                    End If
                    '----------------------------------------------------------------------------



                Case "info", "question", "checkpoint" ' If this item is an info screen, a question screen or a checkpoint...

                    ' Create a new Screen
                    currentScreen = New Entities.Screen
                    currentScreen.ScreenID = screenId
                    currentScreen.SectionID = source.CurrentSection.SectionID
                    currentScreen.Number = currentItem.Number

                    ' Events
                    currentScreen.OnChange = currentItem.OnChange
                    currentScreen.OnLoad = currentItem.OnLoad
                    currentScreen.OnUnload = currentItem.OnUnload


                    ' Transitions
                    '----------------------------------------------------------------------------
                    ' Complete the transition from the previous screen to this one.
                    If transitionToNextScreen IsNot Nothing Then
                        transitionToNextScreen.DestinationScreenID = currentScreen.ScreenID
                        transitionsToStore.Add(transitionToNextScreen)
                    End If


                    ' Create a new transition from the current screen to the next one.
                    transitionToNextScreen = New Entities.Transition
                    transitionToNextScreen.ScreenID = currentScreen.ScreenID
                    transitionToNextScreen.Order = 1


                    ' If this screen is a change to a lower level, complete the bifurcation transitions.
                    Dim bifurcationPoint As BifurcationPoint
                    While bifurcations.Count > 0 AndAlso currentItem.Level <= bifurcations.Peek.Level

                        bifurcationPoint = bifurcations.Pop()
                        bifurcationPoint.Transition.DestinationScreenID = currentScreen.ScreenID
                        transitionsToStore.Add(bifurcationPoint.Transition)

                    End While
                    '----------------------------------------------------------------------------



                    Select Case currentItem.Type.ToLower

                        Case "info"

                            ' Info Screen
                            '----------------------------------------------------------------------------

                            ' Map the columns
                            If currentItem.ScreenTemplate Is Nothing Then
                                currentScreen.ScreenTemplateID = 201 ' Default screen template for an Info Screen.
                            Else
                                currentScreen.ScreenTemplateID = source.GetScreenTemplate(currentItem.ScreenTemplate).ScreenTemplateID
                            End If

                            currentScreen.Name = "Info_" + currentItem.Number
                            currentScreen.Type = "Info"
                            currentScreen.MainText = currentItem.MainText
                            currentScreen.MainTextColor = currentItem.MainTextColor

                            currentScreen.HideNext = currentItem.HideNext
                            currentScreen.HideBack = currentItem.HideBack
                            currentScreen.ConfirmNext = currentItem.ConfirmNext
                            currentScreen.ConfirmBack = currentItem.ConfirmBack


                        Case "question"

                            ' Question Screen
                            '----------------------------------------------------------------------------

                            ' Map the common columns
                            currentScreen.ScreenTemplateID = source.GetScreenTemplate(currentItem.ScreenTemplate).ScreenTemplateID
                            currentScreen.Type = "Question"
                            currentScreen.VariableScope = currentItem.VariableScope ' For those screens without variable but with a lookup table with variables.
                            currentScreen.Arguments = currentItem.Arguments

                            currentScreen.MainTextColor = currentItem.MainTextColor
                            currentScreen.OtherText1Color = currentItem.OtherText1Color
                            currentScreen.OtherText2 = currentItem.OtherText2
                            currentScreen.OtherText2Color = currentItem.OtherText2Color
                            currentScreen.OtherText3 = currentItem.OtherText3
                            currentScreen.OtherText3Color = currentItem.OtherText3Color

                            currentScreen.CustomValidation = currentItem.CustomValidation
                            currentScreen.CustomValidationFailMessage = currentItem.CustomValidationFailMessage
                            currentScreen.ConfirmChange = currentItem.ConfirmChange
                            currentScreen.HideNext = currentItem.HideNext
                            currentScreen.HideBack = currentItem.HideBack
                            currentScreen.ConfirmNext = currentItem.ConfirmNext
                            currentScreen.ConfirmBack = currentItem.ConfirmBack

                            currentScreen.AbsMin = currentItem.AbsMin
                            currentScreen.AbsMax = currentItem.AbsMax
                            currentScreen.PromptOver = currentItem.PromptOver
                            currentScreen.PromptUnder = currentItem.PromptUnder

                            ' Group Text
                            '----------------------------------------------------------------------------
                            If currentItem.GroupText IsNot Nothing Then
                                currentScreen.OtherText1 = currentItem.GroupText
                            Else
                                currentScreen.OtherText1 = currentItem.OtherText1
                            End If
                            '----------------------------------------------------------------------------



                            ' If there is a variable declared and this screen is not CheckBox nor GPSReading
                            Select Case currentItem.ScreenTemplate.ToLower
                                Case "checkbox"

                                    currentScreen.Name = CStr(IIf(String.IsNullOrEmpty(currentItem.VariableName), "Question_" + currentItem.Number, currentItem.VariableName))
                                    currentScreen.VariableName = currentItem.VariableName

                                    currentScreen.MainText = currentItem.MainText
                                    currentScreen.HelpText = currentItem.HelpText

                                    currentScreen.Required = currentItem.Required
                                    currentScreen.AbsMin = currentItem.AbsMin
                                    currentScreen.AbsMax = currentItem.AbsMax
                                    currentScreen.PromptUnder = currentItem.PromptUnder
                                    currentScreen.PromptOver = currentItem.PromptOver
                                    currentScreen.LegalValueTable = currentItem.LegalValueTable

                                    'RegisterVariableFromSectionItem(source, configDB, subjectVariables, questionnaireVariables, sectionVariables, currentItem, currentScreen, False)

                                    ' The variables for each checkbox are declared below, in the Legal Value Table code.


                                Case "gpsreading"
                                    currentScreen.Name = CStr(IIf(String.IsNullOrEmpty(currentItem.VariableName), "Question_" + currentItem.Number, currentItem.VariableName))
                                    currentScreen.VariableName = currentItem.VariableName

                                    currentScreen.MainText = currentItem.MainText
                                    currentScreen.HelpText = currentItem.HelpText

                                    currentScreen.Required = currentItem.Required
                                    currentScreen.AbsMin = currentItem.AbsMin
                                    currentScreen.AbsMax = currentItem.AbsMax
                                    currentScreen.PromptUnder = currentItem.PromptUnder
                                    currentScreen.PromptOver = currentItem.PromptOver
                                    currentScreen.LegalValueTable = currentItem.LegalValueTable

                                    'RegisterVariableFromSectionItem(source, configDB, subjectVariables, questionnaireVariables, sectionVariables, currentItem, currentScreen, False)


                                    ' Define the fixed variables
                                    Dim prefix As String = currentItem.VariableName
                                    RegisterVariableForListItem(configDB, subjectVariables, questionnaireVariables, sectionVariables, currentItem, prefix & "DecLat", "float", "")
                                    RegisterVariableForListItem(configDB, subjectVariables, questionnaireVariables, sectionVariables, currentItem, prefix & "DecLon", "float", "")
                                    RegisterVariableForListItem(configDB, subjectVariables, questionnaireVariables, sectionVariables, currentItem, prefix & "Lat", "NVarChar(50)", "")
                                    RegisterVariableForListItem(configDB, subjectVariables, questionnaireVariables, sectionVariables, currentItem, prefix & "Lon", "NVarChar(50)", "")
                                    RegisterVariableForListItem(configDB, subjectVariables, questionnaireVariables, sectionVariables, currentItem, prefix & "PDOP", "float", "")
                                    RegisterVariableForListItem(configDB, subjectVariables, questionnaireVariables, sectionVariables, currentItem, prefix & "HDOP", "float", "")
                                    RegisterVariableForListItem(configDB, subjectVariables, questionnaireVariables, sectionVariables, currentItem, prefix & "Sat", "Integer", "")


                                Case Else
                                    If Not String.IsNullOrEmpty(currentItem.VariableName) Then

                                        currentScreen.Name = currentItem.VariableName
                                        currentScreen.VariableName = currentItem.VariableName

                                        RegisterVariableFromSectionItem(source, configDB, subjectVariables, questionnaireVariables, sectionVariables, currentItem, currentScreen, True)


                                    Else ' If there is no variable declared

                                        ' Map the columns
                                        currentScreen.Name = "Question_" + currentItem.Number

                                        currentScreen.MainText = currentItem.MainText
                                        currentScreen.HelpText = currentItem.HelpText

                                        currentScreen.Required = currentItem.Required
                                        currentScreen.AbsMin = currentItem.AbsMin
                                        currentScreen.AbsMax = currentItem.AbsMax
                                        currentScreen.PromptUnder = currentItem.PromptUnder
                                        currentScreen.PromptOver = currentItem.PromptOver
                                        currentScreen.LegalValueTable = currentItem.LegalValueTable

                                    End If


                            End Select




                            ' Legal Values table
                            '----------------------------------------------------------------------------
                            If Not String.IsNullOrEmpty(currentItem.LegalValueTable) Then

                                Dim legalValueTableItems As List(Of Entities.LegalValueTableItem) = source.GetLegalValueTableItems(currentItem.LegalValueTable)

                                ' If the Legal Value Table doesn't exist yet, create it.
                                If Not legalValueTables.Contains(currentItem.LegalValueTable.ToLower) Then
                                    configDB.InsertLegalValueTable(currentItem.LegalValueTable, legalValueTableItems)
                                    legalValueTables.Add(currentItem.LegalValueTable.ToLower)
                                End If

                                ' If this section item will use the CheckBox screen template, then register each option as a variable.
                                If Not String.IsNullOrEmpty(currentItem.ScreenTemplate) AndAlso currentItem.ScreenTemplate.ToLower = "checkbox" Then
                                    For Each item As Entities.LegalValueTableItem In legalValueTableItems
                                        RegisterVariableForListItem(configDB, subjectVariables, questionnaireVariables, sectionVariables, currentItem, currentItem.VariableName + item.ShortName, "bit", item.Text)
                                    Next
                                End If

                            End If
                            '----------------------------------------------------------------------------


                        Case "checkpoint" ' todo: Checkpoint Actions

                            ' Create a NOP screen for the CheckPoint.
                            currentScreen.Name = "NOP"
                            currentScreen.Type = "NOP"
                            transitionToNextScreen.Condition = True


                            ' Create and stack a bifurcation point with a transition to be completed later.
                            Dim bifurcationTransition As New Entities.Transition
                            bifurcationTransition.ScreenID = currentScreen.ScreenID
                            bifurcationTransition.Order = 2
                            bifurcations.Push(New BifurcationPoint(currentItem.Level, bifurcationTransition))


                    End Select


                    configDB.InsertScreen(currentScreen)
                    screenId += 1


                    For Each transitionToStore As Entities.Transition In transitionsToStore
                        configDB.InsertTransition(transitionToStore)
                    Next
                    transitionsToStore.Clear()


                    previousScreen = currentScreen

            End Select

        End While



        ' Exit Screen
        '----------------------------------------------------------------------------
        ' Create the Exit Screen.
        Dim exitScreen As New Entities.Screen
        exitScreen.ScreenID = screenId
        exitScreen.SectionID = source.CurrentSection.SectionID
        exitScreen.ScreenTemplateID = 301 ' Default screen template for an Exit Screen.
        exitScreen.Name = "Exit"
        exitScreen.Type = "Exit"
        configDB.InsertScreen(exitScreen)
        screenId += 1


        ' Finish the last transition and the bifurcation points.
        If transitionToNextScreen IsNot Nothing Then
            transitionToNextScreen.DestinationScreenID = exitScreen.ScreenID
            configDB.InsertTransition(transitionToNextScreen)
        End If


        Dim bifurcation As BifurcationPoint
        While bifurcations.Count > 0

            bifurcation = bifurcations.Pop()
            bifurcation.Transition.DestinationScreenID = exitScreen.ScreenID
            configDB.InsertTransition(bifurcation.Transition)

        End While
        '----------------------------------------------------------------------------

    End Sub


    Private Function RegisterDotNETClass(ByVal configDB As DBCE.DA.ConfigDB, ByVal conditionsDLL As DBCE.DA.ConditionsDLL, ByVal className As String) As Integer

        Dim dotNETClass As New Entities.DotNETClass
        dotNETClass.DotNETClassID = configDB.GetMaxID("DotNETClassID", "DotNETClass") + 1
        dotNETClass.DotNETClassName = className
        configDB.InsertDotNETClass(dotNETClass)

        Return dotNETClass.DotNETClassID

    End Function


    Private Sub RegisterMethod(ByVal configDB As DBCE.DA.ConfigDB, ByVal methodName As String, ByVal dotNETClassID As Integer, ByVal dotNETMethodName As String)

        Dim method As New Entities.Method
        method.MethodName = methodName
        method.DotNETClassID = dotNETClassID
        method.DotNETMethodName = dotNETMethodName

        configDB.InsertMethod(method)

    End Sub


    Private Function RegisterVariableFromSectionItem(ByVal source As Source.DA.Source, ByVal configDB As DBCE.DA.ConfigDB, ByVal subjectVariables As Dictionary(Of String, Entities.Variable), ByVal questionnaireVariables As Dictionary(Of String, Entities.Variable), ByVal sectionVariables As Dictionary(Of String, Entities.Variable), ByVal sectionItem As Entities.SectionItem, ByVal screen As Entities.Screen, ByVal createDataColumn As Boolean) As Entities.Variable

        ' If the Variable Scope is not defined, throw an exception.
        If Not sectionItem.VariableScopeType.HasValue Then Throw New ApplicationException(String.Format("The Scope for the Variable [{0}] is not defined", sectionItem.VariableName))


        ' If the variable doesn't exist in the Variables table, create it.
        Dim variable As Entities.Variable = configDB.GetVariable(sectionItem.VariableName)


        If variable Is Nothing Then

            variable = New Entities.Variable
            Dim screenTemplate As Entities.ScreenTemplate = source.GetScreenTemplate(sectionItem.ScreenTemplate)

            variable.VariableName = sectionItem.VariableName
            If sectionItem.ScreenTemplate.ToLower = "gpsreading" Then
                variable.DataType = screen.DataType
            ElseIf sectionItem.ScreenTemplate.ToLower = "decimal" Then
                variable.DataType = "numeric(18, 2)"
            Else
                variable.DataType = screenTemplate.DataType
            End If
            variable.MainText = sectionItem.MainText
            variable.HelpText = sectionItem.HelpText
            variable.Required = sectionItem.Required
            variable.AbsMin = sectionItem.AbsMin
            variable.AbsMax = sectionItem.AbsMax
            variable.PromptUnder = sectionItem.PromptUnder
            variable.PromptOver = sectionItem.PromptOver
            variable.LegalValueTable = sectionItem.LegalValueTable

            configDB.InsertVariable(variable)
        Else

            ' If there is a screen defined then override in the screen the section item properties that are different from the variable.
            If screen IsNot Nothing Then

                If sectionItem.MainText <> variable.MainText Then screen.MainText = sectionItem.MainText
                If sectionItem.HelpText <> variable.HelpText Then screen.HelpText = sectionItem.HelpText
                If Not NullableOfBooleanEquals(sectionItem.Required, variable.Required) Then screen.Required = sectionItem.Required
                If sectionItem.AbsMin <> variable.AbsMin Then screen.AbsMin = sectionItem.AbsMin
                If sectionItem.AbsMax <> variable.AbsMax Then screen.AbsMax = sectionItem.AbsMax
                If sectionItem.PromptUnder <> variable.PromptUnder Then screen.PromptUnder = sectionItem.PromptUnder
                If sectionItem.PromptOver <> variable.PromptOver Then screen.PromptOver = sectionItem.PromptOver
                If sectionItem.LegalValueTable <> variable.LegalValueTable Then screen.LegalValueTable = sectionItem.LegalValueTable

            End If

        End If


        ' If the variable needs a data column, add it to the corresponding list.
        If createDataColumn Then
            Select Case sectionItem.VariableScopeType.Value
                Case Entities.SectionItem.VariableScopeEnum.Section : If Not sectionVariables.ContainsKey(variable.VariableName) Then sectionVariables.Add(variable.VariableName, variable)
                Case Entities.SectionItem.VariableScopeEnum.Questionnaire : If Not questionnaireVariables.ContainsKey(variable.VariableName) Then questionnaireVariables.Add(variable.VariableName, variable)
                Case Entities.SectionItem.VariableScopeEnum.Subject : If Not subjectVariables.ContainsKey(variable.VariableName) Then subjectVariables.Add(variable.VariableName, variable)
            End Select
        End If


        Return variable

    End Function


    Private Function RegisterVariableForListItem(ByVal configDB As DBCE.DA.ConfigDB, ByVal subjectVariables As Dictionary(Of String, Entities.Variable), ByVal questionnaireVariables As Dictionary(Of String, Entities.Variable), ByVal sectionVariables As Dictionary(Of String, Entities.Variable), ByVal sectionItem As Entities.SectionItem, ByVal variableName As String, ByVal dataType As String, ByVal mainText As String) As Entities.Variable

        ' If the Variable Scope is not defined, throw an exception.
        If Not sectionItem.VariableScopeType.HasValue Then Throw New ApplicationException(String.Format("The Scope for the Variable [{0}] is not defined", variableName))


        ' If the variable doesn't exist in the Variables table, create it.
        Dim variable As Entities.Variable = configDB.GetVariable(variableName)


        If variable Is Nothing Then

            variable = New Entities.Variable

            variable.VariableName = variableName
            variable.DataType = dataType
            variable.MainText = mainText

            configDB.InsertVariable(variable)
        End If


        ' Add the variable to the corresponding list.
        Select Case sectionItem.VariableScopeType.Value
            Case Entities.SectionItem.VariableScopeEnum.Section : If Not sectionVariables.ContainsKey(variable.VariableName) Then sectionVariables.Add(variable.VariableName, variable)
            Case Entities.SectionItem.VariableScopeEnum.Questionnaire : If Not questionnaireVariables.ContainsKey(variable.VariableName) Then questionnaireVariables.Add(variable.VariableName, variable)
            Case Entities.SectionItem.VariableScopeEnum.Subject : If Not subjectVariables.ContainsKey(variable.VariableName) Then subjectVariables.Add(variable.VariableName, variable)
        End Select


        Return variable

    End Function


    Private Function RegisterActions(ByVal configDB As DBCE.DA.ConfigDB, ByVal subjectVariables As Dictionary(Of String, Entities.Variable), ByVal questionnaireVariables As Dictionary(Of String, Entities.Variable), ByVal sectionVariables As Dictionary(Of String, Entities.Variable), ByVal actions As List(Of Entities.Action)) As Integer

        ' Get a Procedure ID
        Dim procedureID As Integer = configDB.GetMaxID("ProcedureID", "ProcedureStep") + 1


        ' Create a Procedure Step for each Action
        Dim procedureStep As Entities.ProcedureStep
        Dim action As Entities.Action

        For idx As Integer = 0 To actions.Count - 1

            action = actions(idx)
            procedureStep = New Entities.ProcedureStep

            procedureStep.ProcedureID = procedureID
            procedureStep.Order = idx + 1

            Select Case action.Type.ToLower

                Case "callexternal"
                    procedureStep.MethodName = action.Target
                    procedureStep.MethodArguments = action.Argument


                Case "assign"

                    ' If a scope was not determined, look for the variable in the lists
                    If action.Argument Is Nothing Then
                        Select Case True
                            Case sectionVariables.ContainsKey(action.Target) : procedureStep.MethodName = "QM.AssignSectionVariable"
                            Case questionnaireVariables.ContainsKey(action.Target) : procedureStep.MethodName = "QM.AssignQuestionnaireVariable"
                            Case subjectVariables.ContainsKey(action.Target) : procedureStep.MethodName = "QM.AssignSubjectVariable"
                        End Select

                    Else ' Else, use the specified scope
                        Select Case action.Argument.ToLower
                            Case "section" : procedureStep.MethodName = "QM.AssignSectionVariable"
                            Case "questionnaire" : procedureStep.MethodName = "QM.AssignQuestionnaireVariable"
                            Case "subject" : procedureStep.MethodName = "QM.AssignSubjectVariable"
                        End Select
                    End If

                    ' If a scope couldn't be determined, throw an exception
                    If procedureStep.MethodName Is Nothing Then Throw New ApplicationException(String.Format("The scope of the variable [{0}] was not determined", action.Target))

                    procedureStep.MethodArguments = action.Target + "," + action.Argument


                Case "delete"

                    ' If a scope was not determined, look for the variable in the lists
                    If action.Argument Is Nothing Then
                        Select Case True
                            Case sectionVariables.ContainsKey(action.Target) : procedureStep.MethodName = "QM.ClearSectionVariable"
                            Case questionnaireVariables.ContainsKey(action.Target) : procedureStep.MethodName = "QM.ClearQuestionnaireVariable"
                            Case subjectVariables.ContainsKey(action.Target) : procedureStep.MethodName = "QM.ClearSubjectVariable"
                        End Select

                    Else ' Else, use the specified scope
                        Select Case action.Argument.ToLower
                            Case "section" : procedureStep.MethodName = "QM.ClearSectionVariable"
                            Case "questionnaire" : procedureStep.MethodName = "QM.ClearQuestionnaireVariable"
                            Case "subject" : procedureStep.MethodName = "QM.ClearSubjectVariable"
                        End Select
                    End If

                    ' If a scope couldn't be determined, throw an exception
                    If procedureStep.MethodName Is Nothing Then Throw New ApplicationException(String.Format("The scope of the variable [{0}] was not determined", action.Target))

                    procedureStep.MethodArguments = action.Target

            End Select


            configDB.InsertProcedureStep(procedureStep)

        Next


        Return procedureID

    End Function


    Private Function NullableOfBooleanEquals(ByVal a As Nullable(Of Boolean), ByVal b As Nullable(Of Boolean)) As Boolean

        If Not a.HasValue And Not b.HasValue Then Return True
        If a.HasValue And Not b.HasValue Then Return False
        If b.HasValue And Not a.HasValue Then Return False
        Return Boolean.Equals(a.Value, b.Value)

    End Function


    Private Function BuildDotNETMethodName(ByVal methodNamesList As List(Of String), ByVal condition As String) As String

        Dim idx As Integer = 0
        While idx < condition.Length
            If Not Char.IsLetterOrDigit(condition, idx) And Not condition(idx) = " "c Then condition = condition.Remove(idx, 1) Else idx += 1
        End While


        Dim candidateMethodName As String = condition.Replace(" "c, "_"c)
        Dim methodName As String = candidateMethodName

        idx = 1
        While (methodNamesList.Contains(methodName.ToLower))
            methodName = String.Format("{0}_{1}", candidateMethodName, idx)
            idx += 1
        End While


        methodNamesList.Add(methodName.ToLower)
        Return methodName

    End Function


    Private Function ConvertVariables(ByVal subjectVariables As Dictionary(Of String, Entities.Variable), ByVal questionnaireVariables As Dictionary(Of String, Entities.Variable), ByVal sectionVariables As Dictionary(Of String, Entities.Variable), ByVal expression As String) As String

        ' Find the first variable (@)
        Dim variableNameStartPosition As Integer = expression.IndexOf("@"c)
        Dim variableNameEndPosition As Integer
        Dim variableNameEnding As String
        Dim variableName As String


        ' While a variable (@) has been found...
        While variableNameStartPosition <> -1

            ' Find the end of the variable name.
            variableNameEndPosition = expression.IndexOf(" ", variableNameStartPosition)


            ' Get the variable name.
            ' If the variable is at the end of the line...
            If variableNameEndPosition = -1 Then
                variableNameEnding = ""
                variableName = expression.Substring(variableNameStartPosition + 1, expression.Length - variableNameStartPosition - 1)
            Else
                variableNameEnding = " "
                variableName = expression.Substring(variableNameStartPosition + 1, variableNameEndPosition - variableNameStartPosition - 1)
            End If


            ' Look for the variable in the variable collections.
            Select Case True
                Case sectionVariables.ContainsKey(variableName)
                    expression = expression.Replace("@" + variableName + variableNameEnding, "CurrentSection(""" + variableName + """)" + variableNameEnding)
                Case questionnaireVariables.ContainsKey(variableName)
                    expression = expression.Replace("@" + variableName + variableNameEnding, "CurrentQuestionnaire(""" + variableName + """)" + variableNameEnding)
                Case subjectVariables.ContainsKey(variableName)
                    expression = expression.Replace("@" + variableName + variableNameEnding, "CurrentSubject(""" + variableName + """)" + variableNameEnding)
                Case Else
                    Throw New ApplicationException("The variable [" + variableName + "] hasn't been defined yet." + vbCrLf + "Expression: " + expression)
            End Select


            ' Find the next variable name.
            variableNameStartPosition = expression.IndexOf("@"c)

        End While


        Return expression

    End Function


    Private Sub CopyTables(ByVal source As SqlCeConnection, ByVal target As SqlCeConnection, ByVal table As String, ByVal columns As String)

        Dim query As String = String.Format("SELECT {0} FROM [{1}]", columns, table)
        Dim newRow As DataRow

        ' Get the data from the source table.
        Dim sourceDataAdapter As New SqlCeDataAdapter(query, source)
        Dim sourceTable As New DataTable
        sourceDataAdapter.Fill(sourceTable)

        ' Create the target data adapter.
        Dim targetDataAdapter As New SqlCeDataAdapter(query, target)
        Dim cb As New SqlCeCommandBuilder(targetDataAdapter)
        targetDataAdapter.UpdateCommand = cb.GetUpdateCommand
        targetDataAdapter.InsertCommand = cb.GetInsertCommand
        targetDataAdapter.DeleteCommand = cb.GetDeleteCommand

        Dim targetTable As New DataTable
        targetDataAdapter.FillSchema(targetTable, SchemaType.Source)

        ' Copy each row.
        For Each row As DataRow In sourceTable.Rows

            newRow = targetTable.NewRow()
            For i As Integer = 0 To targetTable.Columns.Count - 1 : newRow(i) = row(i) : Next
            targetTable.Rows.Add(newRow)

        Next
        ' Commit.
        targetDataAdapter.Update(targetTable)

    End Sub

#End Region



#Region " Classes "

    Class BifurcationPoint

        Public Level As Integer
        Public Transition As Entities.Transition


        Public Sub New(ByVal level As Integer, ByVal transition As Entities.Transition)
            Me.Level = level
            Me.Transition = transition
        End Sub

    End Class

#End Region

End Class

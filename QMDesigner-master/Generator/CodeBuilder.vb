Imports System.CodeDom

Public Class CodeBuilder


#Region "Properties"

    Private _importList As New List(Of String)

    Private _namespaces As CodeNamespaceCollection

    Private _commonNamespace As CodeNamespace
    Private _commonClass As CodeTypeDeclaration
    Private _preconditionsClass As CodeTypeDeclaration
    Private _constructorsClass As CodeTypeDeclaration
    Private _methodNames As List(Of String)

    Private _currentConditionsNamespace As CodeNamespace
    Private _currentConditionsClass As CodeTypeDeclaration

    Private _currentValidationsNamespace As CodeNamespace
    Private _currentValidationsClass As CodeTypeDeclaration

    Private _currentEventsNamespace As CodeNamespace
    Private _currentEventsClass As CodeTypeDeclaration

    Private _questionnairesetVariables As List(Of String)
    Private _questionnaireVariables As List(Of String)
    Private _sectionVariables As List(Of String)

    Private Shared _booleanCodeTypeReference As New CodeTypeReference(GetType(Boolean))
    Private Shared _objectCodeTypeReference As New CodeTypeReference(GetType(Object))
    Private Shared _QM_PDA_Import As New CodeNamespaceImport("QM.PDA")
    Private Shared _QM_PDA_BO_Context_Import As New CodeNamespaceImport("QM.PDA.BO.Context")


    Public Property ImportList() As List(Of String)
        Get
            Return _importList
        End Get
        Set(ByVal value As List(Of String))
            Me._importList = value
        End Set
    End Property


    Public ReadOnly Property Namespaces() As CodeNamespaceCollection
        Get

            Dim namespaceIndex As Integer = 0
            Dim typeIndex As Integer

            While namespaceIndex < Me._namespaces.Count

                typeIndex = 0

                While typeIndex < Me._namespaces(namespaceIndex).Types.Count

                    If Me._namespaces(namespaceIndex).Types(typeIndex).Members.Count = 0 Then
                        Me._namespaces(namespaceIndex).Types.RemoveAt(typeIndex)
                    Else
                        typeIndex += 1
                    End If

                End While

                If Me._namespaces(namespaceIndex).Types.Count = 0 Then
                    Me._namespaces.RemoveAt(namespaceIndex)
                Else
                    namespaceIndex += 1
                End If

            End While

            Return Me._namespaces
        End Get
    End Property

#End Region



#Region "Public Methods"

    Public Sub New(ByVal study As BO.Study)

        Me._namespaces = New CodeNamespaceCollection()
        Me._questionnairesetVariables = New List(Of String)
        Me._questionnaireVariables = New List(Of String)
        Me._sectionVariables = New List(Of String)

        ' Common namespace.
        Me._commonNamespace = New CodeNamespace(String.Format("{0}.QM", study.ShortName))
        Me._commonNamespace.Imports.Add(CodeBuilder._QM_PDA_Import)
        Me._commonNamespace.Imports.Add(CodeBuilder._QM_PDA_BO_Context_Import)

        Me._commonClass = New CodeTypeDeclaration("Common")
        Me._commonNamespace.Types.Add(Me._commonClass)

        Me._preconditionsClass = New CodeTypeDeclaration("Preconditions")
        Me._commonNamespace.Types.Add(Me._preconditionsClass)

        Me._constructorsClass = New CodeTypeDeclaration("Constructors")
        Me._commonNamespace.Types.Add(Me._constructorsClass)

        Me._namespaces.Add(Me._commonNamespace)
        Me._methodNames = New List(Of String)

        ' Fill the namelist.
        For Each method As BO.Method In BO.Study.Methods : Me._methodNames.Add(method.Name.ToLower()) : Next

        ' Build the common class.
        For Each method As BO.Method In BO.Study.Methods
            Me._commonClass.Members.Add(New CodeSnippetTypeMember(resolveAbbreviations(method.Code)))
        Next

        ' Build the namespaces based on the study design.
        For Each questionnaireset As BO.QuestionnaireSet In study.QuestionnarieSets

            ' Precondition and constructor.
            buildPrecondition(questionnaireset.ShortName, questionnaireset.PreCondition)
            buildConstructor(String.Format("OnNewSubject_{0}", questionnaireset.ShortName), questionnaireset.OnNewSubject)

            ' Conditions namespace.
            Me._currentConditionsNamespace = New CodeNamespace(String.Format("{0}.QM.Conditions.{1}", study.ShortName, questionnaireset.ShortName))
            Me._currentConditionsNamespace.Imports.Add(CodeBuilder._QM_PDA_Import)
            Me._currentConditionsNamespace.Imports.Add(CodeBuilder._QM_PDA_BO_Context_Import)
            Me._namespaces.Add(Me._currentConditionsNamespace)
            registerContainerVariables(questionnaireset)

            ' Validations namespace.
            Me._currentValidationsNamespace = New CodeNamespace(String.Format("{0}.QM.Validations.{1}", study.ShortName, questionnaireset.ShortName))
            Me._currentValidationsNamespace.Imports.Add(CodeBuilder._QM_PDA_Import)
            Me._currentValidationsNamespace.Imports.Add(CodeBuilder._QM_PDA_BO_Context_Import)
            Me._namespaces.Add(Me._currentValidationsNamespace)

            ' Actions namespace.
            Me._currentEventsNamespace = New CodeNamespace(String.Format("{0}.QM.Events.{1}", study.ShortName, questionnaireset.ShortName))
            Me._currentEventsNamespace.Imports.Add(CodeBuilder._QM_PDA_Import)
            Me._currentEventsNamespace.Imports.Add(CodeBuilder._QM_PDA_BO_Context_Import)
            Me._namespaces.Add(Me._currentEventsNamespace)


            For Each questionnaire As BO.Questionnaire In questionnaireset.Questionnaires

                ' Precondition and constructor.
                buildPrecondition(String.Format("{0}_{1}", questionnaireset.ShortName, questionnaire.ShortName), questionnaire.PreCondition)
                buildConstructor(String.Format("OnNewRecord_{0}_{1}", questionnaireset.ShortName, questionnaire.ShortName), questionnaire.OnNewRecord)

                ' Add variables.
                registerContainerVariables(questionnaire)

                For Each section As BO.Section In questionnaire.Sections

                    ' Precondition and constructor.
                    buildPrecondition(String.Format("{0}_{1}_{2}", questionnaireset.ShortName, questionnaire.ShortName, section.ShortName), section.PreCondition)
                    buildConstructor(String.Format("OnNewRecord_{0}_{1}_{2}", questionnaireset.ShortName, questionnaire.ShortName, section.ShortName), section.OnNewRecord)

                    ' Conditions class.
                    Me._currentConditionsClass = New CodeTypeDeclaration(String.Format("{0}{1}", questionnaire.ShortName, section.ShortName))
                    Me._currentConditionsNamespace.Types.Add(Me._currentConditionsClass)
                    registerContainerVariables(section)

                    ' Validations class.
                    Me._currentValidationsClass = New CodeTypeDeclaration(String.Format("{0}{1}", questionnaire.ShortName, section.ShortName))
                    Me._currentValidationsNamespace.Types.Add(Me._currentValidationsClass)

                    ' Actions class.
                    Me._currentEventsClass = New CodeTypeDeclaration(String.Format("{0}{1}", questionnaire.ShortName, section.ShortName))
                    Me._currentEventsNamespace.Types.Add(Me._currentEventsClass)

                    ' Build classes.
                    buildClass(Me._currentConditionsClass, Me._currentValidationsClass, section.SectionItems)

                Next

            Next

        Next

    End Sub

#End Region



#Region "Private Methods"

    Private Sub addImports(ByVal cNamespace As CodeNamespace)

        cNamespace.Imports.Add(CodeBuilder._QM_PDA_Import)
        cNamespace.Imports.Add(CodeBuilder._QM_PDA_BO_Context_Import)

        For Each ns As String In ImportList

            cNamespace.Imports.Add(New CodeNamespaceImport(ns))

        Next

    End Sub

    Private Sub buildPrecondition(ByVal methodName As String, ByVal statement As String)

        If Not String.IsNullOrEmpty(statement) Then

            Dim precondition As New CodeMemberMethod()
            precondition.Attributes = MemberAttributes.Static Or MemberAttributes.Public
            precondition.ReturnType = CodeBuilder._booleanCodeTypeReference
            precondition.Name = "Precondition_" & methodName
            precondition.Statements.Add(getReturnStatement(statement))

            Me._preconditionsClass.Members.Add(precondition)

        End If

    End Sub


    Private Sub buildConstructor(ByVal methodName As String, ByVal statement As String)

        If Not String.IsNullOrEmpty(statement) Then

            Dim method As New CodeMemberMethod
            method.Attributes = MemberAttributes.Static Or MemberAttributes.Public
            method.Name = methodName
            method.Statements.Add(New CodeSnippetStatement(resolveAbbreviations(statement)))
            Me._constructorsClass.Members.Add(method)

        End If

    End Sub


    Private Sub buildClass(ByRef conditions As CodeTypeDeclaration, ByRef validations As CodeTypeDeclaration, ByVal sectionitems As List(Of BO.SectionItem))

        For Each sectionitem As BO.SectionItem In sectionitems

            If sectionitem.GetType().Equals(GetType(BO.Question)) Then

                registerQuestionVariables(CType(sectionitem, BO.Question))
                buildValidationMethods(CType(sectionitem, BO.Question))

            ElseIf sectionitem.GetType().Equals(GetType(BO.CheckPoint)) Then

                buildConditionMethod(CType(sectionitem, BO.CheckPoint))
                buildClass(conditions, validations, CType(sectionitem, BO.CheckPoint).SectionItems)

            End If

            buildEventMethods(sectionitem)

        Next

    End Sub


    Private Sub buildEventMethods(ByVal item As BO.SectionItem)

        Dim OnLoad As String = Nothing
        Dim OnUnload As String = Nothing
        Dim OnChange As String = Nothing
        Dim method As CodeMemberMethod

        ' Extract the code snippet.
        If item.GetType().Equals(GetType(BO.Question)) Then

            OnLoad = CType(item, BO.Question).OnLoad
            OnUnload = CType(item, BO.Question).OnUnload
            OnChange = CType(item, BO.Question).OnChange

        ElseIf item.GetType().Equals(GetType(BO.Information)) Then

            OnLoad = CType(item, BO.Information).OnLoad
            OnUnload = CType(item, BO.Information).OnUnload

        End If

        ' If any code was found, create the method.
        If Not String.IsNullOrEmpty(OnLoad) Then

            method = New CodeMemberMethod()
            method.Attributes = MemberAttributes.Static Or MemberAttributes.Public
            method.Name = "OnLoad_" & item.Number.Replace(".", "_")
            method.Statements.Add(New CodeSnippetStatement(resolveAbbreviations(OnLoad)))
            Me._currentEventsClass.Members.Add(method)

        End If

        If Not String.IsNullOrEmpty(OnUnload) Then

            method = New CodeMemberMethod()
            method.Attributes = MemberAttributes.Static Or MemberAttributes.Public
            method.Name = "OnUnload_" & item.Number.Replace(".", "_")
            method.Statements.Add(New CodeSnippetStatement(resolveAbbreviations(OnUnload)))
            Me._currentEventsClass.Members.Add(method)

        End If

        If Not String.IsNullOrEmpty(OnChange) Then

            method = New CodeMemberMethod()
            method.Attributes = MemberAttributes.Static Or MemberAttributes.Public
            method.Name = "OnChange_" & item.Number.Replace(".", "_")
            method.Statements.Add(New CodeSnippetStatement(resolveAbbreviations(OnChange)))
            Me._currentEventsClass.Members.Add(method)

        End If
    End Sub


    Private Sub buildConditionMethod(ByVal checkpoint As BO.CheckPoint)

        Dim condition As New CodeMemberMethod()
        Dim statement As String
        condition.Attributes = MemberAttributes.Static Or MemberAttributes.Public
        condition.ReturnType = CodeBuilder._booleanCodeTypeReference
        condition.Name = "Condition_" & checkpoint.Number.Replace(".", "_")

        If checkpoint.BranchIf Then
            statement = checkpoint.Condition
        Else
            statement = String.Format("NOT ( {0} )", checkpoint.Condition)
        End If

        condition.Statements.Add(getReturnStatement(statement))
        Me._currentConditionsClass.Members.Add(condition)

    End Sub


    Private Sub buildValidationMethods(ByVal question As BO.Question)

        Dim method As CodeMemberMethod

        If Not String.IsNullOrEmpty(question.AbsoluteMaximum) Then

            method = New CodeMemberMethod()
            method.Attributes = MemberAttributes.Static Or MemberAttributes.Public
            method.ReturnType = CodeBuilder._objectCodeTypeReference
            method.Name = "AbsMax_" & question.Number.Replace("."c, "_"c)
            method.Statements.Add(getReturnStatement(question.AbsoluteMaximum))
            Me._currentValidationsClass.Members.Add(method)

        End If

        If Not String.IsNullOrEmpty(question.AbsoluteMinimum) Then

            method = New CodeMemberMethod()
            method.Attributes = MemberAttributes.Static Or MemberAttributes.Public
            method.ReturnType = CodeBuilder._objectCodeTypeReference
            method.Name = "AbsMin_" & question.Number.Replace("."c, "_"c)
            method.Statements.Add(getReturnStatement(question.AbsoluteMinimum))
            Me._currentValidationsClass.Members.Add(method)

        End If

        If Not String.IsNullOrEmpty(question.PromptUnder) Then

            method = New CodeMemberMethod()
            method.Attributes = MemberAttributes.Static Or MemberAttributes.Public
            method.ReturnType = CodeBuilder._objectCodeTypeReference
            method.Name = "PromptUnder_" & question.Number.Replace("."c, "_"c)
            method.Statements.Add(getReturnStatement(question.PromptUnder))
            Me._currentValidationsClass.Members.Add(method)

        End If

        If Not String.IsNullOrEmpty(question.PromptOver) Then

            method = New CodeMemberMethod()
            method.Attributes = MemberAttributes.Static Or MemberAttributes.Public
            method.ReturnType = CodeBuilder._objectCodeTypeReference
            method.Name = "PromptOver_" & question.Number.Replace("."c, "_"c)
            method.Statements.Add(getReturnStatement(question.PromptOver))
            Me._currentValidationsClass.Members.Add(method)

        End If

        If Not String.IsNullOrEmpty(question.CustomValidation) Then

            method = New CodeMemberMethod()
            method.Attributes = MemberAttributes.Static Or MemberAttributes.Public
            method.ReturnType = CodeBuilder._booleanCodeTypeReference
            method.Name = "CustomValidation_" & question.Number.Replace("."c, "_"c)
            method.Parameters.Add(New CodeParameterDeclarationExpression(CodeBuilder._objectCodeTypeReference, "value"))
            method.Statements.Add(getReturnStatement(question.CustomValidation))
            Me._currentValidationsClass.Members.Add(method)

        End If

    End Sub


    Private Function getReturnStatement(ByVal expresion As String) As CodeStatement

        expresion = resolveAbbreviations(expresion)
        Dim statement As New CodeMethodReturnStatement()
        statement.Expression = New CodeSnippetExpression(expresion)

        Return statement

    End Function


    Private Function resolveAbbreviations(ByVal statement As String) As String

        If statement.EndsWith("@") Then Throw New Exception("Ilegal use of @ in condition.")

        Dim startIndex As Integer
        Dim index As Integer
        Dim token As String
        Dim lowerToken As String

        ' Solve the variable names.
        While statement.Contains("@")

            startIndex = statement.IndexOf("@")
            index = startIndex + 1
            token = ""

            While index < statement.Length AndAlso (Char.IsLetterOrDigit(statement(index)) OrElse "_-".Contains(statement(index)))
                token &= statement(index)
                index += 1
            End While

            lowerToken = token.ToLower()
            statement = statement.Remove(startIndex, index - startIndex)

            If Me._sectionVariables.Contains(lowerToken) Then

                statement = statement.Insert(startIndex, String.Format("CurrentSection(""{0}"")", token))

            ElseIf Me._questionnaireVariables.Contains(lowerToken) Then

                statement = statement.Insert(startIndex, String.Format("CurrentQuestionnaire(""{0}"")", token))

            ElseIf Me._questionnairesetVariables.Contains(lowerToken) Then

                statement = statement.Insert(startIndex, String.Format("CurrentSubject(""{0}"")", token))

            Else

                Throw New Exception(String.Format("The variable '{0}' wasn't declared before use in [{1}].", token, Me._currentConditionsClass.Name))

            End If

        End While

        ' Solve the method names.
        While statement.Contains("$")

            startIndex = statement.IndexOf("$")
            index = startIndex + 1
            token = ""

            While index < statement.Length AndAlso (Char.IsLetterOrDigit(statement(index)) OrElse "_-".Contains(statement(index)))
                token &= statement(index)
                index += 1
            End While

            lowerToken = token.ToLower()
            statement = statement.Remove(startIndex, index - startIndex)

            If Me._methodNames.Contains(lowerToken) Then

                statement = statement.Insert(startIndex, String.Format("Global.{0}.Common.{1}", Me._commonNamespace.Name, token))

            Else

                Throw New Exception(String.Format("The method '{0}' wasn't declared before use in [{1}].", token, Me._currentConditionsClass.Name))

            End If

        End While

        Return statement

    End Function


    Private Sub registerContainerVariables(ByVal obj As BO.GenericObject)

        Dim variableList As List(Of String)
        Dim variableName As String

        If obj.GetType.Equals(GetType(BO.QuestionnaireSet)) Then : variableList = Me._questionnairesetVariables
        ElseIf obj.GetType.Equals(GetType(BO.Questionnaire)) Then : variableList = Me._questionnaireVariables
        ElseIf obj.GetType.Equals(GetType(BO.Section)) Then : variableList = Me._sectionVariables
        Else : Exit Sub : End If

        For Each variable As BO.Variable In obj.Variables
            variableName = variable.VariableName.ToLower()
            If Not variableList.Contains(variableName) Then variableList.Add(variableName.ToLower())
        Next

    End Sub


    Private Sub registerQuestionVariables(ByVal question As BO.Question)

        Dim variableList As List(Of String)
        Dim variableName As String = question.VariableName.ToLower()
        Dim cbVariableName As String

        Select Case question.VariableScope

            Case BO.VariableScopes.QuestionnaireSet
                variableList = Me._questionnairesetVariables

            Case BO.VariableScopes.Questionnaire
                variableList = Me._questionnaireVariables

            Case BO.VariableScopes.Section
                variableList = Me._sectionVariables

            Case Else : Exit Sub

        End Select

        Select Case question.ScreenTemplate.ToLower()

            Case "gpsreading"
                If Not variableList.Contains(variableName & "declat") Then variableList.Add(variableName & "declat")
                If Not variableList.Contains(variableName & "declon") Then variableList.Add(variableName & "declon")
                If Not variableList.Contains(variableName & "lat") Then variableList.Add(variableName & "lat")
                If Not variableList.Contains(variableName & "lon") Then variableList.Add(variableName & "lon")
                If Not variableList.Contains(variableName & "pdop") Then variableList.Add(variableName & "pdop")
                If Not variableList.Contains(variableName & "hdop") Then variableList.Add(variableName & "hdop")
                If Not variableList.Contains(variableName & "sat") Then variableList.Add(variableName & "sat")

            Case "checkbox"
                For Each legalvalue As BO.LegalValueItem In BO.Study.GetLegalValuesByName(question.LegalValueTable).LegalValues
                    cbVariableName = variableName & legalvalue.ShortName.ToLower()
                    If Not variableList.Contains(cbVariableName) Then variableList.Add(cbVariableName)
                Next

            Case Else
                If Not variableList.Contains(variableName) Then variableList.Add(variableName)

        End Select

    End Sub

#End Region


End Class

Public Class ConditionForm


    ' Crear la instancia y devolver la expresion.
    Public Shared Function GetCondition(ByVal condition As String, ByVal context As Object, ByVal expresionType As String) As String
        Dim instance As New ConditionForm(condition, context)
        If instance.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Try
                instance.Parse(instance.TextBox1.Text)
            Catch e As Exception
                Select Case MessageBox.Show(e.Message & Environment.NewLine & " Are you sure you want to keep changes?", "Parse error", MessageBoxButtons.YesNo)
                    Case Windows.Forms.DialogResult.Yes
                        Return instance.TextBox1.Text
                    Case Windows.Forms.DialogResult.No
                        Return condition
                End Select
            End Try
        Else
            Return condition
        End If

        Return Nothing
    End Function

#Region "Variables"

    Private currentObject As Object = Nothing

#End Region

#Region "Character Classes"

    Private Const Letters As String = "abcdefghijklmnopqrstuvwxyz"
    Private Const Numbers As String = "0123456789"

    Private Const startOfIdentifier As String = Letters & "_@"
    Private Const middleOfIdentifier As String = Letters & "_" & Numbers
    Private Const numbersAndPoint As String = Numbers & "."

#End Region

#Region "Parser methods"

    ' Stacks.
    Private signStack As New Stack(Of String)
    Private typeStack As New Stack(Of String)

    ' Calculates the resedence of the operators.
    Private Function OperatorPresedence(ByVal sign As String) As Integer
        Return "(end|not|and|or|<|>|=|<=|>=|<>|+|-|*|/|~".IndexOf(sign.ToLower)
    End Function

    ' Transforms the infix expersion into postfix.
    Private Function Parse(ByVal infix As String) As Boolean

        signStack.Clear()
        signStack.Push("|")

        Dim postfix As String = ""
        Dim sign As Boolean = False
        Dim i As Integer = 0

        infix = infix.ToLower & "~"

        While infix(i) <> "~"

            If infix(i) = " " Then
                i += 1

            ElseIf sign Then
                If infix(i) = ")" Then
                    ' If is a ).
                    postfix &= PushSign("(")
                    signStack.Pop()
                    i += 1

                ElseIf "or|<=|>=|<>".Contains(infix.Substring(i, 2)) Then
                    ' If is a two characters sign.
                    PushSign(infix.Substring(i, 2))
                    i += 2
                    sign = False

                ElseIf "<|>|=|+|-|*|/".Contains(infix(i)) Then
                    ' If is a one character sign.
                    PushSign(infix(i))
                    i += 1
                    sign = False

                ElseIf infix.Substring(i, 3) = "and" Then
                    ' If is an 'and'.
                    PushSign("and")
                    i += 3
                    sign = False

                Else
                    Throw New Exception(String.Format("Invalid use of '{0}' in the condition.", infix(i)))

                End If

            Else
                If startOfIdentifier.Contains(infix(i)) Then
                    ' If is an identifier.
                    Dim id As String = NextID(infix, i).Remove(0, 1)
                    Dim type As String = getVarType(id).Split("(")(0)
                    typeStack.Push(type)
                    sign = True

                ElseIf infix(i) = """" Then
                    ' If is a string.
                    NextString(infix, i)
                    typeStack.Push("nvarchar")
                    sign = True

                ElseIf Numbers.Contains(infix(i)) Then
                    ' If is a number.
                    typeStack.Push(NextNumberType(infix, i))
                    sign = True

                ElseIf infix(i) = "-" Then
                    ' If is a negative.
                    PushSign("~")
                    i += 1

                ElseIf infix(i) = "(" Then
                    ' If is a (.
                    signStack.Push("(")
                    i += 1

                Else
                    ' Invalid sign.
                    Throw New Exception(String.Format("Invalid use of '{0}', value or variable espected.", infix(i)))

                End If
            End If
        End While

        PushSign("end")

        Return True
    End Function

    ' Pops and pushes into the stack of signs.
    Private Function PushSign(ByVal sign As String)

        Dim operators As String = ""
        While signStack.Peek <> "|" And OperatorPresedence(signStack.Peek) >= OperatorPresedence(sign)
            Dim currentSign As String = signStack.Pop
            If "+|-|*|/".Contains(currentSign) Then
                ' Arithmetical operators.
                Dim t1 As String = typeStack.Pop()
                Dim t2 As String = typeStack.Pop()
                Dim t12 As String = t1 & t2

                If t1 = t2 Then
                    typeStack.Push(t1)
                ElseIf t12.Contains("integer") And t12.Contains("numeric") Then
                    typeStack.Push("numeric")
                Else
                    Throw New Exception(String.Format("Can't use the operator '{0}' with {1} and {2}.", currentSign, t1, t2))
                End If

            ElseIf "<>|<=|>=|<|>|=".Contains(currentSign) Then
                ' Relational operators.
                Dim t1 As String = typeStack.Pop()
                Dim t2 As String = typeStack.Pop()
                Dim t12 As String = t1 & t2

                If t1 = t2 Or t12.Contains("integer") Or t12.Contains("numeric") Then
                    typeStack.Push("bit")
                Else
                    Throw New Exception(String.Format("Can't use the operator '{0}' with {1} and {2}.", currentSign, t1, t2))
                End If

            ElseIf "and|or".Contains(currentSign) Then
                ' Logical operators.
                Dim t1 As String = typeStack.Pop()
                Dim t2 As String = typeStack.Pop()

                If t1 = t2 And t1 = "bit" Then
                    typeStack.Push("bit")
                Else
                    Throw New Exception(String.Format("Can't use the operator '{0}' with {1} and {2}.", currentSign, t1, t2))
                End If
            End If

        End While

        signStack.Push(sign)

        Return operators.Replace("|(", "")

    End Function

    ' Returns the next id in the string.
    Private Function NextID(ByVal expresion As String, ByRef i As Integer) As String

        Dim token As String = expresion(i)
        i += 1
        While middleOfIdentifier.Contains(expresion(i)) And i < expresion.Length
            token &= expresion(i)
            i += 1
        End While

        If token = "@" Then Throw New Exception("Invalid use of '@'.")

        Return token
    End Function

    ' Returns the next number in the string.
    Private Function NextNumberType(ByVal expresion As String, ByRef i As Integer)

        Dim tmp As Decimal
        Dim length As Integer = 1
        Dim token As String = expresion(i)

        While Decimal.TryParse(token, tmp) And i + length < expresion.Length
            token &= expresion(i + length)
            length += 1
        End While

        i = i + length - 1
        If token.Contains(".") Then
            Return "numeric"
        Else
            Return "integer"
        End If
    End Function

    ' Returns the next string in the string.
    Private Function NextString(ByVal expresion As String, ByRef i As Integer)

        Dim token As String = """"
        i += 1

        While expresion(i) <> """" And i < expresion.Length
            token &= expresion(i)
            i += 1
        End While

        If expresion(i) <> """"c Then
            Throw New Exception("No end of string found.")
        Else
            token &= """"
            i += 1
        End If

        Return token
    End Function

    ' Returns the next date.
    Private Sub NextDate(ByVal expresion As String, ByRef i As Integer)

        Dim token As String = "#"
        i += 1

        While expresion(i) <> "#" And i < expresion.Length
            token &= expresion(i)
            i += 1
        End While

        If expresion(i) <> "#" Then
            Throw New Exception("No end of date found.")
        Else
            token &= "#"
            i += 1
            Dim dateRegex As New System.Text.RegularExpressions.Regex("[0-9]{4}/[0-9][0-9]/[0-9][0-9]")
            Dim dateTimeRegex As New System.Text.RegularExpressions.Regex("[0-9]{4}/[0-9][0-9]/[0-9][0-9] [0-9][0-9]:[0-9][0-9]:[0-9][0-9] ((am)/(pm))")


        End If

    End Sub

#End Region

#Region "Type Evaluation"

    ' Searches for the variable name, rises warnings or errors.
    Private Function getVarType(ByRef variableName As String) As String

        ' Search in the subject scope.
        'For Each variable As BO.Variable In BO.ContextClass.CurrentQuestionnaireSet.Subject.Variables
        '    If variable.VariableName.ToLower = variableName Then Return variable.DataType
        'Next

        ' Search in the section scope.
        Dim actual As Object = currentObject
        Dim parent As Object = CType(currentObject, BO.CheckPoint).Parent
        Dim nextParent As Object = Nothing

        While parent IsNot Nothing
            ' Get the section item list.
            Dim sectionItems As List(Of BO.SectionItem) = Nothing
            If parent.GetType().Equals(GetType(BO.CheckPoint)) Then
                sectionItems = CType(parent, BO.CheckPoint).SectionItems
                nextParent = CType(parent, BO.CheckPoint).Parent
            Else
                sectionItems = CType(parent, BO.Section).SectionItems
                nextParent = Nothing
            End If

            ' Check in the list.
            Dim count As Integer = 0
            Dim sectionItem As BO.SectionItem = sectionItems(count)

            ' Stop until find the object where we come from.
            While Not sectionItem.Equals(actual)

                If sectionItem.GetType.Equals(GetType(BO.Question)) Then
                    'Compares if the variable name is the same.
                    Dim question As BO.Question = sectionItem
                    If question.VariableName.ToLower = variableName Then Return question.DataType

                Else
                    ' Checks the branch for the variable.
                    Dim result As String = getVarTypeR(sectionItem, variableName)
                    If result IsNot Nothing Then Return result
                End If

                ' Step.
                count += 1
                sectionItem = sectionItems(count)
            End While

            ' Check the parent.
            actual = parent
            parent = nextParent
        End While

        Throw New Exception("The variable name '" & variableName & "' is not avialible  in this scope.")

    End Function

    ' Searches fot the variable name in the branch.
    Private Function getVarTypeR(ByVal checkpoint As BO.CheckPoint, ByVal variableName As String) As String
        For Each sectionItem As BO.SectionItem In checkpoint.SectionItems
            If sectionItem.GetType.Equals(GetType(BO.Question)) Then
                Dim question As BO.Question = sectionItem
                If question.VariableName.ToLower = variableName Then
                    MessageBox.Show("Is posible that te variable '" & variableName & "' has no value in this point.")
                    Return question.DataType
                End If
            Else
                Dim result As String = getVarTypeR(sectionItem, variableName)
                If result IsNot Nothing Then Return result
            End If
        Next
        Return Nothing
    End Function

#End Region

#Region "Variable names on screen."

    Private Sub refreshVariableTreeNode(ByVal pattern As String)

        VariablesTreeView.Nodes.Clear()
        VariablesTreeView.Nodes.Add(SubjectVariablesNode(pattern))
        VariablesTreeView.Nodes.Add(SectionVariablesNode(pattern))
        VariablesTreeView.Nodes.Add(QuestionnaireVariablesNode(pattern))
        VariablesTreeView.ExpandAll()

    End Sub

    Private Sub AddNodeInOrder(ByRef list As TreeNodeCollection, ByVal value As String, ByVal color As Color)

        Dim node As New TreeNode(value)
        node.ForeColor = color
        For i As Integer = 0 To list.Count - 1
            If list(i).Text > value Then
                list.Insert(i, node)
                Return
            End If
        Next

        list.Add(node)
    End Sub

    Private Function SubjectVariablesNode(ByVal pattern As String) As TreeNode
        ' Creates the parent node.
        Dim node As New TreeNode("Subject Variables")

        ' Fill the child list.
        'For Each var As Variable In ContextClass.CurrentQuestionnaireSet.Subject.Variables
        '    If var.VariableName.ToLower.Contains(pattern) Then
        '        node.Nodes.Add(var.VariableName & " (" & var.DataType & ")")
        '    End If
        'Next

        Return node
    End Function

    Private Function SectionVariablesNode(ByVal pattern As String) As TreeNode
        ' Creates the parent node.
        Dim node As New TreeNode("Section Variables")

        ' Search in the section scope.
        Dim actual As Object = currentObject
        Dim parent As Object = CType(currentObject, BO.CheckPoint).Parent
        Dim nextParent As Object = Nothing

        While parent IsNot Nothing
            ' Get the phase list.
            Dim phases As List(Of BO.SectionItem) = Nothing
            If parent.GetType().Equals(GetType(BO.CheckPoint)) Then
                phases = CType(parent, BO.CheckPoint).SectionItems
                nextParent = CType(parent, BO.CheckPoint).Parent
            Else
                phases = CType(parent, BO.Section).SectionItems
                nextParent = Nothing
            End If

            ' Check the list.
            Dim count As Integer = 0
            Dim phase As BO.SectionItem = phases(count)

            ' Stop until find the object where we come from.
            While Not phase.Equals(actual)

                If phase.GetType.Equals(GetType(BO.Question)) Then
                    'Adds the variable if belongs to a section.
                    Dim question As BO.Question = phase
                    If question.VariableScope = VariableScopes.Section And question.VariableName.ToLower.Contains(pattern) Then
                        AddNodeInOrder(node.Nodes, question.VariableName, Color.Black)
                    End If

                ElseIf phase.GetType.Equals(GetType(BO.CheckPoint)) Then

                    ' Checks the branch for the variable.
                    VariableNodes(node.Nodes, phase, pattern, VariableScopes.Section)
                End If

                ' Step.
                count += 1
                phase = phases(count)
            End While

            ' Check the parent.
            actual = parent
            parent = nextParent
        End While

        Return node

    End Function

    Private Function QuestionnaireVariablesNode(ByVal pattern As String) As TreeNode
        ' Creates the parent node.
        Dim node As New TreeNode("Questionnaire Variables")

        ' Search in the section scope.
        Dim actual As Object = currentObject
        Dim parent As Object = CType(currentObject, BO.CheckPoint).Parent
        Dim nextParent As Object = Nothing

        While parent IsNot Nothing
            ' Get the phase list.
            Dim phases As List(Of BO.SectionItem) = Nothing
            If parent.GetType().Equals(GetType(BO.CheckPoint)) Then
                phases = CType(parent, BO.CheckPoint).SectionItems
                nextParent = CType(parent, BO.CheckPoint).Parent
            Else
                phases = CType(parent, BO.Section).SectionItems
                nextParent = Nothing
            End If

            ' Check the list.
            Dim count As Integer = 0
            Dim phase As BO.SectionItem = phases(count)

            ' Stop until find the object where we come from.
            While Not phase.Equals(actual)

                If phase.GetType.Equals(GetType(BO.Question)) Then
                    'Adds the variable if belongs to a section.
                    Dim question As BO.Question = phase
                    If question.VariableScope = VariableScopes.Questionnaire And question.VariableName.ToLower.Contains(pattern) Then
                        AddNodeInOrder(node.Nodes, question.VariableName, Color.Black)
                    End If

                ElseIf phase.GetType.Equals(GetType(BO.CheckPoint)) Then

                    ' Checks the branch for the variable.
                    VariableNodes(node.Nodes, phase, pattern, VariableScopes.Questionnaire)
                End If

                ' Step.
                count += 1
                phase = phases(count)
            End While

            ' Check the parent.
            actual = parent
            parent = nextParent
        End While

        Return node

    End Function

    Private Sub VariableNodes(ByRef nodeCollection As TreeNodeCollection, ByVal checkpoint As CheckPoint, ByVal pattern As String, ByVal variableScope As VariableScopes)

        For Each phase As SectionItem In checkpoint.SectionItems
            If phase.GetType.Equals(GetType(Question)) Then
                ' If a question found.
                Dim question As Question = phase
                If question.VariableScope = variableScope And question.VariableName.ToLower.Contains(pattern) Then
                    AddNodeInOrder(nodeCollection, question.VariableName, Color.Red)
                End If
            Else
                ' If a checkpoint found.
                VariableNodes(nodeCollection, phase, pattern, variableScope)
            End If
        Next
    End Sub

#End Region

    ' Constructor.
    Public Sub New(ByVal condition As String, ByVal parent As Object)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        TextBox1.Text = condition
        currentObject = parent
        refreshVariableTreeNode("")

    End Sub

    ' Searches for the variables containing the string.
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        refreshVariableTreeNode(SearchTextBox.Text.ToLower)

    End Sub

    ' Inserts the double clicked variable into the textbox.
    Private Sub VariablesTreeView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VariablesTreeView.DoubleClick

        ' Get selected node.
        Dim selected As TreeNode = VariablesTreeView.SelectedNode
        If selected Is Nothing Then Return

        If selected.Level > 0 Then

            ' Set the index for the insertion and variablename.
            Dim index As Integer = TextBox1.SelectionStart
            Dim parts As String() = selected.Text.Split(" (")
            Dim variableName As String = "@" & parts(0)

            ' If text is selected, delete it.
            If TextBox1.SelectionLength > 0 Then
                With TextBox1
                    .Text = .Text.Remove(.SelectionStart, .SelectionLength)
                End With
            End If

            ' Insert the variable name and select the inserted text.
            TextBox1.Text = TextBox1.Text.Insert(index, variableName)
            TextBox1.Focus()
            TextBox1.SelectionStart = index
            TextBox1.SelectionLength = variableName.Length
        End If
    End Sub

End Class
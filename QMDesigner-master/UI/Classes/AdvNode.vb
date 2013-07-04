Imports System.Runtime.Serialization

<Serializable()> _
Public Class AdvNode
    Inherits DevComponents.AdvTree.Node
    Implements ISerializable

#Region "Properties"

    Friend number As String
    Public Shared ADVTree As DevComponents.AdvTree.AdvTree
    Public Shared refreshTree As Boolean = True

    ''' <summary>
    ''' Tag as generic object.
    ''' </summary>
    ''' <value></value>
    ''' <returns>Generic object.</returns>
    ''' <remarks></remarks>

    Public Overloads Property Tag() As BO.GenericObject
        Get
            Return CType(MyBase.Tag, BO.GenericObject)
        End Get
        Set(ByVal value As BO.GenericObject)
            MyBase.Tag = value
        End Set
    End Property


    ''' <summary>
    ''' Get the data type of the tagged object.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public ReadOnly Property TagType() As Type
        Get
            Return MyBase.Tag.GetType()
        End Get
    End Property


    ''' <summary>
    ''' Get the parent as an AdvNode.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public ReadOnly Property AdvNodeParent() As AdvNode
        Get
            Return CType(Me.Parent, AdvNode)
        End Get
    End Property


    ''' <summary>
    ''' Get the previous node as an AdvNode.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public ReadOnly Property AdvNodePrevNode() As AdvNode
        Get
            Return CType(Me.PrevNode, AdvNode)
        End Get
    End Property


    ''' <summary>
    ''' Get the next node as an AdvNode.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public ReadOnly Property AdvNodeNextNode() As AdvNode
        Get
            Return CType(Me.NextNode, AdvNode)
        End Get
    End Property


    ''' <summary>
    ''' Returns a list of numbers with all the indexes of the ansestors.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public ReadOnly Property IndexPath() As List(Of Integer)
        Get

            Dim list As New List(Of Integer)
            Dim n As AdvNode = Me
            While n.Parent IsNot Nothing

                list.Insert(0, n.Index)
                n = n.Parent

            End While
            Return list

        End Get
    End Property

#End Region


#Region "Methods"

    ''' <summary>
    ''' Assigns the tag value.
    ''' </summary>
    ''' <param name="tag"></param>
    ''' <remarks></remarks>

    Public Sub New(ByVal tag As BO.GenericObject)

        MyBase.Tag = tag
        Me.number = Nothing

    End Sub


    ''' <summary>
    ''' Checks if the current node can be dropped over the parameter node.
    ''' </summary>
    ''' <param name="node">Target Node.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Function CanDropOver(ByVal node As AdvNode) As Boolean


        If node Is Nothing Then
            Debug.Print("Node is nothing!")
        ElseIf node.Tag Is Nothing Then
            Debug.Print("Node.tag = nothing")
        Else
            Debug.Print("Node.tag =" & node.Tag.ToString)
        End If


        If Me.TagType.Equals(GetType(BO.Question)) OrElse Me.TagType.Equals(GetType(BO.Variable)) Then

            Return node.Tag Is Nothing OrElse node.Tag.HasSectionItems

        ElseIf Me.TagType.Equals(GetType(BO.CheckPoint)) Then

            Return node.Tag.HasSectionItems

        ElseIf Me.TagType.Equals(GetType(BO.Information)) Then

            Return node.Tag.HasSectionItems

        ElseIf Me.TagType.Equals(GetType(BO.Section)) Then

            Return node.TagType.Equals(GetType(BO.Questionnaire))

        ElseIf Me.TagType.Equals(GetType(BO.Questionnaire)) Then

            Return node.TagType.Equals(GetType(BO.QuestionnaireSet))

        ElseIf Me.TagType.Equals(GetType(BO.QuestionnaireSet)) Then

            Return node.TagType.Equals(GetType(BO.Study))

        Else

            Return False

        End If

    End Function


    ''' <summary>
    ''' Checks if the node is in a branch of the parent node.
    ''' </summary>
    ''' <param name="parent"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Function IsDescendantOf(ByVal parent As AdvNode) As Boolean

        While parent IsNot Nothing And Not Me.Equals(parent) And parent.Level >= Me.Level
            parent = parent.AdvNodeParent
        End While

        Return Me.Equals(parent)
    End Function


    ''' <summary>
    ''' Builds the descendant nodes of the tree.
    ''' </summary>
    ''' <remarks></remarks>

    Public Sub BuildTree()

        Me.Nodes.Clear()
        If Me.TagType.BaseType.Equals(GetType(BO.SectionItem)) Then CType(Me.Tag, BO.SectionItem).Number = Me.number
        Me.Text = Me.Tag.ToString()
        Dim node As AdvNode
        Dim count As Integer = 0
        If Me.Tag.HasVariables Then

            Dim node2 As AdvNode
            node = New AdvNode(Nothing)
            node.Text = "Variables"
            node.Style = ADVTree.Styles("Variables")
            node.ImageKey = "Variables"
            For Each variable As BO.Variable In Me.Tag.Variables

                node2 = New AdvNode(variable)
                node2.Text = variable.ToString()
                node2.Style = ADVTree.Styles("DefaultStyle")
                node2.ImageKey = "Variable"
                node.Nodes.Add(node2)

            Next
            node.Nodes.Sort()
            Me.Nodes.Add(node)

        End If
        If Me.TagType.Equals(GetType(BO.Study)) Then

            Me.ImageKey = "Study"
            For Each qs As BO.QuestionnaireSet In CType(Me.Tag, BO.Study).QuestionnarieSets

                node = New AdvNode(qs)
                node.BuildTree()
                Me.Nodes.Add(node)
                node.Tag.SetParent(Me.Tag)

            Next

        ElseIf Me.TagType.Equals(GetType(BO.QuestionnaireSet)) Then

            Me.ImageKey = "QuestionnaireSet"
            For Each q As BO.Questionnaire In CType(Me.Tag, BO.QuestionnaireSet).Questionnaires

                node = New AdvNode(q)
                node.BuildTree()
                Me.Nodes.Add(node)
                node.Tag.SetParent(Me.Tag)

            Next

        ElseIf Me.TagType.Equals(GetType(BO.Questionnaire)) Then

            If CType(Me.Tag, BO.Questionnaire).MultipleInstances Then
                Me.ImageKey = "QuestionnaireLoop"
            Else
                Me.ImageKey = "Questionnaire"
            End If
            For Each s As BO.Section In CType(Me.Tag, BO.Questionnaire).Sections

                node = New AdvNode(s)
                node.BuildTree()
                Me.Nodes.Add(node)
                node.Tag.SetParent(Me.Tag)

            Next

        ElseIf Me.TagType.Equals(GetType(BO.Section)) Then

            Me.ImageKey = "Section"
            For Each p As BO.SectionItem In CType(Me.Tag, BO.Section).SectionItems

                count += 1
                node = New AdvNode(p)
                node.number = count.ToString()
                node.BuildTree()
                Me.Nodes.Add(node)
                node.Tag.SetParent(Me.Tag)

            Next

        ElseIf Me.TagType.Equals(GetType(BO.CheckPoint)) Then

            Me.ImageKey = "Checkpoint"
            For Each p As BO.SectionItem In CType(Me.Tag, BO.CheckPoint).SectionItems

                count += 1
                node = New AdvNode(p)
                node.number = String.Format("{0}.{1}", Me.number, count)
                node.BuildTree()
                Me.Nodes.Add(node)

            Next

        ElseIf Me.TagType.Equals(GetType(BO.Question)) Then

            Me.ImageKey = "Question"
            If CType(Me.Tag, BO.Question).Required Then Me.Style = ADVTree.Styles("Required")

        ElseIf Me.TagType.Equals(GetType(BO.Information)) Then

            Me.ImageKey = "Information"

        End If

    End Sub


    ''' <summary>
    ''' Builds the descendant nodes of the tree without variables until section level.
    ''' </summary>
    ''' <remarks></remarks>

    Public Sub BuildContainersTree()

        Me.Nodes.Clear()
        If Me.TagType.BaseType.Equals(GetType(BO.SectionItem)) Then Exit Sub
        Me.Text = Me.Tag.ToString()
        Dim node As AdvNode
        If Me.TagType.Equals(GetType(BO.Study)) Then

            Me.ImageKey = "Study"
            For Each qs As BO.QuestionnaireSet In CType(Me.Tag, BO.Study).QuestionnarieSets

                node = New AdvNode(qs)
                node.BuildContainersTree()
                Me.Nodes.Add(node)
                node.Tag.SetParent(Me.Tag)

            Next

        ElseIf Me.TagType.Equals(GetType(BO.QuestionnaireSet)) Then

            Me.ImageKey = "QuestionnaireSet"
            For Each q As BO.Questionnaire In CType(Me.Tag, BO.QuestionnaireSet).Questionnaires

                node = New AdvNode(q)
                node.BuildContainersTree()
                Me.Nodes.Add(node)
                node.Tag.SetParent(Me.Tag)

            Next

        ElseIf Me.TagType.Equals(GetType(BO.Questionnaire)) Then

            If CType(Me.Tag, BO.Questionnaire).MultipleInstances Then
                Me.ImageKey = "QuestionnaireLoop"
            Else
                Me.ImageKey = "Questionnaire"
            End If
            For Each s As BO.Section In CType(Me.Tag, BO.Questionnaire).Sections

                node = New AdvNode(s)
                node.BuildContainersTree()
                Me.Nodes.Add(node)
                node.Tag.SetParent(Me.Tag)

            Next

        ElseIf Me.TagType.Equals(GetType(BO.Section)) Then

            Me.ImageKey = "Section"
            
        End If

    End Sub


    ''' <summary>
    ''' Builds the childs collection from the current child nodes.
    ''' </summary>
    ''' <remarks></remarks>

    Public Sub BuildBOFromTree()

        If Me.Tag Is Nothing Then

            Me.AdvNodeParent.BuildBOFromTree()
            Exit Sub

        ElseIf Me.Nodes.Count = 0 Then
            Me.RefreshUI()
            If Me.Tag.HasSectionItems Then Me.Tag.SectionItems.Clear()
            Exit Sub

        End If

        If Me.Tag.HasVariables Then

            Me.Tag.Variables.Clear()
            Me.Nodes(0).Nodes.Sort()
            For Each node As AdvNode In Me.Nodes(0).Nodes

                If node.TagType.Equals(GetType(BO.Variable)) Then

                    Me.Tag.Variables.Add(CType(node.Tag, BO.Variable))

                ElseIf node.TagType.Equals(GetType(BO.Question)) Then

                    ' Convert question into variable.
                    node.Tag = New BO.Variable(node.Tag)
                    node.RefreshUI()
                    CType(node.Tag, BO.Variable).SetVariableScope(Me.TagType)
                    Me.Tag.Variables.Add(CType(node.Tag, BO.Variable))

                End If
                node.Tag.SetParent(Me.Tag)

            Next

        End If

        If Me.Tag.HasSectionItems Then

            Me.Tag.SectionItems.Clear()
            For i As Integer = CInt(IIf(Me.Tag.HasVariables, 1, 0)) To Me.Nodes.Count - 1

                If Me.Nodes(i).Tag.GetType.BaseType.Equals(GetType(BO.SectionItem)) Then

                    Me.Tag.SectionItems.Add(CType(Me.Nodes(i).Tag, BO.SectionItem))
                    CType(Me.Nodes(i).Tag, BO.SectionItem).SetParent(Me.Tag)

                ElseIf Me.Nodes(i).Tag.GetType.Equals(GetType(BO.Variable)) Then

                    Me.Tag.SectionItems.Add(CType(Me.Nodes(i).Tag, BO.Variable).ToQuestion)
                    CType(Me.Nodes(i).Tag, BO.Variable).SetParent(Me.Tag)

                End If


            Next

        ElseIf Me.TagType.Equals(GetType(BO.Questionnaire)) Then

            CType(Me.Tag, BO.Questionnaire).Sections.Clear()
            For i As Integer = 1 To Me.Nodes.Count - 1

                CType(Me.Tag, BO.Questionnaire).Sections.Add(CType(Me.Nodes(i).Tag, BO.Section))
                CType(Me.Nodes(i).Tag, BO.Section).SetParent(Me.Tag)

            Next

        ElseIf Me.TagType.Equals(GetType(BO.QuestionnaireSet)) Then

            CType(Me.Tag, BO.QuestionnaireSet).Questionnaires.Clear()
            For i As Integer = 1 To Me.Nodes.Count - 1

                CType(Me.Tag, BO.QuestionnaireSet).Questionnaires.Add(CType(Me.Nodes(i).Tag, BO.Questionnaire))
                CType(Me.Nodes(i).Tag, BO.Questionnaire).SetParent(Me.Tag)

            Next

        ElseIf Me.TagType.Equals(GetType(BO.Study)) Then

            CType(Me.Tag, BO.Study).QuestionnarieSets.Clear()
            For i As Integer = 0 To Me.Nodes.Count - 1

                CType(Me.Tag, BO.Study).QuestionnarieSets.Add(CType(Me.Nodes(i).Tag, BO.QuestionnaireSet))
                CType(Me.Nodes(i).Tag, BO.QuestionnaireSet).SetParent(Me.Tag)

            Next

        End If

        If AdvNode.refreshTree Then

            Me.RefreshUIRecursive()

        End If

    End Sub


    ''' <summary>
    ''' Refreshes icon, text, style and color of the current node.
    ''' </summary>
    ''' <remarks></remarks>

    Public Sub RefreshUI()

        If Me.Tag Is Nothing Then

            Me.Text = "Variables"
            Me.ImageKey = "Variables"
            Exit Sub

        ElseIf Me.TagType.BaseType.Equals(GetType(BO.SectionItem)) Then

            If Me.AdvNodeParent.TagType.BaseType.Equals(GetType(BO.SectionItem)) Then
                Me.number = Me.AdvNodeParent.number & "." & (Me.Index + 1).ToString()
            Else
                Me.number = Me.Index.ToString()
            End If

            CType(Me.Tag, BO.SectionItem).Number = Me.number
            Me.Text = Me.Tag.ToString()

        Else

            Me.Text = Me.Tag.ToString()

        End If

        Me.Style = ADVTree.Styles("DefaultStyle")

        If Me.TagType.Equals(GetType(BO.Study)) Then

            Me.ImageKey = "Study"

        ElseIf Me.TagType.Equals(GetType(BO.QuestionnaireSet)) Then

            Me.ImageKey = "QuestionnaireSet"

        ElseIf Me.TagType.Equals(GetType(BO.Questionnaire)) Then

            If CType(Me.Tag, BO.Questionnaire).MultipleInstances Then
                Me.ImageKey = "QuestionnaireLoop"
            Else
                Me.ImageKey = "Questionnaire"
            End If

        ElseIf Me.TagType.Equals(GetType(BO.Section)) Then

            Me.ImageKey = "Section"

        ElseIf Me.TagType.Equals(GetType(BO.CheckPoint)) Then

            Me.ImageKey = "Checkpoint"

        ElseIf Me.TagType.Equals(GetType(BO.Question)) Then

            Me.ImageKey = "Question"
            If CType(Me.Tag, BO.Question).Required Then
                Me.Style = ADVTree.Styles("Required")
            Else
                Me.Style = ADVTree.Styles("DefaultStyle")
            End If

        ElseIf Me.TagType.Equals(GetType(BO.Information)) Then

            Me.ImageKey = "Information"

        ElseIf Me.TagType.Equals(GetType(BO.Variable)) Then

            Me.ImageKey = "Variable"

        End If

    End Sub


    ''' <summary>
    ''' Refreshes UI from node and children.
    ''' </summary>
    ''' <remarks></remarks>

    Private Sub RefreshUIRecursive()

        Me.RefreshUI()

        For Each node As AdvNode In Me.Nodes

            node.RefreshUIRecursive()

        Next

    End Sub


    ''' <summary>
    ''' Constructor to deserialize the object.
    ''' </summary>
    ''' <param name="info">Incomming object.</param>
    ''' <param name="context"></param>
    ''' <remarks></remarks>

    Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)

        If BO.ContextClass.TrailSerialization Then

            MyBase.Tag = info.GetValue("tag", GetType(BO.GenericObject))
            If info.GetInt32("maxNodeIndex") >= 0 Then
                For i As Integer = 0 To info.GetInt32("maxNodeIndex")

                    Me.Nodes.Add(info.GetValue("n" & i.ToString, GetType(AdvNode)))

                Next
                If Me.Tag IsNot Nothing Then

                    AdvNode.refreshTree = False
                    Me.BuildBOFromTree()
                    AdvNode.refreshTree = True

                End If

            End If

            Me.Expanded = info.GetBoolean("expanded")
            Me.Text = info.GetString("text")
            If info.GetString("style") <> "" Then Me.Style = AdvNode.ADVTree.Styles(info.GetString("style"))
            Me.ImageKey = info.GetString("image")
            Me.number = info.GetString("number")

        Else

            MyBase.Tag = info.GetValue("tag", GetType(BO.GenericObject))

        End If

    End Sub


    ''' <summary>
    ''' Serializes the selected variables.
    ''' </summary>
    ''' <param name="info">Object serialization.</param>
    ''' <param name="context"></param>
    ''' <remarks></remarks>

    Public Sub GetObjectData(ByVal info As SerializationInfo, ByVal context As StreamingContext) Implements ISerializable.GetObjectData

        If BO.ContextClass.TrailSerialization Then

            BO.ContextClass.RecursiveSerialization = False
            info.AddValue("tag", Me.Tag)
            info.AddValue("maxNodeIndex", Me.Nodes.Count - 1)
            For i As Integer = 0 To Me.Nodes.Count - 1

                info.AddValue("n" & i.ToString, Me.Nodes(i))

            Next
            info.AddValue("expanded", Me.Expanded)
            info.AddValue("text", Me.Text)
            If Me.Style IsNot Nothing Then info.AddValue("style", Me.Style.Name) Else info.AddValue("style", "")
            info.AddValue("image", Me.ImageKey)
            info.AddValue("number", Me.number)
            BO.ContextClass.RecursiveSerialization = True

        Else

            info.AddValue("tag", Me.Tag)

        End If

    End Sub

#End Region

End Class

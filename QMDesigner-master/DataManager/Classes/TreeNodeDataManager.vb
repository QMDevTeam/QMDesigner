


Public Class EmptyNode
    ' Class used to return a value when my object is nothing.
End Class


Public Class TreeNodeDataManager
    Inherits DevComponents.AdvTree.Node

#Region " Public Members "
    '    Public Shared _columnsMetaDataQuestionnaireSet, _columnsMetaDataQuestionnaire, _columnsMetaDataSection As New List(Of String)
    'Private _columnsMetaData As List(Of String)

    Public Shared _styles As DevComponents.AdvTree.ElementStyleCollection

#End Region

#Region " Public Properties "

    Public Shadows ReadOnly Property TagGO() As BO.GenericObject
        Get
            Return CType(MyBase.Tag, BO.GenericObject)
        End Get
    End Property

    ''' <summary>
    ''' Returns the type of the contained object.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property TagType() As Type
        Get
            If Me.Tag Is Nothing Then
                Return GetType(EmptyNode)
            Else
                Return Me.Tag.GetType
            End If
        End Get
    End Property

    ''' <summary>
    ''' Overrites the parent property to return a TreeNodeDataManager instead of node.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ParentTreeNodeDataManager() As TreeNodeDataManager
        Get
            Return CType(Me.Parent, TreeNodeDataManager)
        End Get
    End Property

    ''' <summary>
    ''' Overrites the previoussibling property to return a TreeNodeDataManager instead of node.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property PrevTreeNodeDataManager() As TreeNodeDataManager
        Get
            Return CType(Me.PrevNode, TreeNodeDataManager)
        End Get
    End Property

#End Region

#Region " Public Methods "

    ''' <summary>
    ''' Sets the string to show and the object to display in the property grid.
    ''' </summary>
    ''' <param name="_myObject"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal _myObject As Object)

        MyBase.Tag = _myObject
        Me.Text = Tag.ToString()
        Me.Checked = True
        Me.CheckBoxVisible = True

    End Sub

    ' Sets the parameters and initial conditions before generate structure childs.
    Public Sub GenerateStructureChilds(ByVal showVariables As Boolean, ByVal metadataQuestionnaireSet As List(Of BO.Variable), _
                    ByVal metadataQuestionnaire As List(Of BO.Variable), ByVal metadataSection As List(Of BO.Variable))

        ' Clear the child nodes.
        Me.Nodes.Clear()

        If Me.TagType.BaseType.Equals(GetType(BO.SectionItem)) Then
            ' Check for previous numeration.
            If Me.ParentTreeNodeDataManager.TagType.Equals(GetType(BO.Section)) Then
                Me.ParentTreeNodeDataManager.GenerateStructureChilds(0, metadataQuestionnaireSet, metadataQuestionnaire, metadataSection)
            Else
                ' Split number and prefix.
                Dim sectionItemNumber As String = CType(Me.ParentTreeNodeDataManager.Tag, BO.SectionItem).Number
                Dim index As Integer = sectionItemNumber.LastIndexOf(".")
                Dim number As Integer = Integer.Parse(sectionItemNumber.Substring(index + 1))

                ' Focus parent node.
                BO.ContextClass.CurrentTreeNode = Me.ParentTreeNodeDataManager

                If index >= 0 Then
                    ' If prefix, split it.
                    Dim prefix As String = sectionItemNumber.Remove(index)
                    Me.ParentTreeNodeDataManager.GenerateStructureChilds(number, metadataQuestionnaireSet, metadataQuestionnaire, _
                            metadataSection, prefix & ".")
                Else
                    ' No prefix.
                    Me.ParentTreeNodeDataManager.GenerateStructureChilds(number, metadataQuestionnaireSet, metadataQuestionnaire, metadataSection)
                End If
            End If

        Else
            ' If is not a section item just generate.
            Me.GenerateStructureChilds(0, metadataQuestionnaireSet, metadataQuestionnaire, metadataSection, , showVariables)
        End If

        Me.Expand()
    End Sub

    ' Verifies if the node is child of the parameter or is the same node.
    Public Function IsChildOrSelfOf(ByVal parent As TreeNodeDataManager) As Boolean

        While parent IsNot Nothing And Not Me.Equals(parent) And parent.Level >= Me.Level
            parent = CType(parent.Parent, TreeNodeDataManager)
        End While

        Return Me.Equals(parent)
    End Function

    ' Sets the checked state to the node and its childrens.
    Public Sub SetCheckedRecursive(ByVal checked As Windows.Forms.CheckState)

        Dim stack As New Stack(Of TreeNodeDataManager)
        stack.Push(Me)

        While stack.Count > 0

            Dim tmp As TreeNodeDataManager = stack.Pop
            tmp.CheckState = checked


            If tmp.NextNode IsNot Nothing Then stack.Push(CType(tmp.NextNode, TreeNodeDataManager))
            If tmp.Nodes.Count > 0 Then stack.Push(CType(tmp.Nodes(0), TreeNodeDataManager))

        End While

    End Sub

    ' Insert childs of the MetaData
    Public Sub CreateMetaDataChilds(ByVal metaData As TreeNodeDataManager, ByVal listOfFlieds As List(Of BO.Variable))
        For Each field As BO.Variable In listOfFlieds
            Dim node As New TreeNodeDataManager(field)
            metaData.Nodes.Add(node)
        Next
    End Sub

#End Region

#Region " Private Method "

    ' Generates the childs for the current note and its childs for the structure tab.
    Private Sub GenerateStructureChilds(ByVal number As Integer, ByVal metadataQuestionnaireSet As List(Of BO.Variable), _
                    ByVal metadataQuestionnaire As List(Of BO.Variable), ByVal metadataSection As List(Of BO.Variable), _
                    Optional ByVal prefix As String = "", Optional ByVal showVariables As Boolean = True)

        Me.Nodes.Clear()

        ' Generate variable nodes.
        If Me.TagGO.HasVariables Then
            Dim node As New TreeNodeDataManager("Variables")
            node.ImageKey = "Variables"
            For Each variable As BO.Variable In Me.TagGO.Variables
                Dim variableNode As New TreeNodeDataManager(variable)
                variableNode.ImageKey = "Variable"
                node.Nodes.Add(variableNode)
            Next
            Me.Nodes.Add(node)
        End If

        ' Generate structure childs.
        Select Case Me.Tag.GetType.ToString

            Case GetType(BO.Study).ToString
                ' Set the study icon.
                Me.ImageKey = "Study"


                ' Add study's childs.
                Dim _study As BO.Study = CType(Me.Tag, BO.Study)
                For Each _questionnaireSet As BO.QuestionnaireSet In _study.QuestionnarieSets
                    Dim node As New TreeNodeDataManager(_questionnaireSet)
                    Me.Nodes.Add(node)
                    node.GenerateStructureChilds(0, metadataQuestionnaireSet, metadataQuestionnaire, metadataSection)
                Next

            Case GetType(BO.QuestionnaireSet).ToString
                ' Set questionnaire set icon.
                Me.ImageKey = "QuestionnaireSet"

                ' MetaData
                Dim _metaData As New TreeNodeDataManager("Metadata")

                CreateMetaDataChilds(_metaData, metadataQuestionnaireSet)

                Me.Nodes.Add(_metaData)
                ' End MetaData


                ' Add questionnaire set's childs.
                Dim _questionnaireSet As BO.QuestionnaireSet = CType(Me.Tag, BO.QuestionnaireSet)

                For Each _questionnarie As BO.Questionnaire In _questionnaireSet.Questionnaires
                    Dim node As New TreeNodeDataManager(_questionnarie)
                    Me.Nodes.Add(node)
                    node.GenerateStructureChilds(0, metadataQuestionnaireSet, metadataQuestionnaire, metadataSection)
                Next

            Case GetType(BO.Questionnaire).ToString
                ' Set questionnaire icon.
                Me.ImageKey = "Questionnaire"

                ' MetaData
                Dim _metaData As New TreeNodeDataManager("Metadata")

                CreateMetaDataChilds(_metaData, metadataQuestionnaire)

                Me.Nodes.Add(_metaData)
                ' End MetaData

                'Add Sections.
                Dim _questionnarie As BO.Questionnaire = CType(Me.Tag, BO.Questionnaire)
                For Each _section As BO.Section In _questionnarie.Sections
                    Dim node As New TreeNodeDataManager(_section)
                    Me.Nodes.Add(node)
                    node.GenerateStructureChilds(0, metadataQuestionnaireSet, metadataQuestionnaire, metadataSection)
                Next

            Case GetType(BO.Section).ToString
                ' Set Section icon.
                Me.ImageKey = "Section"

                ' MetaData
                Dim _metaData As New TreeNodeDataManager("Metadata")

                CreateMetaDataChilds(_metaData, metadataSection)

                Me.Nodes.Add(_metaData)
                ' End MetaData

                'Add Questions.
                Dim _section As BO.Section = CType(Me.Tag, BO.Section)

                Dim count As Integer = 1
                For Each _phase As BO.SectionItem In _section.SectionItems
                    Dim node As New TreeNodeDataManager(_phase)
                    Me.Nodes.Add(node)
                    node.GenerateStructureChilds(count, metadataQuestionnaireSet, metadataQuestionnaire, metadataSection)
                    count += 1
                Next

            Case GetType(BO.CheckPoint).ToString
                ' Set Checkpoint icon.
                Me.ImageKey = "Checkpoint"

                'Add Child Phases.
                Dim _checkPoint As BO.CheckPoint = CType(Me.Tag, BO.CheckPoint)
                _checkPoint.Number = prefix & number

                Dim count As Integer = 1
                For Each _phase As BO.SectionItem In _checkPoint.SectionItems
                    Dim node As New TreeNodeDataManager(_phase)
                    Me.Nodes.Add(node)
                    node.GenerateStructureChilds(count, metadataQuestionnaireSet, metadataQuestionnaire, metadataSection, prefix & number & ".")
                    count += 1
                Next

            Case GetType(BO.Question).ToString
                ' Set question icon.
                Me.ImageKey = "Question"

                ' Sets the color to the question.
                Dim _Question As BO.Question = CType(Me.Tag, BO.Question)
                If _Question.Required Then
                    Me.Style = _styles("Required")
                End If

                ' Sets the number.
                _Question.Number = prefix & number

            Case GetType(BO.Information).ToString
                ' Set information icon.
                Me.ImageKey = "Information"
                CType(Me.Tag, BO.SectionItem).Number = prefix & number
        End Select

        ' Sets the text and the selected image.
        Me.Text = Me.Tag.ToString

    End Sub

#End Region

End Class


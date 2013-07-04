Public Class StructureControl

#Region "Properties"

    ' Constants.
    Const StudyLevel As Integer = 0
    Const QuestionnaireSetLevel As Integer = 1
    Const QuestionnaireLevel As Integer = 2
    Const SectionLevel As Integer = 3
    Const QuestionLevel As Integer = 4

    'Preview control of Main Form
    Public uxPreviewControl As PreviewControl
    Public uxPropertyGrid As PropertyGrid
    Public uxCtlQuestionnaireSet As CtlQuestionnaireSet
    Public uxCtlQuestionnaire As CtlQuestionnaire
    Public uxCtlSection As CtlSection
    Public uxCtlVariable As CtlVariable
    Public uxCtlStudy As CtlStudy
    Public uxCtlCheckPoint As CtlCheckpoint
    Public uxCtlInformation As CtlInformation
    Public uxCtlQuestion As CtlQuestions


    ' Drag and drop.
    Private _dragOverStartTime As DateTime

    ' Compare with the old object and generate the change entry in the log.
    Private oldObject As BO.GenericObject = Nothing

    ' Undo/Redo.
    Public UndoStack As New Stack(Of NodeSnapshot)
    Public RedoStack As New Stack(Of NodeSnapshot)
    Private highLights As New List(Of List(Of Integer))


    ''' <summary>
    ''' Exposes the selected node of the tree.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Property SelectedAdvNode() As AdvNode
        Get
            Return Me.uxOutline.SelectedNode
        End Get
        Set(ByVal value As AdvNode)
            Me.uxOutline.SelectedNode = value
        End Set
    End Property

#End Region


#Region "Methods"

    ''' <summary>
    ''' Constructor: Assigns all the icons to the Add buttons and sets references.
    ''' </summary>
    ''' <remarks></remarks>

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AdvNode.ADVTree = uxOutline

        ' Assign icons to the Add buttons in context menu.
        Me.AddQuestionnaireSetToolStripMenuItem.Image = Me.ImageListTreeViewIcons.Images("QuestionnaireSet")
        Me.AddQuestionnaireToolStripMenuItem.Image = Me.ImageListTreeViewIcons.Images("Questionnaire")
        Me.AddSectionToolStripMenuItem.Image = Me.ImageListTreeViewIcons.Images("Section")
        Me.AddCheckpointToolStripMenuItem.Image = Me.ImageListTreeViewIcons.Images("Checkpoint")
        Me.AddQuestionToolStripMenuItem.Image = Me.ImageListTreeViewIcons.Images("Question")
        Me.AddInformationToolStripMenuItem.Image = Me.ImageListTreeViewIcons.Images("Information")
        Me.AddVariableToolStripMenuItem.Image = Me.ImageListTreeViewIcons.Images("Variable")

        ' Assign icons to the Add button in the menu strip.
        Me.QuestionnaireSetToolStripMenuItem.Image = Me.ImageListTreeViewIcons.Images("QuestionnaireSet")
        Me.QuestionnarieToolStripMenuItem.Image = Me.ImageListTreeViewIcons.Images("Questionnaire")
        Me.SectionToolStripMenuItem.Image = Me.ImageListTreeViewIcons.Images("Section")
        Me.CheckpointToolStripMenuItem.Image = Me.ImageListTreeViewIcons.Images("Checkpoint")
        Me.QuestionToolStripMenuItem.Image = Me.ImageListTreeViewIcons.Images("Question")
        Me.InformationToolStripMenuItem.Image = Me.ImageListTreeViewIcons.Images("Information")
        Me.VariableToolStripMenuItem.Image = Me.ImageListTreeViewIcons.Images("Variable")
    End Sub


    ''' <summary>
    ''' Load the study to the structural view.
    ''' </summary>
    ''' <param name="_study"></param>
    ''' <remarks></remarks>

    Public Sub MapStudy(ByRef _study As BO.Study)

        uxOutline.Nodes.Clear()
        Dim root As New AdvNode(_study)
        root.BuildTree()
        uxOutline.Nodes.Add(root)
        uxOutline.SelectedNode = root

    End Sub


    ''' <summary>
    ''' Highlights the node.
    ''' </summary>
    ''' <param name="node">Node to highlight.</param>
    ''' <remarks></remarks>

    Public Sub HighlightNodes(ByVal node As AdvNode)

        Dim list As New List(Of AdvNode)
        list.Add(node)
        HighlightNodes(list)

    End Sub


    ''' <summary>
    ''' Highlights every node in the list.
    ''' </summary>
    ''' <param name="nodes">List of nodes to highlight.</param>
    ''' <remarks></remarks>

    Public Sub HighlightNodes(ByVal nodes As List(Of AdvNode))

        ' Clear previous higlighted nodes.
        If highLights.Count > 0 Then

            For Each path As List(Of Integer) In highLights

                GetNodeByIndexPath(path).RefreshUI()

            Next
            highLights.Clear()

        End If

        ' Highlight the new nodes.
        For Each n As AdvNode In nodes

            n.Style = uxOutline.Styles("Highlighted")
            highLights.Add(n.IndexPath)

        Next

    End Sub


    ''' <summary>
    ''' Returns the node in the selected path.
    ''' </summary>
    ''' <param name="path">Path of indexes.</param>
    ''' <remarks></remarks>

    Public Function GetNodeByIndexPath(ByVal path As List(Of Integer)) As AdvNode

        Dim n As AdvNode = uxOutline.Nodes(0)
        For Each index As Integer In path

            n = n.Nodes(index)

        Next
        Return n

    End Function

    Public Function DisplayAndHideControls(ControlName As String)

        Select Case ControlName
            Case "BO.Study"
                Me.uxCtlQuestionnaire.Visible = False
                Me.uxCtlSection.Visible = False
                Me.uxCtlQuestionnaireSet.Visible = False
                Me.uxCtlVariable.Visible = False
                Me.uxCtlStudy.Visible = True
                Me.uxCtlCheckPoint.Visible = False
                Me.uxCtlInformation.Visible = False
                Me.uxCtlQuestion.Visible = False
            Case "BO.QuestionnaireSet"
                Me.uxCtlQuestionnaire.Visible = False
                Me.uxCtlSection.Visible = False
                Me.uxCtlQuestionnaireSet.Visible = True
                Me.uxCtlVariable.Visible = False
                Me.uxCtlStudy.Visible = False
                Me.uxCtlCheckPoint.Visible = False
                Me.uxCtlInformation.Visible = False
                Me.uxCtlQuestion.Visible = False
            Case "BO.Questionnaire"
                Me.uxCtlQuestionnaire.Visible = True
                Me.uxCtlQuestionnaireSet.Visible = False
                Me.uxCtlSection.Visible = False
                Me.uxCtlVariable.Visible = False
                Me.uxCtlStudy.Visible = False
                Me.uxCtlCheckPoint.Visible = False
                Me.uxCtlInformation.Visible = False
                Me.uxCtlQuestion.Visible = False
            Case "BO.Section"
                Me.uxCtlQuestionnaire.Visible = False
                Me.uxCtlSection.Visible = True
                Me.uxCtlQuestionnaireSet.Visible = False
                Me.uxCtlVariable.Visible = False
                Me.uxCtlStudy.Visible = False
                Me.uxCtlCheckPoint.Visible = False
                Me.uxCtlInformation.Visible = False
                Me.uxCtlQuestion.Visible = False
            Case "BO.Variable"
                Me.uxCtlQuestionnaire.Visible = False
                Me.uxCtlSection.Visible = False
                Me.uxCtlQuestionnaireSet.Visible = False
                Me.uxCtlVariable.Visible = True
                Me.uxCtlStudy.Visible = False
                Me.uxCtlCheckPoint.Visible = False
                Me.uxCtlInformation.Visible = False
                Me.uxCtlQuestion.Visible = False
            Case "BO.Question"
                Me.uxCtlQuestionnaire.Visible = False
                Me.uxCtlSection.Visible = False
                Me.uxCtlQuestionnaireSet.Visible = False
                Me.uxCtlVariable.Visible = False
                Me.uxCtlStudy.Visible = False
                Me.uxCtlCheckPoint.Visible = False
                Me.uxCtlInformation.Visible = False
                Me.uxCtlQuestion.Visible = True
            Case "BO.CheckPoint"
                Me.uxCtlQuestionnaire.Visible = False
                Me.uxCtlSection.Visible = False
                Me.uxCtlQuestionnaireSet.Visible = False
                Me.uxCtlVariable.Visible = False
                Me.uxCtlStudy.Visible = False
                Me.uxCtlCheckPoint.Visible = True
                Me.uxCtlInformation.Visible = False
                Me.uxCtlQuestion.Visible = False
            Case "BO.Information"
                Me.uxCtlQuestionnaire.Visible = False
                Me.uxCtlSection.Visible = False
                Me.uxCtlQuestionnaireSet.Visible = False
                Me.uxCtlVariable.Visible = False
                Me.uxCtlStudy.Visible = False
                Me.uxCtlCheckPoint.Visible = False
                Me.uxCtlInformation.Visible = True
                Me.uxCtlQuestion.Visible = False
        End Select

    End Function


    ''' <summary>
    ''' private: Custom function to sort nodes by index.
    ''' </summary>
    ''' <param name="o1"></param>
    ''' <param name="o2"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Private Shared Function SortNodeListByIndex(ByVal o1 As AdvNode, ByVal o2 As AdvNode) As Integer
        Return o1.Index - o2.Index
    End Function

#End Region


#Region "Tree View events"

    ''' <summary>
    ''' Drag and drop: Sets the initial time of the hover for expand while dragging nodes.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>

    Private Sub uxOutline_NodeDragStart(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uxOutline.NodeDragStart

        Me._dragOverStartTime = Now

    End Sub


    ''' <summary>
    ''' Drag and drop: Expands the node when the mouse stays more than 500ms
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>

    Private Sub uxOutline_DragOver(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles uxOutline.DragOver

        Dim node As DevComponents.AdvTree.Node = Me.uxOutline.GetNodeAt(uxOutline.PointToClient(New Point(e.X, e.Y)))
        If node IsNot Nothing Then

            If Now.Subtract(_dragOverStartTime).Milliseconds >= 500 Then

                node.Expand()

            End If

        Else

            _dragOverStartTime = Now

        End If

    End Sub


    ''' <summary>
    ''' Drag and drop: Validates if the node can be dropped in the current position.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>

    Private Sub uxOutline_NodeDragFeedback(ByVal sender As System.Object, ByVal e As DevComponents.AdvTree.TreeDragFeedbackEventArgs) Handles uxOutline.NodeDragFeedback

        If CType(e.DragNode, AdvNode).CanDropOver(CType(e.ParentNode, AdvNode)) Then

            e.Effect = DragDropEffects.All

        Else

            e.Effect = DragDropEffects.None

        End If

    End Sub


    ''' <summary>
    ''' Drag and drop: Updates both branches of the tree after the drag and drop is completed.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>Rebuilds the BO of the deeper node first.</remarks>

    Private Sub uxOutline_AfterNodeDrop(ByVal sender As System.Object, ByVal e As DevComponents.AdvTree.TreeDragDropEventArgs) Handles uxOutline.AfterNodeDrop

        If e.NewParentNode.Equals(e.OldParentNode) Then

            CType(e.NewParentNode, AdvNode).BuildBOFromTree()

        ElseIf e.NewParentNode.Level > e.OldParentNode.Level Then

            CType(e.NewParentNode, AdvNode).BuildBOFromTree()
            CType(e.OldParentNode, AdvNode).BuildBOFromTree()

        Else

            CType(e.OldParentNode, AdvNode).BuildBOFromTree()
            CType(e.NewParentNode, AdvNode).BuildBOFromTree()

        End If
        BO.ContextClass.HasChanges = True

    End Sub


    ''' <summary>
    ''' Drag and drop: Takes the snapshots of the tree before the movement takes effect.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>

    Private Sub uxOutline_BeforeNodeDrop(ByVal sender As System.Object, ByVal e As DevComponents.AdvTree.TreeDragDropEventArgs) Handles uxOutline.BeforeNodeDrop

        If e.NewParentNode.Level > e.OldParentNode.Level Then

            Me.UndoStack.Push(New NodeSnapshot(e.OldParentNode.Parent))

        Else

            Me.UndoStack.Push(New NodeSnapshot(e.NewParentNode.Parent))

        End If
        Me.UndoStack.Peek.Description = String.Format("Moved node(s) from '{0}' to '{1}'", e.OldParentNode.Text, e.NewParentNode.Text)
        Me.UndoStack.Peek.Disposable = False

    End Sub


    ''' <summary>
    ''' Before select node.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>Validates if avialible.</remarks>

    Private Sub uxOutline_BeforeNodeSelect(ByVal sender As System.Object, ByVal e As DevComponents.AdvTree.AdvTreeNodeCancelEventArgs) Handles uxOutline.BeforeNodeSelect

        If uxOutline.SelectedNode Is Nothing Then Exit Sub
        If uxOutline.SelectedNode.Tag Is Nothing Then Exit Sub
        If uxOutline.SelectedNode.Tag.GetType.GetInterface("ISelfValidate") Is Nothing Then Exit Sub
        e.Cancel = Not CType(uxOutline.SelectedNode.Tag, BO.ISelfValidate).IsValid()

    End Sub


    ''' <summary>
    ''' Updates the property grid.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>

    Private Sub uxOutline_CellSelected(ByVal sender As System.Object, ByVal e As DevComponents.AdvTree.AdvTreeCellEventArgs) Handles uxOutline.CellSelected

        If Me.uxOutline.SelectedNode.Tag Is Nothing Then
            e.Cell.Tag = Me.uxOutline.SelectedNode.Parent.Tag
        Else
            Select Case SelectedAdvNode.TagType.FullName
                Case "BO.Study"
                    Me.uxCtlStudy.PopulateStudy(Me.uxOutline.SelectedNode.Tag)
                Case "BO.QuestionnaireSet"
                    Me.uxCtlQuestionnaireSet.PopulateQuestionnaireSet(Me.uxOutline.SelectedNode.Tag)
                Case "BO.Questionnaire"
                    Me.uxCtlQuestionnaire.PopulateQuestionnaire(Me.uxOutline.SelectedNode.Tag)
                Case "BO.Section"
                    Me.uxCtlSection.PopulateSection(Me.uxOutline.SelectedNode.Tag)
                Case "BO.Variable"
                    Me.uxCtlVariable.PopulateVariable(Me.uxOutline.SelectedNode.Tag)
                Case "BO.Question"
                    Me.uxCtlQuestion.PopulateQuestion(Me.uxOutline.SelectedNode.Tag)
                Case ("BO.Information")
                    Me.uxCtlInformation.PopulateInformation(Me.uxOutline.SelectedNode.Tag)
                Case "BO.CheckPoint"
                    Me.uxCtlCheckPoint.PopulateCheckPoint(Me.uxOutline.SelectedNode.Tag)
            End Select

            Me.DisplayAndHideControls(SelectedAdvNode.TagType.FullName)

        End If

    End Sub

#End Region


#Region "Tree View Context Menu events"

    ''' <summary>
    ''' Context menu: Make visible or invisible some options acording to the selected node.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>

    Private Sub ContextMenuStripTree_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStripTree.Opening

        ' Show the menu only if the user clicked a node.
        Dim position As Point = uxOutline.PointToClient(Cursor.Position)
        If Me.SelectedAdvNode IsNot Nothing Then

            If Me.SelectedAdvNode.Tag Is Nothing AndAlso Me.SelectedAdvNode.AdvNodeParent.Tag.HasVariables Then
                ' Hide the ADD buttons.
                AddQuestionnaireSetToolStripMenuItem.Visible = False
                AddQuestionnaireToolStripMenuItem.Visible = False
                AddSectionToolStripMenuItem.Visible = False
                AddQuestionToolStripMenuItem.Visible = False
                AddCheckpointToolStripMenuItem.Visible = False
                AddInformationToolStripMenuItem.Visible = False
                AddVariableToolStripMenuItem.Visible = True

                ' Hide indent buttons and separator.
                ToolStripSeparator2.Visible = False
                IncreaseIndentToolStripMenuItem.Visible = False
                DecreaseIndentToolStripMenuItem.Visible = False
            Else

                ' Show the ADD buttons that apply to the selected node.
                AddQuestionnaireSetToolStripMenuItem.Visible = SelectedAdvNode.TagType.Equals(GetType(BO.Study))
                AddQuestionnaireToolStripMenuItem.Visible = SelectedAdvNode.TagType.Equals(GetType(BO.QuestionnaireSet))
                AddSectionToolStripMenuItem.Visible = SelectedAdvNode.TagType.Equals(GetType(BO.Questionnaire))
                AddQuestionToolStripMenuItem.Visible = SelectedAdvNode.TagType.Equals(GetType(BO.Section)) _
                                                    Or SelectedAdvNode.TagType.BaseType.Equals(GetType(BO.SectionItem))
                AddCheckpointToolStripMenuItem.Visible = SelectedAdvNode.TagType.Equals(GetType(BO.Section)) _
                                                      Or SelectedAdvNode.TagType.BaseType.Equals(GetType(BO.SectionItem))
                AddInformationToolStripMenuItem.Visible = SelectedAdvNode.TagType.Equals(GetType(BO.Section)) _
                                                      Or SelectedAdvNode.TagType.BaseType.Equals(GetType(BO.SectionItem))
                AddVariableToolStripMenuItem.Visible = Not SelectedAdvNode.TagType.BaseType.Equals(GetType(BO.SectionItem))

                ' Show if needed the increase and decrease indent buttons.
                ToolStripSeparator2.Visible = SelectedAdvNode.TagType.BaseType.Equals(GetType(BO.SectionItem))
                IncreaseIndentToolStripMenuItem.Visible = SelectedAdvNode.TagType.BaseType.Equals(GetType(BO.SectionItem))
                DecreaseIndentToolStripMenuItem.Visible = SelectedAdvNode.TagType.BaseType.Equals(GetType(BO.SectionItem))
            End If

        Else

            e.Cancel = True

        End If

    End Sub


    ''' <summary>
    ''' Context menu: Add questionnaireSet.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>

    Private Sub AddQuestionnaireSetToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddQuestionnaireSetToolStripMenuItem.Click, QuestionnaireSetToolStripMenuItem.Click

        Dim newNode As New AdvNode(FrmQuestionnaireSet.AddQuestionnaireSetItems(New BO.QuestionnaireSet()))
        If newNode.Tag Is Nothing Then Exit Sub
        Dim index As Integer
        Dim parentNode As AdvNode = Nothing

        If SelectedAdvNode.TagType.Equals(GetType(BO.Study)) Then

            parentNode = Me.uxOutline.SelectedNode
            index = parentNode.Nodes.Count

        ElseIf SelectedAdvNode.TagType.Equals(GetType(BO.QuestionnaireSet)) Then

            parentNode = Me.uxOutline.SelectedNode.Parent
            index = Me.uxOutline.SelectedNode.Index

        End If

        Me.UndoStack.Push(New NodeSnapshot(parentNode))
        Me.UndoStack.Peek.Description = String.Format("Add Questionnaireset as child of '{0}' at position '{1}'", parentNode.ToString, index)
        Me.UndoStack.Peek.Disposable = False

        parentNode.Nodes.Insert(index, newNode)
        parentNode.BuildBOFromTree()
        uxOutline.SelectedNode = newNode
        BO.ContextClass.HasChanges = True

    End Sub


    ''' <summary>
    ''' Context menu: Add questionnaire.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>

    Private Sub AddQuestionnaireToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddQuestionnaireToolStripMenuItem.Click, QuestionnarieToolStripMenuItem.Click

        Dim newNode As New AdvNode(FrmQuestionnaire.AddQuestionnaireItems(New BO.Questionnaire(), Me.SelectedAdvNode))
        If newNode.Tag Is Nothing Then Exit Sub
        Dim index As Integer
        Dim parentNode As AdvNode

        If SelectedAdvNode.TagType.Equals(GetType(BO.QuestionnaireSet)) Then

            parentNode = Me.uxOutline.SelectedNode
            index = parentNode.Nodes.Count

        ElseIf SelectedAdvNode.TagType.Equals(GetType(BO.Questionnaire)) Then

            parentNode = Me.uxOutline.SelectedNode.Parent
            index = Me.uxOutline.SelectedNode.Index

        End If

        Me.UndoStack.Push(New NodeSnapshot(parentNode))
        Me.UndoStack.Peek.Description = String.Format("Add Questionnaire as child of '{0}' at position '{1}'", parentNode.ToString, index)
        Me.UndoStack.Peek.Disposable = False

        parentNode.Nodes.Insert(index, newNode)
        parentNode.BuildBOFromTree()
        uxOutline.SelectedNode = newNode
        BO.ContextClass.HasChanges = True

    End Sub


    ''' <summary>
    ''' Context menu: Add section.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>

    Private Sub AddSectionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddSectionToolStripMenuItem.Click, SectionToolStripMenuItem.Click

        Dim newNode As New AdvNode(FrmSection.AddSectionItems(New BO.Section(), Me.SelectedAdvNode))
        If newNode.Tag Is Nothing Then Exit Sub
        Dim index As Integer
        Dim parentNode As AdvNode

        If SelectedAdvNode.TagType.Equals(GetType(BO.Questionnaire)) Then

            parentNode = Me.uxOutline.SelectedNode
            index = parentNode.Nodes.Count

        ElseIf SelectedAdvNode.TagType.Equals(GetType(BO.Section)) Then

            parentNode = Me.uxOutline.SelectedNode.Parent
            index = Me.uxOutline.SelectedNode.Index

        End If

        Me.UndoStack.Push(New NodeSnapshot(parentNode))
        Me.UndoStack.Peek.Description = String.Format("Add Section as child of '{0}' at position '{1}'", parentNode.ToString, index)
        Me.UndoStack.Peek.Disposable = False

        parentNode.Nodes.Insert(index, newNode)
        parentNode.BuildBOFromTree()
        uxOutline.SelectedNode = newNode
        BO.ContextClass.HasChanges = True

    End Sub


    ''' <summary>
    ''' Context menu: Add question.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>

    Private Sub AddQuestionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddQuestionToolStripMenuItem.Click, QuestionToolStripMenuItem.Click

        Dim newNode As New AdvNode(FrmPropertyQuestions.Execute(New BO.Question()))
        If newNode.Tag Is Nothing Then Exit Sub
        Dim index As Integer
        Dim parentNode As AdvNode

        If SelectedAdvNode.Tag.HasSectionItems Then

            parentNode = Me.uxOutline.SelectedNode
            index = parentNode.Nodes.Count

        ElseIf SelectedAdvNode.TagType.BaseType.Equals(GetType(BO.SectionItem)) Then

            parentNode = Me.uxOutline.SelectedNode.Parent
            index = uxOutline.SelectedNode.Index

        End If

        Me.UndoStack.Push(New NodeSnapshot(parentNode))
        Me.UndoStack.Peek.Description = String.Format("Add question as child of '{0}' at position '{1}'", parentNode.ToString, index)
        Me.UndoStack.Peek.Disposable = False

        parentNode.Nodes.Insert(index, newNode)
        parentNode.BuildBOFromTree()
        uxOutline.SelectedNode = newNode
        BO.ContextClass.HasChanges = True

    End Sub


    ''' <summary>
    ''' Context menu: Add checkpoint.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>

    Private Sub AddCheckpointToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddCheckpointToolStripMenuItem.Click, CheckpointToolStripMenuItem.Click

        Dim newNode As New AdvNode(FrmPropertyCheckpoint.Execute(New BO.CheckPoint()))
        If newNode.Tag Is Nothing Then Exit Sub
        Dim index As Integer
        Dim parentNode As AdvNode

        If SelectedAdvNode.Tag.HasSectionItems Then

            parentNode = Me.uxOutline.SelectedNode
            index = parentNode.Nodes.Count

        ElseIf SelectedAdvNode.TagType.BaseType.Equals(GetType(BO.SectionItem)) Then

            parentNode = Me.uxOutline.SelectedNode.Parent
            index = uxOutline.SelectedNode.Index

        End If

        Me.UndoStack.Push(New NodeSnapshot(parentNode))
        Me.UndoStack.Peek.Description = String.Format("Add checkpoint as child of '{0}' at position '{1}'", parentNode.ToString, index)
        Me.UndoStack.Peek.Disposable = False

        parentNode.Nodes.Insert(index, newNode)
        parentNode.BuildBOFromTree()
        uxOutline.SelectedNode = newNode
        BO.ContextClass.HasChanges = True

    End Sub


    ''' <summary>
    ''' Context menu: Add Information.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>

    Private Sub AddInformationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddInformationToolStripMenuItem.Click, InformationToolStripMenuItem.Click

        Dim newNode As New AdvNode(FrmPropertyInformation.Execute(New BO.Information()))
        If newNode.Tag Is Nothing Then Exit Sub
        Dim index As Integer
        Dim parentNode As AdvNode

        If SelectedAdvNode.Tag.HasSectionItems Then

            parentNode = Me.uxOutline.SelectedNode
            index = parentNode.Nodes.Count

        ElseIf SelectedAdvNode.TagType.BaseType.Equals(GetType(BO.SectionItem)) Then

            parentNode = Me.uxOutline.SelectedNode.Parent
            index = uxOutline.SelectedNode.Index

        End If

        Me.UndoStack.Push(New NodeSnapshot(parentNode))
        Me.UndoStack.Peek.Description = String.Format("Add information screen as child of '{0}' at position '{1}'", parentNode.ToString, index)
        Me.UndoStack.Peek.Disposable = False

        parentNode.Nodes.Insert(index, newNode)
        parentNode.BuildBOFromTree()
        uxOutline.SelectedNode = newNode
        BO.ContextClass.HasChanges = True

    End Sub


    ''' <summary>
    ''' Context menu: Add variable.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>

    Private Sub AddVariableToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddVariableToolStripMenuItem.Click, VariableToolStripMenuItem.Click

        Dim node As AdvNode = SelectedAdvNode
        If Me.uxOutline.SelectedNode.Tag Is Nothing Then

            node = CType(uxOutline.SelectedNode.Parent, AdvNode)

        ElseIf Me.SelectedAdvNode.TagType.Equals(GetType(BO.Variable)) Then

            node = CType(uxOutline.SelectedNode.Parent.Parent, AdvNode)

        End If

        If node.Tag.HasVariables Then

            Dim newNode As New AdvNode(FrmVariable.AddVariableItems(New BO.Variable()))
            If newNode.Tag Is Nothing Then Exit Sub
            newNode.RefreshUI()

            Me.UndoStack.Push(New NodeSnapshot(node))
            Me.UndoStack.Peek.Description = String.Format("Add variable as child of '{0}'", node.ToString)
            Me.UndoStack.Peek.Disposable = False

            Dim i As Integer
            Dim inserted As Boolean = False
            For i = 0 To node.Tag.Variables.Count - 1
                If node.Tag.Variables(i).Name > newNode.Tag.Name Then
                    node.Tag.Variables.Insert(i, CType(newNode.Tag, BO.Variable))
                    node.Nodes(0).Nodes.Insert(i, newNode)
                    inserted = True
                    Exit For
                End If
            Next

            If Not inserted Then
                node.Tag.Variables.Add(CType(newNode.Tag, BO.Variable))
                node.Nodes(0).Nodes.Add(newNode)
            End If

            uxOutline.SelectedNode = newNode
            newNode.BuildTree()

        End If
        BO.ContextClass.HasChanges = True

    End Sub


    ''' <summary>
    ''' Context menu: Collapse all the children nodes.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>

    Private Sub CollapseAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CollapseAllToolStripMenuItem.Click

        Dim queue As New Queue(Of AdvNode)
        queue.Enqueue(Me.uxOutline.SelectedNode)
        While queue.Count > 0

            queue.Peek.Collapse()
            For Each n As AdvNode In queue.Peek.Nodes
                queue.Enqueue(n)
            Next
            queue.Dequeue()

        End While

    End Sub


    ''' <summary>
    ''' Context menu: Expand all the children nodes.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>

    Private Sub ExpandAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExpandAllToolStripMenuItem.Click

        SelectedAdvNode.ExpandAll()
        SelectedAdvNode.Expand()

    End Sub


    ''' <summary>
    ''' Context menu: Deletes all the selected nodes. DEL
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click, ToolStripButton1.Click

        'If the user attempts to delete the study.
        If uxOutline.SelectedNode.Level = 0 Then

            MessageBox.Show("You can't remove the study. Pleace create a new one.")
            Exit Sub

        End If

        ' Remove the references to the selected node.
        If MessageBox.Show("Are you sure you want to delete the selected node(s)?", "Delete", MessageBoxButtons.YesNo) = DialogResult.Yes Then

            Dim parentNode As AdvNode = SelectedAdvNode.AdvNodeParent

            Me.UndoStack.Push(New NodeSnapshot(parentNode))
            Me.UndoStack.Peek.Description = String.Format("Delete node(s) at '{0}'", parentNode.ToString)
            Me.UndoStack.Peek.Disposable = False

            ' Copy the list of nodes.
            Dim list As New List(Of AdvNode)
            For Each n As AdvNode In uxOutline.SelectedNodes

                list.Add(n)

            Next

            ' Delete the nodes.
            For Each n As AdvNode In list

                n.Remove()

            Next
            parentNode.BuildBOFromTree()

        End If
        BO.ContextClass.HasChanges = True

    End Sub


    ''' <summary>
    ''' Context menu: Copy only the selected node. Ctrl + C
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>The children collections are created new. Uses the flag in ContextClass.</remarks>

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem.Click

        Dim list As New List(Of AdvNode)
        For Each n As AdvNode In uxOutline.SelectedNodes
            list.Add(n)
        Next
        list.Sort(AddressOf SortNodeListByIndex)

        Clipboard.Clear()
        BO.ContextClass.RecursiveSerialization = False
        Clipboard.SetData(DataFormats.Serializable, list)
        BO.ContextClass.RecursiveSerialization = True

    End Sub


    ''' <summary>
    ''' Context menu: Copy the hole node including childs. Ctrl + Alt + C
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>

    Private Sub CopyWithChildrenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyWithChildrenToolStripMenuItem.Click

        Dim list As New List(Of AdvNode)
        For Each n As AdvNode In uxOutline.SelectedNodes
            list.Add(n)
        Next
        list.Sort(AddressOf SortNodeListByIndex)

        Clipboard.Clear()
        Clipboard.SetData(DataFormats.Serializable, list)

    End Sub


    ''' <summary>
    ''' Context menu: Cut the node and puts it into the clipboard. Ctrl + X
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>

    Private Sub CutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CutToolStripMenuItem.Click

        Dim parent As AdvNode = uxOutline.SelectedNode.Parent
        Dim list As New List(Of AdvNode)
        For Each n As AdvNode In uxOutline.SelectedNodes
            list.Add(n)
        Next
        list.Sort(AddressOf SortNodeListByIndex)

        Clipboard.Clear()
        Clipboard.SetData(DataFormats.Serializable, list)

        For Each n As AdvNode In list
            n.Remove()
        Next
        parent.BuildBOFromTree()
    End Sub


    ''' <summary>
    ''' Context menu: Paste the object in the clipboard. Ctrl + V
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasteToolStripMenuItem.Click

        SelectedAdvNode = uxOutline.SelectedNode

        If Clipboard.GetDataObject.GetDataPresent(DataFormats.Serializable) AndAlso Clipboard.GetData(DataFormats.Serializable).GetType().Equals(GetType(List(Of AdvNode))) Then

            Dim clip As List(Of AdvNode) = Clipboard.GetData(DataFormats.Serializable)
            Dim parent As AdvNode = SelectedAdvNode.AdvNodeParent
            If parent Is Nothing Then parent = SelectedAdvNode
            Dim index As Integer = SelectedAdvNode.Index

            For Each n As AdvNode In clip

                ' Assign new guids to all the nodes in the tree.
                n.BuildTree()
                Dim queue As New Queue(Of AdvNode)
                queue.Enqueue(n)
                While queue.Count > 0

                    If queue.Peek.Tag IsNot Nothing Then

                        queue.Peek.Tag.Guid = Guid.NewGuid

                        ' Assign new DatabaseID.
                        If queue.Peek.TagType.Equals(GetType(BO.QuestionnaireSet)) Then

                            BO.QuestionnaireSet.MaxDatabaseID += 1
                            queue.Peek.Tag.DataBaseID = BO.QuestionnaireSet.MaxDatabaseID

                        ElseIf queue.Peek.TagType.Equals(GetType(BO.Questionnaire)) Then

                            BO.Questionnaire.MaxDataBaseID += 1
                            queue.Peek.Tag.DataBaseID = BO.Questionnaire.MaxDataBaseID

                        ElseIf queue.Peek.TagType.Equals(GetType(BO.Section)) Then

                            BO.Section.MaxDataBaseID += 1
                            queue.Peek.Tag.DataBaseID = BO.Section.MaxDataBaseID

                        End If

                    End If
                    For Each node As AdvNode In queue.Peek.Nodes

                        queue.Enqueue(node)

                    Next
                    queue.Dequeue()

                End While
            Next

            If clip(0).CanDropOver(parent) Then

                For Each n As AdvNode In clip
                    parent.Nodes.Insert(index, n)
                    index += 1
                Next
                parent.BuildBOFromTree()

            ElseIf clip(0).CanDropOver(SelectedAdvNode) Then

                For Each n As AdvNode In clip
                    SelectedAdvNode.Nodes.Add(n)
                Next
                SelectedAdvNode.BuildBOFromTree()

            Else

                MessageBox.Show("You can't paste the node in this context.")
                Exit Sub

            End If

        End If

    End Sub


    ''' <summary>
    ''' Context menu: Decrease indent.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>Moves the child section items out of a checkpoint as next sibblings.</remarks>

    Private Sub DecreaseIndentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DecreaseIndentToolStripMenuItem.Click

        ' If is the top level of the section.
        If Not SelectedAdvNode.AdvNodeParent.AdvNodeParent.Tag.HasSectionItems Then Exit Sub

        Dim oldParent As AdvNode = SelectedAdvNode.AdvNodeParent
        Dim parent As AdvNode = SelectedAdvNode.AdvNodeParent.AdvNodeParent
        Dim offset As Integer = SelectedAdvNode.AdvNodeParent.Index + 1
        Dim nodeList As New List(Of AdvNode)

        For Each n As AdvNode In uxOutline.SelectedNodes

            nodeList.Add(n)

        Next
        nodeList.Sort(AddressOf SortNodeListByIndex)
        For i As Integer = nodeList.Count - 1 To 0 Step -1

            oldParent.Nodes.RemoveAt(nodeList(i).Index)
            parent.Nodes.Insert(offset, nodeList(i))

        Next
        oldParent.BuildBOFromTree()
        parent.BuildBOFromTree()

    End Sub


    ''' <summary>
    ''' Context menu: Increase indent.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>Puts the selected nodes in the previous node if is a checkpoint.</remarks>

    Private Sub IncreaseIndentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IncreaseIndentToolStripMenuItem.Click

        Dim offset As Integer
        Dim nodeList As New List(Of AdvNode)

        For Each n As AdvNode In uxOutline.SelectedNodes

            nodeList.Add(n)

        Next
        nodeList.Sort(AddressOf SortNodeListByIndex)
        offset = nodeList(0).Index - 1

        If offset < 0 OrElse Not nodeList(0).AdvNodePrevNode.TagType.Equals(GetType(BO.CheckPoint)) Then
            MessageBox.Show("To increase indent you need a checkpoint before the seleced node.")
            Exit Sub
        End If

        Dim parentNode As AdvNode = nodeList(0).AdvNodePrevNode
        For Each n As AdvNode In nodeList

            n.Remove()
            parentNode.Nodes.Add(n)

        Next

        parentNode.BuildBOFromTree()
        parentNode.AdvNodeParent.BuildBOFromTree()

    End Sub

#End Region


#Region "Toolbar events"

    ''' <summary>
    ''' Tool bar button: Generates the preview of the selected node.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click

        uxPreviewControl.Preview(SelectedAdvNode)

    End Sub


    ''' <summary>
    ''' Toolbar button: Refreshes the selected node.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click

        Dim node As AdvNode = uxOutline.SelectedNode
        If Not node Is Nothing Then

            While node.Tag Is Nothing
                node = node.Parent
            End While

            node.BuildTree()
        End If
    End Sub


    ''' <summary>
    ''' Toolbar: Undo the last action.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>

    Private Sub UndoToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UndoToolStripButton.Click

        AdvNode.refreshTree = False
        While Me.UndoStack.Count > 0 AndAlso Me.UndoStack.Peek.Disposable
            Me.UndoStack.Pop()
        End While
        If Me.UndoStack.Count > 0 Then

            Me.RedoStack.Push(New NodeSnapshot(Me.GetNodeByIndexPath(Me.UndoStack.Peek.Path)))
            Me.RedoStack.Peek.Description = Me.UndoStack.Peek.Description
            Me.UndoStack.Pop.Restore(Me.uxOutline.Nodes(0))
            AdvNode.refreshTree = True

        Else

            Me.UndoToolStripDropDownButton.ShowDropDown()

        End If

    End Sub


    ''' <summary>
    ''' Toolbar: Redo the last undone action.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>

    Private Sub RedoToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RedoToolStripButton.Click

        If Me.RedoStack.Count > 0 Then

            AdvNode.refreshTree = False
            Me.UndoStack.Push(New NodeSnapshot(Me.GetNodeByIndexPath(Me.RedoStack.Peek.Path)))
            Me.UndoStack.Peek.Description = Me.RedoStack.Peek.Description
            Me.UndoStack.Peek.Disposable = False
            Me.RedoStack.Pop.Restore(Me.uxOutline.Nodes(0))
            AdvNode.refreshTree = True

        Else

            Me.RedoToolStripDropDownButton.ShowDropDown()

        End If

    End Sub


    ''' <summary>
    ''' Toolbar: Populates the dropdown with all the non disposable entries in the undo stack.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>

    Private Sub UndoToolStripDropDownButton_DropDownOpening(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UndoToolStripDropDownButton.DropDownOpening

        UndoToolStripDropDownButton.DropDown.Items.Clear()
        For Each snapshot As NodeSnapshot In Me.UndoStack

            If Not snapshot.Disposable Then UndoToolStripDropDownButton.DropDown.Items.Add(snapshot.Description).Tag = snapshot

        Next
        If UndoToolStripDropDownButton.DropDown.Items.Count = 0 Then

            UndoToolStripDropDownButton.DropDown.Items.Add("(Empty)")

        End If
    End Sub


    ''' <summary>
    ''' Toolbar: Populates the dropdown with all the non disposable entries in the redo stack.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>

    Private Sub RedoToolStripDropDownButton_DropDownOpening(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RedoToolStripDropDownButton.DropDownOpening

        RedoToolStripDropDownButton.DropDown.Items.Clear()
        If Me.RedoStack.Count > 0 Then
            For Each snapshot As NodeSnapshot In Me.RedoStack

                RedoToolStripDropDownButton.DropDown.Items.Add(snapshot.Description).Tag = snapshot

            Next
        Else
            RedoToolStripDropDownButton.DropDown.Items.Add("(Empty)")
        End If

    End Sub


    ''' <summary>
    ''' Toolbar: Undos actions until the selected one is undone.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>

    Private Sub UndoToolStripDropDownButton_DropDownItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles UndoToolStripDropDownButton.DropDownItemClicked

        If e.ClickedItem.Tag Is Nothing Then Exit Sub
        While Not e.ClickedItem.Tag.Equals(UndoStack.Peek)

            UndoToolStripButton_Click(sender, e)

        End While
        UndoToolStripButton_Click(sender, e)
        UndoToolStripDropDownButton.HideDropDown()

    End Sub


    ''' <summary>
    ''' Toolbar: Redos actions until the selected one is redone.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>

    Private Sub RedoToolStripDropDownButton_DropDownItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles RedoToolStripDropDownButton.DropDownItemClicked

        If e.ClickedItem.Tag Is Nothing Then Exit Sub
        While Not e.ClickedItem.Tag.Equals(RedoStack.Peek)

            RedoToolStripButton_Click(sender, e)

        End While
        RedoToolStripButton_Click(sender, e)
        RedoToolStripDropDownButton.HideDropDown()

    End Sub


    ''' <summary>
    ''' Toolbar: Enables/Disables the add buttons in the toolbar.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>

    Private Sub ToolStripDropDownButton1_DropDownOpening(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripDropDownButton1.DropDownOpening

        If Me.SelectedAdvNode IsNot Nothing Then

            If Me.SelectedAdvNode.Tag Is Nothing AndAlso Me.SelectedAdvNode.AdvNodeParent.Tag.HasVariables Then

                ' Hide the ADD buttons.
                QuestionnaireSetToolStripMenuItem.Enabled = False
                QuestionnarieToolStripMenuItem.Enabled = False
                SectionToolStripMenuItem.Enabled = False
                QuestionToolStripMenuItem.Enabled = False
                CheckpointToolStripMenuItem.Enabled = False
                InformationToolStripMenuItem.Enabled = False
                VariableToolStripMenuItem.Enabled = True

            Else

                ' Show the ADD buttons that apply to the selected node.
                QuestionnaireSetToolStripMenuItem.Enabled = SelectedAdvNode.TagType.Equals(GetType(BO.Study))
                QuestionnarieToolStripMenuItem.Enabled = SelectedAdvNode.TagType.Equals(GetType(BO.QuestionnaireSet))
                SectionToolStripMenuItem.Enabled = SelectedAdvNode.TagType.Equals(GetType(BO.Questionnaire))
                QuestionToolStripMenuItem.Enabled = SelectedAdvNode.TagType.Equals(GetType(BO.Section)) _
                                                    Or SelectedAdvNode.TagType.BaseType.Equals(GetType(BO.SectionItem))
                CheckpointToolStripMenuItem.Enabled = SelectedAdvNode.TagType.Equals(GetType(BO.Section)) _
                                                      Or SelectedAdvNode.TagType.BaseType.Equals(GetType(BO.SectionItem))
                InformationToolStripMenuItem.Enabled = SelectedAdvNode.TagType.Equals(GetType(BO.Section)) _
                                                      Or SelectedAdvNode.TagType.BaseType.Equals(GetType(BO.SectionItem))
                VariableToolStripMenuItem.Enabled = Not SelectedAdvNode.TagType.BaseType.Equals(GetType(BO.SectionItem))

            End If

        End If

    End Sub

#End Region


End Class

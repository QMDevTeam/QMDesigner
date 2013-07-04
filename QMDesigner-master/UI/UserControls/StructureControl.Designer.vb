<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StructureControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StructureControl))
        Me.ContextMenuStripTree = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddQuestionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AddCheckpointToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AddVariableToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AddInformationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AddSectionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AddQuestionnaireToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AddQuestionnaireSetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.CollapseAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExpandAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CopyWithChildrenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.IncreaseIndentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DecreaseIndentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ImageListTreeViewIcons = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton
        Me.QuestionnaireSetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.QuestionnarieToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SectionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.QuestionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CheckpointToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.InformationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.VariableToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
        Me.RedoToolStripDropDownButton = New System.Windows.Forms.ToolStripDropDownButton
        Me.RedoToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.UndoToolStripDropDownButton = New System.Windows.Forms.ToolStripDropDownButton
        Me.UndoToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.uxOutline = New DevComponents.AdvTree.AdvTree
        Me.NodeConnector1 = New DevComponents.AdvTree.NodeConnector
        Me.DefaultStyle = New DevComponents.DotNetBar.ElementStyle
        Me.Required = New DevComponents.DotNetBar.ElementStyle
        Me.Variables = New DevComponents.DotNetBar.ElementStyle
        Me.Highlighted = New DevComponents.DotNetBar.ElementStyle
        Me.ContextMenuStripTree.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.uxOutline, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ContextMenuStripTree
        '
        Me.ContextMenuStripTree.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddQuestionToolStripMenuItem, Me.AddCheckpointToolStripMenuItem, Me.AddVariableToolStripMenuItem, Me.AddInformationToolStripMenuItem, Me.AddSectionToolStripMenuItem, Me.AddQuestionnaireToolStripMenuItem, Me.AddQuestionnaireSetToolStripMenuItem, Me.ToolStripSeparator1, Me.CollapseAllToolStripMenuItem, Me.ExpandAllToolStripMenuItem, Me.ToolStripSeparator4, Me.CopyToolStripMenuItem, Me.CopyWithChildrenToolStripMenuItem, Me.CutToolStripMenuItem, Me.PasteToolStripMenuItem, Me.ToolStripSeparator5, Me.DeleteToolStripMenuItem, Me.ToolStripSeparator2, Me.IncreaseIndentToolStripMenuItem, Me.DecreaseIndentToolStripMenuItem})
        Me.ContextMenuStripTree.Name = "ContextMenuStripQuestion"
        Me.ContextMenuStripTree.Size = New System.Drawing.Size(248, 380)
        '
        'AddQuestionToolStripMenuItem
        '
        Me.AddQuestionToolStripMenuItem.Name = "AddQuestionToolStripMenuItem"
        Me.AddQuestionToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
        Me.AddQuestionToolStripMenuItem.Text = "Add Question"
        '
        'AddCheckpointToolStripMenuItem
        '
        Me.AddCheckpointToolStripMenuItem.Name = "AddCheckpointToolStripMenuItem"
        Me.AddCheckpointToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
        Me.AddCheckpointToolStripMenuItem.Text = "Add Checkpoint"
        '
        'AddVariableToolStripMenuItem
        '
        Me.AddVariableToolStripMenuItem.Name = "AddVariableToolStripMenuItem"
        Me.AddVariableToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
        Me.AddVariableToolStripMenuItem.Text = "Add Variable"
        '
        'AddInformationToolStripMenuItem
        '
        Me.AddInformationToolStripMenuItem.Name = "AddInformationToolStripMenuItem"
        Me.AddInformationToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
        Me.AddInformationToolStripMenuItem.Text = "Add Information"
        '
        'AddSectionToolStripMenuItem
        '
        Me.AddSectionToolStripMenuItem.Name = "AddSectionToolStripMenuItem"
        Me.AddSectionToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
        Me.AddSectionToolStripMenuItem.Text = "Add Section"
        '
        'AddQuestionnaireToolStripMenuItem
        '
        Me.AddQuestionnaireToolStripMenuItem.Name = "AddQuestionnaireToolStripMenuItem"
        Me.AddQuestionnaireToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
        Me.AddQuestionnaireToolStripMenuItem.Text = "Add Questionnaire"
        '
        'AddQuestionnaireSetToolStripMenuItem
        '
        Me.AddQuestionnaireSetToolStripMenuItem.Name = "AddQuestionnaireSetToolStripMenuItem"
        Me.AddQuestionnaireSetToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
        Me.AddQuestionnaireSetToolStripMenuItem.Text = "Add Questionnaire Set"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(244, 6)
        '
        'CollapseAllToolStripMenuItem
        '
        Me.CollapseAllToolStripMenuItem.Name = "CollapseAllToolStripMenuItem"
        Me.CollapseAllToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
        Me.CollapseAllToolStripMenuItem.Text = "Collapse All"
        '
        'ExpandAllToolStripMenuItem
        '
        Me.ExpandAllToolStripMenuItem.Name = "ExpandAllToolStripMenuItem"
        Me.ExpandAllToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
        Me.ExpandAllToolStripMenuItem.Text = "Expand All"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(244, 6)
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Image = Global.UI.My.Resources.Resources.page_copy
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
        Me.CopyToolStripMenuItem.Text = "Copy"
        '
        'CopyWithChildrenToolStripMenuItem
        '
        Me.CopyWithChildrenToolStripMenuItem.Image = Global.UI.My.Resources.Resources.page_2_copy
        Me.CopyWithChildrenToolStripMenuItem.Name = "CopyWithChildrenToolStripMenuItem"
        Me.CopyWithChildrenToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
                    Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.CopyWithChildrenToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
        Me.CopyWithChildrenToolStripMenuItem.Text = "Copy with children"
        '
        'CutToolStripMenuItem
        '
        Me.CutToolStripMenuItem.Image = Global.UI.My.Resources.Resources.cut
        Me.CutToolStripMenuItem.Name = "CutToolStripMenuItem"
        Me.CutToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.CutToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
        Me.CutToolStripMenuItem.Text = "Cut"
        '
        'PasteToolStripMenuItem
        '
        Me.PasteToolStripMenuItem.Image = Global.UI.My.Resources.Resources.page_paste
        Me.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem"
        Me.PasteToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.PasteToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
        Me.PasteToolStripMenuItem.Text = "Paste"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(244, 6)
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Image = Global.UI.My.Resources.Resources.Delete
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(244, 6)
        '
        'IncreaseIndentToolStripMenuItem
        '
        Me.IncreaseIndentToolStripMenuItem.Image = Global.UI.My.Resources.Resources.increase_indent
        Me.IncreaseIndentToolStripMenuItem.Name = "IncreaseIndentToolStripMenuItem"
        Me.IncreaseIndentToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
                    Or System.Windows.Forms.Keys.Right), System.Windows.Forms.Keys)
        Me.IncreaseIndentToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
        Me.IncreaseIndentToolStripMenuItem.Text = "Increase indent"
        '
        'DecreaseIndentToolStripMenuItem
        '
        Me.DecreaseIndentToolStripMenuItem.Image = Global.UI.My.Resources.Resources.decrease_indent
        Me.DecreaseIndentToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White
        Me.DecreaseIndentToolStripMenuItem.Name = "DecreaseIndentToolStripMenuItem"
        Me.DecreaseIndentToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
                    Or System.Windows.Forms.Keys.Left), System.Windows.Forms.Keys)
        Me.DecreaseIndentToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
        Me.DecreaseIndentToolStripMenuItem.Text = "Decrease indent"
        '
        'ImageListTreeViewIcons
        '
        Me.ImageListTreeViewIcons.ImageStream = CType(resources.GetObject("ImageListTreeViewIcons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageListTreeViewIcons.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageListTreeViewIcons.Images.SetKeyName(0, "_Study")
        Me.ImageListTreeViewIcons.Images.SetKeyName(1, "_Section")
        Me.ImageListTreeViewIcons.Images.SetKeyName(2, "_Checkpoint")
        Me.ImageListTreeViewIcons.Images.SetKeyName(3, "_Question")
        Me.ImageListTreeViewIcons.Images.SetKeyName(4, "_Information")
        Me.ImageListTreeViewIcons.Images.SetKeyName(5, "Subject")
        Me.ImageListTreeViewIcons.Images.SetKeyName(6, "_QuestionnaireSet")
        Me.ImageListTreeViewIcons.Images.SetKeyName(7, "_Questionnaire")
        Me.ImageListTreeViewIcons.Images.SetKeyName(8, "_Variables")
        Me.ImageListTreeViewIcons.Images.SetKeyName(9, "_Variable")
        Me.ImageListTreeViewIcons.Images.SetKeyName(10, "_QuestionnaireLoop")
        Me.ImageListTreeViewIcons.Images.SetKeyName(11, "QuestionnaireSet")
        Me.ImageListTreeViewIcons.Images.SetKeyName(12, "Questionnaire")
        Me.ImageListTreeViewIcons.Images.SetKeyName(13, "Section")
        Me.ImageListTreeViewIcons.Images.SetKeyName(14, "Variables")
        Me.ImageListTreeViewIcons.Images.SetKeyName(15, "Variable")
        Me.ImageListTreeViewIcons.Images.SetKeyName(16, "Question")
        Me.ImageListTreeViewIcons.Images.SetKeyName(17, "QuestionnaireLoop")
        Me.ImageListTreeViewIcons.Images.SetKeyName(18, "Checkpoint")
        Me.ImageListTreeViewIcons.Images.SetKeyName(19, "Study")
        Me.ImageListTreeViewIcons.Images.SetKeyName(20, "Information")
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripDropDownButton1, Me.ToolStripButton1, Me.ToolStripSeparator3, Me.ToolStripButton2, Me.ToolStripButton3, Me.ToolStripSeparator6, Me.RedoToolStripDropDownButton, Me.RedoToolStripButton, Me.UndoToolStripDropDownButton, Me.UndoToolStripButton})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(245, 25)
        Me.ToolStrip1.TabIndex = 7
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.QuestionnaireSetToolStripMenuItem, Me.QuestionnarieToolStripMenuItem, Me.SectionToolStripMenuItem, Me.QuestionToolStripMenuItem, Me.CheckpointToolStripMenuItem, Me.InformationToolStripMenuItem, Me.VariableToolStripMenuItem})
        Me.ToolStripDropDownButton1.Image = Global.UI.My.Resources.Resources.Add
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(29, 22)
        Me.ToolStripDropDownButton1.Text = "Add an item to the tree"
        '
        'QuestionnaireSetToolStripMenuItem
        '
        Me.QuestionnaireSetToolStripMenuItem.Name = "QuestionnaireSetToolStripMenuItem"
        Me.QuestionnaireSetToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.QuestionnaireSetToolStripMenuItem.Text = "Questionnaire Set"
        '
        'QuestionnarieToolStripMenuItem
        '
        Me.QuestionnarieToolStripMenuItem.Name = "QuestionnarieToolStripMenuItem"
        Me.QuestionnarieToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.QuestionnarieToolStripMenuItem.Text = "Questionnarie"
        '
        'SectionToolStripMenuItem
        '
        Me.SectionToolStripMenuItem.Name = "SectionToolStripMenuItem"
        Me.SectionToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.SectionToolStripMenuItem.Text = "Section"
        '
        'QuestionToolStripMenuItem
        '
        Me.QuestionToolStripMenuItem.Name = "QuestionToolStripMenuItem"
        Me.QuestionToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.QuestionToolStripMenuItem.Text = "Question"
        '
        'CheckpointToolStripMenuItem
        '
        Me.CheckpointToolStripMenuItem.Name = "CheckpointToolStripMenuItem"
        Me.CheckpointToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.CheckpointToolStripMenuItem.Text = "Checkpoint"
        '
        'InformationToolStripMenuItem
        '
        Me.InformationToolStripMenuItem.Name = "InformationToolStripMenuItem"
        Me.InformationToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.InformationToolStripMenuItem.Text = "Information"
        '
        'VariableToolStripMenuItem
        '
        Me.VariableToolStripMenuItem.Name = "VariableToolStripMenuItem"
        Me.VariableToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.VariableToolStripMenuItem.Text = "Variable"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = Global.UI.My.Resources.Resources.Delete
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "Delete selected item"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = Global.UI.My.Resources.Resources.Refresh
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton2.Text = "Reload the tree"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Image = Global.UI.My.Resources.Resources.Preview
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.White
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton3.Text = "Preview"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'RedoToolStripDropDownButton
        '
        Me.RedoToolStripDropDownButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.RedoToolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None
        Me.RedoToolStripDropDownButton.Image = CType(resources.GetObject("RedoToolStripDropDownButton.Image"), System.Drawing.Image)
        Me.RedoToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.RedoToolStripDropDownButton.Name = "RedoToolStripDropDownButton"
        Me.RedoToolStripDropDownButton.Size = New System.Drawing.Size(13, 22)
        Me.RedoToolStripDropDownButton.Text = "ToolStripDropDownButton2"
        '
        'RedoToolStripButton
        '
        Me.RedoToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.RedoToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.RedoToolStripButton.Image = Global.UI.My.Resources.Resources.Redo
        Me.RedoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.RedoToolStripButton.Name = "RedoToolStripButton"
        Me.RedoToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.RedoToolStripButton.Text = "ToolStripButton5"
        '
        'UndoToolStripDropDownButton
        '
        Me.UndoToolStripDropDownButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.UndoToolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None
        Me.UndoToolStripDropDownButton.Image = CType(resources.GetObject("UndoToolStripDropDownButton.Image"), System.Drawing.Image)
        Me.UndoToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.UndoToolStripDropDownButton.Name = "UndoToolStripDropDownButton"
        Me.UndoToolStripDropDownButton.Size = New System.Drawing.Size(13, 22)
        Me.UndoToolStripDropDownButton.Text = "ToolStripDropDownButton2"
        '
        'UndoToolStripButton
        '
        Me.UndoToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.UndoToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.UndoToolStripButton.Image = Global.UI.My.Resources.Resources.Undo
        Me.UndoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.UndoToolStripButton.Name = "UndoToolStripButton"
        Me.UndoToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.UndoToolStripButton.Text = "ToolStripButton4"
        '
        'uxOutline
        '
        Me.uxOutline.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline
        Me.uxOutline.AllowDrop = True
        Me.uxOutline.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.uxOutline.BackgroundStyle.Class = "TreeBorderKey"
        Me.uxOutline.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.uxOutline.ContextMenuStrip = Me.ContextMenuStripTree
        Me.uxOutline.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uxOutline.DragDropNodeCopyEnabled = False
        Me.uxOutline.DropAsChildOffset = 100
        Me.uxOutline.ImageList = Me.ImageListTreeViewIcons
        Me.uxOutline.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.uxOutline.Location = New System.Drawing.Point(0, 25)
        Me.uxOutline.MultiSelect = True
        Me.uxOutline.Name = "uxOutline"
        Me.uxOutline.NodesConnector = Me.NodeConnector1
        Me.uxOutline.NodeStyle = Me.DefaultStyle
        Me.uxOutline.PathSeparator = ";"
        Me.uxOutline.Size = New System.Drawing.Size(245, 437)
        Me.uxOutline.Styles.Add(Me.DefaultStyle)
        Me.uxOutline.Styles.Add(Me.Required)
        Me.uxOutline.Styles.Add(Me.Variables)
        Me.uxOutline.Styles.Add(Me.Highlighted)
        Me.uxOutline.TabIndex = 8
        Me.uxOutline.Text = "uxOutline"
        '
        'NodeConnector1
        '
        Me.NodeConnector1.LineColor = System.Drawing.SystemColors.ControlText
        '
        'DefaultStyle
        '
        Me.DefaultStyle.Class = ""
        Me.DefaultStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DefaultStyle.Name = "DefaultStyle"
        Me.DefaultStyle.TextColor = System.Drawing.SystemColors.ControlText
        '
        'Required
        '
        Me.Required.Class = ""
        Me.Required.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Required.Name = "Required"
        Me.Required.TextColor = System.Drawing.Color.Red
        '
        'Variables
        '
        Me.Variables.Class = ""
        Me.Variables.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Variables.Name = "Variables"
        Me.Variables.TextColor = System.Drawing.Color.DarkGray
        '
        'Highlighted
        '
        Me.Highlighted.BackColor = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Highlighted.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.DockSiteBackColor2
        Me.Highlighted.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Highlighted.BorderBottomWidth = 1
        Me.Highlighted.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Highlighted.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Highlighted.BorderLeftWidth = 1
        Me.Highlighted.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Highlighted.BorderRightWidth = 1
        Me.Highlighted.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Highlighted.BorderTopWidth = 1
        Me.Highlighted.Class = ""
        Me.Highlighted.CornerDiameter = 3
        Me.Highlighted.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Highlighted.Name = "Highlighted"
        Me.Highlighted.TextColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(0, Byte), Integer))
        '
        'StructureControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.uxOutline)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "StructureControl"
        Me.Size = New System.Drawing.Size(245, 462)
        Me.ContextMenuStripTree.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.uxOutline, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ImageListTreeViewIcons As System.Windows.Forms.ImageList
    Friend WithEvents ContextMenuStripTree As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PasteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddQuestionnaireToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddSectionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddQuestionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddCheckpointToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CollapseAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExpandAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddQuestionnaireSetToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddInformationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents QuestionnaireSetToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents QuestionnarieToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SectionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents QuestionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CheckpointToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InformationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents AddVariableToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VariableToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents uxOutline As DevComponents.AdvTree.AdvTree
    Friend WithEvents NodeConnector1 As DevComponents.AdvTree.NodeConnector
    Friend WithEvents DefaultStyle As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents Required As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents Variables As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents CopyWithChildrenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents IncreaseIndentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DecreaseIndentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Highlighted As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RedoToolStripDropDownButton As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents RedoToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents UndoToolStripDropDownButton As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents UndoToolStripButton As System.Windows.Forms.ToolStripButton

End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StructureControl2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StructureControl2))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolButtonExecuteQuery = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripSplitButton1 = New System.Windows.Forms.ToolStripSplitButton
        Me.SelectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeselectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.uxToolStripComboBoxQuestionnaireSet = New System.Windows.Forms.ToolStripComboBox
        Me.uxToolTipLegalValues = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip
        Me.ToolStripSplitButton2 = New System.Windows.Forms.ToolStripSplitButton
        Me.uxSelectAllVariablesToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.uxUnselectAllVariablesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSplitButton3 = New System.Windows.Forms.ToolStripSplitButton
        Me.uxSelectAllMetaDataToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.uxUnselectAllMetaDataToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.uxOutline = New DevComponents.AdvTree.AdvTree
        Me.NodeConnector1 = New DevComponents.AdvTree.NodeConnector
        Me.DefaultStyle = New DevComponents.DotNetBar.ElementStyle
        Me.Required = New DevComponents.DotNetBar.ElementStyle
        Me.Variables = New DevComponents.DotNetBar.ElementStyle
        Me.ToolStrip1.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        CType(Me.uxOutline, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolButtonExecuteQuery, Me.ToolStripButton1, Me.ToolStripSeparator1, Me.ToolStripSplitButton1, Me.uxToolStripComboBoxQuestionnaireSet})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(311, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolButtonExecuteQuery
        '
        Me.ToolButtonExecuteQuery.Image = CType(resources.GetObject("ToolButtonExecuteQuery.Image"), System.Drawing.Image)
        Me.ToolButtonExecuteQuery.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolButtonExecuteQuery.Name = "ToolButtonExecuteQuery"
        Me.ToolButtonExecuteQuery.Size = New System.Drawing.Size(66, 22)
        Me.ToolButtonExecuteQuery.Text = "Execute"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "Clear Query"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSplitButton1
        '
        Me.ToolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripSplitButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SelectAllToolStripMenuItem, Me.DeselectAllToolStripMenuItem})
        Me.ToolStripSplitButton1.Image = Global.DataManager.My.Resources.Resources.iconCheckbox
        Me.ToolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSplitButton1.Name = "ToolStripSplitButton1"
        Me.ToolStripSplitButton1.Size = New System.Drawing.Size(32, 22)
        Me.ToolStripSplitButton1.Text = "Select All"
        '
        'SelectAllToolStripMenuItem
        '
        Me.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem"
        Me.SelectAllToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.SelectAllToolStripMenuItem.Text = "Select All"
        '
        'DeselectAllToolStripMenuItem
        '
        Me.DeselectAllToolStripMenuItem.Name = "DeselectAllToolStripMenuItem"
        Me.DeselectAllToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.DeselectAllToolStripMenuItem.Text = "Deselect All"
        '
        'uxToolStripComboBoxQuestionnaireSet
        '
        Me.uxToolStripComboBoxQuestionnaireSet.Name = "uxToolStripComboBoxQuestionnaireSet"
        Me.uxToolStripComboBoxQuestionnaireSet.Size = New System.Drawing.Size(121, 25)
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSplitButton2, Me.ToolStripSplitButton3})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 25)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(311, 25)
        Me.ToolStrip2.Stretch = True
        Me.ToolStrip2.TabIndex = 2
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'ToolStripSplitButton2
        '
        Me.ToolStripSplitButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripSplitButton2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.uxSelectAllVariablesToolStripMenuItem1, Me.uxUnselectAllVariablesToolStripMenuItem})
        Me.ToolStripSplitButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSplitButton2.Name = "ToolStripSplitButton2"
        Me.ToolStripSplitButton2.Size = New System.Drawing.Size(66, 22)
        Me.ToolStripSplitButton2.Text = "Variables"
        '
        'uxSelectAllVariablesToolStripMenuItem1
        '
        Me.uxSelectAllVariablesToolStripMenuItem1.Name = "uxSelectAllVariablesToolStripMenuItem1"
        Me.uxSelectAllVariablesToolStripMenuItem1.Size = New System.Drawing.Size(140, 22)
        Me.uxSelectAllVariablesToolStripMenuItem1.Text = "Select All"
        '
        'uxUnselectAllVariablesToolStripMenuItem
        '
        Me.uxUnselectAllVariablesToolStripMenuItem.Name = "uxUnselectAllVariablesToolStripMenuItem"
        Me.uxUnselectAllVariablesToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.uxUnselectAllVariablesToolStripMenuItem.Text = "Unselect All"
        '
        'ToolStripSplitButton3
        '
        Me.ToolStripSplitButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripSplitButton3.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.uxSelectAllMetaDataToolStripMenuItem2, Me.uxUnselectAllMetaDataToolStripMenuItem1})
        Me.ToolStripSplitButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSplitButton3.Name = "ToolStripSplitButton3"
        Me.ToolStripSplitButton3.Size = New System.Drawing.Size(69, 22)
        Me.ToolStripSplitButton3.Text = "Metadata"
        '
        'uxSelectAllMetaDataToolStripMenuItem2
        '
        Me.uxSelectAllMetaDataToolStripMenuItem2.Name = "uxSelectAllMetaDataToolStripMenuItem2"
        Me.uxSelectAllMetaDataToolStripMenuItem2.Size = New System.Drawing.Size(140, 22)
        Me.uxSelectAllMetaDataToolStripMenuItem2.Text = "Select All"
        '
        'uxUnselectAllMetaDataToolStripMenuItem1
        '
        Me.uxUnselectAllMetaDataToolStripMenuItem1.Name = "uxUnselectAllMetaDataToolStripMenuItem1"
        Me.uxUnselectAllMetaDataToolStripMenuItem1.Size = New System.Drawing.Size(140, 22)
        Me.uxUnselectAllMetaDataToolStripMenuItem1.Text = "Unselect All"
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
        Me.uxOutline.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uxOutline.DragDropNodeCopyEnabled = False
        Me.uxOutline.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.uxOutline.Location = New System.Drawing.Point(0, 50)
        Me.uxOutline.Name = "uxOutline"
        Me.uxOutline.NodesConnector = Me.NodeConnector1
        Me.uxOutline.NodeStyle = Me.DefaultStyle
        Me.uxOutline.PathSeparator = ";"
        Me.uxOutline.Size = New System.Drawing.Size(311, 401)
        Me.uxOutline.Styles.Add(Me.DefaultStyle)
        Me.uxOutline.Styles.Add(Me.Required)
        Me.uxOutline.Styles.Add(Me.Variables)
        Me.uxOutline.TabIndex = 3
        Me.uxOutline.Text = "AdvTree1"
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
        Me.Variables.TextColor = System.Drawing.SystemColors.InactiveCaptionText
        '
        'StructureControl2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.uxOutline)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "StructureControl2"
        Me.Size = New System.Drawing.Size(311, 451)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        CType(Me.uxOutline, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSplitButton1 As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents SelectAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeselectAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents uxToolStripComboBoxQuestionnaireSet As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolButtonExecuteQuery As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents uxToolTipLegalValues As System.Windows.Forms.ToolTip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSplitButton2 As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents ToolStripSplitButton3 As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents uxSelectAllVariablesToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents uxUnselectAllVariablesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents uxSelectAllMetaDataToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents uxUnselectAllMetaDataToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NodeConnector1 As DevComponents.AdvTree.NodeConnector
    Friend WithEvents DefaultStyle As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents Required As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents Variables As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents uxOutline As DevComponents.AdvTree.AdvTree

End Class

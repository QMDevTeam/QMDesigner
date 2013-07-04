<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListEditorFrm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.uxListBox = New DevComponents.AdvTree.AdvTree
        Me.NodeConnector1 = New DevComponents.AdvTree.NodeConnector
        Me.DefaultStyle = New DevComponents.DotNetBar.ElementStyle
        Me.DimmedStyle = New DevComponents.DotNetBar.ElementStyle
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripTextBox1 = New System.Windows.Forms.ToolStripTextBox
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton
        Me.AdvPropertyGrid1 = New DevComponents.DotNetBar.AdvPropertyGrid
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.uxListBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.AdvPropertyGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.uxListBox)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ToolStrip1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.AdvPropertyGrid1)
        Me.SplitContainer1.Size = New System.Drawing.Size(558, 264)
        Me.SplitContainer1.SplitterDistance = 271
        Me.SplitContainer1.TabIndex = 0
        '
        'uxListBox
        '
        Me.uxListBox.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline
        Me.uxListBox.AllowDrop = True
        Me.uxListBox.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.uxListBox.BackgroundStyle.Class = "TreeBorderKey"
        Me.uxListBox.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.uxListBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uxListBox.DragDropNodeCopyEnabled = False
        Me.uxListBox.DropAsChildOffset = 10000
        Me.uxListBox.ExpandWidth = 5
        Me.uxListBox.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.uxListBox.Location = New System.Drawing.Point(0, 25)
        Me.uxListBox.MultiNodeDragDropAllowed = False
        Me.uxListBox.Name = "uxListBox"
        Me.uxListBox.NodesConnector = Me.NodeConnector1
        Me.uxListBox.NodeStyle = Me.DefaultStyle
        Me.uxListBox.PathSeparator = ";"
        Me.uxListBox.Size = New System.Drawing.Size(271, 239)
        Me.uxListBox.Styles.Add(Me.DefaultStyle)
        Me.uxListBox.Styles.Add(Me.DimmedStyle)
        Me.uxListBox.TabIndex = 1
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
        'DimmedStyle
        '
        Me.DimmedStyle.Class = ""
        Me.DimmedStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DimmedStyle.Name = "DimmedStyle"
        Me.DimmedStyle.TextColor = System.Drawing.SystemColors.ControlDark
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripTextBox1, Me.ToolStripButton3, Me.ToolStripSeparator1, Me.ToolStripButton1, Me.ToolStripButton2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(271, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripTextBox1
        '
        Me.ToolStripTextBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.ToolStripTextBox1.Name = "ToolStripTextBox1"
        Me.ToolStripTextBox1.Size = New System.Drawing.Size(120, 25)
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Image = Global.BO.My.Resources.Resources.search_icon
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.White
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton3.Text = "Search"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = Global.BO.My.Resources.Resources.Add
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "Add new legal value"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = Global.BO.My.Resources.Resources.Delete
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton2.Text = "Remove selected"
        '
        'AdvPropertyGrid1
        '
        Me.AdvPropertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AdvPropertyGrid1.GridLinesColor = System.Drawing.Color.WhiteSmoke
        Me.AdvPropertyGrid1.Location = New System.Drawing.Point(0, 0)
        Me.AdvPropertyGrid1.Name = "AdvPropertyGrid1"
        Me.AdvPropertyGrid1.Size = New System.Drawing.Size(283, 264)
        Me.AdvPropertyGrid1.TabIndex = 1
        Me.AdvPropertyGrid1.Text = "AdvPropertyGrid1"
        '
        'ListEditorFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(558, 264)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "ListEditorFrm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "LegalValueEditor"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.uxListBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.AdvPropertyGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripTextBox1 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents uxListBox As DevComponents.AdvTree.AdvTree
    Friend WithEvents NodeConnector1 As DevComponents.AdvTree.NodeConnector
    Friend WithEvents DefaultStyle As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents DimmedStyle As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents AdvPropertyGrid1 As DevComponents.DotNetBar.AdvPropertyGrid
End Class

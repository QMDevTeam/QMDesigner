<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReviewChangesDialog
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
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.OK_Button = New System.Windows.Forms.Button
        Me.uxChangesDataGridView = New DevComponents.DotNetBar.Controls.DataGridViewX
        Me.uxAcceptColumn = New DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn
        Me.uxSubjectID = New DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn
        Me.uxSubjectQuestionnaireInstanceIDDataColumn = New DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn
        Me.uxTableNameDataColumn = New DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn
        Me.uxColumnNameDataColumn = New DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn
        Me.uxOldValueDataColumn = New DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn
        Me.uxNewValueDataColumn = New DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn
        Me.uxCommentDataColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.uxReviewDataSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReviewDataSet = New DataManager.ReviewDataSet
        Me.StyleManager1 = New DevComponents.DotNetBar.StyleManager(Me.components)
        Me.ckbUn_SelectAll = New DevComponents.DotNetBar.Controls.CheckBoxX
        Me.rbtCommentSelected = New System.Windows.Forms.RadioButton
        Me.rbtCommentOneByOne = New System.Windows.Forms.RadioButton
        Me.txtComment = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.uxChangesDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uxReviewDataSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReviewDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(728, 593)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(226, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.Location = New System.Drawing.Point(136, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(6, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(100, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "Accept Changes"
        '
        'uxChangesDataGridView
        '
        Me.uxChangesDataGridView.AllowUserToAddRows = False
        Me.uxChangesDataGridView.AllowUserToDeleteRows = False
        Me.uxChangesDataGridView.AllowUserToOrderColumns = True
        Me.uxChangesDataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.uxChangesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.uxChangesDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.uxAcceptColumn, Me.uxSubjectID, Me.uxSubjectQuestionnaireInstanceIDDataColumn, Me.uxTableNameDataColumn, Me.uxColumnNameDataColumn, Me.uxOldValueDataColumn, Me.uxNewValueDataColumn, Me.uxCommentDataColumn})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.uxChangesDataGridView.DefaultCellStyle = DataGridViewCellStyle1
        Me.uxChangesDataGridView.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.uxChangesDataGridView.Location = New System.Drawing.Point(12, 66)
        Me.uxChangesDataGridView.Name = "uxChangesDataGridView"
        Me.uxChangesDataGridView.Size = New System.Drawing.Size(939, 521)
        Me.uxChangesDataGridView.TabIndex = 1
        '
        'uxAcceptColumn
        '
        Me.uxAcceptColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.uxAcceptColumn.Checked = False
        Me.uxAcceptColumn.CheckState = System.Windows.Forms.CheckState.Unchecked
        Me.uxAcceptColumn.CheckValue = "N"
        Me.uxAcceptColumn.DataPropertyName = "Accept"
        Me.uxAcceptColumn.HeaderText = ""
        Me.uxAcceptColumn.MinimumWidth = 25
        Me.uxAcceptColumn.Name = "uxAcceptColumn"
        Me.uxAcceptColumn.Width = 25
        '
        'uxSubjectID
        '
        Me.uxSubjectID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.uxSubjectID.DataPropertyName = "SubjectID"
        Me.uxSubjectID.HeaderText = "SubjectID"
        Me.uxSubjectID.Name = "uxSubjectID"
        Me.uxSubjectID.ReadOnly = True
        Me.uxSubjectID.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.uxSubjectID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.uxSubjectID.Width = 79
        '
        'uxSubjectQuestionnaireInstanceIDDataColumn
        '
        Me.uxSubjectQuestionnaireInstanceIDDataColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.uxSubjectQuestionnaireInstanceIDDataColumn.DataPropertyName = "SubjectQuestionnaireInstanceID"
        Me.uxSubjectQuestionnaireInstanceIDDataColumn.HeaderText = "SubjectQuestionnaireInstanceID"
        Me.uxSubjectQuestionnaireInstanceIDDataColumn.Name = "uxSubjectQuestionnaireInstanceIDDataColumn"
        Me.uxSubjectQuestionnaireInstanceIDDataColumn.ReadOnly = True
        Me.uxSubjectQuestionnaireInstanceIDDataColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.uxSubjectQuestionnaireInstanceIDDataColumn.Width = 185
        '
        'uxTableNameDataColumn
        '
        Me.uxTableNameDataColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.uxTableNameDataColumn.DataPropertyName = "TableName"
        Me.uxTableNameDataColumn.HeaderText = "Table Name"
        Me.uxTableNameDataColumn.Name = "uxTableNameDataColumn"
        Me.uxTableNameDataColumn.ReadOnly = True
        Me.uxTableNameDataColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.uxTableNameDataColumn.Width = 90
        '
        'uxColumnNameDataColumn
        '
        Me.uxColumnNameDataColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.uxColumnNameDataColumn.DataPropertyName = "ColumnName"
        Me.uxColumnNameDataColumn.HeaderText = "Column Name"
        Me.uxColumnNameDataColumn.Name = "uxColumnNameDataColumn"
        Me.uxColumnNameDataColumn.ReadOnly = True
        Me.uxColumnNameDataColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.uxColumnNameDataColumn.Width = 98
        '
        'uxOldValueDataColumn
        '
        Me.uxOldValueDataColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.uxOldValueDataColumn.DataPropertyName = "OldValue"
        Me.uxOldValueDataColumn.HeaderText = "Old Value"
        Me.uxOldValueDataColumn.Name = "uxOldValueDataColumn"
        Me.uxOldValueDataColumn.ReadOnly = True
        Me.uxOldValueDataColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.uxOldValueDataColumn.Width = 78
        '
        'uxNewValueDataColumn
        '
        Me.uxNewValueDataColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.uxNewValueDataColumn.DataPropertyName = "NewValue"
        Me.uxNewValueDataColumn.HeaderText = "New Value"
        Me.uxNewValueDataColumn.Name = "uxNewValueDataColumn"
        Me.uxNewValueDataColumn.ReadOnly = True
        Me.uxNewValueDataColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.uxNewValueDataColumn.Width = 84
        '
        'uxCommentDataColumn
        '
        Me.uxCommentDataColumn.DataPropertyName = "Comment"
        Me.uxCommentDataColumn.HeaderText = "Comments"
        Me.uxCommentDataColumn.Name = "uxCommentDataColumn"
        Me.uxCommentDataColumn.Width = 200
        '
        'uxReviewDataSource
        '
        Me.uxReviewDataSource.DataMember = "Review"
        Me.uxReviewDataSource.DataSource = Me.ReviewDataSet
        '
        'ReviewDataSet
        '
        Me.ReviewDataSet.DataSetName = "ReviewDataSet"
        Me.ReviewDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'StyleManager1
        '
        Me.StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Silver
        '
        'ckbUn_SelectAll
        '
        '
        '
        '
        Me.ckbUn_SelectAll.BackgroundStyle.Class = ""
        Me.ckbUn_SelectAll.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ckbUn_SelectAll.Checked = True
        Me.ckbUn_SelectAll.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckbUn_SelectAll.CheckValue = "Y"
        Me.ckbUn_SelectAll.Location = New System.Drawing.Point(56, 37)
        Me.ckbUn_SelectAll.Name = "ckbUn_SelectAll"
        Me.ckbUn_SelectAll.Size = New System.Drawing.Size(100, 23)
        Me.ckbUn_SelectAll.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ckbUn_SelectAll.TabIndex = 2
        Me.ckbUn_SelectAll.Text = "Un/Select All"
        '
        'rbtCommentSelected
        '
        Me.rbtCommentSelected.AutoSize = True
        Me.rbtCommentSelected.Checked = True
        Me.rbtCommentSelected.Location = New System.Drawing.Point(222, 13)
        Me.rbtCommentSelected.Name = "rbtCommentSelected"
        Me.rbtCommentSelected.Size = New System.Drawing.Size(174, 17)
        Me.rbtCommentSelected.TabIndex = 4
        Me.rbtCommentSelected.TabStop = True
        Me.rbtCommentSelected.Text = "Comment the selected changes"
        Me.rbtCommentSelected.UseVisualStyleBackColor = True
        '
        'rbtCommentOneByOne
        '
        Me.rbtCommentOneByOne.AutoSize = True
        Me.rbtCommentOneByOne.Location = New System.Drawing.Point(222, 37)
        Me.rbtCommentOneByOne.Name = "rbtCommentOneByOne"
        Me.rbtCommentOneByOne.Size = New System.Drawing.Size(125, 17)
        Me.rbtCommentOneByOne.TabIndex = 5
        Me.rbtCommentOneByOne.Text = "Comment one by one"
        Me.rbtCommentOneByOne.UseVisualStyleBackColor = True
        '
        'txtComment
        '
        '
        '
        '
        Me.txtComment.Border.Class = "TextBoxBorder"
        Me.txtComment.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtComment.Location = New System.Drawing.Point(409, 13)
        Me.txtComment.Name = "txtComment"
        Me.txtComment.Size = New System.Drawing.Size(467, 20)
        Me.txtComment.TabIndex = 6
        '
        'ReviewChangesDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(966, 634)
        Me.Controls.Add(Me.txtComment)
        Me.Controls.Add(Me.rbtCommentOneByOne)
        Me.Controls.Add(Me.rbtCommentSelected)
        Me.Controls.Add(Me.ckbUn_SelectAll)
        Me.Controls.Add(Me.uxChangesDataGridView)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ReviewChangesDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Reveiw Changes"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.uxChangesDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uxReviewDataSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReviewDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents uxChangesDataGridView As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents StyleManager1 As DevComponents.DotNetBar.StyleManager
    Friend WithEvents uxReviewDataSource As System.Windows.Forms.BindingSource
    Friend WithEvents ckbUn_SelectAll As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents ReviewDataSet As DataManager.ReviewDataSet
    Friend WithEvents rbtCommentSelected As System.Windows.Forms.RadioButton
    Friend WithEvents rbtCommentOneByOne As System.Windows.Forms.RadioButton
    Friend WithEvents txtComment As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents uxAcceptColumn As DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn
    Friend WithEvents uxSubjectID As DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn
    Friend WithEvents uxSubjectQuestionnaireInstanceIDDataColumn As DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn
    Friend WithEvents uxTableNameDataColumn As DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn
    Friend WithEvents uxColumnNameDataColumn As DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn
    Friend WithEvents uxOldValueDataColumn As DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn
    Friend WithEvents uxNewValueDataColumn As DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn
    Friend WithEvents uxCommentDataColumn As System.Windows.Forms.DataGridViewTextBoxColumn

End Class

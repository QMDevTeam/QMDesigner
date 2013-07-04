<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPropertyCheckpoint
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
        Me.components = New System.ComponentModel.Container()
        Me.GrbMain = New System.Windows.Forms.GroupBox()
        Me.BtnComment = New System.Windows.Forms.Button()
        Me.BtnName = New System.Windows.Forms.Button()
        Me.BtnMainText = New System.Windows.Forms.Button()
        Me.TxtComment = New System.Windows.Forms.TextBox()
        Me.TxtMainText = New System.Windows.Forms.TextBox()
        Me.TxtName = New System.Windows.Forms.TextBox()
        Me.LblComment = New System.Windows.Forms.Label()
        Me.LblMainText = New System.Windows.Forms.Label()
        Me.LblName = New System.Windows.Forms.Label()
        Me.GrbCheckpoint = New System.Windows.Forms.GroupBox()
        Me.CmbBranch = New System.Windows.Forms.ComboBox()
        Me.BtnCondition = New System.Windows.Forms.Button()
        Me.TxtCondition = New System.Windows.Forms.TextBox()
        Me.LblCondition = New System.Windows.Forms.Label()
        Me.LblBranchIf = New System.Windows.Forms.Label()
        Me.GrbSysInfo = New System.Windows.Forms.GroupBox()
        Me.LblUniqueID = New System.Windows.Forms.Label()
        Me.LblSectionID = New System.Windows.Forms.Label()
        Me.LblQuesSetID = New System.Windows.Forms.Label()
        Me.LblQuesID = New System.Windows.Forms.Label()
        Me.LblTitle4 = New System.Windows.Forms.Label()
        Me.LblTitle3 = New System.Windows.Forms.Label()
        Me.LblTitle2 = New System.Windows.Forms.Label()
        Me.LblTitle1 = New System.Windows.Forms.Label()
        Me.BtnGuardar = New System.Windows.Forms.Button()
        Me.BtnCancelar = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GrbMain.SuspendLayout()
        Me.GrbCheckpoint.SuspendLayout()
        Me.GrbSysInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrbMain
        '
        Me.GrbMain.Controls.Add(Me.BtnComment)
        Me.GrbMain.Controls.Add(Me.BtnName)
        Me.GrbMain.Controls.Add(Me.BtnMainText)
        Me.GrbMain.Controls.Add(Me.TxtComment)
        Me.GrbMain.Controls.Add(Me.TxtMainText)
        Me.GrbMain.Controls.Add(Me.TxtName)
        Me.GrbMain.Controls.Add(Me.LblComment)
        Me.GrbMain.Controls.Add(Me.LblMainText)
        Me.GrbMain.Controls.Add(Me.LblName)
        Me.GrbMain.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrbMain.Location = New System.Drawing.Point(12, 12)
        Me.GrbMain.Name = "GrbMain"
        Me.GrbMain.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GrbMain.Size = New System.Drawing.Size(318, 113)
        Me.GrbMain.TabIndex = 0
        Me.GrbMain.TabStop = False
        Me.GrbMain.Text = "MAIN"
        '
        'BtnComment
        '
        Me.BtnComment.Location = New System.Drawing.Point(248, 74)
        Me.BtnComment.Name = "BtnComment"
        Me.BtnComment.Size = New System.Drawing.Size(35, 23)
        Me.BtnComment.TabIndex = 8
        Me.BtnComment.Text = "..."
        Me.BtnComment.UseVisualStyleBackColor = True
        '
        'BtnName
        '
        Me.BtnName.Location = New System.Drawing.Point(248, 17)
        Me.BtnName.Name = "BtnName"
        Me.BtnName.Size = New System.Drawing.Size(35, 23)
        Me.BtnName.TabIndex = 6
        Me.BtnName.Text = "..."
        Me.BtnName.UseVisualStyleBackColor = True
        '
        'BtnMainText
        '
        Me.BtnMainText.Location = New System.Drawing.Point(248, 45)
        Me.BtnMainText.Name = "BtnMainText"
        Me.BtnMainText.Size = New System.Drawing.Size(35, 23)
        Me.BtnMainText.TabIndex = 7
        Me.BtnMainText.Text = "..."
        Me.BtnMainText.UseVisualStyleBackColor = True
        '
        'TxtComment
        '
        Me.TxtComment.Location = New System.Drawing.Point(100, 75)
        Me.TxtComment.Name = "TxtComment"
        Me.TxtComment.Size = New System.Drawing.Size(152, 23)
        Me.TxtComment.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.TxtComment, "Indicates the name of the object.")
        '
        'TxtMainText
        '
        Me.TxtMainText.Location = New System.Drawing.Point(100, 46)
        Me.TxtMainText.Name = "TxtMainText"
        Me.TxtMainText.Size = New System.Drawing.Size(152, 23)
        Me.TxtMainText.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.TxtMainText, "The question to be displayed.")
        '
        'TxtName
        '
        Me.TxtName.Location = New System.Drawing.Point(100, 17)
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(152, 23)
        Me.TxtName.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.TxtName, "Type a comment of the object.")
        '
        'LblComment
        '
        Me.LblComment.AutoSize = True
        Me.LblComment.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblComment.Location = New System.Drawing.Point(11, 79)
        Me.LblComment.Name = "LblComment"
        Me.LblComment.Size = New System.Drawing.Size(78, 19)
        Me.LblComment.TabIndex = 2
        Me.LblComment.Text = "Comment:"
        '
        'LblMainText
        '
        Me.LblMainText.AutoSize = True
        Me.LblMainText.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMainText.Location = New System.Drawing.Point(11, 50)
        Me.LblMainText.Name = "LblMainText"
        Me.LblMainText.Size = New System.Drawing.Size(84, 19)
        Me.LblMainText.TabIndex = 1
        Me.LblMainText.Text = "Main Text:"
        '
        'LblName
        '
        Me.LblName.AutoSize = True
        Me.LblName.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblName.Location = New System.Drawing.Point(11, 21)
        Me.LblName.Name = "LblName"
        Me.LblName.Size = New System.Drawing.Size(54, 19)
        Me.LblName.TabIndex = 0
        Me.LblName.Text = "Name:"
        '
        'GrbCheckpoint
        '
        Me.GrbCheckpoint.Controls.Add(Me.CmbBranch)
        Me.GrbCheckpoint.Controls.Add(Me.BtnCondition)
        Me.GrbCheckpoint.Controls.Add(Me.TxtCondition)
        Me.GrbCheckpoint.Controls.Add(Me.LblCondition)
        Me.GrbCheckpoint.Controls.Add(Me.LblBranchIf)
        Me.GrbCheckpoint.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrbCheckpoint.Location = New System.Drawing.Point(12, 140)
        Me.GrbCheckpoint.Name = "GrbCheckpoint"
        Me.GrbCheckpoint.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GrbCheckpoint.Size = New System.Drawing.Size(318, 88)
        Me.GrbCheckpoint.TabIndex = 1
        Me.GrbCheckpoint.TabStop = False
        Me.GrbCheckpoint.Text = "CHECKPOINT"
        '
        'CmbBranch
        '
        Me.CmbBranch.FormattingEnabled = True
        Me.CmbBranch.Items.AddRange(New Object() {"TRUE", "FALSE"})
        Me.CmbBranch.Location = New System.Drawing.Point(100, 25)
        Me.CmbBranch.Name = "CmbBranch"
        Me.CmbBranch.Size = New System.Drawing.Size(179, 23)
        Me.CmbBranch.TabIndex = 8
        Me.CmbBranch.Tag = ""
        Me.ToolTip1.SetToolTip(Me.CmbBranch, "Indicates if the branch will be followed when the")
        '
        'BtnCondition
        '
        Me.BtnCondition.Location = New System.Drawing.Point(248, 54)
        Me.BtnCondition.Name = "BtnCondition"
        Me.BtnCondition.Size = New System.Drawing.Size(35, 23)
        Me.BtnCondition.TabIndex = 7
        Me.BtnCondition.Text = "..."
        Me.BtnCondition.UseVisualStyleBackColor = True
        '
        'TxtCondition
        '
        Me.TxtCondition.Location = New System.Drawing.Point(100, 54)
        Me.TxtCondition.Name = "TxtCondition"
        Me.TxtCondition.Size = New System.Drawing.Size(152, 23)
        Me.TxtCondition.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.TxtCondition, "Indicates the condition to follow or not the branch.")
        '
        'LblCondition
        '
        Me.LblCondition.AutoSize = True
        Me.LblCondition.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCondition.Location = New System.Drawing.Point(11, 58)
        Me.LblCondition.Name = "LblCondition"
        Me.LblCondition.Size = New System.Drawing.Size(78, 19)
        Me.LblCondition.TabIndex = 1
        Me.LblCondition.Text = "Condition:"
        '
        'LblBranchIf
        '
        Me.LblBranchIf.AutoSize = True
        Me.LblBranchIf.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBranchIf.Location = New System.Drawing.Point(11, 29)
        Me.LblBranchIf.Name = "LblBranchIf"
        Me.LblBranchIf.Size = New System.Drawing.Size(77, 19)
        Me.LblBranchIf.TabIndex = 0
        Me.LblBranchIf.Text = "Branch If:"
        '
        'GrbSysInfo
        '
        Me.GrbSysInfo.Controls.Add(Me.LblUniqueID)
        Me.GrbSysInfo.Controls.Add(Me.LblSectionID)
        Me.GrbSysInfo.Controls.Add(Me.LblQuesSetID)
        Me.GrbSysInfo.Controls.Add(Me.LblQuesID)
        Me.GrbSysInfo.Controls.Add(Me.LblTitle4)
        Me.GrbSysInfo.Controls.Add(Me.LblTitle3)
        Me.GrbSysInfo.Controls.Add(Me.LblTitle2)
        Me.GrbSysInfo.Controls.Add(Me.LblTitle1)
        Me.GrbSysInfo.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrbSysInfo.Location = New System.Drawing.Point(351, 12)
        Me.GrbSysInfo.Name = "GrbSysInfo"
        Me.GrbSysInfo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GrbSysInfo.Size = New System.Drawing.Size(220, 216)
        Me.GrbSysInfo.TabIndex = 2
        Me.GrbSysInfo.TabStop = False
        Me.GrbSysInfo.Text = "System Information"
        '
        'LblUniqueID
        '
        Me.LblUniqueID.AutoSize = True
        Me.LblUniqueID.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LblUniqueID.Location = New System.Drawing.Point(12, 140)
        Me.LblUniqueID.Name = "LblUniqueID"
        Me.LblUniqueID.Size = New System.Drawing.Size(15, 15)
        Me.LblUniqueID.TabIndex = 7
        Me.LblUniqueID.Text = "0"
        '
        'LblSectionID
        '
        Me.LblSectionID.AutoSize = True
        Me.LblSectionID.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LblSectionID.Location = New System.Drawing.Point(163, 86)
        Me.LblSectionID.Name = "LblSectionID"
        Me.LblSectionID.Size = New System.Drawing.Size(15, 15)
        Me.LblSectionID.TabIndex = 6
        Me.LblSectionID.Text = "0"
        '
        'LblQuesSetID
        '
        Me.LblQuesSetID.AutoSize = True
        Me.LblQuesSetID.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LblQuesSetID.Location = New System.Drawing.Point(163, 57)
        Me.LblQuesSetID.Name = "LblQuesSetID"
        Me.LblQuesSetID.Size = New System.Drawing.Size(15, 15)
        Me.LblQuesSetID.TabIndex = 5
        Me.LblQuesSetID.Text = "0"
        '
        'LblQuesID
        '
        Me.LblQuesID.AutoSize = True
        Me.LblQuesID.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LblQuesID.Location = New System.Drawing.Point(163, 28)
        Me.LblQuesID.Name = "LblQuesID"
        Me.LblQuesID.Size = New System.Drawing.Size(15, 15)
        Me.LblQuesID.TabIndex = 4
        Me.LblQuesID.Text = "0"
        '
        'LblTitle4
        '
        Me.LblTitle4.AutoSize = True
        Me.LblTitle4.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitle4.Location = New System.Drawing.Point(11, 111)
        Me.LblTitle4.Name = "LblTitle4"
        Me.LblTitle4.Size = New System.Drawing.Size(127, 19)
        Me.LblTitle4.TabIndex = 3
        Me.LblTitle4.Text = "Unique Identifier:"
        '
        'LblTitle3
        '
        Me.LblTitle3.AutoSize = True
        Me.LblTitle3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitle3.Location = New System.Drawing.Point(11, 83)
        Me.LblTitle3.Name = "LblTitle3"
        Me.LblTitle3.Size = New System.Drawing.Size(81, 19)
        Me.LblTitle3.TabIndex = 2
        Me.LblTitle3.Text = "SectionID:"
        '
        'LblTitle2
        '
        Me.LblTitle2.AutoSize = True
        Me.LblTitle2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitle2.Location = New System.Drawing.Point(11, 54)
        Me.LblTitle2.Name = "LblTitle2"
        Me.LblTitle2.Size = New System.Drawing.Size(148, 19)
        Me.LblTitle2.TabIndex = 1
        Me.LblTitle2.Text = "QuestionnaireSetID:"
        '
        'LblTitle1
        '
        Me.LblTitle1.AutoSize = True
        Me.LblTitle1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitle1.Location = New System.Drawing.Point(11, 25)
        Me.LblTitle1.Name = "LblTitle1"
        Me.LblTitle1.Size = New System.Drawing.Size(126, 19)
        Me.LblTitle1.TabIndex = 0
        Me.LblTitle1.Text = "QuestionnaireID:"
        '
        'BtnGuardar
        '
        Me.BtnGuardar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnGuardar.Location = New System.Drawing.Point(12, 244)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(95, 30)
        Me.BtnGuardar.TabIndex = 3
        Me.BtnGuardar.Text = "OK"
        Me.BtnGuardar.UseVisualStyleBackColor = True
        '
        'BtnCancelar
        '
        Me.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancelar.Location = New System.Drawing.Point(113, 244)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(95, 30)
        Me.BtnCancelar.TabIndex = 4
        Me.BtnCancelar.Text = "CANCELAR"
        Me.BtnCancelar.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(248, 17)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(35, 23)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 1000
        Me.ToolTip1.AutoPopDelay = 5000
        Me.ToolTip1.BackColor = System.Drawing.Color.MediumBlue
        Me.ToolTip1.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ToolTip1.InitialDelay = 1000
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.OwnerDraw = True
        Me.ToolTip1.ReshowDelay = 200
        Me.ToolTip1.ShowAlways = True
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTip1.ToolTipTitle = "Help"
        '
        'FrmPropertyCheckpoint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(601, 319)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.GrbSysInfo)
        Me.Controls.Add(Me.GrbCheckpoint)
        Me.Controls.Add(Me.GrbMain)
        Me.Name = "FrmPropertyCheckpoint"
        Me.Text = "New Checkpoint"
        Me.GrbMain.ResumeLayout(False)
        Me.GrbMain.PerformLayout()
        Me.GrbCheckpoint.ResumeLayout(False)
        Me.GrbCheckpoint.PerformLayout()
        Me.GrbSysInfo.ResumeLayout(False)
        Me.GrbSysInfo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrbMain As System.Windows.Forms.GroupBox
    Friend WithEvents LblName As System.Windows.Forms.Label
    Friend WithEvents LblMainText As System.Windows.Forms.Label
    Friend WithEvents LblComment As System.Windows.Forms.Label
    Friend WithEvents TxtName As System.Windows.Forms.TextBox
    Friend WithEvents TxtMainText As System.Windows.Forms.TextBox
    Friend WithEvents TxtComment As System.Windows.Forms.TextBox
    Friend WithEvents GrbCheckpoint As System.Windows.Forms.GroupBox
    Friend WithEvents BtnCondition As System.Windows.Forms.Button
    Friend WithEvents TxtCondition As System.Windows.Forms.TextBox
    Friend WithEvents LblCondition As System.Windows.Forms.Label
    Friend WithEvents LblBranchIf As System.Windows.Forms.Label
    Friend WithEvents CmbBranch As System.Windows.Forms.ComboBox
    Friend WithEvents GrbSysInfo As System.Windows.Forms.GroupBox
    Friend WithEvents LblTitle3 As System.Windows.Forms.Label
    Friend WithEvents LblTitle2 As System.Windows.Forms.Label
    Friend WithEvents LblTitle1 As System.Windows.Forms.Label
    Friend WithEvents LblTitle4 As System.Windows.Forms.Label
    Friend WithEvents LblQuesID As System.Windows.Forms.Label
    Friend WithEvents LblQuesSetID As System.Windows.Forms.Label
    Friend WithEvents LblSectionID As System.Windows.Forms.Label
    Friend WithEvents LblUniqueID As System.Windows.Forms.Label
    Friend WithEvents BtnGuardar As System.Windows.Forms.Button
    Friend WithEvents BtnCancelar As System.Windows.Forms.Button
    Friend WithEvents BtnComment As System.Windows.Forms.Button
    Friend WithEvents BtnMainText As System.Windows.Forms.Button
    Friend WithEvents BtnName As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class

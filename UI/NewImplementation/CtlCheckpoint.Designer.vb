<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CtlCheckpoint
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
        Me.components = New System.ComponentModel.Container()
        Me.GrbMain = New System.Windows.Forms.GroupBox()
        Me.GrbCheckpoint = New System.Windows.Forms.GroupBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.LblCondition = New System.Windows.Forms.Label()
        Me.LblBranchIf = New System.Windows.Forms.Label()
        Me.BtnComment = New System.Windows.Forms.Button()
        Me.BtnName = New System.Windows.Forms.Button()
        Me.BtnMainText = New System.Windows.Forms.Button()
        Me.TxtComment = New System.Windows.Forms.TextBox()
        Me.TxtMainText = New System.Windows.Forms.TextBox()
        Me.TxtName = New System.Windows.Forms.TextBox()
        Me.LblComment = New System.Windows.Forms.Label()
        Me.LblMainText = New System.Windows.Forms.Label()
        Me.LblName = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CmbBranch = New System.Windows.Forms.ComboBox()
        Me.BtnCondition = New System.Windows.Forms.Button()
        Me.TxtCondition = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GrbSysInfo = New System.Windows.Forms.GroupBox()
        Me.LblUniqueId = New System.Windows.Forms.Label()
        Me.LblSectionID = New System.Windows.Forms.Label()
        Me.LblQuesSetID = New System.Windows.Forms.Label()
        Me.LblQuesID = New System.Windows.Forms.Label()
        Me.LblTitle4 = New System.Windows.Forms.Label()
        Me.LblTitle3 = New System.Windows.Forms.Label()
        Me.LblTitle2 = New System.Windows.Forms.Label()
        Me.LblTitle1 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GrbMain.SuspendLayout()
        Me.GrbCheckpoint.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GrbSysInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrbMain
        '
        Me.GrbMain.Controls.Add(Me.GrbCheckpoint)
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
        Me.GrbMain.Location = New System.Drawing.Point(3, 3)
        Me.GrbMain.Name = "GrbMain"
        Me.GrbMain.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GrbMain.Size = New System.Drawing.Size(274, 113)
        Me.GrbMain.TabIndex = 1
        Me.GrbMain.TabStop = False
        Me.GrbMain.Text = "MAIN"
        '
        'GrbCheckpoint
        '
        Me.GrbCheckpoint.Controls.Add(Me.ComboBox1)
        Me.GrbCheckpoint.Controls.Add(Me.Button6)
        Me.GrbCheckpoint.Controls.Add(Me.TextBox5)
        Me.GrbCheckpoint.Controls.Add(Me.LblCondition)
        Me.GrbCheckpoint.Controls.Add(Me.LblBranchIf)
        Me.GrbCheckpoint.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrbCheckpoint.Location = New System.Drawing.Point(0, 119)
        Me.GrbCheckpoint.Name = "GrbCheckpoint"
        Me.GrbCheckpoint.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GrbCheckpoint.Size = New System.Drawing.Size(318, 88)
        Me.GrbCheckpoint.TabIndex = 2
        Me.GrbCheckpoint.TabStop = False
        Me.GrbCheckpoint.Text = "CHECKPOINT"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"TRUE", "FALSE"})
        Me.ComboBox1.Location = New System.Drawing.Point(100, 25)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(179, 23)
        Me.ComboBox1.TabIndex = 8
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(248, 54)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(35, 23)
        Me.Button6.TabIndex = 7
        Me.Button6.Text = "..."
        Me.Button6.UseVisualStyleBackColor = True
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(100, 54)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(152, 23)
        Me.TextBox5.TabIndex = 4
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
        'BtnComment
        '
        Me.BtnComment.Location = New System.Drawing.Point(232, 74)
        Me.BtnComment.Name = "BtnComment"
        Me.BtnComment.Size = New System.Drawing.Size(35, 23)
        Me.BtnComment.TabIndex = 8
        Me.BtnComment.Text = "..."
        Me.BtnComment.UseVisualStyleBackColor = True
        '
        'BtnName
        '
        Me.BtnName.Location = New System.Drawing.Point(232, 17)
        Me.BtnName.Name = "BtnName"
        Me.BtnName.Size = New System.Drawing.Size(35, 23)
        Me.BtnName.TabIndex = 6
        Me.BtnName.Text = "..."
        Me.BtnName.UseVisualStyleBackColor = True
        '
        'BtnMainText
        '
        Me.BtnMainText.Location = New System.Drawing.Point(232, 45)
        Me.BtnMainText.Name = "BtnMainText"
        Me.BtnMainText.Size = New System.Drawing.Size(35, 23)
        Me.BtnMainText.TabIndex = 7
        Me.BtnMainText.Text = "..."
        Me.BtnMainText.UseVisualStyleBackColor = True
        '
        'TxtComment
        '
        Me.TxtComment.Location = New System.Drawing.Point(92, 75)
        Me.TxtComment.Name = "TxtComment"
        Me.TxtComment.Size = New System.Drawing.Size(142, 23)
        Me.TxtComment.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.TxtComment, "Indicates the name of the object.")
        '
        'TxtMainText
        '
        Me.TxtMainText.Location = New System.Drawing.Point(92, 46)
        Me.TxtMainText.Name = "TxtMainText"
        Me.TxtMainText.Size = New System.Drawing.Size(142, 23)
        Me.TxtMainText.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.TxtMainText, "The question to be displayed.")
        '
        'TxtName
        '
        Me.TxtName.Location = New System.Drawing.Point(92, 17)
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(142, 23)
        Me.TxtName.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.TxtName, "Type a comment of the object.")
        '
        'LblComment
        '
        Me.LblComment.AutoSize = True
        Me.LblComment.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblComment.Location = New System.Drawing.Point(3, 79)
        Me.LblComment.Name = "LblComment"
        Me.LblComment.Size = New System.Drawing.Size(78, 19)
        Me.LblComment.TabIndex = 2
        Me.LblComment.Text = "Comment:"
        '
        'LblMainText
        '
        Me.LblMainText.AutoSize = True
        Me.LblMainText.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMainText.Location = New System.Drawing.Point(3, 50)
        Me.LblMainText.Name = "LblMainText"
        Me.LblMainText.Size = New System.Drawing.Size(84, 19)
        Me.LblMainText.TabIndex = 1
        Me.LblMainText.Text = "Main Text:"
        '
        'LblName
        '
        Me.LblName.AutoSize = True
        Me.LblName.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblName.Location = New System.Drawing.Point(3, 21)
        Me.LblName.Name = "LblName"
        Me.LblName.Size = New System.Drawing.Size(54, 19)
        Me.LblName.TabIndex = 0
        Me.LblName.Text = "Name:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CmbBranch)
        Me.GroupBox1.Controls.Add(Me.BtnCondition)
        Me.GroupBox1.Controls.Add(Me.TxtCondition)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(3, 122)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GroupBox1.Size = New System.Drawing.Size(274, 88)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "CHECKPOINT"
        '
        'CmbBranch
        '
        Me.CmbBranch.FormattingEnabled = True
        Me.CmbBranch.Items.AddRange(New Object() {"TRUE", "FALSE"})
        Me.CmbBranch.Location = New System.Drawing.Point(92, 25)
        Me.CmbBranch.Name = "CmbBranch"
        Me.CmbBranch.Size = New System.Drawing.Size(142, 23)
        Me.CmbBranch.TabIndex = 8
        Me.ToolTip1.SetToolTip(Me.CmbBranch, "Indicates if the branch will be followed when the" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "condition returns true or fals" & _
        "e.")
        '
        'BtnCondition
        '
        Me.BtnCondition.Location = New System.Drawing.Point(232, 54)
        Me.BtnCondition.Name = "BtnCondition"
        Me.BtnCondition.Size = New System.Drawing.Size(35, 23)
        Me.BtnCondition.TabIndex = 7
        Me.BtnCondition.Text = "..."
        Me.BtnCondition.UseVisualStyleBackColor = True
        '
        'TxtCondition
        '
        Me.TxtCondition.Location = New System.Drawing.Point(92, 54)
        Me.TxtCondition.Name = "TxtCondition"
        Me.TxtCondition.Size = New System.Drawing.Size(142, 23)
        Me.TxtCondition.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.TxtCondition, "Indicates the condition to follow or not the branch.")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 19)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Condition:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 19)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Branch If:"
        '
        'GrbSysInfo
        '
        Me.GrbSysInfo.Controls.Add(Me.LblUniqueId)
        Me.GrbSysInfo.Controls.Add(Me.LblSectionID)
        Me.GrbSysInfo.Controls.Add(Me.LblQuesSetID)
        Me.GrbSysInfo.Controls.Add(Me.LblQuesID)
        Me.GrbSysInfo.Controls.Add(Me.LblTitle4)
        Me.GrbSysInfo.Controls.Add(Me.LblTitle3)
        Me.GrbSysInfo.Controls.Add(Me.LblTitle2)
        Me.GrbSysInfo.Controls.Add(Me.LblTitle1)
        Me.GrbSysInfo.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrbSysInfo.Location = New System.Drawing.Point(3, 216)
        Me.GrbSysInfo.Name = "GrbSysInfo"
        Me.GrbSysInfo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GrbSysInfo.Size = New System.Drawing.Size(274, 160)
        Me.GrbSysInfo.TabIndex = 3
        Me.GrbSysInfo.TabStop = False
        Me.GrbSysInfo.Text = "System Information"
        '
        'LblUniqueId
        '
        Me.LblUniqueId.AutoSize = True
        Me.LblUniqueId.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LblUniqueId.Location = New System.Drawing.Point(12, 140)
        Me.LblUniqueId.Name = "LblUniqueId"
        Me.LblUniqueId.Size = New System.Drawing.Size(15, 15)
        Me.LblUniqueId.TabIndex = 7
        Me.LblUniqueId.Text = "0"
        '
        'LblSectionID
        '
        Me.LblSectionID.AutoSize = True
        Me.LblSectionID.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LblSectionID.Location = New System.Drawing.Point(169, 86)
        Me.LblSectionID.Name = "LblSectionID"
        Me.LblSectionID.Size = New System.Drawing.Size(15, 15)
        Me.LblSectionID.TabIndex = 6
        Me.LblSectionID.Text = "0"
        '
        'LblQuesSetID
        '
        Me.LblQuesSetID.AutoSize = True
        Me.LblQuesSetID.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LblQuesSetID.Location = New System.Drawing.Point(169, 57)
        Me.LblQuesSetID.Name = "LblQuesSetID"
        Me.LblQuesSetID.Size = New System.Drawing.Size(15, 15)
        Me.LblQuesSetID.TabIndex = 5
        Me.LblQuesSetID.Text = "0"
        '
        'LblQuesID
        '
        Me.LblQuesID.AutoSize = True
        Me.LblQuesID.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LblQuesID.Location = New System.Drawing.Point(169, 28)
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
        'CtlCheckpoint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GrbSysInfo)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GrbMain)
        Me.Name = "CtlCheckpoint"
        Me.Size = New System.Drawing.Size(338, 389)
        Me.GrbMain.ResumeLayout(False)
        Me.GrbMain.PerformLayout()
        Me.GrbCheckpoint.ResumeLayout(False)
        Me.GrbCheckpoint.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GrbSysInfo.ResumeLayout(False)
        Me.GrbSysInfo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrbMain As System.Windows.Forms.GroupBox
    Friend WithEvents BtnComment As System.Windows.Forms.Button
    Friend WithEvents BtnName As System.Windows.Forms.Button
    Friend WithEvents BtnMainText As System.Windows.Forms.Button
    Friend WithEvents TxtComment As System.Windows.Forms.TextBox
    Friend WithEvents TxtMainText As System.Windows.Forms.TextBox
    Friend WithEvents TxtName As System.Windows.Forms.TextBox
    Friend WithEvents LblComment As System.Windows.Forms.Label
    Friend WithEvents LblMainText As System.Windows.Forms.Label
    Friend WithEvents LblName As System.Windows.Forms.Label
    Friend WithEvents GrbCheckpoint As System.Windows.Forms.GroupBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents LblCondition As System.Windows.Forms.Label
    Friend WithEvents LblBranchIf As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CmbBranch As System.Windows.Forms.ComboBox
    Friend WithEvents BtnCondition As System.Windows.Forms.Button
    Friend WithEvents TxtCondition As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GrbSysInfo As System.Windows.Forms.GroupBox
    Friend WithEvents LblUniqueId As System.Windows.Forms.Label
    Friend WithEvents LblSectionID As System.Windows.Forms.Label
    Friend WithEvents LblQuesSetID As System.Windows.Forms.Label
    Friend WithEvents LblQuesID As System.Windows.Forms.Label
    Friend WithEvents LblTitle4 As System.Windows.Forms.Label
    Friend WithEvents LblTitle3 As System.Windows.Forms.Label
    Friend WithEvents LblTitle2 As System.Windows.Forms.Label
    Friend WithEvents LblTitle1 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip

End Class

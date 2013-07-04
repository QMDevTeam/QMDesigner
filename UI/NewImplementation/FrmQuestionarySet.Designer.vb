<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmQuestionnaireSet
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
        Me.PnlInformation = New System.Windows.Forms.Panel()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.BtnOk = New System.Windows.Forms.Button()
        Me.GrpSystemInformation = New System.Windows.Forms.GroupBox()
        Me.TxtSysInId = New System.Windows.Forms.TextBox()
        Me.TxtSysInSetId = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.GrpServerData = New System.Windows.Forms.GroupBox()
        Me.TxtServerLTname = New System.Windows.Forms.TextBox()
        Me.TxtServerDataTname = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GrpPdaSettings = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GrpPdaData = New System.Windows.Forms.GroupBox()
        Me.TxtPdaTname = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GrpMain = New System.Windows.Forms.GroupBox()
        Me.BtnNameEditor = New System.Windows.Forms.Button()
        Me.BtnPreconditionEditor = New System.Windows.Forms.Button()
        Me.BtnCommentEditor = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolTipSecondaryIdField = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTipConfirmationFields = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTipSearchField = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTipNewSubject = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTipSectionId = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTipShortName = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTipPrecondition = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTipName = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTipComment = New System.Windows.Forms.ToolTip(Me.components)
        Me.TxtComment = New System.Windows.Forms.TextBox()
        Me.TxtName = New System.Windows.Forms.TextBox()
        Me.TxtPrecondition = New System.Windows.Forms.TextBox()
        Me.TxtShortName = New System.Windows.Forms.TextBox()
        Me.TxtPdaSetNewId = New System.Windows.Forms.TextBox()
        Me.TxtPdaSetNewSub = New System.Windows.Forms.TextBox()
        Me.TxtPdaSetSearchField = New System.Windows.Forms.TextBox()
        Me.TxtPdaSetConfirmField = New System.Windows.Forms.TextBox()
        Me.TxtPdaSetSecondField = New System.Windows.Forms.TextBox()
        Me.PnlInformation.SuspendLayout()
        Me.GrpSystemInformation.SuspendLayout()
        Me.GrpServerData.SuspendLayout()
        Me.GrpPdaSettings.SuspendLayout()
        Me.GrpPdaData.SuspendLayout()
        Me.GrpMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnlInformation
        '
        Me.PnlInformation.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PnlInformation.AutoScroll = True
        Me.PnlInformation.Controls.Add(Me.BtnCancel)
        Me.PnlInformation.Controls.Add(Me.BtnOk)
        Me.PnlInformation.Controls.Add(Me.GrpSystemInformation)
        Me.PnlInformation.Controls.Add(Me.GrpServerData)
        Me.PnlInformation.Controls.Add(Me.GrpPdaSettings)
        Me.PnlInformation.Controls.Add(Me.GrpPdaData)
        Me.PnlInformation.Controls.Add(Me.GrpMain)
        Me.PnlInformation.Location = New System.Drawing.Point(2, 3)
        Me.PnlInformation.Name = "PnlInformation"
        Me.PnlInformation.Size = New System.Drawing.Size(638, 395)
        Me.PnlInformation.TabIndex = 0
        '
        'BtnCancel
        '
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Location = New System.Drawing.Point(552, 364)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 23)
        Me.BtnCancel.TabIndex = 8
        Me.BtnCancel.Text = "&Cancel"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'BtnOk
        '
        Me.BtnOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnOk.Location = New System.Drawing.Point(443, 364)
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.Size = New System.Drawing.Size(75, 23)
        Me.BtnOk.TabIndex = 7
        Me.BtnOk.Text = "&Ok"
        Me.BtnOk.UseVisualStyleBackColor = True
        '
        'GrpSystemInformation
        '
        Me.GrpSystemInformation.Controls.Add(Me.TxtSysInId)
        Me.GrpSystemInformation.Controls.Add(Me.TxtSysInSetId)
        Me.GrpSystemInformation.Controls.Add(Me.Label13)
        Me.GrpSystemInformation.Controls.Add(Me.Label14)
        Me.GrpSystemInformation.Location = New System.Drawing.Point(343, 224)
        Me.GrpSystemInformation.Name = "GrpSystemInformation"
        Me.GrpSystemInformation.Size = New System.Drawing.Size(284, 100)
        Me.GrpSystemInformation.TabIndex = 5
        Me.GrpSystemInformation.TabStop = False
        Me.GrpSystemInformation.Text = "SystemInformation"
        '
        'TxtSysInId
        '
        Me.TxtSysInId.Enabled = False
        Me.TxtSysInId.Location = New System.Drawing.Point(106, 54)
        Me.TxtSysInId.Name = "TxtSysInId"
        Me.TxtSysInId.Size = New System.Drawing.Size(149, 20)
        Me.TxtSysInId.TabIndex = 10
        '
        'TxtSysInSetId
        '
        Me.TxtSysInSetId.Enabled = False
        Me.TxtSysInSetId.Location = New System.Drawing.Point(106, 27)
        Me.TxtSysInSetId.Name = "TxtSysInSetId"
        Me.TxtSysInSetId.Size = New System.Drawing.Size(149, 20)
        Me.TxtSysInSetId.TabIndex = 9
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(7, 61)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(84, 13)
        Me.Label13.TabIndex = 8
        Me.Label13.Text = "Unique Identifier"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(7, 34)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(97, 13)
        Me.Label14.TabIndex = 7
        Me.Label14.Text = "QuestionnaireSetId"
        '
        'GrpServerData
        '
        Me.GrpServerData.Controls.Add(Me.TxtServerLTname)
        Me.GrpServerData.Controls.Add(Me.TxtServerDataTname)
        Me.GrpServerData.Controls.Add(Me.Label10)
        Me.GrpServerData.Controls.Add(Me.Label11)
        Me.GrpServerData.Location = New System.Drawing.Point(301, 83)
        Me.GrpServerData.Name = "GrpServerData"
        Me.GrpServerData.Size = New System.Drawing.Size(284, 90)
        Me.GrpServerData.TabIndex = 6
        Me.GrpServerData.TabStop = False
        Me.GrpServerData.Text = "Server Data"
        '
        'TxtServerLTname
        '
        Me.TxtServerLTname.Location = New System.Drawing.Point(102, 45)
        Me.TxtServerLTname.Name = "TxtServerLTname"
        Me.TxtServerLTname.Size = New System.Drawing.Size(149, 20)
        Me.TxtServerLTname.TabIndex = 10
        '
        'TxtServerDataTname
        '
        Me.TxtServerDataTname.Location = New System.Drawing.Point(102, 19)
        Me.TxtServerDataTname.Name = "TxtServerDataTname"
        Me.TxtServerDataTname.Size = New System.Drawing.Size(149, 20)
        Me.TxtServerDataTname.TabIndex = 9
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 53)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(86, 13)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "Log Table Name"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 26)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(91, 13)
        Me.Label11.TabIndex = 7
        Me.Label11.Text = "Data Table Name"
        '
        'GrpPdaSettings
        '
        Me.GrpPdaSettings.Controls.Add(Me.TxtPdaSetSecondField)
        Me.GrpPdaSettings.Controls.Add(Me.TxtPdaSetConfirmField)
        Me.GrpPdaSettings.Controls.Add(Me.TxtPdaSetSearchField)
        Me.GrpPdaSettings.Controls.Add(Me.TxtPdaSetNewSub)
        Me.GrpPdaSettings.Controls.Add(Me.TxtPdaSetNewId)
        Me.GrpPdaSettings.Controls.Add(Me.Label9)
        Me.GrpPdaSettings.Controls.Add(Me.Label5)
        Me.GrpPdaSettings.Controls.Add(Me.Label6)
        Me.GrpPdaSettings.Controls.Add(Me.Label7)
        Me.GrpPdaSettings.Controls.Add(Me.Label8)
        Me.GrpPdaSettings.Location = New System.Drawing.Point(10, 188)
        Me.GrpPdaSettings.Name = "GrpPdaSettings"
        Me.GrpPdaSettings.Size = New System.Drawing.Size(319, 164)
        Me.GrpPdaSettings.TabIndex = 3
        Me.GrpPdaSettings.TabStop = False
        Me.GrpPdaSettings.Text = "PDA Settings"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 134)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(125, 13)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "SubjectSecondaryIdField"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 104)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(128, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "SubjectConfirmationFields"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 77)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(149, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "SubjectAlternativeSearchField"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(7, 53)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(85, 13)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "On New Subject"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(7, 26)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(112, 13)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "NewSubjectSectionID"
        '
        'GrpPdaData
        '
        Me.GrpPdaData.Controls.Add(Me.TxtPdaTname)
        Me.GrpPdaData.Controls.Add(Me.Label12)
        Me.GrpPdaData.Location = New System.Drawing.Point(301, 9)
        Me.GrpPdaData.Name = "GrpPdaData"
        Me.GrpPdaData.Size = New System.Drawing.Size(284, 64)
        Me.GrpPdaData.TabIndex = 4
        Me.GrpPdaData.TabStop = False
        Me.GrpPdaData.Text = "PDA Data"
        '
        'TxtPdaTname
        '
        Me.TxtPdaTname.Enabled = False
        Me.TxtPdaTname.Location = New System.Drawing.Point(122, 22)
        Me.TxtPdaTname.Name = "TxtPdaTname"
        Me.TxtPdaTname.Size = New System.Drawing.Size(149, 20)
        Me.TxtPdaTname.TabIndex = 6
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 29)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(110, 13)
        Me.Label12.TabIndex = 5
        Me.Label12.Text = "PDAData TableName"
        '
        'GrpMain
        '
        Me.GrpMain.Controls.Add(Me.TxtShortName)
        Me.GrpMain.Controls.Add(Me.TxtPrecondition)
        Me.GrpMain.Controls.Add(Me.TxtName)
        Me.GrpMain.Controls.Add(Me.TxtComment)
        Me.GrpMain.Controls.Add(Me.BtnNameEditor)
        Me.GrpMain.Controls.Add(Me.BtnPreconditionEditor)
        Me.GrpMain.Controls.Add(Me.BtnCommentEditor)
        Me.GrpMain.Controls.Add(Me.Label4)
        Me.GrpMain.Controls.Add(Me.Label3)
        Me.GrpMain.Controls.Add(Me.Label2)
        Me.GrpMain.Controls.Add(Me.Label1)
        Me.GrpMain.Location = New System.Drawing.Point(10, 9)
        Me.GrpMain.Name = "GrpMain"
        Me.GrpMain.Size = New System.Drawing.Size(285, 164)
        Me.GrpMain.TabIndex = 0
        Me.GrpMain.TabStop = False
        Me.GrpMain.Text = "Main"
        '
        'BtnNameEditor
        '
        Me.BtnNameEditor.Location = New System.Drawing.Point(245, 58)
        Me.BtnNameEditor.Name = "BtnNameEditor"
        Me.BtnNameEditor.Size = New System.Drawing.Size(36, 20)
        Me.BtnNameEditor.TabIndex = 10
        Me.BtnNameEditor.Text = "..."
        Me.BtnNameEditor.UseVisualStyleBackColor = False
        '
        'BtnPreconditionEditor
        '
        Me.BtnPreconditionEditor.Location = New System.Drawing.Point(245, 82)
        Me.BtnPreconditionEditor.Name = "BtnPreconditionEditor"
        Me.BtnPreconditionEditor.Size = New System.Drawing.Size(36, 20)
        Me.BtnPreconditionEditor.TabIndex = 9
        Me.BtnPreconditionEditor.Text = "..."
        Me.BtnPreconditionEditor.UseVisualStyleBackColor = False
        '
        'BtnCommentEditor
        '
        Me.BtnCommentEditor.Location = New System.Drawing.Point(245, 31)
        Me.BtnCommentEditor.Name = "BtnCommentEditor"
        Me.BtnCommentEditor.Size = New System.Drawing.Size(36, 20)
        Me.BtnCommentEditor.TabIndex = 8
        Me.BtnCommentEditor.Text = "..."
        Me.BtnCommentEditor.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 116)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Short Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 89)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Precondition"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Comment"
        '
        'ToolTipSecondaryIdField
        '
        Me.ToolTipSecondaryIdField.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTipSecondaryIdField.ToolTipTitle = "Subject Secondary Id Field"
        '
        'ToolTipConfirmationFields
        '
        Me.ToolTipConfirmationFields.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTipConfirmationFields.ToolTipTitle = "Subject Confirmation Fields"
        '
        'ToolTipSearchField
        '
        Me.ToolTipSearchField.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTipSearchField.ToolTipTitle = "Subject Alternative Search Field"
        '
        'ToolTipNewSubject
        '
        Me.ToolTipNewSubject.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTipNewSubject.ToolTipTitle = "On New Subject"
        '
        'ToolTipSectionId
        '
        Me.ToolTipSectionId.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTipSectionId.ToolTipTitle = "New Subject SectionID"
        '
        'ToolTipShortName
        '
        Me.ToolTipShortName.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTipShortName.ToolTipTitle = "Short Name"
        '
        'ToolTipPrecondition
        '
        Me.ToolTipPrecondition.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTipPrecondition.ToolTipTitle = "Precondition"
        '
        'ToolTipName
        '
        Me.ToolTipName.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTipName.ToolTipTitle = "Name"
        '
        'ToolTipComment
        '
        Me.ToolTipComment.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTipComment.ToolTipTitle = "Comment"
        '
        'TxtComment
        '
        Me.TxtComment.Location = New System.Drawing.Point(94, 31)
        Me.TxtComment.Name = "TxtComment"
        Me.TxtComment.Size = New System.Drawing.Size(149, 20)
        Me.TxtComment.TabIndex = 11
        Me.ToolTipComment.SetToolTip(Me.TxtComment, "Type a comment of the object.")
        '
        'TxtName
        '
        Me.TxtName.Location = New System.Drawing.Point(94, 56)
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(149, 20)
        Me.TxtName.TabIndex = 12
        Me.ToolTipName.SetToolTip(Me.TxtName, "Indicates the name of the object.")
        '
        'TxtPrecondition
        '
        Me.TxtPrecondition.Location = New System.Drawing.Point(94, 82)
        Me.TxtPrecondition.Name = "TxtPrecondition"
        Me.TxtPrecondition.Size = New System.Drawing.Size(149, 20)
        Me.TxtPrecondition.TabIndex = 13
        Me.ToolTipPrecondition.SetToolTip(Me.TxtPrecondition, "Indicates the precondition for this questionnaire")
        '
        'TxtShortName
        '
        Me.TxtShortName.Location = New System.Drawing.Point(94, 108)
        Me.TxtShortName.Name = "TxtShortName"
        Me.TxtShortName.Size = New System.Drawing.Size(149, 20)
        Me.TxtShortName.TabIndex = 14
        Me.ToolTipShortName.SetToolTip(Me.TxtShortName, "Indicates the short name of the study.")
        '
        'TxtPdaSetNewId
        '
        Me.TxtPdaSetNewId.Location = New System.Drawing.Point(161, 20)
        Me.TxtPdaSetNewId.Name = "TxtPdaSetNewId"
        Me.TxtPdaSetNewId.Size = New System.Drawing.Size(149, 20)
        Me.TxtPdaSetNewId.TabIndex = 18
        Me.ToolTipSectionId.SetToolTip(Me.TxtPdaSetNewId, "New Subject section ID.")
        '
        'TxtPdaSetNewSub
        '
        Me.TxtPdaSetNewSub.Location = New System.Drawing.Point(161, 46)
        Me.TxtPdaSetNewSub.Name = "TxtPdaSetNewSub"
        Me.TxtPdaSetNewSub.Size = New System.Drawing.Size(149, 20)
        Me.TxtPdaSetNewSub.TabIndex = 19
        Me.ToolTipNewSubject.SetToolTip(Me.TxtPdaSetNewSub, "Code to execute when a new subject record is created.")
        '
        'TxtPdaSetSearchField
        '
        Me.TxtPdaSetSearchField.Location = New System.Drawing.Point(161, 72)
        Me.TxtPdaSetSearchField.Name = "TxtPdaSetSearchField"
        Me.TxtPdaSetSearchField.Size = New System.Drawing.Size(149, 20)
        Me.TxtPdaSetSearchField.TabIndex = 20
        Me.ToolTipSearchField.SetToolTip(Me.TxtPdaSetSearchField, "Alternative subject search field.")
        '
        'TxtPdaSetConfirmField
        '
        Me.TxtPdaSetConfirmField.Location = New System.Drawing.Point(161, 98)
        Me.TxtPdaSetConfirmField.Name = "TxtPdaSetConfirmField"
        Me.TxtPdaSetConfirmField.Size = New System.Drawing.Size(149, 20)
        Me.TxtPdaSetConfirmField.TabIndex = 21
        Me.ToolTipConfirmationFields.SetToolTip(Me.TxtPdaSetConfirmField, "Subject Confirmation Fields.")
        '
        'TxtPdaSetSecondField
        '
        Me.TxtPdaSetSecondField.Location = New System.Drawing.Point(161, 124)
        Me.TxtPdaSetSecondField.Name = "TxtPdaSetSecondField"
        Me.TxtPdaSetSecondField.Size = New System.Drawing.Size(149, 20)
        Me.TxtPdaSetSecondField.TabIndex = 22
        Me.ToolTipSecondaryIdField.SetToolTip(Me.TxtPdaSetSecondField, "Alternative Subject Identification.")
        '
        'FrmQuestionnaireSet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(641, 403)
        Me.Controls.Add(Me.PnlInformation)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FrmQuestionnaireSet"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Questionnaire Set Editor"
        Me.PnlInformation.ResumeLayout(False)
        Me.GrpSystemInformation.ResumeLayout(False)
        Me.GrpSystemInformation.PerformLayout()
        Me.GrpServerData.ResumeLayout(False)
        Me.GrpServerData.PerformLayout()
        Me.GrpPdaSettings.ResumeLayout(False)
        Me.GrpPdaSettings.PerformLayout()
        Me.GrpPdaData.ResumeLayout(False)
        Me.GrpPdaData.PerformLayout()
        Me.GrpMain.ResumeLayout(False)
        Me.GrpMain.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnlInformation As System.Windows.Forms.Panel
    Friend WithEvents GrpPdaSettings As System.Windows.Forms.GroupBox
    Friend WithEvents GrpPdaData As System.Windows.Forms.GroupBox
    Friend WithEvents GrpMain As System.Windows.Forms.GroupBox
    Friend WithEvents GrpSystemInformation As System.Windows.Forms.GroupBox
    Friend WithEvents GrpServerData As System.Windows.Forms.GroupBox
    Friend WithEvents BtnOk As System.Windows.Forms.Button
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TxtServerLTname As System.Windows.Forms.TextBox
    Friend WithEvents TxtServerDataTname As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TxtPdaTname As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TxtSysInId As System.Windows.Forms.TextBox
    Friend WithEvents TxtSysInSetId As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents BtnCommentEditor As System.Windows.Forms.Button
    Friend WithEvents BtnPreconditionEditor As System.Windows.Forms.Button
    Friend WithEvents BtnNameEditor As System.Windows.Forms.Button
    Friend WithEvents ToolTipSecondaryIdField As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTipConfirmationFields As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTipSearchField As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTipNewSubject As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTipSectionId As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTipShortName As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTipPrecondition As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTipName As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTipComment As System.Windows.Forms.ToolTip
    Friend WithEvents TxtComment As System.Windows.Forms.TextBox
    Friend WithEvents TxtName As System.Windows.Forms.TextBox
    Friend WithEvents TxtPrecondition As System.Windows.Forms.TextBox
    Friend WithEvents TxtShortName As System.Windows.Forms.TextBox
    Friend WithEvents TxtPdaSetNewId As System.Windows.Forms.TextBox
    Friend WithEvents TxtPdaSetNewSub As System.Windows.Forms.TextBox
    Friend WithEvents TxtPdaSetSearchField As System.Windows.Forms.TextBox
    Friend WithEvents TxtPdaSetConfirmField As System.Windows.Forms.TextBox
    Friend WithEvents TxtPdaSetSecondField As System.Windows.Forms.TextBox
End Class

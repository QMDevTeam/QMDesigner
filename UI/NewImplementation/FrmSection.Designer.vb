<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSection
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
        Me.TxtSectionID = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TxtQuestionnaireID = New System.Windows.Forms.TextBox()
        Me.TxtUniqueIdentifier = New System.Windows.Forms.TextBox()
        Me.TxtQuestionnaireSetId = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.GrpServerData = New System.Windows.Forms.GroupBox()
        Me.TxtServerLTname = New System.Windows.Forms.TextBox()
        Me.TxtServerDataTname = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GrpPdaSettings = New System.Windows.Forms.GroupBox()
        Me.BtnNamePrecondition = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GrpPdaData = New System.Windows.Forms.GroupBox()
        Me.TxtPdaTname = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GrpMain = New System.Windows.Forms.GroupBox()
        Me.BtnNameEditor = New System.Windows.Forms.Button()
        Me.BtnCommentEditor = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolTipPrecondition = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTipProcedureId = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTipModifiable = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTipShortName = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTipName = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTipComment = New System.Windows.Forms.ToolTip(Me.components)
        Me.TxtComment = New System.Windows.Forms.TextBox()
        Me.TxtName = New System.Windows.Forms.TextBox()
        Me.TxtShortName = New System.Windows.Forms.TextBox()
        Me.CmbModifiable = New System.Windows.Forms.ComboBox()
        Me.TxtProcedureID = New System.Windows.Forms.TextBox()
        Me.TxtPrecondition = New System.Windows.Forms.TextBox()
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
        Me.PnlInformation.AutoScroll = True
        Me.PnlInformation.Controls.Add(Me.BtnCancel)
        Me.PnlInformation.Controls.Add(Me.BtnOk)
        Me.PnlInformation.Controls.Add(Me.GrpSystemInformation)
        Me.PnlInformation.Controls.Add(Me.GrpServerData)
        Me.PnlInformation.Controls.Add(Me.GrpPdaSettings)
        Me.PnlInformation.Controls.Add(Me.GrpPdaData)
        Me.PnlInformation.Controls.Add(Me.GrpMain)
        Me.PnlInformation.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlInformation.Location = New System.Drawing.Point(0, 0)
        Me.PnlInformation.Name = "PnlInformation"
        Me.PnlInformation.Size = New System.Drawing.Size(655, 321)
        Me.PnlInformation.TabIndex = 1
        '
        'BtnCancel
        '
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Location = New System.Drawing.Point(520, 286)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 23)
        Me.BtnCancel.TabIndex = 8
        Me.BtnCancel.Text = "&Cancel"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'BtnOk
        '
        Me.BtnOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnOk.Location = New System.Drawing.Point(423, 286)
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.Size = New System.Drawing.Size(75, 23)
        Me.BtnOk.TabIndex = 7
        Me.BtnOk.Text = "&Ok"
        Me.BtnOk.UseVisualStyleBackColor = True
        '
        'GrpSystemInformation
        '
        Me.GrpSystemInformation.Controls.Add(Me.TxtSectionID)
        Me.GrpSystemInformation.Controls.Add(Me.Label15)
        Me.GrpSystemInformation.Controls.Add(Me.TxtQuestionnaireID)
        Me.GrpSystemInformation.Controls.Add(Me.TxtUniqueIdentifier)
        Me.GrpSystemInformation.Controls.Add(Me.TxtQuestionnaireSetId)
        Me.GrpSystemInformation.Controls.Add(Me.Label3)
        Me.GrpSystemInformation.Controls.Add(Me.Label13)
        Me.GrpSystemInformation.Controls.Add(Me.Label14)
        Me.GrpSystemInformation.Location = New System.Drawing.Point(363, 147)
        Me.GrpSystemInformation.Name = "GrpSystemInformation"
        Me.GrpSystemInformation.Size = New System.Drawing.Size(284, 124)
        Me.GrpSystemInformation.TabIndex = 5
        Me.GrpSystemInformation.TabStop = False
        Me.GrpSystemInformation.Text = "SystemInformation"
        '
        'TxtSectionID
        '
        Me.TxtSectionID.Enabled = False
        Me.TxtSectionID.Location = New System.Drawing.Point(106, 69)
        Me.TxtSectionID.Name = "TxtSectionID"
        Me.TxtSectionID.Size = New System.Drawing.Size(149, 20)
        Me.TxtSectionID.TabIndex = 14
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(7, 76)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(54, 13)
        Me.Label15.TabIndex = 13
        Me.Label15.Text = "SectionID"
        '
        'TxtQuestionnaireID
        '
        Me.TxtQuestionnaireID.Enabled = False
        Me.TxtQuestionnaireID.Location = New System.Drawing.Point(106, 14)
        Me.TxtQuestionnaireID.Name = "TxtQuestionnaireID"
        Me.TxtQuestionnaireID.Size = New System.Drawing.Size(149, 20)
        Me.TxtQuestionnaireID.TabIndex = 12
        '
        'TxtUniqueIdentifier
        '
        Me.TxtUniqueIdentifier.Enabled = False
        Me.TxtUniqueIdentifier.Location = New System.Drawing.Point(106, 95)
        Me.TxtUniqueIdentifier.Name = "TxtUniqueIdentifier"
        Me.TxtUniqueIdentifier.Size = New System.Drawing.Size(149, 20)
        Me.TxtUniqueIdentifier.TabIndex = 10
        '
        'TxtQuestionnaireSetId
        '
        Me.TxtQuestionnaireSetId.Enabled = False
        Me.TxtQuestionnaireSetId.Location = New System.Drawing.Point(106, 41)
        Me.TxtQuestionnaireSetId.Name = "TxtQuestionnaireSetId"
        Me.TxtQuestionnaireSetId.Size = New System.Drawing.Size(149, 20)
        Me.TxtQuestionnaireSetId.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "QuestionnaireID"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(7, 102)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(84, 13)
        Me.Label13.TabIndex = 8
        Me.Label13.Text = "Unique Identifier"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(7, 48)
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
        Me.GrpServerData.Location = New System.Drawing.Point(363, 65)
        Me.GrpServerData.Name = "GrpServerData"
        Me.GrpServerData.Size = New System.Drawing.Size(284, 73)
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
        Me.Label10.Location = New System.Drawing.Point(6, 52)
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
        Me.GrpPdaSettings.Controls.Add(Me.TxtPrecondition)
        Me.GrpPdaSettings.Controls.Add(Me.TxtProcedureID)
        Me.GrpPdaSettings.Controls.Add(Me.CmbModifiable)
        Me.GrpPdaSettings.Controls.Add(Me.BtnNamePrecondition)
        Me.GrpPdaSettings.Controls.Add(Me.Label6)
        Me.GrpPdaSettings.Controls.Add(Me.Label7)
        Me.GrpPdaSettings.Controls.Add(Me.Label8)
        Me.GrpPdaSettings.Location = New System.Drawing.Point(10, 123)
        Me.GrpPdaSettings.Name = "GrpPdaSettings"
        Me.GrpPdaSettings.Size = New System.Drawing.Size(347, 110)
        Me.GrpPdaSettings.TabIndex = 3
        Me.GrpPdaSettings.TabStop = False
        Me.GrpPdaSettings.Text = "PDA Settings"
        '
        'BtnNamePrecondition
        '
        Me.BtnNamePrecondition.Location = New System.Drawing.Point(305, 70)
        Me.BtnNamePrecondition.Name = "BtnNamePrecondition"
        Me.BtnNamePrecondition.Size = New System.Drawing.Size(36, 20)
        Me.BtnNamePrecondition.TabIndex = 27
        Me.BtnNamePrecondition.Text = "..."
        Me.BtnNamePrecondition.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 77)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Precondition"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(7, 53)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(138, 13)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "OnNewRecordProcedureID"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(7, 26)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(55, 13)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Modifiable"
        '
        'GrpPdaData
        '
        Me.GrpPdaData.Controls.Add(Me.TxtPdaTname)
        Me.GrpPdaData.Controls.Add(Me.Label12)
        Me.GrpPdaData.Location = New System.Drawing.Point(363, 11)
        Me.GrpPdaData.Name = "GrpPdaData"
        Me.GrpPdaData.Size = New System.Drawing.Size(284, 47)
        Me.GrpPdaData.TabIndex = 4
        Me.GrpPdaData.TabStop = False
        Me.GrpPdaData.Text = "PDA Data"
        '
        'TxtPdaTname
        '
        Me.TxtPdaTname.Location = New System.Drawing.Point(122, 15)
        Me.TxtPdaTname.Name = "TxtPdaTname"
        Me.TxtPdaTname.Size = New System.Drawing.Size(149, 20)
        Me.TxtPdaTname.TabIndex = 6
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 22)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(110, 13)
        Me.Label12.TabIndex = 5
        Me.Label12.Text = "PDAData TableName"
        '
        'GrpMain
        '
        Me.GrpMain.Controls.Add(Me.TxtShortName)
        Me.GrpMain.Controls.Add(Me.TxtName)
        Me.GrpMain.Controls.Add(Me.TxtComment)
        Me.GrpMain.Controls.Add(Me.BtnNameEditor)
        Me.GrpMain.Controls.Add(Me.BtnCommentEditor)
        Me.GrpMain.Controls.Add(Me.Label4)
        Me.GrpMain.Controls.Add(Me.Label2)
        Me.GrpMain.Controls.Add(Me.Label1)
        Me.GrpMain.Location = New System.Drawing.Point(10, 9)
        Me.GrpMain.Name = "GrpMain"
        Me.GrpMain.Size = New System.Drawing.Size(290, 99)
        Me.GrpMain.TabIndex = 0
        Me.GrpMain.TabStop = False
        Me.GrpMain.Text = "Main"
        '
        'BtnNameEditor
        '
        Me.BtnNameEditor.Location = New System.Drawing.Point(248, 43)
        Me.BtnNameEditor.Name = "BtnNameEditor"
        Me.BtnNameEditor.Size = New System.Drawing.Size(36, 20)
        Me.BtnNameEditor.TabIndex = 26
        Me.BtnNameEditor.Text = "..."
        Me.BtnNameEditor.UseVisualStyleBackColor = True
        '
        'BtnCommentEditor
        '
        Me.BtnCommentEditor.Location = New System.Drawing.Point(248, 17)
        Me.BtnCommentEditor.Name = "BtnCommentEditor"
        Me.BtnCommentEditor.Size = New System.Drawing.Size(36, 20)
        Me.BtnCommentEditor.TabIndex = 25
        Me.BtnCommentEditor.Text = "..."
        Me.BtnCommentEditor.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Short Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Comment"
        '
        'ToolTipPrecondition
        '
        Me.ToolTipPrecondition.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTipPrecondition.ToolTipTitle = "Precondition"
        '
        'ToolTipProcedureId
        '
        Me.ToolTipProcedureId.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTipProcedureId.ToolTipTitle = "OnNewRecordProcedureID"
        '
        'ToolTipModifiable
        '
        Me.ToolTipModifiable.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTipModifiable.ToolTipTitle = "Modifiable"
        '
        'ToolTipShortName
        '
        Me.ToolTipShortName.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTipShortName.ToolTipTitle = "Short Name"
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
        Me.TxtComment.Location = New System.Drawing.Point(93, 16)
        Me.TxtComment.Name = "TxtComment"
        Me.TxtComment.Size = New System.Drawing.Size(149, 20)
        Me.TxtComment.TabIndex = 31
        Me.ToolTipComment.SetToolTip(Me.TxtComment, "Type a comment of the object.")
        '
        'TxtName
        '
        Me.TxtName.Location = New System.Drawing.Point(93, 42)
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(149, 20)
        Me.TxtName.TabIndex = 32
        Me.ToolTipName.SetToolTip(Me.TxtName, "Indicates the name of the object.")
        '
        'TxtShortName
        '
        Me.TxtShortName.Location = New System.Drawing.Point(93, 68)
        Me.TxtShortName.Name = "TxtShortName"
        Me.TxtShortName.Size = New System.Drawing.Size(149, 20)
        Me.TxtShortName.TabIndex = 33
        Me.ToolTipShortName.SetToolTip(Me.TxtShortName, "Indicates the short name of the study.")
        '
        'CmbModifiable
        '
        Me.CmbModifiable.FormattingEnabled = True
        Me.CmbModifiable.Items.AddRange(New Object() {"True", "False"})
        Me.CmbModifiable.Location = New System.Drawing.Point(150, 19)
        Me.CmbModifiable.Name = "CmbModifiable"
        Me.CmbModifiable.Size = New System.Drawing.Size(149, 21)
        Me.CmbModifiable.TabIndex = 32
        Me.ToolTipModifiable.SetToolTip(Me.CmbModifiable, "Indicates if the section can be edited or modified.")
        '
        'TxtProcedureID
        '
        Me.TxtProcedureID.Location = New System.Drawing.Point(150, 45)
        Me.TxtProcedureID.Name = "TxtProcedureID"
        Me.TxtProcedureID.Size = New System.Drawing.Size(149, 20)
        Me.TxtProcedureID.TabIndex = 33
        Me.ToolTipProcedureId.SetToolTip(Me.TxtProcedureID, "ID of the procedure to execute when a new record is new.")
        '
        'TxtPrecondition
        '
        Me.TxtPrecondition.Location = New System.Drawing.Point(150, 70)
        Me.TxtPrecondition.Name = "TxtPrecondition"
        Me.TxtPrecondition.Size = New System.Drawing.Size(149, 20)
        Me.TxtPrecondition.TabIndex = 34
        Me.ToolTipPrecondition.SetToolTip(Me.TxtPrecondition, "Indicates the precondition for this questionnaire")
        '
        'FrmSection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(655, 321)
        Me.Controls.Add(Me.PnlInformation)
        Me.Name = "FrmSection"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Section Editor"
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
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents BtnOk As System.Windows.Forms.Button
    Friend WithEvents GrpSystemInformation As System.Windows.Forms.GroupBox
    Friend WithEvents TxtUniqueIdentifier As System.Windows.Forms.TextBox
    Friend WithEvents TxtQuestionnaireSetId As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents GrpServerData As System.Windows.Forms.GroupBox
    Friend WithEvents TxtServerLTname As System.Windows.Forms.TextBox
    Friend WithEvents TxtServerDataTname As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents GrpPdaSettings As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GrpPdaData As System.Windows.Forms.GroupBox
    Friend WithEvents TxtPdaTname As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GrpMain As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtQuestionnaireID As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtSectionID As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents BtnCommentEditor As System.Windows.Forms.Button
    Friend WithEvents BtnNameEditor As System.Windows.Forms.Button
    Friend WithEvents BtnNamePrecondition As System.Windows.Forms.Button
    Friend WithEvents ToolTipPrecondition As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTipProcedureId As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTipModifiable As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTipShortName As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTipName As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTipComment As System.Windows.Forms.ToolTip
    Friend WithEvents TxtComment As System.Windows.Forms.TextBox
    Friend WithEvents TxtName As System.Windows.Forms.TextBox
    Friend WithEvents TxtShortName As System.Windows.Forms.TextBox
    Friend WithEvents CmbModifiable As System.Windows.Forms.ComboBox
    Friend WithEvents TxtProcedureID As System.Windows.Forms.TextBox
    Friend WithEvents TxtPrecondition As System.Windows.Forms.TextBox
End Class

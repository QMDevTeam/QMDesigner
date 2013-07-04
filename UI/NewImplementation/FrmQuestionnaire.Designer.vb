<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmQuestionnaire
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
        Me.ToolTipSecondaryIDField = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTipPrecondition = New System.Windows.Forms.ToolTip(Me.components)
        Me.GrpMain = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BtnCommentEditor = New System.Windows.Forms.Button()
        Me.BtnNameEditor = New System.Windows.Forms.Button()
        Me.GrpPdaData = New System.Windows.Forms.GroupBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TxtPdaTname = New System.Windows.Forms.TextBox()
        Me.GrpInstances = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GrpServerData = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TxtServerDataTname = New System.Windows.Forms.TextBox()
        Me.TxtServerLTname = New System.Windows.Forms.TextBox()
        Me.GrpSystemInformation = New System.Windows.Forms.GroupBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TxtSysInSetId = New System.Windows.Forms.TextBox()
        Me.TxtUniqueIdentifier = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TxtQuestionnaireId = New System.Windows.Forms.TextBox()
        Me.BtnOk = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.GrpMisc = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GrpSettings = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.BtnNamePrecondition = New System.Windows.Forms.Button()
        Me.PnlInformation = New System.Windows.Forms.Panel()
        Me.ToolTipProcedureID = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTipMultipleInstances = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTipInstanceSAIDField = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTipNumeration = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTipShortName = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTipComment = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTipName = New System.Windows.Forms.ToolTip(Me.components)
        Me.TxtComment = New System.Windows.Forms.TextBox()
        Me.TxtName = New System.Windows.Forms.TextBox()
        Me.TxtShortName = New System.Windows.Forms.TextBox()
        Me.CmbNumeration = New System.Windows.Forms.ComboBox()
        Me.TxtIDField = New System.Windows.Forms.TextBox()
        Me.TxtSaidField = New System.Windows.Forms.TextBox()
        Me.CmbInstances = New System.Windows.Forms.ComboBox()
        Me.TxtProcedureID = New System.Windows.Forms.TextBox()
        Me.TxtPrecondition = New System.Windows.Forms.TextBox()
        Me.GrpMain.SuspendLayout()
        Me.GrpPdaData.SuspendLayout()
        Me.GrpInstances.SuspendLayout()
        Me.GrpServerData.SuspendLayout()
        Me.GrpSystemInformation.SuspendLayout()
        Me.GrpMisc.SuspendLayout()
        Me.GrpSettings.SuspendLayout()
        Me.PnlInformation.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolTipSecondaryIDField
        '
        Me.ToolTipSecondaryIDField.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTipSecondaryIDField.ToolTipTitle = "Instance Secondary IDField"
        '
        'ToolTipPrecondition
        '
        Me.ToolTipPrecondition.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTipPrecondition.ToolTipTitle = "Precondition"
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
        Me.GrpMain.Size = New System.Drawing.Size(288, 100)
        Me.GrpMain.TabIndex = 0
        Me.GrpMain.TabStop = False
        Me.GrpMain.Text = "Main"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Comment"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Name"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 75)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Short Name"
        '
        'BtnCommentEditor
        '
        Me.BtnCommentEditor.Location = New System.Drawing.Point(246, 13)
        Me.BtnCommentEditor.Name = "BtnCommentEditor"
        Me.BtnCommentEditor.Size = New System.Drawing.Size(36, 20)
        Me.BtnCommentEditor.TabIndex = 25
        Me.BtnCommentEditor.Text = "..."
        Me.BtnCommentEditor.UseVisualStyleBackColor = True
        '
        'BtnNameEditor
        '
        Me.BtnNameEditor.Location = New System.Drawing.Point(246, 40)
        Me.BtnNameEditor.Name = "BtnNameEditor"
        Me.BtnNameEditor.Size = New System.Drawing.Size(36, 20)
        Me.BtnNameEditor.TabIndex = 26
        Me.BtnNameEditor.Text = "..."
        Me.BtnNameEditor.UseVisualStyleBackColor = True
        '
        'GrpPdaData
        '
        Me.GrpPdaData.Controls.Add(Me.TxtPdaTname)
        Me.GrpPdaData.Controls.Add(Me.Label12)
        Me.GrpPdaData.Location = New System.Drawing.Point(345, 12)
        Me.GrpPdaData.Name = "GrpPdaData"
        Me.GrpPdaData.Size = New System.Drawing.Size(302, 64)
        Me.GrpPdaData.TabIndex = 4
        Me.GrpPdaData.TabStop = False
        Me.GrpPdaData.Text = "PDA Data"
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
        'TxtPdaTname
        '
        Me.TxtPdaTname.Location = New System.Drawing.Point(122, 22)
        Me.TxtPdaTname.Name = "TxtPdaTname"
        Me.TxtPdaTname.Size = New System.Drawing.Size(149, 20)
        Me.TxtPdaTname.TabIndex = 6
        '
        'GrpInstances
        '
        Me.GrpInstances.Controls.Add(Me.TxtProcedureID)
        Me.GrpInstances.Controls.Add(Me.CmbInstances)
        Me.GrpInstances.Controls.Add(Me.TxtSaidField)
        Me.GrpInstances.Controls.Add(Me.TxtIDField)
        Me.GrpInstances.Controls.Add(Me.Label5)
        Me.GrpInstances.Controls.Add(Me.Label6)
        Me.GrpInstances.Controls.Add(Me.Label7)
        Me.GrpInstances.Controls.Add(Me.Label8)
        Me.GrpInstances.Location = New System.Drawing.Point(10, 170)
        Me.GrpInstances.Name = "GrpInstances"
        Me.GrpInstances.Size = New System.Drawing.Size(319, 136)
        Me.GrpInstances.TabIndex = 3
        Me.GrpInstances.TabStop = False
        Me.GrpInstances.Text = "Multiple Instances"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(7, 26)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(138, 13)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Instance Secondary IDField"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(7, 53)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(95, 13)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "InstanceSAIDField"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 82)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(92, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Multiple Instances"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(5, 109)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(150, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "On New Record Procedure ID"
        '
        'GrpServerData
        '
        Me.GrpServerData.Controls.Add(Me.TxtServerLTname)
        Me.GrpServerData.Controls.Add(Me.TxtServerDataTname)
        Me.GrpServerData.Controls.Add(Me.Label10)
        Me.GrpServerData.Controls.Add(Me.Label11)
        Me.GrpServerData.Location = New System.Drawing.Point(345, 136)
        Me.GrpServerData.Name = "GrpServerData"
        Me.GrpServerData.Size = New System.Drawing.Size(302, 90)
        Me.GrpServerData.TabIndex = 6
        Me.GrpServerData.TabStop = False
        Me.GrpServerData.Text = "Server Data"
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
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 53)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(86, 13)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "Log Table Name"
        '
        'TxtServerDataTname
        '
        Me.TxtServerDataTname.Location = New System.Drawing.Point(102, 19)
        Me.TxtServerDataTname.Name = "TxtServerDataTname"
        Me.TxtServerDataTname.Size = New System.Drawing.Size(149, 20)
        Me.TxtServerDataTname.TabIndex = 9
        '
        'TxtServerLTname
        '
        Me.TxtServerLTname.Location = New System.Drawing.Point(102, 45)
        Me.TxtServerLTname.Name = "TxtServerLTname"
        Me.TxtServerLTname.Size = New System.Drawing.Size(149, 20)
        Me.TxtServerLTname.TabIndex = 10
        '
        'GrpSystemInformation
        '
        Me.GrpSystemInformation.Controls.Add(Me.TxtQuestionnaireId)
        Me.GrpSystemInformation.Controls.Add(Me.Label15)
        Me.GrpSystemInformation.Controls.Add(Me.TxtUniqueIdentifier)
        Me.GrpSystemInformation.Controls.Add(Me.TxtSysInSetId)
        Me.GrpSystemInformation.Controls.Add(Me.Label13)
        Me.GrpSystemInformation.Controls.Add(Me.Label14)
        Me.GrpSystemInformation.Location = New System.Drawing.Point(345, 232)
        Me.GrpSystemInformation.Name = "GrpSystemInformation"
        Me.GrpSystemInformation.Size = New System.Drawing.Size(302, 110)
        Me.GrpSystemInformation.TabIndex = 5
        Me.GrpSystemInformation.TabStop = False
        Me.GrpSystemInformation.Text = "SystemInformation"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(7, 59)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(97, 13)
        Me.Label14.TabIndex = 7
        Me.Label14.Text = "QuestionnaireSetId"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(7, 86)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(84, 13)
        Me.Label13.TabIndex = 8
        Me.Label13.Text = "Unique Identifier"
        '
        'TxtSysInSetId
        '
        Me.TxtSysInSetId.Enabled = False
        Me.TxtSysInSetId.Location = New System.Drawing.Point(106, 52)
        Me.TxtSysInSetId.Name = "TxtSysInSetId"
        Me.TxtSysInSetId.Size = New System.Drawing.Size(149, 20)
        Me.TxtSysInSetId.TabIndex = 9
        '
        'TxtUniqueIdentifier
        '
        Me.TxtUniqueIdentifier.Enabled = False
        Me.TxtUniqueIdentifier.Location = New System.Drawing.Point(106, 79)
        Me.TxtUniqueIdentifier.Name = "TxtUniqueIdentifier"
        Me.TxtUniqueIdentifier.Size = New System.Drawing.Size(149, 20)
        Me.TxtUniqueIdentifier.TabIndex = 10
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(8, 31)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(83, 13)
        Me.Label15.TabIndex = 13
        Me.Label15.Text = "QuestionnaireID"
        '
        'TxtQuestionnaireId
        '
        Me.TxtQuestionnaireId.Enabled = False
        Me.TxtQuestionnaireId.Location = New System.Drawing.Point(107, 24)
        Me.TxtQuestionnaireId.Name = "TxtQuestionnaireId"
        Me.TxtQuestionnaireId.Size = New System.Drawing.Size(149, 20)
        Me.TxtQuestionnaireId.TabIndex = 14
        '
        'BtnOk
        '
        Me.BtnOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnOk.Location = New System.Drawing.Point(463, 348)
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.Size = New System.Drawing.Size(75, 23)
        Me.BtnOk.TabIndex = 7
        Me.BtnOk.Text = "&Ok"
        Me.BtnOk.UseVisualStyleBackColor = True
        '
        'BtnCancel
        '
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Location = New System.Drawing.Point(554, 348)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 23)
        Me.BtnCancel.TabIndex = 8
        Me.BtnCancel.Text = "&Cancel"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'GrpMisc
        '
        Me.GrpMisc.Controls.Add(Me.CmbNumeration)
        Me.GrpMisc.Controls.Add(Me.Label3)
        Me.GrpMisc.Location = New System.Drawing.Point(10, 116)
        Me.GrpMisc.Name = "GrpMisc"
        Me.GrpMisc.Size = New System.Drawing.Size(274, 45)
        Me.GrpMisc.TabIndex = 9
        Me.GrpMisc.TabStop = False
        Me.GrpMisc.Text = "Misc"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(117, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Continuous Numeration"
        '
        'GrpSettings
        '
        Me.GrpSettings.Controls.Add(Me.TxtPrecondition)
        Me.GrpSettings.Controls.Add(Me.BtnNamePrecondition)
        Me.GrpSettings.Controls.Add(Me.Label9)
        Me.GrpSettings.Location = New System.Drawing.Point(345, 80)
        Me.GrpSettings.Name = "GrpSettings"
        Me.GrpSettings.Size = New System.Drawing.Size(302, 53)
        Me.GrpSettings.TabIndex = 7
        Me.GrpSettings.TabStop = False
        Me.GrpSettings.Text = "Pda Settings"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 29)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(66, 13)
        Me.Label9.TabIndex = 5
        Me.Label9.Text = "Precondition"
        '
        'BtnNamePrecondition
        '
        Me.BtnNamePrecondition.Location = New System.Drawing.Point(257, 22)
        Me.BtnNamePrecondition.Name = "BtnNamePrecondition"
        Me.BtnNamePrecondition.Size = New System.Drawing.Size(36, 20)
        Me.BtnNamePrecondition.TabIndex = 27
        Me.BtnNamePrecondition.Text = "..."
        Me.BtnNamePrecondition.UseVisualStyleBackColor = True
        '
        'PnlInformation
        '
        Me.PnlInformation.AutoScroll = True
        Me.PnlInformation.Controls.Add(Me.GrpSettings)
        Me.PnlInformation.Controls.Add(Me.GrpMisc)
        Me.PnlInformation.Controls.Add(Me.BtnCancel)
        Me.PnlInformation.Controls.Add(Me.BtnOk)
        Me.PnlInformation.Controls.Add(Me.GrpSystemInformation)
        Me.PnlInformation.Controls.Add(Me.GrpServerData)
        Me.PnlInformation.Controls.Add(Me.GrpInstances)
        Me.PnlInformation.Controls.Add(Me.GrpPdaData)
        Me.PnlInformation.Controls.Add(Me.GrpMain)
        Me.PnlInformation.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlInformation.Location = New System.Drawing.Point(0, 0)
        Me.PnlInformation.Name = "PnlInformation"
        Me.PnlInformation.Size = New System.Drawing.Size(650, 382)
        Me.PnlInformation.TabIndex = 1
        '
        'ToolTipProcedureID
        '
        Me.ToolTipProcedureID.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTipProcedureID.ToolTipTitle = "On New Record Procedure ID"
        '
        'ToolTipMultipleInstances
        '
        Me.ToolTipMultipleInstances.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTipMultipleInstances.ToolTipTitle = "Multiple Instances"
        '
        'ToolTipInstanceSAIDField
        '
        Me.ToolTipInstanceSAIDField.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTipInstanceSAIDField.ToolTipTitle = "InstanceSAIDField"
        '
        'ToolTipNumeration
        '
        Me.ToolTipNumeration.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTipNumeration.ToolTipTitle = "Continuous Information"
        '
        'ToolTipShortName
        '
        Me.ToolTipShortName.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTipShortName.ToolTipTitle = "Short Name"
        '
        'ToolTipComment
        '
        Me.ToolTipComment.AutomaticDelay = 300
        Me.ToolTipComment.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTipComment.ToolTipTitle = "Comment"
        '
        'ToolTipName
        '
        Me.ToolTipName.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTipName.ToolTipTitle = "Name"
        '
        'TxtComment
        '
        Me.TxtComment.Location = New System.Drawing.Point(94, 13)
        Me.TxtComment.Name = "TxtComment"
        Me.TxtComment.Size = New System.Drawing.Size(149, 20)
        Me.TxtComment.TabIndex = 27
        Me.ToolTipComment.SetToolTip(Me.TxtComment, "Type comment of the object")
        '
        'TxtName
        '
        Me.TxtName.Location = New System.Drawing.Point(94, 40)
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(149, 20)
        Me.TxtName.TabIndex = 28
        Me.ToolTipName.SetToolTip(Me.TxtName, "Indicates the name of the object.")
        '
        'TxtShortName
        '
        Me.TxtShortName.Location = New System.Drawing.Point(94, 66)
        Me.TxtShortName.Name = "TxtShortName"
        Me.TxtShortName.Size = New System.Drawing.Size(149, 20)
        Me.TxtShortName.TabIndex = 29
        Me.ToolTipShortName.SetToolTip(Me.TxtShortName, "Indicates the short name of the questionnaire.")
        '
        'CmbNumeration
        '
        Me.CmbNumeration.FormattingEnabled = True
        Me.CmbNumeration.Items.AddRange(New Object() {"True", "False"})
        Me.CmbNumeration.Location = New System.Drawing.Point(137, 12)
        Me.CmbNumeration.Name = "CmbNumeration"
        Me.CmbNumeration.Size = New System.Drawing.Size(121, 21)
        Me.CmbNumeration.TabIndex = 10
        Me.ToolTipNumeration.SetToolTip(Me.CmbNumeration, "True if the number of the questions continues from section to section")
        '
        'TxtIDField
        '
        Me.TxtIDField.Location = New System.Drawing.Point(161, 20)
        Me.TxtIDField.Name = "TxtIDField"
        Me.TxtIDField.Size = New System.Drawing.Size(149, 20)
        Me.TxtIDField.TabIndex = 16
        Me.ToolTipSecondaryIDField.SetToolTip(Me.TxtIDField, "Sets/Gets the instance SecondaryIDField.")
        '
        'TxtSaidField
        '
        Me.TxtSaidField.Location = New System.Drawing.Point(161, 46)
        Me.TxtSaidField.Name = "TxtSaidField"
        Me.TxtSaidField.Size = New System.Drawing.Size(149, 20)
        Me.TxtSaidField.TabIndex = 17
        Me.ToolTipInstanceSAIDField.SetToolTip(Me.TxtSaidField, "Sets/Gets the instanceSAIDField.")
        '
        'CmbInstances
        '
        Me.CmbInstances.FormattingEnabled = True
        Me.CmbInstances.Items.AddRange(New Object() {"True", "False"})
        Me.CmbInstances.Location = New System.Drawing.Point(161, 72)
        Me.CmbInstances.Name = "CmbInstances"
        Me.CmbInstances.Size = New System.Drawing.Size(149, 21)
        Me.CmbInstances.TabIndex = 18
        Me.ToolTipMultipleInstances.SetToolTip(Me.CmbInstances, "True if the questionnaire can be answered multiple times by one subject.")
        '
        'TxtProcedureID
        '
        Me.TxtProcedureID.Location = New System.Drawing.Point(161, 99)
        Me.TxtProcedureID.Name = "TxtProcedureID"
        Me.TxtProcedureID.Size = New System.Drawing.Size(149, 20)
        Me.TxtProcedureID.TabIndex = 19
        Me.ToolTipProcedureID.SetToolTip(Me.TxtProcedureID, "Sets/Gets the OnNewRecordProcedureID.")
        '
        'TxtPrecondition
        '
        Me.TxtPrecondition.Location = New System.Drawing.Point(92, 22)
        Me.TxtPrecondition.Name = "TxtPrecondition"
        Me.TxtPrecondition.Size = New System.Drawing.Size(149, 20)
        Me.TxtPrecondition.TabIndex = 28
        Me.ToolTipPrecondition.SetToolTip(Me.TxtPrecondition, "Sets the condition to set the questionnaire available.")
        '
        'FrmQuestionnaire
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(650, 382)
        Me.Controls.Add(Me.PnlInformation)
        Me.Name = "FrmQuestionnaire"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Questionnaire Editor"
        Me.GrpMain.ResumeLayout(False)
        Me.GrpMain.PerformLayout()
        Me.GrpPdaData.ResumeLayout(False)
        Me.GrpPdaData.PerformLayout()
        Me.GrpInstances.ResumeLayout(False)
        Me.GrpInstances.PerformLayout()
        Me.GrpServerData.ResumeLayout(False)
        Me.GrpServerData.PerformLayout()
        Me.GrpSystemInformation.ResumeLayout(False)
        Me.GrpSystemInformation.PerformLayout()
        Me.GrpMisc.ResumeLayout(False)
        Me.GrpMisc.PerformLayout()
        Me.GrpSettings.ResumeLayout(False)
        Me.GrpSettings.PerformLayout()
        Me.PnlInformation.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolTipSecondaryIDField As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTipPrecondition As System.Windows.Forms.ToolTip
    Friend WithEvents GrpMain As System.Windows.Forms.GroupBox
    Friend WithEvents BtnNameEditor As System.Windows.Forms.Button
    Friend WithEvents BtnCommentEditor As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GrpPdaData As System.Windows.Forms.GroupBox
    Friend WithEvents TxtPdaTname As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GrpInstances As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GrpServerData As System.Windows.Forms.GroupBox
    Friend WithEvents TxtServerLTname As System.Windows.Forms.TextBox
    Friend WithEvents TxtServerDataTname As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents GrpSystemInformation As System.Windows.Forms.GroupBox
    Friend WithEvents TxtQuestionnaireId As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TxtUniqueIdentifier As System.Windows.Forms.TextBox
    Friend WithEvents TxtSysInSetId As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents BtnOk As System.Windows.Forms.Button
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents GrpMisc As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GrpSettings As System.Windows.Forms.GroupBox
    Friend WithEvents BtnNamePrecondition As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents PnlInformation As System.Windows.Forms.Panel
    Friend WithEvents ToolTipProcedureID As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTipMultipleInstances As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTipInstanceSAIDField As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTipNumeration As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTipShortName As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTipComment As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTipName As System.Windows.Forms.ToolTip
    Friend WithEvents TxtComment As System.Windows.Forms.TextBox
    Friend WithEvents TxtName As System.Windows.Forms.TextBox
    Friend WithEvents TxtShortName As System.Windows.Forms.TextBox
    Friend WithEvents CmbNumeration As System.Windows.Forms.ComboBox
    Friend WithEvents TxtIDField As System.Windows.Forms.TextBox
    Friend WithEvents TxtSaidField As System.Windows.Forms.TextBox
    Friend WithEvents CmbInstances As System.Windows.Forms.ComboBox
    Friend WithEvents TxtProcedureID As System.Windows.Forms.TextBox
    Friend WithEvents TxtPrecondition As System.Windows.Forms.TextBox
End Class

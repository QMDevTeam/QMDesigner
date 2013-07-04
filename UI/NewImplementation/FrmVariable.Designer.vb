<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmVariable
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
        Me.TxtUniqueIdentifier = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.GrpServerData = New System.Windows.Forms.GroupBox()
        Me.TxtPdaDataTname = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GrpPdaSettings = New System.Windows.Forms.GroupBox()
        Me.TxtMinimum = New System.Windows.Forms.TextBox()
        Me.TxtUnder = New System.Windows.Forms.TextBox()
        Me.TxtOver = New System.Windows.Forms.TextBox()
        Me.TxtMaximum = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GrpPdaData = New System.Windows.Forms.GroupBox()
        Me.TxtScope = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GrpMain = New System.Windows.Forms.GroupBox()
        Me.BtnMainText = New System.Windows.Forms.Button()
        Me.BtnCommentEditor = New System.Windows.Forms.Button()
        Me.CmbDataType = New System.Windows.Forms.ComboBox()
        Me.TxtVariableName = New System.Windows.Forms.TextBox()
        Me.TxtMainText = New System.Windows.Forms.TextBox()
        Me.TxtComment = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolTipComment = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTipDataType = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTipMainText = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTipVariableName = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTipMaximum = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTipMinimum = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTipOver = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTipUnder = New System.Windows.Forms.ToolTip(Me.components)
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
        Me.PnlInformation.Size = New System.Drawing.Size(617, 319)
        Me.PnlInformation.TabIndex = 1
        '
        'BtnCancel
        '
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Location = New System.Drawing.Point(455, 284)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 23)
        Me.BtnCancel.TabIndex = 8
        Me.BtnCancel.Text = "&Cancel"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'BtnOk
        '
        Me.BtnOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnOk.Location = New System.Drawing.Point(374, 284)
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.Size = New System.Drawing.Size(75, 23)
        Me.BtnOk.TabIndex = 7
        Me.BtnOk.Text = "&Ok"
        Me.BtnOk.UseVisualStyleBackColor = True
        '
        'GrpSystemInformation
        '
        Me.GrpSystemInformation.Controls.Add(Me.TxtUniqueIdentifier)
        Me.GrpSystemInformation.Controls.Add(Me.Label14)
        Me.GrpSystemInformation.Location = New System.Drawing.Point(321, 165)
        Me.GrpSystemInformation.Name = "GrpSystemInformation"
        Me.GrpSystemInformation.Size = New System.Drawing.Size(284, 64)
        Me.GrpSystemInformation.TabIndex = 5
        Me.GrpSystemInformation.TabStop = False
        Me.GrpSystemInformation.Text = "SystemInformation"
        '
        'TxtUniqueIdentifier
        '
        Me.TxtUniqueIdentifier.Enabled = False
        Me.TxtUniqueIdentifier.Location = New System.Drawing.Point(122, 24)
        Me.TxtUniqueIdentifier.Name = "TxtUniqueIdentifier"
        Me.TxtUniqueIdentifier.Size = New System.Drawing.Size(149, 20)
        Me.TxtUniqueIdentifier.TabIndex = 9
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 27)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(84, 13)
        Me.Label14.TabIndex = 7
        Me.Label14.Text = "Unique Identifier"
        '
        'GrpServerData
        '
        Me.GrpServerData.Controls.Add(Me.TxtPdaDataTname)
        Me.GrpServerData.Controls.Add(Me.Label11)
        Me.GrpServerData.Location = New System.Drawing.Point(321, 83)
        Me.GrpServerData.Name = "GrpServerData"
        Me.GrpServerData.Size = New System.Drawing.Size(284, 66)
        Me.GrpServerData.TabIndex = 6
        Me.GrpServerData.TabStop = False
        Me.GrpServerData.Text = "PDA Data"
        '
        'TxtPdaDataTname
        '
        Me.TxtPdaDataTname.Enabled = False
        Me.TxtPdaDataTname.Location = New System.Drawing.Point(122, 26)
        Me.TxtPdaDataTname.Name = "TxtPdaDataTname"
        Me.TxtPdaDataTname.Size = New System.Drawing.Size(149, 20)
        Me.TxtPdaDataTname.TabIndex = 9
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 33)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(110, 13)
        Me.Label11.TabIndex = 7
        Me.Label11.Text = "PDAData TableName"
        '
        'GrpPdaSettings
        '
        Me.GrpPdaSettings.Controls.Add(Me.TxtMinimum)
        Me.GrpPdaSettings.Controls.Add(Me.TxtUnder)
        Me.GrpPdaSettings.Controls.Add(Me.TxtOver)
        Me.GrpPdaSettings.Controls.Add(Me.TxtMaximum)
        Me.GrpPdaSettings.Controls.Add(Me.Label5)
        Me.GrpPdaSettings.Controls.Add(Me.Label6)
        Me.GrpPdaSettings.Controls.Add(Me.Label7)
        Me.GrpPdaSettings.Controls.Add(Me.Label8)
        Me.GrpPdaSettings.Location = New System.Drawing.Point(10, 139)
        Me.GrpPdaSettings.Name = "GrpPdaSettings"
        Me.GrpPdaSettings.Size = New System.Drawing.Size(290, 136)
        Me.GrpPdaSettings.TabIndex = 3
        Me.GrpPdaSettings.TabStop = False
        Me.GrpPdaSettings.Text = "Data variable ranges"
        '
        'TxtMinimum
        '
        Me.TxtMinimum.Location = New System.Drawing.Point(104, 46)
        Me.TxtMinimum.Name = "TxtMinimum"
        Me.TxtMinimum.Size = New System.Drawing.Size(149, 20)
        Me.TxtMinimum.TabIndex = 15
        Me.ToolTipMinimum.SetToolTip(Me.TxtMinimum, "The minimum value assignable to the variable.")
        '
        'TxtUnder
        '
        Me.TxtUnder.Location = New System.Drawing.Point(104, 97)
        Me.TxtUnder.Name = "TxtUnder"
        Me.TxtUnder.Size = New System.Drawing.Size(149, 20)
        Me.TxtUnder.TabIndex = 14
        Me.ToolTipUnder.SetToolTip(Me.TxtUnder, "The minimum value that is common, outside of this range the value needs confirmat" & _
        "ion.")
        '
        'TxtOver
        '
        Me.TxtOver.Location = New System.Drawing.Point(104, 70)
        Me.TxtOver.Name = "TxtOver"
        Me.TxtOver.Size = New System.Drawing.Size(149, 20)
        Me.TxtOver.TabIndex = 13
        Me.ToolTipOver.SetToolTip(Me.TxtOver, "The maximum value that is common, outside of this range the value needs confirmat" & _
        "ion.")
        '
        'TxtMaximum
        '
        Me.TxtMaximum.Location = New System.Drawing.Point(104, 19)
        Me.TxtMaximum.Name = "TxtMaximum"
        Me.TxtMaximum.Size = New System.Drawing.Size(149, 20)
        Me.TxtMaximum.TabIndex = 12
        Me.ToolTipMaximum.SetToolTip(Me.TxtMaximum, "The maximum value assignable to the variable.")
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 104)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Prompt Under"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 77)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Prompt Over"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(7, 53)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(92, 13)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Absolute Minimum"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(7, 26)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(95, 13)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Absolute Maximum"
        '
        'GrpPdaData
        '
        Me.GrpPdaData.Controls.Add(Me.TxtScope)
        Me.GrpPdaData.Controls.Add(Me.Label12)
        Me.GrpPdaData.Location = New System.Drawing.Point(321, 9)
        Me.GrpPdaData.Name = "GrpPdaData"
        Me.GrpPdaData.Size = New System.Drawing.Size(284, 64)
        Me.GrpPdaData.TabIndex = 4
        Me.GrpPdaData.TabStop = False
        Me.GrpPdaData.Text = "Misc"
        '
        'TxtScope
        '
        Me.TxtScope.Enabled = False
        Me.TxtScope.Location = New System.Drawing.Point(122, 22)
        Me.TxtScope.Name = "TxtScope"
        Me.TxtScope.Size = New System.Drawing.Size(149, 20)
        Me.TxtScope.TabIndex = 6
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 29)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(77, 13)
        Me.Label12.TabIndex = 5
        Me.Label12.Text = "Variable scope"
        '
        'GrpMain
        '
        Me.GrpMain.Controls.Add(Me.BtnMainText)
        Me.GrpMain.Controls.Add(Me.BtnCommentEditor)
        Me.GrpMain.Controls.Add(Me.CmbDataType)
        Me.GrpMain.Controls.Add(Me.TxtVariableName)
        Me.GrpMain.Controls.Add(Me.TxtMainText)
        Me.GrpMain.Controls.Add(Me.TxtComment)
        Me.GrpMain.Controls.Add(Me.Label4)
        Me.GrpMain.Controls.Add(Me.Label3)
        Me.GrpMain.Controls.Add(Me.Label2)
        Me.GrpMain.Controls.Add(Me.Label1)
        Me.GrpMain.Location = New System.Drawing.Point(10, 9)
        Me.GrpMain.Name = "GrpMain"
        Me.GrpMain.Size = New System.Drawing.Size(290, 124)
        Me.GrpMain.TabIndex = 0
        Me.GrpMain.TabStop = False
        Me.GrpMain.Text = "Main"
        '
        'BtnMainText
        '
        Me.BtnMainText.Location = New System.Drawing.Point(249, 68)
        Me.BtnMainText.Name = "BtnMainText"
        Me.BtnMainText.Size = New System.Drawing.Size(36, 20)
        Me.BtnMainText.TabIndex = 27
        Me.BtnMainText.Text = "..."
        Me.BtnMainText.UseVisualStyleBackColor = True
        '
        'BtnCommentEditor
        '
        Me.BtnCommentEditor.Location = New System.Drawing.Point(249, 15)
        Me.BtnCommentEditor.Name = "BtnCommentEditor"
        Me.BtnCommentEditor.Size = New System.Drawing.Size(36, 20)
        Me.BtnCommentEditor.TabIndex = 26
        Me.BtnCommentEditor.Text = "..."
        Me.BtnCommentEditor.UseVisualStyleBackColor = True
        '
        'CmbDataType
        '
        Me.CmbDataType.FormattingEnabled = True
        Me.CmbDataType.Location = New System.Drawing.Point(94, 41)
        Me.CmbDataType.Name = "CmbDataType"
        Me.CmbDataType.Size = New System.Drawing.Size(149, 21)
        Me.CmbDataType.TabIndex = 8
        Me.ToolTipDataType.SetToolTip(Me.CmbDataType, "The data type of the variable.")
        '
        'TxtVariableName
        '
        Me.TxtVariableName.Location = New System.Drawing.Point(94, 95)
        Me.TxtVariableName.Name = "TxtVariableName"
        Me.TxtVariableName.Size = New System.Drawing.Size(149, 20)
        Me.TxtVariableName.TabIndex = 7
        Me.ToolTipVariableName.SetToolTip(Me.TxtVariableName, "The name of the variable.")
        '
        'TxtMainText
        '
        Me.TxtMainText.Location = New System.Drawing.Point(94, 68)
        Me.TxtMainText.Name = "TxtMainText"
        Me.TxtMainText.Size = New System.Drawing.Size(149, 20)
        Me.TxtMainText.TabIndex = 6
        Me.ToolTipMainText.SetToolTip(Me.TxtMainText, "What the variable is used for in a few words")
        '
        'TxtComment
        '
        Me.TxtComment.Location = New System.Drawing.Point(94, 15)
        Me.TxtComment.Name = "TxtComment"
        Me.TxtComment.Size = New System.Drawing.Size(149, 20)
        Me.TxtComment.TabIndex = 4
        Me.ToolTipComment.SetToolTip(Me.TxtComment, "Type a comment of the object.")
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 102)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Variable Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Main Text"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Data Type"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Comment"
        '
        'ToolTipComment
        '
        Me.ToolTipComment.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTipComment.ToolTipTitle = "Comment"
        '
        'ToolTipDataType
        '
        Me.ToolTipDataType.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTipDataType.ToolTipTitle = "Data Type"
        '
        'ToolTipMainText
        '
        Me.ToolTipMainText.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTipMainText.ToolTipTitle = "Main Text"
        '
        'ToolTipVariableName
        '
        Me.ToolTipVariableName.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTipVariableName.ToolTipTitle = "Variable Name"
        '
        'ToolTipMaximum
        '
        Me.ToolTipMaximum.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTipMaximum.ToolTipTitle = "Absolute Maximum"
        '
        'ToolTipMinimum
        '
        Me.ToolTipMinimum.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTipMinimum.ToolTipTitle = "Absolute Minimum"
        '
        'ToolTipOver
        '
        Me.ToolTipOver.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTipOver.ToolTipTitle = "Prompt Over"
        '
        'ToolTipUnder
        '
        Me.ToolTipUnder.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTipUnder.ToolTipTitle = "Prompt Under"
        '
        'FrmVariable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(617, 319)
        Me.Controls.Add(Me.PnlInformation)
        Me.Name = "FrmVariable"
        Me.Text = "FrmVariable"
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
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents GrpServerData As System.Windows.Forms.GroupBox
    Friend WithEvents TxtPdaDataTname As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents GrpPdaSettings As System.Windows.Forms.GroupBox
    Friend WithEvents TxtMinimum As System.Windows.Forms.TextBox
    Friend WithEvents TxtUnder As System.Windows.Forms.TextBox
    Friend WithEvents TxtOver As System.Windows.Forms.TextBox
    Friend WithEvents TxtMaximum As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GrpPdaData As System.Windows.Forms.GroupBox
    Friend WithEvents TxtScope As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GrpMain As System.Windows.Forms.GroupBox
    Friend WithEvents TxtVariableName As System.Windows.Forms.TextBox
    Friend WithEvents TxtMainText As System.Windows.Forms.TextBox
    Friend WithEvents TxtComment As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CmbDataType As System.Windows.Forms.ComboBox
    Friend WithEvents BtnCommentEditor As System.Windows.Forms.Button
    Friend WithEvents BtnMainText As System.Windows.Forms.Button
    Friend WithEvents ToolTipComment As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTipDataType As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTipMainText As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTipVariableName As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTipMaximum As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTipMinimum As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTipOver As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTipUnder As System.Windows.Forms.ToolTip
End Class

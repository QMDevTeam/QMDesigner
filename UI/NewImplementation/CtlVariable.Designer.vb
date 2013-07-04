<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CtlVariable
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
        Me.PnlInformation = New System.Windows.Forms.Panel()
        Me.TxtUnder = New System.Windows.Forms.TextBox()
        Me.TxtOver = New System.Windows.Forms.TextBox()
        Me.TxtMinimum = New System.Windows.Forms.TextBox()
        Me.TxtMaximum = New System.Windows.Forms.TextBox()
        Me.TxtVariableName = New System.Windows.Forms.TextBox()
        Me.TxtMainText = New System.Windows.Forms.TextBox()
        Me.CmbDataType = New System.Windows.Forms.ComboBox()
        Me.TxtComment = New System.Windows.Forms.TextBox()
        Me.BtnMainText = New System.Windows.Forms.Button()
        Me.BtnCommentEditor = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TxtUniqueIdentifier = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TxtPdaDataTname = New System.Windows.Forms.TextBox()
        Me.TxtScope = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolTipUnder = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTipOver = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTipMinimum = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTipMaximum = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTipVariableName = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTipMainText = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTipDataType = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTipComment = New System.Windows.Forms.ToolTip(Me.components)
        Me.PnlInformation.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnlInformation
        '
        Me.PnlInformation.AutoScroll = True
        Me.PnlInformation.Controls.Add(Me.TxtUnder)
        Me.PnlInformation.Controls.Add(Me.TxtOver)
        Me.PnlInformation.Controls.Add(Me.TxtMinimum)
        Me.PnlInformation.Controls.Add(Me.TxtMaximum)
        Me.PnlInformation.Controls.Add(Me.TxtVariableName)
        Me.PnlInformation.Controls.Add(Me.TxtMainText)
        Me.PnlInformation.Controls.Add(Me.CmbDataType)
        Me.PnlInformation.Controls.Add(Me.TxtComment)
        Me.PnlInformation.Controls.Add(Me.BtnMainText)
        Me.PnlInformation.Controls.Add(Me.BtnCommentEditor)
        Me.PnlInformation.Controls.Add(Me.Label16)
        Me.PnlInformation.Controls.Add(Me.TxtUniqueIdentifier)
        Me.PnlInformation.Controls.Add(Me.Label15)
        Me.PnlInformation.Controls.Add(Me.Label14)
        Me.PnlInformation.Controls.Add(Me.TxtPdaDataTname)
        Me.PnlInformation.Controls.Add(Me.TxtScope)
        Me.PnlInformation.Controls.Add(Me.Label11)
        Me.PnlInformation.Controls.Add(Me.Label13)
        Me.PnlInformation.Controls.Add(Me.Label12)
        Me.PnlInformation.Controls.Add(Me.Label10)
        Me.PnlInformation.Controls.Add(Me.Label9)
        Me.PnlInformation.Controls.Add(Me.Label5)
        Me.PnlInformation.Controls.Add(Me.Label6)
        Me.PnlInformation.Controls.Add(Me.Label7)
        Me.PnlInformation.Controls.Add(Me.Label8)
        Me.PnlInformation.Controls.Add(Me.Label4)
        Me.PnlInformation.Controls.Add(Me.Label3)
        Me.PnlInformation.Controls.Add(Me.Label2)
        Me.PnlInformation.Controls.Add(Me.Label1)
        Me.PnlInformation.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlInformation.Location = New System.Drawing.Point(0, 0)
        Me.PnlInformation.Name = "PnlInformation"
        Me.PnlInformation.Size = New System.Drawing.Size(338, 420)
        Me.PnlInformation.TabIndex = 2
        '
        'TxtUnder
        '
        Me.TxtUnder.Location = New System.Drawing.Point(114, 235)
        Me.TxtUnder.Name = "TxtUnder"
        Me.TxtUnder.Size = New System.Drawing.Size(149, 20)
        Me.TxtUnder.TabIndex = 34
        Me.ToolTipUnder.SetToolTip(Me.TxtUnder, "The minimum value that is common, outside of this range the value needs confirmat" & _
        "ion.")
        '
        'TxtOver
        '
        Me.TxtOver.Location = New System.Drawing.Point(114, 209)
        Me.TxtOver.Name = "TxtOver"
        Me.TxtOver.Size = New System.Drawing.Size(149, 20)
        Me.TxtOver.TabIndex = 33
        Me.ToolTipOver.SetToolTip(Me.TxtOver, "The maximum value that is common, outside of this range the value needs confirmat" & _
        "ion.")
        '
        'TxtMinimum
        '
        Me.TxtMinimum.Location = New System.Drawing.Point(114, 185)
        Me.TxtMinimum.Name = "TxtMinimum"
        Me.TxtMinimum.Size = New System.Drawing.Size(149, 20)
        Me.TxtMinimum.TabIndex = 32
        Me.ToolTipMinimum.SetToolTip(Me.TxtMinimum, "The minimum value assignable to the variable.")
        '
        'TxtMaximum
        '
        Me.TxtMaximum.Location = New System.Drawing.Point(114, 158)
        Me.TxtMaximum.Name = "TxtMaximum"
        Me.TxtMaximum.Size = New System.Drawing.Size(149, 20)
        Me.TxtMaximum.TabIndex = 31
        Me.ToolTipMaximum.SetToolTip(Me.TxtMaximum, "The maximum value assignable to the variable.")
        '
        'TxtVariableName
        '
        Me.TxtVariableName.Location = New System.Drawing.Point(103, 104)
        Me.TxtVariableName.Name = "TxtVariableName"
        Me.TxtVariableName.Size = New System.Drawing.Size(149, 20)
        Me.TxtVariableName.TabIndex = 30
        Me.ToolTipVariableName.SetToolTip(Me.TxtVariableName, "The name of the variable.")
        '
        'TxtMainText
        '
        Me.TxtMainText.Location = New System.Drawing.Point(103, 77)
        Me.TxtMainText.Name = "TxtMainText"
        Me.TxtMainText.Size = New System.Drawing.Size(149, 20)
        Me.TxtMainText.TabIndex = 29
        Me.ToolTipMainText.SetToolTip(Me.TxtMainText, "What the variable is used for in a few words")
        '
        'CmbDataType
        '
        Me.CmbDataType.FormattingEnabled = True
        Me.CmbDataType.Location = New System.Drawing.Point(103, 50)
        Me.CmbDataType.Name = "CmbDataType"
        Me.CmbDataType.Size = New System.Drawing.Size(149, 21)
        Me.CmbDataType.TabIndex = 28
        Me.ToolTipDataType.SetToolTip(Me.CmbDataType, "The data type of the variable.")
        '
        'TxtComment
        '
        Me.TxtComment.Location = New System.Drawing.Point(103, 24)
        Me.TxtComment.Name = "TxtComment"
        Me.TxtComment.Size = New System.Drawing.Size(149, 20)
        Me.TxtComment.TabIndex = 27
        Me.ToolTipComment.SetToolTip(Me.TxtComment, "Type a comment of the object.")
        '
        'BtnMainText
        '
        Me.BtnMainText.Location = New System.Drawing.Point(258, 77)
        Me.BtnMainText.Name = "BtnMainText"
        Me.BtnMainText.Size = New System.Drawing.Size(36, 20)
        Me.BtnMainText.TabIndex = 26
        Me.BtnMainText.Text = "..."
        Me.BtnMainText.UseVisualStyleBackColor = True
        '
        'BtnCommentEditor
        '
        Me.BtnCommentEditor.Location = New System.Drawing.Point(258, 24)
        Me.BtnCommentEditor.Name = "BtnCommentEditor"
        Me.BtnCommentEditor.Size = New System.Drawing.Size(36, 20)
        Me.BtnCommentEditor.TabIndex = 25
        Me.BtnCommentEditor.Text = "..."
        Me.BtnCommentEditor.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(17, 373)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(130, 15)
        Me.Label16.TabIndex = 18
        Me.Label16.Text = "System Information"
        '
        'TxtUniqueIdentifier
        '
        Me.TxtUniqueIdentifier.Enabled = False
        Me.TxtUniqueIdentifier.Location = New System.Drawing.Point(133, 391)
        Me.TxtUniqueIdentifier.Name = "TxtUniqueIdentifier"
        Me.TxtUniqueIdentifier.Size = New System.Drawing.Size(149, 20)
        Me.TxtUniqueIdentifier.TabIndex = 9
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(17, 318)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(68, 15)
        Me.Label15.TabIndex = 17
        Me.Label15.Text = "PDA Data"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(17, 394)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(84, 13)
        Me.Label14.TabIndex = 7
        Me.Label14.Text = "Unique Identifier"
        '
        'TxtPdaDataTname
        '
        Me.TxtPdaDataTname.Enabled = False
        Me.TxtPdaDataTname.Location = New System.Drawing.Point(133, 341)
        Me.TxtPdaDataTname.Name = "TxtPdaDataTname"
        Me.TxtPdaDataTname.Size = New System.Drawing.Size(149, 20)
        Me.TxtPdaDataTname.TabIndex = 9
        '
        'TxtScope
        '
        Me.TxtScope.Enabled = False
        Me.TxtScope.Location = New System.Drawing.Point(133, 287)
        Me.TxtScope.Name = "TxtScope"
        Me.TxtScope.Size = New System.Drawing.Size(149, 20)
        Me.TxtScope.TabIndex = 6
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(17, 348)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(110, 13)
        Me.Label11.TabIndex = 7
        Me.Label11.Text = "PDAData TableName"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(17, 269)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(37, 15)
        Me.Label13.TabIndex = 16
        Me.Label13.Text = "Misc"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(17, 294)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(77, 13)
        Me.Label12.TabIndex = 5
        Me.Label12.Text = "Variable scope"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(15, 134)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(140, 15)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "Data variable ranges"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(17, 9)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(39, 15)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Main"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 243)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Prompt Under"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 216)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Prompt Over"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(17, 192)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(92, 13)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Absolute Minimum"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(17, 165)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(95, 13)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Absolute Maximum"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 111)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Variable Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Main Text"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Data Type"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Comment"
        '
        'ToolTipUnder
        '
        Me.ToolTipUnder.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTipUnder.ToolTipTitle = "Prompt Under"
        '
        'ToolTipOver
        '
        Me.ToolTipOver.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTipOver.ToolTipTitle = "Prompt Over"
        '
        'ToolTipMinimum
        '
        Me.ToolTipMinimum.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTipMinimum.ToolTipTitle = "Absolute Minimum"
        '
        'ToolTipMaximum
        '
        Me.ToolTipMaximum.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTipMaximum.ToolTipTitle = "Absolute Maximum"
        '
        'ToolTipVariableName
        '
        Me.ToolTipVariableName.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTipVariableName.ToolTipTitle = "Variable Name"
        '
        'ToolTipMainText
        '
        Me.ToolTipMainText.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTipMainText.ToolTipTitle = "Main Text"
        '
        'ToolTipDataType
        '
        Me.ToolTipDataType.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTipDataType.ToolTipTitle = "Data Type"
        '
        'ToolTipComment
        '
        Me.ToolTipComment.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTipComment.ToolTipTitle = "Comment"
        '
        'CtlVariable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PnlInformation)
        Me.Name = "CtlVariable"
        Me.Size = New System.Drawing.Size(338, 420)
        Me.PnlInformation.ResumeLayout(False)
        Me.PnlInformation.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnlInformation As System.Windows.Forms.Panel
    Friend WithEvents TxtUniqueIdentifier As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TxtPdaDataTname As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtScope As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents BtnCommentEditor As System.Windows.Forms.Button
    Friend WithEvents BtnMainText As System.Windows.Forms.Button
    Friend WithEvents ToolTipUnder As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTipOver As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTipMinimum As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTipMaximum As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTipVariableName As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTipMainText As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTipDataType As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTipComment As System.Windows.Forms.ToolTip
    Friend WithEvents TxtComment As System.Windows.Forms.TextBox
    Friend WithEvents CmbDataType As System.Windows.Forms.ComboBox
    Friend WithEvents TxtMainText As System.Windows.Forms.TextBox
    Friend WithEvents TxtVariableName As System.Windows.Forms.TextBox
    Friend WithEvents TxtMaximum As System.Windows.Forms.TextBox
    Friend WithEvents TxtMinimum As System.Windows.Forms.TextBox
    Friend WithEvents TxtOver As System.Windows.Forms.TextBox
    Friend WithEvents TxtUnder As System.Windows.Forms.TextBox

End Class

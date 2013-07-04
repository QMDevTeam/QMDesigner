<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPropertyInformation
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
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.BtnOnUnload = New System.Windows.Forms.Button()
        Me.BtnOnLoad = New System.Windows.Forms.Button()
        Me.TxtOnUnload = New System.Windows.Forms.TextBox()
        Me.TxtOnLoad = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.CmbVisible = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CmbHideNext = New System.Windows.Forms.ComboBox()
        Me.CmbHideBack = New System.Windows.Forms.ComboBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.GrbSysInfo = New System.Windows.Forms.GroupBox()
        Me.LblUniqueID = New System.Windows.Forms.Label()
        Me.LblSectionID = New System.Windows.Forms.Label()
        Me.LblQuesSetID = New System.Windows.Forms.Label()
        Me.LblQuesID = New System.Windows.Forms.Label()
        Me.LblTitle4 = New System.Windows.Forms.Label()
        Me.LblTitle3 = New System.Windows.Forms.Label()
        Me.LblTitle2 = New System.Windows.Forms.Label()
        Me.LblTitle1 = New System.Windows.Forms.Label()
        Me.BtnCancelar = New System.Windows.Forms.Button()
        Me.BtnGuardar = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GrbMain.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
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
        Me.GrbMain.TabIndex = 2
        Me.GrbMain.TabStop = False
        Me.GrbMain.Text = "MAIN"
        '
        'BtnComment
        '
        Me.BtnComment.Location = New System.Drawing.Point(249, 78)
        Me.BtnComment.Name = "BtnComment"
        Me.BtnComment.Size = New System.Drawing.Size(35, 23)
        Me.BtnComment.TabIndex = 8
        Me.BtnComment.Text = "..."
        Me.BtnComment.UseVisualStyleBackColor = True
        '
        'BtnName
        '
        Me.BtnName.Location = New System.Drawing.Point(249, 21)
        Me.BtnName.Name = "BtnName"
        Me.BtnName.Size = New System.Drawing.Size(35, 23)
        Me.BtnName.TabIndex = 6
        Me.BtnName.Text = "..."
        Me.BtnName.UseVisualStyleBackColor = True
        '
        'BtnMainText
        '
        Me.BtnMainText.Location = New System.Drawing.Point(249, 49)
        Me.BtnMainText.Name = "BtnMainText"
        Me.BtnMainText.Size = New System.Drawing.Size(35, 23)
        Me.BtnMainText.TabIndex = 7
        Me.BtnMainText.Text = "..."
        Me.BtnMainText.UseVisualStyleBackColor = True
        '
        'TxtComment
        '
        Me.TxtComment.Location = New System.Drawing.Point(101, 79)
        Me.TxtComment.Name = "TxtComment"
        Me.TxtComment.Size = New System.Drawing.Size(152, 23)
        Me.TxtComment.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.TxtComment, "Type a comment of the object.")
        '
        'TxtMainText
        '
        Me.TxtMainText.Location = New System.Drawing.Point(101, 50)
        Me.TxtMainText.Name = "TxtMainText"
        Me.TxtMainText.Size = New System.Drawing.Size(152, 23)
        Me.TxtMainText.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.TxtMainText, "The question to be displayed.")
        '
        'TxtName
        '
        Me.TxtName.Location = New System.Drawing.Point(101, 21)
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(152, 23)
        Me.TxtName.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.TxtName, "Indicates the name of the object.")
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
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.BtnOnUnload)
        Me.GroupBox4.Controls.Add(Me.BtnOnLoad)
        Me.GroupBox4.Controls.Add(Me.TxtOnUnload)
        Me.GroupBox4.Controls.Add(Me.TxtOnLoad)
        Me.GroupBox4.Controls.Add(Me.Label16)
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(12, 131)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GroupBox4.Size = New System.Drawing.Size(318, 89)
        Me.GroupBox4.TabIndex = 6
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "PDA Actions"
        '
        'BtnOnUnload
        '
        Me.BtnOnUnload.Location = New System.Drawing.Point(249, 47)
        Me.BtnOnUnload.Name = "BtnOnUnload"
        Me.BtnOnUnload.Size = New System.Drawing.Size(35, 23)
        Me.BtnOnUnload.TabIndex = 22
        Me.BtnOnUnload.Text = "..."
        Me.BtnOnUnload.UseVisualStyleBackColor = True
        '
        'BtnOnLoad
        '
        Me.BtnOnLoad.Location = New System.Drawing.Point(249, 18)
        Me.BtnOnLoad.Name = "BtnOnLoad"
        Me.BtnOnLoad.Size = New System.Drawing.Size(35, 23)
        Me.BtnOnLoad.TabIndex = 21
        Me.BtnOnLoad.Text = "..."
        Me.BtnOnLoad.UseVisualStyleBackColor = True
        '
        'TxtOnUnload
        '
        Me.TxtOnUnload.Location = New System.Drawing.Point(101, 48)
        Me.TxtOnUnload.Name = "TxtOnUnload"
        Me.TxtOnUnload.Size = New System.Drawing.Size(152, 23)
        Me.TxtOnUnload.TabIndex = 20
        Me.ToolTip1.SetToolTip(Me.TxtOnUnload, "Set the list of actions when the question is ")
        '
        'TxtOnLoad
        '
        Me.TxtOnLoad.Location = New System.Drawing.Point(101, 19)
        Me.TxtOnLoad.Name = "TxtOnLoad"
        Me.TxtOnLoad.Size = New System.Drawing.Size(152, 23)
        Me.TxtOnLoad.TabIndex = 19
        Me.ToolTip1.SetToolTip(Me.TxtOnLoad, "Set the list of actions when the question is loaded.")
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(11, 48)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(85, 19)
        Me.Label16.TabIndex = 11
        Me.Label16.Text = "On Unload:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(11, 19)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(72, 19)
        Me.Label12.TabIndex = 6
        Me.Label12.Text = "On Load:"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.CmbVisible)
        Me.GroupBox5.Controls.Add(Me.Label1)
        Me.GroupBox5.Controls.Add(Me.CmbHideNext)
        Me.GroupBox5.Controls.Add(Me.CmbHideBack)
        Me.GroupBox5.Controls.Add(Me.Label22)
        Me.GroupBox5.Controls.Add(Me.Label23)
        Me.GroupBox5.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(12, 226)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GroupBox5.Size = New System.Drawing.Size(318, 119)
        Me.GroupBox5.TabIndex = 7
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "PDA Settings"
        '
        'CmbVisible
        '
        Me.CmbVisible.FormattingEnabled = True
        Me.CmbVisible.Items.AddRange(New Object() {"True", "False"})
        Me.CmbVisible.Location = New System.Drawing.Point(107, 77)
        Me.CmbVisible.Name = "CmbVisible"
        Me.CmbVisible.Size = New System.Drawing.Size(150, 23)
        Me.CmbVisible.TabIndex = 22
        Me.ToolTip1.SetToolTip(Me.CmbVisible, "Hides or shows the screen on the PDA.")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(17, 77)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 19)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Visible:"
        '
        'CmbHideNext
        '
        Me.CmbHideNext.FormattingEnabled = True
        Me.CmbHideNext.Items.AddRange(New Object() {"True", "False"})
        Me.CmbHideNext.Location = New System.Drawing.Point(107, 48)
        Me.CmbHideNext.Name = "CmbHideNext"
        Me.CmbHideNext.Size = New System.Drawing.Size(150, 23)
        Me.CmbHideNext.TabIndex = 20
        Me.ToolTip1.SetToolTip(Me.CmbHideNext, "Hides or shows the next question button.")
        '
        'CmbHideBack
        '
        Me.CmbHideBack.FormattingEnabled = True
        Me.CmbHideBack.Items.AddRange(New Object() {"True", "False"})
        Me.CmbHideBack.Location = New System.Drawing.Point(107, 19)
        Me.CmbHideBack.Name = "CmbHideBack"
        Me.CmbHideBack.Size = New System.Drawing.Size(150, 23)
        Me.CmbHideBack.TabIndex = 16
        Me.ToolTip1.SetToolTip(Me.CmbHideBack, "Hides or shows the back button.")
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(17, 48)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(83, 19)
        Me.Label22.TabIndex = 13
        Me.Label22.Text = "Hide Next:"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(17, 19)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(85, 19)
        Me.Label23.TabIndex = 12
        Me.Label23.Text = "Hide Back:"
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
        Me.GrbSysInfo.Location = New System.Drawing.Point(336, 12)
        Me.GrbSysInfo.Name = "GrbSysInfo"
        Me.GrbSysInfo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GrbSysInfo.Size = New System.Drawing.Size(220, 216)
        Me.GrbSysInfo.TabIndex = 8
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
        'BtnCancelar
        '
        Me.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancelar.Location = New System.Drawing.Point(113, 368)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(95, 30)
        Me.BtnCancelar.TabIndex = 11
        Me.BtnCancelar.Text = "CANCELAR"
        Me.BtnCancelar.UseVisualStyleBackColor = True
        '
        'BtnGuardar
        '
        Me.BtnGuardar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnGuardar.Location = New System.Drawing.Point(12, 368)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(95, 30)
        Me.BtnGuardar.TabIndex = 10
        Me.BtnGuardar.Text = "OK"
        Me.BtnGuardar.UseVisualStyleBackColor = True
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 1000
        Me.ToolTip1.AutoPopDelay = 5000
        Me.ToolTip1.BackColor = System.Drawing.Color.MediumBlue
        Me.ToolTip1.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ToolTip1.InitialDelay = 1000
        Me.ToolTip1.OwnerDraw = True
        Me.ToolTip1.ReshowDelay = 200
        Me.ToolTip1.ShowAlways = True
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTip1.ToolTipTitle = "Help"
        '
        'FrmPropertyInformation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(569, 410)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.GrbSysInfo)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GrbMain)
        Me.Name = "FrmPropertyInformation"
        Me.Text = "New Info Screen"
        Me.GrbMain.ResumeLayout(False)
        Me.GrbMain.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
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
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnOnUnload As System.Windows.Forms.Button
    Friend WithEvents BtnOnLoad As System.Windows.Forms.Button
    Friend WithEvents TxtOnUnload As System.Windows.Forms.TextBox
    Friend WithEvents TxtOnLoad As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents CmbHideNext As System.Windows.Forms.ComboBox
    Friend WithEvents CmbHideBack As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents CmbVisible As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GrbSysInfo As System.Windows.Forms.GroupBox
    Friend WithEvents LblUniqueID As System.Windows.Forms.Label
    Friend WithEvents LblSectionID As System.Windows.Forms.Label
    Friend WithEvents LblQuesSetID As System.Windows.Forms.Label
    Friend WithEvents LblQuesID As System.Windows.Forms.Label
    Friend WithEvents LblTitle4 As System.Windows.Forms.Label
    Friend WithEvents LblTitle3 As System.Windows.Forms.Label
    Friend WithEvents LblTitle2 As System.Windows.Forms.Label
    Friend WithEvents LblTitle1 As System.Windows.Forms.Label
    Friend WithEvents BtnCancelar As System.Windows.Forms.Button
    Friend WithEvents BtnGuardar As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class

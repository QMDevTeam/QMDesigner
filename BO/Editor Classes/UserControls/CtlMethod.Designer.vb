<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CtlMethod
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
        Me.PnlInformation = New System.Windows.Forms.Panel()
        Me.CmbType = New System.Windows.Forms.ComboBox()
        Me.TxtName = New System.Windows.Forms.TextBox()
        Me.TxtGuid = New System.Windows.Forms.TextBox()
        Me.TxtCode = New System.Windows.Forms.TextBox()
        Me.BtnCode = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PnlInformation.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnlInformation
        '
        Me.PnlInformation.AutoScroll = True
        Me.PnlInformation.Controls.Add(Me.CmbType)
        Me.PnlInformation.Controls.Add(Me.TxtName)
        Me.PnlInformation.Controls.Add(Me.TxtGuid)
        Me.PnlInformation.Controls.Add(Me.TxtCode)
        Me.PnlInformation.Controls.Add(Me.BtnCode)
        Me.PnlInformation.Controls.Add(Me.Label9)
        Me.PnlInformation.Controls.Add(Me.Label7)
        Me.PnlInformation.Controls.Add(Me.Label8)
        Me.PnlInformation.Controls.Add(Me.Label3)
        Me.PnlInformation.Controls.Add(Me.Label1)
        Me.PnlInformation.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlInformation.Location = New System.Drawing.Point(0, 0)
        Me.PnlInformation.Name = "PnlInformation"
        Me.PnlInformation.Size = New System.Drawing.Size(324, 138)
        Me.PnlInformation.TabIndex = 5
        '
        'CmbType
        '
        Me.CmbType.FormattingEnabled = True
        Me.CmbType.Location = New System.Drawing.Point(117, 104)
        Me.CmbType.Name = "CmbType"
        Me.CmbType.Size = New System.Drawing.Size(149, 21)
        Me.CmbType.TabIndex = 32
        '
        'TxtName
        '
        Me.TxtName.Location = New System.Drawing.Point(117, 80)
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(149, 20)
        Me.TxtName.TabIndex = 31
        '
        'TxtGuid
        '
        Me.TxtGuid.Enabled = False
        Me.TxtGuid.Location = New System.Drawing.Point(117, 54)
        Me.TxtGuid.Name = "TxtGuid"
        Me.TxtGuid.Size = New System.Drawing.Size(149, 20)
        Me.TxtGuid.TabIndex = 29
        '
        'TxtCode
        '
        Me.TxtCode.Location = New System.Drawing.Point(117, 27)
        Me.TxtCode.Name = "TxtCode"
        Me.TxtCode.Size = New System.Drawing.Size(149, 20)
        Me.TxtCode.TabIndex = 27
        '
        'BtnCode
        '
        Me.BtnCode.Location = New System.Drawing.Point(272, 27)
        Me.BtnCode.Name = "BtnCode"
        Me.BtnCode.Size = New System.Drawing.Size(36, 20)
        Me.BtnCode.TabIndex = 26
        Me.BtnCode.Text = "..."
        Me.BtnCode.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(17, 6)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(37, 15)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Misc"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 113)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(31, 13)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Type"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(17, 80)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 13)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Guid"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Code"
        '
        'CtlMethod
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PnlInformation)
        Me.Name = "CtlMethod"
        Me.Size = New System.Drawing.Size(324, 138)
        Me.PnlInformation.ResumeLayout(False)
        Me.PnlInformation.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnlInformation As System.Windows.Forms.Panel
    Friend WithEvents TxtName As System.Windows.Forms.TextBox
    Friend WithEvents TxtGuid As System.Windows.Forms.TextBox
    Friend WithEvents TxtCode As System.Windows.Forms.TextBox
    Friend WithEvents BtnCode As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CmbType As System.Windows.Forms.ComboBox

End Class

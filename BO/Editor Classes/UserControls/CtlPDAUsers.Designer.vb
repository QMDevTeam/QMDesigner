<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CtlPDAUsers
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
        Me.TxtRoleName = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtUserName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtName = New System.Windows.Forms.TextBox()
        Me.TxtPass = New System.Windows.Forms.TextBox()
        Me.TxtSiteID = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PnlInformation.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnlInformation
        '
        Me.PnlInformation.AutoScroll = True
        Me.PnlInformation.Controls.Add(Me.TxtRoleName)
        Me.PnlInformation.Controls.Add(Me.Label4)
        Me.PnlInformation.Controls.Add(Me.TxtUserName)
        Me.PnlInformation.Controls.Add(Me.Label2)
        Me.PnlInformation.Controls.Add(Me.TxtName)
        Me.PnlInformation.Controls.Add(Me.TxtPass)
        Me.PnlInformation.Controls.Add(Me.TxtSiteID)
        Me.PnlInformation.Controls.Add(Me.Label9)
        Me.PnlInformation.Controls.Add(Me.Label8)
        Me.PnlInformation.Controls.Add(Me.Label3)
        Me.PnlInformation.Controls.Add(Me.Label1)
        Me.PnlInformation.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlInformation.Location = New System.Drawing.Point(0, 0)
        Me.PnlInformation.Name = "PnlInformation"
        Me.PnlInformation.Size = New System.Drawing.Size(324, 157)
        Me.PnlInformation.TabIndex = 6
        '
        'TxtRoleName
        '
        Me.TxtRoleName.Location = New System.Drawing.Point(137, 127)
        Me.TxtRoleName.Name = "TxtRoleName"
        Me.TxtRoleName.Size = New System.Drawing.Size(149, 20)
        Me.TxtRoleName.TabIndex = 35
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(36, 134)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 13)
        Me.Label4.TabIndex = 34
        Me.Label4.Text = "RoleName"
        '
        'TxtUserName
        '
        Me.TxtUserName.Location = New System.Drawing.Point(137, 103)
        Me.TxtUserName.Name = "TxtUserName"
        Me.TxtUserName.Size = New System.Drawing.Size(149, 20)
        Me.TxtUserName.TabIndex = 33
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(36, 110)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 13)
        Me.Label2.TabIndex = 32
        Me.Label2.Text = "PDAUserName"
        '
        'TxtName
        '
        Me.TxtName.Location = New System.Drawing.Point(136, 53)
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(149, 20)
        Me.TxtName.TabIndex = 31
        '
        'TxtPass
        '
        Me.TxtPass.Location = New System.Drawing.Point(136, 77)
        Me.TxtPass.Name = "TxtPass"
        Me.TxtPass.Size = New System.Drawing.Size(149, 20)
        Me.TxtPass.TabIndex = 29
        '
        'TxtSiteID
        '
        Me.TxtSiteID.Location = New System.Drawing.Point(136, 27)
        Me.TxtSiteID.Name = "TxtSiteID"
        Me.TxtSiteID.Size = New System.Drawing.Size(149, 20)
        Me.TxtSiteID.TabIndex = 27
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(36, 6)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(37, 15)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Misc"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(36, 60)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 13)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(35, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "PDAPassword"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(36, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "DefaultSiteID"
        '
        'CtlPDAUsers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PnlInformation)
        Me.Name = "CtlPDAUsers"
        Me.Size = New System.Drawing.Size(324, 157)
        Me.PnlInformation.ResumeLayout(False)
        Me.PnlInformation.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnlInformation As System.Windows.Forms.Panel
    Friend WithEvents TxtName As System.Windows.Forms.TextBox
    Friend WithEvents TxtPass As System.Windows.Forms.TextBox
    Friend WithEvents TxtSiteID As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtUserName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtRoleName As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label

End Class

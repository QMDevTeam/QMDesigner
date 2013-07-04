<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConnectionDataBaseForm
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.butAcept = New System.Windows.Forms.Button
        Me.butCancel = New System.Windows.Forms.Button
        Me.txtServerName = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmbAuthentication = New System.Windows.Forms.ComboBox
        Me.lblUsername = New System.Windows.Forms.Label
        Me.lblPassword = New System.Windows.Forms.Label
        Me.txtUsername = New System.Windows.Forms.TextBox
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtDataBase = New System.Windows.Forms.TextBox
        Me.rbtConnectMDF = New System.Windows.Forms.RadioButton
        Me.rbtConnectSQLServer = New System.Windows.Forms.RadioButton
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(52, 96)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Server Name:"
        '
        'butAcept
        '
        Me.butAcept.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.butAcept.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.butAcept.Location = New System.Drawing.Point(86, 312)
        Me.butAcept.Name = "butAcept"
        Me.butAcept.Size = New System.Drawing.Size(75, 23)
        Me.butAcept.TabIndex = 6
        Me.butAcept.Text = "Acept"
        Me.butAcept.UseVisualStyleBackColor = True
        '
        'butCancel
        '
        Me.butCancel.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.butCancel.Location = New System.Drawing.Point(197, 312)
        Me.butCancel.Name = "butCancel"
        Me.butCancel.Size = New System.Drawing.Size(75, 23)
        Me.butCancel.TabIndex = 7
        Me.butCancel.Text = "Cancel"
        Me.butCancel.UseVisualStyleBackColor = True
        '
        'txtServerName
        '
        Me.txtServerName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtServerName.Enabled = False
        Me.txtServerName.Location = New System.Drawing.Point(146, 93)
        Me.txtServerName.Name = "txtServerName"
        Me.txtServerName.Size = New System.Drawing.Size(168, 20)
        Me.txtServerName.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(52, 164)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Authentication:"
        '
        'cmbAuthentication
        '
        Me.cmbAuthentication.AllowDrop = True
        Me.cmbAuthentication.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbAuthentication.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAuthentication.Enabled = False
        Me.cmbAuthentication.FormattingEnabled = True
        Me.cmbAuthentication.Items.AddRange(New Object() {"Windows Authentication", "Server Authentication"})
        Me.cmbAuthentication.Location = New System.Drawing.Point(146, 161)
        Me.cmbAuthentication.Name = "cmbAuthentication"
        Me.cmbAuthentication.Size = New System.Drawing.Size(168, 21)
        Me.cmbAuthentication.TabIndex = 3
        '
        'lblUsername
        '
        Me.lblUsername.AutoSize = True
        Me.lblUsername.Enabled = False
        Me.lblUsername.Location = New System.Drawing.Point(52, 220)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(58, 13)
        Me.lblUsername.TabIndex = 8
        Me.lblUsername.Text = "Username:"
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Enabled = False
        Me.lblPassword.Location = New System.Drawing.Point(52, 260)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(56, 13)
        Me.lblPassword.TabIndex = 9
        Me.lblPassword.Text = "Passwrod:"
        '
        'txtUsername
        '
        Me.txtUsername.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUsername.Enabled = False
        Me.txtUsername.Location = New System.Drawing.Point(146, 220)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(168, 20)
        Me.txtUsername.TabIndex = 4
        '
        'txtPassword
        '
        Me.txtPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPassword.Enabled = False
        Me.txtPassword.Location = New System.Drawing.Point(146, 260)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(168, 20)
        Me.txtPassword.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(52, 130)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Data Base:"
        '
        'txtDataBase
        '
        Me.txtDataBase.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDataBase.Enabled = False
        Me.txtDataBase.Location = New System.Drawing.Point(146, 127)
        Me.txtDataBase.Name = "txtDataBase"
        Me.txtDataBase.Size = New System.Drawing.Size(168, 20)
        Me.txtDataBase.TabIndex = 2
        '
        'rbtConnectMDF
        '
        Me.rbtConnectMDF.AutoSize = True
        Me.rbtConnectMDF.Checked = True
        Me.rbtConnectMDF.Location = New System.Drawing.Point(105, 24)
        Me.rbtConnectMDF.Name = "rbtConnectMDF"
        Me.rbtConnectMDF.Size = New System.Drawing.Size(167, 17)
        Me.rbtConnectMDF.TabIndex = 13
        Me.rbtConnectMDF.TabStop = True
        Me.rbtConnectMDF.Text = "Connect using Instance Mode"
        Me.rbtConnectMDF.UseVisualStyleBackColor = True
        '
        'rbtConnectSQLServer
        '
        Me.rbtConnectSQLServer.AutoSize = True
        Me.rbtConnectSQLServer.Location = New System.Drawing.Point(105, 47)
        Me.rbtConnectSQLServer.Name = "rbtConnectSQLServer"
        Me.rbtConnectSQLServer.Size = New System.Drawing.Size(135, 17)
        Me.rbtConnectSQLServer.TabIndex = 14
        Me.rbtConnectSQLServer.Text = "Connect to SQL Server"
        Me.rbtConnectSQLServer.UseVisualStyleBackColor = True
        '
        'ConnectionDataBaseForm
        '
        Me.AcceptButton = Me.butAcept
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.butCancel
        Me.ClientSize = New System.Drawing.Size(370, 351)
        Me.Controls.Add(Me.rbtConnectSQLServer)
        Me.Controls.Add(Me.rbtConnectMDF)
        Me.Controls.Add(Me.txtDataBase)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.lblPassword)
        Me.Controls.Add(Me.lblUsername)
        Me.Controls.Add(Me.cmbAuthentication)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtServerName)
        Me.Controls.Add(Me.butCancel)
        Me.Controls.Add(Me.butAcept)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(355, 382)
        Me.Name = "ConnectionDataBaseForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "DataBase Connection "
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents butAcept As System.Windows.Forms.Button
    Friend WithEvents butCancel As System.Windows.Forms.Button
    Friend WithEvents txtServerName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbAuthentication As System.Windows.Forms.ComboBox
    Friend WithEvents lblUsername As System.Windows.Forms.Label
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents txtUsername As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDataBase As System.Windows.Forms.TextBox
    Friend WithEvents rbtConnectMDF As System.Windows.Forms.RadioButton
    Friend WithEvents rbtConnectSQLServer As System.Windows.Forms.RadioButton
End Class

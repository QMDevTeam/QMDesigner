<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SQLCommandForm
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
        Me.txtSQLQuery = New System.Windows.Forms.RichTextBox
        Me.butExecute = New System.Windows.Forms.Button
        Me.butClose = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'txtSQLQuery
        '
        Me.txtSQLQuery.Location = New System.Drawing.Point(12, 12)
        Me.txtSQLQuery.Name = "txtSQLQuery"
        Me.txtSQLQuery.Size = New System.Drawing.Size(802, 356)
        Me.txtSQLQuery.TabIndex = 0
        Me.txtSQLQuery.Text = ""
        '
        'butExecute
        '
        Me.butExecute.Location = New System.Drawing.Point(234, 387)
        Me.butExecute.Name = "butExecute"
        Me.butExecute.Size = New System.Drawing.Size(114, 23)
        Me.butExecute.TabIndex = 1
        Me.butExecute.Text = "Exectue Query"
        Me.butExecute.UseVisualStyleBackColor = True
        '
        'butClose
        '
        Me.butClose.Location = New System.Drawing.Point(481, 387)
        Me.butClose.Name = "butClose"
        Me.butClose.Size = New System.Drawing.Size(75, 23)
        Me.butClose.TabIndex = 2
        Me.butClose.Text = "Close"
        Me.butClose.UseVisualStyleBackColor = True
        '
        'SQLCommandForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(826, 426)
        Me.Controls.Add(Me.butClose)
        Me.Controls.Add(Me.butExecute)
        Me.Controls.Add(Me.txtSQLQuery)
        Me.Name = "SQLCommandForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "SQLCommandForm"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtSQLQuery As System.Windows.Forms.RichTextBox
    Friend WithEvents butExecute As System.Windows.Forms.Button
    Friend WithEvents butClose As System.Windows.Forms.Button
End Class

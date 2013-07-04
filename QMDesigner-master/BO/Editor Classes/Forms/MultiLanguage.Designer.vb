<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MultiLanguage
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
        Me.Label_CurrentLanguage = New System.Windows.Forms.Label
        Me.TextBox_CurrentText = New System.Windows.Forms.TextBox
        Me.ComboBox_AlternativeLanguage = New System.Windows.Forms.ComboBox
        Me.TextBox_OtherText = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label_CurrentLanguage
        '
        Me.Label_CurrentLanguage.AutoSize = True
        Me.Label_CurrentLanguage.Location = New System.Drawing.Point(12, 9)
        Me.Label_CurrentLanguage.Name = "Label_CurrentLanguage"
        Me.Label_CurrentLanguage.Size = New System.Drawing.Size(92, 13)
        Me.Label_CurrentLanguage.TabIndex = 0
        Me.Label_CurrentLanguage.Text = "Current Language"
        '
        'TextBox_CurrentText
        '
        Me.TextBox_CurrentText.Location = New System.Drawing.Point(12, 25)
        Me.TextBox_CurrentText.Multiline = True
        Me.TextBox_CurrentText.Name = "TextBox_CurrentText"
        Me.TextBox_CurrentText.Size = New System.Drawing.Size(370, 145)
        Me.TextBox_CurrentText.TabIndex = 1
        '
        'ComboBox_AlternativeLanguage
        '
        Me.ComboBox_AlternativeLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_AlternativeLanguage.FormattingEnabled = True
        Me.ComboBox_AlternativeLanguage.Location = New System.Drawing.Point(101, 189)
        Me.ComboBox_AlternativeLanguage.Name = "ComboBox_AlternativeLanguage"
        Me.ComboBox_AlternativeLanguage.Size = New System.Drawing.Size(139, 21)
        Me.ComboBox_AlternativeLanguage.TabIndex = 2
        '
        'TextBox_OtherText
        '
        Me.TextBox_OtherText.Enabled = False
        Me.TextBox_OtherText.Location = New System.Drawing.Point(12, 216)
        Me.TextBox_OtherText.Multiline = True
        Me.TextBox_OtherText.Name = "TextBox_OtherText"
        Me.TextBox_OtherText.Size = New System.Drawing.Size(370, 145)
        Me.TextBox_OtherText.TabIndex = 3
        '
        'Button1
        '
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Button1.Location = New System.Drawing.Point(226, 367)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Ok"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button2.Location = New System.Drawing.Point(307, 367)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "Cancel"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 192)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Other language:"
        '
        'MultiLanguage
        '
        Me.AcceptButton = Me.Button1
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Button2
        Me.ClientSize = New System.Drawing.Size(394, 399)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox_OtherText)
        Me.Controls.Add(Me.ComboBox_AlternativeLanguage)
        Me.Controls.Add(Me.TextBox_CurrentText)
        Me.Controls.Add(Me.Label_CurrentLanguage)
        Me.Name = "MultiLanguage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "MultiLanguage"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label_CurrentLanguage As System.Windows.Forms.Label
    Friend WithEvents TextBox_CurrentText As System.Windows.Forms.TextBox
    Friend WithEvents ComboBox_AlternativeLanguage As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox_OtherText As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class

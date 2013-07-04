<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LogViewer
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
        Me.uxLogTabControl = New System.Windows.Forms.TabControl
        Me.uxSummaryTabPage = New System.Windows.Forms.TabPage
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.butSaveAsSummary = New System.Windows.Forms.Button
        Me.uxNormalLogTabPage = New System.Windows.Forms.TabPage
        Me.butSaveAsNormalLog = New System.Windows.Forms.Button
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.uxErrorsTabPage = New System.Windows.Forms.TabPage
        Me.butSaveAsErrors = New System.Windows.Forms.Button
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.butClose = New System.Windows.Forms.Button
        Me.uxLogTabControl.SuspendLayout()
        Me.uxSummaryTabPage.SuspendLayout()
        Me.uxNormalLogTabPage.SuspendLayout()
        Me.uxErrorsTabPage.SuspendLayout()
        Me.SuspendLayout()
        '
        'uxLogTabControl
        '
        Me.uxLogTabControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.uxLogTabControl.Controls.Add(Me.uxSummaryTabPage)
        Me.uxLogTabControl.Controls.Add(Me.uxNormalLogTabPage)
        Me.uxLogTabControl.Controls.Add(Me.uxErrorsTabPage)
        Me.uxLogTabControl.Location = New System.Drawing.Point(12, 12)
        Me.uxLogTabControl.Name = "uxLogTabControl"
        Me.uxLogTabControl.SelectedIndex = 0
        Me.uxLogTabControl.Size = New System.Drawing.Size(695, 395)
        Me.uxLogTabControl.TabIndex = 0
        '
        'uxSummaryTabPage
        '
        Me.uxSummaryTabPage.Controls.Add(Me.TextBox1)
        Me.uxSummaryTabPage.Controls.Add(Me.butSaveAsSummary)
        Me.uxSummaryTabPage.Location = New System.Drawing.Point(4, 22)
        Me.uxSummaryTabPage.Name = "uxSummaryTabPage"
        Me.uxSummaryTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.uxSummaryTabPage.Size = New System.Drawing.Size(687, 369)
        Me.uxSummaryTabPage.TabIndex = 0
        Me.uxSummaryTabPage.Text = "Summary"
        Me.uxSummaryTabPage.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.Location = New System.Drawing.Point(6, 6)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox1.Size = New System.Drawing.Size(675, 311)
        Me.TextBox1.TabIndex = 0
        '
        'butSaveAsSummary
        '
        Me.butSaveAsSummary.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.butSaveAsSummary.Location = New System.Drawing.Point(52, 325)
        Me.butSaveAsSummary.Name = "butSaveAsSummary"
        Me.butSaveAsSummary.Size = New System.Drawing.Size(94, 33)
        Me.butSaveAsSummary.TabIndex = 1
        Me.butSaveAsSummary.Text = "Save As..."
        Me.butSaveAsSummary.UseVisualStyleBackColor = True
        '
        'uxNormalLogTabPage
        '
        Me.uxNormalLogTabPage.Controls.Add(Me.butSaveAsNormalLog)
        Me.uxNormalLogTabPage.Controls.Add(Me.TextBox2)
        Me.uxNormalLogTabPage.Location = New System.Drawing.Point(4, 22)
        Me.uxNormalLogTabPage.Name = "uxNormalLogTabPage"
        Me.uxNormalLogTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.uxNormalLogTabPage.Size = New System.Drawing.Size(687, 369)
        Me.uxNormalLogTabPage.TabIndex = 1
        Me.uxNormalLogTabPage.Text = "Normal Log"
        Me.uxNormalLogTabPage.UseVisualStyleBackColor = True
        '
        'butSaveAsNormalLog
        '
        Me.butSaveAsNormalLog.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.butSaveAsNormalLog.Location = New System.Drawing.Point(52, 325)
        Me.butSaveAsNormalLog.Name = "butSaveAsNormalLog"
        Me.butSaveAsNormalLog.Size = New System.Drawing.Size(94, 33)
        Me.butSaveAsNormalLog.TabIndex = 2
        Me.butSaveAsNormalLog.Text = "Save As..."
        Me.butSaveAsNormalLog.UseVisualStyleBackColor = True
        '
        'TextBox2
        '
        Me.TextBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox2.Location = New System.Drawing.Point(6, 6)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox2.Size = New System.Drawing.Size(675, 311)
        Me.TextBox2.TabIndex = 1
        '
        'uxErrorsTabPage
        '
        Me.uxErrorsTabPage.Controls.Add(Me.butSaveAsErrors)
        Me.uxErrorsTabPage.Controls.Add(Me.TextBox3)
        Me.uxErrorsTabPage.Location = New System.Drawing.Point(4, 22)
        Me.uxErrorsTabPage.Name = "uxErrorsTabPage"
        Me.uxErrorsTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.uxErrorsTabPage.Size = New System.Drawing.Size(687, 369)
        Me.uxErrorsTabPage.TabIndex = 2
        Me.uxErrorsTabPage.Text = "Errors"
        Me.uxErrorsTabPage.UseVisualStyleBackColor = True
        '
        'butSaveAsErrors
        '
        Me.butSaveAsErrors.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.butSaveAsErrors.Location = New System.Drawing.Point(52, 325)
        Me.butSaveAsErrors.Name = "butSaveAsErrors"
        Me.butSaveAsErrors.Size = New System.Drawing.Size(94, 33)
        Me.butSaveAsErrors.TabIndex = 3
        Me.butSaveAsErrors.Text = "Save As..."
        Me.butSaveAsErrors.UseVisualStyleBackColor = True
        '
        'TextBox3
        '
        Me.TextBox3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox3.Location = New System.Drawing.Point(6, 6)
        Me.TextBox3.Multiline = True
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox3.Size = New System.Drawing.Size(675, 311)
        Me.TextBox3.TabIndex = 2
        '
        'butClose
        '
        Me.butClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butClose.Location = New System.Drawing.Point(714, 64)
        Me.butClose.Name = "butClose"
        Me.butClose.Size = New System.Drawing.Size(75, 31)
        Me.butClose.TabIndex = 1
        Me.butClose.Text = "Close"
        Me.butClose.UseVisualStyleBackColor = True
        '
        'LogViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(796, 419)
        Me.Controls.Add(Me.butClose)
        Me.Controls.Add(Me.uxLogTabControl)
        Me.Name = "LogViewer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "LogViewer"
        Me.uxLogTabControl.ResumeLayout(False)
        Me.uxSummaryTabPage.ResumeLayout(False)
        Me.uxSummaryTabPage.PerformLayout()
        Me.uxNormalLogTabPage.ResumeLayout(False)
        Me.uxNormalLogTabPage.PerformLayout()
        Me.uxErrorsTabPage.ResumeLayout(False)
        Me.uxErrorsTabPage.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents uxLogTabControl As System.Windows.Forms.TabControl
    Friend WithEvents uxSummaryTabPage As System.Windows.Forms.TabPage
    Friend WithEvents uxNormalLogTabPage As System.Windows.Forms.TabPage
    Friend WithEvents uxErrorsTabPage As System.Windows.Forms.TabPage
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents butSaveAsSummary As System.Windows.Forms.Button
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents butClose As System.Windows.Forms.Button
    Friend WithEvents butSaveAsNormalLog As System.Windows.Forms.Button
    Friend WithEvents butSaveAsErrors As System.Windows.Forms.Button
End Class

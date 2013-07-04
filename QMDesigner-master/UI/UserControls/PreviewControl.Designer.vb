<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PreviewControl
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
        Me.webPreview = New System.Windows.Forms.WebBrowser
        Me.Bar1 = New DevComponents.DotNetBar.Bar
        Me.ckbShowAssignedVariables = New DevComponents.DotNetBar.CheckBoxItem
        Me.ckbShowVariableName = New DevComponents.DotNetBar.CheckBoxItem
        Me.ckbShowValues = New DevComponents.DotNetBar.CheckBoxItem
        Me.ckbShowConditions = New DevComponents.DotNetBar.CheckBoxItem
        Me.ckbMetaData = New DevComponents.DotNetBar.CheckBoxItem
        Me.ckbRoute = New DevComponents.DotNetBar.CheckBoxItem
        Me.ckbPageBreak = New DevComponents.DotNetBar.CheckBoxItem
        Me.ckbHiddenLV = New DevComponents.DotNetBar.CheckBoxItem
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'webPreview
        '
        Me.webPreview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.webPreview.Location = New System.Drawing.Point(0, 42)
        Me.webPreview.MinimumSize = New System.Drawing.Size(20, 20)
        Me.webPreview.Name = "webPreview"
        Me.webPreview.Size = New System.Drawing.Size(588, 409)
        Me.webPreview.TabIndex = 0
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.DisplayMoreItemsOnMenu = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar1.EqualButtonSize = True
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ckbShowAssignedVariables, Me.ckbShowVariableName, Me.ckbShowValues, Me.ckbShowConditions, Me.ckbMetaData, Me.ckbRoute, Me.ckbPageBreak, Me.ckbHiddenLV})
        Me.Bar1.Location = New System.Drawing.Point(0, 0)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(588, 42)
        Me.Bar1.Stretch = True
        Me.Bar1.TabIndex = 2
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        Me.Bar1.ThemeAware = True
        Me.Bar1.WrapItemsDock = True
        '
        'ckbShowAssignedVariables
        '
        Me.ckbShowAssignedVariables.Name = "ckbShowAssignedVariables"
        Me.ckbShowAssignedVariables.Text = "Assigned Variables"
        Me.ckbShowAssignedVariables.ThemeAware = True
        '
        'ckbShowVariableName
        '
        Me.ckbShowVariableName.Name = "ckbShowVariableName"
        Me.ckbShowVariableName.Text = "Variable Names"
        Me.ckbShowVariableName.ThemeAware = True
        '
        'ckbShowValues
        '
        Me.ckbShowValues.Name = "ckbShowValues"
        Me.ckbShowValues.Text = "Values of Legal Values "
        Me.ckbShowValues.ThemeAware = True
        '
        'ckbShowConditions
        '
        Me.ckbShowConditions.Name = "ckbShowConditions"
        Me.ckbShowConditions.Text = "Conditions"
        Me.ckbShowConditions.ThemeAware = True
        '
        'ckbMetaData
        '
        Me.ckbMetaData.Name = "ckbMetaData"
        Me.ckbMetaData.Text = "Metadata"
        Me.ckbMetaData.ThemeAware = True
        '
        'ckbRoute
        '
        Me.ckbRoute.Name = "ckbRoute"
        Me.ckbRoute.Text = "Route"
        Me.ckbRoute.ThemeAware = True
        '
        'ckbPageBreak
        '
        Me.ckbPageBreak.Name = "ckbPageBreak"
        Me.ckbPageBreak.Text = "Page Breaks"
        Me.ckbPageBreak.ThemeAware = True
        '
        'ckbHiddenLV
        '
        Me.ckbHiddenLV.Name = "ckbHiddenLV"
        Me.ckbHiddenLV.Text = "Hidden Legal Values"
        Me.ckbHiddenLV.ThemeAware = True
        '
        'PreviewControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.webPreview)
        Me.Controls.Add(Me.Bar1)
        Me.Name = "PreviewControl"
        Me.Size = New System.Drawing.Size(588, 451)
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents webPreview As System.Windows.Forms.WebBrowser
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents ckbShowAssignedVariables As DevComponents.DotNetBar.CheckBoxItem
    Friend WithEvents ckbShowVariableName As DevComponents.DotNetBar.CheckBoxItem
    Friend WithEvents ckbShowValues As DevComponents.DotNetBar.CheckBoxItem
    Friend WithEvents ckbShowConditions As DevComponents.DotNetBar.CheckBoxItem
    Friend WithEvents ckbMetaData As DevComponents.DotNetBar.CheckBoxItem
    Friend WithEvents ckbRoute As DevComponents.DotNetBar.CheckBoxItem
    Friend WithEvents ckbPageBreak As DevComponents.DotNetBar.CheckBoxItem
    Friend WithEvents ckbHiddenLV As DevComponents.DotNetBar.CheckBoxItem

End Class

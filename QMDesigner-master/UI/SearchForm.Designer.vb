<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SearchForm
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
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX
        Me.PhraseTextBoxX = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.FindNextButton = New DevComponents.DotNetBar.ButtonX
        Me.CancelButton = New DevComponents.DotNetBar.ButtonX
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX
        Me.UseTranslationsCheckBoxX = New DevComponents.DotNetBar.Controls.CheckBoxX
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX
        Me.SearchDirectionComboBoxEx = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.DirectionUpComboItem = New DevComponents.Editors.ComboItem
        Me.DirectionDownComboItem = New DevComponents.Editors.ComboItem
        Me.UseWholePhraseMatchingCheckBoxX = New DevComponents.DotNetBar.Controls.CheckBoxX
        Me.UseRegExpCheckBoxX = New DevComponents.DotNetBar.Controls.CheckBoxX
        Me.SearchInComboBoxEx = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.SearchInDesignComboItem = New DevComponents.Editors.ComboItem
        Me.SearchInLegalValuesComboItem = New DevComponents.Editors.ComboItem
        Me.SearchInMethodsComboItem = New DevComponents.Editors.ComboItem
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX
        Me.SuspendLayout()
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.Class = ""
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(12, 12)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(56, 23)
        Me.LabelX1.TabIndex = 0
        Me.LabelX1.Text = "Find What:"
        '
        'PhraseTextBoxX
        '
        Me.PhraseTextBoxX.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.PhraseTextBoxX.Border.Class = "TextBoxBorder"
        Me.PhraseTextBoxX.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.PhraseTextBoxX.Location = New System.Drawing.Point(74, 15)
        Me.PhraseTextBoxX.Name = "PhraseTextBoxX"
        Me.PhraseTextBoxX.Size = New System.Drawing.Size(261, 20)
        Me.PhraseTextBoxX.TabIndex = 1
        '
        'FindNextButton
        '
        Me.FindNextButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.FindNextButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FindNextButton.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.FindNextButton.Location = New System.Drawing.Point(179, 226)
        Me.FindNextButton.Name = "FindNextButton"
        Me.FindNextButton.Size = New System.Drawing.Size(75, 23)
        Me.FindNextButton.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.FindNextButton.TabIndex = 10
        Me.FindNextButton.Text = "Find Next"
        '
        'CancelButton
        '
        Me.CancelButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.CancelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CancelButton.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CancelButton.Location = New System.Drawing.Point(260, 226)
        Me.CancelButton.Name = "CancelButton"
        Me.CancelButton.Size = New System.Drawing.Size(75, 23)
        Me.CancelButton.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CancelButton.TabIndex = 11
        Me.CancelButton.Text = "Cancel"
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.Class = ""
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Location = New System.Drawing.Point(12, 54)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(83, 23)
        Me.LabelX3.TabIndex = 2
        Me.LabelX3.Text = "Search options:"
        '
        'UseTranslationsCheckBoxX
        '
        '
        '
        '
        Me.UseTranslationsCheckBoxX.BackgroundStyle.Class = ""
        Me.UseTranslationsCheckBoxX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.UseTranslationsCheckBoxX.Location = New System.Drawing.Point(12, 113)
        Me.UseTranslationsCheckBoxX.Name = "UseTranslationsCheckBoxX"
        Me.UseTranslationsCheckBoxX.Size = New System.Drawing.Size(156, 23)
        Me.UseTranslationsCheckBoxX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.UseTranslationsCheckBoxX.TabIndex = 5
        Me.UseTranslationsCheckBoxX.Text = "Search in other languages"
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.Class = ""
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Location = New System.Drawing.Point(12, 197)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(50, 23)
        Me.LabelX4.TabIndex = 8
        Me.LabelX4.Text = "Direction:"
        '
        'SearchDirectionComboBoxEx
        '
        Me.SearchDirectionComboBoxEx.DisplayMember = "Text"
        Me.SearchDirectionComboBoxEx.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.SearchDirectionComboBoxEx.FormattingEnabled = True
        Me.SearchDirectionComboBoxEx.ItemHeight = 14
        Me.SearchDirectionComboBoxEx.Items.AddRange(New Object() {Me.DirectionUpComboItem, Me.DirectionDownComboItem})
        Me.SearchDirectionComboBoxEx.Location = New System.Drawing.Point(68, 200)
        Me.SearchDirectionComboBoxEx.Name = "SearchDirectionComboBoxEx"
        Me.SearchDirectionComboBoxEx.Size = New System.Drawing.Size(99, 20)
        Me.SearchDirectionComboBoxEx.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SearchDirectionComboBoxEx.TabIndex = 9
        '
        'DirectionUpComboItem
        '
        Me.DirectionUpComboItem.Text = "Up"
        '
        'DirectionDownComboItem
        '
        Me.DirectionDownComboItem.Text = "Down"
        '
        'UseWholePhraseMatchingCheckBoxX
        '
        '
        '
        '
        Me.UseWholePhraseMatchingCheckBoxX.BackgroundStyle.Class = ""
        Me.UseWholePhraseMatchingCheckBoxX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.UseWholePhraseMatchingCheckBoxX.Location = New System.Drawing.Point(12, 142)
        Me.UseWholePhraseMatchingCheckBoxX.Name = "UseWholePhraseMatchingCheckBoxX"
        Me.UseWholePhraseMatchingCheckBoxX.Size = New System.Drawing.Size(156, 23)
        Me.UseWholePhraseMatchingCheckBoxX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.UseWholePhraseMatchingCheckBoxX.TabIndex = 6
        Me.UseWholePhraseMatchingCheckBoxX.Text = "Whole phrase matching"
        '
        'UseRegExpCheckBoxX
        '
        '
        '
        '
        Me.UseRegExpCheckBoxX.BackgroundStyle.Class = ""
        Me.UseRegExpCheckBoxX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.UseRegExpCheckBoxX.Location = New System.Drawing.Point(12, 171)
        Me.UseRegExpCheckBoxX.Name = "UseRegExpCheckBoxX"
        Me.UseRegExpCheckBoxX.Size = New System.Drawing.Size(156, 23)
        Me.UseRegExpCheckBoxX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.UseRegExpCheckBoxX.TabIndex = 7
        Me.UseRegExpCheckBoxX.Text = "Use regular expresions"
        '
        'SearchInComboBoxEx
        '
        Me.SearchInComboBoxEx.DisplayMember = "Text"
        Me.SearchInComboBoxEx.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.SearchInComboBoxEx.FormattingEnabled = True
        Me.SearchInComboBoxEx.ItemHeight = 14
        Me.SearchInComboBoxEx.Items.AddRange(New Object() {Me.SearchInDesignComboItem, Me.SearchInLegalValuesComboItem, Me.SearchInMethodsComboItem})
        Me.SearchInComboBoxEx.Location = New System.Drawing.Point(68, 83)
        Me.SearchInComboBoxEx.Name = "SearchInComboBoxEx"
        Me.SearchInComboBoxEx.Size = New System.Drawing.Size(99, 20)
        Me.SearchInComboBoxEx.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SearchInComboBoxEx.TabIndex = 4
        '
        'SearchInDesignComboItem
        '
        Me.SearchInDesignComboItem.Text = "Study Design"
        '
        'SearchInLegalValuesComboItem
        '
        Me.SearchInLegalValuesComboItem.Text = "Legal Values"
        '
        'SearchInMethodsComboItem
        '
        Me.SearchInMethodsComboItem.Text = "Methods"
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.Class = ""
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(12, 80)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(68, 23)
        Me.LabelX2.TabIndex = 3
        Me.LabelX2.Text = "Search In:"
        '
        'SearchForm
        '
        Me.AcceptButton = Me.FindNextButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(349, 261)
        Me.Controls.Add(Me.SearchInComboBoxEx)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.UseRegExpCheckBoxX)
        Me.Controls.Add(Me.UseWholePhraseMatchingCheckBoxX)
        Me.Controls.Add(Me.SearchDirectionComboBoxEx)
        Me.Controls.Add(Me.LabelX4)
        Me.Controls.Add(Me.UseTranslationsCheckBoxX)
        Me.Controls.Add(Me.LabelX3)
        Me.Controls.Add(Me.CancelButton)
        Me.Controls.Add(Me.FindNextButton)
        Me.Controls.Add(Me.PhraseTextBoxX)
        Me.Controls.Add(Me.LabelX1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SearchForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Find"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents PhraseTextBoxX As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents FindNextButton As DevComponents.DotNetBar.ButtonX
    Friend WithEvents CancelButton As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents UseTranslationsCheckBoxX As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents SearchDirectionComboBoxEx As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents DirectionDownComboItem As DevComponents.Editors.ComboItem
    Friend WithEvents DirectionUpComboItem As DevComponents.Editors.ComboItem
    Friend WithEvents UseWholePhraseMatchingCheckBoxX As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents UseRegExpCheckBoxX As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents SearchInComboBoxEx As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents SearchInDesignComboItem As DevComponents.Editors.ComboItem
    Friend WithEvents SearchInLegalValuesComboItem As DevComponents.Editors.ComboItem
    Friend WithEvents SearchInMethodsComboItem As DevComponents.Editors.ComboItem
End Class

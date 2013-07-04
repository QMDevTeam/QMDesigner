<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SummaryViewer
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
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.butAcept = New System.Windows.Forms.Button
        Me.uxSummaryDataGridView = New DevComponents.DotNetBar.Controls.DataGridViewX
        Me.FileNameDataGridViewTextBoxColumn = New DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn
        Me.InsertDataGridViewTextBoxColumn = New DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn
        Me.UpdateDataGridViewTextBoxColumn = New DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn
        Me.BeginDateDataGridViewTextBoxColumn = New DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn
        Me.FinalDateDataGridViewTextBoxColumn = New DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn
        Me.SaveDetailsColumn = New DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn
        Me.SummaryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SummaryDataSet1 = New DataManager.SummaryDataSet
        Me.StyleManager1 = New DevComponents.DotNetBar.StyleManager(Me.components)
        Me.butSaveErrors = New System.Windows.Forms.Button
        Me.ErrorsSaveFileDialog = New System.Windows.Forms.SaveFileDialog
        Me.DetailsSaveFileDialog = New System.Windows.Forms.SaveFileDialog
        CType(Me.uxSummaryDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SummaryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SummaryDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'butAcept
        '
        Me.butAcept.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.butAcept.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.butAcept.Location = New System.Drawing.Point(216, 340)
        Me.butAcept.Name = "butAcept"
        Me.butAcept.Size = New System.Drawing.Size(154, 29)
        Me.butAcept.TabIndex = 2
        Me.butAcept.Text = "Accept"
        Me.butAcept.UseVisualStyleBackColor = True
        '
        'uxSummaryDataGridView
        '
        Me.uxSummaryDataGridView.AllowUserToAddRows = False
        Me.uxSummaryDataGridView.AllowUserToDeleteRows = False
        Me.uxSummaryDataGridView.AutoGenerateColumns = False
        Me.uxSummaryDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.uxSummaryDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FileNameDataGridViewTextBoxColumn, Me.InsertDataGridViewTextBoxColumn, Me.UpdateDataGridViewTextBoxColumn, Me.BeginDateDataGridViewTextBoxColumn, Me.FinalDateDataGridViewTextBoxColumn, Me.SaveDetailsColumn})
        Me.uxSummaryDataGridView.DataSource = Me.SummaryBindingSource
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.uxSummaryDataGridView.DefaultCellStyle = DataGridViewCellStyle2
        Me.uxSummaryDataGridView.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.uxSummaryDataGridView.Location = New System.Drawing.Point(12, 30)
        Me.uxSummaryDataGridView.Name = "uxSummaryDataGridView"
        Me.uxSummaryDataGridView.ReadOnly = True
        Me.uxSummaryDataGridView.Size = New System.Drawing.Size(801, 294)
        Me.uxSummaryDataGridView.TabIndex = 3
        '
        'FileNameDataGridViewTextBoxColumn
        '
        Me.FileNameDataGridViewTextBoxColumn.DataPropertyName = "File Name"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.FileNameDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.FileNameDataGridViewTextBoxColumn.HeaderText = "File Name"
        Me.FileNameDataGridViewTextBoxColumn.Name = "FileNameDataGridViewTextBoxColumn"
        Me.FileNameDataGridViewTextBoxColumn.ReadOnly = True
        Me.FileNameDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.FileNameDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.FileNameDataGridViewTextBoxColumn.Width = 280
        '
        'InsertDataGridViewTextBoxColumn
        '
        Me.InsertDataGridViewTextBoxColumn.DataPropertyName = "Insert"
        Me.InsertDataGridViewTextBoxColumn.HeaderText = "Inserted"
        Me.InsertDataGridViewTextBoxColumn.Name = "InsertDataGridViewTextBoxColumn"
        Me.InsertDataGridViewTextBoxColumn.ReadOnly = True
        Me.InsertDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.InsertDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.InsertDataGridViewTextBoxColumn.Width = 65
        '
        'UpdateDataGridViewTextBoxColumn
        '
        Me.UpdateDataGridViewTextBoxColumn.DataPropertyName = "Update"
        Me.UpdateDataGridViewTextBoxColumn.HeaderText = "Updated"
        Me.UpdateDataGridViewTextBoxColumn.Name = "UpdateDataGridViewTextBoxColumn"
        Me.UpdateDataGridViewTextBoxColumn.ReadOnly = True
        Me.UpdateDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.UpdateDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.UpdateDataGridViewTextBoxColumn.Width = 65
        '
        'BeginDateDataGridViewTextBoxColumn
        '
        '
        '
        '
        Me.BeginDateDataGridViewTextBoxColumn.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.BeginDateDataGridViewTextBoxColumn.BackgroundStyle.Class = "DataGridViewDateTimeBorder"
        Me.BeginDateDataGridViewTextBoxColumn.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.BeginDateDataGridViewTextBoxColumn.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText
        Me.BeginDateDataGridViewTextBoxColumn.CustomFormat = "yyyy/MM/dd hh:mm:ss"
        Me.BeginDateDataGridViewTextBoxColumn.DataPropertyName = "Begin Date"
        Me.BeginDateDataGridViewTextBoxColumn.Format = DevComponents.Editors.eDateTimePickerFormat.Custom
        Me.BeginDateDataGridViewTextBoxColumn.HeaderText = "Begin Date"
        Me.BeginDateDataGridViewTextBoxColumn.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left
        '
        '
        '
        Me.BeginDateDataGridViewTextBoxColumn.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.BeginDateDataGridViewTextBoxColumn.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.BeginDateDataGridViewTextBoxColumn.MonthCalendar.BackgroundStyle.Class = ""
        Me.BeginDateDataGridViewTextBoxColumn.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.BeginDateDataGridViewTextBoxColumn.MonthCalendar.CommandsBackgroundStyle.Class = ""
        Me.BeginDateDataGridViewTextBoxColumn.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.BeginDateDataGridViewTextBoxColumn.MonthCalendar.DisplayMonth = New Date(2011, 3, 1, 0, 0, 0, 0)
        Me.BeginDateDataGridViewTextBoxColumn.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.BeginDateDataGridViewTextBoxColumn.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.BeginDateDataGridViewTextBoxColumn.MonthCalendar.NavigationBackgroundStyle.Class = ""
        Me.BeginDateDataGridViewTextBoxColumn.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.BeginDateDataGridViewTextBoxColumn.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.BeginDateDataGridViewTextBoxColumn.Name = "BeginDateDataGridViewTextBoxColumn"
        Me.BeginDateDataGridViewTextBoxColumn.ReadOnly = True
        Me.BeginDateDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.BeginDateDataGridViewTextBoxColumn.Width = 120
        '
        'FinalDateDataGridViewTextBoxColumn
        '
        '
        '
        '
        Me.FinalDateDataGridViewTextBoxColumn.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.FinalDateDataGridViewTextBoxColumn.BackgroundStyle.Class = "DataGridViewDateTimeBorder"
        Me.FinalDateDataGridViewTextBoxColumn.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.FinalDateDataGridViewTextBoxColumn.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText
        Me.FinalDateDataGridViewTextBoxColumn.CustomFormat = "yyyy/MM/dd hh:mm:ss"
        Me.FinalDateDataGridViewTextBoxColumn.DataPropertyName = "Final Date"
        Me.FinalDateDataGridViewTextBoxColumn.Format = DevComponents.Editors.eDateTimePickerFormat.Custom
        Me.FinalDateDataGridViewTextBoxColumn.HeaderText = "Final Date"
        Me.FinalDateDataGridViewTextBoxColumn.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left
        '
        '
        '
        Me.FinalDateDataGridViewTextBoxColumn.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.FinalDateDataGridViewTextBoxColumn.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.FinalDateDataGridViewTextBoxColumn.MonthCalendar.BackgroundStyle.Class = ""
        Me.FinalDateDataGridViewTextBoxColumn.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.FinalDateDataGridViewTextBoxColumn.MonthCalendar.CommandsBackgroundStyle.Class = ""
        Me.FinalDateDataGridViewTextBoxColumn.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.FinalDateDataGridViewTextBoxColumn.MonthCalendar.DisplayMonth = New Date(2011, 3, 1, 0, 0, 0, 0)
        Me.FinalDateDataGridViewTextBoxColumn.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.FinalDateDataGridViewTextBoxColumn.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.FinalDateDataGridViewTextBoxColumn.MonthCalendar.NavigationBackgroundStyle.Class = ""
        Me.FinalDateDataGridViewTextBoxColumn.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.FinalDateDataGridViewTextBoxColumn.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.FinalDateDataGridViewTextBoxColumn.Name = "FinalDateDataGridViewTextBoxColumn"
        Me.FinalDateDataGridViewTextBoxColumn.ReadOnly = True
        Me.FinalDateDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.FinalDateDataGridViewTextBoxColumn.Width = 120
        '
        'SaveDetailsColumn
        '
        Me.SaveDetailsColumn.HeaderText = "Save Details"
        Me.SaveDetailsColumn.Name = "SaveDetailsColumn"
        Me.SaveDetailsColumn.ReadOnly = True
        Me.SaveDetailsColumn.Text = "Save Details"
        '
        'SummaryBindingSource
        '
        Me.SummaryBindingSource.DataMember = "Summary"
        Me.SummaryBindingSource.DataSource = Me.SummaryDataSet1
        '
        'SummaryDataSet1
        '
        Me.SummaryDataSet1.DataSetName = "SummaryDataSet"
        Me.SummaryDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'StyleManager1
        '
        Me.StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Silver
        '
        'butSaveErrors
        '
        Me.butSaveErrors.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.butSaveErrors.Location = New System.Drawing.Point(442, 340)
        Me.butSaveErrors.Name = "butSaveErrors"
        Me.butSaveErrors.Size = New System.Drawing.Size(161, 29)
        Me.butSaveErrors.TabIndex = 13
        Me.butSaveErrors.Text = "Save List of Errors"
        Me.butSaveErrors.UseVisualStyleBackColor = True
        '
        'ErrorsSaveFileDialog
        '
        Me.ErrorsSaveFileDialog.Filter = "CSV (Comma delimited) (*.csv)|*.csv"
        Me.ErrorsSaveFileDialog.Title = "Save List of Errors"
        '
        'DetailsSaveFileDialog
        '
        Me.DetailsSaveFileDialog.Filter = "CSV (Comma delimited) (*.csv)|*.csv"
        '
        'SummaryViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(825, 381)
        Me.Controls.Add(Me.butSaveErrors)
        Me.Controls.Add(Me.uxSummaryDataGridView)
        Me.Controls.Add(Me.butAcept)
        Me.MinimizeBox = False
        Me.Name = "SummaryViewer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Summary"
        CType(Me.uxSummaryDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SummaryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SummaryDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents butAcept As System.Windows.Forms.Button
    Friend WithEvents uxSummaryDataGridView As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents SummaryDataSet1 As DataManager.SummaryDataSet
    Friend WithEvents StyleManager1 As DevComponents.DotNetBar.StyleManager
    Friend WithEvents SummaryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents butSaveErrors As System.Windows.Forms.Button
    Friend WithEvents ErrorsSaveFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents FileNameDataGridViewTextBoxColumn As DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn
    Friend WithEvents InsertDataGridViewTextBoxColumn As DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn
    Friend WithEvents UpdateDataGridViewTextBoxColumn As DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn
    Friend WithEvents BeginDateDataGridViewTextBoxColumn As DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn
    Friend WithEvents FinalDateDataGridViewTextBoxColumn As DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn
    Friend WithEvents SaveDetailsColumn As DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn
    Friend WithEvents DetailsSaveFileDialog As System.Windows.Forms.SaveFileDialog
End Class

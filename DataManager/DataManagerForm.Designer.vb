<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DataManagerForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DataManagerForm))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.uxConnect_DisconnectPDAMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.uxOpenQMDToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.OpenMainDatabaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ImportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.uxImputPDAToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.uxImputFromQMDFilesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.uxExportToSASToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.uxExportToMainDBToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.QueryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExecuteQueryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClearQueryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.uxMainDataBaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.uxPDADataBaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.uxQMDFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PruebaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.uxOpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.Splitter1 = New System.Windows.Forms.Splitter
        Me.txtShowQuery = New System.Windows.Forms.TextBox
        Me.uxGroupBoxOptions = New System.Windows.Forms.GroupBox
        Me.ckbTrimNames = New System.Windows.Forms.CheckBox
        Me.uxGroupBoxConnection = New System.Windows.Forms.GroupBox
        Me.rbQMDFile = New System.Windows.Forms.RadioButton
        Me.rbPDADataBase = New System.Windows.Forms.RadioButton
        Me.rbMainDataBase = New System.Windows.Forms.RadioButton
        Me.uxGroupBoxCondition = New System.Windows.Forms.GroupBox
        Me.txtWhereQuery = New System.Windows.Forms.TextBox
        Me.uxSaveFileDialogSAS = New System.Windows.Forms.SaveFileDialog
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Splitter4 = New System.Windows.Forms.Splitter
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.uxPencilPictureBox = New System.Windows.Forms.PictureBox
        Me.uxPicturePDA = New System.Windows.Forms.PictureBox
        Me.uxPictureComputer = New System.Windows.Forms.PictureBox
        Me.uxPictureSDFFile = New System.Windows.Forms.PictureBox
        Me.Splitter3 = New System.Windows.Forms.Splitter
        Me.Splitter2 = New System.Windows.Forms.Splitter
        Me.uxOpenQMDToImport = New System.Windows.Forms.OpenFileDialog
        Me.Splitter5 = New System.Windows.Forms.Splitter
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.uxRowsToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.uxReadOnlyToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.uxDataGridViewX = New DevComponents.DotNetBar.Controls.DataGridViewX
        Me.StyleManager1 = New DevComponents.DotNetBar.StyleManager(Me.components)
        Me.Bar1 = New DevComponents.DotNetBar.Bar
        Me.butEdit = New DevComponents.DotNetBar.ButtonItem
        Me.butAcceptChanges = New DevComponents.DotNetBar.ButtonItem
        Me.butDorpChanges = New DevComponents.DotNetBar.ButtonItem
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.uxStructureTree = New DataManager.StructureControl2
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.ImportFromDBFilessToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuStrip1.SuspendLayout()
        Me.uxGroupBoxOptions.SuspendLayout()
        Me.uxGroupBoxConnection.SuspendLayout()
        Me.uxGroupBoxCondition.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.uxPencilPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uxPicturePDA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uxPictureComputer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uxPictureSDFFile, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.uxDataGridViewX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ImportToolStripMenuItem, Me.ExportToolStripMenuItem, Me.QueryToolStripMenuItem, Me.ViewToolStripMenuItem, Me.PruebaToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1074, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.uxConnect_DisconnectPDAMenuItem, Me.uxOpenQMDToolStripMenuItem, Me.ToolStripSeparator3, Me.OpenMainDatabaseToolStripMenuItem, Me.CloseToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'uxConnect_DisconnectPDAMenuItem
        '
        Me.uxConnect_DisconnectPDAMenuItem.Name = "uxConnect_DisconnectPDAMenuItem"
        Me.uxConnect_DisconnectPDAMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.uxConnect_DisconnectPDAMenuItem.Text = "Connect PDA"
        '
        'uxOpenQMDToolStripMenuItem
        '
        Me.uxOpenQMDToolStripMenuItem.Name = "uxOpenQMDToolStripMenuItem"
        Me.uxOpenQMDToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.uxOpenQMDToolStripMenuItem.Text = "Open QMD File..."
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(182, 6)
        '
        'OpenMainDatabaseToolStripMenuItem
        '
        Me.OpenMainDatabaseToolStripMenuItem.Name = "OpenMainDatabaseToolStripMenuItem"
        Me.OpenMainDatabaseToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.OpenMainDatabaseToolStripMenuItem.Text = "Open Main Database"
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.CloseToolStripMenuItem.Text = "Close"
        '
        'ImportToolStripMenuItem
        '
        Me.ImportToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.uxImputPDAToolStripMenuItem, Me.uxImputFromQMDFilesToolStripMenuItem, Me.ImportFromDBFilessToolStripMenuItem})
        Me.ImportToolStripMenuItem.Name = "ImportToolStripMenuItem"
        Me.ImportToolStripMenuItem.Size = New System.Drawing.Size(51, 20)
        Me.ImportToolStripMenuItem.Text = "Import"
        '
        'uxImputPDAToolStripMenuItem
        '
        Me.uxImputPDAToolStripMenuItem.Name = "uxImputPDAToolStripMenuItem"
        Me.uxImputPDAToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.uxImputPDAToolStripMenuItem.Text = "Import From PDA"
        '
        'uxImputFromQMDFilesToolStripMenuItem
        '
        Me.uxImputFromQMDFilesToolStripMenuItem.Name = "uxImputFromQMDFilesToolStripMenuItem"
        Me.uxImputFromQMDFilesToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.uxImputFromQMDFilesToolStripMenuItem.Text = "Import From QMD File(s)..."
        '
        'ExportToolStripMenuItem
        '
        Me.ExportToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.uxExportToSASToolStripMenuItem, Me.ToolStripSeparator2, Me.uxExportToMainDBToolStripMenuItem})
        Me.ExportToolStripMenuItem.Name = "ExportToolStripMenuItem"
        Me.ExportToolStripMenuItem.Size = New System.Drawing.Size(51, 20)
        Me.ExportToolStripMenuItem.Text = "Export"
        '
        'uxExportToSASToolStripMenuItem
        '
        Me.uxExportToSASToolStripMenuItem.Name = "uxExportToSASToolStripMenuItem"
        Me.uxExportToSASToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.uxExportToSASToolStripMenuItem.Text = "Export To SAS"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(170, 6)
        '
        'uxExportToMainDBToolStripMenuItem
        '
        Me.uxExportToMainDBToolStripMenuItem.Name = "uxExportToMainDBToolStripMenuItem"
        Me.uxExportToMainDBToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.uxExportToMainDBToolStripMenuItem.Text = "Export To Main DB"
        '
        'QueryToolStripMenuItem
        '
        Me.QueryToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExecuteQueryToolStripMenuItem, Me.ClearQueryToolStripMenuItem})
        Me.QueryToolStripMenuItem.Name = "QueryToolStripMenuItem"
        Me.QueryToolStripMenuItem.Size = New System.Drawing.Size(49, 20)
        Me.QueryToolStripMenuItem.Text = "Query"
        '
        'ExecuteQueryToolStripMenuItem
        '
        Me.ExecuteQueryToolStripMenuItem.Name = "ExecuteQueryToolStripMenuItem"
        Me.ExecuteQueryToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.ExecuteQueryToolStripMenuItem.Text = "Execute Query"
        '
        'ClearQueryToolStripMenuItem
        '
        Me.ClearQueryToolStripMenuItem.Name = "ClearQueryToolStripMenuItem"
        Me.ClearQueryToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.ClearQueryToolStripMenuItem.Text = "Clear Query"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.uxMainDataBaseToolStripMenuItem, Me.uxPDADataBaseToolStripMenuItem, Me.uxQMDFileToolStripMenuItem})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(41, 20)
        Me.ViewToolStripMenuItem.Text = "View"
        '
        'uxMainDataBaseToolStripMenuItem
        '
        Me.uxMainDataBaseToolStripMenuItem.Checked = True
        Me.uxMainDataBaseToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.uxMainDataBaseToolStripMenuItem.Name = "uxMainDataBaseToolStripMenuItem"
        Me.uxMainDataBaseToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.uxMainDataBaseToolStripMenuItem.Text = "Main Data Base"
        '
        'uxPDADataBaseToolStripMenuItem
        '
        Me.uxPDADataBaseToolStripMenuItem.Name = "uxPDADataBaseToolStripMenuItem"
        Me.uxPDADataBaseToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.uxPDADataBaseToolStripMenuItem.Text = "PDA Data Base"
        '
        'uxQMDFileToolStripMenuItem
        '
        Me.uxQMDFileToolStripMenuItem.Name = "uxQMDFileToolStripMenuItem"
        Me.uxQMDFileToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.uxQMDFileToolStripMenuItem.Text = "QMD File"
        '
        'PruebaToolStripMenuItem
        '
        Me.PruebaToolStripMenuItem.Name = "PruebaToolStripMenuItem"
        Me.PruebaToolStripMenuItem.Size = New System.Drawing.Size(53, 20)
        Me.PruebaToolStripMenuItem.Text = "Prueba"
        '
        'uxOpenFileDialog
        '
        Me.uxOpenFileDialog.Filter = "QMD Data Files|*.qmd"
        '
        'Splitter1
        '
        Me.Splitter1.Location = New System.Drawing.Point(268, 24)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(3, 666)
        Me.Splitter1.TabIndex = 5
        Me.Splitter1.TabStop = False
        '
        'txtShowQuery
        '
        Me.txtShowQuery.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtShowQuery.Location = New System.Drawing.Point(271, 617)
        Me.txtShowQuery.Multiline = True
        Me.txtShowQuery.Name = "txtShowQuery"
        Me.txtShowQuery.ReadOnly = True
        Me.txtShowQuery.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtShowQuery.Size = New System.Drawing.Size(803, 73)
        Me.txtShowQuery.TabIndex = 6
        '
        'uxGroupBoxOptions
        '
        Me.uxGroupBoxOptions.Controls.Add(Me.ckbTrimNames)
        Me.uxGroupBoxOptions.Controls.Add(Me.uxGroupBoxConnection)
        Me.uxGroupBoxOptions.Dock = System.Windows.Forms.DockStyle.Left
        Me.uxGroupBoxOptions.Location = New System.Drawing.Point(0, 0)
        Me.uxGroupBoxOptions.MinimumSize = New System.Drawing.Size(309, 122)
        Me.uxGroupBoxOptions.Name = "uxGroupBoxOptions"
        Me.uxGroupBoxOptions.Size = New System.Drawing.Size(309, 122)
        Me.uxGroupBoxOptions.TabIndex = 3
        Me.uxGroupBoxOptions.TabStop = False
        Me.uxGroupBoxOptions.Text = "Options"
        '
        'ckbTrimNames
        '
        Me.ckbTrimNames.AutoSize = True
        Me.ckbTrimNames.Location = New System.Drawing.Point(13, 29)
        Me.ckbTrimNames.Name = "ckbTrimNames"
        Me.ckbTrimNames.Size = New System.Drawing.Size(127, 17)
        Me.ckbTrimNames.TabIndex = 5
        Me.ckbTrimNames.Text = "Trim Names (for SAS)"
        Me.ckbTrimNames.UseVisualStyleBackColor = True
        '
        'uxGroupBoxConnection
        '
        Me.uxGroupBoxConnection.Controls.Add(Me.rbQMDFile)
        Me.uxGroupBoxConnection.Controls.Add(Me.rbPDADataBase)
        Me.uxGroupBoxConnection.Controls.Add(Me.rbMainDataBase)
        Me.uxGroupBoxConnection.Location = New System.Drawing.Point(153, 16)
        Me.uxGroupBoxConnection.Name = "uxGroupBoxConnection"
        Me.uxGroupBoxConnection.Size = New System.Drawing.Size(143, 97)
        Me.uxGroupBoxConnection.TabIndex = 4
        Me.uxGroupBoxConnection.TabStop = False
        Me.uxGroupBoxConnection.Text = "Connection"
        '
        'rbQMDFile
        '
        Me.rbQMDFile.AutoSize = True
        Me.rbQMDFile.Location = New System.Drawing.Point(7, 68)
        Me.rbQMDFile.Name = "rbQMDFile"
        Me.rbQMDFile.Size = New System.Drawing.Size(69, 17)
        Me.rbQMDFile.TabIndex = 2
        Me.rbQMDFile.Text = "QMD File"
        Me.rbQMDFile.UseVisualStyleBackColor = True
        '
        'rbPDADataBase
        '
        Me.rbPDADataBase.AutoSize = True
        Me.rbPDADataBase.Location = New System.Drawing.Point(7, 44)
        Me.rbPDADataBase.Name = "rbPDADataBase"
        Me.rbPDADataBase.Size = New System.Drawing.Size(100, 17)
        Me.rbPDADataBase.TabIndex = 1
        Me.rbPDADataBase.Text = "PDA Data Base"
        Me.rbPDADataBase.UseVisualStyleBackColor = True
        '
        'rbMainDataBase
        '
        Me.rbMainDataBase.AutoSize = True
        Me.rbMainDataBase.Checked = True
        Me.rbMainDataBase.Location = New System.Drawing.Point(7, 20)
        Me.rbMainDataBase.Name = "rbMainDataBase"
        Me.rbMainDataBase.Size = New System.Drawing.Size(101, 17)
        Me.rbMainDataBase.TabIndex = 0
        Me.rbMainDataBase.TabStop = True
        Me.rbMainDataBase.Text = "Main Data Base"
        Me.rbMainDataBase.UseVisualStyleBackColor = True
        '
        'uxGroupBoxCondition
        '
        Me.uxGroupBoxCondition.Controls.Add(Me.txtWhereQuery)
        Me.uxGroupBoxCondition.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uxGroupBoxCondition.Location = New System.Drawing.Point(422, 0)
        Me.uxGroupBoxCondition.Name = "uxGroupBoxCondition"
        Me.uxGroupBoxCondition.Size = New System.Drawing.Size(381, 122)
        Me.uxGroupBoxCondition.TabIndex = 1
        Me.uxGroupBoxCondition.TabStop = False
        Me.uxGroupBoxCondition.Text = "Condition"
        '
        'txtWhereQuery
        '
        Me.txtWhereQuery.AllowDrop = True
        Me.txtWhereQuery.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtWhereQuery.Location = New System.Drawing.Point(3, 16)
        Me.txtWhereQuery.Multiline = True
        Me.txtWhereQuery.Name = "txtWhereQuery"
        Me.txtWhereQuery.Size = New System.Drawing.Size(375, 103)
        Me.txtWhereQuery.TabIndex = 0
        '
        'uxSaveFileDialogSAS
        '
        Me.uxSaveFileDialogSAS.DefaultExt = "sas"
        Me.uxSaveFileDialogSAS.Filter = "SAS script|*.sas"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.uxGroupBoxCondition)
        Me.Panel1.Controls.Add(Me.Splitter4)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Splitter3)
        Me.Panel1.Controls.Add(Me.uxGroupBoxOptions)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(271, 24)
        Me.Panel1.MinimumSize = New System.Drawing.Size(0, 115)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(803, 122)
        Me.Panel1.TabIndex = 7
        '
        'Splitter4
        '
        Me.Splitter4.Location = New System.Drawing.Point(419, 0)
        Me.Splitter4.Name = "Splitter4"
        Me.Splitter4.Size = New System.Drawing.Size(3, 122)
        Me.Splitter4.TabIndex = 6
        Me.Splitter4.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.uxPencilPictureBox)
        Me.Panel2.Controls.Add(Me.uxPicturePDA)
        Me.Panel2.Controls.Add(Me.uxPictureComputer)
        Me.Panel2.Controls.Add(Me.uxPictureSDFFile)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(312, 0)
        Me.Panel2.MinimumSize = New System.Drawing.Size(107, 122)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(107, 122)
        Me.Panel2.TabIndex = 5
        '
        'uxPencilPictureBox
        '
        Me.uxPencilPictureBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.uxPencilPictureBox.BackColor = System.Drawing.Color.White
        Me.uxPencilPictureBox.Image = CType(resources.GetObject("uxPencilPictureBox.Image"), System.Drawing.Image)
        Me.uxPencilPictureBox.Location = New System.Drawing.Point(86, 0)
        Me.uxPencilPictureBox.Name = "uxPencilPictureBox"
        Me.uxPencilPictureBox.Size = New System.Drawing.Size(21, 20)
        Me.uxPencilPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.uxPencilPictureBox.TabIndex = 11
        Me.uxPencilPictureBox.TabStop = False
        Me.uxPencilPictureBox.Visible = False
        '
        'uxPicturePDA
        '
        Me.uxPicturePDA.BackColor = System.Drawing.Color.White
        Me.uxPicturePDA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uxPicturePDA.Image = CType(resources.GetObject("uxPicturePDA.Image"), System.Drawing.Image)
        Me.uxPicturePDA.Location = New System.Drawing.Point(0, 0)
        Me.uxPicturePDA.Name = "uxPicturePDA"
        Me.uxPicturePDA.Size = New System.Drawing.Size(107, 122)
        Me.uxPicturePDA.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.uxPicturePDA.TabIndex = 1
        Me.uxPicturePDA.TabStop = False
        Me.uxPicturePDA.Visible = False
        '
        'uxPictureComputer
        '
        Me.uxPictureComputer.BackColor = System.Drawing.Color.White
        Me.uxPictureComputer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uxPictureComputer.Image = CType(resources.GetObject("uxPictureComputer.Image"), System.Drawing.Image)
        Me.uxPictureComputer.Location = New System.Drawing.Point(0, 0)
        Me.uxPictureComputer.Name = "uxPictureComputer"
        Me.uxPictureComputer.Size = New System.Drawing.Size(107, 122)
        Me.uxPictureComputer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.uxPictureComputer.TabIndex = 0
        Me.uxPictureComputer.TabStop = False
        Me.uxPictureComputer.Visible = False
        '
        'uxPictureSDFFile
        '
        Me.uxPictureSDFFile.BackColor = System.Drawing.Color.White
        Me.uxPictureSDFFile.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uxPictureSDFFile.Image = CType(resources.GetObject("uxPictureSDFFile.Image"), System.Drawing.Image)
        Me.uxPictureSDFFile.Location = New System.Drawing.Point(0, 0)
        Me.uxPictureSDFFile.Name = "uxPictureSDFFile"
        Me.uxPictureSDFFile.Size = New System.Drawing.Size(107, 122)
        Me.uxPictureSDFFile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.uxPictureSDFFile.TabIndex = 2
        Me.uxPictureSDFFile.TabStop = False
        Me.uxPictureSDFFile.Visible = False
        '
        'Splitter3
        '
        Me.Splitter3.Location = New System.Drawing.Point(309, 0)
        Me.Splitter3.Name = "Splitter3"
        Me.Splitter3.Size = New System.Drawing.Size(3, 122)
        Me.Splitter3.TabIndex = 4
        Me.Splitter3.TabStop = False
        '
        'Splitter2
        '
        Me.Splitter2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Splitter2.Location = New System.Drawing.Point(271, 146)
        Me.Splitter2.Name = "Splitter2"
        Me.Splitter2.Size = New System.Drawing.Size(803, 3)
        Me.Splitter2.TabIndex = 8
        Me.Splitter2.TabStop = False
        '
        'uxOpenQMDToImport
        '
        Me.uxOpenQMDToImport.Filter = "QMD Data Files|*.qmd"
        Me.uxOpenQMDToImport.Multiselect = True
        '
        'Splitter5
        '
        Me.Splitter5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Splitter5.Location = New System.Drawing.Point(271, 614)
        Me.Splitter5.Name = "Splitter5"
        Me.Splitter5.Size = New System.Drawing.Size(803, 3)
        Me.Splitter5.TabIndex = 9
        Me.Splitter5.TabStop = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.uxRowsToolStripStatusLabel, Me.uxReadOnlyToolStripStatusLabel})
        Me.StatusStrip1.Location = New System.Drawing.Point(271, 592)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(803, 22)
        Me.StatusStrip1.TabIndex = 10
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'uxRowsToolStripStatusLabel
        '
        Me.uxRowsToolStripStatusLabel.Name = "uxRowsToolStripStatusLabel"
        Me.uxRowsToolStripStatusLabel.Size = New System.Drawing.Size(46, 17)
        Me.uxRowsToolStripStatusLabel.Text = "Rows: 0"
        '
        'uxReadOnlyToolStripStatusLabel
        '
        Me.uxReadOnlyToolStripStatusLabel.Name = "uxReadOnlyToolStripStatusLabel"
        Me.uxReadOnlyToolStripStatusLabel.Size = New System.Drawing.Size(164, 17)
        Me.uxReadOnlyToolStripStatusLabel.Text = "uxReadOnlyToolStripStatusLabel"
        '
        'uxDataGridViewX
        '
        Me.uxDataGridViewX.AllowUserToAddRows = False
        Me.uxDataGridViewX.AllowUserToDeleteRows = False
        Me.uxDataGridViewX.AllowUserToOrderColumns = True
        Me.uxDataGridViewX.AllowUserToResizeColumns = False
        Me.uxDataGridViewX.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.uxDataGridViewX.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.uxDataGridViewX.DefaultCellStyle = DataGridViewCellStyle5
        Me.uxDataGridViewX.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uxDataGridViewX.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.uxDataGridViewX.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.uxDataGridViewX.Location = New System.Drawing.Point(271, 185)
        Me.uxDataGridViewX.Name = "uxDataGridViewX"
        Me.uxDataGridViewX.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.uxDataGridViewX.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.uxDataGridViewX.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.uxDataGridViewX.Size = New System.Drawing.Size(803, 407)
        Me.uxDataGridViewX.TabIndex = 11
        '
        'StyleManager1
        '
        Me.StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Silver
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.butEdit, Me.butAcceptChanges, Me.butDorpChanges})
        Me.Bar1.Location = New System.Drawing.Point(271, 149)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(803, 36)
        Me.Bar1.Stretch = True
        Me.Bar1.TabIndex = 12
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        Me.Bar1.ThemeAware = True
        '
        'butEdit
        '
        Me.butEdit.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.butEdit.Image = CType(resources.GetObject("butEdit.Image"), System.Drawing.Image)
        Me.butEdit.Name = "butEdit"
        Me.butEdit.Text = "Edit"
        Me.butEdit.ThemeAware = True
        '
        'butAcceptChanges
        '
        Me.butAcceptChanges.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.butAcceptChanges.Enabled = False
        Me.butAcceptChanges.Image = CType(resources.GetObject("butAcceptChanges.Image"), System.Drawing.Image)
        Me.butAcceptChanges.Name = "butAcceptChanges"
        Me.butAcceptChanges.Text = "Accept"
        Me.butAcceptChanges.ThemeAware = True
        '
        'butDorpChanges
        '
        Me.butDorpChanges.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.butDorpChanges.Enabled = False
        Me.butDorpChanges.Image = CType(resources.GetObject("butDorpChanges.Image"), System.Drawing.Image)
        Me.butDorpChanges.ImageIndex = 0
        Me.butDorpChanges.Name = "butDorpChanges"
        Me.butDorpChanges.Text = "Cancel"
        Me.butDorpChanges.ThemeAware = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Cancel Small.png")
        '
        'uxStructureTree
        '
        Me.uxStructureTree.ColumnsInfo = Nothing
        Me.uxStructureTree.Dock = System.Windows.Forms.DockStyle.Left
        Me.uxStructureTree.Location = New System.Drawing.Point(0, 24)
        Me.uxStructureTree.Name = "uxStructureTree"
        Me.uxStructureTree.Size = New System.Drawing.Size(268, 666)
        Me.uxStructureTree.TabIndex = 3
        '
        'BindingSource1
        '
        '
        'ImportFromDBFilessToolStripMenuItem
        '
        Me.ImportFromDBFilessToolStripMenuItem.Name = "ImportFromDBFilessToolStripMenuItem"
        Me.ImportFromDBFilessToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.ImportFromDBFilessToolStripMenuItem.Text = "Import From DB files(s)"
        '
        'DataManagerForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1074, 690)
        Me.Controls.Add(Me.uxDataGridViewX)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Splitter5)
        Me.Controls.Add(Me.Splitter2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txtShowQuery)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.uxStructureTree)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "DataManagerForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Data Manager"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.uxGroupBoxOptions.ResumeLayout(False)
        Me.uxGroupBoxOptions.PerformLayout()
        Me.uxGroupBoxConnection.ResumeLayout(False)
        Me.uxGroupBoxConnection.PerformLayout()
        Me.uxGroupBoxCondition.ResumeLayout(False)
        Me.uxGroupBoxCondition.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.uxPencilPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uxPicturePDA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uxPictureComputer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uxPictureSDFFile, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.uxDataGridViewX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents uxOpenQMDToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents uxOpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents uxStructureTree As DataManager.StructureControl2
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents txtShowQuery As System.Windows.Forms.TextBox
    Friend WithEvents uxConnect_DisconnectPDAMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtWhereQuery As System.Windows.Forms.TextBox
    Friend WithEvents uxGroupBoxOptions As System.Windows.Forms.GroupBox
    Friend WithEvents uxGroupBoxCondition As System.Windows.Forms.GroupBox
    Friend WithEvents uxSaveFileDialogSAS As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Splitter4 As System.Windows.Forms.Splitter
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents uxPictureComputer As System.Windows.Forms.PictureBox
    Friend WithEvents Splitter3 As System.Windows.Forms.Splitter
    Friend WithEvents Splitter2 As System.Windows.Forms.Splitter
    Friend WithEvents uxPicturePDA As System.Windows.Forms.PictureBox
    Friend WithEvents uxPictureSDFFile As System.Windows.Forms.PictureBox
    Friend WithEvents QueryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExecuteQueryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents uxOpenQMDToImport As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Splitter5 As System.Windows.Forms.Splitter
    Friend WithEvents ClearQueryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents uxRowsToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents uxGroupBoxConnection As System.Windows.Forms.GroupBox
    Friend WithEvents rbQMDFile As System.Windows.Forms.RadioButton
    Friend WithEvents rbPDADataBase As System.Windows.Forms.RadioButton
    Friend WithEvents rbMainDataBase As System.Windows.Forms.RadioButton
    Friend WithEvents ImportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents uxImputPDAToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents uxImputFromQMDFilesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents uxExportToSASToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents uxExportToMainDBToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents uxMainDataBaseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents uxPDADataBaseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents uxQMDFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ckbTrimNames As System.Windows.Forms.CheckBox
    Friend WithEvents OpenMainDatabaseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents uxReadOnlyToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents uxPencilPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents uxDataGridViewX As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents StyleManager1 As DevComponents.DotNetBar.StyleManager
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents PruebaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents ImportFromDBFilessToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Private WithEvents butEdit As DevComponents.DotNetBar.ButtonItem
    Private WithEvents butAcceptChanges As DevComponents.DotNetBar.ButtonItem
    Private WithEvents butDorpChanges As DevComponents.DotNetBar.ButtonItem

End Class

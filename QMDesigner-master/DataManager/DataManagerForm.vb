Imports System.Data.SqlServerCe

Public Enum DataSource

    MainDataBase = 1
    PDADataBase = 2
    QMDDataBase = 3

End Enum

Public Class DataManagerForm

#Region " Private Members "

    ''' <summary>
    ''' Current DataBase (QMD, PDA or Main DataBase)
    ''' </summary>
    ''' <remarks></remarks>
    Private _dataSource As DataSource

    Private _dataTableSelect As DataTable

    ' MainDataBase
    Private _mainDB As MainDatabase

    ' External Databases
    Private _PDADataBase As New ExternalDatabase
    Private _QMDDataBase As New ExternalDatabase

    ' Wating Form
    Public Shared _watingForm As New WaitingForm

    ' Used in EditMode 
    Private _editedProgramaticaly As Boolean = False
    Private _columnsInfo As Dictionary(Of String, ColumnInfo)
    Private _currentCellValue As Object
    Private _editMode As Boolean
    Private _tablesToChange As List(Of TableInfo)

    ''' <summary>
    ''' Return the Current External DataBase.  Returns Nothing if the current DataSource is the Main DataBase
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private ReadOnly Property CurrentExternalDataBase() As ExternalDatabase
        Get
            Select Case _dataSource
                Case DataManager.DataSource.PDADataBase
                    Return _PDADataBase
                Case DataManager.DataSource.QMDDataBase
                    Return _QMDDataBase
                Case Else
                    Return Nothing
            End Select
        End Get
    End Property


    Private Property EditMode() As Boolean
        Get
            Return _editMode
        End Get
        Set(ByVal value As Boolean)

            _editedProgramaticaly = False

            'uxDataGrid.ReadOnly = Not _editMode
            uxDataGridViewX.ReadOnly = Not value
            'uxDataGrid.MultiSelect = Not _editMode
            uxDataGridViewX.MultiSelect = Not value

            'uxAcceptChangesToolStripMenuItem.Enabled = value
            'uxDropChangesToolStripMenuItem.Enabled = value
            'uxStartEditingToolStripMenuItem.Enabled = Not value

            uxPencilPictureBox.Visible = value

            If value Then
                'uxDataGrid.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2
                uxDataGridViewX.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2
                uxReadOnlyToolStripStatusLabel.Text = "Editing"
            Else
                'uxDataGrid.EditMode = DataGridViewEditMode.EditProgrammatically
                uxDataGridViewX.EditMode = DataGridViewEditMode.EditProgrammatically
                uxReadOnlyToolStripStatusLabel.Text = "Read Only"
            End If

            uxGroupBoxConnection.Enabled = Not value
            uxGroupBoxCondition.Enabled = Not value
            uxGroupBoxOptions.Enabled = Not value
            uxStructureTree.Enabled = Not value
            FileToolStripMenuItem.Enabled = Not value
            ImportToolStripMenuItem.Enabled = Not value
            ExportToolStripMenuItem.Enabled = Not value
            QueryToolStripMenuItem.Enabled = Not value
            ViewToolStripMenuItem.Enabled = Not value
            butEdit.Enabled = Not value
            butAcceptChanges.Enabled = value
            butDorpChanges.Enabled = value

            _editMode = value

        End Set
    End Property

#End Region

#Region " Public Methods "

    ''' <summary>
    ''' Execute Query
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ExecuteQuery()

        _watingForm.StartWaiting("Executing query, please wait...", "Data Manager")

        Dim query As String = uxStructureTree.GetQuery(Me, ckbTrimNames.Checked, _dataSource = DataSource.MainDataBase)

        'Get Objects used in the EditMode
        _columnsInfo = uxStructureTree.ColumnsInfo

        If txtWhereQuery.Text <> "" Then
            query = String.Format("{0} WHERE {1}", query, txtWhereQuery.Text)
        End If
        EditMode = False
        ShowQueryResult(query)

        _watingForm.StopWaiting()

    End Sub

    ''' <summary>
    ''' Show the Query results in the DataGridView
    ''' </summary>
    ''' <param name="query"></param>
    ''' <remarks></remarks>
    Public Sub ShowQueryResult(ByVal query As String)
        If query <> "" Then

            txtShowQuery.Text = query
            'uxDataGrid.DataSource = Nothing
            uxDataGridViewX.DataSource = Nothing

            'Dim dataTable As DataTable

            Select Case _dataSource

                Case DataManager.DataSource.MainDataBase
                    _dataTableSelect = _mainDB.GetDataTable(query)
                Case Else
                    _dataTableSelect = CurrentExternalDataBase.GetDataTable(query)

            End Select

            ' DataGridView has a bug and Crashes when has 655 or more columns. 
            ' The next code is the workaround.
            Dim oCell As DataGridViewCell = New DataGridViewTextBoxCell

            uxDataGridViewX.AutoGenerateColumns = False

            uxDataGridViewX.Columns.Clear()

            Dim currentColumnInfo As ColumnInfo

            If (_dataTableSelect IsNot Nothing) AndAlso (_dataTableSelect.Columns.Count <> 0) Then

                'DataGridView can't have more than 65535 columns.

                Dim Weight As Integer = CInt((65535 - _dataTableSelect.Columns.Count) / _dataTableSelect.Columns.Count)

                If Weight > 0 Then

                    For Each column As DataColumn In _dataTableSelect.Columns

                        currentColumnInfo = _columnsInfo(column.Caption)
                        Dim tempColumn As DataGridViewColumn = Nothing

                        Select Case currentColumnInfo.Type.ToLower

                            Case "bit"

                                Dim ComboBoxExColumn As New DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn

                                ComboBoxExColumn.Items.Add(System.DBNull.Value)
                                ComboBoxExColumn.Items.Add(True)
                                ComboBoxExColumn.Items.Add(False)
                                ComboBoxExColumn.DrawMode = DrawMode.OwnerDrawFixed
                                ComboBoxExColumn.DropDownStyle = ComboBoxStyle.DropDownList

                                tempColumn = ComboBoxExColumn

                            Case "datetime"

                                Dim DateTimeColumn As New DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn

                                DateTimeColumn.ButtonClear.Visible = True
                                DateTimeColumn.ButtonDropDown.Visible = True
                                DateTimeColumn.Format = DevComponents.Editors.eDateTimePickerFormat.Custom
                                DateTimeColumn.CustomFormat = "yyyy/MM/dd hh:mm:ss"
                                DateTimeColumn.ShowUpDown = True

                                tempColumn = DateTimeColumn

                            Case "float"

                                Dim DoubleColumn As New DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn

                                DoubleColumn.DisplayFormat = "0"

                                tempColumn = DoubleColumn

                            Case "int", "integer"
                                If currentColumnInfo.UseLegalValue And currentColumnInfo.LegalValue IsNot Nothing Then

                                    Dim ComboBoxColumnEx As New DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn
                                    ComboBoxColumnEx.DrawMode = DrawMode.OwnerDrawFixed
                                    ComboBoxColumnEx.DropDownStyle = ComboBoxStyle.DropDownList

                                    ComboBoxColumnEx.Items.Add(System.DBNull.Value)
                                    For Each LVItem As BO.LegalValueItem In currentColumnInfo.LegalValue.LegalValues
                                        ComboBoxColumnEx.Items.Add(LVItem.Value)
                                    Next

                                    tempColumn = ComboBoxColumnEx
                                Else

                                    Dim IntColumn As New DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn

                                    IntColumn.Increment = 1
                                    IntColumn.ShowUpDown = True

                                    tempColumn = IntColumn

                                End If
                            Case "numeric"

                                Dim DoubleColumn As New DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn

                                DoubleColumn.DisplayFormat = "0.00"

                                tempColumn = DoubleColumn

                            Case "nvarchar"

                                tempColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

                            Case "tinyint"

                                Dim IntColumn As New DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn

                                IntColumn.Increment = 1
                                IntColumn.ShowUpDown = True
                                IntColumn.MaxValue = 255
                                IntColumn.MinValue = 0

                                tempColumn = IntColumn

                            Case "uniqueidentifier"

                                tempColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

                        End Select

                        tempColumn.FillWeight = Weight
                        tempColumn.HeaderText = column.Caption
                        tempColumn.Name = column.Caption
                        tempColumn.DataPropertyName = column.Caption
                        tempColumn.ReadOnly = currentColumnInfo.Read_Only
                        tempColumn.Resizable = DataGridViewTriState.True

                        uxDataGridViewX.Columns.Add(tempColumn)

                    Next
                Else

                    MessageBox.Show("The Query can't have more than 65535 columns", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                End If


                uxDataGridViewX.DataSource = _dataTableSelect
                ' uxDataGridViewX.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)

                uxRowsToolStripStatusLabel.Text = String.Format("Rows: {0}", uxDataGridViewX.RowCount)

            End If

        Else
            MessageBox.Show("The query dosen't have columns", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    ''' <summary>
    ''' Clearn the DataGridView.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ClearQuery()
        'uxDataGrid.DataSource = Nothing
        uxDataGridViewX.DataSource = Nothing

        'uxDataGrid.Columns.Clear()
        uxDataGridViewX.Columns.Clear()

        txtShowQuery.Text = ""
    End Sub


    Public Function GetKeys(ByVal table As TableInfo) As DataTable

        Dim query As String = String.Format("SELECT keys.Column_Name, Cols.Data_Type, Cols.Character_Maximum_Length FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE AS keys INNER JOIN INFORMATION_SCHEMA.COLUMNS AS Cols ON keys.Column_Name = Cols.Column_Name AND keys.Table_Name = Cols.Table_Name WHERE keys.Table_Name = '{0}'", table.DataTableName)

        Select Case _dataSource
            Case DataSource.MainDataBase

                Return _mainDB.GetDataTable(query)

            Case DataSource.PDADataBase

                Return _PDADataBase.GetDataTable(query)

            Case DataSource.QMDDataBase

                Return _QMDDataBase.GetDataTable(query)

        End Select

        Return Nothing

    End Function

    Public Function Sort(ByVal obj1 As String, ByVal obj2 As String) As Integer
        Return obj1.ToString.CompareTo(obj2.ToString)
    End Function

#End Region

#Region " Private Methods "

    Private Function GetListFromColumn(ByVal table As DataTable, ByVal column As String) As List(Of String)

        Dim list As New List(Of String)

        For Each row As DataRow In table.Rows

            list.Add(row(column).ToString)

        Next

        Return list

    End Function


    ''' <summary>
    ''' Set the Current Data Source (QMD, PDA or Main DataBase)
    ''' </summary>
    ''' <param name="dataSource"></param>
    ''' <remarks>
    ''' The Funtion Changes the Layout of DataManager depending of the type of dataSource (QMD, PDA or Main DataBase)
    ''' </remarks>
    Private Sub SetDataSource(ByVal dataSource As DataSource)

        Select Case dataSource
            Case DataManager.DataSource.MainDataBase
                uxPictureComputer.Visible = True
                uxPicturePDA.Visible = False
                uxPictureSDFFile.Visible = False
                uxExportToMainDBToolStripMenuItem.Enabled = False
                uxExportToSASToolStripMenuItem.Enabled = True
                uxImputFromQMDFilesToolStripMenuItem.Enabled = True
                If Not rbMainDataBase.Checked Then rbMainDataBase.Checked = True

                'Simulate Radio Buttons on ToolStripMenu 'View'
                If Not uxMainDataBaseToolStripMenuItem.Checked Then uxMainDataBaseToolStripMenuItem.Checked = True
                If uxPDADataBaseToolStripMenuItem.Checked Then uxPDADataBaseToolStripMenuItem.Checked = False
                If uxQMDFileToolStripMenuItem.Checked Then uxQMDFileToolStripMenuItem.Checked = False


            Case DataManager.DataSource.PDADataBase
                uxPictureComputer.Visible = False
                uxPicturePDA.Visible = True
                uxPictureSDFFile.Visible = False
                uxExportToMainDBToolStripMenuItem.Enabled = True
                uxExportToSASToolStripMenuItem.Enabled = False
                uxImputFromQMDFilesToolStripMenuItem.Enabled = False
                If Not rbPDADataBase.Enabled Then rbPDADataBase.Enabled = True
                If Not rbPDADataBase.Checked Then rbPDADataBase.Checked = True
                If Not uxPDADataBaseToolStripMenuItem.Enabled Then uxPDADataBaseToolStripMenuItem.Enabled = True
                If Not uxPDADataBaseToolStripMenuItem.Checked Then uxPDADataBaseToolStripMenuItem.Checked = True
                If Not uxImputPDAToolStripMenuItem.Enabled Then uxImputPDAToolStripMenuItem.Enabled = True
                uxConnect_DisconnectPDAMenuItem.Text = "Disconnect PDA"

                'Simulate Radio Buttons on ToolStripMenu 'View'
                If uxMainDataBaseToolStripMenuItem.Checked Then uxMainDataBaseToolStripMenuItem.Checked = False
                If Not uxPDADataBaseToolStripMenuItem.Checked Then uxPDADataBaseToolStripMenuItem.Checked = True
                If uxQMDFileToolStripMenuItem.Checked Then uxQMDFileToolStripMenuItem.Checked = False

            Case DataManager.DataSource.QMDDataBase
                uxExportToMainDBToolStripMenuItem.Enabled = True
                uxPictureComputer.Visible = False
                uxPicturePDA.Visible = False
                uxPictureSDFFile.Visible = True
                uxExportToSASToolStripMenuItem.Enabled = False
                uxImputFromQMDFilesToolStripMenuItem.Enabled = False
                If Not rbQMDFile.Enabled Then rbQMDFile.Enabled = True
                If Not rbQMDFile.Checked Then rbQMDFile.Checked = True
                If Not uxQMDFileToolStripMenuItem.Enabled Then uxQMDFileToolStripMenuItem.Enabled = True
                If Not uxQMDFileToolStripMenuItem.Checked Then uxQMDFileToolStripMenuItem.Checked = True
                uxOpenQMDToolStripMenuItem.Text = "Close QMD File"

                'Simulate Radio Buttons on ToolStripMenu 'View'
                If uxMainDataBaseToolStripMenuItem.Checked Then uxMainDataBaseToolStripMenuItem.Checked = False
                If uxPDADataBaseToolStripMenuItem.Checked Then uxPDADataBaseToolStripMenuItem.Checked = False
                If Not uxQMDFileToolStripMenuItem.Checked Then uxQMDFileToolStripMenuItem.Checked = True

        End Select
        Me._dataSource = dataSource

    End Sub

    Private Function ImportExternalDataBase(ByVal externalDB As ExternalDatabase) As FileStatistic

        Dim fileStatistics As New FileStatistic(externalDB.Name)
        Dim tempDataTable As DataTable
        Dim waitingFrm As New WaitingForm

        fileStatistics.BeginTime = Date.Now

        waitingFrm.StartWaiting("Importing...", "Data Manager")

        For Each currentQuestionnaireSet As BO.QuestionnaireSet In BO.ContextClass.Study.QuestionnarieSets

            waitingFrm.ChangeText("Importing """ & externalDB.Name & """" & Environment.NewLine & "Table: """ & currentQuestionnaireSet.DataTableName & """")

            'Import QuestionnaireSet
            tempDataTable = externalDB.GetDataTable(String.Format("SELECT * FROM [{0}]", currentQuestionnaireSet.PDADataTableName))
            fileStatistics.AddStatistic(_mainDB.ImportTable(tempDataTable, _
                                                    String.Format("[{0}].[{1}]", BO.ContextClass.Study.DataTableSchema, currentQuestionnaireSet.DataTableName), _
                                                    String.Format("[{0}].[{1}]", BO.ContextClass.Study.LogTableSchema, currentQuestionnaireSet.LogTableName)))

            For Each currentQuestionnaire As BO.Questionnaire In currentQuestionnaireSet.Questionnaires


                waitingFrm.ChangeText("Importing """ & externalDB.Name & """" & Environment.NewLine & "Table: """ & currentQuestionnaire.DataTableName & """")

                'Import Questionnaire
                tempDataTable = externalDB.GetDataTable(String.Format("SELECT * FROM [{0}]", currentQuestionnaire.PDADataTableName))
                fileStatistics.AddStatistic(_mainDB.ImportTable(tempDataTable, _
                                                    String.Format("[{0}].[{1}]", BO.ContextClass.Study.DataTableSchema, currentQuestionnaire.DataTableName), _
                                                    String.Format("[{0}].[{1}]", BO.ContextClass.Study.LogTableSchema, currentQuestionnaire.LogTableName)))

                For Each currentSection As BO.Section In currentQuestionnaire.Sections


                    waitingFrm.ChangeText("Importing """ & externalDB.Name & """" & Environment.NewLine & "Table: """ & currentSection.DataTableName & """")

                    'Import Section
                    tempDataTable = externalDB.GetDataTable(String.Format("SELECT * FROM [{0}]", currentSection.PDADataTableName))
                    fileStatistics.AddStatistic(_mainDB.ImportTable(tempDataTable, _
                                                    String.Format("[{0}].[{1}]", BO.ContextClass.Study.DataTableSchema, currentSection.DataTableName), _
                                                    String.Format("[{0}].[{1}]", BO.ContextClass.Study.LogTableSchema, currentSection.LogTableName)))

                Next

            Next

        Next
        waitingFrm.StopWaiting()

        fileStatistics.EndTime = Date.Now

        Return fileStatistics

    End Function

    ''' <summary>
    ''' Import Data from one External Data Base to the Main DataBase
    ''' </summary>
    ''' <param name="externalDB"></param>
    ''' <param name="isMainDataBaseContext"></param>
    ''' <remarks></remarks>
    Private Sub ImportData(ByVal externalDB As ExternalDatabase, Optional ByVal isMainDataBaseContext As Boolean = True)

        ' Context Message
        Dim messageText As String = IIf(isMainDataBaseContext, "Import", "Export").ToString()

        If externalDB IsNot Nothing AndAlso externalDB.Connected Then

            If MessageBox.Show(String.Format("Do you want to {0} ALL the data?", messageText.ToLower), messageText, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Try

                    _watingForm.StartWaiting(String.Format("{0}ing data, please wait...", messageText), "Data Manager")

                    Dim globalStatistics As New List(Of FileStatistic)()

                    globalStatistics.Add(ImportExternalDataBase(externalDB))

                    _watingForm.StopWaiting()

                    ' Show the Summary Dialog
                    Dim SummaryDialog As New SummaryViewer(globalStatistics)
                    SummaryDialog.ShowDialog()

                Catch ex As Exception

                    _watingForm.StopWaiting()

                    MessageBox.Show(ex.Message, String.Format("Error - DataManager - {0}ing data", messageText), MessageBoxButtons.OK, MessageBoxIcon.Error)

                End Try
            End If

        Else
            MessageBox.Show("External Data Base is Closed", String.Format("{0} Data Error", messageText), MessageBoxButtons.OK, MessageBoxIcon.Error)

        End If
    End Sub

    ''' <summary>
    ''' Import Multiple QMD Files
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ImportMultipleQMDFiles()

        If uxOpenQMDToImport.ShowDialog() = Windows.Forms.DialogResult.OK Then

            Dim globalStatistic As New List(Of FileStatistic)()
            Dim temporalConnection As ExternalDatabase
            Dim fileNames As New List(Of String)

            fileNames.AddRange(uxOpenQMDToImport.FileNames)
            fileNames.Sort(AddressOf Sort)

            For Each fileName As String In fileNames

                temporalConnection = New ExternalDatabase

                Try
                    'Connect to the DataBase
                    temporalConnection.SetConnectionParams(fileName, "Qu3st10nn@1r3M0b1l3")

                Catch ex As Exception

                    Dim fileInfo As New System.IO.FileInfo(fileName)

                    MessageBox.Show("File: " & fileInfo.Name & Environment.NewLine & ex.Message, "Error - DataManager", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    temporalConnection.CloseConnection()

                End Try

                If temporalConnection.Connected Then

                    'Import Data
                    globalStatistic.Add(ImportExternalDataBase(temporalConnection))
                    temporalConnection.CloseConnection()

                End If

            Next

            ' Show the Summary Dialog
            Dim SummaryDialog As New SummaryViewer(globalStatistic)
            SummaryDialog.ShowDialog()

        End If
    End Sub

    ''' <summary>
    ''' Disconect External Database
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DisconectExternalDataBase()
        DisconnectPDA()
        DisconnectQMDFile()
    End Sub

    ''' <summary>
    ''' Get summary message (including error message)
    ''' </summary>
    ''' <param name="fileStatistics"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetSummaryMessage(ByVal fileStatistics As List(Of FileStatistic)) As String

        Dim message As String = ""
        Dim errorMessage As String = "- - - - - - - - - - - -  ERRORS  - - - - - - - - - - - -" & vbCrLf
        Dim errorDetected As Boolean = False
        Dim GlobalSummary As New TableStatistic


        For Each currentFileStatistic As FileStatistic In fileStatistics

            'Gather the statistics of the tables
            Dim fileSummarylStatistic As TableStatistic = currentFileStatistic.SummaryStatistic
            GlobalSummary.AddStats(fileSummarylStatistic)

            'Build an error message if there is an error
            If fileSummarylStatistic.Errors.Count > 0 Then

                errorDetected = True

                'File of the error
                errorMessage &= String.Format("****** File: ""{0}"" ******" & vbCrLf, currentFileStatistic.Name)

                For Each currentTableStatistic As TableStatistic In currentFileStatistic.Statistics

                    If currentTableStatistic.Errors.Count > 0 Then

                        'Table with an error
                        errorMessage &= String.Format(vbTab & "////// Table: ""{0}"" //////" & vbCrLf, currentTableStatistic.Name)

                        For Each errorRegistry As ErrorRegister In currentTableStatistic.Errors

                            'Error Detail
                            errorMessage &= errorRegistry.toString
                            errorMessage &= vbTab & vbTab & "------------------------------------------" & vbCrLf

                        Next

                        errorMessage &= vbTab & "//////////////////////////////" & vbCrLf

                    End If

                Next

                errorMessage &= "******************************" & vbCrLf & vbCrLf & vbCrLf

            End If

        Next


        message &= "-- SUMARY --" & vbCrLf

        message &= String.Format("- Inserted Rows: {0}" & vbCrLf, GlobalSummary.Inserted.ToString)
        message &= String.Format("- Updated Rows: {0}" & vbCrLf, GlobalSummary.Updated.ToString)
        message &= String.Format("- Error Count (see details below): {0}" & vbCrLf, GlobalSummary.Errors.Count.ToString)

        If errorDetected Then
            message &= "--------------------------------------"
            message &= vbCrLf & vbCrLf & errorMessage
        End If

        Return message

    End Function

    ''' <summary>
    ''' Disconnect PDA
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DisconnectPDA()

        _PDADataBase.CloseConnection()
        If rbPDADataBase.Checked Then SetDataSource(DataManager.DataSource.MainDataBase)
        rbPDADataBase.Enabled = False
        uxPDADataBaseToolStripMenuItem.Enabled = False
        uxConnect_DisconnectPDAMenuItem.Text = "Connect PDA"
        If Not _QMDDataBase.Connected Then uxExportToMainDBToolStripMenuItem.Enabled = False
        uxImputPDAToolStripMenuItem.Enabled = False

    End Sub

    ''' <summary>
    ''' Disconect the QMD
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DisconnectQMDFile()

        _QMDDataBase.CloseConnection()
        If rbQMDFile.Checked Then SetDataSource(DataManager.DataSource.MainDataBase)
        rbQMDFile.Enabled = False
        uxQMDFileToolStripMenuItem.Enabled = False
        If Not _PDADataBase.Connected Then uxExportToMainDBToolStripMenuItem.Enabled = False
        uxOpenQMDToolStripMenuItem.Text = "Open QMD File..."

    End Sub


    Private Sub BeginEditMode()

        EditMode = True

        _tablesToChange = New List(Of TableInfo)
    End Sub


    Private Sub EndEditMode()

        EditMode = False

        'uxDataGridViewX.

        If _tablesToChange.Count > 0 Then

            Dim _reviewChangesDialog As New ReviewChangesDialog(_tablesToChange)

            Select Case _dataSource
                Case DataSource.MainDataBase
                    _reviewChangesDialog.SetTargetDataBase(_mainDB)
                Case DataSource.PDADataBase
                    _reviewChangesDialog.SetTargetDataBase(_PDADataBase)
                Case DataSource.QMDDataBase
                    _reviewChangesDialog.SetTargetDataBase(_QMDDataBase)
            End Select

            _reviewChangesDialog.ShowDialog()

            'Rollback the canceled changes
            For Each row As ReviewDataSet.ReviewRow In _reviewChangesDialog.ReviewDataSet.Review.Rows
                uxDataGridViewX.Rows(row.RowIndex).Cells(row.ColumnAlias).Value = row.OldValue
            Next
            _reviewChangesDialog.ReviewDataSet.Review.Clear()

            Me.ClearUncommitedChanges()

        End If

        ''CommitChanges()

    End Sub


    Private Sub CancelEditMode()

        EditMode = False

        RollbackChanges()

        Me.ClearUncommitedChanges()

    End Sub


    Private Function SetKeysValues(ByRef row As RowInfo, ByVal table As TableInfo) As Boolean

        For Each key As KeyInfo In New List(Of KeyInfo)(table.Keys.Values)

            row.AddKeyValue(key, uxDataGridViewX.Rows(row.RowIndex).Cells(key.AliasName).Value)

            If row.GetKeyValue(key) Is System.DBNull.Value Then

                row.ClearKeyValues()
                Return False

            End If

        Next
        Return True

    End Function


    Private Sub RollbackChanges()

        For Each table As TableInfo In _tablesToChange

            For Each row As RowInfo In New List(Of RowInfo)(table.RowsToModify.Values)

                For Each cell As CellInfo In New List(Of CellInfo)(row.CellsToModify.Values)

                    uxDataGridViewX.Rows(row.RowIndex).Cells(cell.Column.AliasName).Value = cell.OldValue

                Next

            Next

        Next

    End Sub


    Private Sub ExecuteQuery(ByVal query As String)
        Select Case _dataSource
            Case DataSource.MainDataBase
                _mainDB.ExecuteNonQuery(query)
            Case DataSource.PDADataBase
                _PDADataBase.ExecuteNonQuery(query)
            Case DataSource.QMDDataBase
                _QMDDataBase.ExecuteNonQuery(query)
        End Select
    End Sub


    Private Sub ClearUncommitedChanges()

        For Each table As TableInfo In _tablesToChange
            table.RowsToModify.Clear()
        Next
        _tablesToChange.Clear()

    End Sub



#End Region

#Region " Event Handlers "

    ''' <summary>
    ''' When the form Loads the data source is the main data base and map the Study 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DataManager_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        'Set main Data Base as data source
        SetDataSource(DataManager.DataSource.MainDataBase)

        'Pass the reference to the StructureTree
        uxStructureTree.uxDataManagerForm = Me

        'Build the Tree
        uxStructureTree.BuildTree()

        ' Layout
        uxExportToMainDBToolStripMenuItem.Enabled = False
        rbPDADataBase.Enabled = False
        rbQMDFile.Enabled = False
        uxPDADataBaseToolStripMenuItem.Enabled = False
        uxQMDFileToolStripMenuItem.Enabled = False
        uxImputPDAToolStripMenuItem.Enabled = False
        uxExportToSASToolStripMenuItem.Enabled = True
        uxImputFromQMDFilesToolStripMenuItem.Enabled = True
        uxConnect_DisconnectPDAMenuItem.Text = "Connect PDA"
        uxOpenQMDToolStripMenuItem.Text = "Open QMD File..."

        EditMode = False

        _mainDB = New MainDatabase(BO.ContextClass.Study.ShortName, Application.StartupPath, String.Format("{0}\data", Application.StartupPath), My.Settings.UserInstanceName)

        Dim ConnectionDialog As New ConnectionDataBaseForm

        While True

            'Prompt the connection string
            If ConnectionDialog.ShowDialog = Windows.Forms.DialogResult.OK Then

                If ConnectionDialog.GetConnectToMDF Then

                    'Connecto to the MDF
                    _mainDB.ConnectToMDF()

                    If _mainDB.VerifyDatabaseVersionAndStudy(True) Then
                        'Everything is fine
                        Exit While
                    Else
                        'Ask another connection string
                        _mainDB.CloseConnection()
                    End If
                ElseIf ConnectionDialog.GetConnectToSQLServer Then

                    'Connect to SQLServer
                    _mainDB.ConnectToSQLServer(ConnectionDialog.GetServerName, ConnectionDialog.GetDataBase, _
                                                    ConnectionDialog.IsTrustedConnection, ConnectionDialog.GetUserName, _
                                                    ConnectionDialog.GetPassword)

                    If _mainDB.VerifyDatabaseVersionAndStudy(False) Then
                        'Everything is fine
                        Exit While
                    Else
                        'Ask another connection string
                        _mainDB.CloseConnection()
                    End If

                End If

            Else
                Me.Close()
                Exit While
            End If

        End While

    End Sub

    ''' <summary>
    ''' Open a QMD or Close the opened QMD
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub OpenQMDToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uxOpenQMDToolStripMenuItem.Click
        'If there is a open QMD File, then Close it
        If rbQMDFile.Enabled Then

            DisconnectQMDFile()

        Else 'If not, then open a QMD File
            If uxOpenFileDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
                Try

                    _QMDDataBase.SetConnectionParams(uxOpenFileDialog.FileName, "Qu3st10nn@1r3M0b1l3")
                    SetDataSource(DataManager.DataSource.QMDDataBase)

                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    _QMDDataBase.CloseConnection()
                End Try
            End If

        End If

    End Sub

    ''' <summary>
    ''' Open DataBase From PDA or Close the DataBase from the PDA (if it is opened)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uxConnect_DisconnectPDAMenuItem.Click
        If rbPDADataBase.Enabled Then
            DisconnectPDA()
        Else
            Try
                _watingForm.StartWaiting("Connecting to PDA, please wait...", "Data manager")
                _PDADataBase.openConnectionPDA("Qu3st10nn@1r3M0b1l3", String.Format("\qm\{0}.qmd", BO.ContextClass.Study.ShortName))
                SetDataSource(DataManager.DataSource.PDADataBase)
                _watingForm.StopWaiting()
            Catch ex As Exception
                _watingForm.StopWaiting()
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End If
    End Sub

    ''' <summary>
    ''' Close the connectons to the databases
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DataManagerForm_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        _PDADataBase.CloseConnection()
        _QMDDataBase.CloseConnection()
        _mainDB.CloseConnection()
        DisconnectQMDFile()
        DisconnectPDA()
    End Sub

    ''' <summary>
    ''' Close Form
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' Import the Data from the PDA
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub uxImportDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uxImputPDAToolStripMenuItem.Click

        If rbPDADataBase.Enabled Then

            ImportData(_PDADataBase)

        End If

    End Sub

    ''' <summary>
    ''' Export to SAS (it's just a connection string)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub uxExportToSASToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uxExportToSASToolStripMenuItem.Click
        If uxSaveFileDialogSAS.ShowDialog() = Windows.Forms.DialogResult.OK Then

            _mainDB.ExportToSAS(uxSaveFileDialogSAS.FileName)

        End If
    End Sub

    ''' <summary>
    ''' Execute the Query and show the result in the DataGridView
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ExecuteQueryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExecuteQueryToolStripMenuItem.Click
        ExecuteQuery()
        'uxDataGridViewX.Rows(
    End Sub

#Region " Drag and Drop Methods "

    ''' <summary>
    ''' Drag Over the txtWhereQuery
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtWhereQuery_DragOver(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtWhereQuery.DragOver

        Dim nodeSource As TreeNodeDataManager = CType(e.Data.GetData(GetType(TreeNodeDataManager)), TreeNodeDataManager)

        e.Effect = DragDropEffects.None

        If nodeSource IsNot Nothing AndAlso (TypeOf nodeSource.Tag Is BO.Question Or TypeOf nodeSource.Tag Is BO.Variable) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    ''' <summary>
    ''' Drop in the txtWhereQuery
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtWhereQuery_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtWhereQuery.DragDrop
        Dim txtBox As TextBox = CType(sender, TextBox)


        Dim nodeSource As TreeNodeDataManager = CType(e.Data.GetData(GetType(TreeNodeDataManager)), TreeNodeDataManager)
        Dim question As BO.Question
        Dim variable As BO.Variable
        Dim parent As BO.GenericObject

        If TypeOf nodeSource.Tag Is BO.Question Then

            question = CType(nodeSource.Tag, BO.Question)
            parent = question.Parent

            Select Case question.VariableScope
                Case BO.VariableScopes.Section
                    While Not TypeOf parent Is BO.Section
                        parent = parent.Parent
                    End While
                    Dim section As BO.Section = CType(parent, BO.Section)
                    Dim questionnaire As BO.Questionnaire = CType(parent.Parent, BO.Questionnaire)
                    txtBox.SelectedText = String.Format("[{0}_{1}].[{2}]", questionnaire.Name, section.Name, question.VariableName).Replace(" "c, "_"c)
                Case BO.VariableScopes.Questionnaire
                    While Not TypeOf parent Is BO.Questionnaire
                        parent = parent.Parent
                    End While
                    txtBox.SelectedText = String.Format("[{0}].[{1}]", CType(parent, BO.Questionnaire).Name.Replace(" "c, "_"c), question.VariableName)
                Case BO.VariableScopes.QuestionnaireSet
                    While Not TypeOf parent Is BO.QuestionnaireSet
                        parent = parent.Parent
                    End While
                    txtBox.SelectedText = String.Format("[{0}].[{1}]", CType(parent, BO.QuestionnaireSet).Name.Replace(" "c, "_"c), question.VariableName)
            End Select

        ElseIf TypeOf nodeSource.Tag Is BO.Variable Then

            variable = CType(nodeSource.Tag, BO.Variable)
            parent = CType(CType(nodeSource.Parent.Parent, TreeNodeDataManager).Tag, BO.GenericObject)

            If TypeOf parent Is BO.Section Then
                txtBox.SelectedText = String.Format("[{0}_{1}].[{2}]", CType(parent.Parent, BO.Questionnaire).Name.Replace(" "c, "_"c) _
                                                , CType(parent, BO.Section).Name.Replace(" "c, "_"c), variable.VariableName)
            ElseIf TypeOf parent Is BO.Questionnaire Then
                txtBox.SelectedText = String.Format("[{0}].[{1}]", CType(parent, BO.Questionnaire).Name.Replace(" "c, "_"c), variable.VariableName)
            ElseIf TypeOf parent Is BO.QuestionnaireSet Then
                txtBox.SelectedText = String.Format("[{0}].[{1}]", CType(parent, BO.QuestionnaireSet).Name.Replace(" "c, "_"c), variable.VariableName)
            End If


        End If

    End Sub

#End Region

    ''' <summary>
    ''' Import multiple QMD Files
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub uxMenuItemImportMultipleData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uxImputFromQMDFilesToolStripMenuItem.Click
        If rbQMDFile.Enabled Then

            Select Case MessageBox.Show("Do you want to import the opened QMD File?", "Import QMD File", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3)
                Case Windows.Forms.DialogResult.Yes
                    ImportData(_QMDDataBase)
                Case Windows.Forms.DialogResult.No
                    ImportMultipleQMDFiles()
                Case Windows.Forms.DialogResult.Cancel
            End Select
        Else
            ImportMultipleQMDFiles()
        End If
    End Sub

    ''' <summary>
    ''' Clear the actual Query.  Clear the DataGridView and the txtShowQuery
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ClearQueryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearQueryToolStripMenuItem.Click
        ClearQuery()
    End Sub


    ''' <summary>
    ''' Set PDA DataBase as current database if the radio button is checked
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rbPDADataBase_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbPDADataBase.CheckedChanged

        If rbPDADataBase.Checked Then

            SetDataSource(DataManager.DataSource.PDADataBase)

        End If

    End Sub

    ''' <summary>
    ''' Set QDM File as data source if the radio button is checked
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rbQMDFile_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbQMDFile.CheckedChanged

        If rbQMDFile.Checked Then

            SetDataSource(DataManager.DataSource.QMDDataBase)

        End If

    End Sub


    ''' <summary>
    ''' Set Main Database as data source
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rbMainDataBase_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbMainDataBase.CheckedChanged

        If rbMainDataBase.Checked Then SetDataSource(DataManager.DataSource.MainDataBase)

    End Sub

    ''' <summary>
    ''' Add Numbers to the Rows
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub uxDataGrid_RowPostPaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles uxDataGridViewX.RowPostPaint
        'Store the Index of the row
        Dim index As String = (e.RowIndex + 1).ToString
        Dim tempDataGridView As DataGridView = CType(sender, DataGridView)

        'prepend leading zeros to the string if necessary to improve
        'appearance. For example, if there are ten rows in the grid,
        'row seven will be numbered as "07" instead of "7". Similarly, if 
        'there are 100 rows in the grid, row seven will be numbered as "007".
        While (index.Length < tempDataGridView.RowCount.ToString().Length)
            index = "0" & index
        End While

        'determine the display size of the row number string using
        'the DataGridView's current font.
        Dim size As SizeF = e.Graphics.MeasureString(index, tempDataGridView.Font)

        'adjust the width of the column that contains the row header cells 
        'if necessary
        Dim width As Integer = CInt(size.Width + 20)
        If (tempDataGridView.RowHeadersWidth < width) Then tempDataGridView.RowHeadersWidth = width

        'this brush will be used to draw the row number string on the
        'row header cell using the system's current ControlText color
        Dim tempBrush As Brush = SystemBrushes.ControlText

        'draw the row number string on the current row header cell using
        'the brush defined above and the DataGridView's default font
        e.Graphics.DrawString(index, tempDataGridView.Font, tempBrush, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

    End Sub

    ''' <summary>
    ''' Import Current External Data Base
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub uxExportToMainDBToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uxExportToMainDBToolStripMenuItem.Click
        ImportData(CurrentExternalDataBase, False)
    End Sub

#Region " Simulate Radio Buttons in 'View' Menu "

    Private Sub PDADataBaseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uxPDADataBaseToolStripMenuItem.Click
        If Not uxPDADataBaseToolStripMenuItem.Checked Then

            SetDataSource(DataManager.DataSource.PDADataBase)

        End If
    End Sub

    Private Sub uxMainDataBaseToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uxMainDataBaseToolStripMenuItem.Click
        If Not uxMainDataBaseToolStripMenuItem.Checked Then

            SetDataSource(DataManager.DataSource.MainDataBase)

        End If
    End Sub

    Private Sub uxQMDFileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uxQMDFileToolStripMenuItem.Click
        If Not uxQMDFileToolStripMenuItem.Checked Then

            SetDataSource(DataManager.DataSource.QMDDataBase)

        End If
    End Sub

#End Region


    ''' <summary>
    ''' Show the Connection Dialog to connect to another database.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks> 
    Private Sub OpenMainDatabaseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenMainDatabaseToolStripMenuItem.Click

        Dim connectionDialog As New ConnectionDataBaseForm
        Dim connectionString As String = ""
        Dim tempMainDB As New MainDatabase(BO.ContextClass.Study.ShortName, Application.StartupPath, _
                                            String.Format("{0}\data", Application.StartupPath), _
                                            My.Settings.UserInstanceName)

        If connectionDialog.ShowDialog = Windows.Forms.DialogResult.OK Then

            Try

                If connectionDialog.GetConnectToMDF Then
                    tempMainDB.ConnectToMDF()
                Else
                    tempMainDB.ConnectToSQLServer(connectionDialog.GetServerName, connectionDialog.GetDataBase, _
                                                    connectionDialog.IsTrustedConnection, connectionDialog.GetUserName, _
                                                    connectionDialog.GetPassword)
                End If

                If tempMainDB.VerifyDatabaseVersionAndStudy(False) Then
                    _mainDB = tempMainDB
                Else
                    MessageBox.Show("DataManager can't connect to the database.", "DataManager", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error - Data Manager")

            End Try
        End If
    End Sub


    Private Sub uxDataGrid_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles uxDataGridViewX.CellValueChanged

        Dim dataGrid As DataGridView = TryCast(sender, DataGridView)

        If dataGrid IsNot Nothing Then

            If _editMode Then

                If _editedProgramaticaly Then
                    _editedProgramaticaly = False
                Else

                    'Create a new Row
                    Dim rowToEdit As New RowInfo(e.RowIndex)
                    Dim columnToEdit As ColumnInfo = _columnsInfo(dataGrid.Columns(e.ColumnIndex).HeaderText)
                    Dim tableToEdit As TableInfo = columnToEdit.Table

                    'Set the Key values of the row
                    If Not SetKeysValues(rowToEdit, tableToEdit) Then

                        MessageBox.Show("The cell cannot be modified because it dosen't have Primary Key.", "DataManager", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        _editedProgramaticaly = True
                        uxDataGridViewX.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = _currentCellValue

                    Else
                        Dim cellToEdit As New CellInfo(_currentCellValue, columnToEdit)
                        cellToEdit.NewValue = dataGrid.Rows(e.RowIndex).Cells(columnToEdit.AliasName).Value

                        rowToEdit.AddCell(cellToEdit)
                        tableToEdit.AddRowsToModify(rowToEdit)

                        If Not _tablesToChange.Contains(tableToEdit) Then

                            _tablesToChange.Add(tableToEdit)

                        End If

                    End If

                End If

            End If

        End If
    End Sub


    ''' <summary>
    ''' Start a Editing Session
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BeginToEditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butEdit.Click

        BeginEditMode()
        uxDataGridViewX.Focus()

    End Sub


    ''' <summary>
    ''' End the Editing Session and Save the Changes
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub AceptChangesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butAcceptChanges.Click

        EndEditMode()

        If uxDataGridViewX.CurrentCell IsNot Nothing Then
            _currentCellValue = uxDataGridViewX.CurrentCell.Value
        End If

    End Sub

    ''' <summary>
    ''' End the Editing Session and Drop the Changes
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CancelChangesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butDorpChanges.Click
        uxDataGridViewX.ReadOnly = Not uxDataGridViewX.ReadOnly
        uxDataGridViewX.ReadOnly = Not uxDataGridViewX.ReadOnly
        If _tablesToChange.Count > 0 Then
            If DevComponents.DotNetBar.TaskDialog.Show("Warning - DataManager", DevComponents.DotNetBar.eTaskDialogIcon.Exclamation, _
                                        "Discard Changes", "Do you want to discard all the changes?", _
                                        DevComponents.DotNetBar.eTaskDialogButton.Yes Or DevComponents.DotNetBar.eTaskDialogButton.No, _
                                        DevComponents.DotNetBar.eTaskDialogBackgroundColor.Tan) = DevComponents.DotNetBar.eTaskDialogResult.Yes Then
                CancelEditMode()

                _currentCellValue = uxDataGridViewX.CurrentCell.Value
            End If
        Else
            CancelEditMode()

            If uxDataGridViewX.CurrentCell IsNot Nothing Then

                _currentCellValue = uxDataGridViewX.CurrentCell.Value

            End If
        End If


    End Sub


    Private Sub uxDataGridViewX_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uxDataGridViewX.CurrentCellChanged

        Dim dataGrid As DataGridView = TryCast(sender, DataGridView)

        If dataGrid IsNot Nothing AndAlso dataGrid.CurrentCell IsNot Nothing Then

            _currentCellValue = dataGrid.CurrentCell.Value

        End If

    End Sub

#End Region

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub PruebaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PruebaToolStripMenuItem.Click

        _dataTableSelect.Rows(0)(0) = System.Guid.NewGuid

    End Sub

    Private Sub BindingSource1_BindingComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.BindingCompleteEventArgs) Handles BindingSource1.BindingComplete

    End Sub

    Private Sub BindingSource1_PositionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingSource1.PositionChanged

    End Sub
End Class

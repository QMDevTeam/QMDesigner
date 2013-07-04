Public Class Main

    Private _study As BO.Study
    Private _objectChanged As Boolean

    ' Load Main.
    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Set references.
        StructureControl1.uxPreviewControl = uxPreviewControl
        'StructureControl1.uxPropertyGrid = uxPropertyGrid
        StructureControl1.uxCtlQuestionnaireSet = UxQuestionnaireSet
        StructureControl1.uxCtlQuestionnaire = UxQuestionnaire
        StructureControl1.uxCtlSection = UxSection
        StructureControl1.uxCtlVariable = UxVariable
        StructureControl1.uxCtlStudy = uxStudy
        StructureControl1.uxCtlQuestion = uxQuestions
        StructureControl1.uxCtlCheckPoint = uxCheckpoint
        StructureControl1.uxCtlInformation = uxlInformation


        ' Load Empty Study.
        _study = DA.Loader.GetStudy(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\Empty Study.sdf")
        _study.QMFileName = Nothing

        If _study Is Nothing Then Exit Sub

        BO.ContextClass.Study = _study
        StructureControl1.MapStudy(_study)

        With cbxLanguage
            .Items.Clear()
            For Each language As BO.Language In BO.Study.LanguageList
                .Items.Add(language)
            Next
            .SelectedItem = BO.ContextClass.CurrentLanguage
        End With

    End Sub

    ' New study.
    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click

        ' Loads the new study database.
        _study = DA.Loader.GetStudy(String.Format("{0}\Empty Study.sdf", AppDomain.CurrentDomain.BaseDirectory))
        _study.setCreationDateTime(Now)

        BO.ContextClass.Study = _study

        ' Clear the studypath.
        _study.QMFileName = ""

        ' Maps the study into the outline.
        StructureControl1.MapStudy(_study)

        ' Save the study in the new location.
        SaveToolStripMenuItem_Click(Nothing, Nothing)

    End Sub

    ' Saves the study as another file.
    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click

        SaveFileDialog1.DefaultExt = "qm"
        SaveFileDialog1.Filter = "QM Files|*.qm"
        SaveFileDialog1.FileName = _study.QMFileName

        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then

            ' If the file replace is reserved or read-only...
            If IO.File.Exists(SaveFileDialog1.FileName) Then
                While Not DA.Functions.CanTouchFile(SaveFileDialog1.FileName)
                    Select Case MessageBox.Show("The selected file is being used by another process or is a read-only file. Do you want to retry?", "File", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning)
                        Case Windows.Forms.DialogResult.Cancel
                            Exit Sub
                    End Select
                End While
            End If

            _study.QMFileName = SaveFileDialog1.FileName
            DA.Storer.SaveStudy(_study, _study.QMFileName)

            MessageBox.Show("Save process ended successfully.")
            BO.ContextClass.HasChanges = False
        End If
    End Sub

    ' Open a study.
    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click

        If OpenQMFileDialog.ShowDialog = Windows.Forms.DialogResult.OK Then

            _study = DA.Loader.GetStudy(OpenQMFileDialog.FileName)

            If _study Is Nothing Then Exit Sub

            BO.ContextClass.Study = _study
            StructureControl1.MapStudy(_study)

            With cbxLanguage
                .Items.Clear()
                For Each language As BO.Language In BO.Study.LanguageList
                    .Items.Add(language)
                Next
                .SelectedItem = BO.ContextClass.CurrentLanguage
            End With

            BO.ContextClass.HasChanges = False
        End If

    End Sub

    ' Saves the study.
    Private Sub SaveToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem1.Click

        If String.IsNullOrEmpty(_study.QMFileName) Then
            ' If no path, save as...
            SaveToolStripMenuItem_Click(sender, e)
            Exit Sub
        Else

            ' If the file replace is reserved or read-only...
            If IO.File.Exists(_study.QMFileName) Then
                While Not DA.Functions.CanTouchFile(_study.QMFileName)
                    Select Case MessageBox.Show("The selected file is being used by another process or is a read-only file. Do you want to retry?", "File", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning)
                        Case Windows.Forms.DialogResult.Cancel
                            Exit Sub
                    End Select
                End While
            End If

            ' Backup the last save.
            Dim backupDirectory As String = String.Format("{0}\{1}", IO.Path.GetDirectoryName(_study.QMFileName), IO.Path.GetFileNameWithoutExtension(_study.QMFileName))
            Dim backupFileName As String = String.Format("{0}\{1} {2}.qm", backupdirectory, _study.ShortName, _study.Version)

            If Not IO.Directory.Exists(backupDirectory) Then
                IO.Directory.CreateDirectory(backupDirectory)
            End If

            IO.File.Copy(Me._study.QMFileName, backupFileName)

            If Not Me._study.OverrideVersionNumber Then Me._study.Version = Me._study.NextVersion

            ' Save changes.
            DA.Storer.SaveStudy(_study, _study.QMFileName)

            MessageBox.Show("Save process ended successfully.")
            BO.ContextClass.HasChanges = False
        End If
    End Sub

    ' Pops up the about window.
    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        Dim pop As New AboutBox1
        pop.ShowDialog()
    End Sub

    'Print Dialog
    Private Sub PrintPreviewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintPreviewToolStripMenuItem.Click
        uxPreviewControl.webPreview.ShowPrintDialog()
    End Sub

    ' Legal values editor.
    Private Sub LegalValuesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LegalValuesToolStripMenuItem.Click

        ' Edit.
        Dim nameProp As Reflection.PropertyInfo = GetType(BO.LegalValuesTable).GetProperty("Name")
        Dim editor As New BO.ListEditorFrm(BO.Study.LegalValues, GetType(BO.LegalValuesTable), "Legal Values Editor", Nothing, nameProp, True, False)
        editor.ShowDialog()
        editor.UpdateInputList()


    End Sub


    ' Sites Editor.
    Private Sub SitesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SitesToolStripMenuItem.Click

        ' Edit.
        Dim editor As New BO.ListEditorFrm(BO.Study.Sites, GetType(BO.Site), "Sites Editor", Nothing, Nothing, True, False)
        editor.ShowDialog()
        editor.UpdateInputList()

    End Sub

    ' Files Editor.
    Private Sub FilesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FilesToolStripMenuItem.Click

        ' Edit.
        Dim nameProp As Reflection.PropertyInfo = GetType(BO.LegalValuesTable).GetProperty("Name")
        Dim editor As New BO.ListEditorFrm(BO.Study.Files, GetType(BO.File), "File references Editor", Nothing, nameProp, True, False)
        editor.ShowDialog()
        editor.UpdateInputList()

    End Sub

    ' Languages Editor.
    Private Sub LanguagesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LanguagesToolStripMenuItem.Click

        ' Edit.
        Dim editor As New BO.ListEditorFrm(BO.Study.LanguageList, GetType(BO.Language), "Languages Editor", Nothing, Nothing, True, False)
        editor.ShowDialog()
        editor.UpdateInputList()

        ' Update the list in the bar and refill the language list in memory.
        cbxLanguage.Items.Clear()
        For Each lang As BO.Language In BO.Study.LanguageList
            cbxLanguage.Items.Add(lang)
        Next
        cbxLanguage.SelectedItem = BO.ContextClass.CurrentLanguage

    End Sub

    'Page Setup Dialog
    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        uxPreviewControl.webPreview.ShowPageSetupDialog()
    End Sub

    'Show the Preview 
    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        uxPreviewControl.Preview(StructureControl1.SelectedAdvNode)
    End Sub

    ' Click a view menu item.
    Private Sub ViewItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StudyOutlineToolStripMenuItem.Click, PropertyGridToolStripMenuItem.Click, PreviewPanelToolStripMenuItem.Click

        ' Controls visibility.
        StructureControl1.Visible = StudyOutlineToolStripMenuItem.Checked
        uxPreviewControl.Visible = PreviewPanelToolStripMenuItem.Checked
        UxQuestionnaireSet.Visible = PropertyGridToolStripMenuItem.Checked

        ' Set splitters visibility.
        StructurePreviewSplitter.Visible = StructureControl1.Visible And (uxPreviewControl.Visible Or UxQuestionnaireSet.Visible)
        PreviewPropertyGridSplitter.Visible = uxPreviewControl.Visible And uxQuestionnaireSet.Visible

    End Sub

    ' Save the preview in a HTML file
    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        If SaveHtmlDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then

            uxPreviewControl.SavePreviewHTML(SaveHtmlDialog.FileName)

        End If
    End Sub

    ' Open DataManager
    Private Sub DataManagerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataManagerToolStripMenuItem1.Click

        Dim dataManagerControl As DataManager.DataManagerForm = New DataManager.DataManagerForm()
        dataManagerControl.Show()

    End Sub

    ' Open the window with the sql commands to update the database.
    Private Sub DatabaseUpdaterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DatabaseUpdaterToolStripMenuItem.Click
    End Sub

    ' Look for changes and confirm closing.
    Private Sub Main_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        If _study Is Nothing Then Exit Sub

        ' If no changes do nothing.
        If Not BO.ContextClass.HasChanges Then Exit Sub

        Select Case MessageBox.Show("The study was modified. Do you want to save changes?", Nothing, MessageBoxButtons.YesNoCancel)
            Case Windows.Forms.DialogResult.Yes
                SaveToolStripMenuItem1_Click(sender, e)

            Case Windows.Forms.DialogResult.Cancel
                e.Cancel = True

        End Select

    End Sub

    ' Change language.
    Private Sub ToolStripComboBox1_LanguageChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxLanguage.SelectedIndexChanged
        BO.ContextClass.CurrentLanguage = cbxLanguage.SelectedItem
    End Sub


    Private Sub ByVariableToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ByVariableToolStripMenuItem.Click

        Dim _dataDictionary As DataDictionary

        If SaveDictonaryDialog.ShowDialog = Windows.Forms.DialogResult.OK Then

            _dataDictionary = New DataDictionary
            _dataDictionary.DataDictionaryByVariable(SaveDictonaryDialog.FileName)
        End If
    End Sub


    Private Sub ByQuestionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ByQuestionToolStripMenuItem.Click

        Dim _dataDictionary As DataDictionary

        If SaveDictonaryDialog.ShowDialog = Windows.Forms.DialogResult.OK Then

            _dataDictionary = New DataDictionary
            _dataDictionary.DataDictionaryByQuestion(SaveDictonaryDialog.FileName)
        End If
    End Sub


    Private Sub uxPropertyGrid_PropertyValueChanged(ByVal s As System.Object, ByVal e As System.Windows.Forms.PropertyValueChangedEventArgs)

        If "MainText|Name|MultipleInstances|Required".Contains(e.ChangedItem.PropertyDescriptor.Name) Then

            Me.StructureControl1.SelectedAdvNode.RefreshUI()

        End If

        Me.StructureControl1.HighlightNodes(Me.StructureControl1.SelectedAdvNode)
        'Me.StructureControl1.UndoStack.Peek.Description = String.Format("Change of '{0}' property '{1}'", uxPropertyGrid.SelectedObject.ToString, e.ChangedItem.PropertyDescriptor.Name)
        Me.StructureControl1.UndoStack.Peek.Disposable = False
        _objectChanged = True
        BO.ContextClass.HasChanges = True

    End Sub


    Private Sub uxPropertyGrid_SelectedObjectsChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If Me.StructureControl1.UndoStack.Count > 0 AndAlso Me.StructureControl1.UndoStack.Peek.Disposable Then
            Me.StructureControl1.UndoStack.Pop()
        ElseIf Me.StructureControl1.RedoStack.Count > 0 Then
            Me.StructureControl1.RedoStack.Clear()
        End If

        _objectChanged = False
        Me.StructureControl1.UndoStack.Push(New NodeSnapshot(Me.StructureControl1.SelectedAdvNode))

    End Sub


    Private Sub FindToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindToolStripMenuItem.Click

        Dim searchForm As New SearchForm(Me.StructureControl1.SelectedAdvNode)
        searchForm.Show()

    End Sub


    Private Sub UsersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UsersToolStripMenuItem.Click

        ' Edit.
        Dim pdaUserNameProp As Reflection.PropertyInfo = GetType(BO.PDAUser).GetProperty("PDAUserName")
        Dim editor As New BO.ListEditorFrm(BO.Study.PDAUsers, GetType(BO.PDAUser), "PDA Users Editor", Nothing, pdaUserNameProp, False, False)
        editor.ShowDialog()
        editor.UpdateInputList()

    End Sub


    Private Sub MethodsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MethodsToolStripMenuItem.Click

        Dim methodNameProp As Reflection.PropertyInfo = GetType(BO.Method).GetProperty("Name")
        Dim editor As New BO.ListEditorFrm(BO.Study.Methods, GetType(BO.Method), "Methods Editor", Nothing, methodNameProp, True, False)
        editor.ShowDialog()
        editor.UpdateInputList()

    End Sub

    Private Sub PDAReportsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PDAReportsToolStripMenuItem.Click

        Dim reportNameProp As Reflection.PropertyInfo = GetType(BO.Report).GetProperty("Name")
        Dim editor As New BO.ListEditorFrm(BO.Study.Reports, GetType(BO.Report), "Report Editor", Nothing, reportNameProp, True, False)
        editor.ShowDialog()
        editor.UpdateInputList()

    End Sub


    Private Sub GenerateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GenerateToolStripMenuItem.Click

        If BO.ContextClass.HasChanges Then
            If MessageBox.Show("The study needs to be saved before generate. Do you want to save now?", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Cancel Then Exit Sub
            SaveToolStripMenuItem1_Click(sender, e)
        End If

        If FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then

            Dim generator As New Generator.Generator()
            generator.Generate(_study.QMFileName, FolderBrowserDialog1.SelectedPath)
            MessageBox.Show("The generating process ended successfully.", "Generator", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub

    Private Sub ExpresionEditorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExpresionEditorToolStripMenuItem.Click
        Dim exed As New ExpresionEditor
        exed.Execute(Nothing, BO.ContextClass.Study, BO.ContextClass.Study)
    End Sub



    Private Sub uxVariable_Leave(sender As System.Object, e As System.EventArgs) Handles uxVariable.Leave

    End Sub

End Class
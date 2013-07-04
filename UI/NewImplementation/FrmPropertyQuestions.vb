Imports BO

Public Class FrmPropertyQuestions

    Public Shared Function Execute(ByVal emptyObject As BO.Question) As BO.GenericObject

        ' Execute the Editor and return the generic object'
        Dim form As New FrmPropertyQuestions(emptyObject)
        If form.ShowDialog = Windows.Forms.DialogResult.OK Then
            form.PopulateQuestions(emptyObject)
            Return emptyObject
        Else
            Return Nothing
        End If
    End Function

    Public Sub New(ByVal emptyObject As BO.Question)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' This set a default value in the ComboBox
        Me.CmbVarScope.Text = CmbVarScope.Items(2)
        Me.CmbGroupMem.Text = CmbGroupMem.Items(1)
        Me.CmbShowQuestion.Text = CmbShowQuestion.Items(0)
        Me.CmbAnswerReq.Text = CmbAnswerReq.Items(0)
        Me.CmbConfBack.Text = CmbConfBack.Items(1)
        Me.CmbConfChange.Text = CmbShowQuestion.Items(1)
        Me.CmbConfNext.Text = CmbConfNext.Items(1)
        Me.CmbHideBack.Text = CmbHideBack.Items(1)
        Me.CmbHideNext.Text = CmbHideNext.Items(1)

        ' This moves the data to the object in the form'
        Me.LblQuesID.Text = emptyObject.QuestionnaireID.ToString()
        Me.LblQuesSetID.Text = emptyObject.QuestionnaireSetID.ToString()
        Me.LblSectionID.Text = emptyObject.SectionID.ToString()
        Me.LblUniqueID.Text = emptyObject.Guid.ToString()

    End Sub

    Public Function PopulateQuestions(ByVal ObjectToPopulate As BO.Question) As Boolean
        Dim ItemScope As Integer = -1
        Select Case CmbVarScope.Text
            Case "QuestionnaireSet"
                ItemScope = 2
            Case "Questionnaire"
                ItemScope = 3
            Case "Section"
                ItemScope = 4
        End Select

        ' Update Main Data
        ObjectToPopulate.Name = Me.TxtName.Text
        ObjectToPopulate.MainText = Me.TxtMainText.Text
        ObjectToPopulate.Comment = Me.TxtComment.Text
        'Update Data_Entry Data
        ObjectToPopulate.LegalValueTable = Me.CmbLegalValue.Text
        ObjectToPopulate.ScreenTemplate = Me.CmbScreenTem.Text
        ObjectToPopulate.VariableName = Me.TxtVarName.Text
        ObjectToPopulate.VariableScope = ItemScope
        'Update Data_Variables_Ranges Data
        ObjectToPopulate.AbsoluteMaximum = Me.TxtAbsMax.Text
        ObjectToPopulate.AbsoluteMinimum = Me.TxtAbsMin.Text
        ObjectToPopulate.PromptOver = Me.TxtPromptOver.Text
        ObjectToPopulate.PromptUnder = Me.TxtPromptUnder.Text
        'Update Misc Data
        ObjectToPopulate.GroupMember = Me.CmbGroupMem.Text
        ObjectToPopulate.GroupText = Me.TxtGroupText.Text
        ObjectToPopulate.Visible = Me.CmbShowQuestion.Text
        'Update PDA_Action Data
        ObjectToPopulate.CustomValidationFailMessage = Me.TxtCustomMss.Text
        ObjectToPopulate.CustomValidation = Me.TxtCustomValidation.Text
        ObjectToPopulate.OnChange = Me.TxtOnChange.Text
        ObjectToPopulate.OnLoad = Me.TxtOnLoad.Text
        ObjectToPopulate.OnUnload = Me.TxtOnUnload.Text
        'Update PDA_Settings
        ObjectToPopulate.Required = Me.CmbAnswerReq.Text
        ObjectToPopulate.ConfirmBack = Me.CmbConfBack.Text
        ObjectToPopulate.ConfirmChange = Me.CmbConfChange.Text
        ObjectToPopulate.ConfirmNext = Me.CmbConfNext.Text
        ObjectToPopulate.HelpText = Me.TxtHelpText.Text
        ObjectToPopulate.HideBack = Me.CmbHideBack.Text
        ObjectToPopulate.HideNext = Me.CmbHideNext.Text
        ObjectToPopulate.Arguments = Me.TxtArguments.Text

    End Function


    Private Sub FrmPropertyQuestions_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        Dim msgValue As String = String.Empty

        If Me.DialogResult = Windows.Forms.DialogResult.OK Then

            If String.IsNullOrEmpty(Me.TxtMainText.Text) Then msgValue &= Environment.NewLine & "Main text is required."
            If String.IsNullOrEmpty(Me.CmbScreenTem.Text) Then
                msgValue &= Environment.NewLine & "Screen Template is required."
            ElseIf BO.Study.ScreenTemplates(Me.CmbScreenTem.Text).VariableNameRequired AndAlso String.IsNullOrEmpty(Me.TxtVarName.Text) Then
                msgValue &= Environment.NewLine & "A valid variable name is required."
            End If
        If "DropDown|RadioButtons|CheckBox|name".Contains(Me.CmbScreenTem.Text) AndAlso String.IsNullOrEmpty(Me.CmbLegalValue.Text) Then msgValue &= Environment.NewLine & "A legal value table name is required."
        If String.IsNullOrEmpty(Me.TxtDataType.Text) Then msgValue &= Environment.NewLine & "Data type is required."
            If (Me.CmbGroupMem.Text) AndAlso String.IsNullOrEmpty(Me.TxtGroupText.Text) Then msgValue &= Environment.NewLine & "If you have group member, group text is required."

        If Not String.IsNullOrEmpty(msgValue) Then
            MessageBox.Show("Error list:" & msgValue, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Cancel = True
            End If
        End If

    End Sub

    Private Sub FrmPropertyQuestions_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        CmbScreenTem.Items.Clear()
        For i As Integer = 0 To Logic.GetStandardValues().Count - 1 Step 1
            CmbScreenTem.Items.Add(Logic.GetStandardValues().Item(i))
        Next

        Dim Valores As Array
        Valores = System.Enum.GetNames(GetType(BO.VariableScopes))
        CmbVarScope.Items.Clear()
        For Each Item As String In Valores
            CmbVarScope.Items.Add(Item)
        Next

    End Sub

    Private Sub CmbScreenTem_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CmbScreenTem.SelectedIndexChanged
        If CmbScreenTem.Text = "DropDown" Or CmbScreenTem.Text = "RadioButtons" Or CmbScreenTem.Text = "CheckBox" Or CmbScreenTem.Text = "Name" Then

            CmbLegalValue.Items.Clear()
            Dim LegalValueTable As System.ComponentModel.TypeConverter.StandardValuesCollection
            LegalValueTable = Logic.GetStandardValuesLegalValueTable(CmbScreenTem.Text)
            For i As Integer = 0 To LegalValueTable.Count - 1 Step 1
                CmbLegalValue.Items.Add(LegalValueTable.Item(i))
            Next

        Else
            CmbLegalValue.Text = String.Empty
            CmbLegalValue.Items.Clear()
        End If

        TxtDataType.Text = Logic.DataTypeNames(CmbScreenTem.Text)

    End Sub

    Private Sub btnComment_Click(sender As System.Object, e As System.EventArgs) Handles btnComment.Click
        TxtComment.Text = CodeEditorForm.GetString(TxtComment.Text)
    End Sub

    Private Sub BtnMainText_Click(sender As System.Object, e As System.EventArgs) Handles BtnMainText.Click
        TxtMainText.Text = CodeEditorForm.GetString(TxtMainText.Text)
    End Sub

    Private Sub btnName_Click(sender As System.Object, e As System.EventArgs) Handles btnName.Click
        TxtName.Text = CodeEditorForm.GetString(TxtName.Text)
    End Sub

    Private Sub BtnGroupText_Click(sender As System.Object, e As System.EventArgs) Handles BtnGroupText.Click
        TxtGroupText.Text = CodeEditorForm.GetString(TxtGroupText.Text)
    End Sub

    Private Sub BtnCustomMss_Click(sender As System.Object, e As System.EventArgs) Handles BtnCustomMss.Click
        TxtCustomMss.Text = CodeEditorForm.GetString(TxtCustomMss.Text)
    End Sub

    Private Sub BtnCustomValidate_Click(sender As System.Object, e As System.EventArgs) Handles BtnCustomValidate.Click
        TxtCustomValidation.Text = CodeEditorForm.GetString(TxtCustomValidation.Text)
    End Sub

    Private Sub BtnOnChange_Click(sender As System.Object, e As System.EventArgs) Handles BtnOnChange.Click
        TxtOnChange.Text = CodeEditorForm.GetString(TxtOnChange.Text)
    End Sub

    Private Sub BtnOnLoad_Click(sender As System.Object, e As System.EventArgs) Handles BtnOnLoad.Click
        TxtOnLoad.Text = CodeEditorForm.GetString(TxtOnLoad.Text)
    End Sub

    Private Sub BtnOnUnload_Click(sender As System.Object, e As System.EventArgs) Handles BtnOnUnload.Click
        TxtOnUnload.Text = CodeEditorForm.GetString(TxtOnUnload.Text)
    End Sub

    Private Sub BtnHelpText_Click(sender As System.Object, e As System.EventArgs) Handles BtnHelpText.Click
        TxtHelpText.Text = CodeEditorForm.GetString(TxtHelpText.Text)
    End Sub
End Class
Imports BO
Public Class CtlQuestions

    Private lobjEmpty As BO.Question = Nothing

    Public Function PopulateQuestion(ByVal Tag As BO.Question) As BO.Question
        'Valid if the data are empty or Null
        
        lobjEmpty = Tag
        Me.GetDataDypes()

        If (Tag.Name = Nothing) Then
            Me.TxtName.Text = String.Empty
        Else
            Me.TxtName.Text = Tag.Name.ToString()
        End If

        If (Tag.MainText = Nothing) Then
            Me.TxtMainText.Text = String.Empty
        Else
            Me.TxtMainText.Text = Tag.MainText.ToString()
        End If

        If (Tag.Comment = Nothing) Then
            Me.TxtComment.Text = String.Empty
        Else
            Me.TxtComment.Text = Tag.Comment.ToString()
        End If

        If (Tag.VariableName = Nothing) Then
            Me.TxtVarName.Text = String.Empty
        Else
            Me.TxtVarName.Text = Tag.VariableName.ToString()
        End If

        If (Tag.DataType = Nothing) Then
            Me.TxtDataType.Text = String.Empty
        Else
            Me.TxtDataType.Text = Tag.DataType.ToString()
        End If

        If (Tag.AbsoluteMaximum = Nothing) Then
            Me.TxtAbsMax.Text = String.Empty
        Else
            Me.TxtAbsMax.Text = Tag.AbsoluteMaximum.ToString()
        End If

        If (Tag.AbsoluteMinimum = Nothing) Then
            Me.TxtAbsMin.Text = String.Empty
        Else
            Me.TxtAbsMin.Text = Tag.AbsoluteMinimum.ToString()
        End If

        If (Tag.PromptOver = Nothing) Then
            Me.TxtPromptOver.Text = String.Empty
        Else
            Me.TxtPromptOver.Text = Tag.PromptOver.ToString()
        End If

        If (Tag.PromptUnder = Nothing) Then
            Me.TxtPromptUnder.Text = String.Empty
        Else
            Me.TxtPromptUnder.Text = Tag.PromptUnder.ToString()
        End If

        If (Tag.GroupText = Nothing) Then
            Me.TxtGroupText.Text = String.Empty
        Else
            Me.TxtGroupText.Text = Tag.GroupText.ToString()
        End If

        If (Tag.CustomValidationFailMessage = Nothing) Then
            Me.TxtCustomMss.Text = String.Empty
        Else
            Me.TxtCustomMss.Text = Tag.CustomValidationFailMessage.ToString()
        End If

        If (Tag.CustomValidation = Nothing) Then
            Me.TxtCustomValidation.Text = String.Empty
        Else
            Me.TxtCustomValidation.Text = Tag.CustomValidation.ToString()
        End If

        If (Tag.OnChange = Nothing) Then
            Me.TxtOnChange.Text = String.Empty
        Else
            Me.TxtOnChange.Text = Tag.OnChange.ToString()
        End If

        If (Tag.OnLoad = Nothing) Then
            Me.TxtOnLoad.Text = String.Empty
        Else
            Me.TxtOnLoad.Text = Tag.OnLoad.ToString()
        End If

        If (Tag.OnUnload = Nothing) Then
            Me.TxtOnUnload.Text = String.Empty
        Else
            Me.TxtOnUnload.Text = Tag.OnUnload.ToString()
        End If

        If (Tag.HelpText = Nothing) Then
            Me.TxtHelpText.Text = String.Empty
        Else
            Me.TxtHelpText.Text = Tag.HelpText.ToString()
        End If

        If (Tag.Arguments = Nothing) Then
            Me.TxtArguments.Text = String.Empty
        Else
            Me.TxtArguments.Text = Tag.Arguments.ToString()
        End If

        If (Tag.QuestionnaireID = Nothing) Then
            Me.LblQuesID.Text = 0
        Else
            Me.LblQuesID.Text = Tag.QuestionnaireID.ToString()
        End If

        If (Tag.QuestionnaireSetID = Nothing) Then
            Me.LblQuesSetID.Text = 0
        Else
            Me.LblQuesSetID.Text = Tag.QuestionnaireSetID.ToString()
        End If

        If (Tag.SectionID = Nothing) Then
            Me.LblSectionID.Text = 0
        Else
            Me.LblSectionID.Text = Tag.SectionID.ToString()
        End If

        If (Tag.Guid = Nothing) Then
            Me.LblUniqueID.Text = 0
        Else
            Me.LblUniqueID.Text = Tag.Guid.ToString()
        End If

        If (Tag.LegalValueTable Is Nothing) Then
            Me.CmbLegalValue.Text = String.Empty
        Else
            Me.CmbLegalValue.Text = Tag.LegalValueTable.ToString()
        End If

        Me.CmbScreenTem.Text = Tag.ScreenTemplate.ToString()
        Me.CmbVarScope.Text = Tag.VariableScope.ToString()
        Me.CmbGroupMem.Text = Tag.GroupMember.ToString()
        Me.CmbShowQuestion.Text = Tag.Visible.ToString()
        Me.CmbAnswerReq.Text = Tag.Required.ToString()
        Me.CmbConfBack.Text = Tag.ConfirmBack.ToString()
        Me.CmbConfChange.Text = Tag.ConfirmChange.ToString()
        Me.CmbConfNext.Text = Tag.ConfirmNext.ToString()
        Me.CmbHideBack.Text = Tag.HideBack.ToString()
        Me.CmbHideNext.Text = Tag.HideNext.ToString()

        Return Tag
    End Function

     Public Function UpdateQuestions(ByVal ObjectToPopulate As BO.Question) As BO.Question
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

        Return ObjectToPopulate
    End Function

    Private Sub GetDataDypes()

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
            CmbLegalvalue.Text = String.Empty
            CmbLegalValue.Items.Clear()
        End If

        TxtDataType.Text = Logic.DataTypeNames(CmbScreenTem.Text)

    End Sub

#Region "CtlQuestion Click Events"
    Private Sub btnComment_Click(sender As System.Object, e As System.EventArgs) Handles btnComment.Click
        TxtComment.Text = CodeEditorForm.GetString(TxtComment.Text)
    End Sub

    Private Sub BtnMainText_Click(sender As System.Object, e As System.EventArgs) Handles BtnMainText.Click
        TxtMainText.Text = CodeEditorForm.GetString(TxtMainText.Text)
    End Sub

    Private Sub CtlQuestions_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load


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

#End Region


    Private Sub BtnHelpText_Click(sender As System.Object, e As System.EventArgs) Handles BtnHelpText.Click
        TxtHelpText.Text = CodeEditorForm.GetString(TxtHelpText.Text)
    End Sub

    Private Sub CtlQuestions_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.Validating
        If lobjEmpty.GetType().GetInterface("ISelfValidate") IsNot Nothing Then

            e.Cancel = Not CType(UpdateQuestions(lobjEmpty), BO.ISelfValidate).IsValid()

        End If
    End Sub
End Class

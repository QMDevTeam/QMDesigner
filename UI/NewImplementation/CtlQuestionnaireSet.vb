Public Class CtlQuestionnaireSet
    Private MyEmptyObject As BO.QuestionnaireSet = Nothing

    Public Function PopulateQuestionnaireSet(ByVal Tag As BO.QuestionnaireSet) As BO.QuestionnaireSet

        MyEmptyObject = Tag

        If Tag.Comment Is Nothing Then
            Me.TxtComment.Text = String.Empty
        Else
            Me.TxtComment.Text = Tag.Comment.ToString()
        End If

        If Tag.Name Is Nothing Then
            Me.TxtName.Text = String.Empty
        Else
            Me.TxtName.Text = Tag.Name.ToString()
        End If

        If Tag.PreCondition Is Nothing Then
            Me.TxtPrecondition.Text = String.Empty
        Else
            Me.TxtPrecondition.Text = Tag.PreCondition.ToString()
        End If

        If Tag.ShortName Is Nothing Then
            Me.TxtShortName.Text = String.Empty
        Else
            Me.TxtShortName.Text = Tag.ShortName.ToString()
        End If

        If Tag.PDADataTableName Is Nothing Then
            Me.TxtPdaTname.Text = String.Empty
        Else
            Me.TxtPdaTname.Text = Tag.PDADataTableName.ToString()
        End If

        If Tag.DataTableName Is Nothing Then
            Me.TxtServerDataTname.Text = String.Empty
        Else
            Me.TxtServerDataTname.Text = Tag.DataTableName.ToString()
        End If

        If Tag.LogTableName Is Nothing Then
            Me.TxtServerLTname.Text = String.Empty
        Else
            Me.TxtServerLTname.Text = Tag.LogTableName.ToString()
        End If

        If Tag.NewSubjectSectionID Is Nothing Then
            Me.TxtPdaSetNewId.Text = String.Empty
        Else
            Me.TxtPdaSetNewId.Text = Tag.NewSubjectSectionID.ToString()
        End If

        If Tag.OnNewSubject Is Nothing Then
            Me.TxtPdaSetNewSub.Text = String.Empty
        Else
            Me.TxtPdaSetNewSub.Text = Tag.OnNewSubject.ToString()
        End If

        If Tag.SubjectAlternativeSearchField Is Nothing Then
            Me.TxtPdaSetSearchField.Text = String.Empty
        Else
            Me.TxtPdaSetSearchField.Text = Tag.SubjectAlternativeSearchField.ToString()
        End If

        If Tag.SubjectConfirmationFields Is Nothing Then
            Me.TxtPdaSetConfirmField.Text = String.Empty
        Else
            Me.TxtPdaSetConfirmField.Text = Tag.SubjectConfirmationFields.ToString()
        End If

        If Tag.SubjectSecondaryIdField Is Nothing Then
            Me.TxtPdaSetSecondField.Text = String.Empty
        Else
            Me.TxtPdaSetSecondField.Text = Tag.SubjectSecondaryIdField.ToString()
        End If

        If Tag.QuestionnaireSetID = Nothing Then
            Me.TxtSysInSetId.Text = String.Empty
        Else
            Me.TxtSysInSetId.Text = Tag.QuestionnaireSetID.ToString()
        End If

        If Tag.Guid = Nothing Then
            Me.TxtSysInId.Text = String.Empty
        Else
            Me.TxtSysInId.Text = Tag.Guid.ToString()
        End If

        Return Tag

    End Function

    Public Function UpdateQuestionnaireSet(ByVal ObjectToUpdate As BO.QuestionnaireSet) As BO.QuestionnaireSet

        ObjectToUpdate.Comment = Me.TxtComment.Text
        ObjectToUpdate.Name = Me.TxtName.Text
        ObjectToUpdate.PreCondition = Me.TxtPrecondition.Text
        ObjectToUpdate.ShortName = Me.TxtShortName.Text
        ObjectToUpdate.OnNewSubject = Me.TxtPdaSetNewSub.Text
        ObjectToUpdate.SubjectAlternativeSearchField = Me.TxtPdaSetSearchField.Text
        ObjectToUpdate.SubjectConfirmationFields = Me.TxtPdaSetConfirmField.Text
        ObjectToUpdate.SubjectSecondaryIdField = Me.TxtPdaSetSecondField.Text
        ObjectToUpdate.DataTableName = Me.TxtServerDataTname.Text
        ObjectToUpdate.LogTableName = Me.TxtServerLTname.Text

        Return ObjectToUpdate

    End Function

    Private Sub BtnCommentEditor_Click(sender As System.Object, e As System.EventArgs) Handles BtnCommentEditor.Click

        TxtComment.Text = BO.CodeEditorForm.GetString(TxtComment.Text)

    End Sub

    Private Sub BtnNameEditor_Click(sender As System.Object, e As System.EventArgs) Handles BtnNameEditor.Click

        TxtName.Text = BO.CodeEditorForm.GetString(TxtName.Text)

    End Sub

    Private Sub BtnNamePrecondition_Click(sender As System.Object, e As System.EventArgs) Handles BtnNamePrecondition.Click

        TxtPrecondition.Text = BO.CodeEditorForm.GetString(TxtPrecondition.Text)

    End Sub

    Private Sub CtlQuestionnaireSet_Validating(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Validating

        If MyEmptyObject.GetType().GetInterface("ISelfValidate") IsNot Nothing Then

            e.Cancel = Not CType(UpdateQuestionnaireSet(MyEmptyObject), BO.ISelfValidate).IsValid()

        End If

    End Sub
End Class

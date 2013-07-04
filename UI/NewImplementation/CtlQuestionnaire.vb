Public Class CtlQuestionnaire
    Private MyEmptyObject As BO.Questionnaire = Nothing

    Public Function PopulateQuestionnaire(ByVal Tag As BO.Questionnaire) As BO.Questionnaire

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

        If Tag.ShortName Is Nothing Then
            Me.TxtShortName.Text = String.Empty
        Else
            Me.TxtShortName.Text = Tag.ShortName.ToString()
        End If

        Me.CmbNumeration.Text = Tag.ContinuousNumeration.ToString()

        If Tag.InstanceSecondaryIDField Is Nothing Then
            Me.TxtIDField.Text = String.Empty
        Else
            Me.TxtIDField.Text = Tag.InstanceSecondaryIDField.ToString()
        End If

        If Tag.InstanceSAIDField Is Nothing Then
            Me.TxtSaidField.Text = String.Empty
        Else
            Me.TxtSaidField.Text = Tag.InstanceSAIDField.ToString()
        End If

        Me.CmbInstances.Text = Tag.MultipleInstances.ToString()

        If Tag.OnNewRecord Is Nothing Then
            Me.TxtProcedureID.Text = String.Empty
        Else
            Me.TxtProcedureID.Text = Tag.OnNewRecord.ToString()
        End If

        If Tag.PDADataTableName Is Nothing Then
            Me.TxtPdaTname.Text = String.Empty
        Else
            Me.TxtPdaTname.Text = Tag.PDADataTableName.ToString()
        End If

        If Tag.PreCondition Is Nothing Then
            Me.TxtPrecondition.Text = String.Empty
        Else
            Me.TxtPrecondition.Text = Tag.PreCondition.ToString()
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

        If Tag.QuestionnaireID = Nothing Then
            Me.TxtQuestionnaireId.Text = String.Empty
        Else
            Me.TxtQuestionnaireId.Text = Tag.QuestionnaireID.ToString()
        End If

        If Tag.QuestionnaireSetID = Nothing Then
            Me.TxtSysInSetId.Text = String.Empty
        Else
            Me.TxtSysInSetId.Text = Tag.QuestionnaireSetID.ToString()
        End If

        If Tag.Guid = Nothing Then
            Me.TxtUniqueIdentifier.Text = String.Empty
        Else
            Me.TxtUniqueIdentifier.Text = Tag.Guid.ToString()
        End If

        Return Tag
    End Function

    Private Function UpdateQuestionnaire(ByVal ObjectToUpdate As BO.Questionnaire) As BO.Questionnaire

        ObjectToUpdate.Comment = Me.TxtComment.Text
        ObjectToUpdate.Name = Me.TxtName.Text
        ObjectToUpdate.ShortName = Me.TxtShortName.Text
        ObjectToUpdate.ContinuousNumeration = Me.CmbNumeration.Text
        ObjectToUpdate.InstanceSecondaryIDField = Me.TxtIDField.Text
        ObjectToUpdate.InstanceSAIDField = Me.TxtSaidField.Text
        ObjectToUpdate.MultipleInstances = Me.CmbInstances.Text
        ObjectToUpdate.OnNewRecord = Me.TxtProcedureID.Text
        ObjectToUpdate.PreCondition = Me.TxtPrecondition.Text
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

    Private Sub CtlQuestionnaire_Validating(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Validating

        If MyEmptyObject.GetType().GetInterface("ISelfValidate") IsNot Nothing Then

            e.Cancel = Not CType(UpdateQuestionnaire(MyEmptyObject), BO.ISelfValidate).IsValid()

        End If

    End Sub
End Class

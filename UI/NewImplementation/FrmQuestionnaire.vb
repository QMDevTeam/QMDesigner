Public Class FrmQuestionnaire
    Public Shared MyEmptyObject As New BO.Questionnaire

    Public Shared Function AddQuestionnaireItems(ByVal emptyObject As BO.Questionnaire, selectedNode As AdvNode) As BO.GenericObject

        MyEmptyObject = emptyObject

        Dim form As New FrmQuestionnaire(emptyObject, selectedNode)
        If form.ShowDialog = Windows.Forms.DialogResult.OK Then
            Return emptyObject
        Else
            Return Nothing
        End If

    End Function

    Public Sub New(ByVal DefaultObject As BO.Questionnaire, selectedNode As AdvNode)

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Populating the default values
        Me.TxtName.Text = DefaultObject.Name.ToString()
        Me.CmbNumeration.Text = DefaultObject.ContinuousNumeration
        Me.CmbInstances.Text = DefaultObject.MultipleInstances
        Me.TxtQuestionnaireId.Text = DefaultObject.QuestionnaireID.ToString()
        Me.TxtUniqueIdentifier.Text = DefaultObject.Guid.ToString()
        Me.TxtServerLTname.Text = String.Format("{0}_{1}", selectedNode.Tag.LogTableName.Replace("S", "D"), DefaultObject.DataBaseID)
        Me.TxtServerDataTname.Text = String.Format("{0}_{1}", selectedNode.Tag.DataTableName.Replace("S", "D"), DefaultObject.DataBaseID)

        If DefaultObject.QuestionnaireSetID = -1 Then
            Me.TxtSysInSetId.Text = "N/A"
        Else
            Me.TxtSysInSetId.Text = DefaultObject.QuestionnaireSetID
        End If

    End Sub

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

    Private Sub FrmQuestionnaire_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        If Me.DialogResult = Windows.Forms.DialogResult.OK Then

            If MyEmptyObject.GetType().GetInterface("ISelfValidate") IsNot Nothing Then

                e.Cancel = Not CType(UpdateQuestionnaire(MyEmptyObject), BO.ISelfValidate).IsValid()

            End If

        End If

    End Sub

    Private Sub BtnCommentEditor_Click(sender As System.Object, e As System.EventArgs) Handles BtnCommentEditor.Click

        TxtComment.Text = BO.CodeEditorForm.GetString(TxtComment.Text)

    End Sub

    Private Sub BtnNameEditor_Click(sender As System.Object, e As System.EventArgs) Handles BtnNameEditor.Click

        TxtName.Text = BO.CodeEditorForm.GetString(TxtName.Text)

    End Sub

    Private Sub BtnNamePrecondition_Click(sender As System.Object, e As System.EventArgs) Handles BtnNamePrecondition.Click

        TxtPrecondition.Text = BO.CodeEditorForm.GetString(TxtPrecondition.Text)

    End Sub
End Class
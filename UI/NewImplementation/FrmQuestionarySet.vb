Public Class FrmQuestionnaireSet
    Public Shared MyEmptyObject As New BO.QuestionnaireSet

    Public Shared Function AddQuestionnaireSetItems(ByVal emptyObject As BO.QuestionnaireSet) As BO.GenericObject
        MyEmptyObject = emptyObject

        Dim form As New FrmQuestionnaireSet(emptyObject)
        If form.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Return emptyObject
        Else
            Return Nothing
        End If

    End Function

    Public Sub New(ByVal DefaultObject As BO.QuestionnaireSet)

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Populating the default values
        Me.TxtName.Text = DefaultObject.Name.ToString()
        Me.TxtPdaTname.Text = DefaultObject.PDADataTableName.ToString()
        Me.TxtServerDataTname.Text = DefaultObject.DataTableName.ToString()
        Me.TxtServerLTname.Text = DefaultObject.LogTableName()
        Me.TxtSysInId.Text = DefaultObject.Guid.ToString()
        Me.TxtSysInSetId.Text = DefaultObject.QuestionnaireSetID.ToString()

    End Sub

    Private Function UpdateQuestionnaireSet(ByVal ObjectToUpdate As BO.QuestionnaireSet) As BO.QuestionnaireSet

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

    Private Sub FrmQuestionnaireSet_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        If Me.DialogResult = Windows.Forms.DialogResult.OK Then

            If MyEmptyObject.GetType().GetInterface("ISelfValidate") IsNot Nothing Then

                e.Cancel = Not CType(UpdateQuestionnaireSet(MyEmptyObject), BO.ISelfValidate).IsValid()

            End If

        End If

    End Sub


    Private Sub BtnCommentEditor_Click(sender As System.Object, e As System.EventArgs) Handles BtnCommentEditor.Click

        TxtComment.Text = BO.CodeEditorForm.GetString(TxtComment.Text)

    End Sub

    Private Sub BtnPreconditionEditor_Click(sender As System.Object, e As System.EventArgs) Handles BtnPreconditionEditor.Click

        TxtPrecondition.Text = BO.CodeEditorForm.GetString(TxtPrecondition.Text)

    End Sub

    Private Sub BtnNameEditor_Click(sender As System.Object, e As System.EventArgs) Handles BtnNameEditor.Click

        TxtName.Text = BO.CodeEditorForm.GetString(TxtName.Text)

    End Sub
End Class
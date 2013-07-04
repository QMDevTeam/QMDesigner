Imports BO
Public Class CtlCheckpoint

    Private lObjEmpty As BO.CheckPoint = Nothing

    Public Function PopulateCheckPoint(ByVal Tag As BO.CheckPoint) As BO.CheckPoint
        
        lObjEmpty = Tag

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

        Me.CmbBranch.Text = Tag.BranchIf.ToString()

        If (Tag.Condition = Nothing) Then
            Me.TxtCondition.Text = String.Empty
        Else
            Me.TxtCondition.Text = Tag.Condition.ToString()
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
            Me.LblUniqueId.Text = 0
        Else
            Me.LblUniqueId.Text = Tag.Guid.ToString()
        End If

        Return Tag
    End Function

    Public Function UpdateCheckpoint(ByVal ObjectToPopulate As BO.CheckPoint) As BO.CheckPoint

        ObjectToPopulate.Name = Me.TxtName.Text
        ObjectToPopulate.MainText = Me.TxtMainText.Text
        ObjectToPopulate.BranchIf = Me.CmbBranch.Text
        ObjectToPopulate.Condition = Me.TxtCondition.Text
        ObjectToPopulate.Comment = Me.TxtComment.Text

        Return ObjectToPopulate

    End Function

    Private Sub BtnName_Click(sender As System.Object, e As System.EventArgs) Handles BtnName.Click
        TxtName.Text = CodeEditorForm.GetString(TxtName.Text)
    End Sub

    Private Sub BtnMainText_Click(sender As System.Object, e As System.EventArgs) Handles BtnMainText.Click
        TxtMainText.Text = CodeEditorForm.GetString(TxtMainText.Text)
    End Sub

    Private Sub BtnComment_Click(sender As System.Object, e As System.EventArgs) Handles BtnComment.Click
        TxtComment.Text = CodeEditorForm.GetString(TxtComment.Text)
    End Sub

    Private Sub BtnCondition_Click(sender As System.Object, e As System.EventArgs) Handles BtnCondition.Click
        TxtCondition.Text = CodeEditorForm.GetString(TxtCondition.Text)
    End Sub

    Private Sub CtlCheckpoint_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.Validating
         
        If lobjEmpty.GetType().GetInterface("ISelfValidate") IsNot Nothing Then
            e.Cancel = Not CType(UpdateCheckpoint(lobjEmpty), BO.ISelfValidate).IsValid()
        End If
    End Sub
End Class

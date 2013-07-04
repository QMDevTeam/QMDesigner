Public Class CtlStudy

    Public Function PopulateStudy(ByVal Tag As BO.Study) As BO.Study

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

        If Tag.Version Is Nothing Then
            Me.TxtVersion.Text = String.Empty
        Else
            Me.TxtVersion.Text = Tag.Version.ToString()
        End If

        Me.TxtCreated.Text = Tag.CreationDateTime.ToString()
        Me.TxtModified.Text = Tag.lastModification.ToString()

        If Tag.QMFileName Is Nothing Then
            Me.TxtQmFileName.Text = String.Empty
        Else
            Me.TxtQmFileName.Text = Tag.QMFileName.ToString()
        End If

        If Tag.AnalysisViewsSchema Is Nothing Then
            Me.TxtAnalysisEschema.Text = String.Empty
        Else
            Me.TxtAnalysisEschema.Text = Tag.AnalysisViewsSchema.ToString()
        End If

        If Tag.DataTableSchema = Nothing Then
            Me.TxtDataTableSchema.Text = String.Empty
        Else
            Me.TxtDataTableSchema.Text = Tag.DataTableSchema.ToString()
        End If

        If Tag.LegalValuesTableSchema = Nothing Then
            Me.TxtLegalValues.Text = String.Empty
        Else
            Me.TxtLegalValues.Text = Tag.LegalValuesTableSchema.ToString()
        End If

        If Tag.LogTableSchema = Nothing Then
            Me.TxtLogTableSchema.Text = String.Empty
        Else
            Me.TxtLogTableSchema.Text = Tag.LogTableSchema.ToString()
        End If

        If Tag.Guid = Nothing Then
            Me.TxtUniqueIdentifier.Text = String.Empty
        Else
            Me.TxtUniqueIdentifier.Text = Tag.Guid.ToString()
        End If

        Return Tag

    End Function

    Private Sub BtnCommentEditor_Click(sender As System.Object, e As System.EventArgs) Handles BtnCommentEditor.Click

        TxtComment.Text = BO.CodeEditorForm.GetString(TxtComment.Text)

    End Sub

    Private Sub BtnNameEditor_Click(sender As System.Object, e As System.EventArgs) Handles BtnNameEditor.Click

        TxtName.Text = BO.CodeEditorForm.GetString(TxtName.Text)

    End Sub
End Class

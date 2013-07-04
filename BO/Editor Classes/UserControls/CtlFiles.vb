Public Class CtlFiles

    Public TagToSave As New BO.File

    Public Function PopulateFile(ByVal Tag As BO.File)

        TagToSave = Tag

        If Tag.CodeNamespace Is Nothing Then
            Me.TxtNamespace.Text = String.Empty
        Else
            Me.TxtNamespace.Text = Tag.CodeNamespace.ToString()
        End If
        
        If Tag.Name Is Nothing Then
            Me.TxtName.Text = String.Empty
        Else
            Me.TxtName.Text = Tag.Name.ToString()
        End If

        If Tag.ReferencePath Is Nothing Then
            Me.TxtPath.Text = String.Empty
        Else
            Me.TxtPath.Text = Tag.ReferencePath.ToString()
        End If

        Me.TxtGuid.Text = Tag.Guid.ToString()

    End Function

    Public Function SaveChanges() As BO.File

        TagToSave.Name = Me.TxtName.Text
        TagToSave.CodeNamespace = Me.TxtNamespace.Text
        TagToSave.ReferencePath = TxtPath.Text

        Return TagToSave

    End Function

    Private Sub BtnPath_Click(sender As System.Object, e As System.EventArgs) Handles BtnPath.Click
        Dim dialog As New Windows.Forms.OpenFileDialog()
        If dialog.ShowDialog = DialogResult.OK Then
            TxtPath.Text = dialog.FileName.ToString()
            TxtName.Text = IO.Path.GetFileName(dialog.FileName.ToString())
        End If
    End Sub
End Class

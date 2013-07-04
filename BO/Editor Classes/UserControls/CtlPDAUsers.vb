Public Class CtlPDAUsers
    Public TagToSave As New BO.PDAUser

    Public Function PopulateUSer(ByVal Tag As BO.PDAUser)

        TagToSave = Tag

        If Tag.DefaultSiteID Is Nothing Then
            Me.TxtSiteID.Text = String.Empty
        Else
            Me.TxtSiteID.Text = Tag.DefaultSiteID.ToString()
        End If

        If Tag.Name Is Nothing Then
            Me.TxtName.Text = String.Empty
        Else
            Me.TxtName.Text = Tag.Name.ToString()
        End If

        If Tag.PDAPassword Is Nothing Then
            Me.TxtPass.Text = String.Empty
        Else
            Me.TxtPass.Text = Tag.PDAPassword.ToString()
        End If

        If Tag.PDAUserName Is Nothing Then
            Me.TxtUserName.Text = String.Empty
        Else
            Me.TxtUserName.Text = Tag.PDAUserName.ToString()
        End If

        If Tag.RoleName Is Nothing Then
            Me.TxtRoleName.Text = String.Empty
        Else
            Me.TxtRoleName.Text = Tag.RoleName.ToString()
        End If

    End Function

    Public Function SaveChanges() As BO.PDAUser

        TagToSave.Name = Me.TxtName.Text

        If TxtSiteID.Text = String.Empty Then
            TagToSave.DefaultSiteID = Nothing
        Else
            TagToSave.DefaultSiteID = Convert.ToInt32(TxtSiteID.Text)
        End If

        TagToSave.PDAPassword = TxtPass.Text
        TagToSave.PDAUserName = Me.TxtUserName.Text
        TagToSave.RoleName = TxtRoleName.Text

        Return TagToSave

    End Function

    Private Sub TxtSiteID_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSiteID.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not e.KeyChar = "." Then
            e.Handled = True
        End If
    End Sub
End Class

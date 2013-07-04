Imports System.Windows.Forms

Public Class EditMessageFrm

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Public Function GetMessage() As String

        If Me.ShowDialog() = Windows.Forms.DialogResult.OK Then

            Return Me.txtEditMessage.Text.Replace("'", "''")

        Else

            Return ""

        End If

    End Function

End Class

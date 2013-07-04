Public Class CtlMethod

    Public TagToSave As New BO.Method

    Public Function PopulateMethod(ByVal Tag As BO.Method)

        TagToSave = Tag

        If Tag.Code Is Nothing Then
            Me.TxtCode.Text = String.Empty
        Else
            Me.TxtCode.Text = Tag.Code.ToString()
        End If

        TxtGuid.Text = Tag.Guid.ToString()

        If Tag.Name Is Nothing Then
            Me.TxtName.Text = String.Empty
        Else
            Me.TxtName.Text = Tag.Name.ToString()
        End If
    End Function

    Private Sub BtnCode_Click(sender As System.Object, e As System.EventArgs) Handles BtnCode.Click
        TxtCode.Text = CodeEditorForm.GetString(TxtCode.Text)
    End Sub

    Public Function SaveChanges() As BO.Method

        Dim type As Integer = -1

        Select Case CmbType.Text
            Case "UserMethod"
                type = 0
            Case "Precondition"
                type = 1
            Case "Action"
                type = 2
        End Select

        TagToSave.Name = Me.TxtName.Text
        TagToSave.Code = Me.TxtCode.Text
        TagToSave.Type = type

        Return TagToSave

    End Function

    Private Sub CtlMethod_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim ReportTypes As Array
        ReportTypes = System.Enum.GetNames(GetType(BO.MethodType))
        CmbType.Items.Clear()

        For Each type As String In ReportTypes
            CmbType.Items.Add(type)
        Next
    End Sub
End Class

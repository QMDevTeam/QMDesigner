Public Class CtlVariable
    Private MyEmptyObject As BO.Variable = Nothing

    Public Function PopulateVariable(ByVal Tag As BO.Variable) As BO.Variable

        MyEmptyObject = Tag

        Me.GetDataTypes()

        If Tag.Comment Is Nothing Then
            Me.TxtComment.Text = String.Empty
        Else
            Me.TxtComment.Text = Tag.Comment.ToString()
        End If

        Me.CmbDataType.Text = Tag.DataType.ToString()

        If Tag.MainText Is Nothing Then
            Me.TxtMainText.Text = String.Empty
        Else
            Me.TxtMainText.Text = Tag.MainText.ToString()
        End If

        If Tag.VariableName Is Nothing Then
            Me.TxtVariableName.Text = String.Empty
        Else
            Me.TxtVariableName.Text = Tag.VariableName.ToString()
        End If

        If Tag.AbsMax Is Nothing Then
            Me.TxtMaximum.Text = String.Empty
        Else
            Me.TxtMaximum.Text = Tag.AbsMax.ToString()
        End If

        If Tag.AbsMin Is Nothing Then
            Me.TxtMinimum.Text = String.Empty
        Else
            Me.TxtMinimum.Text = Tag.AbsMin.ToString()
        End If

        If Tag.PromptOver Is Nothing Then
            Me.TxtOver.Text = String.Empty
        Else
            Me.TxtOver.Text = Tag.PromptOver.ToString()
        End If

        If Tag.PromptUnder Is Nothing Then
            Me.TxtUnder.Text = String.Empty
        Else
            Me.TxtUnder.Text = Tag.PromptUnder.ToString()
        End If

        Me.TxtScope.Text = Tag.Scope.ToString()

        If Tag.PDADataTableName Is Nothing Then
            Me.TxtPdaDataTname.Text = String.Empty
        Else
            Me.TxtPdaDataTname.Text = Tag.PDADataTableName.ToString()
        End If

        If Tag.Guid = Nothing Then
            Me.TxtUniqueIdentifier.Text = String.Empty
        Else
            Me.TxtUniqueIdentifier.Text = Tag.Guid.ToString()
        End If

        Return Tag
    End Function

    Private Function UpdateVariable(ByVal ObjectToUpdate As BO.Variable) As BO.Variable

        ObjectToUpdate.Comment = Me.TxtComment.Text
        ObjectToUpdate.DataType = Me.CmbDataType.Text
        ObjectToUpdate.MainText = Me.TxtMainText.Text
        ObjectToUpdate.VariableName = Me.TxtVariableName.Text
        ObjectToUpdate.AbsMax = Me.TxtMaximum.Text
        ObjectToUpdate.AbsMin = Me.TxtMinimum.Text
        ObjectToUpdate.PromptOver = Me.TxtOver.Text
        ObjectToUpdate.PromptUnder = Me.TxtUnder.Text

        Return ObjectToUpdate

    End Function

    Private Sub GetDataTypes()

        Dim DataTypeItems As System.ComponentModel.TypeConverter.StandardValuesCollection
        DataTypeItems = Logic.DataTypeItems()

        For i As Integer = 0 To DataTypeItems.Count - 1 Step 1
            CmbDataType.Items.Add(DataTypeItems.Item(i))
        Next

    End Sub

    Private Sub BtnCommentEditor_Click(sender As System.Object, e As System.EventArgs) Handles BtnCommentEditor.Click

        TxtComment.Text = BO.CodeEditorForm.GetString(TxtComment.Text)

    End Sub

    Private Sub BtnMainText_Click(sender As System.Object, e As System.EventArgs) Handles BtnMainText.Click

        TxtMainText.Text = BO.CodeEditorForm.GetString(TxtMainText.Text)

    End Sub

    Private Sub CtlVariable_Validating(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Validating

        If MyEmptyObject.GetType().GetInterface("ISelfValidate") IsNot Nothing Then

            e.Cancel = Not CType(UpdateVariable(MyEmptyObject), BO.ISelfValidate).IsValid()

        End If

    End Sub
End Class

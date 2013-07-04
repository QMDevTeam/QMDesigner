Imports System.ComponentModel.TypeConverter

Public Class FrmVariable
    Public Shared MyEmptyObject As New BO.Variable

    Public Shared Function AddVariableItems(ByVal emptyObject As BO.Variable) As BO.GenericObject

        MyEmptyObject = emptyObject

        Dim form As New FrmVariable(emptyObject)
        If form.ShowDialog = Windows.Forms.DialogResult.OK Then
            Return emptyObject
        Else
            Return Nothing
        End If

    End Function

    Public Sub New(ByVal DefaultObject As BO.Variable)

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Populating the default values
        Me.TxtScope.Text = DefaultObject.Scope.ToString()
        Me.TxtUniqueIdentifier.Text = DefaultObject.Guid.ToString()

    End Sub

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

    Private Sub FrmVariable_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Dim DataTypeItems As System.ComponentModel.TypeConverter.StandardValuesCollection
        DataTypeItems = Logic.DataTypeItems()

        For i As Integer = 0 To DataTypeItems.Count - 1 Step 1
            CmbDataType.Items.Add(DataTypeItems.Item(i))
        Next

    End Sub

    Private Sub FrmVariable_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        If Me.DialogResult = Windows.Forms.DialogResult.OK Then

            If MyEmptyObject.GetType().GetInterface("ISelfValidate") IsNot Nothing Then

                e.Cancel = Not CType(UpdateVariable(MyEmptyObject), BO.ISelfValidate).IsValid()

            End If

        End If

    End Sub

    Private Sub BtnCommentEditor_Click(sender As System.Object, e As System.EventArgs) Handles BtnCommentEditor.Click

        TxtComment.Text = BO.CodeEditorForm.GetString(TxtComment.Text)

    End Sub

    Private Sub BtnMainText_Click(sender As System.Object, e As System.EventArgs) Handles BtnMainText.Click

        TxtMainText.Text = BO.CodeEditorForm.GetString(TxtMainText.Text)

    End Sub
End Class
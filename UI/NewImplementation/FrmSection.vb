Public Class FrmSection
    Public Shared MyEmptyObject As New BO.Section

    Public Shared Function AddSectionItems(ByVal emptyObject As BO.Section, selectedNode As AdvNode) As BO.GenericObject

        MyEmptyObject = emptyObject

        Dim form As New FrmSection(emptyObject, selectedNode)
        If form.ShowDialog = Windows.Forms.DialogResult.OK Then
            Return emptyObject
        Else
            Return Nothing
        End If

    End Function

    Public Sub New(ByVal DefaultObject As BO.Section, selectedNode As AdvNode)

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Populating the default values
        Me.TxtName.Text = DefaultObject.Name.ToString()
        Me.CmbModifiable.Text = DefaultObject.Modifiable.ToString()
        Me.TxtServerLTname.Text = String.Format("{0}_{1}", selectedNode.Tag.LogTableName.Replace("S", "D"), DefaultObject.DataBaseID)
        Me.TxtServerDataTname.Text = String.Format("{0}_{1}", selectedNode.Tag.DataTableName.Replace("S", "D"), DefaultObject.DataBaseID)
        Me.TxtSectionID.Text = DefaultObject.SectionID.ToString()
        Me.TxtUniqueIdentifier.Text = DefaultObject.Guid.ToString()

        If DefaultObject.QuestionnaireSetID = -1 Then
            Me.TxtQuestionnaireSetId.Text = "N/A"
        Else
            Me.TxtQuestionnaireSetId.Text = DefaultObject.QuestionnaireSetID
        End If

        If DefaultObject.QuestionnaireID = -1 Then
            Me.TxtQuestionnaireID.Text = "N/A"
        Else
            Me.TxtQuestionnaireID.Text = DefaultObject.QuestionnaireID
        End If

    End Sub

    Private Function UpdateSection(ByVal ObjectToUpdate As BO.Section) As BO.Section

        ObjectToUpdate.Comment = Me.TxtComment.Text
        ObjectToUpdate.Name = Me.TxtName.Text
        ObjectToUpdate.ShortName = Me.TxtShortName.Text
        ObjectToUpdate.Modifiable = Me.CmbModifiable.Text
        ObjectToUpdate.OnNewRecord = Me.TxtProcedureID.Text
        ObjectToUpdate.PreCondition = Me.TxtPrecondition.Text
        ObjectToUpdate.LogTableName = Me.TxtServerLTname.Text
        ObjectToUpdate.DataTableName = Me.TxtServerDataTname.Text

        Return ObjectToUpdate

    End Function

    Private Sub FrmSection_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        If Me.DialogResult = Windows.Forms.DialogResult.OK Then

            If MyEmptyObject.GetType().GetInterface("ISelfValidate") IsNot Nothing Then

                e.Cancel = Not CType(UpdateSection(MyEmptyObject), BO.ISelfValidate).IsValid()

            End If

        End If

    End Sub
End Class
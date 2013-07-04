Public Class newObjectEditor

#Region "External interface."

    ' Execute the editor and return the generic object.
    Public Shared Function Execute(ByVal emptyObject As BO.GenericObject, selectedNode as AdvNode) As BO.GenericObject

        Dim form As New newObjectEditor(emptyObject, selectedNode)
        If form.ShowDialog = Windows.Forms.DialogResult.OK Then
            Return emptyObject
        Else
            Return Nothing
        End If
    End Function

#End Region

#Region "Events and internal methods."

    Public Sub New(ByVal emptyObject As BO.GenericObject, ByVal selectedNode As AdvNode)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Text = emptyObject.GetType.ToString & " Editor"
        PropertyGrid1.SelectedObject = emptyObject

        ' Make the legal value editor button visible only if editing a quiestion.
        LegalValuesEditorToolStripMenuItem.Visible = emptyObject.GetType.Equals(GetType(BO.Question))

        ' Assign LogTable and dataTable if avialible.
        If emptyObject.GetType.Equals(GetType(BO.Questionnaire)) _
        OrElse emptyObject.GetType.Equals(GetType(BO.Section)) Then

            emptyObject.LogTableName = String.Format("{0}_{1}", selectedNode.Tag.LogTableName.Replace("S", "D"), emptyObject.DataBaseID)
            emptyObject.DataTableName = String.Format("{0}_{1}", selectedNode.Tag.DataTableName.Replace("S", "D"), emptyObject.DataBaseID)

        End If

    End Sub

    ' Validate the minimum property requirements for the selected object's type.
    Private Sub newObjectEditor_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        If Me.DialogResult = Windows.Forms.DialogResult.OK Then

            If PropertyGrid1.SelectedObject.GetType.GetInterface("ISelfValidate") IsNot Nothing Then

                e.Cancel = Not CType(PropertyGrid1.SelectedObject, BO.ISelfValidate).IsValid()

            End If

        End If
    End Sub

    ' Pops the Legal Values Editor.
    Private Sub LegalValuesEditorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LegalValuesEditorToolStripMenuItem.Click

        ' Edit.
        Dim nameProp As Reflection.PropertyInfo = GetType(BO.LegalValuesTable).GetProperty("Name")
        Dim editor As New BO.ListEditorFrm(BO.Study.LegalValues, GetType(BO.LegalValuesTable), "Legal Values Editor", Nothing, nameProp, True, False)
        editor.ShowDialog()
        editor.UpdateInputList()

    End Sub
#End Region

End Class
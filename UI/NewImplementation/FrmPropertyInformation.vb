Imports BO
Public Class FrmPropertyInformation

    Public Shared lobjEmpty As New BO.Information

    Public Shared Function Execute(ByVal emptyObject As BO.Information) As BO.GenericObject

        lobjEmpty = emptyObject
        ' Execute the Editor and return the generic object'
        Dim form As New FrmPropertyInformation(emptyObject)
        If form.ShowDialog = Windows.Forms.DialogResult.OK Then
            Return emptyObject
        Else
            Return Nothing
        End If
    End Function

    Public Sub New(ByVal emptyObject As BO.Information)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' This set a default value in the ComboBox

        Me.CmbHideBack.Text = CmbHideBack.Items(1)
        Me.CmbHideNext.Text = CmbHideNext.Items(1)
        Me.CmbVisible.Text = CmbVisible.Items(0)

        ' This moves the data to the object in the form'
        Me.LblQuesID.Text = emptyObject.QuestionnaireID.ToString()
        Me.LblQuesSetID.Text = emptyObject.QuestionnaireSetID.ToString()
        Me.LblSectionID.Text = emptyObject.SectionID.ToString()
        Me.LblUniqueID.Text = emptyObject.Guid.ToString()
    End Sub

    Public Function PopulateInformation(ByVal ObjectToPopulate As BO.Information) As BO.Information

        ' Update Main Data
        ObjectToPopulate.Name = Me.TxtName.Text
        ObjectToPopulate.MainText = Me.TxtMainText.Text
        ObjectToPopulate.Comment = Me.TxtComment.Text
        'Update PDA_Action Data
        ObjectToPopulate.OnLoad = Me.TxtOnLoad.Text
        ObjectToPopulate.OnUnload = Me.TxtOnUnload.Text
        'Update PDA_Settings
        ObjectToPopulate.HideBack = Me.CmbHideBack.Text
        ObjectToPopulate.HideNext = Me.CmbHideNext.Text
        ObjectToPopulate.Visible = Me.CmbVisible.Text

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

    Private Sub BtnOnLoad_Click(sender As System.Object, e As System.EventArgs) Handles BtnOnLoad.Click
        TxtOnLoad.Text = CodeEditorForm.GetString(TxtOnLoad.Text)
    End Sub

    Private Sub BtnOnUnload_Click(sender As System.Object, e As System.EventArgs) Handles BtnOnUnload.Click
        TxtOnUnload.Text = CodeEditorForm.GetString(TxtOnUnload.Text)
    End Sub

    Private Sub FrmPropertyInformation_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.Validating
        
        If Me.DialogResult = Windows.Forms.DialogResult.OK Then

            If lobjEmpty.GetType().GetInterface("ISelfValidate") IsNot Nothing Then

                e.Cancel = Not CType(PopulateInformation(lobjEmpty), BO.ISelfValidate).IsValid()

            End If

        End If
    End Sub
End Class
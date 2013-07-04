Imports System.Drawing.Design

Public Class FileNameEditor
    Inherits UITypeEditor

    ' Sets the edition mode of the property (dropdown or modal window).
    Public Overrides Function GetEditStyle(ByVal context As System.ComponentModel.ITypeDescriptorContext) As System.Drawing.Design.UITypeEditorEditStyle

        Return UITypeEditorEditStyle.Modal

    End Function

    ' Shows the editor of the property.
    ' Value: original value. Returns: The new value.
    Public Overrides Function EditValue(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal provider As System.IServiceProvider, ByVal value As Object) As Object

        Dim dialog As New Windows.Forms.OpenFileDialog()
        If dialog.ShowDialog = DialogResult.OK Then
            Return dialog.FileName
        Else
            Return value
        End If

    End Function


End Class

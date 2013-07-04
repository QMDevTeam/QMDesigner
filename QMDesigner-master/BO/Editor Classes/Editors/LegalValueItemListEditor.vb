Imports System.Drawing.Design

Public Class LegalValueItemListEditor
    Inherits UITypeEditor

#Region "Interface methods"

    ' Sets the edition mode of the property (dropdown or modal window).
    Public Overrides Function GetEditStyle(ByVal context As System.ComponentModel.ITypeDescriptorContext) As System.Drawing.Design.UITypeEditorEditStyle

        Return UITypeEditorEditStyle.Modal

    End Function

    ' Shows the editor of the property.
    ' Value: original value. Returns: The new value.
    Public Overrides Function EditValue(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal provider As System.IServiceProvider, ByVal value As Object) As Object

        Dim hiddenProp As Reflection.PropertyInfo = GetType(BO.LegalValueItem).GetProperty("Hidden")
        Dim valueProp As Reflection.PropertyInfo = GetType(BO.LegalValueItem).GetProperty("Value")
        Dim editor As New ListEditorFrm(value, GetType(BO.LegalValueItem), String.Format("{0} - {1} Editor", context.Instance.ToString, context.PropertyDescriptor.Name), hiddenProp, valueProp, False, False)
        editor.ShowDialog()
        editor.UpdateInputList()

        Return value

    End Function

#End Region

End Class

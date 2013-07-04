Imports System.Drawing.Design

Public Class ConditionEditor
    Inherits UITypeEditor

#Region "Interface methods"

    ' Sets the edition mode of the property (dropdown or modal window).
    Public Overrides Function GetEditStyle(ByVal context As System.ComponentModel.ITypeDescriptorContext) As System.Drawing.Design.UITypeEditorEditStyle

        Return UITypeEditorEditStyle.Modal
    End Function

    ' Shows the editor of the property.
    ' Value: original value. Returns: The new value.
    Public Overrides Function EditValue(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal provider As System.IServiceProvider, ByVal value As Object) As Object

        Return ConditionForm.GetCondition(value, context.Instance, "bit")
    End Function

#End Region

End Class

Imports System.Drawing.Design

Public Class MultiLanguageEditor
    Inherits UITypeEditor

#Region "Interface methods"

    ' Sets the edition mode of the property (dropdown or modal window).
    Public Overrides Function GetEditStyle(ByVal context As System.ComponentModel.ITypeDescriptorContext) As System.Drawing.Design.UITypeEditorEditStyle

        Return UITypeEditorEditStyle.Modal
    End Function

    ' Shows the editor of the property.
    ' Value: original value. Returns: The new value.
    Public Overrides Function EditValue(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal provider As System.IServiceProvider, ByVal value As Object) As Object

        Dim propertyName = context.PropertyDescriptor.Name & "Dictionary"
        Dim dictionaryProperty As Reflection.PropertyInfo = context.Instance.GetType.GetProperty(propertyName)
        Dim dictionary As Dictionary(Of Integer, String) = dictionaryProperty.GetValue(context.Instance, Nothing)
        dictionary = MultiLanguage.GetMultiLanguage(dictionary)
        dictionaryProperty.SetValue(context.Instance, dictionary, Nothing)

        If dictionary.ContainsKey(BO.ContextClass.CurrentLanguage.LanguageID) Then
            Return dictionary(BO.ContextClass.CurrentLanguage.LanguageID)
        Else
            Return ""
        End If
    End Function

#End Region

End Class

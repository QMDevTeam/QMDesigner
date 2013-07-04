Public Class LegalValuesEditor
    Inherits System.ComponentModel.TypeConverter

    ' Returns the list of the posible values.
    Public Overrides Function GetStandardValues(ByVal context As System.ComponentModel.ITypeDescriptorContext) As System.ComponentModel.TypeConverter.StandardValuesCollection

        Dim question As Question = context.Instance
        Dim tmp As String = question.ScreenTemplate.ToLower
        If tmp <> "dropdown" And tmp <> "radiobuttons" And tmp <> "checkbox" And tmp <> "name" Then
            Return Nothing
        Else
            Return New StandardValuesCollection(BO.Study.LegalValues)
        End If
    End Function

    ' Loads the sugested values for the property.
    Public Overrides Function GetStandardValuesSupported(ByVal context As System.ComponentModel.ITypeDescriptorContext) As Boolean

        Return True
    End Function

    ' Validates that the property value is a sugested value.
    Public Overrides Function GetStandardValuesExclusive(ByVal context As System.ComponentModel.ITypeDescriptorContext) As Boolean

        Return True
    End Function
End Class

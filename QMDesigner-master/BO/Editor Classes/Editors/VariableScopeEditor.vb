Public Class VariableScopeEditor
    Inherits System.ComponentModel.TypeConverter

    ' Returns the list of the posible values.
    Public Overrides Function GetStandardValues(ByVal context As System.ComponentModel.ITypeDescriptorContext) As System.ComponentModel.TypeConverter.StandardValuesCollection

        Return New StandardValuesCollection(ConfigData.VariableScopes)
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

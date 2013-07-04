Public Class DataTypeEditor
    Inherits System.ComponentModel.TypeConverter

    ' Returns the list of the posible values.
    Public Overrides Function GetStandardValues(ByVal context As System.ComponentModel.ITypeDescriptorContext) As System.ComponentModel.TypeConverter.StandardValuesCollection

        Dim index As Integer
        Dim dataTypes As New List(Of String)
        For Each template As BO.ScreenTemplate In BO.Study.ScreenTemplates
            If template.DataType <> "" Then
                index = 0
                While index < dataTypes.Count AndAlso dataTypes(index) < template.DataType
                    index += 1
                End While
                If index = dataTypes.Count Then
                    dataTypes.Add(template.DataType)
                ElseIf dataTypes(index) > template.DataType Then
                    dataTypes.Insert(index, template.DataType)
                End If
            End If
        Next

        Return New StandardValuesCollection(dataTypes)
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


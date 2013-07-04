Imports BO
Imports System.ComponentModel.TypeConverter
Imports System.Runtime.Remoting.Contexts

Public Class Logic

    Public Shared Function GetStandardValues() As System.ComponentModel.TypeConverter.StandardValuesCollection

        Return New System.ComponentModel.TypeConverter.StandardValuesCollection(ConfigData.ScreenTemplates)
    End Function

    Public Shared Function GetStandardValuesLegalValueTable(tmp As String) As System.ComponentModel.TypeConverter.StandardValuesCollection


        If tmp <> "DropDown" And tmp <> "RadioButtons" And tmp <> "CheckBox" And tmp <> "Name" Then
            Return Nothing
        Else
            Return New StandardValuesCollection(BO.Study.LegalValues)
        End If
    End Function

    Public Shared Function DataTypeNames(tmp As String) As String
        Dim Name As String = String.Empty
        Select Case tmp
            Case "TextBox", "Name"
                Name = "nvarchar(50)"
            Case "TextArea"
                Name = "nvarchar(255)"
            Case "DropDown", "RadioButtons", "Integer"
                Name = "Integer"
            Case "Decimal"
                Name = "numeric"
            Case "DateTime", "Date", "Time"
                Name = "datetime"
            Case "CheckBox"
                Name = "bit"
            Case "Grid", "GPSReading", "Info", "SectionExitScreen"
                Name = "NULL"
            Case Else
                Name = String.Empty
        End Select

        Return Name

    End Function

    Public Shared Function DataTypeItems() As System.ComponentModel.TypeConverter.StandardValuesCollection
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

        Return New System.ComponentModel.TypeConverter.StandardValuesCollection(dataTypes)
    End Function
End Class

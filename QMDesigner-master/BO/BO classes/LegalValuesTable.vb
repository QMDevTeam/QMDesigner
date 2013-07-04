Imports System.ComponentModel

Public Class LegalValuesTable


#Region "Properties"

    Private _name As String
    Private _comment As String
    Private _legalValues As New List(Of LegalValueItem)
    Private _guid As Guid

    'Name property.
    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            If value IsNot Nothing AndAlso Not String.IsNullOrEmpty(value.Trim) Then _name = value.Trim _
            Else Throw New Exception("The legal values object requires a name.")
        End Set
    End Property

    'Comment property.
    Public Property Comment() As String
        Get
            Return _comment
        End Get
        Set(ByVal value As String)
            If value IsNot Nothing Then
                _comment = value.Trim
            Else
                _comment = Nothing
            End If
        End Set
    End Property

    'Options property.
    <EditorAttribute(GetType(LegalValueItemListEditor), GetType(System.Drawing.Design.UITypeEditor))> _
    Public Property LegalValues() As List(Of LegalValueItem)
        Get
            Return _legalValues
        End Get
        Set(ByVal value As List(Of LegalValueItem))
            _legalValues = value
        End Set
    End Property

    'Guid property.
    <[ReadOnly](True)> _
    Public Property Guid() As Guid
        Get
            Return Me._guid
        End Get
        Set(ByVal value As Guid)
            Me._guid = value
        End Set
    End Property

#End Region



#Region "Methods"

    Public Sub New()

        Me.Name = "Empty Legal Value"
        Me.Guid = Guid.NewGuid()

    End Sub


    Public Overrides Function ToString() As String
        Return _name
    End Function

#End Region


End Class

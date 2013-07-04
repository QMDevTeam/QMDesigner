Imports System.ComponentModel

Public Class LegalValueItem


#Region "Properties"

    Private _guid As Guid
    Private _shortName As String = ""
    Private _text As New Dictionary(Of Integer, String)
    Private _group As String = ""
    Private _value As Integer = 0
    Private _hidden As Boolean = False

    ' Guid property.
    <BrowsableAttribute(False)> _
    Public Property Guid() As Guid
        Get
            Return _guid
        End Get
        Set(ByVal value As Guid)
            _guid = value
        End Set
    End Property

    'ShortName property.
    Public Property ShortName() As String
        Get
            Return _shortName
        End Get
        Set(ByVal value As String)
            _shortName = BO.GenericObject.CheckIdentifier(value)
        End Set
    End Property

    'Text property.
    <EditorAttribute(GetType(MultiLanguageEditor), GetType(System.Drawing.Design.UITypeEditor))> _
    Public Property Text() As String
        Get
            If _text.ContainsKey(BO.ContextClass.CurrentLanguage.LanguageID) Then
                Return _text(BO.ContextClass.CurrentLanguage.LanguageID)
            Else
                Return ""
            End If
        End Get
        Set(ByVal value As String)
            If value IsNot Nothing Then value = value.Trim
            _text.Item(BO.ContextClass.CurrentLanguage.LanguageID) = value
        End Set
    End Property

    'TextDictionary property.
    <BrowsableAttribute(False)> _
    Public Property TextDictionary() As Dictionary(Of Integer, String)
        Get
            Return _text
        End Get
        Set(ByVal value As Dictionary(Of Integer, String))
            _text = value
        End Set
    End Property

    'Group property.
    Public Property Group() As String
        Get
            Return _group
        End Get
        Set(ByVal value As String)
            If value IsNot Nothing Then
                _group = value.Trim
            Else
                _group = Nothing
            End If
        End Set
    End Property

    'Index property.
    Public Property Value() As Integer
        Get
            Return _value
        End Get
        Set(ByVal newValue As Integer)
            _value = newValue
        End Set
    End Property

    <DefaultValue(False)> _
    Public Property Hidden() As Boolean
        Get
            Return Me._hidden
        End Get
        Set(ByVal value As Boolean)
            Me._hidden = value
        End Set
    End Property

#End Region



#Region "Methods"

    Public Overrides Function ToString() As String
        Return Text
    End Function

    Public Sub New()

        Me._guid = Guid.NewGuid

    End Sub
#End Region


End Class

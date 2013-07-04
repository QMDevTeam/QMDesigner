Public Class KeyInfo

    Private _alias As String
    Private _name As String
    Private _show As Boolean

    Public Sub New(ByVal alias_ As String, ByVal name_ As String)
        _alias = alias_
        _name = name_
    End Sub

    Public ReadOnly Property AliasName() As String
        Get
            Return _alias
        End Get
    End Property

    Public ReadOnly Property Name() As String
        Get
            Return _name
        End Get
    End Property

    Public Property Show() As Boolean
        Get
            Return _show
        End Get
        Set(ByVal value As Boolean)
            value = _show
        End Set
    End Property

End Class

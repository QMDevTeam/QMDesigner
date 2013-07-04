Public Class ScreenTemplate

#Region "Properties"

    Private _name As String = ""
    Private _dataType As String = ""
    Private _dotNetClassName As String = ""
    Private _dataBaseID As Integer = 0
    Private _variableNameRequired As Boolean = True

    ' ScreenTemplateName property.
    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            If value IsNot Nothing Then
                _name = value.Trim
            Else
                _name = Nothing
            End If
        End Set
    End Property

    ' DataType property.
    Public Property DataType() As String
        Get
            Return _dataType
        End Get
        Set(ByVal value As String)
            _dataType = value.Trim
        End Set
    End Property

    ' DotNetClassName property.
    Public Property DotNetClassName() As String
        Get
            Return _dotNetClassName
        End Get
        Set(ByVal value As String)
            If value IsNot Nothing Then
                _dotNetClassName = value.Trim
            Else
                _dotNetClassName = Nothing
            End If
        End Set
    End Property

    ' DataBaseID property.
    Public Property DataBaseID() As Integer
        Get
            Return _dataBaseID
        End Get
        Set(ByVal value As Integer)
            _dataBaseID = value
        End Set
    End Property

    ' VariableNameRequired property.
    Public Property VariableNameRequired() As Boolean
        Get
            Return Me._variableNameRequired
        End Get
        Set(ByVal value As Boolean)
            Me._variableNameRequired = value
        End Set
    End Property
#End Region

End Class

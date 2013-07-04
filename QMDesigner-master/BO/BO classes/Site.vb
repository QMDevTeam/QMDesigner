Public Class Site


#Region "Properties"

    Private _name As String = ""
    Private _code As String = ""
    Private _dataBaseID As Integer = 0


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


    Public Property Code() As String
        Get
            Return _code
        End Get
        Set(ByVal value As String)
            If value IsNot Nothing Then
                _code = value.Trim
            Else
                _code = Nothing
            End If
        End Set
    End Property


    Public Property DataBaseID() As Integer
        Get
            Return _dataBaseID
        End Get
        Set(ByVal value As Integer)
            _dataBaseID = value
        End Set
    End Property


#End Region



#Region "Public Methods"

    Public Overrides Function ToString() As String
        Return _name
    End Function

#End Region


End Class

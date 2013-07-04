Public Class CellInfo

    Private _newValue As Object
    Private _oldValue As Object
    Private _column As ColumnInfo

    Public Sub New(ByVal oldValue As Object, ByVal column_ As ColumnInfo)

        _column = column_
        _oldValue = oldValue

    End Sub

    Public ReadOnly Property Column() As ColumnInfo
        Get
            Return _column
        End Get
    End Property

    Public Property NewValue() As Object
        Get
            Return _newValue
        End Get
        Set(ByVal value As Object)

            _newValue = value

        End Set
    End Property

    Public ReadOnly Property OldValue() As Object
        Get
            Return _oldValue
        End Get

    End Property

End Class

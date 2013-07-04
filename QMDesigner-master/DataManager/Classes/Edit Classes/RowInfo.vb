Public Class RowInfo

    Private _rowIndex As Integer
    Private _cellsToModify As Dictionary(Of ColumnInfo, CellInfo)
    Private _keyValues As Dictionary(Of KeyInfo, Object)

    Public ReadOnly Property CellsToModify() As Dictionary(Of ColumnInfo, CellInfo)
        Get
            Return _cellsToModify
        End Get
    End Property

    Public ReadOnly Property KeyValues() As Dictionary(Of KeyInfo, Object)
        Get
            Return _keyValues
        End Get
    End Property

    Public ReadOnly Property RowIndex() As Integer
        Get
            Return _rowIndex
        End Get
    End Property

    Public Sub New(ByVal rowIndex As Integer)
        _rowIndex = rowIndex
        _cellsToModify = New Dictionary(Of ColumnInfo, CellInfo)
        _keyValues = New Dictionary(Of KeyInfo, Object)
    End Sub

    Public Sub AddCell(ByVal cell As CellInfo)

        Dim tempCellInfo As CellInfo = Nothing

        If _cellsToModify.TryGetValue(cell.Column, tempCellInfo) Then

            tempCellInfo.NewValue = cell.NewValue

        Else

            _cellsToModify.Add(cell.Column, cell)

        End If

    End Sub

    Public Sub ClearCells()
        _cellsToModify = New Dictionary(Of ColumnInfo, CellInfo)
    End Sub

    Public Sub AddKeyValue(ByVal key As KeyInfo, ByVal value As Object)
        _keyValues.Add(key, value)
    End Sub

    Public Sub ClearKeyValues()
        _keyValues = New Dictionary(Of KeyInfo, Object)
    End Sub

    Public Function GetKeyValue(ByVal key As KeyInfo) As Object

        If _keyValues.ContainsKey(key) Then
            Return _keyValues(key)
        Else
            Return Nothing
        End If

    End Function

End Class

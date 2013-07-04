

Public Class TableInfo

#Region " Private Memebers "

    Private _alias As String
    Private _dataTableName As String
    Private _questionnaireTable As TableInfo = Nothing
    Private _multipleInstance As Boolean = False
    Private _keys As Dictionary(Of String, KeyInfo)
    Private _rowsToModify As Dictionary(Of Integer, RowInfo)
    Private _tableType As TableType
    Private _logTableName As String
    Private _PDATableName As String

#End Region

#Region " Public Methods "

    Public Sub New(ByVal alias_ As String, ByVal dataTableName_ As String, ByVal logTableName_ As String, _
                ByVal PDATableName_ As String, ByVal tableType_ As TableType)

        _alias = alias_
        _dataTableName = dataTableName_
        _keys = New Dictionary(Of String, KeyInfo)
        _rowsToModify = New Dictionary(Of Integer, RowInfo)
        _tableType = tableType_
        _logTableName = logTableName_
        _PDATableName = PDATableName_

    End Sub

    Public Sub AddKey(ByVal key As KeyInfo)
        _keys.Add(key.Name, key)
    End Sub

    Public Sub ClearKeys()
        _keys.Clear()
    End Sub

    Public Sub AddRowsToModify(ByVal row As RowInfo)

        Dim tempRow As RowInfo = Nothing
        If _rowsToModify.TryGetValue(row.RowIndex, tempRow) Then

            For Each cell As CellInfo In New List(Of CellInfo)(row.CellsToModify.Values)

                tempRow.AddCell(cell)

            Next

        Else
            _rowsToModify.Add(row.RowIndex, row)
        End If

    End Sub

    Public Sub ClearRowsToModify()
        _rowsToModify.Clear()
    End Sub

#End Region

#Region " Public Properties "

    Public ReadOnly Property PDATableName() As String
        Get
            Return _PDATableName
        End Get
    End Property

    Public ReadOnly Property LogTableName() As String
        Get
            Return _logTableName
        End Get
    End Property

    Public Property AliasName() As String
        Get
            Return _alias
        End Get
        Set(ByVal value As String)
            _alias = value
        End Set
    End Property

    Public ReadOnly Property DataTableName() As String
        Get
            Return _dataTableName
        End Get
    End Property

    Public ReadOnly Property Keys() As Dictionary(Of String, KeyInfo)
        Get
            Return _keys
        End Get
    End Property

    Public ReadOnly Property RowsToModify() As Dictionary(Of Integer, RowInfo)
        Get
            Return _rowsToModify
        End Get
    End Property

    ''' <summary>
    ''' Get and Set the Questionnaire Table that is the father of the actual table
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property QuestionnaireTable() As TableInfo
        Get
            Return _questionnaireTable
        End Get
        Set(ByVal value As TableInfo)
            _questionnaireTable = value
        End Set
    End Property

    ''' <summary>
    ''' Get and Set if the table has multiple instance
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MultipleInstance() As Boolean
        Get
            Return _multipleInstance
        End Get
        Set(ByVal value As Boolean)
            _multipleInstance = value
        End Set
    End Property


    ''' <summary>
    ''' Get the SQL Script of the table
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property SQLScript(ByVal questionnaireSetAlias As String, ByVal usingMainDB As Boolean) As String
        Get
            Dim query As String = ""
            Dim tableName As String = IIf(usingMainDB, _
                                        String.Format("[{0}].[{1}]", BO.ContextClass.Study.DataTableSchema, Me.DataTableName), _
                                        String.Format("[{0}]", Me.PDATableName)).ToString
            If _tableType = DataManager.TableType.QuestionnaireSetTable Then

                query = String.Format(" {0} [{1}] ", tableName, Me.AliasName)

            ElseIf _multipleInstance And Not _tableType = DataManager.TableType.Questionnaire Then
                ' Add the Questionnaire Table

                query = String.Format(" LEFT JOIN {0} [{1}] ON [{3}].subjectid = [{1}].subjectid AND [{2}].[SubjectQuestionnaireInstanceID] = [{1}].[SubjectQuestionnaireInstanceID] ", _
                                        tableName, AliasName, QuestionnaireTable.AliasName, _
                                         questionnaireSetAlias)

            Else

                query = String.Format(" LEFT JOIN {0} [{1}] ON [{2}].subjectid = [{1}].subjectid ", tableName, AliasName, _
                                         questionnaireSetAlias)

            End If

            Return query
        End Get
    End Property

    Public ReadOnly Property TableType() As TableType
        Get
            Return _tableType
        End Get
    End Property

#End Region

End Class

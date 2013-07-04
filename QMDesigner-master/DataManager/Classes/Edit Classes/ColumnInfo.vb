Public Class ColumnInfo

#Region " Private Members "

    Private _alias As String
    Private _name As String
    Private _trimName As Boolean = False
    Private _type As String
    Private _table As TableInfo
    Private _readonly As Boolean
    Private _maxChars As Integer
    Private _legalValues As BO.LegalValuesTable
    Private _isDropDownOrRadioBut As Boolean
    Private Const _maxLengthTrimedName As Integer = 32

#End Region

#Region " Public Methods "

    Public Sub New(ByVal alias_ As String, ByVal name_ As String, ByVal type_ As String, _
                    ByVal maxChars_ As Integer, ByVal table_ As TableInfo, _
                    ByVal legalValues As BO.LegalValuesTable, ByVal isDropDownOrRadioBut As Boolean)

        _alias = alias_
        _name = name_
        _type = type_.Trim
        _table = table_
        _maxChars = maxChars_
        _readonly = _type.ToLower = "tinyint" Or _type.ToLower = "uniqueidentifier"
        _legalValues = legalValues
        _isDropDownOrRadioBut = isDropDownOrRadioBut

    End Sub

#End Region

#Region " Public Properties "

    Public ReadOnly Property Name() As String
        Get
            Return _name
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


    Public ReadOnly Property Type() As String
        Get
            Return _type
        End Get
    End Property


    Public ReadOnly Property Table() As TableInfo
        Get
            Return _table
        End Get
    End Property


    Public ReadOnly Property Read_Only() As Boolean
        Get
            Return _readonly
        End Get
    End Property

    ''' <summary>
    ''' True = the maximum number of characters of the alias is 32 
    ''' False = the alias doesnt have masimum number of characters.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TrimName() As Boolean
        Get
            Return _trimName
        End Get
        Set(ByVal value As Boolean)
            _trimName = value
        End Set
    End Property

    ''' <summary>
    ''' Get the SQL Script of the Field
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property SQLScript() As String
        Get
            Dim temp As String = ""
            Dim tempAlias As String = ""

            If _table Is Nothing Or _name.Trim = "" Then Return ""
            If _alias.Trim = "" Then
                tempAlias = _name
            Else
                tempAlias = _alias
            End If

            If _trimName And tempAlias.Length > _maxLengthTrimedName Then
                tempAlias = tempAlias.Substring(0, _maxLengthTrimedName)
            End If

            Return String.Format("[{0}].[{1}] AS [{2}]", _table.AliasName.Trim, _name, tempAlias)

        End Get
    End Property


    Public ReadOnly Property MaxChars() As Integer
        Get
            Return _maxChars
        End Get
    End Property


    Public ReadOnly Property UseLegalValue() As Boolean
        Get
            Return _isDropDownOrRadioBut
        End Get
    End Property


    Public ReadOnly Property LegalValue() As BO.LegalValuesTable
        Get
            Return _legalValues
        End Get
    End Property

#End Region

End Class

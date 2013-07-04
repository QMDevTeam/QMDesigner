Imports System.ComponentModel

''' <summary>
''' Enumerates the report types.
''' </summary>
''' <remarks></remarks>

Public Enum ReportType
    Standard = 1
    Custom = 2
End Enum



Public Class Report


#Region " Properties "

    Private _guid As Guid
    Private _name As String
    Private _reportType As ReportType
    Private _formTypeName As String
    Private _query As String
    Private _columns As List(Of ReportColumn)
    Private _siteCodes As List(Of String)

    ''' <summary>
    ''' Unique identifier for the report.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    <CategoryAttribute("System Information"), _
    DisplayName("Unique Identifier")> _
    Public ReadOnly Property Guid() As Guid
        Get
            Return Me._guid
        End Get
    End Property


    ''' <summary>
    ''' Name of the report.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    <CategoryAttribute(" General Information"), _
    DisplayName("Report Name")> _
    Public Property Name() As String
        Get
            Return Me._name
        End Get
        Set(ByVal value As String)
            Me._name = value
        End Set
    End Property


    ''' <summary>
    ''' Sites where the report is valid.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    <CategoryAttribute(" General Information"), _
    DescriptionAttribute("If left empty the report will be avialibre for all the sites."), _
    DisplayName("Report Sites")> _
    Public Property SiteCodes() As List(Of String)
        Get
            Return Me._siteCodes
        End Get
        Set(ByVal value As List(Of String))
            Me._siteCodes = value
        End Set
    End Property


    ''' <summary>
    ''' Set the type of the report.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    <CategoryAttribute(" General Information"), _
    DisplayName("Report Type")> _
    Public Property ReportType() As ReportType
        Get
            Return Me._reportType
        End Get
        Set(ByVal value As ReportType)
            Me._reportType = value
        End Set
    End Property


    ''' <summary>
    ''' Form Type Name, when is a custom report.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    <CategoryAttribute("Custom Report"), _
    DisplayName("Form Type Name")> _
    Public Property FormTypeName() As String
        Get
            Return Me._formTypeName
        End Get
        Set(ByVal value As String)
            Me._formTypeName = value
        End Set
    End Property


    ''' <summary>
    ''' The report query.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    <CategoryAttribute("Standard report"), _
    DisplayName("Report Query"), _
    EditorAttribute(GetType(CodeEditor), GetType(System.Drawing.Design.UITypeEditor))> _
    Public Property Query() As String
        Get
            Return Me._query
        End Get
        Set(ByVal value As String)
            Me._query = value
        End Set
    End Property


    ''' <summary>
    ''' Columns of the report.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    <CategoryAttribute("Standard report"), _
    DescriptionAttribute("Allows you to customize the columns in the report."), _
    DisplayName("Columns definition")> _
    Public Property Columns() As List(Of ReportColumn)
        Get
            Return Me._columns
        End Get
        Set(ByVal value As List(Of ReportColumn))
            Me._columns = value
        End Set
    End Property

#End Region



#Region " Public Methods "

    Public Sub New()

        Me._guid = Guid.NewGuid()
        Me.Initialize()

    End Sub


    Public Sub New(ByVal guid As Guid)

        Me._guid = guid
        Me.Initialize()

    End Sub


    Public Overrides Function ToString() As String

        Return Me.Name

    End Function

#End Region



#Region " Private Methods "

    Private Sub Initialize()

        Me._columns = New List(Of ReportColumn)
        Me._siteCodes = New List(Of String)

    End Sub

#End Region


End Class

Imports System.ComponentModel

Public Class ReportColumn


#Region " Properties "

    Private _guid As Guid
    Private _name As String
    Private _headerText As String
    Private _width As Integer
    Private _format As String

    ''' <summary>
    ''' Guid for the column definition.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public ReadOnly Property Guid() As Guid
        Get
            Return Me._guid
        End Get
    End Property


    ''' <summary>
    ''' Name of the column.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    <DescriptionAttribute("Name of the column in the query."), _
    DisplayName("Column name")> _
    Public Property Name() As String
        Get
            Return Me._name
        End Get
        Set(ByVal value As String)
            Me._name = value
        End Set
    End Property


    ''' <summary>
    ''' Title for the column in the grid.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    <DescriptionAttribute("Text to be displayed as the column header in the grid."), _
    DisplayName("Header text")> _
    Public Property HeaderText() As String
        Get
            Return Me._headerText
        End Get
        Set(ByVal value As String)
            Me._headerText = value
        End Set
    End Property


    ''' <summary>
    ''' Width of the column in the grid.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Property Width() As Integer
        Get
            Return Me._width
        End Get
        Set(ByVal value As Integer)
            If value > 0 Then Me._width = value
        End Set
    End Property


    ''' <summary>
    ''' Specific format to display the data.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Property Format() As String
        Get
            Return Me._format
        End Get
        Set(ByVal value As String)
            Me._format = value
        End Set
    End Property

#End Region



#Region " Methods "

    Public Sub New()

        Me._guid = Guid.NewGuid

    End Sub


    Public Sub New(ByVal guid As Guid)

        Me._guid = guid

    End Sub

#End Region


End Class

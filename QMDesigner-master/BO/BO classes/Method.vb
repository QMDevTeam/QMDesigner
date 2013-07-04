Imports System.ComponentModel

Public Enum MethodType
    UserMethod = 0
    Precondition = 1
    Action = 2
End Enum

Public Class Method


#Region "Properties"

    Private _guid As Guid
    Private _name As String
    Private _type As String
    Private _code As String


    ''' <summary>
    ''' Guid Property.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    <[ReadOnly](True)> _
    Public Property Guid() As Guid
        Get
            Return Me._guid
        End Get
        Set(ByVal value As Guid)
            Me._guid = value
        End Set
    End Property


    ''' <summary>
    ''' Name property.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Property Name() As String
        Get
            Return Me._name
        End Get
        Set(ByVal value As String)
            Me._name = BO.GenericObject.CheckIdentifier(value)
        End Set
    End Property

    ''' <summary>
    ''' Type property.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Property Type() As MethodType
        Get
            Return Me._type
        End Get
        Set(ByVal value As MethodType)
            Me._type = value
        End Set
    End Property


    ''' <summary>
    ''' Code property.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    <EditorAttribute(GetType(CodeEditor), GetType(System.Drawing.Design.UITypeEditor))> _
    Public Property Code() As String
        Get
            Return Me._code
        End Get
        Set(ByVal value As String)
            Me._code = value
        End Set
    End Property

#End Region



#Region "Methods"

    Public Sub New()

        Me._guid = Guid.NewGuid()

    End Sub


    Public Overrides Function ToString() As String

        Return Me.Name

    End Function

#End Region

End Class

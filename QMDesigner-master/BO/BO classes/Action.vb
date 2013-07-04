Imports System.Runtime.Serialization
Imports System.ComponentModel

<Serializable()> _
Public Class Action
    Implements ISerializable

#Region "Properties"

    Private _actionType As String = ""
    Private _target As String = ""
    Private _argument As String = ""

    ' Action Type property.
    <DisplayName("Action Type"), _
    TypeConverter(GetType(ActionTypeEditor)), _
    DescriptionAttribute("Type of acction to be taken.")> _
    Public Property ActionType() As String
        Get
            Return _actionType
        End Get
        Set(ByVal value As String)
            If value IsNot Nothing Then
                _actionType = value.Trim
            Else
                _actionType = Nothing
            End If
        End Set
    End Property

    ' Target property.
    <DisplayName("Target"), _
    DefaultValue(""), _
    DescriptionAttribute("Type of acction to be taken.")> _
    Public Property Target() As String
        Get
            Return _target
        End Get
        Set(ByVal value As String)
            If value IsNot Nothing Then
                _target = value.Trim
            Else
                _target = Nothing
            End If
        End Set
    End Property

    ' Argument property.
    <DisplayName("Argument"), _
    DefaultValue(""), _
    DescriptionAttribute("Type of acction to be taken.")> _
    Public Property Argument() As String
        Get
            Return _argument
        End Get
        Set(ByVal value As String)
            If value IsNot Nothing Then
                _argument = value.Trim
            Else
                _argument = Nothing
            End If
        End Set
    End Property
#End Region

#Region "Methods"

    ''' <summary>
    ''' Constructor: No parameters, for compatibility.
    ''' </summary>
    ''' <remarks></remarks>

    Public Sub New()

    End Sub


    ''' <summary>
    ''' Constructor: All the properties already set.
    ''' </summary>
    ''' <param name="type">Type of the action</param>
    ''' <param name="target">Target of the action</param>
    ''' <param name="argument">Arguments</param>
    ''' <remarks></remarks>

    Public Sub New(ByVal type As String, ByVal target As String, ByVal argument As String)
        Me.ActionType = type
        Me.Target = target
        Me.Argument = argument
    End Sub


    ''' <summary>
    ''' Constructor: Protected constructor for serialization.
    ''' </summary>
    ''' <param name="info">Seriailzed object.</param>
    ''' <param name="context"></param>
    ''' <remarks></remarks>

    Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)

        Me._actionType = info.GetValue("A001", GetType(String))
        Me._target = info.GetValue("A002", GetType(String))
        Me._argument = info.GetValue("A003", GetType(String))

    End Sub


    ''' <summary>
    ''' Deserialize object.
    ''' </summary>
    ''' <param name="info"></param>
    ''' <param name="context"></param>
    ''' <remarks></remarks>

    Public Sub GetObjectData(ByVal info As SerializationInfo, ByVal context As StreamingContext) Implements ISerializable.GetObjectData

        info.AddValue("A001", Me._actionType)
        info.AddValue("A002", Me._target)
        info.AddValue("A003", Me._argument)

    End Sub


    ''' <summary>
    ''' Overrides ToString for a more representative one.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Overrides Function ToString() As String

        If String.IsNullOrEmpty(Me._actionType) Then

            Return "(New Action)"

        Else

            Return Me._actionType & " " & Me._target

        End If

    End Function

#End Region


End Class

Imports System.Runtime.Serialization
Imports System.ComponentModel

<Serializable()> _
Public Class Information
    Inherits SectionItem
    Implements ISerializable


#Region "PDA Settings Properties"

    Private _hideNext As Boolean = False
    Private _hideBack As Boolean = False
    Private _visible As Boolean = True

    ' HideNext Property.
    <CategoryAttribute("PDA settings"), _
    DisplayName("Hide Next"), _
    DefaultValueAttribute(False), _
    DescriptionAttribute("Hides or shows the next question button.")> _
    Public Property HideNext() As Boolean
        Get
            Return _hideNext
        End Get
        Set(ByVal value As Boolean)
            _hideNext = value
        End Set
    End Property

    ' HideBack Property.
    <CategoryAttribute("PDA settings"), _
    DisplayName("Hide Back"), _
    DefaultValueAttribute(False), _
    DescriptionAttribute("Hides or shows the back button.")> _
    Public Property HideBack() As Boolean
        Get
            Return _hideBack
        End Get
        Set(ByVal value As Boolean)
            _hideBack = value
        End Set
    End Property

    ' HideBack Property.
    <CategoryAttribute("PDA settings"), _
    DisplayName("Visilbe"), _
    DefaultValueAttribute(False), _
    DescriptionAttribute("Hides or shows the screen on the PDA.")> _
    Public Property Visible() As Boolean
        Get
            Return Me._visible
        End Get
        Set(ByVal value As Boolean)
            Me._visible = value
        End Set
    End Property

#End Region



#Region "PDA Actions properties."

    Private _onLoad As String
    Private _onUnload As String

    ' OnLoad Property
    <CategoryAttribute("PDA Actions"), _
    DisplayName("On Load"), _
    DescriptionAttribute("Set the list of actions when the question is loaded."), _
    EditorAttribute(GetType(CodeEditor), GetType(System.Drawing.Design.UITypeEditor))> _
    Public Property OnLoad() As String
        Get
            Return _onLoad
        End Get
        Set(ByVal value As String)
            _onLoad = value
        End Set
    End Property

    ' OnUnload Property
    <CategoryAttribute("PDA Actions"), _
    DisplayName("On Unload"), _
    DescriptionAttribute("Set the list of actions when the question is unloaded."), _
    EditorAttribute(GetType(CodeEditor), GetType(System.Drawing.Design.UITypeEditor))> _
    Public Property OnUnload() As String
        Get
            Return _onUnload
        End Get
        Set(ByVal value As String)
            _onUnload = value
        End Set
    End Property

#End Region



#Region "Generic Object properties"

    ' HasSectionItems property
    <BrowsableAttribute(False)> _
    Public Overrides ReadOnly Property HasSectionItems() As Boolean
        Get
            Return False
        End Get
    End Property

    ' HasVariables property
    <BrowsableAttribute(False)> _
    Public Overrides ReadOnly Property HasVariables() As Boolean
        Get
            Return False
        End Get
    End Property

#End Region


#Region "Methods"

    ''' <summary>
    ''' Sets the parent section.
    ''' </summary>
    ''' <remarks></remarks>

    Public Sub New()
    End Sub


    ''' <summary>
    ''' Finds the diferences between two informations.
    ''' </summary>
    ''' <param name="genericObject"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Overrides Function Difference(ByVal genericObject As GenericObject) As GenericObject

        ' Check types.
        If Not genericObject.GetType.Equals(GetType(Information)) Then Return Nothing

        ' Create the object.
        Dim result As New Information()
        Dim info As Information = genericObject
        Dim changed As Boolean = False

        ' Generic object properties.
        result.SetGuidWithoutHash(Nothing)

        If Me.Name <> info.Name Then
            result.Name = Me.Name
            changed = True
        Else
            result.Name = Nothing
        End If

        If Me.Comment <> info.Comment Then
            result.Comment = Me.Comment
            changed = True
        Else
            result.Comment = Nothing
        End If

        result.DataBaseID = Nothing

        ' Phase properties.
        If Me.MainText <> info.MainText Then
            result.MainText = Me.MainText
            changed = True
        Else
            result.MainText = Nothing
        End If

        If Me.Parent.Guid <> info.Parent.Guid Then
            result.SetParent(Me.Parent)
            changed = True
        End If

        If Me.Number <> info.Number Then
            result.Number = Me.Number
            changed = True
        Else
            result.Number = Nothing
        End If

        ' Checkpoint properties.
        If Me.HideNext <> info.HideNext Then
            result.HideNext = Me.HideNext
            changed = True
        Else
            result.HideNext = Nothing
        End If

        If Me.HideBack <> info.HideBack Then
            result.HideBack = Me.HideBack
            changed = True
        Else
            result.HideBack = Nothing
        End If

        ' Return the value.
        If changed Then Return result Else Return Nothing
    End Function


    Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)

        ' Generic object properties.
        Me._guid = info.GetValue("GO001", GetType(Guid))
        Me._name = info.GetValue("GO002", GetType(Dictionary(Of Integer, String)))
        Me._comment = info.GetValue("GO003", GetType(String))
        Me._dataBaseID = info.GetValue("GO004", GetType(Integer))
        Me._dataTableName = info.GetValue("GO005", GetType(String))
        Me._logTableName = info.GetValue("GO006", GetType(String))

        ' Phase properties.
        Me._mainText = info.GetValue("P001", GetType(Dictionary(Of Integer, String)))
        Me._number = info.GetValue("P002", GetType(String))

        ' Information properties.
        Me._hideNext = info.GetValue("I001", GetType(Boolean))
        Me._hideBack = info.GetValue("I002", GetType(Boolean))


    End Sub

    Public Sub GetObjectData(ByVal info As SerializationInfo, ByVal context As StreamingContext) Implements ISerializable.GetObjectData

        ' Generic object properties.
        info.AddValue("GO001", Me._guid)
        info.AddValue("GO002", Me._name)
        info.AddValue("GO003", Me._comment)
        info.AddValue("GO004", Me._dataBaseID)
        info.AddValue("GO005", Me._dataTableName)
        info.AddValue("GO006", Me._logTableName)

        ' Phase properties.
        info.AddValue("P001", Me._mainText)
        info.AddValue("P002", Me._number)

        ' Information properties.
        info.AddValue("I001", Me._hideNext)
        info.AddValue("I002", Me._hideBack)

    End Sub
#End Region


End Class

Imports System.Runtime.Serialization
Imports System.ComponentModel

Public MustInherit Class SectionItem
    Inherits GenericObject
    Implements ISerializable

#Region "Properties"

    Friend _mainText As New Dictionary(Of Integer, String)
    Friend _parent As GenericObject = Nothing
    Friend _number As String = Nothing

    ' Main text Property.
    <CategoryAttribute("(Main)"), _
    DisplayName("Main Text"), _
    DefaultValueAttribute(""), _
    DescriptionAttribute("The question to be displayed."), _
    EditorAttribute(GetType(MultiLanguageEditor), GetType(System.Drawing.Design.UITypeEditor))> _
    Public Property MainText() As String
        Get
            If _mainText.ContainsKey(BO.ContextClass.CurrentLanguage.LanguageID) Then
                Return _mainText(BO.ContextClass.CurrentLanguage.LanguageID)
            Else
                Return ""
            End If
        End Get
        Set(ByVal value As String)
            If value IsNot Nothing Then value = value.Trim
            _mainText.Item(BO.ContextClass.CurrentLanguage.LanguageID) = value
        End Set
    End Property

    ' Main Text Dictionary Property.
    <Browsable(False)> _
    Public Property MainTextDictionary() As Dictionary(Of Integer, String)
        Get
            Return _mainText
        End Get
        Set(ByVal value As Dictionary(Of Integer, String))
            _mainText = value
        End Set
    End Property

    ' Number Property.
    <BrowsableAttribute(False)> _
    Public Property Number() As String
        Get
            Return _number
        End Get
        Set(ByVal value As String)
            _number = value
        End Set
    End Property


    <BrowsableAttribute(False)> _
    Public Shadows Property DataTableName() As String
        Get
            Return Nothing
        End Get
        Set(ByVal value As String)

        End Set
    End Property


    <BrowsableAttribute(False)> _
    Public Shadows Property LogTableName() As String
        Get
            Return Nothing
        End Get
        Set(ByVal value As String)

        End Set
    End Property


    <BrowsableAttribute(False)> _
    Public Shadows Property PDADataTableName() As String
        Get
            Return Nothing
        End Get
        Set(ByVal value As String)

        End Set
    End Property


    <[ReadOnly](True), _
    CategoryAttribute("System Information")> _
    Public ReadOnly Property SectionID() As Integer
        Get
            Dim obj As GenericObject = Me
            While obj IsNot Nothing
                If obj.GetType.Equals(GetType(BO.Section)) Then
                    Return obj.DataBaseID
                Else
                    obj = obj.Parent
                End If
            End While
        End Get
    End Property


    <[ReadOnly](True), _
    CategoryAttribute("System Information")> _
    Public ReadOnly Property QuestionnaireID() As Integer
        Get
            Dim obj As GenericObject = Me
            While obj IsNot Nothing
                If obj.GetType.Equals(GetType(BO.Questionnaire)) Then
                    Return obj.DataBaseID
                Else
                    obj = obj.Parent
                End If
            End While
        End Get
    End Property


    <[ReadOnly](True), _
    CategoryAttribute("System Information")> _
    Public ReadOnly Property QuestionnaireSetID() As Integer
        Get
            Dim obj As GenericObject = Me
            While obj IsNot Nothing
                If obj.GetType.Equals(GetType(BO.QuestionnaireSet)) Then
                    Return obj.DataBaseID
                Else
                    obj = obj.Parent
                End If
            End While
        End Get
    End Property

#End Region

#Region "Functions"

    Public Overrides Function ToString() As String

        If Me.GetType.Equals(GetType(BO.Question)) Then

            Return String.Format("{0}) {1} {2}", _number, CType(Me, BO.Question).GroupText, MainText.Replace(vbCrLf, ""))

        Else

            Return String.Format("{0}) {1}", _number, MainText.Replace(vbCrLf, ""))

        End If
    End Function

    Public Sub New()
        Me.DataBaseID = Nothing
    End Sub

    Public Function GetMainTextDictionary() As Dictionary(Of Integer, String)
        Return Me._mainText
    End Function

    Public Sub SetMainTextDictionary(ByVal dictionary As Dictionary(Of Integer, String))
        Me._mainText = dictionary
    End Sub

#End Region


    Public Overrides Function Difference(ByVal genericObject As GenericObject) As GenericObject

    End Function

    Public Overrides ReadOnly Property HasSectionItems() As Boolean
        Get

        End Get
    End Property

    Public Overrides ReadOnly Property HasVariables() As Boolean
        Get

        End Get
    End Property


    Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)

    End Sub

    Public Sub GetObjectData(ByVal info As SerializationInfo, ByVal context As StreamingContext) Implements ISerializable.GetObjectData

    End Sub

End Class

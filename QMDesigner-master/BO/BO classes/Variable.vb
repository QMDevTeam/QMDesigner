Imports System.Runtime.Serialization
Imports System.ComponentModel

<Serializable()> _
Public Class Variable
    Inherits GenericObject
    Implements ISerializable, ISelfValidate


#Region "Generic variable properties"

    Dim question As Question

    ' Variable name property.
    <CategoryAttribute("(Main)"), _
    DisplayName("Variable Name"), _
    DefaultValueAttribute(""), _
    DescriptionAttribute("The name of the variable.")> _
    Public Shadows Property VariableName() As String
        Get

            Return question.VariableName
        End Get
        Set(ByVal value As String)

            question.SetVariableName(value)
        End Set
    End Property

    ' Main text property.
    <CategoryAttribute("(Main)"), _
    DisplayName("Main Text"), _
    DefaultValueAttribute(""), _
    DescriptionAttribute("What the variable is used for in a few words."), _
    EditorAttribute(GetType(MultiLanguageEditor), GetType(System.Drawing.Design.UITypeEditor))> _
    Public Property MainText() As String
        Get
            Return question.MainText
        End Get
        Set(ByVal value As String)
            question.MainText = value
        End Set
    End Property

    ' Main Text Dictionary Property.
    <Browsable(False)> _
    Public Property MainTextDictionary() As Dictionary(Of Integer, String)
        Get
            Return question.GetMainTextDictionary
        End Get
        Set(ByVal value As Dictionary(Of Integer, String))
            question.SetMainTextDictionary(value)
        End Set
    End Property

    ' Data type property
    <CategoryAttribute("(Main)"), _
    DisplayName("Data type"), _
    DefaultValueAttribute(""), _
    DescriptionAttribute("The data type of the variable."), _
    TypeConverter(GetType(DataTypeEditor))> _
    Public Property DataType() As String
        Get
            Return question.DataType
        End Get
        Set(ByVal value As String)
            question.SetDataType(value)
        End Set
    End Property

    ' AbsMin property.
    <CategoryAttribute("Data variable ranges"), _
    DisplayName("Absolute Minimum"), _
    DescriptionAttribute("The minimum value assignable to the variable.")> _
    Public Property AbsMin() As String
        Get
            Return question.AbsoluteMinimum
        End Get
        Set(ByVal value As String)
            question.AbsoluteMinimum = value
        End Set

    End Property

    ' AbsMax Property
    <CategoryAttribute("Data variable ranges"), _
    DisplayName("Absolute Maximum"), _
    DescriptionAttribute("The maximum value assignable to the variable.")> _
    Public Property AbsMax() As String
        Get
            Return question.AbsoluteMaximum
        End Get
        Set(ByVal value As String)
            question.AbsoluteMaximum = value
        End Set
    End Property

    ' PromptUnder property
    <CategoryAttribute("Data variable ranges"), _
    DisplayName("Prompt Under"), _
    DescriptionAttribute("The minimum value that is common, outside of this range the value needs confirmation.")> _
    Public Property PromptUnder() As String
        Get
            Return question.PromptUnder
        End Get
        Set(ByVal value As String)
            question.PromptUnder = value
        End Set

    End Property

    ' PromptOver Property
    <CategoryAttribute("Data variable ranges"), _
    DisplayName("Prompt Over"), _
    DescriptionAttribute("The maximum value that is common, outside of this range the value needs confirmation.")> _
    Public Property PromptOver() As String
        Get
            Return question.PromptOver
        End Get
        Set(ByVal value As String)
            question.PromptOver = value
        End Set
    End Property

    ' Scope Property
    <DisplayName("Variable scope"), _
    DefaultValueAttribute(""), _
    DescriptionAttribute("The scope of the variable."), _
    [ReadOnly](True)> _
    Public Property Scope() As VariableScopes
        Get
            Return question.VariableScope
        End Get
        Set(ByVal value As VariableScopes)
            question.VariableScope = value
        End Set
    End Property

#End Region



#Region "Generic Object properties"

    ' Guid property.
    Public Overrides Property Guid() As Guid
        Get

            Return question.Guid
        End Get
        Set(ByVal value As Guid)

            question.Guid = value
        End Set
    End Property


    ' Name property.
    <BrowsableAttribute(False), _
    CategoryAttribute("(Main)"), _
    DisplayName("Name"), _
    DefaultValueAttribute("New Study"), _
    DescriptionAttribute("Indicates the name of the object."), _
    EditorAttribute(GetType(MultiLanguageEditor), GetType(System.Drawing.Design.UITypeEditor))> _
    Public Shadows Property Name() As String
        Get
            Return ""
        End Get
        Set(ByVal value As String)
        End Set
    End Property


    ' Name Dictionary.
    <BrowsableAttribute(False)> _
    Public Shadows Property NameDictionary() As Dictionary(Of Integer, String)
        Get
            Return question.NameDictionary
        End Get
        Set(ByVal value As Dictionary(Of Integer, String))
            question.NameDictionary = value
        End Set
    End Property


    ' Comment property.
    <CategoryAttribute("(Main)"), _
    DisplayName("Comment"), _
    DefaultValueAttribute(""), _
    DescriptionAttribute("Type a comment of the object.")> _
     Public Shadows Property Comment() As String
        Get

            Return question.Comment
        End Get
        Set(ByVal value As String)

            question.Comment = value
        End Set
    End Property


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


    'DataTableName property.
    <BrowsableAttribute(False)> _
    Public Shadows Property DataTableName() As String
        Get
            Return Nothing
        End Get
        Set(ByVal value As String)

        End Set
    End Property


    'LogTableName property.
    <BrowsableAttribute(False)> _
    Public Shadows Property LogTableName() As String
        Get
            Return Nothing
        End Get
        Set(ByVal value As String)

        End Set
    End Property

#End Region



#Region "Methods"

    Public Sub New(Optional ByVal question As BO.Question = Nothing)

        If question Is Nothing Then
            Me.question = New Question()
        Else
            Me.question = question.Clone
        End If
    End Sub


    Public Overrides Function ToString() As String

        Return Me.VariableName & IIf(String.IsNullOrEmpty(Me.MainText), "", " - " & Me.MainText)

    End Function


    Public Overrides Function Difference(ByVal genericObject As GenericObject) As GenericObject

        ' Check types.
        If Not genericObject.GetType.Equals(GetType(Variable)) Then Return Nothing

        ' Create the object.
        Dim result As New Variable()
        Dim var As Variable = genericObject
        Dim changed As Boolean = False

        ' Generic object properties.
        result.SetGuidWithoutHash(Nothing)

        If Me.Name <> var.Name Then
            result.Name = Me.Name
            changed = True
        Else
            result.Name = Nothing
        End If

        If Me.Comment <> var.Comment Then
            result.Comment = Me.Comment
            changed = True
        Else
            result.Comment = Nothing
        End If

        If Me.DataType <> var.DataType Then
            result.DataType = Me.DataType
            changed = True
        Else
            result.DataType = Nothing
        End If

        If Me.AbsMin <> var.AbsMin Then
            result.AbsMin = Me.AbsMin
            changed = True
        Else
            result.AbsMin = Nothing
        End If

        If Me.AbsMax <> var.AbsMax Then
            result.AbsMax = Me.AbsMax
            changed = True
        Else
            result.AbsMax = Nothing
        End If

        If Me.PromptUnder <> var.PromptUnder Then
            result.PromptUnder = Me.PromptUnder
            changed = True
        Else
            result.PromptUnder = Nothing
        End If

        If Me.PromptOver <> var.PromptOver Then
            result.PromptOver = Me.PromptOver
            changed = True
        Else
            result.PromptOver = Nothing
        End If

        ' Return the value.
        If changed Then Return result Else Return Nothing

    End Function


    Public Function ToQuestion() As BO.Question

        Return Me.question

    End Function


    Public Sub SetVariableScope(ByVal type As Type)

        If type.Equals(GetType(BO.Study)) Then
            'Me.question.VariableScope = VariableScopes.Study

        ElseIf type.Equals(GetType(BO.QuestionnaireSet)) Then
            Me.question.VariableScope = VariableScopes.QuestionnaireSet

        ElseIf type.Equals(GetType(BO.Questionnaire)) Then
            Me.question.VariableScope = VariableScopes.Questionnaire

        ElseIf type.Equals(GetType(BO.Section)) Then
            Me.question.VariableScope = VariableScopes.Section

        End If
    End Sub


    Public Function IsValid() As Boolean Implements ISelfValidate.IsValid

        Dim message As String = ""

        If String.IsNullOrEmpty(Me.VariableName) Then message &= Environment.NewLine & "Variable name is required."
        If String.IsNullOrEmpty(Me.MainText) Then message &= Environment.NewLine & "Main text is required."
        If String.IsNullOrEmpty(Me.DataType) Then message &= Environment.NewLine & "Data type is required."

        If Not String.IsNullOrEmpty(message) Then
            MessageBox.Show("Error list:" & message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Else
            Return True
        End If

    End Function


    Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)

        Me.question = info.GetValue("I001", GetType(BO.Question))

    End Sub


    Public Sub GetObjectData(ByVal info As SerializationInfo, ByVal context As StreamingContext) Implements ISerializable.GetObjectData

        info.AddValue("I001", Me.question)

    End Sub

#End Region

End Class

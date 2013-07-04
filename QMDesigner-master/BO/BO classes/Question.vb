Imports System.ComponentModel
Imports System.Runtime.Serialization

' Enumeration of the VariableScopes.
<Serializable()> _
Public Enum VariableScopes As Integer
    'Study = 1
    QuestionnaireSet = 2
    Questionnaire = 3
    Section = 4
End Enum

<Serializable()> _
Public Class Question
    Inherits SectionItem
    Implements ISerializable, ISelfValidate


#Region "Generic Question Properties"

    Private _variableName As String = ""
    Private _screenTemplate As String = ""
    Private _dataType As String = ""
    Private _visible As Boolean = True
    Private _legalValueTable As String = ""
    Private _scope As VariableScopes
    Private _groupMember As Boolean = False
    Private _groupText As New Dictionary(Of Integer, String)
    Private _oldLegalValue As String = ""

    ' Variable Property.
    <CategoryAttribute("Data Entry"), _
    DisplayName("Variable Name"), _
    DefaultValueAttribute(""), _
    DescriptionAttribute("Variable to save the answer.")> _
    Public Property VariableName() As String
        Get
            Return _variableName
        End Get
        Set(ByVal value As String)

            If String.IsNullOrEmpty(Me._screenTemplate) Then

                Throw New Exception("You need to specify the screen template first.")

            ElseIf BO.Study.ScreenTemplates(Me._screenTemplate).VariableNameRequired AndAlso (String.IsNullOrEmpty(value) OrElse String.IsNullOrEmpty(value.Trim)) Then

                Throw New Exception("The selected screentemplate requires a variable name.")

            Else

                _variableName = BO.GenericObject.CheckIdentifier(value)

            End If

        End Set
    End Property

    ' ScreenTemplate Property.
    <CategoryAttribute("Data Entry"), _
    DisplayName("Screen template"), _
    TypeConverter(GetType(ScreenTemplateEditor)), _
    DefaultValueAttribute(""), _
    DescriptionAttribute("Sets the screen template to be used.")> _
    Public Property ScreenTemplate() As String
        Get
            Return _screenTemplate
        End Get
        Set(ByVal value As String)

            If value IsNot Nothing Then
                _screenTemplate = value.Trim
            Else
                _screenTemplate = Nothing
            End If

            If Not _screenTemplate Is Nothing Then
                Dim tmp As String = _screenTemplate.ToLower
                If tmp <> "dropdown" And tmp <> "radiobuttons" And tmp <> "checkbox" And tmp <> "name" Then
                    Me._oldLegalValue = Me.LegalValueTable
                    Me._legalValueTable = Nothing
                Else
                    Me._legalValueTable = Me._oldLegalValue
                End If
            End If

            ' Set the data type.
            For Each template As BO.ScreenTemplate In BO.Study.ScreenTemplates
                If template.Name = _screenTemplate Then
                    Me._dataType = template.DataType
                    Exit For
                End If
            Next
        End Set
    End Property

    ' DataType Property.
    <CategoryAttribute("Data Entry"), _
    DisplayName("Variable Data Type"), _
    DescriptionAttribute("The variable data type.")> _
    Public ReadOnly Property DataType() As String
        Get
            Return _dataType
        End Get
    End Property

    ' Scope property.
    <CategoryAttribute("Data Entry"), _
    DisplayName("Variable Scope"), _
    DefaultValueAttribute(VariableScopes.Section), _
    DescriptionAttribute("Sets the scope of the variable.")> _
    Public Property VariableScope() As VariableScopes
        Get
            Return _scope
        End Get
        Set(ByVal value As VariableScopes)
            _scope = value
        End Set
    End Property

    ' Visible property.
    <DisplayName("Show Question"), _
    DefaultValue(True), _
    DescriptionAttribute("Shows or hides the question in the questionnaire.")> _
    Public Property Visible() As Boolean
        Get
            Return _visible
        End Get
        Set(ByVal value As Boolean)
            _visible = value
        End Set
    End Property

    ' Legalvalues property.
    <CategoryAttribute("Data Entry"), _
    DisplayName("Legal Value Table"), _
    DescriptionAttribute("Sets the legal values for the question."), _
    TypeConverter(GetType(LegalValuesEditor)), _
    DefaultValue("")> _
    Public Property LegalValueTable() As String
        Get
            Return _legalValueTable
        End Get
        Set(ByVal value As String)
            If value IsNot Nothing Then _legalValueTable = value.Trim Else _legalValueTable = Nothing
            Me._oldLegalValue = _legalValueTable
        End Set
    End Property

    ' Group member property.
    <DisplayName("Group member"), _
    DefaultValue(True), _
    DescriptionAttribute("Is the question member of a group?")> _
    Public Property GroupMember() As Boolean
        Get
            Return _groupMember
        End Get
        Set(ByVal value As Boolean)
            _groupMember = value
        End Set
    End Property

    ' Group text property.
    <DisplayName("Group text"), _
    DefaultValue(""), _
    DescriptionAttribute("Group Text"), _
    EditorAttribute(GetType(MultiLanguageEditor), GetType(System.Drawing.Design.UITypeEditor))> _
    Public Property GroupText() As String
        Get
            If _groupText.ContainsKey(BO.ContextClass.CurrentLanguage.LanguageID) Then
                Return _groupText(BO.ContextClass.CurrentLanguage.LanguageID)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal value As String)
            If value IsNot Nothing Then value = value.Trim
            _groupText.Item(BO.ContextClass.CurrentLanguage.LanguageID) = value
        End Set
    End Property

    ' Group text dictionary property.
    <BrowsableAttribute(False)> _
    Public Property GroupTextDictionary() As Dictionary(Of Integer, String)
        Get
            Return _groupText
        End Get
        Set(ByVal value As Dictionary(Of Integer, String))
            _groupText = value
        End Set
    End Property

#End Region


#Region "PDA setting properties"

    Private _arguments As String = ""
    Private _helpText As New Dictionary(Of Integer, String)
    Private _required As Boolean = True
    Private _confirmChange As Boolean = False
    Private _hideNext As Boolean = False
    Private _hideBack As Boolean = False
    Private _confirmNext As Boolean = False
    Private _confirmBack As Boolean = False

    ' Arguments property.
    <CategoryAttribute("PDA settings"), _
    DisplayName("Screen Arguments"), _
    DefaultValueAttribute(""), _
    DescriptionAttribute("Arguments for the screen template.")> _
    Public Property Arguments() As String
        Get
            Return _arguments
        End Get
        Set(ByVal value As String)
            If value IsNot Nothing Then
                _arguments = value.Trim
            Else
                _arguments = Nothing
            End If
        End Set
    End Property

    ' Help Text property.
    <CategoryAttribute("PDA settings"), _
    DisplayName("Help Text"), _
    DefaultValueAttribute(""), _
    DescriptionAttribute("Help Text."), _
    EditorAttribute(GetType(MultiLanguageEditor), GetType(System.Drawing.Design.UITypeEditor))> _
    Public Property HelpText() As String
        Get
            If _helpText.ContainsKey(BO.ContextClass.CurrentLanguage.LanguageID) Then
                Return _helpText(BO.ContextClass.CurrentLanguage.LanguageID)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal value As String)
            If value IsNot Nothing Then value = value.Trim
            _helpText.Item(BO.ContextClass.CurrentLanguage.LanguageID) = value
        End Set
    End Property

    ' Help text dictionary property.
    <BrowsableAttribute(False)> _
    Public Property HelpTextDictionary() As Dictionary(Of Integer, String)
        Get
            Return _helpText
        End Get
        Set(ByVal value As Dictionary(Of Integer, String))
            _helpText = value
        End Set
    End Property

    ' Required Property.
    <CategoryAttribute("PDA settings"), _
    DisplayName("Answer Required"), _
    DefaultValueAttribute(True), _
    DescriptionAttribute("True if the user can't pass this question without an answer.")> _
    Public Property Required() As Boolean
        Get
            Return _required
        End Get
        Set(ByVal value As Boolean)
            _required = value
        End Set
    End Property

    ' ConfirmChange Property.
    <CategoryAttribute("PDA settings"), _
    DisplayName("Confirm Change"), _
    DefaultValueAttribute(False), _
    DescriptionAttribute("True if ask for confirmation when the answer is changed.")> _
    Public Property ConfirmChange() As Boolean
        Get
            Return _confirmChange
        End Get
        Set(ByVal value As Boolean)
            _confirmChange = value
        End Set
    End Property

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

    ' ConfirmNext Property.
    <CategoryAttribute("PDA settings"), _
    DisplayName("Confirm Next"), _
    DefaultValueAttribute(False), _
    DescriptionAttribute("True if ask for confirmation before the shift to the next question.")> _
    Public Property ConfirmNext() As Boolean
        Get
            Return _confirmNext
        End Get
        Set(ByVal value As Boolean)
            _confirmNext = value
        End Set
    End Property

    ' ConfirmBack Property.
    <CategoryAttribute("PDA settings"), _
    DisplayName("Confirm Back"), _
    DefaultValueAttribute(False), _
    DescriptionAttribute("True if ask for confirmation before the shift to the previous question.")> _
    Public Property ConfirmBack() As Boolean
        Get
            Return _confirmBack
        End Get
        Set(ByVal value As Boolean)
            _confirmBack = value
        End Set
    End Property

#End Region


#Region "Data range validation properties"

    Private _absMin As String = ""
    Private _promptUnder As String = ""
    Private _promptOver As String = ""
    Private _absMax As String = ""

    ' AbsoluteMinimum Property.
    <CategoryAttribute("Data variable ranges"), _
    DisplayName("Absolute Minimum"), _
    DescriptionAttribute("The minimum value assignable to the variable.")> _
    Public Property AbsoluteMinimum() As String
        Get
            Return _absMin
        End Get
        Set(ByVal value As String)
            If value IsNot Nothing Then
                _absMin = value.Trim
            Else
                _absMin = Nothing
            End If
        End Set
    End Property

    ' PromptUnder Property.
    <CategoryAttribute("Data variable ranges"), _
    DisplayName("Prompt Under"), _
    DescriptionAttribute("The minimum value that is common, outside of this range the value needs confirmation.")> _
    Public Property PromptUnder() As String
        Get
            Return _promptUnder
        End Get
        Set(ByVal value As String)
            If value IsNot Nothing Then
                _promptUnder = value.Trim
            Else
                _promptUnder = Nothing
            End If
        End Set
    End Property

    ' PromptOver Property.
    <CategoryAttribute("Data variable ranges"), _
    DisplayName("Prompt Over"), _
    DescriptionAttribute("The maximum value that is common, outside of this range the value needs confirmation.")> _
    Public Property PromptOver() As String
        Get
            Return _promptOver
        End Get
        Set(ByVal value As String)
            If value IsNot Nothing Then
                _promptOver = value.Trim
            Else
                _promptOver = Nothing
            End If
        End Set
    End Property

    ' AbsoluteMaximum Property.
    <CategoryAttribute("Data variable ranges"), _
    DisplayName("Absolute Maximum"), _
    DescriptionAttribute("The maximum value assignable to the variable.")> _
    Public Property AbsoluteMaximum() As String
        Get
            Return _absMax
        End Get
        Set(ByVal value As String)
            If value IsNot Nothing Then
                _absMax = value.Trim
            Else
                _absMax = Nothing
            End If
        End Set
    End Property

#End Region


#Region "PDA action properties"

    Private _customValidation As String = ""
    Private _customValidationFailMessage As New Dictionary(Of Integer, String)
    Private _onChange As String
    Private _onLoad As String
    Private _onUnload As String

    ' ExternalValidation Property.
    <CategoryAttribute("PDA Actions"), _
    DisplayName("Custom Validation"), _
    DescriptionAttribute("Set the action for a more complex validation."), _
    EditorAttribute(GetType(CodeEditor), GetType(System.Drawing.Design.UITypeEditor))> _
    Public Property CustomValidation() As String
        Get
            Return _customValidation
        End Get
        Set(ByVal value As String)
            If value IsNot Nothing Then
                _customValidation = value.Trim
            Else
                _customValidation = Nothing
            End If
        End Set
    End Property

    ' ExternalValidationFailMessage Property.
    <CategoryAttribute("PDA Actions"), _
    DisplayName("Custom Fail Message"), _
    DescriptionAttribute("Custom error message to show when the custom validation fails."), _
    EditorAttribute(GetType(MultiLanguageEditor), GetType(System.Drawing.Design.UITypeEditor))> _
    Public Property CustomValidationFailMessage() As String
        Get
            If _customValidationFailMessage.ContainsKey(BO.ContextClass.CurrentLanguage.LanguageID) Then
                Return _customValidationFailMessage(BO.ContextClass.CurrentLanguage.LanguageID)
            Else
                Return ""
            End If
        End Get
        Set(ByVal value As String)
            If value IsNot Nothing Then value = value.Trim
            _customValidationFailMessage.Item(BO.ContextClass.CurrentLanguage.LanguageID) = value
        End Set
    End Property


    ' Main Text Dictionary Property.
    <Browsable(False)> _
    Public Property CustomValidationFailMessageDictionary() As Dictionary(Of Integer, String)
        Get
            Return _customValidationFailMessage
        End Get
        Set(ByVal value As Dictionary(Of Integer, String))
            _customValidationFailMessage = value
        End Set
    End Property


    ' OnChange Property
    <CategoryAttribute("PDA Actions"), _
    DisplayName("On Change"), _
    DescriptionAttribute("Set the list of actions when the question changes."), _
    EditorAttribute(GetType(CodeEditor), GetType(System.Drawing.Design.UITypeEditor))> _
    Public Property OnChange() As String
        Get
            Return _onChange
        End Get
        Set(ByVal value As String)
            _onChange = value
        End Set
    End Property

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

    ' Sets the parent section.
    Public Sub New()

        Me.VariableScope = BO.VariableScopes.Section
    End Sub

    ' Finds the diferences between two checkpoints.
    Public Overrides Function Difference(ByVal genericObject As GenericObject) As GenericObject

        ' Check types.
        If Not genericObject.GetType.Equals(GetType(Question)) Then Return Nothing

        ' Create the object.
        Dim result As New Question()
        Dim question As Question = genericObject
        Dim changed As Boolean = False

        ' Generic object properties.
        result.SetGuidWithoutHash(Me.Guid)

        If Me.Name <> question.Name Then
            result.Name = Me.Name
            changed = True
        Else
            result.Name = Nothing
        End If

        If Me.Comment <> question.Comment Then
            result.Comment = Me.Comment
            changed = True
        Else
            result.Comment = Nothing
        End If

        result.DataBaseID = Nothing

        ' Phase properties.
        If Me.MainText <> question.MainText Then
            result.MainText = Me.MainText
            changed = True
        Else
            result.MainText = Nothing
        End If

        If Me.Parent IsNot Nothing AndAlso question.Parent IsNot Nothing AndAlso Me.Parent.Guid <> question.Parent.Guid Then
            result.SetParent(Me.Parent)
            changed = True
        End If

        If Me.Number <> question.Number Then
            result.Number = Me.Number
            changed = True
        Else
            result.Number = Nothing
        End If

        ' Generic question properties.
        If Me.VariableName <> question.VariableName Then
            result.SetVariableName(Me.VariableName)
            changed = True
        Else
            result.SetVariableName(Nothing)
        End If

        If Me.ScreenTemplate <> question.ScreenTemplate Then
            result.ScreenTemplate = Me.ScreenTemplate
            changed = True
        Else
            result.ScreenTemplate = Nothing
        End If

        If Me.Visible <> question.Visible Then
            result.Visible = Me.Visible
            changed = True
        Else
            result.Visible = Nothing
        End If

        If Me.LegalValueTable <> question.LegalValueTable Then
            result.LegalValueTable = Me.LegalValueTable
            changed = True
        Else
            result.LegalValueTable = Nothing
        End If

        If Me.VariableScope <> question.VariableScope Then
            result.VariableScope = Me.VariableScope
            changed = True
        Else
            result.VariableScope = Nothing
        End If

        If Me.GroupMember <> question.GroupMember Then
            result.GroupMember = Me.GroupMember
            changed = True
        Else
            result.GroupMember = Nothing
        End If

        If Me.GroupText <> question.GroupText Then
            result.GroupText = Me.GroupText
            changed = True
        Else
            result.GroupText = Nothing
        End If

        ' PDA question settings properties.
        If Me.Arguments <> question.Arguments Then
            result.Arguments = Me.Arguments
            changed = True
        Else
            result.Arguments = Nothing
        End If

        If Me.HelpText <> question.HelpText Then
            result.HelpText = Me.HelpText
            changed = True
        Else
            result.HelpText = Nothing
        End If

        If Me.Required <> question.Required Then
            result.Required = Me.Required
            changed = True
        Else
            result.Required = Nothing
        End If

        If Me.ConfirmChange <> question.ConfirmChange Then
            result.ConfirmChange = Me.ConfirmChange
            changed = True
        Else
            result.ConfirmChange = Nothing
        End If

        If Me.HideNext <> question.HideNext Then
            result.HideNext = Me.HideNext
            changed = True
        Else
            result.HideNext = Nothing
        End If

        If Me.HideBack <> question.HideBack Then
            result.HideBack = Me.HideBack
            changed = True
        Else
            result.HideBack = Nothing
        End If

        If Me.ConfirmNext <> question.ConfirmNext Then
            result.ConfirmNext = Me.ConfirmNext
            changed = True
        Else
            result.ConfirmNext = Nothing
        End If

        If Me.ConfirmBack <> question.ConfirmBack Then
            result.ConfirmBack = Me.ConfirmBack
            changed = True
        Else
            result.ConfirmBack = Nothing
        End If

        ' Data range validations question properties.
        If Me.AbsoluteMinimum <> question.AbsoluteMinimum Then
            result.AbsoluteMinimum = Me.AbsoluteMinimum
            changed = True
        Else
            result.AbsoluteMinimum = Nothing
        End If

        If Me.PromptUnder <> question.PromptUnder Then
            result.PromptUnder = Me.PromptUnder
            changed = True
        Else
            result.PromptUnder = Nothing
        End If

        If Me.PromptOver <> question.PromptOver Then
            result.PromptOver = Me.PromptOver
            changed = True
        Else
            result.PromptOver = Nothing
        End If

        If Me.AbsoluteMaximum <> question.AbsoluteMaximum Then
            result.AbsoluteMaximum = Me.AbsoluteMaximum
            changed = True
        Else
            result.AbsoluteMaximum = Nothing
        End If

        ' PDA actions question properties.
        If Me.CustomValidation <> question.CustomValidation Then
            result.CustomValidation = Me.CustomValidation
            changed = True
        Else
            result.CustomValidation = Nothing
        End If

        result.OnChange = Nothing
        result.OnLoad = Nothing
        result.OnUnload = Nothing

        ' Return the value.
        If changed Then Return result Else Return Nothing
    End Function

    ' Assign a variableName without validations.
    Public Sub SetVariableName(ByVal name As String)

        Me._variableName = name
    End Sub

    ' Sets the datatype property.
    Public Sub SetDataType(ByVal dataType As String)
        Me._dataType = dataType
    End Sub


    ' Validates the questionnaireset.
    Public Function IsValid() As Boolean Implements ISelfValidate.IsValid

        Dim message As String = ""

        If String.IsNullOrEmpty(Me.MainText) Then message &= Environment.NewLine & "Main text is required."
        If String.IsNullOrEmpty(Me.ScreenTemplate) Then
            message &= Environment.NewLine & "Screen template is required."
        ElseIf BO.Study.ScreenTemplates(Me.ScreenTemplate).VariableNameRequired AndAlso String.IsNullOrEmpty(Me.VariableName) Then
            message &= Environment.NewLine & "A valid variable name is required."
        End If
        If "DropDown|RadioButtons|CheckBox|name".Contains(Me.ScreenTemplate) AndAlso String.IsNullOrEmpty(Me.LegalValueTable) Then message &= Environment.NewLine & "A legal value table name is required."
        If String.IsNullOrEmpty(Me.DataType) Then message &= Environment.NewLine & "Data type is required."
        If Me.GroupMember AndAlso String.IsNullOrEmpty(Me.GroupText) Then message &= Environment.NewLine & "If group member, group text is required."

        If Not String.IsNullOrEmpty(message) Then
            MessageBox.Show("Error list:" & message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Else
            Return True
        End If

    End Function


    ''' <summary>
    ''' Constructor for deserialization.
    ''' </summary>
    ''' <param name="info">Serialized object.</param>
    ''' <param name="context"></param>
    ''' <remarks></remarks>

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

        ' Question properties.
        Me._variableName = info.GetValue("Q001", GetType(String))
        Me._screenTemplate = info.GetValue("Q002", GetType(String))
        Me._dataType = info.GetValue("Q003", GetType(String))
        Me._visible = info.GetValue("Q004", GetType(Boolean))
        Me._legalValueTable = info.GetValue("Q005", GetType(String))
        Me._scope = info.GetValue("Q006", GetType(Integer))
        Me._groupMember = info.GetValue("Q007", GetType(Boolean))
        Me._groupText = info.GetValue("Q008", GetType(Dictionary(Of Integer, String)))
        Me._oldLegalValue = info.GetValue("Q009", GetType(String))
        Me._arguments = info.GetValue("Q010", GetType(String))
        Me._helpText = info.GetValue("Q011", GetType(Dictionary(Of Integer, String)))
        Me._required = info.GetValue("Q012", GetType(Boolean))
        Me._confirmChange = info.GetValue("Q013", GetType(Boolean))
        Me._hideNext = info.GetValue("Q014", GetType(Boolean))
        Me._hideBack = info.GetValue("Q015", GetType(Boolean))
        Me._confirmNext = info.GetValue("Q016", GetType(Boolean))
        Me._confirmBack = info.GetValue("Q017", GetType(Boolean))
        Me._absMin = info.GetValue("Q018", GetType(String))
        Me._promptUnder = info.GetValue("Q019", GetType(String))
        Me._promptOver = info.GetValue("Q020", GetType(String))
        Me._absMax = info.GetValue("Q021", GetType(String))
        Me._customValidation = info.GetValue("Q022", GetType(String))
        Me._onChange = info.GetValue("Q023", GetType(String))
        Me._onLoad = info.GetValue("Q024", GetType(String))
        Me._onUnload = info.GetValue("Q025", GetType(String))
        Me._customValidationFailMessage = info.GetValue("Q026", GetType(Dictionary(Of Integer, String)))
    End Sub


    ''' <summary>
    ''' Custom serialization method.
    ''' </summary>
    ''' <param name="info"></param>
    ''' <param name="context"></param>
    ''' <remarks></remarks>

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

        ' Question properties.
        info.AddValue("Q001", Me._variableName)
        info.AddValue("Q002", Me._screenTemplate)
        info.AddValue("Q003", Me._dataType)
        info.AddValue("Q004", Me._visible)
        info.AddValue("Q005", Me._legalValueTable)
        info.AddValue("Q006", Me._scope)
        info.AddValue("Q007", Me._groupMember)
        info.AddValue("Q008", Me._groupText)
        info.AddValue("Q009", Me._oldLegalValue)
        info.AddValue("Q010", Me._arguments)
        info.AddValue("Q011", Me._helpText)
        info.AddValue("Q012", Me._required)
        info.AddValue("Q013", Me._confirmChange)
        info.AddValue("Q014", Me._hideNext)
        info.AddValue("Q015", Me._hideBack)
        info.AddValue("Q016", Me._confirmNext)
        info.AddValue("Q017", Me._confirmBack)
        info.AddValue("Q018", Me._absMin)
        info.AddValue("Q019", Me._promptUnder)
        info.AddValue("Q020", Me._promptOver)
        info.AddValue("Q021", Me._absMax)
        info.AddValue("Q022", Me._customValidation)
        info.AddValue("Q023", Me._onChange)
        info.AddValue("Q024", Me._onLoad)
        info.AddValue("Q025", Me._onUnload)
        info.AddValue("Q026", Me._customValidationFailMessage)

    End Sub

#End Region

End Class

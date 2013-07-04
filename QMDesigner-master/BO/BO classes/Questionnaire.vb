Imports System.Runtime.Serialization
Imports System.ComponentModel

<Serializable()> _
Public Class Questionnaire
    Inherits GenericObject
    Implements ISerializable, ISelfValidate


#Region "Shared Properties"

    Public Shared MaxDataBaseID = 0

#End Region



#Region "Generic Questionnaire Properties"

    Private _shortName As String = ""
    Private _continuousNumeration As Boolean = True

    ' Short Name Property.
    <CategoryAttribute("(Main)"), _
    DefaultValueAttribute(""), _
    DisplayName("Short Name"), _
    DescriptionAttribute("Indicates the short name of the questionnaire.")> _
    Public Property ShortName() As String
        Get
            Return _shortName
        End Get
        Set(ByVal value As String)

            _shortName = BO.GenericObject.CheckIdentifier(value)

        End Set
    End Property

    ' QuestionnaireNumeration property.
    <DefaultValueAttribute(True), _
    DisplayName("Continuous Numeration"), _
    DescriptionAttribute("True if the number of the questions continues from section to section.")> _
    Public Property ContinuousNumeration() As Boolean
        Get
            Return _continuousNumeration
        End Get
        Set(ByVal value As Boolean)
            _continuousNumeration = value
        End Set
    End Property

    ' QuestionnaireSetID property.
    <[ReadOnly](True), _
    CategoryAttribute("System Information")> _
    Public ReadOnly Property QuestionnaireSetID() As Integer
        Get
            If Me.Parent IsNot Nothing Then
                Return Me.Parent.DataBaseID
            Else
                Return "N/A"
            End If
        End Get
    End Property

    ' QuestionnaireID property.
    <[ReadOnly](True), _
        CategoryAttribute("System Information")> _
        Public ReadOnly Property QuestionnaireID() As Integer
        Get
            Return Me.DataBaseID
        End Get
    End Property

#End Region



#Region "Multiple instances properties"

    Private _multipleInstances As Boolean = False
    Private _instanceSAIDField As String
    Private _instanceSecondaryIDField As String
    Private _onNewRecord As String = Nothing

    ' Multiple Instances property.
    <CategoryAttribute("Multiple Instances"), _
    DisplayName("Multiple Instances"), _
    DescriptionAttribute("True if the questionnaire can be answered multiple times by one subject.")> _
    Public Property MultipleInstances() As Boolean
        Get
            Return _multipleInstances
        End Get
        Set(ByVal value As Boolean)
            _multipleInstances = value
        End Set
    End Property

    ' InstanceSAIDField property.
    <CategoryAttribute("Multiple Instances"), _
    DefaultValueAttribute(""), _
    DisplayName("InstanceSAIDField"), _
    DescriptionAttribute("Sets/Gets the InstanceSAIDField.")> _
    Public Property InstanceSAIDField() As String
        Get
            Return _instanceSAIDField
        End Get
        Set(ByVal value As String)
            If value IsNot Nothing Then
                _instanceSAIDField = value.Trim
            Else
                _instanceSAIDField = Nothing
            End If
        End Set
    End Property

    ' InstanceSecondaryIDField property.
    <CategoryAttribute("Multiple Instances"), _
    DefaultValueAttribute(""), _
    DisplayName("Instance Secondary IDField"), _
    DescriptionAttribute("Sets/Gets the InstanceSecondaryIDField.")> _
    Public Property InstanceSecondaryIDField() As String
        Get
            Return _instanceSecondaryIDField
        End Get
        Set(ByVal value As String)
            If value IsNot Nothing Then
                _instanceSecondaryIDField = value.Trim
            Else
                _instanceSecondaryIDField = Nothing
            End If
        End Set
    End Property

    ' OnNewRecordProcedureID property.
    <CategoryAttribute("Multiple Instances"), _
    DefaultValueAttribute(""), _
    DisplayName("On New Reord Procedure ID"), _
    DescriptionAttribute("Sets/Gets the OnNewReordProcedureID.")> _
    Public Property OnNewRecord() As String
        Get
            Return _onNewRecord
        End Get
        Set(ByVal value As String)
            _onNewRecord = value
        End Set
    End Property

#End Region



#Region "PDA settings properties"

    Private _preCondition As String = ""

    ' Precondition property.
    <CategoryAttribute("PDA settings"), _
    DisplayName("Precondition"), _
    DescriptionAttribute("Sets the condition to set the questionnaire avialible or not."), _
    EditorAttribute(GetType(CodeEditor), GetType(System.Drawing.Design.UITypeEditor))> _
    Public Property PreCondition() As String
        Get
            Return _preCondition
        End Get
        Set(ByVal value As String)
            If value IsNot Nothing Then
                _preCondition = value.Trim
            Else
                _preCondition = Nothing
            End If
        End Set
    End Property

#End Region



#Region "Child properties"

    Private _Sections As New List(Of Section)
    Private _variables As New List(Of Variable)

    ' Sections Property.
    <BrowsableAttribute(False)> _
    Public ReadOnly Property Sections() As List(Of Section)
        Get
            Return _Sections
        End Get
    End Property

    ' Sections Property.
    <BrowsableAttribute(False)> _
    Public ReadOnly Property Section(ByVal index As Integer) As Section
        Get
            Return _Sections(index)
        End Get
    End Property

    ' Variables property.
    <BrowsableAttribute(False)> _
    Public Overrides Property Variables() As List(Of BO.Variable)
        Get
            Return _variables
        End Get
        Set(ByVal value As List(Of BO.Variable))
            _variables = value
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
            Return True
        End Get
    End Property

#End Region



#Region "Methods"

    ' Constructor.
    Public Sub New(Optional ByVal id As Integer = 0)

        ' if id is not valid, assign a new one.
        Me.DataBaseID = IIf(id > 0, id, MaxDataBaseID + 1)
        MaxDataBaseID = IIf(DataBaseID > MaxDataBaseID, DataBaseID, MaxDataBaseID)

        ' Set name.
        Me.Name = "Questionnaire " & Me.DataBaseID

    End Sub

    ' ToString.
    Public Overrides Function ToString() As String
        Return Me.Name
    End Function


    ' Finds the diferences between two questionnaires.
    Public Overrides Function Difference(ByVal genericObject As GenericObject) As GenericObject

        ' Check types.
        If Not genericObject.GetType.Equals(GetType(Questionnaire)) Then Return Nothing

        ' Create the object.
        Dim result As New Questionnaire(0)
        Dim questionnaire As Questionnaire = genericObject
        Dim changed As Boolean = False

        ' Generic object properties.
        result.SetGuidWithoutHash(Nothing)

        If Me.Name <> questionnaire.Name Then
            result.Name = Me.Name
            changed = True
        Else
            result.Name = Nothing
        End If

        If Me.Comment <> questionnaire.Comment Then
            result.Comment = Me.Comment
            changed = True
        Else
            result.Comment = Nothing
        End If

        result.DataBaseID = Nothing

        ' Questionnaire properties.
        If Me.ShortName <> questionnaire.ShortName Then
            result.ShortName = Me.ShortName
            changed = True
        Else
            result.ShortName = Nothing
        End If

        If Me.ContinuousNumeration <> questionnaire.ContinuousNumeration Then
            result.ContinuousNumeration = Me.ContinuousNumeration
            changed = True
        Else
            result.ContinuousNumeration = Nothing
        End If

        If Me.PreCondition <> questionnaire.PreCondition Then
            result.PreCondition = Me.PreCondition
            changed = True
        Else
            result.PreCondition = Nothing
        End If

        result._Sections = Nothing

        ' Return the value.
        If changed Then Return result Else Return Nothing
    End Function


    ' Validates the questionnaireset.
    Public Function IsValid() As Boolean Implements ISelfValidate.IsValid

        Dim message As String = ""

        If String.IsNullOrEmpty(Me.Name) Then message &= Environment.NewLine & "A valid name required."
        If String.IsNullOrEmpty(Me.ShortName) Then message &= Environment.NewLine & "A valid short name required."

        If Not String.IsNullOrEmpty(message) Then
            MessageBox.Show("Error list:" & message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Else
            Return True
        End If

    End Function


    Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)

        ' Generic object properties.
        Me._guid = info.GetValue("GO001", GetType(Guid))
        Me._name = info.GetValue("GO002", GetType(Dictionary(Of Integer, String)))
        Me._comment = info.GetValue("GO003", GetType(String))
        Me._dataBaseID = info.GetValue("GO004", GetType(Integer))
        Me._dataTableName = info.GetValue("GO005", GetType(String))
        Me._logTableName = info.GetValue("GO006", GetType(String))

        ' Questionnaire properties.
        Me._shortName = info.GetValue("QU001", GetType(String))
        Me._continuousNumeration = info.GetValue("QU002", GetType(Boolean))
        Me._multipleInstances = info.GetValue("QU003", GetType(Boolean))
        Me._instanceSAIDField = info.GetValue("QU004", GetType(String))
        Me._instanceSecondaryIDField = info.GetValue("QU005", GetType(String))
        Me._onNewRecord = info.GetValue("QU006", GetType(String))
        Me._preCondition = info.GetValue("QU007", GetType(String))
        Me._Sections = info.GetValue("QU008", GetType(List(Of Section)))
        Me._variables = info.GetValue("QU009", GetType(List(Of Variable)))

    End Sub


    Public Sub GetObjectData(ByVal info As SerializationInfo, ByVal context As StreamingContext) Implements ISerializable.GetObjectData

        ' Generic object properties.
        info.AddValue("GO001", Me._guid)
        info.AddValue("GO002", Me._name)
        info.AddValue("GO003", Me._comment)
        info.AddValue("GO004", Me._dataBaseID)
        info.AddValue("GO005", Me._dataTableName)
        info.AddValue("GO006", Me._logTableName)

        ' Questionnaire properties.
        info.AddValue("QU001", Me._shortName)
        info.AddValue("QU002", Me._continuousNumeration)
        info.AddValue("QU003", Me._multipleInstances)
        info.AddValue("QU004", Me._instanceSAIDField)
        info.AddValue("QU005", Me._instanceSecondaryIDField)
        info.AddValue("QU006", Me._onNewRecord)
        info.AddValue("QU007", Me._preCondition)

        ' If not recursive then serialize empty lists.
        If ContextClass.RecursiveSerialization Then

            info.AddValue("QU008", Me._Sections)
            info.AddValue("QU009", Me._variables)

        Else

            info.AddValue("QU008", New List(Of Section))
            info.AddValue("QU009", New List(Of Variable))

        End If

    End Sub

#End Region


End Class

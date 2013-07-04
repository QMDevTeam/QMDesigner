Imports System.Runtime.Serialization
Imports System.ComponentModel

<Serializable()> _
Public Class QuestionnaireSet
    Inherits GenericObject
    Implements ISerializable, ISelfValidate

#Region "Shared properties"

    Public Shared MaxDatabaseID = 0

#End Region


#Region "Generic QuestionnaireSet properties"

    Private _shortName As String = ""

    ' Short name.
    <CategoryAttribute("(Main)"), _
    DisplayName("Short name"), _
    DefaultValueAttribute("QS"), _
    DescriptionAttribute("Indicates the short name of the study.")> _
    Public Property ShortName() As String
        Get
            Return _shortName
        End Get
        Set(ByVal value As String)
            _shortName = BO.GenericObject.CheckIdentifier(value)
        End Set
    End Property

    ' QuestionnaireSetID.
    <[ReadOnly](True), _
        CategoryAttribute("System Information")> _
        Public ReadOnly Property QuestionnaireSetID() As Integer
        Get
            Return Me.DataBaseID
        End Get
    End Property

#End Region


#Region "PDA Settings properties"

    Private _precondition As String = ""
    Private _subjectSecondaryIdField As String = ""
    Private _subjectAlternativeSearchField As String = ""
    Private _subjectConfirmationFields As String = ""
    Private _newSubjectSectionID As Nullable(Of Integer) = Nothing
    Private _onNewSubject As String = Nothing

    <CategoryAttribute("(Main)"), _
    DisplayName("Precondition"), _
    DescriptionAttribute("Indicates the precondition for this questionnaire set."), _
    EditorAttribute(GetType(CodeEditor), GetType(System.Drawing.Design.UITypeEditor))> _
    Public Property PreCondition() As String
        Get
            Return _precondition
        End Get
        Set(ByVal value As String)
            If value IsNot Nothing Then
                _precondition = value.Trim
            Else
                _precondition = Nothing
            End If
        End Set
    End Property

    ' SubjectSecondaryIdField.
    <CategoryAttribute("PDA settings"), _
    DisplayName("SubjectSecondaryIdField"), _
    DescriptionAttribute("Alternative subject identification.")> _
    Public Property SubjectSecondaryIdField() As String
        Get
            Return _subjectSecondaryIdField
        End Get
        Set(ByVal value As String)
            If value IsNot Nothing Then
                _subjectSecondaryIdField = value.Trim
            Else
                _subjectSecondaryIdField = Nothing
            End If
        End Set
    End Property

    ' Subject Secondary Id Field Property.
    <CategoryAttribute("PDA settings"), _
    DisplayName("SubjectAlternativeSearchField"), _
    DescriptionAttribute("Alternative subject search field.")> _
    Public Property SubjectAlternativeSearchField() As String
        Get
            Return _subjectAlternativeSearchField
        End Get
        Set(ByVal value As String)
            If value IsNot Nothing Then
                _subjectAlternativeSearchField = value.Trim
            Else
                _subjectAlternativeSearchField = Nothing
            End If
        End Set
    End Property

    ' Subject confirmation fields property.
    <CategoryAttribute("PDA settings"), _
    DisplayName("SubjectConfirmationFields"), _
    DescriptionAttribute("Subject Confirmation Fields.")> _
    Public Property SubjectConfirmationFields() As String
        Get
            Return _subjectConfirmationFields
        End Get
        Set(ByVal value As String)
            If value IsNot Nothing Then
                _subjectConfirmationFields = value.Trim
            Else
                _subjectConfirmationFields = Nothing
            End If
        End Set
    End Property

    ' New subject section id property.
    <CategoryAttribute("PDA settings"), _
    DisplayName("NewSubjectSectionID"), _
    DescriptionAttribute("New Subject section ID.")> _
    Public Property NewSubjectSectionID() As Nullable(Of Integer)
        Get
            Return _newSubjectSectionID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            _newSubjectSectionID = value
        End Set
    End Property

    ' OnNewSubjectProcedureID property.
    <CategoryAttribute("PDA settings"), _
    DisplayName("On New Subject"), _
    DescriptionAttribute("Code to execute when a new subject record is created.")> _
    Public Property OnNewSubject() As String
        Get
            Return _onNewSubject
        End Get
        Set(ByVal value As String)
            _onNewSubject = value
        End Set
    End Property

#End Region


#Region "Child properties"

    Private _questionnaires As New List(Of Questionnaire)
    Private _variables As New List(Of Variable)

    ' Questionnaries Property.
    <BrowsableAttribute(False)> _
    Public ReadOnly Property Questionnaires() As List(Of Questionnaire)
        Get
            Return _questionnaires
        End Get
    End Property

    ' Questionnaries Property.
    <BrowsableAttribute(False)> _
    Public ReadOnly Property Questionnaire(ByVal index As Integer) As Questionnaire
        Get
            Return _questionnaires(index)
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
        Me.DataBaseID = IIf(id > 0, id, MaxDatabaseID + 1)
        MaxDatabaseID = IIf(DataBaseID > MaxDatabaseID, DataBaseID, MaxDatabaseID)

        ' Set name.
        Me.Name = "QuestionnaireSet " & Me.DataBaseID

        ' Set table names.
        Me._dataTableName = Me.PDADataTableName
        Me._logTableName = "log_" & Me.DataTableName

    End Sub

    ' ToString.
    Public Overrides Function ToString() As String
        Return Me.Name
    End Function

    ' Finds the diferences between two Questionnaire sets.
    Public Overrides Function Difference(ByVal genericObject As GenericObject) As GenericObject

        ' Check types.
        If Not genericObject.GetType.Equals(GetType(QuestionnaireSet)) Then Return Nothing

        ' Create the object.
        Dim result As New QuestionnaireSet(Nothing)
        Dim questionnaireSet As QuestionnaireSet = genericObject
        Dim changed As Boolean = False

        ' Generic object properties.
        result.SetGuidWithoutHash(Nothing)

        If Me.Name <> questionnaireSet.Name Then
            result.Name = Me.Name
            changed = True
        Else
            result.Name = Nothing
        End If

        If Me.Comment <> questionnaireSet.Comment Then
            result.Comment = Me.Comment
            changed = True
        Else
            result.Comment = Nothing
        End If

        result.DataBaseID = Nothing

        ' Questionnaire set properties.
        If Me.ShortName <> questionnaireSet.ShortName Then
            result.ShortName = Me.ShortName
            changed = True
        Else
            result.ShortName = Nothing
        End If

        If Me.PreCondition <> questionnaireSet.PreCondition Then
            result.PreCondition = Me.PreCondition
            changed = True
        Else
            result.PreCondition = Nothing
        End If

        If Me.SubjectSecondaryIdField <> questionnaireSet.SubjectSecondaryIdField Then
            result.SubjectSecondaryIdField = Me.SubjectSecondaryIdField
            changed = True
        Else
            result.SubjectSecondaryIdField = Nothing
        End If

        If Me.SubjectAlternativeSearchField <> questionnaireSet.SubjectAlternativeSearchField Then
            result.SubjectAlternativeSearchField = Me.SubjectAlternativeSearchField
            changed = True
        Else
            result.SubjectAlternativeSearchField = Nothing
        End If

        If Me.SubjectConfirmationFields <> questionnaireSet.SubjectConfirmationFields Then
            result.SubjectConfirmationFields = Me.SubjectConfirmationFields
            changed = True
        Else
            result.SubjectConfirmationFields = Nothing
        End If

        If Not Me.NewSubjectSectionID.Equals(questionnaireSet.NewSubjectSectionID) Then
            result.NewSubjectSectionID = Me.NewSubjectSectionID
            changed = True
        Else
            result.NewSubjectSectionID = Nothing
        End If

        If Not Me.OnNewSubject.Equals(questionnaireSet.OnNewSubject) Then
            result.OnNewSubject = Me.OnNewSubject
            changed = True
        End If

        result._questionnaires = Nothing

        ' Return the value.
        If changed Then Return result Else Return Nothing
    End Function

    ' Validates the questionnaireset.
    Public Function IsValid() As Boolean Implements ISelfValidate.IsValid

        Dim message As String = ""

        If String.IsNullOrEmpty(Me.Name) Then message &= Environment.NewLine & "A valid name required."
        If String.IsNullOrEmpty(Me.ShortName) Then message &= Environment.NewLine & "A valid short name required."
        If Not String.IsNullOrEmpty(Me.SubjectAlternativeSearchField) AndAlso Not Me.HasVariableByName(Me.SubjectAlternativeSearchField) Then message &= Environment.NewLine & "Invalid Subject Alternative Search Field."
        If Not String.IsNullOrEmpty(Me.SubjectSecondaryIdField) AndAlso Not Me.HasVariableByName(Me.SubjectSecondaryIdField) Then message &= Environment.NewLine & "Invalid Subject Secondary ID Field."
        If Not String.IsNullOrEmpty(Me.SubjectConfirmationFields) Then

            For Each field As String In Me.SubjectConfirmationFields.Split(",")

                If Not Me.HasVariableByName(field.Trim) Then message &= Environment.NewLine & String.Format("Invalid Subject confirmation fields [{0}].", field.Trim)

            Next

        End If

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

        ' Questionnaireset properties.
        Me._shortName = info.GetValue("QS001", GetType(String))
        Me._precondition = info.GetValue("QS002", GetType(String))
        Me._subjectSecondaryIdField = info.GetValue("QS003", GetType(String))
        Me._subjectAlternativeSearchField = info.GetValue("QS004", GetType(String))
        Me._subjectConfirmationFields = info.GetValue("QS005", GetType(String))
        Me._newSubjectSectionID = info.GetValue("QS006", GetType(Nullable(Of Integer)))
        Me._onNewSubject = info.GetValue("QS007", GetType(String))
        Me._questionnaires = info.GetValue("QS008", GetType(List(Of Questionnaire)))
        Me._variables = info.GetValue("QS009", GetType(List(Of Variable)))

    End Sub

    Public Sub GetObjectData(ByVal info As SerializationInfo, ByVal context As StreamingContext) Implements ISerializable.GetObjectData

        ' Generic object properties.
        info.AddValue("GO001", Me._guid)
        info.AddValue("GO002", Me._name)
        info.AddValue("GO003", Me._comment)
        info.AddValue("GO004", Me._dataBaseID)
        info.AddValue("GO005", Me._dataTableName)
        info.AddValue("GO006", Me._logTableName)

        ' Questionnaireset properties.
        info.AddValue("QS001", Me._shortName)
        info.AddValue("QS002", Me._precondition)
        info.AddValue("QS003", Me._subjectSecondaryIdField)
        info.AddValue("QS004", Me._subjectAlternativeSearchField)
        info.AddValue("QS005", Me._subjectConfirmationFields)
        info.AddValue("QS006", Me._newSubjectSectionID)
        info.AddValue("QS007", Me._onNewSubject)

        ' If not recursive then serialize empty lists.
        If ContextClass.RecursiveSerialization Then

            info.AddValue("QS008", Me._questionnaires)
            info.AddValue("QS009", Me._variables)

        Else
            info.AddValue("QS008", New List(Of Questionnaire))
            info.AddValue("QS009", New List(Of Variable))

        End If

    End Sub

#End Region

End Class

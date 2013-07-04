Imports System.Runtime.Serialization
Imports System.ComponentModel

<Serializable()> _
Public Class Section
    Inherits GenericObject
    Implements ISerializable, ISelfValidate


#Region "Shared properties"

    Public Shared MaxDataBaseID As Integer = 0

#End Region



#Region "Generic section properties"

    Private _shortName As String = ""

    'Short name Property.
    <CategoryAttribute("(Main)"), _
    DefaultValueAttribute(""), _
    DisplayName("Short name"), _
    DescriptionAttribute("Indicates the short name of the section.")> _
    Public Property ShortName() As String
        Get
            Return _shortName
        End Get
        Set(ByVal value As String)
            _shortName = BO.GenericObject.CheckIdentifier(value)
        End Set
    End Property

    <[ReadOnly](True), _
    CategoryAttribute("System Information")> _
    Public ReadOnly Property QuestionnaireSetID() As Integer
        Get
            If Me.Parent IsNot Nothing AndAlso Me.Parent.Parent IsNot Nothing Then
                Return Me.Parent.Parent.DataBaseID
            Else
                Return -1
            End If
        End Get
    End Property

    <[ReadOnly](True), _
    CategoryAttribute("System Information")> _
    Public ReadOnly Property QuestionnaireID() As Integer
        Get
            If Me.Parent IsNot Nothing Then
                Return Me.Parent.DataBaseID
            Else
                Return -1
            End If
        End Get
    End Property

    <[ReadOnly](True), _
        CategoryAttribute("System Information")> _
        Public ReadOnly Property SectionID() As Integer
        Get
            Return Me.DataBaseID
        End Get
    End Property

#End Region



#Region "PDA settings properties"

    Private _modifiable As Boolean = False
    Private _preCondition As String = ""
    Private _onNewRecord As String = Nothing

    ' Modifiable property.
    <CategoryAttribute("PDA settings"), _
    DefaultValueAttribute(True), _
    DisplayName("Modifiable"), _
    DescriptionAttribute("Indicates if the section can be edited or modified.")> _
    Public Property Modifiable() As Boolean
        Get
            Return _modifiable
        End Get
        Set(ByVal value As Boolean)
            _modifiable = value
        End Set
    End Property

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

    ' OnNewRecordProcedureID property.
    <CategoryAttribute("PDA settings"), _
    DisplayName("OnNewRecordProcedureID"), _
    DescriptionAttribute("ID of the procedure to execute when a new record is created.")> _
    Public Property OnNewRecord() As String
        Get
            Return _onNewRecord
        End Get
        Set(ByVal value As String)
            _onNewRecord = value
        End Set
    End Property

#End Region



#Region "Child properties"

    Private _variables As New List(Of Variable)
    Private _sectionItems As New List(Of SectionItem)

    ' Variables Property.
    <BrowsableAttribute(False)> _
    Public Overrides Property Variables() As List(Of Variable)
        Get
            Return _variables
        End Get
        Set(ByVal value As List(Of Variable))
            _variables = value
        End Set
    End Property

    ' Phases Property.
    <BrowsableAttribute(False)> _
    Public Overrides ReadOnly Property SectionItems() As List(Of SectionItem)
        Get
            Return _sectionItems
        End Get
    End Property

    ' Phases Property.
    <BrowsableAttribute(False)> _
    Public ReadOnly Property Phase(ByVal index As Integer) As SectionItem
        Get
            Return _sectionItems(index)
        End Get
    End Property

#End Region



#Region "Generic Object properties"

    ' HasSectionItems property
    <BrowsableAttribute(False)> _
    Public Overrides ReadOnly Property HasSectionItems() As Boolean
        Get
            Return True
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

        ' Si no trae id valido asignarle uno y actualizar el maximo.
        Me.DataBaseID = IIf(id > 0, id, MaxDataBaseID + 1)
        MaxDataBaseID = IIf(DataBaseID > MaxDataBaseID, DataBaseID, MaxDataBaseID)

        ' Set name.
        Me.Name = "Section " & Me.DataBaseID

    End Sub

    ' ToString.
    Public Overrides Function ToString() As String
        Return Me.Name
    End Function

    ' Finds the diferences between two sections.
    Public Overrides Function Difference(ByVal genericObject As GenericObject) As GenericObject

        ' Check types.
        If Not genericObject.GetType.Equals(GetType(Section)) Then Return Nothing

        ' Create the object.
        Dim result As New Section(0)
        Dim section As Section = genericObject
        Dim changed As Boolean = False

        ' Generic object properties.
        result.SetGuidWithoutHash(Nothing)

        If Me.Name <> section.Name Then
            result.Name = Me.Name
            changed = True
        Else
            result.Name = Nothing
        End If

        If Me.Comment <> section.Comment Then
            result.Comment = Me.Comment
            changed = True
        Else
            result.Comment = Nothing
        End If

        result.DataBaseID = Nothing

        ' Section properties.
        If Me.ShortName <> section.ShortName Then
            result.ShortName = Me.ShortName
            changed = True
        Else
            result.ShortName = Nothing
        End If

        If Me.Modifiable <> section.Modifiable Then
            result.Modifiable = Me.Modifiable
            changed = True
        Else
            result.Modifiable = Nothing
        End If

        If Me.PreCondition <> section.PreCondition Then
            result.PreCondition = Me.PreCondition
            changed = True
        Else
            result.PreCondition = Nothing
        End If

        If Not Me.OnNewRecord.Equals(section.OnNewRecord) Then
            result.OnNewRecord = Me.OnNewRecord
            changed = True
        Else
            result.OnNewRecord = Nothing
        End If

        result.Variables = Nothing
        result._sectionItems = Nothing

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

        ' Section properties.
        Me._shortName = info.GetValue("S001", GetType(String))
        Me._modifiable = info.GetValue("S002", GetType(Boolean))
        Me._preCondition = info.GetValue("S003", GetType(String))
        Me._onNewRecord = info.GetValue("S004", GetType(String))
        Me._variables = info.GetValue("S005", GetType(List(Of Variable)))
        Me._sectionItems = info.GetValue("S006", GetType(List(Of SectionItem)))

    End Sub


    Public Sub GetObjectData(ByVal info As SerializationInfo, ByVal context As StreamingContext) Implements ISerializable.GetObjectData

        ' Generic object properties.
        info.AddValue("GO001", Me._guid)
        info.AddValue("GO002", Me._name)
        info.AddValue("GO003", Me._comment)
        info.AddValue("GO004", Me._dataBaseID)
        info.AddValue("GO005", Me._dataTableName)
        info.AddValue("GO006", Me._logTableName)

        ' Section properties.
        info.AddValue("S001", Me._shortName)
        info.AddValue("S002", Me._modifiable)
        info.AddValue("S003", Me._preCondition)
        info.AddValue("S004", Me._onNewRecord)

        ' If not recursive then serialize empty lists.
        If ContextClass.RecursiveSerialization Then

            info.AddValue("S005", Me._variables)
            info.AddValue("S006", Me._sectionItems)

        Else

            info.AddValue("S005", New List(Of Variable))
            info.AddValue("S006", New List(Of SectionItem))

        End If

    End Sub


#End Region


End Class

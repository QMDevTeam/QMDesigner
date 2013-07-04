Imports System.ComponentModel
Imports System.Text.RegularExpressions
Imports System.Runtime.Serialization

<Serializable()> _
Public Class Study
    Inherits GenericObject
    Implements ISerializable


#Region "Instance Properties"

    Private _shortName As String = ""
    Private _version As String = "0.0.0"
    Private _creationDateTime As DateTime
    Private _lastModification As DateTime
    Private _legalValueTableSchema As String
    Private _dataTableSchema As String
    Private _logTableSchema As String
    Private _analysisViewsSchema As String
    Private _qmPath As String
    Private _overrideVersionNumber As Boolean = False

    ''' <summary>
    ''' Short Name Property.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    <CategoryAttribute("(Main)"), _
    DisplayName("Short name"), _
    DefaultValueAttribute("S"), _
    DescriptionAttribute("Indicates the short name of the study.")> _
    Public Property ShortName() As String
        Get
            Return _shortName
        End Get
        Set(ByVal value As String)
            _shortName = BO.GenericObject.CheckIdentifier(value)
        End Set
    End Property


    ''' <summary>
    ''' Version Property.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    <CategoryAttribute("(Main)"), _
    DisplayName("Version"), _
    DefaultValueAttribute(""), _
    DescriptionAttribute("Indicates the version of the study. Format: ##.##.##")> _
    Public Property Version() As String
        Get
            Return _version
        End Get
        Set(ByVal value As String)

            Try
                Dim NewString As String() = value.Trim.Split(".")
                Dim OldString As String() = _version.Split(".")
                If NewString.Length <> 3 OrElse _
                   String.IsNullOrEmpty(NewString(0)) OrElse _
                   String.IsNullOrEmpty(NewString(1)) OrElse _
                   String.IsNullOrEmpty(NewString(2)) Then Throw New Exception("Invalid format.")

                For i As Integer = 0 To 2
                    Dim compare As Integer = CInt(NewString(i)) - CInt(OldString(i))
                    If compare > 0 Then
                        _version = value
                        Exit Try
                    ElseIf compare < 0 Then
                        Dim message As String = "'{0}' is lower than the current version, are you sure you want to set this version number?"
                        If MessageBox.Show(String.Format(message, value), "Version", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                            _version = value
                            _overrideVersionNumber = True
                        End If
                        Exit Try
                    End If
                Next

            Catch ex As Exception
                MessageBox.Show("The version number must have the next format: '##.##.##'")
            End Try

            If Me._version = value AndAlso Application.OpenForms("Main") IsNot Nothing Then
                Application.OpenForms("Main").Text = String.Format("QM Designer - {0} {1}", Me.Name, Me._version)
            End If

        End Set
    End Property


    ''' <summary>
    ''' Data Table Schema property.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    <CategoryAttribute("Server Data"), _
    DisplayName("Data Table Schema"), _
    DescriptionAttribute("Indicates the schema of the data tables.")> _
    Public Property DataTableSchema() As String
        Get

            Return Me._dataTableSchema

        End Get
        Set(ByVal value As String)

            Me._dataTableSchema = value

        End Set
    End Property


    ''' <summary>
    ''' Log Table Schema property.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    <CategoryAttribute("Server Data"), _
    DisplayName("Log Table schema"), _
    DescriptionAttribute("Indicates the schema of the log tables.")> _
    Public Property LogTableSchema() As String
        Get

            Return Me._logTableSchema

        End Get
        Set(ByVal value As String)

            Me._logTableSchema = value

        End Set
    End Property


    ''' <summary>
    ''' Analysis Table Schema property.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    <CategoryAttribute("Server Data"), _
    DisplayName("Analysis Schema"), _
    DescriptionAttribute("Indicates the schema of the analysis views.")> _
    Public Property AnalysisViewsSchema() As String
        Get

            Return Me._analysisViewsSchema

        End Get
        Set(ByVal value As String)

            Me._analysisViewsSchema = value

        End Set
    End Property


    ''' <summary>
    ''' Legal Values Table Schema property.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    <CategoryAttribute("Server Data"), _
    DisplayName("Legal Values Table Schema"), _
    DescriptionAttribute("Indicates the schema of the legal values tables.")> _
    Public Property LegalValuesTableSchema() As String
        Get

            Return Me._legalValueTableSchema

        End Get
        Set(ByVal value As String)

            Me._legalValueTableSchema = value

        End Set
    End Property


    ''' <summary>
    ''' CreationDateTime Property.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    <CategoryAttribute("Read Only"), _
    DisplayName("Created"), _
    DescriptionAttribute("Indicates the date and time of the study creation.")> _
    Public ReadOnly Property CreationDateTime() As DateTime
        Get
            Return _creationDateTime
        End Get
    End Property


    ''' <summary>
    ''' LastModification Property.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    <CategoryAttribute("Read Only"), _
    DisplayName("Modified"), _
    DescriptionAttribute("Indicates the date and time of the last modification of the study.")> _
    Public ReadOnly Property lastModification() As DateTime
        Get
            Return _lastModification
        End Get
    End Property


    ''' <summary>
    ''' QM File name property.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>

    <CategoryAttribute("Read Only"), _
    DisplayName("QM File Name"), _
    DescriptionAttribute("Indicates the file that contains the study."), _
    ReadOnlyAttribute(True)> _
    Public Property QMFileName() As String
        Get
            Return Me._qmPath
        End Get
        Set(ByVal value As String)
            Me._qmPath = value
        End Set
    End Property


    ''' <summary>
    ''' NextVersion property.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    <BrowsableAttribute(False)> _
    Public ReadOnly Property NextVersion() As String
        Get
            Dim numbers() As String = _version.Split(".")
            Return String.Format("{0}.{1}.{2}", numbers(0), numbers(1), Convert.ToInt32(numbers(2)) + 1)
        End Get
    End Property


    ''' <summary>
    '''  NextDeployVersion.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    <BrowsableAttribute(False)> _
    Public ReadOnly Property NextDeployVersion() As String
        Get
            Dim numbers() As String = _version.Split(".")
            Return String.Format("{0}.{1}.0", numbers(0), Convert.ToInt32(numbers(1)) + 1)
        End Get
    End Property


    ''' <summary>
    ''' Override version number.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    <BrowsableAttribute(False)> _
    Public ReadOnly Property OverrideVersionNumber() As Boolean
        Get
            Return Me._overrideVersionNumber
        End Get
    End Property

#End Region



#Region "Child properties"

    Private _questionnarieSets As New List(Of QuestionnaireSet)
    Private _variables As New List(Of Variable)

    ' Questionnaries Property.
    <BrowsableAttribute(False)> _
    Public ReadOnly Property QuestionnarieSets() As List(Of QuestionnaireSet)
        Get
            Return _questionnarieSets
        End Get
    End Property

    ' Questionnaries Property.
    <BrowsableAttribute(False)> _
    Public ReadOnly Property QuestionnarieSet(ByVal index As Integer) As QuestionnaireSet
        Get
            Return _questionnarieSets(index)
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



#Region "Shared properties"

    Private Shared _maxTransactionID As Integer = 0
    Private Shared _legalValues As New List(Of LegalValuesTable)
    Private Shared _methods As New List(Of Method)
    Private Shared _screenTemplates As New List(Of ScreenTemplate)
    Private Shared _sites As New List(Of Site)
    Private Shared _guidHashTable As New Hashtable()
    Private Shared _languageList As New List(Of Language)
    Private Shared _pdaUsers As New List(Of PDAUser)
    Private Shared _files As New List(Of File)
    Private Shared _reports As New List(Of Report)

    ' MaxTransactionID Property.
    <BrowsableAttribute(False)> _
    Public Shared Property MaxTransactionID() As Integer
        Get
            Return _maxTransactionID
        End Get
        Set(ByVal value As Integer)
            _maxTransactionID = value
        End Set
    End Property

    ' Legal values Property.
    <BrowsableAttribute(False)> _
    Public Shared Property LegalValues() As List(Of LegalValuesTable)
        Get
            Return _legalValues
        End Get
        Set(ByVal value As List(Of LegalValuesTable))
            _legalValues = value
        End Set
    End Property

    ' Methods Property.
    <BrowsableAttribute(False)> _
    Public Shared Property Methods() As List(Of Method)
        Get

            Return _methods

        End Get
        Set(ByVal value As List(Of Method))

            _methods = value

        End Set
    End Property

    ' ScreenTemplates Property.
    <BrowsableAttribute(False)> _
    Public Shared Property ScreenTemplates() As List(Of ScreenTemplate)
        Get
            Return _screenTemplates
        End Get
        Set(ByVal value As List(Of ScreenTemplate))
            _screenTemplates = value
        End Set
    End Property

    ' ScreenTemplates indexed by name.
    <BrowsableAttribute(False)> _
    Public Shared ReadOnly Property ScreenTemplates(ByVal Name As String) As BO.ScreenTemplate
        Get
            For Each screen As BO.ScreenTemplate In _screenTemplates
                If screen.Name = Name Then
                    Return screen
                End If
            Next

            Return Nothing
        End Get
    End Property

    ' SiteList Property.
    <BrowsableAttribute(False)> _
    Public Shared Property Sites() As List(Of Site)
        Get
            Return _sites
        End Get
        Set(ByVal value As List(Of Site))
            _sites = value
        End Set
    End Property

    ' LanguageList property.
    Public Shared Property LanguageList() As List(Of BO.Language)
        Get
            Return _languageList
        End Get
        Set(ByVal value As List(Of BO.Language))
            _languageList = value
        End Set
    End Property

    ' language by ID.
    Public Shared ReadOnly Property LanguageList(ByVal languageID As Integer) As BO.Language
        Get
            For Each lang As BO.Language In Study.LanguageList

                If lang.LanguageID = languageID Then Return lang

            Next

            Return Nothing
        End Get
    End Property

    'Get Values of the HashTable
    Public Shared ReadOnly Property ObjectsHashTable() As System.Collections.ICollection
        Get
            Return _guidHashTable.Values
        End Get
    End Property

    ' PDA Users list.
    Public Shared Property PDAUsers() As List(Of PDAUser)
        Get
            Return BO.Study._pdaUsers
        End Get
        Set(ByVal value As List(Of PDAUser))
            BO.Study._pdaUsers = value
        End Set
    End Property

    ' Files list.
    Public Shared Property Files() As List(Of File)
        Get
            Return BO.Study._files
        End Get
        Set(ByVal value As List(Of File))
            BO.Study._files = value
        End Set
    End Property

    ' Reports list.
    Public Shared Property Reports() As List(Of Report)
        Get
            Return BO.Study._reports
        End Get
        Set(ByVal value As List(Of Report))
            BO.Study._reports = value
        End Set
    End Property

#End Region



#Region "Generic Object properties"

    ''' <summary>
    ''' Name property.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    <CategoryAttribute("(Main)"), _
    DisplayName("Name"), _
    DescriptionAttribute("Indicates the name of the object."), _
    EditorAttribute(GetType(MultiLanguageEditor), GetType(System.Drawing.Design.UITypeEditor))> _
    Public Shadows Property Name() As String
        Get
            Return MyBase.Name
        End Get
        Set(ByVal value As String)

            If Application.OpenForms("Main") IsNot Nothing Then
                Application.OpenForms("Main").Text = String.Format("QM Designer - {0} {1}", value, Me._version)
            End If

            MyBase.Name = value
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

    ' Shadows data table name to hide it.
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

#End Region



#Region "Methods"

    ''' <summary>
    ''' User Constructor.
    ''' </summary>
    ''' <param name="clearHash">Clears or not the hash table of all the objects.</param>
    ''' <remarks></remarks>

    Public Sub New(Optional ByVal clearHash As Boolean = True)

        Me.Name = "New Study"
        Me.LogTableSchema = "dbo"
        Me.DataTableSchema = "dbo"
        Me.LegalValuesTableSchema = "LegalValue"
        Me.AnalysisViewsSchema = "Analysis"
        Me.Guid = Guid.NewGuid
        Me.setCreationDateTime(DateTime.Now)
        If clearHash Then
            Study._guidHashTable.Clear()
        End If

    End Sub


    ''' <summary>
    ''' Serialization: Constructor.
    ''' </summary>
    ''' <param name="info">Serialized object.</param>
    ''' <param name="context"></param>
    ''' <remarks></remarks>

    Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)

        Me.ShortName = info.GetString("sn")
    End Sub


    ''' <summary>
    ''' Serialization: the serializator method.
    ''' </summary>
    ''' <param name="info"></param>
    ''' <param name="context"></param>
    ''' <remarks></remarks>

    Public Sub GetObjectData(ByVal info As SerializationInfo, ByVal context As StreamingContext) Implements ISerializable.GetObjectData
        info.AddValue("sn", Me.ShortName)
    End Sub


    ''' <summary>
    ''' To String.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Overrides Function ToString() As String
        Return Me.Name
    End Function


    ''' <summary>
    ''' Set version number.
    ''' </summary>
    ''' <param name="version"></param>
    ''' <remarks>Assigns a new version number, skips validations.</remarks>

    Public Sub setVersion(ByVal version As String)
        Me._version = version
        If Application.OpenForms("Main") IsNot Nothing Then
            Application.OpenForms("Main").Text = String.Format("QM Designer - {0} {1}", Me.Name, Me._version)
        End If
    End Sub


    ''' <summary>
    ''' Update the creation date.
    ''' </summary>
    ''' <param name="creation"></param>
    ''' <remarks></remarks>

    Public Sub setCreationDateTime(ByVal creation As DateTime)
        Me._creationDateTime = creation
    End Sub


    ''' <summary>
    ''' Update the last modification date.
    ''' </summary>
    ''' <param name="modification"></param>
    ''' <remarks></remarks>

    Public Sub setLastModificationDateTime(ByVal modification As DateTime)
        Me._lastModification = modification
    End Sub


    ''' <summary>
    ''' Retrieve the legalValue with the specified name.
    ''' </summary>
    ''' <param name="name"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Shared Function GetLegalValuesByName(ByVal name As String) As LegalValuesTable

        For Each currentLegalValues As LegalValuesTable In BO.Study.LegalValues
            If (name = currentLegalValues.Name) Then
                Return currentLegalValues
            End If
        Next
        Return Nothing

    End Function


    ''' <summary>
    ''' Add an element to the GuidHashTable.
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <remarks></remarks>

    Public Shared Sub AddToGuidHashTable(ByVal obj As GenericObject)

        _guidHashTable.Add(obj.Guid, obj)
    End Sub


    ''' <summary>
    ''' Remove an element from the GuidHashTable.
    ''' </summary>
    ''' <param name="guid"></param>
    ''' <remarks></remarks>

    Public Shared Sub RemoveFromGuidHashTable(ByVal guid As Guid)

        _guidHashTable.Remove(guid)
    End Sub


    ''' <summary>
    '''  Retrieve an element from othe GuidHasTable.
    ''' </summary>
    ''' <param name="guid"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Shared Function GetElementFromGuidHashTable(ByVal guid As Guid) As GenericObject

        Return CType(_guidHashTable.Item(guid), GenericObject)
    End Function


    ''' <summary>
    ''' Finds the diferences between two studies.
    ''' </summary>
    ''' <param name="genericObject"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Overrides Function Difference(ByVal genericObject As GenericObject) As GenericObject

        ' Check types.
        If Not genericObject.GetType.Equals(GetType(Study)) Then Return Nothing

        ' Create the object.
        Dim result As New Study(False)
        Dim study As Study = genericObject
        Dim changed As Boolean = False

        ' Generic object properties.
        result.SetGuidWithoutHash(Nothing)

        If Me.Name <> study.Name Then
            result.Name = Me.Name
            changed = True
        Else
            result.Name = Nothing
        End If

        If Me.Comment <> study.Comment Then
            result.Comment = Me.Comment
            changed = True
        Else
            result.Comment = Nothing
        End If

        result.DataBaseID = Nothing

        ' Study properties.
        If Me.ShortName <> study.ShortName Then
            result.ShortName = Me.ShortName
            changed = True
        Else
            result.ShortName = Nothing
        End If

        If Me.Version <> study.Version Then
            result.setVersion(Me.Version)
            changed = True
        Else
            result.setVersion(Nothing)
        End If

        result.setCreationDateTime(Nothing)
        result.setLastModificationDateTime(Nothing)
        result._questionnarieSets = Nothing

        ' Return the value.
        If changed Then Return result Else Return Nothing
    End Function

#End Region


End Class

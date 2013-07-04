Imports System.ComponentModel
Imports System.Text.RegularExpressions

Public MustInherit Class GenericObject

#Region "Properties"

    Friend _guid As Guid
    Friend _name As New Dictionary(Of Integer, String)
    Friend _comment As String
    Friend _dataBaseID As Integer
    Friend _parentObject As GenericObject
    Friend _dataTableName As String
    Friend _logTableName As String


    <CategoryAttribute("Server Data")> _
    Public Property DataTableName() As String
        Get
            Return Me._dataTableName
        End Get
        Set(ByVal value As String)
            Me._dataTableName = Me.CheckIdentifier(value)
        End Set
    End Property


    <CategoryAttribute("Server Data")> _
    Public Property LogTableName() As String
        Get
            Return Me._logTableName
        End Get
        Set(ByVal value As String)
            Me._logTableName = Me.CheckIdentifier(value)
        End Set
    End Property


    <CategoryAttribute("PDA Data")> _
    Public ReadOnly Property PDADataTableName() As String
        Get
            If Not Me.HasVariables Then
                Return Nothing

            ElseIf Me.GetType.Equals(GetType(BO.QuestionnaireSet)) Then
                Return String.Format("S_{0}", Me.DataBaseID)

            ElseIf Me.GetType.Equals(GetType(BO.Questionnaire)) AndAlso Me.Parent IsNot Nothing Then
                Return String.Format("D_{0}_{1}", Me.Parent.DataBaseID, Me.DataBaseID)

            ElseIf Me.GetType.Equals(GetType(BO.Section)) AndAlso Me.Parent IsNot Nothing AndAlso Me.Parent.Parent IsNot Nothing Then
                Return String.Format("D_{0}_{1}_{2}", Me.Parent.Parent.DataBaseID, Me.Parent.DataBaseID, Me.DataBaseID)

            Else
                Return Nothing

            End If
        End Get
    End Property


    '<BrowsableAttribute(False)> _
    <[ReadOnly](True), _
    CategoryAttribute("System Information"), _
    DisplayName("Unique Identifier")> _
    Public Overridable Property Guid() As Guid
        Get

            Return _guid
        End Get
        Set(ByVal value As Guid)

            ' Remove the oldvalue from the hash table.
            If _guid <> Guid.Empty Then
                BO.Study.RemoveFromGuidHashTable(_guid)
            End If

            ' Set the property.
            _guid = value

            ' Add the new reference.
            BO.Study.AddToGuidHashTable(Me)

        End Set
    End Property

    ' Name property.
    <CategoryAttribute("(Main)"), _
    DisplayName("Name"), _
    DescriptionAttribute("Indicates the name of the object."), _
    EditorAttribute(GetType(MultiLanguageEditor), GetType(System.Drawing.Design.UITypeEditor))> _
    Public Property Name() As String
        Get
            If _name.ContainsKey(BO.ContextClass.CurrentLanguage.LanguageID) Then
                Return _name(BO.ContextClass.CurrentLanguage.LanguageID)
            Else
                Return ""
            End If
        End Get
        Set(ByVal value As String)
            If value IsNot Nothing Then value = value.Trim
            _name.Item(BO.ContextClass.CurrentLanguage.LanguageID) = value
        End Set
    End Property

    ' Name Dictionary.
    <BrowsableAttribute(False)> _
    Public Property NameDictionary() As Dictionary(Of Integer, String)
        Get
            Return _name
        End Get
        Set(ByVal value As Dictionary(Of Integer, String))
            _name = value
        End Set
    End Property

    ' Parent property.
    <BrowsableAttribute(False)> _
    Public ReadOnly Property Parent() As GenericObject
        Get
            Return _parentObject
        End Get
    End Property

    ' Comment property.
    <CategoryAttribute("(Main)"), _
    DisplayName("Comment"), _
    DefaultValueAttribute(""), _
    DescriptionAttribute("Type a comment of the object."), _
    EditorAttribute(GetType(BO.CodeEditor), GetType(System.Drawing.Design.UITypeEditor))> _
    Public Property Comment() As String
        Get

            Return _comment
        End Get
        Set(ByVal value As String)
            If value IsNot Nothing Then
                _comment = value.Trim
            Else
                _comment = Nothing
            End If
        End Set
    End Property

    ' DataBaseID property.
    <BrowsableAttribute(False)> _
    Public Property DataBaseID() As Integer
        Get

            Return _dataBaseID
        End Get
        Set(ByVal value As Integer)

            _dataBaseID = value
        End Set
    End Property

    ' Attribute property.
    <BrowsableAttribute(False)> _
    Public Property Attribute(ByVal name As String, Optional ByVal index As Object = Nothing) As Object
        Get

            name = name.ToLower
            For Each prop As Reflection.PropertyInfo In Me.GetType.GetProperties
                If prop.Name.ToLower = name Then Return prop.GetValue(Me, index)
            Next

            Throw New Exception("The attribute doesn't exists in the current object.")
        End Get
        Set(ByVal value As Object)

            For Each prop As Reflection.PropertyInfo In Me.GetType.GetProperties
                If prop.Name.ToLower = name Then
                    prop.SetValue(Me, value, index)
                    Exit Property
                End If
            Next

            Throw New Exception("The attribute doesn't exists in the current object.")
        End Set
    End Property

    ' AttributeType property.
    <BrowsableAttribute(False)> _
    Public ReadOnly Property AttributeType(ByVal name As String, Optional ByVal index As Object = Nothing) As Type
        Get

            name = name.ToLower
            For Each prop As Reflection.PropertyInfo In Me.GetType.GetProperties
                If prop.Name.ToLower = name Then
                    If prop.PropertyType.Equals(GetType(Nullable(Of Integer))) Then
                        Return GetType(Integer)
                    Else
                        Return prop.PropertyType
                    End If

                End If
            Next

            Throw New Exception("The attribute doesn't exists in the current object.")
        End Get
    End Property

#End Region

#Region "Methods"

    ' Sets the parent property.
    Public Sub SetParent(ByVal genericObject As GenericObject)
        Me._parentObject = genericObject
    End Sub

    ' True if the instance of the object contains a variable with that name.
    Public Function HasVariableByName(ByVal name As String) As Boolean

        If Me.HasVariables Then
            For Each variable As Variable In Me.Variables
                If variable.Name = name Then Return True
            Next
        End If

        Select Case Me.GetType.ToString
            Case GetType(Study).ToString
                For Each questionnaireSet As QuestionnaireSet In CType(Me, Study).QuestionnarieSets
                    If questionnaireSet.HasVariableByName(name) Then Return True
                Next

            Case GetType(QuestionnaireSet).ToString
                For Each questionnaire As Questionnaire In CType(Me, QuestionnaireSet).Questionnaires
                    If questionnaire.HasVariableByName(name) Then Return True
                Next

            Case GetType(Questionnaire).ToString
                For Each section As Section In CType(Me, Questionnaire).Sections
                    If section.HasVariableByName(name) Then Return True
                Next

            Case GetType(Section).ToString
                For Each phase As BO.SectionItem In CType(Me, BO.Section).SectionItems
                    If phase.HasVariableByName(name) Then Return True
                Next

            Case GetType(BO.CheckPoint).ToString
                For Each phase As SectionItem In CType(Me, CheckPoint).SectionItems
                    If phase.HasVariableByName(name) Then Return True
                Next

            Case GetType(BO.Question).ToString
                Dim question As BO.Question = Me
                If String.IsNullOrEmpty(question.VariableName) Then
                    Return False
                Else
                    Return Not question.VariableName.ToLower = name.ToLower
                End If

            Case Else
                Return False

        End Select
    End Function

    ' True if the current instance of the object has the specific attribute.
    Public Function HasAttribute(ByVal name As String) As Boolean

        name = name.ToLower
        For Each prop As Reflection.PropertyInfo In Me.GetType.GetProperties
            If prop.Name.ToLower = name Then Return True
        Next

        Return False
    End Function

    ' Sets the guid value without pushing into the hashtable.
    Public Sub SetGuidWithoutHash(ByVal guid As Guid)
        Me._guid = guid
    End Sub

    ' Constructor.
    Public Sub New()
        Me._guid = Guid.NewGuid()
    End Sub

    ' Adds a variable in alphabetic order into the collection.
    Public Sub RemoveVariableByName(ByVal variableName As String)
        For i As Integer = 0 To Variables.Count - 1
            If Variables(i).Name = variableName Then
                Variables.RemoveAt(i)
                Exit For
            End If
        Next
    End Sub

    ' Clones the question.
    Public Function Clone() As GenericObject

        Dim formatter As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter()
        Dim memStream As New IO.MemoryStream()

        formatter.Serialize(memStream, Me)
        memStream.Seek(0, IO.SeekOrigin.Begin)
        Dim o As GenericObject = formatter.Deserialize(memStream)

        memStream.Close()
        memStream.Dispose()

        Return o

    End Function


    ' Validates if the string is a valid .NET and SQL identifier.
    Public Shared Function CheckIdentifier(ByVal id As String) As String

        If String.IsNullOrEmpty(id) Then

            Return Nothing

        ElseIf Not Regex.IsMatch(id.Trim, "^([A-Z]|[a-z]|_)([A-Z]|[a-z]|[0-9]|_|-)*$") Then

            Throw New Exception(String.Format("'{0}' Is not a valid identifier.", id))

        Else

            Return id.Trim

        End If

    End Function

#End Region

#Region "Virtual Methods & Properties"

    Public MustOverride Function Difference(ByVal genericObject As GenericObject) As GenericObject

    Public MustOverride ReadOnly Property HasSectionItems() As Boolean
    Public MustOverride ReadOnly Property HasVariables() As Boolean

#End Region

#Region "Overridable Methods & Properties"

    ' Variables property. (Returns nothing)
    <BrowsableAttribute(False)> _
    Public Overridable Property Variables() As List(Of BO.Variable)
        Get
            Return Nothing
        End Get
        Set(ByVal value As List(Of BO.Variable))

        End Set
    End Property

    ' SectionItems property. (Returns nothing)
    <BrowsableAttribute(False)> _
    Public Overridable ReadOnly Property SectionItems() As List(Of SectionItem)
        Get
            Return Nothing
        End Get
    End Property

#End Region
End Class

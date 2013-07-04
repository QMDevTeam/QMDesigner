Imports system.Runtime.Serialization
Imports System.ComponentModel

<Serializable()> _
Public Class CheckPoint
    Inherits SectionItem
    Implements ISerializable, ISelfValidate


#Region "Properties"

    Private _condition As String = ""
    Private _branchIf As Boolean = True


    <CategoryAttribute("Checkpoint"), _
    DisplayName("Condition"), _
    DescriptionAttribute("Indicates the condition to follow or not the branch."), _
    EditorAttribute(GetType(CodeEditor), GetType(System.Drawing.Design.UITypeEditor))> _
    Public Property Condition() As String
        Get
            Return _condition
        End Get
        Set(ByVal value As String)
            If value IsNot Nothing Then
                _condition = value.Trim
            Else
                _condition = Nothing
            End If
        End Set
    End Property

    ' BranchIf Property
    <CategoryAttribute("Checkpoint"), _
    DisplayName("Branch If"), _
    DescriptionAttribute("Indicates if the branch will be followed when de condition returns true or false.")> _
    Public Property BranchIf() As Boolean
        Get
            Return _branchIf
        End Get
        Set(ByVal value As Boolean)
            _branchIf = value
        End Set
    End Property

#End Region



#Region "Generic Object properties"

    Private _sectionItems As New List(Of SectionItem)

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
            Return False
        End Get
    End Property

    ' SectionItems Property
    <BrowsableAttribute(False)> _
    Public Overrides ReadOnly Property SectionItems() As List(Of SectionItem)
        Get
            Return _sectionItems
        End Get
    End Property

    ' SectionItems Property
    <BrowsableAttribute(False)> _
    Public ReadOnly Property SectionItem(ByVal index As Integer) As SectionItem
        Get
            Return _sectionItems(index)
        End Get
    End Property

#End Region



#Region "Methods"

    Public Sub New()
    End Sub


    ' Finds the diferences between two checkpoints.
    Public Overrides Function Difference(ByVal genericObject As GenericObject) As GenericObject

        ' Check types.
        If Not genericObject.GetType.Equals(GetType(CheckPoint)) Then Return Nothing

        ' Create the object.
        Dim result As New CheckPoint()
        Dim checkpoint As CheckPoint = genericObject
        Dim changed As Boolean = False

        ' Generic object properties.
        result.SetGuidWithoutHash(Nothing)

        If Me.Name <> checkpoint.Name Then
            result.Name = Me.Name
            changed = True
        Else
            result.Name = Nothing
        End If

        If Me.Comment <> checkpoint.Comment Then
            result.Comment = Me.Comment
            changed = True
        Else
            result.Comment = Nothing
        End If

        result.DataBaseID = Nothing

        ' Phase properties.
        If Me.MainText <> checkpoint.MainText Then
            result.MainText = Me.MainText
            changed = True
        Else
            result.MainText = Nothing
        End If

        If Me.Number <> checkpoint.Number Then
            result.Number = Me.Number
            changed = True
        Else
            result.Number = Nothing
        End If

        ' Checkpoint properties.
        If Me.Condition <> checkpoint.Condition Then
            result.Condition = Me.Condition
            changed = True
        Else
            result.Condition = Nothing
        End If

        If Me.BranchIf <> checkpoint.BranchIf Then
            result.BranchIf = Me.BranchIf
            changed = True
        Else
            result.BranchIf = Nothing
        End If

        Me._sectionItems = Nothing

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

        ' Checkpoint properties.
        Me._condition = info.GetValue("CP001", GetType(String))
        Me._branchIf = info.GetValue("CP002", GetType(Boolean))
        Me._sectionItems = info.GetValue("CP003", GetType(List(Of SectionItem)))

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

        ' Checkpoint properties.
        info.AddValue("CP001", Me._condition)
        info.AddValue("CP002", Me._branchIf)

        ' If not recursive then serialize empty lists.
        If ContextClass.RecursiveSerialization Then

            info.AddValue("CP003", Me._sectionItems)

        Else

            info.AddValue("CP003", New List(Of SectionItem))

        End If

    End Sub


    ' Validates the questionnaireset.
    Public Function IsValid() As Boolean Implements ISelfValidate.IsValid

        Dim message As String = ""

        If String.IsNullOrEmpty(Me.MainText) Then message &= Environment.NewLine & "Main text is required."
        If String.IsNullOrEmpty(Me.Condition) Then message &= Environment.NewLine & "Condition is required."
        
        If Not String.IsNullOrEmpty(message) Then
            MessageBox.Show("Error list:" & message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Else
            Return True
        End If

    End Function

#End Region


End Class

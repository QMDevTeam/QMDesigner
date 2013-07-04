Imports System.ComponentModel

Public Class File
    Implements ISelfValidate


#Region " Properties "

    Private _guid As Guid
    Private _name As String
    Private _referencePath As String
    Private _codeNamespace As String


    ''' <summary>
    ''' Unique identifier for the file object.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public ReadOnly Property Guid() As Guid
        Get

            Return Me._guid

        End Get
    End Property


    ''' <summary>
    ''' Name of the file to be used as reference.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Property Name() As String
        Get
            Return Me._name
        End Get
        Set(ByVal value As String)
            Me._name = value.Trim
        End Set
    End Property


    ''' <summary>
    ''' Path to look for the file in the machine.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    <EditorAttribute(GetType(FileNameEditor), GetType(System.Drawing.Design.UITypeEditor))> _
    Public Property ReferencePath() As String
        Get
            Return Me._referencePath
        End Get
        Set(ByVal value As String)
            value = value.Trim
            If Not value.Equals(Me._referencePath) Then Me._name = IO.Path.GetFileName(value)
            Me._referencePath = value
        End Set
    End Property


    ''' <summary>
    ''' Indicates the namespace of the file, for assembly files only.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Property CodeNamespace() As String
        Get
            Return Me._codeNamespace
        End Get
        Set(ByVal value As String)
            Me._codeNamespace = value.Trim
        End Set
    End Property

#End Region



#Region " Public Methods "

    Public Sub New()

        Me._guid = Guid.NewGuid()

    End Sub


    Public Sub New(ByVal guid As Guid)

        Me._guid = guid

    End Sub


    Public Function IsValid() As Boolean Implements ISelfValidate.IsValid

        Dim message As String = ""

        If String.IsNullOrEmpty(Me._name) Then message &= Environment.NewLine & "Name is required."

        If String.IsNullOrEmpty(Me._referencePath) Then
            message &= Environment.NewLine & "Reference path is required."
        ElseIf Not IO.File.Exists(Me._referencePath) Then
            message &= Environment.NewLine & "Reference path is not valid, the file does not exist."
        End If

        If Not String.IsNullOrEmpty(ReferencePath) AndAlso _
            Not ReferencePath.ToLower.EndsWith("dll") AndAlso _
            Not String.IsNullOrEmpty(Me._codeNamespace) AndAlso _
            MessageBox.Show("The file doesn't appear to be an assembly file, are you sure it has a namespace?", "", MessageBoxButtons.YesNo) = DialogResult.No _
        Then
            Return False
        End If

        If Not String.IsNullOrEmpty(message) Then
            MessageBox.Show("Error list:" & message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Else
            Return True
        End If

    End Function

    Public Overrides Function ToString() As String
        Return Me._name
    End Function

#End Region


End Class

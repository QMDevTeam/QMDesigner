Public Class PDAUser
    Implements ISelfValidate


#Region "Properties"

    Private _PDAUserName As String
    Private _PDAPassword As String
    Private _name As String
    Private _RoleName As String
    Private _defaultSiteID As Nullable(Of Integer)


    Public Property PDAUserName() As String
        Get
            Return Me._PDAUserName
        End Get
        Set(ByVal value As String)
            Me._PDAUserName = value
        End Set
    End Property


    Public Property PDAPassword() As String
        Get
            Return Me._PDAPassword
        End Get
        Set(ByVal value As String)
            Me._PDAPassword = value
        End Set
    End Property


    Public Property Name() As String
        Get
            Return Me._name
        End Get
        Set(ByVal value As String)
            Me._name = value
        End Set
    End Property


    Public Property RoleName() As String
        Get
            Return Me._RoleName
        End Get
        Set(ByVal value As String)
            Me._RoleName = value
        End Set
    End Property


    Public Property DefaultSiteID() As Nullable(Of Integer)
        Get
            Return Me._defaultSiteID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            Me._defaultSiteID = value
        End Set
    End Property

#End Region



#Region "Public Methods"


    Public Overrides Function ToString() As String
        Return Me.PDAUserName
    End Function


    Public Function isValid() As Boolean Implements ISelfValidate.IsValid

        Dim message As String = ""

        If String.IsNullOrEmpty(Me._PDAUserName) Then message &= Environment.NewLine & "PDA User Name is required."
        If String.IsNullOrEmpty(Me._PDAPassword) Then message &= Environment.NewLine & "PDA User Password is required."
        If String.IsNullOrEmpty(Me._name) Then message &= Environment.NewLine & "Name is required."
        If String.IsNullOrEmpty(Me._RoleName) Then message &= Environment.NewLine & "Role name is required."

        If Not String.IsNullOrEmpty(message) Then
            MessageBox.Show("Error list:" & message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Else
            Return True
        End If

    End Function


#End Region


End Class

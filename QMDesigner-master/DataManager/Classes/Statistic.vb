Public Class FileStatistic

#Region " Private Members "

    Private _statistics As New List(Of TableStatistic)
    Private _name As String = ""
    Private _beginTime As Date
    Private _endTime As Date

#End Region

#Region " Properties "

    Public Property Statistics() As List(Of TableStatistic)
        Get
            Return _statistics
        End Get
        Set(ByVal value As List(Of TableStatistic))
            If value Is Nothing Then
                Throw New Exception("The List cannot be Nothing")
            End If
            _statistics = value
        End Set
    End Property

    Public ReadOnly Property SummaryStatistic() As TableStatistic
        Get

            Dim temporalStatistic As New TableStatistic(_name)

            For Each stats As TableStatistic In _statistics
                temporalStatistic.AddStats(stats)
            Next

            Return temporalStatistic

        End Get
    End Property

    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property

    Public Property BeginTime() As Date
        Get
            Return _beginTime
        End Get
        Set(ByVal value As Date)
            _beginTime = value
        End Set
    End Property

    Public Property EndTime() As Date
        Get
            Return _endTime
        End Get
        Set(ByVal value As Date)
            _endTime = value
        End Set
    End Property

#End Region

#Region " Public Methods "

    Public Sub New()
    End Sub

    Public Sub New(ByVal name As String)
        _name = name
    End Sub

    Public Sub AddStatistic(ByVal statistic As TableStatistic)
        _statistics.Add(statistic)
    End Sub

#End Region

End Class

Public Class TableStatistic

#Region " Private Members "

    Private _inserted As Long = 0
    Private _updated As Long = 0
    Private _errors As New List(Of ErrorRegister)
    Private _name As String = ""

#End Region

#Region " Properties "
    Public Property Inserted() As Long
        Get
            Return _inserted
        End Get
        Set(ByVal value As Long)
            _inserted = value
        End Set
    End Property

    Public Property Updated() As Long
        Get
            Return _updated
        End Get
        Set(ByVal value As Long)
            _updated = value
        End Set
    End Property

    Public Property Errors() As List(Of ErrorRegister)
        Get
            Return _errors
        End Get
        Set(ByVal value As List(Of ErrorRegister))
            _errors = value
        End Set
    End Property

    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property

#End Region

#Region " Public Methods "

    Public Sub New()
    End Sub

    Public Sub New(ByVal name As String)
        _name = name
    End Sub

    Public Sub AddStats(ByVal stats As TableStatistic)
        _inserted += stats.Inserted
        _updated += stats.Updated
        _errors.AddRange(stats.Errors)
    End Sub

    Public Sub AddInserted()
        _inserted += 1
    End Sub

    Public Sub AddUpdated()
        _updated += 1
    End Sub

    Public Sub AddError(ByVal errorRegistry As ErrorRegister)
        _errors.Add(errorRegistry)
    End Sub

    Public Sub AddError(ByVal action As String, ByVal errorMessage As String, ByVal subjectID As String, _
                            Optional ByVal subjectQuestionnaireInstanceID As Integer = -1)
        Dim errorRegistry As New ErrorRegister
        errorRegistry.Action = action
        errorRegistry.ErrorMessage = errorMessage
        errorRegistry.SubjectID = subjectID
        errorRegistry.SubjectQuestionnaireInstanceID = subjectQuestionnaireInstanceID

        _errors.Add(errorRegistry)
    End Sub

#End Region

End Class

Public Class ErrorRegister
#Region " Private Members "

    Private _SubjectID As String = ""
    Private _subjectQuestionnaireInstanceID As Integer = -1
    Private _action As String = ""
    Private _error As String = ""
    Private _timeOfError As Date

#End Region

#Region " Public Methods "
    Public Overrides Function toString() As String
        Dim temp As String = ""
        temp &= String.Format(vbTab & vbTab & "SubjectID: {0}", _SubjectID) & vbCrLf
        temp &= IIf(_subjectQuestionnaireInstanceID >= 0, String.Format(vbTab & vbTab & "SubjectQuestionnaireInstanceID: {0}", _subjectQuestionnaireInstanceID.ToString) & vbCrLf, "").ToString()
        temp &= String.Format(vbTab & vbTab & "Action: {0}", _action) & vbCrLf
        temp &= String.Format(vbTab & vbTab & "Error: ""{0}""", _error) & vbCrLf
        Return temp
    End Function

#End Region

#Region " Public Properties "
    Public Property SubjectID() As String
        Get
            Return _SubjectID
        End Get
        Set(ByVal value As String)
            _SubjectID = value
        End Set
    End Property

    Public Property SubjectQuestionnaireInstanceID() As Integer
        Get
            Return _subjectQuestionnaireInstanceID
        End Get
        Set(ByVal value As Integer)
            _subjectQuestionnaireInstanceID = value
        End Set
    End Property

    Public Property Action() As String
        Get
            Return _action
        End Get
        Set(ByVal value As String)
            _action = value
        End Set
    End Property

    Public Property ErrorMessage() As String
        Get
            Return _error
        End Get
        Set(ByVal value As String)
            _timeOfError = Date.Now
            _error = value
        End Set
    End Property

    Public ReadOnly Property TimeOfError() As Date
        Get
            Return _timeOfError
        End Get
    End Property
#End Region

End Class

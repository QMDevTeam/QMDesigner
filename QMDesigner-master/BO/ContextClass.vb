Public Class ContextClass

    Private Shared _currentQuestionnaireSet As QuestionnaireSet
    Private Shared _currentQuestionnaire As Questionnaire
    Private Shared _currentSection As Section
    Private Shared _currentTreeNode As Object
    Private Shared _study As BO.Study
    Private Shared _currentLanguage As BO.Language

    Public Shared RecursiveSerialization As Boolean = True
    Public Shared TrailSerialization As Boolean = True
    Public Shared HasChanges As Boolean = True

    Public Shared Property Study() As BO.Study
        Get
            Return _study
        End Get
        Set(ByVal value As BO.Study)
            _study = value
        End Set
    End Property

    Public Shared Property CurrentQuestionnaireSet() As QuestionnaireSet
        Get
            Return _currentQuestionnaireSet
        End Get
        Set(ByVal value As QuestionnaireSet)
            _currentQuestionnaireSet = value
        End Set
    End Property

    Public Shared Property CurrentQuestionnaire() As Questionnaire
        Get
            Return _currentQuestionnaire
        End Get
        Set(ByVal value As Questionnaire)
            _currentQuestionnaire = value
        End Set
    End Property

    Public Shared Property CurrentSection() As Section
        Get
            Return _currentSection
        End Get
        Set(ByVal value As Section)
            _currentSection = value
        End Set
    End Property

    Public Shared Property CurrentTreeNode() As Object
        Get
            Return _currentTreeNode
        End Get
        Set(ByVal value As Object)
            _currentTreeNode = value
        End Set
    End Property

    Public Shared Property CurrentLanguage() As BO.Language
        Get
            Return _currentLanguage
        End Get
        Set(ByVal value As BO.Language)
            _currentLanguage = value
        End Set
    End Property

End Class

Imports System.ComponentModel

Public Class Language


#Region "Properties"

    Private _languageID As Integer
    Private _language As String

    Private Shared _maxLanguageID As Integer


    <DisplayName("Language ID")> _
    Public ReadOnly Property LanguageID()
        Get
            Return Me._languageID
        End Get
    End Property


    <DisplayName("Language Name")> _
    Public Property Name() As String
        Get
            Return _language
        End Get
        Set(ByVal value As String)
            _language = value
        End Set
    End Property

#End Region



#Region "Public Methods"

    Public Sub New()

        Me._language = "(New Language)"
        Language._maxLanguageID += 1
        Me._languageID = Language._maxLanguageID

    End Sub


    Public Sub New(ByVal languageID As Integer, ByVal languageName As String)

        Me._languageID = languageID
        Me._language = languageName

        If Me._languageID > Language._maxLanguageID Then Language._maxLanguageID = Me.LanguageID

    End Sub


    Public Overrides Function ToString() As String

        Return Me.Name

    End Function

#End Region


End Class

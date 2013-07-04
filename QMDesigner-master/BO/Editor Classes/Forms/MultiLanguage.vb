Public Class MultiLanguage

    ' Invokes the form.
    Public Shared Function GetMultiLanguage(ByVal dictionary As Dictionary(Of Integer, String)) As Dictionary(Of Integer, String)
        Dim form As New MultiLanguage(dictionary)
        If form.ShowDialog = Windows.Forms.DialogResult.OK Then
            Return form.textsDictionary
        Else
            Return dictionary
        End If
    End Function

    ' Default alternative language.
    Shared defaultLanguage As BO.Language = Nothing

    ' Dictionary for the edition.
    Private textsDictionary As New Dictionary(Of Integer, String)


    ' Constructor, fills the dictionary.
    Public Sub New(ByVal dictionary As Dictionary(Of Integer, String))

        InitializeComponent()

        For Each key As Integer In dictionary.Keys
            Me.textsDictionary.Add(key, dictionary(key))
        Next
    End Sub

    ' Fills the combobox and sets the default value.
    Private Sub MultiLanguage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If textsDictionary.ContainsKey(BO.ContextClass.CurrentLanguage.LanguageID) Then
            TextBox_CurrentText.Text = textsDictionary(BO.ContextClass.CurrentLanguage.LanguageID)
        Else
            TextBox_CurrentText.Text = ""
        End If
        For Each language As BO.Language In BO.Study.LanguageList
            If Not language.Equals(BO.ContextClass.CurrentLanguage) Then
                ComboBox_AlternativeLanguage.Items.Add(language)
            End If
        Next

        If defaultLanguage IsNot Nothing AndAlso Not defaultLanguage.Equals(BO.ContextClass.CurrentLanguage) Then
            ComboBox_AlternativeLanguage.SelectedItem = defaultLanguage
        End If

    End Sub

    Private Sub TextBox_CurrentText_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox_CurrentText.Leave
        textsDictionary(BO.ContextClass.CurrentLanguage.LanguageID) = TextBox_CurrentText.Text
    End Sub

    Private Sub TextBox_OtherText_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox_OtherText.Leave
        textsDictionary(CType(ComboBox_AlternativeLanguage.SelectedItem, BO.Language).LanguageID) = TextBox_OtherText.Text
    End Sub

    Private Sub ComboBox_AlternativeLanguage_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox_AlternativeLanguage.SelectedIndexChanged
        If textsDictionary.ContainsKey(CType(ComboBox_AlternativeLanguage.SelectedItem, BO.Language).LanguageID) Then
            TextBox_OtherText.Text = textsDictionary(CType(ComboBox_AlternativeLanguage.SelectedItem, BO.Language).LanguageID)
        Else
            TextBox_OtherText.Text = Nothing
        End If

        Me.TextBox_OtherText.Enabled = True
        defaultLanguage = ComboBox_AlternativeLanguage.SelectedItem
    End Sub

    Private Sub MultiLanguage_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed

        TextBox_CurrentText_Leave(sender, e)
        If Me.TextBox_OtherText.Enabled Then TextBox_OtherText_Leave(sender, e)

    End Sub
End Class
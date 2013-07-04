Imports System.Text.RegularExpressions

Public Class SearchForm


    ' Flags and common use variables.
    Private _searchLoopCompleted As Boolean
    Private _phrase As String
    Private _otherLanguages As Boolean
    Private _wholePhrase As Boolean
    Private _caseSensitive As Boolean
    Private _regularExpression As Regex


    ' Specific to search in design.
    Private _selectedNode As AdvNode
    Private _firstNode As AdvNode


    ' Specific to search in legal values.
    Private _selectedLegalValueIndex As Integer
    Private _selectedLegalValueItemIndex As Integer
    Private _legalValueIndex As Integer
    Private _legalValueItemIndex As Integer



#Region "Constructor and utility methods."


    ''' <summary>
    ''' Constructor to search in design.
    ''' </summary>
    ''' <param name="selectedNode">Selected node of the design tree.</param>
    ''' <remarks></remarks>

    Public Sub New(ByVal selectedNode As AdvNode)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Initialization of the UI.
        Me.SearchInComboBoxEx.SelectedItem = Me.SearchInDesignComboItem
        Me.SearchDirectionComboBoxEx.SelectedItem = Me.DirectionDownComboItem

        ' Add any initialization after the InitializeComponent() call.
        Me._regularExpression = Nothing
        Me._searchLoopCompleted = False

        ' Search in design variables.
        Me._selectedNode = selectedNode
        Me._firstNode = selectedNode

        ' Search in legal values variables.
        Me._legalValueIndex = 0
        Me._legalValueItemIndex = 0
        Me._selectedLegalValueIndex = 0
        Me._selectedLegalValueItemIndex = 0

    End Sub


    ''' <summary>
    ''' Search in each 
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Private Function IsMatch(ByVal obj As Object) As Boolean

        For Each prop As Reflection.PropertyInfo In obj.GetType.GetProperties

            ' If searching in all the languages, then look for matches in the dictionary...
            If Me._otherLanguages AndAlso prop.Name.ToLower.Contains("dictionary") Then

                Dim translations As Dictionary(Of String, String) = prop.GetValue(obj, Nothing)

                For Each translation As String In translations.Values

                    If IsPropertyMatch(translation) Then Return True

                Next

                ' If the property has no parameters...
            ElseIf prop.GetIndexParameters().Length = 0 Then

                Dim value As Object = prop.GetValue(obj, Nothing)

                If Not prop.PropertyType.ToString.Equals(ToStringOrEmpty(value)) _
                        AndAlso IsPropertyMatch(ToStringOrEmpty(value)) Then

                    Return True

                End If

            End If

        Next

        Return False

    End Function


    ''' <summary>
    ''' Determins if the phrase is match with the string depending of the options.
    ''' </summary>
    ''' <param name="characterString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Private Function IsPropertyMatch(ByVal characterString As String) As Boolean

        If Me._regularExpression IsNot Nothing Then

            Return Me._regularExpression.IsMatch(characterString)

        ElseIf Me._wholePhrase Then

            If Me._caseSensitive Then
                Return characterString.Equals(Me._phrase)
            Else
                Return characterString.ToLower.Equals(Me._phrase)
            End If

        Else

            If Me._caseSensitive Then
                Return characterString.Contains(Me._phrase)
            Else
                Return characterString.ToLower.Contains(Me._phrase.ToLower)
            End If

        End If

    End Function


    ''' <summary>
    ''' If the value is nothing returns empty string.
    ''' </summary>
    ''' <param name="value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Private Function ToStringOrEmpty(ByVal value As Object) As String

        If value IsNot Nothing Then

            Return value.ToString

        Else

            Return ""

        End If

    End Function


#End Region



#Region "Event handlers."

    ''' <summary>
    ''' Find next button click: Execute the search.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>

    Private Sub FindNextButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindNextButton.Click

        Me._phrase = Me.PhraseTextBoxX.Text.Trim()
        Me._otherLanguages = Me.UseTranslationsCheckBoxX.Checked
        Me._wholePhrase = Me.UseWholePhraseMatchingCheckBoxX.Checked
        Dim direction As Integer

        Select Case SearchDirectionComboBoxEx.SelectedIndex

            Case 1
                direction = 1

            Case 2
                direction = -1

            Case Else
                direction = 0

        End Select

        If Me.UseRegExpCheckBoxX.Checked Then

            If Me._wholePhrase AndAlso Not Me._phrase.StartsWith("^"c) Then Me._phrase = "^" & Me._phrase
            If Me._wholePhrase AndAlso Not Me._phrase.EndsWith("$"c) Then Me._phrase = Me._phrase & "$"

            Me._regularExpression = New Regex(Me._phrase)

        Else

            Me._regularExpression = Nothing

        End If

        If Me.SearchInComboBoxEx.SelectedItem.Equals(Me.SearchInDesignComboItem) Then

            CType(Me._selectedNode, AdvNode).TreeControl.SelectedNode = FindNextNode(direction)
            Me._selectedNode = CType(Me._selectedNode, AdvNode).TreeControl.SelectedNode

        ElseIf Me.SearchInComboBoxEx.SelectedItem.Equals(Me.SearchInLegalValuesComboItem) Then

            Me._selectedLegalValueIndex = Me._legalValueIndex
            Me._selectedLegalValueItemIndex = Me._legalValueItemIndex

            Dim editor As BO.ListEditorFrm = FindNextLegalValue(direction)
            If editor IsNot Nothing Then
                editor.ShowDialog()
                editor.UpdateInputList()
            End If

        End If

    End Sub


    ''' <summary>
    ''' Cancel button click: Closes the search form.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>

    Private Sub CancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelButton.Click

        Me.Close()

    End Sub


#End Region



#Region "Design Search methods."


    ''' <summary>
    ''' Search for the phrase in design recursive.
    ''' </summary>
    ''' <param name="direction">Direction to look for the next node.</param>
    ''' <remarks></remarks>

    Private Function FindNextNode(ByVal direction As Integer) As AdvNode

        Dim node As AdvNode

        If direction = -1 Then

            node = PrevNode(Me._selectedNode)

        Else

            node = NextNode(Me._selectedNode)

        End If

        While Not node.Equals(Me._selectedNode)

            If node.Equals(Me._firstNode) Then MessageBox.Show("Search loop in design completed.", "Search completed", MessageBoxButtons.OK, MessageBoxIcon.Information)

            If node.Tag IsNot Nothing AndAlso IsMatch(node.Tag) Then

                Return node

            End If

            ' Select the next or previous node...
            If direction = -1 Then

                node = PrevNode(node)

            Else

                node = NextNode(node)

            End If

        End While


        ' No match found in the hole design...
        MessageBox.Show("The search didn't found any matches in the study design.", "Search completed", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Return Me._selectedNode

    End Function


    ''' <summary>
    ''' Returns the next node, if is the last sibbling returns the next node from the parent.
    ''' </summary>
    ''' <param name="node"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Private Function NextNode(ByVal node As AdvNode) As AdvNode

        Dim index As Integer

        If node.Nodes.Count > 0 Then

            Return node.Nodes(0)

        ElseIf node.NextNode IsNot Nothing Then

            Return node.NextNode

        Else

            While node.Parent IsNot Nothing

                index = node.Index
                node = node.Parent

                If node.Nodes.Count > index + 1 Then

                    Return node.Nodes(index + 1)

                End If

            End While

            Return node

        End If

    End Function


    ''' <summary>
    ''' Returns the previous node, if is the first sibbling returns the previous node from the parent.
    ''' </summary>
    ''' <param name="node"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Private Function PrevNode(ByVal node As AdvNode) As AdvNode

        If node.PrevNode IsNot Nothing Then

            node = node.PrevNode

            While node.Nodes.Count > 0

                node = node.Nodes(node.Nodes.Count - 1)

            End While

            Return node

        ElseIf node.Parent IsNot Nothing Then

            Return node.Parent

        Else

            While node.Nodes.Count > 0

                node = node.Nodes(node.Nodes.Count - 1)

            End While

            Return node

        End If

    End Function


#End Region



#Region "Legal values search methods."


    ''' <summary>
    ''' Search in the legalValues tables and items for the phrase.
    ''' </summary>
    ''' <param name="direction"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Function FindNextLegalValue(ByVal direction As Integer) As BO.ListEditorFrm

        If BO.Study.LegalValues.Count = 0 Then Return Nothing
        Dim firstLoop As Boolean = True
        Dim count As Integer = 0

        While firstLoop OrElse Me._selectedLegalValueIndex <> Me._legalValueIndex OrElse Me._selectedLegalValueItemIndex <> Me._legalValueItemIndex

            count += 1
            Me._legalValueItemIndex += direction

            ' If Me._legalValueItemIndex out of range...
            If Me._legalValueItemIndex < 0 _
            OrElse Me._legalValueItemIndex > BO.Study.LegalValues(Me._legalValueIndex).LegalValues.Count - 1 Then

                ' Change to the next legal value table.
                If Me._legalValueItemIndex < 0 Then
                    Me._legalValueIndex -= 1

                ElseIf Me._legalValueItemIndex > BO.Study.LegalValues(Me._legalValueIndex).LegalValues.Count - 1 Then
                    Me._legalValueIndex += 1

                End If

                ' Check if the index is valid.
                If Me._legalValueIndex < 0 Then
                    Me._legalValueIndex = BO.Study.LegalValues.Count - 1

                ElseIf Me._legalValueIndex > BO.Study.LegalValues.Count - 1 Then
                    Me._legalValueIndex = 0

                End If

                ' Starts the item index.
                If Me._legalValueItemIndex < 0 Then
                    Me._legalValueItemIndex = BO.Study.LegalValues(Me._legalValueIndex).LegalValues.Count - 1

                Else
                    Me._legalValueItemIndex = 0

                End If

                ' If the legal value table is match...
                If IsMatch(BO.Study.LegalValues(Me._legalValueIndex)) Then

                    Dim nameProp As Reflection.PropertyInfo = GetType(BO.LegalValuesTable).GetProperty("Name")
                    Dim dialog As New BO.ListEditorFrm(BO.Study.LegalValues, GetType(BO.LegalValuesTable), "Legal values search result", Nothing, nameProp, True, False)
                    dialog.SelectedItem = BO.Study.LegalValues(Me._legalValueIndex)
                    Return dialog

                End If

            End If

            ' If the legal value item is match...
            If BO.Study.LegalValues(Me._legalValueIndex).LegalValues.Count > 0 _
            AndAlso IsMatch(BO.Study.LegalValues(Me._legalValueIndex).LegalValues(Me._legalValueItemIndex)) Then

                Dim valueProp As Reflection.PropertyInfo = GetType(BO.LegalValueItem).GetProperty("Value")
                Dim hiddenProp As Reflection.PropertyInfo = GetType(BO.LegalValueItem).GetProperty("Hidden")
                Dim title As String = BO.Study.LegalValues(Me._legalValueIndex).Name & " Legal values search result"
                Dim dialog As New BO.ListEditorFrm(BO.Study.LegalValues(Me._legalValueIndex).LegalValues, GetType(BO.LegalValueItem), title, hiddenProp, valueProp, False, False)
                dialog.SelectedItem = BO.Study.LegalValues(Me._legalValueIndex).LegalValues(Me._legalValueItemIndex)
                Return dialog

            End If

            firstLoop = False
        End While

        ' Only if the loop ends with no match.
        MessageBox.Show(count & " items checked. The search didn't found any matches in the legal values tables.", "Search completed", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Return Nothing

    End Function


#End Region



End Class
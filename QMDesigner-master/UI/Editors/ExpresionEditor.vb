Public Class ExpresionEditor



    ''' <summary>
    ''' Populates the interface and displays as dialog.
    ''' </summary>
    ''' <param name="expr">Expresion to be displayed.</param>
    ''' <param name="study">Current study.</param>
    ''' <param name="context">Selected object, to provide context information.</param>
    ''' <remarks></remarks>

    Public Sub Execute(ByVal expr As String, ByVal study As BO.Study, ByVal context As BO.GenericObject)

        ' Display the containers in it's tree.
        Dim rootNode As New AdvNode(study)
        rootNode.BuildContainersTree()
        treContainers.Nodes.Clear()
        treContainers.Nodes.Add(rootNode)

        ' Display the variables list.


        ' Display the interface.
        Me.txtExpresion.Text = expr

        ' Show the form.
        Me.ShowDialog()

    End Sub


    ''' <summary>
    ''' When the text changes, the tree is refreshed.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>

    Private Sub txtSearchContainers_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearchContainers.TextChanged

        RefreshTreContainers(treContainers.Nodes(0), Me.txtSearchContainers.Text.ToLower)

    End Sub


    ''' <summary>
    ''' Shows or hides the nodes in the containers tree.
    ''' </summary>
    ''' <remarks></remarks>

    Private Function RefreshTreContainers(ByVal node As AdvNode, ByRef phrase As String) As Boolean

        Dim visible As Boolean = False

        For Each child As AdvNode In node.Nodes

            visible = visible Or RefreshTreContainers(child, phrase)

        Next

        visible = visible Or node.Tag.Name.ToLower.Contains(phrase)
        node.Visible = visible
        node.Expand()

        Return visible

    End Function

End Class
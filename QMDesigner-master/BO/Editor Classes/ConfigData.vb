Public Class ConfigData

    ' Returns an array containing all the screen templates defined in the project resources.
    Shared ReadOnly Property ScreenTemplates() As String()
        Get
            Dim templates As New List(Of String)
            For Each template As BO.ScreenTemplate In BO.Study.ScreenTemplates
                templates.Add(template.Name)
            Next
            Return templates.ToArray
        End Get
    End Property

    ' Returns an array containing all the variable scopes defined in the project resources.
    Shared ReadOnly Property VariableScopes() As String()
        Get
            Return My.Resources.VariableScopes.Split(";")
        End Get
    End Property

    ' Returns an array conaining all the action types defined in the project resources.
    Shared ReadOnly Property ActionTypes() As String()
        Get
            Return My.Resources.ActionTypes.Split(";")
        End Get
    End Property
End Class

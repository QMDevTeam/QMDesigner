Imports System.ComponentModel

Public Class Subject


#Region "Properties"

    Private _name As String = ""
    Private _comment As String = ""
    Private _variables As New List(Of Variable)

    'Name Property
    <CategoryAttribute("(Main)"), _
    DisplayName("Name"), _
    DefaultValueAttribute("New Subject"), _
    DescriptionAttribute("Indicates the name of the subject.")> _
    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property

    'Comment Property
    <DisplayName("Comment"), _
    DefaultValueAttribute("[No comment]"), _
    DescriptionAttribute("Type a brief description of the subject.")> _
    Public Property Comment() As String
        Get
            Return _comment
        End Get
        Set(ByVal value As String)
            _comment = value
        End Set
    End Property

    'Variables Property
    <DisplayName("Variables"), _
    DescriptionAttribute("Read only list of the subject variables.")> _
    Public Property Variables() As List(Of Variable)
        Get
            Return _variables
        End Get
        Set(ByVal value As List(Of Variable))
            _variables = value
        End Set
    End Property


#End Region



#Region "Functions"

    Public Overrides Function ToString() As String
        If _name.Length = 0 Then
            Return "Subject"
        Else
            Return _name
        End If
    End Function

    ' Adds a variable to the collection.
    Public Sub AddVariable(ByVal name As String, ByVal datatype As String, ByVal absMin As String, _
    ByVal absMax As String, ByVal promptUnder As String, ByVal promptOver As String)
        Dim var As New Variable
        var.Name = name
        var.DataType = datatype
        var.AbsMin = absMin
        var.AbsMax = absMax
        var.PromptUnder = promptUnder
        var.PromptOver = promptOver

        For i As Integer = 0 To _variables.Count - 1
            If _variables(i).Name = var.Name Then
                Return
            ElseIf _variables(i).Name > var.Name Then
                _variables.Insert(i, var)
                Return
            End If
        Next

        _variables.Add(var)
    End Sub

    ' Removes a variable to the collection.
    Public Sub RemoveVariable(ByVal name As String)

        Dim i As Integer = 0
        For Each var As Variable In _variables

            If var.Name = name Then

                _variables.RemoveAt(i)
                Return
            Else

                i += 1
            End If
        Next
    End Sub

    ' Clears the subject variables.
    Public Sub ClearVariables()
        _variables.Clear()
    End Sub
#End Region


End Class

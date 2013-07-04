Public Class SQLCommandForm

    Private _dataManagerForm As DataManagerForm

    Public Property DataManagerF() As DataManagerForm
        Get
            Return _dataManagerForm
        End Get
        Set(ByVal value As DataManagerForm)
            _dataManagerForm = value
        End Set
    End Property

    Public Sub New(ByVal dataManagerF As DataManagerForm)
        _dataManagerForm = dataManagerF
        InitializeComponent()
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butClose.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butExecute.Click
        _dataManagerForm.ShowQueryResult(getQuery())
    End Sub

    Private Function getQuery() As String
        Return txtSQLQuery.Text
    End Function
End Class
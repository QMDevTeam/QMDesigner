Public Class CtlPdaReports

    Public TagToSave As New BO.Report

    Public Function PopulatePdaReports(ByVal Tag As BO.Report)

        TagToSave = Tag

        If Tag.Name Is Nothing Then
            Me.TxtReportName.Text = String.Empty
        Else
            Me.TxtReportName.Text = Tag.Name.ToString()
        End If

        If Tag.ReportType = 0 Then
            Me.CmbReportType.Text = String.Empty
        Else
            Me.CmbReportType.Text = Tag.ReportType.ToString()
        End If

        If Tag.FormTypeName Is Nothing Then
            Me.TxtTypeName.Text = String.Empty
        Else
            Me.TxtTypeName.Text = Tag.FormTypeName.ToString()
        End If

        If Tag.Query Is Nothing Then
            Me.TxtQuery.Text = String.Empty
        Else
            Me.TxtQuery.Text = Tag.Query.ToString()
        End If

        Me.TxtUniqueIdentifier.Text = Tag.Guid.ToString()


    End Function

    Public Function SaveChanges() As BO.Report

        TagToSave.Name = Me.TxtReportName.Text
        TagToSave.FormTypeName = Me.TxtTypeName.Text
        TagToSave.ReportType = CmbReportType.Text
        TagToSave.FormTypeName = TxtTypeName.Text
        TagToSave.Query = TxtQuery.Text

        Return TagToSave

    End Function

    Private Sub CtlPdaReports_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Dim ReportTypes As Array
        ReportTypes = System.Enum.GetNames(GetType(BO.ReportType))
        CmbReportType.Items.Clear()

        For Each type As String In ReportTypes
            CmbReportType.Items.Add(type)
        Next

    End Sub

    Private Sub BtnReportName_Click(sender As System.Object, e As System.EventArgs) Handles BtnReportName.Click
        TxtReportName.Text = CodeEditorForm.GetString(TxtReportName.Text)
    End Sub

    Private Sub BtnQuery_Click(sender As System.Object, e As System.EventArgs) Handles BtnQuery.Click
        TxtQuery.Text = CodeEditorForm.GetString(TxtQuery.Text)
    End Sub
End Class

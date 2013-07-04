Imports System.Windows.Forms
Imports DevComponents.DotNetBar

Public Class ReviewChangesDialog

    Private _tablesToChange As List(Of TableInfo)
    Private _mainDB As MainDatabase
    Private _externalDB As ExternalDatabase
    Private taskDialogInfo As TaskDialogInfo = New TaskDialogInfo("Warning - Review Changes", eTaskDialogIcon.Exclamation, _
                                                                 "Comments", "Some selected changes have a comment but you are assigning a comment to the selected changes.<br/>Do you want to continue?", _
                                                                eTaskDialogButton.Yes Or eTaskDialogButton.No, eTaskDialogBackgroundColor.Tan)

    Public Property TablesToChange() As List(Of TableInfo)
        Get
            Return _tablesToChange
        End Get
        Set(ByVal value As List(Of TableInfo))
            _tablesToChange = value
        End Set
    End Property

    Public Sub SetTargetDataBase(ByVal mainDB As MainDatabase)

        _mainDB = mainDB
        _externalDB = Nothing
        uxTableNameDataColumn.DataPropertyName = "DataTableName"

    End Sub

    Public Sub SetTargetDataBase(ByVal externalDB As ExternalDatabase)

        _mainDB = Nothing
        _externalDB = externalDB
        uxTableNameDataColumn.DataPropertyName = "PDATableName"

    End Sub


    Public Sub New(ByVal tablesToChange As List(Of TableInfo))


        _tablesToChange = tablesToChange

        Me.InitializeComponent()

        uxChangesDataGridView.AutoGenerateColumns = False
        uxChangesDataGridView.DataSource = uxReviewDataSource

        uxAcceptColumn.DataPropertyName = "Accept"
        uxSubjectID.DataPropertyName = "SubjectID"
        uxSubjectQuestionnaireInstanceIDDataColumn.DataPropertyName = "SubjectQuestionnaireInstanceID"
        uxColumnNameDataColumn.DataPropertyName = "ColumnName"
        uxOldValueDataColumn.DataPropertyName = "OldValue"
        uxNewValueDataColumn.DataPropertyName = "NewValue"
        uxCommentDataColumn.DataPropertyName = "Comment"

        For Each table As TableInfo In _tablesToChange

            For Each row As RowInfo In table.RowsToModify.Values

                Dim subjectID As Guid
                Dim subjectQuestionnaireInstanceID As Byte
                Dim useSubjectQuestionnaireInstanceID As Boolean = False

                For Each key As KeyInfo In table.Keys.Values

                    If key.Name.ToLower = "subjectid" Then
                        subjectID = CType(row.GetKeyValue(key), Guid)
                    ElseIf key.Name.ToLower = "subjectQuestionnaireInstanceID".ToLower Then
                        subjectQuestionnaireInstanceID = Byte.Parse(row.GetKeyValue(key).ToString)
                        useSubjectQuestionnaireInstanceID = True
                    End If

                Next

                For Each cell As CellInfo In row.CellsToModify.Values

                    ReviewDataSet.Review.AddReviewRow(True, subjectID, subjectQuestionnaireInstanceID, table.DataTableName, _
                                                        cell.Column.Name, cell.OldValue.ToString, cell.NewValue.ToString, "", _
                                                        useSubjectQuestionnaireInstanceID, table.LogTableName, table.PDATableName, _
                                                        row.RowIndex, cell.Column.AliasName)

                Next

            Next

        Next

    End Sub


    Private Function GetDataTable(ByVal query As String) As DataTable

        If _mainDB IsNot Nothing Then

            Return _mainDB.GetDataTable(query)

        ElseIf _externalDB IsNot Nothing Then

            Return _externalDB.GetDataTable(query)

        End If

        Return Nothing

    End Function


    Private Sub ExecuteNonQuery(ByVal query As String)

        If _mainDB IsNot Nothing Then

            _mainDB.ExecuteNonQuery(query)

        ElseIf _externalDB IsNot Nothing Then

            _externalDB.ExecuteNonQuery(query)

        End If

    End Sub


    Private Function GetListColumnsLog(ByVal logTable As String) As String

        Dim querySelectColumnsOfLogTable As String = "SELECT Column_Name FROM INFORMATION_SCHEMA.columns WHERE Table_Name = '{0}' AND NOT (Column_Name = 'LogUser' OR Column_Name = 'LogDate' OR Column_Name = 'LogMsg')"
        Dim list As String = ""
        For Each row As DataRow In GetDataTable(String.Format(querySelectColumnsOfLogTable, logTable)).Rows

            list &= String.Format("[{0}],", row.Item("Column_Name").ToString)

        Next

        If list.Length > 0 Then
            list = list.Remove(list.Length - 1)
        End If

        Return list

    End Function


    Private Sub CommitAcceptedChanges()

        'Used to build the query to insert a row in the Log Table
        Dim listOfColumnsLog As String = ""
        Dim query As String
        Dim dataRowToDelete As New List(Of ReviewDataSet.ReviewRow)

        For Each datarow As ReviewDataSet.ReviewRow In ReviewDataSet.Review.Rows

            If datarow.Accept Then

                If _mainDB IsNot Nothing Then

                    'Build and Execute Log(query)
                    listOfColumnsLog = GetListColumnsLog(datarow.LogTableName)
                    query = BuildLogQuery(datarow, listOfColumnsLog)
                    ExecuteNonQuery(query)

                End If

                'Build and Execute Update Query
                query = BuildUpdateQuery(datarow)
                ExecuteNonQuery(query)

                'Delete the row from the DataGrid
                dataRowToDelete.Add(datarow)

            End If

        Next

        For Each DataRow As ReviewDataSet.ReviewRow In dataRowToDelete

            DataRow.Delete()

        Next

    End Sub



    Private Function BuildUpdateQuery(ByVal row As ReviewDataSet.ReviewRow) As String

        Dim updateTable As String
        Dim comment As String = IIf(rbtCommentSelected.Checked, txtComment.Text, row.Comment).ToString

        If _mainDB IsNot Nothing Then
            updateTable = String.Format("[{0}].[{1}]", BO.ContextClass.Study.DataTableSchema, row.DataTableName)
        Else
            updateTable = String.Format("[{0}]", row.PDATableName)
        End If

        Dim query As String = String.Format("UPDATE {0} SET ", updateTable)

        ' New value of the cell
        If row.NewValue Is Nothing OrElse String.IsNullOrEmpty(row.NewValue.ToString) Then
            query &= String.Format(" [{0}] = NULL, ", row.ColumnName)
        Else
            query &= String.Format(" [{0}] = '{1}', ", row.ColumnName, row.NewValue.ToString)
        End If

        ' Audit Trail columns.
        If _mainDB IsNot Nothing Then
            query &= String.Format(" [UpdateVersion] = [UpdateVersion]+1, [DBModifDate]= GETDATE(),[DBModifUser]= SUSER_SNAME(),[DBModifMsg] = 'DataManager: ''{0}'', [{1}]' ", comment, row.ColumnName)
            'Else
            ' query &= String.Format(" [UpdateVersion] = [UpdateVersion]+1, [DBModifDate]='{0}',[DBModifUser]='{1}',[DBModifMsg] = 'DataManager: ''{2}'', [{3}]' ", _
            '                           DateTime.Now.ToString("yyyyMMdd hh:mm:ss"), System.Environment.UserName, row.Comment, row.ColumnName)
        End If

        ' Filter of the Update
        query &= " WHERE "
        query &= String.Format(" [SubjectID] = '{0}' ", row.SubjectID)
        If row.UseSubjectQuestionnaireInstanceID Then
            query &= String.Format(" AND [SubjectQuestionnaireInstanceID] = '{0}' ", row.SubjectQuestionnaireInstanceID)
        End If

        Return query

    End Function


    ''' <summary>
    ''' Build the Query that insert a new row in the Log Table, (works only when the _dataSource is MainDB)
    ''' </summary>
    ''' <param name="row"></param>
    ''' <param name="listColumns"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function BuildLogQuery(ByVal row As ReviewDataSet.ReviewRow, ByVal listColumns As String) As String

        Dim columnsToCopyToLog As List(Of String) = New List(Of String)
        Dim query As String
        Dim comment As String = IIf(rbtCommentSelected.Checked, txtComment.Text, row.Comment).ToString

        'Build the Insert Queyr
        query = String.Format("INSERT INTO [{0}].[{1}] ", BO.ContextClass.Study.LogTableSchema, row.LogTableName)
        'Columns to Insert
        query &= String.Format(" ({0}, [LogUser],[LogDate],[LogMsg]) ", listColumns)

        'Select Data that will be inserted in the Log Table
        query &= String.Format(" SELECT {0}, SUSER_SNAME(), GETDATE(), 'DataManager: ''{1}'', [{2}]' ", listColumns, comment, row.ColumnName)
        query &= String.Format(" FROM [{0}].[{1}] ", BO.ContextClass.Study.DataTableSchema, row.DataTableName)

        'Build the Where section of the query (keys)
        query &= " WHERE "
        query &= String.Format(" [SubjectID] = '{0}' ", row.SubjectID)
        If row.UseSubjectQuestionnaireInstanceID Then
            query &= String.Format(" AND [SubjectQuestionnaireInstanceID] = '{0}' ", row.SubjectQuestionnaireInstanceID)
        End If

        Return query

    End Function


    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        Dim confimed As Boolean = True

        If rbtCommentSelected.Checked Then

            For Each row As ReviewDataSet.ReviewRow In ReviewDataSet.Review.Rows

                If row.Accept And Not String.IsNullOrEmpty(row.Comment) Then

                    taskDialogInfo.Header = "Comments"
                    taskDialogInfo.Text = "Some selected changes have a comment but you are assigning a comment to the selected changes.<br/>Do you want to continue?"

                    confimed = DevComponents.DotNetBar.TaskDialog.Show(taskDialogInfo) = eTaskDialogResult.Yes

                    Exit For

                End If

            Next

        End If

        If confimed Then

            CommitAcceptedChanges()

            If ReviewDataSet.Review.Rows.Count = 0 Then

                Me.DialogResult = Windows.Forms.DialogResult.Yes
                Me.Close()

            End If

        End If

    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click

        taskDialogInfo.Header = "Discard Changes"
        taskDialogInfo.Text = "Do you want to discard the remaining changes?"

        If TaskDialog.Show(taskDialogInfo) = eTaskDialogResult.Yes Then

            Me.DialogResult = Windows.Forms.DialogResult.No
            Me.Close()

        End If

    End Sub

    Private Sub ckbUn_SelectAll_CheckedChangedEx(ByVal sender As System.Object, ByVal e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles ckbUn_SelectAll.CheckedChangedEx

        Dim checkBox As DevComponents.DotNetBar.Controls.CheckBoxX = TryCast(sender, DevComponents.DotNetBar.Controls.CheckBoxX)

        If checkBox IsNot Nothing Then

            If e.EventSource <> DevComponents.DotNetBar.eEventSource.Code Then

                For Each row As ReviewDataSet.ReviewRow In ReviewDataSet.Review.Rows

                    row.Accept = checkBox.Checked

                Next

            End If

        End If
    End Sub

    Private Sub butCommentAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim editMsgFrm As New EditMessageFrm
        Dim message As String = editMsgFrm.GetMessage()

        For Each row As ReviewDataSet.ReviewRow In ReviewDataSet.Review.Rows

            If row.Accept Then

                row.Comment = message

            End If

        Next

    End Sub

    Private Sub rbtCommentSelected_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtCommentSelected.CheckedChanged
        If rbtCommentSelected.Checked Then
            uxCommentDataColumn.ReadOnly = True
            txtComment.ReadOnly = False
        End If
    End Sub

    Private Sub rbtCommentOneByOne_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtCommentOneByOne.CheckedChanged
        If rbtCommentOneByOne.Checked Then
            uxCommentDataColumn.ReadOnly = False
            txtComment.ReadOnly = True
        End If
    End Sub

End Class

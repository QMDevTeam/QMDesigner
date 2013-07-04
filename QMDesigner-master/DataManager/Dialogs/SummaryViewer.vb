Imports DevComponents.DotNetBar.Controls

Public Class SummaryViewer

#Region "Private Members"

    Private _filesStatistics As List(Of FileStatistic)

#End Region


#Region " Private Methods "

    ''' <summary>
    ''' Initializes column 'Save Details'
    ''' </summary>
    Private Sub SaveDetailsColumn_Initialize()
        Dim bcx As DataGridViewButtonXColumn = TryCast(uxSummaryDataGridView.Columns("SaveDetailsColumn"), DataGridViewButtonXColumn)

        If bcx IsNot Nothing Then

            ' We want to be able to specify our own button text
            ' instead of using the bound data value for the text

            bcx.UseColumnTextForButtonValue = False

            ' Hook onto the following events so we can
            ' demonstrate cell customization and click processing

            AddHandler SaveDetailsColumn.BeforeCellPaint, AddressOf SaveDetailsColumn_BeforeCellPaint
            AddHandler SaveDetailsColumn.Click, AddressOf SaveDetailsColumn_Click


        End If
    End Sub

#End Region

#Region " Public Methods "

    Public Sub New(ByVal GlobalStatistics As List(Of FileStatistic))

        'Initialize components
        InitializeComponent()
        SaveDetailsColumn_Initialize()

        butSaveErrors.Enabled = False

        SummaryDataSet1.Clear()

        _filesStatistics = New List(Of FileStatistic)
        _filesStatistics.AddRange(GlobalStatistics)

        Dim fileSummary As TableStatistic


        For Each fileStatistic As FileStatistic In GlobalStatistics

            fileSummary = fileStatistic.SummaryStatistic

            If fileSummary.Errors.Count > 0 Then

                butSaveErrors.Enabled = True

            End If

            SummaryDataSet1.Summary.AddSummaryRow(fileStatistic.Name, fileSummary.Inserted, fileSummary.Updated, fileStatistic.BeginTime, fileStatistic.EndTime)

        Next

    End Sub


#End Region

#Region " Event Handlers "

    ''' <summary>
    ''' Close the Dialog (Click in Acept button)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub butAcept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butAcept.Click

        Me.Close()
        Me.DialogResult = Windows.Forms.DialogResult.OK

    End Sub


    Private Sub butSaveErrors_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butSaveErrors.Click

        If ErrorsSaveFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then

            If IO.File.Exists(ErrorsSaveFileDialog.FileName) Then
                IO.File.Delete(ErrorsSaveFileDialog.FileName)
            End If

            Dim writer As New System.IO.StreamWriter(ErrorsSaveFileDialog.FileName, False)

            writer.WriteLine("ERRORS")
            writer.WriteLine("")
            writer.WriteLine("File,Table,Time of Error,SubjectID,SubjectQuestionnaireInstanceID,Action,Error")

            For Each currentFileStatistic As FileStatistic In _filesStatistics

                'Gather the statistics of the tables
                Dim fileSummarylStatistic As TableStatistic = currentFileStatistic.SummaryStatistic

                'Build an error message if there is an error
                If fileSummarylStatistic.Errors.Count > 0 Then

                    For Each currentTableStatistic As TableStatistic In currentFileStatistic.Statistics

                        If currentTableStatistic.Errors.Count > 0 Then

                            For Each errorRegistry As ErrorRegister In currentTableStatistic.Errors

                                'Error Detail
                                writer.WriteLine(String.Format("""{0}"",""{1}"",""{2}"",""{3}"",""{4}"",""{5}"",""{6}""", _
                                                    currentFileStatistic.Name, _
                                                    currentTableStatistic.Name, _
                                                    errorRegistry.TimeOfError.ToString("dd/MM/yyyy hh:mm:ss"), _
                                                    errorRegistry.SubjectID, _
                                                    IIf(errorRegistry.SubjectQuestionnaireInstanceID >= 0, errorRegistry.SubjectQuestionnaireInstanceID.ToString, "").ToString, _
                                                    errorRegistry.Action, _
                                                    errorRegistry.ErrorMessage))

                            Next

                        End If

                    Next

                End If

            Next

            writer.Close()

        End If

    End Sub


    Private Sub SaveDetailsColumn_Click(ByVal sender As Object, ByVal e As EventArgs)

        Dim cell As DataGridViewButtonXCell = TryCast(uxSummaryDataGridView.CurrentCell, DataGridViewButtonXCell)

        If cell IsNot Nothing Then

            If DetailsSaveFileDialog.ShowDialog = Windows.Forms.DialogResult.OK Then

                Dim inserted As New System.Text.StringBuilder
                Dim updated As New System.Text.StringBuilder

                If IO.File.Exists(DetailsSaveFileDialog.FileName) Then
                    IO.File.Delete(DetailsSaveFileDialog.FileName)
                End If

                Dim writer As New IO.StreamWriter(DetailsSaveFileDialog.FileName, False)

                For Each currentFile As FileStatistic In _filesStatistics

                    If currentFile.Name.Trim.Equals(uxSummaryDataGridView.Rows(cell.RowIndex).Cells("FileNameDataGridViewTextBoxColumn").Value.ToString.Trim) Then

                        writer.WriteLine("File: , """ & currentFile.Name & """")
                        writer.WriteLine("Import Start Date:, """ & currentFile.BeginTime.ToString("dd/MM/yyyy hh:mm:ss") & """")
                        writer.WriteLine("Import End Date:, """ & currentFile.EndTime.ToString("dd/MM/yyyy hh:mm:ss") & """")
                        writer.WriteLine("")
                        writer.WriteLine("Table,Inserted,Updated")

                        For Each currentTableStatistic As TableStatistic In currentFile.Statistics

                            writer.WriteLine(String.Format("""{0}"",{1},{2}", currentTableStatistic.Name, currentTableStatistic.Inserted.ToString, currentTableStatistic.Updated.ToString))

                        Next

                        Exit For

                    End If

                Next

                writer.Flush()
                writer.Close()
                writer.Dispose()

            End If

        End If

    End Sub


    Private Sub SaveDetailsColumn_BeforeCellPaint(ByVal sender As Object, ByVal e As BeforeCellPaintEventArgs)
        Dim bcx As DataGridViewButtonXColumn = TryCast(sender, DataGridViewButtonXColumn)

        If bcx IsNot Nothing Then
            ' If the cell text is in our _ContactTypes list, then
            ' give our button a default background - otherwise not.

            bcx.Text = "Save Details"

        End If

    End Sub

#End Region

End Class
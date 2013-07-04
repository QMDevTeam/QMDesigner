
''' <summary>
''' Columns to be shown in the DataDictionary by Question
''' </summary>
''' <remarks> 
''' If you want to change the order just change the numbers in the Enum
''' </remarks>
Public Enum DataByQuestion As Integer
    QuestionnaireSet = 1
    Questionnaire = 2
    Section = 3
    Question_Number = 4
    Variable_Name = 5
    Main_Text = 6 ' With GroupText
    Data_Type = 7
    Range = 8
    Legal_Value = 9
    Required_Field = 10
    Variable_Scope = 11
    Data_Table = 12
End Enum

''' <summary>
''' Columns to be shown in the DataDictionary by Variable
''' </summary>
''' <remarks> 
''' If you want to change the order just change the numbers in the Enum
''' </remarks>
Public Enum DataByVariable As Integer
    Main_Text = 2 ' With GroupText
    Legal_Value = 4
    Data_Type = 3
    Variable_Name = 1
    Range = 5
    Location = 6 ' Format of Location = "QuestionnaireSet - Questionnaire - Section - Number"
    Data_Table = 7
End Enum

''' <summary>
''' Columns to be shown in the tables of the LegalValues
''' </summary>
''' <remarks>
''' If you want to change the order just change the numbers in the Enum
''' </remarks>
Public Enum DataLegalValue As Integer
    Value = 1
    Text = 2
End Enum

''' <summary>
''' Encapsulates a variable used in the generation of the DataDictionary by Question
''' </summary>
Public Class QuestionDataDictionary

    Public QuestionnaireSet As String
    Public Questionnaire As String
    Public Section As String
    Public Question_Number As String
    Public Variable_Name As String
    Public Main_Text As String ' With GroupText
    Public Data_Type As String
    Public Range As String
    Public Legal_Value As String
    Public Required_Field As String
    Public Variable_Scope As String
    Public Data_Table As String

End Class

''' <summary>
''' Encapsulates a variable used in the generation of the DataDictionary by Variable
''' </summary>
''' <remarks>
''' Used to keep the tracking of the questions that use each variable
''' </remarks>
Public Class VariableDataDictionary
    Public Main_Text As String
    Public Legal_Value As String
    Public Data_Type As String
    Public Variable_Name As String
    Public Range As String
    Public Location As String ' Format of Location = "QuestionnaireSet - Questionnaire - Section - Number"
    Public Data_Table As String

End Class

''' <summary>
''' Encapsulates a list of Legal Values of the DataDictionary and the methods
''' that the Data Dictionary needs from the list of Legal Values.
''' </summary>
''' <remarks></remarks>
Public Class DataDictionaryLegalValues

#Region " Private Properties "

    Private Const Objectc_rgszShEachLV As String = "c_rgszSh[{#LV}] = ""{LegalValue_Name}""" & vbCrLf
    Private Const ExcelWorksheetsLVs As String = "<x:ExcelWorksheet>" & vbCrLf & _
                                                    "<x:Name>{LegalValue_Name}</x:Name>" & vbCrLf & _
                                                    "<x:WorksheetSource HRef=""{FileName}_files/sheet{#LV+1}.htm""/>" & vbCrLf & _
                                                 "</x:ExcelWorksheet>" & vbCrLf
    Private Const HRefFileEachLV As String = "<o:File HRef=""sheet{#LV+1}.htm""/>" & vbCrLf
    Private Const LinkFilEachLV As String = "<td bgcolor=""#FFFFFF"" nowrap><b><small><small>&nbsp;<a href=""sheet{#LV+1}.htm"" target=""frSheet""><font face=""Arial"" color=""#000000"">{LegalValue_Name}</font></a>&nbsp;</small></small></b></td>" & vbCrLf
    Private Const LVItem As String = "<tr height=18 style='height:13.5pt'>" & vbCrLf & _
                                        "<td height=18 class=xl29 style='height:13.5pt'>{Value}</td>" & vbCrLf & _
                                        "<td class=xl30 style='border-left:none'>{Text}</td>" & vbCrLf & _
                                     "</tr>" & vbCrLf

    Private Const FormatLVNumberForHtm = "D3"
    Private Const LVFileName As String = "sheet{#LV+1}.htm"
    Private Const LinkHRefEachLV As String = "<link id=""shLink"" href=""{FileName}_files/sheet{#LV+1}.htm"" > " & vbCrLf

    Private legalValues As Dictionary(Of BO.LegalValuesTable, String)
    Private fileName As String
    Private folder As String

#End Region

#Region " Public Methods "

    Public ReadOnly Property Count() As Integer
        Get
            Return legalValues.Count
        End Get
    End Property

    Public Sub New(ByVal _fileName As String)
        legalValues = New Dictionary(Of BO.LegalValuesTable, String)
        fileName = _fileName
    End Sub

    Public Sub AddLegalValues(ByVal LVs As BO.LegalValuesTable, ByVal SheetName As String)

        legalValues.Add(LVs, SheetName)

    End Sub

    Public Function GetSheetName(ByVal LVs As BO.LegalValuesTable)

        Dim sheetName As String = ""

        If legalValues.TryGetValue(LVs, sheetName) Then
            Return sheetName
        Else
            Return ""
        End If

    End Function

    Public Function ContainsSheetName(ByVal sheetName As String) As Boolean

        Return legalValues.ContainsValue(sheetName)

    End Function

    Public Function GetObjectc_rgszShEachLV() As String

        Dim returnString As New System.Text.StringBuilder
        Dim tempString As String = ""
        Dim currentLVNumber As Integer = 1

        For Each LV As BO.LegalValuesTable In legalValues.Keys

            tempString = Objectc_rgszShEachLV
            tempString = tempString.Replace("{#LV}", currentLVNumber.ToString())
            tempString = tempString.Replace("{LegalValue_Name}", legalValues(LV))
            tempString = tempString.Replace("{FileName}", Me.fileName)

            returnString.Append(tempString)
            currentLVNumber += 1

        Next

        Return returnString.ToString

    End Function

    Public Function GetExcelWorksheetsLVs() As String

        Dim returnString As New System.Text.StringBuilder
        Dim tempString As String = ""
        Dim currentLVNumber As Integer = 2


        For Each LV As BO.LegalValuesTable In legalValues.Keys

            tempString = ExcelWorksheetsLVs
            tempString = tempString.Replace("{#LV+1}", currentLVNumber.ToString(FormatLVNumberForHtm))
            tempString = tempString.Replace("{LegalValue_Name}", legalValues(LV))
            tempString = tempString.Replace("{FileName}", Me.fileName)


            returnString.Append(tempString)
            currentLVNumber += 1

        Next

        Return returnString.ToString

    End Function

    Public Function GetHRefFileEachLV() As String

        Dim returnString As New System.Text.StringBuilder
        Dim tempString As String = ""
        Dim currentLVNumber As Integer = 2


        For Each LV As BO.LegalValuesTable In legalValues.Keys

            tempString = HRefFileEachLV
            tempString = tempString.Replace("{#LV+1}", currentLVNumber.ToString(FormatLVNumberForHtm))
            returnString.Append(tempString)
            currentLVNumber += 1

        Next

        Return returnString.ToString

    End Function

    Public Function GetLinkFileEachLV() As String

        Dim returnString As New System.Text.StringBuilder
        Dim tempString As String = ""
        Dim currentLVNumber As Integer = 2

        For Each LV As BO.LegalValuesTable In legalValues.Keys

            tempString = LinkFilEachLV
            tempString = tempString.Replace("{#LV+1}", currentLVNumber.ToString(FormatLVNumberForHtm))
            tempString = tempString.Replace("{LegalValue_Name}", legalValues(LV))
            tempString = tempString.Replace("{FileName}", Me.fileName)

            returnString.Append(tempString)
            currentLVNumber += 1

        Next

        Return returnString.ToString

    End Function

    Public Function GetLinkHRefEachLV() As String

        Dim returnString As New System.Text.StringBuilder
        Dim tempString As String = ""
        Dim currentLVNumber As Integer = 2


        For Each LV As BO.LegalValuesTable In legalValues.Keys

            tempString = LinkHRefEachLV
            tempString = tempString.Replace("{#LV+1}", currentLVNumber.ToString(FormatLVNumberForHtm))
            tempString = tempString.Replace("{FileName}", Me.fileName)

            returnString.Append(tempString)
            currentLVNumber += 1

        Next

        Return returnString.ToString

    End Function

    Private Function GetLVItem(ByVal LV As BO.LegalValuesTable) As String

        Dim returnString As New System.Text.StringBuilder
        Dim tempString As String = ""


        For Each currentLVItem As BO.LegalValueItem In LV.LegalValues

            tempString = LVItem
            tempString = tempString.Replace("{Value}", currentLVItem.Value)
            tempString = tempString.Replace("{Text}", currentLVItem.Text)

            returnString.Append(tempString)

        Next

        Return returnString.ToString

    End Function

    Public Sub GenerateHTMFiles(ByVal folder As String, ByVal sourceFolder As String)

        Dim currentLVFileName As String
        Dim contentLVFile As String = ""
        Dim ZeroBaseCounter As Integer = 0
        Dim reader As New System.IO.StreamReader(sourceFolder & "\{FileName}_files\sheet00{#LV+1}.htm")
        Dim writer As System.IO.StreamWriter
        Dim genericContent As String = reader.ReadToEnd

        reader.Close()

        For Each LV As BO.LegalValuesTable In legalValues.Keys

            currentLVFileName = LVFileName.Replace("{#LV+1}", (ZeroBaseCounter + 2).ToString(FormatLVNumberForHtm))
            contentLVFile = genericContent

            contentLVFile = contentLVFile.Replace("{LVItems}", GetLVItem(LV))
            contentLVFile = contentLVFile.Replace("{FileName}", fileName)
            contentLVFile = contentLVFile.Replace("{#LV}", (ZeroBaseCounter + 1).ToString)
            contentLVFile = contentLVFile.Replace("{LegalValue_Name}", legalValues(LV))

            writer = New System.IO.StreamWriter(folder & "\" & currentLVFileName, False, System.Text.Encoding.UTF8)
            writer.Write(contentLVFile)
            writer.Flush()
            writer.Close()

            ZeroBaseCounter += 1

        Next

    End Sub

#End Region

End Class



Public Class DataDictionary

#Region " Private Properties "

    Private Const TRsVariables = "<tr height=18 style='height:13.5pt'>" & vbCrLf & _
                                  "<td height=18 class=xl31 width=210 style='height:13.5pt;width:158pt'>{VariableName}</td>" & vbCrLf & _
                                  "<td class=xl32 width=670 style='border-left:none;width:503pt'>{MainText}</td>" & vbCrLf & _
                                  "<td class=xl32 width=140 style='border-left:none;width:105pt'>{DataType}</td>" & vbCrLf & _
                                  "<td class=xl32 width=211 style='border-left:none;width:158pt'>{LegalValue}</td>" & vbCrLf & _
                                  "<td class=xl32 width=121 style='border-left:none;width:91pt'>{Range}</td>" & vbCrLf & _
                                  "<td class=xl32 width=249 style='border-left:none;width:187pt'>{Location}</td>" & vbCrLf & _
                                  "<td class=xl33 width=109 style='border-left:none;width:82pt'>{DataTable}</td>" & vbCrLf & _
                                 "</tr>" & vbCrLf

    Private Const TRsQuestions = " <tr height=30 style='mso-height-source:userset;height:22.5pt'>" & vbCrLf & _
                                  "<td height=30 class=xl31 width=144 style='height:22.5pt;border-top:none;width:108pt'>{QuestionnaireSet}</td>" & vbCrLf & _
                                  "<td class=xl32 width=130 style='border-top:none;border-left:none;width:98pt'>{Questionnaire}</td>" & vbCrLf & _
                                  "<td class=xl32 width=177 style='border-top:none;border-left:none;width:133pt'>{Section}</td>" & vbCrLf & _
                                  "<td class=xl32 width=119 style='border-top:none;border-left:none;width:89pt'>{Question Number}</td>" & vbCrLf & _
                                  "<td class=xl32 width=175 style='border-top:none;border-left:none;width:231pt'>{Variable Name}</td>" & vbCrLf & _
                                  "<td class=xl32 width=476 style='border-top:none;border-left:none;width:357pt'>{Main Text}</td>" & vbCrLf & _
                                  "<td class=xl32 width=71 style='border-top:none;border-left:none;width:53pt'>{Data Type}</td>" & vbCrLf & _
                                  "<td class=xl32 width=84 style='border-top:none;border-left:none;width:63pt'>{Range}</td>" & vbCrLf & _
                                  "<td class=xl32 width=315 style='border-top:none;border-left:none;width:336pt'>{Legal Value}</td>" & vbCrLf & _
                                  "<td class=xl32 width=102 style='border-top:none;border-left:none;width:77pt'>{Required Field}</td>" & vbCrLf & _
                                  "<td class=xl32 width=106 style='border-top:none;border-left:none;width:80pt'>{Variable Scope}</td>" & vbCrLf & _
                                  "<td class=xl32 width=103 style='border-top:none;border-left:none;width:77pt'>{Data Table}</td>" & vbCrLf & _
                                 "</tr>" & vbCrLf

    Private dataTable As String = ""
    Private procecedLegalValues As DataDictionaryLegalValues
    Private filePath As String

    Private ReadOnly Property Now() As String
        Get
            Return Date.Now.ToString("yyyy-MM-ddThh-mm-ssZ")
        End Get
    End Property

    Private ReadOnly Property FileName() As String
        Get

            If filePath.LastIndexOf(".") >= 0 Then

                Return filePath.Substring(filePath.LastIndexOf("\") + 1, filePath.LastIndexOf(".") - filePath.LastIndexOf("\") - 1)

            Else

                Return filePath.Substring(filePath.LastIndexOf("\") + 1)

            End If
        End Get
    End Property

    Private ReadOnly Property User() As String
        Get
            Return Environment.UserName
        End Get
    End Property

#End Region

#Region " Private Methods "

    ''' <summary>
    ''' Initalize the Workbook of excel
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

    End Sub

    ''' <summary>
    ''' Convert the DataType from SQL to Human Language
    ''' </summary>
    ''' <param name="currentQuestion"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function WriteDataType(ByVal currentQuestion As BO.Question) As String
        Dim returnString As String = ""

        Select Case currentQuestion.DataType
            Case "bit"
                returnString = "True/False"
            Case "datetime"
                returnString = currentQuestion.ScreenTemplate
            Case Else
                returnString = currentQuestion.DataType.ToLower.Replace("nvarchar", "Text")
        End Select

        Return returnString
    End Function

    ''' <summary>
    ''' Returns the text of a LegalValue to write in the cell of a Question or Variable
    ''' </summary>
    ''' <param name="legalValues"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' If there is more than 15 items int he legalValue, a new sheet is created with all the items of the legalValue
    ''' </remarks>
    Private Function registerLegalValues(ByVal legalValues As BO.LegalValuesTable) As String

        Dim returnString As String = ""
        Dim sheetName As String = ""
        Dim count As Integer = 1
        Dim temporalSheetName As String = ""

        ' Check if the legalValue exists
        If legalValues IsNot Nothing Then

            'Sort the Legal Values
            'legalValues.LegalValues.Sort(AddressOf PreviewClass.CompareLegalValueItemsByText)

            ' If the legal values are less than 15 return all the items.
            If legalValues.LegalValues.Count <= 15 Then

                For Each currentLegalValueItem As BO.LegalValueItem In legalValues.LegalValues

                    returnString &= String.Format("{1}-{0}<br />", currentLegalValueItem.Text, currentLegalValueItem.Value.ToString) & vbLf

                Next

                ' remove the last vbLf
                If returnString.Length > 0 Then
                    returnString = returnString.Substring(0, returnString.Length - 7)
                End If

            Else

                'If there are more than 15 legal value items, we have to store the LV in _longLegalValues 
                '  to create a new sheet with the items of the legalValue

                sheetName = procecedLegalValues.GetSheetName(legalValues)
                If String.IsNullOrEmpty(sheetName) Then


                    'Obtain a valid Sheet Name
                    ' The Name of a Sheet cant be more than 31 characters, 
                    'cant be blank and 
                    'cant contain : \ / ? * [ or ]

                    sheetName = legalValues.Name.Replace(":", "").Replace("\", "").Replace("/", "").Replace("?", "").Replace("*", "").Replace("[", "").Replace("]", "")
                    If sheetName.Length > 31 Then
                        sheetName = sheetName.Substring(0, 31)
                    End If
                    If String.IsNullOrEmpty(sheetName) Then
                        sheetName = "_"
                    End If

                    ' Get a Unique SheetName
                    temporalSheetName = sheetName
                    While procecedLegalValues.ContainsSheetName(sheetName)
                        If temporalSheetName.Length = 31 Then

                            sheetName = temporalSheetName.Substring(0, 31 - count.ToString.Length) & count.ToString

                        Else

                            sheetName = temporalSheetName & count.ToString

                        End If
                        count += 1
                    End While

                    'Register the Legal Values as proceced
                    procecedLegalValues.AddLegalValues(legalValues, sheetName)

                End If

                returnString = sheetName

            End If

        End If
        Return returnString
    End Function

    ''' <summary>
    ''' Get the Name of the Section, Questionnaire and QuestionnaireSet that the Question belongs to.
    ''' </summary>
    ''' <param name="question"></param>
    ''' <param name="sectionName"></param>
    ''' <param name="questionnaireName"></param>
    ''' <param name="questionnaireSetName"></param>
    ''' <param name="dataTable"></param>
    ''' <param name="VariableScope"></param>
    ''' <remarks></remarks>
    Private Sub getParentsOfQuestion(ByVal question As BO.GenericObject, ByRef sectionName As String, _
                            ByRef questionnaireName As String, ByRef questionnaireSetName As String, _
                            ByRef dataTable As String, ByVal VariableScope As BO.VariableScopes)

        If question IsNot Nothing Then

            Dim currentNode As BO.GenericObject = question

            While Not TypeOf currentNode Is BO.QuestionnaireSet

                currentNode = currentNode.Parent

                If TypeOf currentNode Is BO.Section Then
                    sectionName = currentNode.Name
                    If VariableScope = BO.VariableScopes.Section Then
                        dataTable = currentNode.DataTableName
                    End If
                ElseIf TypeOf currentNode Is BO.Questionnaire Then
                    questionnaireName = currentNode.Name
                    If VariableScope = BO.VariableScopes.Questionnaire Then
                        dataTable = currentNode.DataTableName
                    End If
                ElseIf TypeOf currentNode Is BO.QuestionnaireSet Then
                    questionnaireSetName = currentNode.Name
                    If VariableScope = BO.VariableScopes.QuestionnaireSet Then
                        dataTable = currentNode.DataTableName
                    End If
                End If

            End While
        Else
            sectionName = ""
            questionnaireName = ""
            questionnaireSetName = ""
            dataTable = ""
        End If

    End Sub

    ''' <summary>
    '''  Get the text of the a QuestionData
    ''' </summary>
    ''' <param name="data"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getColumnName(ByVal data As Integer, ByVal [enum] As Type) As String
        Return System.Enum.GetName([enum], data).Replace("_", " ")
    End Function

#Region " DataDictionary by Variable "

    ''' <summary>
    ''' Add Variable to the DataDictionary By Variable
    ''' </summary>
    ''' <param name="currentQuestion"></param>
    ''' <param name="variables"></param>
    ''' <param name="_dataTable"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function addVariable(ByVal currentQuestion As BO.Question, ByRef variables As Dictionary(Of String, VariableDataDictionary), _
                                    ByVal _dataTable As String, ByVal QuestionnaireSetName As String, ByVal QuestionnaireName As String, ByVal SectionName As String) As Boolean

        If currentQuestion.ScreenTemplate.ToLower = "CheckBox".ToLower Then

            If Not String.IsNullOrEmpty(currentQuestion.LegalValueTable) Then

                Dim variableRealName As String = ""

                For Each currentLegalValueItem As BO.LegalValueItem In BO.Study.GetLegalValuesByName(currentQuestion.LegalValueTable).LegalValues

                    ' The real Name of the variable is the {variableName} & {LegalValueItem.ShortName}
                    variableRealName = currentQuestion.VariableName & currentLegalValueItem.ShortName

                    ' Revisar si esta en el diccionario
                    If variables.ContainsKey(variableRealName) Then
                        addLocationAndDataTable(currentQuestion, variables.Item(variableRealName), _dataTable, QuestionnaireSetName, QuestionnaireName, SectionName)
                    Else
                        Dim tempVariable As New VariableDataDictionary
                        tempVariable.Data_Table = " * " & _dataTable
                        tempVariable.Data_Type = "True/False"
                        tempVariable.Legal_Value = ""
                        tempVariable.Location = String.Format(" * {0}-{1}-{2}-{3}", questionnaireSetName, questionnaireName, sectionName, currentQuestion.Number)
                        tempVariable.Main_Text = String.Format("{0} {1} - {2}", currentQuestion.GroupText, currentQuestion.MainText, currentLegalValueItem.Text)
                        tempVariable.Range = ""
                        tempVariable.Variable_Name = variableRealName
                        variables.Add(tempVariable.Variable_Name, tempVariable)
                    End If

                Next

            End If

            Return False

        ElseIf currentQuestion.ScreenTemplate.ToLower = "GPSReading".ToLower Then
            ' the Template GPSReading has 7 variables

            ' VariableRealName = {variableName}{postfix}
            Dim variableRealName As String = ""


            '--------Variable DecLat---------
            variableRealName = currentQuestion.VariableName & "DecLat"

            If variables.ContainsKey(variableRealName) Then
                addLocationAndDataTable(currentQuestion, variables.Item(variableRealName), _dataTable, QuestionnaireSetName, QuestionnaireName, SectionName)
            Else
                Dim tempVariable As New VariableDataDictionary
                tempVariable.Data_Table = " * " & _dataTable
                tempVariable.Data_Type = "Decimal"
                tempVariable.Legal_Value = ""
                tempVariable.Location = String.Format(" * {0}-{1}-{2}-{3}", questionnaireSetName, questionnaireName, sectionName, currentQuestion.Number)
                tempVariable.Main_Text = "GPS DecLat"
                tempVariable.Range = ""
                tempVariable.Variable_Name = variableRealName
                variables.Add(tempVariable.Variable_Name, tempVariable)
            End If
            '--------------------------------

            '--------Variable DecLon---------
            variableRealName = currentQuestion.VariableName & "DecLon"

            If variables.ContainsKey(variableRealName) Then
                addLocationAndDataTable(currentQuestion, variables.Item(variableRealName), _dataTable, QuestionnaireSetName, QuestionnaireName, SectionName)
            Else
                Dim tempVariable As New VariableDataDictionary
                tempVariable.Data_Table = " * " & _dataTable
                tempVariable.Data_Type = "Decimal"
                tempVariable.Legal_Value = ""
                tempVariable.Location = String.Format(" * {0}-{1}-{2}-{3}", questionnaireSetName, questionnaireName, sectionName, currentQuestion.Number)
                tempVariable.Main_Text = "GPS DecLon"
                tempVariable.Range = ""
                tempVariable.Variable_Name = variableRealName
                variables.Add(tempVariable.Variable_Name, tempVariable)
            End If
            '--------------------------------

            '--------Variable Lat---------
            variableRealName = currentQuestion.VariableName & "Lat"

            If variables.ContainsKey(variableRealName) Then
                addLocationAndDataTable(currentQuestion, variables.Item(variableRealName), _dataTable, QuestionnaireSetName, QuestionnaireName, SectionName)
            Else
                Dim tempVariable As New VariableDataDictionary
                tempVariable.Data_Table = " * " & _dataTable
                tempVariable.Data_Type = "Text"
                tempVariable.Legal_Value = ""
                tempVariable.Location = String.Format(" * {0}-{1}-{2}-{3}", questionnaireSetName, questionnaireName, sectionName, currentQuestion.Number)
                tempVariable.Main_Text = "GPS Lat"
                tempVariable.Range = ""
                tempVariable.Variable_Name = variableRealName
                variables.Add(tempVariable.Variable_Name, tempVariable)
            End If
            '--------------------------------

            '--------Variable Lon---------
            variableRealName = currentQuestion.VariableName & "Lon"

            If variables.ContainsKey(variableRealName) Then
                addLocationAndDataTable(currentQuestion, variables.Item(variableRealName), _dataTable, QuestionnaireSetName, QuestionnaireName, SectionName)
            Else
                Dim tempVariable As New VariableDataDictionary
                tempVariable.Data_Table = " * " & _dataTable
                tempVariable.Data_Type = "Text"
                tempVariable.Legal_Value = ""
                tempVariable.Location = String.Format(" * {0}-{1}-{2}-{3}", questionnaireSetName, questionnaireName, sectionName, currentQuestion.Number)
                tempVariable.Main_Text = "GPS Lon"
                tempVariable.Range = ""
                tempVariable.Variable_Name = variableRealName
                variables.Add(tempVariable.Variable_Name, tempVariable)
            End If
            '--------------------------------

            '--------Variable PDOP---------
            variableRealName = currentQuestion.VariableName & "PDOP"

            If variables.ContainsKey(variableRealName) Then
                addLocationAndDataTable(currentQuestion, variables.Item(variableRealName), _dataTable, QuestionnaireSetName, QuestionnaireName, SectionName)
            Else
                Dim tempVariable As New VariableDataDictionary
                tempVariable.Data_Table = " * " & _dataTable
                tempVariable.Data_Type = "Decimal"
                tempVariable.Legal_Value = ""
                tempVariable.Location = String.Format(" * {0}-{1}-{2}-{3}", questionnaireSetName, questionnaireName, sectionName, currentQuestion.Number)
                tempVariable.Main_Text = "GPS PDOP"
                tempVariable.Range = ""
                tempVariable.Variable_Name = variableRealName
                variables.Add(tempVariable.Variable_Name, tempVariable)
            End If
            '--------------------------------

            '--------Variable HDOP---------
            variableRealName = currentQuestion.VariableName & "HDOP"

            If variables.ContainsKey(variableRealName) Then
                addLocationAndDataTable(currentQuestion, variables.Item(variableRealName), _dataTable, QuestionnaireSetName, QuestionnaireName, SectionName)
            Else
                Dim tempVariable As New VariableDataDictionary
                tempVariable.Data_Table = " * " & _dataTable
                tempVariable.Data_Type = "Decimal"
                tempVariable.Legal_Value = ""
                tempVariable.Location = String.Format(" * {0}-{1}-{2}-{3}", questionnaireSetName, questionnaireName, sectionName, currentQuestion.Number)
                tempVariable.Main_Text = "GPS HDOP"
                tempVariable.Range = ""
                tempVariable.Variable_Name = variableRealName
                variables.Add(tempVariable.Variable_Name, tempVariable)
            End If
            '--------------------------------

            '--------Variable Sat---------
            variableRealName = currentQuestion.VariableName & "Sat"

            If variables.ContainsKey(variableRealName) Then
                addLocationAndDataTable(currentQuestion, variables.Item(variableRealName), _dataTable, QuestionnaireSetName, QuestionnaireName, SectionName)
            Else
                Dim tempVariable As New VariableDataDictionary
                tempVariable.Data_Table = " * " & _dataTable
                tempVariable.Data_Type = "Integer"
                tempVariable.Legal_Value = ""
                tempVariable.Location = String.Format(" * {0}-{1}-{2}-{3}", questionnaireSetName, questionnaireName, sectionName, currentQuestion.Number)
                tempVariable.Main_Text = "GPS Sat"
                tempVariable.Range = ""
                tempVariable.Variable_Name = variableRealName
                variables.Add(tempVariable.Variable_Name, tempVariable)
            End If
            '--------------------------------


            Return False

        Else

            ' Revisar si esta en el diccionario
            If variables.ContainsKey(currentQuestion.VariableName) Then
                addLocationAndDataTable(currentQuestion, variables.Item(currentQuestion.VariableName), _dataTable, QuestionnaireSetName, QuestionnaireName, SectionName)
                Return False
            Else
                Dim tempVariable As New VariableDataDictionary


                tempVariable.Data_Table = " * " & _dataTable
                tempVariable.Data_Type = WriteDataType(currentQuestion)
                tempVariable.Legal_Value = registerLegalValues(BO.Study.GetLegalValuesByName(currentQuestion.LegalValueTable))
                tempVariable.Location = String.Format(" * {0}-{1}-{2}-{3}", questionnaireSetName, questionnaireName, sectionName, currentQuestion.Number)
                tempVariable.Main_Text = String.Format("{0} {1}", currentQuestion.GroupText, currentQuestion.MainText)

                'if question does not have a AbsMax or/and AbsMin then the cell's text is ""
                If (Not String.IsNullOrEmpty(currentQuestion.AbsoluteMaximum)) And (Not String.IsNullOrEmpty(currentQuestion.AbsoluteMinimum)) Then
                    If String.IsNullOrEmpty(currentQuestion.AbsoluteMaximum) Then
                        'there is not a absolute maximum.  print only the minimum
                        tempVariable.Range = String.Format("Minimum {0}", currentQuestion.AbsoluteMinimum)

                    ElseIf String.IsNullOrEmpty(currentQuestion.AbsoluteMinimum) Then
                        'there is not a absolute minimum.  print only the maximum 
                        tempVariable.Range = String.Format("Maximum {0}", currentQuestion.AbsoluteMaximum)
                    Else
                        'there are both absolute minimum and maximum
                        tempVariable.Range = String.Format("Minimum {0} and Maximum {1}", currentQuestion.AbsoluteMinimum, currentQuestion.AbsoluteMaximum)
                    End If
                End If

                tempVariable.Variable_Name = currentQuestion.VariableName
                variables.Add(tempVariable.Variable_Name, tempVariable)

                Return True
            End If
        End If
    End Function

    ''' <summary>
    ''' Add the location of the question that use the variable and add 
    ''' </summary>
    ''' <param name="currentQuestion"></param>
    ''' <param name="variable"></param>
    ''' <remarks></remarks>
    Private Sub addLocationAndDataTable(ByVal currentQuestion As BO.Question, ByVal variable As VariableDataDictionary, ByVal _dataTable As String, _
                                            ByVal QuestionnaireSetName As String, ByVal QuestionnaireName As String, ByVal SectionName As String)
        variable.Location &= vbLf & String.Format("<br /> * {0}-{1}-{2}-{3}", QuestionnaireSetName, QuestionnaireName, _
                                                SectionName, currentQuestion.Number)
        variable.Data_Table &= vbLf & "<br /> * " & _dataTable
    End Sub

    Private Function GenerateVariablesHTML(ByVal variables As Dictionary(Of String, VariableDataDictionary)) As String
        Dim returnString As New System.Text.StringBuilder
        Dim tempString As System.Text.StringBuilder

        For Each variable As VariableDataDictionary In variables.Values

            tempString = New System.Text.StringBuilder
            tempString.Append(TRsVariables)
            tempString = tempString.Replace("{VariableName}", variable.Variable_Name)
            tempString = tempString.Replace("{MainText}", variable.Main_Text)
            tempString = tempString.Replace("{DataType}", variable.Data_Type)
            tempString = tempString.Replace("{LegalValue}", variable.Legal_Value)
            tempString = tempString.Replace("{Range}", variable.Range)
            tempString = tempString.Replace("{Location}", variable.Location)
            tempString = tempString.Replace("{DataTable}", variable.Data_Table)

            returnString.Append(tempString)

        Next

        Return returnString.ToString
    End Function

    Private Sub ProcessSectionItemByVariable(ByVal currentSectionItem As BO.SectionItem, ByRef variables As Dictionary(Of String, VariableDataDictionary))

        Dim QuestionnaireSetName As String = ""
        Dim QuestionnaireName As String = ""
        Dim sectionName As String = ""

        If TypeOf currentSectionItem Is BO.CheckPoint Then

            For Each sectionItem As BO.SectionItem In (CType(currentSectionItem, BO.CheckPoint)).SectionItems

                ProcessSectionItemByVariable(sectionItem, variables)

            Next

        ElseIf TypeOf currentSectionItem Is BO.Question Then

            Dim currentQuestion As BO.Question = CType(currentSectionItem, BO.Question)

            If currentQuestion IsNot Nothing AndAlso (((Not String.IsNullOrEmpty(currentQuestion.VariableName)) AndAlso Not (String.IsNullOrEmpty(currentQuestion.VariableName.Trim))) Or currentQuestion.ScreenTemplate.ToLower = "checkbox") Then
                ' If the parent is nothing then the question is a Assigned Variable
                If currentQuestion.Parent IsNot Nothing Then
                    getParentsOfQuestion(currentQuestion, sectionName, QuestionnaireName, QuestionnaireSetName, dataTable, currentQuestion.VariableScope)
                    addVariable(currentQuestion, variables, dataTable, QuestionnaireSetName, QuestionnaireName, SectionName)
                End If
            End If

        End If

    End Sub

    Private Sub ProcessVariablesByVariable(ByVal listVariables As List(Of BO.Variable), ByRef processedVariables As Dictionary(Of String, VariableDataDictionary))

        Dim currentQuestion As BO.Question
        Dim QuestionnaireSetName As String = ""
        Dim QuestionnaireName As String = ""
        Dim sectionName As String = ""

        For Each currentVariable As BO.Variable In listVariables

            currentQuestion = currentVariable.ToQuestion()

            If currentQuestion IsNot Nothing AndAlso (((Not String.IsNullOrEmpty(currentQuestion.VariableName)) AndAlso Not (String.IsNullOrEmpty(currentQuestion.VariableName.Trim))) Or currentQuestion.ScreenTemplate.ToLower = "checkbox") Then
                ' If the parent is nothing then the question is a Assigned Variable
                If currentQuestion.Parent IsNot Nothing Then
                    getParentsOfQuestion(currentQuestion.Parent, SectionName, QuestionnaireName, QuestionnaireSetName, dataTable, currentQuestion.VariableScope)
                    addVariable(currentQuestion, processedVariables, dataTable, QuestionnaireSetName, QuestionnaireName, SectionName)
                End If
            End If

        Next

    End Sub

#End Region

#Region " DataDictionary by Question "

    ''' <summary>
    ''' Add the question's information to the data code book
    ''' </summary>
    ''' <param name="question"></param>
    ''' <param name="rowNumber"></param>
    ''' <remarks></remarks>
    Private Sub addQuestion(ByVal question As BO.Question, ByRef Questions As List(Of QuestionDataDictionary), _
                                    ByVal QuestionnaireSetName As String, ByVal QuestionnaireName As String, _
                                    ByVal SectionName As String, ByVal DataTable As String)

        Dim questionDataDictionary As New QuestionDataDictionary

        questionDataDictionary.QuestionnaireSet = QuestionnaireSetName
        questionDataDictionary.Questionnaire = QuestionnaireName
        questionDataDictionary.Section = SectionName
        questionDataDictionary.Question_Number = question.Number
        questionDataDictionary.Legal_Value = registerLegalValues(BO.Study.GetLegalValuesByName(question.LegalValueTable))
        questionDataDictionary.Required_Field = IIf(question.Required, "Yes", "No").ToString
        questionDataDictionary.Variable_Scope = System.Enum.GetName(GetType(BO.VariableScopes), question.VariableScope)
        questionDataDictionary.Data_Table = DataTable
        questionDataDictionary.Main_Text = String.Format("{0} {1}", question.GroupText, question.MainText)

        If question.ScreenTemplate.ToLower = "CheckBox".ToLower Then

            questionDataDictionary.Variable_Name = ""
            For Each currentLegalValueItem As BO.LegalValueItem In BO.Study.GetLegalValuesByName(question.LegalValueTable).LegalValues
                questionDataDictionary.Variable_Name &= question.VariableName & currentLegalValueItem.ShortName & "<br/>" & vbCrLf
            Next
            If Not String.IsNullOrEmpty(questionDataDictionary.Variable_Name) Then
                questionDataDictionary.Variable_Name = questionDataDictionary.Variable_Name.Remove(questionDataDictionary.Variable_Name.Length - 6)
            End If

        ElseIf question.ScreenTemplate.ToLower = "GPSReading".ToLower Then

            '--------Variable DecLat---------
            questionDataDictionary.Variable_Name = question.VariableName & "DecLat<br/>" & vbCrLf
            '--------------------------------

            '--------Variable DecLon---------
            questionDataDictionary.Variable_Name &= question.VariableName & "DecLon<br/>" & vbCrLf
            '--------------------------------

            '--------Variable Lat---------
            questionDataDictionary.Variable_Name &= question.VariableName & "Lat<br/>" & vbCrLf
            '--------------------------------

            '--------Variable Lon---------
            questionDataDictionary.Variable_Name &= question.VariableName & "Lon<br/>" & vbCrLf
            '--------------------------------

            '--------Variable PDOP---------
            questionDataDictionary.Variable_Name &= question.VariableName & "PDOP<br/>" & vbCrLf
            '--------------------------------

            '--------Variable HDOP---------
            questionDataDictionary.Variable_Name &= question.VariableName & "HDOP<br/>" & vbCrLf
            '--------------------------------

            '--------Variable Sat---------
            questionDataDictionary.Variable_Name &= question.VariableName & "Sat"
            '--------------------------------
        Else
            questionDataDictionary.Variable_Name = question.VariableName
        End If

        questionDataDictionary.Data_Type = WriteDataType(question)

        If (Not String.IsNullOrEmpty(question.AbsoluteMaximum)) And (Not String.IsNullOrEmpty(question.AbsoluteMinimum)) Then
            questionDataDictionary.Range = String.Format("Minimum {0} and Maximum {1}", question.AbsoluteMinimum, question.AbsoluteMaximum)
        ElseIf (String.IsNullOrEmpty(question.AbsoluteMaximum)) And (Not String.IsNullOrEmpty(question.AbsoluteMinimum)) Then
            questionDataDictionary.Range = String.Format("Minimum {0}", question.AbsoluteMinimum)
        ElseIf (Not String.IsNullOrEmpty(question.AbsoluteMaximum)) And (String.IsNullOrEmpty(question.AbsoluteMinimum)) Then
            questionDataDictionary.Range = String.Format("Maximum {0}", question.AbsoluteMaximum)
        End If

        Questions.Add(questionDataDictionary)

    End Sub


    Private Function GenerateQuestionsHTML(ByVal questions As List(Of QuestionDataDictionary)) As String
        Dim returnString As New System.Text.StringBuilder
        Dim tempString As System.Text.StringBuilder

        For Each question As QuestionDataDictionary In questions

            tempString = New System.Text.StringBuilder
            tempString.Append(TRsQuestions)

            tempString = tempString.Replace("{QuestionnaireSet}", question.QuestionnaireSet)
            tempString = tempString.Replace("{Questionnaire}", question.Questionnaire)
            tempString = tempString.Replace("{Section}", question.Section)
            tempString = tempString.Replace("{Question Number}", question.Question_Number)
            tempString = tempString.Replace("{Variable Name}", question.Variable_Name)
            tempString = tempString.Replace("{Main Text}", question.Main_Text)
            tempString = tempString.Replace("{Data Type}", question.Data_Type)
            tempString = tempString.Replace("{Range}", question.Range)
            tempString = tempString.Replace("{Legal Value}", question.Legal_Value)
            tempString = tempString.Replace("{Required Field}", question.Required_Field)
            tempString = tempString.Replace("{Variable Scope}", question.Variable_Scope)
            tempString = tempString.Replace("{Data Table}", question.Data_Table)

            returnString.Append(tempString)

        Next

        Return returnString.ToString
    End Function


    Private Sub ProcessSectionItemByQuestion(ByVal currentSectionItem As BO.SectionItem, ByRef questions As List(Of QuestionDataDictionary))

        Dim QuestionnaireSetName As String = ""
        Dim QuestionnaireName As String = ""
        Dim sectionName As String = ""

        If TypeOf currentSectionItem Is BO.CheckPoint Then

            For Each sectionItem As BO.SectionItem In (CType(currentSectionItem, BO.CheckPoint)).SectionItems

                ProcessSectionItemByQuestion(sectionItem, questions)

            Next

        ElseIf TypeOf currentSectionItem Is BO.Question Then

            Dim currentQuestion As BO.Question = CType(currentSectionItem, BO.Question)

            If currentQuestion IsNot Nothing AndAlso (((Not String.IsNullOrEmpty(currentQuestion.VariableName)) AndAlso Not (String.IsNullOrEmpty(currentQuestion.VariableName.Trim))) Or currentQuestion.ScreenTemplate.ToLower = "checkbox") Then
                ' If the parent is nothing then the question is a Assigned Variable
                If currentQuestion.Parent IsNot Nothing Then
                    getParentsOfQuestion(currentQuestion, sectionName, QuestionnaireName, QuestionnaireSetName, dataTable, currentQuestion.VariableScope)
                    addQuestion(currentQuestion, questions, QuestionnaireSetName, QuestionnaireName, sectionName, dataTable)
                End If
            End If

        End If

    End Sub

#End Region

#End Region

#Region " Public Methods "

    ''' <summary>
    ''' Generate and Saves the Excel of the DataDictionary by Variable
    ''' </summary>
    ''' <param name="_filename"></param>
    ''' <remarks></remarks>
    Public Sub DataDictionaryByVariable(ByVal _filename As String)

        filePath = _filename

        ' get the data
        Dim variables As New Dictionary(Of String, VariableDataDictionary)
        procecedLegalValues = New DataDictionaryLegalValues(Me.FileName)
        Dim fileContent As System.Text.StringBuilder
        Dim reader As System.IO.StreamReader
        Dim writer As System.IO.StreamWriter
        Dim pathFolder As String = (New System.IO.FileInfo(_filename)).DirectoryName & "\" & Me.FileName & "_files"
        Dim sourcePathFolder As String = Application.StartupPath & "\Resources\DataDictionary HTML Files\"

        'Create the folder of the subFiles
        If Not System.IO.Directory.Exists(pathFolder) Then
            System.IO.Directory.CreateDirectory(pathFolder)
        End If

        ' Insert all the variables
        For Each currentQuestionnaireSet As BO.QuestionnaireSet In BO.ContextClass.Study.QuestionnarieSets

            ProcessVariablesByVariable(currentQuestionnaireSet.Variables, variables)

            For Each currentQuestionnaire As BO.Questionnaire In currentQuestionnaireSet.Questionnaires

                ProcessVariablesByVariable(currentQuestionnaire.Variables, variables)

                For Each currentSection As BO.Section In currentQuestionnaire.Sections

                    ProcessVariablesByVariable(currentSection.Variables, variables)

                    For Each currentSectionItem As BO.SectionItem In currentSection.SectionItems

                        ProcessSectionItemByVariable(currentSectionItem, variables)

                    Next
                Next

            Next

        Next

        ' Generate all the files.

        ' Generate {FileName}.htm File
        fileContent = New System.Text.StringBuilder()
        reader = New System.IO.StreamReader(sourcePathFolder & "\{FileName}.htm")
        fileContent.Append(reader.ReadToEnd)
        reader.Close()

        fileContent = fileContent.Replace("{FileName}", Me.FileName)
        fileContent = fileContent.Replace("{UserName}", Me.User)
        fileContent = fileContent.Replace("{Now}", Me.Now)
        fileContent = fileContent.Replace("{NumTabs}", (Me.procecedLegalValues.Count + 1).ToString)
        fileContent = fileContent.Replace("{Objectc_rgszShEachLV}", Me.procecedLegalValues.GetObjectc_rgszShEachLV)
        fileContent = fileContent.Replace("{ExcelWorksheetsLVs}", Me.procecedLegalValues.GetExcelWorksheetsLVs)
        fileContent = fileContent.Replace("{LinkHRefEachLV}", Me.procecedLegalValues.GetLinkHRefEachLV)

        writer = New System.IO.StreamWriter(filePath, False, System.Text.Encoding.UTF8)
        writer.Write(fileContent.ToString)
        writer.Flush()
        writer.Close()


        ' Generate filelist.xml File
        fileContent = New System.Text.StringBuilder()
        reader = New System.IO.StreamReader(sourcePathFolder & "\{FileName}_files\filelist.xml")
        fileContent.Append(reader.ReadToEnd)
        reader.Close()

        fileContent = fileContent.Replace("{FileName}", Me.FileName)
        fileContent = fileContent.Replace("{HRefFileEachLV}", Me.procecedLegalValues.GetHRefFileEachLV)

        writer = New System.IO.StreamWriter(pathFolder & "\filelist.xml", False, System.Text.Encoding.UTF8)
        writer.Write(fileContent.ToString)
        writer.Flush()
        writer.Close()


        'Generate stylesheet.css
        reader = New System.IO.StreamReader(sourcePathFolder & "\{FileName}_files\stylesheet.css")
        writer = New System.IO.StreamWriter(pathFolder & "\stylesheet.css", False, System.Text.Encoding.UTF8)
        writer.Write(reader.ReadToEnd)
        reader.Close()
        writer.Flush()
        writer.Close()


        ' Generate tabstrip.htm File
        fileContent = New System.Text.StringBuilder()
        reader = New System.IO.StreamReader(sourcePathFolder & "\{FileName}_files\tabstrip.htm")
        fileContent.Append(reader.ReadToEnd)
        reader.Close()

        fileContent = fileContent.Replace("{FileName}", Me.FileName)
        fileContent = fileContent.Replace("{LinkFileEachLV}", Me.procecedLegalValues.GetLinkFileEachLV)

        writer = New System.IO.StreamWriter(pathFolder & "\tabstrip.htm", False, System.Text.Encoding.UTF8)
        writer.Write(fileContent.ToString)
        writer.Flush()
        writer.Close()


        ' Generate sheet001.htm File
        fileContent = New System.Text.StringBuilder()
        reader = New System.IO.StreamReader(sourcePathFolder & "\{FileName}_files\sheet001Variables.htm")
        fileContent.Append(reader.ReadToEnd)
        reader.Close()

        fileContent = fileContent.Replace("{FileName}", Me.FileName)
        fileContent = fileContent.Replace("{TRsVariables}", Me.GenerateVariablesHTML(variables))

        writer = New System.IO.StreamWriter(pathFolder & "\sheet001.htm", False, System.Text.Encoding.UTF8)
        writer.Write(fileContent.ToString)
        writer.Flush()
        writer.Close()


        'Generate sheet00{#LV+1}.htm
        procecedLegalValues.GenerateHTMFiles(pathFolder, sourcePathFolder)

    End Sub

    ''' <summary>
    ''' Generate and Saves the Excel of the DataDictionary by Question
    ''' </summary>
    ''' <param name="fileName"></param>
    ''' <remarks></remarks>
    Public Sub DataDictionaryByQuestion(ByVal _fileName As String)

        filePath = _filename

        ' get the data
        Dim questions As New List(Of QuestionDataDictionary)
        procecedLegalValues = New DataDictionaryLegalValues(Me.FileName)
        Dim fileContent As System.Text.StringBuilder
        Dim reader As System.IO.StreamReader
        Dim writer As System.IO.StreamWriter
        Dim pathFolder As String = (New System.IO.FileInfo(_fileName)).DirectoryName & "\" & Me.FileName & "_files"
        Dim sourcePathFolder As String = Application.StartupPath & "\Resources\DataDictionary HTML Files\"

        'Create the folder of the subFiles
        If Not System.IO.Directory.Exists(pathFolder) Then
            System.IO.Directory.CreateDirectory(pathFolder)
        End If

        ' Insert all the variables
        For Each currentQuestionnaireSet As BO.QuestionnaireSet In BO.ContextClass.Study.QuestionnarieSets

            For Each currentQuestionnaire As BO.Questionnaire In currentQuestionnaireSet.Questionnaires

                For Each currentSection As BO.Section In currentQuestionnaire.Sections

                    For Each currentSectionItem As BO.SectionItem In currentSection.SectionItems

                        ProcessSectionItemByQuestion(currentSectionItem, questions)

                    Next
                Next

            Next

        Next

        ' Generate all the files.

        ' Generate {FileName}.htm File
        fileContent = New System.Text.StringBuilder()
        reader = New System.IO.StreamReader(sourcePathFolder & "\{FileName}.htm")
        fileContent.Append(reader.ReadToEnd)
        reader.Close()

        fileContent = fileContent.Replace("{FileName}", Me.FileName)
        fileContent = fileContent.Replace("{UserName}", Me.User)
        fileContent = fileContent.Replace("{Now}", Me.Now)
        fileContent = fileContent.Replace("{NumTabs}", (Me.procecedLegalValues.Count + 1).ToString)
        fileContent = fileContent.Replace("{Objectc_rgszShEachLV}", Me.procecedLegalValues.GetObjectc_rgszShEachLV)
        fileContent = fileContent.Replace("{ExcelWorksheetsLVs}", Me.procecedLegalValues.GetExcelWorksheetsLVs)
        fileContent = fileContent.Replace("{LinkHRefEachLV}", Me.procecedLegalValues.GetLinkHRefEachLV)

        writer = New System.IO.StreamWriter(filePath, False, System.Text.Encoding.UTF8)
        writer.Write(fileContent.ToString)
        writer.Flush()
        writer.Close()


        ' Generate filelist.xml File
        fileContent = New System.Text.StringBuilder()
        reader = New System.IO.StreamReader(sourcePathFolder & "\{FileName}_files\filelist.xml")
        fileContent.Append(reader.ReadToEnd)
        reader.Close()

        fileContent = fileContent.Replace("{FileName}", Me.FileName)
        fileContent = fileContent.Replace("{HRefFileEachLV}", Me.procecedLegalValues.GetHRefFileEachLV)

        writer = New System.IO.StreamWriter(pathFolder & "\filelist.xml", False, System.Text.Encoding.UTF8)
        writer.Write(fileContent.ToString)
        writer.Flush()
        writer.Close()


        'Generate stylesheet.css
        reader = New System.IO.StreamReader(sourcePathFolder & "\{FileName}_files\stylesheet.css")
        writer = New System.IO.StreamWriter(pathFolder & "\stylesheet.css", False, System.Text.Encoding.UTF8)
        writer.Write(reader.ReadToEnd)
        reader.Close()
        writer.Flush()
        writer.Close()


        ' Generate tabstrip.htm File
        fileContent = New System.Text.StringBuilder()
        reader = New System.IO.StreamReader(sourcePathFolder & "\{FileName}_files\tabstrip.htm")
        fileContent.Append(reader.ReadToEnd)
        reader.Close()

        fileContent = fileContent.Replace("{FileName}", Me.FileName)
        fileContent = fileContent.Replace("{LinkFileEachLV}", Me.procecedLegalValues.GetLinkFileEachLV)

        writer = New System.IO.StreamWriter(pathFolder & "\tabstrip.htm", False, System.Text.Encoding.UTF8)
        writer.Write(fileContent.ToString)
        writer.Flush()
        writer.Close()


        ' Generate sheet001.htm File
        fileContent = New System.Text.StringBuilder()
        reader = New System.IO.StreamReader(sourcePathFolder & "\{FileName}_files\sheet001Questions.htm")
        fileContent.Append(reader.ReadToEnd)
        reader.Close()

        fileContent = fileContent.Replace("{FileName}", Me.FileName)
        fileContent = fileContent.Replace("{TRsQuestions}", Me.GenerateQuestionsHTML(questions))

        writer = New System.IO.StreamWriter(pathFolder & "\sheet001.htm", False, System.Text.Encoding.UTF8)
        writer.Write(fileContent.ToString)
        writer.Flush()
        writer.Close()


        'Generate sheet00{#LV+1}.htm
        procecedLegalValues.GenerateHTMFiles(pathFolder, sourcePathFolder)

    End Sub

#End Region

End Class

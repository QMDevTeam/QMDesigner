Imports System.Data.SqlClient

Public Class StructureControl2

#Region " Private Members"

    Private _tables As New Dictionary(Of String, TableInfo)
    'Private _tablesInfo As New Dictionary(Of String, TableInfo)
    Private _fields As Dictionary(Of String, ColumnInfo)
    Private _clickedNode As TreeNodeDataManager
    Private _questionnaireTableUsed As Boolean
    Private _trimNames As Boolean
    Private _columnsMetaDataQuestionnaireSet, _columnsMetaDataQuestionnaire, _columnsMetaDataSection As New List(Of BO.Variable)
    Private _columnsInTheQuery As Dictionary(Of String, ColumnInfo)
    Private _dataManagerFrm As DataManagerForm

#End Region


#Region " Private Methods"

    Private Sub RegisterKeys(ByVal table As TableInfo)

        Dim keys As DataTable = _dataManagerFrm.GetKeys(table)
        Dim columnQuery As ColumnInfo
        Dim maxChars As Integer = 0

        For Each keyRow As DataRow In keys.Rows

            If Not TypeOf keyRow("Character_Maximum_Length") Is DBNull Then

                maxChars = CInt(keyRow("Character_Maximum_Length"))

            End If

            columnQuery = New ColumnInfo(keyRow("Column_Name").ToString, keyRow("Column_Name").ToString, _
                                keyRow("Data_Type").ToString, maxChars, table, Nothing, False)

            AddField(columnQuery, table)

            table.AddKey(New KeyInfo(columnQuery.AliasName, columnQuery.Name))

        Next

    End Sub


    ''' <summary>
    ''' Register a Variable to generate the Select Query
    ''' </summary>
    ''' <param name="sectionTableInfo">TableInfo of the currentTable</param>
    ''' <param name="questionnaireTableInfo">TableInfo of the Questionnaire</param>
    ''' <param name="variableScope">Scope of the variable</param>
    ''' <param name="variableName">Name of the variable</param>
    ''' <param name="QuestionName">Name of the Question (alias of the variable)</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function RegisterVariable(ByVal sectionTableInfo As TableInfo, ByVal questionnaireTableInfo As TableInfo, _
                                    ByVal questionnaireSetTableInfo As TableInfo, ByVal variableScope As BO.VariableScopes, _
                                    ByVal variableName As String, ByVal QuestionName As String, ByVal dataType As String, _
                                    ByVal maxChars As Integer, ByVal legalValue As BO.LegalValuesTable, _
                                    ByVal isDropDownOrRadioBut As Boolean) As Boolean

        Dim columnName As String = ""

        variableName = variableName.Replace(" "c, "_"c)
        QuestionName = QuestionName.Replace(" "c, "_"c)

        Dim tempField As ColumnInfo


        Select Case variableScope
            Case BO.VariableScopes.Questionnaire

                tempField = New ColumnInfo(QuestionName, variableName, dataType, maxChars, _
                                    questionnaireTableInfo, legalValue, isDropDownOrRadioBut)

                tempField.TrimName = _trimNames

                AddField(tempField, questionnaireTableInfo)
                _questionnaireTableUsed = True

                Return False

            Case BO.VariableScopes.QuestionnaireSet

                tempField = New ColumnInfo(QuestionName, variableName, dataType, maxChars, questionnaireSetTableInfo, _
                                    legalValue, isDropDownOrRadioBut)
                tempField.TrimName = _trimNames

                AddField(tempField, questionnaireSetTableInfo)

                Return False

            Case BO.VariableScopes.Section

                tempField = New ColumnInfo(QuestionName, variableName, dataType, maxChars, _
                                    sectionTableInfo, legalValue, isDropDownOrRadioBut)

                tempField.TrimName = _trimNames

                AddField(tempField, sectionTableInfo)

                Return True

        End Select

        Return False

    End Function

    ''' <summary>
    ''' Register a Question 
    ''' </summary>
    ''' <param name="currentQuestion"></param>
    ''' <param name="areThereFields"></param>
    ''' <param name="sectionTable"></param>
    ''' <param name="questionnaireTable"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function RegisterQuestion(ByVal currentQuestion As BO.Question, ByVal areThereFields As Boolean, ByVal sectionTable As TableInfo, _
                                        ByVal questionnaireTable As TableInfo, ByVal questionnaireSetTable As TableInfo) As Boolean

        Dim dataType As String = currentQuestion.DataType
        Dim maxChars As Integer = 0

        If dataType.Contains("nvarchar") Then

            maxChars = Integer.Parse(dataType.Substring(dataType.IndexOf("(") + 1, dataType.IndexOf(")") - dataType.IndexOf("(") - 1))
            dataType = "nvarchar"

        End If

        ' If the current Question uses legal Values and has 'checkbox' as its screen template, then register each legal value item
        If (Not String.IsNullOrEmpty(currentQuestion.LegalValueTable)) And _
            (Not String.IsNullOrEmpty(currentQuestion.ScreenTemplate) AndAlso currentQuestion.ScreenTemplate.ToLower = "checkbox") Then

            Dim legalValueTableTemp As BO.LegalValuesTable = BO.Study.GetLegalValuesByName(currentQuestion.LegalValueTable)

            If legalValueTableTemp IsNot Nothing Then

                For Each legalValueItem As BO.LegalValueItem In legalValueTableTemp.LegalValues

                    If RegisterVariable(sectionTable, questionnaireTable, questionnaireSetTable, currentQuestion.VariableScope, _
                      currentQuestion.VariableName & legalValueItem.ShortName, currentQuestion.VariableName & legalValueItem.ShortName, _
                      "bit", 0, Nothing, False) Then

                        areThereFields = True

                    End If

                Next

            End If

            ' If the current Question is a 'GPSReading'
        ElseIf (Not String.IsNullOrEmpty(currentQuestion.ScreenTemplate) AndAlso currentQuestion.ScreenTemplate.ToLower = "GPSReading".ToLower) Then


            If RegisterVariable(sectionTable, questionnaireTable, questionnaireSetTable, currentQuestion.VariableScope, _
                    currentQuestion.VariableName & "DecLat", currentQuestion.VariableName & "DecLat", "float", 0, Nothing, False) Or _
              RegisterVariable(sectionTable, questionnaireTable, questionnaireSetTable, currentQuestion.VariableScope, _
                    currentQuestion.VariableName & "DecLon", currentQuestion.VariableName & "DecLon", "float", 0, Nothing, False) Or _
              RegisterVariable(sectionTable, questionnaireTable, questionnaireSetTable, currentQuestion.VariableScope, _
                    currentQuestion.VariableName & "Lat", currentQuestion.VariableName & "Lat", "nvarchar", 50, Nothing, False) Or _
              RegisterVariable(sectionTable, questionnaireTable, questionnaireSetTable, currentQuestion.VariableScope, _
                    currentQuestion.VariableName & "Lon", currentQuestion.VariableName & "Lon", "nvarchar", 50, Nothing, False) Or _
              RegisterVariable(sectionTable, questionnaireTable, questionnaireSetTable, currentQuestion.VariableScope, _
                    currentQuestion.VariableName & "PDOP", currentQuestion.VariableName & "PDOP", "float", 0, Nothing, False) Or _
              RegisterVariable(sectionTable, questionnaireTable, questionnaireSetTable, currentQuestion.VariableScope, _
                    currentQuestion.VariableName & "HDOP", currentQuestion.VariableName & "HDOP", "float", 0, Nothing, False) Or _
              RegisterVariable(sectionTable, questionnaireTable, questionnaireSetTable, currentQuestion.VariableScope, _
                    currentQuestion.VariableName & "Sat", currentQuestion.VariableName & "Sat", "integer", 0, Nothing, False) Then

                areThereFields = True

            End If

        Else
            'If not, then register the question

            Dim VariableName As String = currentQuestion.VariableName
            Dim isDropDownOrRadioBut As Boolean = currentQuestion.ScreenTemplate = "RadioButtons" Or currentQuestion.ScreenTemplate = "DropDown"

            If Not String.IsNullOrEmpty(VariableName) Then

                If VariableName.Trim <> "" Then

                    Dim QuestionName As String = currentQuestion.Name
                    Dim VariableScope As BO.VariableScopes = currentQuestion.VariableScope

                    If String.IsNullOrEmpty(QuestionName) Then
                        QuestionName = VariableName
                    Else
                        If QuestionName.Trim = "" Then
                            QuestionName = VariableName
                        End If
                    End If

                    If RegisterVariable(sectionTable, questionnaireTable, questionnaireSetTable, currentQuestion.VariableScope, VariableName, QuestionName, _
                             dataType, maxChars, BO.Study.GetLegalValuesByName(currentQuestion.LegalValueTable), isDropDownOrRadioBut) Then

                        areThereFields = True

                    End If

                End If

            End If
        End If
            Return areThereFields
    End Function

    ''' <summary>
    ''' Fill the list of fields from a group of SectionItemsNodes (Section or Checkpoint), MetaData Or Assigned Variables
    ''' </summary>
    ''' <param name="node">the current node (section or checkpoint)</param>
    ''' <param name="sectionTable">the TableInfo of the section</param>
    ''' <returns>Returns true if there are fields to show in the section</returns>
    ''' <remarks></remarks>
    Private Function fillListOfFields(ByVal node As TreeNodeDataManager, ByVal sectionTable As TableInfo, _
                ByVal questionnaireTableInfo As TableInfo, ByVal questionnaireSetTableInfo As TableInfo, ByVal scoupe As BO.VariableScopes) As Boolean

        Dim areThereFields As Boolean = False

        'for each TreeNodeDataManager verify the check and the class have to be BO.Question
        For Each sectionItemNode As TreeNodeDataManager In node.Nodes


            If (Not sectionItemNode.CheckState = CheckState.Unchecked) Then 'Check if there are a child in the sectionItemNode that is checked

                If (TypeOf sectionItemNode.Tag Is String) Then

                    Select Case sectionItemNode.Tag.ToString.ToLower
                        '------------MetaData------------
                        Case "metadata"
                            areThereFields = fillListOfFields(sectionItemNode, sectionTable, questionnaireTableInfo, questionnaireSetTableInfo, scoupe)
                            '----------Variables-----------
                        Case "variables"
                            areThereFields = fillListOfFields(sectionItemNode, sectionTable, questionnaireTableInfo, questionnaireSetTableInfo, scoupe)
                            'Case Else 'Is part of the metaData

                            '    RegisterVariable(sectionTable, questionnaireTableInfo, subjectTableInfo, scoupe, sectionItemNode.Text, sectionItemNode.Text)
                            '    areThereFields = True

                    End Select

                Else

                    If TypeOf sectionItemNode.Tag Is BO.Question Then
                        '------------Question---------------
                        areThereFields = RegisterQuestion(CType(sectionItemNode.Tag, BO.Question), areThereFields, sectionTable, questionnaireTableInfo, questionnaireSetTableInfo)
                    ElseIf TypeOf sectionItemNode.Tag Is BO.CheckPoint Then
                        '-------------CheckPoint--------------
                        areThereFields = areThereFields Or fillListOfFields(sectionItemNode, sectionTable, questionnaireTableInfo, questionnaireSetTableInfo, scoupe)
                    ElseIf TypeOf sectionItemNode.Tag Is BO.Variable Then
                        '-------------Variable----------------
                        areThereFields = RegisterQuestion(CType(sectionItemNode.Tag, BO.Variable).ToQuestion, areThereFields, sectionTable, questionnaireTableInfo, questionnaireSetTableInfo)
                    End If

                End If

            End If
        Next

        Return areThereFields
    End Function

    ''' <summary>
    ''' Validate if the field is unique and Add the field to the list.
    ''' </summary>
    ''' <param name="field"></param>
    ''' <remarks>
    ''' There are 2 things to check: 
    '''   -  if the field is alredy added: 
    '''            do nothing
    '''   -  if the there is another field with the same alias but isn't the same field:
    '''            generate an alias to the field ({columnName}_{correlativeNumber}) and add the the field to the list
    '''   -  if it's a new field just add the field to the list.
    '''         
    ''' </remarks>
    Private Sub AddField(ByRef field As ColumnInfo, ByVal tableInfo As TableInfo)

        Dim temporalQueryField As ColumnInfo = Nothing
        Dim validated As Boolean = True
        Dim changeAlias As Boolean = False
        Dim addColumn As Boolean = True

        If _fields.TryGetValue(field.AliasName, temporalQueryField) Then

            validated = Not (temporalQueryField.Table.DataTableName.ToLower = field.Table.DataTableName.ToLower And temporalQueryField.Name.ToLower = field.Name.ToLower)
            changeAlias = True

        End If

        If validated Then

            If changeAlias Then

                Dim postfix As Integer = 1

                While changeAlias
                    If _fields.TryGetValue(String.Format("{0}_{1}", field.AliasName, postfix.ToString), temporalQueryField) Then

                        changeAlias = Not (temporalQueryField.Table.DataTableName.ToLower = field.Table.DataTableName.ToLower And temporalQueryField.Name.ToLower = field.Name.ToLower)
                        addColumn = False

                        postfix += 1

                    Else

                        changeAlias = False
                        addColumn = True

                    End If
                End While

                If addColumn Then

                    field.AliasName = String.Format("{0}_{1}", field.AliasName, postfix.ToString)
                    _columnsInTheQuery.Add(field.AliasName, field)
                    _fields.Add(field.AliasName, field)

                Else

                    postfix -= 1
                    field = _fields(String.Format("{0}_{1}", field.AliasName, postfix.ToString))

                End If

            Else

                _columnsInTheQuery.Add(field.AliasName, field)
                _fields.Add(field.AliasName, field)

            End If

        End If

    End Sub

    ''' <summary>
    ''' Add table to the list of tables to select
    ''' </summary>
    ''' <param name="table"></param>
    ''' <remarks></remarks>
    Private Sub AddTable(ByRef table As TableInfo)

        Dim originalAlias As String = table.AliasName
        Dim counter As Integer = 0

        While (True)

            If _tables.ContainsKey(table.AliasName) Then

                counter += 1
                table.AliasName = String.Format("{0}_{1}", originalAlias, counter)

            Else

                _tables.Add(table.AliasName, table)
                Exit While

            End If

        End While

    End Sub

    ''' <summary>
    ''' Get the SQL of the Tables of the List Of DataTableQuery
    ''' </summary>
    ''' <param name="list"></param>
    ''' <param name="separator"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function DataTableQuerysToString(ByVal list As List(Of TableInfo), ByVal questionnaireSetAlias As String, _
    ByVal usingMainDB As Boolean, Optional ByVal separator As String = ", ") As String

        Dim returnString As String = ""

        For Each table As TableInfo In list
            returnString = returnString & table.SQLScript(questionnaireSetAlias, usingMainDB) & separator & Environment.NewLine
        Next

        'Remove the last separator and the last "Enviorment.NewLine"
        If Not returnString.Length = 0 Then
            returnString = returnString.Substring(0, returnString.Length - separator.Length - Environment.NewLine.Length)
        End If

        Return returnString

    End Function

    ''' <summary>
    ''' Get the SQL of the Fields of the List Of FieldsQuery
    ''' </summary>
    ''' <param name="list"></param>
    ''' <param name="separator"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function FieldsQuerysToString(ByVal list As List(Of ColumnInfo), Optional ByVal separator As String = ", ") As String
        Dim returnString As String = ""

        For Each field As ColumnInfo In list
            returnString = returnString & field.SQLScript & separator & Environment.NewLine
        Next

        If Not returnString.Length = 0 Then
            returnString = returnString.Substring(0, returnString.Length - separator.Length - Environment.NewLine.Length)
        End If

        Return returnString
    End Function

    ' Load the study to the structural view.
    Public Sub MapQuestionnaireSet(ByRef currentQuestionnaireSet As BO.QuestionnaireSet)

        'Create the root node
        Dim root As New TreeNodeDataManager(currentQuestionnaireSet)

        ' Clear the TreeView and adds the root node
        uxOutline.Nodes.Clear()

        ' Generates the tree
        root.GenerateStructureChilds(False, _columnsMetaDataQuestionnaireSet, _columnsMetaDataQuestionnaire, _columnsMetaDataSection)
        uxOutline.Nodes.Add(root)

        ' Select the Questionnaire Set
        uxOutline.SelectedNode = root

    End Sub


#Region "Simulate CheckBox"

    ''' <summary>
    ''' Asing the checkbox value and change the image
    ''' </summary>
    ''' <param name="node"></param>
    ''' <param name="value">New value (ture, false or indeterminate) </param>
    ''' <remarks></remarks>
    Private Sub assignCheckValue(ByVal node As TreeNodeDataManager, ByVal value As Windows.Forms.CheckState)

        node.CheckState = value

    End Sub


    'Recursive method to assign a check value to a node and its childs
    Private Sub assignCheckValueToChilds(ByVal node As TreeNodeDataManager, ByVal value As CheckState)


        For Each childNode As TreeNodeDataManager In node.Nodes
            assignCheckValue(childNode, value)
            assignCheckValueToChilds(childNode, value)
        Next

    End Sub

    'Set the CheckValue of Variables or MetaData
    Private Sub SetCheckValue(ByVal newValue As CheckState, ByVal nodeType As String, ByVal node As TreeNodeDataManager)

        Dim stack As New Stack(Of TreeNodeDataManager)

        For Each currentNode As TreeNodeDataManager In node.Nodes

            If TypeOf currentNode.Tag Is String And String.Equals(nodeType.ToLower, currentNode.Tag.ToString.ToLower) Then

                assignCheckValue(currentNode, newValue)
                assignCheckValueToChilds(currentNode, newValue)
                stack.Push(currentNode)

            ElseIf currentNode.Tag IsNot Nothing AndAlso _
                      (TypeOf currentNode.Tag Is BO.Questionnaire Or _
                        TypeOf currentNode.Tag Is BO.Section) Then

                SetCheckValue(newValue, nodeType, currentNode)

            End If

        Next

        Dim checked As Boolean = True
        Dim indeterminate As Boolean = False
        For Each currentNode As DevComponents.AdvTree.Node In node.Nodes

            checked = checked And currentNode.CheckState = CheckState.Checked
            indeterminate = indeterminate Or currentNode.CheckState <> CheckState.Unchecked

        Next
        If checked Then

            node.CheckState = CheckState.Checked

        ElseIf indeterminate Then

            node.CheckState = CheckState.Indeterminate

        Else

            node.CheckState = CheckState.Unchecked

        End If


    End Sub

#End Region

#End Region


#Region " Public Members "

    Public uxDataManagerForm As DataManagerForm

    Public Property ColumnsInfo() As Dictionary(Of String, ColumnInfo)
        Get
            Return _columnsInTheQuery
        End Get
        Set(ByVal value As Dictionary(Of String, ColumnInfo))
            _columnsInTheQuery = value
        End Set
    End Property

#End Region


#Region " Public Methods "

    ''' <summary>
    ''' Generate the query to consult que selected questions
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetQuery(ByVal dataManagerFrm As DataManagerForm, ByVal trimNames As Boolean, ByVal usingMainDB As Boolean) As String

        Dim query As String = ""
        Dim aliasTableNames As New List(Of String)
        Dim sectionTableUsed As Boolean
        Dim questionnaireSetTableInfo As TableInfo
        _columnsInTheQuery = New Dictionary(Of String, ColumnInfo)

        _tables = New Dictionary(Of String, TableInfo)
        _fields = New Dictionary(Of String, ColumnInfo)
        _trimNames = trimNames
        _dataManagerFrm = dataManagerFrm

        '---------Questionnair Set------------

        If Not uxOutline.Nodes(0) Is Nothing Then

            Dim questionnaireSetObject As BO.QuestionnaireSet = CType(CType(uxOutline.Nodes(0), TreeNodeDataManager).Tag, BO.QuestionnaireSet)

            questionnaireSetTableInfo = New TableInfo(questionnaireSetObject.Name.Replace(" "c, "_"c), _
                    questionnaireSetObject.DataTableName, questionnaireSetObject.LogTableName, _
                    questionnaireSetObject.PDADataTableName, TableType.QuestionnaireSetTable)

            RegisterKeys(questionnaireSetTableInfo)

            AddTable(questionnaireSetTableInfo)

            ' verify that the Questionnair Set is checked
            If Not CType(uxOutline.Nodes(0), TreeNodeDataManager).CheckState = CheckState.Unchecked Then


                'for each TreeNodeDataManager verify the check and the class have to be BO.Questionnaire
                For Each questionnaireNode As TreeNodeDataManager In uxOutline.Nodes(0).Nodes

                    '------------Variables or MetaData of QuestionnaireSet------
                    If (TypeOf questionnaireNode.Tag Is String) And _
                        (questionnaireNode.Tag.ToString.ToLower = "Variables".ToLower Or questionnaireNode.Tag.ToString.ToLower = "Metadata".ToLower) And _
                        (Not questionnaireNode.CheckState = CheckState.Unchecked) Then

                        fillListOfFields(questionnaireNode, Nothing, Nothing, questionnaireSetTableInfo, BO.VariableScopes.QuestionnaireSet)

                    End If

                    '------------Questionnaire-----------
                    If (Not questionnaireNode.CheckState = CheckState.Unchecked) And (questionnaireNode.Tag IsNot Nothing AndAlso _
                            TypeOf questionnaireNode.Tag Is BO.Questionnaire) Then

                        Dim QuestionnaireObject As BO.Questionnaire = (CType(questionnaireNode.Tag, BO.Questionnaire))

                        Dim QuestionnaireTable As New TableInfo(QuestionnaireObject.Name.Replace(" "c, "_"c), _
                                                    QuestionnaireObject.DataTableName, QuestionnaireObject.LogTableName, _
                                                    QuestionnaireObject.PDADataTableName, TableType.Questionnaire)
                        QuestionnaireTable.MultipleInstance = (CType(questionnaireNode.Tag, BO.Questionnaire)).MultipleInstances

                        _questionnaireTableUsed = False

                        AddTable(QuestionnaireTable)

                        For Each sectionNode As TreeNodeDataManager In questionnaireNode.Nodes

                            '------------Variables and MetaData of Questionnaire------
                            If (TypeOf sectionNode.Tag Is String) And _
                                    (sectionNode.Tag.ToString.ToLower = "Variables".ToLower Or sectionNode.Tag.ToString.ToLower = "Metadata".ToLower) And _
                                    (Not sectionNode.CheckState = CheckState.Unchecked) Then

                                fillListOfFields(sectionNode, Nothing, QuestionnaireTable, questionnaireSetTableInfo, BO.VariableScopes.Questionnaire)

                            End If

                            '----------Section--------------
                            'for each TreeNodeDataManager verify the check and the class have to be BO.Section
                            If (Not sectionNode.CheckState = CheckState.Unchecked) And (sectionNode.Tag IsNot Nothing AndAlso _
                                    TypeOf sectionNode.Tag Is BO.Section) Then

                                'Flag
                                sectionTableUsed = False

                                Dim sectionObject As BO.Section = (CType(sectionNode.Tag, BO.Section))

                                Dim sectionTable As New TableInfo(String.Format("{0}_{1}", QuestionnaireObject.Name, sectionObject.Name).Replace(" "c, "_"c), _
                                                                    sectionObject.DataTableName, sectionObject.LogTableName, _
                                                                    sectionObject.PDADataTableName, TableType.Section)

                                sectionTable.QuestionnaireTable = QuestionnaireTable
                                sectionTable.MultipleInstance = QuestionnaireTable.MultipleInstance


                                '------------Childs-----------

                                sectionTableUsed = sectionTableUsed Or fillListOfFields(sectionNode, sectionTable, QuestionnaireTable, questionnaireSetTableInfo, BO.VariableScopes.Section)

                                If sectionTableUsed Then

                                    AddTable(sectionTable)
                                    RegisterKeys(sectionTable)

                                End If

                            End If

                        Next

                        If _questionnaireTableUsed Or QuestionnaireTable.MultipleInstance Then
                            RegisterKeys(QuestionnaireTable)
                        Else
                            _tables.Remove(QuestionnaireTable.AliasName)
                        End If

                    End If

                Next

            End If

            ' Build the quiery

            If _fields.Count > 0 Then
                Dim fieldsSQL As String = FieldsQuerysToString(New List(Of ColumnInfo)(_fields.Values))
                Dim questionnaireSetTableName As String = IIf(usingMainDB, _
                                                                String.Format("[{0}].[{1}]", BO.ContextClass.Study.DataTableSchema, questionnaireSetTableInfo.DataTableName), _
                                                                String.Format("[{0}]", questionnaireSetTableInfo.PDATableName)).ToString

                query = String.Format("SELECT {0} FROM  {1} ", _
                                  fieldsSQL, _
                                  DataTableQuerysToString((New List(Of TableInfo)(_tables.Values)), questionnaireSetTableInfo.AliasName, usingMainDB, " "))
            End If

        End If

        Return query

    End Function


    Public Sub BuildTree()


        Dim tempVariable As BO.Variable

        'Clearn the combobox
        uxToolStripComboBoxQuestionnaireSet.Items.Clear()

        '------------------------------------------------------------------------------------------------------------------------------
        '------------------------------------------------------------------------------------------------------------------------------
        '----------------------------------Fill the list of MetaData of Section -------------------------------------------------------
        '------------------------------------------------------------------------------------------------------------------------------
        _columnsMetaDataSection = New List(Of BO.Variable)

        tempVariable = New BO.Variable
        tempVariable.Scope = BO.VariableScopes.Section
        tempVariable.MainText = "SubjectID"
        tempVariable.VariableName = "SubjectID"
        tempVariable.DataType = "uniqueidentifier"
        _columnsMetaDataSection.Add(tempVariable)

        tempVariable = New BO.Variable
        tempVariable.Scope = BO.VariableScopes.Section
        tempVariable.MainText = "SubjectQuestionnaireInstanceID"
        tempVariable.VariableName = "SubjectQuestionnaireInstanceID"
        tempVariable.DataType = "tinyint"
        _columnsMetaDataSection.Add(tempVariable)

        tempVariable = New BO.Variable
        tempVariable.Scope = BO.VariableScopes.Section
        tempVariable.MainText = "SubjectCompletedRecord"
        tempVariable.VariableName = "SubjectCompletedRecord"
        tempVariable.DataType = "bit"
        _columnsMetaDataSection.Add(tempVariable)

        tempVariable = New BO.Variable
        tempVariable.Scope = BO.VariableScopes.Section
        tempVariable.MainText = "PDAInsertUser"
        tempVariable.VariableName = "PDAInsertUser"
        tempVariable.DataType = "nvarchar(50)"
        _columnsMetaDataSection.Add(tempVariable)

        tempVariable = New BO.Variable
        tempVariable.Scope = BO.VariableScopes.Section
        tempVariable.MainText = "PDAInsertDate"
        tempVariable.VariableName = "PDAInsertDate"
        tempVariable.DataType = "datetime"
        _columnsMetaDataSection.Add(tempVariable)

        tempVariable = New BO.Variable
        tempVariable.Scope = BO.VariableScopes.Section
        tempVariable.MainText = "PDAInsertVersion"
        tempVariable.VariableName = "PDAInsertVersion"
        tempVariable.DataType = "nvarchar(50)"
        _columnsMetaDataSection.Add(tempVariable)

        tempVariable = New BO.Variable
        tempVariable.Scope = BO.VariableScopes.Section
        tempVariable.MainText = "PDAInsertSN"
        tempVariable.VariableName = "PDAInsertSN"
        tempVariable.DataType = "nvarchar(50)"
        _columnsMetaDataSection.Add(tempVariable)

        tempVariable = New BO.Variable
        tempVariable.Scope = BO.VariableScopes.Section
        tempVariable.MainText = "PDAInsertPDAName"
        tempVariable.VariableName = "PDAInsertPDAName"
        tempVariable.DataType = "nvarchar(50)"
        _columnsMetaDataSection.Add(tempVariable)

        tempVariable = New BO.Variable
        tempVariable.Scope = BO.VariableScopes.Section
        tempVariable.MainText = "PDALastModifUser"
        tempVariable.VariableName = "PDALastModifUser"
        tempVariable.DataType = "nvarchar(50)"
        _columnsMetaDataSection.Add(tempVariable)

        tempVariable = New BO.Variable
        tempVariable.Scope = BO.VariableScopes.Section
        tempVariable.MainText = "PDALastModifDate"
        tempVariable.VariableName = "PDALastModifDate"
        tempVariable.DataType = "datetime"
        _columnsMetaDataSection.Add(tempVariable)

        tempVariable = New BO.Variable
        tempVariable.Scope = BO.VariableScopes.Section
        tempVariable.MainText = "PDALastModifVersion"
        tempVariable.VariableName = "PDALastModifVersion"
        tempVariable.DataType = "nvarchar(50)"
        _columnsMetaDataSection.Add(tempVariable)

        tempVariable = New BO.Variable
        tempVariable.Scope = BO.VariableScopes.Section
        tempVariable.MainText = "PDALastModifSN"
        tempVariable.VariableName = "PDALastModifSN"
        tempVariable.DataType = "nvarchar(50)"
        _columnsMetaDataSection.Add(tempVariable)

        tempVariable = New BO.Variable
        tempVariable.Scope = BO.VariableScopes.Section
        tempVariable.MainText = "PDALastModifPDAName"
        tempVariable.VariableName = "PDALastModifPDAName"
        tempVariable.DataType = "nvarchar(50)"
        _columnsMetaDataSection.Add(tempVariable)

        tempVariable = New BO.Variable
        tempVariable.Scope = BO.VariableScopes.Section
        tempVariable.MainText = "PDALastUploadUser"
        tempVariable.VariableName = "PDALastUploadUser"
        tempVariable.DataType = "nvarchar(50)"
        _columnsMetaDataSection.Add(tempVariable)

        tempVariable = New BO.Variable
        tempVariable.Scope = BO.VariableScopes.Section
        tempVariable.MainText = "PDALastUploadDate"
        tempVariable.VariableName = "PDALastUploadDate"
        tempVariable.DataType = "datetime"
        _columnsMetaDataSection.Add(tempVariable)

        tempVariable = New BO.Variable
        tempVariable.Scope = BO.VariableScopes.Section
        tempVariable.MainText = "PDALastUploadVersion"
        tempVariable.VariableName = "PDALastUploadVersion"
        tempVariable.DataType = "nvarchar(50)"
        _columnsMetaDataSection.Add(tempVariable)

        tempVariable = New BO.Variable
        tempVariable.Scope = BO.VariableScopes.Section
        tempVariable.MainText = "PDALastUploadSN"
        tempVariable.VariableName = "PDALastUploadSN"
        tempVariable.DataType = "nvarchar(50)"
        _columnsMetaDataSection.Add(tempVariable)

        tempVariable = New BO.Variable
        tempVariable.Scope = BO.VariableScopes.Section
        tempVariable.MainText = "PDALastUploadPDAName"
        tempVariable.VariableName = "PDALastUploadPDAName"
        tempVariable.DataType = "nvarchar(50)"
        _columnsMetaDataSection.Add(tempVariable)

        tempVariable = New BO.Variable
        tempVariable.Scope = BO.VariableScopes.Section
        tempVariable.MainText = "ForDeletion"
        tempVariable.VariableName = "ForDeletion"
        tempVariable.DataType = "integer"
        _columnsMetaDataSection.Add(tempVariable)
        '------------------------------------------------------------------------------------------------------------------------------
        '------------------------------------------------------------------------------------------------------------------------------
        '------------------------------------------------------------------------------------------------------------------------------



        '------------------------------------------------------------------------------------------------------------------------------
        '------------------------------------------------------------------------------------------------------------------------------
        '------------------------------------------------------------------------------------------------------------------------------
        '------------------------------------------Fill the list of MetaData of Questionnaire------------------------------------------
        '------------------------------------------------------------------------------------------------------------------------------
        _columnsMetaDataQuestionnaire = New List(Of BO.Variable)

        tempVariable = New BO.Variable
        tempVariable.Scope = BO.VariableScopes.Questionnaire
        tempVariable.MainText = "SubjectID"
        tempVariable.VariableName = "SubjectID"
        tempVariable.DataType = "uniqueidentifier"
        _columnsMetaDataQuestionnaire.Add(tempVariable)

        tempVariable = New BO.Variable
        tempVariable.Scope = BO.VariableScopes.Questionnaire
        tempVariable.MainText = "SubjectQuestionnaireInstanceID"
        tempVariable.VariableName = "SubjectQuestionnaireInstanceID"
        tempVariable.DataType = "tinyint"
        _columnsMetaDataQuestionnaire.Add(tempVariable)

        tempVariable = New BO.Variable
        tempVariable.Scope = BO.VariableScopes.Questionnaire
        tempVariable.MainText = "SubjectCompletedRecord"
        tempVariable.VariableName = "SubjectCompletedRecord"
        tempVariable.DataType = "bit"
        _columnsMetaDataQuestionnaire.Add(tempVariable)

        tempVariable = New BO.Variable
        tempVariable.Scope = BO.VariableScopes.Questionnaire
        tempVariable.MainText = "PDAInsertUser"
        tempVariable.VariableName = "PDAInsertUser"
        tempVariable.DataType = "nvarchar(50)"
        _columnsMetaDataQuestionnaire.Add(tempVariable)

        tempVariable = New BO.Variable
        tempVariable.Scope = BO.VariableScopes.Questionnaire
        tempVariable.MainText = "PDAInsertDate"
        tempVariable.VariableName = "PDAInsertDate"
        tempVariable.DataType = "datetime"
        _columnsMetaDataQuestionnaire.Add(tempVariable)

        tempVariable = New BO.Variable
        tempVariable.Scope = BO.VariableScopes.Questionnaire
        tempVariable.MainText = "PDAInsertVersion"
        tempVariable.VariableName = "PDAInsertVersion"
        tempVariable.DataType = "nvarchar(50)"
        _columnsMetaDataQuestionnaire.Add(tempVariable)

        tempVariable = New BO.Variable
        tempVariable.Scope = BO.VariableScopes.Questionnaire
        tempVariable.MainText = "PDAInsertSN"
        tempVariable.VariableName = "PDAInsertSN"
        tempVariable.DataType = "nvarchar(50)"
        _columnsMetaDataQuestionnaire.Add(tempVariable)

        tempVariable = New BO.Variable
        tempVariable.Scope = BO.VariableScopes.Questionnaire
        tempVariable.MainText = "PDAInsertPDAName"
        tempVariable.VariableName = "PDAInsertPDAName"
        tempVariable.DataType = "nvarchar(50)"
        _columnsMetaDataQuestionnaire.Add(tempVariable)

        tempVariable = New BO.Variable
        tempVariable.Scope = BO.VariableScopes.Questionnaire
        tempVariable.MainText = "PDALastModifUser"
        tempVariable.VariableName = "PDALastModifUser"
        tempVariable.DataType = "nvarchar(50)"
        _columnsMetaDataQuestionnaire.Add(tempVariable)

        tempVariable = New BO.Variable
        tempVariable.Scope = BO.VariableScopes.Questionnaire
        tempVariable.MainText = "PDALastModifDate"
        tempVariable.VariableName = "PDALastModifDate"
        tempVariable.DataType = "datetime"
        _columnsMetaDataQuestionnaire.Add(tempVariable)

        tempVariable = New BO.Variable
        tempVariable.Scope = BO.VariableScopes.Questionnaire
        tempVariable.MainText = "PDALastModifVersion"
        tempVariable.VariableName = "PDALastModifVersion"
        tempVariable.DataType = "nvarchar(50)"
        _columnsMetaDataQuestionnaire.Add(tempVariable)

        tempVariable = New BO.Variable
        tempVariable.Scope = BO.VariableScopes.Questionnaire
        tempVariable.MainText = "PDALastModifSN"
        tempVariable.VariableName = "PDALastModifSN"
        tempVariable.DataType = "nvarchar(50)"
        _columnsMetaDataQuestionnaire.Add(tempVariable)

        tempVariable = New BO.Variable
        tempVariable.Scope = BO.VariableScopes.Questionnaire
        tempVariable.MainText = "PDALastModifPDAName"
        tempVariable.VariableName = "PDALastModifPDAName"
        tempVariable.DataType = "nvarchar(50)"
        _columnsMetaDataQuestionnaire.Add(tempVariable)

        tempVariable = New BO.Variable
        tempVariable.Scope = BO.VariableScopes.Questionnaire
        tempVariable.MainText = "PDALastUploadUser"
        tempVariable.VariableName = "PDALastUploadUser"
        tempVariable.DataType = "nvarchar(50)"
        _columnsMetaDataQuestionnaire.Add(tempVariable)

        tempVariable = New BO.Variable
        tempVariable.Scope = BO.VariableScopes.Questionnaire
        tempVariable.MainText = "PDALastUploadDate"
        tempVariable.VariableName = "PDALastUploadDate"
        tempVariable.DataType = "datetime"
        _columnsMetaDataQuestionnaire.Add(tempVariable)

        tempVariable = New BO.Variable
        tempVariable.Scope = BO.VariableScopes.Questionnaire
        tempVariable.MainText = "PDALastUploadVersion"
        tempVariable.VariableName = "PDALastUploadVersion"
        tempVariable.DataType = "nvarchar(50)"
        _columnsMetaDataQuestionnaire.Add(tempVariable)

        tempVariable = New BO.Variable
        tempVariable.Scope = BO.VariableScopes.Questionnaire
        tempVariable.MainText = "PDALastUploadSN"
        tempVariable.VariableName = "PDALastUploadSN"
        tempVariable.DataType = "nvarchar(50)"
        _columnsMetaDataQuestionnaire.Add(tempVariable)

        tempVariable = New BO.Variable
        tempVariable.Scope = BO.VariableScopes.Questionnaire
        tempVariable.MainText = "PDALastUploadPDAName"
        tempVariable.VariableName = "PDALastUploadPDAName"
        tempVariable.DataType = "nvarchar(50)"
        _columnsMetaDataQuestionnaire.Add(tempVariable)

        tempVariable = New BO.Variable
        tempVariable.Scope = BO.VariableScopes.Questionnaire
        tempVariable.MainText = "ForDeletion"
        tempVariable.VariableName = "ForDeletion"
        tempVariable.DataType = "integer"
        _columnsMetaDataQuestionnaire.Add(tempVariable)
        '------------------------------------------------------------------------------------------------------------------------------
        '------------------------------------------------------------------------------------------------------------------------------
        '------------------------------------------------------------------------------------------------------------------------------




        '------------------------------------------------------------------------------------------------------------------------------
        '------------------------------------------------------------------------------------------------------------------------------
        '------------------------------------------------------------------------------------------------------------------------------
        '----------------------------Fill the list of MetaData of QuestionnaireSet (Subject)-------------------------------------------
        '------------------------------------------------------------------------------------------------------------------------------
        _columnsMetaDataQuestionnaireSet = New List(Of BO.Variable)

        tempVariable = New BO.Variable
        tempVariable.Scope = BO.VariableScopes.QuestionnaireSet
        tempVariable.MainText = "SubjectID"
        tempVariable.VariableName = "SubjectID"
        tempVariable.DataType = "uniqueidentifier"
        _columnsMetaDataQuestionnaireSet.Add(tempVariable)

        tempVariable = New BO.Variable
        tempVariable.Scope = BO.VariableScopes.QuestionnaireSet
        tempVariable.MainText = "SubjectSiteID"
        tempVariable.VariableName = "SubjectSiteID"
        tempVariable.DataType = "int"
        _columnsMetaDataQuestionnaireSet.Insert(1, tempVariable)

        tempVariable = New BO.Variable
        tempVariable.Scope = BO.VariableScopes.QuestionnaireSet
        tempVariable.MainText = "SubjectCompletedStudy"
        tempVariable.VariableName = "SubjectCompletedStudy"
        tempVariable.DataType = "bit"
        _columnsMetaDataQuestionnaireSet.Insert(1, tempVariable)

        tempVariable = New BO.Variable
        tempVariable.Scope = BO.VariableScopes.QuestionnaireSet
        tempVariable.MainText = "PDAInsertUser"
        tempVariable.VariableName = "PDAInsertUser"
        tempVariable.DataType = "nvarchar(50)"
        _columnsMetaDataQuestionnaireSet.Add(tempVariable)

        tempVariable = New BO.Variable
        tempVariable.Scope = BO.VariableScopes.QuestionnaireSet
        tempVariable.MainText = "PDAInsertDate"
        tempVariable.VariableName = "PDAInsertDate"
        tempVariable.DataType = "datetime"
        _columnsMetaDataQuestionnaireSet.Add(tempVariable)

        tempVariable = New BO.Variable
        tempVariable.Scope = BO.VariableScopes.QuestionnaireSet
        tempVariable.MainText = "PDAInsertVersion"
        tempVariable.VariableName = "PDAInsertVersion"
        tempVariable.DataType = "nvarchar(50)"
        _columnsMetaDataQuestionnaireSet.Add(tempVariable)

        tempVariable = New BO.Variable
        tempVariable.Scope = BO.VariableScopes.QuestionnaireSet
        tempVariable.MainText = "PDAInsertSN"
        tempVariable.VariableName = "PDAInsertSN"
        tempVariable.DataType = "nvarchar(50)"
        _columnsMetaDataQuestionnaireSet.Add(tempVariable)

        tempVariable = New BO.Variable
        tempVariable.Scope = BO.VariableScopes.QuestionnaireSet
        tempVariable.MainText = "PDAInsertPDAName"
        tempVariable.VariableName = "PDAInsertPDAName"
        tempVariable.DataType = "nvarchar(50)"
        _columnsMetaDataQuestionnaireSet.Add(tempVariable)

        tempVariable = New BO.Variable
        tempVariable.Scope = BO.VariableScopes.QuestionnaireSet
        tempVariable.MainText = "PDALastModifUser"
        tempVariable.VariableName = "PDALastModifUser"
        tempVariable.DataType = "nvarchar(50)"
        _columnsMetaDataQuestionnaireSet.Add(tempVariable)

        tempVariable = New BO.Variable
        tempVariable.Scope = BO.VariableScopes.QuestionnaireSet
        tempVariable.MainText = "PDALastModifDate"
        tempVariable.VariableName = "PDALastModifDate"
        tempVariable.DataType = "datetime"
        _columnsMetaDataQuestionnaireSet.Add(tempVariable)

        tempVariable = New BO.Variable
        tempVariable.Scope = BO.VariableScopes.QuestionnaireSet
        tempVariable.MainText = "PDALastModifVersion"
        tempVariable.VariableName = "PDALastModifVersion"
        tempVariable.DataType = "nvarchar(50)"
        _columnsMetaDataQuestionnaireSet.Add(tempVariable)

        tempVariable = New BO.Variable
        tempVariable.Scope = BO.VariableScopes.QuestionnaireSet
        tempVariable.MainText = "PDALastModifSN"
        tempVariable.VariableName = "PDALastModifSN"
        tempVariable.DataType = "nvarchar(50)"
        _columnsMetaDataQuestionnaireSet.Add(tempVariable)

        tempVariable = New BO.Variable
        tempVariable.Scope = BO.VariableScopes.QuestionnaireSet
        tempVariable.MainText = "PDALastModifPDAName"
        tempVariable.VariableName = "PDALastModifPDAName"
        tempVariable.DataType = "nvarchar(50)"
        _columnsMetaDataQuestionnaireSet.Add(tempVariable)

        tempVariable = New BO.Variable
        tempVariable.Scope = BO.VariableScopes.QuestionnaireSet
        tempVariable.MainText = "PDALastUploadUser"
        tempVariable.VariableName = "PDALastUploadUser"
        tempVariable.DataType = "nvarchar(50)"
        _columnsMetaDataQuestionnaireSet.Add(tempVariable)

        tempVariable = New BO.Variable
        tempVariable.Scope = BO.VariableScopes.QuestionnaireSet
        tempVariable.MainText = "PDALastUploadDate"
        tempVariable.VariableName = "PDALastUploadDate"
        tempVariable.DataType = "datetime"
        _columnsMetaDataQuestionnaireSet.Add(tempVariable)

        tempVariable = New BO.Variable
        tempVariable.Scope = BO.VariableScopes.QuestionnaireSet
        tempVariable.MainText = "PDALastUploadVersion"
        tempVariable.VariableName = "PDALastUploadVersion"
        tempVariable.DataType = "nvarchar(50)"
        _columnsMetaDataQuestionnaireSet.Add(tempVariable)

        tempVariable = New BO.Variable
        tempVariable.Scope = BO.VariableScopes.QuestionnaireSet
        tempVariable.MainText = "PDALastUploadSN"
        tempVariable.VariableName = "PDALastUploadSN"
        tempVariable.DataType = "nvarchar(50)"
        _columnsMetaDataQuestionnaireSet.Add(tempVariable)

        tempVariable = New BO.Variable
        tempVariable.Scope = BO.VariableScopes.QuestionnaireSet
        tempVariable.MainText = "PDALastUploadPDAName"
        tempVariable.VariableName = "PDALastUploadPDAName"
        tempVariable.DataType = "nvarchar(50)"
        _columnsMetaDataQuestionnaireSet.Add(tempVariable)

        tempVariable = New BO.Variable
        tempVariable.Scope = BO.VariableScopes.QuestionnaireSet
        tempVariable.MainText = "SubjectLastScreenID"
        tempVariable.VariableName = "SubjectLastScreenID"
        tempVariable.DataType = "int"
        _columnsMetaDataQuestionnaireSet.Add(tempVariable)

        tempVariable = New BO.Variable
        tempVariable.Scope = BO.VariableScopes.QuestionnaireSet
        tempVariable.MainText = "SubjectStack"
        tempVariable.VariableName = "SubjectStack"
        tempVariable.DataType = "nvarchar(500)"
        _columnsMetaDataQuestionnaireSet.Add(tempVariable)

        tempVariable = New BO.Variable
        tempVariable.Scope = BO.VariableScopes.QuestionnaireSet
        tempVariable.MainText = "SASubjectID"
        tempVariable.VariableName = "SASubjectID"
        tempVariable.DataType = "nvarchar(50)"
        _columnsMetaDataQuestionnaireSet.Add(tempVariable)

        tempVariable = New BO.Variable
        tempVariable.Scope = BO.VariableScopes.QuestionnaireSet
        tempVariable.MainText = "ForDeletion"
        tempVariable.VariableName = "ForDeletion"
        tempVariable.DataType = "integer"
        _columnsMetaDataQuestionnaireSet.Add(tempVariable)

        '-------------------------------------------------------------------------------------------------------------------------------
        '-------------------------------------------------------------------------------------------------------------------------------
        '-------------------------------------------------------------------------------------------------------------------------------



        If BO.ContextClass.Study IsNot Nothing Then

            'Fill the combobox with the QuestionnaireSet
            For Each currentQuestionnaireSet As BO.QuestionnaireSet In BO.ContextClass.Study.QuestionnarieSets
                uxToolStripComboBoxQuestionnaireSet.Items.Add(currentQuestionnaireSet)
            Next

            ' By default select the first QuestionnaireSet and generate de sructure tree
            If uxToolStripComboBoxQuestionnaireSet.Items.Count > 0 Then
                uxToolStripComboBoxQuestionnaireSet.SelectedIndex = 0
            End If

        End If

    End Sub


    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        TreeNodeDataManager._styles = Me.uxOutline.Styles

    End Sub

#End Region


#Region " Event Handlers"

    'Select All
    Private Sub SelectAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAllToolStripMenuItem.Click, ToolStripSplitButton1.ButtonClick

        For Each node As TreeNodeDataManager In uxOutline.Nodes
            CType(node, TreeNodeDataManager).SetCheckedRecursive(CheckState.Checked) 'TreeNodeDataManager.TrueValue
        Next

    End Sub


    'Deselect All
    Private Sub DeselectAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeselectAllToolStripMenuItem.Click

        For Each node As TreeNodeDataManager In uxOutline.Nodes
            CType(node, TreeNodeDataManager).SetCheckedRecursive(CheckState.Unchecked)
        Next

    End Sub


    'Map the selected QuestionnaireSet
    Private Sub uxToolStripComboBoxQuestionnaireSet_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uxToolStripComboBoxQuestionnaireSet.SelectedIndexChanged
        MapQuestionnaireSet(CType(uxToolStripComboBoxQuestionnaireSet.SelectedItem, BO.QuestionnaireSet))
    End Sub


    'Loads the QuestionnaireSet of the Study to a combobox and loads the structure tree
    Private Sub StructureControl2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    ' Execute Query
    Private Sub ToolButtonExecuteQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolButtonExecuteQuery.Click
        If uxDataManagerForm IsNot Nothing Then
            uxDataManagerForm.ExecuteQuery()
        End If
    End Sub

    'Clear Query
    Private Sub ToolStripButton1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        uxDataManagerForm.ClearQuery()
    End Sub

    ''' <summary>
    ''' Select all the variables of the Tree
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub uxSelectAllVariablesToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uxSelectAllVariablesToolStripMenuItem1.Click
        SetCheckValue(CheckState.Checked, "Variables", CType(uxOutline.Nodes(0), TreeNodeDataManager))
    End Sub

    ''' <summary>
    ''' Unselect all the variables of the Tree
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub uxUnselectAllVariablesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uxUnselectAllVariablesToolStripMenuItem.Click
        SetCheckValue(CheckState.Unchecked, "Variables", CType(uxOutline.Nodes(0), TreeNodeDataManager))
    End Sub

    ''' <summary>
    ''' Select all the metadata of the Tree
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub uxSelectAllMetaDataToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uxSelectAllMetaDataToolStripMenuItem2.Click
        SetCheckValue(CheckState.Checked, "Metadata", CType(uxOutline.Nodes(0), TreeNodeDataManager))
    End Sub

    ''' <summary>
    ''' Unselect all the metadata of the Tree
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub uxUnselectAllMetaDataToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uxUnselectAllMetaDataToolStripMenuItem1.Click
        SetCheckValue(CheckState.Unchecked, "Metadata", CType(uxOutline.Nodes(0), TreeNodeDataManager))
    End Sub


    ''' <summary>
    ''' Cascades and bubble up the new checked state of the current node.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub uxOutline_AfterCheck(ByVal sender As System.Object, ByVal e As DevComponents.AdvTree.AdvTreeCellEventArgs) Handles uxOutline.AfterCheck

        If e.Action <> DevComponents.AdvTree.eTreeAction.Code Then

            Dim queue As New Queue(Of DevComponents.AdvTree.Node)
            queue.Enqueue(e.Cell.Parent)
            While queue.Count > 0

                For Each node As DevComponents.AdvTree.Node In queue.Dequeue().Nodes

                    node.CheckState = e.Cell.CheckState
                    queue.Enqueue(node)

                Next

            End While
            Dim parent As DevComponents.AdvTree.Node = e.Cell.Parent.Parent
            While parent IsNot Nothing

                Dim checked As Boolean = True
                Dim indeterminate As Boolean = False
                For Each node As DevComponents.AdvTree.Node In parent.Nodes

                    checked = checked And node.CheckState = CheckState.Checked
                    indeterminate = indeterminate Or node.CheckState <> CheckState.Unchecked

                Next
                If checked Then

                    parent.CheckState = CheckState.Checked

                ElseIf indeterminate Then

                    parent.CheckState = CheckState.Indeterminate

                Else

                    parent.CheckState = CheckState.Unchecked

                End If
                parent = parent.Parent

            End While

        End If

    End Sub

    ''' <summary>
    ''' If the check state change is not code produced, skips the Intermediate state.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub uxOutline_BeforeCheck(ByVal sender As System.Object, ByVal e As DevComponents.AdvTree.AdvTreeCellBeforeCheckEventArgs) Handles uxOutline.BeforeCheck

        Dim node As TreeNodeDataManager = CType(e.Cell.Parent, TreeNodeDataManager)
        If e.Action <> DevComponents.AdvTree.eTreeAction.Code AndAlso e.NewCheckState = CheckState.Indeterminate Then

            If node.CheckState = CheckState.Checked Then

                node.CheckState = CheckState.Unchecked

            ElseIf node.CheckState = CheckState.Unchecked Then

                node.CheckState = CheckState.Checked

            End If

        End If

    End Sub

    ''' <summary>
    ''' Don't allow to drag nodes inside the tree.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub uxOutline_NodeDragFeedback(ByVal sender As System.Object, ByVal e As DevComponents.AdvTree.TreeDragFeedbackEventArgs) Handles uxOutline.NodeDragFeedback

        e.AllowDrop = False

    End Sub


#End Region


End Class

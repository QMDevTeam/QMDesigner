Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Runtime.Serialization.Formatters.Binary
Imports Raccoom.Windows.Forms
Imports System.IO



Public Class ChooseFiles
    Inherits Form

    Public Class NameComparer
        Implements IComparer(Of String)
        Public Function Compare(x As String, y As String) As Integer Implements IComparer(Of String).Compare
            Return String.Compare(x, y, True)
        End Function
    End Class

    Public Class DirectoryClass
        Public filename As String
        Public path As String
        Public Sub New(ByVal pFilename As String, ByVal pPath As String)
            filename = pFilename
            path = pPath
        End Sub
    End Class

    Public Sub New()
        InitializeComponent()
    End Sub
    Private QMDFiles As List(Of String)
    Private QMDFilesClass As List(Of DirectoryClass)
    Private Provider_ As MainDatabase.SQLProviders

    ''' <summary>
    ''' Sets the SQL providers: SQLServer or SQLLIte check ENUM MainDatabase.SQLProviders
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Public Property Provider() As MainDatabase.SQLProviders
        Set(ByVal value As MainDatabase.SQLProviders)
            Provider_ = value

        End Set
        Get
            Return Provider_
        End Get
    End Property

    Protected Overrides Sub OnLoad(ByVal e As EventArgs)

        If Not DesignMode Then
            'FileStream stream = new System.IO.FileStream("list", FileMode.OpenOrCreate);
            'try
            '{
            '    BinaryFormatter binary = new BinaryFormatter();
            '    this.treeViewFolderBrowser1.SelectedDirectories = binary.Deserialize(stream) as System.Collections.Specialized.StringCollection;
            '}
            'catch { }
            'stream.Close();

            '
            FillDataProviderCombo()
            '
            LblTextSource.Text = LblTextSource.Text.Replace("{0}", Provider_.ToString())
            Me.treeViewFolderBrowser1.DataSource = TryCast(_cmbDataProvider.Items(0), ITreeViewFolderBrowserDataProvider)
            Me.treeViewFolderBrowser1.RootFolder = System.Environment.SpecialFolder.MyComputer

            Me.treeViewFolderBrowser1.Populate(System.Environment.SpecialFolder.MyComputer)

            Me.Text = Application.CompanyName & " - " & Application.ProductName & " " & Application.ProductVersion.Substring(0, 3)


            treeViewFolderBrowser1.Nodes(0).Expand()
            QMDFiles = New List(Of String)
            QMDFilesClass = New List(Of DirectoryClass)
        End If

        MyBase.OnLoad(e)

    End Sub

    Private Sub FillDataProviderCombo()
        Me._cmbDataProvider.Items.Clear()


        Me._cmbDataProvider.Items.Add(New Raccoom.Windows.Forms.TreeViewFolderBrowserDataProvider())
        _cmbDataProvider.SelectedIndex = 0
    End Sub

    Protected Overrides Sub OnClosed(ByVal e As EventArgs)
        'FileStream stream = new System.IO.FileStream("list", FileMode.Create);
        'BinaryFormatter binary = new BinaryFormatter();
        'binary.Serialize(stream, this.treeViewFolderBrowser1.SelectedDirectories);
        'stream.Close();
        '''/
        MyBase.OnClosed(e)
    End Sub


    Public Function GetQMDFiles() As List(Of String)
        Return QMDFiles
    End Function
    Public Function GetQMDFilesClass() As List(Of DirectoryClass)
        Return QMDFilesClass
    End Function

    Private Sub WriteTextBoxQMDfiles(ByVal treeNode As TreeNode, ByVal nodeChecked As Boolean)
        For Each node As TreeNode In treeNode.Nodes

            If node.Checked = nodeChecked Then
                If String.Compare(Convert.ToString(node.Tag), "file") = 0 Then
                    Dim nodePt As TreeNodePath = TryCast(node.Parent, TreeNodePath)
                End If
            End If

            If node.Nodes.Count > 0 Then
                ' If the current node has child nodes, call the CheckAllChildsNodes method recursively.

                Me.WriteTextBoxQMDfiles(node, nodeChecked)
            End If
        Next
    End Sub

    Private Sub WriteCheckedNodes(ByVal treeNode As TreeNode, ByVal nodeChecked As Boolean)
        For Each node As TreeNode In treeNode.Nodes

            If node.Checked = nodeChecked Then
                If String.Compare(Convert.ToString(node.Tag), "file") = 0 Then
                    Dim nodePt As TreeNodePath = TryCast(node.Parent, TreeNodePath)
                    QMDFiles.Add(nodePt.Path + "\" + node.Name)
                    QMDFilesClass.Add(New DirectoryClass(node.Name, nodePt.Path + "\" + node.Name))
                End If
            End If

            If node.Nodes.Count > 0 Then
                ' If the current node has child nodes, call the CheckAllChildsNodes method recursively.

                Me.WriteCheckedNodes(node, nodeChecked)
            End If
        Next
    End Sub


    Private Sub CheckAllChildNodes(ByVal treeNode As TreeNode, ByVal nodeChecked As Boolean)
        For Each node As TreeNode In treeNode.Nodes

            node.Checked = nodeChecked

            If node.Nodes.Count > 0 Then
                ' If the current node has child nodes, call the CheckAllChildsNodes method recursively.

                Me.CheckAllChildNodes(node, nodeChecked)
            End If
        Next
    End Sub

    Private Sub ExpandAllCheckNodes(ByVal treeNode As TreeNode)
        For Each node As TreeNode In treeNode.Nodes
            If node.Checked = True Then
                node.Expand()
            End If

            If node.Nodes.Count > 0 Then
                ' If the current node has child nodes, call the CheckAllChildsNodes method recursively.

                Me.ExpandAllCheckNodes(node)
            End If
        Next
    End Sub


    Private Sub treeViewFolderBrowser1_BeforeCheck(ByVal sender As Object, ByVal e As TreeViewCancelEventArgs) Handles treeViewFolderBrowser1.BeforeCheck

        If e.Action = TreeViewAction.ByMouse Then
            If e.Node.Parent IsNot Nothing Then


                If Not e.Node.Checked Then
                    e.Node.ExpandAll()
                Else
                    e.Node.Collapse()
                End If
                CheckAllChildNodes(e.Node, Not e.Node.Checked)
            Else
                If MessageBox.Show("Bulk import will take more time as you expected in checking the subfolders of the selected node. Do you want to continue?", "Time processing", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.OK Then

                    If Not e.Node.Checked Then
                        e.Node.ExpandAll()
                    Else
                        e.Node.Collapse()
                    End If
                    CheckAllChildNodes(e.Node, Not e.Node.Checked)
                Else
                    e.Cancel = True

                End If
            End If
        End If
    End Sub

    Private Sub Checkfilterfiles(ByVal treeNode As TreeNode)
        Dim filters As String = "*.qmd"


        Dim nodePt As TreeNodePath = TryCast(treeNode, TreeNodePath)


        Dim foundFiles As IO.FileInfo() = SearchAndAddToListWithFilter(nodePt.Path, filters)
        Dim filtered As IO.FileInfo
        For Each filtered In foundFiles


            Dim newnode As TreeNode = New TreeNode(filtered.Name)
            newnode.Name = filtered.Name
            newnode.Checked = True
            newnode.ForeColor = Color.Blue
            newnode.ToolTipText = nodePt.Path
            newnode.Tag = "file"

            Dim nodefound As TreeNode() = treeNode.Nodes.Find(filtered.Name, False)
            If nodefound.Length <= 0 Then
                TreeNode.Nodes.Add(newnode)
                TreeNode.Expand()
            End If
        Next
    End Sub

    Private Sub AddFilterfilesToCheckednodes(ByVal treeNode As TreeNode, ByVal nodeChecked As Boolean)
        For Each node As TreeNode In treeNode.Nodes

            If node.Checked = nodeChecked And String.Compare(Convert.ToString(node.Tag), "file") <> 0 Then
                '' If (treeNode.Level > 1) Then
                Checkfilterfiles(node)
                ''End If
            End If
            If node.Nodes.Count > 0 Then
                ' If the current node has child nodes, call the CheckAllChildsNodes method recursively.

                Me.AddFilterfilesToCheckednodes(node, nodeChecked)


            End If

        Next
        Checkfilterfiles(treeNode)
    End Sub

    Private Sub treeViewFolderBrowser1_AfterCheck(ByVal sender As Object, ByVal e As TreeViewEventArgs) Handles treeViewFolderBrowser1.AfterCheck
        'aca entra si el control esta seteado as singlecheck not recursive.--> entra por cada click en el cheque
        If (e.Action = TreeViewAction.ByMouse) Then

            If (e.Node.Checked And String.Compare(Convert.ToString(e.Node.Tag), "file") <> 0) Then

                AddFilterfilesToCheckednodes(e.Node, True)

            End If

            If (String.Compare(Convert.ToString(e.Node.Tag), "file") <> 0) Then
                WriteTextBoxQMDfiles(e.Node, True)

            End If

        End If

    End Sub




    'public List<string> GetSelectedNodes(TreeNode Nodes)
    '{
    '    List<string> listNodes = new List<string>();
    '    foreach (TreeNode node in Nodes.Nodes)
    '    {
    '        if (node.Checked ==false)
    '        {
    '            this.GetSelectedChildNodeText(node.Text, node.Nodes, ref listNodes);
    '        }
    '        else if (node.Checked == true)
    '        {
    '            listNodes.Add(node.Text);
    '            this.GetSelectedChildNodeText(node.Text, node.Nodes, ref listNodes);
    '        }
    '    }

    '    return listNodes;
    '}

    'private void GetSelectedChildNodeText(string nodeName, TreeNodeCollection nodes, ref List<string> listNodes)
    '{ 
    '    foreach (TreeNode node in nodes)
    '    {
    '        string currentName = string.Format("{0}_{1}", nodeName, node.Text);
    '        if (node.Checked == false)
    '        {
    '            this.GetSelectedChildNodeText(currentName, node.Nodes, ref listNodes);
    '        }
    '        else if (node.Checked == true)
    '        {
    '            listNodes.Add(currentName);
    '            this.GetSelectedChildNodeText(currentName, node.Nodes, ref listNodes);
    '        }
    '    }
    '}

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        QMDFiles.Clear()
        QMDFilesClass.Clear()
        For Each root As TreeNode In treeViewFolderBrowser1.Nodes
            WriteCheckedNodes(root, True)
        Next
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub



    Private Function SearchAndAddToListWithFilter(ByVal path As String, ByVal filters As String) As IO.FileInfo()
        If Not IO.Directory.Exists(path) Then
            Throw New Exception("Path not found")
        End If
        Dim di As New IO.DirectoryInfo(path)
        Dim aryFi As IO.FileInfo() = di.GetFiles(filters, SearchOption.TopDirectoryOnly)

        Return aryFi
    End Function

End Class

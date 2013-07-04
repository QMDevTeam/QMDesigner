Public Class NodeSnapshot

#Region "Properties"

    Private _path As List(Of Integer)
    Private _memoryStream As New IO.MemoryStream
    Private _node As AdvNode
    Private _description As String
    Private _disposable As Boolean

    Private Shared formatter As New Runtime.Serialization.Formatters.Binary.BinaryFormatter()


    ''' <summary>
    ''' Gets path of the node.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public ReadOnly Property Path() As List(Of Integer)
        Get
            Return Me._path
        End Get
    End Property


    ''' <summary>
    ''' Gets or sets the node and childs snapshot.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public ReadOnly Property Snapshot() As AdvNode
        Get

            If _node Is Nothing AndAlso _memoryStream.Length > 0 Then

                Me._memoryStream.Seek(0, IO.SeekOrigin.Begin)
                BO.ContextClass.TrailSerialization = True
                Me._node = formatter.Deserialize(Me._memoryStream)
                BO.ContextClass.TrailSerialization = False

            End If
            Return _node

        End Get
    End Property


    ''' <summary>
    ''' Gets or sets if the snapshot is usefull or not.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Property Disposable() As Boolean
        Get
            Return Me._disposable
        End Get
        Set(ByVal value As Boolean)
            Me._disposable = value
        End Set
    End Property


    ''' <summary>
    ''' Sets or gets the description of the change that was performed.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Property Description() As String
        Get
            Return Me._description
        End Get
        Set(ByVal value As String)
            Me._description = value
        End Set
    End Property

#End Region


#Region "Methods"

    ''' <summary>
    ''' Constructor: Takes a snapshot of the node.
    ''' </summary>
    ''' <param name="node"></param>
    ''' <remarks></remarks>

    Public Sub New(ByVal node As AdvNode)

        Me._disposable = True
        Me._path = node.IndexPath
        Me._node = Nothing
        Me._description = Nothing

        BO.ContextClass.TrailSerialization = True
        formatter.Serialize(Me._memoryStream, node)
        BO.ContextClass.TrailSerialization = False

    End Sub


    ''' <summary>
    ''' Restaures the snapshot of the node.
    ''' </summary>
    ''' <param name="rootNode">Root node of the node.</param>
    ''' <remarks></remarks>

    Public Sub Restore(ByRef rootNode As AdvNode)

        Dim node As AdvNode
        If Me._path.Count = 0 Then

            rootNode = Me.Snapshot

        ElseIf Me._path.Count = 1 Then

            rootNode.Nodes(Me._path(0)) = Me.Snapshot

        Else

            node = rootNode
            For i As Integer = 0 To Me._path.Count - 2

                node = node.Nodes(Me._path(i))

            Next
            node.Nodes(Me._path(Me._path.Count - 1)) = Me.Snapshot

        End If


        If Me.Snapshot.Parent IsNot Nothing Then

            node = Snapshot.Parent

        Else

            node = Snapshot

        End If
        Dim q As New Queue(Of AdvNode)
        q.Enqueue(node)
        While q.Count > 0
            AdvNode.refreshTree = False
            q.Peek.AdvNodeParent.BuildBOFromTree()
            AdvNode.refreshTree = True
            q.Peek.ImageKey = q.Peek.ImageKey
            For Each n As AdvNode In q.Peek.Nodes
                q.Enqueue(n)
            Next
            q.Dequeue()
        End While

    End Sub

#End Region

End Class

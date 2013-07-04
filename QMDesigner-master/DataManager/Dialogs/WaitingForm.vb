Public Class WaitingForm

#Region " Private Members"
    Private ms_oThread As System.Threading.Thread
    Private waiting As Boolean = False
    Private Const _widthOffset As Integer = 57
    Private Const _heightOffset As Integer = 66
#End Region

#Region " Delegate "
    ''' <summary>
    ''' Delegate to manage the changing text methods
    ''' </summary>
    ''' <param name="text">Text or Title, depends of the Method</param>
    ''' <remarks></remarks>
    Delegate Sub TextSubCallback(ByVal [text] As String)
#End Region

#Region " Public Methods "
    ''' <summary>
    ''' Set the Text and Title and Show the Waiting Form
    ''' </summary>
    ''' <param name="text">Text to show in the form</param>
    ''' <param name="title">Title of the Form</param>
    ''' <remarks>The method Start a new Thread to manage the Waiting Form</remarks>
    Public Sub StartWaiting(ByVal text As String, ByVal title As String)

        Me.Label1.Text = text
        Me.Text = title

        ms_oThread = New System.Threading.Thread(New System.Threading.ThreadStart(AddressOf ThreadingJob))
        ms_oThread.IsBackground = True
        ms_oThread.Start()

    End Sub

    ''' <summary>
    ''' Change the Text of the form
    ''' </summary>
    ''' <param name="text"></param>
    ''' <remarks></remarks>
    Public Sub ChangeText(ByVal text As String)
        If Me.Label1.InvokeRequired Then
            Dim mi As New TextSubCallback(AddressOf SetText)
            Me.Label1.Invoke(mi, text)
        Else
            Me.Label1.Text = text
        End If
    End Sub

    ''' <summary>
    ''' Change the Title of the form
    ''' </summary>
    ''' <param name="text"></param>
    ''' <remarks></remarks>
    Public Sub ChangeTitle(ByVal text As String)
        If Me.Label1.InvokeRequired Then
            Dim mi As New TextSubCallback(AddressOf SetTitle)
            Me.Label1.Invoke(mi, text)
        Else
            Me.Label1.Text = text
        End If
    End Sub

    ''' <summary>
    ''' Close the form and the thread
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub StopWaiting()

        If waiting Then
            Dim mi As New MethodInvoker(AddressOf Me.Close)

            Me.BeginInvoke(mi)

            Me.waiting = False
            ms_oThread = Nothing

        End If

    End Sub
#End Region

#Region " Private Methods "
    ''' <summary>
    ''' Start the Thread and show the Form in the new thread
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ThreadingJob()

        Me.waiting = True

        Me.ShowDialog()

    End Sub

    ''' <summary>
    ''' Change the Text of the form
    ''' </summary>
    ''' <param name="text"></param>
    ''' <remarks>This method will be used with the Delegate</remarks>
    Private Sub SetText(ByVal text As String)

        Me.Label1.Text = text

    End Sub

    ''' <summary>
    ''' Change the Title of the form
    ''' </summary>
    ''' <param name="text"></param>
    ''' <remarks>This method will be used with the Delegate</remarks>
    Private Sub SetTitle(ByVal text As String)
        Me.Text = text
    End Sub

#End Region

#Region " Event Handlers "

    Private Sub Label1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.TextChanged

        Dim StringSize As New SizeF

        Dim width As Integer
        Dim height As Integer

        width = Label1.Width + _widthOffset
        height = Label1.Height + _heightOffset

        If width > Me.Width Then
            Me.Width = width
        End If

        If height > Me.Height Then
            Me.Height = height
        End If

    End Sub

#End Region

End Class
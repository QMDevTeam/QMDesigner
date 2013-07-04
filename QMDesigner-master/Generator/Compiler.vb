Imports System.CodeDom
Imports System.CodeDom.Compiler

Public Class Compiler


#Region "Properties"

    Private _compileUnit As CodeCompileUnit
    Private _vbCodeProvider As VBCodeProvider
    Private _references As List(Of String)


    Public Property References() As List(Of String)
        Get
            Return Me._references
        End Get
        Set(ByVal value As List(Of String))
            Me._references = value
        End Set
    End Property

#End Region



#Region "Public methods"

    Public Sub New(ByVal namespaces As CodeNamespaceCollection, ByVal version As String)

        ' Instance reference list.
        Me._references = New List(Of String)

        ' Build the compiler.
        Me._compileUnit = New CodeCompileUnit()
        Me._compileUnit.Namespaces.AddRange(namespaces)

        ' Set the strict option on.
        'Me._compileUnit.UserData("AllowLateBound") = False

        ' Set the version number for the dlls.
        Dim attribute As CodeAttributeDeclaration
        attribute = New CodeAttributeDeclaration(New CodeTypeReference("System.Reflection.AssemblyVersion"))
        attribute.Arguments.Add(New CodeAttributeArgument(New CodePrimitiveExpression(version)))
        Me._compileUnit.AssemblyCustomAttributes.Add(attribute)

    End Sub


    Public Function Compile(ByVal dllFileName As String, ByRef errors As String) As Boolean

        ' Delete if exists.
        If IO.File.Exists(dllFileName) Then IO.File.Delete(dllFileName)

        ' Visual basic code provider.
        Dim vbcp As CodeDomProvider = New VBCodeProvider()

        ' compiler settings for the compilation.
        Dim compilerOptions As New CompilerParameters

        ' Compiler notifications and results.
        Dim returnValue As CompilerResults

        ' .Net Compact Framework instalation path.
        Dim NetCFPath As String = "C:\Program Files\Microsoft.NET\SDK\CompactFramework\v2.0\WindowsCE"

        Dim sdkPath As String = """" & NetCFPath & """"

        ' Dll standard references.
        Dim ref As String = " ""/r:" & NetCFPath & "\System.Data.dll""" & _
                            " ""/r:" & NetCFPath & "\System.dll""" & _
                            " ""/r:" & NetCFPath & "\System.Drawing.dll""" & _
                            " ""/r:" & NetCFPath & "\System.Messaging.dll""" & _
                            " ""/r:" & NetCFPath & "\System.Net.IrDA.dll""" & _
                            " ""/r:" & NetCFPath & "\System.Web.Services.dll""" & _
                            " ""/r:" & NetCFPath & "\System.Windows.Forms.DataGrid.dll""" & _
                            " ""/r:" & NetCFPath & "\System.Windows.Forms.dll""" & _
                            " ""/r:" & NetCFPath & "\Microsoft.WindowsCE.Forms.dll""" & _
                            " ""/r:" & NetCFPath & "\System.Xml.dll""" & _
                            " ""/r:" & NetCFPath & "\Microsoft.VisualBasic.dll"""

        ' Add the extra references if any.
        If Me._references IsNot Nothing AndAlso Me._references.Count > 0 Then

            For Each reference As String In Me._references
                ref &= " ""/r:" & reference & """"
            Next
        End If

        ' Standard imports.
        Dim import As String = "/Imports:Microsoft.VisualBasic,System,System.Data,System.Drawing,System.Windows.Forms"

        compilerOptions.CompilerOptions = "-noconfig -sdkpath:" & sdkPath & " -netcf -nostdlib " & import & " " & ref
        compilerOptions.OutputAssembly = dllFileName
        compilerOptions.IncludeDebugInformation = False
        compilerOptions.GenerateExecutable = False
        compilerOptions.TreatWarningsAsErrors = True

        ' Compile the code.
        returnValue = vbcp.CompileAssemblyFromDom(compilerOptions, Me._compileUnit)

        ' If errors show them.
        If returnValue.Errors.Count > 0 Then

            ' Build the message with all the errors.
            errors = ""
            For Each err As CompilerError In returnValue.Errors

                errors &= String.Format("{0} line {1}: {2}{3}", IIf(err.IsWarning, "Warning", "Error"), err.Line, err.ErrorText, Environment.NewLine)

            Next

        End If

        ' Save the vb file.
        Dim codeWriter As New System.CodeDom.Compiler.IndentedTextWriter(New IO.StreamWriter(dllFileName & ".vb", False))
        vbcp.GenerateCodeFromCompileUnit(Me._compileUnit, codeWriter, Nothing)
        codeWriter.Close()

        ' Return true if no errors.
        Return returnValue.Errors.Count = 0

    End Function

#End Region


End Class

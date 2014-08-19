Imports System.Diagnostics
Public Class clsShellWork
    Private objProcess As Process
    Private objStartInfo As ProcessStartInfo

    Private strOutput As String
    Private strError As String

    Public ReadOnly Property ResultOutput As String
        Get
            Return strOutput
        End Get
    End Property

    Public ReadOnly Property ErrorOutput As String
        Get
            Return strError
        End Get
    End Property


    Public Sub exec_Script(ByVal strScript As String, ByVal strExecutable As String, ByVal strExt As String, Optional strScriptFolder As String = Nothing)
        Dim strFilePath As String
        Dim objTextStream As IO.TextWriter
        Dim objOutputReader As IO.StreamReader
        Dim objErrReader As IO.StreamReader
        Dim objProcStartInfo As ProcessStartInfo
        Dim objProc As Process
        dim strFileName As String

        strFileName = Guid.NewGuid.ToString & "." & strExt
        If strScriptFolder Is Nothing Then
            strFilePath = "%temp%\" & strFileName
        Else 
            strFilePath = strScriptFolder & If(strScriptFolder.EndsWith("\"),"","\") & strFileName
        End If
        strFilePath = Environment.ExpandEnvironmentVariables(strFilePath)

        objTextStream = New IO.StreamWriter(strFilePath, IO.FileMode.Create)

        objTextStream.Write(strScript)

        objTextStream.Close()

        If strExecutable <> "" Then
            objProcStartInfo = New ProcessStartInfo(strExecutable, If(strScriptFolder Is Nothing, strFilePath , strFileName))
            Dim strWorkDir = io.Path.GetDirectoryName(strExecutable)
            If not String.IsNullOrEmpty(strWorkDir) Then
                objProcStartInfo.WorkingDirectory = strWorkDir
            End If
            
        Else
            objProcStartInfo = New ProcessStartInfo(strScript)
        End If

        objProcStartInfo.RedirectStandardOutput = True
        objProcStartInfo.RedirectStandardError = True
        objProcStartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal
        objProcStartInfo.UseShellExecute = False

        objProc = System.Diagnostics.Process.Start(objProcStartInfo)

        objOutputReader = objProc.StandardOutput

        strOutput = objOutputReader.ReadToEnd

        objErrReader = objProc.StandardError

        strError = objErrReader.ReadToEnd
        objOutputReader.Close()
        objErrReader.Close()

        IO.File.Delete(strFilePath)
    End Sub

    Public Function start_Process(ByVal strPath As String, ByVal strParameters As String, ByVal strWorkingDirectory As String, ByVal boolWait As Boolean, ByVal boolBackground As Boolean) As Boolean
        Dim boolResult As Boolean

        objProcess = New Process
        objStartInfo = objProcess.StartInfo
        strPath = Environment.ExpandEnvironmentVariables(strPath)
        objStartInfo.FileName = strPath
        If Not strWorkingDirectory Is Nothing Then
            objStartInfo.WorkingDirectory = strWorkingDirectory
        End If

        If Not strParameters = "" Then
            strParameters = Environment.ExpandEnvironmentVariables(strParameters)
            objStartInfo.Arguments = strParameters
        End If

        objStartInfo.RedirectStandardOutput = False
        objStartInfo.UseShellExecute = True
        If boolBackground = True Then
            objStartInfo.WindowStyle = ProcessWindowStyle.Hidden
        Else
            objStartInfo.WindowStyle = ProcessWindowStyle.Normal
        End If

        Try
            objProcess = Diagnostics.Process.Start(objStartInfo)
            If boolWait = True Then
                objProcess.WaitForExit()
            End If
            boolResult = True
        Catch ex As Exception
            boolResult = False
        End Try

        Return boolResult
    End Function
End Class

Public Class frmPowershellExecutor

    Private Sub ToolStripButton_Exec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_Exec.Click
        If TextBox_Script.Text <> "" Then
            exec_Script(TextBox_Script.Text, ToolStripTextBox_Executable.Text, ToolStripTextBox_ScriptExt.Text)
        Else
            MsgBox("Sie haben kein Script eingegeben!", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub exec_Script(ByVal strScript As String, ByVal strExecutable As String, ByVal strExt As String)
        Dim strFilePath As String
        Dim objTextStream As IO.TextWriter
        Dim objOutputReader As IO.StreamReader
        Dim objErrReader As IO.StreamReader
        Dim objProcStartInfo As ProcessStartInfo
        Dim objProc As Process
        Dim strOutput As String
        Dim strError As String


        strFilePath = "%temp%\" & Guid.NewGuid.ToString & "." & strExt
        strFilePath = Environment.ExpandEnvironmentVariables(strFilePath)

        objTextStream = New IO.StreamWriter(strFilePath, IO.FileMode.Create)

        objTextStream.Write(strScript)

        objTextStream.Close()

        If strExecutable <> "" Then
            objProcStartInfo = New ProcessStartInfo(strExecutable, strFilePath)
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

        Me.TextBox_Output.Text = strOutput & vbCrLf & vbCrLf & strError

    End Sub
End Class

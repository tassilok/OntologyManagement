Imports System.Text.RegularExpressions
Public Class frmPowershellExecutor

    Private WithEvents objFrmSearchOutput As frmSearchOutput

    Private intPos_Start As Integer
    Private intPos_End As Integer

    Private Sub initialized_Search() Handles objFrmSearchOutput.initialized
        intPos_Start = 0
        intPos_End = 0
    End Sub

    Private Sub search(ByVal strSearch As String) Handles objFrmSearchOutput.search
        Dim objRegEx As Regex
        Dim objRegExMatchColl As MatchCollection
        Dim objRegExMatch As Match
        Dim boolInitialize As Boolean

        objRegEx = New Regex(strSearch, RegexOptions.IgnoreCase)
        objRegExMatchColl = objRegEx.Matches(TextBox_Output.Text)

        If objRegExMatchColl.Count > 0 Then
            boolInitialize = True
        Else
            boolInitialize = False
        End If

        For Each objRegExMatch In objRegExMatchColl
            If objRegExMatch.Index > intPos_Start Then
                boolInitialize = False
                intPos_Start = objRegExMatch.Index
                intPos_End = objRegExMatch.Length
                TextBox_Output.Focus()
                TextBox_Output.Select(intPos_Start, intPos_End)
                TextBox_Output.ScrollToCaret()
                Exit For
            End If
        Next

        If boolInitialize = True Then
            intPos_Start = intPos_End = 0
            search(strSearch)
        End If
    End Sub

    

    Private Sub ToolStripButton_Exec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_Exec.Click
        startExecution_Script()
    End Sub

    Private Sub startExecution_Script()
        If TextBox_Script.Text <> "" Then
            exec_Script(TextBox_Script.Text, ToolStripTextBox_Executable.Text, ToolStripTextBox_ScriptExt.Text)
        Else
            MsgBox("Sie haben kein Script eingegeben!", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Public Sub exec_Script(ByVal strScript As String, ByVal strExecutable As String, ByVal strExt As String)
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

    Private Sub ToolStripButton_Paste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_Paste.Click
        TextBox_Script.Text = Clipboard.GetDataObject.ToString
    End Sub

    Private Sub TextBox_Output_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox_Output.KeyDown
        Select Case e.KeyCode
            Case Keys.F5
                startExecution_Script()
            Case Keys.F
                If e.Control = True Then
                    objFrmSearchOutput = New frmSearchOutput()
                    objFrmSearchOutput.Show()
                End If
        End Select
    End Sub
End Class

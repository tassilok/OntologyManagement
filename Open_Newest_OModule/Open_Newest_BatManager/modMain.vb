Imports System.IO
Module modMain
   

    Sub main()
        Dim objDR_Config As DataRow
        
        Dim strExe_Dst As String
        Dim objFrmConfig As frmConfig
        Dim objConfig As New clsConfig
        Dim objFileVersion_SRC As FileVersionInfo
        Dim objFileVersion_DST As FileVersionInfo
        Dim objShellWork As New clsShellWork
        Dim boolCopy As Boolean
        
        Dim strPaths() As String
        Dim strPath As String
        Dim strPath_Create As String

        objConfig.get_Config()
       
        If objConfig.Config_OK = False Or objConfig.Config_Copy = True Then
            objFrmConfig = New frmConfig(objConfig)
            objFrmConfig.ShowDialog()
        End If
        If objConfig.Config_OK Then
            boolCopy = True
            Try
                objFileVersion_SRC = FileVersionInfo.GetVersionInfo(objConfig.Path_Orig & "\" & objConfig.Exe)
                Try
                    If objConfig.Plugin = True Then
                        strExe_Dst = objConfig.PluginExe
                    Else
                        strExe_Dst = objConfig.Exe
                    End If
                    objFileVersion_DST = FileVersionInfo.GetVersionInfo(objConfig.Path_Module & "\" & strExe_Dst)
                    If objFileVersion_SRC.FileVersion = objFileVersion_DST.FileVersion Then
                        boolCopy = False
                    End If

                Catch ex As Exception

                End Try
                If boolCopy = True Then
                    If IO.Directory.Exists(objConfig.Path_Module) Then
                        IO.Directory.Delete(objConfig.Path_Module, True)
                    Else
                        strPaths = objConfig.Path_Module.Split("\")
                        strPath_Create = ""
                        For Each strPath In strPaths
                            strPath_Create = strPath_Create & strPath & "\"
                            If Not IO.Directory.Exists(strPath_Create) Then
                                IO.Directory.CreateDirectory(strPath_Create)
                            End If
                        Next
                    End If

                    copy_Content(objConfig.Path_Orig, objConfig.Path_Module)
                    If objConfig.Plugin = True Then
                        IO.File.Move(objConfig.Path_Module & "\" & objConfig.Exe, objConfig.Path_Module & "\" & strExe_Dst)
                    End If
                End If

                objShellWork.start_Process(objConfig.Path_Module & "\" & strExe_Dst, objConfig.Path_Module, Nothing, False, False)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
        Else
            MsgBox("Die Konfiguration ist fehlerhaft!", MsgBoxStyle.Exclamation)

        End If
        




    End Sub
    
    Private Sub copy_Content(ByVal strPath_SRC As String, ByVal strPath_DST As String)
        Dim strFile_SRC As String
        Dim strFile_DST As String
        Dim strFolder_SRC As String
        Dim strFolder_DST As String
        If IO.Directory.Exists(strPath_DST) = False Then
            IO.Directory.CreateDirectory(strPath_DST)
        End If
        For Each strFile_SRC In IO.Directory.GetFiles(strPath_SRC)
            strFile_DST = strFile_SRC.Replace(strPath_SRC, strPath_DST)
            IO.File.Copy(strFile_SRC, strFile_DST)
        Next

        For Each strFolder_SRC In IO.Directory.GetDirectories(strPath_SRC)
            strFolder_DST = strFolder_SRC.Replace(strPath_SRC, strPath_DST)
            copy_Content(strFolder_SRC, strFolder_DST)
        Next
    End Sub
End Module

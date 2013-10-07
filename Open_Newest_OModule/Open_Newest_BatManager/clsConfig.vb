
Public Class clsConfig
    Private dtbl_BaseConfig As New ds_Config.dtbl_BaseConfigDataTable

    Private strPath_App As String = ""
    Private strPath_Orig As String = ""
    Private strPath_Copy As String = ""
    Private strExe As String = ""
    Private strPluginExe As String = ""
    Private boolPlugin As Boolean = False
    Private boolConfig As Boolean = True
    Private boolConfig_OK As Boolean = False
    Public ReadOnly Property Config_OK() As Boolean
        Get
            Dim boolOK As Boolean = True
            If strPath_Copy = "" Then
                boolOK = False
            End If
            If strPath_Orig = "" Then
                boolOK = False
            End If
            If strExe = "" Then
                boolOK = False
            End If
            If strPluginExe = "" Then
                boolOK = False
            End If
            Return boolOK
        End Get
        
    End Property
    Public Property Path_Orig() As String
        Get
            Return strPath_Orig
        End Get
        Set(ByVal value As String)
            strPath_Orig = value
            change_Config("Path_Orig", strPath_Orig)
        End Set
    End Property
    Public Property Path_Module() As String
        Get
            Return strPath_Copy
        End Get
        Set(ByVal value As String)
            strPath_Copy = value
            change_Config("Path_Copy", strPath_Copy)
        End Set
    End Property
    Public Property Exe() As String
        Get
            Return strExe
        End Get
        Set(ByVal value As String)
            strExe = value
            change_Config("EXE", strExe)
        End Set
    End Property
    Public Property PluginExe() As String
        Get
            Return strPluginExe
        End Get
        Set(ByVal value As String)
            strPluginExe = value
            change_Config("PluginExe", strPluginExe)
        End Set
    End Property
    Public Property Plugin() As Boolean
        Get
            Return boolPlugin
        End Get
        Set(ByVal value As Boolean)
            boolPlugin = value
            change_Config("Plugin", boolPlugin)
        End Set
    End Property
    Public Property Config_Copy() As Boolean
        Get
            Return boolConfig
        End Get
        Set(ByVal value As Boolean)
            boolConfig = value
            change_Config("Config", boolConfig)
        End Set
    End Property

    Public Sub get_Config()
        Dim objDR_Config As DataRow
        dtbl_BaseConfig.Clear()
        If IO.File.Exists("Config.xml") = True Then
            dtbl_BaseConfig.ReadXml(strPath_App & "\Config.xml")
        End If

        For Each objDR_Config In dtbl_BaseConfig.Rows
            Select Case objDR_Config.Item("ConfigItem_Name").ToString.ToLower
                Case "path_orig"
                    strPath_Orig = Environment.ExpandEnvironmentVariables(objDR_Config.Item("ConfigItem_Value"))
                Case "path_copy"
                    strPath_Copy = Environment.ExpandEnvironmentVariables(objDR_Config.Item("ConfigItem_Value"))
                Case "exe"
                    strExe = objDR_Config.Item("ConfigItem_Value")
                Case "pluginexe"
                    strPluginExe = objDR_Config.Item("ConfigItem_Value")
                Case "plugin"
                    If objDR_Config.Item("configItem_Value") = "-1" Or objDR_Config.Item("configItem_Value").ToString.ToLower = "true" Then
                        boolPlugin = True
                    End If
                Case "config"
                    If objDR_Config.Item("configItem_Value") = "0" Or objDR_Config.Item("configItem_Value").ToString.ToLower = "false" Then
                        boolConfig = False
                    End If

            End Select
        Next
    End Sub


    Private Sub change_Config(ByVal strConfigItem_Name As String, ByVal strConfigItem_Value As String)
        Dim objDR_Item As DataRow
        Dim boolCreate As Boolean = False

        For Each objDR_Item In dtbl_BaseConfig.Rows
            If objDR_Item.Item("ConfigItem_Name") = strConfigItem_Name Then
                boolCreate = False
                objDR_Item.Item("ConfigItem_Value") = strConfigItem_Value
                Exit For
            End If
        Next

        If boolCreate = True Then
            dtbl_BaseConfig.Rows.Add(strConfigItem_Name, strConfigItem_Value)
        End If

    End Sub

    Public Function save_Config() As Boolean
        dtbl_BaseConfig.WriteXml(strPath_App & "\Config.xml")
        Return True
    End Function

    Public Sub New()
        strPath_App = Application.StartupPath
    End Sub
End Class

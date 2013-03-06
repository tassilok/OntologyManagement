Imports Ontolog_Module
Public Class clsLocalConfig
    Private cstr_ID_SoftwareDevelopment As String = "488fe6a8ac9048718e3a598667ba8828"
    Private cstr_ID_Class_SoftwareDevelopment As String = "132a845f849f4f6b86847ab3fd068824"
    Private cstr_ID_Class_DevelopmentConfig As String = "c6c9bcb80ac947139417eeec1453026c"
    Private cstr_ID_Class_ConfigItem As String = "13c09f11175c4eefbc8a0fd8e86d557f"
    Private cstr_ID_RelType_needs As String = "fafc1464815f45969737bcbc96bd744a"
    Private cstr_ID_RelType_contains As String = "e971160347db44d8a476fe88290639a4"
    Private cstr_ID_RelType_belongsTo As String = "e07469d9766c443e85266d9c684f944f"

    Private objGlobals As clsGlobals

    Private objOItem_DevConfig As New clsOntologyItem
    Private objOItem_BaseConfig As New clsOntologyItem

    Private objDBLevel_Config1 As clsDBLevel
    Private objDBLevel_Config2 As clsDBLevel

    'Attributes
    Private objOItem_Attribute_Blob As New clsOntologyItem
    Private objOItem_Attribute_Datetimestamp__Create_ As New clsOntologyItem
    Private objOItem_Attribute_Hash As New clsOntologyItem

    'RelationTypes
    Private objOItem_RelationType_Fileshare As New clsOntologyItem
    Private objOItem_RelationType_is_of_Type As New clsOntologyItem
    Private objOItem_RelationType_isInState As New clsOntologyItem
    Private objOItem_RelationType_isSubordinated As New clsOntologyItem
    Private objOItem_RelationType_offered_by As New clsOntologyItem
    Private objOItem_RelationType_ends_with As New clsOntologyItem
    Private objOItem_RelationType_watch As New clsOntologyItem
    Private objOItem_RelationType_belongsTo As New clsOntologyItem
    Private objOItem_RelationType_located_in As New clsOntologyItem
    Private objOItem_RelationType_is_checkout_by As New clsOntologyItem
    Private objOItem_RelationType_belongingSource As New clsOntologyItem

    'Token
    Private objOItem_Token_Active_Server_State As New clsOntologyItem
    Private objOItem_Token_Fileserver_Server_Type As New clsOntologyItem
    Private objOItem_token_LogState_Active As New clsOntologyItem

    'Types
    Private objOItem_Type_Filesystem_Management As New clsOntologyItem
    Private objOItem_Type_Drive As New clsOntologyItem
    Private objOItem_type_Folder As New clsOntologyItem
    Private objOItem_Type_File As New clsOntologyItem
    Private objOItem_Type_Module As New clsOntologyItem
    Private objOItem_Type_Server As New clsOntologyItem
    Private objOItem_Type_Server_State As New clsOntologyItem
    Private objOItem_Type_Server_Type As New clsOntologyItem
    Private objOItem_Type_Extensions As New clsOntologyItem
    Private objOItem_Type_BlobDirWatcher As New clsOntologyItem
    Private objOItem_Type_Database_on_Server As New clsOntologyItem
    Private objOItem_Type_Database As New clsOntologyItem
    Private objOItem_Type_Path As New clsOntologyItem


    'Attributes
    Public ReadOnly Property OItem_Attribute_Blob() As clsOntologyItem
        Get
            Return objOItem_Attribute_Blob
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_Datetimestamp__Create_() As clsOntologyItem
        Get
            Return objOItem_Attribute_Datetimestamp__Create_
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_Hash() As clsOntologyItem
        Get
            Return objOItem_Attribute_Hash
        End Get
    End Property

    'RelationTypes
    Public ReadOnly Property OItem_RelationType_Fileshare() As clsOntologyItem
        Get
            Return objOItem_RelationType_Fileshare
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_is_of_Type() As clsOntologyItem
        Get
            Return objOItem_RelationType_is_of_Type
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_isInState() As clsOntologyItem
        Get
            Return objOItem_RelationType_isInState
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_isSubordinated() As clsOntologyItem
        Get
            Return objOItem_RelationType_isSubordinated
        End Get
    End Property
    Public ReadOnly Property OItem_RelationType_offered_by() As clsOntologyItem
        Get
            Return objOItem_RelationType_offered_by
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_ends_with() As clsOntologyItem
        Get
            Return objOItem_RelationType_ends_with
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_watch() As clsOntologyItem
        Get
            Return objOItem_RelationType_watch
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_belongsTo() As clsOntologyItem
        Get
            Return objOItem_RelationType_belongsTo
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_located_in() As clsOntologyItem
        Get
            Return objOItem_RelationType_located_in
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_is_checkout_by() As clsOntologyItem
        Get
            Return objOItem_RelationType_is_checkout_by
        End Get
    End Property

    'Token
    Public ReadOnly Property OItem_Token_Active_Server_State() As clsOntologyItem
        Get
            Return objOItem_Token_Active_Server_State
        End Get
    End Property

    Public ReadOnly Property OItem_Token_Fileserver_Server_Type() As clsOntologyItem
        Get
            Return objOItem_Token_Fileserver_Server_Type
        End Get
    End Property

    Public ReadOnly Property OItem_token_LogState_Active() As clsOntologyItem
        Get
            Return objOItem_token_LogState_Active
        End Get
    End Property

    'Types
    Public ReadOnly Property OItem_Type_Filesystem_Management() As clsOntologyItem
        Get
            Return objOItem_Type_Filesystem_Management
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Drive() As clsOntologyItem
        Get
            Return objOItem_Type_Drive
        End Get
    End Property

    Public ReadOnly Property OItem_type_Folder() As clsOntologyItem
        Get
            Return objOItem_type_Folder
        End Get
    End Property

    Public ReadOnly Property OItem_Type_File() As clsOntologyItem
        Get
            Return objOItem_Type_File
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Module() As clsOntologyItem
        Get
            Return objOItem_Type_Module
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Server() As clsOntologyItem
        Get
            Return objOItem_Type_Server
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Server_State() As clsOntologyItem
        Get
            Return objOItem_Type_Server_State
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Server_Type() As clsOntologyItem
        Get
            Return objOItem_Type_Server_Type
        End Get
    End Property
    Public ReadOnly Property OItem_Type_Extensions() As clsOntologyItem
        Get
            Return objOItem_Type_Extensions
        End Get
    End Property

    Public ReadOnly Property OItem_Type_BlobDirWatcher() As clsOntologyItem
        Get
            Return objOItem_Type_BlobDirWatcher
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Database_on_Server() As clsOntologyItem
        Get
            Return objOItem_Type_Database_on_Server
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Database() As clsOntologyItem
        Get
            Return objOItem_Type_Database
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Path() As clsOntologyItem
        Get
            Return objOItem_Type_Path
        End Get
    End Property


    Public ReadOnly Property OItem_BaseConfig As clsOntologyItem
        Get
            Return objOItem_BaseConfig
        End Get
    End Property

    Public ReadOnly Property Globals As clsGlobals
        Get
            Return objGlobals
        End Get
    End Property

    Private Sub get_Config()
        get_Config_AttributeTypes()
        get_Config_RelationTypes()
        get_Config_Classes()
        get_Config_Objects()

        get_BaseConfig()
    End Sub

    Private Sub get_BaseConfig()
        Dim oList_ObjectRel As New List(Of clsObjectRel)

        oList_ObjectRel.Add(New clsObjectRel(Nothing, _
                                             OItem_Type_Module.GUID, _
                                             cstr_ID_Class_SoftwareDevelopment, _
                                             Nothing, _
                                             OItem_RelationType_offered_by.GUID, _
                                             objGlobals.Type_Object, _
                                             objGlobals.Direction_RightLeft.GUID, _
                                             Nothing))

        objDBLevel_Config1.get()

    End Sub

    Private Sub get_Config_AttributeTypes()
        Dim objABlob = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object = "Attribute_Blob" And obj.Ontology = objGlobals.Type_AttributeType

        If objABlob.Count > 0 Then
            objOItem_Attribute_Blob = New clsOntologyItem
            objOItem_Attribute_Blob.GUID = objABlob(0).ID_Other
            objOItem_Attribute_Blob.Name = objABlob(0).Name_Other
            objOItem_Attribute_Blob.GUID_Parent = objABlob(0).ID_Parent_Other
            objOItem_Attribute_Blob.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objADSC = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object = "Attribute_Datetimestamp__Create_" And obj.Ontology = objGlobals.Type_AttributeType

        If objADSC.Count > 0 Then
            objOItem_Attribute_Datetimestamp__Create_ = New clsOntologyItem
            objOItem_Attribute_Datetimestamp__Create_.GUID = objADSC(0).ID_Other
            objOItem_Attribute_Datetimestamp__Create_.Name = objADSC(0).Name_Other
            objOItem_Attribute_Datetimestamp__Create_.GUID_Parent = objADSC(0).ID_Parent_Other
            objOItem_Attribute_Datetimestamp__Create_.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objHASH = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object = "Attribute_Hash" And obj.Ontology = objGlobals.Type_AttributeType

        If objHASH.Count > 0 Then
            objOItem_Attribute_Hash = New clsOntologyItem
            objOItem_Attribute_Hash.GUID = objHASH(0).ID_Other
            objOItem_Attribute_Hash.Name = objHASH(0).Name_Other
            objOItem_Attribute_Hash.GUID_Parent = objHASH(0).ID_Parent_Other
            objOItem_Attribute_Hash.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If
    End Sub

    Private Sub get_Config_RelationTypes()


        Dim objFS = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "RelationType_Fileshare" And obj.Ontology = objGlobals.Type_RelationType

        If objFS.Count > 0 Then
            objOItem_RelationType_Fileshare = New clsOntologyItem
            objOItem_RelationType_Fileshare.GUID = objFS(0).ID_Other
            objOItem_RelationType_Fileshare.Name = objFS(0).Name_Other
            objOItem_RelationType_Fileshare.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objIoT = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "RelationType_is_of_Type" And obj.Ontology = objGlobals.Type_RelationType

        If objIoT.Count > 0 Then
            objOItem_RelationType_is_of_Type = New clsOntologyItem
            objOItem_RelationType_is_of_Type.GUID = objIoT(0).ID_Other
            objOItem_RelationType_is_of_Type.Name = objIoT(0).Name_Other
            objOItem_RelationType_is_of_Type.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objIiS = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "RelationType_isInState" And obj.Ontology = objGlobals.Type_RelationType

        If objIiS.Count > 0 Then
            objOItem_RelationType_isInState = New clsOntologyItem
            objOItem_RelationType_isInState.GUID = objIiS(0).ID_Other
            objOItem_RelationType_isInState.Name = objIiS(0).Name_Other
            objOItem_RelationType_isInState.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objiSo = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "RelationType_isSubordinated" And obj.Ontology = objGlobals.Type_RelationType

        If objiSo.Count > 0 Then
            objOItem_RelationType_isSubordinated = New clsOntologyItem
            objOItem_RelationType_isSubordinated.GUID = objiSo(0).ID_Other
            objOItem_RelationType_isSubordinated.Name = objiSo(0).Name_Other
            objOItem_RelationType_isSubordinated.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOB = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "RelationType_offered_by" And obj.Ontology = objGlobals.Type_RelationType

        If objOB.Count > 0 Then
            objOItem_RelationType_offered_by = New clsOntologyItem
            objOItem_RelationType_offered_by.GUID = objOB(0).ID_Other
            objOItem_RelationType_offered_by.Name = objOB(0).Name_Other
            objOItem_RelationType_offered_by.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objEW = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "RelationType_ends_with" And obj.Ontology = objGlobals.Type_RelationType

        If objEW.Count > 0 Then
            objOItem_RelationType_ends_with = New clsOntologyItem
            objOItem_RelationType_ends_with.GUID = objEW(0).ID_Other
            objOItem_RelationType_ends_with.Name = objEW(0).Name_Other
            objOItem_RelationType_ends_with.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objWA = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "RelationType_watch" And obj.Ontology = objGlobals.Type_RelationType

        If objEW.Count > 0 Then
            objOItem_RelationType_watch = New clsOntologyItem
            objOItem_RelationType_watch.GUID = objWA(0).ID_Other
            objOItem_RelationType_watch.Name = objWA(0).Name_Other
            objOItem_RelationType_watch.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objBT = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "RelationType_belongsTo" And obj.Ontology = objGlobals.Type_RelationType

        If objBT.Count > 0 Then
            objOItem_RelationType_belongsTo = New clsOntologyItem
            objOItem_RelationType_belongsTo.GUID = objBT(0).ID_Other
            objOItem_RelationType_belongsTo.Name = objBT(0).Name_Other
            objOItem_RelationType_belongsTo.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objLI = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "RelationType_located_in" And obj.Ontology = objGlobals.Type_RelationType

        If objLI.Count > 0 Then
            objOItem_RelationType_located_in = New clsOntologyItem
            objOItem_RelationType_located_in.GUID = objLI(0).ID_Other
            objOItem_RelationType_located_in.Name = objLI(0).Name_Other
            objOItem_RelationType_located_in.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objCI = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "RelationType_is_checkout_by" And obj.Ontology = objGlobals.Type_RelationType

        If objCI.Count > 0 Then
            objOItem_RelationType_is_checkout_by = New clsOntologyItem
            objOItem_RelationType_is_checkout_by.GUID = objCI(0).ID_Other
            objOItem_RelationType_is_checkout_by.Name = objCI(0).Name_Other
            objOItem_RelationType_is_checkout_by.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objBS = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "RelationType_belonging_Source" And obj.Ontology = objGlobals.Type_RelationType

        If objBS.Count > 0 Then
            objOItem_RelationType_belongingSource = New clsOntologyItem
            objOItem_RelationType_belongingSource.GUID = objBS(0).ID_Other
            objOItem_RelationType_belongingSource.Name = objBS(0).Name_Other
            objOItem_RelationType_belongingSource.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If
    End Sub

    Private Sub get_Config_Classes()



        Dim objDR = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_Drive" And obj.Ontology = objGlobals.Type_Class

        If objDR.Count > 0 Then
            objOItem_Type_Drive = New clsOntologyItem
            objOItem_Type_Drive.GUID = objDR(0).ID_Other
            objOItem_Type_Drive.Name = objDR(0).Name_Other
            objOItem_Type_Drive.GUID_Parent = objDR(0).ID_Parent_Other
            objOItem_Type_Drive.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objFO = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "type_Folder" And obj.Ontology = objGlobals.Type_Class

        If objFO.Count > 0 Then
            objOItem_type_Folder = New clsOntologyItem
            objOItem_type_Folder.GUID = objFO(0).ID_Other
            objOItem_type_Folder.Name = objFO(0).Name_Other
            objOItem_type_Folder.GUID_Parent = objFO(0).ID_Parent_Other
            objOItem_type_Folder.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objFI = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_File" And obj.Ontology = objGlobals.Type_Class

        If objFI.Count > 0 Then
            objOItem_Type_File = New clsOntologyItem
            objOItem_Type_File.GUID = objFI(0).ID_Other
            objOItem_Type_File.Name = objFI(0).Name_Other
            objOItem_Type_File.GUID_Parent = objFI(0).ID_Parent_Other
            objOItem_Type_File.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objFSM = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_Filesystem_Management" And obj.Ontology = objGlobals.Type_Class

        If objFSM.Count > 0 Then
            objOItem_Type_Filesystem_Management = New clsOntologyItem
            objOItem_Type_Filesystem_Management.GUID = objFSM(0).ID_Other
            objOItem_Type_Filesystem_Management.Name = objFSM(0).Name_Other
            objOItem_Type_Filesystem_Management.GUID_Parent = objFSM(0).ID_Parent_Other
            objOItem_Type_Filesystem_Management.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objMO = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_Module" And obj.Ontology = objGlobals.Type_Class

        If objMO.Count > 0 Then
            objOItem_Type_Module = New clsOntologyItem
            objOItem_Type_Module.GUID = objMO(0).ID_Other
            objOItem_Type_Module.Name = objMO(0).Name_Other
            objOItem_Type_Module.GUID_Parent = objMO(0).ID_Parent_Other
            objOItem_Type_Module.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objSER = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_Server" And obj.Ontology = objGlobals.Type_Class

        If objSER.Count > 0 Then
            objOItem_Type_Server = New clsOntologyItem
            objOItem_Type_Server.GUID = objSER(0).ID_Other
            objOItem_Type_Server.Name = objSER(0).Name_Other
            objOItem_Type_Server.GUID_Parent = objSER(0).ID_Parent_Other
            objOItem_Type_Server.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objSST = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_Server_State" And obj.Ontology = objGlobals.Type_Class

        If objSST.Count > 0 Then
            objOItem_Type_Server_State = New clsOntologyItem
            objOItem_Type_Server_State.GUID = objSST(0).ID_Other
            objOItem_Type_Server_State.Name = objSST(0).Name_Other
            objOItem_Type_Server_State.GUID_Parent = objSST(0).ID_Parent_Other
            objOItem_Type_Server_State.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objSERT = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_Server_Type" And obj.Ontology = objGlobals.Type_Class

        If objSERT.Count > 0 Then
            objOItem_Type_Server_Type = New clsOntologyItem
            objOItem_Type_Server_Type.GUID = objSERT(0).ID_Other
            objOItem_Type_Server_Type.Name = objSERT(0).Name_Other
            objOItem_Type_Server_Type.GUID_Parent = objSERT(0).ID_Parent_Other
            objOItem_Type_Server_Type.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objEx = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_Extensions" And obj.Ontology = objGlobals.Type_Class

        If objEx.Count > 0 Then
            objOItem_Type_Extensions = New clsOntologyItem
            objOItem_Type_Extensions.GUID = objEx(0).ID_Other
            objOItem_Type_Extensions.Name = objEx(0).Name_Other
            objOItem_Type_Extensions.GUID_Parent = objEx(0).ID_Parent_Other
            objOItem_Type_Extensions.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objBDW = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_BlobDirWatcher" And obj.Ontology = objGlobals.Type_Class

        If objBDW.Count > 0 Then
            objOItem_Type_BlobDirWatcher = New clsOntologyItem
            objOItem_Type_BlobDirWatcher.GUID = objBDW(0).ID_Other
            objOItem_Type_BlobDirWatcher.Name = objBDW(0).Name_Other
            objOItem_Type_BlobDirWatcher.GUID_Parent = objBDW(0).ID_Parent_Other
            objOItem_Type_BlobDirWatcher.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDOS = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_Database_on_Server" And obj.Ontology = objGlobals.Type_Class

        If objDOS.Count > 0 Then
            objOItem_Type_Database_on_Server = New clsOntologyItem
            objOItem_Type_Database_on_Server.GUID = objDOS(0).ID_Other
            objOItem_Type_Database_on_Server.Name = objDOS(0).Name_Other
            objOItem_Type_Database_on_Server.GUID_Parent = objDOS(0).ID_Parent_Other
            objOItem_Type_Database_on_Server.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDB = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_Database" And obj.Ontology = objGlobals.Type_Class

        If objDB.Count > 0 Then
            objOItem_Type_Database = New clsOntologyItem
            objOItem_Type_Database.GUID = objDB(0).ID_Other
            objOItem_Type_Database.Name = objDB(0).Name_Other
            objOItem_Type_Database.GUID_Parent = objDB(0).ID_Parent_Other
            objOItem_Type_Database.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objPA = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_Path" And obj.Ontology = objGlobals.Type_Class

        If objPA.Count > 0 Then
            objOItem_Type_Path = New clsOntologyItem
            objOItem_Type_Path.GUID = objPA(0).ID_Other
            objOItem_Type_Path.Name = objPA(0).Name_Other
            objOItem_Type_Path.GUID_Parent = objPA(0).ID_Parent_Other
            objOItem_Type_Path.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If
    End Sub

    Private Sub get_Config_Objects()


        Dim objPA = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_Active_Server_State" And obj.Ontology = objGlobals.Type_Object

        If objPA.Count > 0 Then
            objOItem_Token_Active_Server_State = New clsOntologyItem
            objOItem_Token_Active_Server_State.GUID = objPA(0).ID_Other
            objOItem_Token_Active_Server_State.Name = objPA(0).Name_Other
            objOItem_Token_Active_Server_State.GUID_Parent = objPA(0).ID_Parent_Other
            objOItem_Token_Active_Server_State.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objFST = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_Fileserver_Server_Type" And obj.Ontology = objGlobals.Type_Object

        If objFST.Count > 0 Then
            objOItem_Token_Fileserver_Server_Type = New clsOntologyItem
            objOItem_Token_Fileserver_Server_Type.GUID = objFST(0).ID_Other
            objOItem_Token_Fileserver_Server_Type.Name = objFST(0).Name_Other
            objOItem_Token_Fileserver_Server_Type.GUID_Parent = objFST(0).ID_Parent_Other
            objOItem_Token_Fileserver_Server_Type.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objLSA = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "token_LogState_Active" And obj.Ontology = objGlobals.Type_Object

        If objLSA.Count > 0 Then
            objOItem_token_LogState_Active = New clsOntologyItem
            objOItem_token_LogState_Active.GUID = objLSA(0).ID_Other
            objOItem_token_LogState_Active.Name = objLSA(0).Name_Other
            objOItem_token_LogState_Active.GUID_Parent = objLSA(0).ID_Parent_Other
            objOItem_token_LogState_Active.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If


    End Sub


    Private Sub get_Data_DevelopmentConfig()
        Dim objOItem_ObjecRel As clsObjectRel
        Dim oList_SoftwareDevelop As New List(Of clsOntologyItem)
        Dim oList_DevelopmentConfig As New List(Of clsOntologyItem)
        Dim oList_ConfigItems As New List(Of clsOntologyItem)
        Dim oList_RelType_needs As New List(Of clsOntologyItem)
        Dim oList_RelType_contains As New List(Of clsOntologyItem)
        Dim oList_RelType_belongsTo As New List(Of clsOntologyItem)

        Dim oList_ConfigItem As New List(Of clsOntologyItem)

        oList_SoftwareDevelop.Add(New clsOntologyItem(cstr_ID_SoftwareDevelopment, _
                                                      objGlobals.Type_Object))

        oList_DevelopmentConfig.Add(New clsOntologyItem(Nothing, Nothing, cstr_ID_Class_DevelopmentConfig, objGlobals.Type_Object))

        oList_RelType_needs.Add(New clsOntologyItem(cstr_ID_RelType_needs, objGlobals.Type_RelationType))

        objDBLevel_Config1.get_Data_ObjectRel(oList_SoftwareDevelop, _
                                      oList_DevelopmentConfig, _
                                      oList_RelType_needs)

        If objDBLevel_Config1.OList_ObjectRel_ID.Count > 0 Then
            objOItem_DevConfig.GUID = objDBLevel_Config1.OList_ObjectRel_ID(0).ID_Other
            objOItem_DevConfig.Name = objDBLevel_Config1.OList_ObjectRel_ID(0).Name_Other
            objOItem_DevConfig.GUID_Parent = objDBLevel_Config1.OList_ObjectRel_ID(0).ID_Parent_Other
            objOItem_DevConfig.Type = objDBLevel_Config1.OList_ObjectRel_ID(0).Ontology

            oList_DevelopmentConfig.Clear()

            oList_DevelopmentConfig.Add(New clsOntologyItem(objOItem_DevConfig.GUID, objGlobals.Type_Object))

            oList_ConfigItem.Add(New clsOntologyItem(Nothing, Nothing, cstr_ID_Class_ConfigItem, objGlobals.Type_Object))

            oList_RelType_contains.Add(New clsOntologyItem(cstr_ID_RelType_contains, objGlobals.Type_RelationType))

            objDBLevel_Config1.get_Data_ObjectRel(oList_DevelopmentConfig, _
                                          oList_ConfigItem, _
                                          oList_RelType_contains, _
                                          False, _
                                          False, _
                                          False, _
                                          objGlobals.Direction_LeftRight.Name, _
                                          True)

            If objDBLevel_Config1.OList_ObjectRel.Count > 0 Then
                For Each objOItem_ObjecRel In objDBLevel_Config1.OList_ObjectRel
                    oList_ConfigItems.Add(New clsOntologyItem(objOItem_ObjecRel.ID_Other, _
                                                              objGlobals.Type_Object))




                Next

                oList_RelType_belongsTo.Add(New clsOntologyItem(cstr_ID_RelType_belongsTo, objGlobals.Type_RelationType))

                objDBLevel_Config2.get_Data_ObjectRel(oList_ConfigItems, _
                                                         Nothing, _
                                                         oList_RelType_belongsTo, _
                                                         False, _
                                                         False, _
                                                         False, _
                                                         objGlobals.Direction_LeftRight.Name, _
                                                         False)
            Else
                Err.Raise(1, "Config not set!")
            End If

        Else
            Err.Raise(1, "Config not set!")
        End If

    End Sub

    Private Sub set_DBConnection()
        objDBLevel_Config1 = New clsDBLevel(objGlobals)
        objDBLevel_Config2 = New clsDBLevel(objGlobals)
    End Sub

    Public Sub New(ByVal Globals As clsGlobals)
        objGlobals = Globals

        set_DBConnection()

        initialize()
    End Sub

    Private Sub initialize()
        get_Data_DevelopmentConfig()
        get_Config()
    End Sub
End Class

﻿Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Imports System.Reflection
Public Class clsLocalConfig
    Private cstrID_Ontology As String = "6afbdb4bfecb40ca9aa73070e209e31e"

    Private objGlobals As clsGlobals

    Private objOItem_DevConfig As New clsOntologyItem
    Private objOItem_BaseConfig As New clsOntologyItem

    Private objDBLevel_Config1 As clsDBLevel
    Private objDBLevel_Config2 As clsDBLevel

    Private objImport As clsImport

    Public Property OItem_User As clsOntologyItem

    'Attributes
    Private objOItem_Attribute_Blob As New clsOntologyItem
    Private objOItem_Attribute_Datetimestamp__Create_ As New clsOntologyItem
    Private objOItem_Attribute_Hash As New clsOntologyItem
    Private objOItem_attributetype_pattern As New clsOntologyItem
    Private objOItem_attributetype_subitems As New clsOntologyItem
    Private objOItem_attributetype_datetimestamp As clsOntologyItem

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
    Private objOItem_relationtype_belonging_resource As New clsOntologyItem
    Private objOItem_relationtype_connect_to As New clsOntologyItem
    Private objOItem_relationtype_authorized_by As New clsOntologyItem
    Private objOItem_relationtype_secured_by As New clsOntologyItem
    Private objOItem_relationtype_src As clsOntologyItem
    Private objOItem_relationtype_dst As clsOntologyItem
    Private objOItem_relationtype_belonging_done As clsOntologyItem
    Private objOItem_relationtype_belonging As clsOntologyItem
    Private objOItem_relationtype_provides As clsOntologyItem
    Private objOItem_relationtype_last_done As clsOntologyItem

    'Token
    Private objOItem_Token_Active_Server_State As New clsOntologyItem
    Private objOItem_Token_Fileserver_Server_Type As New clsOntologyItem
    Private objOItem_token_LogState_Active As New clsOntologyItem
    Private objOItem_Module As New clsOntologyItem
    Private objOItem_object_create As clsOntologyItem
    Private objOItem_object_file_to_blob As clsOntologyItem
    Private objOItem_object_blob_to_file As clsOntologyItem

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
    Private objOItem_class_fileresource As New clsOntologyItem
    Private objOItem_class_web_connection As New clsOntologyItem
    Private objOItem_class_url As New clsOntologyItem
    Private objOItem_class_user_authentication As New clsOntologyItem
    Private objOItem_class_user As New clsOntologyItem
    Private objOItem_class_password As New clsOntologyItem
    Private objOItem_class_filesync As clsOntologyItem
    Private objOItem_class_blobsyncdirection As clsOntologyItem
    Private objOItem_class_logentry As clsOntologyItem
    Private objOItem_class_logstate As clsOntologyItem

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

    Public ReadOnly Property OItem_Attribute_Pattern() As clsOntologyItem
        Get
            Return objOItem_attributetype_pattern
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_SubItems() As clsOntologyItem
        Get
            Return objOItem_attributetype_subitems
        End Get
    End Property

    Public ReadOnly Property OItem_attributetype_datetimestamp As clsOntologyItem
        Get
            Return objOItem_attributetype_datetimestamp
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

    Public ReadOnly Property OItem_RelationType_belonging_source() As clsOntologyItem
        Get
            Return objOItem_RelationType_belongingSource
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_belonging_Resource() As clsOntologyItem
        Get
            Return objOItem_relationtype_belonging_resource
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_connect_To() As clsOntologyItem
        Get
            Return objOItem_relationtype_connect_to
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_secured_by() As clsOntologyItem
        Get
            Return objOItem_relationtype_secured_by
        End Get
    End Property

    Public ReadOnly Property OItem_relationtype_src As clsOntologyItem
        Get
            Return objOItem_relationtype_src
        End Get
    End Property

    Public ReadOnly Property OItem_relationtype_dst As clsOntologyItem
        Get
            Return objOItem_relationtype_dst
        End Get
    End Property

    Public ReadOnly Property OItem_relationtype_belonging_done As clsOntologyItem
        Get
            Return objOItem_relationtype_belonging_done
        End Get
    End Property

    Public ReadOnly Property OItem_relationtype_belonging As clsOntologyItem
        Get
            Return objOItem_relationtype_belonging
        End Get
    End Property

    Public ReadOnly Property OItem_relationtype_provides As clsOntologyItem
        Get
            Return objOItem_relationtype_provides
        End Get
    End Property

    Public ReadOnly Property OItem_relationtype_last_done As clsOntologyItem
        Get
            Return objOItem_relationtype_last_done
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

    Public ReadOnly Property OItem_Module() As clsOntologyItem
        Get
            Return objOItem_Module
        End Get
    End Property

    Public ReadOnly Property OItem_object_create As clsOntologyItem
        Get
            Return objOItem_object_create
        End Get
    End Property

    Public ReadOnly Property OItem_object_file_to_blob As clsOntologyItem
        Get
            Return objOItem_object_file_to_blob
        End Get
    End Property

    Public ReadOnly Property OItem_object_blob_to_file As clsOntologyItem
        Get
            Return objOItem_object_blob_to_file
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

    Public ReadOnly Property OItem_Type_FileResource() As clsOntologyItem
        Get
            Return objOItem_class_fileresource
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Web_Connection() As clsOntologyItem
        Get
            Return objOItem_class_web_connection
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Url() As clsOntologyItem
        Get
            Return objOItem_class_url
        End Get
    End Property

    Public ReadOnly Property OItem_Type_User() As clsOntologyItem
        Get
            Return objOItem_class_user
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Password() As clsOntologyItem
        Get
            Return objOItem_class_password
        End Get
    End Property

    Public ReadOnly Property OItem_class_filesync As clsOntologyItem
        Get
            Return objOItem_class_filesync
        End Get
    End Property

    Public ReadOnly Property OItem_class_blobsyncdirection As clsOntologyItem
        Get
            Return objOItem_class_blobsyncdirection
        End Get
    End Property

    Public ReadOnly Property OItem_class_logentry As clsOntologyItem
        Get
            Return objOItem_class_logentry
        End Get
    End Property

    Public ReadOnly Property OItem_class_logstate As clsOntologyItem
        Get
            Return objOItem_class_logstate
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
        Try
            get_Data_DevelopmentConfig()
            get_Config_AttributeTypes()
            get_Config_RelationTypes()
            get_Config_Classes()
            get_Config_Objects()

            get_BaseConfig()
        Catch ex As Exception
            Dim objAssembly = [Assembly].GetExecutingAssembly()
            Dim objCustomAttributes() As AssemblyTitleAttribute = objAssembly.GetCustomAttributes(GetType(AssemblyTitleAttribute), False)
            Dim strTitle = "Unbekannt"
            If objCustomAttributes.Length = 1 Then
                strTitle = objCustomAttributes.First().Title
            End If
            If MsgBox(strTitle & ": Die notwendigen Basisdaten konnten nicht geladen werden! Soll versucht werden, sie in der Datenbank " & _
                      objGlobals.Index & "@" & objGlobals.Server & " zu erzeugen?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim objOItem_Result = objImport.ImportTemplates(objAssembly)
                If Not objOItem_Result.GUID = objGlobals.LState_Error.GUID Then
                    get_Data_DevelopmentConfig()
                    get_Config_AttributeTypes()
                    get_Config_RelationTypes()
                    get_Config_Classes()
                    get_Config_Objects()
                    get_BaseConfig()
                Else
                    Err.Raise(1, "Config not importable")
                End If
            Else
                Environment.Exit(0)
            End If
        End Try

    End Sub

    Private Sub get_BaseConfig()
        Dim oList_ObjectRel As New List(Of clsObjectRel)


        oList_ObjectRel.Clear()
        oList_ObjectRel.Add(New clsObjectRel(Nothing, _
                                                Nothing, _
                                                objOItem_Type_BlobDirWatcher.GUID, _
                                                Nothing, _
                                                objOItem_Module.GUID, _
                                                Nothing, _
                                                Nothing, _
                                                Nothing, _
                                                objOItem_RelationType_belongsTo.GUID, _
                                                Nothing, _
                                                objGlobals.Type_Object, _
                                                Nothing, _
                                                Nothing, _
                                                Nothing))

        objDBLevel_Config1.get_Data_ObjectRel(oList_ObjectRel, _
                                                boolIDs:=False)

        If objDBLevel_Config1.OList_ObjectRel.Any() Then
            objOItem_BaseConfig = New clsOntologyItem(objDBLevel_Config1.OList_ObjectRel(0).ID_Object, _
                                                    objDBLevel_Config1.OList_ObjectRel(0).Name_Object, _
                                                    objDBLevel_Config1.OList_ObjectRel(0).ID_Parent_Object, _
                                                    objGlobals.Type_Object)
        Else
            Err.Raise(1, "Config not set")
        End If
    End Sub

    Private Sub get_Config_AttributeTypes()
        Dim objOList_attributetype_datetimestamp = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "attributetype_datetimestamp".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objOList_attributetype_datetimestamp.Count > 0 Then
            objOItem_attributetype_datetimestamp = New clsOntologyItem
            objOItem_attributetype_datetimestamp.GUID = objOList_attributetype_datetimestamp.First().ID_Other
            objOItem_attributetype_datetimestamp.Name = objOList_attributetype_datetimestamp.First().Name_Other
            objOItem_attributetype_datetimestamp.GUID_Parent = objOList_attributetype_datetimestamp.First().ID_Parent_Other
            objOItem_attributetype_datetimestamp.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attributetype_subitems = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "attributetype_subitems".ToLower() And objRef.Ontology = Globals.Type_AttributeType
                                           Select objRef).ToList()

        If objOList_attributetype_subitems.Any() Then
            objOItem_attributetype_subitems = New clsOntologyItem() _
                With {
                    .GUID = objOList_attributetype_subitems.First().ID_Other,
                    .Name = objOList_attributetype_subitems.First().Name_Other,
                    .GUID_Parent = objOList_attributetype_subitems.First().ID_Parent_Other,
                    .Type = Globals.Type_AttributeType
                }
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attributetype_pattern = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "attributetype_pattern".ToLower() And objRef.Ontology = Globals.Type_AttributeType
                                           Select objRef).ToList()

        If objOList_attributetype_pattern.Any() Then
            objOItem_attributetype_pattern = New clsOntologyItem() _
                With {
                    .GUID = objOList_attributetype_pattern.First().ID_Other,
                    .Name = objOList_attributetype_pattern.First().Name_Other,
                    .GUID_Parent = objOList_attributetype_pattern.First().ID_Parent_Other,
                    .Type = Globals.Type_AttributeType
                }
        Else
            Err.Raise(1, "config err")
        End If

        Dim objABlob = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Attribute_Blob".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objABlob.Any() Then
            objOItem_Attribute_Blob = New clsOntologyItem
            objOItem_Attribute_Blob.GUID = objABlob.First().ID_Other
            objOItem_Attribute_Blob.Name = objABlob.First().Name_Other
            objOItem_Attribute_Blob.GUID_Parent = objABlob.First().ID_Parent_Other
            objOItem_Attribute_Blob.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objADSC = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Attribute_Datetimestamp__Create_".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objADSC.Any() Then
            objOItem_Attribute_Datetimestamp__Create_ = New clsOntologyItem
            objOItem_Attribute_Datetimestamp__Create_.GUID = objADSC.First().ID_Other
            objOItem_Attribute_Datetimestamp__Create_.Name = objADSC.First().Name_Other
            objOItem_Attribute_Datetimestamp__Create_.GUID_Parent = objADSC.First().ID_Parent_Other
            objOItem_Attribute_Datetimestamp__Create_.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objHASH = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Attribute_Hash".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objHASH.Any() Then
            objOItem_Attribute_Hash = New clsOntologyItem
            objOItem_Attribute_Hash.GUID = objHASH.First().ID_Other
            objOItem_Attribute_Hash.Name = objHASH.First().Name_Other
            objOItem_Attribute_Hash.GUID_Parent = objHASH.First().ID_Parent_Other
            objOItem_Attribute_Hash.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If
    End Sub

    Private Sub get_Config_RelationTypes()
        Dim objOList_relationtype_last_done = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_last_done".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_last_done.Count > 0 Then
            objOItem_relationtype_last_done = New clsOntologyItem
            objOItem_relationtype_last_done.GUID = objOList_relationtype_last_done.First().ID_Other
            objOItem_relationtype_last_done.Name = objOList_relationtype_last_done.First().Name_Other
            objOItem_relationtype_last_done.GUID_Parent = objOList_relationtype_last_done.First().ID_Parent_Other
            objOItem_relationtype_last_done.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_provides = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_provides".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_provides.Count > 0 Then
            objOItem_relationtype_provides = New clsOntologyItem
            objOItem_relationtype_provides.GUID = objOList_relationtype_provides.First().ID_Other
            objOItem_relationtype_provides.Name = objOList_relationtype_provides.First().Name_Other
            objOItem_relationtype_provides.GUID_Parent = objOList_relationtype_provides.First().ID_Parent_Other
            objOItem_relationtype_provides.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_belonging = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_belonging".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_belonging.Count > 0 Then
            objOItem_relationtype_belonging = New clsOntologyItem
            objOItem_relationtype_belonging.GUID = objOList_relationtype_belonging.First().ID_Other
            objOItem_relationtype_belonging.Name = objOList_relationtype_belonging.First().Name_Other
            objOItem_relationtype_belonging.GUID_Parent = objOList_relationtype_belonging.First().ID_Parent_Other
            objOItem_relationtype_belonging.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_belonging_done = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_belonging_done".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_belonging_done.Count > 0 Then
            objOItem_relationtype_belonging_done = New clsOntologyItem
            objOItem_relationtype_belonging_done.GUID = objOList_relationtype_belonging_done.First().ID_Other
            objOItem_relationtype_belonging_done.Name = objOList_relationtype_belonging_done.First().Name_Other
            objOItem_relationtype_belonging_done.GUID_Parent = objOList_relationtype_belonging_done.First().ID_Parent_Other
            objOItem_relationtype_belonging_done.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_src = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_src".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_src.Count > 0 Then
            objOItem_relationtype_src = New clsOntologyItem
            objOItem_relationtype_src.GUID = objOList_relationtype_src.First().ID_Other
            objOItem_relationtype_src.Name = objOList_relationtype_src.First().Name_Other
            objOItem_relationtype_src.GUID_Parent = objOList_relationtype_src.First().ID_Parent_Other
            objOItem_relationtype_src.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_dst = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                                   Where objOItem.ID_Object = cstrID_Ontology
                                                   Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                                   Where objRef.Name_Object.ToLower() = "relationtype_dst".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                                   Select objRef).ToList()

        If objOList_relationtype_dst.Count > 0 Then
            objOItem_relationtype_dst = New clsOntologyItem
            objOItem_relationtype_dst.GUID = objOList_relationtype_dst.First().ID_Other
            objOItem_relationtype_dst.Name = objOList_relationtype_dst.First().Name_Other
            objOItem_relationtype_dst.GUID_Parent = objOList_relationtype_dst.First().ID_Parent_Other
            objOItem_relationtype_dst.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If
        Dim objOList_relationtype_secured_by = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_secured_by".ToLower() And objRef.Ontology = Globals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_secured_by.Any() Then
            objOItem_relationtype_secured_by = New clsOntologyItem() _
                With {
                    .GUID = objOList_relationtype_secured_by.First().ID_Other,
                    .Name = objOList_relationtype_secured_by.First().Name_Other,
                    .GUID_Parent = objOList_relationtype_secured_by.First().ID_Parent_Other,
                    .Type = Globals.Type_RelationType
                }
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_authorized_by = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_authorized_by".ToLower() And objRef.Ontology = Globals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_authorized_by.Any() Then
            objOItem_relationtype_authorized_by = New clsOntologyItem() _
                With {
                    .GUID = objOList_relationtype_authorized_by.First().ID_Other,
                    .Name = objOList_relationtype_authorized_by.First().Name_Other,
                    .GUID_Parent = objOList_relationtype_authorized_by.First().ID_Parent_Other,
                    .Type = Globals.Type_RelationType
                }
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_connect_to = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_connect_to".ToLower() And objRef.Ontology = Globals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_connect_to.Any() Then
            objOItem_relationtype_connect_to = New clsOntologyItem() _
                With {
                        .GUID = objOList_relationtype_connect_to.First().ID_Other,
                        .Name = objOList_relationtype_connect_to.First().Name_Other,
                        .GUID_Parent = objOList_relationtype_connect_to.First().ID_Parent_Other,
                        .Type = Globals.Type_RelationType
                    }
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_belonging_resource = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_belonging_resource".ToLower() And objRef.Ontology = Globals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_belonging_resource.Any() Then
            objOItem_relationtype_belonging_resource = New clsOntologyItem() _
                With { _
                    .GUID = objOList_relationtype_belonging_resource.First().ID_Other, _
                    .Name = objOList_relationtype_belonging_resource.First().Name_Other, _
                    .GUID_Parent = objOList_relationtype_belonging_resource.First().ID_Parent_Other, _
                    .Type = Globals.Type_RelationType
                }
        Else
            Err.Raise(1, "config err")
        End If

        Dim objFS = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "RelationType_Fileshare".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objFS.Any() Then
            objOItem_RelationType_Fileshare = New clsOntologyItem
            objOItem_RelationType_Fileshare.GUID = objFS.First().ID_Other
            objOItem_RelationType_Fileshare.Name = objFS.First().Name_Other
            objOItem_RelationType_Fileshare.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objIoT = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "RelationType_is_of_Type".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objIoT.Any() Then
            objOItem_RelationType_is_of_Type = New clsOntologyItem
            objOItem_RelationType_is_of_Type.GUID = objIoT.First().ID_Other
            objOItem_RelationType_is_of_Type.Name = objIoT.First().Name_Other
            objOItem_RelationType_is_of_Type.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objIiS = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "RelationType_isInState".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objIiS.Any() Then
            objOItem_RelationType_isInState = New clsOntologyItem
            objOItem_RelationType_isInState.GUID = objIiS.First().ID_Other
            objOItem_RelationType_isInState.Name = objIiS.First().Name_Other
            objOItem_RelationType_isInState.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objiSo = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "RelationType_isSubordinated".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objiSo.Any() Then
            objOItem_RelationType_isSubordinated = New clsOntologyItem
            objOItem_RelationType_isSubordinated.GUID = objiSo.First().ID_Other
            objOItem_RelationType_isSubordinated.Name = objiSo.First().Name_Other
            objOItem_RelationType_isSubordinated.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOB = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "RelationType_offered_by".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOB.Any() Then
            objOItem_RelationType_offered_by = New clsOntologyItem
            objOItem_RelationType_offered_by.GUID = objOB.First().ID_Other
            objOItem_RelationType_offered_by.Name = objOB.First().Name_Other
            objOItem_RelationType_offered_by.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objEW = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "RelationType_ends_with".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objEW.Any() Then
            objOItem_RelationType_ends_with = New clsOntologyItem
            objOItem_RelationType_ends_with.GUID = objEW.First().ID_Other
            objOItem_RelationType_ends_with.Name = objEW.First().Name_Other
            objOItem_RelationType_ends_with.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objWA = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "RelationType_watch".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objEW.Any() Then
            objOItem_RelationType_watch = New clsOntologyItem
            objOItem_RelationType_watch.GUID = objWA.First().ID_Other
            objOItem_RelationType_watch.Name = objWA.First().Name_Other
            objOItem_RelationType_watch.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objBT = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "RelationType_belongsTo".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objBT.Any() Then
            objOItem_RelationType_belongsTo = New clsOntologyItem
            objOItem_RelationType_belongsTo.GUID = objBT.First().ID_Other
            objOItem_RelationType_belongsTo.Name = objBT.First().Name_Other
            objOItem_RelationType_belongsTo.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objLI = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "RelationType_located_in".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objLI.Any() Then
            objOItem_RelationType_located_in = New clsOntologyItem
            objOItem_RelationType_located_in.GUID = objLI.First().ID_Other
            objOItem_RelationType_located_in.Name = objLI.First().Name_Other
            objOItem_RelationType_located_in.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objCI = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "RelationType_is_checkout_by".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objCI.Any() Then
            objOItem_RelationType_is_checkout_by = New clsOntologyItem
            objOItem_RelationType_is_checkout_by.GUID = objCI.First().ID_Other
            objOItem_RelationType_is_checkout_by.Name = objCI.First().Name_Other
            objOItem_RelationType_is_checkout_by.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objBS = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "RelationType_belonging_Source".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objBS.Any() Then
            objOItem_RelationType_belongingSource = New clsOntologyItem
            objOItem_RelationType_belongingSource.GUID = objBS.First().ID_Other
            objOItem_RelationType_belongingSource.Name = objBS.First().Name_Other
            objOItem_RelationType_belongingSource.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If
    End Sub

    Private Sub get_Config_Classes()
        Dim objOList_class_logstate = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "class_logstate".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_class_logstate.Count > 0 Then
            objOItem_class_logstate = New clsOntologyItem
            objOItem_class_logstate.GUID = objOList_class_logstate.First().ID_Other
            objOItem_class_logstate.Name = objOList_class_logstate.First().Name_Other
            objOItem_class_logstate.GUID_Parent = objOList_class_logstate.First().ID_Parent_Other
            objOItem_class_logstate.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_class_logentry = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "class_logentry".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_class_logentry.Count > 0 Then
            objOItem_class_logentry = New clsOntologyItem
            objOItem_class_logentry.GUID = objOList_class_logentry.First().ID_Other
            objOItem_class_logentry.Name = objOList_class_logentry.First().Name_Other
            objOItem_class_logentry.GUID_Parent = objOList_class_logentry.First().ID_Parent_Other
            objOItem_class_logentry.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_class_blobsyncdirection = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "class_blobsyncdirection".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_class_blobsyncdirection.Count > 0 Then
            objOItem_class_blobsyncdirection = New clsOntologyItem
            objOItem_class_blobsyncdirection.GUID = objOList_class_blobsyncdirection.First().ID_Other
            objOItem_class_blobsyncdirection.Name = objOList_class_blobsyncdirection.First().Name_Other
            objOItem_class_blobsyncdirection.GUID_Parent = objOList_class_blobsyncdirection.First().ID_Parent_Other
            objOItem_class_blobsyncdirection.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_class_filesync = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "class_filesync".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_class_filesync.Count > 0 Then
            objOItem_class_filesync = New clsOntologyItem
            objOItem_class_filesync.GUID = objOList_class_filesync.First().ID_Other
            objOItem_class_filesync.Name = objOList_class_filesync.First().Name_Other
            objOItem_class_filesync.GUID_Parent = objOList_class_filesync.First().ID_Parent_Other
            objOItem_class_filesync.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_class_password = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "class_password".ToLower() And objRef.Ontology = Globals.Type_Class
                                           Select objRef).ToList()

        If objOList_class_password.Any() Then
            objOItem_class_password = New clsOntologyItem() _
                With {
                    .GUID = objOList_class_password.First().ID_Other,
                    .Name = objOList_class_password.First().Name_Other,
                    .GUID_Parent = objOList_class_password.First().ID_Parent_Other,
                    .Type = Globals.Type_Class
                }
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_class_user = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                                   Where objOItem.ID_Object = cstrID_Ontology
                                                   Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                                   Where objRef.Name_Object.ToLower() = "class_user".ToLower() And objRef.Ontology = Globals.Type_Class
                                                   Select objRef).ToList()

        If objOList_class_user.Any() Then
            objOItem_class_user = New clsOntologyItem() _
                With {
                    .GUID = objOList_class_user.First().ID_Other,
                    .Name = objOList_class_user.First().Name_Other,
                    .GUID_Parent = objOList_class_user.First().ID_Parent_Other,
                    .Type = Globals.Type_Class
                }
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_class_user_authentication = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "class_user_authentication".ToLower() And objRef.Ontology = Globals.Type_Class
                                           Select objRef).ToList()

        If objOList_class_user_authentication.Any() Then
            objOItem_class_user_authentication = New clsOntologyItem() _
                With {
                    .GUID = objOList_class_user_authentication.First().ID_Other,
                    .Name = objOList_class_user_authentication.First().Name_Other,
                    .GUID_Parent = objOList_class_user_authentication.First().ID_Parent_Other,
                    .Type = Globals.Type_Class
                }
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_class_url = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "class_url".ToLower() And objRef.Ontology = Globals.Type_Class
                                           Select objRef).ToList()

        If objOList_class_url.Any() Then
            objOItem_class_url = New clsOntologyItem() _
                With {
                    .GUID = objOList_class_url.First().ID_Other,
                    .Name = objOList_class_url.First().Name_Other,
                    .GUID_Parent = objOList_class_url.First().ID_Parent_Other,
                    .Type = Globals.Type_Class
                }
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_class_fileresource = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "class_fileresource".ToLower() And objRef.Ontology = Globals.Type_Class
                                           Select objRef).ToList()

        If objOList_class_fileresource.Any() Then
            objOItem_class_fileresource = New clsOntologyItem() _
                With { _
                    .GUID = objOList_class_fileresource.First().ID_Other,
                    .Name = objOList_class_fileresource.First().Name_Other,
                    .GUID_Parent = objOList_class_fileresource.First().ID_Parent_Other,
                    .Type = Globals.Type_Class
                }
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_class_web_connection = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                                   Where objOItem.ID_Object = cstrID_Ontology
                                                   Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                                   Where objRef.Name_Object.ToLower() = "class_web_connection".ToLower() And objRef.Ontology = Globals.Type_Class
                                                   Select objRef).ToList()

        If objOList_class_web_connection.Any() Then
            objOItem_class_web_connection = New clsOntologyItem() _
                 With {
                    .GUID = objOList_class_web_connection.First().ID_Other,
                    .Name = objOList_class_web_connection.First().Name_Other,
                    .GUID_Parent = objOList_class_web_connection.First().ID_Parent_Other,
                    .Type = Globals.Type_Class
                }
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDR = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_Drive".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objDR.Any() Then
            objOItem_Type_Drive = New clsOntologyItem
            objOItem_Type_Drive.GUID = objDR.First().ID_Other
            objOItem_Type_Drive.Name = objDR.First().Name_Other
            objOItem_Type_Drive.GUID_Parent = objDR.First().ID_Parent_Other
            objOItem_Type_Drive.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objFO = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_Folder".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objFO.Any() Then
            objOItem_type_Folder = New clsOntologyItem
            objOItem_type_Folder.GUID = objFO.First().ID_Other
            objOItem_type_Folder.Name = objFO.First().Name_Other
            objOItem_type_Folder.GUID_Parent = objFO.First().ID_Parent_Other
            objOItem_type_Folder.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objFI = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_File".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objFI.Any() Then
            objOItem_Type_File = New clsOntologyItem
            objOItem_Type_File.GUID = objFI.First().ID_Other
            objOItem_Type_File.Name = objFI.First().Name_Other
            objOItem_Type_File.GUID_Parent = objFI.First().ID_Parent_Other
            objOItem_Type_File.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objFSM = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_Filesystem_Management".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objFSM.Any() Then
            objOItem_Type_Filesystem_Management = New clsOntologyItem
            objOItem_Type_Filesystem_Management.GUID = objFSM.First().ID_Other
            objOItem_Type_Filesystem_Management.Name = objFSM.First().Name_Other
            objOItem_Type_Filesystem_Management.GUID_Parent = objFSM.First().ID_Parent_Other
            objOItem_Type_Filesystem_Management.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objMO = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_Module".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objMO.Any() Then
            objOItem_Type_Module = New clsOntologyItem
            objOItem_Type_Module.GUID = objMO.First().ID_Other
            objOItem_Type_Module.Name = objMO.First().Name_Other
            objOItem_Type_Module.GUID_Parent = objMO.First().ID_Parent_Other
            objOItem_Type_Module.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objSER = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_Server".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objSER.Any() Then
            objOItem_Type_Server = New clsOntologyItem
            objOItem_Type_Server.GUID = objSER.First().ID_Other
            objOItem_Type_Server.Name = objSER.First().Name_Other
            objOItem_Type_Server.GUID_Parent = objSER.First().ID_Parent_Other
            objOItem_Type_Server.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objSST = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_Server_State".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objSST.Any() Then
            objOItem_Type_Server_State = New clsOntologyItem
            objOItem_Type_Server_State.GUID = objSST.First().ID_Other
            objOItem_Type_Server_State.Name = objSST.First().Name_Other
            objOItem_Type_Server_State.GUID_Parent = objSST.First().ID_Parent_Other
            objOItem_Type_Server_State.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objSERT = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_Server_Type".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objSERT.Any() Then
            objOItem_Type_Server_Type = New clsOntologyItem
            objOItem_Type_Server_Type.GUID = objSERT.First().ID_Other
            objOItem_Type_Server_Type.Name = objSERT.First().Name_Other
            objOItem_Type_Server_Type.GUID_Parent = objSERT.First().ID_Parent_Other
            objOItem_Type_Server_Type.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objEx = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_Extensions".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objEx.Any() Then
            objOItem_Type_Extensions = New clsOntologyItem
            objOItem_Type_Extensions.GUID = objEx.First().ID_Other
            objOItem_Type_Extensions.Name = objEx.First().Name_Other
            objOItem_Type_Extensions.GUID_Parent = objEx.First().ID_Parent_Other
            objOItem_Type_Extensions.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objBDW = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_BlobDirWatcher".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objBDW.Any() Then
            objOItem_Type_BlobDirWatcher = New clsOntologyItem
            objOItem_Type_BlobDirWatcher.GUID = objBDW.First().ID_Other
            objOItem_Type_BlobDirWatcher.Name = objBDW.First().Name_Other
            objOItem_Type_BlobDirWatcher.GUID_Parent = objBDW.First().ID_Parent_Other
            objOItem_Type_BlobDirWatcher.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDOS = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_Database_on_Server".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objDOS.Any() Then
            objOItem_Type_Database_on_Server = New clsOntologyItem
            objOItem_Type_Database_on_Server.GUID = objDOS.First().ID_Other
            objOItem_Type_Database_on_Server.Name = objDOS.First().Name_Other
            objOItem_Type_Database_on_Server.GUID_Parent = objDOS.First().ID_Parent_Other
            objOItem_Type_Database_on_Server.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDB = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_Database".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objDB.Any() Then
            objOItem_Type_Database = New clsOntologyItem
            objOItem_Type_Database.GUID = objDB.First().ID_Other
            objOItem_Type_Database.Name = objDB.First().Name_Other
            objOItem_Type_Database.GUID_Parent = objDB.First().ID_Parent_Other
            objOItem_Type_Database.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objPA = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_Path".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objPA.Any() Then
            objOItem_Type_Path = New clsOntologyItem
            objOItem_Type_Path.GUID = objPA.First().ID_Other
            objOItem_Type_Path.Name = objPA.First().Name_Other
            objOItem_Type_Path.GUID_Parent = objPA.First().ID_Parent_Other
            objOItem_Type_Path.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If
    End Sub

    Private Sub get_Config_Objects()
        Dim objOList_object_file_to_blob = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "object_file_to_blob".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objOList_object_file_to_blob.Count > 0 Then
            objOItem_object_file_to_blob = New clsOntologyItem
            objOItem_object_file_to_blob.GUID = objOList_object_file_to_blob.First().ID_Other
            objOItem_object_file_to_blob.Name = objOList_object_file_to_blob.First().Name_Other
            objOItem_object_file_to_blob.GUID_Parent = objOList_object_file_to_blob.First().ID_Parent_Other
            objOItem_object_file_to_blob.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_object_blob_to_file = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                                   Where objOItem.ID_Object = cstrID_Ontology
                                                   Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                                   Where objRef.Name_Object.ToLower() = "object_blob_to_file".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                                   Select objRef).ToList()

        If objOList_object_blob_to_file.Count > 0 Then
            objOItem_object_blob_to_file = New clsOntologyItem
            objOItem_object_blob_to_file.GUID = objOList_object_blob_to_file.First().ID_Other
            objOItem_object_blob_to_file.Name = objOList_object_blob_to_file.First().Name_Other
            objOItem_object_blob_to_file.GUID_Parent = objOList_object_blob_to_file.First().ID_Parent_Other
            objOItem_object_blob_to_file.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_object_create = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "object_create".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objOList_object_create.Count > 0 Then
            objOItem_object_create = New clsOntologyItem
            objOItem_object_create.GUID = objOList_object_create.First().ID_Other
            objOItem_object_create.Name = objOList_object_create.First().Name_Other
            objOItem_object_create.GUID_Parent = objOList_object_create.First().ID_Parent_Other
            objOItem_object_create.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objPA = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Token_Active_Server_State".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objPA.Any() Then
            objOItem_Token_Active_Server_State = New clsOntologyItem
            objOItem_Token_Active_Server_State.GUID = objPA.First().ID_Other
            objOItem_Token_Active_Server_State.Name = objPA.First().Name_Other
            objOItem_Token_Active_Server_State.GUID_Parent = objPA.First().ID_Parent_Other
            objOItem_Token_Active_Server_State.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objFST = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Token_Fileserver_Server_Type".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objFST.Any() Then
            objOItem_Token_Fileserver_Server_Type = New clsOntologyItem
            objOItem_Token_Fileserver_Server_Type.GUID = objFST.First().ID_Other
            objOItem_Token_Fileserver_Server_Type.Name = objFST.First().Name_Other
            objOItem_Token_Fileserver_Server_Type.GUID_Parent = objFST.First().ID_Parent_Other
            objOItem_Token_Fileserver_Server_Type.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objLSA = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "token_LogState_Active".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objLSA.Any() Then
            objOItem_token_LogState_Active = New clsOntologyItem
            objOItem_token_LogState_Active.GUID = objLSA.First().ID_Other
            objOItem_token_LogState_Active.Name = objLSA.First().Name_Other
            objOItem_token_LogState_Active.GUID_Parent = objLSA.First().ID_Parent_Other
            objOItem_token_LogState_Active.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If


    End Sub


    Private Sub get_Data_DevelopmentConfig()
        Dim objORL_Ontology_To_OntolgyItems = New List(Of clsObjectRel) From {New clsObjectRel With {.ID_Object = cstrID_Ontology, _
                                                                                             .ID_RelationType = objGlobals.RelationType_contains.GUID, _
                                                                                             .ID_Parent_Other = objGlobals.Class_OntologyItems.GUID}}



        Dim objOItem_Result = objDBLevel_Config1.get_Data_ObjectRel(objORL_Ontology_To_OntolgyItems, boolIDs:=False)
        If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then
            If objDBLevel_Config1.OList_ObjectRel.Any Then

                objORL_Ontology_To_OntolgyItems = objDBLevel_Config1.OList_ObjectRel.Select(Function(oi) New clsObjectRel With {.ID_Object = oi.ID_Other,
                                                                                                                                .ID_RelationType = objGlobals.RelationType_belongingAttribute.GUID}).ToList()
                objORL_Ontology_To_OntolgyItems.AddRange(objDBLevel_Config1.OList_ObjectRel.Select(Function(oi) New clsObjectRel With {.ID_Object = oi.ID_Other,
                                                                                                                                .ID_RelationType = objGlobals.RelationType_belongingClass.GUID}))
                objORL_Ontology_To_OntolgyItems.AddRange(objDBLevel_Config1.OList_ObjectRel.Select(Function(oi) New clsObjectRel With {.ID_Object = oi.ID_Other,
                                                                                                                                .ID_RelationType = objGlobals.RelationType_belongingObject.GUID}))
                objORL_Ontology_To_OntolgyItems.AddRange(objDBLevel_Config1.OList_ObjectRel.Select(Function(oi) New clsObjectRel With {.ID_Object = oi.ID_Other,
                                                                                                                                .ID_RelationType = objGlobals.RelationType_belongingRelationType.GUID}))

                objOItem_Result = objDBLevel_Config2.get_Data_ObjectRel(objORL_Ontology_To_OntolgyItems, boolIDs:=False)
                If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then
                    If Not objDBLevel_Config2.OList_ObjectRel.Any Then
                        Err.Raise(1, "Config-Error")
                    End If
                Else
                    Err.Raise(1, "Config-Error")
                End If

            Else
                Err.Raise(1, "Config-Error")
            End If

        End If

    End Sub

    Private Sub set_DBConnection()
        objDBLevel_Config1 = New clsDBLevel(objGlobals)
        objDBLevel_Config2 = New clsDBLevel(objGlobals)
        objImport = New clsImport(objGlobals)

    End Sub

    Public Sub New(ByVal Globals As clsGlobals)
        objGlobals = Globals

        set_DBConnection()

        initialize()
    End Sub

    Private Sub initialize()

        get_Config()
    End Sub
End Class

Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Public Class clsLocalConfig
    Private Const cint_ImageID_Root As Integer = 0
    Private Const cint_ImageID_Process As Integer = 1

    Private cint_ImageID_Ref As Integer = 0
    Private cint_ImageID_Class As Integer = 1
    Private cint_ImageID_Object As Integer = 2
    Private cint_ImageID_Attribute As Integer = 3
    Private cint_ImageID_RelationType As Integer = 4
    Private cint_ImageID_Manual As Integer = 5
    Private cint_ImageID_Needs As Integer = 6
    Private cint_ImageID_NeedsChild As Integer = 7
    Private cint_ImageID_Variable As Integer = 8
    Private cint_ImageID_Responsibility As Integer = 9
    Private cint_ImageID_Group As Integer = 10
    Private cint_ImageID_User As Integer = 11
    Private cint_ImageID_Document As Integer = 12
    Private cint_ImageID_File As Integer = 13
    Private cint_ImageID_Folder As Integer = 14
    Private cint_ImageID_Role As Integer = 15
    Private cint_ImageID_Application As Integer = 16
    Private cint_ImageID_Media As Integer = 17
    Private cint_ImageID_Belonging As Integer = 18
    Private cint_ImageID_Util As Integer = 58
    Private cint_ImageID_Material As Integer = 59

    Private cint_ImageID_Refs As Integer = 19
    Private cint_ImageID_Classes As Integer = 20
    Private cint_ImageID_Objects As Integer = 21
    Private cint_ImageID_Attributes As Integer = 22
    Private cint_ImageID_RelationTypes As Integer = 23
    Private cint_ImageID_Manuals As Integer = 24
    Private cint_ImageID_NeedsPar As Integer = 25
    Private cint_ImageID_NeedsChildPar As Integer = 26
    Private cint_ImageID_Variables As Integer = 27
    Private cint_ImageID_Responsibilities As Integer = 28
    Private cint_ImageID_Groups As Integer = 29
    Private cint_ImageID_Users As Integer = 30
    Private cint_ImageID_Documents As Integer = 31
    Private cint_ImageID_Files As Integer = 32
    Private cint_ImageID_Folders As Integer = 33
    Private cint_ImageID_Roles As Integer = 34
    Private cint_ImageID_Applications As Integer = 35
    Private cint_ImageID_Medias As Integer = 36
    Private cint_ImageID_Belongings As Integer = 37
    Private cint_ImageID_Utils As Integer = 60
    Private cint_ImageID_Materials As Integer = 61

    Private cint_ImageID_VarVal As Integer = 38

    Private cint_ImageID_Log_Ref As Integer = 39
    Private cint_ImageID_Log_Class As Integer = 40
    Private cint_ImageID_Log_Object As Integer = 41
    Private cint_ImageID_Log_Attribute As Integer = 42
    Private cint_ImageID_Log_RelationType As Integer = 43
    Private cint_ImageID_Log_Manual As Integer = 44
    Private cint_ImageID_Log_Needs As Integer = 45
    Private cint_ImageID_Log_NeedsChild As Integer = 46
    Private cint_ImageID_Log_Variable As Integer = 47
    Private cint_ImageID_Log_Responsibility As Integer = 48
    Private cint_ImageID_Log_Group As Integer = 49
    Private cint_ImageID_Log_User As Integer = 50
    Private cint_ImageID_Log_Document As Integer = 51
    Private cint_ImageID_Log_File As Integer = 52
    Private cint_ImageID_Log_Folder As Integer = 53
    Private cint_ImageID_Log_Role As Integer = 53
    Private cint_ImageID_Log_Application As Integer = 55
    Private cint_ImageID_Log_Media As Integer = 56
    Private cint_ImageID_Log_Belonging As Integer = 57
    Private cint_ImageID_Log_Util As Integer = 62
    Private cint_ImageID_Log_Material As Integer = 63

    Private cstr_ID_SoftwareDevelopment As String = "6737a36c9a54448b84f950fac896c5ae"
    Private cstr_ID_Class_SoftwareDevelopment As String = "132a845f849f4f6b86847ab3fd068824"
    Private cstr_ID_Class_DevelopmentConfig As String = "c6c9bcb80ac947139417eeec1453026c"
    Private cstr_ID_Class_ConfigItem As String = "13c09f11175c4eefbc8a0fd8e86d557f"
    Private cstr_ID_RelType_needs As String = "fafc1464815f45969737bcbc96bd744a"
    Private cstr_ID_RelType_contains As String = "e971160347db44d8a476fe88290639a4"
    Private cstr_ID_RelType_belongsTo As String = "e07469d9766c443e85266d9c684f944f"

    Private objGlobals As clsGlobals

    Private objOItem_DevConfig As New clsOntologyItem

    Private objDBLevel_Config1 As clsDBLevel
    Private objDBLevel_Config2 As clsDBLevel
    Private objDBLevel_Languages As clsDBLevel

    'Attributes
    Private objOItem_Attribute_Count As New clsOntologyItem
    Private objOItem_attribute_dbPostfix As New clsOntologyItem
    Private objOItem_Attribute_Description As New clsOntologyItem
    Private objOItem_Attribute_Public As New clsOntologyItem
    Private objOItem_Attribute_Value As New clsOntologyItem

    'RelationTypes
    Private objOItem_RelationType_belonging_Material As New clsOntologyItem
    Private objOItem_RelationType_belonging_Sem_Item As New clsOntologyItem
    Private objOItem_RelationType_belonging_Util As New clsOntologyItem
    Private objOItem_RelationType_belongsTo As New clsOntologyItem
    Private objOItem_RelationType_contains As New clsOntologyItem
    Private objOItem_RelationType_isDescribedBy As New clsOntologyItem
    Private objOItem_RelationType_needed_Documentation As New clsOntologyItem
    Private objOItem_RelationType_needs As New clsOntologyItem
    Private objOItem_RelationType_needs_authority As New clsOntologyItem
    Private objOItem_RelationType_needs_Child As New clsOntologyItem
    Private objOItem_RelationType_offered_by As New clsOntologyItem
    Private objOItem_RelationType_superordinate As New clsOntologyItem

    'Classes
    Private objOItem_Type_Application As New clsOntologyItem
    Private objOItem_Type_File As New clsOntologyItem
    Private objOItem_type_Folder As New clsOntologyItem
    Private objOItem_Type_Group As New clsOntologyItem
    Private objOItem_Type_Language As New clsOntologyItem
    Private objOItem_Type_Manual As New clsOntologyItem
    Private objOItem_Type_Media As New clsOntologyItem
    Private objOItem_Type_Module As New clsOntologyItem
    Private objOItem_Type_Process As New clsOntologyItem
    Private objOItem_Type_Process_Module As New clsOntologyItem
    Private objOItem_Type_Process_References As New clsOntologyItem
    Private objOItem_Type_responsibility As New clsOntologyItem
    Private objOItem_Type_Role As New clsOntologyItem
    Private objOItem_Type_Things_References As New clsOntologyItem
    Private objOItem_type_User As New clsOntologyItem
    Private objOItem_Type_Variable As New clsOntologyItem


    Private objOItem_Development As clsOntologyItem
    Private objOItem_BaseConfig As clsOntologyItem

    Public ReadOnly Property ImageID_Root As Integer
        Get
            Return cint_ImageID_Root
        End Get
    End Property

    Public ReadOnly Property ImageID_Process As Integer
        Get
            Return cint_ImageID_Process
        End Get
    End Property

    Public ReadOnly Property ImageID_Application As Integer
        Get
            Return cint_ImageID_Application
        End Get
    End Property

    Public ReadOnly Property ImageID_Applications As Integer
        Get
            Return cint_ImageID_Applications
        End Get
    End Property

    Public ReadOnly Property ImageID_Attribute As Integer
        Get
            Return cint_ImageID_Attribute
        End Get
    End Property

    Public ReadOnly Property ImageID_Attributes As Integer
        Get
            Return cint_ImageID_Attributes
        End Get
    End Property

    Public ReadOnly Property ImageID_Belonging As Integer
        Get
            Return cint_ImageID_Belonging
        End Get
    End Property

    Public ReadOnly Property ImageID_Belongings As Integer
        Get
            Return cint_ImageID_Belongings
        End Get
    End Property

    Public ReadOnly Property ImageID_Class As Integer
        Get
            Return cint_ImageID_Class
        End Get
    End Property

    Public ReadOnly Property ImageID_Classes As Integer
        Get
            Return cint_ImageID_Classes
        End Get
    End Property

    Public ReadOnly Property ImageID_Document As Integer
        Get
            Return cint_ImageID_Document
        End Get
    End Property

    Public ReadOnly Property ImageID_Documents As Integer
        Get
            Return cint_ImageID_Documents
        End Get
    End Property

    Public ReadOnly Property ImageID_File As Integer
        Get
            Return cint_ImageID_File
        End Get
    End Property

    Public ReadOnly Property ImageID_Files As Integer
        Get
            Return cint_ImageID_Files
        End Get
    End Property

    Public ReadOnly Property ImageID_Folder As Integer
        Get
            Return cint_ImageID_Folder
        End Get
    End Property

    Public ReadOnly Property ImageID_Folders As Integer
        Get
            Return cint_ImageID_Folders
        End Get
    End Property

    Public ReadOnly Property ImageID_Group As Integer
        Get
            Return cint_ImageID_Group
        End Get
    End Property

    Public ReadOnly Property ImageID_Groups As Integer
        Get
            Return cint_ImageID_Groups
        End Get
    End Property

    Public ReadOnly Property ImageID_Log_Application As Integer
        Get
            Return cint_ImageID_Log_Application
        End Get
    End Property

    Public ReadOnly Property ImageID_Log_Attribute As Integer
        Get
            Return cint_ImageID_Log_Attribute
        End Get
    End Property

    Public ReadOnly Property ImageID_Log_Belonging As Integer
        Get
            Return cint_ImageID_Log_Belonging
        End Get
    End Property

    Public ReadOnly Property ImageID_Log_Class As Integer
        Get
            Return cint_ImageID_Log_Class
        End Get
    End Property

    Public ReadOnly Property ImageID_Log_Document As Integer
        Get
            Return cint_ImageID_Log_Document
        End Get
    End Property

    Public ReadOnly Property ImageID_Log_File As Integer
        Get
            Return cint_ImageID_Log_File
        End Get
    End Property

    Public ReadOnly Property ImageID_Log_Folder As Integer
        Get
            Return cint_ImageID_Log_Folder
        End Get
    End Property

    Public ReadOnly Property ImageID_Log_Group As Integer
        Get
            Return cint_ImageID_Log_Group
        End Get
    End Property

    Public ReadOnly Property ImageID_Log_Manual As Integer
        Get
            Return cint_ImageID_Log_Manual
        End Get
    End Property

    Public ReadOnly Property ImageID_Log_Material As Integer
        Get
            Return cint_ImageID_Log_Material
        End Get
    End Property

    Public ReadOnly Property ImageID_Log_Media As Integer
        Get
            Return cint_ImageID_Log_Media
        End Get
    End Property

    Public ReadOnly Property ImageID_Log_Needs As Integer
        Get
            Return cint_ImageID_Log_Needs
        End Get
    End Property

    Public ReadOnly Property ImageID_Log_NeedsChild As Integer
        Get
            Return cint_ImageID_Log_NeedsChild
        End Get
    End Property

    Public ReadOnly Property ImageID_Log_Object As Integer
        Get
            Return cint_ImageID_Log_Object
        End Get
    End Property

    Public ReadOnly Property ImageID_Log_Ref As Integer
        Get
            Return cint_ImageID_Log_Ref
        End Get
    End Property

    Public ReadOnly Property ImageID_Log_RelationType As Integer
        Get
            Return cint_ImageID_Log_RelationType
        End Get
    End Property

    Public ReadOnly Property ImageID_Log_Responsibility As Integer
        Get
            Return cint_ImageID_Log_Responsibility
        End Get
    End Property

    Public ReadOnly Property ImageID_Log_Role As Integer
        Get
            Return cint_ImageID_Log_Role
        End Get
    End Property

    Public ReadOnly Property ImageID_Log_User As Integer
        Get
            Return cint_ImageID_Log_User
        End Get
    End Property

    Public ReadOnly Property ImageID_Log_Util As Integer
        Get
            Return cint_ImageID_Log_Util
        End Get
    End Property

    Public ReadOnly Property ImageID_Log_Variable As Integer
        Get
            Return cint_ImageID_Log_Variable
        End Get
    End Property

    Public ReadOnly Property ImageID_Manual As Integer
        Get
            Return cint_ImageID_Manual
        End Get
    End Property

    Public ReadOnly Property ImageID_Manuals As Integer
        Get
            Return cint_ImageID_Manuals
        End Get
    End Property

    Public ReadOnly Property ImageID_Material As Integer
        Get
            Return cint_ImageID_Material
        End Get
    End Property

    Public ReadOnly Property ImageID_Materials As Integer
        Get
            Return cint_ImageID_Materials
        End Get
    End Property

    Public ReadOnly Property ImageID_Media As Integer
        Get
            Return cint_ImageID_Media
        End Get
    End Property

    Public ReadOnly Property ImageID_Medias As Integer
        Get
            Return cint_ImageID_Medias
        End Get
    End Property

    Public ReadOnly Property ImageID_Needs As Integer
        Get
            Return cint_ImageID_Needs
        End Get
    End Property

    Public ReadOnly Property ImageID_NeedsChild As Integer
        Get
            Return cint_ImageID_NeedsChild
        End Get
    End Property

    Public ReadOnly Property ImageID_NeedsChildPar As Integer
        Get
            Return cint_ImageID_NeedsChildPar
        End Get
    End Property

    Public ReadOnly Property ImageID_NeedsPar As Integer
        Get
            Return cint_ImageID_NeedsPar
        End Get
    End Property

    Public ReadOnly Property ImageID_Object As Integer
        Get
            Return cint_ImageID_Object
        End Get
    End Property

    Public ReadOnly Property ImageID_Objects As Integer
        Get
            Return cint_ImageID_Objects
        End Get
    End Property

    Public ReadOnly Property ImageID_Ref As Integer
        Get
            Return cint_ImageID_Ref
        End Get
    End Property

    Public ReadOnly Property ImageID_Refs As Integer
        Get
            Return cint_ImageID_Refs
        End Get
    End Property

    Public ReadOnly Property ImageID_RelationType As Integer
        Get
            Return cint_ImageID_RelationType
        End Get
    End Property

    Public ReadOnly Property ImageID_RelationTypes As Integer
        Get
            Return cint_ImageID_RelationTypes
        End Get
    End Property

    Public ReadOnly Property ImageID_Responsibilities As Integer
        Get
            Return cint_ImageID_Responsibilities
        End Get
    End Property

    Public ReadOnly Property ImageID_Responsibility As Integer
        Get
            Return cint_ImageID_Responsibility
        End Get
    End Property

    Public ReadOnly Property ImageID_Role As Integer
        Get
            Return cint_ImageID_Role
        End Get
    End Property

    Public ReadOnly Property ImageID_Roles As Integer
        Get
            Return cint_ImageID_Roles
        End Get
    End Property

    Public ReadOnly Property ImageID_User As Integer
        Get
            Return cint_ImageID_User
        End Get
    End Property

    Public ReadOnly Property ImageID_Users As Integer
        Get
            Return cint_ImageID_Users
        End Get
    End Property

    Public ReadOnly Property ImageID_Util As Integer
        Get
            Return cint_ImageID_Util
        End Get
    End Property

    Public ReadOnly Property ImageID_Utils As Integer
        Get
            Return cint_ImageID_Utils
        End Get
    End Property

    Public ReadOnly Property ImageID_Variable As Integer
        Get
            Return cint_ImageID_Variable
        End Get
    End Property

    Public ReadOnly Property ImageID_Variables As Integer
        Get
            Return cint_ImageID_Variables
        End Get
    End Property

    Public ReadOnly Property ImageID_VarVal As Integer
        Get
            Return cint_ImageID_VarVal
        End Get
    End Property

    'Attributes
    Public ReadOnly Property OItem_Attribute_Count() As clsOntologyItem
        Get
            Return objOItem_Attribute_Count
        End Get
    End Property

    Public ReadOnly Property OItem_attribute_dbPostfix() As clsOntologyItem
        Get
            Return objOItem_attribute_dbPostfix
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_Description() As clsOntologyItem
        Get
            Return objOItem_Attribute_Description
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_Public() As clsOntologyItem
        Get
            Return objOItem_Attribute_Public
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_Value() As clsOntologyItem
        Get
            Return objOItem_Attribute_Value
        End Get
    End Property

    'RelationTypes
    Public ReadOnly Property OItem_RelationType_belonging_Material() As clsOntologyItem
        Get
            Return objOItem_RelationType_belonging_Material
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_belonging_Sem_Item() As clsOntologyItem
        Get
            Return objOItem_RelationType_belonging_Sem_Item
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_belonging_Util() As clsOntologyItem
        Get
            Return objOItem_RelationType_belonging_Util
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_belongsTo() As clsOntologyItem
        Get
            Return objOItem_RelationType_belongsTo
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_contains() As clsOntologyItem
        Get
            Return objOItem_RelationType_contains
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_isDescribedBy() As clsOntologyItem
        Get
            Return objOItem_RelationType_isDescribedBy
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_needed_Documentation() As clsOntologyItem
        Get
            Return objOItem_RelationType_needed_Documentation
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_needs() As clsOntologyItem
        Get
            Return objOItem_RelationType_needs
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_needs_authority() As clsOntologyItem
        Get
            Return objOItem_RelationType_needs_authority
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_needs_Child() As clsOntologyItem
        Get
            Return objOItem_RelationType_needs_Child
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_offered_by() As clsOntologyItem
        Get
            Return objOItem_RelationType_offered_by
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_superordinate() As clsOntologyItem
        Get
            Return objOItem_RelationType_superordinate
        End Get
    End Property

    'Classes
    Public ReadOnly Property OItem_Type_Application() As clsOntologyItem
        Get
            Return objOItem_Type_Application
        End Get
    End Property

    Public ReadOnly Property OItem_Type_File() As clsOntologyItem
        Get
            Return objOItem_Type_File
        End Get
    End Property

    Public ReadOnly Property OItem_type_Folder() As clsOntologyItem
        Get
            Return objOItem_type_Folder
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Group() As clsOntologyItem
        Get
            Return objOItem_Type_Group
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Language() As clsOntologyItem
        Get
            Return objOItem_Type_Language
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Manual() As clsOntologyItem
        Get
            Return objOItem_Type_Manual
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Media() As clsOntologyItem
        Get
            Return objOItem_Type_Media
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Module() As clsOntologyItem
        Get
            Return objOItem_Type_Module
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Process() As clsOntologyItem
        Get
            Return objOItem_Type_Process
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Process_Module() As clsOntologyItem
        Get
            Return objOItem_Type_Process_Module
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Process_References() As clsOntologyItem
        Get
            Return objOItem_Type_Process_References
        End Get
    End Property

    Public ReadOnly Property OItem_Type_responsibility() As clsOntologyItem
        Get
            Return objOItem_Type_responsibility
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Role() As clsOntologyItem
        Get
            Return objOItem_Type_Role
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Things_References() As clsOntologyItem
        Get
            Return objOItem_Type_Things_References
        End Get
    End Property

    Public ReadOnly Property OItem_type_User() As clsOntologyItem
        Get
            Return objOItem_type_User
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Variable() As clsOntologyItem
        Get
            Return objOItem_Type_Variable
        End Get
    End Property


    Public ReadOnly Property OList_Languages() As List(Of clsObjectRel)
        Get
            Return objDBLevel_Languages.OList_ObjectRel
        End Get
    End Property


    Private Sub get_Data_DevelopmentConfig()
        Dim objOItem_ObjecRel As clsObjectRel
        Dim oList_ObjectRel As New List(Of clsObjectRel)
        Dim oList_ConfigItems As New List(Of clsOntologyItem)

        Dim oList_RelType_contains As New List(Of clsOntologyItem)
        Dim oList_RelType_belongsTo As New List(Of clsOntologyItem)

        Dim oList_ConfigItem As New List(Of clsOntologyItem)


        oList_ObjectRel.Add(New clsObjectRel(cstr_ID_SoftwareDevelopment, _
                                            Nothing, _
                                            Nothing, _
                                            Nothing, _
                                            Nothing, _
                                            Nothing, _
                                            cstr_ID_Class_DevelopmentConfig, _
                                            Nothing, _
                                            cstr_ID_RelType_needs, _
                                            Nothing, _
                                            objGlobals.Type_Object, _
                                            Nothing, _
                                            Nothing, _
                                            Nothing))

        objDBLevel_Config1.get_Data_ObjectRel(oList_ObjectRel)

        If objDBLevel_Config1.OList_ObjectRel_ID.Count > 0 Then
            objOItem_DevConfig.GUID = objDBLevel_Config1.OList_ObjectRel_ID(0).ID_Other
            objOItem_DevConfig.Name = objDBLevel_Config1.OList_ObjectRel_ID(0).Name_Other
            objOItem_DevConfig.GUID_Parent = objDBLevel_Config1.OList_ObjectRel_ID(0).ID_Parent_Other
            objOItem_DevConfig.Type = objDBLevel_Config1.OList_ObjectRel_ID(0).Ontology

            oList_ObjectRel.Clear()
            oList_ObjectRel.Add(New clsObjectRel(objOItem_DevConfig.GUID, _
                                                 Nothing, _
                                                 Nothing, _
                                                 Nothing, _
                                                 Nothing, _
                                                 Nothing, _
                                                 cstr_ID_Class_ConfigItem, _
                                                 Nothing, _
                                                 cstr_ID_RelType_contains, _
                                                 Nothing, _
                                                 objGlobals.Type_Object, _
                                                 Nothing, _
                                                 Nothing, _
                                                 Nothing))

            objDBLevel_Config1.get_Data_ObjectRel(oList_ObjectRel, _
                                          False, _
                                          False, _
                                          False, _
                                          objGlobals.Direction_LeftRight.Name, _
                                          True)
            oList_ObjectRel.Clear()
            If objDBLevel_Config1.OList_ObjectRel.Count > 0 Then
                For Each objOItem_ObjecRel In objDBLevel_Config1.OList_ObjectRel
                    oList_ConfigItems.Add(New clsOntologyItem(objOItem_ObjecRel.ID_Other, _
                                                              objGlobals.Type_Object))

                    oList_ObjectRel.Add(New clsObjectRel(objOItem_ObjecRel.ID_Other, _
                                                         Nothing, _
                                                         Nothing, _
                                                         Nothing, _
                                                         Nothing, _
                                                         Nothing, _
                                                         Nothing, _
                                                         Nothing, _
                                                         cstr_ID_RelType_belongsTo, _
                                                         Nothing, _
                                                         Nothing, _
                                                         objGlobals.Direction_LeftRight.GUID, _
                                                         objGlobals.Direction_LeftRight.Name, _
                                                         Nothing))



                Next

                objDBLevel_Config2.get_Data_ObjectRel(oList_ObjectRel, _
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

    Public ReadOnly Property Globals() As clsGlobals
        Get
            Return objGlobals
        End Get
    End Property

    Public Sub New(ByVal Globals As clsGlobals)
        objGlobals = Globals
        set_DBConnection()

        objOItem_Development = New clsOntologyItem(cstr_ID_SoftwareDevelopment, objGlobals.Type_Object)

        get_Data_DevelopmentConfig()
        get_Config()
    End Sub

    Private Sub set_DBConnection()
        objDBLevel_Config1 = New clsDBLevel(objGlobals)
        objDBLevel_Config2 = New clsDBLevel(objGlobals)
        objDBLevel_Languages = New clsDBLevel(objGlobals)
    End Sub

    Private Sub get_Languages()
        Dim objOItem_Result As clsOntologyItem
        Dim objOList_Module As New List(Of clsObjectRel)
        Dim objOList_BaseConfig As New List(Of clsObjectRel)
        Dim objOList_Languages As New List(Of clsObjectRel)

        objOList_Module.Add(New clsObjectRel(Nothing, _
                                             objOItem_Type_Module.GUID, _
                                             objOItem_Development.GUID, _
                                             Nothing, _
                                             objOItem_RelationType_offered_by.GUID, _
                                             objGlobals.Type_Object, _
                                             Nothing, _
                                             Nothing))

        objOItem_Result = objDBLevel_Languages.get_Data_ObjectRel(objOList_Module)

        If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then
            If objDBLevel_Languages.OList_ObjectRel_ID.Count > 0 Then
                objOList_BaseConfig.Add(New clsObjectRel(Nothing, _
                                                         objOItem_Type_Process_Module.GUID, _
                                                         objDBLevel_Languages.OList_ObjectRel_ID(0).ID_Object, _
                                                         Nothing, _
                                                         objOItem_RelationType_belongsTo.GUID, _
                                                         objGlobals.Type_Object, _
                                                         Nothing, _
                                                         Nothing))
                objOItem_Result = objDBLevel_Languages.get_Data_ObjectRel(objOList_BaseConfig, _
                                                                          boolIDs:=False)
                If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then
                    If objDBLevel_Languages.OList_ObjectRel.Count > 0 Then
                        objOItem_BaseConfig = New clsOntologyItem(objDBLevel_Languages.OList_ObjectRel(0).ID_Object, _
                                                                  objDBLevel_Languages.OList_ObjectRel(0).Name_Object, _
                                                                  objOItem_Type_Process_Module.GUID, _
                                                                  objGlobals.Type_Object)

                        objOList_Languages.Add(New clsObjectRel(objOItem_BaseConfig.GUID, _
                                                                Nothing, _
                                                                Nothing, _
                                                                objOItem_Type_Language.GUID, _
                                                                objOItem_RelationType_isDescribedBy.GUID, _
                                                                objGlobals.Type_Object, _
                                                                Nothing, _
                                                                Nothing))

                        objOItem_Result = objDBLevel_Languages.get_Data_ObjectRel(objOList_Languages, _
                                                                                boolIDs:=False)

                        If Not objOItem_Result.GUID = objGlobals.LState_Success.GUID Then
                            Err.Raise(1, "Config-Error")
                        End If


                    Else
                        Err.Raise(1, "Config-Error")
                    End If
                Else
                    Err.Raise(1, "Config-Error")
                End If
            Else
                Err.Raise(1, "Config-Error")
            End If



        Else
            Err.Raise(1, "Config-Error")
        End If
    End Sub

    Private Sub get_Config()



        get_Config_AttributeTypes()
        get_Config_RelationTypes()
        get_Config_Classes()
        get_Config_Objects()

        get_Languages()
    End Sub

    Private Sub get_Config_AttributeTypes()
        Dim objOList_attribute_count = From obj In objDBLevel_Config2.OList_ObjectRel
                                  Where obj.Name_Object.ToLower = "attribute_count" And obj.Ontology = objGlobals.Type_AttributeType

        If objOList_attribute_count.Count > 0 Then
            objOItem_Attribute_Count = New clsOntologyItem
            objOItem_Attribute_Count.GUID = objOList_attribute_count(0).ID_Other
            objOItem_Attribute_Count.Name = objOList_attribute_count(0).Name_Other
            objOItem_Attribute_Count.GUID_Parent = objOList_attribute_count(0).ID_Parent_Other
            objOItem_Attribute_Count.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_dbpostfix = From obj In objDBLevel_Config2.OList_ObjectRel
                                    Where obj.Name_Object.ToLower = "attribute_dbpostfix" And obj.Ontology = objGlobals.Type_AttributeType

        If objOList_attribute_dbpostfix.Count > 0 Then
            objOItem_attribute_dbPostfix = New clsOntologyItem
            objOItem_attribute_dbPostfix.GUID = objOList_attribute_dbpostfix(0).ID_Other
            objOItem_attribute_dbPostfix.Name = objOList_attribute_dbpostfix(0).Name_Other
            objOItem_attribute_dbPostfix.GUID_Parent = objOList_attribute_dbpostfix(0).ID_Parent_Other
            objOItem_attribute_dbPostfix.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_description = From obj In objDBLevel_Config2.OList_ObjectRel
                                    Where obj.Name_Object.ToLower = "attribute_description" And obj.Ontology = objGlobals.Type_AttributeType

        If objOList_attribute_description.Count > 0 Then
            objOItem_Attribute_Description = New clsOntologyItem
            objOItem_Attribute_Description.GUID = objOList_attribute_description(0).ID_Other
            objOItem_Attribute_Description.Name = objOList_attribute_description(0).Name_Other
            objOItem_Attribute_Description.GUID_Parent = objOList_attribute_description(0).ID_Parent_Other
            objOItem_Attribute_Description.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_public = From obj In objDBLevel_Config2.OList_ObjectRel
                                    Where obj.Name_Object.ToLower = "attribute_public" And obj.Ontology = objGlobals.Type_AttributeType

        If objOList_attribute_public.Count > 0 Then
            objOItem_Attribute_Public = New clsOntologyItem
            objOItem_Attribute_Public.GUID = objOList_attribute_public(0).ID_Other
            objOItem_Attribute_Public.Name = objOList_attribute_public(0).Name_Other
            objOItem_Attribute_Public.GUID_Parent = objOList_attribute_public(0).ID_Parent_Other
            objOItem_Attribute_Public.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_value = From obj In objDBLevel_Config2.OList_ObjectRel
                                    Where obj.Name_Object.ToLower = "attribute_value" And obj.Ontology = objGlobals.Type_AttributeType

        If objOList_attribute_value.Count > 0 Then
            objOItem_Attribute_Value = New clsOntologyItem
            objOItem_Attribute_Value.GUID = objOList_attribute_value(0).ID_Other
            objOItem_Attribute_Value.Name = objOList_attribute_value(0).Name_Other
            objOItem_Attribute_Value.GUID_Parent = objOList_attribute_value(0).ID_Parent_Other
            objOItem_Attribute_Value.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If


    End Sub

    Private Sub get_Config_RelationTypes()
        Dim objOList_relationtype_belonging_material = From obj In objDBLevel_Config2.OList_ObjectRel
                          Where obj.Name_Object.ToLower = "relationtype_belonging_material" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_belonging_material.Count > 0 Then
            objOItem_RelationType_belonging_Material = New clsOntologyItem
            objOItem_RelationType_belonging_Material.GUID = objOList_relationtype_belonging_material(0).ID_Other
            objOItem_RelationType_belonging_Material.Name = objOList_relationtype_belonging_material(0).Name_Other
            objOItem_RelationType_belonging_Material.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_belonging_sem_item = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_belonging_sem_item" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_belonging_sem_item.Count > 0 Then
            objOItem_RelationType_belonging_Sem_Item = New clsOntologyItem
            objOItem_RelationType_belonging_Sem_Item.GUID = objOList_relationtype_belonging_sem_item(0).ID_Other
            objOItem_RelationType_belonging_Sem_Item.Name = objOList_relationtype_belonging_sem_item(0).Name_Other
            objOItem_RelationType_belonging_Sem_Item.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_belonging_util = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_belonging_util" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_belonging_util.Count > 0 Then
            objOItem_RelationType_belonging_Util = New clsOntologyItem
            objOItem_RelationType_belonging_Util.GUID = objOList_relationtype_belonging_util(0).ID_Other
            objOItem_RelationType_belonging_Util.Name = objOList_relationtype_belonging_util(0).Name_Other
            objOItem_RelationType_belonging_Util.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_belongsto = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_belongsto" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_belongsto.Count > 0 Then
            objOItem_RelationType_belongsTo = New clsOntologyItem
            objOItem_RelationType_belongsTo.GUID = objOList_relationtype_belongsto(0).ID_Other
            objOItem_RelationType_belongsTo.Name = objOList_relationtype_belongsto(0).Name_Other
            objOItem_RelationType_belongsTo.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_contains = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_contains" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_contains.Count > 0 Then
            objOItem_RelationType_contains = New clsOntologyItem
            objOItem_RelationType_contains.GUID = objOList_relationtype_contains(0).ID_Other
            objOItem_RelationType_contains.Name = objOList_relationtype_contains(0).Name_Other
            objOItem_RelationType_contains.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_isdescribedby = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_isdescribedby" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_isdescribedby.Count > 0 Then
            objOItem_RelationType_isDescribedBy = New clsOntologyItem
            objOItem_RelationType_isDescribedBy.GUID = objOList_relationtype_isdescribedby(0).ID_Other
            objOItem_RelationType_isDescribedBy.Name = objOList_relationtype_isdescribedby(0).Name_Other
            objOItem_RelationType_isDescribedBy.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_needed_documentation = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_needed_documentation" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_needed_documentation.Count > 0 Then
            objOItem_RelationType_needed_Documentation = New clsOntologyItem
            objOItem_RelationType_needed_Documentation.GUID = objOList_relationtype_needed_documentation(0).ID_Other
            objOItem_RelationType_needed_Documentation.Name = objOList_relationtype_needed_documentation(0).Name_Other
            objOItem_RelationType_needed_Documentation.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_needs = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_needs" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_needs.Count > 0 Then
            objOItem_RelationType_needs = New clsOntologyItem
            objOItem_RelationType_needs.GUID = objOList_relationtype_needs(0).ID_Other
            objOItem_RelationType_needs.Name = objOList_relationtype_needs(0).Name_Other
            objOItem_RelationType_needs.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_needs_authority = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_needs_authority" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_needs_authority.Count > 0 Then
            objOItem_RelationType_needs_authority = New clsOntologyItem
            objOItem_RelationType_needs_authority.GUID = objOList_relationtype_needs_authority(0).ID_Other
            objOItem_RelationType_needs_authority.Name = objOList_relationtype_needs_authority(0).Name_Other
            objOItem_RelationType_needs_authority.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_needs_child = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_needs_child" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_needs_child.Count > 0 Then
            objOItem_RelationType_needs_Child = New clsOntologyItem
            objOItem_RelationType_needs_Child.GUID = objOList_relationtype_needs_child(0).ID_Other
            objOItem_RelationType_needs_Child.Name = objOList_relationtype_needs_child(0).Name_Other
            objOItem_RelationType_needs_Child.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_offered_by = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_offered_by" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_offered_by.Count > 0 Then
            objOItem_RelationType_offered_by = New clsOntologyItem
            objOItem_RelationType_offered_by.GUID = objOList_relationtype_offered_by(0).ID_Other
            objOItem_RelationType_offered_by.Name = objOList_relationtype_offered_by(0).Name_Other
            objOItem_RelationType_offered_by.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_superordinate = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_superordinate" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_superordinate.Count > 0 Then
            objOItem_RelationType_superordinate = New clsOntologyItem
            objOItem_RelationType_superordinate.GUID = objOList_relationtype_superordinate(0).ID_Other
            objOItem_RelationType_superordinate.Name = objOList_relationtype_superordinate(0).Name_Other
            objOItem_RelationType_superordinate.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If


    End Sub

    Private Sub get_Config_Objects()

    End Sub

    Private Sub get_Config_Classes()
        Dim objOList_type_application = From obj In objDBLevel_Config2.OList_ObjectRel
                          Where obj.Name_Object.ToLower = "type_application" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_application.Count > 0 Then
            objOItem_Type_Application = New clsOntologyItem
            objOItem_Type_Application.GUID = objOList_type_application(0).ID_Other
            objOItem_Type_Application.Name = objOList_type_application(0).Name_Other
            objOItem_Type_Application.GUID_Parent = objOList_type_application(0).ID_Parent_Other
            objOItem_Type_Application.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_file = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_file" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_file.Count > 0 Then
            objOItem_Type_File = New clsOntologyItem
            objOItem_Type_File.GUID = objOList_type_file(0).ID_Other
            objOItem_Type_File.Name = objOList_type_file(0).Name_Other
            objOItem_Type_File.GUID_Parent = objOList_type_file(0).ID_Parent_Other
            objOItem_Type_File.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_folder = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_folder" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_folder.Count > 0 Then
            objOItem_type_Folder = New clsOntologyItem
            objOItem_type_Folder.GUID = objOList_type_folder(0).ID_Other
            objOItem_type_Folder.Name = objOList_type_folder(0).Name_Other
            objOItem_type_Folder.GUID_Parent = objOList_type_folder(0).ID_Parent_Other
            objOItem_type_Folder.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_group = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_group" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_group.Count > 0 Then
            objOItem_Type_Group = New clsOntologyItem
            objOItem_Type_Group.GUID = objOList_type_group(0).ID_Other
            objOItem_Type_Group.Name = objOList_type_group(0).Name_Other
            objOItem_Type_Group.GUID_Parent = objOList_type_group(0).ID_Parent_Other
            objOItem_Type_Group.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_language = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_language" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_language.Count > 0 Then
            objOItem_Type_Language = New clsOntologyItem
            objOItem_Type_Language.GUID = objOList_type_language(0).ID_Other
            objOItem_Type_Language.Name = objOList_type_language(0).Name_Other
            objOItem_Type_Language.GUID_Parent = objOList_type_language(0).ID_Parent_Other
            objOItem_Type_Language.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_manual = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_manual" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_manual.Count > 0 Then
            objOItem_Type_Manual = New clsOntologyItem
            objOItem_Type_Manual.GUID = objOList_type_manual(0).ID_Other
            objOItem_Type_Manual.Name = objOList_type_manual(0).Name_Other
            objOItem_Type_Manual.GUID_Parent = objOList_type_manual(0).ID_Parent_Other
            objOItem_Type_Manual.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_media = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_media" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_media.Count > 0 Then
            objOItem_Type_Media = New clsOntologyItem
            objOItem_Type_Media.GUID = objOList_type_media(0).ID_Other
            objOItem_Type_Media.Name = objOList_type_media(0).Name_Other
            objOItem_Type_Media.GUID_Parent = objOList_type_media(0).ID_Parent_Other
            objOItem_Type_Media.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_module = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_module" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_module.Count > 0 Then
            objOItem_Type_Module = New clsOntologyItem
            objOItem_Type_Module.GUID = objOList_type_module(0).ID_Other
            objOItem_Type_Module.Name = objOList_type_module(0).Name_Other
            objOItem_Type_Module.GUID_Parent = objOList_type_module(0).ID_Parent_Other
            objOItem_Type_Module.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_process = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_process" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_process.Count > 0 Then
            objOItem_Type_Process = New clsOntologyItem
            objOItem_Type_Process.GUID = objOList_type_process(0).ID_Other
            objOItem_Type_Process.Name = objOList_type_process(0).Name_Other
            objOItem_Type_Process.GUID_Parent = objOList_type_process(0).ID_Parent_Other
            objOItem_Type_Process.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_process_module = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_process_module" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_process_module.Count > 0 Then
            objOItem_Type_Process_Module = New clsOntologyItem
            objOItem_Type_Process_Module.GUID = objOList_type_process_module(0).ID_Other
            objOItem_Type_Process_Module.Name = objOList_type_process_module(0).Name_Other
            objOItem_Type_Process_Module.GUID_Parent = objOList_type_process_module(0).ID_Parent_Other
            objOItem_Type_Process_Module.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_process_references = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_process_references" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_process_references.Count > 0 Then
            objOItem_Type_Process_References = New clsOntologyItem
            objOItem_Type_Process_References.GUID = objOList_type_process_references(0).ID_Other
            objOItem_Type_Process_References.Name = objOList_type_process_references(0).Name_Other
            objOItem_Type_Process_References.GUID_Parent = objOList_type_process_references(0).ID_Parent_Other
            objOItem_Type_Process_References.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_responsibility = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_responsibility" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_responsibility.Count > 0 Then
            objOItem_Type_responsibility = New clsOntologyItem
            objOItem_Type_responsibility.GUID = objOList_type_responsibility(0).ID_Other
            objOItem_Type_responsibility.Name = objOList_type_responsibility(0).Name_Other
            objOItem_Type_responsibility.GUID_Parent = objOList_type_responsibility(0).ID_Parent_Other
            objOItem_Type_responsibility.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_role = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_role" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_role.Count > 0 Then
            objOItem_Type_Role = New clsOntologyItem
            objOItem_Type_Role.GUID = objOList_type_role(0).ID_Other
            objOItem_Type_Role.Name = objOList_type_role(0).Name_Other
            objOItem_Type_Role.GUID_Parent = objOList_type_role(0).ID_Parent_Other
            objOItem_Type_Role.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_things_references = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_things_references" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_things_references.Count > 0 Then
            objOItem_Type_Things_References = New clsOntologyItem
            objOItem_Type_Things_References.GUID = objOList_type_things_references(0).ID_Other
            objOItem_Type_Things_References.Name = objOList_type_things_references(0).Name_Other
            objOItem_Type_Things_References.GUID_Parent = objOList_type_things_references(0).ID_Parent_Other
            objOItem_Type_Things_References.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_user = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_user" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_user.Count > 0 Then
            objOItem_type_User = New clsOntologyItem
            objOItem_type_User.GUID = objOList_type_user(0).ID_Other
            objOItem_type_User.Name = objOList_type_user(0).Name_Other
            objOItem_type_User.GUID_Parent = objOList_type_user(0).ID_Parent_Other
            objOItem_type_User.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_variable = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_variable" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_variable.Count > 0 Then
            objOItem_Type_Variable = New clsOntologyItem
            objOItem_Type_Variable.GUID = objOList_type_variable(0).ID_Other
            objOItem_Type_Variable.Name = objOList_type_variable(0).Name_Other
            objOItem_Type_Variable.GUID_Parent = objOList_type_variable(0).ID_Parent_Other
            objOItem_Type_Variable.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If


    End Sub
End Class

Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Imports System.Reflection

Public Class clsLocalConfig
    Private Const cint_ImageID_Root As Integer = 0
    Private Const cint_ImageID_Close As Integer = 1
    Private Const cint_ImageID_Close_SubItems As Integer = 2
    Private Const cint_ImageID_Close_Images As Integer = 3
    Private Const cint_ImageID_Close_Images_SubItems As Integer = 4
    Private Const cint_ImageID_Open As Integer = 5
    Private Const cint_ImageID_Open_SubItems As Integer = 6
    Private Const cint_ImageID_Open_Images As Integer = 7
    Private Const cint_ImageID_Open_Images_SubItems As Integer = 8
    Private Const cint_ImageID_Attributes As Integer = 9
    Private Const cint_ImageID_RelationTypes As Integer = 10
    Private Const cint_ImageID_Token As Integer = 11
    Private Const cint_ImageID_Attribute As Integer = 12
    Private Const cint_ImageID_RelationType As Integer = 13
    Private Const cint_ImageID_Token_Named As Integer = 14
    Private Const cint_ImageID_Close_RelateChoose As Integer = 15
    Private Const cint_ImageID_Open_RelateChoose As Integer = 16

    Private cstrID_Ontology As String = "1ef425afe14e4be7a4a2ea2926fe0f8d"

    Private objGlobals As clsGlobals

    Private objOItem_DevConfig As New clsOntologyItem
    Private objOItem_User As clsOntologyItem

    Private objDBLevel_Config1 As clsDBLevel
    Private objDBLevel_Config2 As clsDBLevel

    Private objImport As clsImport

    'Attributes
    Private objOItem_Attribute_comment As New clsOntologyItem
    Private objOItem_Attribute_DateTimeStamp As New clsOntologyItem
    Private objOItem_attribute_dbPostfix As New clsOntologyItem
    Private objOItem_Attribute_ID As New clsOntologyItem
    Private objOItem_Attribute_L_nge__Minuten_ As New clsOntologyItem
    Private objOItem_Attribute_Media_Position As New clsOntologyItem
    Private objOItem_Attribute_taking As New clsOntologyItem
    Private objOItem_Attribute_Titel As New clsOntologyItem
    Private objOItem_Attribute_XML_Text As New clsOntologyItem
    Private objOItem_Attribute_Datetimestamp__Create_ As New clsOntologyItem

    'RelationTypes
    Private objOItem_RelationType_Artist As New clsOntologyItem
    Private objOItem_RelationType_belonging_Done As New clsOntologyItem
    Private objOItem_RelationType_belonging_Source As New clsOntologyItem
    Private objOItem_RelationType_belongsTo As New clsOntologyItem
    Private objOItem_RelationType_Composer As New clsOntologyItem
    Private objOItem_RelationType_contains As New clsOntologyItem
    Private objOItem_RelationType_Disc As New clsOntologyItem
    Private objOItem_RelationType_finished_with As New clsOntologyItem
    Private objOItem_RelationType_from As New clsOntologyItem
    Private objOItem_RelationType_has As New clsOntologyItem
    Private objOItem_RelationType_is As New clsOntologyItem
    Private objOItem_RelationType_is_of_Type As New clsOntologyItem
    Private objOItem_RelationType_is_used_by As New clsOntologyItem
    Private objOItem_RelationType_isDescribedBy As New clsOntologyItem
    Private objOItem_RelationType_located_in As New clsOntologyItem
    Private objOItem_RelationType_Media_Webservice_Url As New clsOntologyItem
    Private objOItem_RelationType_offered_by As New clsOntologyItem
    Private objOItem_RelationType_offers As New clsOntologyItem
    Private objOItem_RelationType_started_with As New clsOntologyItem
    Private objOItem_RelationType_taking_at As New clsOntologyItem
    Private objOItem_RelationType_wasCreatedBy As New clsOntologyItem

    'Objects
    Private objOItem_Token_Extensions_Image As New clsOntologyItem
    Private objOItem_Token_Extensions_mod As New clsOntologyItem
    Private objOItem_Token_Extensions_pdf As New clsOntologyItem
    Private objOItem_Token_Image_Objects__No_Objects__no_Address As New clsOntologyItem
    Private objOItem_Token_Image_Objects__No_Objects__no_Artwork As New clsOntologyItem
    Private objOItem_Token_Image_Objects__No_Objects__no_Buildings As New clsOntologyItem
    Private objOItem_Token_Image_Objects__No_Objects__no_landscape As New clsOntologyItem
    Private objOItem_Token_Image_Objects__No_Objects__no_Location As New clsOntologyItem
    Private objOItem_Token_Image_Objects__No_Objects__no_Persons As New clsOntologyItem
    Private objOItem_Token_Image_Objects__No_Objects__no_Pets As New clsOntologyItem
    Private objOItem_Token_Image_Objects__No_Objects__no_plant_Species As New clsOntologyItem
    Private objOItem_Token_Image_Objects__No_Objects__no_species As New clsOntologyItem
    Private objOItem_Token_Image_Objects__No_Objects__no_Symbol As New clsOntologyItem
    Private objOItem_Token_Image_Objects__No_Objects__weather_condition As New clsOntologyItem
    Private objOItem_Token_Logstate_Last_Position As New clsOntologyItem
    Private objOItem_Token_Logstate_Pause As New clsOntologyItem
    Private objOItem_Token_Logstate_Start As New clsOntologyItem
    Private objOItem_Token_Logstate_Stop As New clsOntologyItem
    Private objOItem_Token_Logstate_Unassigned As New clsOntologyItem
    Private objOItem_Token_Logstate_User_Defined As New clsOntologyItem
    Private objOItem_Token_Search_Template_Name_ As New clsOntologyItem
    Private objOItem_Token_Variable_ITEMCOUNT As New clsOntologyItem
    Private objOItem_Token_Variable_MEDIASRC As New clsOntologyItem
    Private objOItem_Token_Variable_title As New clsOntologyItem
    Private objOItem_Token_Variable_URL_MEDIASRC As New clsOntologyItem
    Private objOItem_Token_XML_Windows_Playlist_1_0 As New clsOntologyItem
    Private objOItem_Token_XML_Windows_Playlist_1_0_mediasrc As New clsOntologyItem

    'Classes
    Private objOItem_Type_Album As New clsOntologyItem
    Private objOItem_Type_Band As New clsOntologyItem
    Private objOItem_Type_Bauwerke As New clsOntologyItem
    Private objOItem_Type_Day As New clsOntologyItem
    Private objOItem_Type_File As New clsOntologyItem
    Private objOItem_Type_Filetypes As New clsOntologyItem
    Private objOItem_Type_Genre As New clsOntologyItem
    Private objOItem_Type_Haustier As New clsOntologyItem
    Private objOItem_Type_Image_Module As New clsOntologyItem
    Private objOItem_Type_Image_Objects As New clsOntologyItem
    Private objOItem_Type_Image_Objects__No_Objects_ As New clsOntologyItem
    Private objOItem_Type_Images__Graphic_ As New clsOntologyItem
    Private objOItem_Type_Kunst As New clsOntologyItem
    Private objOItem_Type_landscape As New clsOntologyItem
    Private objOItem_Type_Language As New clsOntologyItem
    Private objOItem_Type_LogEntry As New clsOntologyItem
    Private objOItem_Type_Media As New clsOntologyItem
    Private objOItem_Type_Media_Item As New clsOntologyItem
    Private objOItem_Type_Media_Item_Bookmark As New clsOntologyItem
    Private objOItem_Type_Media_Item_Range As New clsOntologyItem
    Private objOItem_Type_Module As New clsOntologyItem
    Private objOItem_Type_Month As New clsOntologyItem
    Private objOItem_Type_mp3_File As New clsOntologyItem
    Private objOItem_Type_Ort As New clsOntologyItem
    Private objOItem_Type_Partner As New clsOntologyItem
    Private objOItem_Type_PDF_Documents As New clsOntologyItem
    Private objOItem_Type_Pflanzenarten As New clsOntologyItem
    Private objOItem_Type_Search_Template As New clsOntologyItem
    Private objOItem_Type_Tierarten As New clsOntologyItem
    Private objOItem_Type_Url As New clsOntologyItem
    Private objOItem_type_User As New clsOntologyItem
    Private objOItem_Type_Wetterlage As New clsOntologyItem
    Private objOItem_Type_Wichtige_Ereignisse As New clsOntologyItem
    Private objOItem_Type_Year As New clsOntologyItem


    Public ReadOnly Property ImageID_Root As Integer
        Get
            Return cint_ImageID_Root
        End Get
    End Property

    Public ReadOnly Property ImageID_Close As Integer
        Get
            Return cint_ImageID_Close
        End Get
    End Property

    Public ReadOnly Property ImageID_Close_SubItems As Integer
        Get
            Return cint_ImageID_Close_SubItems
        End Get
    End Property

    Public ReadOnly Property ImageID_Close_Images As Integer
        Get
            Return cint_ImageID_Close_Images
        End Get
    End Property

    Public ReadOnly Property ImageID_Close_Images_SubItems As Integer
        Get
            Return cint_ImageID_Close_Images_SubItems
        End Get
    End Property

    Public ReadOnly Property ImageID_Open As Integer
        Get
            Return cint_ImageID_Open
        End Get
    End Property

    Public ReadOnly Property ImageID_Open_SubItems As Integer
        Get
            Return cint_ImageID_Open_SubItems
        End Get
    End Property

    Public ReadOnly Property ImageID_Open_Images As Integer
        Get
            Return cint_ImageID_Open_Images
        End Get
    End Property

    Public ReadOnly Property ImageID_Open_Images_SubItems As Integer
        Get
            Return cint_ImageID_Open_Images_SubItems
        End Get
    End Property

    Public ReadOnly Property ImageID_Attributes As Integer
        Get
            Return cint_ImageID_Attributes
        End Get
    End Property

    Public ReadOnly Property ImageID_RelationTypes As Integer
        Get
            Return cint_ImageID_RelationTypes
        End Get
    End Property

    Public ReadOnly Property ImageID_Token As Integer
        Get
            Return cint_ImageID_Token
        End Get
    End Property

    Public ReadOnly Property ImageID_Attribute As Integer
        Get
            Return cint_ImageID_Attribute
        End Get
    End Property

    Public ReadOnly Property ImageID_RelationType As Integer
        Get
            Return cint_ImageID_RelationType
        End Get
    End Property

    Public ReadOnly Property ImageID_Token_Named As Integer
        Get
            Return cint_ImageID_Token_Named
        End Get
    End Property

    Public ReadOnly Property ImageID_Close_RelateChoose As Integer
        Get
            Return cint_ImageID_Close_RelateChoose
        End Get
    End Property

    Public ReadOnly Property ImageID_Open_RelateChoose As Integer
        Get
            Return cint_ImageID_Open_RelateChoose
        End Get
    End Property


    'Attributes
    Public ReadOnly Property OItem_Attribute_comment() As clsOntologyItem
        Get
            Return objOItem_Attribute_comment
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_DateTimeStamp() As clsOntologyItem
        Get
            Return objOItem_Attribute_DateTimeStamp
        End Get
    End Property

    Public ReadOnly Property OItem_attribute_dbPostfix() As clsOntologyItem
        Get
            Return objOItem_attribute_dbPostfix
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_ID() As clsOntologyItem
        Get
            Return objOItem_Attribute_ID
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_L_nge__Minuten_() As clsOntologyItem
        Get
            Return objOItem_Attribute_L_nge__Minuten_
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_Media_Position() As clsOntologyItem
        Get
            Return objOItem_Attribute_Media_Position
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_taking() As clsOntologyItem
        Get
            Return objOItem_Attribute_taking
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_Titel() As clsOntologyItem
        Get
            Return objOItem_Attribute_Titel
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_XML_Text() As clsOntologyItem
        Get
            Return objOItem_Attribute_XML_Text
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_Datetimestamp__Create_() As clsOntologyItem
        Get
            Return objOItem_Attribute_Datetimestamp__Create_
        End Get
    End Property


    'RelationTypes
    Public ReadOnly Property OItem_RelationType_Artist() As clsOntologyItem
        Get
            Return objOItem_RelationType_Artist
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_belonging_Done() As clsOntologyItem
        Get
            Return objOItem_RelationType_belonging_Done
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_belonging_Source() As clsOntologyItem
        Get
            Return objOItem_RelationType_belonging_Source
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_belongsTo() As clsOntologyItem
        Get
            Return objOItem_RelationType_belongsTo
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_Composer() As clsOntologyItem
        Get
            Return objOItem_RelationType_Composer
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_contains() As clsOntologyItem
        Get
            Return objOItem_RelationType_contains
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_Disc() As clsOntologyItem
        Get
            Return objOItem_RelationType_Disc
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_finished_with() As clsOntologyItem
        Get
            Return objOItem_RelationType_finished_with
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_from() As clsOntologyItem
        Get
            Return objOItem_RelationType_from
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_has() As clsOntologyItem
        Get
            Return objOItem_RelationType_has
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_is() As clsOntologyItem
        Get
            Return objOItem_RelationType_is
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_is_of_Type() As clsOntologyItem
        Get
            Return objOItem_RelationType_is_of_Type
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_is_used_by() As clsOntologyItem
        Get
            Return objOItem_RelationType_is_used_by
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_isDescribedBy() As clsOntologyItem
        Get
            Return objOItem_RelationType_isDescribedBy
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_located_in() As clsOntologyItem
        Get
            Return objOItem_RelationType_located_in
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_Media_Webservice_Url() As clsOntologyItem
        Get
            Return objOItem_RelationType_Media_Webservice_Url
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_offered_by() As clsOntologyItem
        Get
            Return objOItem_RelationType_offered_by
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_offers() As clsOntologyItem
        Get
            Return objOItem_RelationType_offers
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_started_with() As clsOntologyItem
        Get
            Return objOItem_RelationType_started_with
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_taking_at() As clsOntologyItem
        Get
            Return objOItem_RelationType_taking_at
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_wasCreatedBy() As clsOntologyItem
        Get
            Return objOItem_RelationType_wasCreatedBy
        End Get
    End Property

    Public ReadOnly Property OItem_Token_Extensions_Image() As clsOntologyItem
        Get
            Return objOItem_Token_Extensions_Image
        End Get
    End Property

    Public ReadOnly Property OItem_Token_Extensions_mod() As clsOntologyItem
        Get
            Return objOItem_Token_Extensions_mod
        End Get
    End Property

    Public ReadOnly Property OItem_Token_Extensions_pdf() As clsOntologyItem
        Get
            Return objOItem_Token_Extensions_pdf
        End Get
    End Property

    Public ReadOnly Property OItem_Token_Image_Objects__No_Objects__no_Address() As clsOntologyItem
        Get
            Return objOItem_Token_Image_Objects__No_Objects__no_Address
        End Get
    End Property

    Public ReadOnly Property OItem_Token_Image_Objects__No_Objects__no_Artwork() As clsOntologyItem
        Get
            Return objOItem_Token_Image_Objects__No_Objects__no_Artwork
        End Get
    End Property

    Public ReadOnly Property OItem_Token_Image_Objects__No_Objects__no_Buildings() As clsOntologyItem
        Get
            Return objOItem_Token_Image_Objects__No_Objects__no_Buildings
        End Get
    End Property

    Public ReadOnly Property OItem_Token_Image_Objects__No_Objects__no_landscape() As clsOntologyItem
        Get
            Return objOItem_Token_Image_Objects__No_Objects__no_landscape
        End Get
    End Property

    Public ReadOnly Property OItem_Token_Image_Objects__No_Objects__no_Location() As clsOntologyItem
        Get
            Return objOItem_Token_Image_Objects__No_Objects__no_Location
        End Get
    End Property

    Public ReadOnly Property OItem_Token_Image_Objects__No_Objects__no_Persons() As clsOntologyItem
        Get
            Return objOItem_Token_Image_Objects__No_Objects__no_Persons
        End Get
    End Property

    Public ReadOnly Property OItem_Token_Image_Objects__No_Objects__no_Pets() As clsOntologyItem
        Get
            Return objOItem_Token_Image_Objects__No_Objects__no_Pets
        End Get
    End Property

    Public ReadOnly Property OItem_Token_Image_Objects__No_Objects__no_plant_Species() As clsOntologyItem
        Get
            Return objOItem_Token_Image_Objects__No_Objects__no_plant_Species
        End Get
    End Property

    Public ReadOnly Property OItem_Token_Image_Objects__No_Objects__no_species() As clsOntologyItem
        Get
            Return objOItem_Token_Image_Objects__No_Objects__no_species
        End Get
    End Property

    Public ReadOnly Property OItem_Token_Image_Objects__No_Objects__no_Symbol() As clsOntologyItem
        Get
            Return objOItem_Token_Image_Objects__No_Objects__no_Symbol
        End Get
    End Property

    Public ReadOnly Property OItem_Token_Image_Objects__No_Objects__weather_condition() As clsOntologyItem
        Get
            Return objOItem_Token_Image_Objects__No_Objects__weather_condition
        End Get
    End Property

    Public ReadOnly Property OItem_Token_Logstate_Last_Position() As clsOntologyItem
        Get
            Return objOItem_Token_Logstate_Last_Position
        End Get
    End Property

    Public ReadOnly Property OItem_Token_Logstate_Pause() As clsOntologyItem
        Get
            Return objOItem_Token_Logstate_Pause
        End Get
    End Property

    Public ReadOnly Property OItem_Token_Logstate_Start() As clsOntologyItem
        Get
            Return objOItem_Token_Logstate_Start
        End Get
    End Property

    Public ReadOnly Property OItem_Token_Logstate_Stop() As clsOntologyItem
        Get
            Return objOItem_Token_Logstate_Stop
        End Get
    End Property

    Public ReadOnly Property OItem_Token_Logstate_Unassigned() As clsOntologyItem
        Get
            Return objOItem_Token_Logstate_Unassigned
        End Get
    End Property

    Public ReadOnly Property OItem_Token_Logstate_User_Defined() As clsOntologyItem
        Get
            Return objOItem_Token_Logstate_User_Defined
        End Get
    End Property

    Public ReadOnly Property OItem_Token_Search_Template_Name_() As clsOntologyItem
        Get
            Return objOItem_Token_Search_Template_Name_
        End Get
    End Property

    Public ReadOnly Property OItem_Token_Variable_ITEMCOUNT() As clsOntologyItem
        Get
            Return objOItem_Token_Variable_ITEMCOUNT
        End Get
    End Property

    Public ReadOnly Property OItem_Token_Variable_MEDIASRC() As clsOntologyItem
        Get
            Return objOItem_Token_Variable_MEDIASRC
        End Get
    End Property

    Public ReadOnly Property OItem_Token_Variable_title() As clsOntologyItem
        Get
            Return objOItem_Token_Variable_title
        End Get
    End Property

    Public ReadOnly Property OItem_Token_Variable_URL_MEDIASRC() As clsOntologyItem
        Get
            Return objOItem_Token_Variable_URL_MEDIASRC
        End Get
    End Property

    Public ReadOnly Property OItem_Token_XML_Windows_Playlist_1_0() As clsOntologyItem
        Get
            Return objOItem_Token_XML_Windows_Playlist_1_0
        End Get
    End Property

    Public ReadOnly Property OItem_Token_XML_Windows_Playlist_1_0_mediasrc() As clsOntologyItem
        Get
            Return objOItem_Token_XML_Windows_Playlist_1_0_mediasrc
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Album() As clsOntologyItem
        Get
            Return objOItem_Type_Album
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Band() As clsOntologyItem
        Get
            Return objOItem_Type_Band
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Bauwerke() As clsOntologyItem
        Get
            Return objOItem_Type_Bauwerke
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Day() As clsOntologyItem
        Get
            Return objOItem_Type_Day
        End Get
    End Property

    Public ReadOnly Property OItem_Type_File() As clsOntologyItem
        Get
            Return objOItem_Type_File
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Filetypes() As clsOntologyItem
        Get
            Return objOItem_Type_Filetypes
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Genre() As clsOntologyItem
        Get
            Return objOItem_Type_Genre
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Haustier() As clsOntologyItem
        Get
            Return objOItem_Type_Haustier
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Image_Module() As clsOntologyItem
        Get
            Return objOItem_Type_Image_Module
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Image_Objects() As clsOntologyItem
        Get
            Return objOItem_Type_Image_Objects
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Image_Objects__No_Objects_() As clsOntologyItem
        Get
            Return objOItem_Type_Image_Objects__No_Objects_
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Images__Graphic_() As clsOntologyItem
        Get
            Return objOItem_Type_Images__Graphic_
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Kunst() As clsOntologyItem
        Get
            Return objOItem_Type_Kunst
        End Get
    End Property

    Public ReadOnly Property OItem_Type_landscape() As clsOntologyItem
        Get
            Return objOItem_Type_landscape
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Language() As clsOntologyItem
        Get
            Return objOItem_Type_Language
        End Get
    End Property

    Public ReadOnly Property OItem_Type_LogEntry() As clsOntologyItem
        Get
            Return objOItem_Type_LogEntry
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Media() As clsOntologyItem
        Get
            Return objOItem_Type_Media
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Media_Item() As clsOntologyItem
        Get
            Return objOItem_Type_Media_Item
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Media_Item_Bookmark() As clsOntologyItem
        Get
            Return objOItem_Type_Media_Item_Bookmark
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Media_Item_Range() As clsOntologyItem
        Get
            Return objOItem_Type_Media_Item_Range
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Module() As clsOntologyItem
        Get
            Return objOItem_Type_Module
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Month() As clsOntologyItem
        Get
            Return objOItem_Type_Month
        End Get
    End Property

    Public ReadOnly Property OItem_Type_mp3_File() As clsOntologyItem
        Get
            Return objOItem_Type_mp3_File
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Ort() As clsOntologyItem
        Get
            Return objOItem_Type_Ort
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Partner() As clsOntologyItem
        Get
            Return objOItem_Type_Partner
        End Get
    End Property

    Public ReadOnly Property OItem_Type_PDF_Documents() As clsOntologyItem
        Get
            Return objOItem_Type_PDF_Documents
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Pflanzenarten() As clsOntologyItem
        Get
            Return objOItem_Type_Pflanzenarten
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Search_Template() As clsOntologyItem
        Get
            Return objOItem_Type_Search_Template
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Tierarten() As clsOntologyItem
        Get
            Return objOItem_Type_Tierarten
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Url() As clsOntologyItem
        Get
            Return objOItem_Type_Url
        End Get
    End Property

    Public ReadOnly Property OItem_type_User() As clsOntologyItem
        Get
            Return objOItem_type_User
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Wetterlage() As clsOntologyItem
        Get
            Return objOItem_Type_Wetterlage
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Wichtige_Ereignisse() As clsOntologyItem
        Get
            Return objOItem_Type_Wichtige_Ereignisse
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Year() As clsOntologyItem
        Get
            Return objOItem_Type_Year
        End Get
    End Property


    Public Property OItem_User As clsOntologyItem
        Get
            Return objOItem_User
        End Get
        Set(ByVal value As clsOntologyItem)
            objOItem_User = value
        End Set
    End Property

    Private Sub get_Data_DevelopmentConfig()
        Dim objORL_Ontology_To_OntolgyItems = New List(Of clsObjectRel) From {New clsObjectRel With {.ID_Object = cstrID_Ontology, _
                                                                                             .ID_RelationType = objGlobals.RelationType_contains.GUID, _
                                                                                             .ID_Parent_Other = objGlobals.Class_OntologyItems.GUID}}



        Dim objOItem_Result = objDBLevel_Config1.get_Data_ObjectRel(objORL_Ontology_To_OntolgyItems, boolIDs:=False)
        If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then
            If objDBLevel_Config1.OList_ObjectRel.Any Then

                objORL_Ontology_To_OntolgyItems = New List(Of clsObjectRel) From {New clsObjectRel With {.ID_Parent_Object = objGlobals.Class_OntologyItems.GUID, _
                                                                                                     .ID_RelationType = objGlobals.RelationType_belongingAttribute.GUID},
                                                                              New clsObjectRel With {.ID_Parent_Object = objGlobals.Class_OntologyItems.GUID, _
                                                                                                     .ID_RelationType = objGlobals.RelationType_belongingClass.GUID},
                                                                             New clsObjectRel With {.ID_Parent_Object = objGlobals.Class_OntologyItems.GUID, _
                                                                                                     .ID_RelationType = objGlobals.RelationType_belongingObject.GUID},
                                                                              New clsObjectRel With {.ID_Parent_Object = objGlobals.Class_OntologyItems.GUID, _
                                                                                                     .ID_RelationType = objGlobals.RelationType_belongingRelationType.GUID}}

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

    Public ReadOnly Property Globals() As clsGlobals
        Get
            Return objGlobals
        End Get
    End Property

    Public Sub New(ByVal Globals As clsGlobals)
        objGlobals = Globals
        set_DBConnection()


        get_Config()
    End Sub

    Public Sub New()
        objGlobals = New clsGlobals
        set_DBConnection()

        get_Config()
    End Sub

    Private Sub set_DBConnection()
        objDBLevel_Config1 = New clsDBLevel(objGlobals)
        objDBLevel_Config2 = New clsDBLevel(objGlobals)
        objImport = New clsImport(objGlobals)
    End Sub

    Private Sub get_Config()
        Try
            get_Data_DevelopmentConfig()
            get_Config_AttributeTypes()
            get_Config_RelationTypes()
            get_Config_Classes()
            get_Config_Objects()
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
                Else
                    Err.Raise(1, "Config not importable")
                End If
            Else
                Environment.Exit(0)
            End If
        End Try
        

    End Sub

    Private Sub get_Config_AttributeTypes()
        Dim objOList_Attribute_Datetimestamp__Create_ = From obj In objDBLevel_Config2.OList_ObjectRel
                                  Where obj.Name_Object.ToLower = "attribute_datetimestamp__create_" And obj.Ontology = objGlobals.Type_AttributeType

        If objOList_Attribute_Datetimestamp__Create_.Count > 0 Then
            objOItem_Attribute_Datetimestamp__Create_ = New clsOntologyItem
            objOItem_Attribute_Datetimestamp__Create_.GUID = objOList_Attribute_Datetimestamp__Create_(0).ID_Other
            objOItem_Attribute_Datetimestamp__Create_.Name = objOList_Attribute_Datetimestamp__Create_(0).Name_Other
            objOItem_Attribute_Datetimestamp__Create_.GUID_Parent = objOList_Attribute_Datetimestamp__Create_(0).ID_Parent_Other
            objOItem_Attribute_Datetimestamp__Create_.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_comment = From obj In objDBLevel_Config2.OList_ObjectRel
                                  Where obj.Name_Object.ToLower = "attribute_comment" And obj.Ontology = objGlobals.Type_AttributeType

        If objOList_attribute_comment.Count > 0 Then
            objOItem_Attribute_comment = New clsOntologyItem
            objOItem_Attribute_comment.GUID = objOList_attribute_comment(0).ID_Other
            objOItem_Attribute_comment.Name = objOList_attribute_comment(0).Name_Other
            objOItem_Attribute_comment.GUID_Parent = objOList_attribute_comment(0).ID_Parent_Other
            objOItem_Attribute_comment.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_datetimestamp = From obj In objDBLevel_Config2.OList_ObjectRel
                                    Where obj.Name_Object.ToLower = "attribute_datetimestamp" And obj.Ontology = objGlobals.Type_AttributeType

        If objOList_attribute_datetimestamp.Count > 0 Then
            objOItem_Attribute_DateTimeStamp = New clsOntologyItem
            objOItem_Attribute_DateTimeStamp.GUID = objOList_attribute_datetimestamp(0).ID_Other
            objOItem_Attribute_DateTimeStamp.Name = objOList_attribute_datetimestamp(0).Name_Other
            objOItem_Attribute_DateTimeStamp.GUID_Parent = objOList_attribute_datetimestamp(0).ID_Parent_Other
            objOItem_Attribute_DateTimeStamp.Type = objGlobals.Type_AttributeType
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

        Dim objOList_attribute_id = From obj In objDBLevel_Config2.OList_ObjectRel
                                    Where obj.Name_Object.ToLower = "attribute_id" And obj.Ontology = objGlobals.Type_AttributeType

        If objOList_attribute_id.Count > 0 Then
            objOItem_Attribute_ID = New clsOntologyItem
            objOItem_Attribute_ID.GUID = objOList_attribute_id(0).ID_Other
            objOItem_Attribute_ID.Name = objOList_attribute_id(0).Name_Other
            objOItem_Attribute_ID.GUID_Parent = objOList_attribute_id(0).ID_Parent_Other
            objOItem_Attribute_ID.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_l_nge__minuten_ = From obj In objDBLevel_Config2.OList_ObjectRel
                                    Where obj.Name_Object.ToLower = "attribute_l_nge__minuten_" And obj.Ontology = objGlobals.Type_AttributeType

        If objOList_attribute_l_nge__minuten_.Count > 0 Then
            objOItem_Attribute_L_nge__Minuten_ = New clsOntologyItem
            objOItem_Attribute_L_nge__Minuten_.GUID = objOList_attribute_l_nge__minuten_(0).ID_Other
            objOItem_Attribute_L_nge__Minuten_.Name = objOList_attribute_l_nge__minuten_(0).Name_Other
            objOItem_Attribute_L_nge__Minuten_.GUID_Parent = objOList_attribute_l_nge__minuten_(0).ID_Parent_Other
            objOItem_Attribute_L_nge__Minuten_.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_media_position = From obj In objDBLevel_Config2.OList_ObjectRel
                                    Where obj.Name_Object.ToLower = "attribute_media_position" And obj.Ontology = objGlobals.Type_AttributeType

        If objOList_attribute_media_position.Count > 0 Then
            objOItem_Attribute_Media_Position = New clsOntologyItem
            objOItem_Attribute_Media_Position.GUID = objOList_attribute_media_position(0).ID_Other
            objOItem_Attribute_Media_Position.Name = objOList_attribute_media_position(0).Name_Other
            objOItem_Attribute_Media_Position.GUID_Parent = objOList_attribute_media_position(0).ID_Parent_Other
            objOItem_Attribute_Media_Position.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_taking = From obj In objDBLevel_Config2.OList_ObjectRel
                                    Where obj.Name_Object.ToLower = "attribute_taking" And obj.Ontology = objGlobals.Type_AttributeType

        If objOList_attribute_taking.Count > 0 Then
            objOItem_Attribute_taking = New clsOntologyItem
            objOItem_Attribute_taking.GUID = objOList_attribute_taking(0).ID_Other
            objOItem_Attribute_taking.Name = objOList_attribute_taking(0).Name_Other
            objOItem_Attribute_taking.GUID_Parent = objOList_attribute_taking(0).ID_Parent_Other
            objOItem_Attribute_taking.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_titel = From obj In objDBLevel_Config2.OList_ObjectRel
                                    Where obj.Name_Object.ToLower = "attribute_titel" And obj.Ontology = objGlobals.Type_AttributeType

        If objOList_attribute_titel.Count > 0 Then
            objOItem_Attribute_Titel = New clsOntologyItem
            objOItem_Attribute_Titel.GUID = objOList_attribute_titel(0).ID_Other
            objOItem_Attribute_Titel.Name = objOList_attribute_titel(0).Name_Other
            objOItem_Attribute_Titel.GUID_Parent = objOList_attribute_titel(0).ID_Parent_Other
            objOItem_Attribute_Titel.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_xml_text = From obj In objDBLevel_Config2.OList_ObjectRel
                                    Where obj.Name_Object.ToLower = "attribute_xml_text" And obj.Ontology = objGlobals.Type_AttributeType

        If objOList_attribute_xml_text.Count > 0 Then
            objOItem_Attribute_XML_Text = New clsOntologyItem
            objOItem_Attribute_XML_Text.GUID = objOList_attribute_xml_text(0).ID_Other
            objOItem_Attribute_XML_Text.Name = objOList_attribute_xml_text(0).Name_Other
            objOItem_Attribute_XML_Text.GUID_Parent = objOList_attribute_xml_text(0).ID_Parent_Other
            objOItem_Attribute_XML_Text.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If


    End Sub

    Private Sub get_Config_RelationTypes()
        Dim objOList_relationtype_artist = From obj In objDBLevel_Config2.OList_ObjectRel
                          Where obj.Name_Object.ToLower = "relationtype_artist" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_artist.Count > 0 Then
            objOItem_RelationType_Artist = New clsOntologyItem
            objOItem_RelationType_Artist.GUID = objOList_relationtype_artist(0).ID_Other
            objOItem_RelationType_Artist.Name = objOList_relationtype_artist(0).Name_Other
            objOItem_RelationType_Artist.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_belonging_done = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_belonging_done" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_belonging_done.Count > 0 Then
            objOItem_RelationType_belonging_Done = New clsOntologyItem
            objOItem_RelationType_belonging_Done.GUID = objOList_relationtype_belonging_done(0).ID_Other
            objOItem_RelationType_belonging_Done.Name = objOList_relationtype_belonging_done(0).Name_Other
            objOItem_RelationType_belonging_Done.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_belonging_source = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_belonging_source" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_belonging_source.Count > 0 Then
            objOItem_RelationType_belonging_Source = New clsOntologyItem
            objOItem_RelationType_belonging_Source.GUID = objOList_relationtype_belonging_source(0).ID_Other
            objOItem_RelationType_belonging_Source.Name = objOList_relationtype_belonging_source(0).Name_Other
            objOItem_RelationType_belonging_Source.Type = objGlobals.Type_RelationType
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

        Dim objOList_relationtype_composer = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_composer" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_composer.Count > 0 Then
            objOItem_RelationType_Composer = New clsOntologyItem
            objOItem_RelationType_Composer.GUID = objOList_relationtype_composer(0).ID_Other
            objOItem_RelationType_Composer.Name = objOList_relationtype_composer(0).Name_Other
            objOItem_RelationType_Composer.Type = objGlobals.Type_RelationType
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

        Dim objOList_relationtype_disc = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_disc" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_disc.Count > 0 Then
            objOItem_RelationType_Disc = New clsOntologyItem
            objOItem_RelationType_Disc.GUID = objOList_relationtype_disc(0).ID_Other
            objOItem_RelationType_Disc.Name = objOList_relationtype_disc(0).Name_Other
            objOItem_RelationType_Disc.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_finished_with = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_finished_with" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_finished_with.Count > 0 Then
            objOItem_RelationType_finished_with = New clsOntologyItem
            objOItem_RelationType_finished_with.GUID = objOList_relationtype_finished_with(0).ID_Other
            objOItem_RelationType_finished_with.Name = objOList_relationtype_finished_with(0).Name_Other
            objOItem_RelationType_finished_with.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_from = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_from" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_from.Count > 0 Then
            objOItem_RelationType_from = New clsOntologyItem
            objOItem_RelationType_from.GUID = objOList_relationtype_from(0).ID_Other
            objOItem_RelationType_from.Name = objOList_relationtype_from(0).Name_Other
            objOItem_RelationType_from.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_has = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_has" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_has.Count > 0 Then
            objOItem_RelationType_has = New clsOntologyItem
            objOItem_RelationType_has.GUID = objOList_relationtype_has(0).ID_Other
            objOItem_RelationType_has.Name = objOList_relationtype_has(0).Name_Other
            objOItem_RelationType_has.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_is = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_is" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_is.Count > 0 Then
            objOItem_RelationType_is = New clsOntologyItem
            objOItem_RelationType_is.GUID = objOList_relationtype_is(0).ID_Other
            objOItem_RelationType_is.Name = objOList_relationtype_is(0).Name_Other
            objOItem_RelationType_is.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_is_of_type = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_is_of_type" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_is_of_type.Count > 0 Then
            objOItem_RelationType_is_of_Type = New clsOntologyItem
            objOItem_RelationType_is_of_Type.GUID = objOList_relationtype_is_of_type(0).ID_Other
            objOItem_RelationType_is_of_Type.Name = objOList_relationtype_is_of_type(0).Name_Other
            objOItem_RelationType_is_of_Type.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_is_used_by = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_is_used_by" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_is_used_by.Count > 0 Then
            objOItem_RelationType_is_used_by = New clsOntologyItem
            objOItem_RelationType_is_used_by.GUID = objOList_relationtype_is_used_by(0).ID_Other
            objOItem_RelationType_is_used_by.Name = objOList_relationtype_is_used_by(0).Name_Other
            objOItem_RelationType_is_used_by.Type = objGlobals.Type_RelationType
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

        Dim objOList_relationtype_located_in = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_located_in" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_located_in.Count > 0 Then
            objOItem_RelationType_located_in = New clsOntologyItem
            objOItem_RelationType_located_in.GUID = objOList_relationtype_located_in(0).ID_Other
            objOItem_RelationType_located_in.Name = objOList_relationtype_located_in(0).Name_Other
            objOItem_RelationType_located_in.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_media_webservice_url = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_media_webservice_url" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_media_webservice_url.Count > 0 Then
            objOItem_RelationType_Media_Webservice_Url = New clsOntologyItem
            objOItem_RelationType_Media_Webservice_Url.GUID = objOList_relationtype_media_webservice_url(0).ID_Other
            objOItem_RelationType_Media_Webservice_Url.Name = objOList_relationtype_media_webservice_url(0).Name_Other
            objOItem_RelationType_Media_Webservice_Url.Type = objGlobals.Type_RelationType
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

        Dim objOList_relationtype_offers = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_offers" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_offers.Count > 0 Then
            objOItem_RelationType_offers = New clsOntologyItem
            objOItem_RelationType_offers.GUID = objOList_relationtype_offers(0).ID_Other
            objOItem_RelationType_offers.Name = objOList_relationtype_offers(0).Name_Other
            objOItem_RelationType_offers.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_started_with = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_started_with" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_started_with.Count > 0 Then
            objOItem_RelationType_started_with = New clsOntologyItem
            objOItem_RelationType_started_with.GUID = objOList_relationtype_started_with(0).ID_Other
            objOItem_RelationType_started_with.Name = objOList_relationtype_started_with(0).Name_Other
            objOItem_RelationType_started_with.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_taking_at = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_taking_at" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_taking_at.Count > 0 Then
            objOItem_RelationType_taking_at = New clsOntologyItem
            objOItem_RelationType_taking_at.GUID = objOList_relationtype_taking_at(0).ID_Other
            objOItem_RelationType_taking_at.Name = objOList_relationtype_taking_at(0).Name_Other
            objOItem_RelationType_taking_at.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_wascreatedby = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_wascreatedby" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_wascreatedby.Count > 0 Then
            objOItem_RelationType_wasCreatedBy = New clsOntologyItem
            objOItem_RelationType_wasCreatedBy.GUID = objOList_relationtype_wascreatedby(0).ID_Other
            objOItem_RelationType_wasCreatedBy.Name = objOList_relationtype_wascreatedby(0).Name_Other
            objOItem_RelationType_wasCreatedBy.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If


    End Sub

    Private Sub get_Config_Objects()
        Dim objOList_token_extensions_image = From obj In objDBLevel_Config2.OList_ObjectRel
                          Where obj.Name_Object.ToLower = "token_extensions_image" And obj.Ontology = objGlobals.Type_Object

        If objOList_token_extensions_image.Count > 0 Then
            objOItem_Token_Extensions_Image = New clsOntologyItem
            objOItem_Token_Extensions_Image.GUID = objOList_token_extensions_image(0).ID_Other
            objOItem_Token_Extensions_Image.Name = objOList_token_extensions_image(0).Name_Other
            objOItem_Token_Extensions_Image.GUID_Parent = objOList_token_extensions_image(0).ID_Parent_Other
            objOItem_Token_Extensions_Image.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_token_extensions_mod = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "token_extensions_mod" And obj.Ontology = objGlobals.Type_Object

        If objOList_token_extensions_mod.Count > 0 Then
            objOItem_Token_Extensions_mod = New clsOntologyItem
            objOItem_Token_Extensions_mod.GUID = objOList_token_extensions_mod(0).ID_Other
            objOItem_Token_Extensions_mod.Name = objOList_token_extensions_mod(0).Name_Other
            objOItem_Token_Extensions_mod.GUID_Parent = objOList_token_extensions_mod(0).ID_Parent_Other
            objOItem_Token_Extensions_mod.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_token_extensions_pdf = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "token_extensions_pdf" And obj.Ontology = objGlobals.Type_Object

        If objOList_token_extensions_pdf.Count > 0 Then
            objOItem_Token_Extensions_pdf = New clsOntologyItem
            objOItem_Token_Extensions_pdf.GUID = objOList_token_extensions_pdf(0).ID_Other
            objOItem_Token_Extensions_pdf.Name = objOList_token_extensions_pdf(0).Name_Other
            objOItem_Token_Extensions_pdf.GUID_Parent = objOList_token_extensions_pdf(0).ID_Parent_Other
            objOItem_Token_Extensions_pdf.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_token_image_objects__no_objects__no_address = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "token_image_objects__no_objects__no_address" And obj.Ontology = objGlobals.Type_Object

        If objOList_token_image_objects__no_objects__no_address.Count > 0 Then
            objOItem_Token_Image_Objects__No_Objects__no_Address = New clsOntologyItem
            objOItem_Token_Image_Objects__No_Objects__no_Address.GUID = objOList_token_image_objects__no_objects__no_address(0).ID_Other
            objOItem_Token_Image_Objects__No_Objects__no_Address.Name = objOList_token_image_objects__no_objects__no_address(0).Name_Other
            objOItem_Token_Image_Objects__No_Objects__no_Address.GUID_Parent = objOList_token_image_objects__no_objects__no_address(0).ID_Parent_Other
            objOItem_Token_Image_Objects__No_Objects__no_Address.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_token_image_objects__no_objects__no_artwork = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "token_image_objects__no_objects__no_artwork" And obj.Ontology = objGlobals.Type_Object

        If objOList_token_image_objects__no_objects__no_artwork.Count > 0 Then
            objOItem_Token_Image_Objects__No_Objects__no_Artwork = New clsOntologyItem
            objOItem_Token_Image_Objects__No_Objects__no_Artwork.GUID = objOList_token_image_objects__no_objects__no_artwork(0).ID_Other
            objOItem_Token_Image_Objects__No_Objects__no_Artwork.Name = objOList_token_image_objects__no_objects__no_artwork(0).Name_Other
            objOItem_Token_Image_Objects__No_Objects__no_Artwork.GUID_Parent = objOList_token_image_objects__no_objects__no_artwork(0).ID_Parent_Other
            objOItem_Token_Image_Objects__No_Objects__no_Artwork.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_token_image_objects__no_objects__no_buildings = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "token_image_objects__no_objects__no_buildings" And obj.Ontology = objGlobals.Type_Object

        If objOList_token_image_objects__no_objects__no_buildings.Count > 0 Then
            objOItem_Token_Image_Objects__No_Objects__no_Buildings = New clsOntologyItem
            objOItem_Token_Image_Objects__No_Objects__no_Buildings.GUID = objOList_token_image_objects__no_objects__no_buildings(0).ID_Other
            objOItem_Token_Image_Objects__No_Objects__no_Buildings.Name = objOList_token_image_objects__no_objects__no_buildings(0).Name_Other
            objOItem_Token_Image_Objects__No_Objects__no_Buildings.GUID_Parent = objOList_token_image_objects__no_objects__no_buildings(0).ID_Parent_Other
            objOItem_Token_Image_Objects__No_Objects__no_Buildings.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_token_image_objects__no_objects__no_landscape = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "token_image_objects__no_objects__no_landscape" And obj.Ontology = objGlobals.Type_Object

        If objOList_token_image_objects__no_objects__no_landscape.Count > 0 Then
            objOItem_Token_Image_Objects__No_Objects__no_landscape = New clsOntologyItem
            objOItem_Token_Image_Objects__No_Objects__no_landscape.GUID = objOList_token_image_objects__no_objects__no_landscape(0).ID_Other
            objOItem_Token_Image_Objects__No_Objects__no_landscape.Name = objOList_token_image_objects__no_objects__no_landscape(0).Name_Other
            objOItem_Token_Image_Objects__No_Objects__no_landscape.GUID_Parent = objOList_token_image_objects__no_objects__no_landscape(0).ID_Parent_Other
            objOItem_Token_Image_Objects__No_Objects__no_landscape.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_token_image_objects__no_objects__no_location = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "token_image_objects__no_objects__no_location" And obj.Ontology = objGlobals.Type_Object

        If objOList_token_image_objects__no_objects__no_location.Count > 0 Then
            objOItem_Token_Image_Objects__No_Objects__no_Location = New clsOntologyItem
            objOItem_Token_Image_Objects__No_Objects__no_Location.GUID = objOList_token_image_objects__no_objects__no_location(0).ID_Other
            objOItem_Token_Image_Objects__No_Objects__no_Location.Name = objOList_token_image_objects__no_objects__no_location(0).Name_Other
            objOItem_Token_Image_Objects__No_Objects__no_Location.GUID_Parent = objOList_token_image_objects__no_objects__no_location(0).ID_Parent_Other
            objOItem_Token_Image_Objects__No_Objects__no_Location.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_token_image_objects__no_objects__no_persons = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "token_image_objects__no_objects__no_persons" And obj.Ontology = objGlobals.Type_Object

        If objOList_token_image_objects__no_objects__no_persons.Count > 0 Then
            objOItem_Token_Image_Objects__No_Objects__no_Persons = New clsOntologyItem
            objOItem_Token_Image_Objects__No_Objects__no_Persons.GUID = objOList_token_image_objects__no_objects__no_persons(0).ID_Other
            objOItem_Token_Image_Objects__No_Objects__no_Persons.Name = objOList_token_image_objects__no_objects__no_persons(0).Name_Other
            objOItem_Token_Image_Objects__No_Objects__no_Persons.GUID_Parent = objOList_token_image_objects__no_objects__no_persons(0).ID_Parent_Other
            objOItem_Token_Image_Objects__No_Objects__no_Persons.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_token_image_objects__no_objects__no_pets = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "token_image_objects__no_objects__no_pets" And obj.Ontology = objGlobals.Type_Object

        If objOList_token_image_objects__no_objects__no_pets.Count > 0 Then
            objOItem_Token_Image_Objects__No_Objects__no_Pets = New clsOntologyItem
            objOItem_Token_Image_Objects__No_Objects__no_Pets.GUID = objOList_token_image_objects__no_objects__no_pets(0).ID_Other
            objOItem_Token_Image_Objects__No_Objects__no_Pets.Name = objOList_token_image_objects__no_objects__no_pets(0).Name_Other
            objOItem_Token_Image_Objects__No_Objects__no_Pets.GUID_Parent = objOList_token_image_objects__no_objects__no_pets(0).ID_Parent_Other
            objOItem_Token_Image_Objects__No_Objects__no_Pets.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_token_image_objects__no_objects__no_plant_species = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "token_image_objects__no_objects__no_plant_species" And obj.Ontology = objGlobals.Type_Object

        If objOList_token_image_objects__no_objects__no_plant_species.Count > 0 Then
            objOItem_Token_Image_Objects__No_Objects__no_plant_Species = New clsOntologyItem
            objOItem_Token_Image_Objects__No_Objects__no_plant_Species.GUID = objOList_token_image_objects__no_objects__no_plant_species(0).ID_Other
            objOItem_Token_Image_Objects__No_Objects__no_plant_Species.Name = objOList_token_image_objects__no_objects__no_plant_species(0).Name_Other
            objOItem_Token_Image_Objects__No_Objects__no_plant_Species.GUID_Parent = objOList_token_image_objects__no_objects__no_plant_species(0).ID_Parent_Other
            objOItem_Token_Image_Objects__No_Objects__no_plant_Species.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_token_image_objects__no_objects__no_species = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "token_image_objects__no_objects__no_species" And obj.Ontology = objGlobals.Type_Object

        If objOList_token_image_objects__no_objects__no_species.Count > 0 Then
            objOItem_Token_Image_Objects__No_Objects__no_species = New clsOntologyItem
            objOItem_Token_Image_Objects__No_Objects__no_species.GUID = objOList_token_image_objects__no_objects__no_species(0).ID_Other
            objOItem_Token_Image_Objects__No_Objects__no_species.Name = objOList_token_image_objects__no_objects__no_species(0).Name_Other
            objOItem_Token_Image_Objects__No_Objects__no_species.GUID_Parent = objOList_token_image_objects__no_objects__no_species(0).ID_Parent_Other
            objOItem_Token_Image_Objects__No_Objects__no_species.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_token_image_objects__no_objects__no_symbol = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "token_image_objects__no_objects__no_symbol" And obj.Ontology = objGlobals.Type_Object

        If objOList_token_image_objects__no_objects__no_symbol.Count > 0 Then
            objOItem_Token_Image_Objects__No_Objects__no_Symbol = New clsOntologyItem
            objOItem_Token_Image_Objects__No_Objects__no_Symbol.GUID = objOList_token_image_objects__no_objects__no_symbol(0).ID_Other
            objOItem_Token_Image_Objects__No_Objects__no_Symbol.Name = objOList_token_image_objects__no_objects__no_symbol(0).Name_Other
            objOItem_Token_Image_Objects__No_Objects__no_Symbol.GUID_Parent = objOList_token_image_objects__no_objects__no_symbol(0).ID_Parent_Other
            objOItem_Token_Image_Objects__No_Objects__no_Symbol.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_token_image_objects__no_objects__weather_condition = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "token_image_objects__no_objects__weather_condition" And obj.Ontology = objGlobals.Type_Object

        If objOList_token_image_objects__no_objects__weather_condition.Count > 0 Then
            objOItem_Token_Image_Objects__No_Objects__weather_condition = New clsOntologyItem
            objOItem_Token_Image_Objects__No_Objects__weather_condition.GUID = objOList_token_image_objects__no_objects__weather_condition(0).ID_Other
            objOItem_Token_Image_Objects__No_Objects__weather_condition.Name = objOList_token_image_objects__no_objects__weather_condition(0).Name_Other
            objOItem_Token_Image_Objects__No_Objects__weather_condition.GUID_Parent = objOList_token_image_objects__no_objects__weather_condition(0).ID_Parent_Other
            objOItem_Token_Image_Objects__No_Objects__weather_condition.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_token_logstate_last_position = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "token_logstate_last_position" And obj.Ontology = objGlobals.Type_Object

        If objOList_token_logstate_last_position.Count > 0 Then
            objOItem_Token_Logstate_Last_Position = New clsOntologyItem
            objOItem_Token_Logstate_Last_Position.GUID = objOList_token_logstate_last_position(0).ID_Other
            objOItem_Token_Logstate_Last_Position.Name = objOList_token_logstate_last_position(0).Name_Other
            objOItem_Token_Logstate_Last_Position.GUID_Parent = objOList_token_logstate_last_position(0).ID_Parent_Other
            objOItem_Token_Logstate_Last_Position.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_token_logstate_pause = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "token_logstate_pause" And obj.Ontology = objGlobals.Type_Object

        If objOList_token_logstate_pause.Count > 0 Then
            objOItem_Token_Logstate_Pause = New clsOntologyItem
            objOItem_Token_Logstate_Pause.GUID = objOList_token_logstate_pause(0).ID_Other
            objOItem_Token_Logstate_Pause.Name = objOList_token_logstate_pause(0).Name_Other
            objOItem_Token_Logstate_Pause.GUID_Parent = objOList_token_logstate_pause(0).ID_Parent_Other
            objOItem_Token_Logstate_Pause.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_token_logstate_start = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "token_logstate_start" And obj.Ontology = objGlobals.Type_Object

        If objOList_token_logstate_start.Count > 0 Then
            objOItem_Token_Logstate_Start = New clsOntologyItem
            objOItem_Token_Logstate_Start.GUID = objOList_token_logstate_start(0).ID_Other
            objOItem_Token_Logstate_Start.Name = objOList_token_logstate_start(0).Name_Other
            objOItem_Token_Logstate_Start.GUID_Parent = objOList_token_logstate_start(0).ID_Parent_Other
            objOItem_Token_Logstate_Start.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_token_logstate_stop = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "token_logstate_stop" And obj.Ontology = objGlobals.Type_Object

        If objOList_token_logstate_stop.Count > 0 Then
            objOItem_Token_Logstate_Stop = New clsOntologyItem
            objOItem_Token_Logstate_Stop.GUID = objOList_token_logstate_stop(0).ID_Other
            objOItem_Token_Logstate_Stop.Name = objOList_token_logstate_stop(0).Name_Other
            objOItem_Token_Logstate_Stop.GUID_Parent = objOList_token_logstate_stop(0).ID_Parent_Other
            objOItem_Token_Logstate_Stop.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_token_logstate_unassigned = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "token_logstate_unassigned" And obj.Ontology = objGlobals.Type_Object

        If objOList_token_logstate_unassigned.Count > 0 Then
            objOItem_Token_Logstate_Unassigned = New clsOntologyItem
            objOItem_Token_Logstate_Unassigned.GUID = objOList_token_logstate_unassigned(0).ID_Other
            objOItem_Token_Logstate_Unassigned.Name = objOList_token_logstate_unassigned(0).Name_Other
            objOItem_Token_Logstate_Unassigned.GUID_Parent = objOList_token_logstate_unassigned(0).ID_Parent_Other
            objOItem_Token_Logstate_Unassigned.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_token_logstate_user_defined = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "token_logstate_user_defined" And obj.Ontology = objGlobals.Type_Object

        If objOList_token_logstate_user_defined.Count > 0 Then
            objOItem_Token_Logstate_User_Defined = New clsOntologyItem
            objOItem_Token_Logstate_User_Defined.GUID = objOList_token_logstate_user_defined(0).ID_Other
            objOItem_Token_Logstate_User_Defined.Name = objOList_token_logstate_user_defined(0).Name_Other
            objOItem_Token_Logstate_User_Defined.GUID_Parent = objOList_token_logstate_user_defined(0).ID_Parent_Other
            objOItem_Token_Logstate_User_Defined.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_token_search_template_name_ = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "token_search_template_name_" And obj.Ontology = objGlobals.Type_Object

        If objOList_token_search_template_name_.Count > 0 Then
            objOItem_Token_Search_Template_Name_ = New clsOntologyItem
            objOItem_Token_Search_Template_Name_.GUID = objOList_token_search_template_name_(0).ID_Other
            objOItem_Token_Search_Template_Name_.Name = objOList_token_search_template_name_(0).Name_Other
            objOItem_Token_Search_Template_Name_.GUID_Parent = objOList_token_search_template_name_(0).ID_Parent_Other
            objOItem_Token_Search_Template_Name_.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_token_variable_itemcount = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "token_variable_itemcount" And obj.Ontology = objGlobals.Type_Object

        If objOList_token_variable_itemcount.Count > 0 Then
            objOItem_Token_Variable_ITEMCOUNT = New clsOntologyItem
            objOItem_Token_Variable_ITEMCOUNT.GUID = objOList_token_variable_itemcount(0).ID_Other
            objOItem_Token_Variable_ITEMCOUNT.Name = objOList_token_variable_itemcount(0).Name_Other
            objOItem_Token_Variable_ITEMCOUNT.GUID_Parent = objOList_token_variable_itemcount(0).ID_Parent_Other
            objOItem_Token_Variable_ITEMCOUNT.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_token_variable_mediasrc = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "token_variable_mediasrc" And obj.Ontology = objGlobals.Type_Object

        If objOList_token_variable_mediasrc.Count > 0 Then
            objOItem_Token_Variable_MEDIASRC = New clsOntologyItem
            objOItem_Token_Variable_MEDIASRC.GUID = objOList_token_variable_mediasrc(0).ID_Other
            objOItem_Token_Variable_MEDIASRC.Name = objOList_token_variable_mediasrc(0).Name_Other
            objOItem_Token_Variable_MEDIASRC.GUID_Parent = objOList_token_variable_mediasrc(0).ID_Parent_Other
            objOItem_Token_Variable_MEDIASRC.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_token_variable_title = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "token_variable_title" And obj.Ontology = objGlobals.Type_Object

        If objOList_token_variable_title.Count > 0 Then
            objOItem_Token_Variable_title = New clsOntologyItem
            objOItem_Token_Variable_title.GUID = objOList_token_variable_title(0).ID_Other
            objOItem_Token_Variable_title.Name = objOList_token_variable_title(0).Name_Other
            objOItem_Token_Variable_title.GUID_Parent = objOList_token_variable_title(0).ID_Parent_Other
            objOItem_Token_Variable_title.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_token_variable_url_mediasrc = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "token_variable_url_mediasrc" And obj.Ontology = objGlobals.Type_Object

        If objOList_token_variable_url_mediasrc.Count > 0 Then
            objOItem_Token_Variable_URL_MEDIASRC = New clsOntologyItem
            objOItem_Token_Variable_URL_MEDIASRC.GUID = objOList_token_variable_url_mediasrc(0).ID_Other
            objOItem_Token_Variable_URL_MEDIASRC.Name = objOList_token_variable_url_mediasrc(0).Name_Other
            objOItem_Token_Variable_URL_MEDIASRC.GUID_Parent = objOList_token_variable_url_mediasrc(0).ID_Parent_Other
            objOItem_Token_Variable_URL_MEDIASRC.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_token_xml_windows_playlist_1_0 = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "token_xml_windows_playlist_1_0" And obj.Ontology = objGlobals.Type_Object

        If objOList_token_xml_windows_playlist_1_0.Count > 0 Then
            objOItem_Token_XML_Windows_Playlist_1_0 = New clsOntologyItem
            objOItem_Token_XML_Windows_Playlist_1_0.GUID = objOList_token_xml_windows_playlist_1_0(0).ID_Other
            objOItem_Token_XML_Windows_Playlist_1_0.Name = objOList_token_xml_windows_playlist_1_0(0).Name_Other
            objOItem_Token_XML_Windows_Playlist_1_0.GUID_Parent = objOList_token_xml_windows_playlist_1_0(0).ID_Parent_Other
            objOItem_Token_XML_Windows_Playlist_1_0.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_token_xml_windows_playlist_1_0_mediasrc = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "token_xml_windows_playlist_1_0_mediasrc" And obj.Ontology = objGlobals.Type_Object

        If objOList_token_xml_windows_playlist_1_0_mediasrc.Count > 0 Then
            objOItem_Token_XML_Windows_Playlist_1_0_mediasrc = New clsOntologyItem
            objOItem_Token_XML_Windows_Playlist_1_0_mediasrc.GUID = objOList_token_xml_windows_playlist_1_0_mediasrc(0).ID_Other
            objOItem_Token_XML_Windows_Playlist_1_0_mediasrc.Name = objOList_token_xml_windows_playlist_1_0_mediasrc(0).Name_Other
            objOItem_Token_XML_Windows_Playlist_1_0_mediasrc.GUID_Parent = objOList_token_xml_windows_playlist_1_0_mediasrc(0).ID_Parent_Other
            objOItem_Token_XML_Windows_Playlist_1_0_mediasrc.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If


    End Sub

    Private Sub get_Config_Classes()
        Dim objOList_type_album = From obj In objDBLevel_Config2.OList_ObjectRel
                          Where obj.Name_Object.ToLower = "type_album" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_album.Count > 0 Then
            objOItem_Type_Album = New clsOntologyItem
            objOItem_Type_Album.GUID = objOList_type_album(0).ID_Other
            objOItem_Type_Album.Name = objOList_type_album(0).Name_Other
            objOItem_Type_Album.GUID_Parent = objOList_type_album(0).ID_Parent_Other
            objOItem_Type_Album.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_band = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_band" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_band.Count > 0 Then
            objOItem_Type_Band = New clsOntologyItem
            objOItem_Type_Band.GUID = objOList_type_band(0).ID_Other
            objOItem_Type_Band.Name = objOList_type_band(0).Name_Other
            objOItem_Type_Band.GUID_Parent = objOList_type_band(0).ID_Parent_Other
            objOItem_Type_Band.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_bauwerke = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_bauwerke" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_bauwerke.Count > 0 Then
            objOItem_Type_Bauwerke = New clsOntologyItem
            objOItem_Type_Bauwerke.GUID = objOList_type_bauwerke(0).ID_Other
            objOItem_Type_Bauwerke.Name = objOList_type_bauwerke(0).Name_Other
            objOItem_Type_Bauwerke.GUID_Parent = objOList_type_bauwerke(0).ID_Parent_Other
            objOItem_Type_Bauwerke.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_day = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_day" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_day.Count > 0 Then
            objOItem_Type_Day = New clsOntologyItem
            objOItem_Type_Day.GUID = objOList_type_day(0).ID_Other
            objOItem_Type_Day.Name = objOList_type_day(0).Name_Other
            objOItem_Type_Day.GUID_Parent = objOList_type_day(0).ID_Parent_Other
            objOItem_Type_Day.Type = objGlobals.Type_Class
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

        Dim objOList_type_filetypes = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_filetypes" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_filetypes.Count > 0 Then
            objOItem_Type_Filetypes = New clsOntologyItem
            objOItem_Type_Filetypes.GUID = objOList_type_filetypes(0).ID_Other
            objOItem_Type_Filetypes.Name = objOList_type_filetypes(0).Name_Other
            objOItem_Type_Filetypes.GUID_Parent = objOList_type_filetypes(0).ID_Parent_Other
            objOItem_Type_Filetypes.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_genre = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_genre" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_genre.Count > 0 Then
            objOItem_Type_Genre = New clsOntologyItem
            objOItem_Type_Genre.GUID = objOList_type_genre(0).ID_Other
            objOItem_Type_Genre.Name = objOList_type_genre(0).Name_Other
            objOItem_Type_Genre.GUID_Parent = objOList_type_genre(0).ID_Parent_Other
            objOItem_Type_Genre.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_haustier = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_haustier" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_haustier.Count > 0 Then
            objOItem_Type_Haustier = New clsOntologyItem
            objOItem_Type_Haustier.GUID = objOList_type_haustier(0).ID_Other
            objOItem_Type_Haustier.Name = objOList_type_haustier(0).Name_Other
            objOItem_Type_Haustier.GUID_Parent = objOList_type_haustier(0).ID_Parent_Other
            objOItem_Type_Haustier.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_image_module = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_image_module" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_image_module.Count > 0 Then
            objOItem_Type_Image_Module = New clsOntologyItem
            objOItem_Type_Image_Module.GUID = objOList_type_image_module(0).ID_Other
            objOItem_Type_Image_Module.Name = objOList_type_image_module(0).Name_Other
            objOItem_Type_Image_Module.GUID_Parent = objOList_type_image_module(0).ID_Parent_Other
            objOItem_Type_Image_Module.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_image_objects = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_image_objects" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_image_objects.Count > 0 Then
            objOItem_Type_Image_Objects = New clsOntologyItem
            objOItem_Type_Image_Objects.GUID = objOList_type_image_objects(0).ID_Other
            objOItem_Type_Image_Objects.Name = objOList_type_image_objects(0).Name_Other
            objOItem_Type_Image_Objects.GUID_Parent = objOList_type_image_objects(0).ID_Parent_Other
            objOItem_Type_Image_Objects.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_image_objects__no_objects_ = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_image_objects__no_objects_" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_image_objects__no_objects_.Count > 0 Then
            objOItem_Type_Image_Objects__No_Objects_ = New clsOntologyItem
            objOItem_Type_Image_Objects__No_Objects_.GUID = objOList_type_image_objects__no_objects_(0).ID_Other
            objOItem_Type_Image_Objects__No_Objects_.Name = objOList_type_image_objects__no_objects_(0).Name_Other
            objOItem_Type_Image_Objects__No_Objects_.GUID_Parent = objOList_type_image_objects__no_objects_(0).ID_Parent_Other
            objOItem_Type_Image_Objects__No_Objects_.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_images__graphic_ = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_images__graphic_" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_images__graphic_.Count > 0 Then
            objOItem_Type_Images__Graphic_ = New clsOntologyItem
            objOItem_Type_Images__Graphic_.GUID = objOList_type_images__graphic_(0).ID_Other
            objOItem_Type_Images__Graphic_.Name = objOList_type_images__graphic_(0).Name_Other
            objOItem_Type_Images__Graphic_.GUID_Parent = objOList_type_images__graphic_(0).ID_Parent_Other
            objOItem_Type_Images__Graphic_.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_kunst = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_kunst" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_kunst.Count > 0 Then
            objOItem_Type_Kunst = New clsOntologyItem
            objOItem_Type_Kunst.GUID = objOList_type_kunst(0).ID_Other
            objOItem_Type_Kunst.Name = objOList_type_kunst(0).Name_Other
            objOItem_Type_Kunst.GUID_Parent = objOList_type_kunst(0).ID_Parent_Other
            objOItem_Type_Kunst.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_landscape = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_landscape" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_landscape.Count > 0 Then
            objOItem_Type_landscape = New clsOntologyItem
            objOItem_Type_landscape.GUID = objOList_type_landscape(0).ID_Other
            objOItem_Type_landscape.Name = objOList_type_landscape(0).Name_Other
            objOItem_Type_landscape.GUID_Parent = objOList_type_landscape(0).ID_Parent_Other
            objOItem_Type_landscape.Type = objGlobals.Type_Class
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

        Dim objOList_type_logentry = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_logentry" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_logentry.Count > 0 Then
            objOItem_Type_LogEntry = New clsOntologyItem
            objOItem_Type_LogEntry.GUID = objOList_type_logentry(0).ID_Other
            objOItem_Type_LogEntry.Name = objOList_type_logentry(0).Name_Other
            objOItem_Type_LogEntry.GUID_Parent = objOList_type_logentry(0).ID_Parent_Other
            objOItem_Type_LogEntry.Type = objGlobals.Type_Class
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

        Dim objOList_type_media_item = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_media_item" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_media_item.Count > 0 Then
            objOItem_Type_Media_Item = New clsOntologyItem
            objOItem_Type_Media_Item.GUID = objOList_type_media_item(0).ID_Other
            objOItem_Type_Media_Item.Name = objOList_type_media_item(0).Name_Other
            objOItem_Type_Media_Item.GUID_Parent = objOList_type_media_item(0).ID_Parent_Other
            objOItem_Type_Media_Item.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_media_item_bookmark = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_media_item_bookmark" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_media_item_bookmark.Count > 0 Then
            objOItem_Type_Media_Item_Bookmark = New clsOntologyItem
            objOItem_Type_Media_Item_Bookmark.GUID = objOList_type_media_item_bookmark(0).ID_Other
            objOItem_Type_Media_Item_Bookmark.Name = objOList_type_media_item_bookmark(0).Name_Other
            objOItem_Type_Media_Item_Bookmark.GUID_Parent = objOList_type_media_item_bookmark(0).ID_Parent_Other
            objOItem_Type_Media_Item_Bookmark.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_media_item_range = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_media_item_range" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_media_item_range.Count > 0 Then
            objOItem_Type_Media_Item_Range = New clsOntologyItem
            objOItem_Type_Media_Item_Range.GUID = objOList_type_media_item_range(0).ID_Other
            objOItem_Type_Media_Item_Range.Name = objOList_type_media_item_range(0).Name_Other
            objOItem_Type_Media_Item_Range.GUID_Parent = objOList_type_media_item_range(0).ID_Parent_Other
            objOItem_Type_Media_Item_Range.Type = objGlobals.Type_Class
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

        Dim objOList_type_month = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_month" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_month.Count > 0 Then
            objOItem_Type_Month = New clsOntologyItem
            objOItem_Type_Month.GUID = objOList_type_month(0).ID_Other
            objOItem_Type_Month.Name = objOList_type_month(0).Name_Other
            objOItem_Type_Month.GUID_Parent = objOList_type_month(0).ID_Parent_Other
            objOItem_Type_Month.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_mp3_file = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_mp3_file" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_mp3_file.Count > 0 Then
            objOItem_Type_mp3_File = New clsOntologyItem
            objOItem_Type_mp3_File.GUID = objOList_type_mp3_file(0).ID_Other
            objOItem_Type_mp3_File.Name = objOList_type_mp3_file(0).Name_Other
            objOItem_Type_mp3_File.GUID_Parent = objOList_type_mp3_file(0).ID_Parent_Other
            objOItem_Type_mp3_File.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_ort = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_ort" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_ort.Count > 0 Then
            objOItem_Type_Ort = New clsOntologyItem
            objOItem_Type_Ort.GUID = objOList_type_ort(0).ID_Other
            objOItem_Type_Ort.Name = objOList_type_ort(0).Name_Other
            objOItem_Type_Ort.GUID_Parent = objOList_type_ort(0).ID_Parent_Other
            objOItem_Type_Ort.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_partner = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_partner" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_partner.Count > 0 Then
            objOItem_Type_Partner = New clsOntologyItem
            objOItem_Type_Partner.GUID = objOList_type_partner(0).ID_Other
            objOItem_Type_Partner.Name = objOList_type_partner(0).Name_Other
            objOItem_Type_Partner.GUID_Parent = objOList_type_partner(0).ID_Parent_Other
            objOItem_Type_Partner.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_pdf_documents = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_pdf_documents" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_pdf_documents.Count > 0 Then
            objOItem_Type_PDF_Documents = New clsOntologyItem
            objOItem_Type_PDF_Documents.GUID = objOList_type_pdf_documents(0).ID_Other
            objOItem_Type_PDF_Documents.Name = objOList_type_pdf_documents(0).Name_Other
            objOItem_Type_PDF_Documents.GUID_Parent = objOList_type_pdf_documents(0).ID_Parent_Other
            objOItem_Type_PDF_Documents.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_pflanzenarten = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_pflanzenarten" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_pflanzenarten.Count > 0 Then
            objOItem_Type_Pflanzenarten = New clsOntologyItem
            objOItem_Type_Pflanzenarten.GUID = objOList_type_pflanzenarten(0).ID_Other
            objOItem_Type_Pflanzenarten.Name = objOList_type_pflanzenarten(0).Name_Other
            objOItem_Type_Pflanzenarten.GUID_Parent = objOList_type_pflanzenarten(0).ID_Parent_Other
            objOItem_Type_Pflanzenarten.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_search_template = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_search_template" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_search_template.Count > 0 Then
            objOItem_Type_Search_Template = New clsOntologyItem
            objOItem_Type_Search_Template.GUID = objOList_type_search_template(0).ID_Other
            objOItem_Type_Search_Template.Name = objOList_type_search_template(0).Name_Other
            objOItem_Type_Search_Template.GUID_Parent = objOList_type_search_template(0).ID_Parent_Other
            objOItem_Type_Search_Template.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_tierarten = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_tierarten" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_tierarten.Count > 0 Then
            objOItem_Type_Tierarten = New clsOntologyItem
            objOItem_Type_Tierarten.GUID = objOList_type_tierarten(0).ID_Other
            objOItem_Type_Tierarten.Name = objOList_type_tierarten(0).Name_Other
            objOItem_Type_Tierarten.GUID_Parent = objOList_type_tierarten(0).ID_Parent_Other
            objOItem_Type_Tierarten.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_url = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_url" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_url.Count > 0 Then
            objOItem_Type_Url = New clsOntologyItem
            objOItem_Type_Url.GUID = objOList_type_url(0).ID_Other
            objOItem_Type_Url.Name = objOList_type_url(0).Name_Other
            objOItem_Type_Url.GUID_Parent = objOList_type_url(0).ID_Parent_Other
            objOItem_Type_Url.Type = objGlobals.Type_Class
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

        Dim objOList_type_wetterlage = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_wetterlage" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_wetterlage.Count > 0 Then
            objOItem_Type_Wetterlage = New clsOntologyItem
            objOItem_Type_Wetterlage.GUID = objOList_type_wetterlage(0).ID_Other
            objOItem_Type_Wetterlage.Name = objOList_type_wetterlage(0).Name_Other
            objOItem_Type_Wetterlage.GUID_Parent = objOList_type_wetterlage(0).ID_Parent_Other
            objOItem_Type_Wetterlage.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_wichtige_ereignisse = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_wichtige_ereignisse" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_wichtige_ereignisse.Count > 0 Then
            objOItem_Type_Wichtige_Ereignisse = New clsOntologyItem
            objOItem_Type_Wichtige_Ereignisse.GUID = objOList_type_wichtige_ereignisse(0).ID_Other
            objOItem_Type_Wichtige_Ereignisse.Name = objOList_type_wichtige_ereignisse(0).Name_Other
            objOItem_Type_Wichtige_Ereignisse.GUID_Parent = objOList_type_wichtige_ereignisse(0).ID_Parent_Other
            objOItem_Type_Wichtige_Ereignisse.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_year = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_year" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_year.Count > 0 Then
            objOItem_Type_Year = New clsOntologyItem
            objOItem_Type_Year.GUID = objOList_type_year(0).ID_Other
            objOItem_Type_Year.Name = objOList_type_year(0).Name_Other
            objOItem_Type_Year.GUID_Parent = objOList_type_year(0).ID_Parent_Other
            objOItem_Type_Year.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If


    End Sub
End Class

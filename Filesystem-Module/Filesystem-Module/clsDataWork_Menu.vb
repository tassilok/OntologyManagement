﻿Imports Ontology_Module
Imports OntologyClasses.BaseClasses

Public Class clsDataWork_Menu
    Private objLocalConfig As clsLocalConfig

    Private objDBLevel_FileRef As clsDBLevel
    Private objDBLevel_RelationTypes As clsDBLevel

    Private objFileWork As clsFileWork

    Private objOItem_Ref As clsOntologyItem

    Private objOItem_Direction As clsOntologyItem
    Private objOItem_RelationType As clsOntologyItem

    Public ReadOnly Property OItem_RelationType As clsOntologyItem
        Get
            Return objOItem_RelationType
        End Get
    End Property

    Public ReadOnly Property OItem_Direction As clsOntologyItem
        Get
            Return objOItem_Direction
        End Get
    End Property

    Public Property FileRelationList As List(Of clsRelatedFileSystemObject)

    Public Function GetOItem(GUID_Item As String, Type_Item As String) As clsOntologyItem
        Return objDBLevel_FileRef.GetOItem(GUID_Item, Type_Item)
    End Function

    Public Function GetData_References(OItem_Ref As clsOntologyItem) As clsOntologyItem
        objOItem_Ref = OItem_Ref
        Dim objOItem_Result As clsOntologyItem

        FileRelationList = New List(Of clsRelatedFileSystemObject)

        If Not objOItem_Ref.GUID_Parent = objLocalConfig.OItem_Type_File.GUID And _
            Not objOItem_Ref.GUID_Parent = objLocalConfig.OItem_type_Folder.GUID Then
            Dim searchRefs = New List(Of clsObjectRel) From {New clsObjectRel With {.ID_Object = objOItem_Ref.GUID,
                                                                                 .ID_Parent_Other = objLocalConfig.OItem_Type_File.GUID},
                                                         New clsObjectRel With {.ID_Object = objOItem_Ref.GUID,
                                                                                .ID_Parent_Other = objLocalConfig.OItem_type_Folder.GUID}}

            objOItem_Result = objDBLevel_FileRef.get_Data_ObjectRel(searchRefs, boolIDs:=False)

            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                FileRelationList.AddRange(objDBLevel_FileRef.OList_ObjectRel.Select(Function(frel) New clsRelatedFileSystemObject With {.ID_Related = frel.ID_Object,
                                                                                                                   .Name_Related = frel.Name_Object,
                                                                                                                   .ID_Parent_Related = frel.ID_Parent_Object,
                                                                                                                   .Name_Parent_Related = frel.Name_Parent_Object,
                                                                                                                   .Type_Related = objLocalConfig.Globals.Type_Object,
                                                                                                                   .ID_FileSystemObject = frel.ID_Other,
                                                                                                                   .Name_FileSystemObject = frel.Name_Other,
                                                                                                                   .ID_Parent_FileSystemObject = frel.ID_Parent_Other,
                                                                                                                   .Name_Parent_FileSystemObject = frel.Name_Parent_Other,
                                                                                                                   .ID_RelationType = frel.ID_RelationType,
                                                                                                                   .Name_RelationType = frel.Name_RelationType,
                                                                                                                   .OrderID = frel.OrderID,
                                                                                                                   .Path_FileSystemObject = objFileWork.get_Path_FileSystemObject(New clsOntologyItem With
                                                                                                                                                                                  {
                                                                                                                                                                                      .GUID = frel.ID_Other,
                                                                                                                                                                                      .Name = frel.Name_Other,
                                                                                                                                                                                      .GUID_Parent = frel.ID_Parent_Other,
                                                                                                                                                                                      .Type = frel.Ontology
                                                                                                                                                                                  }, False),
                                                                                                                                        .IsBlob = objFileWork.is_File_Blob(New clsOntologyItem With
                                                                                                                                                                                  {
                                                                                                                                                                                      .GUID = frel.ID_Other,
                                                                                                                                                                                      .Name = frel.Name_Other,
                                                                                                                                                                                      .GUID_Parent = frel.ID_Parent_Other,
                                                                                                                                                                                      .Type = frel.Ontology
                                                                                                                                                                                  })}))

                searchRefs = New List(Of clsObjectRel) From {New clsObjectRel With {.ID_Other = objOItem_Ref.GUID,
                                                                                     .ID_Parent_Object = objLocalConfig.OItem_Type_File.GUID},
                                                             New clsObjectRel With {.ID_Other = objOItem_Ref.GUID,
                                                                                     .ID_Parent_Object = objLocalConfig.OItem_type_Folder.GUID}}

                objOItem_Result = objDBLevel_FileRef.get_Data_ObjectRel(searchRefs, boolIDs:=False)

                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    FileRelationList.AddRange(objDBLevel_FileRef.OList_ObjectRel.Select(Function(frel) New clsRelatedFileSystemObject With {.ID_Related = frel.ID_Other,
                                                                                                                   .Name_Related = frel.Name_Other,
                                                                                                                   .ID_Parent_Related = frel.ID_Parent_Other,
                                                                                                                   .Name_Parent_Related = frel.Name_Parent_Other,
                                                                                                                   .Type_Related = frel.Ontology,
                                                                                                                   .ID_FileSystemObject = frel.ID_Object,
                                                                                                                   .Name_FileSystemObject = frel.Name_Object,
                                                                                                                   .ID_Parent_FileSystemObject = frel.ID_Parent_Object,
                                                                                                                   .Name_Parent_FileSystemObject = frel.Name_Parent_Object,
                                                                                                                   .ID_RelationType = frel.ID_RelationType,
                                                                                                                   .Name_RelationType = frel.Name_RelationType,
                                                                                                                   .OrderID = frel.OrderID,
                                                                                                                   .Path_FileSystemObject = objFileWork.get_Path_FileSystemObject(New clsOntologyItem With
                                                                                                                                                                                  {
                                                                                                                                                                                      .GUID = frel.ID_Object,
                                                                                                                                                                                      .Name = frel.Name_Object,
                                                                                                                                                                                      .GUID_Parent = frel.ID_Parent_Object,
                                                                                                                                                                                      .Type = objLocalConfig.Globals.Type_Object
                                                                                                                                                                                  }, False),
                                                                                                                                        .IsBlob = objFileWork.is_File_Blob(New clsOntologyItem With
                                                                                                                                                                                  {
                                                                                                                                                                                      .GUID = frel.ID_Object,
                                                                                                                                                                                      .Name = frel.Name_Object,
                                                                                                                                                                                      .GUID_Parent = frel.ID_Parent_Object,
                                                                                                                                                                                      .Type = objLocalConfig.Globals.Type_Object
                                                                                                                                                                                  })}))
                End If
            End If
        Else
            objOItem_Result = objLocalConfig.Globals.LState_Success.Clone()

            FileRelationList.Add(New clsRelatedFileSystemObject With {.ID_FileSystemObject = objOItem_Ref.GUID,
                                                                      .Name_FileSystemObject = objOItem_Ref.Name,
                                                                      .ID_Parent_FileSystemObject = objOItem_Ref.GUID_Parent,
                                                                      .Name_Parent_FileSystemObject = If(objOItem_Ref.GUID_Parent = objLocalConfig.OItem_Type_File.GUID, objLocalConfig.OItem_Type_File.Name, objLocalConfig.OItem_type_Folder.Name),
                                                                      .Path_FileSystemObject = objFileWork.get_Path_FileSystemObject(objOItem_Ref, False),
                                                                      .OrderID = 1,
                                                                      .IsBlob = objFileWork.is_File_Blob(objOItem_Ref)
                                     })
        End If
        


        Return objOItem_Result
    End Function

    Public Function GetRelationTypes(objOItem_Ref As clsOntologyItem) As clsOntologyItem
        Dim searchRelationTypes = New List(Of clsClassRel) From {New clsClassRel With {.ID_Class_Left = objOItem_Ref.GUID_Parent,
                                                                                       .ID_Class_Right = objLocalConfig.OItem_Type_File.GUID}}

        Dim result = objDBLevel_RelationTypes.get_Data_ClassRel(searchRelationTypes, boolIDs:=False)

        If result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            If Not objDBLevel_RelationTypes.OList_ClassRel.Any() Then
                searchRelationTypes = New List(Of clsClassRel) From {New clsClassRel With {.ID_Class_Right = objOItem_Ref.GUID_Parent,
                                                                                           .ID_Class_Left = objLocalConfig.OItem_Type_File.GUID}}

                result = objDBLevel_RelationTypes.get_Data_ClassRel(searchRelationTypes, boolIDs:=False)

                If result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    If objDBLevel_RelationTypes.OList_ClassRel.Any() Then
                        objOItem_RelationType = New clsOntologyItem With {.GUID = objDBLevel_RelationTypes.OList_ClassRel.First().ID_RelationType,
                                                                          .Name = objDBLevel_RelationTypes.OList_ClassRel.First().Name_RelationType,
                                                                          .Type = objLocalConfig.Globals.Type_RelationType}
                        objOItem_Direction = objLocalConfig.Globals.Direction_RightLeft
                    Else
                        objOItem_RelationType = objLocalConfig.OItem_RelationType_belongsTo.Clone()
                        objOItem_Direction = objLocalConfig.Globals.Direction_LeftRight
                    End If
                Else
                    objOItem_RelationType = Nothing
                End If

            Else
                objOItem_RelationType = New clsOntologyItem With {.GUID = objDBLevel_RelationTypes.OList_ClassRel.First().ID_RelationType,
                                                                  .Name = objDBLevel_RelationTypes.OList_ClassRel.First().Name_RelationType,
                                                                  .Type = objLocalConfig.Globals.Type_RelationType}
                objOItem_Direction = objLocalConfig.Globals.Direction_LeftRight
            End If
        Else
            objOItem_RelationType = Nothing
        End If
        

        Return result
    End Function

    Public Sub New(LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig

        Initialize()
    End Sub

    Private Sub Initialize()
        objDBLevel_FileRef = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_RelationTypes = New clsDBLevel(objLocalConfig.Globals)
        objFileWork = New clsFileWork(objLocalConfig)
    End Sub
End Class

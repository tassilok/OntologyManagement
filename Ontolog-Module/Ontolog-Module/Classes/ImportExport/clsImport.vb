Imports OntologyClasses.BaseClasses
Imports OntologyClasses.DataClasses
Imports System.Text
Imports System.Xml
Imports System.IO
Public Class clsImport
    Private objGlobals As clsGlobals

    Private objDataTypes As clsDataTypes

    Private objDBLevel_TestExistance As clsDBLevel

    Private objXMLReader As XmlTextReader

    Private strPath_Templates As String

    Public Function ImportTemplates() As clsOntologyItem
        Dim objOItem_Result = objGlobals.LState_Success
        Dim objOList_OItems As New List(Of clsOntologyItem)
        Dim objOList_ClassAtts As New List(Of clsClassAtt)
        Dim objOList_ClassRel As New List(Of clsClassRel)
        Dim objOList_ObjAtt As New List(Of clsObjectAtt)
        Dim objOList_ObjRel As New List(Of clsObjectRel)

        For Each strFile In IO.Directory.GetFiles(strPath_Templates)
            If strFile.ToLower().EndsWith(".xml") Then
                Dim strType As String
                


                objXMLReader = New XmlTextReader(strFile)
                objXMLReader.ReadToDescendant("Items")
                If objXMLReader.LocalName = "Items" Then
                    strType = objXMLReader.GetAttribute("Type")
                    If strType <> "" Then
                        While objXMLReader.ReadToFollowing("Item")

                            Select Case strType
                                Case objGlobals.Type_AttributeType
                                    Dim ID = objXMLReader.GetAttribute("Id")
                                    Dim ID_Parent = objXMLReader.GetAttribute("Id_Parent")
                                    objXMLReader.Read()
                                    Dim Name = objXMLReader.Value
                                    Dim objOItem_Item = New clsOntologyItem With {.GUID = ID, _
                                                                                  .Name = Name, _
                                                                                  .GUID_Parent = ID_Parent, _
                                                                                  .Type = objGlobals.Type_AttributeType}

                                    objOItem_Result = objDBLevel_TestExistance.save_AttributeType(objOItem_Item)
                                    If objOItem_Result.GUID = objGlobals.LState_Error.GUID Then
                                        Exit While
                                    End If

                                Case objGlobals.Type_Class
                                    Dim ID = objXMLReader.GetAttribute("Id")
                                    Dim ID_Parent = objXMLReader.GetAttribute("Id_Parent")
                                    objXMLReader.Read()
                                    Dim Name = objXMLReader.Value
                                    Dim objOItem_Item = New clsOntologyItem With {.GUID = ID, _
                                                                                  .Name = Name, _
                                                                                  .GUID_Parent = If(ID_Parent = "", Nothing, ID_Parent), _
                                                                                  .Type = objGlobals.Type_Class}

                                    objOItem_Result = objDBLevel_TestExistance.save_Class(objOItem_Item, If(ID_Parent = "", True, False))
                                    If objOItem_Result.GUID = objGlobals.LState_Error.GUID Then
                                        Exit While
                                    End If
                                Case objGlobals.Type_Object
                                    Dim ID = objXMLReader.GetAttribute("Id")
                                    Dim ID_Parent = objXMLReader.GetAttribute("Id_Parent")
                                    objXMLReader.Read()
                                    Dim Name = objXMLReader.Value

                                    objOList_OItems.Add(New clsOntologyItem With {.GUID = ID, _
                                                                                  .Name = Name, _
                                                                                  .GUID_Parent = ID_Parent, _
                                                                                  .Type = objGlobals.Type_Object})

                                Case objGlobals.Type_RelationType
                                    Dim ID = objXMLReader.GetAttribute("Id")
                                    Dim ID_Parent = objXMLReader.GetAttribute("Id_Parent")
                                    objXMLReader.Read()
                                    Dim Name = objXMLReader.Value
                                    Dim objOItem_Item = New clsOntologyItem With {.GUID = ID, _
                                                                                  .Name = Name, _
                                                                                  .GUID_Parent = ID_Parent, _
                                                                                  .Type = objGlobals.Type_RelationType}

                                    objOItem_Result = objDBLevel_TestExistance.save_RelationType(objOItem_Item)
                                    If objOItem_Result.GUID = objGlobals.LState_Error.GUID Then
                                        Exit While
                                    End If
                                Case objGlobals.Type_ClassAtt
                                    Dim ID_AttributeType = objXMLReader.GetAttribute("Id_AttributeType")
                                    Dim ID_Class = objXMLReader.GetAttribute("Id_Class")
                                    Dim ID_DataType = objXMLReader.GetAttribute("Id_DataType")
                                    Dim Min = Integer.Parse(objXMLReader.GetAttribute("Min"))
                                    Dim Max = Integer.Parse(objXMLReader.GetAttribute("Max"))

                                    objXMLReader.Read()
                                    Dim Name = objXMLReader.Value

                                    objOList_ClassAtts.Add(New clsClassAtt With {.ID_AttributeType = ID_AttributeType, _
                                                                                 .ID_Class = ID_Class, _
                                                                                 .ID_DataType = ID_DataType, _
                                                                                 .Min = Min, _
                                                                                 .Max = Max})

                                Case objGlobals.Type_ClassRel
                                    Dim ID_Class_Left = objXMLReader.GetAttribute("Id_Class_Left")
                                    Dim ID_Class_Right = objXMLReader.GetAttribute("Id_Class_Right")
                                    Dim ID_RelationType = objXMLReader.GetAttribute("Id_RelationType")
                                    Dim Min_Forw = Long.Parse(objXMLReader.GetAttribute("Min_Forw"))
                                    Dim Max_Forw = Long.Parse(objXMLReader.GetAttribute("Max_Forw"))
                                    Dim Max_Backw = Long.Parse(objXMLReader.GetAttribute("Max_Backw"))
                                    Dim Ontology = objXMLReader.GetAttribute("Ontology")

                                    objXMLReader.Read()
                                    Dim Name = objXMLReader.Value

                                    objOList_ClassRel.Add(New clsClassRel With {.ID_Class_Left = ID_Class_Left, _
                                                                                 .ID_Class_Right = ID_Class_Right, _
                                                                                 .ID_RelationType = ID_RelationType, _
                                                                                 .Min_Forw = Min_Forw, _
                                                                                 .Max_Forw = Max_Forw, _
                                                                                .Max_Backw = Max_Backw, _
                                                                                .Ontology = Ontology})

                                Case objGlobals.Type_ObjectAtt
                                    Dim Id_Attribute = objXMLReader.GetAttribute("Id_Attribute")
                                    Dim Id_AttributeType = objXMLReader.GetAttribute("Id_AttributeType")
                                    Dim Id_DataType = objXMLReader.GetAttribute("Id_DataType")
                                    Dim Id_Object = objXMLReader.GetAttribute("Id_Object")
                                    Dim Id_Class = objXMLReader.GetAttribute("Id_Class")
                                    Dim OrderId = objXMLReader.GetAttribute("OrderId")
                                    Dim Val_Named = objXMLReader.GetAttribute("Val_Named")
                                    Dim Val_Bit As Nullable(Of Boolean) = Boolean.Parse(If(objXMLReader.GetAttribute("Val_Bit") = "", Nothing, objXMLReader.GetAttribute("Val_Bit")))
                                    Dim Val_Date As Nullable(Of DateTime) = DateTime.Parse(If(objXMLReader.GetAttribute("Val_Date") = "", Nothing, objXMLReader.GetAttribute("Val_Date")))
                                    Dim Val_Double As Nullable(Of Double) = Double.Parse(If(objXMLReader.GetAttribute("Val_Double") = "", Nothing, objXMLReader.GetAttribute("Val_Double")))
                                    Dim Val_Lng As Nullable(Of Long) = Long.Parse(If(objXMLReader.GetAttribute("Val_Lng") = "", Nothing, objXMLReader.GetAttribute("Val_Lng")))
                                    Dim Val_String = objXMLReader.GetAttribute("Val_String")

                                    objOList_ObjAtt.Add(New clsObjectAtt With {.ID_Attribute = Id_Attribute, _
                                                                               .ID_AttributeType = Id_AttributeType, _
                                                                               .ID_DataType = Id_DataType, _
                                                                               .ID_Object = Id_Object, _
                                                                               .ID_Class = Id_Class, _
                                                                               .OrderID = OrderId, _
                                                                               .Val_Named = Val_Named, _
                                                                               .Val_Bit = Val_Bit, _
                                                                               .Val_Date = Val_Date, _
                                                                               .Val_Double = Val_Double, _
                                                                               .Val_Lng = Val_Lng, _
                                                                               .Val_String = Val_String})


                                Case objGlobals.Type_ObjectRel
                                    Dim Id_Object = objXMLReader.GetAttribute("Id_Object")
                                    Dim Id_Parent_Object = objXMLReader.GetAttribute("Id_Parent_Object")
                                    Dim Id_Other = objXMLReader.GetAttribute("Id_Other")
                                    Dim Id_Parent_Other = objXMLReader.GetAttribute("Id_Parent_Other")
                                    Dim Id_RelationType = objXMLReader.GetAttribute("Id_RelationType")
                                    Dim OrderId = Long.Parse(objXMLReader.GetAttribute("OrderId"))
                                    Dim Ontology = objXMLReader.GetAttribute("Ontology")

                                    objOList_ObjRel.Add(New clsObjectRel With {.ID_Object = Id_Object, _
                                                                               .ID_Parent_Object = Id_Parent_Object, _
                                                                               .ID_Other = Id_Other, _
                                                                               .ID_Parent_Other = Id_Parent_Other, _
                                                                               .ID_RelationType = Id_RelationType, _
                                                                               .OrderID = OrderId, _
                                                                               .Ontology = Ontology})

                            End Select
                        End While

                        
                    End If
                End If
                objXMLReader.Close()
            End If
        Next
        If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then
            If objOList_OItems.Any Then
                objOItem_Result = objDBLevel_TestExistance.save_Objects(objOList_OItems)
            End If

            If objOList_ClassAtts.Any Then
                objOItem_Result = objDBLevel_TestExistance.save_ClassAttType(objOList_ClassAtts)
            End If

            If objOList_ClassRel.Any Then
                objOItem_Result = objDBLevel_TestExistance.save_ClassRel(objOList_ClassRel)
            End If

            If objOList_ObjAtt.Any Then
                objOItem_Result = objDBLevel_TestExistance.save_ObjAtt(objOList_ObjAtt)
            End If

            If objOList_ObjRel.Any Then
                objOItem_Result = objDBLevel_TestExistance.save_ObjRel(objOList_ObjRel)
            End If
        End If
        Return objOItem_Result
    End Function

    Public Sub New(Globals As clsGlobals)

        objGlobals = Globals
        initialize()
    End Sub


    Private Sub initialize()
        strPath_Templates = "Config" & IO.Path.DirectorySeparatorChar & "Templates"
        objDBLevel_TestExistance = New clsDBLevel(objGlobals)

    End Sub
End Class


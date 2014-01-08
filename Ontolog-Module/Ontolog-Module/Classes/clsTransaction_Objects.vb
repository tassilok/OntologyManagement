Imports OntologyClasses.BaseClasses

Public Class clsTransaction_Objects
    Private objLocalConfig As clsLocalConfig

    Private objDBLevel As clsDBLevel

    Private objFrm_Name As frm_Name
    Private objOItem_Saved_LastItem As clsOntologyItem

    Private objfrmParent As Windows.Forms.IWin32Window

    Private objTransaction As clsTransaction

    Dim oList_Objects As New List(Of clsOntologyItem)
    Dim oList_ObjectDbl As New List(Of clsOntologyItem)

    Dim boolApply As Boolean

    Public ReadOnly Property Apply As Boolean
        Get
            Return boolApply
        End Get
    End Property
    Public ReadOnly Property NameObjects As List(Of clsOntologyItem)
        Get
            If Not oList_Objects Is Nothing Then
                If oList_Objects.Any Then
                    Return oList_Objects

                End If
            End If

            If Not oList_ObjectDbl Is Nothing Then
                If oList_ObjectDbl.Any Then
                    Return oList_ObjectDbl
                End If
            End If

        End Get
    End Property

    Public ReadOnly Property OItem_SavedLast As clsOntologyItem
        Get
            Return objOItem_Saved_LastItem
        End Get
    End Property

    Public Function duplicate_Object(OItem_Object As clsOntologyItem) As clsOntologyItem
        Dim objOItem_Result = objLocalConfig.Globals.LState_Nothing.Clone()

        objFrm_Name = New frm_Name("New Object", objLocalConfig, Nothing, Nothing, Nothing, True, True, False, False, True)
        objFrm_Name.ShowDialog(objfrmParent)
        If objFrm_Name.DialogResult = DialogResult.OK Then

            Dim strName = objFrm_Name.Value1

            If strName <> "" Then
                Dim objOItem_New = New clsOntologyItem With {.GUID = objLocalConfig.Globals.NewGUID, _
                                                             .Name = strName, _
                                                             .GUID_Parent = OItem_Object.GUID_Parent, _
                                                             .Type = objLocalConfig.Globals.Type_Object
                                                            }

                objOItem_Result = save_Object(objOItem_New.GUID_Parent, objOItem_New)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    Dim objORel_Object_To_Right = Rel_Object_To_Right(OItem_Object)
                    Dim objOList_Object_To_Right = New List(Of clsObjectRel)
                    objOList_Object_To_Right.Add(objORel_Object_To_Right)
                    objOItem_Result = objDBLevel.get_Data_ObjectRel(objOList_Object_To_Right, boolIDs:=False)
                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        Dim objOList_RelNew = objDBLevel.OList_ObjectRel.Select(Function(p) New clsObjectRel With {.ID_Object = objOItem_New.GUID, _
                                                                                                                   .ID_Parent_Object = objOItem_New.GUID_Parent, _
                                                                                                                   .ID_Other = p.ID_Other, _
                                                                                                                   .ID_Parent_Other = p.ID_Parent_Other, _
                                                                                                                   .ID_RelationType = p.ID_RelationType, _
                                                                                                                   .Ontology = p.Ontology, _
                                                                                                                   .OrderID = p.OrderID}).ToList()

                        For Each objORel_ObjectToRel In objOList_RelNew
                            objOItem_Result = objTransaction.do_Transaction(objORel_ObjectToRel)
                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                                MsgBox("Das Objekt konnte nicht erzeugt werden!", MsgBoxStyle.Exclamation)
                                objTransaction.rollback()
                                Exit For
                            End If
                        Next

                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                            Dim objORel_Left_To_Object = Rel_Left_To_Object(OItem_Object)
                            Dim objOList_Left_To_Object = New List(Of clsObjectRel)
                            objOList_Left_To_Object.Add(objORel_Left_To_Object)
                            objOItem_Result = objDBLevel.get_Data_ObjectRel(objOList_Left_To_Object, boolIDs:=False)
                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                'objOList_RelNew = objDBLevel.OList_ObjectRel.Select(Function(p) New clsObjectRel With {.ID_Object = p.ID_Object, _
                                '                                                                                   .ID_Parent_Object = p.ID_Parent_Object, _
                                '                                                                                   .ID_Other = objOItem_New.GUID, _
                                '                                                                                   .ID_Parent_Other = objOItem_New.GUID_Parent, _
                                '                                                                                   .ID_RelationType = p.ID_RelationType, _
                                '                                                                                   .Ontology = p.Ontology, _
                                '                                                                                   .OrderID = p.OrderID}).ToList()

                                'For Each objORel_ObjectToRel In objOList_RelNew
                                '    objOItem_Result = objTransaction.do_Transaction(objORel_ObjectToRel)
                                '    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                                '        MsgBox("Das Objekt konnte nicht erzeugt werden!", MsgBoxStyle.Exclamation)
                                '        objTransaction.rollback()
                                '        Exit For
                                '    End If
                                'Next

                                'If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                Dim objOAtt_OItem_To_Att = Rel_Object_To_AttributeType(OItem_Object)
                                Dim objOList_Object_To_Att = New List(Of clsObjectAtt)
                                objOList_Object_To_Att.Add(objOAtt_OItem_To_Att)
                                objOItem_Result = objDBLevel.get_Data_ObjectAtt(objOList_Object_To_Att, boolIDs:=False)
                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                    Dim objOList_ObjectToAttNew = objDBLevel.OList_ObjectAtt.Select(Function(p) New clsObjectAtt With {.ID_Attribute = Nothing, _
                                                                                                                                       .ID_AttributeType = p.ID_AttributeType, _
                                                                                                                                       .ID_Class = p.ID_Class, _
                                                                                                                                       .ID_Object = p.ID_Object, _
                                                                                                                                       .ID_DataType = p.ID_DataType, _
                                                                                                                                       .Val_Named = p.Val_Named, _
                                                                                                                                       .Val_Bit = p.Val_Bit, _
                                                                                                                                       .Val_Date = p.Val_Date, _
                                                                                                                                       .Val_Double = p.Val_Double, _
                                                                                                                                       .Val_Lng = p.Val_Lng, _
                                                                                                                                       .Val_String = p.Val_String})

                                    For Each objOAtt_ObjectToAtt In objOList_ObjectToAttNew
                                        objOItem_Result = objTransaction.do_Transaction(objOAtt_ObjectToAtt)
                                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                                            MsgBox("Das Objekt konnte nicht erzeugt werden!", MsgBoxStyle.Exclamation)
                                            objTransaction.rollback()
                                            Exit For
                                        End If
                                    Next

                                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                        objOItem_Saved_LastItem = objOItem_New
                                    End If
                                End If

                                'End If
                            End If

                        End If
                    Else
                        objTransaction.ClearItems()
                        objTransaction.do_Transaction(objOItem_New, False, True)
                        MsgBox("Das Objekt konnte nicht erzeugt werden!", MsgBoxStyle.Exclamation)
                    End If
                End If
            Else
                MsgBox("Bitte einen gültigen Namen eingeben!", MsgBoxStyle.Information)
                objOItem_Result = objLocalConfig.Globals.LState_Nothing
            End If
        End If

        Return objOItem_Result
    End Function

    Public Function save_Object(ByVal strClass As String, Optional ByVal objOItem_Object As clsOntologyItem = Nothing) As clsOntologyItem
        
        Dim strGUID As String
        Dim objOItem_Result As clsOntologyItem
        Dim strValue As String
        Dim boolSave As Boolean
        Dim boolOrderID As Boolean
        Dim intOrderID_Start As Integer

        objOItem_Saved_LastItem = Nothing

        If objOItem_Object Is Nothing Then
            objFrm_Name = New frm_Name("New Object", objLocalConfig, Nothing, Nothing, Nothing, True, True, False, False, True)
            objFrm_Name.ShowDialog(objfrmParent)
            If objFrm_Name.DialogResult = DialogResult.OK Then
                boolApply = objFrm_Name.doApply
                boolOrderID = objFrm_Name.OrderID
                intOrderID_Start = objFrm_Name.OrderID_Start

                If objFrm_Name.isList = True Then
                    For Each strValue In objFrm_Name.Values
                        strValue = strValue.Replace(vbLf, "")
                        strValue = strValue.Replace(vbCr, "")

                        oList_Objects.Add(New clsOntologyItem With {.GUID = Guid.NewGuid.ToString.Replace("-", ""), _
                                                              .Name = strValue, _
                                                              .GUID_Parent = strClass, _
                                                              .Type = objLocalConfig.Globals.Type_Object, _
                                                              .Level = intOrderID_Start, _
                                                              .Mark = boolOrderID})
                        intOrderID_Start = intOrderID_Start + 1
                    Next
                Else

                    strValue = objFrm_Name.Value1

                    If objFrm_Name.TextBox_GUID.Text = "" Then
                        strGUID = Guid.NewGuid.ToString.Replace("-", "")
                    Else
                        strGUID = objFrm_Name.TextBox_GUID.Text
                    End If
                    oList_Objects.Add(New clsOntologyItem With {.GUID = strGUID, _
                                                          .Name = strValue, _
                                                          .GUID_Parent = strClass, _
                                                          .Type = objLocalConfig.Globals.Type_Object, _
                                                          .Level = intOrderID_Start, _
                                                          .Mark = boolOrderID})
                    oList_ObjectDbl.Add(New clsOntologyItem With {.Name = strValue, _
                                                            .GUID_Parent = strClass, _
                                                            .Type = objLocalConfig.Globals.Type_Object, _
                                                            .Level = intOrderID_Start, _
                                                            .Mark = boolOrderID})
                End If
                If objFrm_Name.More = True Then

                End If
            End If
        Else
            oList_Objects.Add(objOItem_Object)
            oList_ObjectDbl.Add(objOItem_Object)
        End If

        boolSave = True

        objOItem_Result = objLocalConfig.Globals.LState_Nothing
        If oList_ObjectDbl.Count > 0 Then
            objDBLevel.get_Data_Objects(oList_ObjectDbl)
            If objDBLevel.OList_Objects.Count > 0 Then
                Dim oL_Double = From obj_db In objDBLevel.OList_Objects
                                Join obj_new In oList_Objects On obj_db.Name.ToLower Equals obj_new.Name.ToLower

                If oL_Double.Count > 0 Then
                    If MsgBox("Es existiert bereits Objekt(e) mit dem Namen. Wollen Sie weitere anlegen?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        boolSave = False
                    End If
                End If

            End If
            

        End If

        If boolSave = True Then
            objOItem_Result = objDBLevel.save_Objects(oList_Objects)
            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                objOItem_Saved_LastItem = oList_Objects.Last
            End If
        End If
        Return objOItem_Result
    End Function

    Public Function Rel_Object_To_Right(OItem_Object As clsOntologyItem) As clsObjectRel
        Dim objORel_Object_To_Rel = New clsObjectRel With {.ID_Object = OItem_Object.GUID}

        Return objORel_Object_To_Rel
    End Function

    Public Function Rel_Left_To_Object(OItem_Object As clsOntologyItem) As clsObjectRel
        Dim objORel_Rel_To_Object = New clsObjectRel With {.ID_Other = OItem_Object.GUID}

        Return objORel_Rel_To_Object
    End Function

    Public Function Rel_Object_To_AttributeType(OItem_Object As clsOntologyItem) As clsObjectAtt
        Dim objOAtt_Object_To_AttType = New clsObjectAtt With {.ID_Object = OItem_Object.GUID}

        Return objOAtt_Object_To_AttType
    End Function

    Public Sub New(ByVal LocalConfig As clsLocalConfig, Optional ByVal frmParent As Windows.Forms.IWin32Window = Nothing)
        objLocalConfig = LocalConfig
        objfrmParent = frmParent

        set_DBConnection()
    End Sub

    Private Sub set_DBConnection()
        objDBLevel = New clsDBLevel(objLocalConfig.Globals)
        objTransaction = New clsTransaction(objLocalConfig.Globals)
    End Sub
End Class

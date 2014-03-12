Imports OntologyClasses.BaseClasses

Public Class UserControl_OItemList
    Private objLocalConfig As clsLocalConfig

    Private otblT_Objects As New DataSet_Config.otbl_ObjectsDataTable

    Private objDBLevel As clsDBLevel
    Private objOntologyClipboard As clsOntologyClipboard

    Private objFrm_Main As frmMain
    Private objFrm_ObjectEdit As frm_ObjectEdit
    Private objFrm_AttributeTypeEdit As frm_AttributeTypeEdit
    Private objFrm_Clipboard As frmClipboard
    Private objFrm_Replace As frmReplace

    Private objTransaction_Objects As clsTransaction_Objects
    Private objTransaction_RelationTypes As clsTransaction_RelationTypes
    Private objTransaction_AttributeTypes As clsTransaction_AttributeTypes
    Private objTransaction As clsTransaction
    Private objRelationConfig As clsRelationConfig

    Private objOItem_Parent As clsOntologyItem

    Private objOItem_Class As New clsOntologyItem
    Private objOItem_RelationType As clsOntologyItem
    Private objOItem_Other As clsOntologyItem
    Private objOItem_Object As clsOntologyItem

    Private objOItem_Class_AdvancedFilter As clsOntologyItem
    Private objOItem_RelationType_AdvancedFilter As clsOntologyItem
    Private objOItem_Object_AdvancedFilter As clsOntologyItem
    Private objOItem_Direction_AdvancedFilter As clsOntologyItem


    Private objThread_List As Threading.Thread

    Private boolProgChange As Boolean

    Private strRowName_GUID As String
    Private strRowName_Name As String
    Private strRowName_ParentGUID As String
    Private strGUID_Class As String

    Private objOItem_Direction As clsOntologyItem

    Private oList_Selected_Simple As New List(Of clsOntologyItem)
    Private oList_Selected_ObjectRel As New List(Of clsObjectRel)

    Private objFrmAdvancedFilter As frmAdvancedFilter

    Private objDlg_Attribute_Boolean As dlg_Attribute_Boolean
    Private objDlg_Attribute_DateTime As dlg_Attribute_DateTime
    Private objDlg_Attribute_Long As dlg_Attribute_Long
    Private objDlg_Attribute_Double As dlg_Attribute_Double
    Private objDlg_Attribute_String As dlg_Attribute_String

    Private boolOR As Boolean

    Private strName_Filter As String
    Private strGUID_Filter As String

    Private intRowID As Integer

    Private boolFinished As Boolean
    Private boolApplyable As Boolean

    Private strType As String

    Private strFilter_Extern As String

    Private Event selected_ListItem()

    Public Event Selection_Changed()
    Public Event edit_Object(ByVal strType As String, ByVal oItem_Direction As clsOntologyItem)

    Public Event applied_Items()
    Public Event counted_Items(ByVal intCount As Integer)

    Public ReadOnly Property SelectedRowIndex As Long
        Get
            If DataGridView_Items.SelectedRows.Count > 0 Then
                Return DataGridView_Items.SelectedRows(0).Index
            Else
                Return -1
            End If
        End Get
    End Property

    Public ReadOnly Property ColumnList As DataGridViewColumnCollection
        Get
            Return DataGridView_Items.Columns
        End Get
    End Property

    Public ReadOnly Property RowName_GUID As String
        Get
            Return strRowName_GUID
        End Get
    End Property

    Public ReadOnly Property RowName_Name As String
        Get
            Return strRowName_Name
        End Get
    End Property

    Public ReadOnly Property RowName_GUIDParent As String
        Get
            Return strRowName_ParentGUID
        End Get
    End Property

    Public ReadOnly Property OList_Simple As List(Of clsOntologyItem)
        Get
            Return oList_Selected_Simple
        End Get
    End Property

    Public ReadOnly Property OList_ObjectRel As List(Of clsObjectRel)
        Get
            Return oList_Selected_ObjectRel
        End Get
    End Property

    Public Property Applyable As Boolean
        Get
            Return boolApplyable
        End Get
        Set(ByVal value As Boolean)
            boolApplyable = value
        End Set
    End Property

    Public ReadOnly Property RowID As Integer
        Get
            Return intRowID
        End Get
    End Property

    Public ReadOnly Property DataGridviewRows As DataGridViewRowCollection
        Get
            Return DataGridView_Items.Rows
        End Get
    End Property

    Public ReadOnly Property DataGridViewRowCollection_Selected As DataGridViewSelectedRowCollection
        Get
            Return DataGridView_Items.SelectedRows
        End Get
    End Property

    Public sub select_Row(OItem_Item As clsOntologyItem)
        Dim BindingSource_Grid As BindingSource =  DataGridView_Items.DataSource

        If not BindingSource_Grid Is Nothing Then
            Dim intRowID = BindingSource_Grid.Find(strRowName_GUID, OItem_Item.GUID)
            If intRowID >-1 Then
                BindingSource_Grid.Position = intRowID
                If Not DataGridView_Items.CurrentRow Is Nothing Then
                    DataGridView_Items.CurrentRow.Selected = True
                End If
            End If

        End If
    End Sub

    Public Sub select_Row(index As Long)
        Dim BindingSource_Grid As BindingSource = DataGridView_Items.DataSource

        If Not BindingSource_Grid Is Nothing Then
            If index > -1 Then
                DataGridView_Items.Rows(index).Selected = True
                BindingSource_Grid.Position = index
            End If

        End If
    End Sub

    Public Sub initialize(ByVal OItem_Parent As clsOntologyItem, Optional ByVal oItem_Object As clsOntologyItem = Nothing, Optional ByVal OItem_Direction As clsOntologyItem = Nothing, Optional ByVal OItem_Other As clsOntologyItem = Nothing, Optional ByVal OItem_RelType As clsOntologyItem = Nothing, Optional ByVal boolOR As Boolean = False, optional strFilter As String = Nothing)
        boolProgChange = True

        Me.boolOR = boolOR
        clear_Relation()
        strGUID_Class = Nothing

        
        strGUID_Filter = ""
        strName_Filter = ""

        If Not strFilter Is Nothing Then
            If objLocalConfig.Globals.is_GUID(strFilter) Then
                strGUID_Filter = strFilter
            Else 
                strName_Filter = strFilter
            End If    
         

        End If
        
        objOItem_Class_AdvancedFilter = Nothing
        objOItem_RelationType_AdvancedFilter = Nothing
        objOItem_Object_AdvancedFilter = Nothing

        ToolStripTextBox_Filter.ReadOnly = True
        ToolStripTextBox_Filter.Text = ""
        ToolStripButton_Filter.Checked = False
        ToolStripTextBox_Filter.ReadOnly = False
        BindingSource_Attribute.RemoveFilter()
        BindingSource_RelationType.RemoveFilter()
        BindingSource_Token.RemoveFilter()
        BindingSource_TokenToken.RemoveFilter()
        BindingSource_Type.RemoveFilter()

        If OItem_Direction Is Nothing Then
            If Not oItem_Object Is Nothing Then
                If oItem_Object.GUID <> "" Then
                    strGUID_Filter = oItem_Object.GUID
                ElseIf oItem_Object.Name <> "" Then
                    strGUID_Filter = oItem_Object.Name
                End If
            End If
            objOItem_Other = OItem_Other

            
            objOItem_Object = oItem_Object


            objOItem_RelationType = OItem_RelType
            objOItem_Parent = OItem_Parent


            If objOItem_Parent Is Nothing Then
                strType = OItem_Other.Type
            Else
                strType = objOItem_Parent.Type
            End If



        Else

            strType = objLocalConfig.Globals.Type_Other
            objOItem_Direction = OItem_Direction
            If objOItem_Direction.GUID = objLocalConfig.Globals.Direction_LeftRight.GUID Then
                If Not oItem_Object Is Nothing Then
                    If oItem_Object.GUID <> "" Then
                        strGUID_Filter = oItem_Object.GUID
                    ElseIf oItem_Object.Name <> "" Then
                        strGUID_Filter = oItem_Object.Name
                    End If
                End If
                objOItem_Object = oItem_Object
                objOItem_Other = OItem_Other

                objOItem_RelationType = OItem_RelType
                objOItem_Parent = OItem_Parent
            Else
                If Not OItem_Other Is Nothing Then
                    strGUID_Class = OItem_Other.GUID_Parent
                End If
                If Not oItem_Object Is Nothing Then
                    objOItem_Other = oItem_Object

                End If

                objOItem_Parent = OItem_Parent
                objOItem_RelationType = OItem_RelType
            End If

        End If


        ToolStripButton_AddItem.Visible = True
        ToolStripButton_DelItem.Visible = True
        ToolStripButton_Up.Visible = False
        ToolStripButton_Down.Visible = False
        ToolStripButton_Sort.Visible = True
        ToolStripButton_Report.Visible = True
        ToolStripTextBox_Filter.ReadOnly = True
        ToolStripTextBox_Filter.Text = ""
        ToolStripTextBox_Filter.ReadOnly = False

        get_RowNames()
        configure_TabPages()

        boolProgChange = False
    End Sub

    Private Sub get_RowNames()
        Select Case strType
            Case objLocalConfig.Globals.Type_AttributeType
                strRowName_GUID = "ID_Item"
                strRowName_Name = "Name"
                strRowName_ParentGUID = "ID_Parent"
            Case objLocalConfig.Globals.Type_Class
                strRowName_GUID = "ID_Item"
                strRowName_Name = "Name"
                strRowName_ParentGUID = "ID_Parent"
            Case objLocalConfig.Globals.Type_Object
                strRowName_GUID = "ID_Item"
                strRowName_Name = "Name"
                strRowName_ParentGUID = "ID_Parent"
            Case objLocalConfig.Globals.Type_RelationType
                strRowName_GUID = "ID_Item"
                strRowName_Name = "Name"
                strRowName_ParentGUID = ""
            Case objLocalConfig.Globals.Type_Other
                Select Case objOItem_Direction.GUID
                    Case objLocalConfig.Globals.Direction_LeftRight.GUID
                        strRowName_GUID = "ID_Other"
                        strRowName_Name = "Name_Other"
                        strRowName_ParentGUID = "ID_Parent_Other"
                    Case objLocalConfig.Globals.Direction_RightLeft.GUID
                        strRowName_GUID = "ID_Object"
                        strRowName_Name = "Name_Object"
                        strRowName_ParentGUID = "ID_Parent_Object"
                End Select
        End Select
    End Sub

    Private Sub get_Data()
        Dim oList_Items As New List(Of clsOntologyItem)
        Dim oList_ObjRel As New List(Of clsObjectRel)
        Dim oList_ObjAtt As New List(Of clsObjectAtt)
        Dim objOItem_Item As clsOntologyItem

        

        If Not objOItem_Parent Is Nothing Then
            If objOItem_Parent.Type = objLocalConfig.Globals.Type_Object Then
                strGUID_Class = objOItem_Parent.GUID_Parent
            Else
                strGUID_Class = objOItem_Parent.GUID
            End If
            If boolOR = False Then
                Select Case objOItem_Parent.Type
                    Case objLocalConfig.Globals.Type_Object
    
                        If Not objOItem_RelationType_AdvancedFilter is Nothing or Not objOItem_Class_AdvancedFilter Is nothing Or Not objOItem_Object_AdvancedFilter Is Nothing Then
                            Dim objORel_AdvancedFilter = New List(Of clsObjectRel)
                            If objOItem_Direction_AdvancedFilter.GUID = objLocalConfig.Globals.Direction_LeftRight.GUID
                                objORel_AdVancedFilter = new List(Of clsObjectRel) From { new clsObjectRel With {.ID_Parent_Object = strGUID_Class, _
                                                                                                                 .ID_RelationType = If (Not objOItem_RelationType_AdvancedFilter Is Nothing, objOItem_RelationType_AdvancedFilter.GUID, Nothing), _
                                                                                                                 .ID_Parent_Other = If (Not objOItem_Class_AdvancedFilter Is Nothing, objOItem_Class_AdvancedFilter.GUID, Nothing), _
                                                                                                                 .ID_Other = if (not objOItem_Object_AdvancedFilter Is Nothing, objOItem_Object_AdvancedFilter.GUID, Nothing) }}
                                objDBLevel.get_Data_ObjectRel(objORel_AdvancedFilter,boolIDs := False, boolTable := True,boolTable_Objects_Left := True)
                            Else 
                                objORel_AdVancedFilter = new List(Of clsObjectRel) From { new clsObjectRel With {.ID_Parent_Other = strGUID_Class, _
                                                                                                                 .ID_RelationType = If (Not objOItem_RelationType_AdvancedFilter Is Nothing, objOItem_RelationType_AdvancedFilter.GUID, Nothing), _
                                                                                                                 .ID_Parent_Object = If (Not objOItem_Class_AdvancedFilter Is Nothing, objOItem_Class_AdvancedFilter.GUID, Nothing), _
                                                                                                                 .ID_Object = if (not objOItem_Object_AdvancedFilter Is Nothing, objOItem_Object_AdvancedFilter.GUID, Nothing) }}
                                objDBLevel.get_Data_ObjectRel(objORel_AdvancedFilter,boolIDs := False, boolTable := True,boolTable_Objects_Right := True)
                            End If

                            
                            
                        Else 
                            oList_Items.Add(New clsOntologyItem(strGUID_Filter, strName_Filter, strGUID_Class, objLocalConfig.Globals.Type_Object))
                            objDBLevel.get_Data_Objects(oList_Items, True)
                        End If
                        
                        
                        
                        'objDBLevel.get_Data_Objects(oList_Items)



                    Case objLocalConfig.Globals.Type_RelationType
                        oList_Items.Add(New clsOntologyItem(strGUID_Filter, strName_Filter, objLocalConfig.Globals.Type_RelationType))
                        objDBLevel.get_Data_RelationTypes(oList_Items, True)

                    Case objLocalConfig.Globals.Type_AttributeType
                        oList_Items.Add(New clsOntologyItem(strGUID_Filter, strName_Filter, objLocalConfig.Globals.Type_AttributeType))
                        objDBLevel.get_Data_AttributeType(oList_Items, True)

                End Select
            Else

            End If


        Else
            If Not objOItem_Other Is Nothing Then
                Select Case objOItem_Other.Type



                    Case objLocalConfig.Globals.Type_RelationType
                        oList_Items.Add(New clsOntologyItem(strGUID_Filter, strName_Filter, objLocalConfig.Globals.Type_RelationType))
                        objDBLevel.get_Data_RelationTypes(oList_Items, True)

                    Case objLocalConfig.Globals.Type_AttributeType

                        oList_ObjAtt.Add(New clsObjectAtt(Nothing, objOItem_Object.GUID, Nothing, objOItem_Other.GUID, Nothing))
                        objDBLevel.get_Data_ObjectAtt(oList_ObjAtt, True, False)

                    Case Else

                        oList_ObjRel.Add(New clsObjectRel(strGUID_Filter, _
                                                          strName_Filter, _
                                                          strGUID_Class, _
                                                          Nothing, _
                                                          objOItem_Other.GUID, _
                                                          objOItem_Other.Name, _
                                                          objOItem_Other.GUID_Parent, _
                                                          Nothing, _
                                                          objOItem_RelationType.GUID, _
                                                          Nothing, _
                                                          objLocalConfig.Globals.Type_Object, _
                                                          Nothing, _
                                                          Nothing, _
                                                          Nothing))


                        objDBLevel.get_Data_ObjectRel(oList_ObjRel, True, False)
                End Select
            Else
                If Not objOItem_Object Is Nothing Then
                    If Not objOItem_Object.GUID_Parent Is Nothing Then
                        strGUID_Class = objOItem_Object.GUID_Parent
                    End If
                End If
                'For Each objOItem_Item In oList_Items
                '    oList_ObjRel.Add(New clsObjectRel(objOItem_Item.GUID, _
                '                                      objOItem_Item.Name, _
                '                                      objOItem_Item.GUID_Parent, _
                '                                      Nothing, _
                '                                      strGUID_Filter, _
                '                                      strName_Filter, _
                '                                      strGUID_Class, _
                '                                      Nothing, _
                '                                      objOItem_RelationType.GUID, _
                '                                      Nothing, _
                '                                      objLocalConfig.Globals.Type_Object, _
                '                                      Nothing, _
                '                                      Nothing, _
                '                                      Nothing))


                'Next
                oList_ObjRel.Add(New clsObjectRel(strGUID_Filter, _
                                                      strName_Filter, _
                                                      strGUID_Class, _
                                                      Nothing, _
                                                      Nothing, _
                                                      Nothing, _
                                                      Nothing, _
                                                      Nothing, _
                                                      objOItem_RelationType.GUID, _
                                                      Nothing, _
                                                      Nothing, _
                                                      objLocalConfig.Globals.Direction_LeftRight.GUID, _
                                                      Nothing, _
                                                      Nothing))
                objDBLevel.get_Data_ObjectRel(oList_ObjRel, True, False)


            End If
            

        End If
        boolFinished = True
    End Sub

    Private Sub configure_TabPages()
        ToolStripButton_FilterAdvanced.Enabled = False
        Timer_List.Stop()
        Timer_Filter.Stop()
        Select Case TabControl1.SelectedTab.Name
            Case TabPage_List.Name
                Try
                    objThread_List.Abort()
                Catch ex As Exception

                End Try
                BindingSource_Attribute.DataSource = Nothing
                BindingSource_RelationType.DataSource = Nothing
                BindingSource_Token.DataSource = Nothing
                BindingSource_Type.DataSource = Nothing

                DataGridView_Items.DataSource = Nothing

                boolFinished = False
                objThread_List = New Threading.Thread(AddressOf get_Data)

                
                objThread_List.Start()
                Timer_List.Start

            Case TabPage_Tree.Name
                If Not objOItem_Parent Is Nothing Then
                    'objUserControl_TreeOfToken.initialize(objSemItem_Parent)
                End If
        End Select

    End Sub

    Public Sub clear_Relation()
        Try
            objThread_List.Abort()
            Timer_Filter.Stop()
            Timer_List.Stop()
        Catch ex As Exception

        End Try
        objOItem_Other = Nothing
        objOItem_RelationType = Nothing
        objOItem_Direction = Nothing
        strGUID_Filter = Nothing
        strName_Filter = Nothing
        ToolStripButton_Relate.Checked = False
        ToolStripButton_Relate.Enabled = False
        ToolStripTextBox_Filter.ReadOnly = True
        ToolStripTextBox_Filter.Clear()
        ToolStripTextBox_Filter.ReadOnly = False

        DataGridView_Items.DataSource = Nothing

    End Sub

    
    Public Sub New(ByVal Globals As clsGlobals)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        objLocalConfig = New clsLocalConfig(Globals)
        set_DBConnection()
    End Sub

    Public Sub New(ByVal LocalConfig As clsLocalConfig)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        objLocalConfig = LocalConfig
        set_DBConnection()
    End Sub

    Private Sub set_DBConnection()
        objDBLevel = New clsDBLevel(objLocalConfig.Globals)
        objTransaction_Objects = New clsTransaction_Objects(objLocalConfig, Me)
        objTransaction_AttributeTypes = New clsTransaction_AttributeTypes(objLocalConfig, Me)
        objTransaction_RelationTypes = New clsTransaction_RelationTypes(objLocalConfig, Me)
        objTransaction = New clsTransaction(objLocalConfig.Globals)
        objOntologyClipboard = New clsOntologyClipboard(objLocalConfig)
        objRelationConfig = New clsRelationConfig(objLocalConfig.Globals)
    End Sub

    Private Sub DataGridView_Items_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView_Items.CellDoubleClick
        Dim objDGVR_Selected As DataGridViewRow
        Dim objDRV_Selected As DataRowView
        Dim objOList_Relation As New List(Of clsObjectRel)
        Dim objOLIst_Att As New List(Of clsObjectAtt)
        Dim objOItem_Result As clsOntologyItem
        Dim objColumn As DataGridViewTextBoxColumn
        Dim boolRel As Boolean = False
        Dim boolChange As Boolean = False

        If Not e.ColumnIndex = -1 Then
            If DataGridView_Items.Columns(e.ColumnIndex).DataPropertyName.ToLower = "orderid" Then
                objDGVR_Selected = DataGridView_Items.Rows(e.RowIndex)
                objDRV_Selected = objDGVR_Selected.DataBoundItem

                objDlg_Attribute_Long = New dlg_Attribute_Long("New OrderID", objLocalConfig.Globals, objDRV_Selected.Item("OrderID"))
                objDlg_Attribute_Long.ShowDialog(Me)

                If objDlg_Attribute_Long.DialogResult = DialogResult.OK Then
                    For Each objColumn In DataGridView_Items.Columns
                        If objColumn.DataPropertyName.ToLower = "id_other" Then
                            boolRel = True
                            boolChange = True
                            Exit For
                        End If

                        If objColumn.DataPropertyName.ToLower = "id_attribute" Then

                            boolRel = False
                            boolChange = True
                            Exit For
                        End If
                    Next

                    If boolChange = True Then
                        If boolRel = True Then
                            objOList_Relation.Add(New clsObjectRel(objDRV_Selected.Item("ID_Object"), _
                                                                   objDRV_Selected.Item("ID_Parent_Object"), _
                                                                   objDRV_Selected.Item("ID_Other"), _
                                                                   objDRV_Selected.Item("ID_Parent_Other"), _
                                                                   objDRV_Selected.Item("ID_RelationType"), _
                                                                   objDRV_Selected.Item("Ontology"), _
                                                                   Nothing, _
                                                                   objDlg_Attribute_Long.Value))

                            objOItem_Result = objDBLevel.save_ObjRel(objOList_Relation)
                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                                MsgBox("Die Gewichtung konnte nicht geändert werden!", MsgBoxStyle.Exclamation)
                            End If

                            get_Data()
                        Else
                            Select Case objDRV_Selected.Item("ID_DataType")
                                Case objLocalConfig.Globals.DType_Bool.GUID
                                    objOLIst_Att.Add(New clsObjectAtt With {.ID_Attribute = objDRV_Selected.Item("ID_Attribute"), _
                                                                      .ID_Object = objDRV_Selected.Item("ID_Object"), _
                                                                      .ID_Class = objDRV_Selected.Item("ID_Class"), _
                                                                      .ID_AttributeType = objDRV_Selected.Item("ID_AttributeType"), _
                                                                      .OrderID = objDlg_Attribute_Long.Value, _
                                                                      .Val_Named = objDRV_Selected.Item("val_named"), _
                                                                      .Val_Bit = objDRV_Selected.Item("val_bit"), _
                                                                      .ID_DataType = objDRV_Selected.Item("ID_DataType")})

                                    objOItem_Result = objDBLevel.save_ObjAtt(objOLIst_Att)
                                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                                        MsgBox("Die Gewichtung konnte nicht geändert werden!", MsgBoxStyle.Exclamation)
                                    End If

                                    get_Data()
                                Case objLocalConfig.Globals.DType_DateTime.GUID
                                    objOLIst_Att.Add(New clsObjectAtt(objDRV_Selected.Item("ID_Attribute"), _
                                                                      objDRV_Selected.Item("ID_Object"), _
                                                                      Nothing, _
                                                                      objDRV_Selected.Item("ID_Class"), _
                                                                      Nothing, _
                                                                      objDRV_Selected.Item("ID_AttributeType"), _
                                                                      Nothing, _
                                                                      objDlg_Attribute_Long.Value, _
                                                                      objDRV_Selected.Item("val_named"), _
                                                                      Nothing, _
                                                                      objDRV_Selected.Item("val_datetime"), _
                                                                      Nothing, _
                                                                      Nothing, _
                                                                      Nothing, _
                                                                      objDRV_Selected.Item("ID_DataType")))

                                    objOItem_Result = objDBLevel.save_ObjAtt(objOLIst_Att)
                                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                                        MsgBox("Die Gewichtung konnte nicht geändert werden!", MsgBoxStyle.Exclamation)
                                    End If

                                    get_Data()
                                Case objLocalConfig.Globals.DType_Int.GUID
                                    objOLIst_Att.Add(New clsObjectAtt(objDRV_Selected.Item("ID_Attribute"), _
                                                                      objDRV_Selected.Item("ID_Object"), _
                                                                      Nothing, _
                                                                      objDRV_Selected.Item("ID_Class"), _
                                                                      Nothing, _
                                                                      objDRV_Selected.Item("ID_AttributeType"), _
                                                                      Nothing, _
                                                                      objDlg_Attribute_Long.Value, _
                                                                      objDRV_Selected.Item("val_named"), _
                                                                      Nothing, _
                                                                      Nothing, _
                                                                      objDRV_Selected.Item("val_int"), _
                                                                      Nothing, _
                                                                      Nothing, _
                                                                      objDRV_Selected.Item("ID_DataType")))

                                    objOItem_Result = objDBLevel.save_ObjAtt(objOLIst_Att)
                                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                                        MsgBox("Die Gewichtung konnte nicht geändert werden!", MsgBoxStyle.Exclamation)
                                    End If

                                    get_Data()
                                Case objLocalConfig.Globals.DType_Real.GUID
                                    objOLIst_Att.Add(New clsObjectAtt(objDRV_Selected.Item("ID_Attribute"), _
                                                                      objDRV_Selected.Item("ID_Object"), _
                                                                      Nothing, _
                                                                      objDRV_Selected.Item("ID_Class"), _
                                                                      Nothing, _
                                                                      objDRV_Selected.Item("ID_AttributeType"), _
                                                                      Nothing, _
                                                                      objDlg_Attribute_Long.Value, _
                                                                      objDRV_Selected.Item("val_named"), _
                                                                      Nothing, _
                                                                      Nothing, _
                                                                      Nothing, _
                                                                      objDRV_Selected.Item("val_real"), _
                                                                      Nothing, _
                                                                      objDRV_Selected.Item("ID_DataType")))

                                    objOItem_Result = objDBLevel.save_ObjAtt(objOLIst_Att)
                                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                                        MsgBox("Die Gewichtung konnte nicht geändert werden!", MsgBoxStyle.Exclamation)
                                    End If

                                    get_Data()
                                Case objLocalConfig.Globals.DType_String.GUID
                                    objOLIst_Att.Add(New clsObjectAtt(objDRV_Selected.Item("ID_Attribute"), _
                                                                      objDRV_Selected.Item("ID_Object"), _
                                                                      Nothing, _
                                                                      objDRV_Selected.Item("ID_Class"), _
                                                                      Nothing, _
                                                                      objDRV_Selected.Item("ID_AttributeType"), _
                                                                      Nothing, _
                                                                      objDlg_Attribute_Long.Value, _
                                                                      objDRV_Selected.Item("val_named"), _
                                                                      Nothing, _
                                                                      Nothing, _
                                                                      Nothing, _
                                                                      Nothing, _
                                                                      objDRV_Selected.Item("val_string"), _
                                                                      objDRV_Selected.Item("ID_DataType")))

                                    objOItem_Result = objDBLevel.save_ObjAtt(objOLIst_Att)
                                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                                        MsgBox("Die Gewichtung konnte nicht geändert werden!", MsgBoxStyle.Exclamation)
                                    End If

                                    get_Data()
                            End Select

                        End If
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub DataGridView_Items_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridView_Items.KeyDown
        If e.KeyCode = Keys.F5 Then
            get_Data()
            Timer_List.Start()
        End If
    End Sub

    Private Sub DataGridView_Items_RowHeaderMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView_Items.RowHeaderMouseDoubleClick



        Dim objDGVR_Selected As DataGridViewRow
        Dim objDRV_Selected As DataRowView
        Dim objOItem_Selected As New clsOntologyItem
        Dim objOLObjects As New List(Of clsOntologyItem)
        Dim objOAItem_Value As New clsObjectAtt
        Dim objOItem_Result As clsOntologyItem

        objDGVR_Selected = DataGridView_Items.Rows(e.RowIndex)
        objDRV_Selected = objDGVR_Selected.DataBoundItem
        objOItem_Selected.GUID = objDRV_Selected.Item(strRowName_GUID)



        If Not objOItem_Parent Is Nothing Then
            objOItem_Selected.Name = objDRV_Selected.Item(strRowName_Name)
            If strRowName_ParentGUID <> "" Then
                objOItem_Selected.GUID_Parent = objDRV_Selected.Item(strRowName_ParentGUID)
            End If
            Select Case strType
                Case objLocalConfig.Globals.Type_AttributeType
                    objFrm_AttributeTypeEdit = New frm_AttributeTypeEdit(objLocalConfig, objOItem_Selected)
                    objFrm_AttributeTypeEdit.ShowDialog(Me)
                    MsgBox("Implement: AttributeTye-Edit")
                Case objLocalConfig.Globals.Type_Class
                    MsgBox("Implement: Class-Edit")
                Case objLocalConfig.Globals.Type_RelationType
                    MsgBox("Implement: RelationType-Edit")
                Case objLocalConfig.Globals.Type_Object
                    intRowID = objDGVR_Selected.Index

                    'objOLObjects.Add(objOItem_Selected)
                    If (objFrm_ObjectEdit Is Nothing) Then
                        objFrm_ObjectEdit = New frm_ObjectEdit(objLocalConfig, _
                                                               DataGridView_Items.Rows, _
                                                               intRowID, _
                                                               objLocalConfig.Globals.Type_Object, _
                                                               Nothing)    
                    Else
                        objFrm_ObjectEdit.RefreshForm(DataGridView_Items.Rows, _
                                                               intRowID, _
                                                               objLocalConfig.Globals.Type_Object, _
                                                               Nothing)
                    End If
                    
                    objFrm_ObjectEdit.ShowDialog(Me)
                    get_Data()
                    Timer_List.Start()

            End Select
        Else
            'strOntology = objDRV_Selected.Item("Ontology")
            Select Case strType
                Case objLocalConfig.Globals.Type_AttributeType

                    Select Case objDRV_Selected.Item("ID_DataType")
                        Case objLocalConfig.Globals.DType_Bool.GUID
                            objDlg_Attribute_Boolean = New dlg_Attribute_Boolean(objDRV_Selected.Item("Name_Object") + ": " + objDRV_Selected.Item("Name_DataType"), objLocalConfig.Globals, objDRV_Selected.Item("Val_Bit"))
                            objDlg_Attribute_Boolean.ShowDialog(Me)

                            If objDlg_Attribute_Boolean.DialogResult = DialogResult.OK Then
                                objOAItem_Value = New clsObjectAtt
                                objOAItem_Value.ID_Attribute = objDRV_Selected.Item("ID_ObjectAttribute")
                                objOAItem_Value.ID_AttributeType = objDRV_Selected.Item("ID_AttributeType")
                                objOAItem_Value.ID_Class = objDRV_Selected.Item("ID_Class")
                                objOAItem_Value.ID_Object = objDRV_Selected.Item("ID_Object")
                                objOAItem_Value.Val_Named = objDlg_Attribute_Boolean.Value
                                objOAItem_Value.Val_Bit = objDlg_Attribute_Boolean.Value
                                objOAItem_Value.OrderID = objDRV_Selected.Item("OrderID")
                                objOAItem_Value.ID_DataType = objDRV_Selected.Item("ID_DataType")

                                objTransaction.ClearItems()

                                objOItem_Result = objTransaction.do_Transaction(objOAItem_Value)
                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                                    MsgBox("Das Attribute konnte nicht gesetzt werden!", MsgBoxStyle.Exclamation)

                                Else
                                    get_Data()
                                End If
                            End If
                        Case objLocalConfig.Globals.DType_DateTime.GUID
                            objDlg_Attribute_DateTime = New dlg_Attribute_DateTime(objDRV_Selected.Item("Name_Object") + ": " + objDRV_Selected.Item("Name_DataType"), objLocalConfig.Globals, objDRV_Selected.Item("Val_DateTime"))
                            objDlg_Attribute_DateTime.ShowDialog(Me)

                            If objDlg_Attribute_DateTime.DialogResult = DialogResult.OK Then
                                objOAItem_Value = New clsObjectAtt
                                objOAItem_Value.ID_Attribute = objDRV_Selected.Item("ID_ObjectAttribute")
                                objOAItem_Value.ID_AttributeType = objDRV_Selected.Item("ID_AttributeType")
                                objOAItem_Value.ID_Class = objDRV_Selected.Item("ID_Class")
                                objOAItem_Value.ID_Object = objDRV_Selected.Item("ID_Object")
                                objOAItem_Value.Val_Named = objDlg_Attribute_DateTime.Value
                                objOAItem_Value.Val_Date = objDlg_Attribute_DateTime.Value
                                objOAItem_Value.OrderID = objDRV_Selected.Item("OrderID")
                                objOAItem_Value.ID_DataType = objDRV_Selected.Item("ID_DataType")

                                objTransaction.ClearItems()

                                objOItem_Result = objTransaction.do_Transaction(objOAItem_Value)
                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                                    MsgBox("Das Attribute konnte nicht gesetzt werden!", MsgBoxStyle.Exclamation)

                                Else
                                    get_Data()
                                End If
                            End If
                        Case objLocalConfig.Globals.DType_Int.GUID
                            objDlg_Attribute_Long = New dlg_Attribute_Long(objDRV_Selected.Item("Name_Object") + ": " + objDRV_Selected.Item("Name_DataType"), objLocalConfig.Globals, objDRV_Selected.Item("Val_Int"))
                            objDlg_Attribute_Long.ShowDialog(Me)

                            If objDlg_Attribute_Long.DialogResult = DialogResult.OK Then
                                objOAItem_Value = New clsObjectAtt
                                objOAItem_Value.ID_Attribute = objDRV_Selected.Item("ID_ObjectAttribute")
                                objOAItem_Value.ID_AttributeType = objDRV_Selected.Item("ID_AttributeType")
                                objOAItem_Value.ID_Class = objDRV_Selected.Item("ID_Class")
                                objOAItem_Value.ID_Object = objDRV_Selected.Item("ID_Object")
                                objOAItem_Value.Val_Named = objDlg_Attribute_Long.Value
                                objOAItem_Value.Val_Lng = objDlg_Attribute_Long.Value
                                objOAItem_Value.OrderID = objDRV_Selected.Item("OrderID")
                                objOAItem_Value.ID_DataType = objDRV_Selected.Item("ID_DataType")

                                objTransaction.ClearItems()

                                objOItem_Result = objTransaction.do_Transaction(objOAItem_Value)
                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                                    MsgBox("Das Attribute konnte nicht gesetzt werden!", MsgBoxStyle.Exclamation)

                                Else
                                    get_Data()
                                End If
                            End If
                        Case objLocalConfig.Globals.DType_Real.GUID
                            objDlg_Attribute_Double = New dlg_Attribute_Double(objDRV_Selected.Item("Name_Object") + ": " + objDRV_Selected.Item("Name_DataType"), objLocalConfig.Globals, objDRV_Selected.Item("Val_Real"))
                            objDlg_Attribute_Double.ShowDialog(Me)

                            If objDlg_Attribute_Double.DialogResult = DialogResult.OK Then
                                objOAItem_Value = New clsObjectAtt
                                objOAItem_Value.ID_Attribute = objDRV_Selected.Item("ID_ObjectAttribute")
                                objOAItem_Value.ID_AttributeType = objDRV_Selected.Item("ID_AttributeType")
                                objOAItem_Value.ID_Class = objDRV_Selected.Item("ID_Class")
                                objOAItem_Value.ID_Object = objDRV_Selected.Item("ID_Object")
                                objOAItem_Value.Val_Named = objDlg_Attribute_Double.Value
                                objOAItem_Value.Val_Double = objDlg_Attribute_Double.Value
                                objOAItem_Value.OrderID = objDRV_Selected.Item("OrderID")
                                objOAItem_Value.ID_DataType = objDRV_Selected.Item("ID_DataType")

                                objTransaction.ClearItems()

                                objOItem_Result = objTransaction.do_Transaction(objOAItem_Value)
                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                                    MsgBox("Das Attribute konnte nicht gesetzt werden!", MsgBoxStyle.Exclamation)

                                Else
                                    get_Data()
                                End If
                            End If
                        Case objLocalConfig.Globals.DType_String.GUID
                            objDlg_Attribute_String = New dlg_Attribute_String(objDRV_Selected.Item("Name_Object") + ": " + objDRV_Selected.Item("Name_DataType"), objLocalConfig.Globals, objDRV_Selected.Item("Val_String"))
                            objDlg_Attribute_String.ShowDialog(Me)

                            If objDlg_Attribute_String.DialogResult = DialogResult.OK Then
                                objOAItem_Value = New clsObjectAtt
                                objOAItem_Value.ID_Attribute = objDRV_Selected.Item("ID_ObjectAttribute")
                                objOAItem_Value.ID_AttributeType = objDRV_Selected.Item("ID_AttributeType")
                                objOAItem_Value.ID_Class = objDRV_Selected.Item("ID_Class")
                                objOAItem_Value.ID_Object = objDRV_Selected.Item("ID_Object")
                                objOAItem_Value.Val_Named = objDlg_Attribute_String.Value
                                objOAItem_Value.Val_String = objDlg_Attribute_String.Value
                                objOAItem_Value.OrderID = objDRV_Selected.Item("OrderID")
                                objOAItem_Value.ID_DataType = objDRV_Selected.Item("ID_DataType")

                                objTransaction.ClearItems()

                                objOItem_Result = objTransaction.do_Transaction(objOAItem_Value)
                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                                    MsgBox("Das Attribute konnte nicht gesetzt werden!", MsgBoxStyle.Exclamation)

                                Else
                                    get_Data()
                                End If
                            End If
                    End Select
                Case objLocalConfig.Globals.Type_Class
                    MsgBox("Implement: Class-Edit")
                Case objLocalConfig.Globals.Type_RelationType
                    MsgBox("Implement: RelationType-Edit")
                Case objLocalConfig.Globals.Type_Object
                    objOLObjects.Add(objOItem_Selected)
                    If (objFrm_ObjectEdit is Nothing) Then
                        objFrm_ObjectEdit = New frm_ObjectEdit(objLocalConfig, _
                                                           objOLObjects, _
                                                           0, _
                                                           objLocalConfig.Globals.Type_Object, _
                                                           Nothing)
                    Else
                        objFrm_ObjectEdit.RefreshForm(objOLObjects, _
                                                           0, _
                                                           objLocalConfig.Globals.Type_Object, _
                                                           Nothing)

                    End If
                    
                    objFrm_ObjectEdit.ShowDialog(Me)
                    If objFrm_ObjectEdit.DialogResult = DialogResult.OK Then

                    End If
                Case objLocalConfig.Globals.Type_Other
                    Select Case objDRV_Selected.Item("Ontology")
                        Case objLocalConfig.Globals.Type_Object
                            If objOItem_Direction.GUID = objLocalConfig.Globals.Direction_LeftRight.GUID Then
                                objOLObjects.Add(New clsOntologyItem(objDRV_Selected.Item("ID_Other"), _
                                                                 objDRV_Selected.Item("Name_Other"), _
                                                                 objDRV_Selected.Item("ID_Parent_Other"), _
                                                                 objDRV_Selected.Item("Ontology")))
                            Else
                                objOLObjects.Add(New clsOntologyItem(objDRV_Selected.Item("ID_Object"), _
                                                                 objDRV_Selected.Item("Name_Object"), _
                                                                 objDRV_Selected.Item("ID_Parent_Object"), _
                                                                 objLocalConfig.Globals.Type_Object))
                            End If


                            If objFrm_ObjectEdit Is Nothing Then
                                objFrm_ObjectEdit = New frm_ObjectEdit(objLocalConfig, _
                                                           objOLObjects, _
                                                           0, _
                                                           objLocalConfig.Globals.Type_Object, _
                                                           Nothing)
                            Else
                                objFrm_ObjectEdit.RefreshForm(objOLObjects, _
                                                           0, _
                                                           objLocalConfig.Globals.Type_Object, _
                                                           Nothing)
                            End If
                            
                            objFrm_ObjectEdit.ShowDialog(Me)
                            If objFrm_ObjectEdit.DialogResult = DialogResult.OK Then

                            End If
                    End Select
            End Select
        End If

    End Sub

    Private Sub DataGridView_Items_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView_Items.SelectionChanged
        Dim objDGVR As DataGridViewRow
        Dim objDRV As DataRowView

        ToolStripButton_Replace.Enabled = False
        If DataGridView_Items.SelectedRows.Count = 1 Then

            objDGVR = DataGridView_Items.SelectedRows(0)
            objDRV = objDGVR.DataBoundItem
            ToolStripTextBox_GUID.Text = objDRV.Item(strRowName_GUID).ToString

        Else
            ToolStripTextBox_GUID.Clear()
        End If

        If DataGridView_Items.SelectedRows.Count > 0 And strType = objLocalConfig.Globals.Type_Object then
            ToolStripButton_Replace.Enabled = True
        End If
        If boolProgChange = False Then
            RaiseEvent Selection_Changed()
        End If
    End Sub

    Private Sub ToolStripTextBox_Filter_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripTextBox_Filter.TextChanged
        If ToolStripTextBox_Filter.ReadOnly = False Then
            Timer_List.Stop()
            Timer_Filter.Stop()
            ToolStripButton_Filter.Checked = True
            Timer_Filter.Start()
        End If
    End Sub

    Private Sub Timer_Filter_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_Filter.Tick
        Timer_Filter.Stop()
        Timer_List.Stop()
        Filter_List()
    End Sub

    Public Sub Filter_Items(ByVal strFilter As String)
        strFilter_Extern = strFilter
        ToolStripTextBox_Filter.Text = strFilter

    End Sub

    Private Sub Filter_List()
        strGUID_Filter = ""
        strName_Filter = ""
        BindingSource_Attribute.RemoveFilter()
        BindingSource_RelationType.RemoveFilter()
        BindingSource_Token.RemoveFilter()
        BindingSource_TokenToken.RemoveFilter()
        BindingSource_Type.RemoveFilter()


        If ToolStripButton_Filter.Checked = True Then
            strName_Filter = ToolStripTextBox_Filter.Text
            If objLocalConfig.Globals.is_GUID(strName_Filter) Then
                strGUID_Filter = strName_Filter
                strName_Filter = ""
            End If
        End If

        If strFilter_Extern = "" Then
            configure_TabPages()
        Else

            Select Case strType
                Case objLocalConfig.Globals.Type_AttributeType
                    If strGUID_Filter <> "" Then
                        BindingSource_Attribute.Filter = "[" & strRowName_GUID & "]='" & strGUID_Filter & "'"
                    ElseIf strName_Filter <> "" Then
                        BindingSource_Attribute.Filter = "[" & strRowName_Name & "]='" & strName_Filter & "'"
                    Else
                        BindingSource_Attribute.RemoveFilter()
                    End If
                Case objLocalConfig.Globals.Type_Class
                    If strGUID_Filter <> "" Then
                        BindingSource_Type.Filter = "[" & strRowName_GUID & "]='" & strGUID_Filter & "'"
                    ElseIf strName_Filter <> "" Then
                        BindingSource_Type.Filter = "[" & strRowName_Name & "]='" & strName_Filter & "'"
                    Else
                        BindingSource_Type.RemoveFilter()
                    End If
                Case objLocalConfig.Globals.Type_RelationType
                    If strGUID_Filter <> "" Then
                        BindingSource_RelationType.Filter = "[" & strRowName_GUID & "]='" & strGUID_Filter & "'"
                    ElseIf strName_Filter <> "" Then
                        BindingSource_RelationType.Filter = "[" & strRowName_Name & "]='" & strName_Filter & "'"
                    Else
                        BindingSource_RelationType.RemoveFilter()
                    End If
                Case objLocalConfig.Globals.Type_Object
                    If strGUID_Filter <> "" Then
                        BindingSource_Token.Filter = "[" & strRowName_GUID & "]='" & strGUID_Filter & "'"
                    ElseIf strName_Filter <> "" Then
                        BindingSource_Token.Filter = "[" & strRowName_Name & "]='" & strName_Filter & "'"
                    Else
                        BindingSource_Token.RemoveFilter()
                    End If
                Case objLocalConfig.Globals.Type_Other
                    If strGUID_Filter <> "" Then
                        BindingSource_TokenToken.Filter = "[" & strRowName_GUID & "]='" & strGUID_Filter & "'"
                    ElseIf strName_Filter <> "" Then
                        BindingSource_TokenToken.Filter = "[" & strRowName_Name & "]='" & strName_Filter & "'"
                    Else
                        BindingSource_TokenToken.RemoveFilter()
                    End If
            End Select
        End If


    End Sub

    Private Sub ToolStripButton_Filter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_Filter.Click
        If ToolStripButton_Filter.Checked = True Then
            ToolStripButton_Filter.Checked = False
            ToolStripTextBox_Filter.ReadOnly = True
            ToolStripTextBox_Filter.Text = ""
            ToolStripTextBox_Filter.ReadOnly = False
            Filter_List()
        Else
            ToolStripButton_Filter.Checked = True
            If strFilter_Extern <> "" Then
                ToolStripTextBox_Filter.ReadOnly = True
                ToolStripTextBox_Filter.Text = strFilter_Extern
                ToolStripTextBox_Filter.ReadOnly = False
            End If
            Filter_List()
        End If

    End Sub

    Private Sub Timer_List_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_List.Tick

        If boolFinished = True Then
            Timer_List.Stop()
            If Not objOItem_Parent Is Nothing Then
                Select Case objOItem_Parent.Type
                    Case objLocalConfig.Globals.Type_Object
                        ToolStripButton_FilterAdvanced.Enabled = True
                        BindingSource_Token.DataSource = objDBLevel.tbl_Objects
                        DataGridView_Items.DataSource = BindingSource_Token
                        DataGridView_Items.Columns(0).Visible = False
                        DataGridView_Items.Columns(2).Visible = False
                        DataGridView_Items.Columns(1).Width = DataGridView_Items.Width - 20
                        ToolStripLabel_Count.Text = DataGridView_Items.RowCount
                        strRowName_GUID = "ID_Item"
                    Case objLocalConfig.Globals.Type_RelationType


                        BindingSource_RelationType.DataSource = objDBLevel.tbl_RelationTypes
                        DataGridView_Items.DataSource = BindingSource_RelationType
                        DataGridView_Items.Columns(0).Visible = False
                        DataGridView_Items.Columns(1).Width = DataGridView_Items.Width - 20
                        ToolStripLabel_Count.Text = DataGridView_Items.RowCount
                        strRowName_GUID = "ID_Item"
                    Case objLocalConfig.Globals.Type_AttributeType


                        BindingSource_Attribute.DataSource = objDBLevel.tbl_AttributeTypes
                        DataGridView_Items.DataSource = BindingSource_Attribute
                        DataGridView_Items.Columns(0).Visible = False
                        DataGridView_Items.Columns(1).Width = DataGridView_Items.Width - 20
                        ToolStripLabel_Count.Text = DataGridView_Items.RowCount
                        strRowName_GUID = "ID_Item"
                End Select


            Else
                BindingSource_TokenToken.DataSource = objDBLevel.tbl_ObjectRelation
                DataGridView_Items.DataSource = BindingSource_TokenToken
                Select Case strType
                    Case objLocalConfig.Globals.Type_Object

                        BindingSource_Token.DataSource = objDBLevel.tbl_Objects
                        DataGridView_Items.DataSource = BindingSource_Token
                        DataGridView_Items.Columns(0).Visible = False
                        DataGridView_Items.Columns(2).Visible = False
                        DataGridView_Items.Columns(1).Width = DataGridView_Items.Width - 20
                        ToolStripLabel_Count.Text = DataGridView_Items.RowCount
                        strRowName_GUID = "ID_Item"
                    Case objLocalConfig.Globals.Type_RelationType


                        BindingSource_RelationType.DataSource = objDBLevel.tbl_RelationTypes
                        DataGridView_Items.DataSource = BindingSource_RelationType
                        DataGridView_Items.Columns(0).Visible = False
                        DataGridView_Items.Columns(1).Width = DataGridView_Items.Width - 20
                        ToolStripLabel_Count.Text = DataGridView_Items.RowCount
                        strRowName_GUID = "ID_Item"
                    Case objLocalConfig.Globals.Type_AttributeType

                        BindingSource_Attribute.DataSource = objDBLevel.tbl_ObjectAttribute
                        DataGridView_Items.DataSource = BindingSource_Attribute
                        DataGridView_Items.Columns(0).Visible = False
                        DataGridView_Items.Columns(1).Visible = False
                        DataGridView_Items.Columns(2).Visible = False
                        DataGridView_Items.Columns(3).Visible = False
                        DataGridView_Items.Columns(4).Visible = False
                        DataGridView_Items.Columns(5).Visible = False
                        DataGridView_Items.Columns(6).Visible = False
                        DataGridView_Items.Columns(9).Visible = False
                        DataGridView_Items.Columns(10).Visible = False
                        DataGridView_Items.Columns(11).Visible = False
                        DataGridView_Items.Columns(12).Visible = False
                        DataGridView_Items.Columns(13).Visible = False
                        DataGridView_Items.Columns(14).Visible = False
                        DataGridView_Items.Columns(15).Visible = False

                        ToolStripLabel_Count.Text = DataGridView_Items.RowCount
                        strRowName_GUID = "ID_ObjectAttribute"
                    Case objLocalConfig.Globals.Type_Other
                        If objOItem_Direction.GUID = objLocalConfig.Globals.Direction_LeftRight.GUID Then
                            DataGridView_Items.Columns(0).Visible = False
                            DataGridView_Items.Columns(1).Visible = False
                            DataGridView_Items.Columns(2).Visible = False
                            DataGridView_Items.Columns(3).Visible = False
                            DataGridView_Items.Columns(4).Visible = False
                            DataGridView_Items.Columns(5).Visible = False
                            DataGridView_Items.Columns(7).Visible = False
                            DataGridView_Items.Columns(9).Visible = False
                            DataGridView_Items.Columns(10).Visible = False
                            DataGridView_Items.Columns(11).Visible = False
                        Else
                            DataGridView_Items.Columns(0).Visible = False
                            DataGridView_Items.Columns(2).Visible = False
                            DataGridView_Items.Columns(3).Visible = False
                            DataGridView_Items.Columns(4).Visible = False
                            DataGridView_Items.Columns(5).Visible = False
                            DataGridView_Items.Columns(7).Visible = False
                            DataGridView_Items.Columns(8).Visible = False
                            DataGridView_Items.Columns(9).Visible = False
                            DataGridView_Items.Columns(10).Visible = False
                            DataGridView_Items.Columns(11).Visible = False
                        End If
                End Select

                RaiseEvent counted_Items(DataGridView_Items.RowCount)
                ToolStripLabel_Count.Text = DataGridView_Items.RowCount

            End If
            ToolStripProgressBar_List.Value = 0

        Else
            ToolStripProgressBar_List.Value = 50

        End If
    End Sub

    Private Sub ToolStripButton_AddItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_AddItem.Click
        Dim objOItem_Result As clsOntologyItem
        Dim objOItem_Class As New clsOntologyItem
        Dim oList_Simple As List(Of clsOntologyItem)
        Dim oList_ObjRel As New List(Of clsObjectRel)
        Dim oList_AttType As New List(Of clsOntologyItem)
        Dim oList_ObjAtt As New List(Of clsObjectAtt)
        Dim oItem_Obj As clsOntologyItem
        Dim objOItem_ClipBoardEntry As clsOntologyItem
        Dim boolAdd As Boolean
        Dim boolCancel As Boolean

        Dim boolValue As Boolean
        Dim dateValue As Date
        Dim lngValue As Long
        Dim dblValue As Double
        Dim strValue As String
        Dim strVal_Named As String

        Dim boolOpenMain As Boolean

        If Not objOItem_Parent Is Nothing Then
            Select Case objOItem_Parent.Type
                Case objLocalConfig.Globals.Type_Object
                    objOItem_Result = objTransaction_Objects.save_Object(objOItem_Parent.GUID_Parent)

                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        If objTransaction_Objects.Apply = True Then
                            oList_Selected_Simple.AddRange(objTransaction_Objects.NameObjects)

                            RaiseEvent applied_Items()
                        Else
                            configure_TabPages()
                            If Not objTransaction_Objects.OItem_SavedLast Is Nothing Then
                                ToolStripTextBox_Filter.Text = objTransaction_Objects.OItem_SavedLast.GUID
                            End If
                        End If
                        
                    ElseIf objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                        MsgBox("Beim Erzeugen ist ein Fehler aufgetreten!", MsgBoxStyle.Exclamation)
                    End If

                Case objLocalConfig.Globals.Type_RelationType
                    objOItem_Result = objTransaction_RelationTypes.save_RelType()
                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        configure_TabPages()
                    ElseIf objOItem_Result.GUID = objLocalConfig.Globals.LState_Relation.GUID Then
                        MsgBox("Es gibt bereits einen Beziehungstyp mit diesem Namen!", MsgBoxStyle.Exclamation)
                    ElseIf objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                        MsgBox("Beim Erzeugen ist ein Fehler aufgetreten!", MsgBoxStyle.Exclamation)
                    End If


                Case objLocalConfig.Globals.Type_AttributeType
                    objOItem_Result = objTransaction_AttributeTypes.save_AttType()
                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        configure_TabPages()
                    ElseIf objOItem_Result.GUID = objLocalConfig.Globals.LState_Relation.GUID Then
                        MsgBox("Es gibt bereits einen Beziehungstyp mit diesem Namen!", MsgBoxStyle.Exclamation)
                    ElseIf objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                        MsgBox("Beim Erzeugen ist ein Fehler aufgetreten!", MsgBoxStyle.Exclamation)
                    End If


            End Select


        Else

            Select Case strType
                Case objLocalConfig.Globals.Type_Object


                Case objLocalConfig.Globals.Type_RelationType



                Case objLocalConfig.Globals.Type_AttributeType
                    oList_AttType.Add(New clsOntologyItem(objOItem_Other.GUID, objLocalConfig.Globals.Type_AttributeType))
                    objDBLevel.get_Data_AttributeType(oList_AttType, False, False)


                    Dim objLAT = From objAT In objDBLevel.OList_AttributeTypes
                                 Group By objAT.GUID, objAT.Name, objAT.GUID_Parent Into Group
                    If objLAT.Count > 0 Then
                        Select Case objLAT(0).GUID_Parent
                            Case objLocalConfig.Globals.DType_Bool.GUID
                                objDlg_Attribute_Boolean = New dlg_Attribute_Boolean(objLAT(0).Name & "/" & objLocalConfig.Globals.DType_Bool.Name, objLocalConfig)
                                objDlg_Attribute_Boolean.ShowDialog(Me)
                                If objDlg_Attribute_Boolean.DialogResult = DialogResult.OK Then
                                    boolValue = objDlg_Attribute_Boolean.Value
                                    If boolValue = True Then
                                        strVal_Named = "True"
                                    Else
                                        strVal_Named = "False"
                                    End If

                                    oList_ObjAtt.Clear()
                                    oList_ObjAtt.Add(New clsObjectAtt(Nothing, _
                                                                       objOItem_Object.GUID, _
                                                                       objOItem_Object.Name, _
                                                                       objOItem_Object.GUID_Parent, _
                                                                       Nothing, _
                                                                       objOItem_Other.GUID, _
                                                                       Nothing, _
                                                                       1, _
                                                                       strVal_Named, _
                                                                       boolValue, _
                                                                       Nothing, _
                                                                       Nothing, _
                                                                       Nothing, _
                                                                       Nothing, _
                                                                       objLocalConfig.Globals.DType_Bool.GUID))

                                    objOItem_Result = objDBLevel.save_ObjAtt(oList_ObjAtt)
                                    If Not objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                        MsgBox("Leider konnte das Attribut nicht gespeichert werden!", MsgBoxStyle.Exclamation)

                                    End If
                                    configure_TabPages()
                                End If
                            Case objLocalConfig.Globals.DType_DateTime.GUID
                                objDlg_Attribute_DateTime = New dlg_Attribute_DateTime(objLAT(0).Name & "/" & objLocalConfig.Globals.DType_DateTime.Name, objLocalConfig)
                                objDlg_Attribute_DateTime.ShowDialog(Me)
                                If objDlg_Attribute_DateTime.DialogResult = DialogResult.OK Then
                                    dateValue = objDlg_Attribute_DateTime.Value

                                    strVal_Named = dateValue.ToString
                                    oList_ObjAtt.Clear()
                                    oList_ObjAtt.Add(New clsObjectAtt(Nothing, _
                                                                       objOItem_Object.GUID, _
                                                                       objOItem_Object.Name, _
                                                                       objOItem_Object.GUID_Parent, _
                                                                       Nothing, _
                                                                       objOItem_Other.GUID, _
                                                                       Nothing, _
                                                                       1, _
                                                                       strVal_Named, _
                                                                       Nothing, _
                                                                       dateValue, _
                                                                       Nothing, _
                                                                       Nothing, _
                                                                       Nothing, _
                                                                       objLocalConfig.Globals.DType_DateTime.GUID))

                                    objOItem_Result = objDBLevel.save_ObjAtt(oList_ObjAtt)
                                    If Not objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                        MsgBox("Leider konnte das Attribut nicht gespeichert werden!", MsgBoxStyle.Exclamation)

                                    End If
                                    configure_TabPages()
                                End If
                            Case objLocalConfig.Globals.DType_Int.GUID
                                objDlg_Attribute_Long = New dlg_Attribute_Long(objLAT(0).Name & "/" & objLocalConfig.Globals.DType_Int.Name, objLocalConfig)
                                objDlg_Attribute_Long.ShowDialog(Me)
                                If objDlg_Attribute_Long.DialogResult = DialogResult.OK Then
                                    lngValue = objDlg_Attribute_Long.Value

                                    strVal_Named = lngValue.ToString
                                    oList_ObjAtt.Clear()
                                    oList_ObjAtt.Add(New clsObjectAtt(Nothing, _
                                                                       objOItem_Object.GUID, _
                                                                       objOItem_Object.Name, _
                                                                       objOItem_Object.GUID_Parent, _
                                                                       Nothing, _
                                                                       objOItem_Other.GUID, _
                                                                       Nothing, _
                                                                       1, _
                                                                       strVal_Named, _
                                                                       Nothing, _
                                                                       Nothing, _
                                                                       lngValue, _
                                                                       Nothing, _
                                                                       Nothing, _
                                                                       objLocalConfig.Globals.DType_Int.GUID))

                                    objOItem_Result = objDBLevel.save_ObjAtt(oList_ObjAtt)
                                    If Not objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                        MsgBox("Leider konnte das Attribut nicht gespeichert werden!", MsgBoxStyle.Exclamation)

                                    End If
                                    configure_TabPages()
                                End If
                            Case objLocalConfig.Globals.DType_Real.GUID
                                objDlg_Attribute_Double = New dlg_Attribute_Double(objLAT(0).Name & "/" & objLocalConfig.Globals.DType_Real.Name, objLocalConfig)
                                objDlg_Attribute_Double.ShowDialog(Me)
                                If objDlg_Attribute_Double.DialogResult = DialogResult.OK Then
                                    dblValue = objDlg_Attribute_Double.Value

                                    strVal_Named = dblValue.ToString
                                    oList_ObjAtt.Clear()
                                    oList_ObjAtt.Add(New clsObjectAtt(Nothing, _
                                                                       objOItem_Object.GUID, _
                                                                       objOItem_Object.Name, _
                                                                       objOItem_Object.GUID_Parent, _
                                                                       Nothing, _
                                                                       objOItem_Other.GUID, _
                                                                       Nothing, _
                                                                       1, _
                                                                       strVal_Named, _
                                                                       Nothing, _
                                                                       Nothing, _
                                                                       Nothing, _
                                                                       dblValue, _
                                                                       Nothing, _
                                                                       objLocalConfig.Globals.DType_Real.GUID))

                                    objOItem_Result = objDBLevel.save_ObjAtt(oList_ObjAtt)
                                    If Not objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                        MsgBox("Leider konnte das Attribut nicht gespeichert werden!", MsgBoxStyle.Exclamation)

                                    End If
                                    configure_TabPages()
                                End If
                            Case objLocalConfig.Globals.DType_String.GUID
                                objDlg_Attribute_String = New dlg_Attribute_String(objLAT(0).Name & "/" & objLocalConfig.Globals.DType_String.Name, objLocalConfig)
                                objDlg_Attribute_String.ShowDialog(Me)
                                If objDlg_Attribute_String.DialogResult = DialogResult.OK Then
                                    strValue = objDlg_Attribute_String.Value

                                    strVal_Named = strValue
                                    oList_ObjAtt.Clear()
                                    oList_ObjAtt.Add(New clsObjectAtt(Nothing, _
                                                                       objOItem_Object.GUID, _
                                                                       objOItem_Object.Name, _
                                                                       objOItem_Object.GUID_Parent, _
                                                                       Nothing, _
                                                                       objOItem_Other.GUID, _
                                                                       Nothing, _
                                                                       1, _
                                                                       strVal_Named, _
                                                                       Nothing, _
                                                                       Nothing, _
                                                                       Nothing, _
                                                                       Nothing, _
                                                                       strValue, _
                                                                       objLocalConfig.Globals.DType_String.GUID))

                                    objOItem_Result = objDBLevel.save_ObjAtt(oList_ObjAtt)
                                    If Not objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                        MsgBox("Leider konnte das Attribut nicht gespeichert werden!", MsgBoxStyle.Exclamation)

                                    End If
                                    configure_TabPages()
                                End If
                        End Select

                    End If


                Case objLocalConfig.Globals.Type_Other
                    boolCancel = False
                    Dim boolOrderID = False
                    If objOItem_Other Is Nothing Then
                        objFrm_Clipboard = New frmClipboard(objLocalConfig)
                        Dim objOLRel As New List(Of clsObjectRel)
                        If objFrm_Clipboard.containedByClipboard() = True Then
                            objFrm_Clipboard.ShowDialog(Me)
                            boolOR = objFrm_Clipboard.OrderID
                            If objFrm_Clipboard.DialogResult = DialogResult.OK Then
                                For Each objDGVR_Selected As DataGridViewRow In objFrm_Clipboard.selectedRows
                                    objOLRel.Add(objDGVR_Selected.DataBoundItem)

                                Next
                            End If
                        End If

                        If objFrm_Clipboard.Cntrl = False Then
                            If Not objOLRel.Any Then
                                objFrm_Main = New frmMain(objLocalConfig.Globals)
                                objFrm_Main.Applyable = True
                                objFrm_Main.ShowDialog(Me)
                                If objFrm_Main.DialogResult = DialogResult.OK Then
                                    If objFrm_Main.OList_Simple.Any Then
                                        oList_Simple = objFrm_Main.OList_Simple
                                        boolAdd = True
                                    Else
                                        MsgBox("Bitte ein Element auswählen!", MsgBoxStyle.Information)
                                    End If
                                Else
                                    boolCancel = True
                                End If

                                objFrm_Main.Dispose()
                            Else
                                oList_Simple = (From objORel In objOLRel
                                                        Select New clsOntologyItem With {.GUID = objORel.ID_Other, _
                                                                                         .Name = objORel.Name_Other, _
                                                                                         .GUID_Parent = objORel.ID_Parent_Other, _
                                                                                         .Type = objLocalConfig.Globals.Type_Object, _
                                                                                         .Level = objORel.OrderID, _
                                                                                         .Mark = boolOrderID}).ToList()
                                boolAdd = True
                            End If
                        Else
                            boolCancel = True
                        End If
                        

                    Else
                        Select Case objOItem_Other.Type
                            Case objLocalConfig.Globals.Type_Object



                                If objOItem_Direction.GUID = objLocalConfig.Globals.Direction_LeftRight.GUID Then
                                    objOItem_ClipBoardEntry = New clsOntologyItem(Nothing, Nothing, objOItem_Other.GUID_Parent, objLocalConfig.Globals.Type_Object)
                                    objOItem_Class.GUID = objOItem_Other.GUID_Parent
                                    objOItem_Class.Type = objLocalConfig.Globals.Type_Class
                                Else
                                    objOItem_ClipBoardEntry = New clsOntologyItem(Nothing, Nothing, strGUID_Class, objLocalConfig.Globals.Type_Object)
                                    objOItem_Class.GUID = strGUID_Class
                                    objOItem_Class.Type = objLocalConfig.Globals.Type_Class
                                End If

                                boolOpenMain = True

                                objFrm_Clipboard = New frmClipboard(objLocalConfig, objOItem_ClipBoardEntry)
                                Dim objOLRel As New List(Of clsObjectRel)
                                If objFrm_Clipboard.containedByClipboard() = True Then
                                    objFrm_Clipboard.ShowDialog(Me)
                                    boolOrderID = objFrm_Clipboard.OrderID
                                    If objFrm_Clipboard.DialogResult = DialogResult.OK Then
                                        For Each objDGVR_Selected As DataGridViewRow In objFrm_Clipboard.selectedRows
                                            objOLRel.Add(objDGVR_Selected.DataBoundItem)

                                        Next
                                    End If
                                End If

                                If objFrm_Clipboard.Cntrl = False Then
                                    If Not objOLRel.Any Then
                                        objFrm_Main = New frmMain(objLocalConfig, objLocalConfig.Globals.Type_Class, objOItem_Class)
                                        objFrm_Main.ShowDialog(Me)
                                        If objFrm_Main.DialogResult = DialogResult.OK Then
                                            If objFrm_Main.Type_Applied = objLocalConfig.Globals.Type_Object Then
                                                oList_Simple = objFrm_Main.OList_Simple
                                                boolAdd = True

                                                Dim oLSel = From obj In oList_Simple
                                                            Group By obj.GUID_Parent Into Group

                                                For Each oSel In oLSel
                                                    If Not oSel.GUID_Parent = objOItem_Class.GUID Then
                                                        boolAdd = False
                                                        Exit For
                                                    End If
                                                Next

                                            Else
                                                MsgBox("Bitte nur Objekte auswählen!", MsgBoxStyle.Information)
                                            End If

                                        Else
                                            boolCancel = True
                                        End If

                                        objFrm_Main.Dispose()
                                    Else
                                        oList_Simple = (From objORel In objOLRel
                                                        Select New clsOntologyItem With {.GUID = objORel.ID_Other, _
                                                                                         .Name = objORel.Name_Other, _
                                                                                         .GUID_Parent = objORel.ID_Parent_Other, _
                                                                                         .Type = objLocalConfig.Globals.Type_Object, _
                                                                                         .Level = objORel.OrderID, _
                                                                                         .Mark = boolOrderID}).ToList()
                                        boolAdd = True
                                    End If
                                Else
                                    boolCancel = True
                                End If
                                

                        End Select
                    End If


                    If boolAdd = True Then
                        For Each oItem_Obj In oList_Simple
                            If objOItem_Direction.GUID = objLocalConfig.Globals.Direction_LeftRight.GUID Then
                                oList_ObjRel.Add(New clsObjectRel(objOItem_Object.GUID, objOItem_Object.GUID_Parent, oItem_Obj.GUID, oItem_Obj.GUID_Parent, objOItem_RelationType.GUID, oItem_Obj.Type, Nothing, If(oItem_Obj.Mark, oItem_Obj.Level, 1)))

                            Else
                                oList_ObjRel.Add(New clsObjectRel(oItem_Obj.GUID, oItem_Obj.GUID_Parent, objOItem_Other.GUID, objOItem_Other.GUID_Parent, objOItem_RelationType.GUID, oItem_Obj.Type, Nothing, If(oItem_Obj.Mark, oItem_Obj.Level, 1)))

                            End If
                        Next
                        objOItem_Result = objDBLevel.save_ObjRel(oList_ObjRel)

                        If Not objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                            MsgBox("Beim Speichern ist ein Fehler aufgetreten!", MsgBoxStyle.Exclamation)
                        ElseIf objOItem_Result.Max1 > objOItem_Result.Val_Long Then
                            MsgBox("Es konnten nicht alle Beziehungen erzeugt werden!", MsgBoxStyle.Information)

                        End If
                        configure_TabPages()
                    Else
                        If boolCancel = False Then
                            MsgBox("Sie haben Objekte der falschen Klasse ausgewählt!", MsgBoxStyle.Exclamation)
                        End If

                    End If


            End Select

        End If
    End Sub


    Private Sub ToolStripButton_DelItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_DelItem.Click
        Dim objDGVR_Selected As DataGridViewRow
        Dim objDRV_Selected As DataRowView
        Dim oList_Simple As New List(Of clsOntologyItem)
        Dim oList_ORel As New List(Of clsObjectRel)
        Dim oList_OAtt As New List(Of clsObjectAtt)
        Dim objOItem_Result As clsOntologyItem
        Dim objOAL_ObjectAtts As New List(Of clsObjectAtt)

        For Each objDGVR_Selected In DataGridView_Items.SelectedRows
            objDRV_Selected = objDGVR_Selected.DataBoundItem

            If Not objOItem_Parent Is Nothing Then


                oList_Simple.Add(New clsOntologyItem(objDRV_Selected.Item("ID_Item"), objOItem_Parent.Type))





            Else
                Select Case strType
                    Case objLocalConfig.Globals.Type_AttributeType
                        oList_OAtt.Add(New clsObjectAtt(objDRV_Selected.Item("ID_ObjectAttribute"), _
                                                        Nothing, _
                                                        Nothing, _
                                                        Nothing, _
                                                        Nothing))

                    Case objLocalConfig.Globals.Type_Other
                        oList_ORel.Add(New clsObjectRel(objDRV_Selected.Item("ID_Object"), _
                                                            Nothing, _
                                                            objDRV_Selected.Item("ID_Other"), _
                                                            Nothing, _
                                                            objDRV_Selected.Item("ID_RelationType"), _
                                                            objDRV_Selected.Item("Ontology"), _
                                                            Nothing, _
                                                            Nothing))
                End Select



            End If

        Next

        If Not oList_Simple Is Nothing Then
            If oList_Simple.Count > 0 Then

                If oList_Simple(0).Type = objLocalConfig.Globals.Type_AttributeType Then
                    objOItem_Result = objDBLevel.del_AttributeType(oList_Simple)
                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        If objOItem_Result.Count > 0 Then
                            MsgBox("Es konnten nur " & objOItem_Result.Min & " von " & objOItem_Result.Max1 & " Items gelöscht werden!", MsgBoxStyle.Information)
                        End If

                    ElseIf objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                        MsgBox("Beim Löschen ist ein Fehler aufgetreten!", MsgBoxStyle.Exclamation)
                    End If
                    get_Data()
                ElseIf oList_Simple(0).Type = objLocalConfig.Globals.Type_Object Then
                    If Control.ModifierKeys = Keys.Control Then
                        If MsgBox("Wollen Sie wirklich alle markierten Elemente einschließlich derer Beziehungen löschen?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            Dim objOList_AttributesDel = oList_Simple.Select(Function(o) New clsObjectAtt With {.ID_Object = o.GUID}).ToList()
                            Dim objOList_ObjectsForw = oList_Simple.Select(Function(o) New clsObjectRel With {.ID_Object = o.GUID}).ToList()
                            Dim objOList_ObjectsBackw = oList_Simple.Select(Function(o) New clsObjectRel With {.ID_Other = o.GUID}).ToList()

                            objOItem_Result = objDBLevel.del_ObjectAtt(objOList_AttributesDel)
                            If Not objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                                objOItem_Result = objDBLevel.del_ObjectRel(objOList_ObjectsForw)
                                If Not objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                                    objOItem_Result = objDBLevel.del_ObjectRel(objOList_ObjectsBackw)
                                    If Not objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                                        objOItem_Result = objDBLevel.del_Objects(oList_Simple)
                                        If objOItem_Result.Count > 0 Then
                                            MsgBox("Es konnten nur " & objOItem_Result.Min & " von " & objOItem_Result.Max1 & " Items gelöscht werden!", MsgBoxStyle.Information)
                                        ElseIf objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                                            MsgBox("Beim Löschen ist ein Fehler aufgetreten!", MsgBoxStyle.Exclamation)
                                        End If
                                    Else
                                        MsgBox("Die Elemente konnten nicht gelöscht werden!", MsgBoxStyle.Exclamation)
                                    End If
                                Else
                                    MsgBox("Die Elemente konnten nicht gelöscht werden!", MsgBoxStyle.Exclamation)
                                End If
                            Else
                                MsgBox("Die Elemente konnten nicht gelöscht werden!", MsgBoxStyle.Exclamation)
                            End If
                        End If

                    Else
                        objOItem_Result = objDBLevel.del_Objects(oList_Simple)
                        If objOItem_Result.Count > 0 Then
                            MsgBox("Es konnten nur " & objOItem_Result.Min & " von " & objOItem_Result.Max1 & " Items gelöscht werden!", MsgBoxStyle.Information)
                        ElseIf objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                            MsgBox("Beim Löschen ist ein Fehler aufgetreten!", MsgBoxStyle.Exclamation)
                        End If

                    End If
                    get_Data()

                ElseIf oList_Simple(0).Type = objLocalConfig.Globals.Type_RelationType Then
                    objOItem_Result = objDBLevel.del_RelationTypes(oList_Simple)
                    If objOItem_Result.Count > 0 Then
                        MsgBox("Es konnten nur " & objOItem_Result.Min & " von " & objOItem_Result.Max1 & " Items gelöscht werden!", MsgBoxStyle.Information)
                    ElseIf objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                        MsgBox("Beim Löschen ist ein Fehler aufgetreten!", MsgBoxStyle.Exclamation)
                    End If
                    get_Data()
                End If





            End If
        End If

        If Not oList_ORel Is Nothing Then
            If oList_ORel.Count > 0 Then
                objOItem_Result = objDBLevel.del_ObjectRel(oList_ORel)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                    MsgBox("Die Beziehungen konnten nicht entfernt werden!", MsgBoxStyle.Exclamation)
                End If
            End If
        End If

        If Not oList_OAtt Is Nothing Then
            If oList_OAtt.Count > 0 Then
                objOItem_Result = objDBLevel.del_ObjectAtt(oList_OAtt)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                    MsgBox("Die Beziehungen konnten nicht entfernt werden!", MsgBoxStyle.Exclamation)
                End If
            End If
        End If

        configure_TabPages()
    End Sub

    Private Sub ContextMenuStrip_SemList_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip_SemList.Opening
        Dim i As Integer
        Dim boolFillCombo As Boolean = False

        ToClipboardToolStripMenuItem.Enabled = False
        ApplyToolStripMenuItem.Enabled = False
        DuplicateItemToolStripMenuItem.Enabled = False
        ChangeOrderIDsToolStripMenuItem.Enabled = False
        MoveObjectsToolStripMenuItem.Enabled = False
        
        If DataGridView_Items.SelectedRows.Count > 0 Then
            If boolApplyable = True Then
                ApplyToolStripMenuItem.Enabled = True
            End If
            If DataGridView_Items.SelectedRows.Count = 1 Then
                If Not objOItem_Parent Is Nothing Then
                    If objOItem_Parent.Type = objLocalConfig.Globals.Type_Object Then
                        DuplicateItemToolStripMenuItem.Enabled = True
                        MoveObjectsToolStripMenuItem.Enabled = True
                    End If
                End If


            End If

            If Not objOItem_Parent Is Nothing Then
                If objOItem_Parent.Type = objLocalConfig.Globals.Type_Object Then
                    MoveObjectsToolStripMenuItem.Enabled = True
                End If
            End If
            ToClipboardToolStripMenuItem.Enabled = True
        End If

        If DataGridView_Items.SelectedCells.Count>0 Then
            ChangeOrderIDsToolStripMenuItem.Enabled = True    
        End If
    End Sub

    Private Sub ApplyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ApplyToolStripMenuItem.Click
        Dim objDGVR_Selected As DataGridViewRow
        Dim objDRV_Selected As DataRowView
        oList_Selected_ObjectRel.Clear()
        oList_Selected_Simple.Clear()
        If boolApplyable = True And DataGridView_Items.SelectedRows.Count > 0 Then
            For Each objDGVR_Selected In DataGridView_Items.SelectedRows
                objDRV_Selected = objDGVR_Selected.DataBoundItem
                If Not objOItem_Parent Is Nothing Then
                    Select Case objOItem_Parent.Type
                        Case objLocalConfig.Globals.Type_Object
                            oList_Selected_Simple.Add(New clsOntologyItem(objDRV_Selected.Item("ID_Item"), _
                                                                          objDRV_Selected.Item("Name"), _
                                                                          objDRV_Selected.Item("ID_Parent"), _
                                                                          objLocalConfig.Globals.Type_Object))
                            RaiseEvent applied_Items()
                        Case objLocalConfig.Globals.Type_RelationType
                            oList_Selected_Simple.Add(New clsOntologyItem(objDRV_Selected.Item("ID_Item"), _
                                                                              objDRV_Selected.Item("Name"), _
                                                                              objLocalConfig.Globals.Type_RelationType))
                            RaiseEvent applied_Items()
                        Case objLocalConfig.Globals.Type_AttributeType
                            oList_Selected_Simple.Add(New clsOntologyItem(objDRV_Selected.Item("ID_Item"), _
                                                                              objDRV_Selected.Item("Name"), _
                                                                              objDRV_Selected.Item("ID_Parent"), _
                                                                              objLocalConfig.Globals.Type_AttributeType))
                            RaiseEvent applied_Items()
                    End Select


                Else

                    Select Case strType
                        Case objLocalConfig.Globals.Type_Object


                        Case objLocalConfig.Globals.Type_RelationType



                        Case objLocalConfig.Globals.Type_AttributeType



                        Case objLocalConfig.Globals.Type_Other


                    End Select

                End If
            Next
        End If
    End Sub

    Private Sub ToClipboardToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToClipboardToolStripMenuItem.Click
        Dim objDGVR_Selected As DataGridViewRow
        Dim objDRV_Selected As DataRowView
        Dim objOItem_ToClipboard As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem

        For Each objDGVR_Selected In DataGridView_Items.SelectedRows
            objDRV_Selected = objDGVR_Selected.DataBoundItem

            If Not objOItem_Parent Is Nothing Then
                Select Case objOItem_Parent.Type
                    Case objLocalConfig.Globals.Type_Object
                        objOItem_ToClipboard = New clsOntologyItem(objDRV_Selected.Item(strRowName_GUID), _
                                                                   objDRV_Selected.Item(strRowName_Name), _
                                                                   objDRV_Selected.Item(strRowName_ParentGUID), _
                                                                   objLocalConfig.Globals.Type_Object)

                        objOItem_Result = objOntologyClipboard.addToClipboard(objOItem_ToClipboard, False)
                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                            MsgBox("Das Item kann nicht ins Clipboard geschrieben werden!", MsgBoxStyle.Exclamation)

                        End If

                    Case objLocalConfig.Globals.Type_RelationType
                        objOItem_ToClipboard = New clsOntologyItem(objDRV_Selected.Item(strRowName_GUID), _
                                                                   objDRV_Selected.Item(strRowName_Name), _
                                                                   objLocalConfig.Globals.Type_Object)

                        objOItem_Result = objOntologyClipboard.addToClipboard(objOItem_ToClipboard, False)
                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                            MsgBox("Das Item kann nicht ins Clipboard geschrieben werden!", MsgBoxStyle.Exclamation)

                        End If
                    Case objLocalConfig.Globals.Type_AttributeType
                        objOItem_ToClipboard = New clsOntologyItem(objDRV_Selected.Item(strRowName_GUID), _
                                                                   objDRV_Selected.Item(strRowName_Name), _
                                                                   objDRV_Selected.Item(strRowName_ParentGUID), _
                                                                   objLocalConfig.Globals.Type_Object)

                        objOItem_Result = objOntologyClipboard.addToClipboard(objOItem_ToClipboard, False)
                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                            MsgBox("Das Item kann nicht ins Clipboard geschrieben werden!", MsgBoxStyle.Exclamation)

                        End If
                End Select


            Else

                Select Case strType
                    Case objLocalConfig.Globals.Type_Object


                    Case objLocalConfig.Globals.Type_RelationType



                    Case objLocalConfig.Globals.Type_AttributeType



                    Case objLocalConfig.Globals.Type_Other
                        objOItem_ToClipboard = New clsOntologyItem(objDRV_Selected.Item(strRowName_GUID), _
                                                                   objDRV_Selected.Item(strRowName_Name), _
                                                                   objDRV_Selected.Item(strRowName_ParentGUID), _
                                                                   objLocalConfig.Globals.Type_Object)
                        objOItem_Result = objOntologyClipboard.addToClipboard(objOItem_ToClipboard, False)
                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                            MsgBox("Das Item kann nicht ins Clipboard geschrieben werden!", MsgBoxStyle.Exclamation)

                        End If
                End Select

            End If
        Next
    End Sub

    Private Sub CopyNameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyNameToolStripMenuItem.Click
        Dim objDGVR_Selected As DataGridViewRow
        Dim objDRV_Selected As DataRowView
        Dim strClipboard As String = ""


        For Each objDGVR_Selected In DataGridView_Items.SelectedRows
            objDRV_Selected = objDGVR_Selected.DataBoundItem
            If Not objOItem_Parent Is Nothing Then
                Select Case objOItem_Parent.Type
                    Case objLocalConfig.Globals.Type_Object
                        strClipboard = objDRV_Selected.Item("Name")


                    Case objLocalConfig.Globals.Type_RelationType
                        strClipboard = objDRV_Selected.Item("Name")

                    Case objLocalConfig.Globals.Type_AttributeType
                        strClipboard = objDRV_Selected.Item("Name")

                End Select


            Else

                Select Case strType
                    Case objLocalConfig.Globals.Type_Object


                    Case objLocalConfig.Globals.Type_RelationType



                    Case objLocalConfig.Globals.Type_AttributeType



                    Case objLocalConfig.Globals.Type_Other

                        If objOItem_Direction.GUID = objLocalConfig.Globals.Direction_LeftRight.GUID Then
                            strClipboard = objDRV_Selected.Item("name_other")


                        Else
                            strClipboard = objDRV_Selected.Item("name_object")

                        End If



                End Select

            End If
        Next

        Clipboard.SetDataObject(strClipboard)
    End Sub

    Private Sub DuplicateItemToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DuplicateItemToolStripMenuItem.Click
        Dim objDGVR_Selected As DataGridViewRow
        Dim objDRV_Selected As DataRowView

        objDGVR_Selected = DataGridView_Items.SelectedRows(0)
        objDRV_Selected = objDGVR_Selected.DataBoundItem

        Dim objOItem_Object = New clsOntologyItem With {.GUID = objDRV_Selected.Item("ID_Item"), _
                                                        .Name = objDRV_Selected.Item("Name"), _
                                                        .GUID_Parent = objDRV_Selected.Item("ID_Parent"), _
                                                        .Type = objLocalConfig.Globals.Type_Object}

        Dim objOItem_Result = objTransaction_Objects.duplicate_Object(objOItem_Object)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            configure_TabPages()
            ToolStripTextBox_Filter.Text = objTransaction_Objects.OItem_SavedLast.GUID
        End If

    End Sub

    Private Sub ToolStripButton_FilterAdvanced_Click( sender As Object,  e As EventArgs) Handles ToolStripButton_FilterAdvanced.Click
        
        If strGUID_Class <>"" Then
            objOItem_Class.GUID= strGUID_Class
            objOItem_Class.Type = objLocalConfig.Globals.Type_Class

            objFrmAdvancedFilter = New frmAdvancedFilter(objLocalConfig,objOItem_Class)
            objFrmAdvancedFilter.ShowDialog(Me)
            If objFrmAdvancedFilter.DialogResult = DialogResult.OK Then
                objOItem_Class_AdvancedFilter= objFrmAdvancedFilter.OItem_Class
                objOItem_Object_AdvancedFilter = objFrmAdvancedFilter.OItem_Object
                objOItem_RelationType_AdvancedFilter = objFrmAdvancedFilter.OItem_RelationType
                objOItem_Direction_AdvancedFilter = objFrmAdvancedFilter.OItem_Direction
                
                get_Data()
                configure_TabPages()
            End If
        End If        
        

    End Sub

    Private Sub ToolStripButton_Replace_Click( sender As Object,  e As EventArgs) Handles ToolStripButton_Replace.Click
        If strType = objLocalConfig.Globals.Type_Object Then
            Dim objObjectList as List(Of clsOntologyItem) = (From objDGVR As DataGridViewRow In DataGridView_Items.SelectedRows Select objDRV = objDGVR.DataBoundItem Select New clsOntologyItem With {.GUID = DirectCast(objDRV, DataRowView).Item("ID_Item"), _
                    .Name = DirectCast(objDRV, DataRowView).Item("Name"), _
                    .GUID_Parent = DirectCast(objDRV, DataRowView).Item("ID_Parent"), _
                    .Type = objLocalConfig.Globals.Type_Object }).ToList()

            If objObjectList.Any() Then
                objFrm_Replace = New frmReplace(objLocalConfig,objObjectList)
                objFrm_Replace.ShowDialog(Me)
                If objFrm_Replace.DialogResult=DialogResult.OK Then
                    get_Data()
                End If
                
            End If
        End If
    End Sub

    Private Sub ModuleMenuToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs) Handles ModuleMenuToolStripMenuItem.DropDownOpening

        If Not objOItem_Parent Is Nothing Then
            If objOItem_Parent.Type = objLocalConfig.Globals.Type_Object Then
                If DataGridView_Items.SelectedRows.Count = 1 Then
                    Dim objDGVR_Selected As DataGridViewRow = DataGridView_Items.SelectedRows(0)
                    Dim objDRV_Selected As DataRowView = objDGVR_Selected.DataBoundItem

                    Dim objOItem_Object = New clsOntologyItem With {.GUID = objDRV_Selected.Item("ID_Item"), _
                                                                    .Name = objDRV_Selected.Item("Name"), _
                                                                    .GUID_Parent = objDRV_Selected.Item("ID_Parent"), _
                                                                    .Type = objLocalConfig.Globals.Type_Object}


                    For Each objModule In objLocalConfig.Globals.ModuleList

                        Dim objMenuItems = objModule.GetMenuItems(objOItem_Object)
                        If Not objMenuItems Is Nothing Then
                            Dim objToolStrip_Root As ToolStripMenuItem
                            For i As Integer = 0 To objMenuItems.Count - 1
                                If i = 0 Then
                                    If ModuleMenuToolStripMenuItem.DropDownItems.Count = 1 Then
                                        objToolStrip_Root = ModuleMenuToolStripMenuItem.DropDownItems.Add(objMenuItems(i).Name, Nothing)
                                    Else
                                        objToolStrip_Root = ModuleMenuToolStripMenuItem.DropDownItems(0)
                                    End If

                                Else
                                    Dim boolAdd = True
                                    For Each objToolStripItem As ToolStripItem In objToolStrip_Root.DropDownItems
                                        If objToolStripItem.Text = objMenuItems(i).Name Then
                                            boolAdd = False
                                        End If
                                    Next

                                    If boolAdd Then
                                        objToolStrip_Root.DropDownItems.Add(objMenuItems(i).Name, Nothing, New EventHandler(AddressOf ModuleExecutor))
                                    End If
                                End If


                            Next

                        End If
                    Next
                ElseIf DataGridView_Items.SelectedRows.Count > 1 Then

                End If
            End If
            
        ElseIf objOItem_Parent Is Nothing And Not objOItem_Other Is Nothing Then
            If objOItem_Direction.GUID = objLocalConfig.Globals.Direction_LeftRight.GUID Then
                If DataGridView_Items.SelectedRows.Count = 1 Then
                    Dim objDGVR_Selected As DataGridViewRow = DataGridView_Items.SelectedRows(0)
                    Dim objDRV_Selected As DataRowView = objDGVR_Selected.DataBoundItem

                    Dim objOItem_Object = New clsOntologyItem With {.GUID = objDRV_Selected.Item("ID_Other"), _
                                                                    .Name = objDRV_Selected.Item("Name_Other"), _
                                                                    .GUID_Parent = objDRV_Selected.Item("ID_Parent_Other"), _
                                                                    .Type = objDRV_Selected.Item("Ontology")}


                    For Each objModule In objLocalConfig.Globals.ModuleList

                        Dim objMenuItems = objModule.GetMenuItems(objOItem_Object)
                        If Not objMenuItems Is Nothing Then
                            Dim objToolStrip_Root As ToolStripMenuItem
                            For i As Integer = 0 To objMenuItems.Count - 1
                                If i = 0 Then
                                    If ModuleMenuToolStripMenuItem.DropDownItems.Count = 1 Then
                                        objToolStrip_Root = ModuleMenuToolStripMenuItem.DropDownItems.Add(objMenuItems(i).Name, Nothing)
                                    Else
                                        objToolStrip_Root = ModuleMenuToolStripMenuItem.DropDownItems(0)
                                    End If

                                Else
                                    Dim boolAdd = True
                                    For Each objToolStripItem As ToolStripItem In objToolStrip_Root.DropDownItems
                                        If objToolStripItem.Text = objMenuItems(i).Name Then
                                            boolAdd = False
                                        End If
                                    Next

                                    If boolAdd Then
                                        objToolStrip_Root.DropDownItems.Add(objMenuItems(i).Name, Nothing, New EventHandler(AddressOf ModuleExecutor))
                                    End If
                                End If


                            Next

                        End If
                    Next
                ElseIf DataGridView_Items.SelectedRows.Count > 1 Then


                End If
            Else
                If DataGridView_Items.SelectedRows.Count = 1 Then
                    Dim objDGVR_Selected As DataGridViewRow = DataGridView_Items.SelectedRows(0)
                    Dim objDRV_Selected As DataRowView = objDGVR_Selected.DataBoundItem

                    Dim objOItem_Object = New clsOntologyItem With {.GUID = objDRV_Selected.Item("ID_Object"), _
                                                                    .Name = objDRV_Selected.Item("Name_Object"), _
                                                                    .GUID_Parent = objDRV_Selected.Item("ID_Parent_Object"), _
                                                                    .Type = objDRV_Selected.Item("Ontology")}


                    For Each objModule In objLocalConfig.Globals.ModuleList

                        Dim objMenuItems = objModule.GetMenuItems(objOItem_Object)
                        If Not objMenuItems Is Nothing Then
                            Dim objToolStrip_Root As ToolStripMenuItem
                            For i As Integer = 0 To objMenuItems.Count - 1
                                If i = 0 Then
                                    If ModuleMenuToolStripMenuItem.DropDownItems.Count = 1 Then
                                        objToolStrip_Root = ModuleMenuToolStripMenuItem.DropDownItems.Add(objMenuItems(i).Name, Nothing)
                                    Else
                                        objToolStrip_Root = ModuleMenuToolStripMenuItem.DropDownItems(0)
                                    End If

                                Else
                                    Dim boolAdd = True
                                    For Each objToolStripItem As ToolStripItem In objToolStrip_Root.DropDownItems
                                        If objToolStripItem.Text = objMenuItems(i).Name Then
                                            boolAdd = False
                                        End If
                                    Next

                                    If boolAdd Then
                                        objToolStrip_Root.DropDownItems.Add(objMenuItems(i).Name, Nothing, New EventHandler(AddressOf ModuleExecutor))
                                    End If
                                End If


                            Next

                        End If
                    Next
                ElseIf DataGridView_Items.SelectedRows.Count > 1 Then


                End If
            End If

        End If








    End Sub

    Private Sub ModuleExecutor(sender As Object, e As EventArgs)

        If Not objOItem_Parent Is Nothing Then
            If objOItem_Parent.Type = objLocalConfig.Globals.Type_Object Then
                If DataGridView_Items.SelectedRows.Count = 1 Then
                    Dim objMenuItem As ToolStripMenuItem = sender

                    Dim objDGVR_Selected As DataGridViewRow = DataGridView_Items.SelectedRows(0)
                    Dim objDRV_Selected As DataRowView = objDGVR_Selected.DataBoundItem

                    Dim objOItem_Object = New clsOntologyItem With {.GUID = objDRV_Selected.Item("ID_Item"), _
                                                                    .Name = objDRV_Selected.Item("Name"), _
                                                                    .GUID_Parent = objDRV_Selected.Item("ID_Parent"), _
                                                                    .Type = objLocalConfig.Globals.Type_Object}

                    For Each objModule In objLocalConfig.Globals.ModuleList


                        Dim objMenuItems = objModule.GetMenuItems(objOItem_Object)
                        If objMenuItems.Any Then
                            If objMenuItems(0).Name = objMenuItem.OwnerItem.Text Then
                                Dim objMenuItemsSel = objMenuItems.Where(Function(m) m.Name = objMenuItem.Text).ToList()
                                If objMenuItemsSel.Any() Then
                                    Dim objOItem_MenuItem = objMenuItemsSel.First()
                                    objModule.Instance.Open_Viewer(objOItem_Object, objOItem_MenuItem)
                                End If

                            End If
                        End If
                    Next

                ElseIf DataGridView_Items.SelectedRows.Count > 1 Then

                End If

            End If
        ElseIf objOItem_Parent Is Nothing And Not objOItem_Other Is Nothing Then
            If objOItem_Direction.GUID = objLocalConfig.Globals.Direction_LeftRight.GUID Then
                If DataGridView_Items.SelectedRows.Count = 1 Then
                    Dim objMenuItem As ToolStripMenuItem = sender

                    Dim objDGVR_Selected As DataGridViewRow = DataGridView_Items.SelectedRows(0)
                    Dim objDRV_Selected As DataRowView = objDGVR_Selected.DataBoundItem

                    Dim objOItem_Object = New clsOntologyItem With {.GUID = objDRV_Selected.Item("ID_Other"), _
                                                                    .Name = objDRV_Selected.Item("Name_Other"), _
                                                                    .GUID_Parent = objDRV_Selected.Item("ID_Parent_Other"), _
                                                                    .Type = objDRV_Selected.Item("Ontology")}

                    For Each objModule In objLocalConfig.Globals.ModuleList


                        Dim objMenuItems = objModule.GetMenuItems(objOItem_Object)
                        If objMenuItems.Any Then
                            If objMenuItems(0).Name = objMenuItem.OwnerItem.Text Then
                                Dim objMenuItemsSel = objMenuItems.Where(Function(m) m.Name = objMenuItem.Text).ToList()
                                If objMenuItemsSel.Any() Then
                                    Dim objOItem_MenuItem = objMenuItemsSel.First()
                                    objModule.Instance.Open_Viewer(objOItem_Object, objOItem_MenuItem)
                                End If

                            End If
                        End If
                    Next

                ElseIf DataGridView_Items.SelectedRows.Count > 1 Then

                End If
            Else
                If DataGridView_Items.SelectedRows.Count = 1 Then
                    Dim objMenuItem As ToolStripMenuItem = sender

                    Dim objDGVR_Selected As DataGridViewRow = DataGridView_Items.SelectedRows(0)
                    Dim objDRV_Selected As DataRowView = objDGVR_Selected.DataBoundItem

                    Dim objOItem_Object = New clsOntologyItem With {.GUID = objDRV_Selected.Item("ID_Object"), _
                                                                    .Name = objDRV_Selected.Item("Name_Object"), _
                                                                    .GUID_Parent = objDRV_Selected.Item("ID_Parent_Object"), _
                                                                    .Type = objLocalConfig.Globals.Type_Object}

                    For Each objModule In objLocalConfig.Globals.ModuleList


                        Dim objMenuItems = objModule.GetMenuItems(objOItem_Object)
                        If objMenuItems.Any Then
                            If objMenuItems(0).Name = objMenuItem.OwnerItem.Text Then
                                Dim objMenuItemsSel = objMenuItems.Where(Function(m) m.Name = objMenuItem.Text).ToList()
                                If objMenuItemsSel.Any() Then
                                    Dim objOItem_MenuItem = objMenuItemsSel.First()
                                    objModule.Instance.Open_Viewer(objOItem_Object, objOItem_MenuItem)
                                End If

                            End If
                        End If
                    Next

                ElseIf DataGridView_Items.SelectedRows.Count > 1 Then

                End If
            End If
        End If
    End Sub

    Private Sub ChangeOrderIDsToolStripMenuItem_Click( sender As Object,  e As EventArgs) Handles ChangeOrderIDsToolStripMenuItem.Click
        Dim boolOk = DataGridView_Items.SelectedCells.Cast (Of DataGridViewCell)().All(Function(cell) DataGridView_Items.Columns(cell.ColumnIndex).DataPropertyName = "OrderID")
        Dim objOList_Relation As List(Of clsObjectRel) = New List(Of clsObjectRel)()
        dim objOLIst_Att As List(Of clsObjectAtt) = New List(Of clsObjectAtt)()
        Dim boolRel As Boolean
        Dim boolChange = false

        If boolOk Then
            
            objDlg_Attribute_Long = New dlg_Attribute_Long("New OrderID", objLocalConfig.Globals, 0)
            objDlg_Attribute_Long.ShowDialog(Me)

            If objDlg_Attribute_Long.DialogResult = DialogResult.OK Then
                For Each objColumn In DataGridView_Items.Columns
                    If objColumn.DataPropertyName.ToLower = "id_other" Then
                        boolRel = True
                        boolChange = True
                        Exit For
                    End If

                    If objColumn.DataPropertyName.ToLower = "id_attribute" Then

                        boolRel = False
                        boolChange = True
                        Exit For
                    End If
                Next
                If boolChange Then
                    Dim lngOrderID = objDlg_Attribute_Long.Value
                    For Each cell As DataGridViewCell In DataGridView_Items.SelectedCells
                        Dim objDGVR As DataGridViewRow = DataGridView_Items.Rows(cell.RowIndex)
                        Dim objDRV As DataRowView = objDGVR.DataBoundItem

                        If boolRel Then
                             objOList_Relation.Add(New clsObjectRel(objDRV.Item("ID_Object"), _
                                                                       objDRV.Item("ID_Parent_Object"), _
                                                                       objDRV.Item("ID_Other"), _
                                                                       objDRV.Item("ID_Parent_Other"), _
                                                                       objDRV.Item("ID_RelationType"), _
                                                                       objDRV.Item("Ontology"), _
                                                                       Nothing, _
                                                                       lngOrderID))

                            
                        Else 
                            objOLIst_Att.Add(New clsObjectAtt With {.ID_Attribute = objDRV.Item("ID_Attribute"), _
                                                                          .ID_Object = objDRV.Item("ID_Object"), _
                                                                          .ID_Class = objDRV.Item("ID_Class"), _
                                                                          .ID_AttributeType = objDRV.Item("ID_AttributeType"), _
                                                                          .OrderID = objDlg_Attribute_Long.Value, _
                                                                          .Val_Named = objDRV.Item("val_named"), _
                                                                          .Val_Bit = objDRV.Item("val_bit"), _
                                                                          .ID_DataType = objDRV.Item("ID_DataType")})

                            
                        End If
                   
                    Next

                    If boolRel And objOList_Relation.Any Then
                        Dim objOItem_Result = objDBLevel.save_ObjRel(objOList_Relation)
                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                            MsgBox("Die Gewichtung konnte nicht geändert werden!", MsgBoxStyle.Exclamation)
                        End If

                        get_Data()
                    ElseIf boolRel = False and objOLIst_Att.Any Then
                        Dim objOItem_Result = objDBLevel.save_ObjAtt(objOLIst_Att)
                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                            MsgBox("Die Gewichtung konnte nicht geändert werden!", MsgBoxStyle.Exclamation)
                        End If

                        get_Data()
                    End If
                    
                Else 
                    MsgBox("Hier können keine Order-IDs geändert werden!",MsgBoxStyle.OkOnly)
                End If
                


                
            End If
        Else
            MsgBox("Nur OrderID-Zellen können geändert werden!",MsgBoxStyle.OkOnly)

        End If
    End Sub

    Private Sub ToolStripButton_Sort_Click( sender As Object,  e As EventArgs) Handles ToolStripButton_Sort.Click
        Dim lngOrderID as Long
        Dim boolRel As Boolean
        Dim boolChange = false
        Dim objOList_Relation As List(Of clsObjectRel) = New List(Of clsObjectRel)()
        dim objOLIst_Att As List(Of clsObjectAtt) = New List(Of clsObjectAtt)()

        if DataGridView_Items.SelectedRows.Count>0 Then
             For Each objColumn In DataGridView_Items.Columns
                If objColumn.DataPropertyName.ToLower = "id_other" Then
                    boolRel = True
                    boolChange = True
                    Exit For
                End If

                If objColumn.DataPropertyName.ToLower = "id_attribute" Then

                    boolRel = False
                    boolChange = True
                    Exit For
                End If
            Next

            If boolChange Then
                objDlg_Attribute_Long = New dlg_Attribute_Long("New OrderID", objLocalConfig.Globals, 0)
                objDlg_Attribute_Long.ShowDialog(Me)

                If objDlg_Attribute_Long.DialogResult = DialogResult.OK Then
                    lngOrderID = objDlg_Attribute_Long.Value
                    For Each objDGVR As DataGridViewRow In DataGridView_Items.SelectedRows.Cast(of DataGridViewRow).OrderBy(function(i) i.Index).ToList()
                        Dim objDRV As DataRowView = objDGVR.DataBoundItem

                        If boolRel Then
                             objOList_Relation.Add(New clsObjectRel(objDRV.Item("ID_Object"), _
                                                                       objDRV.Item("ID_Parent_Object"), _
                                                                       objDRV.Item("ID_Other"), _
                                                                       objDRV.Item("ID_Parent_Other"), _
                                                                       objDRV.Item("ID_RelationType"), _
                                                                       objDRV.Item("Ontology"), _
                                                                       Nothing, _
                                                                       lngOrderID))

                            
                        Else 
                            objOLIst_Att.Add(New clsObjectAtt With {.ID_Attribute = objDRV.Item("ID_Attribute"), _
                                                                          .ID_Object = objDRV.Item("ID_Object"), _
                                                                          .ID_Class = objDRV.Item("ID_Class"), _
                                                                          .ID_AttributeType = objDRV.Item("ID_AttributeType"), _
                                                                          .OrderID = objDlg_Attribute_Long.Value, _
                                                                          .Val_Named = objDRV.Item("val_named"), _
                                                                          .Val_Bit = objDRV.Item("val_bit"), _
                                                                          .ID_DataType = objDRV.Item("ID_DataType")})

                            
                        End If
                        lngOrderID = lngOrderID + 1
                    Next

                    If boolRel And objOList_Relation.Any Then
                        Dim objOItem_Result = objDBLevel.save_ObjRel(objOList_Relation)
                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                            MsgBox("Die Gewichtung konnte nicht geändert werden!", MsgBoxStyle.Exclamation)
                        End If

                        get_Data()
                    ElseIf boolRel = False and objOLIst_Att.Any Then
                        Dim objOItem_Result = objDBLevel.save_ObjAtt(objOLIst_Att)
                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                            MsgBox("Die Gewichtung konnte nicht geändert werden!", MsgBoxStyle.Exclamation)
                        End If

                        get_Data()
                    End If
                End If
            Else 
                MsgBox("Hier leider nicht möglich.",MsgBoxStyle.OkOnly)
            End If

        End If
    End Sub

    Private Sub MoveObjectsToolStripMenuItem_Click( sender As Object,  e As EventArgs) Handles MoveObjectsToolStripMenuItem.Click
        objFrm_Main = New frmMain(objLocalConfig)
        objFrm_Main.ShowDialog(Me)
        If objFrm_Main.DialogResult = DialogResult.OK Then
            If objFrm_Main.Type_Applied = objLocalConfig.Globals.Type_Class Then
                If objFrm_Main.OList_Simple.Count = 1 Then
                    Dim objOList_DGVR = (From objDGVR As DataGridViewRow in DataGridView_Items.SelectedRows).Select(Function(r) r.DataBoundItem).ToList()
                    Dim objOList_Objects = (From objDRV As DataRowView in objOList_DGVR
                                            Select New clsOntologyItem With {.GUID = objDRV.Item("ID_Item"), _
                                                                             .Name = objDRV.Item("Name"), _
                                                                             .GUID_Parent = objFrm_Main.OList_Simple.First().GUID, _
                                                                             .Type = objLocalConfig.Globals.Type_Object}).ToList()

                    dim objOItem_Result = objDBLevel.save_Objects(objOList_Objects)
                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                        MsgBox("Die Objekte konnten nicht verschoben werden!",MsgBoxStyle.Exclamation)
                    End If
                            
                    configure_TabPages()
                Else 
                    MsgBox("Bitte wählen Sie eine Klasse aus!",MsgBoxStyle.OkOnly)
                End If

            Else 
                MsgBox("Bitte wählen Sie eine Klasse aus!",MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub
End Class


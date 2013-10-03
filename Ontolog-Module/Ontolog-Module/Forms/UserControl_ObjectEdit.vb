Imports OntologyClasses.BaseClasses

Public Class UserControl_ObjectEdit

    Private objLocalConfig As clsLocalConfig
    Private objDBLevel As clsDBLevel
    Private objOList_Objects As List(Of clsOntologyItem)
    Private objOList_ObjectRel As List(Of clsObjectRel)
    Private objTransaction As clsTransaction

    Private objFrm_ObjectEdit As frm_ObjectEdit

    Private objDataGridviewRowCollection_Objects As DataGridViewRowCollection
    Private WithEvents objUserControl_ObjectRelTree As UserControl_ObjectRelTree
    Private WithEvents objUserControl_OItem_List As UserControl_OItemList

    Private objOItem_Object As clsOntologyItem
    Private objOItem_ObjectRel As clsObjectRel
    Private objOItem_Direction As clsOntologyItem
    Private intRowID As Integer
    Private strOntology As String

    Private strRowName_ID As String
    Private strRowName_Name As String
    Private strRowName_ID_Parent As String

    Private Sub editObject(ByVal strType As String, ByVal objOItem_Direction As clsOntologyItem) Handles objUserControl_OItem_List.edit_Object
        objFrm_ObjectEdit = New frm_ObjectEdit(objLocalConfig, _
                                               objUserControl_OItem_List.DataGridviewRows, _
                                               objUserControl_OItem_List.RowID, _
                                               strType, _
                                               objOItem_Direction)
        objFrm_ObjectEdit.ShowDialog(Me)
        If objFrm_ObjectEdit.DialogResult = Windows.Forms.DialogResult.OK Then

        End If
    End Sub

    Private Sub configure_Navigation()
        ToolStripButton_Nav_First.Enabled = False
        ToolStripButton_Nav_Previous.Enabled = False
        ToolStripButton_Nav_Next.Enabled = False
        ToolStripButton_Nav_Last.Enabled = False

        If objDataGridviewRowCollection_Objects Is Nothing Then
            If objDataGridviewRowCollection_Objects.Count > 0 Then
                If intRowID >= 0 Then
                    ToolStripButton_Nav_First.Enabled = True
                    ToolStripButton_Nav_Previous.Enabled = True
                End If

                If intRowID < objDataGridviewRowCollection_Objects.Count Then
                    ToolStripButton_Nav_Next.Enabled = True
                    ToolStripButton_Nav_Last.Enabled = True
                End If
            End If
            
        ElseIf objOList_ObjectRel Is Nothing Then
            If objOList_ObjectRel.Count > 0 Then
                If intRowID >= 0 Then
                    ToolStripButton_Nav_First.Enabled = True
                    ToolStripButton_Nav_Previous.Enabled = True
                End If

                If intRowID < objOList_ObjectRel.Count Then
                    ToolStripButton_Nav_Next.Enabled = True
                    ToolStripButton_Nav_Last.Enabled = True
                End If
            End If
        Else
            If objOList_Objects.Count > 0 Then
                If intRowID >= 0 Then
                    ToolStripButton_Nav_First.Enabled = True
                    ToolStripButton_Nav_Previous.Enabled = True
                End If

                If intRowID < objOList_Objects.Count Then
                    ToolStripButton_Nav_Next.Enabled = True
                    ToolStripButton_Nav_Last.Enabled = True
                End If
            End If

        End If
    End Sub


    Private Sub selected_Node(ByVal oList_Selected As List(Of clsOntologyItem)) Handles objUserControl_ObjectRelTree.selected_Item


        Dim oList_Object As New List(Of clsOntologyItem)
        Dim oList_Other As New List(Of clsOntologyItem)
        Dim oItem_Direction As clsOntologyItem
        Dim oList_RelationType As New List(Of clsOntologyItem)

        


        If oList_Selected.Count = 4 Then
            oList_Object.Add(New clsOntologyItem(oList_Selected(0).GUID, oList_Selected(0).Name, oList_Selected(0).GUID_Parent, objLocalConfig.Globals.Type_Object))
            If oList_Selected(1).Type = objLocalConfig.Globals.Type_Class Then
                oList_Other.Add(New clsOntologyItem(Nothing, Nothing, oList_Selected(1).GUID, objLocalConfig.Globals.Type_Object))
            Else
                oList_Other.Add(New clsOntologyItem(oList_Selected(1).GUID, oList_Selected(1).Type))
            End If

            oList_RelationType.Add(New clsOntologyItem(oList_Selected(2).GUID, objLocalConfig.Globals.Type_RelationType))
            If oList_Selected(3).GUID = objLocalConfig.Globals.Direction_LeftRight.GUID Then
                oItem_Direction = objLocalConfig.Globals.Direction_LeftRight
            Else
                oItem_Direction = objLocalConfig.Globals.Direction_RightLeft

            End If
            objUserControl_OItem_List.initialize(Nothing, _
                                                 oList_Object(0), _
                                             oItem_Direction, _
                                             oList_Other(0), _
                                             oList_RelationType(0), False)
        ElseIf oList_Selected.Count = 2 Then
            oList_Object.Add(New clsOntologyItem(oList_Selected(0).GUID, oList_Selected(0).Name, oList_Selected(0).GUID_Parent, objLocalConfig.Globals.Type_Object))
            If oList_Selected(1).Type = objLocalConfig.Globals.Type_Class Then
                oList_Other.Add(New clsOntologyItem(Nothing, Nothing, oList_Selected(1).GUID, objLocalConfig.Globals.Type_Object))
            Else
                oList_Other.Add(New clsOntologyItem(oList_Selected(1).GUID, oList_Selected(1).Type))
            End If
            objUserControl_OItem_List.initialize(Nothing, _
                                                 oList_Object(0), _
                                             Nothing, _
                                             oList_Other(0), _
                                             Nothing, False)
        Else
            oList_Object.Add(New clsOntologyItem(oList_Selected(0).GUID, oList_Selected(0).Name, oList_Selected(0).GUID_Parent, objLocalConfig.Globals.Type_Object))
            oList_RelationType.Add(New clsOntologyItem(oList_Selected(1).GUID, oList_Selected(1).Name, objLocalConfig.Globals.Type_RelationType))

            objUserControl_OItem_List.initialize(Nothing, _
                                                 oList_Object(0), _
                                                 objLocalConfig.Globals.Direction_LeftRight, _
                                                    Nothing, _
                                                    oList_RelationType(0), _
                                                    True)
        End If

        
    End Sub


    Public Sub New(ByVal OList_Objecst As List(Of clsObjectRel), _
                   ByVal Ontology As String, _
                   ByVal oItem_Direction As clsOntologyItem, _
                   ByVal RowID As Integer, _
                   ByVal Globals As clsGlobals, _
                   Optional ByVal RowName_ID As String = Nothing, _
                   Optional ByVal RowName_Name As String = Nothing, _
                   Optional ByVal RowName_ID_Parent As String = Nothing)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = New clsLocalConfig(Globals)

        objOItem_Direction = oItem_Direction
        objOList_ObjectRel = OList_Objecst
        objDataGridviewRowCollection_Objects = Nothing
        objOList_Objects = Nothing

        intRowID = RowID
        strOntology = Ontology

        strRowName_ID = RowName_ID
        strRowName_Name = RowName_Name
        strRowName_ID_Parent = RowName_ID_Parent

        set_DBConnection()
        initialize()
    End Sub

    Public Sub New(ByVal OList_Objecst As List(Of clsOntologyItem), _
                   ByVal Ontology As String, _
                   ByVal oItem_Direction As clsOntologyItem, _
                   ByVal RowID As Integer, _
                   ByVal Globals As clsGlobals, _
                   Optional ByVal RowName_ID As String = Nothing, _
                   Optional ByVal RowName_Name As String = Nothing, _
                   Optional ByVal RowName_ID_Parent As String = Nothing)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = New clsLocalConfig(Globals)

        objOItem_Direction = oItem_Direction
        objOList_Objects = OList_Objecst
        objOList_ObjectRel = Nothing
        objDataGridviewRowCollection_Objects = Nothing
        intRowID = RowID
        strOntology = Ontology

        strRowName_ID = RowName_ID
        strRowName_Name = RowName_Name
        strRowName_ID_Parent = RowName_ID_Parent

        set_DBConnection()
        initialize()
    End Sub

    Public Sub New(ByVal DataGridviewRowCollection As DataGridViewRowCollection, _
                   ByVal Ontology As String, _
                   ByVal oItem_Direction As clsOntologyItem, _
                   ByVal RowID As Integer, _
                   ByVal Globals As clsGlobals, _
                   Optional ByVal RowName_ID As String = Nothing, _
                   Optional ByVal RowName_Name As String = Nothing, _
                   Optional ByVal RowName_ID_Parent As String = Nothing)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = New clsLocalConfig(Globals)

        objOItem_Direction = oItem_Direction
        objDataGridviewRowCollection_Objects = DataGridviewRowCollection
        objOList_Objects = Nothing
        objOList_ObjectRel = Nothing
        intRowID = RowID
        strOntology = Ontology

        strRowName_ID = RowName_ID
        strRowName_Name = RowName_Name
        strRowName_ID_Parent = RowName_ID_Parent

        set_DBConnection()
        initialize()
    End Sub

    Private Sub initialize()
        Dim objDGVR_Selected As DataGridViewRow
        Dim objDRV_Selected As DataRowView



        If Not objOList_Objects Is Nothing Then
            objOItem_Object = objOList_Objects(intRowID)

            ToolStripTextBox_GUID.Text = objOItem_Object.GUID
            ToolStripTextBox_Name.ReadOnly = True
            ToolStripTextBox_Name.Text = objOItem_Object.Name
            ToolStripTextBox_Name.ReadOnly = False

        ElseIf objDataGridviewRowCollection_Objects Is Nothing Then

        Else

            objDGVR_Selected = objDataGridviewRowCollection_Objects(intRowID)
            objDRV_Selected = objDGVR_Selected.DataBoundItem

            objOItem_Object = New clsOntologyItem
            If strOntology = objLocalConfig.Globals.Type_Other Then
                
                If objOItem_Direction.GUID = objLocalConfig.Globals.Direction_LeftRight.GUID Then

                    If strRowName_ID = Nothing Then
                        strRowName_ID = "ID_Other"
                    End If

                    If strRowName_Name = Nothing Then
                        strRowName_Name = "Name_Other"
                    End If

                    If strRowName_ID_Parent = Nothing Then
                        strRowName_ID_Parent = "ID_Parent_Other"
                    End If

                    objOItem_Object.GUID = objDRV_Selected.Item(strRowName_ID)
                    objOItem_Object.Name = objDRV_Selected.Item(strRowName_Name)
                    objOItem_Object.GUID_Parent = objDRV_Selected.Item(strRowName_ID_Parent)
                    objOItem_Object.Type = objLocalConfig.Globals.Type_Object
                Else

                    If strRowName_ID = Nothing Then
                        strRowName_ID = "ID_Object"
                    End If

                    If strRowName_Name = Nothing Then
                        strRowName_Name = "Name_Object"
                    End If

                    If strRowName_ID_Parent = Nothing Then
                        strRowName_ID_Parent = "ID_Parent_Object"
                    End If

                    objOItem_Object.GUID = objDRV_Selected.Item(strRowName_ID)
                    objOItem_Object.Name = objDRV_Selected.Item(strRowName_Name)
                    objOItem_Object.GUID_Parent = objDRV_Selected.Item(strRowName_ID_Parent)
                    objOItem_Object.Type = objLocalConfig.Globals.Type_Object

                End If
            Else
                If strRowName_ID = Nothing Then
                    strRowName_ID = "ID_Item"
                End If

                If strRowName_Name = Nothing Then
                    strRowName_Name = "Name"
                End If

                If strRowName_ID_Parent = Nothing Then
                    strRowName_ID_Parent = "ID_Parent"
                End If

                objOItem_Object.GUID = objDRV_Selected.Item(strRowName_ID)
                objOItem_Object.Name = objDRV_Selected.Item(strRowName_Name)
                objOItem_Object.GUID_Parent = objDRV_Selected.Item(strRowName_ID_Parent)
                objOItem_Object.Type = objLocalConfig.Globals.Type_Object
            End If
            

            ToolStripTextBox_GUID.Text = objOItem_Object.GUID
            ToolStripTextBox_Name.ReadOnly = True
            ToolStripTextBox_Name.Text = objOItem_Object.Name
            ToolStripTextBox_Name.ReadOnly = False
        End If
        If objOItem_Object.Type Is Nothing Then
            objOItem_Object.Type = objLocalConfig.Globals.Type_Object
        End If
        objUserControl_ObjectRelTree = New UserControl_ObjectRelTree(objLocalConfig, objOItem_Object)
        objUserControl_ObjectRelTree.Dock = DockStyle.Fill
        SplitContainer1.Panel1.Controls.Clear()
        SplitContainer1.Panel1.Controls.Add(objUserControl_ObjectRelTree)
        objUserControl_OItem_List = New UserControl_OItemList(objLocalConfig)
        objUserControl_OItem_List.Dock = DockStyle.Fill
        SplitContainer1.Panel2.Controls.Clear()
        SplitContainer1.Panel2.Controls.Add(objUserControl_OItem_List)
        set_CountLbl()
    End Sub

    Private Sub set_CountLbl()
        ToolStripLabel_ObjectCount.Text = intRowID + 1

        If objOList_Objects Is Nothing Then
            ToolStripLabel_ObjectCount.Text = ToolStripLabel_ObjectCount.Text & "/" & objDataGridviewRowCollection_Objects.Count
        Else
            ToolStripLabel_ObjectCount.Text = ToolStripLabel_ObjectCount.Text & "/" & objOList_Objects.Count
        End If

    End Sub

    Private Sub set_DBConnection()
        objDBLevel = New clsDBLevel(objLocalConfig.Globals)
        objTransaction = New clsTransaction(objLocalConfig.Globals)
    End Sub

    Private Sub ToolStripTextBox_Name_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripTextBox_Name.TextChanged
        Timer_Name_Change.Stop()
        If ToolStripTextBox_Name.ReadOnly = False Then
            Timer_Name_Change.Start()
        End If


    End Sub

    Private Sub Timer_Name_Change_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_Name_Change.Tick
        Dim objOItem_Result As clsOntologyItem
        Timer_Name_Change.Stop()

        If ToolStripTextBox_Name.Text <> objOItem_Object.Name Then
            objOItem_Object.Name = ToolStripTextBox_Name.Text
            objTransaction.ClearItems()
            objOItem_Result = objTransaction.do_Transaction(objOItem_Object)
            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                MsgBox("Der Name konnte nicht geändert werden!", MsgBoxStyle.Exclamation)
                ToolStripTextBox_Name.ReadOnly = True
                ToolStripTextBox_Name.Text = objOItem_Object.Name
                ToolStripTextBox_Name.ReadOnly = False
            End If
        End If
    End Sub

    Private Sub ToolStripButton_Nav_First_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Nav_First.Click
        intRowID = 0

        initialize()
    End Sub

    Private Function RowIdLast() As Integer
        intRowID = -1
        If objDataGridviewRowCollection_Objects Is Nothing Then
            If objDataGridviewRowCollection_Objects.Count > 0 Then
                intRowID = objDataGridviewRowCollection_Objects.Count - 1
            End If

        ElseIf objOList_ObjectRel Is Nothing Then
            If objOList_ObjectRel.Count > 0 Then
                intRowID = objOList_ObjectRel.Count - 1

            End If
        Else
            If objOList_Objects.Count > 0 Then
                intRowID = objOList_Objects.Count - 1
            End If

        End If
    End Function

    Private Function IsRowIdValid() As Boolean
        Dim boolResult As Boolean

        boolResult = False
        If objDataGridviewRowCollection_Objects Is Nothing Then
            If objDataGridviewRowCollection_Objects.Count > 0 Then
                If intRowID >= 0 Then
                    boolResult = True
                End If

                If intRowID < objDataGridviewRowCollection_Objects.Count Then
                    boolResult = True
                End If
            End If

        ElseIf objOList_ObjectRel Is Nothing Then
            If objOList_ObjectRel.Count > 0 Then
                If intRowID >= 0 Then
                    boolResult = True
                End If

                If intRowID < objOList_ObjectRel.Count Then
                    boolResult = True
                End If
            End If
        Else
            If objOList_Objects.Count > 0 Then
                If intRowID >= 0 Then
                    boolResult = True
                End If

                If intRowID < objOList_Objects.Count Then
                    boolResult = True
                End If
            End If

        End If

        Return boolResult
    End Function

    Private Sub ToolStripButton_Nav_Previous_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Nav_Previous.Click
        intRowID = intRowID - 1
        initialize()

    End Sub

    Private Sub ToolStripButton_Nav_Next_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Nav_Next.Click
        intRowID = intRowID + 1
        initialize()
    End Sub

    Private Sub ToolStripButton_Nav_Last_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Nav_Last.Click
        intRowID = RowIdLast()
        initialize()

    End Sub
End Class


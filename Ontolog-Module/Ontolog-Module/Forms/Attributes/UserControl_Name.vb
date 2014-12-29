Imports OntologyClasses.BaseClasses

Public Class UserControl_Name
    Private objGlobals As clsGlobals
    Private objOItem As clsOntologyItem

    Private objFrmName As frm_Name

    Private strName As String

    Private objDBLevel_Name As clsDBLevel
    Private objTransaciton As clsTransaction

    Private Delegate Sub InvokeChangeOfName(objOItem_Result As clsOntologyItem)
    Private DgInvokeChangeOfName As InvokeChangeOfName

    Public Event NameLoaded(objOItem_Result As clsOntologyItem)

    Private objThread As Threading.Thread

    Private boolChangedByInvoke As Boolean

    Public Sub Clear()
        Label_Name.Text = "-"
        TextBox_Name.ReadOnly = True
        TextBox_Name.Text = ""
    End Sub

    Public Sub InitializeNameConnection(strCaption As String, objOItem As clsOntologyItem)
        Me.strName = strCaption
        Me.objOItem = objOItem

        TextBox_Name.ReadOnly = True
        Label_Name.Text = strName
        TextBox_Name.Left = Label_Name.Left + Label_Name.Width + 5
        TextBox_Name.Width = Me.Width - TextBox_Name.Left - 1

        AddHandler NameLoaded, AddressOf NameIsLoaded
        DgInvokeChangeOfName = New InvokeChangeOfName(AddressOf InvokeNameChange)

        objThread = New Threading.Thread(AddressOf GetName)
        objThread.Start()

    End Sub

    Private Sub Initialize()
        objDBLevel_Name = New clsDBLevel(objGlobals)
        objTransaciton = New clsTransaction(objGlobals)

        TextBox_Name.ReadOnly = True

       
    End Sub

    Private Sub NameIsLoaded(objOItem_Result As clsOntologyItem)
        If Me.InvokeRequired Then
            Me.Invoke(DgInvokeChangeOfName, objOItem_Result)
        Else
            InvokeNameChange(objOItem_Result)
        End If
    End Sub

    Private Sub InvokeNameChange(objOItem_Result As clsOntologyItem)

        If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then
            boolChangedByInvoke = True
            TextBox_Name.Text = objOItem_Result.Val_String

        Else
            MsgBox("Der Wert konnte nicht ermittelt werden!", MsgBoxStyle.Exclamation)
        End If

    End Sub

    Private Sub GetName()

        Select Case objOItem.Type
            Case objGlobals.Type_AttributeType
                Dim searchItem = New List(Of clsOntologyItem) From {New clsOntologyItem With {.GUID = objOItem.GUID}}
                Dim objOItem_Result = objDBLevel_Name.get_Data_AttributeType(searchItem)

                If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then
                    If objDBLevel_Name.OList_AttributeTypes.Any() Then
                        objOItem_Result.Val_String = objDBLevel_Name.OList_AttributeTypes.First().Name
                    Else
                        objOItem_Result = objGlobals.LState_Error
                    End If
                End If

                RaiseEvent NameLoaded(objOItem_Result)
            Case objGlobals.Type_Class
                Dim searchItem = New List(Of clsOntologyItem) From {New clsOntologyItem With {.GUID = objOItem.GUID}}
                Dim objOItem_Result = objDBLevel_Name.get_Data_Classes(searchItem)

                If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then
                    If objDBLevel_Name.OList_Classes.Any() Then
                        objOItem_Result.Val_String = objDBLevel_Name.OList_Classes.First().Name
                    Else
                        objOItem_Result = objGlobals.LState_Error
                    End If
                End If

                RaiseEvent NameLoaded(objOItem_Result)
            Case objGlobals.Type_RelationType
                Dim searchItem = New List(Of clsOntologyItem) From {New clsOntologyItem With {.GUID = objOItem.GUID}}
                Dim objOItem_Result = objDBLevel_Name.get_Data_RelationTypes(searchItem)

                If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then
                    If objDBLevel_Name.OList_RelationTypes.Any() Then
                        objOItem_Result.Val_String = objDBLevel_Name.OList_RelationTypes.First().Name
                    Else
                        objOItem_Result = objGlobals.LState_Error
                    End If
                End If

                RaiseEvent NameLoaded(objOItem_Result)
            Case objGlobals.Type_Object
                Dim searchItem = New List(Of clsOntologyItem) From {New clsOntologyItem With {.GUID = objOItem.GUID}}
                Dim objOItem_Result = objDBLevel_Name.get_Data_Objects(searchItem)

                If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then
                    If objDBLevel_Name.OList_Objects.Any() Then
                        objOItem_Result.Val_String = objDBLevel_Name.OList_Objects.First().Name
                    Else
                        objOItem_Result = objGlobals.LState_Error
                    End If
                End If

                RaiseEvent NameLoaded(objOItem_Result)
        End Select
    End Sub

    Public Sub New(objGlobals As clsGlobals)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        Me.objGlobals = objGlobals
        Initialize()
    End Sub

    Private Sub TextBox_Name_TextChanged(sender As Object, e As EventArgs) Handles TextBox_Name.TextChanged
        Timer_Change.Stop()
        Timer_Change.Start()
    End Sub

    Private Sub Timer_Change_Tick(sender As Object, e As EventArgs) Handles Timer_Change.Tick
        Timer_Change.Stop()
        SaveName()
        If boolChangedByInvoke Then
            boolChangedByInvoke = False
            TextBox_Name.ReadOnly = False
        End If

    End Sub


    Private Sub SaveName()
        If TextBox_Name.ReadOnly = False Then
            Dim strName = TextBox_Name.Text
            Dim objOItem_Save = objOItem.Clone()
            objOItem_Save.Name = strName
            objTransaciton.ClearItems()
            
            Dim objOItem_Result = objTransaciton.do_Transaction(objOItem_Save)
            If objOItem_Result.GUID = objGlobals.LState_Error.GUID Then
                MsgBox("Leider konnte der Name nicht gespeichert werden!", MsgBoxStyle.Exclamation)
                TextBox_Name.ReadOnly = True
                TextBox_Name.Text = objOItem.Name
                TextBox_Name.ReadOnly = False
            End If
            
        End If
    End Sub

    Private Sub TextBox_Name_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles TextBox_Name.MouseDoubleClick
        If TextBox_Name.ReadOnly = False Then
            objFrmName = New frm_Name("Name", objGlobals, Value1:=TextBox_Name.Text)
            objFrmName.ShowDialog(Me)
            If objFrmName.DialogResult = DialogResult.OK Then
                TextBox_Name.Text = objFrmName.Value1
            End If
        End If
        
    End Sub


End Class

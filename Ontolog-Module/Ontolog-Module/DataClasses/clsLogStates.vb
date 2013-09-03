Public Class clsLogStates
    Private objClasses As New clsClasses
    Private objTypes As New clsTypes

    Private objLogState_Success As clsOntologyItem
    Private objLogState_Error As clsOntologyItem
    Private objLogState_Nothing As clsOntologyItem
    Private objLogState_Insert As clsOntologyItem
    Private objLogState_Update As clsOntologyItem
    Private objLogState_Delete As clsOntologyItem
    Private objLogState_Relation As clsOntologyItem
    Private objLogState_Exists As clsOntologyItem

    Public ReadOnly Property LogState_Success As clsOntologyItem
        Get
            Return objLogState_Success
        End Get
    End Property
    Public ReadOnly Property LogState_Error As clsOntologyItem
        Get
            Return objLogState_Error
        End Get
    End Property
    Public ReadOnly Property LogState_Nothing As clsOntologyItem
        Get
            Return objLogState_Nothing
        End Get
    End Property
    Public ReadOnly Property LogState_Insert As clsOntologyItem
        Get
            Return objLogState_Insert
        End Get
    End Property
    Public ReadOnly Property LogState_Update As clsOntologyItem
        Get
            Return objLogState_Update
        End Get
    End Property
    Public ReadOnly Property LogState_Delete As clsOntologyItem
        Get
            Return objLogState_Delete
        End Get
    End Property
    Public ReadOnly Property LogState_Relation As clsOntologyItem
        Get
            Return objLogState_Relation
        End Get
    End Property
    Public ReadOnly Property LogState_Exists As clsOntologyItem
        Get
            Return objLogState_Exists
        End Get
    End Property

    Public Sub New()
        objLogState_Delete = New clsOntologyItem("bb6a95553af640fc9fb0489d2678dff2", "Delete", objClasses.OItem_Class_Logstate.GUID, objTypes.ObjectType)
        objLogState_Error = New clsOntologyItem("cc71434176314b78b8f4385db073635f", "Error", objClasses.OItem_Class_Logstate.GUID, objTypes.ObjectType)
        objLogState_Exists = New clsOntologyItem("0b285306f64d4444bffe627a21687eff", "Exist", objClasses.OItem_Class_Logstate.GUID, objTypes.ObjectType)
        objLogState_Insert = New clsOntologyItem("a6df6ab2359045b1b32535334a2f574a", "Insert", objClasses.OItem_Class_Logstate.GUID, objTypes.ObjectType)
        objLogState_Nothing = New clsOntologyItem("95666887fb2a416e9624a48d48dc5446", "Nothing", objClasses.OItem_Class_Logstate.GUID, objTypes.ObjectType)
        objLogState_Relation = New clsOntologyItem("a46b74723c8e44a8b7853913b760db", "Relation", objClasses.OItem_Class_Logstate.GUID, objTypes.ObjectType)
        objLogState_Success = New clsOntologyItem("84251164265e4e0294b2ed7c40a02e56", "Success", objClasses.OItem_Class_Logstate.GUID, objTypes.ObjectType)
        objLogState_Update = New clsOntologyItem("2bf7e9d6fb9c40929b16ecc4fef7c072", "Update", objClasses.OItem_Class_Logstate.GUID, objTypes.ObjectType)
    End Sub
End Class

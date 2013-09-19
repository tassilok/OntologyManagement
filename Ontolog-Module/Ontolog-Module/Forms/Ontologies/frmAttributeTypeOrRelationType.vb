Public Class frmAttributeTypeOrRelationType

    Private objGlobals As clsGlobals
    Private WithEvents objUserControl_AttributeTypes As UserControl_OItemList
    Private WithEvents objUserControl_RelationTypes As UserControl_OItemList


    Public Sub New(Globals As clsGlobals)
        
        ' This call is required by the designer.
        InitializeComponent()
        
        ' Add any initialization after the InitializeComponent() call.
        objGlobals = Globals
        initialize()
    End Sub

    Private sub initialize
        Dim objOItem_RelType As New clsOntologyItem(Nothing, Nothing, objGlobals.Type_RelationType)
        Dim objOItem_AttType As New clsOntologyItem(Nothing, Nothing, objGlobals.Type_AttributeType)

        objUserControl_AttributeTypes = new UserControl_OItemList(objGlobals)
        objUserControl_AttributeTypes.Dock = Dock.Fill
        Panel_AttributeTypes.Controls.Add(objUserControl_AttributeTypes)

        objUserControl_RelationTypes = new UserControl_OItemList(objGlobals)
        objUserControl_RelationTypes.Dock = Dock.Fill
        Panel_AttributeTypes.Controls.Add(objUserControl_RelationTypes)


        objUserControl_AttributeTypes.initialize(objOItem_AttType)
        objUserControl_AttributeTypes.Applyable = True
        objUserControl_RelationTypes.initialize(objOItem_RelType)
        objUserControl_RelationTypes.Applyable = True

    End Sub
End Class
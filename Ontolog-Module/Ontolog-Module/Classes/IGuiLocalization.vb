Imports OntologyClasses.BaseClasses

Public Interface IGuiLocalization
    ReadOnly Property OItem_attribute_caption As clsOntologyItem
    ReadOnly Property OItem_attributetype_message As clsOntologyItem
    ReadOnly Property OItem_attributetype_short As clsOntologyItem

    ReadOnly Property OItem_type_gui_caption As clsOntologyItem
    ReadOnly Property OItem_type_gui_entires As clsOntologyItem
    ReadOnly Property OItem_type_language As clsOntologyItem
    ReadOnly Property OItem_class_localized_message As clsOntologyItem
    ReadOnly Property OItem_class_messages As clsOntologyItem
    ReadOnly Property OItem_type_tooltip_messages As clsOntologyItem

    ReadOnly Property OItem_relationtype_belongsto As clsOntologyItem
    ReadOnly Property OItem_relationtype_contains As clsOntologyItem
    ReadOnly Property OItem_relationtype_errormessage As clsOntologyItem
    ReadOnly Property OItem_relationtype_user_message As clsOntologyItem
    ReadOnly Property OItem_relationtype_inputmessage As clsOntologyItem
    ReadOnly Property OItem_relationtype_is_defined_by As clsOntologyItem
    ReadOnly Property OItem_relationtype_iswrittenin As clsOntologyItem

    ReadOnly Property Globals As clsGlobals
    ReadOnly Property ID_Development As String
End Interface

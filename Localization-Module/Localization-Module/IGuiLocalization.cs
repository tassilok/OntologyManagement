using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.BaseClasses;
using Ontology_Module;

namespace Localization_Module
{
    public interface IGuiLocalization
    {
        clsOntologyItem OItem_attribute_caption { get; set; }
        clsOntologyItem OItem_attributetype_message { get; set; }
        clsOntologyItem OItem_attributetype_short { get; set; }

        clsOntologyItem OItem_type_gui_caption { get; set; }
        clsOntologyItem OItem_type_gui_entires { get; set; }
        clsOntologyItem OItem_type_language { get; set; }
        clsOntologyItem OItem_class_localized_message { get; set; }
        clsOntologyItem OItem_class_messages { get; set; }
        clsOntologyItem OItem_type_tooltip_messages { get; set; }

        clsOntologyItem OItem_relationtype_belongsto { get; set; }
        clsOntologyItem OItem_relationtype_contains { get; set; }
        clsOntologyItem OItem_relationtype_errormessage { get; set; }
        clsOntologyItem OItem_relationtype_user_message { get; set; }
        clsOntologyItem OItem_relationtype_inputmessage { get; set; }
        clsOntologyItem OItem_relationtype_is_defined_by { get; set; }
        clsOntologyItem OItem_relationtype_iswrittenin { get; set; }

        clsGlobals Globals { get; set; }
        string Id_Development { get; }
    }
    
}

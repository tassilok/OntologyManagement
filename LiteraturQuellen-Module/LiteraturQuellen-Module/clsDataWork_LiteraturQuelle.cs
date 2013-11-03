using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ontology_Module;
using Structure_Module;
using OntologyClasses.BaseClasses;

namespace LiteraturQuellen_Module
{
    
    public class clsDataWork_LiteraturQuelle
    {
        private clsLocalConfig objLocalConfig;

        private clsDBLevel objDBLevel_LiteraturQuellen;

        public clsOntologyItem OItem_Result_LiteraturQuellen { get; private set; }

        public SortableBindingList<clsLiteraturQuelle> OList_LiteraturQuellen { get; set; }

        public void GetData_LiteraturQuellen()
        {
            OItem_Result_LiteraturQuellen = objLocalConfig.Globals.LState_Nothing.Clone();

            var objORL_Literaturquellen = new List<clsObjectRel> {
                new clsObjectRel {ID_Parent_Other = objLocalConfig.OItem_type_literarische_quelle.GUID,
                    ID_RelationType = objLocalConfig.OItem_relationtype_issubordinated.GUID, 
                    ID_Parent_Object = objLocalConfig.OItem_type_audio_quelle.GUID },
                new clsObjectRel {ID_Parent_Other = objLocalConfig.OItem_type_literarische_quelle.GUID,
                    ID_RelationType = objLocalConfig.OItem_relationtype_issubordinated.GUID, 
                    ID_Parent_Object = objLocalConfig.OItem_type_bild_quelle.GUID },
                new clsObjectRel {ID_Parent_Other = objLocalConfig.OItem_type_literarische_quelle.GUID,
                    ID_RelationType = objLocalConfig.OItem_relationtype_issubordinated.GUID, 
                    ID_Parent_Object = objLocalConfig.OItem_type_buch_quellenangabe.GUID },
                new clsObjectRel {ID_Parent_Other = objLocalConfig.OItem_type_literarische_quelle.GUID,
                    ID_RelationType = objLocalConfig.OItem_relationtype_issubordinated.GUID, 
                    ID_Parent_Object = objLocalConfig.OItem_type_email_quelle.GUID },
                new clsObjectRel {ID_Parent_Other = objLocalConfig.OItem_type_literarische_quelle.GUID,
                    ID_RelationType = objLocalConfig.OItem_relationtype_issubordinated.GUID, 
                    ID_Parent_Object = objLocalConfig.OItem_type_internet_quellenangabe.GUID },
                new clsObjectRel {ID_Parent_Other = objLocalConfig.OItem_type_literarische_quelle.GUID,
                    ID_RelationType = objLocalConfig.OItem_relationtype_issubordinated.GUID, 
                    ID_Parent_Object = objLocalConfig.OItem_type_video_quelle.GUID },
                new clsObjectRel {ID_Parent_Other = objLocalConfig.OItem_type_literarische_quelle.GUID,
                    ID_RelationType = objLocalConfig.OItem_relationtype_issubordinated.GUID, 
                    ID_Parent_Object = objLocalConfig.OItem_type_zeitungsquelle.GUID } };

            var objOItem_Result = objDBLevel_LiteraturQuellen.get_Data_ObjectRel(objORL_Literaturquellen, boolIDs: false);

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                OList_LiteraturQuellen = new SortableBindingList<clsLiteraturQuelle>(objDBLevel_LiteraturQuellen.OList_ObjectRel.Select(p => new clsLiteraturQuelle
                {
                    ID_LiteraturQuelle = p.ID_Other,
                    Name_LiteraturQuelle = p.Name_Other,
                    ID_Quelle = p.ID_Object,
                    Name_Quelle = p.Name_Object,
                    ID_Class_Quelle = p.ID_Parent_Object,
                    Name_Class_Quelle = p.Name_Parent_Object
                }));

                OItem_Result_LiteraturQuellen = objOItem_Result;
            }
            else
            {
                OItem_Result_LiteraturQuellen = objLocalConfig.Globals.LState_Error.Clone();
            }
        }

        public clsDataWork_LiteraturQuelle(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;
            Initialize();
        }

        private void Initialize()
        {
            objDBLevel_LiteraturQuellen = new clsDBLevel(objLocalConfig.Globals);

            OItem_Result_LiteraturQuellen = objLocalConfig.Globals.LState_Nothing.Clone();
        }
    }
}

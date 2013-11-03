using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ontology_Module;
using OntologyClasses.BaseClasses;
using Structure_Module;

namespace OutlookConnector_Module
{
    public class clsDataWork_OutlookItems
    {
        private clsLocalConfig objLocalConfig;

        private clsDBLevel objDBLevel_OutlookItems_Att;
        private clsDBLevel objDBLevel_OutlookItems_Rel1;
        private clsDBLevel objDBLevel_OutlookItems_Rel2;

        private clsAppDBLevel objAppDBLevel;

        public clsOntologyItem OItem_Result_OutlookItems { get; private set; }

        private clsDataWork_OutlookConnector objDataWork_OutlookConnector;

        public SortableBindingList<clsMailItem> MailItems = new SortableBindingList<clsMailItem>();
    
        public void GetData_OutlookItems()
        {
            OItem_Result_OutlookItems = objLocalConfig.Globals.LState_Nothing.Clone();

            var objOAL_Mail__Sended = new List<clsObjectAtt> { new clsObjectAtt {ID_Class = objLocalConfig.OItem_type_e_mail.GUID,
                ID_AttributeType = objLocalConfig.OItem_attribute_sended.GUID } };

            var objORL_Mail_LeftRight = new List<clsObjectRel> { 
                new clsObjectRel {ID_Parent_Object = objLocalConfig.OItem_type_e_mail.GUID,
                    ID_Parent_Other = objLocalConfig.OItem_type_email_address.GUID,
                    ID_RelationType = objLocalConfig.OItem_relationtype_von.GUID },
                new clsObjectRel {ID_Parent_Object = objLocalConfig.OItem_type_e_mail.GUID,
                    ID_Parent_Other = objLocalConfig.OItem_type_email_address.GUID,
                    ID_RelationType = objLocalConfig.OItem_relationtype_an.GUID} };

            var objORL_Mail_RightLeft = new List<clsObjectRel> {
                new clsObjectRel {ID_Parent_Other = objLocalConfig.OItem_type_e_mail.GUID,
                    ID_RelationType = objLocalConfig.OItem_relationtype_is.GUID,
                    ID_Parent_Object = objLocalConfig.OItem_type_outlook_item.GUID } };

            var objOItem_Result = objDBLevel_OutlookItems_Att.get_Data_ObjectAtt(objOAL_Mail__Sended, boolIDs: false);
            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                objOItem_Result = objDBLevel_OutlookItems_Rel1.get_Data_ObjectRel(objORL_Mail_LeftRight, boolIDs: false);
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    objOItem_Result = objDBLevel_OutlookItems_Rel2.get_Data_ObjectRel(objORL_Mail_RightLeft, boolIDs: false);
                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {

                                                                               
                    }
                    else
                    {
                        OItem_Result_OutlookItems = objOItem_Result;
                    }
                }
                else
                {
                    OItem_Result_OutlookItems = objOItem_Result;
                }
            }
            else
            {
                OItem_Result_OutlookItems = objOItem_Result;
            }
        }

        public void GetData_Documents()
        {
            List<clsAppDocuments> Documents = objAppDBLevel.GetData_Documents();

            var _MailItems = Documents.Select(p => new clsMailItem {ID_MailItem = p.Id,
            EntryID = p.Dict["EntryID"].ToString()}).ToList();
            //MailItems = new SortableBindingList<clsMailItem> (
        }

        public clsDataWork_OutlookItems(clsLocalConfig LocalConfig, clsDataWork_OutlookConnector DataWork_OutlookConnector)
        {
            objLocalConfig = LocalConfig;
            objDataWork_OutlookConnector = DataWork_OutlookConnector;
            Initialize();
        }

        private void Initialize()
        {

            objDBLevel_OutlookItems_Att = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_OutlookItems_Rel1 = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_OutlookItems_Rel2 = new clsDBLevel(objLocalConfig.Globals);
            objAppDBLevel = new clsAppDBLevel(objLocalConfig.Globals, objDataWork_OutlookConnector.Ontology, objLocalConfig.User);

            OItem_Result_OutlookItems = objLocalConfig.Globals.LState_Nothing.Clone();

        }

        
    }
}

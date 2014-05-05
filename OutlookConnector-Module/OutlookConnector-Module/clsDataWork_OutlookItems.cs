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
        private clsDBLevel objDBLevel_EmailAddress;

        private clsDBLevel objDBLevel_RefToMailItem;

        private clsAppDBLevel objAppDBLevel;

        public clsOntologyItem OItem_Result_OutlookItems { get; private set; }
        public clsOntologyItem OItem_Result_Documents { get; private set; }

        public List<clsObjectRel> OList_OutlookItems
        {
            get { return objDBLevel_OutlookItems_Rel2.OList_ObjectRel; }
        }

        private clsDataWork_OutlookConnector objDataWork_OutlookConnector;

        public List<clsObjectRel> OList_MailItem_LeftRight
        {
            get { return objDBLevel_OutlookItems_Rel1.OList_ObjectRel; }
        }

        public SortableBindingList<clsMailItem> MailItems = new SortableBindingList<clsMailItem>();

        public clsOntologyItem GetOItemByEntryID(string strEntryID)
        {
            var objOList_OItems = objDBLevel_OutlookItems_Rel2.OList_ObjectRel.Where(p => p.Name_Object == strEntryID).Select(p => new clsOntologyItem {GUID = p.ID_Other,
                Name = p.Name_Other,
                GUID_Parent = p.ID_Parent_Other,
                Type = objLocalConfig.Globals.Type_Object}).ToList();
            if (objOList_OItems.Any())
            {
                return objOList_OItems.First();
            }
            else
            {
                return null;
            }
        }

        public List<clsMailItem> GetData_EmailItemByRefOfOItem(clsOntologyItem OITem_Ref, clsOntologyItem OItem_RelationType, clsOntologyItem OItem_Direction)
        {
            var mailItems = new List<clsMailItem>();

            List<clsObjectRel> oRel_Ref_To_mailItems;

            if (OItem_Direction.GUID == objLocalConfig.Globals.Direction_LeftRight.GUID)
            {
                oRel_Ref_To_mailItems = new List<clsObjectRel> 
                {
                    new clsObjectRel 
                    {
                        ID_Object = OITem_Ref.GUID,
                        ID_RelationType = OItem_RelationType.GUID,
                        ID_Parent_Other = objLocalConfig.OItem_type_e_mail.GUID 
                    } 
                };

            }
            else
            {
                oRel_Ref_To_mailItems = new List<clsObjectRel> 
                {
                    new clsObjectRel 
                    {
                        ID_Other = OITem_Ref.GUID,
                        ID_RelationType = OItem_RelationType.GUID,
                        ID_Parent_Object = objLocalConfig.OItem_type_e_mail.GUID 
                    } 
                };
            }

            var objOItem_Result = objDBLevel_RefToMailItem.get_Data_ObjectRel(oRel_Ref_To_mailItems, boolIDs: false);

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                if (objDBLevel_RefToMailItem.OList_ObjectRel.Any())
                {
                    var objOList_MailItems = objDBLevel_RefToMailItem.OList_ObjectRel.Select(mi => new clsOntologyItem
                    {
                        GUID = OItem_Direction.GUID == objLocalConfig.Globals.Direction_LeftRight.GUID ? mi.ID_Other : mi.ID_Object,
                        Name = OItem_Direction.GUID == objLocalConfig.Globals.Direction_LeftRight.GUID ? mi.Name_Object : mi.Name_Other,
                        GUID_Parent = objLocalConfig.OItem_type_e_mail.GUID,
                        Type = objLocalConfig.Globals.Type_Object
                    }).ToList();

                    GetData_OutlookItems(objOList_MailItems);

                    if (OItem_Result_OutlookItems.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        mailItems = (from objMailItem in objOList_MailItems
                                     join objSended in objDBLevel_OutlookItems_Att.OList_ObjectAtt on objMailItem.GUID equals objSended.ID_Object
                                     join objVon in objDBLevel_OutlookItems_Rel1.OList_ObjectRel.Where(oi => oi.ID_RelationType == objLocalConfig.OItem_relationtype_von.GUID).ToList() on
                                        objMailItem.GUID equals objVon.ID_Object
                                     join objAn in objDBLevel_OutlookItems_Rel1.OList_ObjectRel.Where(oi => oi.ID_RelationType == objLocalConfig.OItem_relationtype_an.GUID).ToList() on
                                        objMailItem.GUID equals objAn.ID_Object
                                     select new clsMailItem
                                     {
                                         ID_OItem = objMailItem.GUID,
                                         Name_OItem = objMailItem.Name,
                                         CreationDate = (DateTime)objSended.Val_Date,
                                         SenderEmail = objVon.Name_Other,
                                         To = objAn.Name_Other
                                     }).ToList();
                    }
                    else
                    {
                        mailItems = null;
                    }
                }
            }
            else
            {
                mailItems = null;
            }

            return mailItems;
        }

        public void GetData_OutlookItems(List<clsOntologyItem> OList_MailItems = null)
        {
            OItem_Result_OutlookItems = objLocalConfig.Globals.LState_Nothing.Clone();

            List<clsObjectAtt> objOAL_Mail__Sended;
            if (OList_MailItems == null || !OList_MailItems.Any() || OList_MailItems.Count > 500)
            {
                objOAL_Mail__Sended = new List<clsObjectAtt> { new clsObjectAtt {ID_Class = objLocalConfig.OItem_type_e_mail.GUID,
                    ID_AttributeType = objLocalConfig.OItem_attribute_sended.GUID } };
            }
            else
            {
                objOAL_Mail__Sended = OList_MailItems.Select(mi => new clsObjectAtt { ID_Object = mi.GUID,
                    ID_AttributeType = objLocalConfig.OItem_attribute_sended.GUID } ).ToList();
                
                    
                
            }


            List<clsObjectRel> objORL_Mail_LeftRight;

            if (OList_MailItems == null || !OList_MailItems.Any() || OList_MailItems.Count > 500)
            {
                objORL_Mail_LeftRight = new List<clsObjectRel> { 
                    new clsObjectRel {ID_Parent_Object = objLocalConfig.OItem_type_e_mail.GUID,
                        ID_Parent_Other = objLocalConfig.OItem_type_email_address.GUID,
                        ID_RelationType = objLocalConfig.OItem_relationtype_von.GUID },
                    new clsObjectRel {ID_Parent_Object = objLocalConfig.OItem_type_e_mail.GUID,
                        ID_Parent_Other = objLocalConfig.OItem_type_email_address.GUID,
                        ID_RelationType = objLocalConfig.OItem_relationtype_an.GUID} };
            }
            else
            {
                objORL_Mail_LeftRight = OList_MailItems.Select(mi => new clsObjectRel
                {
                    ID_Object = mi.GUID,
                    ID_Parent_Other = objLocalConfig.OItem_type_email_address.GUID,
                    ID_RelationType = objLocalConfig.OItem_relationtype_von.GUID
                }).ToList();

                objORL_Mail_LeftRight.AddRange(OList_MailItems.Select(mi => new clsObjectRel
                {
                    ID_Object = mi.GUID,
                    ID_Parent_Other = objLocalConfig.OItem_type_email_address.GUID,
                    ID_RelationType = objLocalConfig.OItem_relationtype_an.GUID
                }));



            }

            List<clsObjectRel> objORL_Mail_RightLeft;

            if (OList_MailItems == null || !OList_MailItems.Any() || OList_MailItems.Count > 500)
            {
                objORL_Mail_RightLeft = new List<clsObjectRel> {
                new clsObjectRel {ID_Parent_Other = objLocalConfig.OItem_type_e_mail.GUID,
                    ID_RelationType = objLocalConfig.OItem_relationtype_is.GUID,
                    ID_Parent_Object = objLocalConfig.OItem_type_outlook_item.GUID } };
            }
            else
            {
                objORL_Mail_RightLeft = OList_MailItems.Select(mi => new clsObjectRel { ID_Other = mi.GUID,
                    ID_RelationType = objLocalConfig.OItem_relationtype_is.GUID,
                    ID_Parent_Object = objLocalConfig.OItem_type_outlook_item.GUID }).ToList();



            }

            

            var objOItem_Result = objDBLevel_OutlookItems_Att.get_Data_ObjectAtt(objOAL_Mail__Sended, boolIDs: false);
            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                objOItem_Result = objDBLevel_OutlookItems_Rel1.get_Data_ObjectRel(objORL_Mail_LeftRight, boolIDs: false);
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    objOItem_Result = objDBLevel_OutlookItems_Rel2.get_Data_ObjectRel(objORL_Mail_RightLeft, boolIDs: false);
                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {

                        OItem_Result_OutlookItems = objOItem_Result;                                                
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

        public void GetData_Documents(List<clsOntologyItem> OList_MailItems = null)
        {
            OItem_Result_Documents = objLocalConfig.Globals.LState_Nothing.Clone();

            GetData_OutlookItems(OList_MailItems);
            if (OItem_Result_OutlookItems.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                List<clsAppDocuments> Documents = objAppDBLevel.GetData_Documents();

                var _MailItems = (from objDoc in Documents.ToList()
                                  join objOutlookItem in objDBLevel_OutlookItems_Rel2.OList_ObjectRel on objDoc.Dict["EntryID"].ToString().ToLower() equals objOutlookItem.Name_Object.ToLower() into objOutlookItems
                                  from objOutlookItem in objOutlookItems.DefaultIfEmpty()
                                  select new clsMailItem 
                                  {
                                        ID_MailItem = objDoc.Id,
                                        EntryID = objDoc.Dict["EntryID"].ToString(),
                                        CreationDate = objDoc.Dict["CreationDate"] != null ? (DateTime)objDoc.Dict["CreationDate"] : new DateTime(),
                                        SenderEmail = objDoc.Dict["SenderEmailAddress"] != null ? objDoc.Dict["SenderEmailAddress"].ToString() : null,
                                        SenderName = objDoc.Dict["SenderName"] != null ? objDoc.Dict["SenderName"].ToString() : null,
                                        Subject = objDoc.Dict["Subject"] != null ? objDoc.Dict["Subject"].ToString() : null,
                                        To = objDoc.Dict["To"] != null ? objDoc.Dict["To"].ToString() : null,
                                        SemItemPresent = objOutlookItem != null ? true : false,
                                        ID_OItem = objOutlookItem != null ? objOutlookItem.ID_Other : null,
                                        Name_OItem = objOutlookItem != null ? objOutlookItem.Name_Other : null
                                    }).ToList();    

                
                MailItems = new SortableBindingList<clsMailItem>(_MailItems);
                OItem_Result_Documents = objLocalConfig.Globals.LState_Success.Clone();
            }
            else
            {
                OItem_Result_Documents = OItem_Result_Documents.Clone();
            }
            
            
            
        }

        public clsDataWork_OutlookItems(clsLocalConfig LocalConfig, clsDataWork_OutlookConnector DataWork_OutlookConnector)
        {
            objLocalConfig = LocalConfig;
            objDataWork_OutlookConnector = DataWork_OutlookConnector;
            Initialize();
        }

        public clsDataWork_OutlookItems(clsGlobals Globals, clsOntologyItem OItem_User)
        {
            objLocalConfig = new clsLocalConfig(Globals);
            objLocalConfig.User = OItem_User;
            objDataWork_OutlookConnector = new clsDataWork_OutlookConnector(objLocalConfig);
            Initialize();
        }

        public List<clsOntologyItem> GetData_EmailAddress(string strEmailAddress)
        {
            var objOList_Objects = new List<clsOntologyItem> { new clsOntologyItem {Name = strEmailAddress,
                GUID_Parent = objLocalConfig.OItem_type_email_address.GUID}};

            var objOList_Result = new List<clsOntologyItem>();

            var objOItem_Result =  objDBLevel_EmailAddress.get_Data_Objects(objOList_Objects,boolExact:true);

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                objOList_Result = objDBLevel_EmailAddress.OList_Objects;
            }
            else
            {
                objOList_Result = null;
            }

            return objOList_Result;

        }
        private void Initialize()
        {

            objDBLevel_OutlookItems_Att = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_OutlookItems_Rel1 = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_OutlookItems_Rel2 = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_EmailAddress = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_RefToMailItem = new clsDBLevel(objLocalConfig.Globals);

            objAppDBLevel = new clsAppDBLevel(objLocalConfig.Globals, objDataWork_OutlookConnector.Ontology, objLocalConfig.User);

            OItem_Result_OutlookItems = objLocalConfig.Globals.LState_Nothing.Clone();
            OItem_Result_Documents = objLocalConfig.Globals.LState_Nothing.Clone();
        }

        
    }
}

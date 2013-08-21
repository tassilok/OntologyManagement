using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Ontolog_Module;

namespace Office_Module
{
    class clsDataWork_Documents
    {
        private clsLocalConfig objLocalConfig;

        private clsDBLevel objDBLevel_ManagementDocuments;
        private clsDBLevel objDBLevel_MD__DateTimeStampChanged;
        private clsDBLevel objDBLevel_MD_To_DocumentType;
        private clsDBLevel objDBLevel_MD_To_File;
        private clsDBLevel objDBLevel_MD_To_OItem;

        private Thread objThread_ManagedDocuments;
        private Thread objThread_MD__DateTimeStampChanged;
        private Thread objThread_MD_To_DocumentType;
        private Thread objThread_MD_To_File;
        private Thread objThread_MD_To_OItem;

        public List<clsOntologyItem> OList_OItems { get; set; }

        public clsOntologyItem OItem_Result_ManagedDocuments { get; set; }
        public clsOntologyItem OItem_Result_MD__DateTimeStampChanged { get; set; }
        public clsOntologyItem OItem_Result_MD_To_DocumentType { get; set; }
        public clsOntologyItem OItem_Result_MD_To_File { get; set; }
        public clsOntologyItem OItem_Result_MD_To_OItem { get; set; }

        public clsOntologyItem isPresent_OItems()
        {
            clsOntologyItem objOItem_Result;

            if (OItem_Result_ManagedDocuments.GUID == objLocalConfig.Globals.LState_Success.GUID &&
                OItem_Result_MD_To_File.GUID == objLocalConfig.Globals.LState_Success.GUID &&
                OItem_Result_MD_To_OItem.GUID == objLocalConfig.Globals.LState_Success.GUID &&
                OItem_Result_MD_To_DocumentType.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                objOItem_Result = objLocalConfig.Globals.LState_Success;
            }
            else if (OItem_Result_ManagedDocuments.GUID == objLocalConfig.Globals.LState_Nothing.GUID ||
                OItem_Result_MD_To_File.GUID == objLocalConfig.Globals.LState_Nothing.GUID ||
                OItem_Result_MD_To_OItem.GUID == objLocalConfig.Globals.LState_Nothing.GUID ||
                OItem_Result_MD_To_DocumentType.GUID == objLocalConfig.Globals.LState_Nothing.GUID)
            {
                objOItem_Result = objLocalConfig.Globals.LState_Nothing;
            }
            else
            {
                objOItem_Result = objLocalConfig.Globals.LState_Error;
            }

            return objOItem_Result;
        }

        public clsOntologyItem GetOItems()
        {

            clsOntologyItem objOItem_Result;

            if (OList_OItems == null)
            {
                OList_OItems = new List<clsOntologyItem>();
            }
            else
            {
                OList_OItems.Clear();
            }

            if (isPresent_OItems().GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                OList_OItems = (from ManagedDoc in objDBLevel_ManagementDocuments.OList_Objects
                                join Files in objDBLevel_MD_To_File.OList_ObjectRel on ManagedDoc.GUID equals Files.ID_Object
                                join DocTypes in objDBLevel_MD_To_DocumentType.OList_ObjectRel on ManagedDoc.GUID equals DocTypes.ID_Object
                                join OItems in objDBLevel_MD_To_OItem.OList_ObjectRel on ManagedDoc.GUID equals OItems.ID_Object
                                select new clsOntologyItem
                                {
                                    GUID = OItems.ID_Other,
                                    Name = OItems.Name_Object,
                                    GUID_Parent = OItems.ID_Parent_Other,
                                    Type = OItems.Ontology
                                }).ToList();

                objOItem_Result = objLocalConfig.Globals.LState_Success;
            }
            else if (isPresent_OItems().GUID == objLocalConfig.Globals.LState_Nothing.GUID)
            {
                objOItem_Result = objLocalConfig.Globals.LState_Nothing;
            }
            else
            {
                objOItem_Result = objLocalConfig.Globals.LState_Error;
            }



            return objOItem_Result;
        }

        public clsDataWork_Documents(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;

            set_DBConnection();
        }

        public clsOntologyItem GetData()
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success;

            try
            {
                objThread_ManagedDocuments.Abort();
            }
            catch(Exception e)
            {
            }

            try
            {
                objThread_MD__DateTimeStampChanged.Abort();
            }
            catch (Exception e)
            {
            }

            try
            {
                objThread_MD_To_DocumentType.Abort();
            }
            catch (Exception e)
            {
            }

            try
            {
                objThread_MD_To_File.Abort();
            }
            catch (Exception e)
            {
            }

            try
            {
                objThread_MD_To_OItem.Abort();
            }
            catch (Exception e)
            {
            }

            OItem_Result_ManagedDocuments = objLocalConfig.Globals.LState_Nothing;
            OItem_Result_MD__DateTimeStampChanged = objLocalConfig.Globals.LState_Nothing;
            OItem_Result_MD_To_DocumentType = objLocalConfig.Globals.LState_Nothing;
            OItem_Result_MD_To_File = objLocalConfig.Globals.LState_Nothing;
            OItem_Result_MD_To_OItem = objLocalConfig.Globals.LState_Nothing;
            
            objThread_ManagedDocuments = new Thread(GetData_ManagedDocuments);
            objThread_MD__DateTimeStampChanged = new Thread(GetData_MD__DateTimeStampChange);
            objThread_MD_To_DocumentType = new Thread(GetData_MD_To_DocumentType);
            objThread_MD_To_File = new Thread(GetData_MD_To_File);
            objThread_MD_To_OItem = new Thread(GetData_MD_To_OItem);

            objThread_ManagedDocuments.Start();
            objThread_MD__DateTimeStampChanged.Start();
            objThread_MD_To_DocumentType.Start();
            objThread_MD_To_File.Start();
            objThread_MD_To_OItem.Start();

            return objOItem_Result;
        }

        private void set_DBConnection()
        {
            objDBLevel_ManagementDocuments = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_MD__DateTimeStampChanged = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_MD_To_DocumentType = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_MD_To_File = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_MD_To_OItem = new clsDBLevel(objLocalConfig.Globals);
        }

        private void GetData_ManagedDocuments()
        {
            var objOList_ManagedDocuments = new List<clsOntologyItem>();

            OItem_Result_ManagedDocuments = objLocalConfig.Globals.LState_Nothing;

            objOList_ManagedDocuments.Add(new clsOntologyItem(null, 
                                                              null, 
                                                              objLocalConfig.OItem_Type_Managed_Document.GUID,
                                                              objLocalConfig.Globals.Type_Object));


            OItem_Result_ManagedDocuments = objDBLevel_ManagementDocuments.get_Data_Objects(objOList_ManagedDocuments);
        }

        private void GetData_MD__DateTimeStampChange()
        {
            var objOAList_MD__DateTimeStampChange = new List<clsObjectAtt>();

            OItem_Result_MD__DateTimeStampChanged = objLocalConfig.Globals.LState_Nothing;

            objOAList_MD__DateTimeStampChange.Add(new clsObjectAtt(null,
                                                                   null,
                                                                   objLocalConfig.OItem_Type_Managed_Document.GUID,
                                                                   objLocalConfig.OItem_Attribute_DateTimeStamp__Change_.GUID,
                                                                   null));

            OItem_Result_MD__DateTimeStampChanged = objDBLevel_MD__DateTimeStampChanged.get_Data_ObjectAtt(objOAList_MD__DateTimeStampChange,
                                                                                                      boolIDs:false);
        }

        private void GetData_MD_To_DocumentType()
        {
            var objORList_MD_To_DocumentType = new List<clsObjectRel>();

            OItem_Result_MD_To_DocumentType = objLocalConfig.Globals.LState_Nothing;

            objORList_MD_To_DocumentType.Add(new clsObjectRel(null,
                                                              objLocalConfig.OItem_Type_Managed_Document.GUID,
                                                              null,
                                                              objLocalConfig.OItem_Type_Document_Type__managed_.GUID,
                                                              objLocalConfig.OItem_RelationType_is_of_Type.GUID,
                                                              objLocalConfig.Globals.Type_Object,
                                                              null,
                                                              null));

            OItem_Result_MD_To_DocumentType = objDBLevel_MD_To_DocumentType.get_Data_ObjectRel(objORList_MD_To_DocumentType,
                                                                                               boolIDs: false);
        }

        private void GetData_MD_To_File()
        {
            var objORList_MD_To_File = new List<clsObjectRel>();

            OItem_Result_MD_To_File = objLocalConfig.Globals.LState_Nothing;

            objORList_MD_To_File.Add(new clsObjectRel(null,
                                                      objLocalConfig.OItem_Type_Managed_Document.GUID,
                                                      null,
                                                      objLocalConfig.OItem_Type_File.GUID,
                                                      objLocalConfig.OItem_RelationType_belonging_Document.GUID,
                                                      objLocalConfig.Globals.Type_Object,
                                                      null,
                                                      null));

            OItem_Result_MD_To_File = objDBLevel_MD_To_File.get_Data_ObjectRel(objORList_MD_To_File,
                                                                               boolIDs: false);
        }

        private void GetData_MD_To_OItem()
        {
            var objORList_MD_To_OItem = new List<clsObjectRel>();

            OItem_Result_MD_To_OItem = objLocalConfig.Globals.LState_Nothing;

            objORList_MD_To_OItem.Add(new clsObjectRel(null,
                                                      objLocalConfig.OItem_Type_Managed_Document.GUID,
                                                      null,
                                                      null,
                                                      objLocalConfig.OItem_RelationType_belongsTo.GUID,
                                                      null,
                                                      null,
                                                      null));

            OItem_Result_MD_To_OItem = objDBLevel_MD_To_OItem.get_Data_ObjectRel(objORList_MD_To_OItem,
                                                                               boolIDs: false);
        }

    }
}



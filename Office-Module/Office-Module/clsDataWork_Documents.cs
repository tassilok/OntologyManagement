using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Ontolog_Module;

namespace Office_Module
{
    public class clsDataWork_Documents
    {
        private clsLocalConfig objLocalConfig;

        private clsDBLevel objDBLevel_ManagementDocuments;
        private clsDBLevel objDBLevel_MD__DateTimeStampChanged;
        private clsDBLevel objDBLevel_MD_To_DocumentType;
        private clsDBLevel objDBLevel_MD_To_File;
        private clsDBLevel objDBLevel_MD_To_OItem;
        private clsDBLevel objDBLevel_Classes;
        private clsDBLevel objDBLevel_Documents;
        private clsDBLevel objDBLevel_Templates;

        private Thread objThread_ManagedDocuments;
        private Thread objThread_MD__DateTimeStampChanged;
        private Thread objThread_MD_To_DocumentType;
        private Thread objThread_MD_To_File;
        private Thread objThread_MD_To_OItem;

        public SortableBindingList<clsDocument> OList_Documents { get; set; }
        public List<clsOntologyItem> OList_Classes { get; set; }

        public clsOntologyItem OItem_Result_ManagedDocuments { get; set; }
        public clsOntologyItem OItem_Result_MD__DateTimeStampChanged { get; set; }
        public clsOntologyItem OItem_Result_MD_To_DocumentType { get; set; }
        public clsOntologyItem OItem_Result_MD_To_File { get; set; }
        public clsOntologyItem OItem_Result_MD_To_OItem { get; set; }

        private clsOntologyItem OItem_Document;

        public clsOntologyItem isPresent_Documents()
        {
            clsOntologyItem objOItem_Result;

            if (OItem_Result_ManagedDocuments.GUID == objLocalConfig.Globals.LState_Success.GUID &&
                OItem_Result_MD__DateTimeStampChanged.GUID == objLocalConfig.Globals.LState_Success.GUID &&
                OItem_Result_MD_To_File.GUID == objLocalConfig.Globals.LState_Success.GUID &&
                OItem_Result_MD_To_OItem.GUID == objLocalConfig.Globals.LState_Success.GUID &&
                OItem_Result_MD_To_DocumentType.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                objOItem_Result = objLocalConfig.Globals.LState_Success;
            }
            else if (OItem_Result_ManagedDocuments.GUID == objLocalConfig.Globals.LState_Nothing.GUID ||
                OItem_Result_MD__DateTimeStampChanged.GUID == objLocalConfig.Globals.LState_Nothing.GUID ||
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

        public clsDocument GetData_DocumentData(clsOntologyItem OItem_Document)
        {
            this.OItem_Document = OItem_Document;
            clsDocument ItemDocument;
            OItem_Result_ManagedDocuments = objLocalConfig.Globals.LState_Success;
            GetData_MD__DateTimeStampChange();
            GetData_MD_To_DocumentType();
            GetData_MD_To_File();
            GetData_MD_To_OItem();
            if (isPresent_Documents().GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                OList_Documents = new SortableBindingList<clsDocument>((from Files in objDBLevel_MD_To_File.OList_ObjectRel 
                                                                        where Files.ID_Object == this.OItem_Document.GUID
                                                                        join ChangeDate in objDBLevel_MD__DateTimeStampChanged.OList_ObjectAtt on Files.ID_Object equals this.OItem_Document.GUID into ChangeDates
                                                                        from ChangeDate in ChangeDates.DefaultIfEmpty()
                                                                        join DocTypes in objDBLevel_MD_To_DocumentType.OList_ObjectRel on Files.ID_Object equals DocTypes.ID_Object
                                                                        join OItems in objDBLevel_MD_To_OItem.OList_ObjectRel on Files.ID_Object equals OItems.ID_Object
                                                                        select new clsDocument
                                                                        {
                                                                            ID_Attribute_DateTimeStampChange = (ChangeDate != null ? ChangeDate.ID_Attribute : null),
                                                                            ID_Object_DateTimeStampChange = (ChangeDate != null ? ChangeDate.ID_Object : null),
                                                                            ID_Parent_Object_DateTimeStampChange = (ChangeDate != null ? ChangeDate.ID_Class : null),
                                                                            DateTimeStampChanged = (ChangeDate != null ? ChangeDate.Val_Date : null),
                                                                            ID_Document = this.OItem_Document.GUID,
                                                                            Name_Document = this.OItem_Document.Name,
                                                                            ID_Parent_Document = this.OItem_Document.GUID_Parent,
                                                                            ID_DocumentType = DocTypes.ID_Other,
                                                                            Name_DocumentType = DocTypes.Name_Other,
                                                                            ID_Parent_DocumentType = DocTypes.ID_Parent_Other,
                                                                            ID_File = Files.ID_Other,
                                                                            Name_File = Files.Name_Other,
                                                                            ID_Parent_File = Files.ID_Parent_Other,
                                                                            ID_Ref = OItems.ID_Other,
                                                                            Name_Ref = OItems.Name_Other,
                                                                            ID_Parent_Ref = OItems.ID_Parent_Other,
                                                                            Ontology_Ref = OItems.Ontology
                                                                        }).ToList());

                if (OList_Documents.Any())
                {
                    ItemDocument = OList_Documents.First();
                }
                else
                {
                    ItemDocument = null;
                }
            }
            else
            {
                ItemDocument = new clsDocument() { OItem_Result = objLocalConfig.Globals.LState_Error };
            }

            return ItemDocument;
        }

        public clsOntologyItem GetData_Documents()
        {

            clsOntologyItem objOItem_Result;

            if (isPresent_Documents().GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                OList_Documents = new SortableBindingList<clsDocument>((from ManagedDoc in objDBLevel_ManagementDocuments.OList_Objects
                                   join ChangeDate in objDBLevel_MD__DateTimeStampChanged.OList_ObjectAtt on ManagedDoc.GUID equals ChangeDate.ID_Object into ChangeDates
                                   from ChangeDate in ChangeDates.DefaultIfEmpty()
                                   join Files in objDBLevel_MD_To_File.OList_ObjectRel on ManagedDoc.GUID equals Files.ID_Object
                                   join DocTypes in objDBLevel_MD_To_DocumentType.OList_ObjectRel on ManagedDoc.GUID equals DocTypes.ID_Object
                                   join OItems in objDBLevel_MD_To_OItem.OList_ObjectRel on ManagedDoc.GUID equals OItems.ID_Object
                                   select new clsDocument
                                   {
                                       ID_Attribute_DateTimeStampChange = (ChangeDate != null ? ChangeDate.ID_Attribute : null) ,
                                       ID_Object_DateTimeStampChange = (ChangeDate != null ? ChangeDate.ID_Object : null),
                                       ID_Parent_Object_DateTimeStampChange = (ChangeDate != null ? ChangeDate.ID_Class : null),
                                       DateTimeStampChanged = (ChangeDate != null ? ChangeDate.Val_Date : null),
                                       ID_Document = ManagedDoc.GUID,
                                       Name_Document = ManagedDoc.Name,
                                       ID_Parent_Document = ManagedDoc.GUID_Parent,
                                       ID_DocumentType = DocTypes.ID_Other,
                                       Name_DocumentType = DocTypes.Name_Other,
                                       ID_Parent_DocumentType = DocTypes.ID_Parent_Other,
                                       ID_File = Files.ID_Other,
                                       Name_File = Files.Name_Other,
                                       ID_Parent_File = Files.ID_Parent_Other,
                                       ID_Ref = OItems.ID_Other,
                                       Name_Ref = OItems.Name_Other,
                                       ID_Parent_Ref = OItems.ID_Parent_Other,
                                       Ontology_Ref = OItems.Ontology
                                   }).ToList());

                objOItem_Result = objLocalConfig.Globals.LState_Success;
            }
            else if (isPresent_Documents().GUID == objLocalConfig.Globals.LState_Nothing.GUID)
            {
                objOItem_Result = objLocalConfig.Globals.LState_Nothing;
            }
            else
            {
                objOItem_Result = objLocalConfig.Globals.LState_Error;
            }



            return objOItem_Result;
        }

        public clsOntologyItem GetData_Classes()
        {
            int intCount;
            clsOntologyItem objOItem_Result;
            List<clsOntologyItem> objOList_ClassParObjects = new List<clsOntologyItem>();

            OList_Classes = (from obj in OList_Documents
                                     where obj.Ontology_Ref == objLocalConfig.Globals.Type_Object
                                     group obj by obj.ID_Parent_Ref into objGroup
                                     select new clsOntologyItem
                                     {
                                         GUID = objGroup.Key,
                                         Type = objLocalConfig.Globals.Type_Object
                                     }).ToList();

            objOItem_Result = objDBLevel_Classes.get_Data_Classes(OList_Classes);

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                OList_Classes = (from obj in objDBLevel_Classes.OList_Classes
                                         select new clsOntologyItem
                                         {
                                             GUID = obj.GUID,
                                             Name = obj.Name,
                                             GUID_Parent = obj.GUID_Parent,
                                             Type = obj.Type
                                         }).ToList();
                    
                do
                {
                    objOList_ClassParObjects = (from obj in OList_Classes
                                                group obj by obj.GUID_Parent into ClassParents
                                                select new clsOntologyItem
                                                {
                                                    GUID = ClassParents.Key,
                                                    Type = objLocalConfig.Globals.Type_Class
                                                }).ToList();

                    objOItem_Result = objDBLevel_Classes.get_Data_Classes(objOList_ClassParObjects);


                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        intCount = OList_Classes.Count;
                        OList_Classes = OList_Classes.Concat((from obj in objDBLevel_Classes.OList_Classes
                                                                join objExist in OList_Classes on obj.GUID equals objExist.GUID into GroupExists
                                                                from objExist in GroupExists.DefaultIfEmpty()
                                                                where objExist == null
                                                                select new clsOntologyItem
                                                                {
                                                                    GUID = obj.GUID,
                                                                    Name = obj.Name,
                                                                    GUID_Parent = obj.GUID_Parent,
                                                                    Type = obj.Type
                                                                }).ToList()).ToList();
                    }
                    else
                    {
                        intCount = 0;
                    }
                        


                } while (intCount < OList_Classes.Count);
                    

            }
            
            return objOItem_Result;
        }

        

        public clsDataWork_Documents(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;

            set_DBConnection();
        }

        public clsDataWork_Documents(clsGlobals Globals)
        {
            objLocalConfig = new clsLocalConfig(Globals);

            set_DBConnection();
        }

        public clsOntologyItem GetData()
        {
            OItem_Document = null;
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

        public clsOntologyItem GetClassOfObject(clsOntologyItem OItem_Object)
        {
            clsOntologyItem objOItem_Class = new clsOntologyItem();
            clsOntologyItem objOItem_Result;

            List<clsOntologyItem> objOList_ClassOfObject = new List<clsOntologyItem>();

            objOList_ClassOfObject.Add(new clsOntologyItem(OItem_Object.GUID_Parent, objLocalConfig.Globals.Type_Class));

            objOItem_Result = objDBLevel_Documents.get_Data_Classes(objOList_ClassOfObject);

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                if (objDBLevel_Documents.OList_Classes.Any())
                {
                    objOItem_Class = objDBLevel_Documents.OList_Classes.First();
                }
                else
                {
                    objOItem_Class = null;
                }
            }
            else
            {
                objOItem_Class = null;
            }

            return objOItem_Class;
        }

        private void set_DBConnection()
        {
            objDBLevel_ManagementDocuments = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_MD__DateTimeStampChanged = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_MD_To_DocumentType = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_MD_To_File = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_MD_To_OItem = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Classes = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Documents = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Templates = new clsDBLevel(objLocalConfig.Globals);
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

            if (OItem_Document == null)
            {

                objOAList_MD__DateTimeStampChange.Add(new clsObjectAtt(null,
                                                                       null,
                                                                       objLocalConfig.OItem_Type_Managed_Document.GUID,
                                                                       objLocalConfig.OItem_Attribute_DateTimeStamp__Change_.GUID,
                                                                       null));
            }
            else
            {
                objOAList_MD__DateTimeStampChange.Add(new clsObjectAtt(null,
                                                                       OItem_Document.GUID,
                                                                       null,
                                                                       objLocalConfig.OItem_Attribute_DateTimeStamp__Change_.GUID,
                                                                       null));
            }

            OItem_Result_MD__DateTimeStampChanged = objDBLevel_MD__DateTimeStampChanged.get_Data_ObjectAtt(objOAList_MD__DateTimeStampChange,
                                                                                                      boolIDs:false);
        }

        private void GetData_MD_To_DocumentType()
        {
            var objORList_MD_To_DocumentType = new List<clsObjectRel>();

            OItem_Result_MD_To_DocumentType = objLocalConfig.Globals.LState_Nothing;

            if (OItem_Document == null)
            {
                objORList_MD_To_DocumentType.Add(new clsObjectRel(null,
                                                              objLocalConfig.OItem_Type_Managed_Document.GUID,
                                                              null,
                                                              objLocalConfig.OItem_Type_Document_Type__managed_.GUID,
                                                              objLocalConfig.OItem_RelationType_is_of_Type.GUID,
                                                              objLocalConfig.Globals.Type_Object,
                                                              null,
                                                              null));
            }
            else
            {
                objORList_MD_To_DocumentType.Add(new clsObjectRel(OItem_Document.GUID,
                                                              null,
                                                              null,
                                                              objLocalConfig.OItem_Type_Document_Type__managed_.GUID,
                                                              objLocalConfig.OItem_RelationType_is_of_Type.GUID,
                                                              objLocalConfig.Globals.Type_Object,
                                                              null,
                                                              null));
            }

            

            OItem_Result_MD_To_DocumentType = objDBLevel_MD_To_DocumentType.get_Data_ObjectRel(objORList_MD_To_DocumentType,
                                                                                               boolIDs: false);
        }

        private void GetData_MD_To_File()
        {
            var objORList_MD_To_File = new List<clsObjectRel>();

            OItem_Result_MD_To_File = objLocalConfig.Globals.LState_Nothing;

            if (OItem_Document == null)
            {
                objORList_MD_To_File.Add(new clsObjectRel(null,
                                                      objLocalConfig.OItem_Type_Managed_Document.GUID,
                                                      null,
                                                      objLocalConfig.OItem_Type_File.GUID,
                                                      objLocalConfig.OItem_RelationType_belonging_Document.GUID,
                                                      objLocalConfig.Globals.Type_Object,
                                                      null,
                                                      null));
            }
            else
            {
                objORList_MD_To_File.Add(new clsObjectRel(OItem_Document.GUID,
                                                      null,
                                                      null,
                                                      objLocalConfig.OItem_Type_File.GUID,
                                                      objLocalConfig.OItem_RelationType_belonging_Document.GUID,
                                                      objLocalConfig.Globals.Type_Object,
                                                      null,
                                                      null));
            }
            

            OItem_Result_MD_To_File = objDBLevel_MD_To_File.get_Data_ObjectRel(objORList_MD_To_File,
                                                                               boolIDs: false);
        }

        private void GetData_MD_To_OItem()
        {
            var objORList_MD_To_OItem = new List<clsObjectRel>();

            OItem_Result_MD_To_OItem = objLocalConfig.Globals.LState_Nothing;

            if (OItem_Document == null)
            {
                objORList_MD_To_OItem.Add(new clsObjectRel(null,
                                                      objLocalConfig.OItem_Type_Managed_Document.GUID,
                                                      null,
                                                      null,
                                                      objLocalConfig.OItem_RelationType_belongsTo.GUID,
                                                      null,
                                                      null,
                                                      null));
            }
            else
            {
                objORList_MD_To_OItem.Add(new clsObjectRel(OItem_Document.GUID,
                                                      null,
                                                      null,
                                                      null,
                                                      objLocalConfig.OItem_RelationType_belongsTo.GUID,
                                                      null,
                                                      null,
                                                      null));
            }
            

            OItem_Result_MD_To_OItem = objDBLevel_MD_To_OItem.get_Data_ObjectRel(objORList_MD_To_OItem,
                                                                               boolIDs: false);
        }


        public clsOntologyItem GetStandardTemplate()
        {
            clsOntologyItem objOItem_Result;
            clsOntologyItem objOItem_File;
            List<clsObjectRel> objORel_WordTemplate = new List<clsObjectRel>();

            objORel_WordTemplate.Add(new clsObjectRel()
            {
                ID_Object = objLocalConfig.OItem_BaseConfig.GUID,
                ID_Parent_Other = objLocalConfig.OItem_Type_Word_Templates.GUID,
                ID_RelationType = objLocalConfig.OItem_RelationType_Standard.GUID
            });

            objOItem_Result = objDBLevel_Templates.get_Data_ObjectRel(objORel_WordTemplate);

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                if (objDBLevel_Templates.OList_ObjectRel_ID.Any())
                {
                    objORel_WordTemplate.Clear();
                    objORel_WordTemplate.Add(new clsObjectRel()
                    {
                        ID_Object = objDBLevel_Templates.OList_ObjectRel_ID.First().ID_Other,
                        ID_Parent_Other = objLocalConfig.OItem_Type_File.GUID,
                        ID_RelationType = objLocalConfig.OItem_RelationType_is.GUID
                    });

                    objOItem_Result = objDBLevel_Templates.get_Data_ObjectRel(objORel_WordTemplate,
                                                                              boolIDs: false);
                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        if (objDBLevel_Templates.OList_ObjectRel.Any())
                        {
                            objOItem_File = new clsOntologyItem()
                            {
                                GUID = objDBLevel_Templates.OList_ObjectRel.First().ID_Other,
                                Name = objDBLevel_Templates.OList_ObjectRel.First().Name_Other,
                                GUID_Parent = objLocalConfig.OItem_Type_File.GUID,
                                Type = objLocalConfig.Globals.Type_Object
                            };

                        }
                        else
                        {
                            objOItem_File = null;
                        }
                    }
                    else
                    {
                        objOItem_File = null;
                    }
                }
                else
                {
                    objOItem_File = null;
                }
            }
            else
            {
                objOItem_File = null;
            }



            return objOItem_File;
        }

        public clsOntologyItem GetTemplate(clsOntologyItem objOItem_RefForTemplate)
        {

            clsOntologyItem objOItem_File;
            clsOntologyItem objOItem_Result;
            List<clsObjectRel> objORel_Templates = new List<clsObjectRel>();


            if (objOItem_RefForTemplate != null)
            {
                objORel_Templates.Add(new clsObjectRel()
                {
                    ID_Parent_Object = objOItem_RefForTemplate.GUID,
                    ID_Other = objOItem_RefForTemplate.GUID,
                    ID_RelationType = objLocalConfig.OItem_RelationType_used_for.GUID
                });

                objOItem_Result = objDBLevel_Templates.get_Data_ObjectRel(objORel_Templates,
                                                                          boolIDs: true);

                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    if (objDBLevel_Templates.OList_ClassRel.Any())
                    {
                        objORel_Templates.Clear();
                        objORel_Templates.Add(new clsObjectRel()
                        {
                            ID_Object = objDBLevel_Classes.OList_ObjectRel.First().ID_Object,
                            ID_Parent_Other = objLocalConfig.OItem_Type_File.GUID,
                            ID_RelationType = objLocalConfig.OItem_RelationType_is.GUID
                        });

                        objOItem_Result = objDBLevel_Templates.get_Data_ObjectRel(objORel_Templates,
                                                                                  boolIDs: false);

                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {
                            if (objDBLevel_Templates.OList_ObjectRel.Any())
                            {
                                objOItem_File = new clsOntologyItem()
                                {
                                    GUID = objDBLevel_Templates.OList_ObjectRel.First().ID_Other,
                                    Name = objDBLevel_Templates.OList_ObjectRel.First().Name_Other,
                                    GUID_Parent = objLocalConfig.OItem_Type_File.GUID,
                                    Type = objLocalConfig.Globals.Type_Object
                                };

                            }
                            else
                            {
                                objOItem_File = null;
                            }
                        }
                        else
                        {
                            objOItem_File = null;
                        }

                    }
                    else
                    {
                        objOItem_File = null;
                    }
                    
                }
                else
                {
                    objOItem_File = null;
                }
            }
            else
            {
                objOItem_File = null;
            }

            

                    

            return objOItem_File;
        }

    }
}



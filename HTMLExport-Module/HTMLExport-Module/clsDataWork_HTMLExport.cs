using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ontology_Module;
using OntologyClasses.BaseClasses;
using Filesystem_Module;
using System.IO;

namespace HTMLExport_Module
{
    public class clsDataWork_HTMLExport
    {
        private clsLocalConfig objLocalConfig;

        private clsXML objXML;

        private clsDBLevel objDBLevel_Signs;
        private clsDBLevel objDBLevel_Folder;
        private clsDBLevel objDBLevel_XMLIntro;
        private clsDBLevel objDBLevel_Tag;

        private clsFileWork objFileWork;

        public clsOntologyItem OItem_Folder { get; set; }
        public clsOntologyItem OItem_XML { get; set; }
        public clsObjectAtt OItem_XMLText { get; set; }

        public string GetStart
        {
            get
            {
                var oRel_StartTag =
                    objDBLevel_Signs.OList_ObjectRel.FirstOrDefault(t => t.ID_RelationType == objLocalConfig.OItem_relationtype_tag_start.GUID);

                return oRel_StartTag != null ? oRel_StartTag.Name_Other : null;
            }
        }

        public string GetEndInit
        {
            get
            {
                var oRel_EndInit =
                    objDBLevel_Signs.OList_ObjectRel.FirstOrDefault(t => t.ID_RelationType == objLocalConfig.OItem_relationtype_tag_end_init.GUID);

                return oRel_EndInit != null ? oRel_EndInit.Name_Other : null;
            }
        }

        public string GetEnd
        {
            get
            {
                var oRel_End =
                    objDBLevel_Signs.OList_ObjectRel.FirstOrDefault(t => t.ID_RelationType == objLocalConfig.OItem_relationtype_tag_end.GUID);

                return oRel_End != null ? oRel_End.Name_Other : null;
            }
        }


        public clsOntologyItem GetHtmlTag(clsOntologyItem OItem_DoucmentType, int? intOrderId = null)
        {
            clsOntologyItem oItem_HTMLTag = null;
            var searchHtmlTag = new List<clsObjectRel>
                {
                    new clsObjectRel
                        {
                            ID_Other = OItem_DoucmentType.GUID,
                            ID_RelationType = objLocalConfig.OItem_relationtype_belongsto.GUID,
                            ID_Parent_Object = objLocalConfig.OItem_type_html_tags.GUID
                        }
                };

            var objOItem_Result = objDBLevel_Tag.get_Data_ObjectRel(searchHtmlTag, boolIDs: false);

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                List<clsOntologyItem> HTMLTags;
                    
                if (intOrderId == null)
                {
                    HTMLTags = objDBLevel_Tag.OList_ObjectRel.Select(ht => new clsOntologyItem
                    {
                        GUID = ht.ID_Object,
                        Name = ht.Name_Object,
                        GUID_Parent = ht.ID_Parent_Object,
                        Type = objLocalConfig.Globals.Type_Object
                    }).ToList();
                }
                else
                {
                    HTMLTags = objDBLevel_Tag.OList_ObjectRel.Where(ht => ht.OrderID == intOrderId).Select(ht => new clsOntologyItem
                    {
                        GUID = ht.ID_Object,
                        Name = ht.Name_Object,
                        GUID_Parent = ht.ID_Parent_Object,
                        Type = objLocalConfig.Globals.Type_Object
                    }).ToList();
                }
                    

                
                oItem_HTMLTag = HTMLTags.FirstOrDefault();
                

            }

            return oItem_HTMLTag;
        }

        public clsOntologyItem GetBaseData()
        {
            var objOItem_Result = GetSubData_Signs();

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                objOItem_Result = GetSubData_Folder();
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    objOItem_Result = GetSubData_XMLTextIntro();
                }
            }

            return objOItem_Result;
        }

        public clsOntologyItem GetSubData_Signs()
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            var searchSigns = new List<clsObjectRel>
                {
                    new clsObjectRel
                        {
                            ID_Object = objLocalConfig.OItem_object_baseconfig.GUID,
                            ID_Parent_Other = objLocalConfig.OItem_type_zeichen.GUID
                        }
                };

            objOItem_Result = objDBLevel_Signs.get_Data_ObjectRel(searchSigns, boolIDs: false);

            
            return objOItem_Result;
        }

        public clsOntologyItem GetSubData_Folder()
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            var searchFolder = new List<clsObjectRel>
                {
                    new clsObjectRel
                        {
                            ID_Object = objLocalConfig.OItem_object_baseconfig.GUID,
                            ID_RelationType = objLocalConfig.OItem_relationtype_export_to.GUID
                        }
                };

            objOItem_Result = objDBLevel_Folder.get_Data_ObjectRel(searchFolder, boolIDs: false);

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                OItem_Folder = objDBLevel_Folder.OList_ObjectRel.Select(f => new clsOntologyItem
                    {
                        GUID = f.ID_Other,
                        Name = f.Name_Other,
                        GUID_Parent = f.ID_Parent_Other,
                        Type = objLocalConfig.Globals.Type_Object
                    }).FirstOrDefault();

                if (OItem_Folder != null)
                {
                    OItem_Folder.Additional1 = objFileWork.get_Path_FileSystemObject(OItem_Folder);
                    if (string.IsNullOrEmpty(OItem_Folder.Additional1))
                    {
                        objOItem_Result = objLocalConfig.Globals.LState_Error.Clone();
                    }
                }
                else
                {
                    objOItem_Result = objLocalConfig.Globals.LState_Error.Clone();

                }

            }

            return objOItem_Result;
        }

        public clsOntologyItem GetSubData_XMLTextIntro()
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            var searchXML = new List<clsObjectRel>
                {
                    new clsObjectRel
                        {
                            ID_Object = objLocalConfig.OItem_object_baseconfig.GUID,
                            ID_RelationType = objLocalConfig.OItem_relationtype_intro.GUID,
                            ID_Parent_Other = objLocalConfig.OItem_type_xml.GUID
                        }
                };

            objOItem_Result = objDBLevel_XMLIntro.get_Data_ObjectRel(searchXML, boolIDs: false);

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                OItem_XML = objDBLevel_XMLIntro.OList_ObjectRel.Select(xml => new clsOntologyItem
                    {
                        GUID = xml.ID_Other,
                        Name = xml.Name_Other,
                        GUID_Parent = xml.ID_Parent_Other,
                        Type = xml.Ontology
                    }).FirstOrDefault();

                if (OItem_XML != null)
                {
                    OItem_XMLText = objXML.get_XML(OItem_XML);
                    if (OItem_XMLText == null)
                    {
                        objOItem_Result = objLocalConfig.Globals.LState_Error.Clone();
                    }
                }
                else
                {
                    objOItem_Result = objLocalConfig.Globals.LState_Error.Clone();
                }
            }

            return objOItem_Result;
        }

        public clsDataWork_HTMLExport(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;

            Initialize();
        }

        private void Initialize()
        {
            objDBLevel_Signs = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Folder = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_XMLIntro = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Tag = new clsDBLevel(objLocalConfig.Globals);

            objXML = new clsXML(objLocalConfig);

            objFileWork = new clsFileWork(objLocalConfig.Globals);
        }
    }
}

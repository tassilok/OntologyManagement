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

        private clsDBLevel objDBLevel_Filter1;
        private clsDBLevel objDBLevel_Filter2;
        private clsDBLevel objDBLevel_Filter3;
        private clsDBLevel objDBLevel_Filter4;

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

        public List<clsOntologyItem> getFilterQuellen(clsOntologyItem OItem_Filter)
        {
            List<clsOntologyItem> OList_LiteraturQuellen = new List<clsOntologyItem>();

            if (OItem_Filter.GUID_Parent == objLocalConfig.OItem_type_literatur.GUID)
            {
                var oList_Obj1 = new List<clsOntologyItem> {new clsOntologyItem { GUID = OItem_Filter.GUID,
                    Name = OItem_Filter.Name,
                    GUID_Parent = OItem_Filter.GUID_Parent} };

                var objOItem_Result = objDBLevel_Filter1.get_Data_Objects(oList_Obj1);
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {

                    var oList_Rel1 = objDBLevel_Filter1.OList_Objects.Select(p => new clsObjectRel { ID_Other = p.GUID,
                        ID_RelationType = objLocalConfig.OItem_relationtype_belonging_source.GUID,
                        ID_Parent_Object = objLocalConfig.OItem_type_buch_quellenangabe.GUID,
                        ID_Object = OItem_Filter.GUID,
                        Name_Object = OItem_Filter.Name}).ToList();

                    objOItem_Result = objDBLevel_Filter2.get_Data_ObjectRel(oList_Rel1);

                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        var oList_Rel2 = objDBLevel_Filter2.OList_ObjectRel_ID.Select(p => new clsObjectRel
                        {
                            ID_Object = p.ID_Object,
                            ID_RelationType = objLocalConfig.OItem_relationtype_issubordinated.GUID,
                            ID_Parent_Other = objLocalConfig.OItem_type_literarische_quelle.GUID
                        }).ToList();

                        objOItem_Result = objDBLevel_Filter3.get_Data_ObjectRel(oList_Rel2);

                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {
                            OList_LiteraturQuellen = objDBLevel_Filter3.OList_ObjectRel_ID.Select(p => new clsOntologyItem
                            {
                                GUID = p.ID_Other,
                                GUID_Parent = p.ID_Parent_Other,
                                Type = objLocalConfig.Globals.Type_Object
                            }).ToList();


                        }
                        else
                        {
                            OList_LiteraturQuellen = null;
                        }
                    }
                    else
                    {
                        OList_LiteraturQuellen = null;
                    }

                }
                else
                {
                    OList_LiteraturQuellen = null;
                }
                
            }
            else if (OItem_Filter.GUID_Parent == objLocalConfig.OItem_attribute_seite.GUID)
            {
                var oList_Rel1 = new List<clsObjectAtt> {new clsObjectAtt {ID_AttributeType = objLocalConfig.OItem_attribute_seite.GUID, 
                    ID_Class = objLocalConfig.OItem_type_buch_quellenangabe.GUID,
                    Val_String = OItem_Filter.Val_String}};

                var objOItem_Result = objDBLevel_Filter1.get_Data_ObjectAtt(oList_Rel1);

                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    var oList_Rel2 = objDBLevel_Filter1.OList_ObjectRel_ID.Select(p => new clsObjectRel
                    {
                        ID_Other = p.ID_Object,
                        ID_RelationType = objLocalConfig.OItem_relationtype_issubordinated.GUID,
                        ID_Parent_Object = objLocalConfig.OItem_type_literarische_quelle.GUID
                    }).ToList();

                    objOItem_Result = objDBLevel_Filter2.get_Data_ObjectRel(oList_Rel2);

                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        OList_LiteraturQuellen = objDBLevel_Filter2.OList_ObjectRel_ID.Select(p => new clsOntologyItem
                        {
                            GUID = p.ID_Object,
                            GUID_Parent = p.ID_Parent_Object,
                            Type = objLocalConfig.Globals.Type_Object
                        }).ToList();


                    }
                    else
                    {
                        OList_LiteraturQuellen = null;
                    }
                }
                else
                {
                    OList_LiteraturQuellen = null;
                }
            }
            else if (OItem_Filter.GUID_Parent == objLocalConfig.OItem_type_url.GUID)
            {
                var oList_Obj1 = new List<clsOntologyItem> {new clsOntologyItem { GUID = OItem_Filter.GUID,
                    Name = OItem_Filter.Name,
                    GUID_Parent = OItem_Filter.GUID_Parent} };

                var objOItem_Result = objDBLevel_Filter1.get_Data_Objects(oList_Obj1);
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {

                    var oList_Rel1 = objDBLevel_Filter1.OList_Objects.Select(p => new clsObjectRel
                    {
                        ID_Other = p.GUID,
                        ID_RelationType = objLocalConfig.OItem_relationtype_belonging_source.GUID,
                        ID_Parent_Object = objLocalConfig.OItem_type_internet_quellenangabe.GUID
                    }).ToList();

                    if (oList_Rel1.Any())
                    {
                        objOItem_Result = objDBLevel_Filter2.get_Data_ObjectRel(oList_Rel1);

                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {
                            var oList_Rel2 = objDBLevel_Filter2.OList_ObjectRel_ID.Select(p => new clsObjectRel
                            {
                                ID_Object = p.ID_Object,
                                ID_RelationType = objLocalConfig.OItem_relationtype_issubordinated.GUID,
                                ID_Parent_Other = objLocalConfig.OItem_type_literarische_quelle.GUID
                            }).ToList();

                            if (oList_Rel2.Any())
                            {
                                objOItem_Result = objDBLevel_Filter3.get_Data_ObjectRel(oList_Rel2);

                                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                {
                                    OList_LiteraturQuellen = objDBLevel_Filter3.OList_ObjectRel_ID.Select(p => new clsOntologyItem
                                    {
                                        GUID = p.ID_Other,
                                        GUID_Parent = p.ID_Parent_Other,
                                        Type = objLocalConfig.Globals.Type_Object
                                    }).ToList();


                                }
                                else
                                {
                                    OList_LiteraturQuellen = null;
                                }
                            }
                            
                        }
                        else
                        {
                            OList_LiteraturQuellen = null;
                        }
                    }
                    

                }
                else
                {
                    OList_LiteraturQuellen = null;
                }
            }
            else if (OItem_Filter.GUID_Parent == objLocalConfig.OItem_class_media_item.GUID)
            {
                var oList_Obj1 = new List<clsOntologyItem> {new clsOntologyItem { GUID = OItem_Filter.GUID,
                    Name = OItem_Filter.Name,
                    GUID_Parent = OItem_Filter.GUID_Parent} };

                var objOItem_Result = objDBLevel_Filter1.get_Data_Objects(oList_Obj1);

                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    var oList_Rel1 = objDBLevel_Filter1.OList_Objects.Select(p => new clsObjectRel
                    {
                        ID_Object = p.GUID,
                        ID_RelationType = objLocalConfig.OItem_relationtype_belongsto.GUID,
                        ID_Parent_Other = objLocalConfig.OItem_type_video.GUID
                    }).ToList();

                    if (oList_Rel1.Any())
                    {
                        objOItem_Result = objDBLevel_Filter2.get_Data_ObjectRel(oList_Rel1);

                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {
                            var oList_Rel2 = objDBLevel_Filter2.OList_ObjectRel_ID.Select(p => new clsObjectRel
                            {
                                ID_Other = p.ID_Other,
                                ID_RelationType = objLocalConfig.OItem_relationtype_belonging.GUID,
                                ID_Parent_Object = objLocalConfig.OItem_type_video_quelle.GUID
                            }).ToList();

                            if (oList_Rel2.Any())
                            {
                                objOItem_Result = objDBLevel_Filter3.get_Data_ObjectRel(oList_Rel2);

                                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                {
                                    //Video-quelle
                                    var oList_Rel3 = objDBLevel_Filter3.OList_ObjectRel_ID.Select(p => new clsObjectRel
                                    {
                                        ID_Object = p.ID_Object,
                                        ID_RelationType = objLocalConfig.OItem_relationtype_issubordinated.GUID,
                                        ID_Parent_Other = objLocalConfig.OItem_type_literarische_quelle.GUID
                                    }).ToList();

                                    if (oList_Rel3.Any())
                                    {
                                        objOItem_Result = objDBLevel_Filter4.get_Data_ObjectRel(oList_Rel3);
                                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                        {
                                            OList_LiteraturQuellen = objDBLevel_Filter4.OList_ObjectRel_ID.Select(p => new clsOntologyItem
                                            {
                                                GUID = p.ID_Other,
                                                GUID_Parent = p.ID_Parent_Other,
                                                Type = objLocalConfig.Globals.Type_Object
                                            }).ToList();
                                        }
                                        else
                                        {
                                            OList_LiteraturQuellen = null;
                                        }
                                    }
                                    



                                }
                                else
                                {
                                    OList_LiteraturQuellen = null;
                                }
                            }
                            
                        }
                        else
                        {
                            OList_LiteraturQuellen = null;
                        }
                    }
                    
                }
                else
                {
                    OList_LiteraturQuellen = null;
                }

                if (OList_LiteraturQuellen != null)
                {
                    if (!OList_LiteraturQuellen.Any())
                    {
                        var oList_Rel2 = objDBLevel_Filter1.OList_Objects.Select(p => new clsObjectRel
                        {
                            ID_Object = p.GUID,
                            ID_RelationType = objLocalConfig.OItem_relationtype_belongsto.GUID,
                            ID_Parent_Object = objLocalConfig.OItem_type_audio_quelle.GUID
                        }).ToList();

                        objOItem_Result = objDBLevel_Filter2.get_Data_ObjectRel(oList_Rel2);
                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {
                            var oList_Rel3 = objDBLevel_Filter2.OList_ObjectRel_ID.Select(p => new clsObjectRel
                            {
                                ID_Object = p.ID_Object,
                                ID_RelationType = objLocalConfig.OItem_relationtype_issubordinated.GUID,
                                ID_Parent_Other = objLocalConfig.OItem_type_literarische_quelle.GUID
                            }).ToList();


                            objOItem_Result = objDBLevel_Filter3.get_Data_ObjectRel(oList_Rel3);
                            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                            {
                                OList_LiteraturQuellen = objDBLevel_Filter3.OList_ObjectRel_ID.Select(p => new clsOntologyItem
                                {
                                    GUID = p.ID_Other,
                                    GUID_Parent = p.ID_Parent_Other,
                                    Type = objLocalConfig.Globals.Type_Object
                                }).ToList();
                            }
                            else
                            {
                                OList_LiteraturQuellen = null;
                            }
                        }
                        else
                        {
                            OList_LiteraturQuellen = null;
                        }
                    }
                }

            }
            else if (OItem_Filter.GUID_Parent == objLocalConfig.OItem_class_images__graphic_.GUID)
            {
                
            }
            else if (OItem_Filter.GUID_Parent == objLocalConfig.OItem_class_e_mail.GUID)
            {

            }
            else if (OItem_Filter.GUID_Parent == objLocalConfig.OItem_class_zeitschrift.GUID)
            {

            }
            else if (OItem_Filter.GUID_Parent == objLocalConfig.OItem_type_zeitschriftenausgabe.GUID)
            {

            }

            return OList_LiteraturQuellen;
        }

        public clsDataWork_LiteraturQuelle(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;
            Initialize();
        }

        private void Initialize()
        {
            objDBLevel_LiteraturQuellen = new clsDBLevel(objLocalConfig.Globals);

            objDBLevel_Filter1 = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Filter2 = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Filter3 = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Filter4 = new clsDBLevel(objLocalConfig.Globals);

            OItem_Result_LiteraturQuellen = objLocalConfig.Globals.LState_Nothing.Clone();
        }
    }
}

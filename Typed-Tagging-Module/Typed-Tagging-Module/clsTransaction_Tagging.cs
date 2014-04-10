using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ontology_Module;
using OntologyClasses.BaseClasses;

namespace Typed_Tagging_Module
{
    public class clsTransaction_Tagging
    {

        private clsLocalConfig objLocalConfig;

        private clsTransaction objTransaction;
        private clsRelationConfig objRelationConfig;

        private clsDataWork_Tagging objDataWork_Tagging;

        private clsOntologyItem objOItem_Result_Data;

        public clsTransaction_Tagging(clsGlobals Globals, clsOntologyItem OItem_User, clsOntologyItem OItem_Group)
        {
            objLocalConfig = new clsLocalConfig(Globals);
            
            objLocalConfig.OItem_User = OItem_User;
            objLocalConfig.OItem_Group = OItem_Group;

            Initialize();
        }

        private void Initialize()
        {
            objTransaction = new clsTransaction(objLocalConfig.Globals);
            objRelationConfig = new clsRelationConfig(objLocalConfig.Globals);

            objDataWork_Tagging = new clsDataWork_Tagging(objLocalConfig);
        }

        
        public clsOntologyItem Save_Tag(clsOntologyItem OItem_TaggingSource, clsOntologyItem OItem_TaggingDest)
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            objTransaction.ClearItems();

            
            objOItem_Result_Data = objDataWork_Tagging.GetTagsOfTaggingSource(OItem_TaggingSource);
            

            if (objOItem_Result_Data.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                if (!objDataWork_Tagging.OList_Tags().Any(t => t.GUID == OItem_TaggingDest.GUID))
                {
                    var objOItem_Tag = new clsOntologyItem
                    {
                        GUID = objLocalConfig.Globals.NewGUID,
                        Name = OItem_TaggingSource.Name,
                        GUID_Parent = objLocalConfig.OItem_class_typed_tag.GUID,
                        Type = objLocalConfig.Globals.Type_Object
                    };

                    objOItem_Result = objTransaction.do_Transaction(objOItem_Tag);
                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        var objORel_Tag_To_User = objRelationConfig.Rel_ObjectRelation(objOItem_Tag, objLocalConfig.OItem_User, objLocalConfig.OItem_relationtype_belongs_to);
                        objOItem_Result = objTransaction.do_Transaction(objORel_Tag_To_User);
                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {
                            var objORel_Tag_To_Group = objRelationConfig.Rel_ObjectRelation(objOItem_Tag, objLocalConfig.OItem_Group, objLocalConfig.OItem_relationtype_belongs_to);
                            objOItem_Result = objTransaction.do_Transaction(objORel_Tag_To_Group);
                            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                            {
                                var objORel_Tag_To_Source = objRelationConfig.Rel_ObjectRelation(objOItem_Tag, OItem_TaggingSource, objLocalConfig.OItem_relationtype_is_tagging);
                                objOItem_Result = objTransaction.do_Transaction(objORel_Tag_To_Source);
                                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                {
                                    var objORel_Tag_To_Dest = objRelationConfig.Rel_ObjectRelation(objOItem_Tag, OItem_TaggingDest, objLocalConfig.OItem_relationtype_belonging_tag);
                                    objOItem_Result = objTransaction.do_Transaction(objORel_Tag_To_Dest);
                                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Error.GUID)
                                    {
                                        objTransaction.rollback();
                                    }
                                }
                                else
                                {
                                    objTransaction.rollback();
                                }
                            }
                            else
                            {
                                objTransaction.rollback();
                            }
                        }
                    }
                }
            }

            return objOItem_Result;
        }
    }
}

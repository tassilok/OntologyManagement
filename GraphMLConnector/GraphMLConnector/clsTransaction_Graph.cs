using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ontolog_Module;

namespace GraphMLConnector
{
    class clsTransaction_Graph
    {
        private clsLocalConfig objLocalConfig;
        private clsTransaction objTransaction;


        public clsOntologyItem save_GraphItem(clsOntologyItem OItem_Graph, clsOntologyItem OItem_GraphItem, clsOntologyItem OItem_ExportMode,
                                          clsOntologyItem OItem_OItem)
        {
            var objOItem_Result = new clsOntologyItem();



            objOItem_Result = objTransaction.do_Transaction(OItem_GraphItem);
            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                var objOR_GraphToGraphItem = new clsObjectRel(OItem_Graph.GUID,
                                                            OItem_Graph.GUID_Parent,
                                                            OItem_GraphItem.GUID,
                                                            OItem_GraphItem.GUID_Parent,
                                                            objLocalConfig.OItem_RelationType_Contains.GUID,
                                                            objLocalConfig.Globals.Type_Object,
                                                            null,
                                                            1);

                objOItem_Result = objTransaction.do_Transaction(objOR_GraphToGraphItem);
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    var objOR_GraphItemToExportMode = new clsObjectRel(OItem_GraphItem.GUID,
                                                                         OItem_GraphItem.GUID_Parent,
                                                                         OItem_ExportMode.GUID,
                                                                         OItem_ExportMode.GUID_Parent,
                                                                         objLocalConfig.OItem_RelationType_isOfType.GUID,
                                                                         objLocalConfig.Globals.Type_Object,
                                                                         null,
                                                                         1);

                    objOItem_Result = objTransaction.do_Transaction(objOR_GraphItemToExportMode);

                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        var objOR_GraphItemToOItem = new clsObjectRel();

                        if (OItem_OItem.Type == objLocalConfig.Globals.Type_Object)
                        {
                            objOR_GraphItemToOItem = new clsObjectRel(OItem_GraphItem.GUID,
                                                                      OItem_GraphItem.GUID_Parent,
                                                                      OItem_OItem.GUID,
                                                                      OItem_OItem.GUID_Parent,
                                                                      objLocalConfig.OItem_RelationType_belongingSemItem
                                                                                    .GUID,
                                                                      OItem_OItem.Type,
                                                                      null,
                                                                      1);    
                        }
                        else
                        {
                            objOR_GraphItemToOItem = new clsObjectRel(OItem_GraphItem.GUID,
                                                                      OItem_GraphItem.GUID_Parent,
                                                                      OItem_OItem.GUID,
                                                                      null,
                                                                      objLocalConfig.OItem_RelationType_belongingSemItem
                                                                                    .GUID,
                                                                      OItem_OItem.Type,
                                                                      null,
                                                                      1);
                        }
                        

                        objOItem_Result = objTransaction.do_Transaction(objOR_GraphItemToOItem);
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
            

            return objOItem_Result;
        }

        public clsOntologyItem Remove_GraphItem(clsOntologyItem OItem_Graph, clsOntologyItem OItem_GraphItem)
        {
            clsOntologyItem objOItem_Result;

            

            var objOR_GraphItemToRight = new clsObjectRel(OItem_GraphItem.GUID, 
                                                             null,
                                                             null,
                                                             null,
                                                             null,
                                                             null,
                                                             null,
                                                             null);

            var objOR_GrahToGraphItem = new clsObjectRel(OItem_Graph.GUID,
                                                         null,
                                                         OItem_GraphItem.GUID,
                                                         null,
                                                         objLocalConfig.OItem_RelationType_Contains.GUID,
                                                         objLocalConfig.Globals.Type_Object,
                                                         null,
                                                         null);

            objTransaction.ClearItems();
            objOItem_Result = objTransaction.do_Transaction(objOR_GraphItemToRight, false, true);
            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                objOItem_Result = objTransaction.do_Transaction(objOR_GrahToGraphItem, false, true);
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    objOItem_Result = objTransaction.do_Transaction(OItem_GraphItem, false, true);

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

            return objOItem_Result;
        }

        public clsOntologyItem save_GraphItem_To_ExportMode(clsOntologyItem OItem_GraphItem,
                                                            clsOntologyItem OItem_ExportMode)
        {
            clsOntologyItem objOItem_Result;

            objTransaction.ClearItems();

            var objOR_GraphItemToExportMode = new clsObjectRel(OItem_GraphItem.GUID,
                                                               OItem_GraphItem.GUID_Parent,
                                                               OItem_ExportMode.GUID,
                                                               OItem_ExportMode.GUID_Parent,
                                                               objLocalConfig.OItem_RelationType_isOfType.GUID,
                                                               objLocalConfig.Globals.Type_Object,
                                                               null,
                                                               1);

            objOItem_Result = objTransaction.do_Transaction(objOR_GraphItemToExportMode, true);
            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Error.GUID)
            {
                objTransaction.rollback();
            }

            

            return objOItem_Result;
        }

        public clsTransaction_Graph(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;

            initialize();
        }

        private void initialize()
        {
            objTransaction = new clsTransaction(objLocalConfig.Globals);
        }
    }
}

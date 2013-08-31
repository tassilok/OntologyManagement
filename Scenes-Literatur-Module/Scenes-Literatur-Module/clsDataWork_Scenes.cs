using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ontolog_Module;
using System.Threading;

namespace Scenes_Literatur_Module
{
    public class clsDataWork_Scenes
    {
        private clsLocalConfig objLocalConfig;

        private clsDBLevel objDBLevel_Literature;
        private clsDBLevel objDBLevel_Chapter;
        private clsDBLevel objDBLevel_Scenes;

        public clsOntologyItem OItem_Result_Literature { get; set; }
        public clsOntologyItem OItem_Result_Chapter { get; set; }
        public clsOntologyItem OItem_Result_Scene { get; set; }

        private Thread objThread_Literature;
        private Thread objThread_Chapter;
        private Thread objThread_Scene;

        public List<clsOntologyItem> OList_Literature { get; set; }
        public List<clsObjectRel> OList_Chapter { get; set; }
        public List<clsObjectRel> OList_Scene { get; set; }


        public clsDataWork_Scenes(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;
            initialize();
        }

        private void initialize()
        {
            objDBLevel_Literature = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Chapter = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Scenes = new clsDBLevel(objLocalConfig.Globals);

            getData();
        }

        private void getData()
        {
            OItem_Result_Chapter = objLocalConfig.Globals.LState_Nothing;
            OItem_Result_Literature = objLocalConfig.Globals.LState_Nothing;
            OItem_Result_Scene = objLocalConfig.Globals.LState_Nothing;

            try
            {
                objThread_Chapter.Abort();
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }

            try
            {
                objThread_Literature.Abort();
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }

            try
            {
                objThread_Scene.Abort();
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }

            objThread_Chapter = new Thread(getDataChapter);
            objThread_Literature = new Thread(getDataLiterature);
            objThread_Scene = new Thread(getDataScenes);

            objThread_Literature.Start();
            objThread_Chapter.Start();
            objThread_Scene.Start();
        }

        public void getDataLiterature()
        {
            OItem_Result_Literature = objLocalConfig.Globals.LState_Nothing;
            List<clsOntologyItem> OList_Literatures = new List<clsOntologyItem>();
            OList_Literatures.Add(
                new clsOntologyItem()
            {
                GUID_Parent = objLocalConfig.OItem_type_eigene_literatur.GUID,
                Type = objLocalConfig.Globals.Type_Object
            });

            objDBLevel_Literature.Sort = clsDBLevel.SortEnum.ASC_Name;
            var objOItem_Result = objDBLevel_Literature.get_Data_Objects(OList_Literatures);
            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                OList_Literature = objDBLevel_Literature.OList_Objects;
                OItem_Result_Literature = objLocalConfig.Globals.LState_Success;
            }
            else
            {
                OList_Literature = null;
                OItem_Result_Literature = objLocalConfig.Globals.LState_Error;
            }
        }

        public void getDataChapter()
        {
            OItem_Result_Chapter = objLocalConfig.Globals.LState_Nothing;
            List<clsObjectRel> OList_ChapterOfLiterature = new List<clsObjectRel>();

            OList_ChapterOfLiterature.Add(new clsObjectRel()
            {
                ID_Parent_Object = objLocalConfig.OItem_type_eigene_literatur.GUID,
                ID_Parent_Other = objLocalConfig.OItem_type_kapitel.GUID,
                ID_RelationType = objLocalConfig.OItem_relationtype_contains.GUID
            });

            objDBLevel_Chapter.Sort = clsDBLevel.SortEnum.ASC_OrderID;
            var objOItem_Result = objDBLevel_Chapter.get_Data_ObjectRel(OList_ChapterOfLiterature, 
                                                                         boolIDs: false);

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                OList_Chapter = objDBLevel_Chapter.OList_ObjectRel;
                OItem_Result_Chapter = objLocalConfig.Globals.LState_Success;
            }
            else
            {
                OList_Chapter = null;
                OItem_Result_Chapter = objLocalConfig.Globals.LState_Error;
            }
        }

        public void getDataScenes()
        {
            OItem_Result_Scene = objLocalConfig.Globals.LState_Nothing;
            List<clsObjectRel> OList_ScenesOfChapter = new List<clsObjectRel>();

            OList_ScenesOfChapter.Add(new clsObjectRel()
            {
                ID_Parent_Object = objLocalConfig.OItem_type_kapitel.GUID,
                ID_Parent_Other = objLocalConfig.OItem_type_szene.GUID,
                ID_RelationType = objLocalConfig.OItem_relationtype_contains.GUID
            });

            objDBLevel_Scenes.Sort = clsDBLevel.SortEnum.ASC_OrderID;
            var objOItem_Result = objDBLevel_Scenes.get_Data_ObjectRel(OList_ScenesOfChapter, 
                                                                      boolIDs: false);

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                OList_Scene = objDBLevel_Scenes.OList_ObjectRel;
                OItem_Result_Scene = objLocalConfig.Globals.LState_Success;
            }
            else
            {
                OList_Scene = null;
                OItem_Result_Scene = objLocalConfig.Globals.LState_Error;
            }
        }



    }
}

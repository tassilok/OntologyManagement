using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.BaseClasses;
using Ontology_Module;
using Filesystem_Module;

namespace CommandLineRun_Module
{
    public class clsDataWork_ExecutableConfiguration
    {
        private clsLocalConfig objLocalConfig;

        private clsDBLevel objDBLevel_ExecutableConfigurations;
        private clsDBLevel objDBLevel_Relations;

        public clsOntologyItem OItem_Result_ExecConfig { get; private set; }
        public clsOntologyItem OItem_Result_Relations { get; private set; }

        public List<clsExecutableConfiguration> ExecutableConfigurations { get; set; }

        private clsFileWork objFileWork;

        public clsOntologyItem GetData()
        {
            ExecutableConfigurations = new List<clsExecutableConfiguration>();

            GetSubData_001_ExecConfig();
            var objOItem_Result = OItem_Result_ExecConfig;
            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                GetSubData_002_Relations();
                objOItem_Result = OItem_Result_Relations;
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    ExecutableConfigurations = (from objExec in objDBLevel_ExecutableConfigurations.OList_ObjectRel
                                                join objExtension in
                                                    objDBLevel_Relations.OList_ObjectRel.Where(
                                                        rel =>
                                                        rel.ID_Parent_Other ==
                                                        objLocalConfig.OItem_class_extensions.GUID).ToList() on
                                                    objExec.ID_Other equals objExtension.ID_Object
                                                join objFile in
                                                    objDBLevel_Relations.OList_ObjectRel.Where(
                                                        rel =>
                                                        rel.ID_Parent_Other == objLocalConfig.OItem_class_file.GUID)
                                                                        .ToList() on objExec.ID_Other equals
                                                    objFile.ID_Object
                                                join objPL in
                                                    objDBLevel_Relations.OList_ObjectRel.Where(
                                                        rel =>
                                                        rel.ID_Parent_Other ==
                                                        objLocalConfig.OItem_class_programing_language.GUID).ToList() on
                                                    objExec.ID_Other equals objPL.ID_Object
                                                join objFolder in objDBLevel_Relations.OList_ObjectRel.Where(
                                                        rel =>
                                                        rel.ID_Parent_Other ==
                                                        objLocalConfig.OItem_class_folder.GUID).ToList() on
                                                    objExec.ID_Other equals objFolder.ID_Object into objFolders
                                                from objFolder in objFolders.DefaultIfEmpty()
                                                join objPath in objDBLevel_Relations.OList_ObjectRel.Where(
                                                        rel =>
                                                        rel.ID_Parent_Other ==
                                                        objLocalConfig.OItem_class_path.GUID).ToList() on
                                                    objExec.ID_Other equals objPath.ID_Object into objPaths
                                                from objPath in objPaths.DefaultIfEmpty()
                                                select new clsExecutableConfiguration
                                                    {
                                                        ID_ExecConfig = objExec.ID_Other,
                                                        Name_ExecConfig = objExec.Name_Other,
                                                        ID_Extension = objExtension.ID_Other,
                                                        Name_Extension = objExtension.Name_Other,
                                                        ID_ProgrammingLanguage = objPL.ID_Other,
                                                        Name_ProgrammingLanguage = objPL.Name_Other,
                                                        ID_File = objFile.ID_Other,
                                                        Name_File = objFile.Name_Other,
                                                        Path_File = objFileWork.get_Path_FileSystemObject(new clsOntologyItem
                                                            {
                                                                GUID = objFile.ID_Other,
                                                                Name = objFile.Name_Other,
                                                                GUID_Parent = objFile.ID_Parent_Other,
                                                                Type = objLocalConfig.Globals.Type_Object
                                                            },false),
                                                        ID_ScriptFolder = objFolder != null ? objFolder.ID_Other : "",
                                                        Name_ScriptFolder = objFolder != null ? objFolder.Name_Other : objPath != null ? objPath.Name_Other : "",
                                                        Path_Folder = objFolder != null ? objFileWork.get_Path_FileSystemObject( new clsOntologyItem
                                                        {
                                                                GUID = objFolder.ID_Other,
                                                                Name = objFolder.Name_Other,
                                                                GUID_Parent = objFolder.ID_Parent_Other,
                                                                Type = objLocalConfig.Globals.Type_Object
                                                            },false) : objPath != null ? Environment.ExpandEnvironmentVariables(objPath.Name_Other) : null
                                                    }).ToList();

                }
            }

            return objOItem_Result;
        }

        private void GetSubData_001_ExecConfig()
        {
            OItem_Result_ExecConfig = objLocalConfig.Globals.LState_Nothing.Clone();
            
            
            
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            var searchConfig = new List<clsObjectRel>
                {
                    new clsObjectRel
                        {
                            ID_Object = objLocalConfig.OItem_BaseConfig.GUID,
                            ID_RelationType = objLocalConfig.OItem_relationtype_offers.GUID,
                            ID_Parent_Other = objLocalConfig.OItem_class_executable_configuration.GUID
                        }
                };

            objOItem_Result = objDBLevel_ExecutableConfigurations.get_Data_ObjectRel(searchConfig, boolIDs: false);

            OItem_Result_ExecConfig = objOItem_Result;
        }

        private void GetSubData_002_Relations()
        {
            OItem_Result_Relations = objLocalConfig.Globals.LState_Nothing.Clone();

            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            var searchRelations = objDBLevel_ExecutableConfigurations.OList_ObjectRel.Select(exec => new clsObjectRel
                {
                    ID_Object = exec.ID_Other,
                    ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID,
                    ID_Parent_Other = objLocalConfig.OItem_class_extensions.GUID
                }).ToList();

            searchRelations.AddRange(objDBLevel_ExecutableConfigurations.OList_ObjectRel.Select(exec => new clsObjectRel
            {
                ID_Object = exec.ID_Other,
                ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID,
                ID_Parent_Other = objLocalConfig.OItem_class_file.GUID
            }));

            searchRelations.AddRange(objDBLevel_ExecutableConfigurations.OList_ObjectRel.Select(exec => new clsObjectRel
            {
                ID_Object = exec.ID_Other,
                ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID,
                ID_Parent_Other = objLocalConfig.OItem_class_programing_language.GUID
            }));

            searchRelations.AddRange(objDBLevel_ExecutableConfigurations.OList_ObjectRel.Select(exec => new clsObjectRel
                {
                    ID_Object =  exec.ID_Other,
                    ID_RelationType = objLocalConfig.OItem_relationtype_script_folder.GUID,
                    ID_Parent_Other = objLocalConfig.OItem_class_folder.GUID
                }));

            searchRelations.AddRange(objDBLevel_ExecutableConfigurations.OList_ObjectRel.Select(exec => new clsObjectRel
            {
                ID_Object = exec.ID_Other,
                ID_RelationType = objLocalConfig.OItem_relationtype_script_folder.GUID,
                ID_Parent_Other = objLocalConfig.OItem_class_path.GUID
            }));

            if (searchRelations.Any())
            {
                objOItem_Result = objDBLevel_Relations.get_Data_ObjectRel(searchRelations, boolIDs: false);
            }
            else
            {
                objDBLevel_Relations.OList_ObjectRel.Clear();
            }

            OItem_Result_Relations = objOItem_Result;
        }

        public clsDataWork_ExecutableConfiguration(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;

            Initialize();
        }

        private void Initialize()
        {
            objDBLevel_ExecutableConfigurations = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Relations = new clsDBLevel(objLocalConfig.Globals);

            objFileWork = new clsFileWork(objLocalConfig.Globals);

            OItem_Result_ExecConfig = objLocalConfig.Globals.LState_Nothing.Clone();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ontology_Module;
using OntologyClasses.BaseClasses;

namespace CommandLineRun_Module
{
    public class clsDataWork_CodeSniplets
    {
        private clsLocalConfig objLocalConfig;

        private clsDBLevel objDBLevel_CodeSnipplets;
        private clsDBLevel objDBLevel_SyntaxHighlight;

        public clsOntologyItem OItem_CodeSnipplet { get; private set; }
        public clsObjectAtt OAItem_Code { get; private set; }
        public clsOntologyItem OItem_SyntaxHighlight { get; private set; }

        public clsOntologyItem GetData_CodeSnipplet(clsOntologyItem OItem_CodeSnipplet)
        {
            this.OItem_CodeSnipplet = OItem_CodeSnipplet;
            OAItem_Code = null;
            var result = objLocalConfig.Globals.LState_Success.Clone();

            var searchCode = new List<clsObjectAtt> { new clsObjectAtt { ID_Object = OItem_CodeSnipplet.GUID,
                        ID_AttributeType = objLocalConfig.OItem_attributetype_code.GUID } };

            result = objDBLevel_CodeSnipplets.get_Data_ObjectAtt(searchCode, boolIDs:false);

            if (result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                OAItem_Code = objDBLevel_CodeSnipplets.OList_ObjectAtt.FirstOrDefault();
            }

            return result;
        }

        public clsOntologyItem GetData_SyntaxHighlight(clsOntologyItem OItem_ProgrammingLanguage)
        {
            OItem_SyntaxHighlight = null;
            var result = objLocalConfig.Globals.LState_Success.Clone();

            var searchHighlight = new List<clsObjectRel> { new clsObjectRel { ID_Other = OItem_ProgrammingLanguage.GUID,
                ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID,
                ID_Parent_Object = objLocalConfig.OItem_class_syntax_highlighting__scintillanet_.GUID } };

            result = objDBLevel_SyntaxHighlight.get_Data_ObjectRel(searchHighlight, boolIDs: false);

            if (result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                OItem_SyntaxHighlight = objDBLevel_SyntaxHighlight.OList_ObjectRel.Select(syn => new clsOntologyItem
                {
                    GUID = syn.ID_Object,
                    Name = syn.Name_Object,
                    GUID_Parent = syn.ID_Parent_Object,
                    Type = objLocalConfig.Globals.Type_Object
                }).ToList().FirstOrDefault();
            }

            return result;
        }

        public clsDataWork_CodeSniplets(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;

            Initialize();
        }

        public clsDataWork_CodeSniplets(clsGlobals Globals)
        {
            objLocalConfig = new clsLocalConfig(Globals);

            Initialize();
        }

        private void Initialize()
        {
            objDBLevel_CodeSnipplets = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_SyntaxHighlight = new clsDBLevel(objLocalConfig.Globals);
        }
    }
}

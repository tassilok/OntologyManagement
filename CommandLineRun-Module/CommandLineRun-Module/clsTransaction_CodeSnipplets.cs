using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ontology_Module;
using OntologyClasses.BaseClasses;

namespace CommandLineRun_Module
{
    public class clsTransaction_CodeSnipplets
    {
        private clsLocalConfig localConfig;
        private clsRelationConfig objRelationConfig_CodeSnipplet;
        private clsTransaction objTransaction_CodeSnipplets;

        public clsOntologyItem OItem_Class_CodeSnipplet
        {
            get { return localConfig.OItem_class_code_snipplets; }
        }

        public clsOntologyItem OItem_RelationType_isWrittenIn
        {
            get { return localConfig.OItem_relationtype_is_written_in; }
        }

        public clsTransaction_CodeSnipplets(clsLocalConfig localConfig)
        {
            this.localConfig = localConfig;
            Initialize();
        }

        public clsTransaction_CodeSnipplets(clsGlobals globals)
        {
            this.localConfig = new clsLocalConfig(globals);
            Initialize();
        }

        private void Initialize()
        {
            objTransaction_CodeSnipplets = new clsTransaction(localConfig.Globals);
            objRelationConfig_CodeSnipplet = new clsRelationConfig(localConfig.Globals);
        }

        public clsOntologyItem SaveCodeSnipplet(clsOntologyItem OItem_CodeSnipplet, clsOntologyItem OItem_ProgrammingLanguage, string code = "")
        {
            var result = localConfig.Globals.LState_Success.Clone();

            objTransaction_CodeSnipplets.ClearItems();

            result = objTransaction_CodeSnipplets.do_Transaction(OItem_CodeSnipplet);
            if (result.GUID == localConfig.Globals.LState_Success.GUID)
            {
                var codeSave = objRelationConfig_CodeSnipplet.Rel_ObjectAttribute(OItem_CodeSnipplet,
                    localConfig.OItem_attributetype_code,
                    code);

                result = objTransaction_CodeSnipplets.do_Transaction(codeSave, boolRemoveAll:true);
                if (result.GUID == localConfig.Globals.LState_Success.GUID)
                {
                    var progLSave = objRelationConfig_CodeSnipplet.Rel_ObjectRelation(OItem_CodeSnipplet,
                        OItem_ProgrammingLanguage,
                        localConfig.OItem_relationtype_is_written_in);

                    result = objTransaction_CodeSnipplets.do_Transaction(progLSave, boolRemoveAll:true);
                    if (result.GUID == localConfig.Globals.LState_Error.GUID)
                    {
                        objTransaction_CodeSnipplets.rollback();
                    }
                }
                else
                {
                    objTransaction_CodeSnipplets.rollback();
                }
            }

            return result;
        }
    }
}

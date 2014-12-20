using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.BaseClasses;
using Ontology_Module;
using System.Windows.Forms;

namespace ScriptingModule
{
    public class ScriptParser
    {
        clsLocalConfig localConfig;
        private LuaManager luaManager;
        public string Script { get; set; }
        private IWin32Window parentForm;
        
        public ScriptParser(clsLocalConfig localConfig, IWin32Window parentForm)
        {
            this.localConfig = localConfig;

            this.parentForm = parentForm;

            Initialize();
        }

        private void Initialize()
        {
            luaManager = new LuaManager(localConfig, parentForm);
        }

        public clsOntologyItem ParseScript(string script)
        {
            var result = localConfig.Globals.LState_Success.Clone();

            try
            {
                result = luaManager.ExecuteScript(script);
            }
            catch (Exception ex)
            {
                result = localConfig.Globals.LState_Error.Clone();
            }
            
            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuaInterface;
using System.Collections;
using System.Windows.Forms;
using OntologyClasses.BaseClasses;

namespace ScriptingModule
{
    public class LuaManager
    {
        private static Lua lua = new Lua();
        private Functions functions;
        private clsLocalConfig localConfig;
        private IWin32Window parentForm;

        private clsDataWork_Scripting objDataWork_Scripting;

        public LuaManager(clsLocalConfig localConfig, IWin32Window parentForm)
        {
            this.localConfig = localConfig;
            this.parentForm = parentForm;
            Initialize();
        }

        private void Initialize()
        {
            objDataWork_Scripting = new clsDataWork_Scripting(localConfig);

            localConfig.DataWork_Scripting = objDataWork_Scripting;

            var result = objDataWork_Scripting.GetData();

            if (result.GUID == localConfig.Globals.LState_Success.GUID)
            {
                functions = new Functions(localConfig, parentForm);

                objDataWork_Scripting.OList_Functions.ForEach(luaf =>
                {
                    lua.RegisterFunction(luaf.Name, functions, functions.GetType().GetMethod(luaf.Name));
                });


            }
            else
            {
                throw new Exception("No Functions definied");
            }

            
        }

        public clsOntologyItem ExecuteScript(string script)
        {
            var result = localConfig.Globals.LState_Success.Clone();
            try
            {

                lua.DoString(script);
            }
            catch (Exception ex)
            {
                result = localConfig.Globals.LState_Error.Clone();
                result.Additional1 = ex.Message;
            }
            return result;
        }

        

    }
}

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

        public LuaManager(clsLocalConfig localConfig, IWin32Window parentForm)
        {
            this.localConfig = localConfig;
            this.parentForm = parentForm;
            Initialize();
        }

        private void Initialize()
        {
            functions = new Functions(localConfig, parentForm);
            lua.RegisterFunction("InsertObject", functions, functions.GetType().GetMethod("InsertObject") );
            lua.RegisterFunction("InsertClass", functions, functions.GetType().GetMethod("InsertClass"));
            lua.RegisterFunction("InsertClassAtts", functions, functions.GetType().GetMethod("InsertClassAtts"));
            lua.RegisterFunction("InsertClassRels", functions, functions.GetType().GetMethod("InsertClassRels"));
            lua.RegisterFunction("InsertObject", functions, functions.GetType().GetMethod("InsertObject"));
            lua.RegisterFunction("InsertObjectAttribute", functions, functions.GetType().GetMethod("InsertObjectAttribute"));
            lua.RegisterFunction("InsertObjectRelation", functions, functions.GetType().GetMethod("InsertObjectRelation"));
            lua.RegisterFunction("InsertRelationType", functions, functions.GetType().GetMethod("InsertRelationType"));
            lua.RegisterFunction("TransactionStart", functions, functions.GetType().GetMethod("TransactionStart"));
            lua.RegisterFunction("TransactionCommit", functions, functions.GetType().GetMethod("TransactionCommit"));
            lua.RegisterFunction("CreateGuid", functions, functions.GetType().GetMethod("CreateGuid"));
            lua.RegisterFunction("MsgBox", functions, functions.GetType().GetMethod("MsgBox"));
            lua.RegisterFunction("SaveFile", functions, functions.GetType().GetMethod("SaveFile"));
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Outlook;
using System.Runtime.InteropServices;
using Ontology_Module;
using OntologyClasses.BaseClasses;

namespace OutlookConnector_Module
{
    class clsOutlookConnector
    {
        Microsoft.Office.Interop.Outlook.Application objOutlook;
        Microsoft.Office.Interop.Outlook.NameSpace objMapi;

        private clsGlobals objGlobals;

        public string ActiveFolder { get; private set; }

        public List<clsAppDocuments> MailItems { get; private set; }

        public clsOutlookConnector(clsGlobals Globals)
        {
            objGlobals = Globals;
            Initialize();
        }

        private void Initialize()
        {
            MailItems = new List<clsAppDocuments>();
        }

        public string State_Outlook
        {
            get
            {
                try
                {
                    objOutlook = (Microsoft.Office.Interop.Outlook.Application)Marshal.GetActiveObject("Outlook.Application");
                    var objActiveExplorer = objOutlook.ActiveExplorer();
                    if (objActiveExplorer != null)
                    {
                        ActiveFolder = objActiveExplorer.CurrentFolder.Name;
                        return "Running";
                    }
                    else
                    {
                        ActiveFolder = "";
                        return "Not Running";
                    }
                }
                catch (System.Exception ex )
                {
                    ActiveFolder = "";
                    return "Not Running";
                }
                


            }
        }

        public clsOntologyItem GetMailItems(Microsoft.Office.Interop.Outlook.MAPIFolder objFolder = null)
        {
            if (objFolder == null) MailItems.Clear();

            clsOntologyItem objOItem_Result = objGlobals.LState_Success.Clone();
            if (State_Outlook == "Running")
            {
                if (objFolder == null)
                {
                    objFolder = objOutlook.ActiveExplorer().CurrentFolder;
                }

                
                for (int i = 1; i <= objFolder.Items.Count; i++)
                {
                    var item = objFolder.Items[i] as Microsoft.Office.Interop.Outlook.MailItem;
                    if (item != null)
                    {
                        var itemType = item.GetType();
                        var strType = itemType.InvokeMember("MessageClass",System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.GetProperty | System.Reflection.BindingFlags.Instance,null,objFolder.Items[i], new object[] {}).ToString();
                        if (strType == "IPM.Note")
                        {
                            var objMailItem = (Microsoft.Office.Interop.Outlook.MailItem)objFolder.Items[i];
                            var strTo = "";
                            foreach (Microsoft.Office.Interop.Outlook.Recipient objRecipient in objMailItem.Recipients)
                            {
                                strTo += strTo != "" ? ";" : "" + (objRecipient.Address != null ? objRecipient.Address.ToString() : "");
                            }

                            var objDict = new Dictionary<string, object>();

                            var mailItem = new clsAppDocuments
                            {
                                Id = objGlobals.NewGUID,
                                Dict = new Dictionary<string,object> { 
                                    {"EntryID", objMailItem.EntryID},
                                    {"CreationDate",objMailItem.CreationTime},
                                    {"Folder",objFolder.Name},
                                    {"SemItemPresent",false},
                                    {"SenderEmailAddress",objMailItem.SenderEmailAddress},
                                    {"SenderName",objMailItem.SenderName},
                                    {"Subject",objMailItem.Subject},
                                    {"To",strTo}}
                            };
                            MailItems.Add(mailItem);
                        }
                    }
                    
                }

                foreach (Microsoft.Office.Interop.Outlook.MAPIFolder objSubFolder in objFolder.Folders)
                {
                    objOItem_Result =  GetMailItems(objSubFolder);
                    if (objOItem_Result.GUID == objGlobals.LState_Error.GUID)
                    {
                        break;
                    }
                }

            }
            else
            {
                objOItem_Result = objGlobals.LState_Error.Clone();
            }

            return objOItem_Result;
            
        }

        public clsOntologyItem OpenMailItem(string strEntryID)
        {
            var objOItem_Result = objGlobals.LState_Success.Clone();

            objOutlook = new Microsoft.Office.Interop.Outlook.Application();
            objMapi = objOutlook.GetNamespace("Mapi");

            try
            {
                var objMailItem = objMapi.GetItemFromID(strEntryID);
                if (objMailItem != null)
                {
                    objMailItem.Display();
                }
                else
                {
                    objOItem_Result = objGlobals.LState_Error.Clone();
                }
            }
            catch(System.Exception ex)
            {
                objOItem_Result = objGlobals.LState_Error.Clone();
            }
            

            return objOItem_Result;
        }
    }
}

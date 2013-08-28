using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Word;
using System.IO;

namespace Office_Module
{
    class clsWordWork
    {
        private const int wdFieldEmpty = -1;
        private const int wdCharacter = 1;
        private const int wdBulletGallery = 1;
        private const int wdTrailingTab = 0;
        private const int wdListNumberStyleBullet = 23;
        private const int wdListApplyToWholeList = 0;
        private const int wdWord10ListBehavior = 2;
        private const int wdSortByName = 0;
        private const int wdGoToBookmark = -1;

        private Application objWord;
        private List<clsWordDoc> objWordDocs = new List<clsWordDoc>();
        private string strFilePath_LastAction;
        private string strFileName;

        private Guid DocID;
        private bool boolVisible = false;

        public string FilePath_LastAction { get; set; }
        public string FilePath_Active_Doc { get; set; }
        public string FileName_Active_Doc { get; set; }

        public bool Visible
        {
            get { return boolVisible; }
            set
            {
                boolVisible = value;
                try
                {
                    objWord.Visible = boolVisible;
                }
                catch (Exception e)
                {
                }
            }

        }

        public bool isDocOpen(string strNameDoc, bool boolActivate)
        {
            bool boolOpen = false;

            openWord();
            if (objWord != null)
            {
                foreach (Document objWordDoc in objWord.Documents)
                {
                    if (objWordDoc.Name.ToLower().Contains(strNameDoc.ToLower()))
                    {
                        if (boolActivate)
                        {
                            objWordDoc.Activate();
                        }
                        boolOpen = true;
                        break;
                    }
                }
            }
            return boolOpen;
        }

        public bool activateDoc(string strNameDoc)
        {
            bool boolActivate;

            boolActivate = false;
            if (objWord != null)
            {
                foreach (Document objWordDoc in objWord.Documents)
                {
                    if (objWordDoc.Name.ToLower().Contains(strNameDoc.ToLower()))
                    {

                        objWordDoc.Activate();
                        boolActivate = true;
                        break;
                    }
                }
            }
            return boolActivate;
        }

        public bool openWord()
        {
            try
            {
                objWord = Marshal.GetActiveObject("Word.Application") as Application;
                objWord.Visible = boolVisible;
            }
            catch (Exception ex)
            {
                objWord = new Application();
                if (boolVisible = true)
                {
                    objWord.Visible = boolVisible;
                }

            }

            if (objWord != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool closeWord()
        {
            try
            {
                if (objWord != null)
                {
                    objWord.Documents.Close(false);
                    objWord.Quit();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            
        
        }

        public DateTime? getChangeDate(string idDoc)
        {
            DateTime? dateLastAccess;
            var objWordDoc = (from objDoc in objWordDocs
                              where objDoc.ID_Doc == idDoc
                              select objDoc).ToList();

            if (objWordDoc.Any())
            {
                dateLastAccess = File.GetLastAccessTime(objWordDoc.First().PathDoc);
            }
            else
            {
                dateLastAccess = null;
            }

            return dateLastAccess;
        }

        public string openDocument(string strPathDoc, string strCategory, string strName, string strPathTemplate)
        {
            string idDoc;
            Document objWordDoc_active = null;
            bool boolOpen = true;
            openWord();
            idDoc = Guid.NewGuid().ToString();
            try
            {
                if (File.Exists(strPathDoc))
                {
                    foreach (Document objWordDoc_activeTmp in objWord.Documents)
                    {
                        if ((objWordDoc_activeTmp.Path + "\\" + objWordDoc_activeTmp.Name).ToLower() == strPathDoc.ToLower())
                        {
                            objWordDoc_activeTmp.Activate();
                            objWordDoc_active = objWordDoc_activeTmp;
                            boolOpen = false;
                        }
                    }
                    
                    
                                                       
                    if (boolOpen == true)
                    {
                        objWordDocs.Add(new clsWordDoc() 
                        { 
                            ID_Doc = idDoc,
                            PathDoc = strPathDoc,
                            WordDoc = objWord.Documents.Open(strPathDoc) 
                        } );
                    }
                    else
                    {
                        objWordDocs.Add(new clsWordDoc() 
                        { 
                            ID_Doc = idDoc,
                            PathDoc = strPathDoc,
                            WordDoc = objWordDoc_active 
                        } );
                    }
                }
                else
                {
                    Document objDocument;
                    if (File.Exists(strPathTemplate))
                    {
                        objDocument = objWord.Documents.Add(strPathTemplate);
                    }
                    else
                    {
                        objDocument = objWord.Documents.Add();
                    }
                    
                    objWordDocs.Add(new clsWordDoc() 
                        { 
                            ID_Doc = idDoc,
                            PathDoc = strPathDoc,
                            WordDoc =  objDocument
        
                        } );
                    
                    
                    objDocument.SaveAs(strPathDoc);


                }

                if (strName == "")
                {
                    objWord.ActiveDocument.BuiltInDocumentProperties["TITLE"] = strName;
                    objWord.ActiveDocument.BuiltInDocumentProperties["CATEGORY"] = strCategory;
                    objWord.ActiveDocument.Fields.Update();
                }

                return idDoc;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool closeWordDoc(string idDoc)
        {
            var objLDocs = (from objDoc in objWordDocs
                            where objDoc.ID_Doc == idDoc 
                            select objDoc).ToList();

            if (objLDocs.Any())
            {
                try
                {
                    objLDocs.First().WordDoc.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            else
            {
                return true;
            }

            
        }

        public bool activateBookmark(string strTitle, string strDocName)
        {
            bool boolResult = false;

            try
            {
                openWord();
                foreach (Document objDocument in objWord.Documents)
                {
                    if (objDocument.Name.ToLower() == strDocName.ToLower())
                    {
                        objDocument.Activate();
                        objWord.Selection.GoTo(What:wdGoToBookmark, 
                                               Name: strTitle);
                        objDocument.Bookmarks.DefaultSorting = wdSortByName;
                        objDocument.Bookmarks.ShowHidden = false;
                            
                        boolResult = true;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                boolResult = false;
            }

            return boolResult;
        }

    }

    


}

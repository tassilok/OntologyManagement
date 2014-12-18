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
        private const WdListGalleryType wdBulletGallery = WdListGalleryType.wdBulletGallery;
        private const int wdTrailingTab = 0;
        private const WdListNumberStyle wdListNumberStyleBullet = WdListNumberStyle.wdListNumberStyleBullet;
        private const int wdListApplyToWholeList = 0;
        private const int wdWord10ListBehavior = 2;
        private const int wdSortByName = 0;
        private const int wdGoToBookmark = -1;

        private Application objWord;
        private List<clsWordDoc> objWordDocs = new List<clsWordDoc>();
        private string strFilePath_LastAction;
        private string strFileName;

        private ContentControl objContentControl;

        private Guid DocID;
        private bool boolVisible = false;

        public string FilePath_LastAction { get; set; }
        public string FilePath_Active_Doc 
        { 
            get 
            {
                if (openWord())
                {
                    return objWord.ActiveDocument.Path;
                }
                else
                {
                    return null;
                }
            }

        }
        public string FileName_Active_Doc 
        {
            get
            {
                if (openWord())
                {
                    return objWord.ActiveDocument.Name;
                }
                else
                {
                    return null;
                }
            }
        }

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
            strPathDoc = Environment.ExpandEnvironmentVariables(strPathDoc);
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

        public List<clsContentObject> getContentObject(string idDoc)
        {
            Document objWordDoc;
            List<clsContentObject> objContentObjects = new List<clsContentObject>();
            int intContentObjectID = 0;

            try
            {
                openWord();
                if (objWord.Documents.Count > 0)
                {
                    if (idDoc == null) 
                    {
                        objWordDoc = objWord.ActiveDocument;
                        
                        foreach (ContentControl objContentControl in objWordDoc.ContentControls)
                        {

                            objContentObjects.Add(new clsContentObject()
                            {
                                NameDoc = objWordDoc.Name,
                                ContentItem = objContentControl
                            });

                        }
                    }
                    else
                    {
                        var objLWordDoc = (from objDoc in objWordDocs
                              where objDoc.ID_Doc == idDoc
                              select objDoc).ToList();
                        if (objLWordDoc.Any())
                        {
                            objWordDoc = objLWordDoc.First().WordDoc;

                            foreach (ContentControl objContentControl in objWordDoc.ContentControls)
                            {

                                objContentObjects.Add(new clsContentObject()
                                {
                                    NameDoc = objWordDoc.Name,
                                    ContentItem = objContentControl
                                });

                            }
                        }
                        else
                        {
                            objContentObjects = null;
                        }

                    }

                
                    
                }
                else
                {
                    objContentObjects = null;
                }

            }
            catch (Exception ex)
            {
                objContentObjects = null;
            }

            return objContentObjects;
        }

        public string insertBookmark(string ID_ContentObject)
        {
            Document objWordDoc;
            string strDocGUID;
            string strTitle;

            strTitle = ID_ContentObject;

            if (strTitle.Length==32)
            {
                strTitle = strTitle.Insert(8,"_");
                strTitle = strTitle.Insert(13,"_");
                strTitle = strTitle.Insert(18,"_");
                strTitle = strTitle.Insert(23,"_");

                strTitle = "m_" + strTitle;

                try
                {
                    openWord();
                    if (objWord.Documents.Count > 0)
                    {
                        objWordDoc = objWord.ActiveDocument;
                        strDocGUID = objWordDoc.Name;
                        strFilePath_LastAction = objWordDoc.Path;
                        if (objWordDoc.Bookmarks.Exists(strTitle))
                        {
                            objWordDoc.Bookmarks[strTitle].Delete();
                        }

                        objWordDoc.Bookmarks.Add(strTitle,objWord.Selection.Range);
                        objWordDoc.Bookmarks.DefaultSorting = wdSortByName;
                        objWordDoc.Bookmarks.ShowHidden = false;

                        
                    }
                    else
                    {
                        strDocGUID = null;
                    }

                }
                catch (Exception ex)
                {
                    strDocGUID = null;
                }
                
            }
            else
            {
                strDocGUID = null;
            }

            

            return strDocGUID;
        }

        public string insertContentControl(string strTitle, string text = null)
        {
            
            Document objWordDoc;
            string strDocGUID;

            try
            {
                openWord();
                if (objWord.Documents.Count > 0) 
                {
                    objWordDoc = objWord.ActiveDocument;
                    strDocGUID = objWordDoc.Name;
                    strFilePath_LastAction = objWordDoc.Path;
                    objContentControl = objWord.ActiveDocument.ContentControls.Add(Microsoft.Office.Interop.Word.WdContentControlType.wdContentControlRichText);
                    objContentControl.Title = strTitle;
                    objContentControl.Range.Select();
                    if (!string.IsNullOrEmpty(text))
                    {
                        objContentControl.Range.Text = text;
                    }
                }
                else
                {
                    strDocGUID = null;
                }

            }
            catch (Exception ex)
            {
                strDocGUID = null;
            }

            return strDocGUID;
        }

        public string insertDocumentContent(string strPathDoc)
        {
            Document objWordDoc;
            string strDocGUID;

            try
            {
                openWord();
                if (objWord.Documents.Count > 0)
                {
                    objWordDoc = objWord.ActiveDocument;
                    strDocGUID = objWordDoc.Name;
                    strFilePath_LastAction = objWordDoc.Path;
                    strPathDoc = strPathDoc.Replace("\\", "\\\\");
                    objWord.Selection.Fields.Add(objWord.Selection.Range, wdFieldEmpty, "INCLUDETEXT  \"" + strPathDoc + "\" ", true);
                    moveRight();
                }
                else
                {
                    strDocGUID = null;
                }

            }
            catch (Exception ex)
            {
                strDocGUID = null;
            }

            return strDocGUID;
        }

        public string insertList()
        {
            Document objWordDoc;
            ListGalleries objListGalleries;
            string strDocGUID;

            try
            {
                openWord();
                if (objWord.Documents.Count > 0)
                {
                    objListGalleries = objWord.ListGalleries;
                    objListGalleries[wdBulletGallery].ListTemplates[1].ListLevels[1].NumberFormat = char.ConvertFromUtf32((int) 61623);
                    objListGalleries[wdBulletGallery].ListTemplates[1].ListLevels[1].TrailingCharacter = wdTrailingTab;
                    objListGalleries[wdBulletGallery].ListTemplates[1].ListLevels[1].NumberStyle = wdListNumberStyleBullet;
                    objListGalleries[wdBulletGallery].ListTemplates[1].ListLevels[1].ResetOnHigher = 0;
                    objListGalleries[wdBulletGallery].ListTemplates[1].ListLevels[1].StartAt = 1;
                    objListGalleries[wdBulletGallery].ListTemplates[1].ListLevels[1].LinkedStyle = "";
                    
                    objListGalleries[wdBulletGallery].ListTemplates[1].Name = "";
                    objWordDoc = objWord.ActiveDocument;
                    strDocGUID = objWordDoc.Name;
                    strFilePath_LastAction = objWordDoc.Path;
                    objWord.Selection.Range.ListFormat.ApplyListTemplateWithLevel(ListTemplate:objListGalleries[wdBulletGallery].ListTemplates[1], 
                                                                                  ContinuePreviousList:false, 
                                                                                  ApplyTo:wdListApplyToWholeList, 
                                                                                  DefaultListBehavior:wdWord10ListBehavior);


                }
                else
                {
                    strDocGUID = null;
                }

            }
            catch (Exception ex)
            {
                strDocGUID = null;
            }

            return strDocGUID;
        }

        public string insertNewLine()
        {
            Document objWordDoc;
            string strDocGUID;

            try
            {
                openWord();
                if (objWord.Documents.Count > 0) 
                {
                    objWordDoc = objWord.ActiveDocument;
                    strDocGUID = objWordDoc.Name;
                    strFilePath_LastAction = objWordDoc.Path;
                    objWord.Selection.TypeParagraph();
                }
                else
                {
                    strDocGUID = null;
                }

            }
            catch (Exception ex)
            {
                strDocGUID = null;
            }

            return strDocGUID;
        }

        public string insertTextContent(string strTitle, string strValue)
        {
            ContentControl objContentControl;
            Document objWordDoc;
            string strDocGUID;

            try
            {
                openWord();
                if (objWord.Documents.Count > 0)
                {
                    objWordDoc = objWord.ActiveDocument;
                    strDocGUID = objWordDoc.Name;
                    strFilePath_LastAction = objWordDoc.Path;
                    objContentControl = objWord.ActiveDocument.ContentControls.Add(Microsoft.Office.Interop.Word.WdContentControlType.wdContentControlRichText);
                    objContentControl.Title = strTitle;
                    objContentControl.Range.Select();
                    objWord.Selection.TypeText(strValue);
                    moveRight();
                }
                else
                {
                    strDocGUID = null;
                }

            }
            catch (Exception ex)
            {
                strDocGUID = null;
            }

            return strDocGUID;
        }

        public string moveRight()
        {
            Document objWordDoc;
            string strDocGUID;

            try
            {
                openWord();
                if (objWord.Documents.Count > 0)
                {
                    objWordDoc = objWord.ActiveDocument;
                    strDocGUID = objWordDoc.Name;
                    strFilePath_LastAction = objWordDoc.Path;
                    objWord.Selection.MoveRight(wdCharacter, 1);
                }
                else
                {
                    strDocGUID = null;
                }

            }
            catch (Exception ex)
            {
                strDocGUID = null;
            }

            return strDocGUID;
        }

        public bool saveWordDoc(string idDoc = null)
        {
            Document objWordDoc;
            try
            {
                if (idDoc == null)
                {
                    objWord.ActiveDocument.Save();
                }
                else
                {
                    var objLWordDoc = (from objDoc in objWordDocs
                              where objDoc.ID_Doc == idDoc
                              select objDoc).ToList();
                    if (objLWordDoc.Any())
                    {
                        objWordDoc = objLWordDoc.First().WordDoc;
                        objWordDoc.SaveAs(objLWordDoc.First().PathDoc);
                    }
                    
                }

                return true;
            }
            catch (Exception ex)
            {
            return false;
            }
        }

        public string typeText(string strText)
        {
            Document objWordDoc;
            string strDocGUID;

        try
        {
            openWord();
            if (objWord.Documents.Count > 0)
            {
                objWordDoc = objWord.ActiveDocument;
                strDocGUID = objWordDoc.Name;
                strFilePath_LastAction = objWordDoc.Path;
                objWord.Selection.TypeText(strText);
            }
            else
            {
                strDocGUID = null;
            }

        }
        catch (Exception ex)
        {
            strDocGUID = null;
        }

        return strDocGUID;
        }

    }

    


}

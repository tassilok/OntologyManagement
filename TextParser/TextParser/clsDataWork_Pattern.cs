using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ontology_Module;
using OntologyClasses.BaseClasses;

namespace TextParser
{
    public class clsDataWork_Pattern
    {
        private clsLocalConfig localConfig;

        private clsDBLevel dbLevel_PatternLeftRight;
        private clsDBLevel dbLevel_PatternRightLeft;
        private clsDBLevel dbLevel_PatternAtt;

        public clsOntologyItem OItem_Ref { get; private set; }

        public clsOntologyItem Result { get; private set;  }

        public List<clsSearchPattern> SearchPatterns { get; set; } 


        private Thread threadPattern;

        private bool doLeftRight;

        public delegate void LoadedData(clsOntologyItem oItem_Result);

        public event LoadedData LoadedPattern;

        public clsDataWork_Pattern(clsLocalConfig localConfig)
        {
            this.localConfig = localConfig;

            Initialize();
        }

        public void GetData(clsOntologyItem oItem_Ref = null)
        {
            OItem_Ref = oItem_Ref;
            try
            {
                threadPattern.Abort();
            }
            catch (Exception)
            {
                
                
            }

            threadPattern = new Thread(_GetData);
            threadPattern.Start();
        }

        private void _GetData()
        {
            var oItem_Result = GetSubData_001_Pattern();

            if (oItem_Result.GUID == localConfig.Globals.LState_Success.GUID)
            {
                oItem_Result = GetSubData_002_PatternAtt();
            }

            if (LoadedPattern != null)
            {
                Result = oItem_Result;
                LoadedPattern(Result);
            }
        }

        private clsOntologyItem GetSubData_001_Pattern()
        {
            SearchPatterns = new List<clsSearchPattern>();
            var result = localConfig.Globals.LState_Success.Clone();
            if (OItem_Ref != null)
            {
                var searchPattern = new List<clsObjectRel>
                {
                    new clsObjectRel
                    {
                        ID_Object = OItem_Ref.GUID,
                        ID_Parent_Other = localConfig.OItem_class_pattern.GUID
                    }
                };

                result = dbLevel_PatternLeftRight.get_Data_ObjectRel(searchPattern, boolIDs: false);

                if (dbLevel_PatternLeftRight.OList_ObjectRel.Any())
                {
                    doLeftRight = true;
                }
                else
                {
                    if (result.GUID == localConfig.Globals.LState_Success.GUID)
                    {

                        searchPattern = new List<clsObjectRel>
                        {
                            new clsObjectRel
                            {
                                ID_Other = OItem_Ref.GUID,
                                ID_Parent_Object = localConfig.OItem_class_pattern.GUID
                            }
                        };

                        result = dbLevel_PatternRightLeft.get_Data_ObjectRel(searchPattern, boolIDs: false);

                        doLeftRight = false;

                    }    
                }

                

            }
            else
            {
                var searchPattern = new List<clsOntologyItem>
                {
                    new clsOntologyItem {GUID_Parent = localConfig.OItem_class_pattern.GUID}
                };

                result = dbLevel_PatternLeftRight.get_Data_Objects(searchPattern);
            }

            return result;
        }

        private clsOntologyItem GetSubData_002_PatternAtt()
        {
            var result = localConfig.Globals.LState_Success.Clone();

            List<clsObjectAtt> searchPattern;
            if (OItem_Ref != null)
            {
                if (doLeftRight)
                {
                    searchPattern = dbLevel_PatternLeftRight.OList_ObjectRel.Select(pat => new clsObjectAtt
                    {
                        ID_Object = pat.ID_Other,
                        ID_AttributeType = localConfig.OItem_attributetype_pattern.GUID
                    }).ToList();    
                }
                else
                {
                    searchPattern = dbLevel_PatternRightLeft.OList_ObjectRel.Select(pat => new clsObjectAtt
                    {
                        ID_Object = pat.ID_Object,
                        ID_AttributeType = localConfig.OItem_attributetype_pattern.GUID
                    }).ToList();        
                }
                

                
            }
            else
            {
                searchPattern = dbLevel_PatternLeftRight.OList_Objects.Select(pat => new clsObjectAtt
                {
                    ID_Object = pat.GUID,
                    ID_AttributeType = localConfig.OItem_attributetype_pattern.GUID
                }).ToList();    
            }


            if (searchPattern.Any())
            {
                result = dbLevel_PatternAtt.get_Data_ObjectAtt(searchPattern, boolIDs: false);    
            }
            else
            {
                dbLevel_PatternAtt.OList_ObjectAtt.Clear();
            }
            

            if (result.GUID == localConfig.Globals.LState_Success.GUID)
            {
                if (OItem_Ref == null)
                {
                    SearchPatterns = (from pattern in dbLevel_PatternLeftRight.OList_Objects
                        join att in dbLevel_PatternAtt.OList_ObjectAtt on pattern.GUID equals att.ID_Object
                        select new clsSearchPattern
                        {
                            IdPattern = pattern.GUID,
                            NamePattern = pattern.Name,
                            IdAttributePattern = att.ID_Attribute,
                            Pattern = att.Val_String

                        }).ToList();    
                }
                else
                {
                    if (doLeftRight)
                    {
                        SearchPatterns = (from pattern in dbLevel_PatternLeftRight.OList_ObjectRel
                                          join att in dbLevel_PatternAtt.OList_ObjectAtt on pattern.ID_Other equals att.ID_Object
                                          select new clsSearchPattern
                                          {
                                              IdPattern = pattern.ID_Other,
                                              NamePattern = pattern.Name_Other,
                                              IdAttributePattern = att.ID_Attribute,
                                              Pattern = att.Val_String,
                                              IdRef = pattern.ID_Object,
                                              NameRef = pattern.Name_Object

                                          }).ToList();    
    
                    }
                    else
                    {
                        SearchPatterns = (from pattern in dbLevel_PatternRightLeft.OList_ObjectRel
                                          join att in dbLevel_PatternAtt.OList_ObjectAtt on pattern.ID_Object equals att.ID_Object
                                          select new clsSearchPattern
                                          {
                                              IdPattern = pattern.ID_Object,
                                              NamePattern = pattern.Name_Object,
                                              IdAttributePattern = att.ID_Attribute,
                                              Pattern = att.Val_String,
                                              IdRef = pattern.ID_Other,
                                              NameRef = pattern.Name_Other

                                          }).ToList();    

                    }
                    
                }
                
            }
            else
            {
                SearchPatterns.Clear();
            }

            return result;
        }

        public void Abort()
        {
            try
            {
                threadPattern.Abort();
            }
            catch (Exception)
            {
                
                
            }
        }

        private void Initialize()
        {
            dbLevel_PatternLeftRight = new clsDBLevel(localConfig.Globals);
            dbLevel_PatternRightLeft = new clsDBLevel(localConfig.Globals);
            dbLevel_PatternAtt = new clsDBLevel(localConfig.Globals);
        }
    }
}

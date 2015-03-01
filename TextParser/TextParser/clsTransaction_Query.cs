using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.BaseClasses;
using Ontology_Module;

namespace TextParser
{
    public class clsTransaction_Query
    {
        private clsLocalConfig localConfig;
        private clsTransaction transation;
        private clsRelationConfig relationConfig;

        public clsOntologyItem OItem_Ref { get; set; }
        private clsOntologyItem OItem_LoadResult;

        public clsTransaction_Query(clsLocalConfig localConfig)
        {
            this.localConfig = localConfig;
            Initialize();
        }

        private void Initialize()
        {
            if (localConfig.DataWork_Pattern == null)
            {
                localConfig.DataWork_Pattern = new clsDataWork_Pattern(localConfig);
                localConfig.DataWork_Pattern.LoadedPattern += DataWork_Pattern_LoadedPattern;
            }

            transation = new clsTransaction(localConfig.Globals);
            relationConfig = new clsRelationConfig(localConfig.Globals);
        }

        public clsOntologyItem SaveSearchPattern(clsOntologyItem oItem_Parser, string searchPattern)
        {
            

            if (localConfig.DataWork_Pattern.OItem_Ref == null || localConfig.DataWork_Pattern.OItem_Ref.GUID != oItem_Parser.GUID)
            {
                localConfig.DataWork_Pattern.GetData(oItem_Parser);
                OItem_LoadResult = localConfig.Globals.LState_Nothing.Clone();
            }
            else
            {
                OItem_LoadResult = localConfig.Globals.LState_Success.Clone();
            }

            while (OItem_LoadResult.GUID == localConfig.Globals.LState_Nothing.GUID)
            {

            }

            if (OItem_LoadResult.GUID == localConfig.Globals.LState_Success.GUID)
            {
                transation.ClearItems();
                if (localConfig.DataWork_Pattern.SearchPatterns.All(pat => pat.Pattern != searchPattern))
                {
                    var newPattern = new clsOntologyItem
                    {
                        GUID = localConfig.Globals.NewGUID,
                        Name = searchPattern.Length > 255 ? searchPattern.Substring(0, 254) : searchPattern,
                        GUID_Parent = localConfig.OItem_class_pattern.GUID,
                        Type = localConfig.Globals.Type_Object
                    };

                    OItem_LoadResult = transation.do_Transaction(newPattern);
                    if (OItem_LoadResult.GUID == localConfig.Globals.LState_Success.GUID)
                    {
                        var relPattern = relationConfig.Rel_ObjectRelation(oItem_Parser, newPattern,
                            localConfig.OItem_relationtype_contains);
                        OItem_LoadResult = transation.do_Transaction(relPattern);

                        if (OItem_LoadResult.GUID == localConfig.Globals.LState_Success.GUID)
                        {
                            var attPattern = relationConfig.Rel_ObjectAttribute(newPattern,
                                localConfig.OItem_attributetype_pattern, searchPattern);

                            OItem_LoadResult = transation.do_Transaction(attPattern);
                            if (OItem_LoadResult.GUID == localConfig.Globals.LState_Success.GUID)
                            {
                                localConfig.DataWork_Pattern.SearchPatterns.Add(new clsSearchPattern
                                {
                                    IdPattern = newPattern.GUID,
                                    NamePattern = newPattern.Name,
                                    IdAttributePattern = transation.OItem_Last.OItem_ObjectAtt.ID_Attribute,
                                    Pattern = searchPattern,
                                    IdRef = oItem_Parser.GUID,
                                    NameRef = oItem_Parser.Name
                                });
                            }
                            else
                            {
                                transation.rollback();
                            }
                        }
                        else
                        {
                            transation.rollback();
                        }

                    }
                }

            }

            return OItem_LoadResult;
        }

        void DataWork_Pattern_LoadedPattern(clsOntologyItem oItem_Result)
        {
            OItem_LoadResult = oItem_Result;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lucene.Net.Index;
using Lucene.Net.Search;

namespace OntWeb.Classes
{
    public class BoolQueryWorker
    {
        public BooleanQuery SimpleQuery(List<OntologyItem> OList_Items, string Ontology)
        {
            BooleanQuery BoolQuery = new BooleanQuery();
            Boolean HasGUID;

            string Field_IDParent;
            string QueryString;

            if (Ontology == Globals.Type_AttributeType)
            {

                Field_IDParent = Globals.Field_ID_DataType;
            }
            else if (Ontology == Globals.Field_ID_Class)
            {
                Field_IDParent = Globals.Field_ID_Class;
            }
            else
            {
                Field_IDParent = Globals.Field_ID_Parent;
            }

            HasGUID = false;
            if (OList_Items != null)
            {
                if (OList_Items.Any())
                {
                    if (Ontology == Globals.Type_AttributeType ||
                        Ontology == Globals.Type_RelationType ||
                        Ontology == Globals.Type_Class ||
                        Ontology == Globals.Type_Object ||
                        Ontology == Globals.Type_DataType)
                    {
                        var objLQuery_ID = from OntologyItem obj  in  OList_Items
                                           group obj by obj.GUID_Item
                                           into obj1
                                           select obj1;

                        QueryString = "";

                        foreach (var objQuery_ID in objLQuery_ID)
                        {
                            if (!String.IsNullOrEmpty(objQuery_ID.Key))
                            {
                                if (QueryString != "") QueryString += "\\ OR\\ ";

                                QueryString += objQuery_ID.Key;
                            }
                        }

                        if (QueryString != "")
                        {
                            HasGUID = true;
                            BoolQuery.Add(new TermQuery(new Term(Globals.Field_ID_Item, QueryString)),
                                          BooleanClause.Occur.MUST);
                        }

                    }

                    if (HasGUID == false)
                    {
                        
                        if (Ontology == Globals.Type_AttributeType ||
                            Ontology == Globals.Type_RelationType ||
                            Ontology == Globals.Type_Class ||
                            Ontology == Globals.Type_Object ||
                            Ontology == Globals.Type_DataType)
                        {
                            var objLQuery_Name = from OntologyItem obj in OList_Items
                                                 group obj by obj.Name_Item
                                                     into obj1
                                                     select obj1;

                            QueryString = "";

                            foreach (var objQuery_Name in objLQuery_Name)
                            {
                                if (!String.IsNullOrEmpty(objQuery_Name.Key))
                                {
                                    if (QueryString != "") QueryString += "\\ OR\\ ";

                                    QueryString += "*" + objQuery_Name.Key + "*";
                                }
                            }

                            if (QueryString != "")
                            {
                                HasGUID = true;
                                BoolQuery.Add(new WildcardQuery(new Term(Globals.Field_Name_Item, QueryString)),
                                              BooleanClause.Occur.MUST);
                            }
                        }

                        
                        if (Ontology == Globals.Type_AttributeType ||
                            Ontology == Globals.Type_RelationType ||
                            Ontology == Globals.Type_Class ||
                            Ontology == Globals.Type_Object ||
                            Ontology == Globals.Type_DataType)
                        {
                            var objLQuery_IDParent = from OntologyItem obj in OList_Items
                                               group obj by obj.GUID_Parent
                                                   into obj1
                                                   select obj1;

                            QueryString = "";

                            foreach (var objQuery_IDParent in objLQuery_IDParent)
                            {
                                if (!String.IsNullOrEmpty(objQuery_IDParent.Key))
                                {
                                    if (QueryString != "") QueryString += "\\ OR\\ ";

                                    QueryString += objQuery_IDParent.Key;
                                }
                            }

                            if (QueryString != "")
                            {
                                HasGUID = true;
                                BoolQuery.Add(new TermQuery(new Term(Field_IDParent, QueryString)),
                                              BooleanClause.Occur.MUST);
                            }

                        }
                    }
                }

                
            
                
            }
            if (BoolQuery.ToString() == "")
            {
                QueryString = "*";
                BoolQuery.Add(new WildcardQuery(new Term(Globals.Field_ID_Item, QueryString)),
                                          BooleanClause.Occur.MUST);
            }
            return BoolQuery;
        }

        public BooleanQuery ClassRelQuery(List<ClassRelFull> OList_Items, string Ontology)
        {
            BooleanQuery BoolQuery = new BooleanQuery();

            string QueryString;

            if (OList_Items != null)
            {
                if (OList_Items.Any())
                {
                    
                        var objLQuery_ID = from ClassRelFull obj in OList_Items
                                           group obj by obj.ClassRels
                                               into obj1
                                               select obj1;

                        QueryString = "";

                        foreach (var objQuery_ID in objLQuery_ID)
                        {
                            if (!String.IsNullOrEmpty(objQuery_ID.Key))
                            {
                                if (QueryString != "") QueryString += "\\ OR\\ ";

                                QueryString += objQuery_ID.Key;
                            }
                        }

                        if (QueryString != "")
                        {
                    
                            BoolQuery.Add(new TermQuery(new Term(Globals.Field_ID_Item, QueryString)),
                                          BooleanClause.Occur.MUST);
                        }

                    

                    
                }




            }
            if (BoolQuery.ToString() == "")
            {
                QueryString = "*";
                BoolQuery.Add(new WildcardQuery(new Term(Globals.Field_ID_Item, QueryString)),
                                          BooleanClause.Occur.MUST);
            }
            return BoolQuery;
        }
    }
}
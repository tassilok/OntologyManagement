using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElasticSearch.Client;
using ElasticSearch.Client.Config;
using ElasticSearch.Client.Domain;
using Lucene.Net.Index;
using Lucene.Net.Search;
using OntologyClasses.BaseClasses;
using OntologyClasses.DataClasses;

namespace ElasticSearchConnector
{
    [Flags]
    public enum SortEnum
    {
        ASC_Name,
        DESC_Name,
        NONE,
        ASC_OrderID,
        DESC_OrderID
    }

    public class clsDBLevel
    {
        private string strServer;
        private int intPort;
        private string strIndex;
        private string strIndexRep;
        private int intSearchRange;
        private string strSession;

        private SortEnum sort;

        private ElasticSearchClient objElConn;

        private clsDBLevel objDBLevel_Other_Objects;
        private clsDBLevel objDBLevel_Other_Classes;
        private clsDBLevel objDBLevel_Other_AttributeTypes;
        private clsDBLevel objDBLevel_Other_RelationTypes;

        private clsFields objFields = new clsFields();
        private clsTypes objTypes = new clsTypes();

        public List<clsOntologyItem> OntologyList_Objects1 { get; set; }
        public List<clsOntologyItem> OntologyList_Objects2 { get; set; }
        public List<clsObjectRel> OntologyList_ObjectRel_ID { get; set; }
        public List<clsObjectRel> OntologyList_ObjectRel { get; set; }
        public List<clsObjectTree> OntologyList_ObjectTree { get; set; }
        public List<clsOntologyItem> OntologyList_Classes1 { get; set; }
        public List<clsOntologyItem> OntologyList_Classes2 { get; set; }
        public List<clsOntologyItem> OntologyList_RelationTypes1 { get; set; }
        public List<clsOntologyItem> OntologyList_RelationTypes2 { get; set; }
        public List<clsOntologyItem> OntologyList_AttributTypes1 { get; set; }
        public List<clsOntologyItem> OntologyList_AttributTypes2 { get; set; }
        public List<clsClassRel> OntologyList_ClassRel_ID { get; set; }
        public List<clsClassRel> OntologyList_ClassRel { get; set; }
        public List<clsClassAtt> OntologyList_ClassAtt_ID { get; set; }
        public List<clsClassAtt> OntologyList_ClassAtt { get; set; }
        public List<clsObjectAtt> OntologyList_ObjAtt_ID { get; set; }
        public List<clsObjectAtt> OntologyList_ObjAtt { get; set; }
        public List<clsOntologyItem> OntologyList_DataTypes { get; set; }
        public List<clsAttribute> OntologyList_Attributes { get; set; }

        private BooleanQuery create_BoolQuery_ClassRel(List<clsClassRel> OList_ClassRel, bool boolClear = true )
        {
            var objBoolQuery = new BooleanQuery();

            if (OList_ClassRel != null)
            {
                var strQuery = "";
                if (OList_ClassRel.Any())
                {
                    strQuery = "";

                    var oL_ID_Left = (from obj in OList_ClassRel
                                      where obj.ID_Class_Left != null
                                      group obj by obj.ID_Class_Left
                                      into g
                                      select g.Key).ToList();

                    

                    foreach (var ID_Left in oL_ID_Left)
                    {
                        if (strQuery != "")
                            strQuery += "\\ OR\\ ";

                        strQuery += ID_Left;
                    }

                    if (strQuery != "")
                    {
                        objBoolQuery.Add(new TermQuery(new Term(objFields.ID_Class_Left,strQuery)),BooleanClause.Occur.MUST);
                    }

                    strQuery = "";

                    var oL_ID_Right = (from obj in OList_ClassRel
                                       where obj.ID_Class_Right != null
                                      group obj by obj.ID_Class_Right
                                          into g
                                          select g.Key).ToList();



                    foreach (var ID_Right in oL_ID_Right)
                    {
                        if (strQuery != "")
                            strQuery += "\\ OR\\ ";

                        strQuery += ID_Right;
                    }

                    if (strQuery != "")
                    {
                        objBoolQuery.Add(new TermQuery(new Term(objFields.ID_Class_Right, strQuery)), BooleanClause.Occur.MUST);
                    }

                    strQuery = "";

                    var oL_ID_RelationType = (from obj in OList_ClassRel
                                              where obj.ID_RelationType != null
                                       group obj by obj.ID_RelationType
                                           into g
                                           select g.Key).ToList();



                    foreach (var ID_RelationType in oL_ID_RelationType)
                    {
                        if (strQuery != "")
                            strQuery += "\\ OR\\ ";

                        strQuery += ID_RelationType;
                    }

                    if (strQuery != "")
                    {
                        objBoolQuery.Add(new TermQuery(new Term(objFields.ID_RelationType, strQuery)), BooleanClause.Occur.MUST);
                    }
                }
            }

            if (objBoolQuery.ToString() == "")
            {
                objBoolQuery.Add(new WildcardQuery(new Term(objFields.ID_Class_Left,"*")),BooleanClause.Occur.MUST);
            }

            return objBoolQuery;
        }

        private BooleanQuery create_BoolQuery_ObjectAtt(List<clsObjectAtt> OList_ObjectAtt, bool doJoin = false)
        {
            var objBoolQuery = new BooleanQuery();
            var strQuery = "";
            if (OList_ObjectAtt != null)
            {
                strQuery = "";

                var oL_ID_Attribute = (from obj in OList_ObjectAtt
                                       where obj.ID_Attribute != null
                                          group obj by obj.ID_Attribute
                                              into g
                                              select g.Key).ToList();



                foreach (var ID_Attribute in oL_ID_Attribute)
                {
                    if (strQuery != "")
                        strQuery += "\\ OR\\ ";

                    strQuery += ID_Attribute;
                }

                if (strQuery != "")
                {
                    objBoolQuery.Add(new TermQuery(new Term(objFields.ID_Attribute, strQuery)), BooleanClause.Occur.MUST);
                }

                strQuery = "";

                var oL_ID_AttributeType = (from obj in OList_ObjectAtt
                                           where obj.ID_AttributeType != null
                                       group obj by obj.ID_AttributeType
                                           into g
                                           select g.Key).ToList();



                foreach (var ID_AttributeType in oL_ID_AttributeType)
                {
                    if (strQuery != "")
                        strQuery += "\\ OR\\ ";

                    strQuery += ID_AttributeType;
                }

                if (strQuery != "")
                {
                    objBoolQuery.Add(new TermQuery(new Term(objFields.ID_AttributeType, strQuery)), BooleanClause.Occur.MUST);
                }

                strQuery = "";

                var oL_ID_Object = (from obj in OList_ObjectAtt
                                    where obj.ID_Object != null
                                           group obj by obj.ID_Object
                                               into g
                                               select g.Key).ToList();



                foreach (var ID_Object in oL_ID_Object)
                {
                    if (strQuery != "")
                        strQuery += "\\ OR\\ ";

                    strQuery += ID_Object;
                }

                if (strQuery != "")
                {
                    objBoolQuery.Add(new TermQuery(new Term(objFields.ID_Object, strQuery)), BooleanClause.Occur.MUST);
                }

                strQuery = "";

                var oL_ID_Class = (from obj in OList_ObjectAtt
                                   where obj.ID_Class != null
                                    group obj by obj.ID_Class
                                        into g
                                        select g.Key).ToList();



                foreach (var ID_Class in oL_ID_Class)
                {
                    if (strQuery != "")
                        strQuery += "\\ OR\\ ";

                    strQuery += ID_Class;
                }

                if (strQuery != "")
                {
                    objBoolQuery.Add(new TermQuery(new Term(objFields.ID_Class, strQuery)), BooleanClause.Occur.MUST);
                }

                strQuery = "";

                var oL_ID_DataType = (from obj in OList_ObjectAtt
                                      where obj.ID_DataType != null
                                   group obj by obj.ID_DataType
                                       into g
                                       select g.Key).ToList();



                foreach (var ID_DataType in oL_ID_DataType)
                {
                    if (strQuery != "")
                        strQuery += "\\ OR\\ ";

                    strQuery += ID_DataType;
                }

                if (strQuery != "")
                {
                    objBoolQuery.Add(new TermQuery(new Term(objFields.ID_DataType, strQuery)), BooleanClause.Occur.MUST);
                }

                strQuery = "";

                var oL_Bit = (from obj in OList_ObjectAtt
                              where obj.Val_Bit != null
                                      group obj by obj.Val_Bit
                                          into g
                                          select g.Key).ToList();



                foreach (var Val_Bit in oL_Bit)
                {
                    if (strQuery != "")
                        strQuery += "\\ OR\\ ";

                    strQuery += Val_Bit.ToString();
                }

                if (strQuery != "")
                {
                    objBoolQuery.Add(new TermQuery(new Term(objFields.Val_Bool, strQuery)), BooleanClause.Occur.MUST);
                }

                strQuery = "";

                var oL_Date = (from obj in OList_ObjectAtt
                               where obj.Val_Date != null
                              group obj by obj.Val_Date
                                  into g
                                  select g.Key).ToList();



                foreach (var Val_Date in oL_Date)
                {
                    if (strQuery != "")
                        strQuery += "\\ OR\\ ";

                    strQuery += Val_Date.ToString();
                }

                if (strQuery != "")
                {
                    objBoolQuery.Add(new TermQuery(new Term(objFields.Val_Datetime, strQuery)), BooleanClause.Occur.MUST);
                }

                strQuery = "";

                var oL_Dbl = (from obj in OList_ObjectAtt
                              where obj.Val_Double != null
                               group obj by obj.Val_Double
                                   into g
                                   select g.Key).ToList();



                foreach (var Val_Dbl in oL_Dbl)
                {
                    if (strQuery != "")
                        strQuery += "\\ OR\\ ";

                    strQuery += Val_Dbl.ToString();
                }

                if (strQuery != "")
                {
                    objBoolQuery.Add(new TermQuery(new Term(objFields.Val_Real, strQuery)), BooleanClause.Occur.MUST);
                }

                strQuery = "";

                var oL_Lng = (from obj in OList_ObjectAtt
                              where obj.Val_Lng != null
                              group obj by obj.Val_Lng
                                  into g
                                  select g.Key).ToList();



                foreach (var Val_Lng in oL_Lng)
                {
                    if (strQuery != "")
                        strQuery += "\\ OR\\ ";

                    strQuery += Val_Lng.ToString();
                }

                if (strQuery != "")
                {
                    objBoolQuery.Add(new TermQuery(new Term(objFields.Val_Int, strQuery)), BooleanClause.Occur.MUST);
                }

                strQuery = "";

                var oL_Str = (from obj in OList_ObjectAtt
                              where obj.Val_String != null
                              group obj by obj.Val_String
                                  into g
                                  select g.Key).ToList();



                foreach (var Val_Str in oL_Str)
                {
                    if (strQuery != "")
                        strQuery += "\\ OR\\ ";

                    strQuery += Val_Str;
                }

                if (strQuery != "")
                {
                    objBoolQuery.Add(new TermQuery(new Term(objFields.Val_String, strQuery)), BooleanClause.Occur.MUST);
                }

            }

            if (doJoin)
            {
                strQuery = "";

                var objLClasses = (from obj in OntologyList_Objects1
                                   where obj.GUID_Parent != null
                                   group obj by obj.GUID_Parent
                                   into g
                                   select g.Key).ToList();

                foreach (var objClass in objLClasses)
                {
                    if (strQuery != "")
                        strQuery += "\\ OR\\ ";

                    strQuery += objClass;
                }

                if (strQuery != "")
                {
                    objBoolQuery.Add(new TermQuery(new Term(objFields.ID_Class, strQuery)), BooleanClause.Occur.MUST);
                }
            }

            if (objBoolQuery.ToString() == "")
            {
                objBoolQuery.Add(new WildcardQuery(new Term(objFields.ID_Attribute,"*")),BooleanClause.Occur.MUST);

            }

            return objBoolQuery;
        }

        private BooleanQuery create_BoolQuery_ObjectRel(List<clsObjectRel> OList_ObjectRel)
        {
           var objBoolQuery = new BooleanQuery();
            var strQuery = "";
            if (OList_ObjectRel != null)
            {
                if (OList_ObjectRel.Any())
                {
                    strQuery = "";

                    var oL_IDObject = (from obj in OList_ObjectRel
                                       where obj.ID_Object != null
                                  group obj by obj.ID_Object
                                      into g
                                      select g.Key).ToList();



                    foreach (var ID_Object in oL_IDObject)
                    {
                        if (strQuery != "")
                            strQuery += "\\ OR\\ ";

                        strQuery += ID_Object;
                    }

                    if (strQuery != "")
                    {
                        objBoolQuery.Add(new TermQuery(new Term(objFields.ID_Object, strQuery)), BooleanClause.Occur.MUST);
                    }

                    strQuery = "";

                    var oL_IDParentObject = (from obj in OList_ObjectRel
                                             where obj.ID_Parent_Object != null
                                       group obj by obj.ID_Parent_Object
                                           into g
                                           select g.Key).ToList();



                    foreach (var ID_ParentObject in oL_IDParentObject)
                    {
                        if (strQuery != "")
                            strQuery += "\\ OR\\ ";

                        strQuery += ID_ParentObject;
                    }

                    if (strQuery != "")
                    {
                        objBoolQuery.Add(new TermQuery(new Term(objFields.ID_Parent_Object, strQuery)), BooleanClause.Occur.MUST);
                    }

                    strQuery = "";

                    var oL_IDOther = (from obj in OList_ObjectRel
                                             where obj.ID_Other != null
                                             group obj by obj.ID_Other
                                                 into g
                                                 select g.Key).ToList();



                    foreach (var ID_Other in oL_IDOther)
                    {
                        if (strQuery != "")
                            strQuery += "\\ OR\\ ";

                        strQuery += ID_Other;
                    }

                    if (strQuery != "")
                    {
                        objBoolQuery.Add(new TermQuery(new Term(objFields.ID_Other, strQuery)), BooleanClause.Occur.MUST);
                    }

                    strQuery = "";

                    var oL_IDParentOther = (from obj in OList_ObjectRel
                                      where obj.ID_Parent_Other != null
                                            group obj by obj.ID_Parent_Other
                                          into g
                                          select g.Key).ToList();



                    foreach (var ID_ParentOther in oL_IDParentOther)
                    {
                        if (strQuery != "")
                            strQuery += "\\ OR\\ ";

                        strQuery += ID_ParentOther;
                    }

                    if (strQuery != "")
                    {
                        objBoolQuery.Add(new TermQuery(new Term(objFields.ID_Parent_Other, strQuery)), BooleanClause.Occur.MUST);
                    }

                    strQuery = "";

                    var oL_IDRelationType = (from obj in OList_ObjectRel
                                            where obj.ID_RelationType != null
                                            group obj by obj.ID_RelationType
                                                into g
                                                select g.Key).ToList();



                    foreach (var ID_RelationType in oL_IDRelationType)
                    {
                        if (strQuery != "")
                            strQuery += "\\ OR\\ ";

                        strQuery += ID_RelationType;
                    }

                    if (strQuery != "")
                    {
                        objBoolQuery.Add(new TermQuery(new Term(objFields.ID_RelationType, strQuery)), BooleanClause.Occur.MUST);
                    }

                    strQuery = "";

                    var oL_Ontology = (from obj in OList_ObjectRel
                                             where obj.Ontology != null
                                             group obj by obj.Ontology
                                                 into g
                                                 select g.Key).ToList();



                    foreach (var ontology in oL_Ontology)
                    {
                        if (strQuery != "")
                            strQuery += "\\ OR\\ ";

                        strQuery += ontology;
                    }

                    if (strQuery != "")
                    {
                        objBoolQuery.Add(new TermQuery(new Term(objFields.Ontology, strQuery)), BooleanClause.Occur.MUST);
                    }
                }
            }

            if (objBoolQuery.ToString() == "")
            {
                objBoolQuery.Add(new WildcardQuery(new Term(objFields.ID_Object,strQuery)),BooleanClause.Occur.MUST);
            }

            return objBoolQuery;

        }

        private BooleanQuery create_BoolQuery_ClassAtt(List<clsOntologyItem> OList_Classes = null,
                                                       List<clsOntologyItem> OList_AttributeTypes = null)
        {
            BooleanQuery objBoolQuery = new BooleanQuery();
            var strQuery = "";

            if (OList_Classes != null)
            {
                if (OList_Classes.Any())
                {
                    strQuery = "";

                    var oL_ID = (from obj in OList_Classes
                                 where obj.GUID != null
                                 group obj by obj.GUID
                                     into g
                                     select g.Key).ToList();



                    foreach (var id in oL_ID)
                    {
                        if (strQuery != "")
                            strQuery += "\\ OR\\ ";

                        strQuery += id;
                    }

                    if (strQuery != "")
                    {
                        objBoolQuery.Add(new TermQuery(new Term(objFields.ID_Class, strQuery)), BooleanClause.Occur.MUST);
                    }
                }
            }

            if (OList_AttributeTypes != null)
            {
                if (OList_AttributeTypes.Any())
                {
                    strQuery = "";

                    var oL_ID = (from obj in OList_AttributeTypes
                                 where obj.GUID != null
                                 group obj by obj.GUID
                                     into g
                                     select g.Key).ToList();



                    foreach (var id in oL_ID)
                    {
                        if (strQuery != "")
                            strQuery += "\\ OR\\ ";

                        strQuery += id;
                    }

                    if (strQuery != "")
                    {
                        objBoolQuery.Add(new TermQuery(new Term(objFields.ID_AttributeType, strQuery)), BooleanClause.Occur.MUST);
                    }
                }
            }

            if (objBoolQuery.ToString() == "")
            {
                objBoolQuery.Add(new WildcardQuery(new Term(objFields.ID_Class, "*")),BooleanClause.Occur.MUST);
            }

            return objBoolQuery;
        }

        private BooleanQuery create_BoolQuery_Simple(List<clsOntologyItem> OList_Items, string strOntology)
        {
            var strQuery = "";
            var strField_IDParent = "";

            if (strOntology == objTypes.AttributeType)
            {
                strField_IDParent = objFields.ID_DataType;
            }
            else if (strOntology == objTypes.ObjectType)
            {
                strField_IDParent = objFields.ID_Class;
            }
            else
            {
                strField_IDParent = objFields.ID_Parent;
            }

            var objBoolQuery = new BooleanQuery();

            if (OList_Items != null)
            {
                if (OList_Items.Any())
                {
                    strQuery = "";
                    var boolID = false;
                    var oL_ID = (from obj in OList_Items
                                       where obj.GUID != null
                                       group obj by obj.GUID
                                           into g
                                           select g.Key).ToList();



                    foreach (var id in oL_ID)
                    {
                        if (strQuery != "")
                            strQuery += "\\ OR\\ ";

                        strQuery += id;
                    }

                    if (strQuery != "")
                    {
                        boolID = true;
                        objBoolQuery.Add(new TermQuery(new Term(objFields.ID_Item, strQuery)), BooleanClause.Occur.MUST);
                    }

                    if (!boolID)
                    {
                        strQuery = "";
                        var oL_Name = (from obj in OList_Items
                                     where obj.Name != null
                                     group obj by obj.Name
                                         into g
                                         select g.Key).ToList();



                        foreach (var name in oL_Name)
                        {
                            if (strQuery != "")
                                strQuery += "\\ OR\\ ";

                            strQuery += name;
                        }

                        if (strQuery != "")
                        {
                            objBoolQuery.Add(new WildcardQuery(new Term(objFields.Name_Item, strQuery)), BooleanClause.Occur.MUST);
                        }

                        if (strOntology == objTypes.AttributeType ||
                            strOntology == objTypes.ClassType ||
                            strOntology == objTypes.ObjectType)
                        {
                            strQuery = "";
                            var oL_IDParent = (from obj in OList_Items
                                         where obj.GUID_Parent != null
                                         group obj by obj.GUID_Parent
                                             into g
                                             select g.Key).ToList();



                            foreach (var idParent in oL_IDParent)
                            {
                                if (strQuery != "")
                                    strQuery += "\\ OR\\ ";

                                strQuery += idParent;
                            }

                            if (strQuery != "")
                            {
                                boolID = true;
                                objBoolQuery.Add(new TermQuery(new Term(strField_IDParent, strQuery)), BooleanClause.Occur.MUST);
                            }

                        }
                    }
                }
            }

            if (objBoolQuery.ToString() == "")
            {
                objBoolQuery.Add(new WildcardQuery(new Term(objFields.ID_Item, strQuery)),BooleanClause.Occur.MUST);
            }

            return objBoolQuery;
        }

        private BooleanQuery create_Query_Att_OrderID(clsOntologyItem OItem_Object = null,
                                                      clsOntologyItem OItem_AttributeType = null)
        {
            var objBoolQuery = new Lucene.Net.Search.BooleanQuery();

            var strQuery = "";

            if (OItem_Object != null)
            {
                if (OItem_Object.GUID != null)
                {
                    strQuery = OItem_Object.GUID;
                }

                if (strQuery != "")
                {
                    objBoolQuery.Add(new TermQuery(new Term(objFields.ID_Object,strQuery)),BooleanClause.Occur.MUST);
                }

                strQuery = "";

                if (OItem_Object.GUID_Parent != null)
                {
                    strQuery = OItem_Object.GUID_Parent;
                }

                if (strQuery != null)
                {
                    objBoolQuery.Add(new TermQuery(new Term(objFields.ID_Class, strQuery)), BooleanClause.Occur.MUST);
                }
            }

            if (OItem_AttributeType != null)
            {
                if (OItem_AttributeType.GUID != null)
                {
                    strQuery = OItem_AttributeType.GUID;
                }

                if (strQuery != "")
                {
                    objBoolQuery.Add(new TermQuery(new Term(objFields.ID_AttributeType, strQuery)), BooleanClause.Occur.MUST);
                }

                
            }

            return objBoolQuery;
        }

        private BooleanQuery create_Query_Rel_OrderID(clsOntologyItem OItem_Left = null,
                                                      clsOntologyItem OItem_Right = null,
                                                      clsOntologyItem OItem_RelationType = null)
        {
            var objBoolQuery = new Lucene.Net.Search.BooleanQuery();

            if (OItem_Left != null)
            {

                if (OItem_Left.GUID != null)
                {
                    objBoolQuery.Add(new TermQuery(new Term(objFields.ID_Object, OItem_Left.GUID)), BooleanClause.Occur.MUST);
                }

                if (OItem_Left.GUID_Parent != null)
                {
                    objBoolQuery.Add(new TermQuery(new Term(objFields.ID_Parent_Object, OItem_Left.GUID_Parent)), BooleanClause.Occur.MUST);
                }

            }

            if (OItem_Right != null)
            {
                
                if (OItem_Right.GUID != null)
                {
                    objBoolQuery.Add(new TermQuery(new Term(objFields.ID_Other, OItem_Right.GUID)), BooleanClause.Occur.MUST);
                }

                if (OItem_Right.GUID_Parent != null)
                {
                    objBoolQuery.Add(new TermQuery(new Term(objFields.ID_Parent_Other, OItem_Right.GUID_Parent)), BooleanClause.Occur.MUST);
                }

                
                if (OItem_Right.Type != null)
                {
                    objBoolQuery.Add(new TermQuery(new Term(objFields.Ontology,OItem_Right.Type)),BooleanClause.Occur.MUST);
                }
            }

            if (OItem_RelationType != null)
            {

                if (OItem_RelationType.GUID != null)
                {
                    objBoolQuery.Add(new TermQuery(new Term(objFields.ID_RelationType, OItem_RelationType.GUID)), BooleanClause.Occur.MUST);
                }

               

            }

            return objBoolQuery;
        }

        public long get_Data_Att_OrderByVal(string strOrderField,
                                            clsOntologyItem OItem_Object = null,
                                            clsOntologyItem OItem_AttributeType = null,
                                            bool doASC = true)
        {
            SearchResult objSearchResult;

            var strSort = strOrderField + ":";
            if (doASC)
            {
                strSort += "asc";
            }
            else
            {
                strSort += "desc";
            }

            var objBoolQuery = create_Query_Att_OrderID(OItem_Object, OItem_AttributeType);

            try
            {
                objSearchResult = objElConn.Search(strIndex, objTypes.ObjectAtt, objBoolQuery.ToString(), strSort, 0, 1);
            }
            catch (Exception)
            {
                try
                {
                    objSearchResult = objElConn.Search(strIndex, objTypes.ObjectAtt, objBoolQuery.ToString(), strSort, 0, 1);
                }
                catch (Exception)
                {
                    
                    throw;
                }
                
            }

            long lngOrderID = 0;

            List<ElasticSearch.Client.Domain.Hits>  objList = objSearchResult.GetHits().Hits;
            if (objList.Any())
            {
                long.TryParse(objList.First().Source[strOrderField].ToString(),out lngOrderID);
            }

            return lngOrderID;
        }

        private void initialize_Client()
        {
            objElConn = new ElasticSearchClient(strServer,intPort,TransportType.Thrift);

            try
            {
                objElConn.CreateIndex(strIndexRep);
            }
            catch (Exception)
            {
                
                throw new Exception("Report index!");
            }
        }

        public long get_Data_AttributeTypeCount(List<clsOntologyItem> OList_AttType = null)
        {
            SearchResult objSearchResult;

            OntologyList_AttributTypes1.Clear();

            var objBoolQuery = create_BoolQuery_Simple(OList_AttType, objTypes.AttributeType);

            
            try
            {
                objSearchResult = objElConn.Search(strIndex, objTypes.AttributeType, objBoolQuery.ToString(), 0, 1);
            }
            catch (Exception)
            {

                try
                {
                    objSearchResult = objElConn.Search(strIndex, objTypes.AttributeType, objBoolQuery.ToString(), 0,
                                                    1);
                }
                catch (Exception)
                {

                    throw;
                }
            }

            var lngCount = objSearchResult.GetTotalCount();

            return lngCount;
        }

        public List<clsOntologyItem> get_Data_AttributeType(List<clsOntologyItem> OList_AttType = null)
        {
            SearchResult objSearchResult;

            OntologyList_AttributTypes1.Clear();

            var objBoolQuery = create_BoolQuery_Simple(OList_AttType, objTypes.AttributeType);

            var intCount = intSearchRange;
            var intPos = 0;

            while (intCount>0)
            {
                intCount = 0;

                try
                {
                    objSearchResult = objElConn.Search(strIndex, objTypes.AttributeType, objBoolQuery.ToString(), intPos,
                                                       intSearchRange);
                }
                catch (Exception)
                {

                    try
                    {
                        objSearchResult = objElConn.Search(strIndex, objTypes.AttributeType, objBoolQuery.ToString(), intPos,
                                                       intSearchRange);
                    }
                    catch (Exception)
                    {
                        
                        throw;
                    }
                }

               
                var objList = objSearchResult.GetHits().Hits;

                OntologyList_AttributTypes1.AddRange((from objHit in objList
                                                        select new clsOntologyItem
                                                            {
                                                                GUID = objHit.Id,
                                                                Name = objHit.Source[objFields.Name_Item].ToString(),
                                                                GUID_Parent =
                                                                    objHit.Source[objFields.ID_DataType].ToString(),
                                                                Type = objTypes.AttributeType
                                                            }).ToList());

                intCount = objList.Count;
                intPos += intCount;
                


            }

            return OntologyList_AttributTypes1;
        }

        public long get_Data_ClassAttCount(List<clsOntologyItem> OList_Class = null,
                                           List<clsOntologyItem> OList_AttributeType = null)
        {
            SearchResult objSearchResult;

            var objBoolQuery = create_BoolQuery_ClassAtt(OList_Class,OList_AttributeType);

            OntologyList_ClassAtt_ID.Clear();

            try
            {
                objSearchResult = objElConn.Search(strIndex, objTypes.ClassAtt, objBoolQuery.ToString(), 0, 1);
            }
            catch (Exception)
            {

                try
                {
                    objSearchResult = objElConn.Search(strIndex, objTypes.ClassAtt, objBoolQuery.ToString(), 0,
                                                    1);
                }
                catch (Exception)
                {

                    throw;
                }
            }

            var lngCount = objSearchResult.GetTotalCount();

            return lngCount;
        }

        public List<clsClassAtt> get_Data_ClassAtt(List<clsOntologyItem> OList_Class = null,
                                           List<clsOntologyItem> OList_AttributeType = null,
                                           bool boolIDs = true)
        {
            SearchResult objSearchResult;

            OntologyList_ClassAtt_ID.Clear();
            OntologyList_ClassAtt.Clear();

            var objBoolQuery = create_BoolQuery_ClassAtt(OList_Class, OList_AttributeType);

            OntologyList_ClassAtt_ID.Clear();
            OntologyList_ClassAtt.Clear();

            var intCount = intSearchRange;
            var intPos = 0;

            while (intCount > 0)
            {
                try
                {
                    objSearchResult = objElConn.Search(strIndex, objTypes.ClassAtt, objBoolQuery.ToString(), intPos, intSearchRange);
                }
                catch (Exception)
                {

                    try
                    {
                        objSearchResult = objElConn.Search(strIndex, objTypes.ClassAtt, objBoolQuery.ToString(), intPos, intSearchRange);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }

                var objList = objSearchResult.GetHits().Hits;
                OntologyList_ClassAtt_ID.AddRange((from objHit in objList 
                                                   select new clsClassAtt {ID_AttributeType =  objHit.Source[objFields.ID_AttributeType].ToString(),
                                                                           ID_DataType = objHit.Source[objFields.ID_DataType].ToString(),
                                                                           ID_Class = objHit.Source[objFields.ID_Class].ToString(),
                                                                           Min = (long?)objHit.Source[objFields.Min],
                                                                           Max = (long?)objHit.Source[objFields.Max]}).ToList());

                intCount = objList.Count;
                intPos += intCount;
            }

            if (!boolIDs)
            {
                var oList_AttributeTypes = (from objAttributeType in OntologyList_ClassAtt_ID
                                            group objAttributeType by objAttributeType.ID_AttributeType
                                            into g
                                            select new clsOntologyItem {GUID = g.Key}).ToList();
                get_Data_AttributeType(oList_AttributeTypes);

                var oList_Classes = (from objClass in OntologyList_ClassAtt_ID
                                     group objClass by objClass.ID_Class
                                     into g
                                     select new clsOntologyItem {GUID = g.Key}).ToList();

                get_Data_Classes(oList_Classes);

                var oList_DataTypes = (from objDataType in OntologyList_ClassAtt_ID
                                       group objDataType by objDataType.ID_DataType
                                       into g
                                       select new clsOntologyItem {GUID = g.Key}).ToList();

                get_Data_DataTypes(oList_DataTypes);

                OntologyList_ClassAtt.AddRange((from objClassAtt in OntologyList_ClassAtt_ID
                                                join objClass in OntologyList_Classes1 on objClassAtt.ID_Class equals objClass.GUID
                                                join objAttType in OntologyList_AttributTypes1 on objClassAtt.ID_AttributeType equals objAttType.GUID
                                                join objDataType in OntologyList_DataTypes on objAttType.GUID_Parent equals  objDataType.GUID
                                                select new clsClassAtt { ID_AttributeType = objAttType.GUID,
                                                                         ID_Class = objClass.GUID,
                                                                         ID_DataType = objClassAtt.ID_DataType,
                                                                         Name_AttributeType = objAttType.Name,
                                                                         Name_Class = objClass.Name,
                                                                         Name_DataType = objDataType.Name,
                                                                         Min = objClassAtt.Min,
                                                                         Max = objClassAtt.Max
                                                                         }));
            }
            

            
            if (boolIDs)
            {
                return OntologyList_ClassAtt_ID;    
            }
            else
            {
                return OntologyList_ClassAtt;
            }
            
        }

        

        public long get_Data_ClassesCount(List<clsOntologyItem> OList_Classes = null)
        {
            SearchResult objSearchResult;

            OntologyList_AttributTypes1.Clear();

            var objBoolQuery = create_BoolQuery_Simple(OList_Classes, objTypes.ClassType);

            try
            {
                objSearchResult = objElConn.Search(strIndex, objTypes.ClassType, objBoolQuery.ToString(), 0, 1);
            }
            catch (Exception)
            {

                try
                {
                    objSearchResult = objElConn.Search(strIndex, objTypes.ClassType, objBoolQuery.ToString(), 0,
                                                    1);
                }
                catch (Exception)
                {

                    throw;
                }
            }

            var lngCount = objSearchResult.GetTotalCount();

            return lngCount;
        }

        public List<clsOntologyItem> get_Data_Classes(List<clsOntologyItem> OList_Classes = null,
                                                  bool boolClasses_Right = false,
                                                  string strSort = null,
                                                  bool boolIDs = true)
        {
            SearchResult objSearchResult;

            OntologyList_ClassAtt_ID.Clear();
            OntologyList_ClassAtt.Clear();

            var objBoolQuery = create_BoolQuery_Simple(OList_Classes,objTypes.ClassType);

            if (!boolClasses_Right)
            {
                OntologyList_Classes1.Clear();    
            }
            else
            {
                OntologyList_Classes2.Clear();    
            }
            

            var intCount = intSearchRange;
            var intPos = 0;

            while (intCount > 0)
            {
                try
                {
                    objSearchResult = objElConn.Search(strIndex, objTypes.ClassType, objBoolQuery.ToString(), intPos, intSearchRange);
                }
                catch (Exception)
                {

                    try
                    {
                        objSearchResult = objElConn.Search(strIndex, objTypes.ClassType, objBoolQuery.ToString(), intPos, intSearchRange);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }

                var objList = objSearchResult.GetHits().Hits;

                if (!boolClasses_Right)
                {
                    OntologyList_Classes1.AddRange((from objHit in objList
                                                       select new clsOntologyItem()
                                                       {
                                                           GUID = objHit.Id,
                                                           Name = objHit.Source[objFields.Name_Item].ToString(),
                                                           GUID_Parent = objHit.Source[objFields.ID_Parent_Object].ToString(),
                                                           Type = objTypes.ClassType
                                                       }).ToList());    
                }
                else
                {
                    OntologyList_Classes2.AddRange((from objHit in objList
                                                    select new clsOntologyItem()
                                                    {
                                                        GUID = objHit.Id,
                                                        Name = objHit.Source[objFields.Name_Item].ToString(),
                                                        GUID_Parent = objHit.Source[objFields.ID_Parent_Object].ToString(),
                                                        Type = objTypes.ClassType
                                                    }).ToList());    
                }
                

                intCount = objList.Count;
                intPos += intCount;
            }

            if (boolIDs)
            {
                return OntologyList_Classes1;
            }
            else
            {
                return OntologyList_Classes2;
            }

        }


        public long get_Data_DataTypesCount(List<clsOntologyItem> OList_DataTypes = null)
        {
            SearchResult objSearchResult;

            OntologyList_AttributTypes1.Clear();

            var objBoolQuery = create_BoolQuery_Simple(OList_DataTypes, objTypes.DataType);

            try
            {
                objSearchResult = objElConn.Search(strIndex, objTypes.DataType, objBoolQuery.ToString(), 0, 1);
            }
            catch (Exception)
            {

                try
                {
                    objSearchResult = objElConn.Search(strIndex, objTypes.DataType, objBoolQuery.ToString(), 0,
                                                    1);
                }
                catch (Exception)
                {

                    throw;
                }
            }

            var lngCount = objSearchResult.GetTotalCount();

            return lngCount;
        }

        public List<clsOntologyItem> get_Data_DataTypes(List<clsOntologyItem> OList_DataType = null)
        {
            SearchResult objSearchResult;

            OntologyList_DataTypes.Clear();

            var objBoolQuery = create_BoolQuery_Simple(OList_DataType, objTypes.DataType);

            var intCount = intSearchRange;
            var intPos = 0;

            while (intCount > 0)
            {
                intCount = 0;

                try
                {
                    objSearchResult = objElConn.Search(strIndex, objTypes.DataType, objBoolQuery.ToString(), intPos,
                                                       intSearchRange);
                }
                catch (Exception)
                {

                    try
                    {
                        objSearchResult = objElConn.Search(strIndex, objTypes.DataType, objBoolQuery.ToString(), intPos,
                                                       intSearchRange);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }


                var objList = objSearchResult.GetHits().Hits;

                OntologyList_DataTypes.AddRange((from objHit in objList
                                                     select new clsOntologyItem
                                                     {
                                                         GUID = objHit.Id,
                                                         Name = objHit.Source[objFields.Name_Item].ToString(),
                                                         Type = objTypes.DataType
                                                     }).ToList());

                intCount = objList.Count;
                intPos += intCount;



            }

            return OntologyList_DataTypes;
        }

        public long get_Data_ObjectAttCount(List<clsObjectAtt> OList_ObjectAtt)
        {
            SearchResult objSearchResult;

            OntologyList_AttributTypes1.Clear();

            var objBoolQuery = create_BoolQuery_ObjectAtt(OList_ObjectAtt);

            try
            {
                objSearchResult = objElConn.Search(strIndex, objTypes.ObjectAtt, objBoolQuery.ToString(), 0, 1);
            }
            catch (Exception)
            {

                try
                {
                    objSearchResult = objElConn.Search(strIndex, objTypes.ObjectAtt, objBoolQuery.ToString(), 0,
                                                    1);
                }
                catch (Exception)
                {

                    throw;
                }
            }

            var lngCount = objSearchResult.GetTotalCount();

            return lngCount;
        }

        public List<clsObjectAtt> get_Data_ObjectAtt(List<clsObjectAtt> OList_ObjectAtt,
                                                     bool boolIDs = true,
                                                     bool doJoin = false)
        {
            SearchResult objSearchResult;

            OntologyList_DataTypes.Clear();

            var objBoolQuery = create_BoolQuery_ObjectAtt(OList_ObjectAtt, doJoin);

            OntologyList_ObjAtt.Clear();
            OntologyList_ObjAtt_ID.Clear();
            OntologyList_AttributTypes1.Clear();
            OntologyList_Attributes.Clear();
            OntologyList_Classes1.Clear();
            OntologyList_Objects1.Clear();


            var intCount = intSearchRange;
            var intPos = 0;

            while (intCount > 0)
            {
                intCount = 0;

                try
                {
                    objSearchResult = objElConn.Search(strIndex, objTypes.ObjectAtt, objBoolQuery.ToString(), intPos,
                                                       intSearchRange);
                }
                catch (Exception)
                {

                    try
                    {
                        objSearchResult = objElConn.Search(strIndex, objTypes.ObjectAtt, objBoolQuery.ToString(), intPos,
                                                       intSearchRange);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }


                var objList = objSearchResult.GetHits().Hits;

                OntologyList_ObjAtt_ID.AddRange((from objHit in objList
                                                 select new clsObjectAtt
                                                 {
                                                     ID_Attribute = objHit.Id,
                                                     ID_AttributeType = objHit.Source[objFields.ID_AttributeType].ToString(),
                                                     ID_Object = objHit.Source[objFields.ID_Object].ToString(),
                                                     ID_Class = objHit.Source[objFields.ID_Class].ToString(),
                                                     ID_DataType = objHit.Source[objFields.ID_DataType].ToString(),
                                                     Val_Bit = (objHit.Source[objFields.Val_Bool]!=null ? (bool?) objHit.Source[objFields.Val_Bool] : null),
                                                     Val_Date = (objHit.Source[objFields.Val_Datetime] != null ? (DateTime?)objHit.Source[objFields.Val_Datetime] : null),
                                                     Val_Double = (objHit.Source[objFields.Val_Real] != null ? (double?)objHit.Source[objFields.Val_Real] : null),
                                                     Val_Lng = (objHit.Source[objFields.Val_Int] != null ? (int?)objHit.Source[objFields.Val_Int] : null),
                                                     Val_Named = (objHit.Source[objFields.Val_Name] != null ? objHit.Source[objFields.Val_Name].ToString() : null),
                                                     Val_String = (objHit.Source[objFields.Val_String] != null ? objHit.Source[objFields.Val_String].ToString() : null),
                                                     OrderID = (long?)objHit.Source[objFields.OrderID]
                                                 }).ToList());

                intCount = objList.Count;
                intPos += intCount;



            }


            if (!boolIDs)
            {
                if (!doJoin)
                {
                    var oList_OItems = (from objObj in OntologyList_ObjAtt_ID
                                             group objObj by objObj.ID_Class
                                             into g
                                             select
                                                 new clsOntologyItem {GUID_Parent = g.Key, Type = objTypes.ObjectType}).ToList();
                    
                    if (oList_OItems.Any())
                    {
                        get_Data_Objects(oList_OItems);
                    }
                }

                var oList_AttributeTypes = (from objAttType in OntologyList_ObjAtt_ID
                                            group objAttType by objAttType.ID_AttributeType
                                            into g
                                            select new clsOntologyItem {GUID = g.Key}).ToList();

                if (oList_AttributeTypes.Any())
                {
                    get_Data_AttributeType(oList_AttributeTypes);
                }

                var oList_Classes = (from objClass in OntologyList_ObjAtt_ID
                                     group objClass by objClass.ID_Class
                                     into g
                                     select new clsOntologyItem {GUID = g.Key}).ToList();

                if (oList_Classes.Any())
                {
                    get_Data_Classes(oList_Classes);
                }

                var oList_DataTypes = (from objDataType in OntologyList_ObjAtt_ID
                                       group objDataType by objDataType.ID_DataType
                                       into g
                                       select new clsOntologyItem {GUID = g.Key}).ToList();

                if (oList_DataTypes.Any())
                {
                    get_Data_DataTypes(oList_DataTypes);
                }

                OntologyList_ObjAtt = (from objObjAtt in OntologyList_ObjAtt_ID
                                       join objObject in OntologyList_Objects1 on objObjAtt.ID_Object equals
                                           objObject.GUID
                                       join objClass in OntologyList_Classes1 on objObject.GUID_Parent equals
                                           objClass.GUID
                                       join objAttType in OntologyList_AttributTypes1 on objObjAtt.ID_AttributeType
                                           equals objAttType.GUID
                                       join objDataType in OntologyList_DataTypes on objAttType.GUID_Parent equals
                                           objDataType.GUID
                                       select new clsObjectAtt
                                           {
                                               ID_Attribute = objObjAtt.ID_Attribute,
                                               ID_AttributeType = objAttType.GUID,
                                               ID_Class = objClass.GUID,
                                               ID_Object = objObject.GUID,
                                               ID_DataType = objDataType.GUID,
                                               OrderID = objObjAtt.OrderID,
                                               Name_AttributeType = objAttType.Name,
                                               Name_Class = objClass.Name,
                                               Name_Object = objObject.Name,
                                               Name_DataType = objDataType.Name,
                                               Val_Bit = objObjAtt.Val_Bit,
                                               Val_Date = objObjAtt.Val_Date,
                                               Val_Double = objObjAtt.Val_Double,
                                               Val_Lng = objObjAtt.Val_Lng,
                                               Val_Named = objObjAtt.Val_Named,
                                               Val_String = objObjAtt.Val_String
                                           }).ToList();
            }

            return OntologyList_ObjAtt;
        }

        public long get_Data_ObjectsCount(List<clsOntologyItem> OList_Objects = null)
        {
            SearchResult objSearchResult;

            OntologyList_AttributTypes1.Clear();

            var objBoolQuery = create_BoolQuery_Simple(OList_Objects,objTypes.ObjectType);

            try
            {
                objSearchResult = objElConn.Search(strIndex, objTypes.ObjectType, objBoolQuery.ToString(), 0, 1);
            }
            catch (Exception)
            {

                try
                {
                    objSearchResult = objElConn.Search(strIndex, objTypes.ObjectType, objBoolQuery.ToString(), 0,
                                                    1);
                }
                catch (Exception)
                {

                    throw;
                }
            }

            var lngCount = objSearchResult.GetTotalCount();

            return lngCount;
        }

        
        public List<clsOntologyItem> get_Data_Objects(List<clsOntologyItem> OList_Objects = null,
                                                      bool List2 = false,
                                                      bool ClearObj1 = true,
                                                      bool ClearObj2 = true)
        {
            SearchResult objSearchResult;

            if (OntologyList_Objects1 == null)
            {
                OntologyList_Objects1 = new List<clsOntologyItem>();
            }
            else
            {
                if (ClearObj1) OntologyList_Objects1.Clear();    
            }
            if (OntologyList_Objects2 == null)
            {
                OntologyList_Objects2 = new List<clsOntologyItem>();
            }
            else
            {
                if (ClearObj2) OntologyList_Objects2.Clear();
            }

            var objBoolQuery = create_BoolQuery_Simple(OList_Objects, objTypes.ObjectType);

            var intCount = intSearchRange;
            var intPos = 0;

            while (intCount > 0)
            {
                intCount = 0;

                try
                {
                    objSearchResult = objElConn.Search(strIndex, objTypes.ObjectType, objBoolQuery.ToString(), intPos,
                                                       intSearchRange);
                }
                catch (Exception)
                {

                    try
                    {
                        objSearchResult = objElConn.Search(strIndex, objTypes.ObjectType, objBoolQuery.ToString(), intPos,
                                                       intSearchRange);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }


                var objList = objSearchResult.GetHits().Hits;

                if (!List2)
                {
                    OntologyList_Objects1.AddRange((from objHit in objList
                                                    select new clsOntologyItem
                                                    {
                                                        GUID = objHit.Id,
                                                        Name = objHit.Source[objFields.Name_Item].ToString(),
                                                        GUID_Parent =  objHit.Source[objFields.ID_Class].ToString(),
                                                        Type = objTypes.DataType
                                                    }).ToList());
                }
                else
                {
                    OntologyList_Objects2.AddRange((from objHit in objList
                                                    select new clsOntologyItem
                                                    {
                                                        GUID = objHit.Id,
                                                        Name = objHit.Source[objFields.Name_Item].ToString(),
                                                        GUID_Parent = objHit.Source[objFields.ID_Class].ToString(),
                                                        Type = objTypes.DataType
                                                    }).ToList());
                }
                

                intCount = objList.Count;
                intPos += intCount;



            }

            if (!List2)
            {
                return OntologyList_Objects1;    
            }
            else
            {
                return OntologyList_Objects2;    
            }
            
        }

        public long get_Data_ObjectRelCount(List<clsObjectRel> OList_ObjectRel = null)
        {
            SearchResult objSearchResult;

            OntologyList_AttributTypes1.Clear();

            var objBoolQuery = create_BoolQuery_ObjectRel(OList_ObjectRel);

            try
            {
                objSearchResult = objElConn.Search(strIndex, objTypes.ObjectRel, objBoolQuery.ToString(), 0, 1);
            }
            catch (Exception)
            {

                try
                {
                    objSearchResult = objElConn.Search(strIndex, objTypes.ObjectRel, objBoolQuery.ToString(), 0,
                                                    1);
                }
                catch (Exception)
                {

                    throw;
                }
            }

            var lngCount = objSearchResult.GetTotalCount();

            return lngCount;
        }

        public List<clsObjectRel> get_Data_ObjectRel(List<clsObjectRel> OList_ObjectRel = null,
                                                     bool boolIDs = true,
                                                     string Direction = null,
                                                     bool doJoin_Left = false,
                                                     bool doJoin_Right = false)
        {
            SearchResult objSearchResult;

            OntologyList_DataTypes.Clear();

            var objBoolQuery = create_BoolQuery_ObjectRel(OList_ObjectRel);

            OntologyList_ObjectRel.Clear();
            OntologyList_ObjectRel_ID.Clear();
            OntologyList_Objects1.Clear();
            OntologyList_Classes1.Clear();
            OntologyList_RelationTypes1.Clear();

            objDBLevel_Other_AttributeTypes = new clsDBLevel(strServer, intPort, strIndex, strIndexRep, intSearchRange, strSession);
            objDBLevel_Other_Classes = new clsDBLevel(strServer, intPort, strIndex, strIndexRep, intSearchRange, strSession);
            objDBLevel_Other_Objects = new clsDBLevel(strServer, intPort, strIndex, strIndexRep, intSearchRange, strSession);
            objDBLevel_Other_RelationTypes = new clsDBLevel(strServer, intPort, strIndex, strIndexRep, intSearchRange, strSession);

            if (!doJoin_Left) OntologyList_Objects1.Clear();
            if (!doJoin_Right) OntologyList_Objects2.Clear();

            string strSort = null;
            if (sort == SortEnum.DESC_OrderID)
            {
                strSort = "OrderID:asc";
            }
            else if (sort == SortEnum.DESC_OrderID)
            {
                strSort = "OrderID:desc";
            }

            var intCount = intSearchRange;
            var intPos = 0;

            while (intCount > 0)
            {
                intCount = 0;

                if (strSort == null)
                {
                    try
                    {
                        objSearchResult = objElConn.Search(strIndex, objTypes.ObjectRel, objBoolQuery.ToString(), intPos,
                                                           intSearchRange);
                    }
                    catch (Exception)
                    {

                        try
                        {
                            objSearchResult = objElConn.Search(strIndex, objTypes.ObjectRel, objBoolQuery.ToString(), intPos,
                                                           intSearchRange);
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }
                }
                else
                {
                    try
                    {
                        objSearchResult = objElConn.Search(strIndex, objTypes.ObjectRel, objBoolQuery.ToString(), strSort, intPos,
                                                           intSearchRange);
                    }
                    catch (Exception)
                    {

                        try
                        {
                            objSearchResult = objElConn.Search(strIndex, objTypes.ObjectRel, objBoolQuery.ToString(), strSort, intPos,
                                                           intSearchRange);
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }
                }
                


                var objList = objSearchResult.GetHits().Hits;

                OntologyList_ObjectRel_ID.AddRange((from objHit in objList
                                                 select new clsObjectRel
                                                 {
                                                     
                                                     ID_Object = objHit.Source[objFields.ID_Object].ToString(),
                                                     ID_Other = objHit.Source[objFields.ID_Other].ToString(),
                                                     ID_Parent_Object = objHit.Source[objFields.ID_Parent_Object].ToString(),
                                                     ID_Parent_Other = (objHit.Source[objFields.ID_Parent_Other] != null ? objHit.Source[objFields.ID_Parent_Other].ToString() : null),
                                                     ID_RelationType = objHit.Source[objFields.ID_RelationType].ToString(),
                                                     OrderID = (long?)objHit.Source[objFields.OrderID],
                                                     Ontology = objHit.Source[objFields.Ontology].ToString()
                                                 }).ToList());

                intCount = objList.Count;
                intPos += intCount;



            }


            if (!boolIDs)
            {
                if (!doJoin_Left)
                {
                    var oList_OItems = (from objObj in OntologyList_ObjectRel_ID
                                        group objObj by objObj.ID_Object
                                            into g
                                            select
                                                new clsOntologyItem { GUID_Parent = g.Key, Type = objTypes.ObjectType }).ToList();

                    if (oList_OItems.Any())
                    {
                        get_Data_Objects(oList_OItems);
                    }
                }

                
                var oList_Classes = (from objClass in OntologyList_ObjAtt_ID
                                     group objClass by objClass.ID_Class
                                         into g
                                         select new clsOntologyItem { GUID = g.Key }).ToList();

                if (oList_Classes.Any())
                {
                    get_Data_Classes(oList_Classes);
                }

                var oList_RelationTypes = (from objRelType in OntologyList_ObjectRel_ID
                                           group objRelType by objRelType.ID_RelationType
                                           into g
                                           select new clsOntologyItem {GUID = g.Key}).ToList();

                if (oList_RelationTypes.Any())
                {
                    get_Data_RelationTypes(oList_RelationTypes);
                }
                else
                {
                    OntologyList_RelationTypes1 = new List<clsOntologyItem>();
                }

                OntologyList_Classes2 = objDBLevel_Other_Classes.get_Data_Classes();

                var oList_AttributeTypes2 = (from objAttributeType in OntologyList_ObjectRel_ID
                                             where objAttributeType.Ontology == objTypes.AttributeType
                                             group objAttributeType by objAttributeType.ID_Parent_Other
                                                 into g
                                                 select new clsOntologyItem { GUID_Parent = g.Key }).ToList();

                OntologyList_AttributTypes2 = oList_AttributeTypes2.Any() ? objDBLevel_Other_AttributeTypes.get_Data_AttributeType(oList_AttributeTypes2) : new List<clsOntologyItem>();


                OntologyList_RelationTypes2 = (from objObj in OntologyList_ObjectRel_ID
                                               where objObj.Ontology == objTypes.RelationType
                                               select objObj).Any() ? objDBLevel_Other_RelationTypes.get_Data_RelationTypes() : new List<clsOntologyItem>();
                                          
                var oList_OtherObjects = (from objClass in OntologyList_ObjectRel_ID
                                          where objClass.Ontology == objTypes.ObjectType
                                           group objClass by objClass.ID_Parent_Other
                                           into g
                                           select new clsOntologyItem {GUID = g.Key}).ToList();
                OntologyList_Objects2 = oList_OtherObjects.Any() ? objDBLevel_Other_Objects.get_Data_Objects(oList_OtherObjects) : new List<clsOntologyItem>();

                OntologyList_DataTypes = get_Data_DataTypes();

                if (OntologyList_Objects2.Any())
                {
                    OntologyList_ObjectRel.AddRange((from objObjRel in OntologyList_ObjectRel_ID
                                                     join objLeft in OntologyList_Objects1 on objObjRel.ID_Object equals
                                                         objLeft.GUID
                                                     join objLeftClass in OntologyList_Classes1 on
                                                         objObjRel.ID_Parent_Object equals objLeftClass.GUID
                                                     join objRight in OntologyList_Objects2 on objObjRel.ID_Other equals
                                                         objRight.GUID
                                                     join objRightParent in OntologyList_Classes2 on
                                                         objObjRel.ID_Parent_Other equals objRightParent.GUID
                                                     join objRelationType in OntologyList_RelationTypes1 on
                                                         objObjRel.ID_RelationType equals objRelationType.GUID
                                                     select new clsObjectRel
                                                         {
                                                             ID_Object = objLeft.GUID,
                                                             Name_Object = objLeft.Name,
                                                             ID_Parent_Object = objLeftClass.GUID,
                                                             Name_Parent_Object = objLeftClass.Name,
                                                             ID_Other = objRight.GUID,
                                                             Name_Other = objRight.Name,
                                                             ID_Parent_Other = objRightParent.GUID,
                                                             Name_Parent_Other = objRightParent.Name,
                                                             OrderID = objObjRel.OrderID,
                                                             Ontology = objObjRel.Ontology,
                                                             ID_RelationType = objRelationType.GUID,
                                                             Name_RelationType = objRelationType.Name
                                                         }).ToList());

                }

                if (OntologyList_AttributTypes2.Any())
                {
                    OntologyList_ObjectRel.AddRange((from objObjRel in OntologyList_ObjectRel_ID
                                                     join objLeft in OntologyList_Objects1 on objObjRel.ID_Object equals
                                                         objLeft.GUID
                                                     join objLeftClass in OntologyList_Classes1 on
                                                         objObjRel.ID_Parent_Object equals objLeftClass.GUID
                                                     join objRight in OntologyList_AttributTypes2 on objObjRel.ID_Other equals
                                                         objRight.GUID
                                                     join objRightParent in OntologyList_DataTypes on
                                                         objObjRel.ID_Parent_Other equals objRightParent.GUID
                                                     join objRelationType in OntologyList_RelationTypes1 on
                                                         objObjRel.ID_RelationType equals objRelationType.GUID
                                                     select new clsObjectRel
                                                     {
                                                         ID_Object = objLeft.GUID,
                                                         Name_Object = objLeft.Name,
                                                         ID_Parent_Object = objLeftClass.GUID,
                                                         Name_Parent_Object = objLeftClass.Name,
                                                         ID_Other = objRight.GUID,
                                                         Name_Other = objRight.Name,
                                                         ID_Parent_Other = objRightParent.GUID,
                                                         Name_Parent_Other = objRightParent.Name,
                                                         OrderID = objObjRel.OrderID,
                                                         Ontology = objObjRel.Ontology,
                                                         ID_RelationType = objRelationType.GUID,
                                                         Name_RelationType = objRelationType.Name
                                                     }).ToList());

                }

                if (OntologyList_RelationTypes2.Any())
                {
                    OntologyList_ObjectRel.AddRange((from objObjRel in OntologyList_ObjectRel_ID
                                                     join objLeft in OntologyList_Objects1 on objObjRel.ID_Object equals
                                                         objLeft.GUID
                                                     join objLeftClass in OntologyList_Classes1 on
                                                         objObjRel.ID_Parent_Object equals objLeftClass.GUID
                                                     join objRight in OntologyList_RelationTypes2 on objObjRel.ID_Other equals
                                                         objRight.GUID
                                                     join objRelationType in OntologyList_RelationTypes1 on
                                                         objObjRel.ID_RelationType equals objRelationType.GUID
                                                     select new clsObjectRel
                                                     {
                                                         ID_Object = objLeft.GUID,
                                                         Name_Object = objLeft.Name,
                                                         ID_Parent_Object = objLeftClass.GUID,
                                                         Name_Parent_Object = objLeftClass.Name,
                                                         ID_Other = objRight.GUID,
                                                         Name_Other = objRight.Name,
                                                         OrderID = objObjRel.OrderID,
                                                         Ontology = objObjRel.Ontology,
                                                         ID_RelationType = objRelationType.GUID,
                                                         Name_RelationType = objRelationType.Name
                                                     }).ToList());

                }

                if (OntologyList_Classes2.Any())
                {
                    OntologyList_ObjectRel.AddRange((from objObjRel in OntologyList_ObjectRel_ID
                                                     join objLeft in OntologyList_Objects1 on objObjRel.ID_Object equals
                                                         objLeft.GUID
                                                     join objLeftClass in OntologyList_Classes1 on
                                                         objObjRel.ID_Parent_Object equals objLeftClass.GUID
                                                     join objRight in OntologyList_Classes2 on objObjRel.ID_Other equals
                                                         objRight.GUID
                                                     join objRelationType in OntologyList_RelationTypes1 on
                                                         objObjRel.ID_RelationType equals objRelationType.GUID
                                                     select new clsObjectRel
                                                     {
                                                         ID_Object = objLeft.GUID,
                                                         Name_Object = objLeft.Name,
                                                         ID_Parent_Object = objLeftClass.GUID,
                                                         Name_Parent_Object = objLeftClass.Name,
                                                         ID_Other = objRight.GUID,
                                                         Name_Other = objRight.Name,
                                                         ID_Parent_Other = objRight.GUID_Parent,
                                                         OrderID = objObjRel.OrderID,
                                                         Ontology = objObjRel.Ontology,
                                                         ID_RelationType = objRelationType.GUID,
                                                         Name_RelationType = objRelationType.Name
                                                     }).ToList());

                }
                
            }

            return OntologyList_ObjectRel;
        }
            

        public long get_Data_RelationTypesCount(List<clsOntologyItem> OList_RelType = null)
        {
            SearchResult objSearchResult;

            OntologyList_AttributTypes1.Clear();

            var objBoolQuery = create_BoolQuery_Simple(OList_RelType, objTypes.RelationType);

            try
            {
                objSearchResult = objElConn.Search(strIndex, objTypes.RelationType, objBoolQuery.ToString(), 0, 1);
            }
            catch (Exception)
            {

                try
                {
                    objSearchResult = objElConn.Search(strIndex, objTypes.RelationType, objBoolQuery.ToString(), 0,
                                                    1);
                }
                catch (Exception)
                {

                    throw;
                }
            }

            var lngCount = objSearchResult.GetTotalCount();

            return lngCount;
        }

        public List<clsOntologyItem> get_Data_RelationTypes(List<clsOntologyItem> OList_RelType = null)
        {
            SearchResult objSearchResult;

            OntologyList_DataTypes.Clear();

            var objBoolQuery = create_BoolQuery_Simple(OList_RelType, objTypes.RelationType);

            var intCount = intSearchRange;
            var intPos = 0;

            while (intCount > 0)
            {
                intCount = 0;

                try
                {
                    objSearchResult = objElConn.Search(strIndex, objTypes.RelationType, objBoolQuery.ToString(), intPos,
                                                       intSearchRange);
                }
                catch (Exception)
                {

                    try
                    {
                        objSearchResult = objElConn.Search(strIndex, objTypes.RelationType, objBoolQuery.ToString(), intPos,
                                                       intSearchRange);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }


                var objList = objSearchResult.GetHits().Hits;

                OntologyList_DataTypes.AddRange((from objHit in objList
                                                 select new clsOntologyItem
                                                 {
                                                     GUID = objHit.Id,
                                                     Name = objHit.Source[objFields.Name_Item].ToString(),
                                                     Type = objTypes.RelationType
                                                 }).ToList());

                intCount = objList.Count;
                intPos += intCount;



            }

            return OntologyList_DataTypes;
        }


        public clsDBLevel(string strServer,
                          int intPort,
                          string strIndex,
                          string strIndexRep,
                          int intSearchRange,
                          string strSession)
        {
            this.strServer = strServer;
            this.intPort = intPort;
            this.strIndex = strIndex;
            this.strIndexRep = strIndexRep;
            this.intSearchRange = intSearchRange;
            this.strSession = strSession;

            initialize_Client();
            sort = SortEnum.NONE;

            
            

        }
    }
}

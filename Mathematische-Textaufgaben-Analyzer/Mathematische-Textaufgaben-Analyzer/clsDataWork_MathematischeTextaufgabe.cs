using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.BaseClasses;
using Ontology_Module;
using ModuleLibrary;

namespace Mathematische_Textaufgaben_Analyzer
{
    public class clsDataWork_MathematischeTextaufgabe
    {
        private clsLocalConfig objLocalConfig;

        private clsDBLevel objDBLevel_Sachaufgabe;
        private clsDBLevel objDBLevel_Description;
        private clsDBLevel objDBLevel_MathematischesElement;
        private clsDBLevel objDBLevel_MathematischerTermOfMathematischesElement;
        private clsDBLevel objDBLevel_Funktion;
        private clsDBLevel objDBLevel_Operator;

        public clsOntologyItem OItem_Result_Sachaufgabe { get; set; }
        public clsOntologyItem OItem_Result_MathematischesElement { get; set; }
        public clsOntologyItem OItem_Result_MengeOfMathematischesElement { get; set; }
        public clsOntologyItem OItem_Result_MathematischerTermOfMathematischesElement { get; set; }
        public clsOntologyItem OItem_Result_Funktion { get; set; }
        public clsOntologyItem OItem_Result_Operator { get; set; }

        private clsDataWork_Amount objDataWork_Amount;

        private List<clsAmountOfRef> amountsOfRef;

        public List<clsSachaufgabe> Sachaufgaben { get; set; }

        public List<clsSachaufgabenelement> SachaufgabenElemente { get; set; }

        public List<clsTerm> Terms { get; set; }

        private clsOntologyItem objOItem_Sachaufgabe;

        public clsOntologyItem GetData_Sachaufgabe(clsOntologyItem OItem_Sachaufgabe = null)
        {
            objOItem_Sachaufgabe = OItem_Sachaufgabe;
            clsOntologyItem objOItem_Result;

            GetSubData_001_Sachaufgabe();
            objOItem_Result = OItem_Result_Sachaufgabe;
            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                GetSubData_002_MathematischesElement();
                objOItem_Result = OItem_Result_MathematischesElement;

                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    GetSubData_003_MengeOfMathematischesElement();
                    objOItem_Result = OItem_Result_MengeOfMathematischesElement;

                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        GetSubData_004_MathematischesElementOfMathematnischerTerm();
                        objOItem_Result = OItem_Result_MathematischerTermOfMathematischesElement;

                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {
                            GetSubData_005_FunktionOfTerm();
                            objOItem_Result = OItem_Result_Funktion;

                            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                            {
                                GetSubData_006_OperatorOfTerm();
                                objOItem_Result = OItem_Result_Operator;

                                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                {
                                    Sachaufgaben = (from objSachaufgabe in objDBLevel_Sachaufgabe.OList_Objects
                                                    join objDescription in objDBLevel_Description.OList_ObjectAtt on objSachaufgabe.GUID equals objDescription.ID_Object
                                                    select new clsSachaufgabe
                                                    {
                                                        ID_Sachaufgabe = objSachaufgabe.GUID,
                                                        Name_Sachaufgabe = objSachaufgabe.Name,
                                                        ID_Attribute_Description = objDescription.ID_Attribute,
                                                        Description = objDescription.Val_String
                                                    }).ToList();

                                    SachaufgabenElemente = (from objSachaufgabe in objDBLevel_Sachaufgabe.OList_Objects
                                                            join objElement in objDBLevel_MathematischesElement.OList_ObjectRel on objSachaufgabe.GUID equals objElement.ID_Object
                                                            join objAmount in amountsOfRef on objElement.ID_Other equals objAmount.ID_Ref
                                                            select new clsSachaufgabenelement
                                                            {
                                                                ID_Sachaufgabe = objSachaufgabe.GUID,
                                                                Name_Sachaufgabe = objSachaufgabe.Name,
                                                                ID_Element = objElement.ID_Other,
                                                                Name_Element = objElement.Name_Other,
                                                                ID_Menge = objAmount.ID_Amount,
                                                                Name_Menge = objAmount.Name_Amount,
                                                                ID_Attribute_Menge = objAmount.ID_Attribute,
                                                                Menge = objAmount.Value,
                                                                ID_Unit = objAmount.ID_Unit,
                                                                Name_Unit = objAmount.Name_Unit
                                                            }).ToList();


                                    Terms = (from objTerm in
                                                 (from objSachaufgabe in objDBLevel_Sachaufgabe.OList_Objects
                                                  join objElement in objDBLevel_MathematischesElement.OList_ObjectRel on objSachaufgabe.GUID equals objElement.ID_Object
                                                  join objTerm in objDBLevel_MathematischerTermOfMathematischesElement.OList_ObjectRel on objElement.ID_Other equals objTerm.ID_Other
                                                  group objTerm by new { ID_Sachaufgaben = objSachaufgabe.GUID, Name_Sachaufgabe = objSachaufgabe.Name, ID_Term = objTerm.ID_Object, Name_Term = objTerm.Name_Object } into objTerms
                                                  select objTerms).ToList()
                                             join objFunktion in objDBLevel_Funktion.OList_ObjectRel on objTerm.Key.ID_Term equals objFunktion.ID_Object into objFunktions
                                             from objFunktion in objFunktions.DefaultIfEmpty()
                                             join objOperator in objDBLevel_Operator.OList_ObjectRel on objTerm.Key.ID_Term equals objOperator.ID_Object into objOperators
                                             from objOperator in objOperators.DefaultIfEmpty()
                                             select new clsTerm
                                             {
                                                 ID_Term = objTerm.Key.ID_Term,
                                                 Name_Term = objTerm.Key.Name_Term,
                                                 ID_Sachaufgabe = objTerm.Key.ID_Sachaufgaben,
                                                 Name_Sachaufgabe = objTerm.Key.Name_Sachaufgabe,
                                                 ID_Funktion = objFunktion != null ? objFunktion.ID_Other : null,
                                                 Name_Funktion = objFunktion != null ? objFunktion.Name_Other : null,
                                                 ID_Operator = objOperator != null ? objOperator.ID_Other : null,
                                                 Name_Operator = objOperator != null ? objOperator.Name_Other : null
                                             }).ToList();

                                    foreach (var objTerm in Terms)
                                    {
                                        var termElements = (from objElementsOfTerms in objDBLevel_MathematischerTermOfMathematischesElement.OList_ObjectRel.Where(mtme => mtme.ID_Object == objTerm.ID_Term).ToList()
                                                            join objElement in SachaufgabenElemente on objElementsOfTerms.ID_Other equals objElement.ID_Element
                                                            select new { objElementsOfTerms, objElement }).ToList();

                                        if (objTerm.ID_Funktion != null)
                                        {
                                            if (objTerm.ID_Funktion == objLocalConfig.OItem_object_abyio_i.GUID)
                                            {

                                            }
                                            else if (objTerm.ID_Funktion == objLocalConfig.OItem_object_min.GUID)
                                            {

                                            }
                                            else if (objTerm.ID_Funktion == objLocalConfig.OItem_object_diff.GUID)
                                            {

                                            }

                                        }
                                        else
                                        {
                                            var leftElements = termElements.Where(te => te.objElementsOfTerms.ID_RelationType == objLocalConfig.OItem_relationtype_left.GUID).ToList();
                                            var rightElements = termElements.Where(te => te.objElementsOfTerms.ID_RelationType == objLocalConfig.OItem_relationtype_right.GUID).ToList();
                                            var resultElements = termElements.Where(te => te.objElementsOfTerms.ID_RelationType == objLocalConfig.OItem_relationtype_ergebnis.GUID).ToList();
                                            string term = "";
                                            string result = "";
                                            double? leftTerm = null;  
                                            double? rightTerm = null;
                                            double? resultTerm = null;


                                            if (leftElements.Any())
                                            {
                                                leftTerm = leftElements.First().objElement.Menge;
                                            }

                                            if (rightElements.Any())
                                            {
                                                rightTerm = rightElements.First().objElement.Menge;
                                            }
                                            
                                            if (resultElements.Any())
                                            {
                                                resultTerm = resultElements.First().objElement.Menge;
                                            }
                                            

                                            if (leftTerm != null && rightTerm != null && resultTerm != null)
                                            {
                                                term = leftTerm.ToString() + " " + objTerm.Name_Operator + " " + rightTerm.ToString();
                                                result = resultTerm.ToString();
                                                var resultVal = CalculateTerm((double)leftTerm, (double)rightTerm, objTerm.ID_Operator);
                                                if (resultVal != null)
                                                {
                                                    if (resultVal != resultTerm)
                                                    {
                                                        result += "!";
                                                    }
                                                }
                                                else
                                                {
                                                    result += "!";
                                                }
                                            }
                                            else if (leftTerm != null && rightTerm != null)
                                            {
                                                term = leftTerm.ToString() + " " + objTerm.Name_Operator + " " + rightTerm.ToString();
                                                var resultVal = CalculateTerm((double)leftTerm, (double)rightTerm, objTerm.ID_Operator);
                                                if (resultVal != null)
                                                {
                                                    result = resultVal.ToString();
                                                }
                                                else
                                                {
                                                    result = "?";
                                                }
                                            }
                                            else if (leftTerm != null && resultTerm != null)
                                            {
                                                var resultVal = CalculateTerm_Right((double)leftTerm, (double)resultTerm, objTerm.ID_Operator);
                                                if (resultVal != null)
                                                {
                                                    term = leftTerm.ToString() + " " + objTerm.Name_Operator + " " + resultVal.ToString();
                                                    result = resultTerm.ToString();
                                                }
                                                else
                                                {
                                                    term = leftTerm.ToString() + " " + objTerm.Name_Operator + " ?";
                                                    result = resultTerm.ToString();
                                                }

                                            }
                                            else if (rightTerm != null && resultTerm != null)
                                            {
                                                var resultVal = CalculateTerm_Left((double)rightTerm, (double)resultTerm, objTerm.ID_Operator);
                                                if (resultVal != null)
                                                {
                                                    term = resultVal.ToString() + " " + objTerm.Name_Operator + " " + rightTerm.ToString();
                                                    result = resultTerm.ToString();
                                                }
                                                else
                                                {
                                                    term =  "? " + objTerm.Name_Operator + " " + rightTerm.ToString();
                                                    result = resultTerm.ToString();
                                                }
                                            }
                                            else
                                            {
                                                
                                            }

                                            objTerm.Term = term;
                                            objTerm.Ergebnis = result;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return objOItem_Result;
        }
        
        private double? CalculateTerm_Left(double rightTerm, double resultTerm, string ID_Operator)
        {
            double? result;
            if (ID_Operator == objLocalConfig.OItem_object_add.GUID)
            {
                result = resultTerm - rightTerm;
            }
            else if (ID_Operator == objLocalConfig.OItem_object_sub.GUID)
            {
                result = resultTerm + rightTerm;
            }
            else if (ID_Operator == objLocalConfig.OItem_object_mult.GUID)
            {
                result = resultTerm / rightTerm;

            }
            else if (ID_Operator == objLocalConfig.OItem_object_div.GUID)
            {
                result = rightTerm * resultTerm;
            }
            else
            {
                result = null;
            }

            return result;
        }

        private double? CalculateTerm_Right(double leftTerm, double resultTerm, string ID_Operator)
        {
            double? result;
            if (ID_Operator == objLocalConfig.OItem_object_add.GUID)
            {
                result = resultTerm - leftTerm;
            }
            else if (ID_Operator == objLocalConfig.OItem_object_sub.GUID)
            {
                result = leftTerm - resultTerm;
            }
            else if (ID_Operator == objLocalConfig.OItem_object_mult.GUID)
            {
                result = resultTerm / leftTerm;

            }
            else if (ID_Operator == objLocalConfig.OItem_object_div.GUID)
            {
                result = leftTerm / resultTerm;
            }
            else
            {
                result = null;
            }

            return result;
        }

        private double? CalculateTerm(double leftTerm, double rightTerm, string ID_Operator)
        {
            double? result;
            if (ID_Operator == objLocalConfig.OItem_object_add.GUID)
            {
                result = leftTerm + rightTerm;
            }
            else if (ID_Operator == objLocalConfig.OItem_object_sub.GUID)
            {
                result = leftTerm - rightTerm;
            }
            else if (ID_Operator == objLocalConfig.OItem_object_mult.GUID)
            {
                result = leftTerm * rightTerm;
               
            }
            else if (ID_Operator == objLocalConfig.OItem_object_div.GUID)
            {
                if (rightTerm != 0)
                {
                    result = leftTerm / rightTerm;
                }
                else
                {
                    result = null;
                }
            }
            else
            {
                result = null;
            }

            return result;
        }

        private void GetSubData_001_Sachaufgabe()
        {
            OItem_Result_Sachaufgabe = objLocalConfig.Globals.LState_Nothing.Clone();

            List<clsOntologyItem> searchL_Sachaufgabe;

            if (objOItem_Sachaufgabe == null)
            {
                searchL_Sachaufgabe = new List<clsOntologyItem> { new clsOntologyItem { GUID_Parent = objLocalConfig.OItem_class_sachaufgabe.GUID } };
            }
            else
            {
                searchL_Sachaufgabe = new List<clsOntologyItem> { new clsOntologyItem { GUID = objOItem_Sachaufgabe.GUID } };
            }
            



            var objOItem_Result = objDBLevel_Sachaufgabe.get_Data_Objects(searchL_Sachaufgabe);

            objDBLevel_Description.OList_ObjectAtt.Clear();

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                if (objDBLevel_Sachaufgabe.OList_Objects.Any())
                {
                    List<clsObjectAtt> searchL_Description;
                    if (objDBLevel_Sachaufgabe.OList_Objects.Count < 500)
                    {
                        searchL_Description = objDBLevel_Sachaufgabe.OList_Objects.Select(sa => new clsObjectAtt
                        {
                            ID_Object = sa.GUID,
                            ID_AttributeType = objLocalConfig.OItem_attributetype_description.GUID }).ToList();

                    }
                    else
                    {
                        searchL_Description = new List<clsObjectAtt> { new clsObjectAtt {ID_Class = objLocalConfig.OItem_class_sachaufgabe.GUID,
                            ID_AttributeType = objLocalConfig.OItem_attributetype_description.GUID } };
                    }

                    objOItem_Result = objDBLevel_Description.get_Data_ObjectAtt(searchL_Description,boolIDs:false);
                }
                

            }

            OItem_Result_Sachaufgabe = objOItem_Result;
        }

        private void GetSubData_002_MathematischesElement()
        {
            OItem_Result_MathematischesElement = objLocalConfig.Globals.LState_Nothing.Clone();

            objDBLevel_MathematischesElement.OList_ObjectRel.Clear();

            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            if (objDBLevel_Sachaufgabe.OList_Objects.Any())
            {
                List<clsObjectRel> searchL_MathematischesElement;
                if (objDBLevel_Sachaufgabe.OList_Objects.Count < 500)
                {
                    searchL_MathematischesElement = objDBLevel_Sachaufgabe.OList_Objects.Select(sa => new clsObjectRel
                    {
                        ID_Object = sa.GUID,
                        ID_RelationType = objLocalConfig.OItem_relationtype_contains.GUID,
                        ID_Parent_Other = objLocalConfig.OItem_class_mathematisches_element.GUID
                    }).ToList(); ;

                }
                else
                {
                    searchL_MathematischesElement = new List<clsObjectRel> { new clsObjectRel
                    {
                        ID_Parent_Object = objLocalConfig.OItem_class_sachaufgabe.GUID,
                        ID_RelationType = objLocalConfig.OItem_relationtype_contains.GUID,
                        ID_Parent_Other = objLocalConfig.OItem_class_mathematisches_element.GUID
                    }};
                    
                }

                objOItem_Result = objDBLevel_MathematischesElement.get_Data_ObjectRel(searchL_MathematischesElement, boolIDs: false);
            }

            OItem_Result_MathematischesElement = objOItem_Result;
        }

        public void GetSubData_003_MengeOfMathematischesElement()
        {
            OItem_Result_MengeOfMathematischesElement = objLocalConfig.Globals.LState_Nothing.Clone();



            if (objDBLevel_MathematischesElement.OList_ObjectRel.Any())
            {
                amountsOfRef = objDataWork_Amount.Get_Data_AmountsOfRef(objDBLevel_MathematischesElement.OList_ObjectRel.Select(me => new clsOntologyItem {GUID = me.ID_Other,
                    Name = me.Name_Other,
                    GUID_Parent = me.ID_Parent_Other,
                    Type = objLocalConfig.Globals.Type_Object}).ToList(), objLocalConfig.OItem_relationtype_entspricht, objLocalConfig.Globals.Direction_LeftRight);
                if (amountsOfRef != null)
                {
                    OItem_Result_MengeOfMathematischesElement = objLocalConfig.Globals.LState_Success.Clone();
                }
                else
                {
                    OItem_Result_MengeOfMathematischesElement = objLocalConfig.Globals.LState_Error.Clone();
                }

            }
            else
            {
                OItem_Result_MengeOfMathematischesElement = objLocalConfig.Globals.LState_Success.Clone();
            }
        }

        public void GetSubData_004_MathematischesElementOfMathematnischerTerm()
        {
            OItem_Result_MathematischerTermOfMathematischesElement = objLocalConfig.Globals.LState_Nothing.Clone();
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();
            objDBLevel_MathematischerTermOfMathematischesElement.OList_ObjectRel.Clear();
            if (objDBLevel_MathematischesElement.OList_ObjectRel.Any())
            {
                List<clsObjectRel> searchL_MathematischerTerm;
                if (objDBLevel_MathematischesElement.OList_ObjectRel.Count < 500)
                {
                    searchL_MathematischerTerm = objDBLevel_MathematischesElement.OList_ObjectRel.Select(me => new clsObjectRel
                    {
                        ID_Other = me.ID_Other,
                        ID_Parent_Object = objLocalConfig.OItem_class_mathematischer_term.GUID
                    }).ToList();
                }
                else
                {
                    searchL_MathematischerTerm = objDBLevel_MathematischesElement.OList_Objects.Select(me => new clsObjectRel
                    {
                        ID_Parent_Other = objLocalConfig.OItem_class_mathematisches_element.GUID,
                        ID_Parent_Object = objLocalConfig.OItem_class_mathematischer_term.GUID
                    }).ToList();
                }

                objOItem_Result = objDBLevel_MathematischerTermOfMathematischesElement.get_Data_ObjectRel(searchL_MathematischerTerm, boolIDs: false);

            }

            OItem_Result_MathematischerTermOfMathematischesElement = objOItem_Result;
        }

        public void GetSubData_005_FunktionOfTerm()
        {
            OItem_Result_Funktion = objLocalConfig.Globals.LState_Nothing.Clone();
            objDBLevel_Funktion.OList_ObjectRel.Clear();

            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            if (objDBLevel_MathematischerTermOfMathematischesElement.OList_ObjectRel.Any())
            {
                List<clsObjectRel> searchL_Funktion;
                if (objDBLevel_MathematischerTermOfMathematischesElement.OList_ObjectRel.Count < 500)
                {
                    searchL_Funktion = (from objTerm in objDBLevel_MathematischerTermOfMathematischesElement.OList_ObjectRel
                                    group objTerm by objTerm.ID_Object into objTerms
                                    select new clsObjectRel
                                    {
                                        ID_Object = objTerms.Key,
                                        ID_RelationType = objLocalConfig.OItem_relationtype_connector.GUID,
                                        ID_Parent_Other = objLocalConfig.OItem_class_funktion.GUID
                                    }).ToList();
                }
                else
                {
                    searchL_Funktion = new List<clsObjectRel> { new clsObjectRel { ID_Parent_Object = objLocalConfig.OItem_class_mathematischer_term.GUID,
                        ID_RelationType = objLocalConfig.OItem_relationtype_connector.GUID,
                        ID_Parent_Other = objLocalConfig.OItem_class_funktion.GUID } };
                }

                objOItem_Result = objDBLevel_Funktion.get_Data_ObjectRel(searchL_Funktion, boolIDs: false);
            }

            OItem_Result_Funktion = objOItem_Result;

        }

        public void GetSubData_006_OperatorOfTerm()
        {
            OItem_Result_Operator = objLocalConfig.Globals.LState_Nothing.Clone();
            objDBLevel_Operator.OList_ObjectRel.Clear();

            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            if (objDBLevel_MathematischerTermOfMathematischesElement.OList_ObjectRel.Any())
            {
                List<clsObjectRel> searchL_Operator;
                if (objDBLevel_MathematischerTermOfMathematischesElement.OList_ObjectRel.Count < 500)
                {
                    searchL_Operator = (from objTerm in objDBLevel_MathematischerTermOfMathematischesElement.OList_ObjectRel
                                        group objTerm by objTerm.ID_Object into objTerms
                                        select new clsObjectRel
                                        {
                                            ID_Object = objTerms.Key,
                                            ID_RelationType = objLocalConfig.OItem_relationtype_connector.GUID,
                                            ID_Parent_Other = objLocalConfig.OItem_class_operator.GUID
                                        }).ToList();
                }
                else
                {
                    searchL_Operator = new List<clsObjectRel> { new clsObjectRel { ID_Parent_Object = objLocalConfig.OItem_class_mathematischer_term.GUID,
                        ID_RelationType = objLocalConfig.OItem_relationtype_connector.GUID,
                        ID_Parent_Other = objLocalConfig.OItem_class_operator.GUID } };
                }

                objOItem_Result = objDBLevel_Operator.get_Data_ObjectRel(searchL_Operator, boolIDs: false);
            }

            OItem_Result_Operator = objOItem_Result;
        }

        public clsDataWork_MathematischeTextaufgabe(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;

            Initialize();
        }

        private void Initialize()
        {
            objDBLevel_Sachaufgabe = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Description = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_MathematischesElement = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_MathematischerTermOfMathematischesElement = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Funktion = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Operator = new clsDBLevel(objLocalConfig.Globals);

            objDataWork_Amount = new clsDataWork_Amount(objLocalConfig.Globals);

            OItem_Result_Sachaufgabe = objLocalConfig.Globals.LState_Nothing.Clone();
            OItem_Result_MathematischesElement = objLocalConfig.Globals.LState_Nothing.Clone();
            OItem_Result_MengeOfMathematischesElement = objLocalConfig.Globals.LState_Nothing.Clone();
            OItem_Result_MathematischerTermOfMathematischesElement = objLocalConfig.Globals.LState_Nothing.Clone();
            OItem_Result_Funktion = objLocalConfig.Globals.LState_Nothing.Clone();
            OItem_Result_Operator = objLocalConfig.Globals.LState_Nothing.Clone();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OntWeb.Classes
{
    public class ClassRel
    {
        public string ID_Class_Left { get; set; }
        public string ID_Class_Right { get; set; }
        public string ID_RelationType { get; set; }
        public string Ontology { get; set; }
        public long? Min_Forw { get; set; }
        public long? Max_Forw { get; set; }
        public long? Max_Backw { get; set; }

        public ClassRel()
        {
            
        }

        public ClassRel(string ID_Class_Left, string ID_Class_Right, string ID_RelationType)
        {
            this.ID_Class_Left = ID_Class_Left;
            this.ID_Class_Right = ID_Class_Right;
            this.ID_RelationType = ID_RelationType;

        }

        public ClassRel(string ID_Class_Left, string ID_Class_Right = null, string Ontology, string ID_RelationType)
        {
            this.ID_Class_Left = ID_Class_Left;
            this.ID_Class_Right = ID_Class_Right;
            this.ID_RelationType = ID_RelationType;
            this.Ontology = Ontology;

        }


        public ClassRel(string ID_Class_Left, string ID_Class_Right, string ID_RelationType, long? Min_Forw, long? Max_Forw, long? Max_Backw)
        {
            this.ID_Class_Left = ID_Class_Left;
            this.ID_Class_Right = ID_Class_Right;
            this.ID_RelationType = ID_RelationType;
            this.Min_Forw = Min_Forw;
            this.Max_Forw = Max_Forw;
            this.Max_Backw = Max_Backw;

        }

        public ClassRel(string ID_Class_Left, string ID_Class_Right=null, string Ontology, string ID_RelationType, long? Min_Forw, long? Max_Forw, long? Max_Backw)
        {
            this.ID_Class_Left = ID_Class_Left;
            this.ID_Class_Right = ID_Class_Right;
            this.Ontology = Ontology;
            this.ID_RelationType = ID_RelationType;
            this.Min_Forw = Min_Forw;
            this.Max_Forw = Max_Forw;
            this.Max_Backw = Max_Backw;

        }

        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OntWeb.Classes
{
    public class ClassRelFull
    {
        private List<OntologyItem> Classes_Left = new List<OntologyItem>();
        private List<OntologyItem> Classes_Right = new List<OntologyItem>();
        private List<OntologyItem> _RelationTypes = new List<OntologyItem>(); 
        private List<ClassRel> _ClassRels = new List<ClassRel>();

        public List<OntologyItem> ClassesLeft
        {
            get { return Classes_Left; }
        }

        public List<OntologyItem> ClassesRight
        {
            get { return Classes_Right; }
        }

        public List<OntologyItem> RelationTypes
        {
            get { return _RelationTypes;  }
        }

        public List<ClassRel> ClassRels
        {
            get { return _ClassRels;  }
        }
        
        public void AddClassLeft(OntologyItem OItem_Class)
        {
            AddClass(true,OItem_Class);
        }

        public void AddClassRight(OntologyItem OItem_Class)
        {
            AddClass(false,OItem_Class);
        }

        private void AddClass(Boolean IsLeft, OntologyItem OItem_Class)
        {
            if (IsLeft)
            {
                Classes_Left.Add(OItem_Class);
            }
            else
            {
                Classes_Right.Add(OItem_Class);
            }
        }

        public void AddRelationType(OntologyItem OItem_RelationType)
        {
            RelationTypes.Add(OItem_RelationType);
        }

        public void AddClassRel(ClassRel CRel)
        {
            _ClassRels.Add(CRel);
        }

    
    }
}
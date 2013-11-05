using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.BaseClasses;

namespace OntologyClasses.DataClasses
{
    public class clsBaseClassRelation
    {

        private clsClasses objClasses = new clsClasses();
        private clsRelationTypes objRelationTypes = new clsRelationTypes();

        public clsClassRel Rel_Ontologyies_To_Ontologies { get; private set; }
        public clsClassRel Rel_Ontologyies_To_OntologyItems { get; private set; }
        public clsClassRel Rel_Ontologyies_To_OntologyJoins { get; private set; }
        public clsClassRel Rel_OntologyJoins_To_OntologyItems { get; private set; }
        public clsClassRel Rel_OntologyMappings_To_MappingItems_src { get; private set; }
        public clsClassRel Rel_OntologyMappings_To_MappingItems_dst { get; private set; }
        public clsClassRel Rel_OntologyMappings_To_MappingRules { get; private set; }
        public clsClassRel Rel_OntologyMappingItems_To_OntologyJoins { get; private set; }
        public clsClassRel Rel_OntologyMappingItems_To_Direction { get; private set; }
        public clsClassRel Rel_OntologyMappingItems_To_MappingItems { get; private set; }

        public List<clsClassRel> ClassRelations { get; private set; }
        public clsTypes objTypes = new clsTypes();

        public clsBaseClassRelation()
        {
            Rel_Ontologyies_To_Ontologies = new clsClassRel
                {
                    ID_Class_Left = objClasses.OItem_Class_Ontologies.GUID,
                    ID_Class_Right = objClasses.OItem_Class_Ontologies.GUID,
                    ID_RelationType = objRelationTypes.OItem_RelationType_Contains.GUID,
                    Min_Forw = 0,
                    Max_Forw = -1,
                    Max_Backw = -1,
                    Ontology = objTypes.ClassType
                };

            Rel_Ontologyies_To_OntologyItems = new clsClassRel
                {
                    ID_Class_Left = objClasses.OItem_Class_Ontologies.GUID,
                    ID_Class_Right = objClasses.OItem_Class_OntologyItems.GUID,
                    ID_RelationType = objRelationTypes.OItem_RelationType_Contains.GUID,
                    Min_Forw = 0,
                    Max_Forw = -1,
                    Max_Backw = -1,
                    Ontology = objTypes.ClassType
                };

            Rel_Ontologyies_To_OntologyJoins = new clsClassRel
                {
                    ID_Class_Left = objClasses.OItem_Class_Ontologies.GUID,
                    ID_Class_Right = objClasses.OItem_Class_OntologyJoin.GUID,
                    ID_RelationType = objRelationTypes.OItem_RelationType_Contains.GUID,
                    Min_Forw = 0,
                    Max_Forw = -1,
                    Max_Backw = -1,
                    Ontology = objTypes.ClassType
                };

            Rel_OntologyJoins_To_OntologyItems = new clsClassRel
                {
                    ID_Class_Left = objClasses.OItem_Class_OntologyJoin.GUID,
                    ID_Class_Right = objClasses.OItem_Class_OntologyItems.GUID,
                    ID_RelationType = objRelationTypes.OItem_RelationType_Contains.GUID,
                    Min_Forw = 0,
                    Max_Forw = -1,
                    Max_Backw = -1,
                    Ontology = objTypes.ClassType
                };

            Rel_OntologyMappings_To_MappingItems_src = new clsClassRel
                {
                    ID_Class_Left = objClasses.OItem_Class_OntologyMapping.GUID,
                    ID_Class_Right = objClasses.OItem_Class_OntologyMappingItem.GUID,
                    ID_RelationType = objRelationTypes.OItem_RelationType_Src.GUID,
                    Min_Forw = 1,
                    Max_Forw = 1,
                    Max_Backw = -1,
                    Ontology = objTypes.ClassType
                };

            Rel_OntologyMappings_To_MappingItems_dst = new clsClassRel
                {
                    ID_Class_Left = objClasses.OItem_Class_OntologyMapping.GUID,
                    ID_Class_Right = objClasses.OItem_Class_OntologyMappingItem.GUID,
                    ID_RelationType = objRelationTypes.OItem_RelationType_Dst.GUID,
                    Min_Forw = 1,
                    Max_Forw = 1,
                    Max_Backw = -1,
                    Ontology = objTypes.ClassType
                };

            Rel_OntologyMappings_To_MappingRules = new clsClassRel
                {
                    ID_Class_Left = objClasses.OItem_Class_OntologyMapping.GUID,
                    ID_Class_Right = objClasses.OItem_Class_MappingRule.GUID,
                    ID_RelationType = objRelationTypes.OItem_RelationType_Apply.GUID,
                    Min_Forw = 1,
                    Max_Forw = -1,
                    Max_Backw = -1,
                    Ontology = objTypes.ClassType
                };

            Rel_OntologyMappings_To_MappingRules = new clsClassRel
                {
                    ID_Class_Left = objClasses.OItem_Class_OntologyMapping.GUID,
                    ID_Class_Right = objClasses.OItem_Class_MappingRule.GUID,
                    ID_RelationType = objRelationTypes.OItem_RelationType_Apply.GUID,
                    Min_Forw = 1,
                    Max_Forw = -1,
                    Max_Backw = -1
                };

            Rel_OntologyMappingItems_To_OntologyJoins = new clsClassRel
                {
                    ID_Class_Left = objClasses.OItem_Class_OntologyMappingItem.GUID,
                    ID_Class_Right = objClasses.OItem_Class_OntologyJoin.GUID,
                    ID_RelationType = objRelationTypes.OItem_RelationType_belongingsTo.GUID,
                    Min_Forw = 1,
                    Max_Forw = 1,
                    Max_Backw = -1,
                    Ontology = objTypes.ClassType
                };

            Rel_OntologyMappingItems_To_Direction = new clsClassRel
                {
                    ID_Class_Left = objClasses.OItem_Class_OntologyMappingItem.GUID,
                    ID_Class_Right = objClasses.OItem_Class_Directions.GUID,
                    ID_RelationType = objRelationTypes.OItem_RelationType_belonging.GUID,
                    Min_Forw = 1,
                    Max_Forw = 1,
                    Max_Backw = -1,
                    Ontology = objTypes.ClassType
                };
            Rel_OntologyMappingItems_To_MappingItems = new clsClassRel
                {
                    ID_Class_Left = objClasses.OItem_Class_OntologyMappingItem.GUID,
                    ID_Class_Right = objClasses.OItem_Class_OntologyMappingItem.GUID,
                    ID_RelationType = objRelationTypes.OItem_RelationType_Contains.GUID,
                    Min_Forw = 0,
                    Max_Forw = -1,
                    Max_Backw = -1,
                    Ontology = objTypes.ClassType
                };

            ClassRelations = new List<clsClassRel>
                {
                    Rel_OntologyJoins_To_OntologyItems,
                    Rel_OntologyMappingItems_To_Direction,
                    Rel_OntologyMappingItems_To_MappingItems,
                    Rel_OntologyMappingItems_To_OntologyJoins,
                    Rel_OntologyMappings_To_MappingItems_dst,
                    Rel_OntologyMappings_To_MappingItems_src,
                    Rel_OntologyMappings_To_MappingRules,
                    Rel_Ontologyies_To_Ontologies,
                    Rel_Ontologyies_To_OntologyItems,
                    Rel_Ontologyies_To_OntologyJoins
                };
        }
    }
}

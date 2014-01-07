using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ElasticSearchNestConnector;
using OntologyClasses.BaseClasses;
using Ontology_Module;

namespace NestTest
{
    public partial class frmNestTest : Form
    {
        private clsDBSelector objDBSelector;
        private clsDBUpdater objDBUpdater;
        private clsDBDeletor objDBDeletor;
        private clsGlobals objGlobals = new clsGlobals();

        public frmNestTest()
        {
            InitializeComponent();

            TestNest();
        }

        private void TestNest()
        {
            objDBSelector = new clsDBSelector("localhost",9200,"ontology_db","Report",20000,"Test123");
            objDBUpdater = new clsDBUpdater(objDBSelector);
            objDBDeletor = new clsDBDeletor(objDBSelector);

            var objOList_AttTypes = new List<clsOntologyItem>
                {
                    new clsOntologyItem
                        {
                            GUID = objGlobals.NewGUID,
                            Name = "test123",
                            GUID_Parent = objGlobals.DType_Int.GUID,
                            Type = objGlobals.Type_AttributeType
                        }
                };


            objDBUpdater.save_AttributeType(objOList_AttTypes.First());

            objDBDeletor.del_AttributeType(objOList_AttTypes);
        }
    }
}

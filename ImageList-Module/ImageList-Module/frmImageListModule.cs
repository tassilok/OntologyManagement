using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ontology_Module;
using OntologyClasses.BaseClasses;

namespace ImageList_Module
{
    public partial class frmImageListModule : Form
    {
        private clsLocalConfig objLocalConfig;

        private UserControl_OItemList objUserControl_ImageLists;
        private UserControl_OItemList objUserControl_Images_List;
        private clsDataWork_Images objDataWork_Images;

        public frmImageListModule()
        {
            InitializeComponent();

            objLocalConfig = new clsLocalConfig(new clsGlobals());

            Initialize();
        }

        private void Initialize()
        {
            objUserControl_ImageLists = new UserControl_OItemList(objLocalConfig.Globals);
            objUserControl_ImageLists.Selection_Changed += objUserControl_ImageLists_Selection_Changed;
            objUserControl_ImageLists.Dock = DockStyle.Fill;
            splitContainer1.Panel1.Controls.Add(objUserControl_ImageLists);

            objUserControl_Images_List = new UserControl_OItemList(objLocalConfig.Globals);
            objUserControl_Images_List.Dock = DockStyle.Fill;
            splitContainer2.Panel1.Controls.Add(objUserControl_Images_List);

            objUserControl_ImageLists.initialize(new clsOntologyItem
            {
                GUID_Parent = objLocalConfig.OItem_class_image_lists.GUID,
                Type = objLocalConfig.Globals.Type_Object
            });

            objDataWork_Images = new clsDataWork_Images(objLocalConfig);

        }

        void objUserControl_ImageLists_Selection_Changed()
        {
            objUserControl_Images_List.clear_Relation();
            if (objUserControl_ImageLists.DataGridViewRowCollection_Selected.Count == 1)
            {
                var rowView = ((DataRowView)objUserControl_ImageLists.DataGridViewRowCollection_Selected[0].DataBoundItem);
                var objOItem_ImageList = new clsOntologyItem {GUID = rowView[objUserControl_ImageLists.RowName_GUID].ToString(),
                    Name = rowView[objUserControl_ImageLists.RowName_Name].ToString(),
                    GUID_Parent = rowView[objUserControl_ImageLists.RowName_GUIDParent].ToString(),
                    Type = objLocalConfig.Globals.Type_Object};

                objDataWork_Images.GetData_ImagesOfImageList(objOItem_ImageList);

                objUserControl_Images_List.initialize(null,
                    objOItem_ImageList,
                    objLocalConfig.Globals.Direction_LeftRight,
                    new clsOntologyItem {GUID_Parent = objLocalConfig.OItem_class_images__image_lists_.GUID, 
                        Type = objLocalConfig.Globals.Type_Object},
                        objLocalConfig.OItem_relationtype_contains);


            }
        }
    }
}

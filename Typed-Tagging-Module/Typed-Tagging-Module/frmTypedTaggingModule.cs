﻿using System;
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
using Security_Module;

namespace Typed_Tagging_Module
{
    public partial class frmTypedTaggingModule : Form
    {
        private clsLocalConfig objLocalConfig;

        private UserControl_RefTree objUserControl_RefTree;

        private UserControl_TaggingContainer objUserControl_TaggingContainer;

        private frmAuthenticate objFrmAuthenticate;

        public frmTypedTaggingModule()
        {
            InitializeComponent();

            objLocalConfig = new clsLocalConfig(new clsGlobals());

            Initialize();
        }

        private void Initialize()
        {
            objFrmAuthenticate = new frmAuthenticate(objLocalConfig.Globals, true, true, frmAuthenticate.ERelateMode.User_To_Group, true);
            objFrmAuthenticate.ShowDialog(this);
            if (objFrmAuthenticate.DialogResult == DialogResult.OK)
            {
                objLocalConfig.OItem_User = objFrmAuthenticate.OItem_User;
                objLocalConfig.OItem_Group = objFrmAuthenticate.OItem_Group;

                objUserControl_RefTree = new UserControl_RefTree(objLocalConfig.Globals);
                objUserControl_RefTree.Dock = DockStyle.Fill;
                splitContainer1.Panel1.Controls.Add(objUserControl_RefTree);

                objUserControl_RefTree.selected_Node += objUserControl_RefTree_selected_Node;

                objUserControl_TaggingContainer = new UserControl_TaggingContainer(objLocalConfig);
                objUserControl_TaggingContainer.Dock = DockStyle.Fill;
                splitContainer1.Panel2.Controls.Add(objUserControl_TaggingContainer);

                var objOList_Classes = new List<clsOntologyItem> { objLocalConfig.OItem_class_typed_tag };
                var objOList_RelationTypes = new List<clsOntologyItem> { objLocalConfig.OItem_relationtype_is_tagging };

                objUserControl_RefTree.initialize_Tree(objOList_Classes, objOList_RelationTypes);
            }
            else
            {
                Environment.Exit(-1);
            }

            
        }

        void objUserControl_RefTree_selected_Node(clsOntologyItem OItem_Selected)
        {
            objUserControl_TaggingContainer.Initialize_Taging(OItem_Selected);
        }
    }
}

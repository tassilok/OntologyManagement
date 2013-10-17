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

namespace Version_Module
{
    public partial class frmVersionEdit : Form
    {

        private clsOntologyItem objOItem_Ref;

        private clsLocalConfig objLocalConfig;
        private clsVersionWork objVersionWork;
        private UserControl_VersionEdit userControl_VersionEdit;

        private bool boolOpen;

        public clsOntologyItem OItem_Result { get; private set; }

        public clsOntologyItem OItem_Version { get; private set; }

        public clsOntologyItem OItem_LogEntry
        {
            get { return objVersionWork.OItem_LogEntry; }
        }


        public long Major
        {
            get { return userControl_VersionEdit.Major; }
            set { userControl_VersionEdit.Major = value; }
        }

        public long Minor
        {
            get { return userControl_VersionEdit.Minor; }
            set { userControl_VersionEdit.Minor = value; }
        }

        public long Build
        {
            get { return userControl_VersionEdit.Build; }
            set { userControl_VersionEdit.Build = value; }
        }

        public long Revision
        {
            get { return userControl_VersionEdit.Revision; }
            set { userControl_VersionEdit.Revision = value; }
        }

        public frmVersionEdit(clsOntologyItem OItem_Ref, clsLocalConfig LocalConfig)
        {
            InitializeComponent();

            objOItem_Ref = OItem_Ref;
            objLocalConfig = LocalConfig;
            boolOpen = false;
            initialize();
        }

        public frmVersionEdit(clsOntologyItem OItem_Ref, clsGlobals Globals, clsOntologyItem OItem_User )
        {
            InitializeComponent();

            objOItem_Ref = OItem_Ref;
            objLocalConfig = new clsLocalConfig(Globals);
            objLocalConfig.objUser = OItem_User;
            boolOpen = false;
            initialize();
        }

        private void initialize()
        {
            userControl_VersionEdit = new UserControl_VersionEdit();
            userControl_VersionEdit.Dock = DockStyle.Fill;
            this.Controls.Add(userControl_VersionEdit);
            userControl_VersionEdit.applied_Version +=userControl_VersionEdit_applied_Version;
            objVersionWork = new clsVersionWork(objLocalConfig, this, objOItem_Ref);
            var objOItem_Result = objVersionWork.get_VersionData();
            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                
                userControl_VersionEdit.Major = objVersionWork.Major;
                userControl_VersionEdit.Minor = objVersionWork.Minor;
                userControl_VersionEdit.Build = objVersionWork.Build;
                userControl_VersionEdit.Revision = objVersionWork.Revision;
                boolOpen = true;
            }

            if (!boolOpen)
            {
                MessageBox.Show(this, "Die Version konnte nicht emittelt werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void userControl_VersionEdit_applied_Version()
        {
            OItem_Result = objVersionWork.save_Version(true,
                                                        userControl_VersionEdit.Major,
                                                        userControl_VersionEdit.Minor,
                                                        userControl_VersionEdit.Build,
                                                        userControl_VersionEdit.Revision);
            if (OItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                OItem_Version = objVersionWork.objVersion;
            }
            else
            {
                OItem_Version = null;
            }
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void userControl_VersionEdit_Load(object sender, EventArgs e)
        {
            
        }

        private void frmVersionEdit_Load(object sender, EventArgs e)
        {
            if (!boolOpen)
            {
                Close();
            }

        }

    }
}

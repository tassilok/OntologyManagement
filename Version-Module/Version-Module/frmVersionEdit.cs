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

        private bool removeOldVersions;

        public clsOntologyItem OItem_Result { get; private set; }

        public clsOntologyItem OItem_Version { get; private set; }

        public clsObjectAtt OAItem_Message { get; private set; }

        public clsOntologyItem OItem_LogState { get; set; }
        public string MessageForLogEntry { get; set;  }

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

        public long MajorFirst
        {
            get { return userControl_VersionEdit.MajorFirst; }
        }

        public long MinorFirst
        {
            get { return userControl_VersionEdit.MinorFirst; }
        }

        public long BuildFirst
        {
            get { return userControl_VersionEdit.BuildFirst; }
        }

        public long RevisionFirst
        {
            get { return userControl_VersionEdit.RevisionFirst; }
        }

        public void IncreaseVersion(int major, int minor, int build, int revision)
        {
            userControl_VersionEdit.IncreaseVersion(major, minor, build, revision);
        }

        public frmVersionEdit(clsLocalConfig LocalConfig)
        {
            InitializeComponent();

            
            objLocalConfig = LocalConfig;
            boolOpen = false;
            initialize();
        }

        public frmVersionEdit(clsGlobals Globals, clsOntologyItem OItem_User )
        {
            InitializeComponent();

            
            objLocalConfig = new clsLocalConfig(Globals);
            objLocalConfig.objUser = OItem_User;
            
            boolOpen = false;
            initialize();
        }

        public void Initialize_VersionEdit(clsOntologyItem OItem_Ref, bool removeOldVersions = true)
        {
            boolOpen = false;
            objOItem_Ref = OItem_Ref;
            this.Text = OItem_Ref.Name;
            this.removeOldVersions = removeOldVersions;

            if (objVersionWork == null)
            {
                objVersionWork = new clsVersionWork(objLocalConfig, this);
            }


            var objOItem_Result = objVersionWork.get_VersionData(objOItem_Ref);
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
                boolOpen = false;
                MessageBox.Show(this, "Die Version konnte nicht emittelt werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void initialize()
        {
            userControl_VersionEdit = new UserControl_VersionEdit();
            userControl_VersionEdit.Dock = DockStyle.Fill;
            this.Controls.Add(userControl_VersionEdit);
            userControl_VersionEdit.applied_Version +=userControl_VersionEdit_applied_Version;
            
        }

        public void ApplyVersion()
        {

            objVersionWork.MessageForLogEntry = MessageForLogEntry;
            objVersionWork.OItem_LogState = OItem_LogState;
            OItem_Result = objVersionWork.save_Version(true,
                                                        userControl_VersionEdit.Major,
                                                        userControl_VersionEdit.Minor,
                                                        userControl_VersionEdit.Build,
                                                        userControl_VersionEdit.Revision, removeOldVersions: removeOldVersions);
            MessageForLogEntry = objVersionWork.MessageForLogEntry;
            OItem_LogState = objVersionWork.OItem_LogState;
            if (OItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                OAItem_Message = objVersionWork.OAItem_Message;
                OItem_Version = objVersionWork.objVersion;
            }
            else
            {
                OItem_Version = null;
            }
            this.DialogResult = DialogResult.OK;
            if (this.Visible)
            {
                Close();
            }

            
        }

        private void userControl_VersionEdit_applied_Version()
        {
            ApplyVersion();
            
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

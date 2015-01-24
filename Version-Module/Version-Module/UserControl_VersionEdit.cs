using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OntologyClasses.BaseClasses;

namespace Version_Module
{
    public delegate void Applied_Version();

    public partial class UserControl_VersionEdit : UserControl
    {

        public long MajorFirst { get; private set; }
        public long MinorFirst { get; private set; }
        public long BuildFirst { get; private set; }
        public long RevisionFirst { get; private set; }

        public event Applied_Version applied_Version;

        public long Major
        {
            get { return long.Parse(NumericUpDown_Marjor.Value.ToString()); }
            set 
            {
                MajorFirst = value;
                NumericUpDown_Marjor.Value = value; 
            }
        }

        

        public long Minor
        {
            get { return long.Parse(NumericUpDown_Minor.Value.ToString()); }
            set 
            {
                MinorFirst = value;
                NumericUpDown_Minor.Value = value; 
            }
        }

        public long Build
        {
            get { return long.Parse(NumericUpDown_Build.Value.ToString()); }
            set 
            {
                BuildFirst = value;
                NumericUpDown_Build.Value = value; 
            }
        }

        public long Revision
        {
            get { return long.Parse(NumericUpDown_Revision.Value.ToString()); }
            set 
            {
                RevisionFirst = value;
                NumericUpDown_Revision.Value = value; 
            }
        }

        public void IncreaseVersion(int major, int minor, int build, int revision)
        {
            NumericUpDown_Marjor.Value += major;
            NumericUpDown_Minor.Value += minor;
            NumericUpDown_Build.Value += build;
            NumericUpDown_Revision.Value += revision;
        }

        public void firstVersion(long major, long minor, long build, long revision)
        {
            MajorFirst = major;
            Major = MajorFirst;
            MinorFirst = minor;
            Minor = MinorFirst;
            BuildFirst = build;
            Build = BuildFirst;
            RevisionFirst = revision;
            Revision = RevisionFirst;

        }

        public UserControl_VersionEdit()
        {
            InitializeComponent();
        }

        private void ToolStripButton_Apply_Click(object sender, EventArgs e)
        {
            applied_Version();
        }

        private void NumericUpDown_Marjor_ValueChanged(object sender, EventArgs e)
        {
            Configure_ApplyClear();
        }

        private void Configure_ApplyClear()
        {
            ToolStripButton_Clear.Enabled = false;
            ToolStripButton_Apply.Enabled = false;
            if (NumericUpDown_Marjor.Value != MajorFirst ||
                NumericUpDown_Minor.Value != MinorFirst ||
                NumericUpDown_Build.Value != BuildFirst ||
                NumericUpDown_Revision.Value != RevisionFirst)
            {
                ToolStripButton_Apply.Enabled = true;
                ToolStripButton_Clear.Enabled = true;
            }
        }

        private void ToolStripButton_Clear_Click(object sender, EventArgs e)
        {
            Major = MajorFirst;
            Minor = MinorFirst;
            Build = BuildFirst;
            Revision = RevisionFirst;

            Configure_ApplyClear();
        }

        private void NumericUpDown_Minor_ValueChanged(object sender, EventArgs e)
        {
            Configure_ApplyClear();
        }

        private void NumericUpDown_Build_ValueChanged(object sender, EventArgs e)
        {
            Configure_ApplyClear();
        }

        private void NumericUpDown_Revision_ValueChanged(object sender, EventArgs e)
        {
            Configure_ApplyClear();
        }

        private void ToolStripButton_Cancel_Click(object sender, EventArgs e)
        {

        }
    }
}

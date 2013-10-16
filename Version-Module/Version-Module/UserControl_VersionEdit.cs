using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Version_Module
{
    public delegate void Applied_Version();

    public partial class UserControl_VersionEdit : UserControl
    {

        private long majorFirst;
        private long minorFirst;
        private long buildFirst;
        private long revisionFirst;

        public event Applied_Version applied_Version;
        public long Major
        {
            get { return long.Parse(NumericUpDown_Marjor.Value.ToString()); }
            set { NumericUpDown_Marjor.Value = value; }
        }

        public long Minor
        {
            get { return long.Parse(NumericUpDown_Minor.Value.ToString()); }
            set { NumericUpDown_Minor.Value = value; }
        }

        public long Build
        {
            get { return long.Parse(NumericUpDown_Build.Value.ToString()); }
            set { NumericUpDown_Build.Value = value; }
        }

        public long Revision
        {
            get { return long.Parse(NumericUpDown_Revision.Value.ToString()); }
            set { NumericUpDown_Revision.Value = value; }
        }

        public void firstVersion(long major, long minor, long build, long revision)
        {
            majorFirst = major;
            Major = majorFirst;
            minorFirst = minor;
            Minor = minorFirst;
            buildFirst = build;
            Build = buildFirst;
            revisionFirst = revision;
            Revision = revisionFirst;

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
            if (NumericUpDown_Marjor.Value != majorFirst ||
                NumericUpDown_Minor.Value != minorFirst ||
                NumericUpDown_Build.Value != buildFirst ||
                NumericUpDown_Revision.Value != revisionFirst)
            {
                ToolStripButton_Apply.Enabled = true;
                ToolStripButton_Clear.Enabled = true;
            }
        }

        private void ToolStripButton_Clear_Click(object sender, EventArgs e)
        {
            Major = majorFirst;
            Minor = minorFirst;
            Build = buildFirst;
            Revision = revisionFirst;

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
    }
}

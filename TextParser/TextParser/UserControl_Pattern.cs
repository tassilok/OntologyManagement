using System;
using System.Linq;
using System.Windows.Forms;
using OntologyClasses.BaseClasses;
using Structure_Module;

namespace TextParser
{
    public partial class UserControl_Pattern : UserControl
    {
        private clsLocalConfig localConfig;
        private clsOntologyItem oItem_Ref;

        public delegate void CloseParent(bool HideOnly);
        public event CloseParent CloseParentForm;

        public delegate void AppliedPattern(clsSearchPattern pattern);

        public event AppliedPattern PatternApplied;

        private delegate void InvokeAfterResult();

        private clsOntologyItem oItem_LoadResult;

        private InvokeAfterResult invokeAfterResult;

        public UserControl_Pattern(clsLocalConfig localConfig, clsOntologyItem OItem_Ref = null)
        {
            InitializeComponent();

            this.localConfig = localConfig;
            oItem_Ref = OItem_Ref;

            Initialize();
        }

        private void Initialize()
        {
            if (localConfig.DataWork_Pattern == null)
            {
                localConfig.DataWork_Pattern = new clsDataWork_Pattern(localConfig);
                localConfig.DataWork_Pattern.LoadedPattern += dataWork_Pattern_LoadedPattern;
                 
            }
            localConfig.DataWork_Pattern.GetData(oItem_Ref);   

            invokeAfterResult = new InvokeAfterResult(ChangeFormAfterLoad);
            toolStripProgressBar_Load.Visible = true;
        }

        private void ChangeFormAfterLoad()
        {
            toolStripProgressBar_Load.Visible = false;

            if (oItem_LoadResult.GUID == localConfig.Globals.LState_Error.GUID)
            {
                MessageBox.Show(this, "Beim Laden der Pattern ist ein Fehler aufgetreten!", "Fehler!",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                if (CloseParentForm != null)
                {
                    CloseParentForm(true);
                }
            }
            else
            {
                FillListView();
            }
        }

        void dataWork_Pattern_LoadedPattern(clsOntologyItem oItem_Result)
        {
            oItem_LoadResult = oItem_Result;
            if (InvokeRequired)
            {
                Invoke(invokeAfterResult);
            }
            else
            {
                ChangeFormAfterLoad();
            }
            

        }

        private void UserControl_Pattern_Load(object sender, EventArgs e)
        {

            if (localConfig.DataWork_Pattern.Result != null && localConfig.DataWork_Pattern.Result.GUID == localConfig.Globals.LState_Error.GUID)
            {
                if (CloseParentForm != null)
                {
                    CloseParentForm(true);
                }
            }
        }

        public void InitializePatternView(string filter)
        {
            toolStripTextBox_Filter.Text = filter;
            FillListView();
        }

        private void FillListView()
        {
            dataGridView_Pattern.DataSource = null;
            SortableBindingList<clsSearchPattern> patternList;
            if (localConfig.DataWork_Pattern.SearchPatterns != null && localConfig.DataWork_Pattern.SearchPatterns.Any())
            {
                if (!string.IsNullOrEmpty(toolStripTextBox_Filter.Text))
                {
                    patternList = new SortableBindingList<clsSearchPattern>(localConfig.DataWork_Pattern.SearchPatterns.Where(pat => pat.Pattern.ToLower().Contains(toolStripTextBox_Filter.Text.ToLower())));
                }
                else
                {
                    patternList = new SortableBindingList<clsSearchPattern>(localConfig.DataWork_Pattern.SearchPatterns);
                }
                dataGridView_Pattern.DataSource = patternList;
                foreach (DataGridViewColumn col in dataGridView_Pattern.Columns)
                {
                    col.Visible = (col.DataPropertyName == "Pattern");
                    col.Width = dataGridView_Pattern.Width - 20;

                }
            }
            

            
        }

        private void toolStripTextBox_Filter_TextChanged(object sender, EventArgs e)
        {
            timer_Pattern.Stop();
            timer_Pattern.Start();
        }

        private void timer_Pattern_Tick(object sender, EventArgs e)
        {
            timer_Pattern.Stop();
            FillListView();
        }

        private void toolStripButton_Cancel_Click(object sender, EventArgs e)
        {
            localConfig.DataWork_Pattern.Abort();
            if (CloseParentForm != null)
            {
                CloseParentForm(true);
            }
        }

        private void dataGridView_Pattern_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    CloseParentForm(true);
                    break;
                case Keys.Enter:
                    if (dataGridView_Pattern.SelectedRows.Count == 1)
                    {
                        clsSearchPattern searchPattern =
                            (clsSearchPattern) dataGridView_Pattern.SelectedRows[0].DataBoundItem;
                        if (PatternApplied != null)
                        {
                            PatternApplied(searchPattern);
                        }
                    }
                    break;
            }
        }

        private void toolStripTextBox_Filter_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    CloseParentForm(true);
                    break;
            }
        }
    }
}

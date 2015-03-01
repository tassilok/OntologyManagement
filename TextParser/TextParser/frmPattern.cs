using System.Windows.Forms;
using OntologyClasses.BaseClasses;
using Ontology_Module;

namespace TextParser
{
    public partial class frmPattern : Form
    {
        private readonly clsLocalConfig localConfig;

        private readonly clsOntologyItem _oItemRef;

        private UserControl_Pattern _userControlPattern;

        public event UserControl_Pattern.AppliedPattern PatternApplied;

        public frmPattern(clsGlobals globals, clsOntologyItem oItemRef)
        {
            InitializeComponent();

            _oItemRef = oItemRef;
            localConfig = new clsLocalConfig(globals);

            Initialize();
        }

        public frmPattern(clsLocalConfig localConfig, clsOntologyItem oItemRef)
        {
            InitializeComponent();

            _oItemRef = oItemRef;
            this.localConfig = localConfig;

            Initialize();
        }

        public void InitializePatternView(string filter)
        {
            _userControlPattern.InitializePatternView(filter);
        }

        private void Initialize()
        {
            _userControlPattern = new UserControl_Pattern(localConfig, _oItemRef);
            _userControlPattern.CloseParentForm += userControl_Pattern_CloseParentForm;
            _userControlPattern.PatternApplied += _userControlPattern_PatternApplied;
            _userControlPattern.Dock = DockStyle.Fill;
            Controls.Add(_userControlPattern);
        }

        void _userControlPattern_PatternApplied(clsSearchPattern pattern)
        {
            if (PatternApplied != null)
            {
                PatternApplied(pattern);    
                Hide();
            }
            
        }

        void userControl_Pattern_CloseParentForm(bool hideOnly)
        {
            if (hideOnly)
            {
                Hide();
            }
            else
            {
                Close();
            }
        }

        private void frmPattern_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Hide();
                    break;
            }
        }
    }
}

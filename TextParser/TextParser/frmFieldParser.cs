using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Structure_Module;

namespace TextParser
{
    public partial class frmFieldParser : Form
    {
        private clsLocalConfig objLocalConfig;

        
        public frmFieldParser(clsLocalConfig LocalConfig)
        {
            InitializeComponent();
            objLocalConfig = LocalConfig;

            Initialize();
        }

        private void Initialize()
        {
            
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Code_Modeller_module
{
    public partial class UserControl_CodeModell : UserControl
    {
        private clsLocalConfig objLocalConfig;

        public UserControl_CodeModell(clsLocalConfig LocalConfig)
        {
            InitializeComponent();

            objLocalConfig = LocalConfig;


        }

        private void Fill_Tree()
        {

        }
    }
}

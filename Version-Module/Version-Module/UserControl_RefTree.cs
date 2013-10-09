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
    public partial class UserControl_RefTree : UserControl
    {
        private clsDataWork_RefTree objDataWork_RefTree;

        public UserControl_RefTree(clsDataWork_RefTree DataWork_RefTree)
        {
            InitializeComponent();
            objDataWork_RefTree = DataWork_RefTree;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OutlookConnector_Module
{
    public partial class UserControl_OutlookItemList : UserControl
    {
        private clsLocalConfig objLocalConfig;
        private clsDataWork_OutlookItems objDataWork_OutlookItems;
        private clsDataWork_OutlookConnector objDataWork_OutlookConnector;

        public UserControl_OutlookItemList(clsLocalConfig LocalConfig, clsDataWork_OutlookConnector DataWork_OutlookConnector)
        {
            InitializeComponent();
            objDataWork_OutlookConnector = DataWork_OutlookConnector;
            objLocalConfig = LocalConfig;
            Initialize();
        }

        private void Initialize()
        {
            objDataWork_OutlookItems = new clsDataWork_OutlookItems(objLocalConfig, objDataWork_OutlookConnector);
            objDataWork_OutlookItems.GetData_Documents();
        }
    }
}

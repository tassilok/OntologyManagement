using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Appointment_Module
{
    public partial class UserControl_Appointments : UserControl
    {
        clsLocalConfig objLocalConfig;

        public UserControl_Appointments(clsLocalConfig LocalConfig)
        {
            InitializeComponent();
            objLocalConfig = LocalConfig;
        }
    }
}

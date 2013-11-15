using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using SilverOnt.OServiceClasses;

namespace SilverOnt
{
    public class ClassItemSelectedEventArgs : EventArgs
    {
        public clsOntologyItem OItemSelected { get; private set; }

        public ClassItemSelectedEventArgs(clsOntologyItem oItemSelected)
        {
            OItemSelected = oItemSelected;
        }
    }
}

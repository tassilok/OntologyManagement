﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SilverOnt.OServiceClasses;

namespace SilverOnt
{
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();
        }

        // Wird ausgeführt, wenn der Benutzer zu dieser Seite navigiert.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void TypeTree_selectedClass_1(object sender, ClassItemSelectedEventArgs e)
        {
            objectGrid.IdClass = e.OItemSelected.GUID;
        }

        
    }
}
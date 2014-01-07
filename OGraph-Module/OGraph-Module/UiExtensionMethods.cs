﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace OGraph_Module
{
    public static class UiExtensionMethods
    {
        private static Action EmptyDelegate = delegate() { };


        public static void Refresh(this UIElement uiElement)
        {
            uiElement.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
        }

        public static void RefreshBinding(this UIElement uiElement)
        {
            uiElement.Dispatcher.Invoke(DispatcherPriority.DataBind, EmptyDelegate);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextProcessor_Module
{
    public partial class UserControl_TextProcessor : UserControl
    {
        public HtmlDocument htmlDoc { get; set; }
        private clsLocalConfig objLocalConfig;

        private KeyEventArgs lastKeyDown;

        private bool boolShift;
        private bool boolStrg;

        public KeyEventArgs LastKeyDown
        {
            get { return lastKeyDown; }
            set 
            { 
                lastKeyDown = value;
                if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                    boolStrg = true;
                else
                    boolStrg = false;

                if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
                    boolShift = true;
                else
                    boolShift = false;

                if (lastKeyDown.KeyCode == Keys.ShiftKey)
                {
                    
                }
                else if (lastKeyDown.KeyCode == Keys.ControlKey)
                {
                    
                }
                else if (lastKeyDown.KeyCode == Keys.Back)
                {
                    deleteLastSign();
                }
                else
                {
                    ParseKey(LastKeyDown);
                }
            }
        }

        private void deleteLastSign()
        {
            if (!string.IsNullOrEmpty(htmlDoc.Body.InnerText))
            {
                htmlDoc.Body.InnerText = htmlDoc.Body.InnerText.Substring(0, htmlDoc.Body.InnerText.Length - 1);
            }
        }

        private void ParseKey(KeyEventArgs key)
        {
            if (boolShift == true)
            {
                htmlDoc.Body.InnerText += ((char)key.KeyValue).ToString().ToUpper();
            }
            else if (boolStrg == true)
            {

            }
            else
            {
                htmlDoc.Body.InnerText += ((char)key.KeyValue).ToString().ToLower() ;
            }
        }


        public UserControl_TextProcessor(clsLocalConfig LocalConfig)
        {
            InitializeComponent();

            objLocalConfig = LocalConfig;
            Initialize();

        }

        private void Initialize()
        {
            
            webBrowser_Text.DocumentText = "<html><body></body></html>";
            htmlDoc = webBrowser_Text.Document;
            htmlDoc.Click += htmlDoc_Click;
        }

        void htmlDoc_Click(object sender, HtmlElementEventArgs e)
        {
            
        }

        private void UserControl_TextProcessor_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        
    }
}

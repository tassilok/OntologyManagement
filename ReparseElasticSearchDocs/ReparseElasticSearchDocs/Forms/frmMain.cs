using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ReparseElasticSearchDocs.Classes;

namespace ReparseElasticSearchDocs
{
    public partial class frmMain : Form
    {
        private clsLocalConfig objLocalConfig = new clsLocalConfig();
        private clsReparse objReparse;
        private clsNetParser objNetParser;
        public frmMain()
        {
            InitializeComponent();

            //objReparse = new clsReparse(objLocalConfig);
            //objReparse.initialize_Reparse_ES();

            
            objNetParser = new clsNetParser(objLocalConfig);
            objNetParser.initialize_Parsing();
            
            toolStripLabel_Port.Text = objLocalConfig.Network.Ports[0].ToString();
            if (objLocalConfig.Network.Ports.Count > 1)
            {
                toolStripLabel_Port.Text += " / " + objLocalConfig.Network.Ports[1].ToString();
                if (objLocalConfig.Network.Ports.Count > 2)
                {
                    toolStripLabel_Port.Text += " / " + objLocalConfig.Network.Ports[2].ToString();
                    if (objLocalConfig.Network.Ports.Count > 3)
                    {
                        toolStripLabel_Port.Text += " / " + objLocalConfig.Network.Ports[4].ToString();
                        if (objLocalConfig.Network.Ports.Count > 4)
                        {
                            toolStripLabel_Port.Text += " / " + objLocalConfig.Network.Ports[4].ToString();
                        }
                    }
                }
            

            }

            timer_Linecount.Start();
        }

        private void timer_Linecount_Tick(object sender, EventArgs e)
        {
            toolStripLabel_LineCount.Text = objNetParser.LineCount.ToString() + " - " +
                                            objNetParser.LineCount1.ToString() + " - " +
                                            objNetParser.LineCount2.ToString() + " - " +
                                            objNetParser.LineCount3.ToString() + " - " +
                                            objNetParser.LineCount4.ToString() + " - " +
                                            objNetParser.LineCount5.ToString();
        }       
    }
}

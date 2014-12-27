using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NextGenerationOntoEdit
{
    public partial class DataItemWidthChanger : Form
    {
        public delegate void ChangedWidth();
        public event ChangedWidth changedWidth;
        public int WidthOfItems { get; private set; }
        public List<ViewItem> ViewItems { get; private set; }
        private bool sync;



        public DataItemWidthChanger(int controlWidth, List<ViewItem> viewItems)
        {
            InitializeComponent();
            WidthOfItems = controlWidth;
            ViewItems = viewItems;
            trackBar_Width.Value = WidthOfItems;
        }

        private void trackBar_Width_ValueChanged(object sender, EventArgs e)
        {
            if (trackBar_Width.Value < 50)
            {
                trackBar_Width.Value = 50;
            }
            else
            {
                if (!sync)
                {
                    SyncWidthChnager(trackBar_Width);
                }
                WidthOfItems = trackBar_Width.Value;
                if (changedWidth != null)
                {
                    changedWidth();
                }
            }

        }

        private void numericUpDown_Width_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown_Width.Value < 50)
            {
                trackBar_Width.Value = 50;
            }
            else
            {
                if (!sync)
                {
                    SyncWidthChnager(numericUpDown_Width);
                }

                
            }

            
        }

        private void SyncWidthChnager(object sourceControl)
        {
            sync = true;
            if (sourceControl is NumericUpDown)
            {
                trackBar_Width.Value = (int)numericUpDown_Width.Value;
            }
            else
            {
                numericUpDown_Width.Value = trackBar_Width.Value;
            }
            sync = false;
        }
    }
}

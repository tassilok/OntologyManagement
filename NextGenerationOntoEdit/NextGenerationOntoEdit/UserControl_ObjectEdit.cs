using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OntologyClasses.BaseClasses;

namespace NextGenerationOntoEdit
{
    public partial class UserControl_ObjectEdit : UserControl
    {
        private clsLocalConfig localConfig;

        private UserControl_ObjectItemList userControl_ObjectItemList;

        private List<ControlLine> controlLines = new List<ControlLine>();

        private clsOntologyItem oItem;

        private List<ViewItem> viewItemList = new List<ViewItem>();

        private DataItemWidthChanger dataItemWidthChanger;

        public UserControl_ObjectEdit(clsLocalConfig localConfig)
        {
            this.localConfig = localConfig;
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            userControl_ObjectItemList = new UserControl_ObjectItemList(localConfig);
            userControl_ObjectItemList.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(userControl_ObjectItemList);
        }

        public void Initialize_OItem(clsOntologyItem oItem)
        {
            this.oItem = oItem;
            userControl_ObjectItemList.Initialize_OItem(oItem);
        }

        private void timer_ToogleVisibleToolStrip_Tick(object sender, EventArgs e)
        {
           
        }

        private void splitContainer1_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void toolStripContainer1_ContentPanel_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void toolStripButton_ToogleVisibilityPanel2_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2Collapsed = !splitContainer1.Panel2Collapsed;
            toolStripButton_ToogleVisibilityPanel2.Image = splitContainer1.Panel2Collapsed ? NextGenerationOntoEdit.Properties.Resources.bb_back_ : NextGenerationOntoEdit.Properties.Resources.bb_forward_;
        }

        private void splitContainer1_Panel1_ClientSizeChanged(object sender, EventArgs e)
        {
            
        }

        private void splitContainer1_Panel2_ClientSizeChanged(object sender, EventArgs e)
        {
            toolStripButton_ToogleVisibilityPanel2.Image = splitContainer1.Panel2Collapsed ? NextGenerationOntoEdit.Properties.Resources.bb_back_ : NextGenerationOntoEdit.Properties.Resources.bb_forward_;
        }

        private void toolStripContainer1_ContentPanel_DragEnter(object sender, DragEventArgs e)
        {
            var item = (ViewItem)e.Data.GetData(typeof(ViewItem));
            if (item is ViewItem)
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void toolStripContainer1_ContentPanel_DragOver(object sender, DragEventArgs e)
        {

            var viewItem = (ViewItem)e.Data.GetData(typeof(ViewItem));
            var label = (Label)e.Data.GetData(typeof(Label));
            var point = toolStripContainer1.ContentPanel.PointToClient(new Point(e.X, e.Y));
            var left = point.X;
            var top = point.Y;
            
            toolStripContainer1.ContentPanel.Refresh();

            if (viewItem != null)
            {
                drawVerticalLine(left, top);
                e.Effect = DragDropEffects.Copy;
            }
            else if (label != null)
            {
                drawVerticalLine(left, top);
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
            
        }

        private void drawVerticalLine(int left, int top)
        {
            Control nextControl = null;
            
            foreach (Control control in toolStripContainer1.ContentPanel.Controls)
            {
                if (control.Location.X == left)
                {
                    if (nextControl == null)
                    {
                        nextControl = control;
                    }
                    else
                    {
                        if (Math.Abs(control.Location.Y - top) < Math.Abs(nextControl.Location.Y - top))
                        {
                            nextControl = control;
                        }
                    }
                }
                
            }

            if (nextControl != null && nextControl.Location.X == left)
            {
                var g = toolStripContainer1.ContentPanel.CreateGraphics();
                g.DrawLine(new Pen(Color.Black, 1), left, top, left, nextControl.Location.Y);

                var font = new Font("Arial", 7);
                // Create rectangle for drawing.
                SolidBrush drawBrush = new SolidBrush(Color.Black);

                g.DrawString((top > nextControl.Location.Y ? top - nextControl.Location.Y : nextControl.Location.Y - top).ToString(), font, drawBrush, left + 3, top - 10);
            }
            
        }

        private void toolStripContainer1_ContentPanel_DragDrop(object sender, DragEventArgs e)
        {
            toolStripContainer1.ContentPanel.Refresh();
            var viewItem = (ViewItem)e.Data.GetData(typeof(ViewItem));
            var labelItem = (Label)e.Data.GetData(typeof(Label));
            if (viewItem != null)
            {
                var point = toolStripContainer1.ContentPanel.PointToClient(new Point(e.X, e.Y));
                var left = point.X;
                var top = point.Y;
                if (viewItem.Relation == localConfig.Globals.Type_AttributeType)
                {
                    var label = new Label();
                    label.MouseDown += label_MouseDown;
                    label.AutoSize = true;
                    var textBox = new TextBox();

                    label.Name = "lbl_" + viewItem.IdItem;
                    label.Text = viewItem.NameItem;
                    label.Top = top;
                    label.Left = left;

                    toolStripContainer1.ContentPanel.Controls.Add(label);

                    viewItem.LabelOfItem = label;

                    var centerVert = top + ( label.Height / 2 );

                    
                    textBox.Name = "tb_" + viewItem.IdItem;
                    textBox.Top = centerVert - ( textBox.Height / 2 );
                    textBox.Left = left + label.Width + 5;
                    viewItem.TextBoxOfItem = textBox;
                    
                    toolStripContainer1.ContentPanel.Controls.Add(textBox);

                    viewItemList.Add(viewItem);
                }
                else
                {
                    var label = new Label();
                    label.MouseDown += label_MouseDown;
                    label.AutoSize = true;
                    var comboBox = new ComboBox();
                    label.Name = "lbl_" + viewItem.IdItem;
                    label.Text = viewItem.NameItem;
                    label.Top = top;
                    label.Left = left;

                    toolStripContainer1.ContentPanel.Controls.Add(label);

                    viewItem.LabelOfItem = label;

                    var centerVert = top + (label.Height / 2);

                    comboBox.Name = "cb_" + viewItem.IdItem;
                    comboBox.Top = centerVert - (comboBox.Height / 2);
                    comboBox.Left = left + label.Width + 5;

                    
                    toolStripContainer1.ContentPanel.Controls.Add(comboBox);
                    viewItem.ComboBoxOfItem = comboBox;
                    viewItemList.Add(viewItem);
                }

            }
            else if (labelItem != null)
            {
                var point = toolStripContainer1.ContentPanel.PointToClient(new Point(e.X, e.Y));
                var left = point.X;
                var top = point.Y;

                labelItem.Left = left;
                labelItem.Top = top;
                var centerVert = top + (labelItem.Height / 2);

                var viewItemToMove = viewItemList.Where(viewItm => viewItm.LabelOfItem == labelItem).FirstOrDefault();

                if (viewItemToMove != null)
                {
                    if (viewItemToMove.TextBoxOfItem != null)
                    {
                        viewItemToMove.TextBoxOfItem.Left = left + labelItem.Width + 5;
                        viewItemToMove.TextBoxOfItem.Top = centerVert - (viewItemToMove.TextBoxOfItem.Height / 2);
                    }
                    else
                    {
                        viewItemToMove.ComboBoxOfItem.Left = left + labelItem.Width + 5;
                        viewItemToMove.ComboBoxOfItem.Top = centerVert - (viewItemToMove.ComboBoxOfItem.Height / 2); 
                    }
                }

                
            }
            
        }

        
        private int GetLeftTextBoxes(Label label)
        {
            var result = 0;

            return result;
        }

        private void SetLeftTextBoxes(List<TextBox> textBoxes, int left)
        {
            textBoxes.ForEach(tb => tb.Left = left);
        }

        void label_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                DoDragDrop(sender, DragDropEffects.Move);
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                var label = (Label) sender;
                contextMenuStrip_Labels.Show(label, new System.Drawing.Point(20, 20));
            }

        }

        private void syncTextBoxesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var label = (Label)(contextMenuStrip_Labels.SourceControl);
            if (label != null)
            {
               
                var viewItemsToMove = viewItemList.Where(viewItm => viewItm.LabelOfItem.Left == label.Left).ToList();
                if (viewItemsToMove.Any())
                {
                    var maxLeft = viewItemsToMove.Max(viewItm => viewItm.TextBoxOfItem != null ? viewItm.TextBoxOfItem.Left : viewItm.ComboBoxOfItem.Left);
                    viewItemsToMove.ForEach(viewItm =>
                        {
                            if (viewItm.TextBoxOfItem != null)
                            {
                                viewItm.TextBoxOfItem.Left = maxLeft;
                            }
                            else
                            {
                                viewItm.ComboBoxOfItem.Left = maxLeft;
                            }
                        });
                }
                
            }
        }

        private void changeWidthOfDataitemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            syncTextBoxesToolStripMenuItem_Click(sender, e);
            var label = (Label)(contextMenuStrip_Labels.SourceControl);
            if (label != null)
            {
                var viewItems = viewItemList.Where(viewItem => viewItem.LabelOfItem == label);
                int maxWidth = 0;
                var viewItemsToChange = viewItemList.Where(viewItm => viewItm.LabelOfItem.Left == label.Left).ToList();
                if (viewItemsToChange.Any())
                {
                    maxWidth = viewItemsToChange.Max(viewItm => viewItm.TextBoxOfItem != null ? viewItm.TextBoxOfItem.Width : viewItm.ComboBoxOfItem.Width);
                    viewItemsToChange.ForEach(viewItm =>
                    {
                        if (viewItm.TextBoxOfItem != null)
                        {
                            viewItm.TextBoxOfItem.Width = maxWidth;
                        }
                        else
                        {
                            viewItm.ComboBoxOfItem.Width = maxWidth;
                        }
                    });
                }

                if (maxWidth > 0)
                {
                    dataItemWidthChanger = new DataItemWidthChanger(maxWidth, viewItemsToChange);
                    dataItemWidthChanger.changedWidth += dataItemWidthChanger_changedWidth;
                    dataItemWidthChanger.Show();
                }

            }
        }

        void dataItemWidthChanger_changedWidth()
        {
            var viewItems = dataItemWidthChanger.ViewItems;

            viewItems.ForEach(viewItm =>
                {
                    if (viewItm.TextBoxOfItem != null)
                    {
                        viewItm.TextBoxOfItem.Width = dataItemWidthChanger.WidthOfItems;
                    }
                    else
                    {
                        viewItm.ComboBoxOfItem.Width = dataItemWidthChanger.WidthOfItems;
                    }
                });
        }
    }
}

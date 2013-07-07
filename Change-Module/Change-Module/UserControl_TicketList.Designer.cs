namespace Change_Module
{
    partial class UserControl_TicketList
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl_TicketList));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.bindingNavigator_Tickets = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingSource_Tickets = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_Refresh = new System.Windows.Forms.ToolStripButton();
            this.dataGridView_TicketLists = new System.Windows.Forms.DataGridView();
            this.ContextMenuStrip_Tickets = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.NewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EqualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripTextBox_Equal = new System.Windows.Forms.ToolStripTextBox();
            this.NotEqualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripTextBox_NotEqual = new System.Windows.Forms.ToolStripTextBox();
            this.approximateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripTextBox_approximate = new System.Windows.Forms.ToolStripTextBox();
            this.ContainsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripTextBox_Contains = new System.Windows.Forms.ToolStripTextBox();
            this.ClearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RelateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ApplyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator_Tickets)).BeginInit();
            this.bindingNavigator_Tickets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Tickets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_TicketLists)).BeginInit();
            this.ContextMenuStrip_Tickets.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.bindingNavigator_Tickets);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.dataGridView_TicketLists);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(782, 482);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(782, 507);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            this.toolStripContainer1.TopToolStripPanelVisible = false;
            // 
            // bindingNavigator_Tickets
            // 
            this.bindingNavigator_Tickets.AddNewItem = null;
            this.bindingNavigator_Tickets.BindingSource = this.bindingSource_Tickets;
            this.bindingNavigator_Tickets.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator_Tickets.DeleteItem = null;
            this.bindingNavigator_Tickets.Dock = System.Windows.Forms.DockStyle.None;
            this.bindingNavigator_Tickets.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.toolStripSeparator1,
            this.toolStripButton_Refresh});
            this.bindingNavigator_Tickets.Location = new System.Drawing.Point(3, 0);
            this.bindingNavigator_Tickets.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator_Tickets.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator_Tickets.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator_Tickets.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator_Tickets.Name = "bindingNavigator_Tickets";
            this.bindingNavigator_Tickets.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator_Tickets.Size = new System.Drawing.Size(337, 25);
            this.bindingNavigator_Tickets.TabIndex = 0;
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(44, 22);
            this.bindingNavigatorCountItem.Text = "von {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Die Gesamtanzahl der Elemente.";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Erste verschieben";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Vorherige verschieben";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Aktuelle Position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Nächste verschieben";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Letzte verschieben";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton_Refresh
            // 
            this.toolStripButton_Refresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_Refresh.Enabled = false;
            this.toolStripButton_Refresh.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Refresh.Image")));
            this.toolStripButton_Refresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Refresh.Name = "toolStripButton_Refresh";
            this.toolStripButton_Refresh.Size = new System.Drawing.Size(113, 22);
            this.toolStripButton_Refresh.Text = "x_Refresh-Relations";
            // 
            // dataGridView_TicketLists
            // 
            this.dataGridView_TicketLists.AllowUserToAddRows = false;
            this.dataGridView_TicketLists.AllowUserToDeleteRows = false;
            this.dataGridView_TicketLists.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_TicketLists.ContextMenuStrip = this.ContextMenuStrip_Tickets;
            this.dataGridView_TicketLists.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_TicketLists.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_TicketLists.Name = "dataGridView_TicketLists";
            this.dataGridView_TicketLists.ReadOnly = true;
            this.dataGridView_TicketLists.Size = new System.Drawing.Size(782, 482);
            this.dataGridView_TicketLists.TabIndex = 0;
            this.dataGridView_TicketLists.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView_TicketLists_KeyDown);
            // 
            // ContextMenuStrip_Tickets
            // 
            this.ContextMenuStrip_Tickets.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewToolStripMenuItem,
            this.FilterToolStripMenuItem,
            this.RelateToolStripMenuItem,
            this.OpenToolStripMenuItem,
            this.ApplyToolStripMenuItem});
            this.ContextMenuStrip_Tickets.Name = "ContextMenuStrip_Tickets";
            this.ContextMenuStrip_Tickets.Size = new System.Drawing.Size(116, 114);
            // 
            // NewToolStripMenuItem
            // 
            this.NewToolStripMenuItem.Name = "NewToolStripMenuItem";
            this.NewToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.NewToolStripMenuItem.Text = "x_New";
            this.NewToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripMenuItem_Click);
            // 
            // FilterToolStripMenuItem
            // 
            this.FilterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EqualToolStripMenuItem,
            this.NotEqualToolStripMenuItem,
            this.approximateToolStripMenuItem,
            this.ContainsToolStripMenuItem,
            this.ClearToolStripMenuItem});
            this.FilterToolStripMenuItem.Name = "FilterToolStripMenuItem";
            this.FilterToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.FilterToolStripMenuItem.Text = "x_Filter";
            // 
            // EqualToolStripMenuItem
            // 
            this.EqualToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripTextBox_Equal});
            this.EqualToolStripMenuItem.Name = "EqualToolStripMenuItem";
            this.EqualToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.EqualToolStripMenuItem.Text = "x_equal";
            // 
            // ToolStripTextBox_Equal
            // 
            this.ToolStripTextBox_Equal.Name = "ToolStripTextBox_Equal";
            this.ToolStripTextBox_Equal.Size = new System.Drawing.Size(100, 23);
            // 
            // NotEqualToolStripMenuItem
            // 
            this.NotEqualToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripTextBox_NotEqual});
            this.NotEqualToolStripMenuItem.Name = "NotEqualToolStripMenuItem";
            this.NotEqualToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.NotEqualToolStripMenuItem.Text = "x_not equal";
            // 
            // ToolStripTextBox_NotEqual
            // 
            this.ToolStripTextBox_NotEqual.Name = "ToolStripTextBox_NotEqual";
            this.ToolStripTextBox_NotEqual.Size = new System.Drawing.Size(100, 23);
            // 
            // approximateToolStripMenuItem
            // 
            this.approximateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripTextBox_approximate});
            this.approximateToolStripMenuItem.Name = "approximateToolStripMenuItem";
            this.approximateToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.approximateToolStripMenuItem.Text = "x_approximate";
            // 
            // ToolStripTextBox_approximate
            // 
            this.ToolStripTextBox_approximate.Name = "ToolStripTextBox_approximate";
            this.ToolStripTextBox_approximate.Size = new System.Drawing.Size(100, 23);
            // 
            // ContainsToolStripMenuItem
            // 
            this.ContainsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripTextBox_Contains});
            this.ContainsToolStripMenuItem.Name = "ContainsToolStripMenuItem";
            this.ContainsToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.ContainsToolStripMenuItem.Text = "x_Contains";
            // 
            // ToolStripTextBox_Contains
            // 
            this.ToolStripTextBox_Contains.Name = "ToolStripTextBox_Contains";
            this.ToolStripTextBox_Contains.Size = new System.Drawing.Size(100, 23);
            // 
            // ClearToolStripMenuItem
            // 
            this.ClearToolStripMenuItem.Name = "ClearToolStripMenuItem";
            this.ClearToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.ClearToolStripMenuItem.Text = "Clear";
            // 
            // RelateToolStripMenuItem
            // 
            this.RelateToolStripMenuItem.Enabled = false;
            this.RelateToolStripMenuItem.Name = "RelateToolStripMenuItem";
            this.RelateToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.RelateToolStripMenuItem.Text = "x_relate";
            // 
            // OpenToolStripMenuItem
            // 
            this.OpenToolStripMenuItem.Enabled = false;
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            this.OpenToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.OpenToolStripMenuItem.Text = "x_Open";
            // 
            // ApplyToolStripMenuItem
            // 
            this.ApplyToolStripMenuItem.Enabled = false;
            this.ApplyToolStripMenuItem.Name = "ApplyToolStripMenuItem";
            this.ApplyToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.ApplyToolStripMenuItem.Text = "x_Apply";
            this.ApplyToolStripMenuItem.Visible = false;
            // 
            // UserControl_TicketList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "UserControl_TicketList";
            this.Size = new System.Drawing.Size(782, 507);
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator_Tickets)).EndInit();
            this.bindingNavigator_Tickets.ResumeLayout(false);
            this.bindingNavigator_Tickets.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Tickets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_TicketLists)).EndInit();
            this.ContextMenuStrip_Tickets.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.BindingNavigator bindingNavigator_Tickets;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton_Refresh;
        private System.Windows.Forms.DataGridView dataGridView_TicketLists;
        internal System.Windows.Forms.ContextMenuStrip ContextMenuStrip_Tickets;
        internal System.Windows.Forms.ToolStripMenuItem NewToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem FilterToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem EqualToolStripMenuItem;
        internal System.Windows.Forms.ToolStripTextBox ToolStripTextBox_Equal;
        internal System.Windows.Forms.ToolStripMenuItem NotEqualToolStripMenuItem;
        internal System.Windows.Forms.ToolStripTextBox ToolStripTextBox_NotEqual;
        internal System.Windows.Forms.ToolStripMenuItem approximateToolStripMenuItem;
        internal System.Windows.Forms.ToolStripTextBox ToolStripTextBox_approximate;
        internal System.Windows.Forms.ToolStripMenuItem ContainsToolStripMenuItem;
        internal System.Windows.Forms.ToolStripTextBox ToolStripTextBox_Contains;
        internal System.Windows.Forms.ToolStripMenuItem ClearToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem RelateToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem ApplyToolStripMenuItem;
        private System.Windows.Forms.BindingSource bindingSource_Tickets;
    }
}

namespace Appointment_Module
{
    partial class UserControl_AppointmentData
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dateTimePicker_Ende = new System.Windows.Forms.DateTimePicker();
            this.label_Ende = new System.Windows.Forms.Label();
            this.dateTimePicker_Start = new System.Windows.Forms.DateTimePicker();
            this.label_Start = new System.Windows.Forms.Label();
            this.comboBox_User = new System.Windows.Forms.ComboBox();
            this.label_UserLbl = new System.Windows.Forms.Label();
            this.tabControl_Appointments = new System.Windows.Forms.TabControl();
            this.tabPage_BaseData = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer_Contacts = new System.Windows.Forms.SplitContainer();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripProgressBar_Contacts = new System.Windows.Forms.ToolStripProgressBar();
            this.dataGridView_Contacts = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel_Contractors = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton_AddContractor = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_RemContractor = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel_Contractees = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton_AddContractee = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_RemContractee = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel_Watchers = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton_AddWatcher = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_RemWatcher = new System.Windows.Forms.ToolStripButton();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.toolStripContainer2 = new System.Windows.Forms.ToolStripContainer();
            this.splitContainer_Resource = new System.Windows.Forms.SplitContainer();
            this.dataGridView_Resource = new System.Windows.Forms.DataGridView();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_AddResource = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_AddNamedResource = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_RemResource = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_Address = new System.Windows.Forms.TabPage();
            this.tabPage_Ort = new System.Windows.Forms.TabPage();
            this.tabPage_Raum = new System.Windows.Forms.TabPage();
            this.timer_Contacts = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl_Appointments.SuspendLayout();
            this.tabPage_BaseData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Contacts)).BeginInit();
            this.splitContainer_Contacts.Panel1.SuspendLayout();
            this.splitContainer_Contacts.SuspendLayout();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Contacts)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.toolStripContainer2.ContentPanel.SuspendLayout();
            this.toolStripContainer2.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Resource)).BeginInit();
            this.splitContainer_Resource.Panel1.SuspendLayout();
            this.splitContainer_Resource.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Resource)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tabControl_Appointments, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1001, 495);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dateTimePicker_Ende);
            this.panel1.Controls.Add(this.label_Ende);
            this.panel1.Controls.Add(this.dateTimePicker_Start);
            this.panel1.Controls.Add(this.label_Start);
            this.panel1.Controls.Add(this.comboBox_User);
            this.panel1.Controls.Add(this.label_UserLbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(995, 24);
            this.panel1.TabIndex = 0;
            // 
            // dateTimePicker_Ende
            // 
            this.dateTimePicker_Ende.Location = new System.Drawing.Point(487, 3);
            this.dateTimePicker_Ende.Name = "dateTimePicker_Ende";
            this.dateTimePicker_Ende.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker_Ende.TabIndex = 5;
            // 
            // label_Ende
            // 
            this.label_Ende.AutoSize = true;
            this.label_Ende.Location = new System.Drawing.Point(437, 6);
            this.label_Ende.Name = "label_Ende";
            this.label_Ende.Size = new System.Drawing.Size(43, 13);
            this.label_Ende.TabIndex = 4;
            this.label_Ende.Text = "x_Ende";
            // 
            // dateTimePicker_Start
            // 
            this.dateTimePicker_Start.Location = new System.Drawing.Point(230, 3);
            this.dateTimePicker_Start.Name = "dateTimePicker_Start";
            this.dateTimePicker_Start.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker_Start.TabIndex = 3;
            // 
            // label_Start
            // 
            this.label_Start.AutoSize = true;
            this.label_Start.Location = new System.Drawing.Point(181, 6);
            this.label_Start.Name = "label_Start";
            this.label_Start.Size = new System.Drawing.Size(43, 13);
            this.label_Start.TabIndex = 2;
            this.label_Start.Text = "x_Start:";
            // 
            // comboBox_User
            // 
            this.comboBox_User.FormattingEnabled = true;
            this.comboBox_User.Location = new System.Drawing.Point(53, 2);
            this.comboBox_User.Name = "comboBox_User";
            this.comboBox_User.Size = new System.Drawing.Size(121, 21);
            this.comboBox_User.TabIndex = 1;
            // 
            // label_UserLbl
            // 
            this.label_UserLbl.AutoSize = true;
            this.label_UserLbl.Location = new System.Drawing.Point(4, 5);
            this.label_UserLbl.Name = "label_UserLbl";
            this.label_UserLbl.Size = new System.Drawing.Size(43, 13);
            this.label_UserLbl.TabIndex = 0;
            this.label_UserLbl.Text = "x_User:";
            // 
            // tabControl_Appointments
            // 
            this.tabControl_Appointments.Controls.Add(this.tabPage_BaseData);
            this.tabControl_Appointments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_Appointments.Location = new System.Drawing.Point(3, 33);
            this.tabControl_Appointments.Name = "tabControl_Appointments";
            this.tabControl_Appointments.SelectedIndex = 0;
            this.tabControl_Appointments.Size = new System.Drawing.Size(995, 459);
            this.tabControl_Appointments.TabIndex = 1;
            // 
            // tabPage_BaseData
            // 
            this.tabPage_BaseData.Controls.Add(this.splitContainer1);
            this.tabPage_BaseData.Location = new System.Drawing.Point(4, 22);
            this.tabPage_BaseData.Name = "tabPage_BaseData";
            this.tabPage_BaseData.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_BaseData.Size = new System.Drawing.Size(987, 433);
            this.tabPage_BaseData.TabIndex = 0;
            this.tabPage_BaseData.Text = "x_Data";
            this.tabPage_BaseData.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer_Contacts);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(981, 427);
            this.splitContainer1.SplitterDistance = 211;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer_Contacts
            // 
            this.splitContainer_Contacts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer_Contacts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_Contacts.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_Contacts.Name = "splitContainer_Contacts";
            // 
            // splitContainer_Contacts.Panel1
            // 
            this.splitContainer_Contacts.Panel1.Controls.Add(this.toolStripContainer1);
            this.splitContainer_Contacts.Size = new System.Drawing.Size(981, 211);
            this.splitContainer_Contacts.SplitterDistance = 488;
            this.splitContainer_Contacts.TabIndex = 0;
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.toolStrip3);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.dataGridView_Contacts);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(484, 157);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(484, 207);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // toolStrip3
            // 
            this.toolStrip3.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar_Contacts});
            this.toolStrip3.Location = new System.Drawing.Point(3, 0);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(145, 25);
            this.toolStrip3.TabIndex = 0;
            // 
            // toolStripProgressBar_Contacts
            // 
            this.toolStripProgressBar_Contacts.Maximum = 10;
            this.toolStripProgressBar_Contacts.Name = "toolStripProgressBar_Contacts";
            this.toolStripProgressBar_Contacts.Size = new System.Drawing.Size(100, 22);
            this.toolStripProgressBar_Contacts.Step = 1;
            // 
            // dataGridView_Contacts
            // 
            this.dataGridView_Contacts.AllowUserToAddRows = false;
            this.dataGridView_Contacts.AllowUserToDeleteRows = false;
            this.dataGridView_Contacts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Contacts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Contacts.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_Contacts.Name = "dataGridView_Contacts";
            this.dataGridView_Contacts.ReadOnly = true;
            this.dataGridView_Contacts.Size = new System.Drawing.Size(484, 157);
            this.dataGridView_Contacts.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel_Contractors,
            this.toolStripButton_AddContractor,
            this.toolStripButton_RemContractor,
            this.toolStripSeparator1,
            this.toolStripLabel_Contractees,
            this.toolStripButton_AddContractee,
            this.toolStripButton_RemContractee,
            this.toolStripSeparator2,
            this.toolStripLabel_Watchers,
            this.toolStripButton_AddWatcher,
            this.toolStripButton_RemWatcher});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(387, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // toolStripLabel_Contractors
            // 
            this.toolStripLabel_Contractors.Name = "toolStripLabel_Contractors";
            this.toolStripLabel_Contractors.Size = new System.Drawing.Size(79, 22);
            this.toolStripLabel_Contractors.Text = "x_Contractors";
            // 
            // toolStripButton_AddContractor
            // 
            this.toolStripButton_AddContractor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_AddContractor.Image = global::Appointment_Module.Properties.Resources.pulsante_01_architetto_f_011;
            this.toolStripButton_AddContractor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_AddContractor.Name = "toolStripButton_AddContractor";
            this.toolStripButton_AddContractor.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_AddContractor.Text = "toolStripButton1";
            // 
            // toolStripButton_RemContractor
            // 
            this.toolStripButton_RemContractor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_RemContractor.Image = global::Appointment_Module.Properties.Resources.pulsante_02_architetto_f_01;
            this.toolStripButton_RemContractor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_RemContractor.Name = "toolStripButton_RemContractor";
            this.toolStripButton_RemContractor.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_RemContractor.Text = "toolStripButton1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel_Contractees
            // 
            this.toolStripLabel_Contractees.Name = "toolStripLabel_Contractees";
            this.toolStripLabel_Contractees.Size = new System.Drawing.Size(80, 22);
            this.toolStripLabel_Contractees.Text = "x_Contractees";
            // 
            // toolStripButton_AddContractee
            // 
            this.toolStripButton_AddContractee.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_AddContractee.Image = global::Appointment_Module.Properties.Resources.pulsante_01_architetto_f_011;
            this.toolStripButton_AddContractee.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_AddContractee.Name = "toolStripButton_AddContractee";
            this.toolStripButton_AddContractee.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_AddContractee.Text = "toolStripButton1";
            // 
            // toolStripButton_RemContractee
            // 
            this.toolStripButton_RemContractee.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_RemContractee.Image = global::Appointment_Module.Properties.Resources.pulsante_02_architetto_f_01;
            this.toolStripButton_RemContractee.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_RemContractee.Name = "toolStripButton_RemContractee";
            this.toolStripButton_RemContractee.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_RemContractee.Text = "toolStripButton2";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel_Watchers
            // 
            this.toolStripLabel_Watchers.Name = "toolStripLabel_Watchers";
            this.toolStripLabel_Watchers.Size = new System.Drawing.Size(66, 22);
            this.toolStripLabel_Watchers.Text = "x_Watchers";
            // 
            // toolStripButton_AddWatcher
            // 
            this.toolStripButton_AddWatcher.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_AddWatcher.Image = global::Appointment_Module.Properties.Resources.pulsante_01_architetto_f_011;
            this.toolStripButton_AddWatcher.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_AddWatcher.Name = "toolStripButton_AddWatcher";
            this.toolStripButton_AddWatcher.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_AddWatcher.Text = "toolStripButton1";
            // 
            // toolStripButton_RemWatcher
            // 
            this.toolStripButton_RemWatcher.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_RemWatcher.Image = global::Appointment_Module.Properties.Resources.pulsante_02_architetto_f_01;
            this.toolStripButton_RemWatcher.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_RemWatcher.Name = "toolStripButton_RemWatcher";
            this.toolStripButton_RemWatcher.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_RemWatcher.Text = "toolStripButton2";
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.toolStripContainer2);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer3.Size = new System.Drawing.Size(977, 208);
            this.splitContainer3.SplitterDistance = 624;
            this.splitContainer3.TabIndex = 0;
            // 
            // toolStripContainer2
            // 
            this.toolStripContainer2.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer2.ContentPanel
            // 
            this.toolStripContainer2.ContentPanel.Controls.Add(this.splitContainer_Resource);
            this.toolStripContainer2.ContentPanel.Size = new System.Drawing.Size(624, 183);
            this.toolStripContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer2.LeftToolStripPanelVisible = false;
            this.toolStripContainer2.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer2.Name = "toolStripContainer2";
            this.toolStripContainer2.RightToolStripPanelVisible = false;
            this.toolStripContainer2.Size = new System.Drawing.Size(624, 208);
            this.toolStripContainer2.TabIndex = 0;
            this.toolStripContainer2.Text = "toolStripContainer2";
            // 
            // toolStripContainer2.TopToolStripPanel
            // 
            this.toolStripContainer2.TopToolStripPanel.Controls.Add(this.toolStrip2);
            // 
            // splitContainer_Resource
            // 
            this.splitContainer_Resource.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer_Resource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_Resource.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_Resource.Name = "splitContainer_Resource";
            // 
            // splitContainer_Resource.Panel1
            // 
            this.splitContainer_Resource.Panel1.Controls.Add(this.dataGridView_Resource);
            this.splitContainer_Resource.Size = new System.Drawing.Size(624, 183);
            this.splitContainer_Resource.SplitterDistance = 208;
            this.splitContainer_Resource.TabIndex = 0;
            // 
            // dataGridView_Resource
            // 
            this.dataGridView_Resource.AllowUserToAddRows = false;
            this.dataGridView_Resource.AllowUserToDeleteRows = false;
            this.dataGridView_Resource.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Resource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Resource.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_Resource.Name = "dataGridView_Resource";
            this.dataGridView_Resource.ReadOnly = true;
            this.dataGridView_Resource.Size = new System.Drawing.Size(204, 179);
            this.dataGridView_Resource.TabIndex = 0;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_AddResource,
            this.toolStripSeparator3,
            this.toolStripButton_AddNamedResource,
            this.toolStripButton_RemResource});
            this.toolStrip2.Location = new System.Drawing.Point(3, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(149, 25);
            this.toolStrip2.TabIndex = 0;
            // 
            // toolStripButton_AddResource
            // 
            this.toolStripButton_AddResource.Image = global::Appointment_Module.Properties.Resources.b_plus;
            this.toolStripButton_AddResource.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_AddResource.Name = "toolStripButton_AddResource";
            this.toolStripButton_AddResource.Size = new System.Drawing.Size(85, 22);
            this.toolStripButton_AddResource.Text = "x_Resource";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton_AddNamedResource
            // 
            this.toolStripButton_AddNamedResource.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_AddNamedResource.Image = global::Appointment_Module.Properties.Resources.pulsante_01_architetto_f_011;
            this.toolStripButton_AddNamedResource.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_AddNamedResource.Name = "toolStripButton_AddNamedResource";
            this.toolStripButton_AddNamedResource.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_AddNamedResource.Text = "toolStripButton1";
            // 
            // toolStripButton_RemResource
            // 
            this.toolStripButton_RemResource.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_RemResource.Image = global::Appointment_Module.Properties.Resources.pulsante_02_architetto_f_01;
            this.toolStripButton_RemResource.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_RemResource.Name = "toolStripButton_RemResource";
            this.toolStripButton_RemResource.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_RemResource.Text = "toolStripButton2";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_Address);
            this.tabControl1.Controls.Add(this.tabPage_Ort);
            this.tabControl1.Controls.Add(this.tabPage_Raum);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(349, 208);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage_Address
            // 
            this.tabPage_Address.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Address.Name = "tabPage_Address";
            this.tabPage_Address.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Address.Size = new System.Drawing.Size(341, 182);
            this.tabPage_Address.TabIndex = 0;
            this.tabPage_Address.Text = "x_Adresse";
            this.tabPage_Address.UseVisualStyleBackColor = true;
            // 
            // tabPage_Ort
            // 
            this.tabPage_Ort.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Ort.Name = "tabPage_Ort";
            this.tabPage_Ort.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Ort.Size = new System.Drawing.Size(341, 182);
            this.tabPage_Ort.TabIndex = 1;
            this.tabPage_Ort.Text = "x_Ort";
            this.tabPage_Ort.UseVisualStyleBackColor = true;
            // 
            // tabPage_Raum
            // 
            this.tabPage_Raum.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Raum.Name = "tabPage_Raum";
            this.tabPage_Raum.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Raum.Size = new System.Drawing.Size(341, 182);
            this.tabPage_Raum.TabIndex = 2;
            this.tabPage_Raum.Text = "x_Raum";
            this.tabPage_Raum.UseVisualStyleBackColor = true;
            // 
            // timer_Contacts
            // 
            this.timer_Contacts.Interval = 300;
            this.timer_Contacts.Tick += new System.EventHandler(this.timer_Contacts_Tick);
            // 
            // UserControl_AppointmentData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UserControl_AppointmentData";
            this.Size = new System.Drawing.Size(1001, 495);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl_Appointments.ResumeLayout(false);
            this.tabPage_BaseData.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer_Contacts.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Contacts)).EndInit();
            this.splitContainer_Contacts.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Contacts)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.toolStripContainer2.ContentPanel.ResumeLayout(false);
            this.toolStripContainer2.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer2.TopToolStripPanel.PerformLayout();
            this.toolStripContainer2.ResumeLayout(false);
            this.toolStripContainer2.PerformLayout();
            this.splitContainer_Resource.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Resource)).EndInit();
            this.splitContainer_Resource.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Resource)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_Ende;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Start;
        private System.Windows.Forms.Label label_Start;
        private System.Windows.Forms.ComboBox comboBox_User;
        private System.Windows.Forms.Label label_UserLbl;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Ende;
        private System.Windows.Forms.TabControl tabControl_Appointments;
        private System.Windows.Forms.TabPage tabPage_BaseData;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer_Contacts;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_Contractors;
        private System.Windows.Forms.ToolStripButton toolStripButton_AddContractor;
        private System.Windows.Forms.ToolStripButton toolStripButton_RemContractor;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_Contractees;
        private System.Windows.Forms.DataGridView dataGridView_Contacts;
        private System.Windows.Forms.ToolStripButton toolStripButton_AddContractee;
        private System.Windows.Forms.ToolStripButton toolStripButton_RemContractee;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_Watchers;
        private System.Windows.Forms.ToolStripButton toolStripButton_AddWatcher;
        private System.Windows.Forms.ToolStripButton toolStripButton_RemWatcher;
        private System.Windows.Forms.ToolStripContainer toolStripContainer2;
        private System.Windows.Forms.SplitContainer splitContainer_Resource;
        private System.Windows.Forms.DataGridView dataGridView_Resource;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton_AddResource;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton_AddNamedResource;
        private System.Windows.Forms.ToolStripButton toolStripButton_RemResource;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_Address;
        private System.Windows.Forms.TabPage tabPage_Ort;
        private System.Windows.Forms.TabPage tabPage_Raum;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar_Contacts;
        private System.Windows.Forms.Timer timer_Contacts;

    }
}


namespace game5
{
    partial class MainF
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainF));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ts_menu = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.ts_menu_prename = new System.Windows.Forms.ToolStripTextBox();
            this.ts_menu_but_search = new System.Windows.Forms.ToolStripSplitButton();
            this.ts_menu_but_search_auto_5s = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ts_menu_but_start = new System.Windows.Forms.ToolStripButton();
            this.ts_menu_but_stop = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ts_menu_but_update = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ts_menu_but_install = new System.Windows.Forms.ToolStripSplitButton();
            this.ts_menu_but_install_multiple = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_menu_but_uninstall = new System.Windows.Forms.ToolStripButton();
            this.ss_menu = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ss_menu_status = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv_services = new System.Windows.Forms.DataGridView();
            this.dgv_service_col_chk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgv_service_col_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_service_col_folder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_service_col_status = new System.Windows.Forms.DataGridViewStatusColumn();
            this.dgv_service_col_memory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_service_col_cpu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ts_menu_but_search_auto_1s = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_menu.SuspendLayout();
            this.ss_menu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_services)).BeginInit();
            this.SuspendLayout();
            // 
            // ts_menu
            // 
            this.ts_menu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ts_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.ts_menu_prename,
            this.ts_menu_but_search,
            this.toolStripSeparator1,
            this.ts_menu_but_start,
            this.ts_menu_but_stop,
            this.toolStripSeparator2,
            this.ts_menu_but_update,
            this.toolStripSeparator3,
            this.ts_menu_but_install,
            this.ts_menu_but_uninstall});
            this.ts_menu.Location = new System.Drawing.Point(0, 0);
            this.ts_menu.Name = "ts_menu";
            this.ts_menu.Size = new System.Drawing.Size(892, 25);
            this.ts_menu.TabIndex = 0;
            this.ts_menu.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(64, 22);
            this.toolStripLabel1.Text = "Pre-Name:";
            // 
            // ts_menu_prename
            // 
            this.ts_menu_prename.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ts_menu_prename.Name = "ts_menu_prename";
            this.ts_menu_prename.Size = new System.Drawing.Size(100, 25);
            // 
            // ts_menu_but_search
            // 
            this.ts_menu_but_search.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_menu_but_search_auto_1s,
            this.ts_menu_but_search_auto_5s});
            this.ts_menu_but_search.Image = global::game5.Properties.Resources.Search_16x;
            this.ts_menu_but_search.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_menu_but_search.Name = "ts_menu_but_search";
            this.ts_menu_but_search.Size = new System.Drawing.Size(74, 22);
            this.ts_menu_but_search.Text = "Search";
            this.ts_menu_but_search.Click += new System.EventHandler(this.ts_menu_but_search_Click);
            // 
            // ts_menu_but_search_auto_5s
            // 
            this.ts_menu_but_search_auto_5s.Name = "ts_menu_but_search_auto_5s";
            this.ts_menu_but_search_auto_5s.Size = new System.Drawing.Size(180, 22);
            this.ts_menu_but_search_auto_5s.Text = "Auto 5s";
            this.ts_menu_but_search_auto_5s.Click += new System.EventHandler(this.ts_menu_but_search_auto_5s_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // ts_menu_but_start
            // 
            this.ts_menu_but_start.Image = global::game5.Properties.Resources.Run_16x;
            this.ts_menu_but_start.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_menu_but_start.Name = "ts_menu_but_start";
            this.ts_menu_but_start.Size = new System.Drawing.Size(51, 22);
            this.ts_menu_but_start.Text = "Start";
            this.ts_menu_but_start.Click += new System.EventHandler(this.ts_menu_but_start_Click);
            // 
            // ts_menu_but_stop
            // 
            this.ts_menu_but_stop.Image = ((System.Drawing.Image)(resources.GetObject("ts_menu_but_stop.Image")));
            this.ts_menu_but_stop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_menu_but_stop.Name = "ts_menu_but_stop";
            this.ts_menu_but_stop.Size = new System.Drawing.Size(51, 22);
            this.ts_menu_but_stop.Text = "Stop";
            this.ts_menu_but_stop.Click += new System.EventHandler(this.ts_menu_but_stop_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // ts_menu_but_update
            // 
            this.ts_menu_but_update.Image = global::game5.Properties.Resources.UpdateDatabase_16x;
            this.ts_menu_but_update.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_menu_but_update.Name = "ts_menu_but_update";
            this.ts_menu_but_update.Size = new System.Drawing.Size(65, 22);
            this.ts_menu_but_update.Text = "Update";
            this.ts_menu_but_update.Click += new System.EventHandler(this.ts_menu_but_update_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // ts_menu_but_install
            // 
            this.ts_menu_but_install.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_menu_but_install_multiple});
            this.ts_menu_but_install.Image = global::game5.Properties.Resources.InstallFromSource_16x;
            this.ts_menu_but_install.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_menu_but_install.Name = "ts_menu_but_install";
            this.ts_menu_but_install.Size = new System.Drawing.Size(70, 22);
            this.ts_menu_but_install.Text = "Install";
            this.ts_menu_but_install.ButtonClick += new System.EventHandler(this.ts_menu_but_install_ButtonClick);
            // 
            // ts_menu_but_install_multiple
            // 
            this.ts_menu_but_install_multiple.Name = "ts_menu_but_install_multiple";
            this.ts_menu_but_install_multiple.Size = new System.Drawing.Size(118, 22);
            this.ts_menu_but_install_multiple.Text = "Multiple";
            this.ts_menu_but_install_multiple.Click += new System.EventHandler(this.ts_menu_but_install_multiple_Click);
            // 
            // ts_menu_but_uninstall
            // 
            this.ts_menu_but_uninstall.Image = global::game5.Properties.Resources.UninstallFromSource_16x;
            this.ts_menu_but_uninstall.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_menu_but_uninstall.Name = "ts_menu_but_uninstall";
            this.ts_menu_but_uninstall.Size = new System.Drawing.Size(73, 22);
            this.ts_menu_but_uninstall.Text = "Uninstall";
            this.ts_menu_but_uninstall.Click += new System.EventHandler(this.ts_menu_but_uninstall_Click);
            // 
            // ss_menu
            // 
            this.ss_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.ss_menu_status});
            this.ss_menu.Location = new System.Drawing.Point(0, 541);
            this.ss_menu.Name = "ss_menu";
            this.ss_menu.Size = new System.Drawing.Size(892, 22);
            this.ss_menu.TabIndex = 1;
            this.ss_menu.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ActiveLinkColor = System.Drawing.Color.DarkRed;
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.DarkRed;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(45, 17);
            this.toolStripStatusLabel1.Text = "Status:";
            // 
            // ss_menu_status
            // 
            this.ss_menu_status.Name = "ss_menu_status";
            this.ss_menu_status.Size = new System.Drawing.Size(12, 17);
            this.ss_menu_status.Text = "-";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(8, 516);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(884, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(8, 516);
            this.panel2.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv_services);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(8, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(876, 516);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Services";
            // 
            // dgv_services
            // 
            this.dgv_services.AllowUserToAddRows = false;
            this.dgv_services.AllowUserToDeleteRows = false;
            this.dgv_services.AllowUserToOrderColumns = true;
            this.dgv_services.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_services.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgv_services.ColumnHeadersHeight = 30;
            this.dgv_services.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_services.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgv_service_col_chk,
            this.dgv_service_col_name,
            this.dgv_service_col_folder,
            this.dgv_service_col_status,
            this.dgv_service_col_memory,
            this.dgv_service_col_cpu});
            this.dgv_services.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_services.Location = new System.Drawing.Point(3, 17);
            this.dgv_services.MultiSelect = false;
            this.dgv_services.Name = "dgv_services";
            this.dgv_services.RowHeadersVisible = false;
            this.dgv_services.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgv_services.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgv_services.RowTemplate.Height = 30;
            this.dgv_services.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_services.Size = new System.Drawing.Size(870, 496);
            this.dgv_services.TabIndex = 0;
            // 
            // dgv_service_col_chk
            // 
            this.dgv_service_col_chk.HeaderText = "";
            this.dgv_service_col_chk.MinimumWidth = 30;
            this.dgv_service_col_chk.Name = "dgv_service_col_chk";
            this.dgv_service_col_chk.Width = 30;
            // 
            // dgv_service_col_name
            // 
            this.dgv_service_col_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgv_service_col_name.HeaderText = "Name";
            this.dgv_service_col_name.Name = "dgv_service_col_name";
            this.dgv_service_col_name.ReadOnly = true;
            // 
            // dgv_service_col_folder
            // 
            this.dgv_service_col_folder.HeaderText = "Folder";
            this.dgv_service_col_folder.Name = "dgv_service_col_folder";
            this.dgv_service_col_folder.Visible = false;
            // 
            // dgv_service_col_status
            // 
            this.dgv_service_col_status.HeaderText = "Status";
            this.dgv_service_col_status.MinimumWidth = 150;
            this.dgv_service_col_status.Name = "dgv_service_col_status";
            this.dgv_service_col_status.ReadOnly = true;
            this.dgv_service_col_status.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_service_col_status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgv_service_col_status.Width = 150;
            // 
            // dgv_service_col_memory
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgv_service_col_memory.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgv_service_col_memory.HeaderText = "Memory";
            this.dgv_service_col_memory.MinimumWidth = 100;
            this.dgv_service_col_memory.Name = "dgv_service_col_memory";
            this.dgv_service_col_memory.ReadOnly = true;
            // 
            // dgv_service_col_cpu
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgv_service_col_cpu.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgv_service_col_cpu.HeaderText = "CPU";
            this.dgv_service_col_cpu.MinimumWidth = 100;
            this.dgv_service_col_cpu.Name = "dgv_service_col_cpu";
            // 
            // ts_menu_but_search_auto_1s
            // 
            this.ts_menu_but_search_auto_1s.Name = "ts_menu_but_search_auto_1s";
            this.ts_menu_but_search_auto_1s.Size = new System.Drawing.Size(180, 22);
            this.ts_menu_but_search_auto_1s.Text = "Auto 1s";
            this.ts_menu_but_search_auto_1s.Click += new System.EventHandler(this.ts_menu_but_search_auto_1s_Click);
            // 
            // MainF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 563);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ss_menu);
            this.Controls.Add(this.ts_menu);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MainF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Windows Services Controller";
            this.ts_menu.ResumeLayout(false);
            this.ts_menu.PerformLayout();
            this.ss_menu.ResumeLayout(false);
            this.ss_menu.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_services)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip ts_menu;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox ts_menu_prename;
        private System.Windows.Forms.StatusStrip ss_menu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgv_services;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton ts_menu_but_start;
        private System.Windows.Forms.ToolStripButton ts_menu_but_stop;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel ss_menu_status;
        private System.Windows.Forms.ToolStripSplitButton ts_menu_but_search;
        private System.Windows.Forms.ToolStripMenuItem ts_menu_but_search_auto_5s;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton ts_menu_but_update;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton ts_menu_but_uninstall;
        private System.Windows.Forms.ToolStripSplitButton ts_menu_but_install;
        private System.Windows.Forms.ToolStripMenuItem ts_menu_but_install_multiple;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgv_service_col_chk;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_service_col_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_service_col_folder;
        private System.Windows.Forms.DataGridViewStatusColumn dgv_service_col_status;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_service_col_memory;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_service_col_cpu;
        private System.Windows.Forms.ToolStripMenuItem ts_menu_but_search_auto_1s;
    }
}


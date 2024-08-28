
namespace game9
{
    partial class DataBindingF
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataBindingF));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.grp_summary = new System.Windows.Forms.GroupBox();
            this.dgv_summary = new System.Windows.Forms.DataGridView();
            this.dgv_summary_col_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_summary_col_modulename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_summary_col_totalrecords = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_summary_col_viewchart = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ts_menu = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.ts_menu_txt_filepath = new System.Windows.Forms.ToolStripTextBox();
            this.ts_menu_but_browsefilepath = new System.Windows.Forms.ToolStripButton();
            this.ts_menu_view = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ts_menu_viewallcharts = new System.Windows.Forms.ToolStripButton();
            this.tabc_main = new System.Windows.Forms.TabControl();
            this.tab_auto = new System.Windows.Forms.TabPage();
            this.lab_manual = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv_raw = new System.Windows.Forms.DataGridView();
            this.sp_raw = new System.Windows.Forms.SplitContainer();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.grp_summary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_summary)).BeginInit();
            this.ts_menu.SuspendLayout();
            this.tabc_main.SuspendLayout();
            this.tab_auto.SuspendLayout();
            this.lab_manual.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_raw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp_raw)).BeginInit();
            this.sp_raw.Panel1.SuspendLayout();
            this.sp_raw.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(994, 40);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "DATA BINDING";
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 533);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(984, 40);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(10, 533);
            this.panel3.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(10, 563);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(974, 10);
            this.panel4.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.tabc_main);
            this.panel5.Controls.Add(this.ts_menu);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(10, 40);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(974, 523);
            this.panel5.TabIndex = 4;
            // 
            // grp_summary
            // 
            this.grp_summary.Controls.Add(this.dgv_summary);
            this.grp_summary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp_summary.Location = new System.Drawing.Point(3, 3);
            this.grp_summary.Name = "grp_summary";
            this.grp_summary.Size = new System.Drawing.Size(960, 464);
            this.grp_summary.TabIndex = 1;
            this.grp_summary.TabStop = false;
            // 
            // dgv_summary
            // 
            this.dgv_summary.AllowUserToAddRows = false;
            this.dgv_summary.AllowUserToDeleteRows = false;
            this.dgv_summary.AllowUserToResizeColumns = false;
            this.dgv_summary.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_summary.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_summary.ColumnHeadersHeight = 30;
            this.dgv_summary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_summary.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgv_summary_col_no,
            this.dgv_summary_col_modulename,
            this.dgv_summary_col_totalrecords,
            this.dgv_summary_col_viewchart});
            this.dgv_summary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_summary.Location = new System.Drawing.Point(3, 17);
            this.dgv_summary.Name = "dgv_summary";
            this.dgv_summary.RowHeadersVisible = false;
            this.dgv_summary.RowTemplate.Height = 30;
            this.dgv_summary.Size = new System.Drawing.Size(954, 444);
            this.dgv_summary.TabIndex = 0;
            // 
            // dgv_summary_col_no
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgv_summary_col_no.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_summary_col_no.HeaderText = "No.";
            this.dgv_summary_col_no.MinimumWidth = 50;
            this.dgv_summary_col_no.Name = "dgv_summary_col_no";
            this.dgv_summary_col_no.Width = 50;
            // 
            // dgv_summary_col_modulename
            // 
            this.dgv_summary_col_modulename.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgv_summary_col_modulename.HeaderText = "Module Name";
            this.dgv_summary_col_modulename.Name = "dgv_summary_col_modulename";
            // 
            // dgv_summary_col_totalrecords
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgv_summary_col_totalrecords.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_summary_col_totalrecords.HeaderText = "Total Records";
            this.dgv_summary_col_totalrecords.MinimumWidth = 200;
            this.dgv_summary_col_totalrecords.Name = "dgv_summary_col_totalrecords";
            this.dgv_summary_col_totalrecords.Width = 200;
            // 
            // dgv_summary_col_viewchart
            // 
            this.dgv_summary_col_viewchart.HeaderText = "Chart";
            this.dgv_summary_col_viewchart.MinimumWidth = 200;
            this.dgv_summary_col_viewchart.Name = "dgv_summary_col_viewchart";
            this.dgv_summary_col_viewchart.Width = 200;
            // 
            // ts_menu
            // 
            this.ts_menu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ts_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.ts_menu_txt_filepath,
            this.ts_menu_but_browsefilepath,
            this.ts_menu_view,
            this.toolStripSeparator1,
            this.ts_menu_viewallcharts});
            this.ts_menu.Location = new System.Drawing.Point(0, 0);
            this.ts_menu.Name = "ts_menu";
            this.ts_menu.Size = new System.Drawing.Size(974, 25);
            this.ts_menu.TabIndex = 0;
            this.ts_menu.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(55, 22);
            this.toolStripLabel1.Text = "File Path:";
            // 
            // ts_menu_txt_filepath
            // 
            this.ts_menu_txt_filepath.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ts_menu_txt_filepath.Name = "ts_menu_txt_filepath";
            this.ts_menu_txt_filepath.Size = new System.Drawing.Size(300, 25);
            // 
            // ts_menu_but_browsefilepath
            // 
            this.ts_menu_but_browsefilepath.Image = global::game9.Properties.Resources.BrowseData_16x;
            this.ts_menu_but_browsefilepath.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_menu_but_browsefilepath.Name = "ts_menu_but_browsefilepath";
            this.ts_menu_but_browsefilepath.Size = new System.Drawing.Size(65, 22);
            this.ts_menu_but_browsefilepath.Text = "Browse";
            this.ts_menu_but_browsefilepath.Click += new System.EventHandler(this.ts_menu_but_browsefilepath_Click);
            // 
            // ts_menu_view
            // 
            this.ts_menu_view.Image = global::game9.Properties.Resources.View_16x;
            this.ts_menu_view.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_menu_view.Name = "ts_menu_view";
            this.ts_menu_view.Size = new System.Drawing.Size(52, 22);
            this.ts_menu_view.Text = "View";
            this.ts_menu_view.Click += new System.EventHandler(this.ts_menu_view_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // ts_menu_viewallcharts
            // 
            this.ts_menu_viewallcharts.Image = global::game9.Properties.Resources.ViewFull_16x;
            this.ts_menu_viewallcharts.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_menu_viewallcharts.Name = "ts_menu_viewallcharts";
            this.ts_menu_viewallcharts.Size = new System.Drawing.Size(106, 22);
            this.ts_menu_viewallcharts.Text = "View All Charts";
            this.ts_menu_viewallcharts.Click += new System.EventHandler(this.ts_menu_viewallcharts_Click);
            // 
            // tabc_main
            // 
            this.tabc_main.Controls.Add(this.tab_auto);
            this.tabc_main.Controls.Add(this.lab_manual);
            this.tabc_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabc_main.Location = new System.Drawing.Point(0, 25);
            this.tabc_main.Name = "tabc_main";
            this.tabc_main.SelectedIndex = 0;
            this.tabc_main.Size = new System.Drawing.Size(974, 498);
            this.tabc_main.TabIndex = 2;
            // 
            // tab_auto
            // 
            this.tab_auto.Controls.Add(this.grp_summary);
            this.tab_auto.Location = new System.Drawing.Point(4, 24);
            this.tab_auto.Name = "tab_auto";
            this.tab_auto.Padding = new System.Windows.Forms.Padding(3);
            this.tab_auto.Size = new System.Drawing.Size(966, 470);
            this.tab_auto.TabIndex = 0;
            this.tab_auto.Text = "Automatic";
            this.tab_auto.UseVisualStyleBackColor = true;
            // 
            // lab_manual
            // 
            this.lab_manual.Controls.Add(this.sp_raw);
            this.lab_manual.Location = new System.Drawing.Point(4, 24);
            this.lab_manual.Name = "lab_manual";
            this.lab_manual.Padding = new System.Windows.Forms.Padding(3);
            this.lab_manual.Size = new System.Drawing.Size(966, 470);
            this.lab_manual.TabIndex = 1;
            this.lab_manual.Text = "Manual";
            this.lab_manual.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv_raw);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(960, 232);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "RAW - Data";
            // 
            // dgv_raw
            // 
            this.dgv_raw.AllowUserToAddRows = false;
            this.dgv_raw.AllowUserToDeleteRows = false;
            this.dgv_raw.AllowUserToResizeColumns = false;
            this.dgv_raw.AllowUserToResizeRows = false;
            this.dgv_raw.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_raw.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_raw.ColumnHeadersHeight = 30;
            this.dgv_raw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_raw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_raw.Location = new System.Drawing.Point(3, 17);
            this.dgv_raw.Name = "dgv_raw";
            this.dgv_raw.RowHeadersVisible = false;
            this.dgv_raw.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_raw.RowTemplate.Height = 40;
            this.dgv_raw.Size = new System.Drawing.Size(954, 212);
            this.dgv_raw.TabIndex = 0;
            // 
            // sp_raw
            // 
            this.sp_raw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sp_raw.Location = new System.Drawing.Point(3, 3);
            this.sp_raw.Name = "sp_raw";
            this.sp_raw.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // sp_raw.Panel1
            // 
            this.sp_raw.Panel1.Controls.Add(this.groupBox1);
            this.sp_raw.Size = new System.Drawing.Size(960, 464);
            this.sp_raw.SplitterDistance = 232;
            this.sp_raw.TabIndex = 1;
            // 
            // DataBindingF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 573);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DataBindingF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data Binding";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.grp_summary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_summary)).EndInit();
            this.ts_menu.ResumeLayout(false);
            this.ts_menu.PerformLayout();
            this.tabc_main.ResumeLayout(false);
            this.tab_auto.ResumeLayout(false);
            this.lab_manual.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_raw)).EndInit();
            this.sp_raw.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sp_raw)).EndInit();
            this.sp_raw.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ToolStrip ts_menu;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox ts_menu_txt_filepath;
        private System.Windows.Forms.ToolStripButton ts_menu_but_browsefilepath;
        private System.Windows.Forms.ToolStripButton ts_menu_view;
        private System.Windows.Forms.GroupBox grp_summary;
        private System.Windows.Forms.DataGridView dgv_summary;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_summary_col_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_summary_col_modulename;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_summary_col_totalrecords;
        private System.Windows.Forms.DataGridViewButtonColumn dgv_summary_col_viewchart;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton ts_menu_viewallcharts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabc_main;
        private System.Windows.Forms.TabPage tab_auto;
        private System.Windows.Forms.TabPage lab_manual;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgv_raw;
        private System.Windows.Forms.SplitContainer sp_raw;
    }
}
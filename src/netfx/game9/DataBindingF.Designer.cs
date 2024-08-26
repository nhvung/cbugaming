
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataBindingF));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.ts_menu = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.ts_menu_txt_filepath = new System.Windows.Forms.ToolStripTextBox();
            this.ts_menu_but_browsefilepath = new System.Windows.Forms.ToolStripButton();
            this.ts_menu_view = new System.Windows.Forms.ToolStripButton();
            this.grp_summary = new System.Windows.Forms.GroupBox();
            this.dgv_summary = new System.Windows.Forms.DataGridView();
            this.dgv_summary_col_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_summary_col_modulename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_summary_col_totalrecords = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_summary_col_viewchart = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel5.SuspendLayout();
            this.ts_menu.SuspendLayout();
            this.grp_summary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_summary)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(994, 40);
            this.panel1.TabIndex = 0;
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
            this.panel5.Controls.Add(this.grp_summary);
            this.panel5.Controls.Add(this.ts_menu);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(10, 40);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(974, 523);
            this.panel5.TabIndex = 4;
            // 
            // ts_menu
            // 
            this.ts_menu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ts_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.ts_menu_txt_filepath,
            this.ts_menu_but_browsefilepath,
            this.ts_menu_view});
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
            this.ts_menu_but_browsefilepath.Image = ((System.Drawing.Image)(resources.GetObject("ts_menu_but_browsefilepath.Image")));
            this.ts_menu_but_browsefilepath.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_menu_but_browsefilepath.Name = "ts_menu_but_browsefilepath";
            this.ts_menu_but_browsefilepath.Size = new System.Drawing.Size(65, 22);
            this.ts_menu_but_browsefilepath.Text = "Browse";
            this.ts_menu_but_browsefilepath.Click += new System.EventHandler(this.ts_menu_but_browsefilepath_Click);
            // 
            // ts_menu_view
            // 
            this.ts_menu_view.Image = ((System.Drawing.Image)(resources.GetObject("ts_menu_view.Image")));
            this.ts_menu_view.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_menu_view.Name = "ts_menu_view";
            this.ts_menu_view.Size = new System.Drawing.Size(52, 22);
            this.ts_menu_view.Text = "View";
            this.ts_menu_view.Click += new System.EventHandler(this.ts_menu_view_Click);
            // 
            // grp_summary
            // 
            this.grp_summary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grp_summary.Controls.Add(this.dgv_summary);
            this.grp_summary.Location = new System.Drawing.Point(6, 28);
            this.grp_summary.Name = "grp_summary";
            this.grp_summary.Size = new System.Drawing.Size(962, 489);
            this.grp_summary.TabIndex = 1;
            this.grp_summary.TabStop = false;
            this.grp_summary.Text = "Summary";
            // 
            // dgv_summary
            // 
            this.dgv_summary.AllowUserToAddRows = false;
            this.dgv_summary.AllowUserToDeleteRows = false;
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
            this.dgv_summary.Size = new System.Drawing.Size(956, 469);
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
            this.Name = "DataBindingF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DataBindingF";
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ts_menu.ResumeLayout(false);
            this.ts_menu.PerformLayout();
            this.grp_summary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_summary)).EndInit();
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
    }
}
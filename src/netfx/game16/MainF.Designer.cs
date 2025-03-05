
namespace game16
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txt_srcfolderpath = new System.Windows.Forms.TextBox();
            this.ts_menu = new System.Windows.Forms.ToolStrip();
            this.ts_menu_but_reloadconfig = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.but_srcfolderpathbrowse = new System.Windows.Forms.Button();
            this.but_clonefolderpathbrowse = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_clonefolderpath = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv_clone = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_clonenameformat = new System.Windows.Forms.TextBox();
            this.but_clone = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_numberofclone = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_defaultexefilename = new System.Windows.Forms.TextBox();
            this.but_runall = new System.Windows.Forms.Button();
            this.but_killall = new System.Windows.Forms.Button();
            this.dgv_clone_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_clone_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_clone_path = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_clone_executefile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_clone_run = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rtxt_logs = new System.Windows.Forms.RichTextBox();
            this.but_removeallclones = new System.Windows.Forms.Button();
            this.but_clearlog = new System.Windows.Forms.Button();
            this.ts_menu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_clone)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_srcfolderpath
            // 
            this.txt_srcfolderpath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_srcfolderpath.Location = new System.Drawing.Point(290, 39);
            this.txt_srcfolderpath.Name = "txt_srcfolderpath";
            this.txt_srcfolderpath.Size = new System.Drawing.Size(394, 21);
            this.txt_srcfolderpath.TabIndex = 0;
            // 
            // ts_menu
            // 
            this.ts_menu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ts_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_menu_but_reloadconfig});
            this.ts_menu.Location = new System.Drawing.Point(0, 0);
            this.ts_menu.Name = "ts_menu";
            this.ts_menu.Size = new System.Drawing.Size(927, 25);
            this.ts_menu.TabIndex = 1;
            this.ts_menu.Text = "toolStrip1";
            // 
            // ts_menu_but_reloadconfig
            // 
            this.ts_menu_but_reloadconfig.Image = ((System.Drawing.Image)(resources.GetObject("ts_menu_but_reloadconfig.Image")));
            this.ts_menu_but_reloadconfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_menu_but_reloadconfig.Name = "ts_menu_but_reloadconfig";
            this.ts_menu_but_reloadconfig.Size = new System.Drawing.Size(107, 22);
            this.ts_menu_but_reloadconfig.Text = "Reload Configs";
            this.ts_menu_but_reloadconfig.Click += new System.EventHandler(this.ts_menu_but_reloadconfig_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(129, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Source Folder Path:";
            // 
            // but_srcfolderpathbrowse
            // 
            this.but_srcfolderpathbrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.but_srcfolderpathbrowse.Location = new System.Drawing.Point(690, 38);
            this.but_srcfolderpathbrowse.Name = "but_srcfolderpathbrowse";
            this.but_srcfolderpathbrowse.Size = new System.Drawing.Size(75, 23);
            this.but_srcfolderpathbrowse.TabIndex = 3;
            this.but_srcfolderpathbrowse.Text = "...";
            this.but_srcfolderpathbrowse.UseVisualStyleBackColor = true;
            this.but_srcfolderpathbrowse.Click += new System.EventHandler(this.but_srcfolderpathbrowse_Click);
            // 
            // but_clonefolderpathbrowse
            // 
            this.but_clonefolderpathbrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.but_clonefolderpathbrowse.Location = new System.Drawing.Point(690, 65);
            this.but_clonefolderpathbrowse.Name = "but_clonefolderpathbrowse";
            this.but_clonefolderpathbrowse.Size = new System.Drawing.Size(75, 23);
            this.but_clonefolderpathbrowse.TabIndex = 6;
            this.but_clonefolderpathbrowse.Text = "...";
            this.but_clonefolderpathbrowse.UseVisualStyleBackColor = true;
            this.but_clonefolderpathbrowse.Click += new System.EventHandler(this.but_clonefolderpathbrowse_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(129, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Clone Folder Path:";
            // 
            // txt_clonefolderpath
            // 
            this.txt_clonefolderpath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_clonefolderpath.Location = new System.Drawing.Point(290, 66);
            this.txt_clonefolderpath.Name = "txt_clonefolderpath";
            this.txt_clonefolderpath.Size = new System.Drawing.Size(394, 21);
            this.txt_clonefolderpath.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dgv_clone);
            this.groupBox1.Location = new System.Drawing.Point(12, 173);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(903, 222);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Items";
            // 
            // dgv_clone
            // 
            this.dgv_clone.AllowUserToAddRows = false;
            this.dgv_clone.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_clone.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_clone.ColumnHeadersHeight = 30;
            this.dgv_clone.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_clone.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgv_clone_no,
            this.dgv_clone_name,
            this.dgv_clone_path,
            this.dgv_clone_executefile,
            this.dgv_clone_run});
            this.dgv_clone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_clone.Location = new System.Drawing.Point(3, 17);
            this.dgv_clone.Name = "dgv_clone";
            this.dgv_clone.RowHeadersVisible = false;
            this.dgv_clone.RowTemplate.Height = 30;
            this.dgv_clone.Size = new System.Drawing.Size(897, 202);
            this.dgv_clone.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(129, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Clone Name Format:";
            // 
            // txt_clonenameformat
            // 
            this.txt_clonenameformat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_clonenameformat.Location = new System.Drawing.Point(290, 93);
            this.txt_clonenameformat.Name = "txt_clonenameformat";
            this.txt_clonenameformat.Size = new System.Drawing.Size(209, 21);
            this.txt_clonenameformat.TabIndex = 8;
            this.txt_clonenameformat.Text = "{0}_Staging{1:00}";
            // 
            // but_clone
            // 
            this.but_clone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.but_clone.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.but_clone.Location = new System.Drawing.Point(690, 92);
            this.but_clone.Name = "but_clone";
            this.but_clone.Size = new System.Drawing.Size(75, 23);
            this.but_clone.TabIndex = 10;
            this.but_clone.Text = "Clone";
            this.but_clone.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.but_clone.UseVisualStyleBackColor = true;
            this.but_clone.Click += new System.EventHandler(this.but_clone_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(515, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "# of clone:";
            // 
            // txt_numberofclone
            // 
            this.txt_numberofclone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_numberofclone.Location = new System.Drawing.Point(584, 93);
            this.txt_numberofclone.Name = "txt_numberofclone";
            this.txt_numberofclone.Size = new System.Drawing.Size(100, 21);
            this.txt_numberofclone.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(129, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(155, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "Default Execute File Name:";
            // 
            // txt_defaultexefilename
            // 
            this.txt_defaultexefilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_defaultexefilename.Location = new System.Drawing.Point(290, 120);
            this.txt_defaultexefilename.Name = "txt_defaultexefilename";
            this.txt_defaultexefilename.Size = new System.Drawing.Size(394, 21);
            this.txt_defaultexefilename.TabIndex = 14;
            // 
            // but_runall
            // 
            this.but_runall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.but_runall.Location = new System.Drawing.Point(686, 412);
            this.but_runall.Name = "but_runall";
            this.but_runall.Size = new System.Drawing.Size(110, 23);
            this.but_runall.TabIndex = 15;
            this.but_runall.Text = "Run them all";
            this.but_runall.UseVisualStyleBackColor = true;
            this.but_runall.Click += new System.EventHandler(this.but_runall_Click);
            // 
            // but_killall
            // 
            this.but_killall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.but_killall.Location = new System.Drawing.Point(802, 412);
            this.but_killall.Name = "but_killall";
            this.but_killall.Size = new System.Drawing.Size(110, 23);
            this.but_killall.TabIndex = 16;
            this.but_killall.Text = "Kill them all";
            this.but_killall.UseVisualStyleBackColor = true;
            this.but_killall.Click += new System.EventHandler(this.but_killall_Click);
            // 
            // dgv_clone_no
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgv_clone_no.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_clone_no.HeaderText = "No.";
            this.dgv_clone_no.Name = "dgv_clone_no";
            this.dgv_clone_no.ReadOnly = true;
            this.dgv_clone_no.Width = 50;
            // 
            // dgv_clone_name
            // 
            this.dgv_clone_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgv_clone_name.HeaderText = "Name";
            this.dgv_clone_name.Name = "dgv_clone_name";
            this.dgv_clone_name.ReadOnly = true;
            // 
            // dgv_clone_path
            // 
            this.dgv_clone_path.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgv_clone_path.HeaderText = "Path";
            this.dgv_clone_path.Name = "dgv_clone_path";
            this.dgv_clone_path.ReadOnly = true;
            this.dgv_clone_path.Visible = false;
            // 
            // dgv_clone_executefile
            // 
            this.dgv_clone_executefile.HeaderText = "EXE File";
            this.dgv_clone_executefile.MinimumWidth = 150;
            this.dgv_clone_executefile.Name = "dgv_clone_executefile";
            this.dgv_clone_executefile.Visible = false;
            this.dgv_clone_executefile.Width = 150;
            // 
            // dgv_clone_run
            // 
            this.dgv_clone_run.HeaderText = "";
            this.dgv_clone_run.Name = "dgv_clone_run";
            this.dgv_clone_run.Width = 80;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.rtxt_logs);
            this.groupBox2.Location = new System.Drawing.Point(15, 461);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(900, 176);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Logs";
            // 
            // rtxt_logs
            // 
            this.rtxt_logs.BackColor = System.Drawing.Color.Black;
            this.rtxt_logs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxt_logs.ForeColor = System.Drawing.Color.White;
            this.rtxt_logs.Location = new System.Drawing.Point(3, 17);
            this.rtxt_logs.Name = "rtxt_logs";
            this.rtxt_logs.ReadOnly = true;
            this.rtxt_logs.Size = new System.Drawing.Size(894, 156);
            this.rtxt_logs.TabIndex = 0;
            this.rtxt_logs.Text = "";
            // 
            // but_removeallclones
            // 
            this.but_removeallclones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.but_removeallclones.Location = new System.Drawing.Point(15, 412);
            this.but_removeallclones.Name = "but_removeallclones";
            this.but_removeallclones.Size = new System.Drawing.Size(110, 23);
            this.but_removeallclones.TabIndex = 18;
            this.but_removeallclones.Text = "Remove all clones";
            this.but_removeallclones.UseVisualStyleBackColor = true;
            this.but_removeallclones.Click += new System.EventHandler(this.but_removeallclones_Click);
            // 
            // but_clearlog
            // 
            this.but_clearlog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.but_clearlog.Location = new System.Drawing.Point(15, 649);
            this.but_clearlog.Name = "but_clearlog";
            this.but_clearlog.Size = new System.Drawing.Size(110, 23);
            this.but_clearlog.TabIndex = 19;
            this.but_clearlog.Text = "Clear log";
            this.but_clearlog.UseVisualStyleBackColor = true;
            this.but_clearlog.Click += new System.EventHandler(this.but_clearlog_Click);
            // 
            // MainF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 684);
            this.Controls.Add(this.but_clearlog);
            this.Controls.Add(this.but_removeallclones);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.but_killall);
            this.Controls.Add(this.but_runall);
            this.Controls.Add(this.txt_defaultexefilename);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_numberofclone);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.but_clone);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_clonenameformat);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.but_clonefolderpathbrowse);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_clonefolderpath);
            this.Controls.Add(this.but_srcfolderpathbrowse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ts_menu);
            this.Controls.Add(this.txt_srcfolderpath);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game 16 - Clone";
            this.ts_menu.ResumeLayout(false);
            this.ts_menu.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_clone)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_srcfolderpath;
        private System.Windows.Forms.ToolStrip ts_menu;
        private System.Windows.Forms.ToolStripButton ts_menu_but_reloadconfig;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button but_srcfolderpathbrowse;
        private System.Windows.Forms.Button but_clonefolderpathbrowse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_clonefolderpath;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_clonenameformat;
        private System.Windows.Forms.Button but_clone;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_numberofclone;
        private System.Windows.Forms.DataGridView dgv_clone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_defaultexefilename;
        private System.Windows.Forms.Button but_runall;
        private System.Windows.Forms.Button but_killall;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_clone_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_clone_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_clone_path;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_clone_executefile;
        private System.Windows.Forms.DataGridViewButtonColumn dgv_clone_run;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox rtxt_logs;
        private System.Windows.Forms.Button but_removeallclones;
        private System.Windows.Forms.Button but_clearlog;
    }
}


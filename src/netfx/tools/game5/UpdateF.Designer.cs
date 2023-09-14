
namespace game5
{
    partial class UpdateF
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateF));
            this.but_srcfolderpathbrowse = new System.Windows.Forms.Button();
            this.txt_srcfolderpath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.but_close = new System.Windows.Forms.Button();
            this.but_update = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv_service = new System.Windows.Forms.DataGridView();
            this.dgv_service_col_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_service_col_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_service_col_folder_path = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_service_col_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_service)).BeginInit();
            this.SuspendLayout();
            // 
            // but_srcfolderpathbrowse
            // 
            this.but_srcfolderpathbrowse.Location = new System.Drawing.Point(822, 26);
            this.but_srcfolderpathbrowse.Name = "but_srcfolderpathbrowse";
            this.but_srcfolderpathbrowse.Size = new System.Drawing.Size(36, 23);
            this.but_srcfolderpathbrowse.TabIndex = 5;
            this.but_srcfolderpathbrowse.Text = "...";
            this.but_srcfolderpathbrowse.UseVisualStyleBackColor = true;
            this.but_srcfolderpathbrowse.Click += new System.EventHandler(this.but_srcfolderpathbrowse_Click);
            // 
            // txt_srcfolderpath
            // 
            this.txt_srcfolderpath.Location = new System.Drawing.Point(12, 27);
            this.txt_srcfolderpath.Name = "txt_srcfolderpath";
            this.txt_srcfolderpath.Size = new System.Drawing.Size(804, 21);
            this.txt_srcfolderpath.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Build Folder Path:";
            // 
            // but_close
            // 
            this.but_close.Location = new System.Drawing.Point(759, 526);
            this.but_close.Name = "but_close";
            this.but_close.Size = new System.Drawing.Size(99, 27);
            this.but_close.TabIndex = 24;
            this.but_close.Text = "Close";
            this.but_close.UseVisualStyleBackColor = true;
            this.but_close.Click += new System.EventHandler(this.but_close_Click);
            // 
            // but_update
            // 
            this.but_update.Location = new System.Drawing.Point(654, 526);
            this.but_update.Name = "but_update";
            this.but_update.Size = new System.Drawing.Size(99, 27);
            this.but_update.TabIndex = 23;
            this.but_update.Text = "Update";
            this.but_update.UseVisualStyleBackColor = true;
            this.but_update.Click += new System.EventHandler(this.but_update_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv_service);
            this.groupBox1.Location = new System.Drawing.Point(15, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(843, 438);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Services";
            // 
            // dgv_service
            // 
            this.dgv_service.AllowUserToAddRows = false;
            this.dgv_service.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_service.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgv_service.ColumnHeadersHeight = 30;
            this.dgv_service.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_service.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgv_service_col_no,
            this.dgv_service_col_name,
            this.dgv_service_col_folder_path,
            this.dgv_service_col_status});
            this.dgv_service.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_service.Location = new System.Drawing.Point(3, 17);
            this.dgv_service.Name = "dgv_service";
            this.dgv_service.RowHeadersVisible = false;
            this.dgv_service.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgv_service.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgv_service.RowTemplate.Height = 30;
            this.dgv_service.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_service.Size = new System.Drawing.Size(837, 418);
            this.dgv_service.TabIndex = 0;
            // 
            // dgv_service_col_no
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgv_service_col_no.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgv_service_col_no.HeaderText = "No.";
            this.dgv_service_col_no.MinimumWidth = 50;
            this.dgv_service_col_no.Name = "dgv_service_col_no";
            this.dgv_service_col_no.ReadOnly = true;
            this.dgv_service_col_no.Width = 50;
            // 
            // dgv_service_col_name
            // 
            this.dgv_service_col_name.HeaderText = "Name";
            this.dgv_service_col_name.MinimumWidth = 250;
            this.dgv_service_col_name.Name = "dgv_service_col_name";
            this.dgv_service_col_name.ReadOnly = true;
            this.dgv_service_col_name.Width = 250;
            // 
            // dgv_service_col_folder_path
            // 
            this.dgv_service_col_folder_path.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgv_service_col_folder_path.HeaderText = "Path";
            this.dgv_service_col_folder_path.Name = "dgv_service_col_folder_path";
            this.dgv_service_col_folder_path.ReadOnly = true;
            // 
            // dgv_service_col_status
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgv_service_col_status.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgv_service_col_status.HeaderText = "Status";
            this.dgv_service_col_status.MinimumWidth = 150;
            this.dgv_service_col_status.Name = "dgv_service_col_status";
            this.dgv_service_col_status.Width = 150;
            // 
            // UpdateF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 565);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.but_close);
            this.Controls.Add(this.but_update);
            this.Controls.Add(this.but_srcfolderpathbrowse);
            this.Controls.Add(this.txt_srcfolderpath);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "UpdateF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update Service";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_service)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button but_srcfolderpathbrowse;
        private System.Windows.Forms.TextBox txt_srcfolderpath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button but_close;
        private System.Windows.Forms.Button but_update;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgv_service;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_service_col_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_service_col_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_service_col_folder_path;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_service_col_status;
    }
}
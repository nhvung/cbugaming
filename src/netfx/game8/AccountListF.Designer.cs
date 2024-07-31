
namespace game8
{
    partial class AccountListF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountListF));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ts_status = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.ts_status_lab_password = new System.Windows.Forms.ToolStripLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.ts_menu = new System.Windows.Forms.ToolStrip();
            this.ts_menu_but_retypepassword = new System.Windows.Forms.ToolStripButton();
            this.ts_menu_but_add = new System.Windows.Forms.ToolStripButton();
            this.ts_menu_but_edit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.ts_menu_com_url = new System.Windows.Forms.ToolStripComboBox();
            this.ts_menu_but_view = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ts_menu_but_delete = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv_account = new System.Windows.Forms.DataGridView();
            this.dgv_account_col_chk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgv_account_col_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_account_col_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_account_col_url = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_account_col_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_account_col_name_hidden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_account_col_username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_account_col_username_hidden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_account_col_password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_account_col_password_hidden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_account_col_description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_account_col_description_hidden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ts_menu_but_showhide = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.ts_status.SuspendLayout();
            this.ts_menu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_account)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1184, 50);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ts_status);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 489);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1184, 30);
            this.panel2.TabIndex = 1;
            // 
            // ts_status
            // 
            this.ts_status.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ts_status.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ts_status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.ts_status_lab_password});
            this.ts_status.Location = new System.Drawing.Point(0, 5);
            this.ts_status.Name = "ts_status";
            this.ts_status.Size = new System.Drawing.Size(1184, 25);
            this.ts_status.TabIndex = 0;
            this.ts_status.Text = "toolStrip1";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(83, 22);
            this.toolStripLabel2.Text = "Password-256:";
            // 
            // ts_status_lab_password
            // 
            this.ts_status_lab_password.Name = "ts_status_lab_password";
            this.ts_status_lab_password.Size = new System.Drawing.Size(12, 22);
            this.ts_status_lab_password.Text = "-";
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 50);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(10, 439);
            this.panel3.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(1174, 50);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(10, 439);
            this.panel4.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(10, 50);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1164, 10);
            this.panel5.TabIndex = 4;
            // 
            // ts_menu
            // 
            this.ts_menu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ts_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_menu_but_retypepassword,
            this.ts_menu_but_add,
            this.ts_menu_but_edit,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.ts_menu_com_url,
            this.ts_menu_but_view,
            this.ts_menu_but_showhide,
            this.toolStripSeparator2,
            this.ts_menu_but_delete});
            this.ts_menu.Location = new System.Drawing.Point(10, 60);
            this.ts_menu.Name = "ts_menu";
            this.ts_menu.Size = new System.Drawing.Size(1164, 25);
            this.ts_menu.TabIndex = 6;
            this.ts_menu.Text = "toolStrip1";
            // 
            // ts_menu_but_retypepassword
            // 
            this.ts_menu_but_retypepassword.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ts_menu_but_retypepassword.Image = global::game8.Properties.Resources.PasswordBox_16x;
            this.ts_menu_but_retypepassword.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_menu_but_retypepassword.Name = "ts_menu_but_retypepassword";
            this.ts_menu_but_retypepassword.Size = new System.Drawing.Size(121, 22);
            this.ts_menu_but_retypepassword.Text = "Re-type Password";
            this.ts_menu_but_retypepassword.Click += new System.EventHandler(this.ts_menu_but_retypepassword_Click);
            // 
            // ts_menu_but_add
            // 
            this.ts_menu_but_add.Image = global::game8.Properties.Resources.AddUser_16x;
            this.ts_menu_but_add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_menu_but_add.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.ts_menu_but_add.Name = "ts_menu_but_add";
            this.ts_menu_but_add.Size = new System.Drawing.Size(49, 22);
            this.ts_menu_but_add.Text = "Add";
            this.ts_menu_but_add.Click += new System.EventHandler(this.ts_menu_but_add_Click);
            // 
            // ts_menu_but_edit
            // 
            this.ts_menu_but_edit.Image = global::game8.Properties.Resources.ASX_Edit_grey_16x;
            this.ts_menu_but_edit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_menu_but_edit.Name = "ts_menu_but_edit";
            this.ts_menu_but_edit.Size = new System.Drawing.Size(47, 22);
            this.ts_menu_but_edit.Text = "Edit";
            this.ts_menu_but_edit.Click += new System.EventHandler(this.ts_menu_but_edit_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel1.ForeColor = System.Drawing.Color.DarkRed;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(33, 22);
            this.toolStripLabel1.Text = "URL:";
            // 
            // ts_menu_com_url
            // 
            this.ts_menu_com_url.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ts_menu_com_url.Items.AddRange(new object[] {
            "-- All --"});
            this.ts_menu_com_url.Name = "ts_menu_com_url";
            this.ts_menu_com_url.Size = new System.Drawing.Size(250, 25);
            // 
            // ts_menu_but_view
            // 
            this.ts_menu_but_view.Image = global::game8.Properties.Resources.Search_16x;
            this.ts_menu_but_view.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_menu_but_view.Name = "ts_menu_but_view";
            this.ts_menu_but_view.Size = new System.Drawing.Size(52, 22);
            this.ts_menu_but_view.Text = "View";
            this.ts_menu_but_view.Click += new System.EventHandler(this.ts_menu_but_view_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // ts_menu_but_delete
            // 
            this.ts_menu_but_delete.Image = global::game8.Properties.Resources.DeleteUser_16x;
            this.ts_menu_but_delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_menu_but_delete.Name = "ts_menu_but_delete";
            this.ts_menu_but_delete.Size = new System.Drawing.Size(60, 22);
            this.ts_menu_but_delete.Text = "Delete";
            this.ts_menu_but_delete.Click += new System.EventHandler(this.ts_menu_but_delete_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv_account);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(10, 85);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1164, 404);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Account List";
            // 
            // dgv_account
            // 
            this.dgv_account.AllowUserToAddRows = false;
            this.dgv_account.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_account.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_account.ColumnHeadersHeight = 30;
            this.dgv_account.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_account.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgv_account_col_chk,
            this.dgv_account_col_no,
            this.dgv_account_col_id,
            this.dgv_account_col_url,
            this.dgv_account_col_name,
            this.dgv_account_col_name_hidden,
            this.dgv_account_col_username,
            this.dgv_account_col_username_hidden,
            this.dgv_account_col_password,
            this.dgv_account_col_password_hidden,
            this.dgv_account_col_description,
            this.dgv_account_col_description_hidden});
            this.dgv_account.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_account.Location = new System.Drawing.Point(3, 17);
            this.dgv_account.MultiSelect = false;
            this.dgv_account.Name = "dgv_account";
            this.dgv_account.RowHeadersVisible = false;
            this.dgv_account.RowTemplate.Height = 30;
            this.dgv_account.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv_account.Size = new System.Drawing.Size(1158, 384);
            this.dgv_account.TabIndex = 0;
            // 
            // dgv_account_col_chk
            // 
            this.dgv_account_col_chk.HeaderText = "";
            this.dgv_account_col_chk.MinimumWidth = 30;
            this.dgv_account_col_chk.Name = "dgv_account_col_chk";
            this.dgv_account_col_chk.Width = 30;
            // 
            // dgv_account_col_no
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgv_account_col_no.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_account_col_no.HeaderText = "No.";
            this.dgv_account_col_no.MinimumWidth = 50;
            this.dgv_account_col_no.Name = "dgv_account_col_no";
            this.dgv_account_col_no.ReadOnly = true;
            this.dgv_account_col_no.Width = 50;
            // 
            // dgv_account_col_id
            // 
            this.dgv_account_col_id.HeaderText = "ID";
            this.dgv_account_col_id.Name = "dgv_account_col_id";
            this.dgv_account_col_id.Visible = false;
            // 
            // dgv_account_col_url
            // 
            this.dgv_account_col_url.HeaderText = "Url";
            this.dgv_account_col_url.MinimumWidth = 200;
            this.dgv_account_col_url.Name = "dgv_account_col_url";
            this.dgv_account_col_url.ReadOnly = true;
            this.dgv_account_col_url.Width = 200;
            // 
            // dgv_account_col_name
            // 
            this.dgv_account_col_name.HeaderText = "Name";
            this.dgv_account_col_name.MinimumWidth = 150;
            this.dgv_account_col_name.Name = "dgv_account_col_name";
            this.dgv_account_col_name.ReadOnly = true;
            this.dgv_account_col_name.Width = 150;
            // 
            // dgv_account_col_name_hidden
            // 
            this.dgv_account_col_name_hidden.HeaderText = "Name-Hidden";
            this.dgv_account_col_name_hidden.Name = "dgv_account_col_name_hidden";
            this.dgv_account_col_name_hidden.Visible = false;
            // 
            // dgv_account_col_username
            // 
            this.dgv_account_col_username.HeaderText = "Username";
            this.dgv_account_col_username.MinimumWidth = 200;
            this.dgv_account_col_username.Name = "dgv_account_col_username";
            this.dgv_account_col_username.ReadOnly = true;
            this.dgv_account_col_username.Width = 200;
            // 
            // dgv_account_col_username_hidden
            // 
            this.dgv_account_col_username_hidden.HeaderText = "Username-Hidden";
            this.dgv_account_col_username_hidden.Name = "dgv_account_col_username_hidden";
            this.dgv_account_col_username_hidden.Visible = false;
            // 
            // dgv_account_col_password
            // 
            this.dgv_account_col_password.HeaderText = "Password";
            this.dgv_account_col_password.MinimumWidth = 200;
            this.dgv_account_col_password.Name = "dgv_account_col_password";
            this.dgv_account_col_password.ReadOnly = true;
            this.dgv_account_col_password.Width = 200;
            // 
            // dgv_account_col_password_hidden
            // 
            this.dgv_account_col_password_hidden.HeaderText = "Password-Hidden";
            this.dgv_account_col_password_hidden.Name = "dgv_account_col_password_hidden";
            this.dgv_account_col_password_hidden.Visible = false;
            // 
            // dgv_account_col_description
            // 
            this.dgv_account_col_description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_account_col_description.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_account_col_description.HeaderText = "Description";
            this.dgv_account_col_description.MinimumWidth = 200;
            this.dgv_account_col_description.Name = "dgv_account_col_description";
            this.dgv_account_col_description.ReadOnly = true;
            // 
            // dgv_account_col_description_hidden
            // 
            this.dgv_account_col_description_hidden.HeaderText = "Description-Hidden";
            this.dgv_account_col_description_hidden.Name = "dgv_account_col_description_hidden";
            this.dgv_account_col_description_hidden.Visible = false;
            // 
            // ts_menu_but_showhide
            // 
            this.ts_menu_but_showhide.Image = global::game8.Properties.Resources.ShowHideComparisonData_16x;
            this.ts_menu_but_showhide.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_menu_but_showhide.Name = "ts_menu_but_showhide";
            this.ts_menu_but_showhide.Size = new System.Drawing.Size(56, 22);
            this.ts_menu_but_showhide.Text = "Show";
            this.ts_menu_but_showhide.Click += new System.EventHandler(this.ts_menu_but_showhide_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1019, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "ACCOUNT LIST";
            // 
            // AccountListF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1184, 519);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ts_menu);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AccountListF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Account List";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ts_status.ResumeLayout(false);
            this.ts_status.PerformLayout();
            this.ts_menu.ResumeLayout(false);
            this.ts_menu.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_account)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ToolStrip ts_menu;
        private System.Windows.Forms.ToolStripButton ts_menu_but_add;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgv_account;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox ts_menu_com_url;
        private System.Windows.Forms.ToolStripButton ts_menu_but_edit;
        private System.Windows.Forms.ToolStripButton ts_menu_but_view;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton ts_menu_but_delete;
        private System.Windows.Forms.ToolStrip ts_status;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripLabel ts_status_lab_password;
        private System.Windows.Forms.ToolStripButton ts_menu_but_retypepassword;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgv_account_col_chk;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_account_col_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_account_col_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_account_col_url;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_account_col_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_account_col_name_hidden;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_account_col_username;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_account_col_username_hidden;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_account_col_password;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_account_col_password_hidden;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_account_col_description;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_account_col_description_hidden;
        private System.Windows.Forms.ToolStripButton ts_menu_but_showhide;
        private System.Windows.Forms.Label label1;
    }
}


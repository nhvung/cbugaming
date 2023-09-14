
namespace game5
{
    partial class MultipleInstallF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MultipleInstallF));
            this.label1 = new System.Windows.Forms.Label();
            this.txt_srcfolderpath = new System.Windows.Forms.TextBox();
            this.but_srcfolderpathbrowse = new System.Windows.Forms.Button();
            this.but_rootservicesfolderpathbrowse = new System.Windows.Forms.Button();
            this.txt_rootservicesfolderpath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rtxt_servicenames = new System.Windows.Forms.RichTextBox();
            this.but_close = new System.Windows.Forms.Button();
            this.but_install = new System.Windows.Forms.Button();
            this.but_exepathbrowse = new System.Windows.Forms.Button();
            this.txt_exepath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rtxt_logs = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Source Folder Path:";
            // 
            // txt_srcfolderpath
            // 
            this.txt_srcfolderpath.Location = new System.Drawing.Point(12, 27);
            this.txt_srcfolderpath.Name = "txt_srcfolderpath";
            this.txt_srcfolderpath.Size = new System.Drawing.Size(518, 21);
            this.txt_srcfolderpath.TabIndex = 1;
            // 
            // but_srcfolderpathbrowse
            // 
            this.but_srcfolderpathbrowse.Location = new System.Drawing.Point(536, 26);
            this.but_srcfolderpathbrowse.Name = "but_srcfolderpathbrowse";
            this.but_srcfolderpathbrowse.Size = new System.Drawing.Size(36, 23);
            this.but_srcfolderpathbrowse.TabIndex = 2;
            this.but_srcfolderpathbrowse.Text = "...";
            this.but_srcfolderpathbrowse.UseVisualStyleBackColor = true;
            this.but_srcfolderpathbrowse.Click += new System.EventHandler(this.but_srcfolderpathbrowse_Click);
            // 
            // but_rootservicesfolderpathbrowse
            // 
            this.but_rootservicesfolderpathbrowse.Location = new System.Drawing.Point(536, 137);
            this.but_rootservicesfolderpathbrowse.Name = "but_rootservicesfolderpathbrowse";
            this.but_rootservicesfolderpathbrowse.Size = new System.Drawing.Size(36, 23);
            this.but_rootservicesfolderpathbrowse.TabIndex = 5;
            this.but_rootservicesfolderpathbrowse.Text = "...";
            this.but_rootservicesfolderpathbrowse.UseVisualStyleBackColor = true;
            this.but_rootservicesfolderpathbrowse.Click += new System.EventHandler(this.but_rootservicesfolderpathbrowse_Click);
            // 
            // txt_rootservicesfolderpath
            // 
            this.txt_rootservicesfolderpath.Location = new System.Drawing.Point(12, 138);
            this.txt_rootservicesfolderpath.Name = "txt_rootservicesfolderpath";
            this.txt_rootservicesfolderpath.Size = new System.Drawing.Size(518, 21);
            this.txt_rootservicesfolderpath.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Root Services Folder Path:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(196, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Service Names (1 name per line)*:";
            // 
            // rtxt_servicenames
            // 
            this.rtxt_servicenames.Location = new System.Drawing.Point(12, 198);
            this.rtxt_servicenames.Name = "rtxt_servicenames";
            this.rtxt_servicenames.Size = new System.Drawing.Size(560, 206);
            this.rtxt_servicenames.TabIndex = 7;
            this.rtxt_servicenames.Text = "";
            // 
            // but_close
            // 
            this.but_close.Location = new System.Drawing.Point(471, 421);
            this.but_close.Name = "but_close";
            this.but_close.Size = new System.Drawing.Size(99, 27);
            this.but_close.TabIndex = 15;
            this.but_close.Text = "Close";
            this.but_close.UseVisualStyleBackColor = true;
            this.but_close.Click += new System.EventHandler(this.but_close_Click);
            // 
            // but_install
            // 
            this.but_install.Location = new System.Drawing.Point(366, 421);
            this.but_install.Name = "but_install";
            this.but_install.Size = new System.Drawing.Size(99, 27);
            this.but_install.TabIndex = 12;
            this.but_install.Text = "Install";
            this.but_install.UseVisualStyleBackColor = true;
            this.but_install.Click += new System.EventHandler(this.but_install_Click);
            // 
            // but_exepathbrowse
            // 
            this.but_exepathbrowse.Location = new System.Drawing.Point(536, 81);
            this.but_exepathbrowse.Name = "but_exepathbrowse";
            this.but_exepathbrowse.Size = new System.Drawing.Size(36, 23);
            this.but_exepathbrowse.TabIndex = 21;
            this.but_exepathbrowse.Text = "...";
            this.but_exepathbrowse.UseVisualStyleBackColor = true;
            this.but_exepathbrowse.Click += new System.EventHandler(this.but_exepathbrowse_Click);
            // 
            // txt_exepath
            // 
            this.txt_exepath.Location = new System.Drawing.Point(12, 82);
            this.txt_exepath.Name = "txt_exepath";
            this.txt_exepath.Size = new System.Drawing.Size(518, 21);
            this.txt_exepath.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 15);
            this.label5.TabIndex = 19;
            this.label5.Text = "EXE file name:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtxt_logs);
            this.groupBox1.Location = new System.Drawing.Point(15, 468);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(557, 183);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Logs";
            // 
            // rtxt_logs
            // 
            this.rtxt_logs.BackColor = System.Drawing.Color.White;
            this.rtxt_logs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxt_logs.Location = new System.Drawing.Point(3, 17);
            this.rtxt_logs.Name = "rtxt_logs";
            this.rtxt_logs.ReadOnly = true;
            this.rtxt_logs.Size = new System.Drawing.Size(551, 163);
            this.rtxt_logs.TabIndex = 0;
            this.rtxt_logs.Text = "";
            // 
            // MultipleInstallF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 663);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.but_exepathbrowse);
            this.Controls.Add(this.txt_exepath);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.but_close);
            this.Controls.Add(this.but_install);
            this.Controls.Add(this.rtxt_servicenames);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.but_rootservicesfolderpathbrowse);
            this.Controls.Add(this.txt_rootservicesfolderpath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.but_srcfolderpathbrowse);
            this.Controls.Add(this.txt_srcfolderpath);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MultipleInstallF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Install Multi Services";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_srcfolderpath;
        private System.Windows.Forms.Button but_srcfolderpathbrowse;
        private System.Windows.Forms.Button but_rootservicesfolderpathbrowse;
        private System.Windows.Forms.TextBox txt_rootservicesfolderpath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rtxt_servicenames;
        private System.Windows.Forms.Button but_close;
        private System.Windows.Forms.Button but_install;
        private System.Windows.Forms.Button but_exepathbrowse;
        private System.Windows.Forms.TextBox txt_exepath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox rtxt_logs;
    }
}
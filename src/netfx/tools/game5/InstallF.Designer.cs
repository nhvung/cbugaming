
namespace game5
{
    partial class InstallF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InstallF));
            this.label1 = new System.Windows.Forms.Label();
            this.txt_exepath = new System.Windows.Forms.TextBox();
            this.but_exepathbrowse = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.but_install = new System.Windows.Forms.Button();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lab_status = new System.Windows.Forms.Label();
            this.but_close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "EXE path*:";
            // 
            // txt_exepath
            // 
            this.txt_exepath.Location = new System.Drawing.Point(12, 33);
            this.txt_exepath.Name = "txt_exepath";
            this.txt_exepath.Size = new System.Drawing.Size(513, 21);
            this.txt_exepath.TabIndex = 1;
            // 
            // but_exepathbrowse
            // 
            this.but_exepathbrowse.Location = new System.Drawing.Point(531, 31);
            this.but_exepathbrowse.Name = "but_exepathbrowse";
            this.but_exepathbrowse.Size = new System.Drawing.Size(36, 23);
            this.but_exepathbrowse.TabIndex = 2;
            this.but_exepathbrowse.Text = "...";
            this.but_exepathbrowse.UseVisualStyleBackColor = true;
            this.but_exepathbrowse.Click += new System.EventHandler(this.but_exepathbrowse_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Service Name*:";
            // 
            // but_install
            // 
            this.but_install.Location = new System.Drawing.Point(366, 149);
            this.but_install.Name = "but_install";
            this.but_install.Size = new System.Drawing.Size(99, 27);
            this.but_install.TabIndex = 5;
            this.but_install.Text = "Install";
            this.but_install.UseVisualStyleBackColor = true;
            this.but_install.Click += new System.EventHandler(this.but_install_Click);
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(12, 97);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(513, 21);
            this.txt_name.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Status:";
            // 
            // lab_status
            // 
            this.lab_status.AutoSize = true;
            this.lab_status.Location = new System.Drawing.Point(63, 155);
            this.lab_status.Name = "lab_status";
            this.lab_status.Size = new System.Drawing.Size(11, 15);
            this.lab_status.TabIndex = 10;
            this.lab_status.Text = "-";
            // 
            // but_close
            // 
            this.but_close.Location = new System.Drawing.Point(471, 149);
            this.but_close.Name = "but_close";
            this.but_close.Size = new System.Drawing.Size(99, 27);
            this.but_close.TabIndex = 11;
            this.but_close.Text = "Close";
            this.but_close.UseVisualStyleBackColor = true;
            this.but_close.Click += new System.EventHandler(this.but_close_Click);
            // 
            // InstallF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 196);
            this.Controls.Add(this.but_close);
            this.Controls.Add(this.lab_status);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.but_install);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.but_exepathbrowse);
            this.Controls.Add(this.txt_exepath);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "InstallF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InstallF";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_exepath;
        private System.Windows.Forms.Button but_exepathbrowse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button but_install;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lab_status;
        private System.Windows.Forms.Button but_close;
    }
}
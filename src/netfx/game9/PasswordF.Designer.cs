
namespace game9
{
    partial class PasswordF
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
            this.but_ok = new System.Windows.Forms.Button();
            this.but_cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rtxt_description = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // but_ok
            // 
            this.but_ok.Location = new System.Drawing.Point(274, 195);
            this.but_ok.Name = "but_ok";
            this.but_ok.Size = new System.Drawing.Size(75, 23);
            this.but_ok.TabIndex = 0;
            this.but_ok.Text = "Submit";
            this.but_ok.UseVisualStyleBackColor = true;
            this.but_ok.Click += new System.EventHandler(this.but_ok_Click);
            // 
            // but_cancel
            // 
            this.but_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.but_cancel.Location = new System.Drawing.Point(355, 195);
            this.but_cancel.Name = "but_cancel";
            this.but_cancel.Size = new System.Drawing.Size(75, 23);
            this.but_cancel.TabIndex = 1;
            this.but_cancel.Text = "Cancel";
            this.but_cancel.UseVisualStyleBackColor = true;
            this.but_cancel.Click += new System.EventHandler(this.but_cancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Password:";
            // 
            // txt_password
            // 
            this.txt_password.Location = new System.Drawing.Point(139, 148);
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(512, 21);
            this.txt_password.TabIndex = 3;
            this.txt_password.UseSystemPasswordChar = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtxt_description);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(724, 104);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Welcome Messages";
            // 
            // rtxt_description
            // 
            this.rtxt_description.BackColor = System.Drawing.Color.White;
            this.rtxt_description.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxt_description.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxt_description.Location = new System.Drawing.Point(3, 17);
            this.rtxt_description.Name = "rtxt_description";
            this.rtxt_description.ReadOnly = true;
            this.rtxt_description.Size = new System.Drawing.Size(718, 84);
            this.rtxt_description.TabIndex = 0;
            this.rtxt_description.Text = "Everything about today was perfect. A heartfelt ‘thank you’ for making this day t" +
    "he best one.\n\nAnyway, please type the password below....";
            // 
            // PasswordF
            // 
            this.AcceptButton = this.but_ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.but_cancel;
            this.ClientSize = new System.Drawing.Size(748, 249);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txt_password);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.but_cancel);
            this.Controls.Add(this.but_ok);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "PasswordF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Password";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button but_ok;
        private System.Windows.Forms.Button but_cancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox rtxt_description;
    }
}
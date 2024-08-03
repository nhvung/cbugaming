
namespace game8
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
            this.label1 = new System.Windows.Forms.Label();
            this.chk_showpassword = new System.Windows.Forms.CheckBox();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.but_ok = new System.Windows.Forms.Button();
            this.but_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Password:";
            // 
            // chk_showpassword
            // 
            this.chk_showpassword.AutoSize = true;
            this.chk_showpassword.Location = new System.Drawing.Point(84, 49);
            this.chk_showpassword.Name = "chk_showpassword";
            this.chk_showpassword.Size = new System.Drawing.Size(57, 19);
            this.chk_showpassword.TabIndex = 1;
            this.chk_showpassword.Text = "Show";
            this.chk_showpassword.UseVisualStyleBackColor = true;
            this.chk_showpassword.CheckedChanged += new System.EventHandler(this.chk_showpassword_CheckedChanged);
            // 
            // txt_password
            // 
            this.txt_password.Location = new System.Drawing.Point(84, 22);
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(334, 21);
            this.txt_password.TabIndex = 2;
            this.txt_password.UseSystemPasswordChar = true;
            // 
            // but_ok
            // 
            this.but_ok.Location = new System.Drawing.Point(144, 94);
            this.but_ok.Name = "but_ok";
            this.but_ok.Size = new System.Drawing.Size(75, 23);
            this.but_ok.TabIndex = 3;
            this.but_ok.Text = "OK";
            this.but_ok.UseVisualStyleBackColor = true;
            this.but_ok.Click += new System.EventHandler(this.but_ok_Click);
            // 
            // but_cancel
            // 
            this.but_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.but_cancel.Location = new System.Drawing.Point(225, 94);
            this.but_cancel.Name = "but_cancel";
            this.but_cancel.Size = new System.Drawing.Size(75, 23);
            this.but_cancel.TabIndex = 4;
            this.but_cancel.Text = "CANCEL";
            this.but_cancel.UseVisualStyleBackColor = true;
            this.but_cancel.Click += new System.EventHandler(this.but_cancel_Click);
            // 
            // PasswordF
            // 
            this.AcceptButton = this.but_ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.but_cancel;
            this.ClientSize = new System.Drawing.Size(435, 140);
            this.ControlBox = false;
            this.Controls.Add(this.but_cancel);
            this.Controls.Add(this.but_ok);
            this.Controls.Add(this.txt_password);
            this.Controls.Add(this.chk_showpassword);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "PasswordF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Password";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chk_showpassword;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.Button but_ok;
        private System.Windows.Forms.Button but_cancel;
    }
}
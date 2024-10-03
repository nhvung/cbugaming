
namespace game11
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.txt_filepath = new System.Windows.Forms.TextBox();
            this.but_browse = new System.Windows.Forms.Button();
            this.but_count = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.rtxt_words = new System.Windows.Forms.RichTextBox();
            this.chk_ignorecase = new System.Windows.Forms.CheckBox();
            this.rtxt_result = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "File Path:";
            // 
            // txt_filepath
            // 
            this.txt_filepath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_filepath.Location = new System.Drawing.Point(76, 26);
            this.txt_filepath.Name = "txt_filepath";
            this.txt_filepath.Size = new System.Drawing.Size(504, 21);
            this.txt_filepath.TabIndex = 1;
            // 
            // but_browse
            // 
            this.but_browse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.but_browse.Location = new System.Drawing.Point(590, 25);
            this.but_browse.Name = "but_browse";
            this.but_browse.Size = new System.Drawing.Size(75, 23);
            this.but_browse.TabIndex = 2;
            this.but_browse.Text = "Browse";
            this.but_browse.UseVisualStyleBackColor = true;
            this.but_browse.Click += new System.EventHandler(this.but_browse_Click);
            // 
            // but_count
            // 
            this.but_count.Location = new System.Drawing.Point(505, 233);
            this.but_count.Name = "but_count";
            this.but_count.Size = new System.Drawing.Size(75, 23);
            this.but_count.TabIndex = 3;
            this.but_count.Text = "Count";
            this.but_count.UseVisualStyleBackColor = true;
            this.but_count.Click += new System.EventHandler(this.but_count_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Words:";
            // 
            // rtxt_words
            // 
            this.rtxt_words.Location = new System.Drawing.Point(76, 53);
            this.rtxt_words.Name = "rtxt_words";
            this.rtxt_words.Size = new System.Drawing.Size(504, 166);
            this.rtxt_words.TabIndex = 5;
            this.rtxt_words.Text = "Address";
            // 
            // chk_ignorecase
            // 
            this.chk_ignorecase.AutoSize = true;
            this.chk_ignorecase.Location = new System.Drawing.Point(76, 236);
            this.chk_ignorecase.Name = "chk_ignorecase";
            this.chk_ignorecase.Size = new System.Drawing.Size(94, 19);
            this.chk_ignorecase.TabIndex = 6;
            this.chk_ignorecase.Text = "Ignore Case";
            this.chk_ignorecase.UseVisualStyleBackColor = true;
            // 
            // rtxt_result
            // 
            this.rtxt_result.Location = new System.Drawing.Point(76, 284);
            this.rtxt_result.Name = "rtxt_result";
            this.rtxt_result.Size = new System.Drawing.Size(504, 265);
            this.rtxt_result.TabIndex = 7;
            this.rtxt_result.Text = "";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 287);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Result:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 594);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rtxt_result);
            this.Controls.Add(this.chk_ignorecase);
            this.Controls.Add(this.rtxt_words);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.but_count);
            this.Controls.Add(this.but_browse);
            this.Controls.Add(this.txt_filepath);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game 11";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_filepath;
        private System.Windows.Forms.Button but_browse;
        private System.Windows.Forms.Button but_count;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rtxt_words;
        private System.Windows.Forms.CheckBox chk_ignorecase;
        private System.Windows.Forms.RichTextBox rtxt_result;
        private System.Windows.Forms.Label label3;
    }
}


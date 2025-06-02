
namespace game18
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_samplefilepath = new System.Windows.Forms.TextBox();
            this.but_samplefilepathbrowse = new System.Windows.Forms.Button();
            this.but_resultfilepathbrowse = new System.Windows.Forms.Button();
            this.txt_resultfilepath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.but_execute = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sample File:";
            // 
            // txt_samplefilepath
            // 
            this.txt_samplefilepath.Location = new System.Drawing.Point(133, 38);
            this.txt_samplefilepath.Name = "txt_samplefilepath";
            this.txt_samplefilepath.Size = new System.Drawing.Size(543, 21);
            this.txt_samplefilepath.TabIndex = 1;
            // 
            // but_samplefilepathbrowse
            // 
            this.but_samplefilepathbrowse.Location = new System.Drawing.Point(682, 37);
            this.but_samplefilepathbrowse.Name = "but_samplefilepathbrowse";
            this.but_samplefilepathbrowse.Size = new System.Drawing.Size(41, 23);
            this.but_samplefilepathbrowse.TabIndex = 2;
            this.but_samplefilepathbrowse.Text = "...";
            this.but_samplefilepathbrowse.UseVisualStyleBackColor = true;
            this.but_samplefilepathbrowse.Click += new System.EventHandler(this.but_samplefilepathbrowse_Click);
            // 
            // but_resultfilepathbrowse
            // 
            this.but_resultfilepathbrowse.Location = new System.Drawing.Point(682, 64);
            this.but_resultfilepathbrowse.Name = "but_resultfilepathbrowse";
            this.but_resultfilepathbrowse.Size = new System.Drawing.Size(41, 23);
            this.but_resultfilepathbrowse.TabIndex = 5;
            this.but_resultfilepathbrowse.Text = "...";
            this.but_resultfilepathbrowse.UseVisualStyleBackColor = true;
            this.but_resultfilepathbrowse.Click += new System.EventHandler(this.but_resultfilepathbrowse_Click);
            // 
            // txt_resultfilepath
            // 
            this.txt_resultfilepath.Location = new System.Drawing.Point(133, 65);
            this.txt_resultfilepath.Name = "txt_resultfilepath";
            this.txt_resultfilepath.Size = new System.Drawing.Size(543, 21);
            this.txt_resultfilepath.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Result File:";
            // 
            // but_execute
            // 
            this.but_execute.Location = new System.Drawing.Point(133, 101);
            this.but_execute.Name = "but_execute";
            this.but_execute.Size = new System.Drawing.Size(121, 23);
            this.but_execute.TabIndex = 6;
            this.but_execute.Text = "Execute";
            this.but_execute.UseVisualStyleBackColor = true;
            this.but_execute.Click += new System.EventHandler(this.but_execute_Click);
            // 
            // MainF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 163);
            this.Controls.Add(this.but_execute);
            this.Controls.Add(this.but_resultfilepathbrowse);
            this.Controls.Add(this.txt_resultfilepath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.but_samplefilepathbrowse);
            this.Controls.Add(this.txt_samplefilepath);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game 18";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_samplefilepath;
        private System.Windows.Forms.Button but_samplefilepathbrowse;
        private System.Windows.Forms.Button but_resultfilepathbrowse;
        private System.Windows.Forms.TextBox txt_resultfilepath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button but_execute;
    }
}


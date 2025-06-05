
namespace game19
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
            this.txt_inputfolderpath = new System.Windows.Forms.TextBox();
            this.but_inputfolderpathbrowse = new System.Windows.Forms.Button();
            this.but_outputfolderpathbrowse = new System.Windows.Forms.Button();
            this.txt_outputfolderpath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.but_execute = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_aliaspath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Input Folder:";
            // 
            // txt_inputfolderpath
            // 
            this.txt_inputfolderpath.Location = new System.Drawing.Point(146, 70);
            this.txt_inputfolderpath.Name = "txt_inputfolderpath";
            this.txt_inputfolderpath.Size = new System.Drawing.Size(672, 21);
            this.txt_inputfolderpath.TabIndex = 1;
            // 
            // but_inputfolderpathbrowse
            // 
            this.but_inputfolderpathbrowse.Location = new System.Drawing.Point(824, 69);
            this.but_inputfolderpathbrowse.Name = "but_inputfolderpathbrowse";
            this.but_inputfolderpathbrowse.Size = new System.Drawing.Size(33, 23);
            this.but_inputfolderpathbrowse.TabIndex = 2;
            this.but_inputfolderpathbrowse.Text = "...";
            this.but_inputfolderpathbrowse.UseVisualStyleBackColor = true;
            this.but_inputfolderpathbrowse.Click += new System.EventHandler(this.but_inputfolderpathbrowse_Click);
            // 
            // but_outputfolderpathbrowse
            // 
            this.but_outputfolderpathbrowse.Location = new System.Drawing.Point(824, 96);
            this.but_outputfolderpathbrowse.Name = "but_outputfolderpathbrowse";
            this.but_outputfolderpathbrowse.Size = new System.Drawing.Size(33, 23);
            this.but_outputfolderpathbrowse.TabIndex = 5;
            this.but_outputfolderpathbrowse.Text = "...";
            this.but_outputfolderpathbrowse.UseVisualStyleBackColor = true;
            this.but_outputfolderpathbrowse.Click += new System.EventHandler(this.but_outputfolderpathbrowse_Click);
            // 
            // txt_outputfolderpath
            // 
            this.txt_outputfolderpath.Location = new System.Drawing.Point(146, 97);
            this.txt_outputfolderpath.Name = "txt_outputfolderpath";
            this.txt_outputfolderpath.Size = new System.Drawing.Size(672, 21);
            this.txt_outputfolderpath.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Output Folder:";
            // 
            // but_execute
            // 
            this.but_execute.Location = new System.Drawing.Point(146, 175);
            this.but_execute.Name = "but_execute";
            this.but_execute.Size = new System.Drawing.Size(103, 23);
            this.but_execute.TabIndex = 6;
            this.but_execute.Text = "Execute";
            this.but_execute.UseVisualStyleBackColor = true;
            this.but_execute.Click += new System.EventHandler(this.but_execute_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Alias Path:";
            // 
            // txt_aliaspath
            // 
            this.txt_aliaspath.Location = new System.Drawing.Point(146, 124);
            this.txt_aliaspath.Name = "txt_aliaspath";
            this.txt_aliaspath.Size = new System.Drawing.Size(672, 21);
            this.txt_aliaspath.TabIndex = 8;
            // 
            // MainF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 256);
            this.Controls.Add(this.txt_aliaspath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.but_execute);
            this.Controls.Add(this.but_outputfolderpathbrowse);
            this.Controls.Add(this.txt_outputfolderpath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.but_inputfolderpathbrowse);
            this.Controls.Add(this.txt_inputfolderpath);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game 19";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_inputfolderpath;
        private System.Windows.Forms.Button but_inputfolderpathbrowse;
        private System.Windows.Forms.Button but_outputfolderpathbrowse;
        private System.Windows.Forms.TextBox txt_outputfolderpath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button but_execute;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_aliaspath;
    }
}


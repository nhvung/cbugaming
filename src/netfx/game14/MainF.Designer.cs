
namespace game14
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
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.address_2_but_preview = new System.Windows.Forms.Button();
            this.address_2_rad_latlong = new System.Windows.Forms.RadioButton();
            this.address_2_rad_address = new System.Windows.Forms.RadioButton();
            this.address_2_txt_address = new System.Windows.Forms.TextBox();
            this.address_2_txt_latlong = new System.Windows.Forms.TextBox();
            this.txt_apikey = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rtxt_result = new System.Windows.Forms.RichTextBox();
            this.but_calculate = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.address_1_but_preview = new System.Windows.Forms.Button();
            this.address_1_rad_latlong = new System.Windows.Forms.RadioButton();
            this.address_1_rad_address = new System.Windows.Forms.RadioButton();
            this.address_1_txt_address = new System.Windows.Forms.TextBox();
            this.address_1_txt_latlong = new System.Windows.Forms.TextBox();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.address_2_but_preview);
            this.groupBox5.Controls.Add(this.address_2_rad_latlong);
            this.groupBox5.Controls.Add(this.address_2_rad_address);
            this.groupBox5.Controls.Add(this.address_2_txt_address);
            this.groupBox5.Controls.Add(this.address_2_txt_latlong);
            this.groupBox5.Location = new System.Drawing.Point(11, 158);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(635, 87);
            this.groupBox5.TabIndex = 20;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Address 2";
            // 
            // address_2_but_preview
            // 
            this.address_2_but_preview.Location = new System.Drawing.Point(510, 35);
            this.address_2_but_preview.Name = "address_2_but_preview";
            this.address_2_but_preview.Size = new System.Drawing.Size(75, 23);
            this.address_2_but_preview.TabIndex = 9;
            this.address_2_but_preview.Text = "Preview";
            this.address_2_but_preview.UseVisualStyleBackColor = true;
            this.address_2_but_preview.Click += new System.EventHandler(this.address_2_but_preview_Click);
            // 
            // address_2_rad_latlong
            // 
            this.address_2_rad_latlong.AutoSize = true;
            this.address_2_rad_latlong.Checked = true;
            this.address_2_rad_latlong.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.address_2_rad_latlong.Location = new System.Drawing.Point(25, 52);
            this.address_2_rad_latlong.Name = "address_2_rad_latlong";
            this.address_2_rad_latlong.Size = new System.Drawing.Size(133, 19);
            this.address_2_rad_latlong.TabIndex = 7;
            this.address_2_rad_latlong.TabStop = true;
            this.address_2_rad_latlong.Text = "Latitude/Longitude:";
            this.address_2_rad_latlong.UseVisualStyleBackColor = true;
            // 
            // address_2_rad_address
            // 
            this.address_2_rad_address.AutoSize = true;
            this.address_2_rad_address.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.address_2_rad_address.Location = new System.Drawing.Point(25, 25);
            this.address_2_rad_address.Name = "address_2_rad_address";
            this.address_2_rad_address.Size = new System.Drawing.Size(76, 19);
            this.address_2_rad_address.TabIndex = 6;
            this.address_2_rad_address.Text = "Address:";
            this.address_2_rad_address.UseVisualStyleBackColor = true;
            // 
            // address_2_txt_address
            // 
            this.address_2_txt_address.Location = new System.Drawing.Point(213, 24);
            this.address_2_txt_address.Name = "address_2_txt_address";
            this.address_2_txt_address.Size = new System.Drawing.Size(267, 21);
            this.address_2_txt_address.TabIndex = 5;
            // 
            // address_2_txt_latlong
            // 
            this.address_2_txt_latlong.Location = new System.Drawing.Point(213, 51);
            this.address_2_txt_latlong.Name = "address_2_txt_latlong";
            this.address_2_txt_latlong.Size = new System.Drawing.Size(267, 21);
            this.address_2_txt_latlong.TabIndex = 2;
            // 
            // txt_apikey
            // 
            this.txt_apikey.Location = new System.Drawing.Point(120, 29);
            this.txt_apikey.Name = "txt_apikey";
            this.txt_apikey.Size = new System.Drawing.Size(476, 21);
            this.txt_apikey.TabIndex = 24;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(44, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 15);
            this.label9.TabIndex = 23;
            this.label9.Text = "API Key:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rtxt_result);
            this.groupBox4.Location = new System.Drawing.Point(13, 306);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(635, 157);
            this.groupBox4.TabIndex = 22;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Result";
            // 
            // rtxt_result
            // 
            this.rtxt_result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxt_result.Location = new System.Drawing.Point(3, 17);
            this.rtxt_result.Name = "rtxt_result";
            this.rtxt_result.Size = new System.Drawing.Size(629, 137);
            this.rtxt_result.TabIndex = 0;
            this.rtxt_result.Text = "";
            // 
            // but_calculate
            // 
            this.but_calculate.Location = new System.Drawing.Point(261, 265);
            this.but_calculate.Name = "but_calculate";
            this.but_calculate.Size = new System.Drawing.Size(137, 23);
            this.but_calculate.TabIndex = 21;
            this.but_calculate.Text = "Calculate";
            this.but_calculate.UseVisualStyleBackColor = true;
            this.but_calculate.Click += new System.EventHandler(this.but_calc_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.address_1_but_preview);
            this.groupBox6.Controls.Add(this.address_1_rad_latlong);
            this.groupBox6.Controls.Add(this.address_1_rad_address);
            this.groupBox6.Controls.Add(this.address_1_txt_address);
            this.groupBox6.Controls.Add(this.address_1_txt_latlong);
            this.groupBox6.Location = new System.Drawing.Point(13, 65);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(635, 87);
            this.groupBox6.TabIndex = 19;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Address 1";
            // 
            // address_1_but_preview
            // 
            this.address_1_but_preview.Location = new System.Drawing.Point(508, 39);
            this.address_1_but_preview.Name = "address_1_but_preview";
            this.address_1_but_preview.Size = new System.Drawing.Size(75, 23);
            this.address_1_but_preview.TabIndex = 8;
            this.address_1_but_preview.Text = "Preview";
            this.address_1_but_preview.UseVisualStyleBackColor = true;
            this.address_1_but_preview.Click += new System.EventHandler(this.address_1_but_preview_Click);
            // 
            // address_1_rad_latlong
            // 
            this.address_1_rad_latlong.AutoSize = true;
            this.address_1_rad_latlong.Checked = true;
            this.address_1_rad_latlong.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.address_1_rad_latlong.Location = new System.Drawing.Point(25, 52);
            this.address_1_rad_latlong.Name = "address_1_rad_latlong";
            this.address_1_rad_latlong.Size = new System.Drawing.Size(133, 19);
            this.address_1_rad_latlong.TabIndex = 7;
            this.address_1_rad_latlong.TabStop = true;
            this.address_1_rad_latlong.Text = "Latitude/Longitude:";
            this.address_1_rad_latlong.UseVisualStyleBackColor = true;
            // 
            // address_1_rad_address
            // 
            this.address_1_rad_address.AutoSize = true;
            this.address_1_rad_address.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.address_1_rad_address.Location = new System.Drawing.Point(25, 25);
            this.address_1_rad_address.Name = "address_1_rad_address";
            this.address_1_rad_address.Size = new System.Drawing.Size(76, 19);
            this.address_1_rad_address.TabIndex = 6;
            this.address_1_rad_address.Text = "Address:";
            this.address_1_rad_address.UseVisualStyleBackColor = true;
            // 
            // address_1_txt_address
            // 
            this.address_1_txt_address.Location = new System.Drawing.Point(213, 24);
            this.address_1_txt_address.Name = "address_1_txt_address";
            this.address_1_txt_address.Size = new System.Drawing.Size(265, 21);
            this.address_1_txt_address.TabIndex = 5;
            // 
            // address_1_txt_latlong
            // 
            this.address_1_txt_latlong.Location = new System.Drawing.Point(213, 51);
            this.address_1_txt_latlong.Name = "address_1_txt_latlong";
            this.address_1_txt_latlong.Size = new System.Drawing.Size(265, 21);
            this.address_1_txt_latlong.TabIndex = 2;
            // 
            // MainF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 475);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.txt_apikey);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.but_calculate);
            this.Controls.Add(this.groupBox6);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calculate Distance";
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button address_2_but_preview;
        private System.Windows.Forms.RadioButton address_2_rad_latlong;
        private System.Windows.Forms.RadioButton address_2_rad_address;
        private System.Windows.Forms.TextBox address_2_txt_address;
        private System.Windows.Forms.TextBox address_2_txt_latlong;
        private System.Windows.Forms.TextBox txt_apikey;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RichTextBox rtxt_result;
        private System.Windows.Forms.Button but_calculate;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button address_1_but_preview;
        private System.Windows.Forms.RadioButton address_1_rad_latlong;
        private System.Windows.Forms.RadioButton address_1_rad_address;
        private System.Windows.Forms.TextBox address_1_txt_address;
        private System.Windows.Forms.TextBox address_1_txt_latlong;
    }
}


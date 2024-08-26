
namespace game9
{
    partial class ViewChartF
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.main_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.but_exporttoimage = new System.Windows.Forms.Button();
            this.but_close = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.but_apply = new System.Windows.Forms.Button();
            this.com_xaxislabel = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.com_yaxislabel = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.com_xaxislabelangle = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.com_charttitle = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.main_chart)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // main_chart
            // 
            this.main_chart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.Name = "ChartArea1";
            this.main_chart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.main_chart.Legends.Add(legend2);
            this.main_chart.Location = new System.Drawing.Point(12, 167);
            this.main_chart.Name = "main_chart";
            this.main_chart.Size = new System.Drawing.Size(909, 241);
            this.main_chart.TabIndex = 0;
            this.main_chart.Text = "chart1";
            // 
            // but_exporttoimage
            // 
            this.but_exporttoimage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.but_exporttoimage.Location = new System.Drawing.Point(361, 609);
            this.but_exporttoimage.Name = "but_exporttoimage";
            this.but_exporttoimage.Size = new System.Drawing.Size(142, 23);
            this.but_exporttoimage.TabIndex = 1;
            this.but_exporttoimage.Text = "Export Image...";
            this.but_exporttoimage.UseVisualStyleBackColor = true;
            // 
            // but_close
            // 
            this.but_close.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.but_close.Location = new System.Drawing.Point(509, 609);
            this.but_close.Name = "but_close";
            this.but_close.Size = new System.Drawing.Size(75, 23);
            this.but_close.TabIndex = 2;
            this.but_close.Text = "Close";
            this.but_close.UseVisualStyleBackColor = true;
            this.but_close.Click += new System.EventHandler(this.but_close_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "X-Axis Label:";
            // 
            // but_apply
            // 
            this.but_apply.Location = new System.Drawing.Point(151, 113);
            this.but_apply.Name = "but_apply";
            this.but_apply.Size = new System.Drawing.Size(75, 23);
            this.but_apply.TabIndex = 4;
            this.but_apply.Text = "Apply";
            this.but_apply.UseVisualStyleBackColor = true;
            this.but_apply.Click += new System.EventHandler(this.but_apply_Click);
            // 
            // com_xaxislabel
            // 
            this.com_xaxislabel.FormattingEnabled = true;
            this.com_xaxislabel.Location = new System.Drawing.Point(151, 55);
            this.com_xaxislabel.Name = "com_xaxislabel";
            this.com_xaxislabel.Size = new System.Drawing.Size(221, 23);
            this.com_xaxislabel.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Y-Axis Label:";
            // 
            // com_yaxislabel
            // 
            this.com_yaxislabel.FormattingEnabled = true;
            this.com_yaxislabel.Location = new System.Drawing.Point(151, 84);
            this.com_yaxislabel.Name = "com_yaxislabel";
            this.com_yaxislabel.Size = new System.Drawing.Size(221, 23);
            this.com_yaxislabel.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.com_charttitle);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.com_xaxislabelangle);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.but_apply);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.com_yaxislabel);
            this.groupBox1.Controls.Add(this.com_xaxislabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(909, 149);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configurations";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(411, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "X-Axis Label Angle :";
            // 
            // com_xaxislabelangle
            // 
            this.com_xaxislabelangle.FormattingEnabled = true;
            this.com_xaxislabelangle.Location = new System.Drawing.Point(530, 55);
            this.com_xaxislabelangle.Name = "com_xaxislabelangle";
            this.com_xaxislabelangle.Size = new System.Drawing.Size(105, 23);
            this.com_xaxislabelangle.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Chart Title:";
            // 
            // com_charttitle
            // 
            this.com_charttitle.FormattingEnabled = true;
            this.com_charttitle.Location = new System.Drawing.Point(151, 26);
            this.com_charttitle.Name = "com_charttitle";
            this.com_charttitle.Size = new System.Drawing.Size(697, 23);
            this.com_charttitle.TabIndex = 11;
            // 
            // ViewChartF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 644);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.but_close);
            this.Controls.Add(this.but_exporttoimage);
            this.Controls.Add(this.main_chart);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ViewChartF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ViewChartF";
            ((System.ComponentModel.ISupportInitialize)(this.main_chart)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart main_chart;
        private System.Windows.Forms.Button but_exporttoimage;
        private System.Windows.Forms.Button but_close;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button but_apply;
        private System.Windows.Forms.ComboBox com_xaxislabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox com_yaxislabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox com_charttitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox com_xaxislabelangle;
    }
}
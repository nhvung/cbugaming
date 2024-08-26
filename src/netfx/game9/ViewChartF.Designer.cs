
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewChartF));
            this.main_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.but_exporttoimage = new System.Windows.Forms.Button();
            this.but_close = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.but_apply = new System.Windows.Forms.Button();
            this.com_xaxislabel = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.com_yaxislabel = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.but_setbackgroundcolor = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.com_charttitle = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.com_xaxislabelangle = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgv_detail = new System.Windows.Forms.DataGridView();
            this.panel_overview = new System.Windows.Forms.Panel();
            this.sp_panel = new System.Windows.Forms.SplitContainer();
            this.ratio_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.main_chart)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_detail)).BeginInit();
            this.panel_overview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sp_panel)).BeginInit();
            this.sp_panel.Panel1.SuspendLayout();
            this.sp_panel.Panel2.SuspendLayout();
            this.sp_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ratio_chart)).BeginInit();
            this.SuspendLayout();
            // 
            // main_chart
            // 
            this.main_chart.BackColor = System.Drawing.SystemColors.Control;
            this.main_chart.BorderlineColor = System.Drawing.SystemColors.Control;
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisX2.TitleFont = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY2.TitleFont = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.BorderColor = System.Drawing.Color.DimGray;
            chartArea1.Name = "ChartArea1";
            this.main_chart.ChartAreas.Add(chartArea1);
            this.main_chart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.main_chart.Legends.Add(legend1);
            this.main_chart.Location = new System.Drawing.Point(0, 0);
            this.main_chart.Name = "main_chart";
            this.main_chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SemiTransparent;
            this.main_chart.Size = new System.Drawing.Size(584, 284);
            this.main_chart.TabIndex = 0;
            this.main_chart.Text = "chart1";
            // 
            // but_exporttoimage
            // 
            this.but_exporttoimage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.but_exporttoimage.Location = new System.Drawing.Point(361, 752);
            this.but_exporttoimage.Name = "but_exporttoimage";
            this.but_exporttoimage.Size = new System.Drawing.Size(142, 23);
            this.but_exporttoimage.TabIndex = 1;
            this.but_exporttoimage.Text = "Export Image...";
            this.but_exporttoimage.UseVisualStyleBackColor = true;
            this.but_exporttoimage.Click += new System.EventHandler(this.but_exporttoimage_Click);
            // 
            // but_close
            // 
            this.but_close.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.but_close.Location = new System.Drawing.Point(509, 752);
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
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.but_setbackgroundcolor);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.com_charttitle);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.com_xaxislabelangle);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.but_apply);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.com_yaxislabel);
            this.groupBox1.Controls.Add(this.com_xaxislabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 575);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(909, 149);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Custom Configurations";
            // 
            // but_setbackgroundcolor
            // 
            this.but_setbackgroundcolor.Location = new System.Drawing.Point(414, 84);
            this.but_setbackgroundcolor.Name = "but_setbackgroundcolor";
            this.but_setbackgroundcolor.Size = new System.Drawing.Size(221, 23);
            this.but_setbackgroundcolor.TabIndex = 12;
            this.but_setbackgroundcolor.Text = "Set Background Color";
            this.but_setbackgroundcolor.UseVisualStyleBackColor = true;
            this.but_setbackgroundcolor.Click += new System.EventHandler(this.but_setbackgroundcolor_Click);
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
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.sp_panel);
            this.groupBox2.Location = new System.Drawing.Point(9, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(897, 304);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dgv_detail);
            this.groupBox3.Location = new System.Drawing.Point(3, 313);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(903, 241);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            // 
            // dgv_detail
            // 
            this.dgv_detail.AllowUserToAddRows = false;
            this.dgv_detail.AllowUserToDeleteRows = false;
            this.dgv_detail.AllowUserToResizeColumns = false;
            this.dgv_detail.AllowUserToResizeRows = false;
            this.dgv_detail.BackgroundColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_detail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_detail.ColumnHeadersHeight = 30;
            this.dgv_detail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_detail.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_detail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_detail.GridColor = System.Drawing.Color.White;
            this.dgv_detail.Location = new System.Drawing.Point(3, 17);
            this.dgv_detail.Name = "dgv_detail";
            this.dgv_detail.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_detail.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_detail.RowHeadersVisible = false;
            this.dgv_detail.RowTemplate.Height = 30;
            this.dgv_detail.Size = new System.Drawing.Size(897, 221);
            this.dgv_detail.TabIndex = 0;
            // 
            // panel_overview
            // 
            this.panel_overview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_overview.Controls.Add(this.groupBox3);
            this.panel_overview.Controls.Add(this.groupBox2);
            this.panel_overview.Location = new System.Drawing.Point(12, 12);
            this.panel_overview.Name = "panel_overview";
            this.panel_overview.Size = new System.Drawing.Size(909, 557);
            this.panel_overview.TabIndex = 11;
            // 
            // sp_panel
            // 
            this.sp_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sp_panel.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.sp_panel.Location = new System.Drawing.Point(3, 17);
            this.sp_panel.Name = "sp_panel";
            // 
            // sp_panel.Panel1
            // 
            this.sp_panel.Panel1.Controls.Add(this.main_chart);
            // 
            // sp_panel.Panel2
            // 
            this.sp_panel.Panel2.Controls.Add(this.ratio_chart);
            this.sp_panel.Size = new System.Drawing.Size(891, 284);
            this.sp_panel.SplitterDistance = 584;
            this.sp_panel.TabIndex = 1;
            // 
            // ratio_chart
            // 
            chartArea2.Name = "ChartArea1";
            this.ratio_chart.ChartAreas.Add(chartArea2);
            this.ratio_chart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.ratio_chart.Legends.Add(legend2);
            this.ratio_chart.Location = new System.Drawing.Point(0, 0);
            this.ratio_chart.Name = "ratio_chart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.ratio_chart.Series.Add(series1);
            this.ratio_chart.Size = new System.Drawing.Size(303, 284);
            this.ratio_chart.TabIndex = 0;
            this.ratio_chart.Text = "chart1";
            // 
            // ViewChartF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 787);
            this.Controls.Add(this.panel_overview);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.but_close);
            this.Controls.Add(this.but_exporttoimage);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ViewChartF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View Chart";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.main_chart)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_detail)).EndInit();
            this.panel_overview.ResumeLayout(false);
            this.sp_panel.Panel1.ResumeLayout(false);
            this.sp_panel.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sp_panel)).EndInit();
            this.sp_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ratio_chart)).EndInit();
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
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgv_detail;
        private System.Windows.Forms.Panel panel_overview;
        private System.Windows.Forms.Button but_setbackgroundcolor;
        private System.Windows.Forms.SplitContainer sp_panel;
        private System.Windows.Forms.DataVisualization.Charting.Chart ratio_chart;
    }
}
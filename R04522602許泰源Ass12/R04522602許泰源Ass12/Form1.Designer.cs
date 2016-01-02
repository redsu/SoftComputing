namespace R04522602許泰源Ass12
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
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.OpenFile = new System.Windows.Forms.ToolStripButton();
			this.button1 = new System.Windows.Forms.Button();
			this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.toolStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 12;
			this.listBox1.Location = new System.Drawing.Point(203, 28);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(491, 148);
			this.listBox1.TabIndex = 0;
			this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenFile});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(720, 25);
			this.toolStrip1.TabIndex = 1;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// OpenFile
			// 
			this.OpenFile.AccessibleName = "";
			this.OpenFile.Image = ((System.Drawing.Image)(resources.GetObject("OpenFile.Image")));
			this.OpenFile.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.OpenFile.Name = "OpenFile";
			this.OpenFile.Size = new System.Drawing.Size(47, 22);
			this.OpenFile.Text = "File";
			this.OpenFile.Click += new System.EventHandler(this.OpenFile_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(47, 73);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 2;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// chart1
			// 
			chartArea1.Name = "ChartArea1";
			this.chart1.ChartAreas.Add(chartArea1);
			legend1.Name = "Legend1";
			this.chart1.Legends.Add(legend1);
			this.chart1.Location = new System.Drawing.Point(203, 182);
			this.chart1.Name = "chart1";
			series1.ChartArea = "ChartArea1";
			series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series1.Legend = "Legend1";
			series1.Name = "Series1";
			this.chart1.Series.Add(series1);
			this.chart1.Size = new System.Drawing.Size(491, 258);
			this.chart1.TabIndex = 3;
			this.chart1.Text = "chart1";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(720, 463);
			this.Controls.Add(this.chart1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.listBox1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton OpenFile;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
	}
}


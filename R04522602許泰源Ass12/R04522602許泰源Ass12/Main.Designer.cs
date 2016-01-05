namespace R04522602許泰源Ass12
{
	partial class NeuralNetworkSystem
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NeuralNetworkSystem));
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.OpenFile = new System.Windows.Forms.ToolStripButton();
			this.button1 = new System.Windows.Forms.Button();
			this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.NN_system = new System.Windows.Forms.PropertyGrid();
			this.lbl_ein = new System.Windows.Forms.Label();
			this.lbl_eout = new System.Windows.Forms.Label();
			this.btn_ins = new System.Windows.Forms.Button();
			this.num_perc = new System.Windows.Forms.NumericUpDown();
			this.button2 = new System.Windows.Forms.Button();
			this.lbl_err01 = new System.Windows.Forms.Label();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.btn_test = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.lbl_correctness = new System.Windows.Forms.Label();
			this.toolStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.num_perc)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 12;
			this.listBox1.Location = new System.Drawing.Point(168, 6);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(260, 148);
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
			this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
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
			this.button1.Location = new System.Drawing.Point(8, 5);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 2;
			this.button1.Text = "Run";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// chart1
			// 
			this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			chartArea1.Name = "ChartArea1";
			this.chart1.ChartAreas.Add(chartArea1);
			legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
			legend1.Name = "Legend1";
			this.chart1.Legends.Add(legend1);
			this.chart1.Location = new System.Drawing.Point(168, 164);
			this.chart1.Name = "chart1";
			series1.ChartArea = "ChartArea1";
			series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series1.Legend = "Legend1";
			series1.Name = "In-Sample Error";
			series2.ChartArea = "ChartArea1";
			series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series2.Legend = "Legend1";
			series2.Name = "Out-Of-Sample Error";
			this.chart1.Series.Add(series1);
			this.chart1.Series.Add(series2);
			this.chart1.Size = new System.Drawing.Size(491, 237);
			this.chart1.TabIndex = 3;
			this.chart1.Text = "chart1";
			// 
			// NN_system
			// 
			this.NN_system.Location = new System.Drawing.Point(443, 6);
			this.NN_system.Name = "NN_system";
			this.NN_system.Size = new System.Drawing.Size(225, 148);
			this.NN_system.TabIndex = 4;
			// 
			// lbl_ein
			// 
			this.lbl_ein.AutoSize = true;
			this.lbl_ein.Location = new System.Drawing.Point(8, 139);
			this.lbl_ein.Name = "lbl_ein";
			this.lbl_ein.Size = new System.Drawing.Size(30, 12);
			this.lbl_ein.TabIndex = 6;
			this.lbl_ein.Text = "Ein : ";
			this.lbl_ein.Click += new System.EventHandler(this.lbl_ein_Click);
			// 
			// lbl_eout
			// 
			this.lbl_eout.AutoSize = true;
			this.lbl_eout.Location = new System.Drawing.Point(8, 164);
			this.lbl_eout.Name = "lbl_eout";
			this.lbl_eout.Size = new System.Drawing.Size(36, 12);
			this.lbl_eout.TabIndex = 7;
			this.lbl_eout.Text = "Eout : ";
			this.lbl_eout.Click += new System.EventHandler(this.lbl_eout_Click);
			// 
			// btn_ins
			// 
			this.btn_ins.Location = new System.Drawing.Point(8, 63);
			this.btn_ins.Name = "btn_ins";
			this.btn_ins.Size = new System.Drawing.Size(75, 23);
			this.btn_ins.TabIndex = 8;
			this.btn_ins.Text = "Insert";
			this.btn_ins.UseVisualStyleBackColor = true;
			this.btn_ins.Click += new System.EventHandler(this.btn_ins_Click);
			// 
			// num_perc
			// 
			this.num_perc.Location = new System.Drawing.Point(89, 66);
			this.num_perc.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.num_perc.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.num_perc.Name = "num_perc";
			this.num_perc.Size = new System.Drawing.Size(58, 22);
			this.num_perc.TabIndex = 9;
			this.num_perc.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(8, 92);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 10;
			this.button2.Text = "Delete";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// lbl_err01
			// 
			this.lbl_err01.AutoSize = true;
			this.lbl_err01.Location = new System.Drawing.Point(8, 190);
			this.lbl_err01.Name = "lbl_err01";
			this.lbl_err01.Size = new System.Drawing.Size(59, 12);
			this.lbl_err01.TabIndex = 11;
			this.lbl_err01.Text = "Eout(0/1) : ";
			this.lbl_err01.Click += new System.EventHandler(this.lbl_err01_Click);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(0, 28);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(720, 435);
			this.tabControl1.TabIndex = 12;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.NN_system);
			this.tabPage1.Controls.Add(this.num_perc);
			this.tabPage1.Controls.Add(this.chart1);
			this.tabPage1.Controls.Add(this.lbl_err01);
			this.tabPage1.Controls.Add(this.button2);
			this.tabPage1.Controls.Add(this.listBox1);
			this.tabPage1.Controls.Add(this.button1);
			this.tabPage1.Controls.Add(this.lbl_eout);
			this.tabPage1.Controls.Add(this.lbl_ein);
			this.tabPage1.Controls.Add(this.btn_ins);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(712, 409);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "tabPage1";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.lbl_correctness);
			this.tabPage2.Controls.Add(this.btn_test);
			this.tabPage2.Controls.Add(this.dataGridView1);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(712, 409);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "tabPage2";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// btn_test
			// 
			this.btn_test.Location = new System.Drawing.Point(6, 293);
			this.btn_test.Name = "btn_test";
			this.btn_test.Size = new System.Drawing.Size(75, 23);
			this.btn_test.TabIndex = 6;
			this.btn_test.Text = "Test";
			this.btn_test.UseVisualStyleBackColor = true;
			this.btn_test.Click += new System.EventHandler(this.btn_test_Click);
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.AllowUserToResizeColumns = false;
			this.dataGridView1.AllowUserToResizeRows = false;
			this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
			this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(3, 3);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowTemplate.Height = 24;
			this.dataGridView1.Size = new System.Drawing.Size(709, 284);
			this.dataGridView1.TabIndex = 0;
			// 
			// lbl_correctness
			// 
			this.lbl_correctness.AutoSize = true;
			this.lbl_correctness.Location = new System.Drawing.Point(8, 333);
			this.lbl_correctness.Name = "lbl_correctness";
			this.lbl_correctness.Size = new System.Drawing.Size(68, 12);
			this.lbl_correctness.TabIndex = 12;
			this.lbl_correctness.Text = "Correctness : ";
			// 
			// NeuralNetworkSystem
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(720, 463);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.tabControl1);
			this.Name = "NeuralNetworkSystem";
			this.Text = "NeuralNetworkSystem";
			this.Load += new System.EventHandler(this.NeuralNetworkSystem_Load);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.num_perc)).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton OpenFile;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
		private System.Windows.Forms.PropertyGrid NN_system;
		private System.Windows.Forms.Label lbl_ein;
		private System.Windows.Forms.Label lbl_eout;
		private System.Windows.Forms.Button btn_ins;
		private System.Windows.Forms.NumericUpDown num_perc;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label lbl_err01;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Button btn_test;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Label lbl_correctness;
	}
}


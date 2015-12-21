namespace R04522602許泰源Ass10
{
	partial class Main
	{
		/// <summary>
		/// 設計工具所需的變數。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清除任何使用中的資源。
		/// </summary>
		/// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form 設計工具產生的程式碼

		/// <summary>
		/// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
		/// 這個方法的內容。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
			this.sCouter1 = new System.Windows.Forms.SplitContainer();
			this.rtxBenchmark = new System.Windows.Forms.RichTextBox();
			this.lbl_sl = new System.Windows.Forms.Label();
			this.lbl_noc = new System.Windows.Forms.Label();
			this.lbl_title = new System.Windows.Forms.Label();
			this.sCouter2 = new System.Windows.Forms.SplitContainer();
			this.sCouter3 = new System.Windows.Forms.SplitContainer();
			this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.tab_display = new System.Windows.Forms.TabControl();
			this.tab_route = new System.Windows.Forms.TabPage();
			this.tabPhenSol = new System.Windows.Forms.TabPage();
			this.splitContainer5 = new System.Windows.Forms.SplitContainer();
			this.lsbPheromone = new System.Windows.Forms.RichTextBox();
			this.ckbShowPheromone = new System.Windows.Forms.CheckBox();
			this.lsbSolutions = new System.Windows.Forms.RichTextBox();
			this.ckbShowSolutions = new System.Windows.Forms.CheckBox();
			this.sCouter4 = new System.Windows.Forms.SplitContainer();
			this.lbl_sofarslen = new System.Windows.Forms.Label();
			this.lbl_sofarsol = new System.Windows.Forms.Label();
			this.tabHeur = new System.Windows.Forms.TabControl();
			this.tab_ACO = new System.Windows.Forms.TabPage();
			this.btn_createACO = new System.Windows.Forms.Button();
			this.tabGA = new System.Windows.Forms.TabPage();
			this.btn_createGA = new System.Windows.Forms.Button();
			this.updateperiteration = new System.Windows.Forms.CheckBox();
			this.Solver = new System.Windows.Forms.PropertyGrid();
			this.btnEnd = new System.Windows.Forms.Button();
			this.btnExeone = new System.Windows.Forms.Button();
			this.btnReset = new System.Windows.Forms.Button();
			this.pBar = new System.Windows.Forms.ProgressBar();
			this.openfile = new System.Windows.Forms.ToolStrip();
			this.tsbtn_open = new System.Windows.Forms.ToolStripButton();
			this.tip = new System.Windows.Forms.ToolTip(this.components);
			((System.ComponentModel.ISupportInitialize)(this.sCouter1)).BeginInit();
			this.sCouter1.Panel1.SuspendLayout();
			this.sCouter1.Panel2.SuspendLayout();
			this.sCouter1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.sCouter2)).BeginInit();
			this.sCouter2.Panel1.SuspendLayout();
			this.sCouter2.Panel2.SuspendLayout();
			this.sCouter2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.sCouter3)).BeginInit();
			this.sCouter3.Panel1.SuspendLayout();
			this.sCouter3.Panel2.SuspendLayout();
			this.sCouter3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
			this.tab_display.SuspendLayout();
			this.tabPhenSol.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
			this.splitContainer5.Panel1.SuspendLayout();
			this.splitContainer5.Panel2.SuspendLayout();
			this.splitContainer5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.sCouter4)).BeginInit();
			this.sCouter4.Panel1.SuspendLayout();
			this.sCouter4.Panel2.SuspendLayout();
			this.sCouter4.SuspendLayout();
			this.tabHeur.SuspendLayout();
			this.tab_ACO.SuspendLayout();
			this.tabGA.SuspendLayout();
			this.openfile.SuspendLayout();
			this.SuspendLayout();
			// 
			// sCouter1
			// 
			this.sCouter1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.sCouter1.Location = new System.Drawing.Point(0, 28);
			this.sCouter1.Name = "sCouter1";
			// 
			// sCouter1.Panel1
			// 
			this.sCouter1.Panel1.BackColor = System.Drawing.SystemColors.ControlLight;
			this.sCouter1.Panel1.Controls.Add(this.rtxBenchmark);
			this.sCouter1.Panel1.Controls.Add(this.lbl_sl);
			this.sCouter1.Panel1.Controls.Add(this.lbl_noc);
			this.sCouter1.Panel1.Controls.Add(this.lbl_title);
			// 
			// sCouter1.Panel2
			// 
			this.sCouter1.Panel2.Controls.Add(this.sCouter2);
			this.sCouter1.Size = new System.Drawing.Size(1089, 453);
			this.sCouter1.SplitterDistance = 213;
			this.sCouter1.TabIndex = 0;
			// 
			// rtxBenchmark
			// 
			this.rtxBenchmark.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.rtxBenchmark.Location = new System.Drawing.Point(12, 69);
			this.rtxBenchmark.Name = "rtxBenchmark";
			this.rtxBenchmark.ReadOnly = true;
			this.rtxBenchmark.Size = new System.Drawing.Size(189, 380);
			this.rtxBenchmark.TabIndex = 5;
			this.rtxBenchmark.Text = "";
			// 
			// lbl_sl
			// 
			this.lbl_sl.AutoSize = true;
			this.lbl_sl.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.lbl_sl.ForeColor = System.Drawing.Color.Black;
			this.lbl_sl.Location = new System.Drawing.Point(12, 50);
			this.lbl_sl.Name = "lbl_sl";
			this.lbl_sl.Size = new System.Drawing.Size(102, 16);
			this.lbl_sl.TabIndex = 3;
			this.lbl_sl.Text = "Shortest Length :";
			// 
			// lbl_noc
			// 
			this.lbl_noc.AutoSize = true;
			this.lbl_noc.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.lbl_noc.ForeColor = System.Drawing.Color.Black;
			this.lbl_noc.Location = new System.Drawing.Point(12, 31);
			this.lbl_noc.Name = "lbl_noc";
			this.lbl_noc.Size = new System.Drawing.Size(107, 16);
			this.lbl_noc.TabIndex = 2;
			this.lbl_noc.Text = "Number of cities :";
			// 
			// lbl_title
			// 
			this.lbl_title.AutoSize = true;
			this.lbl_title.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.lbl_title.ForeColor = System.Drawing.Color.Black;
			this.lbl_title.Location = new System.Drawing.Point(12, 12);
			this.lbl_title.Name = "lbl_title";
			this.lbl_title.Size = new System.Drawing.Size(38, 16);
			this.lbl_title.TabIndex = 1;
			this.lbl_title.Text = "Title :";
			// 
			// sCouter2
			// 
			this.sCouter2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sCouter2.Location = new System.Drawing.Point(0, 0);
			this.sCouter2.Name = "sCouter2";
			// 
			// sCouter2.Panel1
			// 
			this.sCouter2.Panel1.Controls.Add(this.sCouter3);
			// 
			// sCouter2.Panel2
			// 
			this.sCouter2.Panel2.Controls.Add(this.sCouter4);
			this.sCouter2.Size = new System.Drawing.Size(872, 453);
			this.sCouter2.SplitterDistance = 427;
			this.sCouter2.TabIndex = 0;
			// 
			// sCouter3
			// 
			this.sCouter3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sCouter3.Location = new System.Drawing.Point(0, 0);
			this.sCouter3.Name = "sCouter3";
			this.sCouter3.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// sCouter3.Panel1
			// 
			this.sCouter3.Panel1.BackColor = System.Drawing.SystemColors.ControlLight;
			this.sCouter3.Panel1.Controls.Add(this.chart);
			// 
			// sCouter3.Panel2
			// 
			this.sCouter3.Panel2.BackColor = System.Drawing.SystemColors.ControlLight;
			this.sCouter3.Panel2.Controls.Add(this.tab_display);
			this.sCouter3.Size = new System.Drawing.Size(427, 453);
			this.sCouter3.SplitterDistance = 211;
			this.sCouter3.TabIndex = 0;
			// 
			// chart
			// 
			chartArea1.Name = "ChartArea1";
			this.chart.ChartAreas.Add(chartArea1);
			this.chart.Dock = System.Windows.Forms.DockStyle.Fill;
			legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
			legend1.Name = "Legend1";
			this.chart.Legends.Add(legend1);
			this.chart.Location = new System.Drawing.Point(0, 0);
			this.chart.Name = "chart";
			series1.ChartArea = "ChartArea1";
			series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series1.Legend = "Legend1";
			series1.Name = "Series1";
			series2.ChartArea = "ChartArea1";
			series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series2.Legend = "Legend1";
			series2.Name = "Series2";
			series3.ChartArea = "ChartArea1";
			series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series3.Legend = "Legend1";
			series3.Name = "Series3";
			this.chart.Series.Add(series1);
			this.chart.Series.Add(series2);
			this.chart.Series.Add(series3);
			this.chart.Size = new System.Drawing.Size(427, 211);
			this.chart.TabIndex = 0;
			this.chart.Text = "chart1";
			// 
			// tab_display
			// 
			this.tab_display.Controls.Add(this.tab_route);
			this.tab_display.Controls.Add(this.tabPhenSol);
			this.tab_display.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tab_display.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.tab_display.Location = new System.Drawing.Point(0, 0);
			this.tab_display.Name = "tab_display";
			this.tab_display.SelectedIndex = 0;
			this.tab_display.Size = new System.Drawing.Size(427, 238);
			this.tab_display.TabIndex = 0;
			// 
			// tab_route
			// 
			this.tab_route.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.tab_route.Location = new System.Drawing.Point(4, 26);
			this.tab_route.Name = "tab_route";
			this.tab_route.Padding = new System.Windows.Forms.Padding(3);
			this.tab_route.Size = new System.Drawing.Size(419, 208);
			this.tab_route.TabIndex = 0;
			this.tab_route.Text = "Cities & Routes";
			this.tab_route.UseVisualStyleBackColor = true;
			this.tab_route.Paint += new System.Windows.Forms.PaintEventHandler(this.Draw_Route_and_Vertex);
			// 
			// tabPhenSol
			// 
			this.tabPhenSol.Controls.Add(this.splitContainer5);
			this.tabPhenSol.Location = new System.Drawing.Point(4, 26);
			this.tabPhenSol.Name = "tabPhenSol";
			this.tabPhenSol.Padding = new System.Windows.Forms.Padding(3);
			this.tabPhenSol.Size = new System.Drawing.Size(419, 208);
			this.tabPhenSol.TabIndex = 1;
			this.tabPhenSol.Text = "Pheromone & Solutions";
			this.tabPhenSol.UseVisualStyleBackColor = true;
			// 
			// splitContainer5
			// 
			this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer5.Location = new System.Drawing.Point(3, 3);
			this.splitContainer5.Name = "splitContainer5";
			// 
			// splitContainer5.Panel1
			// 
			this.splitContainer5.Panel1.Controls.Add(this.lsbPheromone);
			this.splitContainer5.Panel1.Controls.Add(this.ckbShowPheromone);
			// 
			// splitContainer5.Panel2
			// 
			this.splitContainer5.Panel2.Controls.Add(this.lsbSolutions);
			this.splitContainer5.Panel2.Controls.Add(this.ckbShowSolutions);
			this.splitContainer5.Size = new System.Drawing.Size(413, 202);
			this.splitContainer5.SplitterDistance = 204;
			this.splitContainer5.TabIndex = 1;
			// 
			// lsbPheromone
			// 
			this.lsbPheromone.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lsbPheromone.Location = new System.Drawing.Point(3, 36);
			this.lsbPheromone.Name = "lsbPheromone";
			this.lsbPheromone.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
			this.lsbPheromone.Size = new System.Drawing.Size(197, 160);
			this.lsbPheromone.TabIndex = 2;
			this.lsbPheromone.Text = "";
			this.lsbPheromone.WordWrap = false;
			// 
			// ckbShowPheromone
			// 
			this.ckbShowPheromone.AutoSize = true;
			this.ckbShowPheromone.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.ckbShowPheromone.ForeColor = System.Drawing.Color.DarkRed;
			this.ckbShowPheromone.Location = new System.Drawing.Point(3, 8);
			this.ckbShowPheromone.Name = "ckbShowPheromone";
			this.ckbShowPheromone.Size = new System.Drawing.Size(136, 21);
			this.ckbShowPheromone.TabIndex = 0;
			this.ckbShowPheromone.Text = "Show Pehromone";
			this.ckbShowPheromone.UseVisualStyleBackColor = true;
			// 
			// lsbSolutions
			// 
			this.lsbSolutions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lsbSolutions.Location = new System.Drawing.Point(3, 36);
			this.lsbSolutions.Name = "lsbSolutions";
			this.lsbSolutions.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
			this.lsbSolutions.Size = new System.Drawing.Size(199, 160);
			this.lsbSolutions.TabIndex = 3;
			this.lsbSolutions.Text = "";
			this.lsbSolutions.WordWrap = false;
			// 
			// ckbShowSolutions
			// 
			this.ckbShowSolutions.AutoSize = true;
			this.ckbShowSolutions.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.ckbShowSolutions.ForeColor = System.Drawing.Color.DarkRed;
			this.ckbShowSolutions.Location = new System.Drawing.Point(3, 8);
			this.ckbShowSolutions.Name = "ckbShowSolutions";
			this.ckbShowSolutions.Size = new System.Drawing.Size(124, 21);
			this.ckbShowSolutions.TabIndex = 0;
			this.ckbShowSolutions.Text = "Show Solutions";
			this.ckbShowSolutions.UseVisualStyleBackColor = true;
			// 
			// sCouter4
			// 
			this.sCouter4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sCouter4.Location = new System.Drawing.Point(0, 0);
			this.sCouter4.Name = "sCouter4";
			this.sCouter4.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// sCouter4.Panel1
			// 
			this.sCouter4.Panel1.BackColor = System.Drawing.SystemColors.ControlLight;
			this.sCouter4.Panel1.Controls.Add(this.lbl_sofarslen);
			this.sCouter4.Panel1.Controls.Add(this.lbl_sofarsol);
			this.sCouter4.Panel1.Controls.Add(this.tabHeur);
			// 
			// sCouter4.Panel2
			// 
			this.sCouter4.Panel2.BackColor = System.Drawing.SystemColors.ControlLight;
			this.sCouter4.Panel2.Controls.Add(this.updateperiteration);
			this.sCouter4.Panel2.Controls.Add(this.Solver);
			this.sCouter4.Panel2.Controls.Add(this.btnEnd);
			this.sCouter4.Panel2.Controls.Add(this.btnExeone);
			this.sCouter4.Panel2.Controls.Add(this.btnReset);
			this.sCouter4.Size = new System.Drawing.Size(441, 453);
			this.sCouter4.SplitterDistance = 186;
			this.sCouter4.TabIndex = 0;
			// 
			// lbl_sofarslen
			// 
			this.lbl_sofarslen.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.lbl_sofarslen.ForeColor = System.Drawing.Color.DarkGreen;
			this.lbl_sofarslen.Location = new System.Drawing.Point(5, 94);
			this.lbl_sofarslen.Name = "lbl_sofarslen";
			this.lbl_sofarslen.Size = new System.Drawing.Size(433, 25);
			this.lbl_sofarslen.TabIndex = 4;
			this.lbl_sofarslen.Text = "So Far The Best Solution : (NONE)";
			// 
			// lbl_sofarsol
			// 
			this.lbl_sofarsol.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.lbl_sofarsol.ForeColor = System.Drawing.Color.DarkGreen;
			this.lbl_sofarsol.Location = new System.Drawing.Point(5, 119);
			this.lbl_sofarsol.Name = "lbl_sofarsol";
			this.lbl_sofarsol.Size = new System.Drawing.Size(433, 76);
			this.lbl_sofarsol.TabIndex = 3;
			this.lbl_sofarsol.Text = "So Far The Best Objective : (NONE)";
			// 
			// tabHeur
			// 
			this.tabHeur.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabHeur.Controls.Add(this.tab_ACO);
			this.tabHeur.Controls.Add(this.tabGA);
			this.tabHeur.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.tabHeur.Location = new System.Drawing.Point(3, 3);
			this.tabHeur.Name = "tabHeur";
			this.tabHeur.SelectedIndex = 0;
			this.tabHeur.Size = new System.Drawing.Size(435, 76);
			this.tabHeur.TabIndex = 1;
			this.tabHeur.SelectedIndexChanged += new System.EventHandler(this.tabHeur_SelectedIndexChanged);
			// 
			// tab_ACO
			// 
			this.tab_ACO.Controls.Add(this.btn_createACO);
			this.tab_ACO.Location = new System.Drawing.Point(4, 26);
			this.tab_ACO.Name = "tab_ACO";
			this.tab_ACO.Padding = new System.Windows.Forms.Padding(3);
			this.tab_ACO.Size = new System.Drawing.Size(427, 46);
			this.tab_ACO.TabIndex = 0;
			this.tab_ACO.Text = "ACO Algorithm";
			this.tab_ACO.UseVisualStyleBackColor = true;
			// 
			// btn_createACO
			// 
			this.btn_createACO.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.btn_createACO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_createACO.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.btn_createACO.ForeColor = System.Drawing.Color.DarkBlue;
			this.btn_createACO.Location = new System.Drawing.Point(6, 6);
			this.btn_createACO.Name = "btn_createACO";
			this.btn_createACO.Size = new System.Drawing.Size(149, 35);
			this.btn_createACO.TabIndex = 1;
			this.btn_createACO.Text = "Create ACO Solver";
			this.btn_createACO.UseVisualStyleBackColor = false;
			this.btn_createACO.Click += new System.EventHandler(this.btn_createACO_Click);
			// 
			// tabGA
			// 
			this.tabGA.Controls.Add(this.btn_createGA);
			this.tabGA.Location = new System.Drawing.Point(4, 22);
			this.tabGA.Name = "tabGA";
			this.tabGA.Padding = new System.Windows.Forms.Padding(3);
			this.tabGA.Size = new System.Drawing.Size(427, 50);
			this.tabGA.TabIndex = 1;
			this.tabGA.Text = "Genetic Algorithm";
			this.tabGA.UseVisualStyleBackColor = true;
			// 
			// btn_createGA
			// 
			this.btn_createGA.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.btn_createGA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_createGA.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.btn_createGA.ForeColor = System.Drawing.Color.DarkBlue;
			this.btn_createGA.Location = new System.Drawing.Point(6, 6);
			this.btn_createGA.Name = "btn_createGA";
			this.btn_createGA.Size = new System.Drawing.Size(149, 35);
			this.btn_createGA.TabIndex = 2;
			this.btn_createGA.Text = "Create GA Solver";
			this.btn_createGA.UseVisualStyleBackColor = false;
			this.btn_createGA.Click += new System.EventHandler(this.btn_createGA_Click);
			// 
			// updateperiteration
			// 
			this.updateperiteration.AutoSize = true;
			this.updateperiteration.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.updateperiteration.ForeColor = System.Drawing.Color.DarkRed;
			this.updateperiteration.Location = new System.Drawing.Point(7, 115);
			this.updateperiteration.Name = "updateperiteration";
			this.updateperiteration.Size = new System.Drawing.Size(151, 21);
			this.updateperiteration.TabIndex = 7;
			this.updateperiteration.Text = "Update Per Iteration";
			this.updateperiteration.UseVisualStyleBackColor = true;
			// 
			// Solver
			// 
			this.Solver.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.Solver.Location = new System.Drawing.Point(175, 3);
			this.Solver.Name = "Solver";
			this.Solver.Size = new System.Drawing.Size(265, 267);
			this.Solver.TabIndex = 6;
			// 
			// btnEnd
			// 
			this.btnEnd.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.btnEnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnEnd.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.btnEnd.ForeColor = System.Drawing.Color.DarkBlue;
			this.btnEnd.Location = new System.Drawing.Point(7, 76);
			this.btnEnd.Name = "btnEnd";
			this.btnEnd.Size = new System.Drawing.Size(155, 23);
			this.btnEnd.TabIndex = 4;
			this.btnEnd.Text = "Run To End";
			this.btnEnd.UseVisualStyleBackColor = false;
			this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
			// 
			// btnExeone
			// 
			this.btnExeone.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.btnExeone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnExeone.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.btnExeone.ForeColor = System.Drawing.Color.DarkBlue;
			this.btnExeone.Location = new System.Drawing.Point(7, 47);
			this.btnExeone.Name = "btnExeone";
			this.btnExeone.Size = new System.Drawing.Size(155, 23);
			this.btnExeone.TabIndex = 3;
			this.btnExeone.Text = "Execute One Iteration";
			this.btnExeone.UseVisualStyleBackColor = false;
			this.btnExeone.Click += new System.EventHandler(this.btnExeone_Click);
			// 
			// btnReset
			// 
			this.btnReset.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnReset.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.btnReset.ForeColor = System.Drawing.Color.DarkBlue;
			this.btnReset.Location = new System.Drawing.Point(7, 18);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(155, 23);
			this.btnReset.TabIndex = 2;
			this.btnReset.Text = "Reset";
			this.btnReset.UseVisualStyleBackColor = false;
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			// 
			// pBar
			// 
			this.pBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pBar.Location = new System.Drawing.Point(0, 487);
			this.pBar.Name = "pBar";
			this.pBar.Size = new System.Drawing.Size(1089, 23);
			this.pBar.TabIndex = 6;
			// 
			// openfile
			// 
			this.openfile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtn_open});
			this.openfile.Location = new System.Drawing.Point(0, 0);
			this.openfile.Name = "openfile";
			this.openfile.Size = new System.Drawing.Size(1089, 25);
			this.openfile.TabIndex = 1;
			this.openfile.Text = "toolStrip1";
			// 
			// tsbtn_open
			// 
			this.tsbtn_open.Image = ((System.Drawing.Image)(resources.GetObject("tsbtn_open.Image")));
			this.tsbtn_open.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtn_open.Name = "tsbtn_open";
			this.tsbtn_open.Size = new System.Drawing.Size(79, 22);
			this.tsbtn_open.Text = "OpenFile";
			this.tsbtn_open.Click += new System.EventHandler(this.import_btn_Click);
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.LightBlue;
			this.ClientSize = new System.Drawing.Size(1089, 507);
			this.Controls.Add(this.pBar);
			this.Controls.Add(this.openfile);
			this.Controls.Add(this.sCouter1);
			this.Name = "Main";
			this.Text = "Job Assignment Problem Solver";
			this.sCouter1.Panel1.ResumeLayout(false);
			this.sCouter1.Panel1.PerformLayout();
			this.sCouter1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.sCouter1)).EndInit();
			this.sCouter1.ResumeLayout(false);
			this.sCouter2.Panel1.ResumeLayout(false);
			this.sCouter2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.sCouter2)).EndInit();
			this.sCouter2.ResumeLayout(false);
			this.sCouter3.Panel1.ResumeLayout(false);
			this.sCouter3.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.sCouter3)).EndInit();
			this.sCouter3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
			this.tab_display.ResumeLayout(false);
			this.tabPhenSol.ResumeLayout(false);
			this.splitContainer5.Panel1.ResumeLayout(false);
			this.splitContainer5.Panel1.PerformLayout();
			this.splitContainer5.Panel2.ResumeLayout(false);
			this.splitContainer5.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
			this.splitContainer5.ResumeLayout(false);
			this.sCouter4.Panel1.ResumeLayout(false);
			this.sCouter4.Panel2.ResumeLayout(false);
			this.sCouter4.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.sCouter4)).EndInit();
			this.sCouter4.ResumeLayout(false);
			this.tabHeur.ResumeLayout(false);
			this.tab_ACO.ResumeLayout(false);
			this.tabGA.ResumeLayout(false);
			this.openfile.ResumeLayout(false);
			this.openfile.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.SplitContainer sCouter1;
		private System.Windows.Forms.ToolStrip openfile;
		private System.Windows.Forms.Label lbl_sl;
		private System.Windows.Forms.Label lbl_noc;
		private System.Windows.Forms.Label lbl_title;
		private System.Windows.Forms.SplitContainer sCouter2;
		private System.Windows.Forms.SplitContainer sCouter3;
		private System.Windows.Forms.DataVisualization.Charting.Chart chart;
		private System.Windows.Forms.TabPage tab_route;
		private System.Windows.Forms.TabPage tabPhenSol;
		private System.Windows.Forms.SplitContainer splitContainer5;
		private System.Windows.Forms.RichTextBox lsbPheromone;
		private System.Windows.Forms.CheckBox ckbShowPheromone;
		private System.Windows.Forms.RichTextBox lsbSolutions;
		private System.Windows.Forms.CheckBox ckbShowSolutions;
		private System.Windows.Forms.SplitContainer sCouter4;
		private System.Windows.Forms.Label lbl_sofarslen;
		private System.Windows.Forms.Label lbl_sofarsol;
		private System.Windows.Forms.TabControl tabHeur;
		private System.Windows.Forms.TabPage tab_ACO;
		private System.Windows.Forms.Button btn_createACO;
		private System.Windows.Forms.TabPage tabGA;
		private System.Windows.Forms.PropertyGrid Solver;
		private System.Windows.Forms.Button btnEnd;
		private System.Windows.Forms.Button btnExeone;
		private System.Windows.Forms.Button btnReset;
		private System.Windows.Forms.ToolStripButton tsbtn_open;
		private System.Windows.Forms.RichTextBox rtxBenchmark;
		private System.Windows.Forms.ProgressBar pBar;
		private System.Windows.Forms.Button btn_createGA;
		private System.Windows.Forms.CheckBox updateperiteration;
		private System.Windows.Forms.ToolTip tip;
		private System.Windows.Forms.TabControl tab_display;

	}
}


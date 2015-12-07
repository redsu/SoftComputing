namespace R04522602許泰源Ass08
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
			this.import_btn = new System.Windows.Forms.Button();
			this.tab = new System.Windows.Forms.TabControl();
			this.bf_pg = new System.Windows.Forms.TabPage();
			this.show_chk = new System.Windows.Forms.CheckBox();
			this.recursive_type = new System.Windows.Forms.ComboBox();
			this.timer = new System.Windows.Forms.TextBox();
			this.BSset = new System.Windows.Forms.Label();
			this.BSlbl = new System.Windows.Forms.Label();
			this.BOval = new System.Windows.Forms.Label();
			this.BOlbl = new System.Windows.Forms.Label();
			this.result_list = new System.Windows.Forms.ListBox();
			this.slv_btn = new System.Windows.Forms.Button();
			this.ga_pg = new System.Windows.Forms.TabPage();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.tabGA = new System.Windows.Forms.TabControl();
			this.BinGA = new System.Windows.Forms.TabPage();
			this.constrain = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.textpenalty = new System.Windows.Forms.TextBox();
			this.btnCreateBinGA = new System.Windows.Forms.Button();
			this.BOGA = new System.Windows.Forms.Label();
			this.GAsol_lbl = new System.Windows.Forms.Label();
			this.GAobj_lbl = new System.Windows.Forms.Label();
			this.BSGA = new System.Windows.Forms.Label();
			this.PermGA = new System.Windows.Forms.TabPage();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.btnCreatePerGA = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.PGAsol_lbl = new System.Windows.Forms.Label();
			this.PGAobj_lbl = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.chartGA = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.iterend = new System.Windows.Forms.Button();
			this.iterone = new System.Windows.Forms.Button();
			this.buttonReset = new System.Windows.Forms.Button();
			this.Solver = new System.Windows.Forms.PropertyGrid();
			this.data = new System.Windows.Forms.DataGridView();
			this.NOJ_lbl = new System.Windows.Forms.Label();
			this.noj_num = new System.Windows.Forms.Label();
			this.TM_lbl = new System.Windows.Forms.Label();
			this.tip = new System.Windows.Forms.ToolTip(this.components);
			this.tip1 = new System.Windows.Forms.ToolTip(this.components);
			this.constrains = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.tab.SuspendLayout();
			this.bf_pg.SuspendLayout();
			this.ga_pg.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			this.tabGA.SuspendLayout();
			this.BinGA.SuspendLayout();
			this.PermGA.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.chartGA)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.data)).BeginInit();
			this.SuspendLayout();
			// 
			// import_btn
			// 
			this.import_btn.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.import_btn.ForeColor = System.Drawing.Color.Green;
			this.import_btn.Location = new System.Drawing.Point(12, 12);
			this.import_btn.Name = "import_btn";
			this.import_btn.Size = new System.Drawing.Size(142, 31);
			this.import_btn.TabIndex = 1;
			this.import_btn.Text = "Import File";
			this.import_btn.UseVisualStyleBackColor = true;
			this.import_btn.Click += new System.EventHandler(this.import_btn_Click);
			this.import_btn.MouseHover += new System.EventHandler(this.import_btn_MouseHover);
			// 
			// tab
			// 
			this.tab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tab.Controls.Add(this.bf_pg);
			this.tab.Controls.Add(this.ga_pg);
			this.tab.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tab.Location = new System.Drawing.Point(306, 12);
			this.tab.Name = "tab";
			this.tab.SelectedIndex = 0;
			this.tab.Size = new System.Drawing.Size(779, 567);
			this.tab.TabIndex = 1;
			// 
			// bf_pg
			// 
			this.bf_pg.BackColor = System.Drawing.Color.Lavender;
			this.bf_pg.Controls.Add(this.show_chk);
			this.bf_pg.Controls.Add(this.recursive_type);
			this.bf_pg.Controls.Add(this.timer);
			this.bf_pg.Controls.Add(this.BSset);
			this.bf_pg.Controls.Add(this.BSlbl);
			this.bf_pg.Controls.Add(this.BOval);
			this.bf_pg.Controls.Add(this.BOlbl);
			this.bf_pg.Controls.Add(this.result_list);
			this.bf_pg.Controls.Add(this.slv_btn);
			this.bf_pg.Location = new System.Drawing.Point(4, 28);
			this.bf_pg.Name = "bf_pg";
			this.bf_pg.Padding = new System.Windows.Forms.Padding(3);
			this.bf_pg.Size = new System.Drawing.Size(771, 535);
			this.bf_pg.TabIndex = 0;
			this.bf_pg.Text = "Brute Force";
			// 
			// show_chk
			// 
			this.show_chk.AutoSize = true;
			this.show_chk.Location = new System.Drawing.Point(582, 68);
			this.show_chk.Name = "show_chk";
			this.show_chk.Size = new System.Drawing.Size(146, 23);
			this.show_chk.TabIndex = 15;
			this.show_chk.Text = "Show All Solutions";
			this.show_chk.UseVisualStyleBackColor = true;
			// 
			// recursive_type
			// 
			this.recursive_type.DisplayMember = "0";
			this.recursive_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.recursive_type.FormattingEnabled = true;
			this.recursive_type.Items.AddRange(new object[] {
            "Permutation",
            "FastPermutation",
            "TurboPermutation"});
			this.recursive_type.Location = new System.Drawing.Point(410, 66);
			this.recursive_type.Name = "recursive_type";
			this.recursive_type.Size = new System.Drawing.Size(162, 27);
			this.recursive_type.TabIndex = 14;
			this.recursive_type.SelectedIndexChanged += new System.EventHandler(this.recursive_type_SelectedIndexChanged);
			// 
			// timer
			// 
			this.timer.Location = new System.Drawing.Point(154, 66);
			this.timer.Name = "timer";
			this.timer.Size = new System.Drawing.Size(250, 27);
			this.timer.TabIndex = 13;
			// 
			// BSset
			// 
			this.BSset.AutoSize = true;
			this.BSset.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BSset.Location = new System.Drawing.Point(313, 19);
			this.BSset.Name = "BSset";
			this.BSset.Size = new System.Drawing.Size(58, 19);
			this.BSset.TabIndex = 7;
			this.BSset.Text = "(NONE)";
			// 
			// BSlbl
			// 
			this.BSlbl.AutoSize = true;
			this.BSlbl.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BSlbl.Location = new System.Drawing.Point(209, 19);
			this.BSlbl.Name = "BSlbl";
			this.BSlbl.Size = new System.Drawing.Size(98, 19);
			this.BSlbl.TabIndex = 6;
			this.BSlbl.Text = "Best Solution:";
			// 
			// BOval
			// 
			this.BOval.AutoSize = true;
			this.BOval.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BOval.Location = new System.Drawing.Point(120, 19);
			this.BOval.Name = "BOval";
			this.BOval.Size = new System.Drawing.Size(58, 19);
			this.BOval.TabIndex = 5;
			this.BOval.Text = "(NONE)";
			// 
			// BOlbl
			// 
			this.BOlbl.AutoSize = true;
			this.BOlbl.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BOlbl.Location = new System.Drawing.Point(6, 19);
			this.BOlbl.Name = "BOlbl";
			this.BOlbl.Size = new System.Drawing.Size(108, 19);
			this.BOlbl.TabIndex = 4;
			this.BOlbl.Text = "Best Objective:";
			// 
			// result_list
			// 
			this.result_list.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.result_list.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.result_list.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.result_list.FormattingEnabled = true;
			this.result_list.ItemHeight = 19;
			this.result_list.Location = new System.Drawing.Point(3, 107);
			this.result_list.Name = "result_list";
			this.result_list.Size = new System.Drawing.Size(677, 418);
			this.result_list.TabIndex = 3;
			// 
			// slv_btn
			// 
			this.slv_btn.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.slv_btn.ForeColor = System.Drawing.Color.Navy;
			this.slv_btn.Location = new System.Drawing.Point(6, 63);
			this.slv_btn.Name = "slv_btn";
			this.slv_btn.Size = new System.Drawing.Size(142, 31);
			this.slv_btn.TabIndex = 12;
			this.slv_btn.Text = "Solve";
			this.slv_btn.UseVisualStyleBackColor = true;
			this.slv_btn.Click += new System.EventHandler(this.slv_btn_Click);
			// 
			// ga_pg
			// 
			this.ga_pg.BackColor = System.Drawing.Color.GhostWhite;
			this.ga_pg.Controls.Add(this.splitContainer1);
			this.ga_pg.Location = new System.Drawing.Point(4, 28);
			this.ga_pg.Name = "ga_pg";
			this.ga_pg.Padding = new System.Windows.Forms.Padding(3);
			this.ga_pg.Size = new System.Drawing.Size(771, 535);
			this.ga_pg.TabIndex = 1;
			this.ga_pg.Text = "Genetic Algorithm";
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(3, 3);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.BackColor = System.Drawing.Color.Lavender;
			this.splitContainer1.Panel2.Controls.Add(this.iterend);
			this.splitContainer1.Panel2.Controls.Add(this.iterone);
			this.splitContainer1.Panel2.Controls.Add(this.buttonReset);
			this.splitContainer1.Panel2.Controls.Add(this.Solver);
			this.splitContainer1.Size = new System.Drawing.Size(765, 529);
			this.splitContainer1.SplitterDistance = 498;
			this.splitContainer1.TabIndex = 16;
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.BackColor = System.Drawing.Color.Lavender;
			this.splitContainer2.Panel1.Controls.Add(this.tabGA);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.chartGA);
			this.splitContainer2.Size = new System.Drawing.Size(498, 529);
			this.splitContainer2.SplitterDistance = 268;
			this.splitContainer2.TabIndex = 0;
			// 
			// tabGA
			// 
			this.tabGA.Controls.Add(this.BinGA);
			this.tabGA.Controls.Add(this.PermGA);
			this.tabGA.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabGA.Location = new System.Drawing.Point(0, 0);
			this.tabGA.Name = "tabGA";
			this.tabGA.SelectedIndex = 0;
			this.tabGA.Size = new System.Drawing.Size(498, 268);
			this.tabGA.TabIndex = 17;
			this.tabGA.SelectedIndexChanged += new System.EventHandler(this.tabGA_SelectedIndexChanged);
			// 
			// BinGA
			// 
			this.BinGA.Controls.Add(this.label2);
			this.BinGA.Controls.Add(this.constrains);
			this.BinGA.Controls.Add(this.constrain);
			this.BinGA.Controls.Add(this.label1);
			this.BinGA.Controls.Add(this.textpenalty);
			this.BinGA.Controls.Add(this.btnCreateBinGA);
			this.BinGA.Controls.Add(this.BOGA);
			this.BinGA.Controls.Add(this.GAsol_lbl);
			this.BinGA.Controls.Add(this.GAobj_lbl);
			this.BinGA.Controls.Add(this.BSGA);
			this.BinGA.Location = new System.Drawing.Point(4, 28);
			this.BinGA.Name = "BinGA";
			this.BinGA.Padding = new System.Windows.Forms.Padding(3);
			this.BinGA.Size = new System.Drawing.Size(490, 236);
			this.BinGA.TabIndex = 0;
			this.BinGA.Text = "Binary GA";
			this.BinGA.UseVisualStyleBackColor = true;
			// 
			// constrain
			// 
			this.constrain.AutoSize = true;
			this.constrain.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.constrain.Location = new System.Drawing.Point(399, 156);
			this.constrain.Name = "constrain";
			this.constrain.Size = new System.Drawing.Size(58, 19);
			this.constrain.TabIndex = 16;
			this.constrain.Text = "(NONE)";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(338, 65);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(101, 19);
			this.label1.TabIndex = 15;
			this.label1.Text = "Penalty Value:";
			// 
			// textpenalty
			// 
			this.textpenalty.Location = new System.Drawing.Point(342, 88);
			this.textpenalty.Name = "textpenalty";
			this.textpenalty.Size = new System.Drawing.Size(142, 27);
			this.textpenalty.TabIndex = 14;
			this.textpenalty.Text = "100.0";
			this.textpenalty.TextChanged += new System.EventHandler(this.textpenalty_TextChanged);
			// 
			// btnCreateBinGA
			// 
			this.btnCreateBinGA.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCreateBinGA.ForeColor = System.Drawing.Color.MidnightBlue;
			this.btnCreateBinGA.Location = new System.Drawing.Point(342, 6);
			this.btnCreateBinGA.Name = "btnCreateBinGA";
			this.btnCreateBinGA.Size = new System.Drawing.Size(142, 56);
			this.btnCreateBinGA.TabIndex = 5;
			this.btnCreateBinGA.Text = "Create Binary GA";
			this.btnCreateBinGA.UseVisualStyleBackColor = true;
			this.btnCreateBinGA.Click += new System.EventHandler(this.btnCreateBinGA_Click);
			// 
			// BOGA
			// 
			this.BOGA.AutoSize = true;
			this.BOGA.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BOGA.Location = new System.Drawing.Point(6, 19);
			this.BOGA.Name = "BOGA";
			this.BOGA.Size = new System.Drawing.Size(108, 19);
			this.BOGA.TabIndex = 8;
			this.BOGA.Text = "Best Objective:";
			// 
			// GAsol_lbl
			// 
			this.GAsol_lbl.AutoSize = true;
			this.GAsol_lbl.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.GAsol_lbl.Location = new System.Drawing.Point(120, 52);
			this.GAsol_lbl.Name = "GAsol_lbl";
			this.GAsol_lbl.Size = new System.Drawing.Size(46, 15);
			this.GAsol_lbl.TabIndex = 11;
			this.GAsol_lbl.Text = "(NONE)";
			// 
			// GAobj_lbl
			// 
			this.GAobj_lbl.AutoSize = true;
			this.GAobj_lbl.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.GAobj_lbl.Location = new System.Drawing.Point(120, 23);
			this.GAobj_lbl.Name = "GAobj_lbl";
			this.GAobj_lbl.Size = new System.Drawing.Size(46, 15);
			this.GAobj_lbl.TabIndex = 9;
			this.GAobj_lbl.Text = "(NONE)";
			// 
			// BSGA
			// 
			this.BSGA.AutoSize = true;
			this.BSGA.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BSGA.Location = new System.Drawing.Point(6, 49);
			this.BSGA.Name = "BSGA";
			this.BSGA.Size = new System.Drawing.Size(98, 19);
			this.BSGA.TabIndex = 10;
			this.BSGA.Text = "Best Solution:";
			// 
			// PermGA
			// 
			this.PermGA.Controls.Add(this.label3);
			this.PermGA.Controls.Add(this.textBox2);
			this.PermGA.Controls.Add(this.btnCreatePerGA);
			this.PermGA.Controls.Add(this.label4);
			this.PermGA.Controls.Add(this.PGAsol_lbl);
			this.PermGA.Controls.Add(this.PGAobj_lbl);
			this.PermGA.Controls.Add(this.label7);
			this.PermGA.Location = new System.Drawing.Point(4, 28);
			this.PermGA.Name = "PermGA";
			this.PermGA.Padding = new System.Windows.Forms.Padding(3);
			this.PermGA.Size = new System.Drawing.Size(490, 236);
			this.PermGA.TabIndex = 1;
			this.PermGA.Text = "Permutation GA";
			this.PermGA.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(338, 65);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(101, 19);
			this.label3.TabIndex = 23;
			this.label3.Text = "Penalty Value:";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(342, 88);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(142, 27);
			this.textBox2.TabIndex = 22;
			this.textBox2.Text = "100.0";
			// 
			// btnCreatePerGA
			// 
			this.btnCreatePerGA.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCreatePerGA.ForeColor = System.Drawing.Color.MidnightBlue;
			this.btnCreatePerGA.Location = new System.Drawing.Point(342, 6);
			this.btnCreatePerGA.Name = "btnCreatePerGA";
			this.btnCreatePerGA.Size = new System.Drawing.Size(142, 56);
			this.btnCreatePerGA.TabIndex = 17;
			this.btnCreatePerGA.Text = "Create Permutation GA";
			this.btnCreatePerGA.UseVisualStyleBackColor = true;
			this.btnCreatePerGA.Click += new System.EventHandler(this.btnCreatePerGA_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(6, 19);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(108, 19);
			this.label4.TabIndex = 18;
			this.label4.Text = "Best Objective:";
			// 
			// PGAsol_lbl
			// 
			this.PGAsol_lbl.AutoSize = true;
			this.PGAsol_lbl.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PGAsol_lbl.Location = new System.Drawing.Point(120, 52);
			this.PGAsol_lbl.Name = "PGAsol_lbl";
			this.PGAsol_lbl.Size = new System.Drawing.Size(46, 15);
			this.PGAsol_lbl.TabIndex = 21;
			this.PGAsol_lbl.Text = "(NONE)";
			// 
			// PGAobj_lbl
			// 
			this.PGAobj_lbl.AutoSize = true;
			this.PGAobj_lbl.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PGAobj_lbl.Location = new System.Drawing.Point(120, 23);
			this.PGAobj_lbl.Name = "PGAobj_lbl";
			this.PGAobj_lbl.Size = new System.Drawing.Size(46, 15);
			this.PGAobj_lbl.TabIndex = 19;
			this.PGAobj_lbl.Text = "(NONE)";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(6, 49);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(98, 19);
			this.label7.TabIndex = 20;
			this.label7.Text = "Best Solution:";
			// 
			// chartGA
			// 
			this.chartGA.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.chartGA.BackColor = System.Drawing.Color.Lavender;
			chartArea1.Name = "ChartArea1";
			this.chartGA.ChartAreas.Add(chartArea1);
			legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
			legend1.Name = "Legend1";
			this.chartGA.Legends.Add(legend1);
			this.chartGA.Location = new System.Drawing.Point(0, -2);
			this.chartGA.Name = "chartGA";
			series1.ChartArea = "ChartArea1";
			series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series1.Legend = "Legend1";
			series1.Name = "Iteration Average";
			series2.ChartArea = "ChartArea1";
			series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series2.Legend = "Legend1";
			series2.Name = "Iteration Best";
			series3.ChartArea = "ChartArea1";
			series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series3.Legend = "Legend1";
			series3.Name = "So Far The Best";
			this.chartGA.Series.Add(series1);
			this.chartGA.Series.Add(series2);
			this.chartGA.Series.Add(series3);
			this.chartGA.Size = new System.Drawing.Size(498, 259);
			this.chartGA.TabIndex = 0;
			this.chartGA.Text = "ChartGA";
			// 
			// iterend
			// 
			this.iterend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.iterend.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.iterend.ForeColor = System.Drawing.Color.MidnightBlue;
			this.iterend.Location = new System.Drawing.Point(3, 87);
			this.iterend.Name = "iterend";
			this.iterend.Size = new System.Drawing.Size(257, 31);
			this.iterend.TabIndex = 4;
			this.iterend.Text = "Run To End";
			this.iterend.UseVisualStyleBackColor = true;
			this.iterend.Click += new System.EventHandler(this.iterend_Click);
			// 
			// iterone
			// 
			this.iterone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.iterone.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.iterone.ForeColor = System.Drawing.Color.MidnightBlue;
			this.iterone.Location = new System.Drawing.Point(3, 50);
			this.iterone.Name = "iterone";
			this.iterone.Size = new System.Drawing.Size(257, 31);
			this.iterone.TabIndex = 3;
			this.iterone.Text = "Run One Iteration";
			this.iterone.UseVisualStyleBackColor = true;
			this.iterone.Click += new System.EventHandler(this.iterone_Click);
			// 
			// buttonReset
			// 
			this.buttonReset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonReset.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonReset.ForeColor = System.Drawing.Color.MidnightBlue;
			this.buttonReset.Location = new System.Drawing.Point(3, 13);
			this.buttonReset.Name = "buttonReset";
			this.buttonReset.Size = new System.Drawing.Size(257, 31);
			this.buttonReset.TabIndex = 2;
			this.buttonReset.Text = "Reset";
			this.buttonReset.UseVisualStyleBackColor = true;
			this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
			// 
			// Solver
			// 
			this.Solver.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.Solver.CategoryForeColor = System.Drawing.SystemColors.InactiveCaptionText;
			this.Solver.Location = new System.Drawing.Point(3, 134);
			this.Solver.Name = "Solver";
			this.Solver.Size = new System.Drawing.Size(256, 392);
			this.Solver.TabIndex = 0;
			// 
			// data
			// 
			this.data.AllowUserToAddRows = false;
			this.data.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.data.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
			this.data.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.data.Location = new System.Drawing.Point(12, 115);
			this.data.Name = "data";
			this.data.RowTemplate.Height = 24;
			this.data.Size = new System.Drawing.Size(288, 464);
			this.data.TabIndex = 8;
			// 
			// NOJ_lbl
			// 
			this.NOJ_lbl.AutoSize = true;
			this.NOJ_lbl.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.NOJ_lbl.ForeColor = System.Drawing.Color.Blue;
			this.NOJ_lbl.Location = new System.Drawing.Point(12, 59);
			this.NOJ_lbl.Name = "NOJ_lbl";
			this.NOJ_lbl.Size = new System.Drawing.Size(113, 19);
			this.NOJ_lbl.TabIndex = 9;
			this.NOJ_lbl.Text = "Number of Jobs:";
			// 
			// noj_num
			// 
			this.noj_num.AutoSize = true;
			this.noj_num.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.noj_num.ForeColor = System.Drawing.Color.Blue;
			this.noj_num.Location = new System.Drawing.Point(131, 59);
			this.noj_num.Name = "noj_num";
			this.noj_num.Size = new System.Drawing.Size(17, 19);
			this.noj_num.TabIndex = 10;
			this.noj_num.Text = "0";
			// 
			// TM_lbl
			// 
			this.TM_lbl.AutoSize = true;
			this.TM_lbl.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TM_lbl.Location = new System.Drawing.Point(12, 90);
			this.TM_lbl.Name = "TM_lbl";
			this.TM_lbl.Size = new System.Drawing.Size(91, 19);
			this.TM_lbl.TabIndex = 11;
			this.TM_lbl.Text = "Time Matrix:";
			// 
			// constrains
			// 
			this.constrains.AutoSize = true;
			this.constrains.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.constrains.Location = new System.Drawing.Point(338, 127);
			this.constrains.Name = "constrains";
			this.constrains.Size = new System.Drawing.Size(133, 19);
			this.constrains.TabIndex = 17;
			this.constrains.Text = "Constrain Violation";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(338, 156);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(55, 19);
			this.label2.TabIndex = 18;
			this.label2.Text = "Count :";
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.LightGray;
			this.ClientSize = new System.Drawing.Size(1089, 586);
			this.Controls.Add(this.TM_lbl);
			this.Controls.Add(this.noj_num);
			this.Controls.Add(this.NOJ_lbl);
			this.Controls.Add(this.data);
			this.Controls.Add(this.tab);
			this.Controls.Add(this.import_btn);
			this.Name = "Main";
			this.Text = "Job Assignment Problem Solver";
			this.tab.ResumeLayout(false);
			this.bf_pg.ResumeLayout(false);
			this.bf_pg.PerformLayout();
			this.ga_pg.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			this.tabGA.ResumeLayout(false);
			this.BinGA.ResumeLayout(false);
			this.BinGA.PerformLayout();
			this.PermGA.ResumeLayout(false);
			this.PermGA.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.chartGA)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.data)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button import_btn;
		private System.Windows.Forms.TabControl tab;
		private System.Windows.Forms.TabPage bf_pg;
		private System.Windows.Forms.TabPage ga_pg;
		private System.Windows.Forms.ListBox result_list;
		private System.Windows.Forms.Label BSset;
		private System.Windows.Forms.Label BSlbl;
		private System.Windows.Forms.Label BOval;
		private System.Windows.Forms.Label BOlbl;
		private System.Windows.Forms.DataGridView data;
		private System.Windows.Forms.Label NOJ_lbl;
		private System.Windows.Forms.Label noj_num;
		private System.Windows.Forms.Label TM_lbl;
		private System.Windows.Forms.ToolTip tip;
		private System.Windows.Forms.ToolTip tip1;
		private System.Windows.Forms.Button slv_btn;
		private System.Windows.Forms.TabControl tabGA;
		private System.Windows.Forms.TabPage BinGA;
		private System.Windows.Forms.TextBox timer;
		private System.Windows.Forms.TabPage PermGA;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.Button btnCreateBinGA;
		private System.Windows.Forms.Label BOGA;
		private System.Windows.Forms.Label GAsol_lbl;
		private System.Windows.Forms.Label GAobj_lbl;
		private System.Windows.Forms.Label BSGA;
		private System.Windows.Forms.DataVisualization.Charting.Chart chartGA;
		private System.Windows.Forms.Button iterend;
		private System.Windows.Forms.Button iterone;
		private System.Windows.Forms.Button buttonReset;
		private System.Windows.Forms.PropertyGrid Solver;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textpenalty;
		private System.Windows.Forms.Label constrain;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Button btnCreatePerGA;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label PGAsol_lbl;
		private System.Windows.Forms.Label PGAobj_lbl;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox recursive_type;
		private System.Windows.Forms.CheckBox show_chk;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label constrains;
	}
}


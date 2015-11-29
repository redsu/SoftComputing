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
			this.import_btn = new System.Windows.Forms.Button();
			this.tab = new System.Windows.Forms.TabControl();
			this.bf_pg = new System.Windows.Forms.TabPage();
			this.BSset = new System.Windows.Forms.Label();
			this.BSlbl = new System.Windows.Forms.Label();
			this.BOval = new System.Windows.Forms.Label();
			this.BOlbl = new System.Windows.Forms.Label();
			this.result_list = new System.Windows.Forms.ListBox();
			this.slv_btn = new System.Windows.Forms.Button();
			this.ga_pg = new System.Windows.Forms.TabPage();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.data = new System.Windows.Forms.DataGridView();
			this.NOJ_lbl = new System.Windows.Forms.Label();
			this.noj_num = new System.Windows.Forms.Label();
			this.TM_lbl = new System.Windows.Forms.Label();
			this.tip = new System.Windows.Forms.ToolTip(this.components);
			this.tip1 = new System.Windows.Forms.ToolTip(this.components);
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.BinGA = new System.Windows.Forms.TabPage();
			this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.new_binga = new System.Windows.Forms.Button();
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
			((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.data)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.BinGA.SuspendLayout();
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
			this.tab.Size = new System.Drawing.Size(691, 567);
			this.tab.TabIndex = 1;
			// 
			// bf_pg
			// 
			this.bf_pg.BackColor = System.Drawing.Color.Lavender;
			this.bf_pg.Controls.Add(this.BSset);
			this.bf_pg.Controls.Add(this.BSlbl);
			this.bf_pg.Controls.Add(this.BOval);
			this.bf_pg.Controls.Add(this.BOlbl);
			this.bf_pg.Controls.Add(this.result_list);
			this.bf_pg.Controls.Add(this.slv_btn);
			this.bf_pg.Location = new System.Drawing.Point(4, 28);
			this.bf_pg.Name = "bf_pg";
			this.bf_pg.Padding = new System.Windows.Forms.Padding(3);
			this.bf_pg.Size = new System.Drawing.Size(683, 535);
			this.bf_pg.TabIndex = 0;
			this.bf_pg.Text = "Brute Force";
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
			this.ga_pg.Controls.Add(this.tabControl1);
			this.ga_pg.Location = new System.Drawing.Point(4, 28);
			this.ga_pg.Name = "ga_pg";
			this.ga_pg.Padding = new System.Windows.Forms.Padding(3);
			this.ga_pg.Size = new System.Drawing.Size(683, 535);
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
			this.splitContainer1.Panel2.Controls.Add(this.button3);
			this.splitContainer1.Panel2.Controls.Add(this.button2);
			this.splitContainer1.Panel2.Controls.Add(this.button1);
			this.splitContainer1.Panel2.Controls.Add(this.propertyGrid1);
			this.splitContainer1.Size = new System.Drawing.Size(663, 491);
			this.splitContainer1.SplitterDistance = 408;
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
			this.splitContainer2.Panel1.Controls.Add(this.new_binga);
			this.splitContainer2.Panel1.Controls.Add(this.label1);
			this.splitContainer2.Panel1.Controls.Add(this.label2);
			this.splitContainer2.Panel1.Controls.Add(this.label3);
			this.splitContainer2.Panel1.Controls.Add(this.label4);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.chart1);
			this.splitContainer2.Size = new System.Drawing.Size(408, 491);
			this.splitContainer2.SplitterDistance = 227;
			this.splitContainer2.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(122, 47);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(58, 19);
			this.label1.TabIndex = 11;
			this.label1.Text = "(NONE)";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(8, 47);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(98, 19);
			this.label2.TabIndex = 10;
			this.label2.Text = "Best Solution:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(122, 17);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(58, 19);
			this.label3.TabIndex = 9;
			this.label3.Text = "(NONE)";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(8, 17);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(108, 19);
			this.label4.TabIndex = 8;
			this.label4.Text = "Best Objective:";
			// 
			// chart1
			// 
			this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.chart1.BackColor = System.Drawing.Color.Lavender;
			chartArea1.Name = "ChartArea1";
			this.chart1.ChartAreas.Add(chartArea1);
			legend1.Name = "Legend1";
			this.chart1.Legends.Add(legend1);
			this.chart1.Location = new System.Drawing.Point(0, -2);
			this.chart1.Name = "chart1";
			this.chart1.Size = new System.Drawing.Size(408, 262);
			this.chart1.TabIndex = 0;
			this.chart1.Text = "chart1";
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
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.BinGA);
			this.tabControl1.Location = new System.Drawing.Point(3, 3);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(677, 529);
			this.tabControl1.TabIndex = 17;
			// 
			// BinGA
			// 
			this.BinGA.Controls.Add(this.splitContainer1);
			this.BinGA.Location = new System.Drawing.Point(4, 28);
			this.BinGA.Name = "BinGA";
			this.BinGA.Padding = new System.Windows.Forms.Padding(3);
			this.BinGA.Size = new System.Drawing.Size(669, 497);
			this.BinGA.TabIndex = 0;
			this.BinGA.Text = "Binary GA";
			this.BinGA.UseVisualStyleBackColor = true;
			// 
			// propertyGrid1
			// 
			this.propertyGrid1.Location = new System.Drawing.Point(3, 167);
			this.propertyGrid1.Name = "propertyGrid1";
			this.propertyGrid1.Size = new System.Drawing.Size(245, 321);
			this.propertyGrid1.TabIndex = 0;
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.ForeColor = System.Drawing.Color.MidnightBlue;
			this.button1.Location = new System.Drawing.Point(59, 16);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(142, 31);
			this.button1.TabIndex = 2;
			this.button1.Text = "Reset";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			this.button2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button2.ForeColor = System.Drawing.Color.MidnightBlue;
			this.button2.Location = new System.Drawing.Point(59, 53);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(142, 31);
			this.button2.TabIndex = 3;
			this.button2.Text = "Run One Iteration";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// button3
			// 
			this.button3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button3.ForeColor = System.Drawing.Color.MidnightBlue;
			this.button3.Location = new System.Drawing.Point(59, 90);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(142, 31);
			this.button3.TabIndex = 4;
			this.button3.Text = "Run To End";
			this.button3.UseVisualStyleBackColor = true;
			// 
			// new_binga
			// 
			this.new_binga.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.new_binga.ForeColor = System.Drawing.Color.MidnightBlue;
			this.new_binga.Location = new System.Drawing.Point(259, 10);
			this.new_binga.Name = "new_binga";
			this.new_binga.Size = new System.Drawing.Size(142, 31);
			this.new_binga.TabIndex = 5;
			this.new_binga.Text = "Create Binary GA";
			this.new_binga.UseVisualStyleBackColor = true;
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.LightGray;
			this.ClientSize = new System.Drawing.Size(1001, 586);
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
			this.splitContainer2.Panel1.PerformLayout();
			this.splitContainer2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.data)).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.BinGA.ResumeLayout(false);
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
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage BinGA;
		private System.Windows.Forms.PropertyGrid propertyGrid1;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button new_binga;
	}
}


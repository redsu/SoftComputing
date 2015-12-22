namespace R04522602許泰源Ass11
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
			this.sCouter1 = new System.Windows.Forms.SplitContainer();
			this.sCouter2 = new System.Windows.Forms.SplitContainer();
			this.sCouter4 = new System.Windows.Forms.SplitContainer();
			this.lbl_sofarsol = new System.Windows.Forms.Label();
			this.lbl_sofarobj = new System.Windows.Forms.Label();
			this.tabHeur = new System.Windows.Forms.TabControl();
			this.tab_ACO = new System.Windows.Forms.TabPage();
			this.btn_createPSO = new System.Windows.Forms.Button();
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
			this.tChart = new Steema.TeeChart.TChart();
			this.chartController = new Steema.TeeChart.ChartController();
			((System.ComponentModel.ISupportInitialize)(this.sCouter1)).BeginInit();
			this.sCouter1.Panel2.SuspendLayout();
			this.sCouter1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.sCouter2)).BeginInit();
			this.sCouter2.Panel1.SuspendLayout();
			this.sCouter2.Panel2.SuspendLayout();
			this.sCouter2.SuspendLayout();
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
			// 
			// sCouter1.Panel2
			// 
			this.sCouter1.Panel2.Controls.Add(this.sCouter2);
			this.sCouter1.Size = new System.Drawing.Size(1089, 453);
			this.sCouter1.SplitterDistance = 313;
			this.sCouter1.TabIndex = 0;
			// 
			// sCouter2
			// 
			this.sCouter2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sCouter2.Location = new System.Drawing.Point(0, 0);
			this.sCouter2.Name = "sCouter2";
			// 
			// sCouter2.Panel1
			// 
			this.sCouter2.Panel1.BackColor = System.Drawing.SystemColors.ControlLight;
			this.sCouter2.Panel1.Controls.Add(this.chartController);
			this.sCouter2.Panel1.Controls.Add(this.tChart);
			// 
			// sCouter2.Panel2
			// 
			this.sCouter2.Panel2.Controls.Add(this.sCouter4);
			this.sCouter2.Size = new System.Drawing.Size(772, 453);
			this.sCouter2.SplitterDistance = 378;
			this.sCouter2.TabIndex = 0;
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
			this.sCouter4.Panel1.Controls.Add(this.lbl_sofarsol);
			this.sCouter4.Panel1.Controls.Add(this.lbl_sofarobj);
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
			this.sCouter4.Size = new System.Drawing.Size(390, 453);
			this.sCouter4.SplitterDistance = 186;
			this.sCouter4.TabIndex = 0;
			// 
			// lbl_sofarsol
			// 
			this.lbl_sofarsol.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.lbl_sofarsol.ForeColor = System.Drawing.Color.DarkGreen;
			this.lbl_sofarsol.Location = new System.Drawing.Point(4, 107);
			this.lbl_sofarsol.Name = "lbl_sofarsol";
			this.lbl_sofarsol.Size = new System.Drawing.Size(383, 79);
			this.lbl_sofarsol.TabIndex = 5;
			this.lbl_sofarsol.Text = "So Far The Best Objective : (NONE)";
			// 
			// lbl_sofarobj
			// 
			this.lbl_sofarobj.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.lbl_sofarobj.ForeColor = System.Drawing.Color.DarkGreen;
			this.lbl_sofarobj.Location = new System.Drawing.Point(4, 82);
			this.lbl_sofarobj.Name = "lbl_sofarobj";
			this.lbl_sofarobj.Size = new System.Drawing.Size(383, 25);
			this.lbl_sofarobj.TabIndex = 4;
			this.lbl_sofarobj.Text = "So Far The Best Objective : (NONE)";
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
			this.tabHeur.Size = new System.Drawing.Size(384, 76);
			this.tabHeur.TabIndex = 1;
			this.tabHeur.SelectedIndexChanged += new System.EventHandler(this.tabHeur_SelectedIndexChanged);
			// 
			// tab_ACO
			// 
			this.tab_ACO.Controls.Add(this.btn_createPSO);
			this.tab_ACO.Location = new System.Drawing.Point(4, 26);
			this.tab_ACO.Name = "tab_ACO";
			this.tab_ACO.Padding = new System.Windows.Forms.Padding(3);
			this.tab_ACO.Size = new System.Drawing.Size(376, 46);
			this.tab_ACO.TabIndex = 0;
			this.tab_ACO.Text = "ACO Algorithm";
			this.tab_ACO.UseVisualStyleBackColor = true;
			// 
			// btn_createPSO
			// 
			this.btn_createPSO.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.btn_createPSO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_createPSO.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.btn_createPSO.ForeColor = System.Drawing.Color.DarkBlue;
			this.btn_createPSO.Location = new System.Drawing.Point(6, 6);
			this.btn_createPSO.Name = "btn_createPSO";
			this.btn_createPSO.Size = new System.Drawing.Size(149, 35);
			this.btn_createPSO.TabIndex = 1;
			this.btn_createPSO.Text = "Create PSO Solver";
			this.btn_createPSO.UseVisualStyleBackColor = false;
			this.btn_createPSO.Click += new System.EventHandler(this.btn_createPSO_Click);
			// 
			// tabGA
			// 
			this.tabGA.Controls.Add(this.btn_createGA);
			this.tabGA.Location = new System.Drawing.Point(4, 26);
			this.tabGA.Name = "tabGA";
			this.tabGA.Padding = new System.Windows.Forms.Padding(3);
			this.tabGA.Size = new System.Drawing.Size(376, 46);
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
			this.Solver.Size = new System.Drawing.Size(214, 267);
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
			// tChart
			// 
			this.tChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			// 
			// 
			// 
			this.tChart.Aspect.ZOffset = 0D;
			this.tChart.BackColor = System.Drawing.SystemColors.ControlLight;
			this.tChart.Location = new System.Drawing.Point(0, 29);
			this.tChart.Name = "tChart";
			this.tChart.Size = new System.Drawing.Size(378, 425);
			this.tChart.TabIndex = 0;
			this.tChart.Click += new System.EventHandler(this.tChart1_Click);
			// 
			// chartController
			// 
			this.chartController.ButtonSize = Steema.TeeChart.ControllerButtonSize.x16;
			this.chartController.Chart = this.tChart;
			this.chartController.LabelValues = true;
			this.chartController.Location = new System.Drawing.Point(0, 0);
			this.chartController.Name = "chartController";
			this.chartController.Size = new System.Drawing.Size(378, 25);
			this.chartController.TabIndex = 1;
			this.chartController.Text = "chartController1";
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
			this.DoubleBuffered = true;
			this.Name = "Main";
			this.Text = "PSO Solver";
			this.sCouter1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.sCouter1)).EndInit();
			this.sCouter1.ResumeLayout(false);
			this.sCouter2.Panel1.ResumeLayout(false);
			this.sCouter2.Panel1.PerformLayout();
			this.sCouter2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.sCouter2)).EndInit();
			this.sCouter2.ResumeLayout(false);
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
		private System.Windows.Forms.SplitContainer sCouter2;
		private System.Windows.Forms.SplitContainer sCouter4;
		private System.Windows.Forms.Label lbl_sofarobj;
		private System.Windows.Forms.TabControl tabHeur;
		private System.Windows.Forms.TabPage tab_ACO;
		private System.Windows.Forms.Button btn_createPSO;
		private System.Windows.Forms.TabPage tabGA;
		private System.Windows.Forms.PropertyGrid Solver;
		private System.Windows.Forms.Button btnEnd;
		private System.Windows.Forms.Button btnExeone;
		private System.Windows.Forms.Button btnReset;
		private System.Windows.Forms.ToolStripButton tsbtn_open;
		private System.Windows.Forms.ProgressBar pBar;
		private System.Windows.Forms.Button btn_createGA;
		private System.Windows.Forms.CheckBox updateperiteration;
		private System.Windows.Forms.ToolTip tip;
		private System.Windows.Forms.Label lbl_sofarsol;
		private Steema.TeeChart.TChart tChart;
		private Steema.TeeChart.ChartController chartController;

	}
}


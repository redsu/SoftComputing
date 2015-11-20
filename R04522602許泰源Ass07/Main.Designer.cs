namespace R04522602許泰源Ass07
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
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.import_btn = new System.Windows.Forms.Button();
			this.tab = new System.Windows.Forms.TabControl();
			this.bf_pg = new System.Windows.Forms.TabPage();
			this.ga_pg = new System.Windows.Forms.TabPage();
			this.slv_btn = new System.Windows.Forms.Button();
			this.result_list = new System.Windows.Forms.ListBox();
			this.BOlbl = new System.Windows.Forms.Label();
			this.BOval = new System.Windows.Forms.Label();
			this.BSset = new System.Windows.Forms.Label();
			this.BSlbl = new System.Windows.Forms.Label();
			this.data = new System.Windows.Forms.DataGridView();
			this.tab.SuspendLayout();
			this.bf_pg.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.data)).BeginInit();
			this.SuspendLayout();
			// 
			// openFileDialog
			// 
			this.openFileDialog.FileName = "openFileDialog1";
			// 
			// import_btn
			// 
			this.import_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.import_btn.Location = new System.Drawing.Point(12, 12);
			this.import_btn.Name = "import_btn";
			this.import_btn.Size = new System.Drawing.Size(142, 31);
			this.import_btn.TabIndex = 0;
			this.import_btn.Text = "Import File";
			this.import_btn.UseVisualStyleBackColor = true;
			this.import_btn.Click += new System.EventHandler(this.import_btn_Click);
			// 
			// tab
			// 
			this.tab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tab.Controls.Add(this.bf_pg);
			this.tab.Controls.Add(this.ga_pg);
			this.tab.Location = new System.Drawing.Point(452, 12);
			this.tab.Name = "tab";
			this.tab.SelectedIndex = 0;
			this.tab.Size = new System.Drawing.Size(547, 542);
			this.tab.TabIndex = 1;
			// 
			// bf_pg
			// 
			this.bf_pg.Controls.Add(this.BSset);
			this.bf_pg.Controls.Add(this.BSlbl);
			this.bf_pg.Controls.Add(this.BOval);
			this.bf_pg.Controls.Add(this.BOlbl);
			this.bf_pg.Controls.Add(this.result_list);
			this.bf_pg.Controls.Add(this.slv_btn);
			this.bf_pg.Location = new System.Drawing.Point(4, 22);
			this.bf_pg.Name = "bf_pg";
			this.bf_pg.Padding = new System.Windows.Forms.Padding(3);
			this.bf_pg.Size = new System.Drawing.Size(539, 516);
			this.bf_pg.TabIndex = 0;
			this.bf_pg.Text = "Brute Force";
			this.bf_pg.UseVisualStyleBackColor = true;
			// 
			// ga_pg
			// 
			this.ga_pg.Location = new System.Drawing.Point(4, 22);
			this.ga_pg.Name = "ga_pg";
			this.ga_pg.Padding = new System.Windows.Forms.Padding(3);
			this.ga_pg.Size = new System.Drawing.Size(642, 377);
			this.ga_pg.TabIndex = 1;
			this.ga_pg.Text = "Genetic Algorithm";
			this.ga_pg.UseVisualStyleBackColor = true;
			// 
			// slv_btn
			// 
			this.slv_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.slv_btn.Location = new System.Drawing.Point(6, 6);
			this.slv_btn.Name = "slv_btn";
			this.slv_btn.Size = new System.Drawing.Size(142, 31);
			this.slv_btn.TabIndex = 2;
			this.slv_btn.Text = "Solve";
			this.slv_btn.UseVisualStyleBackColor = true;
			this.slv_btn.Click += new System.EventHandler(this.slv_btn_Click);
			// 
			// result_list
			// 
			this.result_list.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.result_list.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.result_list.FormattingEnabled = true;
			this.result_list.ItemHeight = 19;
			this.result_list.Location = new System.Drawing.Point(6, 43);
			this.result_list.Name = "result_list";
			this.result_list.Size = new System.Drawing.Size(530, 460);
			this.result_list.TabIndex = 3;
			// 
			// BOlbl
			// 
			this.BOlbl.AutoSize = true;
			this.BOlbl.Location = new System.Drawing.Point(155, 24);
			this.BOlbl.Name = "BOlbl";
			this.BOlbl.Size = new System.Drawing.Size(75, 12);
			this.BOlbl.TabIndex = 4;
			this.BOlbl.Text = "Best Objective:";
			// 
			// BOval
			// 
			this.BOval.AutoSize = true;
			this.BOval.Location = new System.Drawing.Point(236, 24);
			this.BOval.Name = "BOval";
			this.BOval.Size = new System.Drawing.Size(44, 12);
			this.BOval.TabIndex = 5;
			this.BOval.Text = "(NONE)";
			// 
			// BSset
			// 
			this.BSset.AutoSize = true;
			this.BSset.Location = new System.Drawing.Point(397, 24);
			this.BSset.Name = "BSset";
			this.BSset.Size = new System.Drawing.Size(44, 12);
			this.BSset.TabIndex = 7;
			this.BSset.Text = "(NONE)";
			// 
			// BSlbl
			// 
			this.BSlbl.AutoSize = true;
			this.BSlbl.Location = new System.Drawing.Point(316, 24);
			this.BSlbl.Name = "BSlbl";
			this.BSlbl.Size = new System.Drawing.Size(70, 12);
			this.BSlbl.TabIndex = 6;
			this.BSlbl.Text = "Best Solution:";
			// 
			// data
			// 
			this.data.AllowUserToAddRows = false;
			this.data.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
			this.data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.data.Location = new System.Drawing.Point(12, 49);
			this.data.Name = "data";
			this.data.RowTemplate.Height = 24;
			this.data.Size = new System.Drawing.Size(434, 505);
			this.data.TabIndex = 8;
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1004, 561);
			this.Controls.Add(this.data);
			this.Controls.Add(this.tab);
			this.Controls.Add(this.import_btn);
			this.Name = "Main";
			this.Text = "Job Assignment Problem Solver";
			this.tab.ResumeLayout(false);
			this.bf_pg.ResumeLayout(false);
			this.bf_pg.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.data)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.Button import_btn;
		private System.Windows.Forms.TabControl tab;
		private System.Windows.Forms.TabPage bf_pg;
		private System.Windows.Forms.Button slv_btn;
		private System.Windows.Forms.TabPage ga_pg;
		private System.Windows.Forms.ListBox result_list;
		private System.Windows.Forms.Label BSset;
		private System.Windows.Forms.Label BSlbl;
		private System.Windows.Forms.Label BOval;
		private System.Windows.Forms.Label BOlbl;
		private System.Windows.Forms.DataGridView data;
	}
}


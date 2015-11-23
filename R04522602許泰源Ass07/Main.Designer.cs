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
			this.components = new System.ComponentModel.Container();
			this.import_btn = new System.Windows.Forms.Button();
			this.tab = new System.Windows.Forms.TabControl();
			this.bf_pg = new System.Windows.Forms.TabPage();
			this.BSset = new System.Windows.Forms.Label();
			this.BSlbl = new System.Windows.Forms.Label();
			this.BOval = new System.Windows.Forms.Label();
			this.BOlbl = new System.Windows.Forms.Label();
			this.result_list = new System.Windows.Forms.ListBox();
			this.ga_pg = new System.Windows.Forms.TabPage();
			this.data = new System.Windows.Forms.DataGridView();
			this.NOJ_lbl = new System.Windows.Forms.Label();
			this.noj_num = new System.Windows.Forms.Label();
			this.TM_lbl = new System.Windows.Forms.Label();
			this.tip = new System.Windows.Forms.ToolTip(this.components);
			this.tip1 = new System.Windows.Forms.ToolTip(this.components);
			this.slv_btn = new System.Windows.Forms.Button();
			this.tab.SuspendLayout();
			this.bf_pg.SuspendLayout();
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
			this.tab.Location = new System.Drawing.Point(379, 12);
			this.tab.Name = "tab";
			this.tab.SelectedIndex = 0;
			this.tab.Size = new System.Drawing.Size(621, 542);
			this.tab.TabIndex = 1;
			// 
			// bf_pg
			// 
			this.bf_pg.Controls.Add(this.BSset);
			this.bf_pg.Controls.Add(this.BSlbl);
			this.bf_pg.Controls.Add(this.BOval);
			this.bf_pg.Controls.Add(this.BOlbl);
			this.bf_pg.Controls.Add(this.result_list);
			this.bf_pg.Location = new System.Drawing.Point(4, 28);
			this.bf_pg.Name = "bf_pg";
			this.bf_pg.Padding = new System.Windows.Forms.Padding(3);
			this.bf_pg.Size = new System.Drawing.Size(613, 510);
			this.bf_pg.TabIndex = 0;
			this.bf_pg.Text = "Brute Force";
			this.bf_pg.UseVisualStyleBackColor = true;
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
			this.result_list.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.result_list.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.result_list.FormattingEnabled = true;
			this.result_list.ItemHeight = 19;
			this.result_list.Location = new System.Drawing.Point(6, 43);
			this.result_list.Name = "result_list";
			this.result_list.Size = new System.Drawing.Size(601, 441);
			this.result_list.TabIndex = 3;
			// 
			// ga_pg
			// 
			this.ga_pg.Location = new System.Drawing.Point(4, 28);
			this.ga_pg.Name = "ga_pg";
			this.ga_pg.Padding = new System.Windows.Forms.Padding(3);
			this.ga_pg.Size = new System.Drawing.Size(613, 510);
			this.ga_pg.TabIndex = 1;
			this.ga_pg.Text = "Genetic Algorithm";
			this.ga_pg.UseVisualStyleBackColor = true;
			// 
			// data
			// 
			this.data.AllowUserToAddRows = false;
			this.data.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
			this.data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.data.Location = new System.Drawing.Point(12, 115);
			this.data.Name = "data";
			this.data.RowTemplate.Height = 24;
			this.data.Size = new System.Drawing.Size(361, 439);
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
			// slv_btn
			// 
			this.slv_btn.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.slv_btn.ForeColor = System.Drawing.Color.Navy;
			this.slv_btn.Location = new System.Drawing.Point(160, 12);
			this.slv_btn.Name = "slv_btn";
			this.slv_btn.Size = new System.Drawing.Size(142, 31);
			this.slv_btn.TabIndex = 12;
			this.slv_btn.Text = "Solve";
			this.slv_btn.UseVisualStyleBackColor = true;
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1004, 561);
			this.Controls.Add(this.TM_lbl);
			this.Controls.Add(this.noj_num);
			this.Controls.Add(this.NOJ_lbl);
			this.Controls.Add(this.data);
			this.Controls.Add(this.tab);
			this.Controls.Add(this.import_btn);
			this.Controls.Add(this.slv_btn);
			this.Name = "Main";
			this.Text = "Job Assignment Problem Solver";
			this.tab.ResumeLayout(false);
			this.bf_pg.ResumeLayout(false);
			this.bf_pg.PerformLayout();
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
	}
}


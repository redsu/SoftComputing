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
			this.SuspendLayout();
			// 
			// openFileDialog
			// 
			this.openFileDialog.FileName = "openFileDialog1";
			// 
			// import_btn
			// 
			this.import_btn.Location = new System.Drawing.Point(12, 12);
			this.import_btn.Name = "import_btn";
			this.import_btn.Size = new System.Drawing.Size(75, 23);
			this.import_btn.TabIndex = 0;
			this.import_btn.Text = "Import File";
			this.import_btn.UseVisualStyleBackColor = true;
			this.import_btn.Click += new System.EventHandler(this.import_btn_Click);
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1006, 529);
			this.Controls.Add(this.import_btn);
			this.Name = "Main";
			this.Text = "Job Assignment Problem Solver";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.Button import_btn;
	}
}


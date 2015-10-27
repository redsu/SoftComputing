namespace R04522602許泰源Ass05
{
	partial class Rename
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
			this.name_box = new System.Windows.Forms.TextBox();
			this.ent_btn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// name_box
			// 
			this.name_box.Location = new System.Drawing.Point(12, 25);
			this.name_box.Name = "name_box";
			this.name_box.Size = new System.Drawing.Size(268, 22);
			this.name_box.TabIndex = 0;
			// 
			// ent_btn
			// 
			this.ent_btn.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ent_btn.Location = new System.Drawing.Point(205, 64);
			this.ent_btn.Name = "ent_btn";
			this.ent_btn.Size = new System.Drawing.Size(75, 33);
			this.ent_btn.TabIndex = 1;
			this.ent_btn.Text = "Enter";
			this.ent_btn.UseVisualStyleBackColor = true;
			this.ent_btn.Click += new System.EventHandler(this.ent_btn_Click);
			// 
			// Rename
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(292, 109);
			this.Controls.Add(this.ent_btn);
			this.Controls.Add(this.name_box);
			this.MaximizeBox = false;
			this.Name = "Rename";
			this.Text = "Rename";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox name_box;
		private System.Windows.Forms.Button ent_btn;
	}
}
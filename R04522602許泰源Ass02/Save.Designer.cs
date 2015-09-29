namespace R04522602許泰源Ass02
{
    partial class save_win
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(save_win));
            this.file_name_bx = new System.Windows.Forms.TextBox();
            this.save_dia_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // file_name_bx
            // 
            this.file_name_bx.Location = new System.Drawing.Point(12, 30);
            this.file_name_bx.Name = "file_name_bx";
            this.file_name_bx.Size = new System.Drawing.Size(215, 22);
            this.file_name_bx.TabIndex = 0;
            // 
            // save_dia_btn
            // 
            this.save_dia_btn.Location = new System.Drawing.Point(152, 58);
            this.save_dia_btn.Name = "save_dia_btn";
            this.save_dia_btn.Size = new System.Drawing.Size(75, 23);
            this.save_dia_btn.TabIndex = 1;
            this.save_dia_btn.Text = "Save";
            this.save_dia_btn.UseVisualStyleBackColor = true;
            this.save_dia_btn.Click += new System.EventHandler(this.save_dia_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Please enter the file name";
            // 
            // save_win
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 95);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.save_dia_btn);
            this.Controls.Add(this.file_name_bx);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "save_win";
            this.Text = "Save Image";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox file_name_bx;
        private System.Windows.Forms.Button save_dia_btn;
        private System.Windows.Forms.Label label1;
    }
}
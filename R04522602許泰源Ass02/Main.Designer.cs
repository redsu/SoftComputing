namespace R04522602許泰源Ass02
{
    partial class Main
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
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
			this.Chart_func = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.label_a = new System.Windows.Forms.Label();
			this.label_b = new System.Windows.Forms.Label();
			this.label_c = new System.Windows.Forms.Label();
			this.formula_pic = new System.Windows.Forms.PictureBox();
			this.Delete_btn = new System.Windows.Forms.Button();
			this.save_btn = new System.Windows.Forms.Button();
			this.user_guide_btn = new System.Windows.Forms.Button();
			this.create_func_btn = new System.Windows.Forms.Button();
			this.FuncTypSel = new System.Windows.Forms.ComboBox();
			this.created_func_list = new System.Windows.Forms.ListBox();
			this.color_dialog = new System.Windows.Forms.ColorDialog();
			this.color_dia_btn = new System.Windows.Forms.Button();
			this.tBar_a = new System.Windows.Forms.TrackBar();
			this.Box_a = new System.Windows.Forms.TextBox();
			this.Box_c = new System.Windows.Forms.TextBox();
			this.Box_b = new System.Windows.Forms.TextBox();
			this.numUD_b = new System.Windows.Forms.NumericUpDown();
			this.numUD_a = new System.Windows.Forms.NumericUpDown();
			this.Update_btn = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.Chart_func)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.formula_pic)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tBar_a)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numUD_b)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numUD_a)).BeginInit();
			this.SuspendLayout();
			// 
			// Chart_func
			// 
			this.Chart_func.BackColor = System.Drawing.Color.MistyRose;
			this.Chart_func.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.DiagonalRight;
			chartArea1.AxisY.Maximum = 1.25D;
			chartArea1.AxisY.Title = "y";
			chartArea1.InnerPlotPosition.Auto = false;
			chartArea1.InnerPlotPosition.Height = 90F;
			chartArea1.InnerPlotPosition.Width = 88F;
			chartArea1.InnerPlotPosition.X = 12F;
			chartArea1.Name = "ChartArea1";
			this.Chart_func.ChartAreas.Add(chartArea1);
			legend1.Name = "Legend1";
			this.Chart_func.Legends.Add(legend1);
			this.Chart_func.Location = new System.Drawing.Point(25, 23);
			this.Chart_func.Name = "Chart_func";
			this.Chart_func.Size = new System.Drawing.Size(462, 364);
			this.Chart_func.TabIndex = 4;
			this.Chart_func.Text = "Chart";
			// 
			// label_a
			// 
			this.label_a.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label_a.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label_a.Location = new System.Drawing.Point(637, 248);
			this.label_a.Name = "label_a";
			this.label_a.Size = new System.Drawing.Size(103, 19);
			this.label_a.TabIndex = 12;
			this.label_a.Text = "a";
			this.label_a.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label_b
			// 
			this.label_b.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label_b.Location = new System.Drawing.Point(637, 276);
			this.label_b.Name = "label_b";
			this.label_b.Size = new System.Drawing.Size(103, 19);
			this.label_b.TabIndex = 6;
			this.label_b.Text = "b";
			this.label_b.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label_c
			// 
			this.label_c.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label_c.Location = new System.Drawing.Point(637, 304);
			this.label_c.Name = "label_c";
			this.label_c.Size = new System.Drawing.Size(103, 19);
			this.label_c.TabIndex = 7;
			this.label_c.Text = "c";
			this.label_c.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// formula_pic
			// 
			this.formula_pic.BackColor = System.Drawing.Color.Transparent;
			this.formula_pic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.formula_pic.Location = new System.Drawing.Point(501, 23);
			this.formula_pic.Name = "formula_pic";
			this.formula_pic.Size = new System.Drawing.Size(345, 170);
			this.formula_pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.formula_pic.TabIndex = 13;
			this.formula_pic.TabStop = false;
			// 
			// Delete_btn
			// 
			this.Delete_btn.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Delete_btn.Location = new System.Drawing.Point(746, 365);
			this.Delete_btn.Name = "Delete_btn";
			this.Delete_btn.Size = new System.Drawing.Size(100, 32);
			this.Delete_btn.TabIndex = 14;
			this.Delete_btn.Text = "Delete";
			this.Delete_btn.UseVisualStyleBackColor = true;
			this.Delete_btn.Click += new System.EventHandler(this.Delete_btn_Click);
			// 
			// save_btn
			// 
			this.save_btn.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.save_btn.Location = new System.Drawing.Point(746, 467);
			this.save_btn.Name = "save_btn";
			this.save_btn.Size = new System.Drawing.Size(100, 32);
			this.save_btn.TabIndex = 15;
			this.save_btn.Text = "Save";
			this.save_btn.UseVisualStyleBackColor = true;
			this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
			// 
			// user_guide_btn
			// 
			this.user_guide_btn.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.user_guide_btn.Location = new System.Drawing.Point(626, 467);
			this.user_guide_btn.Name = "user_guide_btn";
			this.user_guide_btn.Size = new System.Drawing.Size(114, 32);
			this.user_guide_btn.TabIndex = 16;
			this.user_guide_btn.Text = "User Guide";
			this.user_guide_btn.UseVisualStyleBackColor = true;
			this.user_guide_btn.Click += new System.EventHandler(this.user_guide_btn_Click);
			// 
			// create_func_btn
			// 
			this.create_func_btn.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.create_func_btn.Location = new System.Drawing.Point(746, 332);
			this.create_func_btn.Name = "create_func_btn";
			this.create_func_btn.Size = new System.Drawing.Size(100, 32);
			this.create_func_btn.TabIndex = 26;
			this.create_func_btn.Text = "Create";
			this.create_func_btn.UseVisualStyleBackColor = true;
			this.create_func_btn.Click += new System.EventHandler(this.create_func_Click);
			// 
			// FuncTypSel
			// 
			this.FuncTypSel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.FuncTypSel.FormattingEnabled = true;
			this.FuncTypSel.ImeMode = System.Windows.Forms.ImeMode.On;
			this.FuncTypSel.Items.AddRange(new object[] {
            "Triangular Function",
            "Gaussian Function",
            "Bell Function",
            "Sigmoidal Function"});
			this.FuncTypSel.Location = new System.Drawing.Point(511, 214);
			this.FuncTypSel.Name = "FuncTypSel";
			this.FuncTypSel.Size = new System.Drawing.Size(120, 20);
			this.FuncTypSel.TabIndex = 27;
			this.FuncTypSel.SelectedIndexChanged += new System.EventHandler(this.FuncTypSel_SelectedIndexChanged);
			// 
			// created_func_list
			// 
			this.created_func_list.FormattingEnabled = true;
			this.created_func_list.ItemHeight = 12;
			this.created_func_list.Location = new System.Drawing.Point(25, 393);
			this.created_func_list.Name = "created_func_list";
			this.created_func_list.Size = new System.Drawing.Size(462, 100);
			this.created_func_list.TabIndex = 28;
			this.created_func_list.SelectedIndexChanged += new System.EventHandler(this.created_func_list_SelectedIndexChanged);
			this.created_func_list.DoubleClick += new System.EventHandler(this.created_func_DoubleClick);
			// 
			// color_dialog
			// 
			this.color_dialog.FullOpen = true;
			// 
			// color_dia_btn
			// 
			this.color_dia_btn.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.color_dia_btn.Location = new System.Drawing.Point(746, 433);
			this.color_dia_btn.Name = "color_dia_btn";
			this.color_dia_btn.Size = new System.Drawing.Size(100, 32);
			this.color_dia_btn.TabIndex = 29;
			this.color_dia_btn.Text = "Color";
			this.color_dia_btn.UseVisualStyleBackColor = true;
			this.color_dia_btn.Click += new System.EventHandler(this.color_dia_btn_Click);
			// 
			// tBar_a
			// 
			this.tBar_a.Location = new System.Drawing.Point(502, 274);
			this.tBar_a.Name = "tBar_a";
			this.tBar_a.Size = new System.Drawing.Size(129, 45);
			this.tBar_a.TabIndex = 32;
			this.tBar_a.Scroll += new System.EventHandler(this.tBar_a_Scroll);
			// 
			// Box_a
			// 
			this.Box_a.Location = new System.Drawing.Point(746, 248);
			this.Box_a.Name = "Box_a";
			this.Box_a.Size = new System.Drawing.Size(100, 22);
			this.Box_a.TabIndex = 33;
			// 
			// Box_c
			// 
			this.Box_c.Location = new System.Drawing.Point(746, 304);
			this.Box_c.Name = "Box_c";
			this.Box_c.Size = new System.Drawing.Size(100, 22);
			this.Box_c.TabIndex = 35;
			// 
			// Box_b
			// 
			this.Box_b.Location = new System.Drawing.Point(746, 276);
			this.Box_b.Name = "Box_b";
			this.Box_b.Size = new System.Drawing.Size(100, 22);
			this.Box_b.TabIndex = 34;
			// 
			// numUD_b
			// 
			this.numUD_b.Location = new System.Drawing.Point(511, 304);
			this.numUD_b.Name = "numUD_b";
			this.numUD_b.Size = new System.Drawing.Size(120, 22);
			this.numUD_b.TabIndex = 36;
			this.numUD_b.ValueChanged += new System.EventHandler(this.numUD_b_ValueChanged);
			// 
			// numUD_a
			// 
			this.numUD_a.Location = new System.Drawing.Point(511, 248);
			this.numUD_a.Name = "numUD_a";
			this.numUD_a.Size = new System.Drawing.Size(120, 22);
			this.numUD_a.TabIndex = 39;
			this.numUD_a.ValueChanged += new System.EventHandler(this.numUD_a_ValueChanged);
			// 
			// Update_btn
			// 
			this.Update_btn.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Update_btn.Location = new System.Drawing.Point(746, 399);
			this.Update_btn.Name = "Update_btn";
			this.Update_btn.Size = new System.Drawing.Size(100, 32);
			this.Update_btn.TabIndex = 40;
			this.Update_btn.Text = "Update";
			this.Update_btn.UseVisualStyleBackColor = true;
			this.Update_btn.Click += new System.EventHandler(this.Update_btn_Click);
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.ClientSize = new System.Drawing.Size(863, 503);
			this.Controls.Add(this.Update_btn);
			this.Controls.Add(this.numUD_a);
			this.Controls.Add(this.numUD_b);
			this.Controls.Add(this.Box_c);
			this.Controls.Add(this.Box_b);
			this.Controls.Add(this.Box_a);
			this.Controls.Add(this.tBar_a);
			this.Controls.Add(this.color_dia_btn);
			this.Controls.Add(this.created_func_list);
			this.Controls.Add(this.FuncTypSel);
			this.Controls.Add(this.create_func_btn);
			this.Controls.Add(this.user_guide_btn);
			this.Controls.Add(this.save_btn);
			this.Controls.Add(this.Delete_btn);
			this.Controls.Add(this.formula_pic);
			this.Controls.Add(this.Chart_func);
			this.Controls.Add(this.label_c);
			this.Controls.Add(this.label_b);
			this.Controls.Add(this.label_a);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.Name = "Main";
			this.Text = "Function Generator";
			this.Load += new System.EventHandler(this.Main_Load);
			((System.ComponentModel.ISupportInitialize)(this.Chart_func)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.formula_pic)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tBar_a)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numUD_b)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numUD_a)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.DataVisualization.Charting.Chart Chart_func;
        private System.Windows.Forms.Label label_a;
        private System.Windows.Forms.Label label_b;
        private System.Windows.Forms.Label label_c;
        private System.Windows.Forms.PictureBox formula_pic;
        private System.Windows.Forms.Button Delete_btn;
        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.Button user_guide_btn;
        private System.Windows.Forms.Button create_func_btn;
        private System.Windows.Forms.ComboBox FuncTypSel;
        private System.Windows.Forms.ListBox created_func_list;
        private System.Windows.Forms.ColorDialog color_dialog;
		private System.Windows.Forms.Button color_dia_btn;
		private System.Windows.Forms.TrackBar tBar_a;
		private System.Windows.Forms.TextBox Box_a;
		private System.Windows.Forms.TextBox Box_c;
		private System.Windows.Forms.TextBox Box_b;
		private System.Windows.Forms.NumericUpDown numUD_b;
		private System.Windows.Forms.NumericUpDown numUD_a;
		private System.Windows.Forms.Button Update_btn;
    }
}


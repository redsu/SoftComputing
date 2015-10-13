namespace R04522602許泰源Ass03
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
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
			this.Chart_func = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.label_a = new System.Windows.Forms.Label();
			this.label_b = new System.Windows.Forms.Label();
			this.label_c = new System.Windows.Forms.Label();
			this.save_btn = new System.Windows.Forms.Button();
			this.user_guide_btn = new System.Windows.Forms.Button();
			this.color_dialog = new System.Windows.Forms.ColorDialog();
			this.Box_a = new System.Windows.Forms.TextBox();
			this.Box_c = new System.Windows.Forms.TextBox();
			this.Box_b = new System.Windows.Forms.TextBox();
			this.tree = new System.Windows.Forms.TreeView();
			this.FuncTypSel = new System.Windows.Forms.ComboBox();
			this.universe_btn = new System.Windows.Forms.Button();
			this.fs_btn = new System.Windows.Forms.Button();
			this.uni_name = new System.Windows.Forms.TextBox();
			this.uni_max = new System.Windows.Forms.TextBox();
			this.uni_min = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.uni_inc = new System.Windows.Forms.TextBox();
			this.tbar_a = new System.Windows.Forms.TrackBar();
			this.tbar_b = new System.Windows.Forms.TrackBar();
			this.tbar_c = new System.Windows.Forms.TrackBar();
			this.del_btn = new System.Windows.Forms.Button();
			this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
			((System.ComponentModel.ISupportInitialize)(this.Chart_func)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tbar_a)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tbar_b)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tbar_c)).BeginInit();
			this.SuspendLayout();
			// 
			// Chart_func
			// 
			this.Chart_func.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.Chart_func.BackColor = System.Drawing.Color.MistyRose;
			this.Chart_func.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.DiagonalRight;
			legend1.Name = "Legend1";
			this.Chart_func.Legends.Add(legend1);
			this.Chart_func.Location = new System.Drawing.Point(469, 14);
			this.Chart_func.Name = "Chart_func";
			this.Chart_func.Size = new System.Drawing.Size(346, 486);
			this.Chart_func.TabIndex = 4;
			this.Chart_func.Text = "Chart";
			// 
			// label_a
			// 
			this.label_a.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label_a.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label_a.Location = new System.Drawing.Point(155, 125);
			this.label_a.Name = "label_a";
			this.label_a.Size = new System.Drawing.Size(120, 22);
			this.label_a.TabIndex = 12;
			this.label_a.Text = "a";
			this.label_a.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label_b
			// 
			this.label_b.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label_b.Location = new System.Drawing.Point(155, 175);
			this.label_b.Name = "label_b";
			this.label_b.Size = new System.Drawing.Size(120, 22);
			this.label_b.TabIndex = 6;
			this.label_b.Text = "b";
			this.label_b.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label_c
			// 
			this.label_c.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label_c.Location = new System.Drawing.Point(155, 225);
			this.label_c.Name = "label_c";
			this.label_c.Size = new System.Drawing.Size(120, 22);
			this.label_c.TabIndex = 7;
			this.label_c.Text = "c";
			this.label_c.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// save_btn
			// 
			this.save_btn.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.save_btn.Location = new System.Drawing.Point(281, 222);
			this.save_btn.Name = "save_btn";
			this.save_btn.Size = new System.Drawing.Size(154, 37);
			this.save_btn.TabIndex = 15;
			this.save_btn.Text = "Save";
			this.save_btn.UseVisualStyleBackColor = true;
			this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
			// 
			// user_guide_btn
			// 
			this.user_guide_btn.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.user_guide_btn.Location = new System.Drawing.Point(281, 179);
			this.user_guide_btn.Name = "user_guide_btn";
			this.user_guide_btn.Size = new System.Drawing.Size(154, 37);
			this.user_guide_btn.TabIndex = 16;
			this.user_guide_btn.Text = "User Guide";
			this.user_guide_btn.UseVisualStyleBackColor = true;
			this.user_guide_btn.Click += new System.EventHandler(this.user_guide_btn_Click);
			// 
			// color_dialog
			// 
			this.color_dialog.FullOpen = true;
			// 
			// Box_a
			// 
			this.Box_a.Location = new System.Drawing.Point(155, 150);
			this.Box_a.Name = "Box_a";
			this.Box_a.Size = new System.Drawing.Size(98, 22);
			this.Box_a.TabIndex = 33;
			// 
			// Box_c
			// 
			this.Box_c.Location = new System.Drawing.Point(155, 250);
			this.Box_c.Name = "Box_c";
			this.Box_c.Size = new System.Drawing.Size(98, 22);
			this.Box_c.TabIndex = 35;
			// 
			// Box_b
			// 
			this.Box_b.Location = new System.Drawing.Point(155, 200);
			this.Box_b.Name = "Box_b";
			this.Box_b.Size = new System.Drawing.Size(98, 22);
			this.Box_b.TabIndex = 34;
			// 
			// tree
			// 
			this.tree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.tree.Location = new System.Drawing.Point(14, 317);
			this.tree.Name = "tree";
			this.tree.Size = new System.Drawing.Size(285, 183);
			this.tree.TabIndex = 44;
			this.tree.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tree_AfterChecked);
			this.tree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tree_AfterSelect);
			this.tree.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tree_DoubleClick);
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
			this.FuncTypSel.Location = new System.Drawing.Point(17, 93);
			this.FuncTypSel.Name = "FuncTypSel";
			this.FuncTypSel.Size = new System.Drawing.Size(126, 22);
			this.FuncTypSel.TabIndex = 27;
			this.FuncTypSel.SelectedIndexChanged += new System.EventHandler(this.FuncTypSel_SelectedIndexChanged);
			// 
			// universe_btn
			// 
			this.universe_btn.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.universe_btn.Location = new System.Drawing.Point(281, 93);
			this.universe_btn.Name = "universe_btn";
			this.universe_btn.Size = new System.Drawing.Size(154, 37);
			this.universe_btn.TabIndex = 45;
			this.universe_btn.Text = "Create Universe";
			this.universe_btn.UseVisualStyleBackColor = true;
			this.universe_btn.Click += new System.EventHandler(this.universe_btn_Click);
			// 
			// fs_btn
			// 
			this.fs_btn.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.fs_btn.Location = new System.Drawing.Point(281, 136);
			this.fs_btn.Name = "fs_btn";
			this.fs_btn.Size = new System.Drawing.Size(154, 37);
			this.fs_btn.TabIndex = 46;
			this.fs_btn.Text = "Add Fuzzy Set";
			this.fs_btn.UseVisualStyleBackColor = true;
			this.fs_btn.Click += new System.EventHandler(this.fs_btn_Click);
			// 
			// uni_name
			// 
			this.uni_name.Location = new System.Drawing.Point(112, 24);
			this.uni_name.Name = "uni_name";
			this.uni_name.Size = new System.Drawing.Size(90, 22);
			this.uni_name.TabIndex = 47;
			this.uni_name.Text = "X1";
			// 
			// uni_max
			// 
			this.uni_max.Location = new System.Drawing.Point(325, 55);
			this.uni_max.Name = "uni_max";
			this.uni_max.Size = new System.Drawing.Size(90, 22);
			this.uni_max.TabIndex = 48;
			this.uni_max.Text = "10.0";
			// 
			// uni_min
			// 
			this.uni_min.Location = new System.Drawing.Point(325, 24);
			this.uni_min.Name = "uni_min";
			this.uni_min.Size = new System.Drawing.Size(90, 22);
			this.uni_min.TabIndex = 49;
			this.uni_min.Text = "0.0";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(14, 28);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(92, 15);
			this.label1.TabIndex = 50;
			this.label1.Text = "Universe Title";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(211, 28);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(108, 15);
			this.label2.TabIndex = 51;
			this.label2.Text = "Minimum Bound";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(209, 58);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(110, 15);
			this.label3.TabIndex = 52;
			this.label3.Text = "Maximum Bound";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(35, 58);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(71, 15);
			this.label4.TabIndex = 53;
			this.label4.Text = "Increment";
			// 
			// uni_inc
			// 
			this.uni_inc.Location = new System.Drawing.Point(112, 55);
			this.uni_inc.Name = "uni_inc";
			this.uni_inc.Size = new System.Drawing.Size(90, 22);
			this.uni_inc.TabIndex = 54;
			this.uni_inc.Text = "0.1";
			// 
			// tbar_a
			// 
			this.tbar_a.Location = new System.Drawing.Point(19, 150);
			this.tbar_a.Name = "tbar_a";
			this.tbar_a.Size = new System.Drawing.Size(124, 45);
			this.tbar_a.TabIndex = 55;
			this.tbar_a.Scroll += new System.EventHandler(this.tbar_a_Scroll);
			// 
			// tbar_b
			// 
			this.tbar_b.Location = new System.Drawing.Point(19, 200);
			this.tbar_b.Name = "tbar_b";
			this.tbar_b.Size = new System.Drawing.Size(124, 45);
			this.tbar_b.TabIndex = 56;
			this.tbar_b.Scroll += new System.EventHandler(this.tbar_b_Scroll);
			// 
			// tbar_c
			// 
			this.tbar_c.Location = new System.Drawing.Point(19, 250);
			this.tbar_c.Name = "tbar_c";
			this.tbar_c.Size = new System.Drawing.Size(124, 45);
			this.tbar_c.TabIndex = 57;
			this.tbar_c.Scroll += new System.EventHandler(this.tbar_c_Scroll);
			// 
			// del_btn
			// 
			this.del_btn.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.del_btn.Location = new System.Drawing.Point(281, 265);
			this.del_btn.Name = "del_btn";
			this.del_btn.Size = new System.Drawing.Size(154, 37);
			this.del_btn.TabIndex = 58;
			this.del_btn.Text = "Delete";
			this.del_btn.UseVisualStyleBackColor = true;
			this.del_btn.Click += new System.EventHandler(this.del_btn_Click);
			// 
			// propertyGrid1
			// 
			this.propertyGrid1.Location = new System.Drawing.Point(305, 317);
			this.propertyGrid1.Name = "propertyGrid1";
			this.propertyGrid1.Size = new System.Drawing.Size(158, 183);
			this.propertyGrid1.TabIndex = 59;
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.ClientSize = new System.Drawing.Size(827, 512);
			this.Controls.Add(this.propertyGrid1);
			this.Controls.Add(this.del_btn);
			this.Controls.Add(this.fs_btn);
			this.Controls.Add(this.user_guide_btn);
			this.Controls.Add(this.save_btn);
			this.Controls.Add(this.tbar_c);
			this.Controls.Add(this.tbar_b);
			this.Controls.Add(this.tbar_a);
			this.Controls.Add(this.uni_inc);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.uni_min);
			this.Controls.Add(this.uni_max);
			this.Controls.Add(this.uni_name);
			this.Controls.Add(this.universe_btn);
			this.Controls.Add(this.tree);
			this.Controls.Add(this.Box_c);
			this.Controls.Add(this.Box_b);
			this.Controls.Add(this.Box_a);
			this.Controls.Add(this.FuncTypSel);
			this.Controls.Add(this.Chart_func);
			this.Controls.Add(this.label_c);
			this.Controls.Add(this.label_b);
			this.Controls.Add(this.label_a);
			this.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MinimumSize = new System.Drawing.Size(820, 550);
			this.Name = "Main";
			this.Text = "Function Generator";
			this.Load += new System.EventHandler(this.Main_Load);
			((System.ComponentModel.ISupportInitialize)(this.Chart_func)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tbar_a)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tbar_b)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tbar_c)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.DataVisualization.Charting.Chart Chart_func;
        private System.Windows.Forms.Label label_a;
        private System.Windows.Forms.Label label_b;
		private System.Windows.Forms.Label label_c;
        private System.Windows.Forms.Button save_btn;
		private System.Windows.Forms.Button user_guide_btn;
		private System.Windows.Forms.ColorDialog color_dialog;
		private System.Windows.Forms.TextBox Box_a;
		private System.Windows.Forms.TextBox Box_c;
		private System.Windows.Forms.TextBox Box_b;
		private System.Windows.Forms.TreeView tree;
		private System.Windows.Forms.ComboBox FuncTypSel;
		private System.Windows.Forms.Button universe_btn;
		private System.Windows.Forms.Button fs_btn;
		private System.Windows.Forms.TextBox uni_name;
		private System.Windows.Forms.TextBox uni_max;
		private System.Windows.Forms.TextBox uni_min;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox uni_inc;
		private System.Windows.Forms.TrackBar tbar_a;
		private System.Windows.Forms.TrackBar tbar_b;
		private System.Windows.Forms.TrackBar tbar_c;
		private System.Windows.Forms.Button del_btn;
		private System.Windows.Forms.PropertyGrid propertyGrid1;
    }
}


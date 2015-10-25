namespace R04522602許泰源Ass04
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
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("InputUniverses", 1, 0);
			System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("OutputUniverses", 3, 2);
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
			this.Chart_func = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.save_btn = new System.Windows.Forms.Button();
			this.user_guide_btn = new System.Windows.Forms.Button();
			this.tree = new System.Windows.Forms.TreeView();
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.FuncTypSel = new System.Windows.Forms.ComboBox();
			this.universe_btn = new System.Windows.Forms.Button();
			this.fs_btn = new System.Windows.Forms.Button();
			this.del_btn = new System.Windows.Forms.Button();
			this.propertyGrid = new System.Windows.Forms.PropertyGrid();
			this.sel_name = new System.Windows.Forms.Label();
			this.tip = new System.Windows.Forms.ToolTip(this.components);
			this.us_btn = new System.Windows.Forms.Button();
			this.OpTypSel = new System.Windows.Forms.ComboBox();
			((System.ComponentModel.ISupportInitialize)(this.Chart_func)).BeginInit();
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
			this.Chart_func.Location = new System.Drawing.Point(505, 14);
			this.Chart_func.Margin = new System.Windows.Forms.Padding(0);
			this.Chart_func.Name = "Chart_func";
			this.Chart_func.Size = new System.Drawing.Size(400, 553);
			this.Chart_func.TabIndex = 4;
			this.Chart_func.Text = "Chart";
			this.Chart_func.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Chart_func_MouseDown);
			this.Chart_func.MouseHover += new System.EventHandler(this.Chart_func_MouseHover);
			this.Chart_func.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Chart_func_MouseMove);
			this.Chart_func.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Chart_func_MouseUp);
			// 
			// save_btn
			// 
			this.save_btn.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.save_btn.Location = new System.Drawing.Point(379, 169);
			this.save_btn.Name = "save_btn";
			this.save_btn.Size = new System.Drawing.Size(111, 27);
			this.save_btn.TabIndex = 15;
			this.save_btn.Text = "Save";
			this.save_btn.UseVisualStyleBackColor = true;
			this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
			// 
			// user_guide_btn
			// 
			this.user_guide_btn.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.user_guide_btn.Location = new System.Drawing.Point(379, 235);
			this.user_guide_btn.Name = "user_guide_btn";
			this.user_guide_btn.Size = new System.Drawing.Size(111, 27);
			this.user_guide_btn.TabIndex = 16;
			this.user_guide_btn.Text = "User Guide";
			this.user_guide_btn.UseVisualStyleBackColor = true;
			this.user_guide_btn.Click += new System.EventHandler(this.user_guide_btn_Click);
			// 
			// tree
			// 
			this.tree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.tree.ImageIndex = 0;
			this.tree.ImageList = this.imageList;
			this.tree.Location = new System.Drawing.Point(14, 89);
			this.tree.Name = "tree";
			treeNode1.ImageIndex = 1;
			treeNode1.Name = "node_in";
			treeNode1.SelectedImageIndex = 0;
			treeNode1.Text = "InputUniverses";
			treeNode2.ImageIndex = 3;
			treeNode2.Name = "node_out";
			treeNode2.SelectedImageIndex = 2;
			treeNode2.Text = "OutputUniverses";
			this.tree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
			this.tree.SelectedImageIndex = 0;
			this.tree.Size = new System.Drawing.Size(230, 478);
			this.tree.TabIndex = 44;
			this.tree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tree_AfterSelect);
			this.tree.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tree_DoubleClick);
			// 
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList.Images.SetKeyName(0, "I1.png");
			this.imageList.Images.SetKeyName(1, "I2.png");
			this.imageList.Images.SetKeyName(2, "O1.png");
			this.imageList.Images.SetKeyName(3, "O2.png");
			this.imageList.Images.SetKeyName(4, "U1.png");
			this.imageList.Images.SetKeyName(5, "U2.png");
			this.imageList.Images.SetKeyName(6, "F1.png");
			this.imageList.Images.SetKeyName(7, "F2.png");
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
            "Sigmoidal Function",
            "SMF",
            "PI"});
			this.FuncTypSel.Location = new System.Drawing.Point(297, 43);
			this.FuncTypSel.Name = "FuncTypSel";
			this.FuncTypSel.Size = new System.Drawing.Size(154, 22);
			this.FuncTypSel.TabIndex = 27;
			this.FuncTypSel.SelectedIndexChanged += new System.EventHandler(this.FuncTypSel_SelectedIndexChanged);
			// 
			// universe_btn
			// 
			this.universe_btn.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.universe_btn.Location = new System.Drawing.Point(44, 33);
			this.universe_btn.Name = "universe_btn";
			this.universe_btn.Size = new System.Drawing.Size(164, 37);
			this.universe_btn.TabIndex = 45;
			this.universe_btn.Text = "Create Universe";
			this.universe_btn.UseVisualStyleBackColor = true;
			this.universe_btn.Click += new System.EventHandler(this.universe_btn_Click);
			// 
			// fs_btn
			// 
			this.fs_btn.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.fs_btn.Location = new System.Drawing.Point(297, 71);
			this.fs_btn.Name = "fs_btn";
			this.fs_btn.Size = new System.Drawing.Size(111, 27);
			this.fs_btn.TabIndex = 46;
			this.fs_btn.Text = "Add Fuzzy Set";
			this.fs_btn.UseVisualStyleBackColor = true;
			this.fs_btn.Click += new System.EventHandler(this.fs_btn_Click);
			// 
			// del_btn
			// 
			this.del_btn.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.del_btn.Location = new System.Drawing.Point(379, 202);
			this.del_btn.Name = "del_btn";
			this.del_btn.Size = new System.Drawing.Size(111, 27);
			this.del_btn.TabIndex = 58;
			this.del_btn.Text = "Delete";
			this.del_btn.UseVisualStyleBackColor = true;
			this.del_btn.Click += new System.EventHandler(this.del_btn_Click);
			// 
			// propertyGrid
			// 
			this.propertyGrid.CategoryForeColor = System.Drawing.SystemColors.InactiveCaptionText;
			this.propertyGrid.Location = new System.Drawing.Point(250, 322);
			this.propertyGrid.Name = "propertyGrid";
			this.propertyGrid.Size = new System.Drawing.Size(249, 245);
			this.propertyGrid.TabIndex = 59;
			this.propertyGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid_PropertyValueChanged);
			// 
			// sel_name
			// 
			this.sel_name.AccessibleRole = System.Windows.Forms.AccessibleRole.IpAddress;
			this.sel_name.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.sel_name.Cursor = System.Windows.Forms.Cursors.Default;
			this.sel_name.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.sel_name.ForeColor = System.Drawing.Color.Lime;
			this.sel_name.Location = new System.Drawing.Point(250, 263);
			this.sel_name.Name = "sel_name";
			this.sel_name.Size = new System.Drawing.Size(249, 49);
			this.sel_name.TabIndex = 60;
			this.sel_name.Text = "NAME";
			this.sel_name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tip
			// 
			this.tip.IsBalloon = true;
			this.tip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
			// 
			// us_btn
			// 
			this.us_btn.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.us_btn.Location = new System.Drawing.Point(297, 136);
			this.us_btn.Name = "us_btn";
			this.us_btn.Size = new System.Drawing.Size(111, 27);
			this.us_btn.TabIndex = 61;
			this.us_btn.Text = "Add Unary Set";
			this.us_btn.UseVisualStyleBackColor = true;
			this.us_btn.Click += new System.EventHandler(this.us_btn_Click);
			// 
			// OpTypSel
			// 
			this.OpTypSel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.OpTypSel.FormattingEnabled = true;
			this.OpTypSel.ImeMode = System.Windows.Forms.ImeMode.On;
			this.OpTypSel.Items.AddRange(new object[] {
            "NegateOperator",
            "ConcentrationOperator"});
			this.OpTypSel.Location = new System.Drawing.Point(297, 108);
			this.OpTypSel.Name = "OpTypSel";
			this.OpTypSel.Size = new System.Drawing.Size(154, 22);
			this.OpTypSel.TabIndex = 62;
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.ClientSize = new System.Drawing.Size(917, 579);
			this.Controls.Add(this.OpTypSel);
			this.Controls.Add(this.us_btn);
			this.Controls.Add(this.sel_name);
			this.Controls.Add(this.propertyGrid);
			this.Controls.Add(this.del_btn);
			this.Controls.Add(this.fs_btn);
			this.Controls.Add(this.user_guide_btn);
			this.Controls.Add(this.save_btn);
			this.Controls.Add(this.universe_btn);
			this.Controls.Add(this.tree);
			this.Controls.Add(this.FuncTypSel);
			this.Controls.Add(this.Chart_func);
			this.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MinimumSize = new System.Drawing.Size(820, 550);
			this.Name = "Main";
			this.Text = "Function Generator";
			this.Load += new System.EventHandler(this.Main_Load);
			((System.ComponentModel.ISupportInitialize)(this.Chart_func)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

		private System.Windows.Forms.DataVisualization.Charting.Chart Chart_func;
        private System.Windows.Forms.Button save_btn;
		private System.Windows.Forms.Button user_guide_btn;
		private System.Windows.Forms.TreeView tree;
		private System.Windows.Forms.ComboBox FuncTypSel;
		private System.Windows.Forms.Button universe_btn;
		private System.Windows.Forms.Button fs_btn;
		private System.Windows.Forms.Button del_btn;
		private System.Windows.Forms.PropertyGrid propertyGrid;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.Label sel_name;
		private System.Windows.Forms.ToolTip tip;
		private System.Windows.Forms.Button us_btn;
		private System.Windows.Forms.ComboBox OpTypSel;
	}
}


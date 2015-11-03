namespace R04522602許泰源Ass05
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
			System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("InputUniverses", 1, 0);
			System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("OutputUniverses", 3, 2);
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
			this.BOpTypSel = new System.Windows.Forms.ComboBox();
			this.bs_btn = new System.Windows.Forms.Button();
			this.FirstFuzzySet = new System.Windows.Forms.Label();
			this.SecondFuzzySet = new System.Windows.Forms.Label();
			this.Cancel_btn = new System.Windows.Forms.Button();
			this.PrimFuzzy = new System.Windows.Forms.GroupBox();
			this.PFS_l = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.sC01 = new System.Windows.Forms.SplitContainer();
			this.sC03 = new System.Windows.Forms.SplitContainer();
			this.sC02 = new System.Windows.Forms.SplitContainer();
			this.tab = new System.Windows.Forms.TabControl();
			this.Page01 = new System.Windows.Forms.TabPage();
			this.Page02 = new System.Windows.Forms.TabPage();
			this.Cut_check = new System.Windows.Forms.CheckBox();
			this.inf_btn = new System.Windows.Forms.Button();
			this.add_rules = new System.Windows.Forms.Button();
			this.del_rules = new System.Windows.Forms.Button();
			this.conds = new System.Windows.Forms.Label();
			this.rules = new System.Windows.Forms.Label();
			this.conditions = new System.Windows.Forms.DataGridView();
			this.ifthenrules = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.Chart_func)).BeginInit();
			this.PrimFuzzy.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.sC01)).BeginInit();
			this.sC01.Panel1.SuspendLayout();
			this.sC01.Panel2.SuspendLayout();
			this.sC01.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.sC03)).BeginInit();
			this.sC03.Panel1.SuspendLayout();
			this.sC03.Panel2.SuspendLayout();
			this.sC03.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.sC02)).BeginInit();
			this.sC02.Panel1.SuspendLayout();
			this.sC02.Panel2.SuspendLayout();
			this.sC02.SuspendLayout();
			this.tab.SuspendLayout();
			this.Page01.SuspendLayout();
			this.Page02.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.conditions)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ifthenrules)).BeginInit();
			this.SuspendLayout();
			// 
			// Chart_func
			// 
			this.Chart_func.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.Chart_func.BackColor = System.Drawing.Color.MistyRose;
			this.Chart_func.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.DiagonalRight;
			legend2.Name = "Legend1";
			this.Chart_func.Legends.Add(legend2);
			this.Chart_func.Location = new System.Drawing.Point(8, 7);
			this.Chart_func.Margin = new System.Windows.Forms.Padding(0);
			this.Chart_func.Name = "Chart_func";
			this.Chart_func.Size = new System.Drawing.Size(455, 645);
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
			this.save_btn.Location = new System.Drawing.Point(135, 165);
			this.save_btn.Name = "save_btn";
			this.save_btn.Size = new System.Drawing.Size(118, 27);
			this.save_btn.TabIndex = 15;
			this.save_btn.Text = "Save";
			this.save_btn.UseVisualStyleBackColor = true;
			this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
			// 
			// user_guide_btn
			// 
			this.user_guide_btn.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.user_guide_btn.Location = new System.Drawing.Point(6, 198);
			this.user_guide_btn.Name = "user_guide_btn";
			this.user_guide_btn.Size = new System.Drawing.Size(120, 27);
			this.user_guide_btn.TabIndex = 16;
			this.user_guide_btn.Text = "User Guide";
			this.user_guide_btn.UseVisualStyleBackColor = true;
			this.user_guide_btn.Click += new System.EventHandler(this.user_guide_btn_Click);
			// 
			// tree
			// 
			this.tree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tree.ImageIndex = 0;
			this.tree.ImageList = this.imageList;
			this.tree.Location = new System.Drawing.Point(9, 48);
			this.tree.Name = "tree";
			treeNode3.ImageIndex = 1;
			treeNode3.Name = "node_in";
			treeNode3.SelectedImageIndex = 0;
			treeNode3.Text = "InputUniverses";
			treeNode4.ImageIndex = 3;
			treeNode4.Name = "node_out";
			treeNode4.SelectedImageIndex = 2;
			treeNode4.Text = "OutputUniverses";
			this.tree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4});
			this.tree.SelectedImageIndex = 0;
			this.tree.Size = new System.Drawing.Size(227, 236);
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
			this.FuncTypSel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.FuncTypSel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.FuncTypSel.FormattingEnabled = true;
			this.FuncTypSel.ImeMode = System.Windows.Forms.ImeMode.On;
			this.FuncTypSel.Items.AddRange(new object[] {
            "Triangular Function",
            "Gaussian Function",
            "Bell Function",
            "Sigmoidal Function",
            "SFuzzySet",
            "PiFuzzySet",
            "Trapezoidal"});
			this.FuncTypSel.Location = new System.Drawing.Point(6, 39);
			this.FuncTypSel.Name = "FuncTypSel";
			this.FuncTypSel.Size = new System.Drawing.Size(155, 22);
			this.FuncTypSel.TabIndex = 27;
			this.FuncTypSel.SelectedIndexChanged += new System.EventHandler(this.FuncTypSel_SelectedIndexChanged);
			// 
			// universe_btn
			// 
			this.universe_btn.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.universe_btn.Location = new System.Drawing.Point(9, 9);
			this.universe_btn.Name = "universe_btn";
			this.universe_btn.Size = new System.Drawing.Size(228, 37);
			this.universe_btn.TabIndex = 45;
			this.universe_btn.Text = "Create Universe";
			this.universe_btn.UseVisualStyleBackColor = true;
			this.universe_btn.Click += new System.EventHandler(this.universe_btn_Click);
			// 
			// fs_btn
			// 
			this.fs_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.fs_btn.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.fs_btn.ForeColor = System.Drawing.Color.Black;
			this.fs_btn.Location = new System.Drawing.Point(167, 28);
			this.fs_btn.Name = "fs_btn";
			this.fs_btn.Size = new System.Drawing.Size(74, 40);
			this.fs_btn.TabIndex = 46;
			this.fs_btn.Text = "Add FuzzySet";
			this.fs_btn.UseVisualStyleBackColor = true;
			this.fs_btn.Click += new System.EventHandler(this.fs_btn_Click);
			// 
			// del_btn
			// 
			this.del_btn.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.del_btn.Location = new System.Drawing.Point(6, 165);
			this.del_btn.Name = "del_btn";
			this.del_btn.Size = new System.Drawing.Size(120, 27);
			this.del_btn.TabIndex = 58;
			this.del_btn.Text = "Delete";
			this.del_btn.UseVisualStyleBackColor = true;
			this.del_btn.Click += new System.EventHandler(this.del_btn_Click);
			// 
			// propertyGrid
			// 
			this.propertyGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.propertyGrid.CategoryForeColor = System.Drawing.SystemColors.InactiveCaptionText;
			this.propertyGrid.Location = new System.Drawing.Point(11, 56);
			this.propertyGrid.Name = "propertyGrid";
			this.propertyGrid.Size = new System.Drawing.Size(255, 232);
			this.propertyGrid.TabIndex = 59;
			this.propertyGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid_PropertyValueChanged);
			// 
			// sel_name
			// 
			this.sel_name.AccessibleRole = System.Windows.Forms.AccessibleRole.IpAddress;
			this.sel_name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.sel_name.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.sel_name.Cursor = System.Windows.Forms.Cursors.Default;
			this.sel_name.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.sel_name.ForeColor = System.Drawing.Color.Lime;
			this.sel_name.Location = new System.Drawing.Point(11, 6);
			this.sel_name.Name = "sel_name";
			this.sel_name.Size = new System.Drawing.Size(255, 38);
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
			this.us_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.us_btn.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.us_btn.ForeColor = System.Drawing.Color.Black;
			this.us_btn.Location = new System.Drawing.Point(167, 24);
			this.us_btn.Name = "us_btn";
			this.us_btn.Size = new System.Drawing.Size(74, 40);
			this.us_btn.TabIndex = 61;
			this.us_btn.Text = "Add FuzzySet";
			this.us_btn.UseVisualStyleBackColor = true;
			this.us_btn.Click += new System.EventHandler(this.us_btn_Click);
			// 
			// OpTypSel
			// 
			this.OpTypSel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.OpTypSel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.OpTypSel.FormattingEnabled = true;
			this.OpTypSel.ImeMode = System.Windows.Forms.ImeMode.On;
			this.OpTypSel.Items.AddRange(new object[] {
            "NegateOperator",
            "ConcentrationOperator",
            "CutOperator",
            "ScaleOperator",
            "YagerComplement",
            "SugenoComplement",
            "Dilate",
            "MoreOrLess",
            "Extremely",
            "Intensify",
            "Diminish"});
			this.OpTypSel.Location = new System.Drawing.Point(6, 35);
			this.OpTypSel.Name = "OpTypSel";
			this.OpTypSel.Size = new System.Drawing.Size(155, 22);
			this.OpTypSel.TabIndex = 62;
			// 
			// BOpTypSel
			// 
			this.BOpTypSel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.BOpTypSel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.BOpTypSel.FormattingEnabled = true;
			this.BOpTypSel.ImeMode = System.Windows.Forms.ImeMode.On;
			this.BOpTypSel.Items.AddRange(new object[] {
            "IntersetOperator",
            "UnionOperator",
            "AlgebraicProduct",
            "BoundedProduct",
            "DrasticProduct",
            "AlgebraicSum",
            "BoundedSum",
            "DrasticSum",
            "DuboisPradeTNorm",
            "DuboisPradeSNorm",
            "HamacherTNorm",
            "HamacherSNorm",
            "FrankTNorm",
            "FrankSNorm",
            "SugenoTNorm",
            "SugenoSNorm",
            "DombiTNorm",
            "DombiSNorm"});
			this.BOpTypSel.Location = new System.Drawing.Point(6, 35);
			this.BOpTypSel.Name = "BOpTypSel";
			this.BOpTypSel.Size = new System.Drawing.Size(155, 22);
			this.BOpTypSel.TabIndex = 64;
			// 
			// bs_btn
			// 
			this.bs_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.bs_btn.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bs_btn.ForeColor = System.Drawing.Color.Black;
			this.bs_btn.Location = new System.Drawing.Point(167, 21);
			this.bs_btn.Name = "bs_btn";
			this.bs_btn.Size = new System.Drawing.Size(74, 40);
			this.bs_btn.TabIndex = 63;
			this.bs_btn.Text = "Add FuzzySet";
			this.bs_btn.UseVisualStyleBackColor = true;
			this.bs_btn.Click += new System.EventHandler(this.bs_btn_Click);
			// 
			// FirstFuzzySet
			// 
			this.FirstFuzzySet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.FirstFuzzySet.BackColor = System.Drawing.SystemColors.ControlDark;
			this.FirstFuzzySet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.FirstFuzzySet.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FirstFuzzySet.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.FirstFuzzySet.Location = new System.Drawing.Point(6, 83);
			this.FirstFuzzySet.Name = "FirstFuzzySet";
			this.FirstFuzzySet.Size = new System.Drawing.Size(174, 23);
			this.FirstFuzzySet.TabIndex = 65;
			this.FirstFuzzySet.Text = "Click to Assign 1st Fuzzy Set";
			this.FirstFuzzySet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.FirstFuzzySet.Click += new System.EventHandler(this.FirstFuzzySet_Click);
			// 
			// SecondFuzzySet
			// 
			this.SecondFuzzySet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.SecondFuzzySet.BackColor = System.Drawing.SystemColors.ControlDark;
			this.SecondFuzzySet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.SecondFuzzySet.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SecondFuzzySet.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.SecondFuzzySet.Location = new System.Drawing.Point(6, 109);
			this.SecondFuzzySet.Name = "SecondFuzzySet";
			this.SecondFuzzySet.Size = new System.Drawing.Size(174, 23);
			this.SecondFuzzySet.TabIndex = 66;
			this.SecondFuzzySet.Text = "Click to Assign 2nd Fuzzy Set";
			this.SecondFuzzySet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.SecondFuzzySet.Click += new System.EventHandler(this.SecondFuzzySet_Click);
			// 
			// Cancel_btn
			// 
			this.Cancel_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.Cancel_btn.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Cancel_btn.ForeColor = System.Drawing.Color.Brown;
			this.Cancel_btn.Location = new System.Drawing.Point(186, 83);
			this.Cancel_btn.Name = "Cancel_btn";
			this.Cancel_btn.Size = new System.Drawing.Size(50, 49);
			this.Cancel_btn.TabIndex = 67;
			this.Cancel_btn.Text = "X";
			this.Cancel_btn.UseVisualStyleBackColor = true;
			this.Cancel_btn.Click += new System.EventHandler(this.Cancel_btn_Click);
			// 
			// PrimFuzzy
			// 
			this.PrimFuzzy.Controls.Add(this.PFS_l);
			this.PrimFuzzy.Controls.Add(this.FuncTypSel);
			this.PrimFuzzy.Controls.Add(this.fs_btn);
			this.PrimFuzzy.ForeColor = System.Drawing.Color.Navy;
			this.PrimFuzzy.Location = new System.Drawing.Point(6, 6);
			this.PrimFuzzy.Name = "PrimFuzzy";
			this.PrimFuzzy.Size = new System.Drawing.Size(247, 76);
			this.PrimFuzzy.TabIndex = 68;
			this.PrimFuzzy.TabStop = false;
			this.PrimFuzzy.Text = "Primary Fuzzy Set";
			// 
			// PFS_l
			// 
			this.PFS_l.AutoSize = true;
			this.PFS_l.ForeColor = System.Drawing.Color.DarkRed;
			this.PFS_l.Location = new System.Drawing.Point(6, 18);
			this.PFS_l.Name = "PFS_l";
			this.PFS_l.Size = new System.Drawing.Size(99, 14);
			this.PFS_l.TabIndex = 47;
			this.PFS_l.Text = "Type Of Fuzzy Set";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.OpTypSel);
			this.groupBox1.Controls.Add(this.us_btn);
			this.groupBox1.ForeColor = System.Drawing.Color.Navy;
			this.groupBox1.Location = new System.Drawing.Point(6, 88);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(247, 71);
			this.groupBox1.TabIndex = 69;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Unary Operated Fuzzy Set";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.ForeColor = System.Drawing.Color.DarkRed;
			this.label1.Location = new System.Drawing.Point(6, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(99, 14);
			this.label1.TabIndex = 47;
			this.label1.Text = "Type Of Fuzzy Set";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.BOpTypSel);
			this.groupBox2.Controls.Add(this.Cancel_btn);
			this.groupBox2.Controls.Add(this.bs_btn);
			this.groupBox2.Controls.Add(this.SecondFuzzySet);
			this.groupBox2.Controls.Add(this.FirstFuzzySet);
			this.groupBox2.ForeColor = System.Drawing.Color.Navy;
			this.groupBox2.Location = new System.Drawing.Point(259, 6);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(247, 142);
			this.groupBox2.TabIndex = 70;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Binary Operated Fuzzy Set";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.ForeColor = System.Drawing.Color.DarkRed;
			this.label3.Location = new System.Drawing.Point(6, 60);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(58, 14);
			this.label3.TabIndex = 65;
			this.label3.Text = "Operands";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.ForeColor = System.Drawing.Color.DarkRed;
			this.label2.Location = new System.Drawing.Point(6, 18);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(99, 14);
			this.label2.TabIndex = 47;
			this.label2.Text = "Type Of Fuzzy Set";
			// 
			// sC01
			// 
			this.sC01.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sC01.Location = new System.Drawing.Point(0, 0);
			this.sC01.Name = "sC01";
			// 
			// sC01.Panel1
			// 
			this.sC01.Panel1.Controls.Add(this.sC03);
			// 
			// sC01.Panel2
			// 
			this.sC01.Panel2.BackColor = System.Drawing.SystemColors.ControlLight;
			this.sC01.Panel2.Controls.Add(this.Chart_func);
			this.sC01.Size = new System.Drawing.Size(998, 661);
			this.sC01.SplitterDistance = 522;
			this.sC01.TabIndex = 71;
			// 
			// sC03
			// 
			this.sC03.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sC03.Location = new System.Drawing.Point(0, 0);
			this.sC03.Name = "sC03";
			this.sC03.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// sC03.Panel1
			// 
			this.sC03.Panel1.Controls.Add(this.sC02);
			// 
			// sC03.Panel2
			// 
			this.sC03.Panel2.BackColor = System.Drawing.SystemColors.ControlLight;
			this.sC03.Panel2.Controls.Add(this.tab);
			this.sC03.Size = new System.Drawing.Size(522, 661);
			this.sC03.SplitterDistance = 297;
			this.sC03.TabIndex = 72;
			// 
			// sC02
			// 
			this.sC02.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sC02.Location = new System.Drawing.Point(0, 0);
			this.sC02.Name = "sC02";
			// 
			// sC02.Panel1
			// 
			this.sC02.Panel1.BackColor = System.Drawing.SystemColors.ControlLight;
			this.sC02.Panel1.Controls.Add(this.universe_btn);
			this.sC02.Panel1.Controls.Add(this.tree);
			// 
			// sC02.Panel2
			// 
			this.sC02.Panel2.BackColor = System.Drawing.SystemColors.ControlLight;
			this.sC02.Panel2.Controls.Add(this.sel_name);
			this.sC02.Panel2.Controls.Add(this.propertyGrid);
			this.sC02.Size = new System.Drawing.Size(522, 297);
			this.sC02.SplitterDistance = 246;
			this.sC02.TabIndex = 0;
			// 
			// tab
			// 
			this.tab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tab.Controls.Add(this.Page01);
			this.tab.Controls.Add(this.Page02);
			this.tab.Location = new System.Drawing.Point(3, 3);
			this.tab.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
			this.tab.Name = "tab";
			this.tab.SelectedIndex = 0;
			this.tab.Size = new System.Drawing.Size(523, 360);
			this.tab.TabIndex = 5;
			// 
			// Page01
			// 
			this.Page01.BackColor = System.Drawing.SystemColors.ControlLight;
			this.Page01.Controls.Add(this.PrimFuzzy);
			this.Page01.Controls.Add(this.groupBox1);
			this.Page01.Controls.Add(this.user_guide_btn);
			this.Page01.Controls.Add(this.save_btn);
			this.Page01.Controls.Add(this.del_btn);
			this.Page01.Controls.Add(this.groupBox2);
			this.Page01.Location = new System.Drawing.Point(4, 23);
			this.Page01.Name = "Page01";
			this.Page01.Padding = new System.Windows.Forms.Padding(3);
			this.Page01.Size = new System.Drawing.Size(515, 333);
			this.Page01.TabIndex = 0;
			this.Page01.Text = "Fuzzy Sets";
			// 
			// Page02
			// 
			this.Page02.BackColor = System.Drawing.SystemColors.ControlLight;
			this.Page02.Controls.Add(this.Cut_check);
			this.Page02.Controls.Add(this.inf_btn);
			this.Page02.Controls.Add(this.add_rules);
			this.Page02.Controls.Add(this.del_rules);
			this.Page02.Controls.Add(this.conds);
			this.Page02.Controls.Add(this.rules);
			this.Page02.Controls.Add(this.conditions);
			this.Page02.Controls.Add(this.ifthenrules);
			this.Page02.Location = new System.Drawing.Point(4, 22);
			this.Page02.Name = "Page02";
			this.Page02.Padding = new System.Windows.Forms.Padding(3);
			this.Page02.Size = new System.Drawing.Size(515, 334);
			this.Page02.TabIndex = 1;
			this.Page02.Text = "If-Then Rules";
			// 
			// Cut_check
			// 
			this.Cut_check.AutoSize = true;
			this.Cut_check.Checked = true;
			this.Cut_check.CheckState = System.Windows.Forms.CheckState.Checked;
			this.Cut_check.Location = new System.Drawing.Point(322, 187);
			this.Cut_check.Name = "Cut_check";
			this.Cut_check.Size = new System.Drawing.Size(44, 18);
			this.Cut_check.TabIndex = 49;
			this.Cut_check.Text = "Cut";
			this.Cut_check.UseVisualStyleBackColor = true;
			this.Cut_check.Click += new System.EventHandler(this.Cut_check_Click);
			// 
			// inf_btn
			// 
			this.inf_btn.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.inf_btn.Location = new System.Drawing.Point(414, 182);
			this.inf_btn.Name = "inf_btn";
			this.inf_btn.Size = new System.Drawing.Size(91, 29);
			this.inf_btn.TabIndex = 48;
			this.inf_btn.Text = "Inference";
			this.inf_btn.UseVisualStyleBackColor = true;
			this.inf_btn.Click += new System.EventHandler(this.inf_btn_Click);
			// 
			// add_rules
			// 
			this.add_rules.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.add_rules.Location = new System.Drawing.Point(419, 6);
			this.add_rules.Name = "add_rules";
			this.add_rules.Size = new System.Drawing.Size(86, 29);
			this.add_rules.TabIndex = 47;
			this.add_rules.Text = "Add Rules";
			this.add_rules.UseVisualStyleBackColor = true;
			this.add_rules.Click += new System.EventHandler(this.add_rules_Click);
			// 
			// del_rules
			// 
			this.del_rules.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.del_rules.Location = new System.Drawing.Point(322, 6);
			this.del_rules.Name = "del_rules";
			this.del_rules.Size = new System.Drawing.Size(91, 29);
			this.del_rules.TabIndex = 46;
			this.del_rules.Text = "Delete Rules";
			this.del_rules.UseVisualStyleBackColor = true;
			this.del_rules.Click += new System.EventHandler(this.del_rules_Click);
			// 
			// conds
			// 
			this.conds.AutoSize = true;
			this.conds.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.conds.ForeColor = System.Drawing.Color.Purple;
			this.conds.Location = new System.Drawing.Point(6, 186);
			this.conds.Name = "conds";
			this.conds.Size = new System.Drawing.Size(89, 19);
			this.conds.TabIndex = 2;
			this.conds.Text = "Conditions";
			// 
			// rules
			// 
			this.rules.AutoSize = true;
			this.rules.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rules.ForeColor = System.Drawing.Color.Purple;
			this.rules.Location = new System.Drawing.Point(6, 10);
			this.rules.Name = "rules";
			this.rules.Size = new System.Drawing.Size(50, 19);
			this.rules.TabIndex = 1;
			this.rules.Text = "Rules";
			// 
			// conditions
			// 
			this.conditions.AllowUserToAddRows = false;
			this.conditions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.conditions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.conditions.Location = new System.Drawing.Point(10, 217);
			this.conditions.Name = "conditions";
			this.conditions.ReadOnly = true;
			this.conditions.RowTemplate.Height = 24;
			this.conditions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.conditions.Size = new System.Drawing.Size(499, 112);
			this.conditions.TabIndex = 0;
			this.conditions.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.conditions_CellClick);
			// 
			// ifthenrules
			// 
			this.ifthenrules.AllowUserToAddRows = false;
			this.ifthenrules.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ifthenrules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.ifthenrules.Location = new System.Drawing.Point(10, 41);
			this.ifthenrules.Name = "ifthenrules";
			this.ifthenrules.ReadOnly = true;
			this.ifthenrules.RowTemplate.Height = 24;
			this.ifthenrules.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.ifthenrules.Size = new System.Drawing.Size(499, 125);
			this.ifthenrules.TabIndex = 0;
			this.ifthenrules.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ifthenrules_CellClick);
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.ClientSize = new System.Drawing.Size(998, 661);
			this.Controls.Add(this.sC01);
			this.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MinimumSize = new System.Drawing.Size(820, 550);
			this.Name = "Main";
			this.Text = "Function Generator";
			this.Load += new System.EventHandler(this.Main_Load);
			((System.ComponentModel.ISupportInitialize)(this.Chart_func)).EndInit();
			this.PrimFuzzy.ResumeLayout(false);
			this.PrimFuzzy.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.sC01.Panel1.ResumeLayout(false);
			this.sC01.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.sC01)).EndInit();
			this.sC01.ResumeLayout(false);
			this.sC03.Panel1.ResumeLayout(false);
			this.sC03.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.sC03)).EndInit();
			this.sC03.ResumeLayout(false);
			this.sC02.Panel1.ResumeLayout(false);
			this.sC02.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.sC02)).EndInit();
			this.sC02.ResumeLayout(false);
			this.tab.ResumeLayout(false);
			this.Page01.ResumeLayout(false);
			this.Page02.ResumeLayout(false);
			this.Page02.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.conditions)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ifthenrules)).EndInit();
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
		private System.Windows.Forms.ComboBox BOpTypSel;
		private System.Windows.Forms.Button bs_btn;
		private System.Windows.Forms.Label FirstFuzzySet;
		private System.Windows.Forms.Label SecondFuzzySet;
		private System.Windows.Forms.Button Cancel_btn;
		private System.Windows.Forms.GroupBox PrimFuzzy;
		private System.Windows.Forms.Label PFS_l;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.SplitContainer sC01;
		private System.Windows.Forms.SplitContainer sC02;
		private System.Windows.Forms.SplitContainer sC03;
		private System.Windows.Forms.TabControl tab;
		private System.Windows.Forms.TabPage Page01;
		private System.Windows.Forms.DataGridView ifthenrules;
		private System.Windows.Forms.TabPage Page02;
		private System.Windows.Forms.DataGridView conditions;
		private System.Windows.Forms.Button add_rules;
		private System.Windows.Forms.Button del_rules;
		private System.Windows.Forms.Label conds;
		private System.Windows.Forms.Label rules;
		private System.Windows.Forms.CheckBox Cut_check;
		private System.Windows.Forms.Button inf_btn;
	}
}


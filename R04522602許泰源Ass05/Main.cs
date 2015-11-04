using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing.Imaging;

namespace R04522602許泰源Ass05{
    public partial class Main : Form{
		private const double INFINITY = 1e100, NEG_INFINITY = -1e100;
		private DataPoint selectedDataPoint = null;
		private HitTestResult hitResult = null;
		protected static Random rnd = new Random(unchecked(DateTime.Now.Ticks.GetHashCode()));
		private bool out_exist = false;
		private FuzzySet conclusion;
		private TreeNode tmp_node = null;
		//Definition of tags of different control points
		private enum Control_Point : int{
			tri_L = 0,
			tri_M = 1,
			tri_R = 2,
			gau_M = 3,
			gau_S = 4,
			bel_C = 5,
			bel_W = 6,
			bel_S = 7,
			sig_C = 8,
			sig_S = 9
		}
		//Control Point Flag
		private int Ctrl_Pt = -1;
		
		public Main(){
			
			InitializeComponent();
			
			//tree.CheckBoxes = true;
			tree.HideSelection = false;
			
			tree.SelectedNode = tree.Nodes[0];
			FuncTypSel.SelectedIndex = 0;
			OpTypSel.SelectedIndex = 0;
			BOpTypSel.SelectedIndex = 0;
			inf_btn.Enabled = false;

			tip.ToolTipTitle = "操作提示";
			tip.SetToolTip(this.Chart_func,"點拉線圖上的控制點，\n即時調整曲線參數。");
			tip.ToolTipIcon = ToolTipIcon.Info;
			//Change the language of exception messages into Engilsh.
            System.Threading.Thread.CurrentThread.CurrentCulture = 
                                        new System.Globalization.CultureInfo("en-US");

            System.Threading.Thread.CurrentThread.CurrentUICulture = 
                                        new System.Globalization.CultureInfo("en-US");
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            //Detect keypressed events. If ESC was pressed, terminate the application.
            if (keyData == Keys.Escape) {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }       

        private void user_guide_btn_Click(object sender, EventArgs e){
            //If "User Guide" button is clicked, open readme.txt.
            Process notepad = new Process();
            notepad.StartInfo.FileName = "readme.txt";
            notepad.Start();
        }

        private void Main_Load(object sender, EventArgs e){
            //Activate KeyPreview.
            this.KeyPreview = true;
	    }
		
		//control the object show when FuncTypSel changed
		private void FuncTypSel_SelectedIndexChanged(object sender, EventArgs e){
			;
		}

		//add universe
		private void universe_btn_Click(object sender, EventArgs e){
			Universe u;
			if(tree.SelectedNode.Level == 0 && tree.SelectedNode.Name == "node_in"){
				try{
						u = new Universe(Chart_func);
						TreeNode tn = new TreeNode( u.Name );
						tn.Tag = u;
						tn.Checked = true;
						//tree.Nodes.Add(tn);
						tree.SelectedNode.Nodes.Add(tn);
						tree.SelectedNode.Expand();
						tn.SelectedImageIndex = 4;
						tn.ImageIndex = 5;
						if(out_exist){
							DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
							col.Name = u.Name;
							col.HeaderText = u.Name;
							ifthenrules.Columns.Insert(ifthenrules.Columns.Count-1, col);
						}
						else{
							ifthenrules.Columns.Add(u.Name, u.Name);
						}
						conditions.Columns.Add(u.Name, u.Name);
						if (conditions.Rows.Count<1)
							conditions.Rows.Add();
				}catch{
					MessageBox.Show("Invalid Parameters or Name!!");
				}
			}
			else if(tree.SelectedNode.Level == 0 && tree.SelectedNode.Name == "node_out" && tree.SelectedNode.Nodes.Count==0){
				try{
						u = new Universe(Chart_func);
						TreeNode tn = new TreeNode( u.Name );
						tn.Tag = u;
						tn.Checked = true;
						//tree.Nodes.Add(tn);
						tree.SelectedNode.Nodes.Add(tn);
						tree.SelectedNode.Expand();
						tn.SelectedImageIndex = 4;
						tn.ImageIndex = 5;
						ifthenrules.Columns.Add(u.Name, u.Name);
						
						out_exist = true;
				}catch{
					MessageBox.Show("Invalid Parameters or Name!!");
				}
			}
			else{
				MessageBox.Show("You can't add more than one Universe to OutputUniverses");
			}
		}

		//add unary fuzzy set
		private void fs_btn_Click(object sender, EventArgs e){
			FuzzySet fs = null;
            Universe u;
			if(tree.SelectedNode != null)
				if(tree.SelectedNode.Tag is Universe){
					u = (Universe) tree.SelectedNode.Tag;

					switch (FuncTypSel.SelectedIndex){
						case 0:
							fs = new triangle_fuzzy_set(u);
							break;

						case 1:
							fs = new gaussian_fuzzy_set(u);
							break;

						case 2:
							fs = new bell_fuzzy_set(u);
							break;

						case 3:
							fs = new sigmoidal_fuzzy_set(u);
							break;

						case 4:
							fs = new S_fuzzy_set(u);
							break;

						case 5:
							fs = new PI_fuzzy_set(u);
							break;

						case 6:
							fs = new Trapezoidal(u);
							break;
					}
					if(fs!=null){
						TreeNode tn = new TreeNode(fs.Name);
						tn.Tag = fs;
						tn.SelectedImageIndex = 6;
						tn.ImageIndex = 7;
						tn.Checked = true;
						tree.SelectedNode.Nodes.Add(tn);
						tree.SelectedNode.Expand();
						fs.Display = true;
						
						//tree.SelectedNode = tn;
					}
				}
		}

		//if a line was selected, change the width of line and the object show on the panel
		private void tree_AfterSelect(object sender, TreeViewEventArgs e){
			foreach(TreeNode tn0 in tree.Nodes){
				foreach(TreeNode tn1 in tn0.Nodes){
					foreach(TreeNode tn2 in tn1.Nodes){
						((FuzzySet)tn2.Tag).Enchant = false;
					}
				}
			}
			
			if(tree.SelectedNode.Level == 0)
				universe_btn.Enabled = true;
			else
				universe_btn.Enabled = false;
			
			if(tree.SelectedNode.Tag is Universe)
				fs_btn.Enabled = true;
			else
				fs_btn.Enabled = false;

			if(tree.SelectedNode.Tag is FuzzySet){
				us_btn.Enabled = true;
			}
			else{
				us_btn.Enabled = false;
			}

			if(FirstFuzzySet.Tag != null && SecondFuzzySet.Tag !=null)
				bs_btn.Enabled = true;
			else
				bs_btn.Enabled = false;
			
			propertyGrid.SelectedObject = tree.SelectedNode.Tag;

			if(tree.SelectedNode.Level == 0)
				sel_name.Text = "";
			else if(tree.SelectedNode.Level == 1){
				sel_name.Text = "Universe:" + tree.SelectedNode.Text;
			}
			else if(tree.SelectedNode.Level == 2){
				((FuzzySet)tree.SelectedNode.Tag).Enchant = true;
				sel_name.Text = "Fuzzy Set:" + tree.SelectedNode.Text;
			}
			
		}

		//delete selected node
		private void del_btn_Click(object sender, EventArgs e){
			if(tree.SelectedNode != null && tree.SelectedNode.Level > 0){
				if(tree.SelectedNode.Tag is Universe){
					Universe u = tree.SelectedNode.Tag as Universe;
					foreach(TreeNode tn in tree.SelectedNode.Nodes){
						FuzzySet f = (FuzzySet)tn.Tag;
						u.hostChart.Series.Remove(u.hostChart.Series.FindByName(f.Name));
					}
					Chart_func.ChartAreas[u.Name].Visible = false;
					tree.SelectedNode.Remove();
				}
				else{
					Universe u = tree.SelectedNode.Parent.Tag as Universe;
					FuzzySet f = tree.SelectedNode.Tag as FuzzySet;
					if(FirstFuzzySet.Tag == tree.SelectedNode.Tag){
						FirstFuzzySet.Tag = null;
						FirstFuzzySet.Text = "Click to Assign 1st Fuzzy Set";
					}
					if(SecondFuzzySet.Tag == tree.SelectedNode.Tag){
						SecondFuzzySet.Tag = null;
						SecondFuzzySet.Text = "Click to Assign 2nd Fuzzy Set";
					}
					u.hostChart.Series.Remove(u.hostChart.Series.FindByName(f.Name));
					tree.SelectedNode.Remove();
				}
			}
		}

		//Change the name show on the tag of the tree
		private void propertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e){
			if(tree.SelectedNode.Tag is FuzzySet)
				((FuzzySet)tree.SelectedNode.Tag).Enchant = true;
			if (e.ChangedItem.Label == "Name"){
				tree.SelectedNode.Text = e.ChangedItem.Value.ToString();
				if(tree.SelectedNode.Level == 1){
					Universe u = tree.SelectedNode.Tag as Universe;
					sel_name.Text = "Universe:" + tree.SelectedNode.Text;
				}
				else if(tree.SelectedNode.Level == 2){
					Universe u = tree.SelectedNode.Parent.Tag as Universe;
					FuzzySet f = tree.SelectedNode.Tag as FuzzySet;					
					sel_name.Text = "Fuzzy Set:" + tree.SelectedNode.Text;
				}
				if(FirstFuzzySet.Tag != null)
					if(FirstFuzzySet.Text != (FirstFuzzySet.Tag.ToString()))
						FirstFuzzySet.Text = (FirstFuzzySet.Tag.ToString());
				if(SecondFuzzySet.Tag != null)
					if(SecondFuzzySet.Text != (SecondFuzzySet.Tag.ToString()))
						SecondFuzzySet.Text = (SecondFuzzySet.Tag.ToString());

				foreach (TreeNode treeNode in this.tree.Nodes){
					foreach (TreeNode treeNode2 in treeNode.Nodes){
						foreach (TreeNode treeNode3 in treeNode2.Nodes){
							if(treeNode3.Text != ((FuzzySet)treeNode3.Tag).Name){
								treeNode3.Text = ((FuzzySet)treeNode3.Tag).Name;
								Universe u = treeNode2.Tag as Universe;
								FuzzySet f = treeNode3.Tag as FuzzySet;
							}
						}
					}
				}
            }
		}

		//Double Click to control 'visible' property of universe and fuzzysets
		private void tree_DoubleClick(object sender, TreeNodeMouseClickEventArgs e){
			Universe u;
			if(tree.SelectedNode != null){
				if(tree.SelectedNode.Tag is Universe){
					u = tree.SelectedNode.Tag as Universe;
					if(u.hostChart.ChartAreas[u.Name].Visible){
						u.hostChart.ChartAreas[u.Name].Visible = false;
						foreach(TreeNode tn in tree.SelectedNode.Nodes){
							FuzzySet f = (FuzzySet)tn.Tag;
							u.hostChart.Series.FindByName(f.Name).Enabled = false;
						}
					}
					else{
						u.hostChart.ChartAreas[u.Name].Visible = true;
						
						foreach(TreeNode tn in tree.SelectedNode.Nodes){
							FuzzySet f = (FuzzySet)tn.Tag;
							u.hostChart.Series.FindByName(f.Name).Enabled = false;
						}
					}
				}
				else if(tree.SelectedNode.Level==2){
					u = tree.SelectedNode.Parent.Tag as Universe;
					FuzzySet f = (FuzzySet)tree.SelectedNode.Tag;
					u.hostChart.Series.FindByName(f.Name).Enabled = !u.hostChart.Series.FindByName(f.Name).Enabled;
				}
			}
		}

		//When mouse_down, catch the line and control point on it clicked
		private void Chart_func_MouseDown(object sender, MouseEventArgs e){
			hitResult = Chart_func.HitTest( e.X, e.Y );

			// Initialize currently selected data point
			selectedDataPoint = null;
			if( hitResult.ChartElementType == ChartElementType.DataPoint ){
				selectedDataPoint = (DataPoint)hitResult.Object;
				// Show point value as label
				//selectedDataPoint.IsValueShownAsLabel = true;

				// Mouse coordinates should not be outside of the chart 
				int coordinatey = e.Y;
				if(coordinatey < 0)
					coordinatey = 0;
				if(coordinatey > Chart_func.Size.Height - 1)
					coordinatey = Chart_func.Size.Height - 1;

				int coordinatex = e.X;
				if(coordinatex < 0)
					coordinatex = 0;
				if(coordinatex > Chart_func.Size.Width - 1)
					coordinatex = Chart_func.Size.Width - 1;
				
				// Calculate new Y value from current cursor position
				double yValue = Chart_func.ChartAreas[hitResult.ChartArea.Name].AxisY.PixelPositionToValue(coordinatey);
				double xValue = Chart_func.ChartAreas[hitResult.ChartArea.Name].AxisX.PixelPositionToValue(coordinatex);
				yValue = Math.Min(yValue, Chart_func.ChartAreas[hitResult.ChartArea.Name].AxisY.Maximum);
				yValue = Math.Max(yValue, Chart_func.ChartAreas[hitResult.ChartArea.Name].AxisY.Minimum);
				xValue = Math.Min(xValue, Chart_func.ChartAreas[hitResult.ChartArea.Name].AxisX.Maximum);
				xValue = Math.Max(xValue, Chart_func.ChartAreas[hitResult.ChartArea.Name].AxisX.Minimum);

				foreach(TreeNode tn0 in tree.Nodes){
					foreach(TreeNode tn1 in tn0.Nodes){
						foreach(TreeNode tn2 in tn1.Nodes){
							Universe u = tn1.Tag as Universe;
							if(tn2.Tag.ToString() == hitResult.Series.Name){
								((FuzzySet)tn2.Tag).Enchant = true;
								tree.SelectedNode = tn2;
								if(tn2.Tag is triangle_fuzzy_set){
									triangle_fuzzy_set f = tn2.Tag as triangle_fuzzy_set;
									if( f.Name == hitResult.Series.Name && u.Name == hitResult.ChartArea.AxisX.Title){
										double max, min;
										max = Chart_func.ChartAreas[hitResult.ChartArea.Name].AxisX.Maximum;
										min = Chart_func.ChartAreas[hitResult.ChartArea.Name].AxisX.Minimum;
										tree.SelectedNode = tn2;
										if(Math.Abs(xValue-f.Left)<0.05 && Math.Abs(yValue-0.0)<0.05){
											Ctrl_Pt = (int)Control_Point.tri_L;
										}
										else if(Math.Abs(xValue-f.Middle)<0.05 || Math.Abs(xValue-1.0)<0.05){
											Ctrl_Pt = (int)Control_Point.tri_M;
										}
										else if(Math.Abs(xValue-f.Right)<0.05 || Math.Abs(xValue-0.0)<0.05){
											Ctrl_Pt = (int)Control_Point.tri_R;
										}
										else{
											Ctrl_Pt = -1;
										}
									};
								}
								else if(tn2.Tag is gaussian_fuzzy_set){
									gaussian_fuzzy_set f = tn2.Tag as gaussian_fuzzy_set;
									if( f.Name == hitResult.Series.Name && u.Name == hitResult.ChartArea.AxisX.Title){
										double max, min;
										max = Chart_func.ChartAreas[hitResult.ChartArea.Name].AxisX.Maximum;
										min = Chart_func.ChartAreas[hitResult.ChartArea.Name].AxisX.Minimum;
										tree.SelectedNode = tn2;
										if(Math.Abs(xValue-f.Mean)<0.05 && Math.Abs(yValue-1.0f)<0.05){
											Ctrl_Pt = (int)Control_Point.gau_M;
										}
										else if(Math.Abs(xValue-((max-min)*0.25+f.Mean))<0.05 || Math.Abs(xValue-(-(max-min)*0.25+f.Mean))<0.05){
											Ctrl_Pt = (int)Control_Point.gau_S;
										}
										else{
											Ctrl_Pt = -1;
										}
									}
								}
								else if(tn2.Tag is bell_fuzzy_set){
									bell_fuzzy_set f = tn2.Tag as bell_fuzzy_set;
									if( f.Name == hitResult.Series.Name && u.Name == hitResult.ChartArea.AxisX.Title){
										double max, min;
										max = Chart_func.ChartAreas[hitResult.ChartArea.Name].AxisX.Maximum;
										min = Chart_func.ChartAreas[hitResult.ChartArea.Name].AxisX.Minimum;
										tree.SelectedNode = tn2;
										if(Math.Abs(xValue-f.Center)<0.05 && Math.Abs(yValue-1.0f)<0.05){
											Ctrl_Pt = (int)Control_Point.bel_C;
										}
										else if(Math.Abs(xValue-((max-min)*0.25+f.Center))<0.05 || Math.Abs(xValue-(-(max-min)*0.25+f.Center))<0.05){
											Ctrl_Pt = (int)Control_Point.bel_S;
										}
										else{
											Ctrl_Pt = -1;
										}
									}
								}
								else
									Ctrl_Pt = -1;
							}
						}
					}
				}
			}
		}

		//When mouse_move, update the parameter with the corresponding control point
		private void Chart_func_MouseMove(object sender, MouseEventArgs e){			
			// Check if data point selected
			if(selectedDataPoint != null){
				// Mouse coordinates should not be outside of the chart 
				int coordinatey = e.Y;
				if(coordinatey < 0)
					coordinatey = 0;
				if(coordinatey > Chart_func.Size.Height - 1)
					coordinatey = Chart_func.Size.Height - 1;

				int coordinatex = e.X;
				if(coordinatex < 0)
					coordinatex = 0;
				if(coordinatex > Chart_func.Size.Width - 1)
					coordinatex = Chart_func.Size.Width - 1;

				// Calculate new Y value from current cursor position
				double yValue = Chart_func.ChartAreas[hitResult.ChartArea.Name].AxisY.PixelPositionToValue(coordinatey);
				double xValue = Chart_func.ChartAreas[hitResult.ChartArea.Name].AxisX.PixelPositionToValue(coordinatex);
				yValue = Math.Min(yValue, Chart_func.ChartAreas[hitResult.ChartArea.Name].AxisY.Maximum);
				yValue = Math.Max(yValue, Chart_func.ChartAreas[hitResult.ChartArea.Name].AxisY.Minimum);
				xValue = Math.Min(xValue, Chart_func.ChartAreas[hitResult.ChartArea.Name].AxisX.Maximum);
				xValue = Math.Max(xValue, Chart_func.ChartAreas[hitResult.ChartArea.Name].AxisX.Minimum);

				

			    if(tree.SelectedNode.Tag is triangle_fuzzy_set){
					triangle_fuzzy_set f = tree.SelectedNode.Tag as triangle_fuzzy_set;
					if(Ctrl_Pt==(int)Control_Point.tri_L){
						f.Left = xValue;
					}
					else if(Ctrl_Pt==(int)Control_Point.tri_M){
						f.Middle = xValue;
					}
					else if(Ctrl_Pt==(int)Control_Point.tri_R){
						f.Right = xValue;
					}
				}
				else if(tree.SelectedNode.Tag is gaussian_fuzzy_set){
					gaussian_fuzzy_set f = tree.SelectedNode.Tag as gaussian_fuzzy_set;
					if(Ctrl_Pt==(int)Control_Point.gau_S){
						f.Std = Math.Abs(xValue-f.Mean);
					}
					else if(Ctrl_Pt==(int)Control_Point.gau_M){
						f.Mean = xValue;
					}
				}
				else if(tree.SelectedNode.Tag is bell_fuzzy_set){
					bell_fuzzy_set f = tree.SelectedNode.Tag as bell_fuzzy_set;
					if(Ctrl_Pt==(int)Control_Point.bel_S){
						f.Slope = Math.Abs(xValue-f.Center);
					}
					else if(Ctrl_Pt==(int)Control_Point.bel_C){
						f.Center = xValue;
					}
				}
				// Invalidate chart
				Chart_func.Invalidate();
				((FuzzySet)tree.SelectedNode.Tag).Enchant = true;
			}
		}

		//When mouse_up, release the seleted line and control point
		private void Chart_func_MouseUp(object sender, MouseEventArgs e){
			selectedDataPoint = null;
			propertyGrid.Refresh();
		}

		//Add binary fuzzy set
		private void us_btn_Click(object sender, EventArgs e){
			FuzzySet operand = null;
            UnaryOperator op = null;
            FuzzySet fs = null;

            operand = (FuzzySet)tree.SelectedNode.Tag;
            switch (OpTypSel.SelectedIndex){
                case 0: // Not
					fs = ~operand;
                    break;
                case 1: // Con
                    op = new ConcentrationOperator();
                    break;
				case 2: // Cut
                    fs = rnd.NextDouble() - operand;
                    break;
				case 3: // Scale
                    fs = rnd.NextDouble() * operand;
                    break;
				case 4: // Yager
                    op = new YagerComplement();
					break;
				case 5: // Sugeno
                    op = new SugenoComplement();
                    break;
				case 6: // Dilate
                    op = new DilateOperator();
                    break;
				case 7: // MoreOrLess
                    op = new MoreOrLess();
                    break;
				case 8: // Extremely
                    op = new Extremely();
                    break;
				case 9: // Intensify
                    op = new Intensify();
                    break;
				case 10: // Diminish
                    op = new Diminish();
                    break;
            }
			if(OpTypSel.SelectedIndex!=0 && OpTypSel.SelectedIndex!=2 && OpTypSel.SelectedIndex!=3)
				fs = new UnaryOperatedFuzzySet(operand, op);

            TreeNode tn = new TreeNode(fs.Name);
            tn.Tag = fs;
            tn.ImageIndex = 7;
			tn.SelectedImageIndex = 6;

            tree.SelectedNode.Parent.Nodes.Add(tn);
			fs.Display = true;
		}

		//When the cursor hover in the area of Chart_func, change its style to a hand
		private void Chart_func_MouseHover(object sender, EventArgs e){
			Chart_func.Cursor = Cursors.Hand;
			
		}

		//Select first fuzzyset
		private void FirstFuzzySet_Click(object sender, EventArgs e){
			if(tree.SelectedNode.Level > 1)
				if(tree.SelectedNode.Tag != SecondFuzzySet.Tag){
					if(SecondFuzzySet.Tag==null){
						FirstFuzzySet.Tag = tree.SelectedNode.Tag;
						FirstFuzzySet.Text = FirstFuzzySet.Tag.ToString();
						tmp_node = tree.SelectedNode;
					}
					else if(((FuzzySet)tree.SelectedNode.Tag).TheUniverse == ((FuzzySet)SecondFuzzySet.Tag).TheUniverse){
						FirstFuzzySet.Tag = tree.SelectedNode.Tag;
						FirstFuzzySet.Text = FirstFuzzySet.Tag.ToString();
						tmp_node = tree.SelectedNode;
					}
					else{
						MessageBox.Show(string.Format("Two fussy set operands are not defined in the same universe for binary operation."), "Change Selection Please", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				else{
					MessageBox.Show(string.Format("The selected fuzzy set {0} has been selected as the other operand.", tree.SelectedNode.Name), "Change Selection Please", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			else
				MessageBox.Show(string.Format("The selected fuzzy set {0} is invalid set.", tree.SelectedNode.Name), "Change Selection Please", MessageBoxButtons.OK, MessageBoxIcon.Hand);

			if(FirstFuzzySet.Tag != null && SecondFuzzySet.Tag !=null)
				bs_btn.Enabled = true;
			else
				bs_btn.Enabled = false;
		}

		//Select second fuzzyset
		private void SecondFuzzySet_Click(object sender, EventArgs e){
			if(tree.SelectedNode.Level > 1)
				if(tree.SelectedNode.Tag != FirstFuzzySet.Tag){
					if(FirstFuzzySet.Tag==null){
						SecondFuzzySet.Tag = tree.SelectedNode.Tag;
						SecondFuzzySet.Text = SecondFuzzySet.Tag.ToString();
						tmp_node = tree.SelectedNode;
					}
					else if(((FuzzySet)tree.SelectedNode.Tag).TheUniverse == ((FuzzySet)FirstFuzzySet.Tag).TheUniverse){
						SecondFuzzySet.Tag = tree.SelectedNode.Tag;
						SecondFuzzySet.Text = SecondFuzzySet.Tag.ToString();
						tmp_node = tree.SelectedNode;
					}
					else{
						MessageBox.Show(string.Format("Two fussy set operands are not defined in the same universe for binary operation."), "Change Selection Please", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				else{
					MessageBox.Show(string.Format("The selected fuzzy set {0} has been selected as the other operand.", tree.SelectedNode.Name), "Change Selection Please", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			else
				MessageBox.Show(string.Format("The selected fuzzy set {0} is invalid set.", tree.SelectedNode.Name), "Change Selection Please", MessageBoxButtons.OK, MessageBoxIcon.Hand);

			if(FirstFuzzySet.Tag != null && SecondFuzzySet.Tag !=null)
				bs_btn.Enabled = true;
			else
				bs_btn.Enabled = false;
		}

		private void Cancel_btn_Click(object sender, EventArgs e){
			FirstFuzzySet.Tag = null;
			SecondFuzzySet.Tag = null;
			FirstFuzzySet.Text = "Click to Assign 1st Fuzzy Set";
			SecondFuzzySet.Text = "Click to Assign 2nd Fuzzy Set";
		}

		private void bs_btn_Click(object sender, EventArgs e){
			if(FirstFuzzySet.Tag != null && SecondFuzzySet.Tag != null){
				FuzzySet One = (FuzzySet)FirstFuzzySet.Tag;
				FuzzySet Two = (FuzzySet)SecondFuzzySet.Tag;
				FuzzySet fs = null;
				BinaryOperator op = null;
				switch(BOpTypSel.SelectedIndex){
					case 0: //Intersect
						fs = One&Two;
						break;
					case 1: //Union
						fs = One|Two;
						break;
					case 2: //AlgebraicProduct
						fs = One*Two;
						break;
					case 3: //BoundedProduct
						op = new BoundedProduct();
						break;
					case 4: //DrasticProduct
						op = new DrasticProduct();
						break;
					case 5: //AlgebraicSum
						op = new AlgebraicSum();
						break;
					case 6: //BoundedSum
						op = new BoundedSum();
						break;
					case 7: //DrasticSum
						op = new DrasticSum();
						break;
					case 8: //DuboisPradeTNorm
						op = new DuboisPradeTNorm();
						break;
					case 9: //DuboisPradeSNorm
						op = new DuboisPradeSNorm();
						break;
					case 10: //HamacherTNorm
						op = new HamacherTNorm();
						break;
					case 11: //HamacherSNorm
						op = new HamacherSNorm();
						break;
					case 12: //FrankTNorm
						op = new FrankTNorm();
						break;
					case 13: //FrankSNorm
						op = new FrankSNorm();
						break;
					case 14: //SugenoTNorm
						op = new SugenoTNorm();
						break;
					case 15: //SugenoSNorm
						op = new SugenoSNorm();
						break;
					case 16: //DombiTNorm
						op = new DombiTNorm();
						break;
					case 17: //DombiSNorm
						op = new DombiSNorm();
						break;
				}

				if(BOpTypSel.SelectedIndex > 2)
					fs = new BinaryOperatedFuzzySet(One, Two, op);
				TreeNode tn = new TreeNode(fs.Name);
				tn.Tag = fs;
				tn.ImageIndex = 7;
				tn.SelectedImageIndex = 6;
				tmp_node.Parent.Nodes.Add(tn);
				fs.Display = true;/*
				if(tree.SelectedNode.Level == 2){
					tree.SelectedNode.Parent.Nodes.Add(tn);
					fs.Display = true;
				}
				if(tree.SelectedNode.Level == 1){
					tree.SelectedNode.Nodes.Add(tn);
					fs.Display = true;
				}*/
				
			}

		}

		private void area_btn_Click(object sender, EventArgs e){
			if(tree.SelectedNode.Level>1){
				FuzzySet fs = (FuzzySet)tree.SelectedNode.Tag;
				fs.set_style();
			}
		}

		private void del_rules_Click(object sender, EventArgs e){
			
			if(ifthenrules.RowCount > 0 && ifthenrules.CurrentCell!=null){
				if(MessageBox.Show("The selected rule will be deleted. Are your sure to delete it?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes){
					ifthenrules.Rows[ifthenrules.SelectedCells[0].RowIndex].Selected = true;
					
					if (ifthenrules.SelectedRows.Count > 0)
						ifthenrules.Rows.RemoveAt(ifthenrules.SelectedRows.Count-1);
					if(ifthenrules.RowCount==0)
						inf_btn.Enabled = false	;
				}
			}
		}

		private void ifthenrules_CellClick(object sender, DataGridViewCellEventArgs e){
			if(e.ColumnIndex>=0 && e.RowIndex>=0)
				if(tree.SelectedNode.Level > 1 && tree.SelectedNode.Parent.Parent.Name == "node_in"){
					if(e.ColumnIndex == tree.SelectedNode.Parent.Index){
						ifthenrules.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = tree.SelectedNode.Tag;
					}
					else
						MessageBox.Show("Please selecte the fuzzyset in the corresponding universe!");
				}
				else if(tree.SelectedNode.Level > 1 && tree.SelectedNode.Parent.Parent.Name == "node_out"){
					if(e.ColumnIndex == ifthenrules.ColumnCount-1){
						ifthenrules.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = tree.SelectedNode.Tag;
					}
					else
						MessageBox.Show("Please selecte the fuzzyset in the corresponding universe!");
				}
		}

		private void conditions_CellClick(object sender, DataGridViewCellEventArgs e){
			if(e.ColumnIndex>=0 && e.RowIndex>=0)
				if(tree.SelectedNode.Level > 1 && tree.SelectedNode.Parent.Parent.Name == "node_in"){
					if(e.ColumnIndex == tree.SelectedNode.Parent.Index){
						conditions.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = tree.SelectedNode.Tag;
					}
					else
						MessageBox.Show("Please selecte the fuzzyset in the corresponding universe!");
				}
		}

		private void add_rules_Click(object sender, EventArgs e){
			if(ifthenrules.ColumnCount > 0)
				ifthenrules.Rows.Add();
			if(ifthenrules.RowCount>0)
				inf_btn.Enabled = true;
		}

		List<IfThenFuzzyRule> allRules = new List<IfThenFuzzyRule>();
        //FuzzySet finalFS;

        void UpdateAllRules() {
            allRules.Clear();

            for (int i = 0; i < ifthenrules.Rows.Count; i++){
                List<FuzzySet> ant = new List<FuzzySet>();

                int j;
                for ( j = 0; j < ifthenrules.Columns.Count - 1; j++){
                    ant.Add( (FuzzySet)  ifthenrules.Rows[i].Cells[j].Value);
                }

                IfThenFuzzyRule arule = new IfThenFuzzyRule(ant, (FuzzySet)ifthenrules.Rows[i].Cells[j].Value, Cut_check.Text=="Cut");
                allRules.Add(arule);
            }
        }

		private void inf_btn_Click(object sender, EventArgs e){
			inference();
		}

		private void inference() {
			UpdateAllRules();

			//if (finalFS != null) finalFS.DisplayEnabled = false;
            //finalFS = null;

            List<FuzzySet> conds = new List<FuzzySet>();
			for(int i=0; i<conditions.Columns.Count; i++){
				conds.Add(conditions.Rows[0].Cells[i].Value as FuzzySet);
			}
			if(conclusion!=null){
				conclusion.Display = false;
				conclusion = null;
			}
			conclusion = allRules[0].Inference(conds);
            for (int i = 1; i < allRules.Count; i++){
				conclusion |= allRules[i].Inference(conds);
            }

			conclusion.Name = "Output";
			
			conclusion.Display = true;
			conclusion.set_style();

            //finalFS.DisplayEnabled = true;
            //finalFS.ShowFuzzyArea = true; // shade the area covered by the fuzzy set
		}

		private void Cut_check_Click(object sender, EventArgs e){
			if(Cut_check.Text == "Cut")
				Cut_check.Text = "Scaled";
			else
				Cut_check.Text = "Cut";
			Cut_check.Checked = true;
			inference();
		}

		private void save_btn_Click(object sender, EventArgs e){
            //If "Save" button is clicked, create a save form.
			//Metafile f = new Metafile("test");
            SaveFileDialog save = new SaveFileDialog();
			save.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif|Png Image|*.png|Wmf Image|*.wmf";
            save.Title = "Save an Image File";
			if(save.ShowDialog()==System.Windows.Forms.DialogResult.OK && save.FileName!=""){
				switch(save.FilterIndex){
					case 1:
						Chart_func.SaveImage(save.FileName,System.Drawing.Imaging.ImageFormat.Jpeg);
						break;
					case 2:
						Chart_func.SaveImage(save.FileName,System.Drawing.Imaging.ImageFormat.Bmp);
						break;
					case 3:
						Chart_func.SaveImage(save.FileName,System.Drawing.Imaging.ImageFormat.Gif);
						break;
					case 4:
						Chart_func.SaveImage(save.FileName,System.Drawing.Imaging.ImageFormat.Png);
						break;
					case 5:
						Chart_func.SaveImage(save.FileName,System.Drawing.Imaging.ImageFormat.Wmf);
						break;
				}
			}
            
        }
		
    }
}

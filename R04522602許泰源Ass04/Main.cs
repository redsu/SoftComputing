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

namespace R04522602許泰源Ass04{
    public partial class Main : Form{
		private const double INFINITY = 1e100, NEG_INFINITY = -1e100;
		
		public Main(){

			InitializeComponent();
			
			tree.CheckBoxes = true;
			tree.HideSelection = false;

			Box_a.Enabled = false;
			Box_b.Enabled = false;
			Box_c.Enabled = false;
			
			FuncTypSel.SelectedIndex = 0;

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

        private void save_btn_Click(object sender, EventArgs e){
            //If "Save" button is clicked, create a save form.
			//Metafile f = new Metafile("test");
            save_win save = new save_win();
            DialogResult dr = save.ShowDialog();
            //Get the filename.
            string sv_name = save.GetMsg();
            //Save the file of the current image by the filename.
			//f = Chart_func.Images.
			
            Chart_func.SaveImage(sv_name,System.Drawing.Imaging.ImageFormat.Wmf);
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
			switch(FuncTypSel.SelectedIndex){
				case 0:
                    label_c.Visible = true;
					tbar_c.Visible  = true;
					Box_c.Visible   = true;

					tbar_a.Enabled = 
					tbar_b.Enabled = 
					tbar_c.Enabled = false;

                    label_a.Text = "Left";
                    label_b.Text = "Turning";
                    label_c.Text = "Right";

					break;
				case 1:
                    label_c.Visible = false;
					tbar_c.Visible  = false;
                    Box_c.Visible   = false;

					tbar_a.Enabled = 
					tbar_b.Enabled = 
					tbar_c.Enabled = false;

                    label_a.Text = "Mean";
                    label_b.Text = "Std";

					break;
				case 2:
                    label_c.Visible = true;
                    tbar_c.Visible  = true;
                    Box_c.Visible   = true;

					tbar_a.Enabled = 
					tbar_b.Enabled = 
					tbar_c.Enabled = false;

                    label_a.Text = "Half-width";
                    label_b.Text = "Slope";
                    label_c.Text = "Center";

					break;
				case 3:
					label_c.Visible = false;
					tbar_c.Visible  = false;
                    Box_c.Visible   = false;

					tbar_a.Enabled = 
					tbar_b.Enabled = 
					tbar_c.Enabled = false;

                    label_a.Text = "Slope";
                    label_b.Text = "X-Point";

					break;
			}
		}

		//add universe
		private void universe_btn_Click(object sender, EventArgs e){
			Universe u;
			try{
				double max, min;
				min = double.Parse(uni_min.Text);
				max = double.Parse(uni_max.Text);
				if(max-min >= 10.0){
					u = new Universe(Chart_func, uni_name.Text, min, max);
					TreeNode tn = new TreeNode( u.name );
					tn.Tag = u;
					tn.Checked = true;
					tree.Nodes.Add(tn);
					tree.SelectedNode = tn;
					uni_name.Text = "X" + u.GetCount().ToString();
					uni_max.Text = "10.0";
					uni_min.Text= "0.0";
				}
				else{
					uni_max.Text = "10.0";
					uni_min.Text= "0.0";
					MessageBox.Show("Invalid Range of ChartArea!!");
				}
			}catch{
				MessageBox.Show("Invalid Parameters or Name!!");
			}
		}

		//add fuzzy sets
		private void fs_btn_Click(object sender, EventArgs e){
			FuzzySet fs = null;
            Universe u;
			if(tree.SelectedNode != null)
				if(tree.SelectedNode.Tag is Universe){
					u = (Universe) tree.SelectedNode.Tag;

					switch (FuncTypSel.SelectedIndex){
						case 0:
							fs = new triangle_function(u);
							break;

						case 1:
							fs = new gaussian_function(u);
							break;

						case 2:
							fs = new bell_function(u);
							break;

						case 3:
							fs = new sigmoidal_function(u);
							break;
					}
					if(fs!=null){
						TreeNode tn = new TreeNode(fs.GetName());
						tn.Tag = fs;
						tn.Checked = true;
						tree.SelectedNode.Nodes.Add(tn);
						tree.SelectedNode.Expand();
						//tree.SelectedNode = tn;
					}
				}
		}

		//if a line was selected, change the width of line and the object show on the panel
		private void tree_AfterSelect(object sender, TreeViewEventArgs e){
			foreach(TreeNode t in tree.Nodes){
				foreach(TreeNode tn in t.Nodes){
					if(tn.Tag is triangle_function){
						triangle_function f = tn.Tag as triangle_function;
						f.SetWidth(1);
					}
					if(tn.Tag is gaussian_function){
						gaussian_function f = tn.Tag as gaussian_function;
						f.SetWidth(1);
					}
					if(tn.Tag is bell_function){
						bell_function f = tn.Tag as bell_function;
						f.SetWidth(1);
					}
					if(tn.Tag is sigmoidal_function){
						sigmoidal_function f = tn.Tag as sigmoidal_function;
						f.SetWidth(1);
					}
				}
			}
			if(e.Node.Level == 1){
				if(e.Node.Tag is triangle_function){
					triangle_function f = e.Node.Tag as triangle_function;
					Universe u = e.Node.Parent.Tag as Universe;
					propertyGrid1.SelectedObject = f;
					propertyGrid1.Refresh();
					f.SetWidth(2);
					label_c.Visible = true;
					tbar_c.Visible  = true;
					Box_c.Visible   = true;

					tbar_a.Enabled = 
					tbar_b.Enabled = 
					tbar_c.Enabled = true;

                    label_a.Text = "Left";
                    label_b.Text = "Turning";
                    label_c.Text = "Right";

					tbar_a.Minimum = (int)u.Xmin;
					tbar_a.Maximum = (int)u.Xmax;
					tbar_b.Minimum = (int)u.Xmin;
					tbar_b.Maximum = (int)u.Xmax;
					tbar_c.Minimum = (int)u.Xmin;
					tbar_c.Maximum = (int)u.Xmax;
					
					tbar_a.Value = (int)f.GetParameter("Left");
					tbar_b.Value = (int)f.GetParameter("Middle");
					tbar_c.Value = (int)f.GetParameter("Right");

					Box_a.Text = tbar_a.Value.ToString();
					Box_b.Text = tbar_b.Value.ToString();
					Box_c.Text = tbar_c.Value.ToString();
				}
				else if(e.Node.Tag is gaussian_function){
					gaussian_function f = e.Node.Tag as gaussian_function;
					Universe u = e.Node.Parent.Tag as Universe;
					propertyGrid1.SelectedObject = f;
					propertyGrid1.Refresh();
					f.SetWidth(2);
					label_c.Visible = false;
					tbar_c.Visible  = false;
                    Box_c.Visible   = false;

					tbar_a.Enabled = 
					tbar_b.Enabled = 
					tbar_c.Enabled = true;

                    label_a.Text = "Mean";
                    label_b.Text = "Std";
					
					tbar_a.Minimum = (int)u.Xmin;
					tbar_a.Maximum = (int)u.Xmax;
					tbar_b.Minimum = (int)u.Xmin;
					tbar_b.Maximum = (int)u.Xmax;
					
					tbar_a.Value = (int)f.GetParameter("mean");
					tbar_b.Value = (int)f.GetParameter("sigma");

					Box_a.Text = tbar_a.Value.ToString();
					Box_b.Text = tbar_b.Value.ToString();
				}
				else if(e.Node.Tag is bell_function){
					bell_function f = e.Node.Tag as bell_function;
					Universe u = e.Node.Parent.Tag as Universe;
					propertyGrid1.SelectedObject = f;
					propertyGrid1.Refresh();
					f.SetWidth(2);
					label_c.Visible = true;
                    tbar_c.Visible  = true;
                    Box_c.Visible   = true;

					tbar_a.Enabled = 
					tbar_b.Enabled = 
					tbar_c.Enabled = true;

                    label_a.Text = "Half-width";
                    label_b.Text = "Slope";
                    label_c.Text = "Center";
					
					tbar_a.Minimum = (int)u.Xmin;
					tbar_a.Maximum = (int)u.Xmax;
					tbar_b.Minimum = (int)u.Xmin;
					tbar_b.Maximum = (int)u.Xmax;
					tbar_c.Minimum = (int)u.Xmin;
					tbar_c.Maximum = (int)u.Xmax;
					
					tbar_a.Value = (int)f.GetParameter("Half-width");
					tbar_b.Value = (int)f.GetParameter("Slope");
					tbar_c.Value = (int)f.GetParameter("Center");

					Box_a.Text = tbar_a.Value.ToString();
					Box_b.Text = tbar_b.Value.ToString();
					Box_c.Text = tbar_c.Value.ToString();
				}
				else if(e.Node.Tag is sigmoidal_function){
					sigmoidal_function f = e.Node.Tag as sigmoidal_function;
					Universe u = e.Node.Parent.Tag as Universe;
					propertyGrid1.SelectedObject = f;
					propertyGrid1.Refresh();
					f.SetWidth(2);
					label_c.Visible = false;
					tbar_c.Visible  = false;
                    Box_c.Visible   = false;

					tbar_a.Enabled = 
					tbar_b.Enabled = 
					tbar_c.Enabled = true;

                    label_a.Text = "Slope";
                    label_b.Text = "X-Point";
					
					tbar_a.Minimum = -1000;
					tbar_a.Maximum = 1000;
					tbar_b.Minimum = (int)u.Xmin;
					tbar_b.Maximum = (int)u.Xmax;
					
					tbar_a.Value = (int)f.GetParameter("Slope");
					tbar_b.Value = (int)f.GetParameter("CrossoverPoint");

					Box_a.Text = tbar_a.Value.ToString();
					Box_b.Text = tbar_b.Value.ToString();
				}
			}
			else{
				tbar_a.Enabled =
				tbar_b.Enabled =
				tbar_c.Enabled = false;
			}
		}
		//use checkbox to control 'visible' property of universe and fuzzysets
		private void tree_AfterChecked(object sender, TreeViewEventArgs e){
			if(e.Action != TreeViewAction.Unknown)
				foreach(TreeNode t in tree.Nodes){
					if(t.Tag is Universe){
						Universe u = t.Tag as Universe;
						if(t.Checked){
							u.hostChart.ChartAreas[u.name].Visible = true;
							foreach(TreeNode tn in t.Nodes){
								if(tn.Tag is triangle_function){
									triangle_function f = tn.Tag as triangle_function;
									if(tn.Checked)
										u.hostChart.Series.FindByName(f.GetName()).Enabled = true;
									else
										u.hostChart.Series.FindByName(f.GetName()).Enabled = false;
								}
								if(tn.Tag is gaussian_function){
									gaussian_function f = tn.Tag as gaussian_function;
									if(tn.Checked)
										u.hostChart.Series.FindByName(f.GetName()).Enabled = true;
									else
										u.hostChart.Series.FindByName(f.GetName()).Enabled = false;
								}
								if(tn.Tag is bell_function){
									bell_function f = tn.Tag as bell_function;
									if(tn.Checked)
										u.hostChart.Series.FindByName(f.GetName()).Enabled = true;
									else
										u.hostChart.Series.FindByName(f.GetName()).Enabled = false;
								}
								if(tn.Tag is sigmoidal_function){
									sigmoidal_function f = tn.Tag as sigmoidal_function;
									if(tn.Checked)
										u.hostChart.Series.FindByName(f.GetName()).Enabled = true;
									else
										u.hostChart.Series.FindByName(f.GetName()).Enabled = false;
								}
							}
						}
						else{
							u.hostChart.ChartAreas[u.name].Visible = false;
						}
					}
				}
		}
		//adjust parameter a
		private void tbar_a_Scroll(object sender, EventArgs e){
			propertyGrid1.Refresh();
			if(tree.SelectedNode.Tag is triangle_function){
				triangle_function f = tree.SelectedNode.Tag as triangle_function;
				if(tbar_a.Value<=tbar_b.Value){
					f.SetParameter("Left", tbar_a.Value);
					Box_a.Text = tbar_a.Value.ToString();
				}
				else{
					tbar_a.Value = tbar_b.Value;
					Box_a.Text = tbar_b.Value.ToString();
				}
				f.Refresh();
			}
			else if(tree.SelectedNode.Tag is gaussian_function){
				gaussian_function f = tree.SelectedNode.Tag as gaussian_function;
				f.SetParameter("mean", tbar_a.Value);
				Box_a.Text = tbar_a.Value.ToString();
				f.Refresh();
			}
			else if(tree.SelectedNode.Tag is bell_function){
				bell_function f = tree.SelectedNode.Tag as bell_function;
				f.SetParameter("Half-width", tbar_a.Value);
				Box_a.Text = tbar_a.Value.ToString();
				f.Refresh();
			}
			else if(tree.SelectedNode.Tag is sigmoidal_function){
				sigmoidal_function f = tree.SelectedNode.Tag as sigmoidal_function;
				f.SetParameter("Slope", (double)(tbar_a.Value)/100);
				Box_a.Text = ((double)tbar_a.Value/100.0f).ToString();
				f.Refresh();
			}
			
		}
		//adjust parameter b
		private void tbar_b_Scroll(object sender, EventArgs e){
			propertyGrid1.Refresh();
			if(tree.SelectedNode.Tag is triangle_function){
				triangle_function f = tree.SelectedNode.Tag as triangle_function;
				if(tbar_b.Value<=tbar_c.Value&&tbar_b.Value>=tbar_a.Value){
					f.SetParameter("Middle", tbar_b.Value);
					Box_b.Text = tbar_b.Value.ToString();
					f.Refresh();
				}
				else if(tbar_b.Value>=tbar_c.Value){
					tbar_b.Value=tbar_c.Value;
					Box_b.Text = tbar_c.Value.ToString();
				}
				else if(tbar_b.Value<=tbar_a.Value){
					tbar_b.Value=tbar_a.Value;
					Box_b.Text = tbar_a.Value.ToString();
				}
				f.Refresh();
			}
			else if(tree.SelectedNode.Tag is gaussian_function){
				gaussian_function f = tree.SelectedNode.Tag as gaussian_function;
				f.SetParameter("sigma", tbar_b.Value);
				Box_b.Text = tbar_b.Value.ToString();
				f.Refresh();
			}
			else if(tree.SelectedNode.Tag is bell_function){
				bell_function f = tree.SelectedNode.Tag as bell_function;
				f.SetParameter("Slope", tbar_b.Value);
				Box_b.Text = tbar_b.Value.ToString();
				f.Refresh();
			}
			else if(tree.SelectedNode.Tag is sigmoidal_function){
				sigmoidal_function f = tree.SelectedNode.Tag as sigmoidal_function;
				f.SetParameter("CrossoverPoint", tbar_b.Value);
				Box_b.Text = tbar_b.Value.ToString();
				f.Refresh();
			}
		}
		//adjust parameter c
		private void tbar_c_Scroll(object sender, EventArgs e){
			propertyGrid1.Refresh();
			if(tree.SelectedNode.Tag is triangle_function){
				triangle_function f = tree.SelectedNode.Tag as triangle_function;
				if(tbar_c.Value>=tbar_b.Value){
					f.SetParameter("Right", tbar_c.Value);
					Box_c.Text = tbar_c.Value.ToString();
					f.Refresh();
				}
				else{
					tbar_c.Value = tbar_b.Value;
					Box_c.Text = tbar_b.Value.ToString();
				}
			}
			else if(tree.SelectedNode.Tag is bell_function){
				bell_function f = tree.SelectedNode.Tag as bell_function;
				f.SetParameter("Center", tbar_c.Value);
				Box_c.Text = tbar_c.Value.ToString();
				f.Refresh();
			}
		}

		//delete selected node
		private void del_btn_Click(object sender, EventArgs e){
			if(tree.SelectedNode != null){
				if(tree.SelectedNode.Tag is Universe){
					Universe u = tree.SelectedNode.Tag as Universe;
					Chart_func.ChartAreas[u.name].Visible = false;
					tree.SelectedNode.Remove();
				}
				else{
					Universe u = tree.SelectedNode.Parent.Tag as Universe;
					if(tree.SelectedNode.Tag is triangle_function){
						triangle_function f = tree.SelectedNode.Tag as triangle_function;					
						u.hostChart.Series.Remove(u.hostChart.Series.FindByName(f.GetName()));
						tree.SelectedNode.Remove();
					}
					else if(tree.SelectedNode.Tag is gaussian_function){
						gaussian_function f = tree.SelectedNode.Tag as gaussian_function;					
						u.hostChart.Series.Remove(u.hostChart.Series.FindByName(f.GetName()));
						tree.SelectedNode.Remove();
					}
					else if(tree.SelectedNode.Tag is bell_function){
						bell_function f = tree.SelectedNode.Tag as bell_function;					
						u.hostChart.Series.Remove(u.hostChart.Series.FindByName(f.GetName()));
						tree.SelectedNode.Remove();
					}
					else if(tree.SelectedNode.Tag is sigmoidal_function){
						sigmoidal_function f = tree.SelectedNode.Tag as sigmoidal_function;					
						u.hostChart.Series.Remove(u.hostChart.Series.FindByName(f.GetName()));
						tree.SelectedNode.Remove();
					}
				}
			}
		}

		//Double Click to Rename universe	
		private void tree_DoubleClick(object sender, TreeNodeMouseClickEventArgs e){
			Universe u;
			if(tree.SelectedNode != null){
				if(tree.SelectedNode.Tag is Universe){
					Rename rename = new Rename();
					DialogResult dr = rename.ShowDialog();
					string findname = rename.GetMsg();
					if(findname != ""){
						foreach(TreeNode tn in tree.Nodes){
							u = tn.Tag as Universe;
							if(u.name == findname){
								MessageBox.Show("Universe name EXIST!!");
								return;
							}
						}
						u = tree.SelectedNode.Tag as Universe;
						tree.SelectedNode.Text = findname;
						u.hostChart.ChartAreas[u.name].Name = findname;
						u.hostChart.ChartAreas[findname].AxisX.Title = findname;
						u.name = findname;
					}
				}
			}
		}
    }
}

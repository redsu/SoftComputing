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

namespace R04522602許泰源Ass03{
    public partial class Main : Form{
		private const double INFINITY = 1e100, NEG_INFINITY = -1e100;
		
		public Main(){
			
			InitializeComponent();
			
			//tree.CheckBoxes = true;
			tree.HideSelection = false;
			
			tree.SelectedNode = tree.Nodes[0];
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
                    

					break;
				case 1:
                    

					break;
				case 2:
                    

					break;
				case 3:
					

					break;
			}
		}

		//add universe
		private void universe_btn_Click(object sender, EventArgs e){
			Universe u;
			if(tree.SelectedNode.Level == 0){
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
				}catch{
					MessageBox.Show("Invalid Parameters or Name!!");
				}
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
						TreeNode tn = new TreeNode(fs.Name);
						tn.Tag = fs;
						tn.SelectedImageIndex = 6;
						tn.ImageIndex = 7;
						tn.Checked = true;
						tree.SelectedNode.Nodes.Add(tn);
						tree.SelectedNode.Expand();
						//tree.SelectedNode = tn;
					}
				}
		}

		//if a line was selected, change the width of line and the object show on the panel
		private void tree_AfterSelect(object sender, TreeViewEventArgs e){
			foreach(TreeNode tn0 in tree.Nodes){
				foreach(TreeNode tn1 in tn0.Nodes){
					foreach(TreeNode tn2 in tn1.Nodes){
						if(tn2.Tag is triangle_function){
							triangle_function f = tn2.Tag as triangle_function;
							f.SetWidth(1);
						}
						if(tn2.Tag is gaussian_function){
							gaussian_function f = tn2.Tag as gaussian_function;
							f.SetWidth(1);
						}
						if(tn2.Tag is bell_function){
							bell_function f = tn2.Tag as bell_function;
							f.SetWidth(1);
						}
						if(tn2.Tag is sigmoidal_function){
							sigmoidal_function f = tn2.Tag as sigmoidal_function;
							f.SetWidth(1);
						}
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
			
			propertyGrid.SelectedObject = tree.SelectedNode.Tag;

			if(tree.SelectedNode.Level == 0)
				sel_name.Text = "";
			else if(tree.SelectedNode.Level == 1){
				sel_name.Text = "Universe:" + tree.SelectedNode.Text;
			}
			else if(tree.SelectedNode.Level == 2){
				if(tree.SelectedNode.Tag is triangle_function){
					triangle_function f = tree.SelectedNode.Tag as triangle_function;
					sel_name.Text = "Fuzzy Set:" + tree.SelectedNode.Text;
					f.SetWidth(2);
				}
				else if(tree.SelectedNode.Tag is gaussian_function){
					gaussian_function f = tree.SelectedNode.Tag as gaussian_function;
					sel_name.Text = "Fuzzy Set:" + tree.SelectedNode.Text;
					f.SetWidth(2);
				}
				else if(tree.SelectedNode.Tag is bell_function){
					bell_function f = tree.SelectedNode.Tag as bell_function;
					sel_name.Text = "Fuzzy Set:" + tree.SelectedNode.Text;
					f.SetWidth(2);
				}
				else if(tree.SelectedNode.Tag is sigmoidal_function){
					sigmoidal_function f = tree.SelectedNode.Tag as sigmoidal_function;
					sel_name.Text = "Fuzzy Set:" + tree.SelectedNode.Text;
					f.SetWidth(2);
				}
			}
			
		}
		//use checkbox to control 'visible' property of universe and fuzzysets
		private void tree_AfterChecked(object sender, TreeViewEventArgs e){
			if(e.Action != TreeViewAction.Unknown)
				foreach(TreeNode t in tree.Nodes){
					if(t.Tag is Universe){
						Universe u = t.Tag as Universe;
						if(t.Checked){
							u.hostChart.ChartAreas[u.tmp_name].Visible = true;
							foreach(TreeNode tn in t.Nodes){
								if(tn.Tag is triangle_function){
									triangle_function f = tn.Tag as triangle_function;
									if(tn.Checked)
										u.hostChart.Series[f.tmp_name].Enabled = true;
									else
										u.hostChart.Series[f.tmp_name].Enabled = false;
								}
								if(tn.Tag is gaussian_function){
									gaussian_function f = tn.Tag as gaussian_function;
									if(tn.Checked)
										u.hostChart.Series[f.tmp_name].Enabled = true;
									else
										u.hostChart.Series[f.tmp_name].Enabled = false;
								}
								if(tn.Tag is bell_function){
									bell_function f = tn.Tag as bell_function;
									if(tn.Checked)
										u.hostChart.Series[f.tmp_name].Enabled = true;
									else
										u.hostChart.Series[f.tmp_name].Enabled = false;
								}
								if(tn.Tag is sigmoidal_function){
									sigmoidal_function f = tn.Tag as sigmoidal_function;
									if(tn.Checked)
										u.hostChart.Series[f.tmp_name].Enabled = true;
									else
										u.hostChart.Series[f.tmp_name].Enabled = false;
								}
							}
						}
						else{
							u.hostChart.ChartAreas[u.tmp_name].Visible = false;
							foreach(TreeNode tn in t.Nodes){
								if(tn.Tag is triangle_function){
									triangle_function f = tn.Tag as triangle_function;
									u.hostChart.Series[f.tmp_name].Enabled = false;
								}
								if(tn.Tag is gaussian_function){
									gaussian_function f = tn.Tag as gaussian_function;
									u.hostChart.Series[f.tmp_name].Enabled = false;
								}
								if(tn.Tag is bell_function){
									bell_function f = tn.Tag as bell_function;
									u.hostChart.Series[f.tmp_name].Enabled = false;
								}
								if(tn.Tag is sigmoidal_function){
									sigmoidal_function f = tn.Tag as sigmoidal_function;
									u.hostChart.Series[f.tmp_name].Enabled = false;
								}
							}
						}
					}
				}
		}
		

		//delete selected node
		private void del_btn_Click(object sender, EventArgs e){
			if(tree.SelectedNode != null){
				if(tree.SelectedNode.Tag is Universe){
					Universe u = tree.SelectedNode.Tag as Universe;
					foreach(TreeNode tn in tree.SelectedNode.Nodes){
						if(tn.Tag is triangle_function){
							triangle_function f = tn.Tag as triangle_function;
							u.hostChart.Series.Remove(u.hostChart.Series.FindByName(f.Name));
						}
						if(tn.Tag is gaussian_function){
							gaussian_function f = tn.Tag as gaussian_function;
							u.hostChart.Series.Remove(u.hostChart.Series.FindByName(f.Name));
						}
						if(tn.Tag is bell_function){
							bell_function f = tn.Tag as bell_function;
							u.hostChart.Series.Remove(u.hostChart.Series.FindByName(f.Name));
						}
						if(tn.Tag is sigmoidal_function){
							sigmoidal_function f = tn.Tag as sigmoidal_function;
							u.hostChart.Series.Remove(u.hostChart.Series.FindByName(f.Name));
						}						
					}
					Chart_func.ChartAreas[u.tmp_name].Visible = false;
					tree.SelectedNode.Remove();
				}
				else{
					Universe u = tree.SelectedNode.Parent.Tag as Universe;
					if(tree.SelectedNode.Tag is triangle_function){
						triangle_function f = tree.SelectedNode.Tag as triangle_function;					
						u.hostChart.Series.Remove(u.hostChart.Series.FindByName(f.Name));
						tree.SelectedNode.Remove();
					}
					else if(tree.SelectedNode.Tag is gaussian_function){
						gaussian_function f = tree.SelectedNode.Tag as gaussian_function;					
						u.hostChart.Series.Remove(u.hostChart.Series.FindByName(f.Name));
						tree.SelectedNode.Remove();
					}
					else if(tree.SelectedNode.Tag is bell_function){
						bell_function f = tree.SelectedNode.Tag as bell_function;					
						u.hostChart.Series.Remove(u.hostChart.Series.FindByName(f.Name));
						tree.SelectedNode.Remove();
					}
					else if(tree.SelectedNode.Tag is sigmoidal_function){
						sigmoidal_function f = tree.SelectedNode.Tag as sigmoidal_function;					
						u.hostChart.Series.Remove(u.hostChart.Series.FindByName(f.Name));
						tree.SelectedNode.Remove();
					}
				}
			}
		}

		//Change the name show on the tag of the tree
		private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e){
			if (e.ChangedItem.Label == "Name"){
				tree.SelectedNode.Text = e.ChangedItem.Value.ToString();
				if(tree.SelectedNode.Level == 1){
					Universe u = tree.SelectedNode.Tag as Universe;
					Chart_func.ChartAreas[u.tmp_name].AxisX.Title = u.Name;
					Chart_func.ChartAreas[u.tmp_name].Name = u.Name;
					u.tmp_name = u.Name;
					sel_name.Text = "Universe:" + tree.SelectedNode.Text;
				}
				else if(tree.SelectedNode.Level == 2){
					Universe u = tree.SelectedNode.Parent.Tag as Universe;
					if(tree.SelectedNode.Tag is triangle_function){
						triangle_function f = tree.SelectedNode.Tag as triangle_function;					
						u.hostChart.Series[f.tmp_name].LegendText = f.Name;
						u.hostChart.Series[f.tmp_name].Name = f.Name;
						f.tmp_name = f.Name;
						sel_name.Text = "Fuzzy Set:" + tree.SelectedNode.Text;
					}
					else if(tree.SelectedNode.Tag is gaussian_function){
						gaussian_function f = tree.SelectedNode.Tag as gaussian_function;					
						u.hostChart.Series[f.tmp_name].LegendText = f.Name;
						u.hostChart.Series[f.tmp_name].Name = f.Name;
						f.tmp_name = f.Name;
						sel_name.Text = "Fuzzy Set:" + tree.SelectedNode.Text;
					}
					else if(tree.SelectedNode.Tag is bell_function){
						bell_function f = tree.SelectedNode.Tag as bell_function;					
						u.hostChart.Series[f.tmp_name].LegendText = f.Name;
						u.hostChart.Series[f.tmp_name].Name = f.Name;
						f.tmp_name = f.Name;
						sel_name.Text = "Fuzzy Set:" + tree.SelectedNode.Text;
					}
					else if(tree.SelectedNode.Tag is sigmoidal_function){
						sigmoidal_function f = tree.SelectedNode.Tag as sigmoidal_function;					
						u.hostChart.Series[f.tmp_name].LegendText = f.Name;
						u.hostChart.Series[f.tmp_name].Name = f.Name;
						f.tmp_name = f.Name;
						sel_name.Text = "Fuzzy Set:" + tree.SelectedNode.Text;
					}
				}
            }
		}

		//Double Click to Rename universe	
		private void tree_DoubleClick(object sender, TreeNodeMouseClickEventArgs e){
			Universe u;
			if(tree.SelectedNode != null){
				if(tree.SelectedNode.Tag is Universe){
					u = tree.SelectedNode.Tag as Universe;
					if(u.hostChart.ChartAreas[u.Name].Visible){
						u.hostChart.ChartAreas[u.Name].Visible = false;
						foreach(TreeNode tn in tree.SelectedNode.Nodes){
							if(tn.Tag is triangle_function){
								triangle_function f = tn.Tag as triangle_function;
								u.hostChart.Series.FindByName(f.Name).Enabled = false;
							}
							if(tn.Tag is gaussian_function){
								gaussian_function f = tn.Tag as gaussian_function;
								u.hostChart.Series.FindByName(f.Name).Enabled = false;
							}
							if(tn.Tag is bell_function){
								bell_function f = tn.Tag as bell_function;
								u.hostChart.Series.FindByName(f.Name).Enabled = false;
							}
							if(tn.Tag is sigmoidal_function){
								sigmoidal_function f = tn.Tag as sigmoidal_function;
								u.hostChart.Series.FindByName(f.Name).Enabled = false;
							}
						}
					}
					else{
						u.hostChart.ChartAreas[u.Name].Visible = true;
						foreach(TreeNode tn in tree.SelectedNode.Nodes){
							if(tn.Tag is triangle_function){
								triangle_function f = tn.Tag as triangle_function;
								u.hostChart.Series.FindByName(f.Name).Enabled = true;
							}
							if(tn.Tag is gaussian_function){
								gaussian_function f = tn.Tag as gaussian_function;
								u.hostChart.Series.FindByName(f.Name).Enabled = true;
							}
							if(tn.Tag is bell_function){
								bell_function f = tn.Tag as bell_function;
								u.hostChart.Series.FindByName(f.Name).Enabled = true;
							}
							if(tn.Tag is sigmoidal_function){
								sigmoidal_function f = tn.Tag as sigmoidal_function;
								u.hostChart.Series.FindByName(f.Name).Enabled = true;
							}
						}
					}
				}
				else if(tree.SelectedNode.Level==2){
					u = tree.SelectedNode.Parent.Tag as Universe;
					if(tree.SelectedNode.Tag is triangle_function){
						triangle_function f = tree.SelectedNode.Tag as triangle_function;
						u.hostChart.Series.FindByName(f.Name).Enabled = !u.hostChart.Series.FindByName(f.Name).Enabled;
					}
					if(tree.SelectedNode.Tag is gaussian_function){
						gaussian_function f = tree.SelectedNode.Tag as gaussian_function;
						u.hostChart.Series.FindByName(f.Name).Enabled = !u.hostChart.Series.FindByName(f.Name).Enabled;
					}
					if(tree.SelectedNode.Tag is bell_function){
						bell_function f = tree.SelectedNode.Tag as bell_function;
						u.hostChart.Series.FindByName(f.Name).Enabled = !u.hostChart.Series.FindByName(f.Name).Enabled;
					}
					if(tree.SelectedNode.Tag is sigmoidal_function){
						sigmoidal_function f = tree.SelectedNode.Tag as sigmoidal_function;
						u.hostChart.Series.FindByName(f.Name).Enabled = !u.hostChart.Series.FindByName(f.Name).Enabled;
					}
				}
			}
		}
    }
}

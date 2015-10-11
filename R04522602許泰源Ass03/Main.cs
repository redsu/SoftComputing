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
		//double bound_l = INFINITY, bound_r = NEG_INFINITY;
		
		public Main(){
			
			
            //Series sss = new Series();
			//sss.ChartArea = Chart_func.ChartAreas[0].Name;
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

		private void universe_btn_Click(object sender, EventArgs e){
			if(uni_name.Text != "Name" && uni_name.Text != ""){
				Universe u = new Universe(Chart_func, uni_name.Text);
				TreeNode tn = new TreeNode( u.name );
				tn.Tag = u;
				tn.Checked = true;
				tree.Nodes.Add(tn);
				tree.SelectedNode = tn;
				uni_name.Text = "Name";
			}
			else{
				Universe u = new Universe(Chart_func);
				TreeNode tn = new TreeNode( u.name );
				tn.Tag = u;
				tn.Checked = true;
				tree.Nodes.Add(tn);
				tree.SelectedNode = tn;
			}
		}

		private void fs_btn_Click(object sender, EventArgs e){
			FuzzySet fs = null;
            Universe u;
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
					tree.SelectedNode = tn;
				}
			}
		}

		private void tree_AfterSelect(object sender, TreeViewEventArgs e){
			if(e.Node.Level == 1){
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

				if(e.Node.Tag is triangle_function){
					triangle_function f = e.Node.Tag as triangle_function;
					Universe u = e.Node.Parent.Tag as Universe;

					f.SetWidth(2);
					tbar_a.Enabled =
					tbar_b.Enabled =
					tbar_c.Enabled = true;
					
					tbar_a.Minimum = (int)u.xMin;
					tbar_a.Maximum = (int)u.xMax;
					tbar_b.Minimum = (int)u.xMin;
					tbar_b.Maximum = (int)u.xMax;
					tbar_c.Minimum = (int)u.xMin;
					tbar_c.Maximum = (int)u.xMax;
					
					tbar_a.Value = (int)f.GetParameter("Left");
					tbar_b.Value = (int)f.GetParameter("Middle");
					tbar_c.Value = (int)f.GetParameter("Right");
				}
				else if(e.Node.Tag is gaussian_function){
					gaussian_function f = e.Node.Tag as gaussian_function;
					Universe u = e.Node.Parent.Tag as Universe;

					f.SetWidth(2);
					tbar_a.Enabled =
					tbar_b.Enabled = true;
					tbar_c.Enabled = false;
					tbar_c.Visible = false;
					
					tbar_a.Minimum = (int)u.xMin;
					tbar_a.Maximum = (int)u.xMax;
					tbar_b.Minimum = (int)u.xMin;
					tbar_b.Maximum = (int)u.xMax;
					
					tbar_a.Value = (int)f.GetParameter("mean");
					tbar_b.Value = (int)f.GetParameter("sigma");
				}
				else if(e.Node.Tag is bell_function){
					bell_function f = e.Node.Tag as bell_function;
					Universe u = e.Node.Parent.Tag as Universe;

					f.SetWidth(2);
					tbar_a.Enabled =
					tbar_b.Enabled =
					tbar_c.Enabled = true;
					
					tbar_a.Minimum = (int)u.xMin;
					tbar_a.Maximum = (int)u.xMax;
					tbar_b.Minimum = (int)u.xMin;
					tbar_b.Maximum = (int)u.xMax;
					tbar_c.Minimum = (int)u.xMin;
					tbar_c.Maximum = (int)u.xMax;
					
					tbar_a.Value = (int)f.GetParameter("Half-width");
					tbar_b.Value = (int)f.GetParameter("Slope");
					tbar_c.Value = (int)f.GetParameter("Center");
				}
				else if(e.Node.Tag is sigmoidal_function){
					sigmoidal_function f = e.Node.Tag as sigmoidal_function;
					Universe u = e.Node.Parent.Tag as Universe;

					f.SetWidth(2);
					tbar_a.Enabled =
					tbar_b.Enabled = true;
					tbar_c.Enabled = false;
					tbar_c.Visible = false;
					
					tbar_a.Minimum = -100;
					tbar_a.Maximum = 100;
					tbar_b.Minimum = (int)u.xMin;
					tbar_b.Maximum = (int)u.xMax;
					
					tbar_a.Value = (int)f.GetParameter("Slope");
					tbar_b.Value = (int)f.GetParameter("CrossoverPoint");
				}
			}
			else{
				tbar_a.Enabled =
				tbar_b.Enabled =
				tbar_c.Enabled = false;
			}
		}

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

		private void tbar_a_Scroll(object sender, EventArgs e){
			if(tree.SelectedNode.Tag is triangle_function){
				triangle_function f = tree.SelectedNode.Tag as triangle_function;
				if(tbar_a.Value<=tbar_b.Value){
					f.SetParameter("Left", tbar_a.Value);
				}
				else{
					tbar_a.Value = tbar_b.Value;
				}
				f.Refresh();
			}
			else if(tree.SelectedNode.Tag is gaussian_function){
				gaussian_function f = tree.SelectedNode.Tag as gaussian_function;
				f.SetParameter("mean", tbar_a.Value);
				f.Refresh();
			}
			else if(tree.SelectedNode.Tag is bell_function){
				bell_function f = tree.SelectedNode.Tag as bell_function;
				f.SetParameter("Half-width", tbar_a.Value);
				f.Refresh();
			}
			else if(tree.SelectedNode.Tag is sigmoidal_function){
				sigmoidal_function f = tree.SelectedNode.Tag as sigmoidal_function;
				f.SetParameter("Slope", (double)(tbar_a.Value)/10);
				f.Refresh();
			}
			
		}

		private void tbar_b_Scroll(object sender, EventArgs e){
			if(tree.SelectedNode.Tag is triangle_function){
				triangle_function f = tree.SelectedNode.Tag as triangle_function;
				if(tbar_b.Value<=tbar_c.Value&&tbar_b.Value>=tbar_a.Value){
					f.SetParameter("Middle", tbar_b.Value);
					f.Refresh();
				}
				else if(tbar_b.Value>=tbar_c.Value){
					tbar_b.Value=tbar_c.Value;
				}
				else if(tbar_b.Value<=tbar_a.Value){
					tbar_b.Value=tbar_a.Value;
				}
				f.Refresh();
			}
			else if(tree.SelectedNode.Tag is gaussian_function){
				gaussian_function f = tree.SelectedNode.Tag as gaussian_function;
				f.SetParameter("sigma", tbar_b.Value);
				f.Refresh();
			}
			else if(tree.SelectedNode.Tag is bell_function){
				bell_function f = tree.SelectedNode.Tag as bell_function;
				f.SetParameter("Slope", tbar_b.Value);
				f.Refresh();
			}
			else if(tree.SelectedNode.Tag is sigmoidal_function){
				sigmoidal_function f = tree.SelectedNode.Tag as sigmoidal_function;
				f.SetParameter("CrossoverPoint", tbar_b.Value);
				f.Refresh();
			}
		}

		private void tbar_c_Scroll(object sender, EventArgs e){
			if(tree.SelectedNode.Tag is triangle_function){
				triangle_function f = tree.SelectedNode.Tag as triangle_function;
				if(tbar_c.Value>=tbar_b.Value){
					f.SetParameter("Right", tbar_c.Value);
					f.Refresh();
				}
				else{
					tbar_c.Value = tbar_b.Value;
				}
			}
			else if(tree.SelectedNode.Tag is bell_function){
				bell_function f = tree.SelectedNode.Tag as bell_function;
				f.SetParameter("Center", tbar_c.Value);
				f.Refresh();
			}
		}

		private void del_btn_Click(object sender, EventArgs e){
			if(tree.SelectedNode != null){
				if(tree.SelectedNode.Tag is Universe){
					Universe u = tree.SelectedNode.Tag as Universe;
					Chart_func.ChartAreas[u.name].Visible = false;
					tree.SelectedNode.Remove();
				}
				else if(tree.SelectedNode.Tag is triangle_function){
					triangle_function f = tree.SelectedNode.Tag as triangle_function;
					Universe u = tree.SelectedNode.Parent.Tag as Universe;
					u.hostChart.Series.Remove(u.hostChart.Series.FindByName(f.GetName()));
					tree.SelectedNode.Remove();
				}
				else if(tree.SelectedNode.Tag is gaussian_function){

				}
				else if(tree.SelectedNode.Tag is bell_function){

				}
				else if(tree.SelectedNode.Tag is sigmoidal_function){

				}
			}
		}

		
    }
}

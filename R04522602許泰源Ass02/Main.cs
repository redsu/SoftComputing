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

namespace R04522602許泰源Ass02
{
    public partial class Main : Form
    {
		private const double INFINITY = 1e100, NEG_INFINITY = -1e100;
		double bound_l = INFINITY, bound_r = NEG_INFINITY;
		public Main(){
            
            InitializeComponent();
			//Set the properties of chart that enable the user zooming interface.
            Chart_func.ChartAreas[0].CursorX.IsUserEnabled = true;
            Chart_func.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            Chart_func.ChartAreas[0].AxisX.ScaleView.Zoomable = true;

			//Set the label style and format.
            Chart_func.ChartAreas[0].AxisX.LabelStyle.Format = "###0.#";
			Chart_func.ChartAreas[0].AxisY.LabelStyle.Format = "###0.#";
			Chart_func.ChartAreas[0].AxisX.Title = "X Axis";
			Chart_func.ChartAreas[0].AxisY.Title = "Y Axis";
            
            FuncTypSel.SelectedIndex = 0;
			//Preset valid parameters for demo.
            Box_a.Text     = "10.0";
            Box_b.Text     = "30.0";
            Box_c.Text     = "50.0";

            //Change the language of exception messages into Engilsh.
            System.Threading.Thread.CurrentThread.CurrentCulture = 
                                        new System.Globalization.CultureInfo("en-US");

            System.Threading.Thread.CurrentThread.CurrentUICulture = 
                                        new System.Globalization.CultureInfo("en-US");

			//Set the range and interval of y axis
			Chart_func.ChartAreas[0].AxisY.Maximum   = 1.25;
			Chart_func.ChartAreas[0].AxisY.Minimum   = 0;
			Chart_func.ChartAreas[0].AxisY.Interval  = 0.25;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            //Detect keypressed events. If ESC was pressed, terminate the application.
            if (keyData == Keys.Escape) {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }       

        private void Delete_btn_Click(object sender, EventArgs e){
			//Enable user to delete seleted function in listbox by delete button.
            Series s = Chart_func.Series.FindByName(created_func_list.Text);
            if(created_func_list.Text != ""){
                Chart_func.Series.Remove(s);
                created_func_list.Items.RemoveAt(created_func_list.SelectedIndex);
            }
        }

        private void save_btn_Click(object sender, EventArgs e){
            //If "Save" button is clicked, create a save form.
            save_win save = new save_win();
            DialogResult dr = save.ShowDialog();
            //Get the filename.
            string sv_name = save.GetMsg();
            //Save the file of the current image by the filename.
            Chart_func.SaveImage(sv_name,System.Drawing.Imaging.ImageFormat.Png);
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

        private void create_func_Click(object sender, EventArgs e){
			//Enable user to create new function by Create button.
			//The function type can be selected by Combobox
            switch (FuncTypSel.SelectedIndex){
                case 0:
                    // Triangular function
                    try{
                        double a, b, c;
                        a = double.Parse(Box_a.Text);
                        b = double.Parse(Box_b.Text);
                        c = double.Parse(Box_c.Text);
                        if (b < a || c < b){
                            MessageBox.Show("Please enter valid numbers that c > b > a","Bad argument!");
                        }
                        else{
                            triangle_function triObject = new triangle_function(a, b, c);
                            created_func_list.Items.Add(triObject);
                            triObject.Draw(Chart_func);
                        }
                    }catch(Exception ex){
                        //When an exception is thrown, show the error message.
                        string caption = "ERROR";
                        MessageBox.Show(ex.Message + "\nPlease Enter Numbers Only.", caption);
                    }          
                    break;
                case 1:
                    // Gaussian function
                    try{//Catch bad arguments like characters, space, and etc.
                        double c, sigma;
                        c     = double.Parse(Box_a.Text);
                        sigma = double.Parse(Box_b.Text);
                        if (sigma < 0)
                            MessageBox.Show("Bad argument!\n\u03C3 should be positive number!");
                        else{
                            gaussian_function gauObject = new gaussian_function(c, sigma);
                            created_func_list.Items.Add(gauObject);
                            gauObject.Draw(Chart_func);
                        }
                    }catch(Exception ex){
                        //When an exception is thrown, show the error message.
                        string caption = "ERROR";
                        MessageBox.Show(ex.Message + "\nPlease Enter Numbers Only.", caption);
                    }                    
                    break;
                case 2:
					//Bell function
                    try{//Catch bad arguments like characters, space, and etc.
                        double a, b, c;
                        a = double.Parse(Box_a.Text);
                        b = double.Parse(Box_b.Text);
                        c = double.Parse(Box_c.Text);
                        if (a == 0)
                            MessageBox.Show("Parameter a  shouldn't be zero.","Bad argument!");
                        else{
                            bell_function bellObject = new bell_function(a, b, c);
                            created_func_list.Items.Add(bellObject);
                            bellObject.Draw(Chart_func);
                        }
                    }catch(Exception ex){
                        //When an exception is thrown, show the error message.
                        string caption = "ERROR";
                        MessageBox.Show(ex.Message + "\nPlease Enter Numbers Only.", caption);
                    }
                    break;
                case 3:
					//Sigmoidal function
                    try{
                        double Slope, CrossoverPoint;
                        Slope          = double.Parse(Box_a.Text);
                        CrossoverPoint = double.Parse(Box_b.Text);
                        sigmoidal_function sigObject = new sigmoidal_function(Slope, CrossoverPoint);
                        created_func_list.Items.Add(sigObject);
                        sigObject.Draw(Chart_func);
                    }catch(Exception ex){
                        //When an exception is thrown, show the error message.
                        string caption = "ERROR";
                        MessageBox.Show(ex.Message + "\nPlease Enter Numbers Only.", caption);
                    }
                    break;
            }
			//Find the current Maximum/Minimum of all the visible function and adjust the scale.
            FindBoundary();
			Chart_func.ChartAreas[0].AxisX.Interval = (double)((int)(bound_r-bound_l)/5);
			Chart_func.ChartAreas[0].AxisX.Maximum  = bound_r;
			Chart_func.ChartAreas[0].AxisX.Minimum  = bound_l;
			Chart_func.ChartAreas[0].AxisX.Title = "X Axis";
        }

        
        private void created_func_DoubleClick(object sender, EventArgs e){
            Series s = Chart_func.Series.FindByName(created_func_list.Text);
			int i = created_func_list.SelectedIndex;
				
            if(created_func_list.Text!="" && i>=0){
				if(s.Enabled){
					if(typeof(triangle_function).ToString() == created_func_list.Items[i].GetType().ToString()){
						triangle_function FuncObject = created_func_list.Items[i] as triangle_function;
						FuncObject.visible = false;
					}
					if(typeof(gaussian_function).ToString() == created_func_list.Items[i].GetType().ToString()){
						gaussian_function FuncObject = created_func_list.Items[i] as gaussian_function;
						FuncObject.visible = false;
					}
					if(typeof(bell_function).ToString() == created_func_list.Items[i].GetType().ToString()){
						bell_function FuncObject = created_func_list.Items[i] as bell_function;
						FuncObject.visible = false;
					}
					if(typeof(sigmoidal_function).ToString() == created_func_list.Items[i].GetType().ToString()){
						sigmoidal_function FuncObject = created_func_list.Items[i] as sigmoidal_function;
						FuncObject.visible = false;
					}
				}
				else{
					if(typeof(triangle_function).ToString() == created_func_list.Items[i].GetType().ToString()){
						triangle_function FuncObject = created_func_list.Items[i] as triangle_function;
						FuncObject.visible = true;
						FuncObject.Refresh(s);
					}
					if(typeof(gaussian_function).ToString() == created_func_list.Items[i].GetType().ToString()){
						gaussian_function FuncObject = created_func_list.Items[i] as gaussian_function;
						FuncObject.visible = true;
						FuncObject.Refresh(s);
					}
					if(typeof(bell_function).ToString() == created_func_list.Items[i].GetType().ToString()){
						bell_function FuncObject = created_func_list.Items[i] as bell_function;
						FuncObject.visible = true;
						FuncObject.Refresh(s);
					}
					if(typeof(sigmoidal_function).ToString() == created_func_list.Items[i].GetType().ToString()){
						sigmoidal_function FuncObject = created_func_list.Items[i] as sigmoidal_function;
						FuncObject.visible = true;
						FuncObject.Refresh(s);
					}
				}
				s.Enabled = !s.Enabled;
			}
			//Find the current Maximum/Minimum of all the visible function and adjust the scale.
			FindBoundary();
			Chart_func.ChartAreas[0].AxisX.Interval = (double)((int)(bound_r-bound_l)/5);
			Chart_func.ChartAreas[0].AxisX.Maximum  = bound_r;
			Chart_func.ChartAreas[0].AxisX.Minimum  = bound_l;
			Chart_func.ChartAreas[0].AxisX.Title    = "X Axis";
			//MessageBox.Show(Chart_func.ChartAreas[0].AxisX.Interval.ToString());
        }

        private void color_dia_btn_Click(object sender, EventArgs e){
            Series s = Chart_func.Series.FindByName(created_func_list.Text);
			if(created_func_list.Text != "")
				if(color_dialog.ShowDialog() == DialogResult.OK){                
					if(created_func_list.Text != "")
						s.Color = color_dialog.Color;
				}
        }

        private void FuncTypSel_SelectedIndexChanged(object sender, EventArgs e){
            switch (FuncTypSel.SelectedIndex){
                case 0:
                    // Triangular function
                    label_a.Visible = true;
                    label_b.Visible = true;
                    label_c.Visible = true;

                    Box_a.Visible   = true;
                    Box_b.Visible   = true;
                    Box_c.Visible   = true;

                    label_a.Text = "Left";
                    label_b.Text = "Turning";
                    label_c.Text = "Right";

                    Box_a.Text     = "10.0";
                    Box_b.Text     = "30.0";
                    Box_c.Text     = "50.0";

					tBar_a.Visible  = true;
					numUD_a.Visible = true;
					numUD_b.Visible = true;
					tBar_a.Enabled  = false;
					numUD_a.Enabled = false;
					numUD_b.Enabled = false;
					
					tBar_a.Minimum = 10;
					tBar_a.Maximum = 50;					
					tBar_a.Value   = 30;

                    formula_pic.Load("Resource/fml_t.PNG");
                    formula_pic.SizeMode = PictureBoxSizeMode.Zoom;

                    break;
                case 1:
                    // Gaussian function
                    label_a.Visible = true;
                    label_b.Visible = true;
                    label_c.Visible = false;

                    Box_a.Visible   = true;
                    Box_b.Visible   = true;
                    Box_c.Visible   = false;

                    label_a.Text = "Mean";
                    label_b.Text = "Std";

                    Box_a.Text     = "30.0";
                    Box_b.Text     = "5.0";

					tBar_a.Visible  = false;
					numUD_a.Visible = false;
					numUD_b.Visible = false;
                    
                    formula_pic.Load("Resource/fml_g.PNG");
                    formula_pic.SizeMode = PictureBoxSizeMode.Zoom;

                    break;
                case 2:
                    // Bell function
                    label_a.Visible = true;
                    label_b.Visible = true;
                    label_c.Visible = true;
                    
                    Box_a.Visible   = true;
                    Box_b.Visible   = true;
                    Box_c.Visible   = true;

                    label_a.Text = "Half-width";
                    label_b.Text = "Slope";
                    label_c.Text = "Center";

                    Box_a.Text     = "3.0";
                    Box_b.Text     = "5.0";
                    Box_c.Text     = "30.0";

					tBar_a.Visible  = false;
					numUD_a.Visible = false;
					numUD_b.Visible = false;

                    formula_pic.Load("Resource/fml_b.PNG");
                    formula_pic.SizeMode = PictureBoxSizeMode.Zoom;

                    break;
                case 3:
                    // Sigmoidal function
                    label_a.Visible   = true;
                    label_b.Visible   = true;
                    label_c.Visible   = false;
                    
                    Box_a.Visible     = true;
                    Box_b.Visible     = true;
                    Box_c.Visible     = false;                    

                    label_a.Text = "Slope";
                    label_b.Text = "X-Point";

                    Box_a.Text     = "3.0";
                    Box_b.Text     = "30";

					tBar_a.Visible  = false;
					numUD_a.Visible = false;
					numUD_b.Visible = false;
                    
                    formula_pic.Load("Resource/fml_s.PNG");
                    formula_pic.SizeMode = PictureBoxSizeMode.Zoom;

                    break;
            }
        }

		private void created_func_list_SelectedIndexChanged(object sender, EventArgs e){
			int i = created_func_list.SelectedIndex;
			if(i>=0){
				//Highlight the selected line.
				foreach(Series s in Chart_func.Series)
					s.BorderWidth = 1;
				Chart_func.Series[created_func_list.SelectedIndex].BorderWidth = 3;
				//Enable slected triangle function be adjust by trackbar and numericUpDown.
				if(typeof(triangle_function).ToString() == created_func_list.Items[i].GetType().ToString()){
					triangle_function FuncObject = created_func_list.Items[i] as triangle_function;
					tBar_a.Minimum = ((int)FuncObject.GetParameter("Left"));
					
					tBar_a.Maximum = ((int)FuncObject.GetParameter("Right"));
					tBar_a.Value    = (int)FuncObject.GetParameter("Middle");
					
					numUD_a.Maximum = (int)FuncObject.GetParameter("Middle");
					
					numUD_a.Minimum = (int)FuncObject.Lbound;
					numUD_a.Value   = ((int)FuncObject.GetParameter("Left"));
					numUD_b.Maximum = (int)FuncObject.Rbound;
					numUD_b.Value   = ((int)FuncObject.GetParameter("Right"));
					numUD_b.Minimum = (int)FuncObject.GetParameter("Middle");

					FuncTypSel.SelectedIndex = 0;

					Box_a.Text = FuncObject.GetParameter("Left").ToString();
					Box_b.Text = FuncObject.GetParameter("Middle").ToString();
					Box_c.Text = FuncObject.GetParameter("Right").ToString();

					tBar_a.Visible  = true;
					numUD_a.Visible = true;
					numUD_b.Visible = true;

					tBar_a.Enabled  = true;
					numUD_a.Enabled = true;
					numUD_b.Enabled = true;
				}
				else{
					tBar_a.Visible  = false;
					numUD_a.Visible = false;
					numUD_b.Visible = false;
				}

				if(typeof(gaussian_function).ToString() == created_func_list.Items[i].GetType().ToString()){
					gaussian_function FuncObject = created_func_list.Items[i] as gaussian_function;
					FuncTypSel.SelectedIndex = 1;
					Box_a.Text = FuncObject.GetParameter("c").ToString();
                    Box_b.Text = FuncObject.GetParameter("sigma").ToString();
				}
				else{
					;
				}

				if(typeof(bell_function).ToString() == created_func_list.Items[i].GetType().ToString()){
					bell_function FuncObject = created_func_list.Items[i] as bell_function;
					FuncTypSel.SelectedIndex = 2;
					Box_a.Text = FuncObject.GetParameter("Half-width").ToString();
                    Box_b.Text = FuncObject.GetParameter("Slope").ToString();
					Box_c.Text = FuncObject.GetParameter("Center").ToString();
				}
				else{
					;
				}

				if(typeof(sigmoidal_function).ToString() == created_func_list.Items[i].GetType().ToString()){
					sigmoidal_function FuncObject = created_func_list.Items[i] as sigmoidal_function;
					FuncTypSel.SelectedIndex = 3;
					Box_a.Text = FuncObject.GetParameter("Slope").ToString();
                    Box_b.Text = FuncObject.GetParameter("CrossoverPoint").ToString();
				}
				else{
					;
				}
			}
		}

		private void tBar_a_Scroll(object sender, EventArgs e){
			int i = created_func_list.SelectedIndex;
			//Enable slected triangle function be adjust by trackbar.
			if(i>=0){
				if(typeof(triangle_function).ToString() == created_func_list.Items[i].GetType().ToString()){
					triangle_function FuncObject = created_func_list.Items[i] as triangle_function;
					FuncObject.SetParameter("Middle", tBar_a.Value);
					Box_b.Text =  tBar_a.Value.ToString();

					Series s = Chart_func.Series.FindByName(FuncObject.ToString());
					FuncObject.Refresh(s);
				}
			}
		}

		private void FindBoundary(){
			//Find the current Maximum/Minimum of all the visible function.
			double bound_l = INFINITY, bound_r = NEG_INFINITY;
			bound_l = INFINITY;
			bound_r = NEG_INFINITY;
			for(int i=0; i<created_func_list.Items.Count; i++){
				if(typeof(triangle_function).ToString() == created_func_list.Items[i].GetType().ToString()){
					triangle_function FuncObject = created_func_list.Items[i] as triangle_function;
					if(FuncObject.visible){
						bound_l = FuncObject.GetLeftBound() < bound_l ? FuncObject.GetLeftBound() : bound_l;
						bound_r = FuncObject.GetRightBound() > bound_r ? FuncObject.GetRightBound() : bound_r;
					}
				}
				if(typeof(gaussian_function).ToString() == created_func_list.Items[i].GetType().ToString()){
					gaussian_function FuncObject = created_func_list.Items[i] as gaussian_function;
					if(FuncObject.visible){
						bound_l = FuncObject.GetLeftBound() < bound_l ? FuncObject.GetLeftBound() : bound_l;
						bound_r = FuncObject.GetRightBound() > bound_r ? FuncObject.GetRightBound() : bound_r;
					}
				}
				if(typeof(bell_function).ToString() == created_func_list.Items[i].GetType().ToString()){
					bell_function FuncObject = created_func_list.Items[i] as bell_function;
					if(FuncObject.visible){
						bound_l = FuncObject.GetLeftBound() < bound_l ? FuncObject.GetLeftBound() : bound_l;
						bound_r = FuncObject.GetRightBound() > bound_r ? FuncObject.GetRightBound() : bound_r;
					}
				}
				if(typeof(sigmoidal_function).ToString() == created_func_list.Items[i].GetType().ToString()){
					sigmoidal_function FuncObject = created_func_list.Items[i] as sigmoidal_function;
					if(FuncObject.visible){
						bound_l = FuncObject.GetLeftBound() < bound_l ? FuncObject.GetLeftBound() : bound_l;
						bound_r = FuncObject.GetRightBound() > bound_r ? FuncObject.GetRightBound() : bound_r;
					}
				}
			}
			this.bound_l = bound_l;
			this.bound_r = bound_r;
		}

		private void numUD_b_ValueChanged(object sender, EventArgs e){
			tBar_a.Maximum = (int)numUD_b.Value;
			//Enable slected triangle function be adjust by numericUpDown.
			int i = created_func_list.SelectedIndex;
			if(i>=0){
				if(typeof(triangle_function).ToString() == created_func_list.Items[i].GetType().ToString()){
					triangle_function FuncObject = created_func_list.Items[i] as triangle_function;
					FuncObject.SetParameter("Right", tBar_a.Maximum);
					if(tBar_a.Maximum <= tBar_a.Value){
						tBar_a.Value = tBar_a.Maximum;
						Box_b.Text = tBar_a.Maximum.ToString();
						FuncObject.SetParameter("Middle", tBar_a.Maximum);
					}
					Box_c.Text = numUD_b.Value.ToString();

					Series s = Chart_func.Series.FindByName(FuncObject.ToString());
					FuncObject.Refresh(s);
				}
			}
			//Find the current Maximum/Minimum of all the visible function and adjust the scale.
			FindBoundary();
			Chart_func.ChartAreas[0].AxisX.Interval = (double)((int)(bound_r-bound_l)/5);
			Chart_func.ChartAreas[0].AxisX.Maximum  = bound_r;
			Chart_func.ChartAreas[0].AxisX.Minimum  = bound_l;
			Chart_func.ChartAreas[0].AxisX.Title = "X Axis";
		}

		private void numUD_a_ValueChanged(object sender, EventArgs e){
			tBar_a.Minimum = (int)numUD_a.Value;
			//Enable slected triangle function be adjust by numericUpDown.
			int i = created_func_list.SelectedIndex;
			if(i>=0){
				if(typeof(triangle_function).ToString() == created_func_list.Items[i].GetType().ToString()){
					triangle_function FuncObject = created_func_list.Items[i] as triangle_function;
					FuncObject.SetParameter("Left", tBar_a.Minimum);
					if(tBar_a.Minimum >= tBar_a.Value){
						tBar_a.Value = tBar_a.Minimum;
						Box_b.Text = tBar_a.Minimum.ToString();
						FuncObject.SetParameter("Middle", tBar_a.Minimum);
					}
					Box_a.Text = numUD_a.Value.ToString();
					Series s = Chart_func.Series.FindByName(FuncObject.ToString());
					FuncObject.Refresh(s);
				}
			}
			//Find the current Maximum/Minimum of all the visible function and adjust the scale.
			FindBoundary();
			Chart_func.ChartAreas[0].AxisX.Interval = (double)((int)(bound_r-bound_l)/5);
			Chart_func.ChartAreas[0].AxisX.Maximum  = bound_r;
			Chart_func.ChartAreas[0].AxisX.Minimum  = bound_l;
			Chart_func.ChartAreas[0].AxisX.Title = "X Axis";
		}

		private void Update_btn_Click(object sender, EventArgs e){
			Series s = Chart_func.Series.FindByName(created_func_list.Text);
			int i = created_func_list.SelectedIndex;
			if(created_func_list.Text != ""){
				if(typeof(triangle_function).ToString() == created_func_list.Items[i].GetType().ToString()){
					triangle_function FuncObject = created_func_list.Items[i] as triangle_function;
					// Triangular function
					try{
						double a, b, c;
						a = double.Parse(Box_a.Text);
						b = double.Parse(Box_b.Text);
						c = double.Parse(Box_c.Text);
						if (b < a || c < b){
							MessageBox.Show("Please enter valid numbers that c > b > a","Bad argument!");
						}
						else{
							//triangle_function triObject = new triangle_function(a, b, c);
							FuncObject.SetParameter("Left", a);
							FuncObject.SetParameter("Middle", b);
							FuncObject.SetParameter("Right", c);
							tBar_a.Minimum = ((int)FuncObject.GetParameter("Left"));
					
							tBar_a.Maximum = ((int)FuncObject.GetParameter("Right"));
							tBar_a.Value    = (int)FuncObject.GetParameter("Middle");
					
							numUD_a.Maximum = (int)FuncObject.GetParameter("Middle");
					
							numUD_a.Minimum = (int)FuncObject.Lbound;
							numUD_a.Value   = ((int)FuncObject.GetParameter("Left"));
							numUD_b.Maximum = (int)FuncObject.Rbound;
							numUD_b.Value   = ((int)FuncObject.GetParameter("Right"));
							numUD_b.Minimum = (int)FuncObject.GetParameter("Middle");

							FuncTypSel.SelectedIndex = 0;

							Box_a.Text = FuncObject.GetParameter("Left").ToString();
							Box_b.Text = FuncObject.GetParameter("Middle").ToString();
							Box_c.Text = FuncObject.GetParameter("Right").ToString();
							FuncObject.Refresh(s);
						}
					}catch(Exception ex){
						//When an exception is thrown, show the error message.
						string caption = "ERROR";
						MessageBox.Show(ex.Message + "\nPlease Enter Numbers Only.", caption);
					}
				}
				else{
					;
				}

				if(typeof(gaussian_function).ToString() == created_func_list.Items[i].GetType().ToString()){
					gaussian_function FuncObject = created_func_list.Items[i] as gaussian_function;
					// Gaussian function
					try{//Catch bad arguments like characters, space, and etc.
						double c, sigma;
						c     = double.Parse(Box_a.Text);
						sigma = double.Parse(Box_b.Text);
						if (sigma < 0)
							MessageBox.Show("Bad argument!\n\u03C3 should be positive number!");
						else{
							FuncObject.SetParameter("c", c);
							FuncObject.SetParameter("sigma", sigma);
							FuncObject.Refresh(s);
						}
					}catch(Exception ex){
						//When an exception is thrown, show the error message.
						string caption = "ERROR";
						MessageBox.Show(ex.Message + "\nPlease Enter Numbers Only.", caption);
					}
				}
				else{
					;
				}

				if(typeof(bell_function).ToString() == created_func_list.Items[i].GetType().ToString()){
					bell_function FuncObject = created_func_list.Items[i] as bell_function;
					//Bell function
					try{//Catch bad arguments like characters, space, and etc.
						double a, b, c;
						a = double.Parse(Box_a.Text);
						b = double.Parse(Box_b.Text);
						c = double.Parse(Box_c.Text);
						if (a == 0)
							MessageBox.Show("Parameter a  shouldn't be zero.","Bad argument!");
						else{
							FuncObject.SetParameter("Half-width", a);
							FuncObject.SetParameter("Slope", b);
							FuncObject.SetParameter("Center", c);
							FuncObject.Refresh(s);
						}
					}catch(Exception ex){
						//When an exception is thrown, show the error message.
						string caption = "ERROR";
						MessageBox.Show(ex.Message + "\nPlease Enter Numbers Only.", caption);
					}
				}
				else{
					;
				}

				if(typeof(sigmoidal_function).ToString() == created_func_list.Items[i].GetType().ToString()){
					sigmoidal_function FuncObject = created_func_list.Items[i] as sigmoidal_function;
					//Sigmoidal function
					try{
						double Slope, CrossoverPoint;
						Slope          = double.Parse(Box_a.Text);
						CrossoverPoint = double.Parse(Box_b.Text);
						FuncObject.SetParameter("Slope", Slope);
						FuncObject.SetParameter("CrossoverPoint", CrossoverPoint);
						FuncObject.Refresh(s);
					}catch(Exception ex){
						//When an exception is thrown, show the error message.
						string caption = "ERROR";
						MessageBox.Show(ex.Message + "\nPlease Enter Numbers Only.", caption);
					}
				}
				else{
					;
				}
			}
			FindBoundary();
			Chart_func.ChartAreas[0].AxisX.Interval = (double)((int)(bound_r-bound_l)/5);
			Chart_func.ChartAreas[0].AxisX.Maximum  = bound_r;
			Chart_func.ChartAreas[0].AxisX.Minimum  = bound_l;
		}
    }
}

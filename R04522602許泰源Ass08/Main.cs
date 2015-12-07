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

namespace R04522602許泰源Ass08{
	public partial class Main : Form{
		//Time matrix
		double[,] ProcessTime;
		//Potential solution
		int[] jobs;
		//No. of solution
		int numofsol = 0;
		//Number of machines and jobs
		int numofJobs = 0;
		//Flag to check if data loaded
		int temp;

		bool loaded = false;
		
		//Optimal objective
		double bestobj;
		//Best solution set
		string bestsolution;
		bool[] Position;

		double Penality = 100.0;

		BinaryGA binarySolver;
		PermutationGA permSolver;

		public Main(){
			InitializeComponent();
			//Initialize the flags and disable all unused button.
			loaded = false;
			slv_btn.Enabled = false;
			buttonReset.Enabled = false;
			iterone.Enabled = false;
			iterend.Enabled = false;
			btnCreateBinGA.Enabled = false;
			btnCreatePerGA.Enabled = false;

			//Setup the dfault value of combobox
			recursive_type.SelectedIndex = 0;

			//Wake up import_btn_MouseHover
			import_btn_MouseHover(null, null);

			
		}

		/*Original Brute Force Permutaion*/
		//Time Complexity of Permutation() is about O(N^N)
		int[] solution;
		int[] fastbestsolution;
		private void Permutation(ref int index){			
			int i, j;
			double obj;
			for(i = 0; i < numofJobs; i++){
				if(!Position[i]){
					solution[index] = i;
					Position[i] = true;
					if(index == numofJobs-1){
						obj = 0.0;
						sol = "";
						for(j = 0; j < numofJobs; j++)
							obj += ProcessTime[solution[j],j];

						if(obj < bestobj){
							for(j=0; j<numofJobs; j++)
								fastbestsolution[j] = solution[j];
							bestobj = obj;
						}

						if(show_chk.Checked){
							for(j = 0; j < numofJobs; j++)
								sol += solution[j].ToString()+" ";
							output = string.Format("No. {0:00000000} Solution: {1}  Obj = {2:.0000}", numofsol, sol, obj);
							result_list.Items.Add(output);
						}
						numofsol++;
					}
					else{
						index++;
						Permutation(ref index);
						index--;
					}
					Position[i] = false;
				}
			}
		}

		/*Fast Brute Force Permutaion*/
		//Time Complexity of Permutation() is about O(N!)
		string output = "", sol = "";
		private void FastPermutation(int[] list, int k, int m){
			if(k==m) {
				output = "";
				sol = "";
				double Obj = 0.0;

				for(int i=0; i<numofJobs; i++)
					Obj += ProcessTime[list[i],i];

				if(Obj < bestobj){
					for(int j=0; j<numofJobs; j++)
						fastbestsolution[j] = list[j];
					bestobj = Obj;
				}

				if(show_chk.Checked){
					for(int i=0; i<numofJobs; i++)
						sol += list[i].ToString()+" ";
					output = string.Format("No. {0:00000000} Solution: {1}  Obj = {2:.0000}", numofsol, sol, Obj);
					result_list.Items.Add(output);
				}

				numofsol++;
			}
			else{
				for(int i= k; i<= m; i++){
					temp = list[i];
					for(int j=i; j>k; j--)
						list[j] = list[j-1];
					list[k] = temp;
					FastPermutation(list, k + 1, m);
					temp = list[k];
					for(int j=k; j<i; j++)
						list[j] = list[j+1];
					list[i] = temp;
				}
			}
		}
		

		string FILENAME;
		private void import_btn_Click(object sender, EventArgs e){
			OpenFileDialog open = new OpenFileDialog();
			System.IO.StreamReader myFile = null;
			string myString = "";

			//Check the filename and open the file
			if (open.ShowDialog()==System.Windows.Forms.DialogResult.OK && open.FileName!=""){
				//Read the data from file by Streamreader
				myFile = new System.IO.StreamReader(open.FileName);
				FILENAME = open.FileName;
				//Check the file is not empty
				if (myFile != null){
					myString = myFile.ReadLine().Trim();

					//Check the first line is not empty
					if(myString!=""){
						//Set the loaded flag to true				
						loaded = true;

						//Number of jobs		
						numofJobs = int.Parse(myString);
						
						//Show number of jobs
						noj_num.Text = numofJobs.ToString();

						//Initialize the Time matrix with size [count X count]
						ProcessTime = new double[numofJobs, numofJobs];
						//Initialize the Solution set
						jobs = new int[numofJobs];

						for (int i = 0; i < numofJobs; i++)
							jobs[i] = i;

						//Read the Time matrix and save into the 2-D array.
						for(int i=0; i<numofJobs; i++){
							myString = myFile.ReadLine().Trim();
							string[] nums = myString.Split(' ');
							for(int j=0; j<numofJobs; j++) 
								ProcessTime[i, j] = double.Parse(nums[j]);
						}
						
						//Clear the data output area
						data.Columns.Clear();

						//Show the data on the DatagridView
						for (int i=0; i<numofJobs; i++)
							data.Columns.Add("m" + i.ToString(), "m" + i.ToString());
						for (int i = 0; i < numofJobs; i++)
							data.Rows.Add();
						for (int i = 0; i < numofJobs; i++)
							for (int j = 0; j < numofJobs; j++)
								data.Rows[i].Cells[j].Value = ProcessTime[i, j];



						//Reset chart
						reset_chart();

						GAobj_lbl.Text = "(NONE)";
						GAsol_lbl.Text = "(NONE)";
						constrain.Text = "(NONE)";

						//Reset all the buttons and solvers
						slv_btn.Enabled = true;
						btnCreateBinGA.Enabled = btnCreatePerGA.Enabled = true;						
						buttonReset.Enabled = false;
						iterone.Enabled = false;
						iterend.Enabled = false;

						permSolver = null;
						binarySolver = null;
						Solver.SelectedObject = null;
					}
				}
			}
        }

		private void slv_btn_Click(object sender, EventArgs e){
			if(loaded){
				//If the data is loaded and selected page is page No.01, calculate the result and show
				System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
				//Intitialize the number of solution and the first element in permutations
				numofsol = 1;
				int start = 0;

				//Initialize the value of best objective to infinity
				bestobj = double.MaxValue;

				//Initialize the arrays may be used
				Position = new bool[numofJobs];
				fastbestsolution = new int[numofJobs];
				solution = new int[numofJobs];
				for(int i=0; i<numofJobs; i++)
					Position[i] = false;

				//Clear the result list
				result_list.Items.Clear();
				result_list.SuspendLayout();

				//Setup the stopwatch
				sw.Reset();
				sw.Start();

				switch(recursive_type.SelectedIndex){
					case 0:		//Permutation
						
						Permutation(ref start);
						sw.Stop();
						timer.Text = (sw.Elapsed.TotalMilliseconds/1000.0).ToString() + " (sec)";

						bestsolution = "";
						for(int i=0; i<numofJobs; i++)
							bestsolution += fastbestsolution[i].ToString() + " ";
						BSset.Text = bestsolution;
						BOval.Text = bestobj.ToString();
						result_list.ResumeLayout();

						break;

					case 1:		//FastPermutation

						FastPermutation(jobs, start, numofJobs-1);
						sw.Stop();
						timer.Text = (sw.Elapsed.TotalMilliseconds/1000.0).ToString() + " (sec)";

						bestsolution = "";
						for(int i=0; i<numofJobs; i++)
							bestsolution += fastbestsolution[i].ToString() + " ";
						BSset.Text = bestsolution;
						BOval.Text = bestobj.ToString();
						result_list.ResumeLayout();

						break;

					case 2:		//TurboPermutation
						//Since that C program is more efficient than C#, in this case, call out BFperm.exe to help us. 
						Process permu = new Process();
						ProcessStartInfo pInfo = new ProcessStartInfo("BFperm.exe");
						pInfo.Arguments = FILENAME;
						pInfo.CreateNoWindow = true;
						permu.StartInfo = pInfo;

						permu.Start();

						while(!permu.HasExited) {
							permu.WaitForExit(33);
							timer.Text = (permu.TotalProcessorTime.TotalMilliseconds/1000.0).ToString() + " (sec)";
						}

						if (permu != null){
							sw.Stop();
							timer.Text = (permu.TotalProcessorTime.TotalMilliseconds/1000.0).ToString() + " (sec)";
							permu.Close();
							permu.Dispose();
							permu = null;						            
						}
				
						System.IO.StreamReader myFile = null;
						myFile = new System.IO.StreamReader("Ans.txt");
						if(myFile!= null) {
							string myString = myFile.ReadLine().Trim();
							bestobj = double.Parse(myString);
							myString = myFile.ReadLine();
							BSset.Text = myString;
							BOval.Text = bestobj.ToString();
							myString = myFile.ReadLine();
							myFile.Close();
						}
						break;
				}
			}
		}

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            //Detect keypressed events. If ESC was pressed, terminate the application.
            if (keyData == Keys.Escape) {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

		private void import_btn_MouseHover(object sender, EventArgs e){
			tip.ToolTipTitle = "操作提示";
			tip.SetToolTip(this.import_btn,"點擊 \"Import File\" 按鈕匯入檔案");
			tip.ToolTipIcon = ToolTipIcon.Info;
		}

		private void btnCreateBinGA_Click(object sender, EventArgs e){
			//Create binarySolver
			binarySolver = new BinaryGA(numofJobs * numofJobs, OptimizationType.Min, new GASolver<byte>.ObjectiveFunctionDelegate(ComputeTotalSetupTime));
			Solver.SelectedObject = binarySolver;
			buttonReset.Enabled = true;
			btnCreateBinGA.Enabled = false;
		}
		
		private void btnCreatePerGA_Click(object sender, EventArgs e){
			//Create permSolver
			permSolver = new PermutationGA(numofJobs, OptimizationType.Min, new GASolver<int>.ObjectiveFunctionDelegate(ComputeTotalSetupTime));
			Solver.SelectedObject = this.permSolver;
			buttonReset.Enabled = true;
		}

		private double ComputeTotalSetupTime(byte[] variables){
			//ComputeTotalSetupTime for binarySolver
			double time = 0.0;
			for (int i = 0; i < variables.Length; i++){
				time += ProcessTime[(int)(i / numofJobs), i % numofJobs] * (double)variables[i];
			}

			return time + Penality * (double)GetConstraintCount(variables);
		}
		
		private double ComputeTotalSetupTime(int[] variables){
			//ComputeTotalSetupTime for permSolver
			double time = 0.0;
			for (int i = 0; i < numofJobs; i++)
				time += ProcessTime[variables[i], i];

			return time;
		}

		private int GetConstraintCount(byte[] variables){
			int ConstraintCount = 0, error;
			//GetConstraintCount for binarySolver
			for (int i = 0; i < numofJobs; i++){
				error = 0;
				for (int j = i * numofJobs; j < i * numofJobs + numofJobs; j++)
					error += (int)variables[j];
				ConstraintCount += Math.Abs(error - 1);
			}
			for (int i = 0; i < numofJobs; i++){
				error = 0;
				for (int j = 0; j < numofJobs; j++)
					error += (int)variables[j * this.numofJobs + i];
				ConstraintCount += Math.Abs(error - 1);
			}
			return ConstraintCount;
		}

		private void buttonReset_Click(object sender, EventArgs e){
			//Reset all the objects
			if(tabGA.SelectedTab == BinGA){
				if(binarySolver == null){
					iterend.Enabled = iterone.Enabled = false;
					return ;
				}
				binarySolver.reset();
			}
			else if(tabGA.SelectedTab == PermGA){
				if(permSolver == null){
					iterend.Enabled = iterone.Enabled = false;
					return ;
				}
				permSolver.reset();
			}

			iterone.Enabled = iterend.Enabled = true;

			reset_chart();

			GAobj_lbl.Text = "(NONE)";
			GAsol_lbl.Text = "(NONE)";
			constrain.Text = "(NONE)";
		}

		private void iterone_Click(object sender, EventArgs e){
			//Run one time of GA
			if(tabGA.SelectedTab == BinGA){
				if(binarySolver!=null){
					binarySolver.executeOneIteration();					
					chartGA.Series[0].Points.AddXY((double)binarySolver.IterationCount, binarySolver.IterationAverage);
					chartGA.Series[1].Points.AddXY((double)binarySolver.IterationCount, binarySolver.IterationBestObjective);
					chartGA.Series[2].Points.AddXY((double)binarySolver.IterationCount, binarySolver.SoFarTheBestObjective);
					updateBestInformation();
				}
			}
			else if(tabGA.SelectedTab == PermGA){
				if(permSolver!=null){
					permSolver.executeOneIteration();
					chartGA.Series[0].Points.AddXY((double)permSolver.IterationCount, permSolver.IterationAverage);
					chartGA.Series[1].Points.AddXY((double)permSolver.IterationCount, permSolver.IterationBestObjective);
					chartGA.Series[2].Points.AddXY((double)permSolver.IterationCount, permSolver.SoFarTheBestObjective);
					updateBestInformation();
				}
			}
			Solver.Refresh();
		}
		
		private void iterend_Click(object sender, EventArgs e){
			//Run preset times of GA
			if(tabGA.SelectedTab == BinGA){
				if(binarySolver!=null){
					for (int i = 0; i < binarySolver.IterationLimit; i++){
						binarySolver.executeOneIteration();					
						chartGA.Series[0].Points.AddXY((double)binarySolver.IterationCount, binarySolver.IterationAverage);
						chartGA.Series[1].Points.AddXY((double)binarySolver.IterationCount, binarySolver.IterationBestObjective);
						chartGA.Series[2].Points.AddXY((double)binarySolver.IterationCount, binarySolver.SoFarTheBestObjective);
					}
					updateBestInformation();
				}
			}
			else if(tabGA.SelectedTab == PermGA){
				if(permSolver!=null){
					for (int i = 0; i < permSolver.IterationLimit; i++){
						permSolver.executeOneIteration();
						chartGA.Series[0].Points.AddXY((double)permSolver.IterationCount, permSolver.IterationAverage);
						chartGA.Series[1].Points.AddXY((double)permSolver.IterationCount, permSolver.IterationBestObjective);
						chartGA.Series[2].Points.AddXY((double)permSolver.IterationCount, permSolver.SoFarTheBestObjective);
					}
					updateBestInformation();
				}
			}
			Solver.Refresh();
		}

		private void updateBestInformation(){
			//Update all the information 
			if(tabGA.SelectedTab == BinGA){				
				string text="\n";
				for(int i=0; i<numofJobs; i++){
					for(int j=0; j<numofJobs; j++)
						text += binarySolver.SoFarTheBestSolution[i*numofJobs+j].ToString() + " ";
					text += "\n";
				}
				
				GAsol_lbl.Text = text;
				text=binarySolver.SoFarTheBestObjective.ToString();

				GAobj_lbl.Text = text;
				constrain.Text = GetConstraintCount(binarySolver.SoFarTheBestSolution).ToString();
			}
			else if(tabGA.SelectedTab == PermGA){
				PGAobj_lbl.Text = permSolver.SoFarTheBestObjective.ToString();
				string text = "\n";
				for(int i=0; i<numofJobs; i++){
						text += permSolver.SoFarTheBestSolution[i].ToString() + " ";
				}
				PGAsol_lbl.Text = text;
			}
		}

		private void textpenalty_TextChanged(object sender, EventArgs e){
			//Set the penalty
			try{
				Penality = Convert.ToDouble(textpenalty.Text);
			}
			catch
			{
				Penality = 100.0;
				textpenalty.Text = Penality.ToString();
			}
		}
		
		private void tabGA_SelectedIndexChanged(object sender, EventArgs e){
			//reset chart and handle the event when tabpage changed
			reset_chart();
			if(tabGA.SelectedTab == BinGA){
				if(binarySolver == null){
					buttonReset.Enabled = false;
					iterone.Enabled = false;
					iterend.Enabled = false;
				}
				else{
					buttonReset.Enabled = true;
					iterone.Enabled = true;
					iterend.Enabled = true;
				}
				Solver.SelectedObject = binarySolver;
			}
			else if(tabGA.SelectedTab == PermGA){
				if(permSolver == null){
					buttonReset.Enabled = false;
					iterone.Enabled = false;
					iterend.Enabled = false;
				}
				else{
					buttonReset.Enabled = true;
					iterone.Enabled = true;
					iterend.Enabled = true;
				}
				Solver.SelectedObject = permSolver;
			}
		}

		private void recursive_type_SelectedIndexChanged(object sender, EventArgs e){
			//All solutions won't be shown when call BFperm.exe
			if(recursive_type.SelectedIndex == 2){
				show_chk.Checked = false;
				show_chk.Enabled = false;
			}
			else{
				show_chk.Enabled = true;
			}
		}

		private void reset_chart(){
			//Reset Chart
			chartGA.Series.Dispose();
			chartGA.Series.Clear();
			chartGA.Series.Dispose();
			chartGA.Series.Add("Iteration Average");
			chartGA.Series.Add("Iteration Best");
			chartGA.Series.Add("So Far The Best");
			chartGA.Series[0].ChartType = SeriesChartType.Line;
			chartGA.Series[1].ChartType = SeriesChartType.Line;
			chartGA.Series[2].ChartType = SeriesChartType.Line;
		}
	}
}

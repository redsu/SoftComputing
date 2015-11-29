using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace R04522602許泰源Ass08{
	public partial class Main : Form{
		//Time matrix
		double[,] ProcessTime;
		//Potential solution
		int[] jobs;
		//No. of solution
		int numofsol = 0;
		//Number of machines and jobs
		int count = 0;
		//Flag to check if data loaded
		bool loaded = false;
		
		//Optimal objective
		double bestobj;
		//Best solution set
		string bestsolution;

		public Main(){
			InitializeComponent();
			//Initialize the flags and disable solve button
			loaded = false;
			slv_btn.Enabled = false;

			//Wake up import_btn_MouseHover
			import_btn_MouseHover(null, null);
		}
		
		//Swap list[i] and list[k]
		private int[] Swap(int[] list, int i, int k) {
			int tmp;
			int[] tmplist = (int[])list.Clone();

			tmp = tmplist[i];
			
			for(int j= i; j>k; j--)
				tmplist[j] = tmplist[j-1];
			tmplist[k] = tmp;
	
			return tmplist;
		}

		//Get all of the permutations by recursion
		private void Permutation(int[] list, int k, int m){
			if(k==m) {
				string output = "", sol = "";
				double Obj = 0.0;

				for(int i=0; i<count; i++){
					Obj += ProcessTime[list[i],i];
					sol += string.Format("{0} ", list[i]);
				}

				if (Obj < bestobj){
					bestobj = Obj;
					bestsolution = sol;
				}
				
				output = string.Format("No. {0:00000000} Solution: {1}  Obj = {2:.0000}", numofsol, sol, Obj);
				result_list.Items.Add(output);

				numofsol++;
			}
			else{
				for(int i= k; i<= m; i++){
					int[] tmplist = Swap(list, i, k);
					Permutation(tmplist, k + 1, m);
				}
			}
		}
			
		private void import_btn_Click(object sender, EventArgs e){
			OpenFileDialog open = new OpenFileDialog();
			System.IO.StreamReader myFile = null;
			string myString = "";

			//Check the filename and open the file
			if (open.ShowDialog()==System.Windows.Forms.DialogResult.OK && open.FileName!=""){
				//Read the data from file by Streamreader
				myFile = new System.IO.StreamReader(open.FileName);

				//Check the file is not empty
				if (myFile != null){
					myString = myFile.ReadLine().Trim();

					//Check the first line is not empty
					if(myString!=""){
						//Set the loaded flag to true				
						loaded = true;

						//Number of jobs		
						count = int.Parse(myString);
						
						//Show number of jobs
						noj_num.Text = count.ToString();

						//Initialize the Time matrix with size [count X count]
						ProcessTime = new double[count, count];
						//Initialize the Solution set
						jobs = new int[count];

						for (int i = 0; i < count; i++)
							jobs[i] = i;

						//Read the Time matrix and save into the 2-D array.
						for(int i=0; i<count; i++){
							myString = myFile.ReadLine().Trim();
							string[] nums = myString.Split(' ');
							for(int j=0; j<count; j++) 
								ProcessTime[i, j] = double.Parse(nums[j]);
						}
						
						//Clear the data output area
						data.Columns.Clear();

						//Show the data on the DatagridView
						for (int i=0; i<count; i++)
							data.Columns.Add("m" + i.ToString(), "m" + i.ToString());
						for (int i = 0; i < count; i++)
							data.Rows.Add();
						for (int i = 0; i < count; i++)
							for (int j = 0; j < count; j++)
								data.Rows[i].Cells[j].Value = ProcessTime[i, j];

						//Enable the solve button
						slv_btn.Enabled = true;
					}
				}
			}
        }

		private void slv_btn_Click(object sender, EventArgs e){
			//If the data is loaded and selected page is page No.01, calculate the result and show
			if(loaded == true && tab.SelectedIndex == 0){
				//Intitialize the number of solution
				numofsol = 1;
				
				//Initialize the value of best objective to infinity
				bestobj = double.MaxValue;

				//Clear the result list
				result_list.Items.Clear();

				//Run Permutation() to try any potential solution.
				Permutation(jobs, 0, count - 1);

				//Show the optimal solution
				BSset.Text = bestsolution;
				BOval.Text = bestobj.ToString();
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
	}
}

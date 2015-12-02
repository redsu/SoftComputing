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
		bool[] Position;

		public Main(){
			InitializeComponent();
			//Initialize the flags and disable solve button
			loaded = false;
			slv_btn.Enabled = false;

			//Wake up import_btn_MouseHover
			import_btn_MouseHover(null, null);
		}

		/*********************************************/
		int[] solution;
		int[] fastbestsolution;
		private void FastPremutation(int index){			
			int i, j;
			double obj;
			for(i = 0; i < count; i++){
				if(!Position[i]){
					solution[i] = index;
					Position[i] = true;
					if(index == count-1){
						obj = 0.0;
						for(j = 0; j < count; j++){
							obj += ProcessTime[solution[j],j];
						}
						if(obj < bestobj){
							for(j=0; j<count; j++)
								fastbestsolution[j] = solution[j];
							bestobj = obj;
						}
					}
					else
						FastPremutation(index+1);
					Position[i] = false;
				}
			}
		}
		/*********************************************/

		//Get all of the permutations by recursion
		private class perm{
			public int[] list;
			public int s, layer;
		}

		private void Permutation(int[] list, int k, int m){
			//Stack
			
			perm[] stack = new perm[500];
			int ptr = 0, len, layer, swap;
			len = list.Length;

			string output = "", sol = "";
			double Obj = 0.0;
			int[] tmp = new int[len];
			int[] stacklist = new int[len];
			
			for(int i=0; i<len/2+1; i++){
				swap = list[i];
				list[i] = list[len-i-1];
				list[len-i-1] = swap;
			}

			stack[ptr] = new perm();

			stack[ptr].list = list;
			stack[ptr].s = 0;
			stack[ptr].layer = 0;

			while(ptr >= 0){
				layer = stack[ptr].layer;
				stacklist = (int [])stack[ptr].list.Clone();
				if(len>layer){
					for(int i=0; i<len-layer; i++){
					
						tmp = (int[])stacklist.Clone();
						
						int t = tmp[i+layer];
					
						for(int j=layer+i; j>layer; j--)
							tmp[j] = tmp[j-1]; 
						tmp[layer] = t;

						stack[ptr] = new perm();
						stack[ptr].list = new int[len];
						stack[ptr].list = (int[])tmp.Clone();
						stack[ptr].layer = layer+1;
						ptr++;
					}
					ptr--;
				}
				else{
					Obj = 0;
					sol = "";
					for(int i=0; i<count; i++){
						Obj += ProcessTime[stack[ptr].list[i],i];
						sol += string.Format("{0} ", stack[ptr].list[i]);
					}

					if (Obj < bestobj){
						bestobj = Obj;
						bestsolution = sol;
					}
				
					output = string.Format("No. {0:00000000} Solution: {1}  Obj = {2:.0000}", numofsol, sol, Obj);
					result_list.Items.Add(output);

					numofsol++;
					ptr--;
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
			System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
			
			Process permu = new Process();
			permu.StartInfo.FileName = "BFperm.exe";
			ProcessStartInfo pInfo = new ProcessStartInfo("BFperm.exe");
            pInfo.Arguments = FILENAME;
			pInfo.CreateNoWindow = true;
			permu.StartInfo = pInfo;
			
			sw.Reset();//碼表歸零
			sw.Start();//碼表開始計時

			permu.Start();
			permu.WaitForExit();

			if (permu != null){
				textBox1.Text = (permu.TotalProcessorTime.TotalMilliseconds/1000.0).ToString() + " (sec)";
                permu.Close();
                permu.Dispose();
                permu = null;
                sw.Stop();//碼錶停止            
            }

			System.IO.StreamReader myFile = null;
			myFile = new System.IO.StreamReader("Ans.txt");
			string myString = myFile.ReadLine().Trim();
			bestobj = double.Parse(myString);
			myString = myFile.ReadLine();
			BSset.Text = myString;
			BOval.Text = bestobj.ToString();
			textBox1.Text = (sw.Elapsed.TotalMilliseconds/1000.0).ToString() + " (sec)";
			myString = myFile.ReadLine();
			myFile.Close();
			
			/*
			if(loaded == true && tab.SelectedIndex == 0){
				//Intitialize the number of solution
				numofsol = 1;
				
				//Initialize the value of best objective to infinity
				bestobj = double.MaxValue;

				//Clear the result list
				result_list.Items.Clear();
				result_list.SuspendLayout();

				//Run Permutation() to try any potential solution.
				//Permutation(jobs, 0, count - 1);

				//FP
				Position = new bool[count];
				fastbestsolution = new int[count];
				solution = new int[count];
				for(int i=0; i<count; i++)
					Position[i] = false;

				sw.Reset();//碼表歸零
				sw.Start();//碼表開始計時

				FastPremutation(0);
				
				sw.Stop();//碼錶停止
				//CFP
				

				//Show the optimal solution
				//BSset.Text = bestsolution;
				bestsolution = "";
				for(int i=0; i<count; i++)
					bestsolution += fastbestsolution[i].ToString() + " ";
				BSset.Text = bestsolution;
				BOval.Text = bestobj.ToString();
				result_list.ResumeLayout();
				

				textBox1.Text = (sw.Elapsed.TotalMilliseconds/1000.0).ToString() + " (sec)";
			}
			*/
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

		private void new_binga_Click(object sender, EventArgs e){

		}
	}
}

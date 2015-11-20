using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace R04522602許泰源Ass07
{
	public partial class Main : Form
	{
		double[,] ProcessTime;
		int[] jobs;
		int numofsol = 0;
		int count = 0;
		bool loaded = false;
		double bestobj;
		string bestsolution;

		public Main()
		{
			InitializeComponent();
			loaded = false;
			slv_btn.Enabled = false;
		}
		
		private int[] Swap(int[] list, int i, int k) {
			int tmp;
			int[] tmplist = (int[])list.Clone();
			tmp = tmplist[i];
			for(int j= i; j>k; j--) {
				tmplist[j] = tmplist[j-1];
			}
			tmplist[k] = tmp;
			return tmplist;
		}

		private void Permutation(int[] list, int k, int m) {
			if(k== m) {
				string output = "", sol = "";
				
				double Obj = 0.0;
				for(int i=0; i<count; i++) {
					Obj += ProcessTime[list[i],i];
					sol += string.Format("{0} ", list[i]);
				}
				if(Obj < bestobj) {
					bestobj = Obj;
					bestsolution = sol;
				}
				
				output = string.Format("No. {0:00000000} Solution: {1}  Obj = {2:.0000}", numofsol, sol, Obj);
				result_list.Items.Add(output);


				numofsol++;
			}
			else
			{
				for(int i= k; i<= m; i++) {
					int[] tmplist = Swap(list, i, k);
					//Swap(list, i, k);
					Permutation(tmplist, k + 1, m);
					//Swap(list, i, k);
				}
			}
		}

		private void import_btn_Click(object sender, EventArgs e)
		{
			OpenFileDialog open = new OpenFileDialog();
			System.IO.StreamReader myFile = null;
			string myString = "";
			if(open.ShowDialog()==System.Windows.Forms.DialogResult.OK && open.FileName!="")
			{
				myFile = new System.IO.StreamReader(open.FileName);
				if (myFile != null) {
					myString = myFile.ReadLine().Trim();
					if(myString!="") {						
						count = int.Parse(myString);
						ProcessTime = new double[count, count];

						for(int i=0; i<count; i++) {
							myString = myFile.ReadLine().Trim();
							string[] nums = myString.Split(' ');
							for(int j=0; j<count; j++) 
								ProcessTime[i, j] = double.Parse(nums[j]);
						}

						jobs = new int[count];

						for (int i = 0; i < count; i++)
							jobs[i] = i;

						loaded = true;

						data.Columns.Clear();

						for (int i=0; i<count; i++)
							data.Columns.Add("m" + i.ToString(), "m" + i.ToString());
						for (int i = 0; i < count; i++)
							data.Rows.Add();
						for (int i = 0; i < count; i++)
							for (int j = 0; j < count; j++)
								data.Rows[i].Cells[j].Value = ProcessTime[i, j];
						slv_btn.Enabled = true;
					}
				}
			}
        }

		private void slv_btn_Click(object sender, EventArgs e){
			if(loaded == true) {				
				numofsol = 1;
				bestobj = double.MaxValue;
				Permutation(jobs, 0, count - 1);
				BSset.Text = bestsolution;
				BOval.Text = bestobj.ToString();
			}
		}
	}
}

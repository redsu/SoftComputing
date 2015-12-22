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
using TSP;
using COP;
using Steema.TeeChart;
using Steema.TeeChart.Styles;

namespace R04522602許泰源Ass11{
	public partial class Main : Form{
		Random randomizer = new Random();
		COPBenchmark COP_Problem = null;
		PSOSolver PSO_Solver = null;
		Surface surface = new Surface();
		Points3D points = new Points3D();

		int[] SoFarTheBestSolution;
		

		public Main(){
			InitializeComponent();
			WindowState = FormWindowState.Maximized;
			//Initialize the flags and disable all unused button.
			
			btnReset.Enabled = false;
			btnExeone.Enabled = false;
			btnEnd.Enabled = false;
			btn_createPSO.Enabled = false;
			

			tChart.Aspect.Orthogonal = false;
			tChart.Aspect.Zoom = 60;
			tChart.Aspect.Chart3DPercent = 100;
			

			//Wake up import_btn_MouseHover
			import_btn_MouseHover(null, null);

			string text = "So Far The Best Objective : (NONE)";
			lbl_sofarobj.Text = text;
			text = "So Far The Best Solution : (NONE)";
			lbl_sofarsol.Text = text;

			surface.Title = "Function";
			points.Title  = "SoFarSolutionParticles";
		}

		//Find a solution by Greedy Algorithm.
		

		//Import the data
		private void import_btn_Click(object sender, EventArgs e){
			COP_Problem = COPBenchmark.LoadAProblemFromAFile();
			if(COP_Problem != null){
				COP_Problem.DisplayOnPanel(sCouter1.Panel1);
				double[] variables = new double[COP_Problem.Dimension];
			
				SoFarTheBestSolution = new int[COP_Problem.Dimension];
			
				Solver.SelectedObject = null;
				btnReset.Enabled = btnExeone.Enabled = btnEnd.Enabled = false;
				btn_createPSO.Enabled = true;
				tChart.Series.Clear();
				tChart.Series.Add(surface);
				tChart.Series.Add(points);
				for(int i=0; i<COP_Problem.Dimension; i++)
					variables[i] = 0;

				for(double i=COP_Problem.LowerBound[0]; i<COP_Problem.UpperBound[0]; i+=(COP_Problem.UpperBound[0]-COP_Problem.LowerBound[0])/100){
					for(double j=COP_Problem.LowerBound[1]; j<COP_Problem.UpperBound[1]; j+=(COP_Problem.UpperBound[1]-COP_Problem.LowerBound[1])/100){
					
						for(int k=0; k<COP_Problem.Dimension; k++)
							variables[k] = (COP_Problem.UpperBound[0]-COP_Problem.LowerBound[0])/100*(k-COP_Problem.Dimension/2);
					
						variables[0] = i;
						variables[1] = j;
						surface.Add(variables[0], COP_Problem.GetObjectiveValue(variables), variables[1]);
					}
				}
			}
		}

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            //Detect keypressed events. If ESC was pressed, terminate the application.
            if (keyData == Keys.Escape) {
                Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

		private void import_btn_MouseHover(object sender, EventArgs e){
			tip.ToolTipTitle = "操作提示";
			tip.SetToolTip(openfile,"點擊 \"OpenFile\" 按鈕匯入檔案");
			tip.ToolTipIcon = ToolTipIcon.Info;
		}

		private void btnExeone_Click(object sender, EventArgs e){
			int i;
			PSO_Solver.RunOneIteration();
			points.Clear();
			for(i=0; i<PSO_Solver.NumberOfParticles; i++)
				points.Add(PSO_Solver.Solutions[i][0], PSO_Solver.ObjectiveValues[i], PSO_Solver.Solutions[i][1]);
			
			sCouter2.Panel1.Refresh();
			updateBestInformation();
		}
		
		private void btnEnd_Click(object sender, EventArgs e){
			int i, j;
			
			for(i=0; i<PSO_Solver.Iteration_Limit; i++){
				PSO_Solver.RunOneIteration();
				updateBestInformation();
				if(updateperiteration.Checked){
					chart.Update();
					points.Clear();
					for(j=0; j<PSO_Solver.NumberOfParticles; j++)
						points.Add(PSO_Solver.Solutions[j][0], PSO_Solver.ObjectiveValues[j], PSO_Solver.Solutions[j][1]);
					sCouter2.Panel1.Refresh();
				}
			}
			points.Clear();
			for(i=0; i<PSO_Solver.NumberOfParticles; i++)
				points.Add(PSO_Solver.Solutions[i][0], PSO_Solver.ObjectiveValues[i], PSO_Solver.Solutions[i][1]);
			updateBestInformation();
			sCouter2.Panel1.Refresh();
		}
		private void updateBestInformation(){
			int i;
			double obj = 0.0;
			string text = "So Far The Best Objective : ";
			text += PSO_Solver.SoFarTheBestObjective.ToString("F5");
			lbl_sofarobj.Text = text;
			text = "So Far The Best Solution : \n";
			for(i=0; i<COP_Problem.Dimension; i++)
				text += PSO_Solver.SoFarTheBestSolution[i].ToString("F5") + " ";
			lbl_sofarsol.Text = text;


			chart.Series[0].Points.AddXY((double)PSO_Solver.Iteration_count, PSO_Solver.SoFarTheBestObjective);
			chart.Series[1].Points.AddXY((double)PSO_Solver.Iteration_count, PSO_Solver.IterationAverage);
			chart.Series[2].Points.AddXY((double)PSO_Solver.Iteration_count, PSO_Solver.IterationBest);
		}

		private void btn_createPSO_Click(object sender, EventArgs e){
			PSO_Solver = new PSOSolver(COP_Problem, OptimizationType.Min);
			Solver.SelectedObject = PSO_Solver;
			btnReset.Enabled = true;
		}

		//Reset
		private void btnReset_Click(object sender, EventArgs e){
			int i, j;
			PSO_Solver.Reset();
			btnExeone.Enabled = true;
			btnEnd.Enabled = true;
			points.Clear();
			for(i=0; i<chart.Series.Count; i++)
				chart.Series[i].Points.Clear();
			for(i=0; i<PSO_Solver.NumberOfParticles; i++)
				points.Add(PSO_Solver.Solutions[i][0], COP_Problem.GetObjectiveValue(PSO_Solver.Solutions[i]) ,PSO_Solver.Solutions[i][1]);
			

			string text = "So Far The Best Objective : (NONE)";
			lbl_sofarobj.Text = text;
			text = "So Far The Best Solution : (NONE)";
			lbl_sofarsol.Text = text;
		}

		private void btn_createGA_Click(object sender, EventArgs e){

		}

		private void tChart1_Click(object sender, EventArgs e){

		}
	}
}

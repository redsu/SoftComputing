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

namespace R04522602許泰源Ass10{
	public partial class Main : Form{
		Random randomizer = new Random();
		
		//
		int[] SoFarTheBestSolution;
		double SoFarTheBestObjective;
		bool loaded = false;

		PermutationGA permSolver;
		PermutationACS ACOSolver;

		public Main(){
			InitializeComponent();
			//Initialize the flags and disable all unused button.
			
			btnReset.Enabled = false;
			btnExeone.Enabled = false;
			btnEnd.Enabled = false;
			btn_createACO.Enabled = false;
			loaded = false;

			//Setup the dfault value of combobox
			

			//Wake up import_btn_MouseHover
			import_btn_MouseHover(null, null);

			string text = "So Far The Best Solution : (NONE)";

			lbl_sofarsol.Text = text;

			text = "So Far The Best Objective : (NONE)";

			lbl_sofarslen.Text = text;

			reset_chart();
		}

		private void SetGreedyRoute(){
            int noc = TSPBenchmark.NumberOfCities;
			int k = randomizer.Next(noc);
			int start = k, visitedvertex;
			SoFarTheBestSolution[0] = k;
            visitedvertex = 1;

			bool[] visited = new bool[noc];
            for (int i = 0; i < visited.Length; i++) visited[i] = false;
            visited[k] = true;
			
			double greedylength = 0.0, shortestedge;
			int closestvertex;

            while(true){
				shortestedge = double.MaxValue;
				closestvertex = -1;
                for(int i=0; i<noc; i++){
					if(i!=k && !visited[i]){
						if(TSPBenchmark.FromToDistanceMatrix[k,i] < shortestedge){
							shortestedge = TSPBenchmark.FromToDistanceMatrix[k,i];
							closestvertex = i;
						}
					}
				}
				if(closestvertex != -1){
					greedylength += shortestedge;
					k = closestvertex;
					visited[k] = true;
					SoFarTheBestSolution[visitedvertex] = k;
					visitedvertex++;
				}
				if(visitedvertex == noc)
					break;
            }

			greedylength += TSPBenchmark.FromToDistanceMatrix[k,start];
			SoFarTheBestObjective = greedylength;
        }

		private void import_btn_Click(object sender, EventArgs e){
			int i = TSPBenchmark.ImportATSPFile(true, true);
            lsbSolutions.Clear();
            lsbPheromone.Clear();
            foreach (Series s in chart.Series) s.Points.Clear();

            rtxBenchmark.Text = "";
            SoFarTheBestSolution = null;
            if (i < 0){
                tab_route.Refresh();
                return;
            }

            lbl_title.Text = "Title : " + TSPBenchmark.Title;
            lbl_sl.Text = "Shorest Length : " + (TSPBenchmark.HasOptimalObjective ? TSPBenchmark.GlobalShorestLength4TSP.ToString("0.0000") : "n/a");
            lbl_noc.Text = "Number of Cities : " + TSPBenchmark.NumberOfCities.ToString();
            rtxBenchmark.AppendText(TSPBenchmark.FileComments);
            SoFarTheBestSolution = new int[TSPBenchmark.NumberOfCities];

            SetGreedyRoute();
			tab_route.Refresh();

			Solver.SelectedObject = null;
			ACOSolver = null;
			btnReset.Enabled = btnExeone.Enabled = btnEnd.Enabled = false;
			btn_createACO.Enabled = true;
			loaded = true;
		}
		
		private void Draw_Route_and_Vertex(object sender, PaintEventArgs e){
            if (SoFarTheBestSolution != null && TSPBenchmark.BenchmarkIsReady )
                TSPBenchmark.DrawCitiesOptimalRouteAndARoute(e.Graphics, e.ClipRectangle.Width, e.ClipRectangle.Height, SoFarTheBestSolution);
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
			///tip.ToolTipTitle = "操作提示";
			///tip.SetToolTip(import_btn,"點擊 \"Import File\" 按鈕匯入檔案");
			///tip.ToolTipIcon = ToolTipIcon.Info;
		}

		private void btnExeone_Click(object sender, EventArgs e){
			//Run one time of GA
			if(tabHeur.SelectedTab == tab_ACO){
				if(ACOSolver!=null){
					ACOSolver.executeOneIteration();					
					chart.Series[0].Points.AddXY((double)ACOSolver.IterationCount, ACOSolver.IterationAverage);
					chart.Series[1].Points.AddXY((double)ACOSolver.IterationCount, ACOSolver.IterationBestObjective);
					chart.Series[2].Points.AddXY((double)ACOSolver.IterationCount, ACOSolver.SoFarTheBestObjective);
					SoFarTheBestSolution = ACOSolver.SoFarTheBestSoluiton;
					updateBestInformation();
					sCouter3.Panel2.Refresh();
				}
			}
			else if(tabHeur.SelectedTab == tabGA){
				if(permSolver!=null){
					permSolver.executeOneIteration();
					chart.Series[0].Points.AddXY((double)permSolver.IterationCount, permSolver.IterationAverage);
					chart.Series[1].Points.AddXY((double)permSolver.IterationCount, permSolver.IterationBestObjective);
					chart.Series[2].Points.AddXY((double)permSolver.IterationCount, permSolver.SoFarTheBestObjective);
					SoFarTheBestSolution = permSolver.SoFarTheBestSolution;
					updateBestInformation();
					sCouter3.Panel2.Refresh();
				}
			}
			Solver.Refresh();
		}
		
		private void btnEnd_Click(object sender, EventArgs e){
			//Run preset times of GA
			if(tabHeur.SelectedTab == tab_ACO){
				if(ACOSolver!=null){
					pBar.Minimum = 0;
					pBar.Maximum = ACOSolver.IterationLimit;
					pBar.Value = 0;
					for(int i=0; i<ACOSolver.IterationLimit; i++){
						pBar.Value++;
						ACOSolver.executeOneIteration();					
						chart.Series[0].Points.AddXY((double)ACOSolver.IterationCount, ACOSolver.IterationAverage);
						chart.Series[1].Points.AddXY((double)ACOSolver.IterationCount, ACOSolver.IterationBestObjective);
						chart.Series[2].Points.AddXY((double)ACOSolver.IterationCount, ACOSolver.SoFarTheBestObjective);
						SoFarTheBestSolution = ACOSolver.SoFarTheBestSoluiton;
						SoFarTheBestObjective = ACOSolver.SoFarTheBestObjective;
						if(updateperiteration.Checked){
							sCouter3.Panel2.Refresh();
						}
					}
					updateBestInformation();
					sCouter3.Panel2.Refresh();
				}
			}
			else if(tabHeur.SelectedTab == tabGA){
				if(permSolver!=null){
					pBar.Minimum = 0;
					pBar.Maximum = permSolver.IterationLimit;
					pBar.Value = 0;
					for (int i = 0; i < permSolver.IterationLimit; i++){
						pBar.Value++;
						permSolver.executeOneIteration();
						chart.Series[0].Points.AddXY((double)permSolver.IterationCount, permSolver.IterationAverage);
						chart.Series[1].Points.AddXY((double)permSolver.IterationCount, permSolver.IterationBestObjective);
						chart.Series[2].Points.AddXY((double)permSolver.IterationCount, permSolver.SoFarTheBestObjective);
						SoFarTheBestSolution = (int[])permSolver.SoFarTheBestSolution;
						SoFarTheBestObjective = permSolver.SoFarTheBestObjective;
						if(updateperiteration.Checked){
							sCouter3.Panel2.Refresh();
						}
					}
					updateBestInformation();
					sCouter3.Panel2.Refresh();
				}
			}
			Solver.Refresh();
		}

		private void updateBestInformation(){
			//Update all the information 
	
			if(tabHeur.SelectedTab == tab_ACO){
				string text = "So Far The Best Solution : \n";

				for(int i=0; i<TSPBenchmark.NumberOfCities; i++)
					text += ACOSolver.SoFarTheBestSoluiton[i].ToString() + " ";

				lbl_sofarsol.Text = text;

				text = "So Far The Best Objective : ";
				text += ACOSolver.SoFarTheBestObjective.ToString();
				lbl_sofarslen.Text = text;
			}
			else if(tabHeur.SelectedTab == tabGA){
				string text = "So Far The Best Solution : \n";

				for(int i=0; i<TSPBenchmark.NumberOfCities; i++)
					text += permSolver.SoFarTheBestSolution[i].ToString() + " ";
				

				lbl_sofarsol.Text = text;

				text = "So Far The Best Objective : ";
				text += permSolver.SoFarTheBestObjective.ToString();
				lbl_sofarslen.Text = text;
			}
		}

		private void tabGA_SelectedIndexChanged(object sender, EventArgs e){
			//reset chart and handle the event when tabpage changed
			reset_chart();
			if(tabHeur.SelectedTab == tabGA){
				if(permSolver == null){
					btnReset.Enabled = false;
					btnExeone.Enabled = false;
					btnEnd.Enabled = false;
				}
				else{
					btnReset.Enabled = true;
					btnExeone.Enabled = true;
					btnEnd.Enabled = true;
				}
				Solver.SelectedObject = permSolver;
			}
		}

		

		private void reset_chart(){
			//Reset Chart
			chart.Series.Dispose();
			chart.Series.Clear();
			chart.Series.Dispose();
			chart.Series.Add("Iteration Average");
			chart.Series.Add("Iteration Best");
			chart.Series.Add("So Far The Best");
			chart.Series[0].ChartType = SeriesChartType.Line;
			chart.Series[1].ChartType = SeriesChartType.Line;
			chart.Series[2].ChartType = SeriesChartType.Line;
		}

		private void btn_createACO_Click(object sender, EventArgs e){
			ACOSolver = new PermutationACS(TSPBenchmark.NumberOfCities, OptimizationType.Min, TSPBenchmark.ComputeObjectiveValue, DistanceInverseHeuristic);
            btnReset.Enabled = true;
            btnEnd.Enabled = btnExeone.Enabled = false;
            Solver.SelectedObject = ACOSolver;

            // Use the known best route length to set the drop amount multiplier
            if (TSPBenchmark.HasOptimalObjective)
                ACOSolver.DropMultiplier = TSPBenchmark.GlobalShorestLength4TSP;
            else
                ACOSolver.DropMultiplier = TSPBenchmark.AverageDistance * TSPBenchmark.NumberOfCities;


			ACOSolver.SoFarTheBestSoluiton = (int[])SoFarTheBestSolution.Clone();
			ACOSolver.SoFarTheBestObjective = TSPBenchmark.ComputeObjectiveValue(SoFarTheBestSolution);			
		}

		public double DistanceInverseHeuristic(int i, int j){
            double B = TSPBenchmark.MinimalTourDistance / TSPBenchmark.NumberOfCities;
            if (TSPBenchmark.HasOptimalObjective)  B = TSPBenchmark.MinimalTourDistance / TSPBenchmark.NumberOfCities;
            else B = TSPBenchmark.AverageDistance / 5.0;

			double mindis = TSPBenchmark.FromToDistanceMatrix[i, j];

			return mindis < 0.000001 ? 0.0 : B / mindis + 0.0000001;
        }

		private void btnReset_Click(object sender, EventArgs e){
			if(tabHeur.SelectedTab == tab_ACO){
				ACOSolver.reset();
				reset_chart();
				string text = "So Far The Best Solution : (NONE)";

				lbl_sofarsol.Text = text;

				text = "So Far The Best Objective : (NONE)";

				lbl_sofarslen.Text = text;

				btnExeone.Enabled = btnEnd.Enabled = true;


				ACOSolver.SoFarTheBestSoluiton = (int[])SoFarTheBestSolution.Clone();
				ACOSolver.SoFarTheBestObjective = TSPBenchmark.ComputeObjectiveValue(SoFarTheBestSolution);
				ACOSolver.GreedyShortest = TSPBenchmark.ComputeObjectiveValue(SoFarTheBestSolution);
				ACOSolver.DropMultiplier = ACOSolver.SoFarTheBestObjective;

				Solver.Refresh();
			}
			else{
				if(permSolver == null){
					btnEnd.Enabled = btnExeone.Enabled = false;
					return ;
				}
				permSolver.reset();

				string text = "So Far The Best Solution : (NONE)";

				lbl_sofarsol.Text = text;

				text = "So Far The Best Objective : (NONE)";

				lbl_sofarslen.Text = text;

				btnEnd.Enabled = btnExeone.Enabled = true;

				reset_chart();
			}
		}

		private void btn_createGA_Click(object sender, EventArgs e){
			//Create permSolver
			permSolver = new PermutationGA(TSPBenchmark.NumberOfCities, OptimizationType.Min, new GASolver<int>.ObjectiveFunctionDelegate(TSPBenchmark.ComputeObjectiveValue));
			Solver.SelectedObject = permSolver;
			btnReset.Enabled = true;
            btnEnd.Enabled = btnExeone.Enabled = false;
		}

	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace R04522602許泰源Ass12 {
	class Layer {
		Random rand = new Random();
		double[] perceptrons;
		double[] epsilons;
		double[][] weights;
		int Dout, Din;

		public int InputDim{
			get{ return Din; }
			set{ Din = value>0 ? value : Din; }
		}

		public int OutputDim{
			get{ return Dout; }
			set{ Dout = value>0 ? value : Dout; }
		}

		public double[] Perceptrons{
			get{ return perceptrons; }
			set{ perceptrons = value; }
		}

		public double[] Epsilons{
			get{ return epsilons; }
			set{ epsilons = value; }
		}

		public Layer(int input_dimension, int output_dimension){
			Dout = output_dimension;
			Din  = input_dimension;
			perceptrons = new double[input_dimension];
			epsilons    = new double[input_dimension];
			weights = new double[input_dimension][];
			for(int i=0; i<input_dimension; i++)
				weights[i] = new double[output_dimension];
			InitWeights();
		}

		public void InitWeights(){
			//Bug, need to add one more dimension for x0
			//But we can do it on the input data before it send in;
			//perceptrons = (double[])input.Clone();
			for(int i=0; i<Din; i++)
				for(int j=0; j<Dout; j++)
					weights[i][j] = (rand.NextDouble()-0.5)*2;
		}

		public double[] Output(){
			double[] output = new double[Dout+1];
			double value;
			for(int i=1; i<Dout+1; i++){
				value = 0;

				for(int j=0; j<Din; j++)
					value += perceptrons[j] * weights[j][i-1];
				
				value = 1.0 / (1.0 + Math.Exp(-value));
				output[i] = value;
			}
			output[0] = 1.0;
					
			return output;
		}

		public void UpdateLastLayerEpsilon(double[] y){
			for(int i=1; i<Din; i++)
				epsilons[i] = -2 * (y[i-1] - perceptrons[i])*(perceptrons[i])*(1.0-perceptrons[i]);
		}

		public void UpdateEpsilon(double[] e){
			for(int i=1; i<Din; i++){
				epsilons[i] = 0;

				for(int j=0; j<Dout; j++)
					epsilons[i] += e[j+1]*weights[i][j];

				epsilons[i] *= (perceptrons[i])*(1.0-perceptrons[i]);
			}
		}

		public void UpdateWeight(double[] e, double eta){
			double delta_weight = 0.0;
			for(int i=0; i<Din; i++){
				delta_weight = 0.0;
				for(int j=0; j<Dout; j++){
					delta_weight = -eta * e[j+1] * perceptrons[i];
					weights[i][j] += delta_weight;
				}
			}
		}

		public void ShowWeights(int d, object sender){			
			for(int i=0; i<Dout; i++)
				for(int j=0; j<Din; j++)
					((ListBox)sender).Items.Add(String.Format("w[{0}][{2}][{1}] = {3:F4}",d,j,i,weights[j][i]));
		}
	}
}

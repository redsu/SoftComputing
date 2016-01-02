using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace R04522602許泰源Ass12 {
	class NeuralNetwork {
		public List<Layer> layer = new List<Layer>();
		int numOfLayer = 0, numOfHiddenLayer = 1;
		Data NN_Data;
		int input_dimension;
		int output_dimension;
		int vector_nums;
		int input_width;
		double eta = 0.7;
		double EoutRMS = 0.0;

		public double ErrOutRMS{
			get{return EoutRMS;}
		}

		public NeuralNetwork(int inputdim, int outputDim, int hiddenDim, Data data){
			//I:inputdim, O:outputDim, H:hiddenDim
			numOfLayer = 3;	//Default layers : 3
			layer.Add(new Layer(inputdim+1, hiddenDim));
			layer.Add(new Layer(hiddenDim+1, outputDim));
			layer.Add(new Layer(outputDim, 1));

			NN_Data = data;
		}

		public NeuralNetwork(){
			
		}

		public bool ImportData(){
			OpenFileDialog openfile = new OpenFileDialog();
			System.IO.StreamReader File = null;
			string fileString = "";
			string[] elements;
			char[] separator = new char[] {' ',',',';'};
			

			if (openfile.ShowDialog() == DialogResult.OK && openfile.FileName != ""){
				File = new System.IO.StreamReader(openfile.FileName);

				if(File != null){
					fileString = File.ReadLine().Trim();
					elements = fileString.Split(separator);
					vector_nums		 = int.Parse(elements[0]);
					input_dimension	 = int.Parse(elements[1]);
					output_dimension = int.Parse(elements[2]);
					input_width		 = int.Parse(elements[3]);

					//I:inputdim, O:outputDim, H:hiddenDim
					numOfLayer = 4;	//Default layers : 3
					layer.Add(new Layer(input_dimension+1, 4));
					layer.Add(new Layer(5, 5));
					layer.Add(new Layer(6, output_dimension));
					layer.Add(new Layer(output_dimension+1, 1));

					NN_Data = new Data(input_dimension, output_dimension, vector_nums);

					for(int i=0; i<vector_nums; i++){
						fileString = File.ReadLine().Trim();
						elements = fileString.Split(separator);
						for(int j=1; j<input_dimension+1; j++)
							NN_Data.input[i][j] = double.Parse(elements[j-1]);
						NN_Data.input[i][0] = 1.0;

						for(int j=input_dimension; j<input_dimension+output_dimension; j++)
							NN_Data.output[i][j-input_dimension] = double.Parse(elements[j]);
					}

					NN_Data.Shuffle();
					return true;
				}
				return false;
			}
			else
				return false;
		}

		public void InsertHiddenLayer(int position){
			if(position > 0 || position < numOfLayer){
				Layer newLayer = null;
				newLayer = new Layer(layer[position-1].OutputDim+1, layer[position].InputDim);
				layer.Insert(position, newLayer);
			}
		}

		public void DeleteHiddenLayer(int position){
			//DeleteLayer();
			;
		}

		public void UpdateNN(){
			EoutRMS = 0.0;
			double Eout_iter = 0.0;
			
			for(int i=0; i<vector_nums; i++){
				//Update all x (Pass forward)
				for(int j=0; j<layer[0].InputDim; j++)
					layer[0].Perceptrons[j] = NN_Data.input[i][j];
				
				for(int j=1; j<numOfLayer; j++)
					layer[j].Perceptrons = (double[])layer[j-1].Output().Clone();
				
				//Update all epsilons
				layer[numOfLayer-1].UpdateLastLayerEpsilon(NN_Data.output[i]);
				for(int j=numOfLayer-2; j>=0; j--)
					layer[j].UpdateEpsilon(layer[j+1].Epsilons);
				
				////Update all weights
				for(int j=0; j<numOfLayer-1; j++)
					layer[j].UpdateWeight(layer[j+1].Epsilons, eta);

				for(int j=1; j<layer[numOfLayer-1].InputDim; j++)
					Eout_iter += Math.Pow((NN_Data.output[i][j-1]-layer[numOfLayer-1].Perceptrons[j]), 2.0);
			}
			EoutRMS = Math.Sqrt(Eout_iter/((double)vector_nums*(layer[numOfLayer-1].InputDim-1)));
			//Console.WriteLine(EoutRMS.ToString());
		}
		
	}
}

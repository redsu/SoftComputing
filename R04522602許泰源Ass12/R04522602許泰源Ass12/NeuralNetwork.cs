using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;


namespace R04522602許泰源Ass12 {
	class NeuralNetwork {
		Random rand = new Random();
		public List<Layer> layer = new List<Layer>();
		int numOfLayer = 0, numOfHiddenLayer = 1;
		Data NN_Data;
		bool[] validationDataList;
		int input_dimension;
		int output_dimension;
		int vector_nums;
		int input_width;
		int iterationLimit = 100;
		double eta = 0.7;
		double learningRate = 0.999;
		double EoutRMS = 0.0, EinRMS = 0.0;
		double Eout01 = 0.0, Eout = 0.0;
		double sampleRate = 0.2;
		double correctness = 0.0;

		[Browsable(false)]
		public double ErrOut01{
			get{return Eout01;}
		}

		[Browsable(false)]
		public double ErrOutRMS{
			get{return EoutRMS;}
		}

		[Browsable(false)]
		public double ErrInRMS{
			get{return EinRMS;}
		}
		
		public double Eta{
			get{return eta;}
			set{eta = value;}
		}

		public double SampleRate{
			get{return sampleRate;}
			set{sampleRate = value;}
		}

		public int IterationLimit{
			get{return iterationLimit;}
			set{iterationLimit = value;}
		}

		public int NumOfLayer{
			get{return numOfLayer;}
			set{numOfLayer = value;}
		}

		public int Dimout{
			get{return output_dimension;}
			set{output_dimension = value;}
		}

		public double Correctness{
			get{return correctness;}
			set{correctness = value;}
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
			double minI, maxI, minO, maxO;

			minI = double.MaxValue;
			maxI = double.MinValue;
			minO = double.MaxValue;
			maxO = double.MinValue;

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
					numOfLayer = 3;	//Default layers : 3
					layer.Add(new Layer(input_dimension+1, 5));
					layer.Add(new Layer(6, output_dimension));
					layer.Add(new Layer(output_dimension+1, 1));

					NN_Data = new Data(input_dimension, output_dimension, vector_nums);
					validationDataList = new bool[vector_nums];
					for(int i=0; i<vector_nums; i++){
						validationDataList[i] = false;
						fileString = File.ReadLine().Trim();
						elements = fileString.Split(separator);
						for(int j=1; j<input_dimension+1; j++){
							NN_Data.input[i][j] = double.Parse(elements[j-1]);
							if(NN_Data.input[i][j]<minI)
								minI = NN_Data.input[i][j];
							if(NN_Data.input[i][j]>maxI)
								maxI = NN_Data.input[i][j];
						}
						NN_Data.input[i][0] = 1.0;

						for(int j=input_dimension; j<input_dimension+output_dimension; j++){
							NN_Data.output[i][j-input_dimension] = double.Parse(elements[j]);
							if(NN_Data.output[i][j-input_dimension]<minO)
								minO = NN_Data.output[i][j-input_dimension];
							if(NN_Data.output[i][j-input_dimension]>maxO)
								maxO = NN_Data.output[i][j-input_dimension];
						}
					}

					for(int i=0; i<vector_nums; i++){
						
						for(int j=0; j<input_dimension+1; j++)
							NN_Data.input[i][j] /= (maxI-minI);

						for(int j=input_dimension; j<input_dimension+output_dimension; j++)
							NN_Data.output[i][j-input_dimension] /= (maxO-minO);
						
					}

					NN_Data.Shuffle();
					BuildValidList();
					return true;
				}
				return false;
			}
			else
				return false;
		}

		public void InsertHiddenLayer(int position, int numOfPerceptrons){
			if(position > 0 || position < numOfLayer){
				Layer newLayer = null;
				newLayer = new Layer(numOfPerceptrons+1, layer[position].InputDim-1);
				layer[position-1].OutputDim = numOfPerceptrons;
				layer[position-1].Reset();
				layer.Insert(position, newLayer);
				numOfLayer++;
				Reset();
			}
		}

		public void DeleteHiddenLayer(int position){
			if(position > 0 && position < numOfLayer-1 && numOfLayer > 3){
				//layer[position+1].InputDim = layer[position-1].OutputDim+1;
				layer[position-1].OutputDim = layer[position+1].InputDim-1;
				layer[position-1].Reset();
				layer.RemoveAt(position);
				numOfLayer--;
				Reset();
			}
		}

		public void UpdateNN(){
			double Ein_iter = 0.0;
			int numOfTrainData = 0;
			for(int i=0; i<vector_nums; i++){
				if(!validationDataList[i]){
					numOfTrainData++;
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
						Ein_iter += Math.Pow((NN_Data.output[i][j-1]-layer[numOfLayer-1].Perceptrons[j]), 2.0);
				}
			}
			EinRMS = Math.Sqrt(Ein_iter/((double)numOfTrainData*(layer[numOfLayer-1].InputDim-1)));
			//eta *= learningRate;
			//eta = 1.0 / (1.0 + Math.Exp(-EinRMS));;
			//Console.WriteLine(EoutRMS.ToString());
		}

		public void BuildValidList(){
			int rnd;
			int N = (int)(vector_nums*sampleRate);
			for(int i=0; i<vector_nums; i++)
				validationDataList[i] = false;
			for(int i=0; i<N; i++){
				rnd = rand.Next(vector_nums);
				//if(rand.NextDouble()<sampleRate)
				
				if(!validationDataList[i])
					validationDataList[i] = true;
				else
					i--;
			}
		}
		
		public void Validation(){
			double Eout_test = 0.0;
			int numOfTestData = 0;
			for(int i=0; i<vector_nums; i++){
				if(validationDataList[i]){
					numOfTestData++;
					//Update all x (Pass forward)
					for(int j=0; j<layer[0].InputDim; j++)
						layer[0].Perceptrons[j] = NN_Data.input[i][j];
				
					for(int j=1; j<numOfLayer; j++)
						layer[j].Perceptrons = (double[])layer[j-1].Output().Clone();

					for(int j=1; j<layer[numOfLayer-1].InputDim; j++){
						if(Math.Abs(NN_Data.output[i][j-1]-layer[numOfLayer-1].Perceptrons[j])>0.1)
							Eout++;
						Eout_test += Math.Pow((NN_Data.output[i][j-1]-layer[numOfLayer-1].Perceptrons[j]), 2.0);
					}
				}
			}
			EoutRMS = Math.Sqrt(Eout_test/((double)numOfTestData*(layer[numOfLayer-1].InputDim-1)));
			Eout01 = Eout_test/((double)numOfTestData*(layer[numOfLayer-1].InputDim-1));

			//Console.WriteLine(EoutRMS.ToString());
		}

		public int[][] ValidationTable(){
			int[][] table = new int[output_dimension][];
			for(int i=0; i<output_dimension; i++){
				table[i] = new int[output_dimension];
				for(int j=0; j<output_dimension; j++)
					table[i][j] = 0;
			}

			double Eout_test = 0.0;
			int numOfTestData = 0;
			double Max;
			int indexV = 0, indexY = 0;
			correctness = 0.0;
			for(int i=0; i<vector_nums; i++){
				
				if(!validationDataList[i]){
					numOfTestData++;
					//Update all x (Pass forward)
					for(int j=0; j<layer[0].InputDim; j++)
						layer[0].Perceptrons[j] = NN_Data.input[i][j];
				
					for(int j=1; j<numOfLayer; j++)
						layer[j].Perceptrons = (double[])layer[j-1].Output().Clone();


					Max = double.MinValue;
					for(int j=1; j<layer[numOfLayer-1].InputDim; j++){
						if(Max < layer[numOfLayer-1].Perceptrons[j]){
							Max = layer[numOfLayer-1].Perceptrons[j];
							indexY = j-1;
						}
					}

					Max = double.MinValue;
					for(int j=0; j<layer[numOfLayer-1].InputDim-1; j++){
						if(Max < NN_Data.output[i][j]){
							Max = NN_Data.output[i][j];
							indexV = j;
						}
					}
					table[indexY][indexV]++;
					if(indexV == indexY)
						correctness += 1.0;
				}
			}
			correctness /= (int)(vector_nums - (int)(vector_nums*sampleRate));
			return table;
		}

		public void Reset(){
			for(int i=0; i<numOfLayer; i++)
				layer[i].InitWeights();
		}
	}
}

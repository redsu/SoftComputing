using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace R04522602許泰源Ass12 {
	public partial class Form1 : Form {
		NeuralNetwork NN = null;
		int count = 0;
		public Form1() {
			InitializeComponent();
		}

		private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {
			
		}

		private void OpenFile_Click(object sender, EventArgs e) {
			NN = new NeuralNetwork();
			if(NN.ImportData())	return;
			else MessageBox.Show("Fail to import data!");
			/*OpenFileDialog openfile = new OpenFileDialog();
			System.IO.StreamReader File = null;
			string fileString = "";
			string[] elements;
			char[] separator = new char[] {' ',',',';'};
			int input_dimension;
			int output_dimension;
			int vector_nums;
			int input_width;

			if (openfile.ShowDialog() == DialogResult.OK && openfile.FileName != ""){
				File = new System.IO.StreamReader(openfile.FileName);

				if(File != null){
					fileString = File.ReadLine().Trim();
					elements = fileString.Split(separator);
					vector_nums		 = int.Parse(elements[0]);
					input_dimension	 = int.Parse(elements[1]);
					output_dimension = int.Parse(elements[2]);
					input_width		 = int.Parse(elements[3]);
					Data data = new Data(input_dimension, output_dimension, vector_nums);

					for(int i=0; i<vector_nums; i++){
						fileString = File.ReadLine().Trim();
						elements = fileString.Split(separator);
						for(int j=1; j<input_dimension+1; j++)
							data.input[i][j] = int.Parse(elements[j-1]);
						data.input[i][0] = 1.0;

						for(int j=input_dimension; j<input_dimension+output_dimension; j++)
							data.output[i][j-input_dimension] = int.Parse(elements[j]);
					}
					NN = new NeuralNetwork(input_dimension, output_dimension, 1, data);
				}
				
			}
			else
				return;*/
		}

		private void button1_Click(object sender, EventArgs e) {
			//chart1.Series[0].Points.Clear();
			for(int i=0; i<50; i++){
				NN.UpdateNN();
				listBox1.Items.Clear();
				//NN.layer[0].ShowWeights(0, listBox1);
				chart1.Series[0].Points.AddXY(count++, NN.ErrOutRMS);
			}
		}
	}
}

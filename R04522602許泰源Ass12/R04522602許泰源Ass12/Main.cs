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
	public partial class NeuralNetworkSystem : Form {
		NeuralNetwork NN = null;
		int count = 0;
		public NeuralNetworkSystem() {
			InitializeComponent();
		}

		private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {
			
		}

		private void OpenFile_Click(object sender, EventArgs e) {
			NN = new NeuralNetwork();
			
			if(NN.ImportData()){
				NN_system.SelectedObject = NN;
				listBox1.Items.Clear();
				for(int i=0; i<NN.layer.Count; i++){
					listBox1.Items.Add(NN.layer[i]);
					//listBox1.Items[i]
				}
				dataGridView1.Rows.Clear();
				dataGridView1.Columns.Clear();
				for(int i=0; i<NN.Dimout; i++)
					dataGridView1.Columns.Add("y"+i.ToString(), "y"+i.ToString());

				for(int i=0; i<NN.Dimout; i++){
					dataGridView1.Rows.Add();
					dataGridView1.Rows[i].HeaderCell.Value = "Out " + i.ToString();
				}

				dataGridView1.RowHeadersWidth = 100;
				return;
			}
			else MessageBox.Show("Fail to import data!");
		}

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            //Detect keypressed events. If ESC was pressed, terminate the application.
            if (keyData == Keys.Escape) {
                Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

		private void button1_Click(object sender, EventArgs e) {
			/*chart1.Series[0].Points.Clear();
			chart1.Series[1].Points.Clear();
			count = 0;*/
			for(int i=0; i<NN.IterationLimit; i++){
				NN.UpdateNN();
				//listBox1.Items.Clear();
				//NN.layer[0].ShowWeights(0, listBox1);
				NN.Validation();
				chart1.Series[0].Points.AddXY(count, NN.ErrInRMS);
				chart1.Series[1].Points.AddXY(count, NN.ErrOutRMS);
				count++;
				UpdateInformation();
			}
		}

		private void UpdateInformation(){
			
			lbl_ein.Text = "Ein : " + NN.ErrInRMS;
			lbl_eout.Text = "Eout : " + NN.ErrOutRMS;
			lbl_err01.Text = "Eout(0/1) : " + NN.ErrOut01;
			lbl_ein.Refresh();
			lbl_eout.Refresh();
		}

		private void btn_test_Click(object sender, EventArgs e) {
			NN.Validation();
			int[][] table = NN.ValidationTable();
			for(int i=0; i<NN.Dimout; i++)
				for(int j=0; j<NN.Dimout; j++)
					dataGridView1.Rows[i].Cells[j].Value = table[i][j];
			lbl_correctness.Text = "Correctness : " + (NN.Correctness*100).ToString();
		}

		private void NeuralNetworkSystem_Load(object sender, EventArgs e) {

		}

		private void btn_ins_Click(object sender, EventArgs e) {
			NN.InsertHiddenLayer(1, (int)num_perc.Value);
			listBox1.Items.Clear();
			for(int i=0; i<NN.layer.Count; i++)
				listBox1.Items.Add(NN.layer[i]);
		}

		private void button2_Click(object sender, EventArgs e) {
			if(listBox1.SelectedIndex>0 && listBox1.SelectedIndex<NN.NumOfLayer-1)
				NN.DeleteHiddenLayer(listBox1.SelectedIndex);
			listBox1.Items.Clear();
			for(int i=0; i<NN.layer.Count; i++)
				listBox1.Items.Add(NN.layer[i]);
		}

		private void lbl_eout_Click(object sender, EventArgs e) {

		}

		private void lbl_ein_Click(object sender, EventArgs e) {

		}

		private void lbl_err01_Click(object sender, EventArgs e) {

		}

		private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {

		}

	}
}

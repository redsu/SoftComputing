using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace R04522602許泰源Ass06{
	public partial class Rename : Form{
		private string rename;
		public Rename(){
			InitializeComponent();
			rename = "";
		}
		//send the rename back to Main.cs
		private void ent_btn_Click(object sender, EventArgs e){
			if(name_box.Text != ""){
				rename = name_box.Text;
				this.Close();
			}
		}

		public string GetMsg(){
            //return rename
            return rename;
        }
	}
}

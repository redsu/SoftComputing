using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace R04522602許泰源Ass05
{
    public partial class save_win : Form
    {
        public save_win(){
            InitializeComponent();
        }

        private string msg = "";
        
        private void save_dia_btn_Click(object sender, EventArgs e){
            //Read filename from the textbox "file_name_bx".
            msg = file_name_bx.Text;
            //Check the filename if it is empty
            if(msg == ""){
                MessageBox.Show("Please enter the filename.", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //Check the filename if it is exist.
            //If the filename is exist, require the user to rename it.
            else if(System.IO.File.Exists(msg+".wmf")){
                MessageBox.Show("The file "+msg+".wmf"+" is exist.\nPlease change another filename.", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else{
                this.Close();
            }
        }
        
        public string GetMsg(){
            //return filename with filename extension.
            return msg+".wmf";
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData){
            //Detect keypressed events. If ESC was pressed, terminate the application.
            if (keyData == Keys.Escape) {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}

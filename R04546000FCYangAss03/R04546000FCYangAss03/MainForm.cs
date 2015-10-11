using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace R04546000FCYangAss03
{
    public partial class MainForm : Form
    {
       
        public MainForm()
        {
            InitializeComponent();
             
        }

        private void btnCreateUniverse_Click(object sender, EventArgs e)
        {
            Universe u = new Universe(chart1);
            TreeNode tn = new TreeNode( u.name );
            tn.Tag = u;

            tree.Nodes.Add(tn);
        }

        private void btnCreateFuzzySet_Click(object sender, EventArgs e)
        {
            FuzzySet fs = null;
            Universe u;
            u = (Universe) tree.SelectedNode.Tag;
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    fs = new GaussianFuzzySet(u);
                    break;
            }

            TreeNode tn = new TreeNode(fs.name);
            tn.Tag = fs;
            tree.SelectedNode.Nodes.Add(tn);
        }

        private void tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (tree.SelectedNode.Parent == null) btnCreateFuzzySet.Enabled = true;
            else btnCreateFuzzySet.Enabled = false;
        }
    }
}

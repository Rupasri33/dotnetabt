using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace gd
{
    public partial class addfile : DevComponents.DotNetBar.Office2007RibbonForm
    {
        public addfile()
        {
            InitializeComponent();
        }

        private void addfile_Load(object sender, EventArgs e)
        {
            
            textBoxName.Select();
            comboBoxType.SelectedIndex = 0;
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text == "")
                MessageBox.Show("Enter file name!");
            else
            {
                Close();
            }
          

            
           
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace gd
{
    public partial class AddFile1 : Telerik.WinControls.UI.RadForm
    {
        public AddFile1()
        {
            InitializeComponent();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
                MessageBox.Show("Enter file name!");
            else
            {
                Close();
            }
          
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddFile1_Load(object sender, EventArgs e)
        {
            txtName.Select();
            cboType.SelectedIndex = 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ung
{
    public partial class _frmNewFile : DevComponents.DotNetBar.Office2007RibbonForm
    {
        public _frmNewFile()
        {
            InitializeComponent();
        }

        private void _frmNewFile_Load(object sender, EventArgs e)
        {
            textBoxName.Select();
            comboBoxType.SelectedIndex = 0;
        }

        private void _btAdd_Click_1(object sender, EventArgs e)
        {

            if (textBoxName.Text == "")
                MessageBox.Show("Enter folder name!");
            else
            {
                Close();
            }
        }

        private void _btCancal_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

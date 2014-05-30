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
    public partial class _frmNewFile : Telerik.WinControls.UI.RadForm
    {
        public _frmNewFile()
        {
            InitializeComponent();
        }

        private void _frmNewFile_Load(object sender, EventArgs e)
        {
            //textBoxName.Select();
            comboBoxType.SelectedIndex = 1;
        }

        private void _btAdd_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text == "")
                MessageBox.Show("Enter folder name!");
            else
            {
                Close();
            }
        }

        private void _btCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

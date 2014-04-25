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
    public partial class frmRun : DevComponents.DotNetBar.Office2007RibbonForm
    {
        public frmRun()
        {
            InitializeComponent();
        }

        private void frmRun_Load(object sender, EventArgs e)
        {
            //frmMain main = new frmMain();
            //_txtScript.Text = main._treeViewProjectExplore.SelectedNode.Text;
            _cboBrowser.SelectedIndex = 0;
        }

        private void _btRun_Click(object sender, EventArgs e)
        {
            //abt.Automation at = new abt.Automation();
            //seleniumabt.SeleniumActionManager aM = new seleniumabt.SeleniumActionManager();
            //aM.RegisterAction(new seleniumabt.ActionClick());

            //at.Scripts = "";
            //at.Run();
        }

        private void _btCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

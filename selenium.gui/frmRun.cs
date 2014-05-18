using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using selenium_auto;
using selenium_auto.auto;

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
            //IAutomation at = new Automation(new ExcelFileParser());
            //SeleniumActionManager am = new SeleniumActionManager(at);

            //Script startScript = new Script(at.Parser.NewInstance);
            //startScript.FileName = "test.xls";

            //at.Scripts.Push(startScript);
            //at.Start();
           
        }

        private void _btCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

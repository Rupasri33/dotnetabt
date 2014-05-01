using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using abt;
using seleniumabt;

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
            Automation at = new Automation(new ExcelFileParser());
            SeleniumActionManager am = new SeleniumActionManager(at);
            am.RegisterAction(new seleniumabt.ActionClick());

            Script startScript = new Script(at.Parser.NewInstance);
            startScript.FileName = "test.xls";

            at.Scripts.Push(startScript);
            at.Run();
           
        }

        private void _btCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

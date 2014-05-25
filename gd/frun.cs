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
using codeduiabt;

namespace gd
{
    public partial class frun : DevComponents.DotNetBar.Office2007RibbonForm
    {
        public frun()
        {
            InitializeComponent();
        }

        
        private void _btRun_Click(object sender, EventArgs e)
        {
            //Automation at = new Automation(new ExcelFileParser());
            //SeleniumActionManager am = new SeleniumActionManager(at);
            //am.RegisterAction(new seleniumabt.ActionClick());

            //Script startScript = new Script(at.Parser.NewInstance);
            //startScript.FileName = "test.xls";

            //at.Scripts.Push(startScript);
            //at.Run();

        }

       

        private void _btCancel_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}

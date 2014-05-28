using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//using abt;
//using codeduiabt;
using abt.model;
using abt.auto;
using uia_auto.auto;

namespace gd
{
    public partial class frun : DevComponents.DotNetBar.Office2007RibbonForm
    {
        public frun()
        {
            InitializeComponent();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            Close();
           
            IAutomation at = new Automation(new ExcelFileParser(), new ExcelReporter(new ExcelFileParser()),
                @"E:\demo_new\dotnetabt\codeduiabt\sample");
            UIAActionManager am = new UIAActionManager(at);

            Script startScript = new Script(at.Parser.NewInstance);
            startScript.FileName = _txtScript.Text;

            at.Speed = 10;
            at.StartScript = startScript;
            at.Start();
        }

        

        
       
       

       
    }
}

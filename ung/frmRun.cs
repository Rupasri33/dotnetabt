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
    public partial class frmRun : Telerik.WinControls.UI.RadForm
    {
        public frmRun()
        {
            InitializeComponent();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btRun_Click(object sender, EventArgs e)
        {
            //Automation at = new Automation(new ExcelFileParser());
            //SeleniumActionManager am = new SeleniumActionManager(at);
            //am.RegisterAction(new seleniumabt.ActionClick());

            //Script startScript = new Script(at.Parser.NewInstance);
            //startScript.FileName = "test.xls";

            //at.Scripts.Push(startScript);
            //at.Run();

            Automation at = new Automation(new ExcelFileParser(), new ExcelReporter(), @"D:\VAIO\dotnetabt\seleniumabt\sample");

            if (radRadioChrome.IsChecked)
            {
                SeleniumActionManager am = new SeleniumActionManager(at, SeleniumActionManager.Browser.Chrome);
            }
            else if (radRadioFireFox.IsChecked)
            {
                SeleniumActionManager am = new SeleniumActionManager(at, SeleniumActionManager.Browser.FireFox);
            }
            else if (radRadioIE.IsChecked)
            {
                SeleniumActionManager am = new SeleniumActionManager(at, SeleniumActionManager.Browser.IE);
            }

            Script startScript = new Script(at.Parser.NewInstance);
            startScript.FileName = _txtScript.Text;

            at.Scripts.Push(startScript);
            at.Start();
            this.DialogResult = System.Windows.Forms.DialogResult.No;
            this.Close();
        }

        private void frmRun_Load(object sender, EventArgs e)
        {
            _cboData.SelectedIndex = 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using uia_auto.auto;
using abt.model;
using abt.auto;

namespace uia_gui.forms
{
    public partial class FormViewer : Form
    {
        public FormViewer()
        {
            InitializeComponent();

            //iff.FileName

            IAutomation automation = new Automation(new ExcelFileParser(), new ExcelReporter(), @"D:\codes\dotnetabt\codeduiabt\sample");
            UIAActionManager actionManager = new UIAActionManager(automation);
            IInterface iff = new Interface(automation.Parser.NewInstance);
            iff.FileName = "Calculator.xls";

            //windowsViewer1.ActionManager = actionManager;
            //windowsViewer1.CurrentInterface = iff;
        }

        private void FormViewer_Load(object sender, EventArgs e)
        {
            windowsViewer1.RefreshWindows();
            windowsViewer1.RefreshWindows();
        }

        private void windowsViewer1_SelectedItemChanged(TestStack.White.UIItems.UIItem item)
        {
            try
            {
                propertiesViewer1.Object = item;
            }
            catch (Exception)
            {
                MessageBox.Show(@"The selected item is not exist anymore. Press OK to refresh", @"Automation", MessageBoxButtons.OK);
                windowsViewer1.RefreshWindows();
            }
        }

        private void propertiesViewer1_InvalidItemSelected()
        {
            MessageBox.Show(@"The selected item is not exist anymore. Press OK to refresh", @"Automation", MessageBoxButtons.OK);
            windowsViewer1.RefreshWindows();
        }
    }
}

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
        Dictionary<string, TestStack.White.UIItems.IUIItem> matchedControls;

        public FormViewer()
        {
            InitializeComponent();

            IAutomation automation = new Automation(new ExcelFileParser(), new ExcelReporter(new ExcelFileParser()),
                @"E:\demo_new\dotnetabt\codeduiabt\sample");
            UIAActionManager actionManager = new UIAActionManager(automation);
            actionManager.WaitTime = new TimeSpan(0, 0, 1);

            IInterface iff = new Interface(automation.Parser.NewInstance);
            iff.FileName = "Calculator.xls";

            windowsViewer1.ActionManager = actionManager;
            windowsViewer1.CurrentInterface = iff;
            windowsViewer1.WindowsRefreshed += windowsViewer1_WindowsRefreshed;
            propertiesViewer1.CurrentInterface = iff;
        }

        void windowsViewer1_WindowsRefreshed(Dictionary<string, TestStack.White.UIItems.IUIItem> matchedControls)
        {
            this.matchedControls = matchedControls;
            matchesViewer1.MatchedControls = matchedControls;
        }

        private void FormViewer_Load(object sender, EventArgs e)
        {
            windowsViewer1.RefreshWindows();
        }

        private void windowsViewer1_SelectedItemChanged(TestStack.White.UIItems.IUIItem item, string controlName)
        {
            propertiesViewer1.CurrentName = controlName;
            propertiesViewer1.Object = item;
        }

        private void propertiesViewer1_InvalidItemSelected()
        {
            MessageBox.Show(@"The selected item is not exist anymore. Press OK to refresh", @"Automation", MessageBoxButtons.OK);
            matchesViewer1.Reset();
            propertiesViewer1.Reset();
            windowsViewer1.RefreshWindows();
        }

        private void toolstripBtnRefresh_Click(object sender, EventArgs e)
        {
            matchesViewer1.Reset();
            propertiesViewer1.Reset();
            windowsViewer1.RefreshWindows();
        }

        private void matchesViewer1_ControlSelected(string name)
        {
            windowsViewer1.SelectControlByName(name);
        }
    }
}

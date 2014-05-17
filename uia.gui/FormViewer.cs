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
using uia_auto.model;
using uia_auto.file_parser;

namespace uia_gui.forms
{
    public partial class FormViewer : Form
    {
        public FormViewer()
        {
            InitializeComponent();

            //iff.FileName

            IAutomation automation = new UIAAutomation(new ExcelFileParser(), new ExcelReporter(), @"D:\codes\dotnetabt\codeduiabt\sample");
            UIAActionManager actionManager = new UIAActionManager(automation);
            IInterface iff = new Interface(automation.Parser.NewInstance);
            iff.FileName = "Calculator.xls";

            windowsViewer1.ActionManager = actionManager;
            windowsViewer1.CurrentInterface = iff;
        }

        private void FormViewer_Load(object sender, EventArgs e)
        {
            windowsViewer1.RefreshWindows();

        }

        private void windowsViewer1_SelectedItemChanged(TestStack.White.UIItems.UIItem item)
        {
            propertiesViewer1.Object = item;
        }
    }
}

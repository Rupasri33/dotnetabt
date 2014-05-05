using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.Finders;

using abt;
using codeduiabt;

namespace gd
{
    public partial class WindowsViewer : UserControl
    {
        public WindowsViewer()
        {
            InitializeComponent();

            ShowWindow();
        }

        public Interface CurrentInterface { get; set; }

        private void ShowWindow()
        {
            List<Window> windows = WindowFactory.Desktop.DesktopWindows();
            System.Diagnostics.ProcessStartInfo si = new System.Diagnostics.ProcessStartInfo();
            si.FileName = @"C:\Windows\explorer.exe";
            TestStack.White.Application app = TestStack.White.Application.AttachOrLaunch(si);
            List<Window> wins = app.GetWindows();

            foreach (Window window in windows)
            {
                if (window.IsOffScreen || !window.Visible || window.Name.Length == 0)
                    continue;

                if (window.Title == @"Program Manager" && window.AutomationElement.Current.ProcessId == app.Process.Id)
                    continue;

                TreeNode node = treeView.Nodes.Add(window.Name);
                node.Tag = window;
                node.Nodes.Add("Scanning...");
            }
        }

        private void ShowControl(TreeNode node)
        {
            Window window = node.Tag as Window;
            //window.Get<Window>
            //window.
            foreach (UIItem item in window.Items)
            {
                node.Nodes.Add(item.Name);
            }
        }
    }
}

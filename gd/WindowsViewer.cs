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

            foreach (Window window in windows)
            {
                if (window.IsOffScreen || !window.Visible || window.Title.Length == 0)
                    continue;

                treeView.Nodes.Add(window.Title);
            }
        }

        private void ShowControl(Window window)
        {
        }
    }
}

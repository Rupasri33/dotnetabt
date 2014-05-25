using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Automation;
using System.Diagnostics;
using System.Data;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
//using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace gd
{
    /// <summary>
    /// Interaction logic for Spy.xaml
    /// </summary>
    public partial class Spy : DevComponents.DotNetBar.Office2007RibbonForm
    {
        public Spy()
        {
            InitializeComponent();
            TreeViewItem treeItem = new TreeViewItem();
            List<TreeViewItem> newtree = new List<TreeViewItem>();
            UIView viewCondition;
            AutomationElement root;
            trvTree.Nodes.Clear();
            //------------------------------------

            //------------------------------------
            StringBuilder sb = new StringBuilder();
            int tam = 0;
            foreach (Process p in Process.GetProcesses("."))
            {
                try
                {
                    tam++;
                    if (p.MainWindowTitle.Length > 0)
                    {
                        IntPtr a = p.MainWindowHandle;
                        root = Findelementhandle(a);
                        TreeViewItem newa = new TreeViewItem();
                        if (root == null)
                        {
                            throw new NullReferenceException("Element not found");
                        }

                        viewCondition = UIView.Content;
                        WalkControlElements(root, ref newa, viewCondition);
                        newa.Header = root.Current.Name;
                        newa.Tag = root;
                        //trvTree.Items.Add(newa);
                        //trvTree.SelectedItemChanged += trvTree_SelectedItemChanged;
                        //datagridviewprob.SelectedCellsChanged += datagridviewprob_SelectedCellsChanged;

                    }

                }

                catch (Exception e)
                {
                    MessageBox.Show("" + e);
                }
            }
        }


        void datagridviewprob_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {

            var grid = sender as DataGrid;
            var selected = grid.SelectedItems;

            foreach (var item in selected)
            {
                int so = selected.Count;
                var Spy = item as SpyView;
                string giatri = Spy.Check.ToString();
                string fale = "False";
                if (string.Compare(giatri, fale) != 0)
                {
                    //textboxprop.Text += Spy.Name + Spy.Property.ToString() + "\n";
                }

            }



        }


        public class SpyView
        {
            public string Name { get; set; }
            public string Property { get; set; }
            public bool Check { get; set; }
        }


        void trvTree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {

            try
            {
                var tree = sender as TreeView;
                TreeViewItem tvi = tree.SelectedItem as TreeViewItem;
                AutomationElement focus = tvi.Tag as AutomationElement;


                //-----------------------------------------------------------
                var items = new List<SpyView>();
                items.Add(new SpyView()
                {
                    Name = "Name Forcus: ",
                    Property = focus.Current.Name,
                    Check = false

                });
                items.Add(new SpyView()
                {
                    Name = "Class Name: ",
                    Property = focus.Current.ClassName,
                    Check = false

                });
                items.Add(new SpyView()
                {
                    Name = "Processing ID: ",
                    Property = focus.Current.ProcessId.ToString(),
                    Check = false

                });
                items.Add(new SpyView()
                {
                    Name = "Control Type: ",
                    Property = focus.Current.ControlType.ToString(),
                    Check = false

                });

                items.Add(new SpyView()
                {
                    Name = "Automation ID: ",
                    Property = focus.Current.AutomationId,
                    Check = false

                });

                items.Add(new SpyView()
                {
                    Name = "NativeWindowHandle: ",
                    Property = focus.Current.NativeWindowHandle.ToString(),
                    Check = false

                });

                //datagridviewprob.ItemsSource = items;


            }


            catch (Exception error)
            {
                MessageBox.Show("The Element Have Remove Or With Error: " + error);
            }
        }


        public enum UIView
        {

            Content
        }



        private void WalkControlElements(AutomationElement rootElement, ref TreeViewItem treeNode, UIView viewCondition)
        {
            TreeWalker viewWalker = null;

            viewWalker = TreeWalker.ContentViewWalker;

            AutomationElement elementNode = viewWalker.GetFirstChild(rootElement);

            while (elementNode != null)
            {
                TreeViewItem temp = new TreeViewItem();
                string strTemp = "  " + elementNode.Current.ControlType.LocalizedControlType + " :  " + elementNode.Current.Name;
                Debug.WriteLine(strTemp);
                temp.Header = strTemp;
                TreeViewItem childTreeNode = temp;
                treeNode.Items.Add(temp);
                childTreeNode.Tag = elementNode;
                WalkControlElements(elementNode, ref childTreeNode, viewCondition);
                elementNode = viewWalker.GetNextSibling(elementNode);
            }
        }

        public AutomationElement FindWindowByTitle(string title)
        {
            AutomationElement returnLE = null;
            PropertyCondition conds = new PropertyCondition(AutomationElement.NameProperty, title);
            returnLE = AutomationElement.RootElement.FindFirst(TreeScope.Children, conds);
            return returnLE;
        }

        public AutomationElement FindElementByProcessId(int pid)
        {
            AutomationElement element = null;
            PropertyCondition conds = new PropertyCondition(AutomationElement.ProcessIdProperty, pid);
            while (element == null)
                element = AutomationElement.RootElement.FindFirst(TreeScope.Children, conds);
            return element;
        }

        public AutomationElement Findelementhandle(IntPtr a)
        {
            AutomationElement element = null;
            element = AutomationElement.FromHandle(a);
            return element;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

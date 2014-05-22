using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using Telerik;
using System.Drawing;

namespace AUI_Test
{
    public class DirectoryTreeview  : TreeView
    {


        public string path = @".\";

        public string PathTree
        {
            get
            {
                return path;
            }
            set
            {
                path = value;
            }
        }

        public DirectoryTreeview()
        {
            Nodes.Clear();
            string drives = Path.Combine(Environment.CurrentDirectory, PathTree);
            string RootNameDirection = "Root";
            TreeNode node = new TreeNode();
            node.Text = RootNameDirection;
            Nodes.Add(node);
            FillDirectory(drives, node, 0);


            
            

            
            //----------------------------------------------------------
        }

        // chạy lại một lần nữa khi mình tạo new với đường dẫn mới.
        public void Runother()
        {
            Nodes.Clear();
            string drives = Path.Combine(Environment.CurrentDirectory, PathTree);
            string RootNameDirection = "Root";
            TreeNode node = new TreeNode();
            node.Text = RootNameDirection;
            Nodes.Add(node);
            FillDirectory(drives, node, 0);


            
        }

        public void FillDirectory(string drv, TreeNode parent, int level)
        {
            try
            {

                level++;
                if (level > 4)
                    return;
                DirectoryInfo dir = new DirectoryInfo(drv);
                if (!dir.Exists)
                    throw new DirectoryNotFoundException
                        ("directory does not exist:" + drv);
                this.AfterSelect += new TreeViewEventHandler(this.TreeAfterSelect);
                this.NodeMouseClick += new TreeNodeMouseClickEventHandler(this.rightclick);
                foreach (DirectoryInfo di in dir.GetDirectories())
                {
                    TreeNode child = new TreeNode();
                    child.Text = di.Name;
                    parent.Nodes.Add(child);
                    foreach (FileInfo fi in di.GetFiles())
                    {
                        child.Nodes.Add(fi.Name);
                    }

                    FillDirectory(child.FullPath, child, level);

                }
            }

            catch (Exception ex)
            {
                ex.ToString();
            }

        }



        // Mình sẽ sử lý sự kiện sau khi select node

        private void TreeAfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (e.Action == TreeViewAction.ByMouse)
                {

                    string duongdan = e.Node.FullPath;
                    if (duongdan.Contains("Root"))
                    {
                        string da = duongdan.Remove(0, 5);
                        da = "\\" + da;
                        string FPath = PathTree + da;




                    }

                }


            }

            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }

        }
        //-----------------------

        private void rightclick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {

                if (e.Button == MouseButtons.Right)
                {
                }
            }
            catch
            {
            }
        }







    }
}

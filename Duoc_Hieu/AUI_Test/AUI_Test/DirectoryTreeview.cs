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
using Excel = Microsoft.Office.Interop.Excel;

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


        //---- Tao Mot Context menu
       
        public myContextMenuStrip myMenu;


        public DirectoryTreeview()
        {
            Nodes.Clear();
            string drives = Path.Combine(Environment.CurrentDirectory, PathTree);
            string RootNameDirection = "Root";
            TreeNode node = new TreeNode();
            node.Text = RootNameDirection;
            Nodes.Add(node);
            FillDirectory(drives, node, 0);

            System.Windows.Forms.ImageList myImageList = new System.Windows.Forms.ImageList();
            myImageList.Images.Add(Properties.Resources.iconsubtree);
            myImageList.Images.Add(Properties.Resources.icontree);


            // Assign the ImageList to the TreeView.
            ImageList = myImageList;

            // Set the TreeView control's default image and selected image indexes.
            ImageIndex = 0;
            SelectedImageIndex = 1;

            
            
            //---------Dua Con Text Menu Vao -----------------------------------
            myMenu = new myContextMenuStrip();
            ToolStripMenuItem ADD = new ToolStripMenuItem("Add");
            ADD.Image = Properties.Resources.Add;
            ToolStripMenuItem Del = new ToolStripMenuItem("Delete");
            Del.Image = Properties.Resources.delete;
            ToolStripMenuItem Open = new ToolStripMenuItem("Open");
            Open.Image = Properties.Resources.openfile;
            myMenu.Items.AddRange(new ToolStripItem[] { Open, ADD, Del });          
            ContextMenuStrip = myMenu;
            

            
           
        }

        // chạy lại một lần nữa khi mình tạo new với đường dẫn mới.
        public void Runother()
        {
            Nodes.Clear();
            string drives = Path.Combine(Environment.CurrentDirectory, path);
            string RootNameDirection = "Root";
            TreeNode node = new TreeNode();
            node.Text = RootNameDirection;
            Nodes.Add(node);
            FillDirectory(drives, node, 0);

            System.Windows.Forms.ImageList myImageList = new System.Windows.Forms.ImageList();
            myImageList.Images.Add(Properties.Resources.iconsubtree);
            myImageList.Images.Add(Properties.Resources.icontree);


            // Assign the ImageList to the TreeView.
            ImageList = myImageList;

            // Set the TreeView control's default image and selected image indexes.
            ImageIndex = 0;
            SelectedImageIndex = 1;


            //---------Dua Con Text Menu Vao -----------------------------------
            myMenu = new myContextMenuStrip();
            ToolStripMenuItem ADD = new ToolStripMenuItem("Add");
            ADD.Image = Properties.Resources.Add;
            ToolStripMenuItem Del = new ToolStripMenuItem("Delete");
            Del.Image = Properties.Resources.delete;
            myMenu.Items.AddRange(new ToolStripItem[] { ADD, Del });
            ContextMenuStrip = myMenu;
            
        }

        private void SetDisplayRed(object sender, EventArgs e)
        {
            throw new NotImplementedException();
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
                //this.AfterSelect += new TreeViewEventHandler(this.TreeAfterSelect);
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



        private void rightclick(object sender, TreeNodeMouseClickEventArgs e)
        {
           
            if (e.Button == MouseButtons.Right)
            {
               
                             
                    TreeNode tn = GetNodeAt(e.Location);
                    myMenu.tn = tn;
                
            }
        }



        public class myContextMenuStrip : ContextMenuStrip
        {
            public TreeNode tn;

            public myContextMenuStrip()
            {
                
            }

            protected override void OnItemClicked(ToolStripItemClickedEventArgs e)
            {
                base.OnItemClicked(e);
                
                if (e.ClickedItem.Text == "Add")
                {
                    
                    MessageBox.Show("Thanh Cong");
                }
                if (e.ClickedItem.Text == "Delete")
                {
                    MessageBox.Show("Del Thanh Cong");
                }
            }
        }


        public class ContextMenuStripnew : ContextMenuStrip
        {
            public TreeNode tn;

            public ContextMenuStripnew()
            {

            }

            protected override void OnItemClicked(ToolStripItemClickedEventArgs e)
            {
                base.OnItemClicked(e);

                if (e.ClickedItem.Text == "Add")
                {

                    MessageBox.Show("Thanh Cong");
                }
               
            }
        }

        // Mình sẽ sử lý sự kiện sau khi select node

        //private void TreeAfterSelect(object sender, TreeViewEventArgs e)
        //{
        //    try
        //    {

        //        //if (e.Action == TreeViewAction.ByMouse)
        //        //{

        //        //    string duongdan = e.Node.FullPath;
        //        //    if (duongdan.Contains("Root"))
        //        //    {
        //        //        string da = duongdan.Remove(0, 5);
        //        //        da = "\\" + da;
        //        //        string FPath = PathTree + da;


        //       if (SelectedNode.Text == Nodes[0].Nodes[0].Text)
        //        {
        //            //addFileToolStripMenuItem.Visible = true;
                   
        //        }
        //        else if (SelectedNode.Text ==Nodes[0].Nodes[1].Text)
        //        {
        //           // addFileToolStripMenuItem.Visible = true;
                    
        //        }
        //        else if (SelectedNode.Text == Nodes[0].Nodes[2].Text)
        //        {
        //            //addFileToolStripMenuItem.Visible = true;
                   
        //        }

        //        else if (SelectedNode.Text == Nodes[0].Nodes[0].Nodes[0].Text)
        //        {
                    
        //           // deleteToolStripMenuItem.Visible = true;
                   
        //        }
        //        else if (SelectedNode.Text == Nodes[0].Nodes[1].Nodes[0].Text)
        //        {
                    
        //           // deleteToolStripMenuItem.Visible = true;
                    
        //        }
        //        else if (SelectedNode.Text == Nodes[0].Nodes[2].Nodes[0].Text)
        //        {
        //           // deleteToolStripMenuItem.Visible = true;
        //            //runToolStripMenuItem1.Visible = true;
        //         //  runToolStripMenuItem.Enabled = true;
        //        }


        //    }

        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("" + ex);
        //    }

        //}
        
        
       



    }
}

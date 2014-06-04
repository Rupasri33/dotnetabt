using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using WeifenLuo.WinFormsUI.Docking;
using DevComponents.DotNetBar;

using System.Diagnostics;
using System.Windows;
using System.IO;
using System.Runtime.InteropServices;
//-------------------------------------------
using QiHe.CodeLib;
using ExcelLibrary.CompoundDocumentFormat;
using ExcelLibrary.BinaryDrawingFormat;
using ExcelLibrary.BinaryFileFormat;
using ExcelLibrary.SpreadSheet;
using System.Data.Odbc;
using Office_12 = Microsoft.Office.Core;
using Excel_12 = Microsoft.Office.Interop.Excel;
//-------------------------------------------
using White.Core.Factory;
using White.Core.UIItems.Finders;
using White.Core.InputDevices;
using System.Threading;

//--------------------------------------------------
using System.Windows.Automation;
using System.Windows.Controls;
using UITimer = System.Windows.Forms.Timer;
using System.Management;
using con = System.Windows.Condition;
using Excel = Microsoft.Office.Interop.Excel;
using gd;
using uia_auto.auto;
using abt.model;
using abt.auto;
using uia_gui.forms;
//using Automation_Test; 


//using System.Management;


namespace gd
{
    public partial class main : DevComponents.DotNetBar.Office2007RibbonForm
    {
        public main()
        {
            InitializeComponent();
        }
        CompoundDocument doc;
        White.Core.Application _application;
        White.Core.UIItems.WindowItems.Window _mainWindow;
        DataGridView dgvCells;
        StatusStrip status;
        private string filepath;
        
        public string CurrentProjectPath {get; set;}
        class FolderTreeNode : TreeNode { }
        class FileTreeNode : TreeNode { }

        private void dgvCells_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.KeyCode == Keys.I && e.Control)
            {
                DataGridView dataView=sender as DataGridView;
                if (dataView.SelectedCells.Count == 1)
                {
                    int curRow = dataView.SelectedCells[0].RowIndex;
                    dataView.Rows.Insert(curRow, 1);
                }
            }
        }

        private void main_Load(object sender, EventArgs e)
        {
            
            StatusStrip status = new StatusStrip();
            ToolStripStatusLabel lb = new ToolStripStatusLabel();
            
            lb.Text = "Ready";
            status.Items.Add(lb);
            Controls.Add(status);
        }

        /////////// xu li nut new
        private void buttonItem2_Click(object sender, EventArgs e)
        {
            treeViewproject.Nodes.Clear();
            tabControl1.TabPages.Clear();
            NewProject n = new NewProject();
            n.ShowDialog();
            if (n.DialogResult == System.Windows.Forms.DialogResult.Yes)
            {
               CurrentProjectPath = n.ProjectPath;
                // lấy path ra ở đây... 
                TreeNode treenode;

                DirectoryInfo dir = new DirectoryInfo(CurrentProjectPath);
                if (dir.Exists)
                {
                    treenode = new TreeNode(dir.Name);
                    treenode.Tag = dir;
                    treenode.Name = "Folder";
                    treenode.ImageIndex = 1;
                    //treenode.ImageIndex = 0;
                    treenode.SelectedImageIndex = 1;
                    // GetDirectories(dir.GetDirectories(), treenode);
                    treeViewproject.Nodes.Add(treenode);

                    try
                    {
                        DirectoryInfo[] directories = dir.GetDirectories();
                        if (directories.Length > 0)
                        {
                            foreach (DirectoryInfo directory in directories)
                            {
                                TreeNode node = treenode.Nodes.Add(directory.Name);
                                node.Tag = directory.Name;
                                node.ImageIndex = node.SelectedImageIndex = 1;
                                foreach (FileInfo file in directory.GetFiles())
                                {
                                    treenode = new TreeNode(file.Name);
                                    treenode.Tag = file;
                                    treenode.Name = "File";
                                    treenode.ImageIndex = 1;
                                    treenode.SelectedImageIndex = 1;
                                    treeViewproject.Nodes.Add(treenode);

                                    if (file.Exists)
                                    {
                                        TreeNode nodes = treeViewproject.Nodes[0].Nodes[node.Index].Nodes.Add(file.Name);
                                        treenode.ImageIndex = 1;
                                        //node.ImageIndex = node.SelectedImageIndex = 0;
                                    }
                                }
                            }
                            treeViewproject.ExpandAll();
                            
                        }
                        
                     
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.Message);

                    }
                    Text =treeViewproject.Nodes[0].Text+ " - "+ "Automation";
                } 
            }
        }

        //Refresh
        private void buttonItem6_Click(object sender, EventArgs e)
        {
            LoadTreeView();
        }

        private void addNewFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddFile1 newFile = new AddFile1();

            //newFile.labelX3.Text = newFile.labelX3.Text + "-" + treeViewproject.SelectedNode.Text;
            newFile.ShowDialog();
            main main = new main();

            Excel.Application xlApp = default(Excel.Application);
            Excel.Workbook xlWorkBook = default(Excel.Workbook);
            Excel.Worksheet xlWorkSheet = default(Excel.Worksheet);

            FileTreeNode treeNode = new FileTreeNode();
            treeNode.Text = newFile.txtName.Text + "." + newFile.cboType.Text;
            treeNode.Tag = CurrentProjectPath + @"\" + treeViewproject.SelectedNode.Text + @"\" + treeNode.Text;
            treeNode.Name = "File";
            treeNode.ImageIndex = newFile.cboType.SelectedIndex;
            newFile.Close();
            if (newFile.txtName.Text != "")
            {
                treeViewproject.SelectedNode.Nodes.Add(treeNode);
                treeViewproject.SelectedNode.ExpandAll();
                //@new new1 = new @new();
                //string path = new1.ProjectPath;
                //string fName = path + @"\" + treeViewproject.SelectedNode.Tag + @"\" + treeNode.Tag;
                string fName = treeViewproject.Nodes[0].Tag + @"\" + treeViewproject.SelectedNode.Text + @"\" + treeNode.Text;
                 //const string fName =@"F:\abc.xls";
                try
                {
                    object misValue = System.Reflection.Missing.Value;
                    xlApp = new Excel.Application();
                    xlWorkBook = xlApp.Workbooks.Add(misValue);
                    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                    xlWorkBook.SaveAs(fName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                    xlWorkBook.Close(true, misValue, misValue);
                    xlApp.Quit();
                    releaseObject(xlWorkSheet);
                    releaseObject(xlWorkBook);
                    releaseObject(xlApp);
                }
                finally
                {
                    if (xlApp != null)
                        releaseObject(xlApp);
                    if (xlWorkBook != null)
                        releaseObject(xlWorkBook);
                    if (xlWorkSheet != null)
                        releaseObject(xlWorkSheet);
                }
                //if (System.IO.File.Exists(fName))
                //{
                //    //if (System.Windows.Forms.MessageBox.Show("Would you like to open the excel file?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                //    //{
                //        //try
                //        //{
                //        //    System.Diagnostics.Process.Start(fName);
                //        //}
                //        //catch (Exception ex)
                //        //{
                //        //    System.Windows.Forms.MessageBox.Show("Error opening the excel file." + Environment.NewLine +
                //        //      ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //        //}
                //    //}
                //}

                
                
               
               //CompoundDocument _doc = CompoundDocument.Open(fName);
            }

        }

        private void releaseObject(object obj)
        {
            if (obj == null)
                throw new ArgumentNullException("obj");
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
            }
            catch { }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeViewproject.SelectedNode.Remove();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
           
            if (treeViewproject.SelectedNode.Tag == treeViewproject.Nodes[0].Tag)
            {
                addNewFileToolStripMenuItem.Enabled = false;
                deleteToolStripMenuItem.Enabled = false;
                runToolStripMenuItem.Enabled = false;
                spyToolStripMenuItem.Enabled = false;
                buttonItem5.Enabled = false;
            }
            else
            {

                if (treeViewproject.SelectedNode.Tag == treeViewproject.Nodes[0].Nodes[0].Tag || treeViewproject.SelectedNode.Tag == treeViewproject.Nodes[0].Nodes[1].Tag ||  treeViewproject.SelectedNode.Tag == treeViewproject.Nodes[0].Nodes[3].Tag)
                {
                    addNewFileToolStripMenuItem.Enabled = true;
                    deleteToolStripMenuItem.Enabled = false;
                    runToolStripMenuItem.Enabled = false;
                    spyToolStripMenuItem.Enabled = false;
                    buttonItem4.Enabled = false;
                    buttonItem15.Enabled = false;
                    buttonItem5.Enabled = false;
                }

                else
                {
                    if (treeViewproject.SelectedNode.Parent == treeViewproject.Nodes[0].Nodes[3])
                    {
                        addNewFileToolStripMenuItem.Enabled = false;
                        deleteToolStripMenuItem.Enabled = true;
                        runToolStripMenuItem.Enabled = true;
                        spyToolStripMenuItem.Enabled = false;
                        buttonItem4.Enabled = false;
                        buttonItem15.Enabled = true;
                        buttonItem5.Enabled = false;
                    }
                    else
                    {
                        if (treeViewproject.SelectedNode.Parent == treeViewproject.Nodes[0].Nodes[1])
                        {
                            addNewFileToolStripMenuItem.Enabled = false;
                            deleteToolStripMenuItem.Enabled = true;
                            runToolStripMenuItem.Enabled = false;
                            spyToolStripMenuItem.Enabled = true;
                            buttonItem4.Enabled = false;
                            buttonItem5.Enabled = true;
                            buttonItem15.Enabled = false;
                        }
                        else
                        {
                            if (treeViewproject.SelectedNode.Tag == treeViewproject.Nodes[0].Nodes[2].Tag)
                            {
                                addNewFileToolStripMenuItem.Enabled = false;
                                deleteToolStripMenuItem.Enabled = false;
                                runToolStripMenuItem.Enabled = false;
                                spyToolStripMenuItem.Enabled = false;
                                buttonItem4.Enabled = false;
                                buttonItem15.Enabled = false;
                                buttonItem5.Enabled = false;
                            }
                            else
                            {
                                addNewFileToolStripMenuItem.Enabled = false;
                                deleteToolStripMenuItem.Enabled = true;
                                runToolStripMenuItem.Enabled = false;
                                spyToolStripMenuItem.Enabled = false;
                                buttonItem4.Enabled = false;
                                buttonItem15.Enabled = false;
                                buttonItem5.Enabled = false;
                            }
                        }
                    }
                }
            }
            

            ////nếu node đang chọn là file thì không cho phép tạo gì cả, chỉ cho delete thôi
                   
        }

        private string[] ConvertToStringArray(Array myvalues)
        {
            throw new NotImplementedException();
        }


        private void OpenProject()
        {
            treeViewproject.Nodes.Clear();
            tabControl1.TabPages.Clear();
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = false;
            fbd.Description = "Mời bạn chọn thư mục";
            fbd.RootFolder = Environment.SpecialFolder.MyComputer;

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                TreeNode treenode;
                CurrentProjectPath = fbd.SelectedPath;
                //string path1 = fbd.SelectedPath + treeViewproject.SelectedNode.Tag;
                //doc = CompoundDocument.Open(path);
                DirectoryInfo dir = new DirectoryInfo(CurrentProjectPath);

                if (dir.Exists)
                {
                    FolderTreeNode projectNode = new FolderTreeNode();
                    projectNode.Text = dir.Name;
                    projectNode.Tag = dir;
                    //projectNode.Name = "Folder";
                    //treenode.ImageIndex = 0;
                    projectNode.ImageIndex = 1;
                    projectNode.SelectedImageIndex = 1;
                    // GetDirectories(dir.GetDirectories(), treenode);
                    treeViewproject.Nodes.Add(projectNode);

                    try
                    {
                        DirectoryInfo[] directories = dir.GetDirectories();
                        if (directories.Length > 0)
                        {
                            foreach (DirectoryInfo directory in directories)
                            {
                                FolderTreeNode folderNode =new FolderTreeNode();
                                folderNode.Text = directory.Name;
                                folderNode.Tag = directory.Name;
                                projectNode.Nodes.Add(folderNode);
                                folderNode.ImageIndex = folderNode.SelectedImageIndex = 1;
                                foreach (FileInfo file in directory.GetFiles())
                                {
                                    

                                    if (file.Exists)
                                    {
                                        FileTreeNode fileNode = new FileTreeNode();
                                        fileNode.Text = file.Name;
                                        fileNode.Tag = file.FullName;
                                        folderNode.Nodes.Add(fileNode);                                        
                                        fileNode.ImageIndex = fileNode.SelectedImageIndex = 0;
                                        //treenode.Name = "Folder"

                                    }

                                }

                            }
                            treeViewproject.ExpandAll();

                        }


                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.Message);

                    }
                    Text = treeViewproject.Nodes[0].Text + " - " + "Automation";
                }

            }
            
 
        }

        ///////////////////xu li nut open
        private void buttonItem3_Click(object sender, EventArgs e)
        {

            OpenProject();
        }

        class ExcelTabPage : TabPage
        {
            public ExcelTabPage(string name) : base(name) { }
            public string FileName { get; set; }
        }

        //close tab
        private void tabControl1_MouseDown_1(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < this.tabControl1.TabPages.Count; i++)
            {
                Rectangle rPage = tabControl1.GetTabRect(i);
                Rectangle closeButton = new Rectangle(rPage.Right - 10, rPage.Top + 5, 10, 10);
                if (closeButton.Contains(e.Location))
                {
                    if (System.Windows.Forms.MessageBox.Show("Close this Tab?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.tabControl1.TabPages.RemoveAt(i);
                        break;
                    }
                }
            }
        }

        private void tabControl1_DrawItem_1(object sender, DrawItemEventArgs e)
        {
            Font closefont = new Font(e.Font.FontFamily, e.Font.Size);
            Font titlefont = new Font(e.Font.FontFamily, e.Font.Size);
            e.Graphics.DrawString("X", closefont, Brushes.Red, e.Bounds.Right - 10, e.Bounds.Top + 5);
            e.Graphics.DrawString(this.tabControl1.TabPages[e.Index].Text, titlefont, Brushes.Black, e.Bounds.Left, e.Bounds.Top + 5);

        }

        private void treeViewproject_DoubleClick(object sender, EventArgs e)
        {
            FileTreeNode node = treeViewproject.SelectedNode as FileTreeNode;
            if (node != null)
            {
                LoadExcelSheets(node.Tag.ToString());
            }
           
        }

        public void LoadExcelSheets(string filepath)
        {
            CompoundDocument _doc = CompoundDocument.Open(filepath);

            byte[] bookdata = _doc.GetStreamData("Workbook"); // Doc Theo Byte
            if (bookdata == null) return;
            Workbook book = WorkbookDecoder.Decode(new MemoryStream(bookdata));


            foreach (Worksheet sheet in book.Worksheets)
            {
                ExcelTabPage sheetPage = new ExcelTabPage(sheet.Name); // Tên Sheet
                sheetPage.FileName = filepath;
                dgvCells = new DataGridView(); // Tao Moi Datagridview
                dgvCells.Dock = DockStyle.Fill;
                //dgvCells.RowCount = sheet.Cells.LastRowIndex + 1;
                //dgvCells.ColumnCount = sheet.Cells.LastColIndex + 1;
                dgvCells.RowCount = 500;
                dgvCells.ColumnCount = 500;
                dgvCells.KeyUp += dgvCells_KeyUp;

                // tranverse cells
                foreach (Pair<Pair<int, int>, Cell> cell in sheet.Cells)
                {
                    dgvCells[cell.Left.Right, cell.Left.Left].Value = cell.Right.Value;
                    if (cell.Right.Style.BackColor != Color.White)
                    {
                        dgvCells[cell.Left.Right, cell.Left.Left].Style.BackColor = cell.Right.Style.BackColor;
                    }
                }

                // tranvers rows by Index
                for (int rowIndex = sheet.Cells.FirstRowIndex; rowIndex <= sheet.Cells.LastRowIndex; rowIndex++)
                {
                    Row row = sheet.Cells.GetRow(rowIndex);
                    for (int colIndex = row.FirstColIndex; colIndex <= row.LastColIndex; colIndex++)
                    {
                        Cell cell = row.GetCell(colIndex);
                    }
                }
                // tranvers rows directly

                foreach (KeyValuePair<int, Row> row in sheet.Cells.Rows)
                {
                    foreach (KeyValuePair<int, Cell> cell in row.Value)
                    {
                    }
                }

                _doc.Close();
                sheetPage.Controls.Add(dgvCells);
                tabControl1.TabPages.Add(sheetPage);
                tabControl1.SelectedTab = sheetPage;
                
            }
        }

        //SAVE        
        private void buttonItem5_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void Save()
        {
            ExcelTabPage page = tabControl1.SelectedTab as ExcelTabPage;
            Workbook workbook = new Workbook();
            Worksheet worksheet = new Worksheet(page.Text);
            DataGridView dataView = page.Controls[0] as DataGridView;
            for (int i = 0; i < 100; i++)
                worksheet.Cells[i, 0] = new Cell(string.Empty);
            for (int i = 0; i < dataView.RowCount; i++)
            {
                for (int j = 0; j < dataView.ColumnCount; j++)
                {
                    if (dataView[j, i].Value != null)
                        worksheet.Cells[i, j] = new Cell(dataView[j, i].Value);
                }
            }
            workbook.Worksheets.Add(worksheet);
            workbook.Save(page.FileName);

        }

        //right click tabcontrol
        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.contextMenuStrip1.Show(this.tabControl1, e.Location);
            }
        }

        private void closeTabToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            

                if (System.Windows.Forms.MessageBox.Show("Close this Tab?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    tabControl1.TabPages.Remove(tabControl1.SelectedTab);
                }

            
        }

         #region tabControl1_MouseDown
         private void tabControl1_MouseDown(object sender, MouseEventArgs e)
         {
             for (int i = 0; i < this.tabControl1.TabPages.Count; i++)
             {
                 Rectangle rPage = tabControl1.GetTabRect(i);
                 Rectangle closeButton = new Rectangle(rPage.Right - 10, rPage.Top + 5, 10, 10);
                 if (closeButton.Contains(e.Location))
                 {
                     if (System.Windows.Forms.MessageBox.Show("Want to save your changes?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                     {
                         Save();
                         this.tabControl1.TabPages.RemoveAt(i);
                         break;
                     }
                     else
                     {
                         this.tabControl1.TabPages.RemoveAt(i);
                         break;
                         //else if (System.Windows.Forms.MessageBox.Show("Want to save your changes?", "Confirm", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                         //{}
                     }

                 }

             }



         }
         #endregion

        //RESUM
         private void buttonItem2_Click_1(object sender, EventArgs e)
         {
             if (CurrentAutomation != null)
             {
                 buttonItem2.Enabled = false;
                 buttonItem15.Enabled = false;
                 runToolStripMenuItem.Enabled = false;
                 buttonItem4.Enabled = true;
                 buttonItem16.Enabled = true;
                 CurrentAutomation.Resume();
             }
            
         }

         private IAutomation CurrentAutomation { get; set; }

         private void Run()
         {
                 buttonItem15.Enabled = false;
                 runToolStripMenuItem.Enabled = false;
                 buttonItem16.Enabled = true;
                 buttonItem4.Enabled = true;
                 buttonItem2.Enabled = false;
                 Run f = new Run();
                 f._txtScript.Text = treeViewproject.SelectedNode.Text;
                 TreeNode currnode = treeViewproject.Nodes[0].Nodes[0];
                 //List<DirectoryInfo> dirlist = Duyetthumuccon((String)currnode.Tag);
                 List<string> dataList = Duyetfile((String)currnode.Tag);
                 dataList.Insert(0, @"[None]");
                 f._cboData.DataSource = dataList;
                 f.CurrentProjectPath = CurrentProjectPath;
                 f.ShowDialog();
                 CurrentAutomation = f.CurrenrtAutomation;
                 CurrentAutomation.Ended += CurrentAutomation_Ended;
         }

        //XỬ LÍ NÚT RUN
         private void buttonItem15_Click(object sender, EventArgs e)
         {
             Run();
         }
        
        //LOAD CAY
        private void LoadTreeView()
         {
             treeViewproject.Nodes.Clear();
             DirectoryInfo dir = new DirectoryInfo(CurrentProjectPath);

             if (dir.Exists)
             {
                 FolderTreeNode projectNode = new FolderTreeNode();
                 projectNode.Text = dir.Name;
                 projectNode.Tag = dir;
                 //projectNode.Name = "Folder";
                 //treenode.ImageIndex = 0;
                 projectNode.ImageIndex = 1;
                 projectNode.SelectedImageIndex = 1;
                 // GetDirectories(dir.GetDirectories(), treenode);
                 treeViewproject.Nodes.Add(projectNode);

                 try
                 {
                     DirectoryInfo[] directories = dir.GetDirectories();
                     if (directories.Length > 0)
                     {
                         foreach (DirectoryInfo directory in directories)
                         {
                             FolderTreeNode folderNode = new FolderTreeNode();
                             folderNode.Text = directory.Name;
                             folderNode.Tag = directory.Name;
                             projectNode.Nodes.Add(folderNode);
                             folderNode.ImageIndex = folderNode.SelectedImageIndex = 1;
                             foreach (FileInfo file in directory.GetFiles())
                             {


                                 if (file.Exists)
                                 {
                                     FileTreeNode fileNode = new FileTreeNode();
                                     fileNode.Text = file.Name;
                                     fileNode.Tag = file.FullName;
                                     folderNode.Nodes.Add(fileNode);
                                     fileNode.ImageIndex = fileNode.SelectedImageIndex = 0;
                                     //treenode.Name = "Folder"

                                 }

                             }

                         }
                         treeViewproject.ExpandAll();

                     }


                 }
                 catch (Exception ex)
                 {
                     System.Windows.Forms.MessageBox.Show(ex.Message);

                 }
                 Text = treeViewproject.Nodes[0].Text + " - " + "Automation";
             }

         }
         void CurrentAutomation_Ended(IAutomation at)
         {
             //throw new NotImplementedException();
             if (System.Windows.Forms.MessageBox.Show("Testing Finish... ", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
             {
                 //LoadTreeView();
             }
             CurrentAutomation = null;

         }

        //RUN 
        private void runToolStripMenuItem_Click(object sender, EventArgs e)
         {
             Run();
         }

         
         List<string> Duyetfile(String path)
         {

             String aa = CurrentProjectPath + @"\" + path;
             //string aa = n.ProjectPath1;
             DirectoryInfo dirinfo = new DirectoryInfo(aa);
             FileInfo[] fileinfolist = dirinfo.GetFiles();
             List<string> ret = new List<string>();
             foreach (FileInfo f in fileinfolist)
                 ret.Add(f.Name);
             return ret;
         }

        //SPY 
        private void spyToolStripMenuItem_Click_1(object sender, EventArgs e)
         {
             FormViewer s = new FormViewer();
             s.ShowDialog();
         }

        //PAUSE
         private void buttonItem16_Click(object sender, EventArgs e)
         {
             if (CurrentAutomation != null)
             {
                 buttonItem16.Enabled = false;
                 buttonItem15.Enabled = false;
                 runToolStripMenuItem.Enabled = false;
                 buttonItem4.Enabled = true;
                 buttonItem2.Enabled = true;
                 CurrentAutomation.Pause();
             }
         }

        //STOP
         private void buttonItem4_Click(object sender, EventArgs e)
         {
             if (CurrentAutomation != null)
             {
                 buttonItem2.Enabled = false;
                 buttonItem16.Enabled = false;
                 buttonItem15.Enabled = true;
                 runToolStripMenuItem.Enabled = true;
                 buttonItem4.Enabled = false;
                 CurrentAutomation.Interupt();
                 CurrentAutomation = null;
             }
         }

         private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
         {
             LoadTreeView();
         }

         private void buttonItem5_Click_1(object sender, EventArgs e)
         {
             FormViewer s = new FormViewer();
             s.ShowDialog();
         }

        //Refresh
        private void Refresh_Click(object sender, EventArgs e)
        {
            LoadTreeView();
        }
        //XU LI EXIT         
        private void Exit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

       
         
         
    } 
}

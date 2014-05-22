
#region Thu Vien
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using QiHe.CodeLib;
using ExcelLibrary.CompoundDocumentFormat;
using ExcelLibrary.BinaryDrawingFormat;
using ExcelLibrary.BinaryFileFormat;
using ExcelLibrary.SpreadSheet;
using Excel = Microsoft.Office.Interop.Excel;
#endregion

namespace ung
{
    public partial class frmMain : DevComponents.DotNetBar.Office2007RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            
        }

        #region Tao New Project
        private void projectToolStripNewProject_Click(object sender, EventArgs e)
        {
            _treeViewProjectExplore.Nodes.Clear();
            tabControl1.TabPages.Clear();
            _frmNewProject newpj = new _frmNewProject();
            newpj.ShowDialog();
            if (newpj.DialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                string path = newpj.ProjectPath;
                // lấy path ra ở đây... 
                TreeNode treenode;

                DirectoryInfo dir = new DirectoryInfo(path);
                if (dir.Exists)
                {
                    treenode = new TreeNode(dir.Name);
                    treenode.Tag = dir;
                    treenode.Name = "Folder";
                    treenode.ImageIndex = 0;
                    treenode.SelectedImageIndex = 0;
                    // GetDirectories(dir.GetDirectories(), treenode);
                    _treeViewProjectExplore.Nodes.Add(treenode);

                    try
                    {
                        DirectoryInfo[] directories = dir.GetDirectories();
                        if (directories.Length > 0)
                        {
                            foreach (DirectoryInfo directory in directories)
                            {
                                TreeNode node = treenode.Nodes.Add(directory.Name);
                                node.Tag = directory.Name;
                                node.ImageIndex = node.SelectedImageIndex = 0;
                                foreach (FileInfo file in directory.GetFiles())
                                {
                                    treenode = new TreeNode(file.Name);
                                    treenode.Tag = file;
                                    treenode.Name = "File";
                                    treenode.ImageIndex = treenode.SelectedImageIndex = 0; ;
                                    treenode.SelectedImageIndex = 0;
                                    _treeViewProjectExplore.Nodes.Add(treenode);

                                    if (file.Exists)
                                    {
                                        TreeNode nodes = _treeViewProjectExplore.Nodes[0].Nodes[node.Index].Nodes.Add(file.Name);
                                        treenode.ImageIndex = 0;
                                        node.ImageIndex = node.SelectedImageIndex = 0;
                                    }
                                }
                            }
                            _treeViewProjectExplore.ExpandAll();
                        }


                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.Message);

                    }
                }
            }
        }

        //New Project Phim Tat
        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            _treeViewProjectExplore.Nodes.Clear();
            tabControl1.TabPages.Clear();
            _frmNewProject newpj = new _frmNewProject();
            newpj.ShowDialog();
            if (newpj.DialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                string path = newpj.ProjectPath;
                // lấy path ra ở đây... 
                TreeNode treenode;

                DirectoryInfo dir = new DirectoryInfo(path);
                if (dir.Exists)
                {
                    treenode = new TreeNode(dir.Name);
                    treenode.Tag = dir;
                    treenode.Name = "Folder";
                    treenode.ImageIndex = 0;
                    treenode.SelectedImageIndex = 0;
                    // GetDirectories(dir.GetDirectories(), treenode);
                    _treeViewProjectExplore.Nodes.Add(treenode);

                    try
                    {
                        DirectoryInfo[] directories = dir.GetDirectories();
                        if (directories.Length > 0)
                        {
                            foreach (DirectoryInfo directory in directories)
                            {
                                TreeNode node = treenode.Nodes.Add(directory.Name);
                                node.Tag = directory.Name;
                                node.ImageIndex = node.SelectedImageIndex = 0;
                                foreach (FileInfo file in directory.GetFiles())
                                {
                                    treenode = new TreeNode(file.Name);
                                    treenode.Tag = file;
                                    treenode.Name = "File";
                                    treenode.ImageIndex = treenode.SelectedImageIndex = 0; ;
                                    treenode.SelectedImageIndex = 0;
                                    _treeViewProjectExplore.Nodes.Add(treenode);

                                    if (file.Exists)
                                    {
                                        TreeNode nodes = _treeViewProjectExplore.Nodes[0].Nodes[node.Index].Nodes.Add(file.Name);
                                        treenode.ImageIndex = 0;
                                        node.ImageIndex = node.SelectedImageIndex = 0;
                                    }
                                }
                            }
                            _treeViewProjectExplore.ExpandAll();
                        }


                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.Message);

                    }
                }
            }
        }
        #endregion

        #region Open Project
        private void projectToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _treeViewProjectExplore.Nodes.Clear();
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = false;
            fbd.Description = "Mời bạn chọn thư mục";
            fbd.RootFolder = Environment.SpecialFolder.MyComputer;

            if (fbd.ShowDialog() == DialogResult.OK)
            {
               
                TreeNode treenode;
                string path = fbd.SelectedPath;
                 //doc = CompoundDocument.Open(path);
                DirectoryInfo dir = new DirectoryInfo(path);

                if (dir.Exists)
                {
                    treenode = new TreeNode(dir.Name);
                    treenode.Tag = dir;
                    treenode.Name = "Folder";
                    treenode.ImageIndex =0;
                    treenode.SelectedImageIndex = 0;
                    _treeViewProjectExplore.Nodes.Add(treenode);

                    try
                    {
                        DirectoryInfo[] directories = dir.GetDirectories();
                        if (directories.Length > 0)
                        {
                            foreach (DirectoryInfo directory in directories)
                            {
                                TreeNode node = treenode.Nodes.Add(directory.Name);
                                node.Tag = directory.Name;
                                node.ImageIndex = node.SelectedImageIndex = 0;
                                foreach (FileInfo file in directory.GetFiles())
                                {
                                    //treenode = new TreeNode(file.Name);
                                    //treenode.Tag = file;
                                    //treenode.Name = "File";
                                    //treenode.ImageIndex = 0;
                                    //treenode.ImageIndex = treenode.SelectedImageIndex = 1;
                                    // _treeViewProjectExplore.Nodes.Add(treenode);
                                    if (file.Exists)
                                    {
                                        TreeNode nodes = _treeViewProjectExplore.Nodes[0].Nodes[node.Index].Nodes.Add(file.Name);
                                        treenode.ImageIndex = 0;
                                        node.ImageIndex = node.SelectedImageIndex = 0;
                                    }
                                }
                            }
                        }


                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.Message);

                    }
                }
            }    
        }

        //Open Phim Tat
        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            _treeViewProjectExplore.Nodes.Clear();
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = false;
            fbd.Description = "Mời bạn chọn thư mục";
            fbd.RootFolder = Environment.SpecialFolder.MyComputer;

            if (fbd.ShowDialog() == DialogResult.OK)
            {

                TreeNode treenode;
                string path = fbd.SelectedPath;
                //doc = CompoundDocument.Open(path);
                DirectoryInfo dir = new DirectoryInfo(path);

                if (dir.Exists)
                {
                    treenode = new TreeNode(dir.Name);
                    treenode.Tag = dir;
                    treenode.Name = "Folder";
                    treenode.ImageIndex = 0;
                    treenode.SelectedImageIndex = 0;
                    _treeViewProjectExplore.Nodes.Add(treenode);

                    try
                    {
                        DirectoryInfo[] directories = dir.GetDirectories();
                        if (directories.Length > 0)
                        {
                            foreach (DirectoryInfo directory in directories)
                            {
                                TreeNode node = treenode.Nodes.Add(directory.Name);
                                node.Tag = directory.Name;
                                node.ImageIndex = node.SelectedImageIndex = 0;
                                foreach (FileInfo file in directory.GetFiles())
                                {
                                    //treenode = new TreeNode(file.Name);
                                    //treenode.Tag = file;
                                    //treenode.Name = "File";
                                    //treenode.ImageIndex = 0;
                                    //treenode.ImageIndex = treenode.SelectedImageIndex = 1;
                                    // _treeViewProjectExplore.Nodes.Add(treenode);
                                    if (file.Exists)
                                    {
                                        TreeNode nodes = _treeViewProjectExplore.Nodes[0].Nodes[node.Index].Nodes.Add(file.Name);
                                        treenode.ImageIndex = 0;
                                        node.ImageIndex = node.SelectedImageIndex = 0;
                                    }
                                }
                            }
                        }


                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.Message);

                    }
                }
            }    
        }
        #endregion

        #region Khoi Tao & Ham LoadExxcelSheet
        //khoi tao
        CompoundDocument doc;
        //CompoundDocument doc1;
        White.Core.Application _application;
        White.Core.UIItems.WindowItems.Window _mainWindow;
        DataGridView dgvCells;
        private string filepath;

        //doc excel
        public void LoadExcelSheets()
        {
            byte[] bookdata = doc.GetStreamData("Workbook"); // Doc Theo Byte
            if (bookdata == null) return;
            Workbook book = WorkbookDecoder.Decode(new MemoryStream(bookdata));


            foreach (Worksheet sheet in book.Worksheets)
            {
                TabPage sheetPage = new TabPage(sheet.Name); // Tên Sheet
                dgvCells = new DataGridView(); // Tao Moi Datagridview
                dgvCells.Dock = DockStyle.Fill;
                //dgvCells.RowCount = sheet.Cells.LastRowIndex + 1;
                //dgvCells.ColumnCount = sheet.Cells.LastColIndex + 1;
                dgvCells.RowCount = 500;
                dgvCells.ColumnCount = 500;

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

                sheetPage.Controls.Add(dgvCells);
                tabControl1.TabPages.Add(sheetPage);
            }
        }
        #endregion
        
        #region Button Save
        Workbook workbook;
        private void _btSave_Click(object sender, EventArgs e)
        {
            if (doc == null) return;
            string file = FileSelector.BrowseFileForSave(FileType.All);   
            if (file == null) return;

            using (CompoundDocument newDoc = CompoundDocument.Create(file))
            {
                foreach (string streamName in doc.RootStorage.Members.Keys)
                {
                   
                    newDoc.WriteStreamData(new string[] { streamName }, doc.GetStreamData(streamName));
                }
                byte[] bookdata = doc.GetStreamData("Workbook");
                if (bookdata != null)
                {
                    if (workbook == null)
                    {
                        workbook = WorkbookDecoder.Decode(new MemoryStream(bookdata));
                    }
                    MemoryStream stream = new MemoryStream();
                    //WorkbookEncoder.Encode(workbook, stream);

                    BinaryWriter writer = new BinaryWriter(stream);
                    foreach (Record record in workbook.Records)
                    {
                        record.Write(writer);
                    }
                    writer.Close();
                    newDoc.WriteStreamData(new string[] { "Workbook" }, stream.ToArray());
                }
                newDoc.Save();
            }
        }
        
        #endregion

        #region Button Exit
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region TreeViewProjectExplore_DoubleClick
        private void _treeViewProjectExplore_DoubleClick(object sender, EventArgs e)
        {
            tabControl1X.SelectedIndex = 2;
            if (_treeViewProjectExplore.SelectedNode.Name == "File")
            {
                try
                {
                    LoadExcelSheets();
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("Error opening the excel file." + Environment.NewLine +
                      ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            //Open file excel
            string fName = _treeViewProjectExplore.Nodes[0].Tag + @"\" + _treeViewProjectExplore.Nodes[0].Nodes[0].Text + @"\" + _treeViewProjectExplore.SelectedNode.Text;
            string fName1 = _treeViewProjectExplore.Nodes[0].Tag + @"\" + _treeViewProjectExplore.Nodes[0].Nodes[1].Text + @"\" + _treeViewProjectExplore.SelectedNode.Text;
            string fName2 = _treeViewProjectExplore.Nodes[0].Tag + @"\" + _treeViewProjectExplore.Nodes[0].Nodes[2].Text + @"\" + _treeViewProjectExplore.SelectedNode.Text;

            if (_treeViewProjectExplore.SelectedNode.Text == _treeViewProjectExplore.SelectedNode.Text)
            {
                try
                {
                    doc = CompoundDocument.Open(fName);
                    LoadExcelSheets();
                }
                catch (Exception ex)
                {

                }
                if (_treeViewProjectExplore.SelectedNode.Text == _treeViewProjectExplore.SelectedNode.Text)
                {
                    try
                    {
                        doc = CompoundDocument.Open(fName1);
                        LoadExcelSheets();
                    }
                    catch (Exception ex)
                    {

                    }
                }
                if (_treeViewProjectExplore.SelectedNode.Text == _treeViewProjectExplore.SelectedNode.Text)
                {
                    try
                    {
                        doc = CompoundDocument.Open(fName2);
                        LoadExcelSheets();
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
        }
        #endregion

        #region TreeViewProjectExplore_AfterSelect
        private void _treeViewProjectExplore_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (_treeViewProjectExplore.SelectedNode.Text == _treeViewProjectExplore.Nodes[0].Text)
            {
                addFileToolStripMenuItem.Visible = false;
                deleteToolStripMenuItem.Visible = false;
                runToolStripMenuItem1.Visible = false;
                runToolStripMenuItem.Enabled = false;
                //_treeViewProjectExplore.SelectedImageIndex = _treeViewProjectExplore.SelectedNode.ImageIndex;
            }
            else if (_treeViewProjectExplore.SelectedNode.Text == _treeViewProjectExplore.Nodes[0].Nodes[0].Text)
            {
                addFileToolStripMenuItem.Visible = true;
                deleteToolStripMenuItem.Visible = false;
                runToolStripMenuItem1.Visible = false;
                runToolStripMenuItem.Enabled = false;
            }
            else if (_treeViewProjectExplore.SelectedNode.Text == _treeViewProjectExplore.Nodes[0].Nodes[1].Text)
            {
                addFileToolStripMenuItem.Visible = true;
                deleteToolStripMenuItem.Visible = false;
                runToolStripMenuItem1.Visible = false;
                runToolStripMenuItem.Enabled = false;
            }
            else if (_treeViewProjectExplore.SelectedNode.Text == _treeViewProjectExplore.Nodes[0].Nodes[2].Text)
            {
                addFileToolStripMenuItem.Visible = true;
                deleteToolStripMenuItem.Visible = false;
                runToolStripMenuItem1.Visible = false;
                runToolStripMenuItem.Enabled = false;
            }

            else if (_treeViewProjectExplore.SelectedNode.Text == _treeViewProjectExplore.Nodes[0].Nodes[0].Nodes[0].Text)
            {
                addFileToolStripMenuItem.Visible = false;
                deleteToolStripMenuItem.Visible = true;
                runToolStripMenuItem1.Visible = false;
                runToolStripMenuItem.Enabled = false;
            }
            else if (_treeViewProjectExplore.SelectedNode.Text == _treeViewProjectExplore.Nodes[0].Nodes[1].Nodes[0].Text)
            {
                addFileToolStripMenuItem.Visible = false;
                deleteToolStripMenuItem.Visible = true;
                runToolStripMenuItem1.Visible = false;
                runToolStripMenuItem.Enabled = false;
            }
            else if (_treeViewProjectExplore.SelectedNode.Text == _treeViewProjectExplore.Nodes[0].Nodes[2].Nodes[0].Text)
            {
                addFileToolStripMenuItem.Visible = false;
                deleteToolStripMenuItem.Visible = true;
                runToolStripMenuItem1.Visible = true;
                runToolStripMenuItem.Enabled = true;
            }
        }
        #endregion

        #region Add New File Excel
        private void addFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _frmNewFile newFile = new _frmNewFile();
            newFile.ShowDialog();

            Excel.Application xlApp = default(Excel.Application);
            Excel.Workbook xlWorkBook = default(Excel.Workbook);
            Excel.Worksheet xlWorkSheet = default(Excel.Worksheet);

            TreeNode treeNode = new TreeNode();
            treeNode.Text = newFile.textBoxName.Text + "." + newFile.comboBoxType.Text;
            treeNode.Tag = treeNode.Text;
            treeNode.Name = "File";
            treeNode.ImageIndex = newFile.comboBoxType.SelectedIndex;
            newFile.Close();
            if (newFile.textBoxName.Text != "")
            {
                _treeViewProjectExplore.SelectedNode.Nodes.Add(treeNode);
                _treeViewProjectExplore.SelectedNode.ExpandAll();

                string fName = _treeViewProjectExplore.Nodes[0].Tag + @"\" + _treeViewProjectExplore.SelectedNode.Tag + @"\" + treeNode.Tag;
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
                if (System.IO.File.Exists(fName))
                {
                    //if (System.Windows.Forms.MessageBox.Show("Would you like to open the excel file?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    //{
                    //    try
                    //    {
                    //        //System.Diagnostics.Process.Start(fName);
                    doc = CompoundDocument.Open(fName);
                    //        LoadExcel();

                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        System.Windows.Forms.MessageBox.Show("Error opening the excel file." + Environment.NewLine +
                    //          ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    }
                    //} //doc1 = CompoundDocument.Open(fName);
                }
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
        #endregion

        #region Close Tab Control
        private void tabControl1_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < this.tabControl1.TabPages.Count; i++)
            {
                Rectangle rPage = tabControl1.GetTabRect(i);
                Rectangle closeButton = new Rectangle(rPage.Right - 15, rPage.Top + 5, 20, 10);
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
        #endregion

        #region Run ContextMenuStrip
        private void runToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmRun run = new frmRun();
            run._txtScript.Text = _treeViewProjectExplore.SelectedNode.Text;
            run._cboData.Text = _treeViewProjectExplore.Nodes[0].Nodes[0].Nodes[0].Text;
            run.ShowDialog();
        }
        #endregion         

       

       
    }
}

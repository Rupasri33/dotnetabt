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
using Telerik.WinControls.UI.Docking;
#endregion

namespace ung
{
    public partial class Form1 : Telerik.WinControls.UI.RadForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region Tao New Project
        private void projectToolStripNewProject_Click(object sender, EventArgs e)
        {
            _treeViewProjectExplore.Nodes.Clear();
            tabControl1.TabPages.Clear();
            NewProject newpj = new NewProject();
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
                    Text = _treeViewProjectExplore.Nodes[0].Text + " - " + Text;
                }
            }
        }

        //new project phim tat
        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            _treeViewProjectExplore.Nodes.Clear();
            tabControl1.TabPages.Clear();
            NewProject newpj = new NewProject();
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
                    Text = _treeViewProjectExplore.Nodes[0].Text + " - " + Text;
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
                    Text = _treeViewProjectExplore.Nodes[0].Text + " - " + Text;
                }
            }    
        }

        //open phim tat
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
                    Text = _treeViewProjectExplore.Nodes[0].Text + " - " + Text;
                }
            }    
        }
        #endregion

        #region Button Save
        private void _btSave_Click(object sender, EventArgs e)
        {

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

        #region Button Exit
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region Run main
        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRun run = new frmRun();
            run._txtScript.Text = _treeViewProjectExplore.SelectedNode.Text;
            run._cboData.Text = _treeViewProjectExplore.Nodes[0].Nodes[0].Nodes[0].Text;
            run.ShowDialog();
        }
        #endregion

        #region Pause
        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Stop
        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region About App & Autor
        private void thoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Information info = new Information();
            info.ShowDialog();
        }

        private void tácGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Author author = new Author();
            author.ShowDialog();
        }

        //information shortcut
        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            Information info = new Information();
            info.ShowDialog();
        }  
        #endregion

        #region Run Contax
        private void runToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmRun run = new frmRun();
            run._txtScript.Text = _treeViewProjectExplore.SelectedNode.Text;
            run._cboData.Text = _treeViewProjectExplore.Nodes[0].Nodes[0].Nodes[0].Text;
            run.Text = _treeViewProjectExplore.Nodes[0].Text + " - " + run.Text;
            run.ShowDialog();
        }
        #endregion

        #region Add File
        private void addFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _frmNewFile newFile = new _frmNewFile();
            newFile.Text = _treeViewProjectExplore.SelectedNode.Text + " - " + newFile.Text;
            newFile.ShowDialog();

            Excel.Application xlApp = default(Excel.Application);
            Excel.Workbook xlWorkBook = default(Excel.Workbook);
            //TabPage sheetPage = new TabPage(_treeViewProjectExplore.SelectedNode.Text);
            //Excel.Worksheet xlWorkSheet = default(Excel.Worksheet);
            Excel.Worksheet xlWorkSheet = new Excel.Worksheet();

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
                    doc = CompoundDocument.Open(fName);
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

        #region Delete File

        #endregion

        #region TreeViewProjectExplore_DoubleClick
        private void _treeViewProjectExplore_DoubleClick_1(object sender, EventArgs e)
        {
            radDock1.Show();
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
            string fname3 = _treeViewProjectExplore.Nodes[0].Tag + @"\" + _treeViewProjectExplore.Nodes[0].Nodes[3].Text + @"\" + _treeViewProjectExplore.SelectedNode.Text;
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
                if (_treeViewProjectExplore.SelectedNode.Text == _treeViewProjectExplore.SelectedNode.Text)
                {
                    try
                    {
                        doc = CompoundDocument.Open(fname3);
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
            if (_treeViewProjectExplore.SelectedNode.Tag == _treeViewProjectExplore.Nodes[0].Tag)
            {
                runToolStripMenuItem1.Visible = false;
                addFileToolStripMenuItem.Visible = false;
                deleteToolStripMenuItem.Visible = false;
            }
            else
            {
                if (_treeViewProjectExplore.SelectedNode.Tag == _treeViewProjectExplore.Nodes[0].Nodes[0].Tag ||
                    _treeViewProjectExplore.SelectedNode.Tag == _treeViewProjectExplore.Nodes[0].Nodes[1].Tag || 
                    _treeViewProjectExplore.SelectedNode.Tag == _treeViewProjectExplore.Nodes[0].Nodes[2].Tag)
                {
                    runToolStripMenuItem1.Visible = false;
                    addFileToolStripMenuItem.Visible = true;
                    deleteToolStripMenuItem.Visible = false;
                }
                else
                {
                    if (_treeViewProjectExplore.SelectedNode.Parent == _treeViewProjectExplore.Nodes[0].Nodes[3])
                    {
                        runToolStripMenuItem1.Visible = true;
                        addFileToolStripMenuItem.Visible = false;
                        deleteToolStripMenuItem.Visible = true;
                    }
                    else
                    {
                        runToolStripMenuItem1.Visible = false;
                        addFileToolStripMenuItem.Visible = false;
                        deleteToolStripMenuItem.Visible = true;
                    }
                }
            }
        }
        #endregion

        #region Remove Node Treeview
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _treeViewProjectExplore.SelectedNode.Remove();
        }
        #endregion

    }
}

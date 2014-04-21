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
#endregion

namespace ung
{
    public partial class frmMain : DevComponents.DotNetBar.Office2007RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        #region Tạo New Project
        private void projectToolStripNewProject_Click(object sender, EventArgs e)
        {
            _frmNewProject _frmNewProject = new _frmNewProject();
            _frmNewProject.ShowDialog();
            if (_frmNewProject.DialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                string path = _frmNewProject.ProjectPath;
                // l?y path ra ? dây...   
                TreeNode treenode;
                DirectoryInfo dir = new DirectoryInfo(path);
                if (dir.Exists)
                {
                    treenode = new TreeNode(dir.Name);
                    treenode.Tag = dir;
                    treenode.Name = "Folder";
                    treenode.ImageIndex = treenode.SelectedImageIndex = 0;
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
                                treenode.ImageIndex = treenode.SelectedImageIndex = 0;
                                foreach (FileInfo file in directory.GetFiles())
                                {
                                    treenode = new TreeNode(file.Name);
                                    treenode.Tag = file;
                                    treenode.Name = "File";
                                    _treeViewProjectExplore.Nodes.Add(treenode);
                                    treenode.ImageIndex = treenode.SelectedImageIndex = 1;
                                   
                                    if (file.Exists)
                                    {
                                        TreeNode nodes = _treeViewProjectExplore.Nodes[0].Nodes[node.Index].Nodes.Add(file.Name);
                                        treenode.ImageIndex = treenode.SelectedImageIndex = 0;
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

        #region Open File Excel
        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                getopen();
                LoadExcelSheets();
            }
            catch (Exception error)
            {
                System.Windows.Forms.MessageBox.Show("" + error);
            }
        }
        //khoi tao
        CompoundDocument doc;
        CompoundDocument doc1;
        White.Core.Application _application;
        White.Core.UIItems.WindowItems.Window _mainWindow;
        DataGridView dgvCells;
        private string filepath;


        //open excel
        public string getopen()
        {
            string file = FileSelector.BrowseFile(FileType.All);
            if (file == null) return null;
            doc = CompoundDocument.Open(file);
            // doc1 = CompoundDocument.Open(file);
            return file;

        }
        public string getopen1()
        {
            string file = FileSelector.BrowseFile(FileType.All);
            if (file == null) return null;
            doc1 = CompoundDocument.Open(file);
            return file;

        }
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

        #region Open Project
        private void projectToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = false;
            fbd.Description = "Mời bạn chọn thư mục";
            fbd.RootFolder = Environment.SpecialFolder.MyComputer;

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                TreeNode treenode;
                string path = fbd.SelectedPath;
                // doc1 = CompoundDocument.Open(path);
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
                                    //treenode.SelectedImageIndex = 0;
                                    // _treeViewProjectExplore.Nodes.Add(treenode);
                                    if (file.Exists)
                                    {
                                        TreeNode nodes = _treeViewProjectExplore.Nodes[0].Nodes[node.Index].Nodes.Add(file.Name);
                                        treenode.ImageIndex = 0;
                                        //node.ImageIndex = node.SelectedImageIndex = 0;
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

        #region Button Save
        private void _btSave_Click(object sender, EventArgs e)
        {
            string fName = _treeViewProjectExplore.Nodes[0].Tag + @"\" + _treeViewProjectExplore.Nodes[0].Nodes[0].Text + @"\" + _treeViewProjectExplore.SelectedNode.Text;
            System.Windows.Forms.TabControl tabControl = new System.Windows.Forms.TabControl();
            tabControl.Name = "TC";
            System.Windows.Forms.TabControl cc = (System.Windows.Forms.TabControl)this.Controls.Find("TC", true).FirstOrDefault();
            SaveForDataGridview(cc, fName, false);
        }

        //...
        public static bool SaveForDataGridview(System.Windows.Forms.TabControl tabControl, string fileName, bool isShowExcle)
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            Excel.Workbook workbook;
            if (!File.Exists(fileName))
            {
                workbook = app.Workbooks.Add(Type.Missing);
                app.DisplayAlerts = false;
                workbook.SaveAs(fileName);
                app.DisplayAlerts = true;
            }
            else
                workbook = app.Workbooks.Open(fileName);
            try
            {
                if (app == null)
                {
                    return false;
                }

                app.Visible = isShowExcle;

                Excel.Sheets sheets = workbook.Worksheets;

                for (int i = 0; i < tabControl.TabPages.Count; i++)
                {
                    DataGridView gridView = (DataGridView)tabControl.TabPages[i].Controls[0];
                    Excel._Worksheet worksheet = workbook.Worksheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    if (worksheet == null)
                    {
                        return false;
                    }
                    string sLen = "";

                    char H = (char)(64 + gridView.ColumnCount / 26);
                    char L = (char)(64 + gridView.ColumnCount % 26);
                    if (gridView.ColumnCount < 26)
                    {
                        sLen = L.ToString();
                    }
                    else
                    {
                        sLen = H.ToString() + L.ToString();
                    }


                    string sTmp = sLen + "1";
                    Excel.Range ranCaption = worksheet.get_Range(sTmp, "A1");
                    string[] asCaption = new string[gridView.ColumnCount];
                    for (int j = 0; j < gridView.ColumnCount; j++)
                    {
                        asCaption[j] = gridView.Columns[j].HeaderText;
                    }
                    ranCaption.Value2 = asCaption;


                    object[] obj = new object[gridView.Columns.Count];
                    for (int r = 0; r < gridView.RowCount; r++)
                    {
                        for (int l = 0; l < gridView.Columns.Count; l++)
                        {
                            if (gridView[l, r].ValueType == typeof(DateTime))
                            {
                                obj[l] = gridView[l, r].Value.ToString();
                            }
                            else
                            {
                                obj[l] = gridView[l, r].Value;
                            }
                        }
                        string cell1 = sLen + ((int)(r + 2)).ToString();
                        string cell2 = "A" + ((int)(r + 2)).ToString();
                        Excel.Range ran = worksheet.get_Range(cell1, cell2);
                        ran.Value2 = obj;
                    }

                }

                workbook.Save();
                workbook.Close();
                app.Quit();
            }
            finally
            {
                app.UserControl = false;
                app.Quit();
            }
            return true;
        }
    
        #endregion

        #region Button Exit
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region Ve chu x dong cac TabControl
        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Font closefont = new Font(e.Font.FontFamily, e.Font.Size);
            Font titlefont = new Font(e.Font.FontFamily, e.Font.Size);
            e.Graphics.DrawString("x", closefont, Brushes.Blue, e.Bounds.Right - 10, e.Bounds.Top + 5);
            e.Graphics.DrawString(this.tabControl1.TabPages[e.Index].Text, titlefont, Brushes.Black, e.Bounds.Left, e.Bounds.Top + 5);
        }

        private void tabControl1_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < this.tabControl1.TabPages.Count; i++)
            {
                Rectangle rPage = tabControl1.GetTabRect(i);
                Rectangle closeButton = new Rectangle(rPage.Right - 15, rPage.Top + 5, 10, 10);
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
                    doc1 = CompoundDocument.Open(fName);
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

        #region Ham LoadExcel
        public void LoadExcel()
        {
            byte[] bookdata = doc1.GetStreamData("Workbook"); // Doc Theo Byte
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

        #region TreeViewProjectExplore_DoubleClick
        private void _treeViewProjectExplore_DoubleClick(object sender, EventArgs e)
        {
            if (_treeViewProjectExplore.SelectedNode.Name == "File")
            {
                try
                {
                    LoadExcel();

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

        #region New Project Phim Tat 
        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            _frmNewProject _frmNewProject = new _frmNewProject();
            _frmNewProject.ShowDialog();
            if (_frmNewProject.DialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                string path = _frmNewProject.ProjectPath;
                // l?y path ra ? dây...   
                TreeNode treenode;
                DirectoryInfo dir = new DirectoryInfo(path);
                if (dir.Exists)
                {
                    treenode = new TreeNode(dir.Name);
                    treenode.Tag = dir;
                    treenode.Name = "Folder";
                    treenode.ImageIndex = treenode.SelectedImageIndex = 0;
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
                                treenode.ImageIndex = treenode.SelectedImageIndex = 0;
                                foreach (FileInfo file in directory.GetFiles())
                                {
                                    treenode = new TreeNode(file.Name);
                                    treenode.Tag = file;
                                    treenode.Name = "File";
                                    _treeViewProjectExplore.Nodes.Add(treenode);
                                    treenode.ImageIndex = treenode.SelectedImageIndex = 1;

                                    if (file.Exists)
                                    {
                                        TreeNode nodes = _treeViewProjectExplore.Nodes[0].Nodes[node.Index].Nodes.Add(file.Name);
                                        treenode.ImageIndex = treenode.SelectedImageIndex = 0;
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

        #region Open Project Phim Tat
        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = false;
            fbd.Description = "Mời bạn chọn thư mục";
            fbd.RootFolder = Environment.SpecialFolder.MyComputer;

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                TreeNode treenode;
                string path = fbd.SelectedPath;
                // doc1 = CompoundDocument.Open(path);
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
                                    //treenode.SelectedImageIndex = 0;
                                    // _treeViewProjectExplore.Nodes.Add(treenode);
                                    if (file.Exists)
                                    {
                                        TreeNode nodes = _treeViewProjectExplore.Nodes[0].Nodes[node.Index].Nodes.Add(file.Name);
                                        treenode.ImageIndex = 0;
                                        //node.ImageIndex = node.SelectedImageIndex = 0;
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

    }
}

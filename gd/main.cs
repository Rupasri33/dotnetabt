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
       

        void test()
        {
            //create new xls file
            string file = "F:\\newdoc.xls";
            Workbook workbook = new Workbook();
            Worksheet worksheet = new Worksheet("First Sheet");
            //worksheet.Cells[0, 1] = new Cell((short)1);
            //worksheet.Cells[2, 0] = new Cell(9999999);
            //worksheet.Cells[3, 3] = new Cell((decimal)3.45);
            //worksheet.Cells[2, 2] = new Cell("Text string");
            //worksheet.Cells[2, 4] = new Cell("Second string");
            //worksheet.Cells[4, 0] = new Cell(32764.5, "#,##0.00");
            //worksheet.Cells[5, 1] = new Cell(DateTime.Now, @"YYYY\-MM\-DD");
            //worksheet.Cells.ColumnWidth[0, 1] = 3000;
            workbook.Worksheets.Add(worksheet);
            workbook.Save(file);
            doc = CompoundDocument.Open(file);
            //IsOpened = true;
            //PopulateTreeview(file);

            // open xls file
            Workbook book = Workbook.Load(file);
            Worksheet sheet = book.Worksheets[0];

            // traverse cells
            foreach (Pair<Pair<int, int>, Cell> cell in sheet.Cells)
            {
                dgvCells[cell.Left.Right, cell.Left.Left].Value = cell.Right.Value;
                if (cell.Right.Style.BackColor != Color.White)
                {
                    dgvCells[cell.Left.Right, cell.Left.Left].Style.BackColor = cell.Right.Style.BackColor;
                }
            }

            // traverse rows by Index
            for (int rowIndex = sheet.Cells.FirstRowIndex;
                   rowIndex <= sheet.Cells.LastRowIndex; rowIndex++)
            {
                Row row = sheet.Cells.GetRow(rowIndex);
                for (int colIndex = row.FirstColIndex;
                   colIndex <= row.LastColIndex; colIndex++)
                {
                    Cell cell = row.GetCell(colIndex);
                }
            }
        }

        public void LoadExcelSheets()
        {
            byte[] bookdata = doc.GetStreamData("Workbook");
            if (bookdata == null) return;
            Workbook book = WorkbookDecoder.Decode(new MemoryStream(bookdata));

            //ExtractImages(book, @"C:\Images");

            

            foreach (Worksheet sheet in book.Worksheets)
            {
               // string Name=treeViewproject.SelectedNode.Text;
                TabPage sheetPage = new TabPage(treeViewproject.SelectedNode.Text);
                
                DataGridView dgvCells = new DataGridView();
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


                foreach (KeyValuePair<Pair<int, int>, Picture> cell in sheet.Pictures)
                {
                    int rowIndex = cell.Key.Left;
                    int colIndex = cell.Key.Right;
                    if (dgvCells.RowCount < rowIndex + 1)
                    {
                        dgvCells.RowCount = rowIndex + 1;
                    }
                    if (dgvCells.ColumnCount < colIndex + 1)
                    {
                        dgvCells.ColumnCount = colIndex + 1;
                    }
                    dgvCells[colIndex, rowIndex].Value = String.Format("<Image,{0}>", cell.Value.Image.FileExtension);
                }

                sheetPage.Controls.Add(dgvCells);
                tabControl1.TabPages.Add(sheetPage);
             
            }
        }

        

        private void main_Load(object sender, EventArgs e)
        {
            //Text="Automation Test";
            //test();
            ////Right click tabControl1
            //this.tabControl1.MouseClick += new MouseEventHandler(tabControl1_MouseClick);
        }


        /////////// xu li nut new
        private void buttonItem2_Click(object sender, EventArgs e)
        {
            treeViewproject.Nodes.Clear();
            tabControl1.TabPages.Clear();
            @new @new = new @new();
            @new.ShowDialog();
            if (@new.DialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                string path = @new.ProjectPath;
                // lấy path ra ở đây... 
                TreeNode treenode;
                
                DirectoryInfo dir = new DirectoryInfo(path);
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
                    Text =treeViewproject.Nodes[0].Text+ " - "+Text;
                } 
            }
        }



        //xu ly nut exit
        private void buttonItem6_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }




        private void addNewFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addfile newFile = new addfile();
            newFile.ShowDialog();
            main main = new main();

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
                treeViewproject.SelectedNode.Nodes.Add(treeNode);
                treeViewproject.SelectedNode.ExpandAll();
                //@new new1 = new @new();
                //string path = new1.ProjectPath;
                //string fName = path + @"\" + treeViewproject.SelectedNode.Tag + @"\" + treeNode.Tag;
                string fName = treeViewproject.Nodes[0].Tag + @"\" + treeViewproject.SelectedNode.Tag + @"\" + treeNode.Tag;
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
                //    if (System.Windows.Forms.MessageBox.Show("Would you like to open the excel file?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                //    {
                //        try
                //        {
                //            System.Diagnostics.Process.Start(fName);
                //        }
                //        catch (Exception ex)
                //        {
                //            System.Windows.Forms.MessageBox.Show("Error opening the excel file." + Environment.NewLine +
                //              ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //        }
                //    }
                //}

                
                
               
                doc = CompoundDocument.Open(fName);
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
            //if (treeViewproject.SelectedNode.Tag == treeViewproject.Nodes[0].Nodes[2].)
            //{
            //    buttonItem15.Enabled = true;
            //}
            //else
            //{
            //    buttonItem15.Enabled = false;
            //}

            ////nếu node đang chọn là thư mục thì cho phép tạo tập tin và thư mục, cũng cho delete luôn
            if (treeViewproject.SelectedNode.Tag == treeViewproject.Nodes[0].Tag)
            {
                addNewFileToolStripMenuItem.Enabled = false;
                deleteToolStripMenuItem.Enabled = false;
                runToolStripMenuItem.Enabled = false;
            }
            else
            {

                if (treeViewproject.SelectedNode.Tag == treeViewproject.Nodes[0].Nodes[0].Tag || treeViewproject.SelectedNode.Tag == treeViewproject.Nodes[0].Nodes[1].Tag || treeViewproject.SelectedNode.Tag == treeViewproject.Nodes[0].Nodes[2].Tag || treeViewproject.SelectedNode.Tag == treeViewproject.Nodes[0].Nodes[3].Tag)
                {
                    addNewFileToolStripMenuItem.Enabled = true;
                    deleteToolStripMenuItem.Enabled = false;
                    runToolStripMenuItem.Enabled = false;

                }

                else
                {
                    addNewFileToolStripMenuItem.Enabled = false;
                    deleteToolStripMenuItem.Enabled = true;
                    runToolStripMenuItem.Enabled = true;
                }
            }
            

            ////nếu node đang chọn là file thì không cho phép tạo gì cả, chỉ cho delete thôi
                   
        }



        private string[] ConvertToStringArray(Array myvalues)
        {
            throw new NotImplementedException();
        }

        //duong dan mo file
        public string getopen()
        {
        
            string file = FileSelector.BrowseFile(FileType.All);
            if (file == null)
                return null;
            doc = CompoundDocument.Open(file);
            return file;

        }






        ///////////////////xu li nut open
        private void buttonItem3_Click(object sender, EventArgs e)
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
                string path = fbd.SelectedPath;
                //string path1 = fbd.SelectedPath + treeViewproject.SelectedNode.Tag;
                //doc = CompoundDocument.Open(path);
                DirectoryInfo dir = new DirectoryInfo(path);

                if (dir.Exists)
                {
                    treenode = new TreeNode(dir.Name);
                    treenode.Tag = dir;
                    treenode.Name = "Folder";
                    //treenode.ImageIndex = 0;
                    treenode.ImageIndex = 1;
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
                                    //treenode = new TreeNode(file.Name);
                                    //treenode.Tag = file;
                                    //treenode.Name = "File";
                                    //treenode.ImageIndex = 1;
                                    //treenode.SelectedImageIndex = 1;
                                    //treeViewproject.Nodes.Add(treenode);

                                    if (file.Exists)
                                    {
                                        TreeNode nodes = treeViewproject.Nodes[0].Nodes[node.Index].Nodes.Add(file.Name);

                                        treenode.ImageIndex = 1;
                                        node.ImageIndex = node.SelectedImageIndex = 1;
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
                    Text = treeViewproject.Nodes[0].Text + " - " + Text;
                }
               
            }
            
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
            //if (treeViewproject.SelectedNode.Name=="File")
            //{
            //    LoadExcelSheets();
            //}
            string path = treeViewproject.Nodes[0].Tag + @"\" + treeViewproject.Nodes[0].Nodes[0].Text + @"\" + treeViewproject.SelectedNode.Text;
            string path1 = treeViewproject.Nodes[0].Tag + @"\" + treeViewproject.Nodes[0].Nodes[1].Text + @"\" + treeViewproject.SelectedNode.Text;
            string path2 = treeViewproject.Nodes[0].Tag + @"\" + treeViewproject.Nodes[0].Nodes[2].Text + @"\" + treeViewproject.SelectedNode.Text;
            if (treeViewproject.SelectedNode.Text == treeViewproject.SelectedNode.Text)
            {
                try
                {
                    doc = CompoundDocument.Open(path);
                    LoadExcelSheets();
                    
                }
                catch { }

                if (treeViewproject.SelectedNode.Text == treeViewproject.SelectedNode.Text)
                {
                    try
                    {
                        doc = CompoundDocument.Open(path1);
                        LoadExcelSheets();
                    }
                    catch { }
                    if (treeViewproject.SelectedNode.Text == treeViewproject.SelectedNode.Text)
                    {
                        try
                        {
                            doc = CompoundDocument.Open(path2);
                            LoadExcelSheets();
                        }
                        catch { }
                        if (treeViewproject.SelectedNode.Name == "File")
                        {
                            LoadExcelSheets();
                        }
                    }
                }

               
            
                
            }
           
        }

        //SAVE        
        private void buttonItem5_Click(object sender, EventArgs e)
        {
            if (doc != null)
            {
                doc.Save();
            }
            
        }

        //SAVE AS
        Workbook workbook;
        private void buttonItem7_Click(object sender, EventArgs e)
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

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }


         
         private void buttonItem12_Click(object sender, EventArgs e)
         {
            
         }

         private void buttonItem14_Click(object sender, EventArgs e)
         {

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
                     if (System.Windows.Forms.MessageBox.Show("Close this Tab?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                     {
                         this.tabControl1.TabPages.RemoveAt(i);
                         break;
                     }
                 }

             }



         }
         #endregion

         private void bar1_ItemClick(object sender, EventArgs e)
         {

         }

         private void ribbonBar3_ItemClick(object sender, EventArgs e)
         {

         }

         private void pictureBox1_Click(object sender, EventArgs e)
         {

         }

         private void buttonItem2_Click_1(object sender, EventArgs e)
         {
             
             FormViewer s = new FormViewer();
             s.ShowDialog();
         }

        //XỬ LÍ NÚT RUN
         private void buttonItem15_Click(object sender, EventArgs e)
         {
             //if (buttonItem15.Enabled == true)
             //{
             //    buttonItem15.Enabled = false;
             //    buttonItem16.Enabled = true;
             //    buttonItem4.Enabled = true;
             //}
            
             frun f = new frun();
             f._txtScript.Text = treeViewproject.SelectedNode.Text;
             f.ShowDialog();
            
            
         }

         
    } 
}

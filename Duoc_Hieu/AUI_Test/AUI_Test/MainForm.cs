using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.IO;
using System.Runtime.InteropServices;
//-------------------------------------------
using QiHe.CodeLib;
using ExcelLibrary.CompoundDocumentFormat;
using ExcelLibrary.BinaryDrawingFormat;
using ExcelLibrary.BinaryFileFormat;
using ExcelLibrary.SpreadSheet;
//-------------------------------------------
using System.Linq;
using System.Text;
using White.Core.Factory;
using White.Core.UIItems.Finders;
using White.Core.InputDevices;
using System.Threading;

//-------------------------------------------

using UITimer = System.Windows.Forms.Timer;
using System.Management;
using System.Management;
using System.Windows.Forms;
using Telerik.WinControls.UI.Docking;

namespace AUI_Test
{
    public partial class MainForm : Telerik.WinControls.UI.RadForm
    {
        public MainForm()
        {
            InitializeComponent();
            
        }

        private void radMenuItem8_Click(object sender, EventArgs e)
        {

        }

        private void radMenuItem7_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {


        }

        private void tileGroupElement1_Click(object sender, EventArgs e)
        {

        }

        private void radMenuItem13_Click(object sender, EventArgs e)
        {

        }

        private void radMenuItem14_Click(object sender, EventArgs e)
        {

        }

        private void radMenuItem18_Click(object sender, EventArgs e)
        {

        }

        private void radMenuItem19_Click(object sender, EventArgs e)
        {

        }

        private void radMenuItem10_Click(object sender, EventArgs e)
        {

        }

        private void radMenuItem20_Click(object sender, EventArgs e)
        {

        }

        private void radMenuItem15_Click(object sender, EventArgs e)
        {

        }

        private void Open_File_Click(object sender, EventArgs e)
        {
            string file = FileSelector.BrowseFile(FileType.Excel97);
            //DirectoryTabcontrol RanString = tabControl as DirectoryTabcontrol;
            //RanString.Dir = file;
            //RanString.Run();          
          
            
        }

        private void radSplitContainerChinh_Click(object sender, EventArgs e)
        {

        }

        private void Automation_Bar_Click(object sender, EventArgs e)
        {

        }

        private void documentWindow3_Click(object sender, EventArgs e)
        {
        }

        private void radMenuItem23_Click(object sender, EventArgs e)
        {

        }

        //---- New Project
        private void radMenuItem11_Click(object sender, EventArgs e)
        {
            NewProject _newproject = new NewProject();
            _newproject.ShowDialog();
            DirectoryTreeview NewDir = treeView as DirectoryTreeview;
            radTextBoxduongdanproject.Text = NewDir.PathTree = _newproject.duongdanproject;
            string Pathproject = radTextBoxduongdanproject.Text;
            DirectoryTreeview Tree = treeView as DirectoryTreeview;
            Tree.PathTree = Pathproject;
            Tree.Runother();
            IFileParser WorkDir = new IFileParser();
            WorkDir.WorkingDir = radTextBoxduongdanproject.Text;
           
        }

        //--- Open Project 
        private void radMenuItemOpenProject_Click(object sender, EventArgs e)
        {
            string duongdan;
            FolderBrowserDialog Chonduongdan = new FolderBrowserDialog();
            Chonduongdan.RootFolder = Environment.SpecialFolder.MyComputer;
            if (Chonduongdan.ShowDialog() == DialogResult.OK)
            {
                duongdan = Chonduongdan.SelectedPath;
                DirectoryTreeview NewTree = treeView as DirectoryTreeview;
                NewTree.PathTree = duongdan;
                radTextBoxduongdanproject.Text = duongdan;
                NewTree.Runother();
            }
        }
    }
}

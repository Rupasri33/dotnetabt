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
using White.Core.Factory;
using White.Core.UIItems.Finders;
using White.Core.InputDevices;
using System.Threading;

//-------------------------------------------

using UITimer = System.Windows.Forms.Timer;
using System.Management;
using Telerik.WinControls.UI.Docking;

namespace AUI_Test
{
    public partial class MainForm : Telerik.WinControls.UI.RadForm
    {
        public MainForm()
        {
            InitializeComponent();
            treeView.SelectOpen += treeView_SelectOpen;
        }

        private void treeView_SelectOpen(string s)
        {
            duongdantabcontrol = s;
            RunTabConTrol();
        }

        // Khi bam open ben tree vi no truyen duong dan qua va thuc hien runtabcontrolben nay
        public string duongdan;
        public string duongdantabcontrol
        {
            set
            {
                duongdan = value;

            }
        }

        //DUONG DAN PROJECT
        public string duongdanproject;
        public string pathproject
        {

            set
            {
                duongdanproject = value;
            }
        }

        // cHAY TAB
        public void RunTabConTrol()
        {
            DirectoryTabcontrol RanString = tabControl as DirectoryTabcontrol;
            RanString.Dir = duongdan;
            RanString.Run();
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
            Automation at = new Automation(new ExcelFileParser(), new ExcelReporter(), @"C:\Users\10110_000\Desktop\Duoc");
            UIAActionManager am = new UIAActionManager(at);
            Script startScript = new Script(at.Parser);
            at.Scripts.Push(startScript);
            at.Start();
        }

        private void Open_File_Click(object sender, EventArgs e)
        {
            string file = FileSelector.BrowseFile(FileType.Excel97);
            DirectoryTabcontrol RanString = tabControl as DirectoryTabcontrol;
            RanString.Dir = file;
            RanString.Run();


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
            //Show Form
            NewProject _newproject = new NewProject();
            _newproject.ShowDialog();

            // Dua Vao CAY
            DirectoryTreeview NewDir = treeView as DirectoryTreeview;
            //
            NewDir.PathTree = _newproject.duongdanproject;
            pathproject = _newproject.duongdanproject;
            string Pathproject = duongdanproject;
            NewDir.NameProject = _newproject._nameproject;

            DirectoryTreeview Tree = treeView as DirectoryTreeview;
            Tree.PathTree = Pathproject;
            Tree.Runother();

            IFileParser WorkDir = new IFileParser();
            WorkDir.WorkingDir = duongdanproject;

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
                duongdanproject = duongdan;
                NewTree.Runother();
            }
        }

        private void commandBarButtonPause_Click(object sender, EventArgs e)
        {

        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

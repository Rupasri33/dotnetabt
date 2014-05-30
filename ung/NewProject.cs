using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace ung
{
    public partial class NewProject : Telerik.WinControls.UI.RadForm
    {
        public NewProject()
        {
            InitializeComponent();
        }

        private void btBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = false;
            fbd.Description = "Chọn thư mục lưu";
            fbd.RootFolder = Environment.SpecialFolder.MyComputer;
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                cboLocation.Text = fbd.SelectedPath;
            }
        }

        public string ProjectPath { get; private set; }
        private void btOK_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Tên Project không được bỏ trống!");
                txtName.Focus();
            }
            else
            {
                if (cboLocation.Text.Trim() == "")
                {
                    MessageBox.Show("Vui lòng chọn đường dẫn lưu tập tin");
                }
                else
                {
                    try
                    {
                        this.DialogResult = System.Windows.Forms.DialogResult.No;
                        // tạo biến để lưu thư mục cần tạo, tên thư mục cần tạo là "StoredFiles"
                        string path = cboLocation.Text;
                        string directoryPath = txtName.Text;
                        //kiểm tra nếu thư mục "StoredFiles" chưa tồn tại thì tạo mới
                        if (!System.IO.Directory.Exists(directoryPath))
                            System.IO.Directory.CreateDirectory(directoryPath);
                        // tạo tập tin "EmployeeList.txt" trong thư mục "StoredFiles"
                        ProjectPath = path + @"\" + directoryPath;
                        string filePath = ProjectPath + @"\Script";
                        string filePath1 = ProjectPath + @"\Data";
                        string filePath2 = ProjectPath + @"\Interface";
                        string filePath3 = ProjectPath + @"\Report";
                        // System.IO.FileStream fs = new System.IO.FileStream(filePath, System.IO.FileMode.Create);
                        System.IO.Directory.CreateDirectory(filePath);
                        System.IO.Directory.CreateDirectory(filePath1);
                        System.IO.Directory.CreateDirectory(filePath2);
                        System.IO.Directory.CreateDirectory(filePath3);
                        // Kết thúc: thông báo tạo tập tin thành công
                        //string mesage = "Project đã được tạo";
                        //MessageBox.Show(mesage, "Thông báo");
                        this.DialogResult = System.Windows.Forms.DialogResult.Yes;
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.InnerException.ToString());
                        this.Close();
                    }
                }
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void NewProject_Load(object sender, EventArgs e)
        {
            //txtName.Select();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}

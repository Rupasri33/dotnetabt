using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace gd
{
    public partial class @new : DevComponents.DotNetBar.Office2007RibbonForm
    {
        public @new()
        {
            InitializeComponent();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
           this.Close();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = false;
            fbd.Description = "Mời bạn chọn thư mục";
            fbd.RootFolder = Environment.SpecialFolder.MyComputer;
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                textBoxX2.Text = fbd.SelectedPath;

            }
        }
        public string ProjectPath { get; private set; }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            
           
            try
            {
                main m = new main();
                 
               // main main = new main();
                //main.GetFirstValue = ProjectPath;
                this.DialogResult = System.Windows.Forms.DialogResult.No;
                // Bước 1: tạo biến để lưu thư mục cần tạo, tên thư mục cần tạo là "StoredFiles"
                string path = textBoxX2.Text;
                string directoryPath = textBoxX1.Text; 
                // Bước 2: kiểm tra nếu thư mục "StoredFiles" chưa tồn tại thì tạo mới
                if (!System.IO.Directory.Exists(directoryPath))
                    System.IO.Directory.CreateDirectory(directoryPath);
                // Bước 4: tạo tập tin "EmployeeList.txt" trong thư mục "StoredFiles"
                ProjectPath = path + @"\" + directoryPath;

                string filePath = path + @"\" + directoryPath + @"\Script";
                string filePath1 = path + @"\" + directoryPath + @"\Data";
                string filePath2 = path + @"\" + directoryPath + @"\Interface";
                string filePath3 = path + @"\" + directoryPath + @"\Report";
                // System.IO.FileStream fs = new System.IO.FileStream(filePath, System.IO.FileMode.Create);
                System.IO.Directory.CreateDirectory(filePath);
                System.IO.Directory.CreateDirectory(filePath1);
                System.IO.Directory.CreateDirectory(filePath2);
                System.IO.Directory.CreateDirectory(filePath3);
                // Kết thúc: thông báo tạo tập tin thành công
                // và chỉ ra đường dẫn tập tin để người dùng dễ dàng kiểm tra tập tin vừa tạo
                //string mesage = "Tạo tập tin thành công";
                //string mesage = "Tạo tập tin \"Script\" thành công." + Environment.NewLine;
                //mesage += "Đường dẫn là \"" + System.Windows.Forms.Application.StartupPath + @"\" + directoryPath + filePath + "\"";
                //MessageBox.Show(mesage, "Thông báo");
                this.DialogResult = System.Windows.Forms.DialogResult.Yes;
                this.Close();
               

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.InnerException.ToString());
            }
           

            
        }

        private void @new_Load(object sender, EventArgs e)
        {
            textBoxX1.Select();
        }

        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ung
{
    public partial class _frmNewProject : Form

    {
        //di chuyen form khong có title
        const int WM_NCHITTEST = 0x84;
        const int HTCLIENT = 0x1;
        const int HTCAPTION = 0x2;

        public _frmNewProject()
        {
            InitializeComponent();
            textBoxX1.Focus();
        }

        //di chuyen form khong có title
        protected override void WndProc(ref Message message)
        {
            base.WndProc(ref message);

            if (message.Msg == WM_NCHITTEST && (int)message.Result == HTCLIENT)
                message.Result = (IntPtr)HTCAPTION;
        }

        //button cancel
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //button Browse
        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = false;
            fbd.Description = "Chọn thư mục lưu";
            fbd.RootFolder = Environment.SpecialFolder.MyComputer;
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                comboBox1.Text = fbd.SelectedPath;
            }
            
        }

        public string ProjectPath { get; private set; }

        //button OK
        private void _btOK_Click(object sender, EventArgs e)
        {
            if (textBoxX1.Text.Trim() == "")
            {
                MessageBox.Show("Tên Project không được bỏ trống!");
                textBoxX1.Focus();
            }
            else
            {
                if (comboBox1.Text.Trim() == "")
                {
                    MessageBox.Show("Vui lòng chọn đường dẫn lưu tập tin");
                }
                else
                {
                    try
                    {
                        this.DialogResult = System.Windows.Forms.DialogResult.No;
                        // tạo biến để lưu thư mục cần tạo, tên thư mục cần tạo là "StoredFiles"
                        string path = comboBox1.Text;
                        string directoryPath = textBoxX1.Text;
                        //kiểm tra nếu thư mục "StoredFiles" chưa tồn tại thì tạo mới
                        if (!System.IO.Directory.Exists(directoryPath))
                            System.IO.Directory.CreateDirectory(directoryPath);
                        // tạo tập tin "EmployeeList.txt" trong thư mục "StoredFiles"
                        ProjectPath = path + @"\" + directoryPath;
                        string filePath = ProjectPath + @"\Script";
                        string filePath1 = ProjectPath + @"\Data";
                        string filePath2 = ProjectPath + @"\Interface";
                        // System.IO.FileStream fs = new System.IO.FileStream(filePath, System.IO.FileMode.Create);
                        System.IO.Directory.CreateDirectory(filePath);
                        System.IO.Directory.CreateDirectory(filePath1);
                        System.IO.Directory.CreateDirectory(filePath2);
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

        public static string directoryPath { get; set; }

      
    }
}

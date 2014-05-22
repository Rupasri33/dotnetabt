using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QiHe.CodeLib;
using ExcelLibrary.CompoundDocumentFormat;
using ExcelLibrary.BinaryDrawingFormat;
using ExcelLibrary.BinaryFileFormat;
using ExcelLibrary.SpreadSheet;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Threading;
using Telerik.WinControls.UI.Docking;
namespace AUI_Test
{
    public class DirectoryTabcontrol : TabControl
    {

        IFileParser Parser = new IFileParser();

        string PathDir;
        public string Dir
        {
            set
            {
                PathDir = value;

            }

            get
            {

                return PathDir;
            }
        }





        public void Run()
        {
            if (Dir == null)
                return;
            Parser.getopen(Dir);
            Parser.loadexcel();
            TabPage sheetPage = new TabPage();
            sheetPage.Controls.Add(Parser.loadexcel());
            TabPages.Add(sheetPage);

        }

        public DirectoryTabcontrol()
        {

            Run();            
            Location = new System.Drawing.Point(6, 16);
            SelectedIndex = 0;
            Size = new System.Drawing.Size(694, 274);
            TabIndex = 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//using abt;
//using codeduiabt;
using abt.model;
using abt.auto;
using uia_auto.auto;

namespace gd
{
    public partial class frun : DevComponents.DotNetBar.Office2007RibbonForm
    {
        public frun()
        {
            InitializeComponent();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            Close();
            main m = new main();
            ////IAutomation at = new Automation(new ExcelFileParser(), new ExcelReporter(new ExcelFileParser()),
            ////    @"E:\demo_new\dotnetabt\codeduiabt\sample");
            //IAutomation at = new Automation(new ExcelFileParser(), new ExcelReporter(new ExcelFileParser()), @"E:\aa\test" );
            //UIAActionManager am = new UIAActionManager(at);

            //Script startScript = new Script(at.Parser.NewInstance);
            //startScript.FileName = _txtScript.Text;

            //at.Speed = 10;
            //at.StartScript = startScript;
            //at.Start();
            string path= m.treeViewproject.Nodes[0].Text;
            IAutomation at = new Automation(new ExcelFileParser(), new ExcelReporter(new ExcelFileParser()),
                @"E:\aa" + @"\" +path);
            UIAActionManager am = new UIAActionManager(at);

            try
            {
                Script startScript = new Script(at.Parser.NewInstance);
                startScript.FileName = _txtScript.Text;

                Data data = new Data(at.Parser.NewInstance);
                data.FileName = "DataSet1.xls";

                at.Name = "Regression 1";
                at.Speed = 10;
                at.Data = data;
                at.StartScript = startScript;
                at.Start();

                at.Paused += at_Paused;
                at.Resumed += at_Resumed;
                at.Interupted += at_Interupted;
                at.Ended += at_Ended;
                at.ActionPerforming += at_ActionPerforming;

                //System.Threading.Thread.Sleep(3000);
                //at.Pause();

                //System.Threading.Thread.Sleep(10000);
                //at.Resume();

                //System.Threading.Thread.Sleep(3000);
                //at.Interupt();
            }
            catch (Exception x)
            {
                System.Windows.Forms.MessageBox.Show(x.Message);
            }
            finally
            {
                //at.Interupt();
                //Console.ReadLine();
            }

            //Automation at = new Automation(new ExcelFileParser(), new ExcelReporter(), @"D:\codes\dotnetabt\seleniumabt\sample");
            //SeleniumActionManager am = new SeleniumActionManager(at, SeleniumActionManager.Browser.Chrome);

            //Script startScript = new Script(at.Parser.NewInstance);
            //startScript.FileName = "Script.xls";

            //at.Scripts.Push(startScript);
            //at.Start();






        }

        static void at_ActionPerforming(string s)
        {
 	        //throw new NotImplementedException();
            Console.WriteLine(s);
        }

        static void at_Ended(IAutomation at)
        {
            //throw new NotImplementedException();
            Console.WriteLine("Automation ended");
        }

        static void at_Interupted(IAutomation at)
        {
            //throw new NotImplementedException();
            Console.WriteLine("Automation stopped. Error: " + at.ErrorMessage);
        }

        static void at_Resumed(IAutomation at)
        {
            //throw new NotImplementedException();
            Console.WriteLine("Automation resumed");
        }

        static void at_Paused(IAutomation at)
        {
            //throw new NotImplementedException();
            Console.WriteLine("Automation paused");






        }
    }
}

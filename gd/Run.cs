using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using abt.model;
using abt.auto;
using uia_auto.auto;

namespace gd
{
    public partial class Run : Telerik.WinControls.UI.RadForm
    {
        public Run()
        {
            InitializeComponent();
        }
        public string CurrentProjectPath { get; set; }
        public IAutomation CurrenrtAutomation { get; set; }
        private void btAdd_Click(object sender, EventArgs e)
        {
            Close();
            main m = new main();
            //string path = m.CurrentProjectPath;
        
            CurrenrtAutomation = new Automation(new ExcelFileParser(), new ExcelReporter(new ExcelFileParser()),
               CurrentProjectPath);
            UIAActionManager am = new UIAActionManager(CurrenrtAutomation);

            try
            {
                Script startScript = new Script(CurrenrtAutomation.Parser.NewInstance);
                startScript.FileName = _txtScript.Text;
                string dataset = _cboData.SelectedItem.ToString();
                if (dataset != @"[None]")
                {
                    Data data = new Data(CurrenrtAutomation.Parser.NewInstance);
                    data.FileName = dataset;
                    CurrenrtAutomation.Data = data;
 
                }
               

                CurrenrtAutomation.Name = "Regression 1";
                CurrenrtAutomation.Speed = 10;
                CurrenrtAutomation.StartScript = startScript;
                CurrenrtAutomation.Start();
                

                //CurrenrtAutomation.Paused += at_Paused;
                //CurrenrtAutomation.Resumed += at_Resumed;
                //CurrenrtAutomation.Interupted += at_Interupted;
                //CurrenrtAutomation.Ended += at_Ended;
                //CurrenrtAutomation.ActionPerforming += at_ActionPerforming;

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

        //private void at_ActionPerforming(string summary)
        //{
        //    //throw new NotImplementedException();
        //    main m = new main();
            
        //}
        //// static void at_ActionPerforming(string s)
        ////{
        ////    //throw new NotImplementedException();
        ////    Console.WriteLine(s);
        ////}

        ////static void at_Ended(IAutomation at)
        ////{
        ////    //throw new NotImplementedException();
        ////    Console.WriteLine("Automation ended");
        ////}

        ////static void at_Interupted(IAutomation at)
        ////{
        ////    //throw new NotImplementedException();
        ////    Console.WriteLine("Automation stopped. Error: " + at.ErrorMessage);
        ////}

        ////static void at_Resumed(IAutomation at)
        ////{
        ////    //throw new NotImplementedException();
        ////    Console.WriteLine("Automation resumed");
        ////}

        ////static void at_Paused(IAutomation at)
        ////{
        ////    //throw new NotImplementedException();
        ////    Console.WriteLine("Automation paused");
        ////}

        private void btCancel_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}

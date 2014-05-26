using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using abt;
//using codeduiabt;
//using seleniumabt;

using abt.model;
using abt.auto;
using uia_auto.auto;

namespace uiatest
{
    class Program
    {
        static void Main(string[] args)
        {
            IAutomation at = new Automation(new ExcelFileParser(), new ExcelReporter(new ExcelFileParser()),
                @"C:\Users\datthong.nguyen\Documents\Visual Studio 2012\Projects\dotnetabt\codeduiabt\sample");
            UIAActionManager am = new UIAActionManager(at);

            try
            {
                Script startScript = new Script(at.Parser.NewInstance);
                startScript.FileName = "Script2.xls";

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

                System.Threading.Thread.Sleep(3000);
                at.Pause();

                System.Threading.Thread.Sleep(10000);
                at.Resume();

                System.Threading.Thread.Sleep(3000);
                at.Interupt();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
            }
            finally
            {
                //at.Interupt();
                Console.ReadLine();
            }

            //Automation at = new Automation(new ExcelFileParser(), new ExcelReporter(), @"D:\codes\dotnetabt\seleniumabt\sample");
            //SeleniumActionManager am = new SeleniumActionManager(at, SeleniumActionManager.Browser.Chrome);

            //Script startScript = new Script(at.Parser.NewInstance);
            //startScript.FileName = "Script.xls";

            //at.Scripts.Push(startScript);
            //at.Start();






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

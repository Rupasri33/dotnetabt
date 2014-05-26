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

            Script startScript = new Script(at.Parser.NewInstance);
            startScript.FileName = "Script2.xls";

            Data data = new Data(at.Parser.NewInstance);
            data.FileName = "DataSet1.xls";

            at.Name = "Regression 1";
            at.Speed = 10;
            at.Data = data;
            at.StartScript = startScript;
            at.Start();

            System.Threading.Thread.Sleep(3000);
            at.Pause();

            System.Threading.Thread.Sleep(10000);
            at.Resume();

            //Automation at = new Automation(new ExcelFileParser(), new ExcelReporter(), @"D:\codes\dotnetabt\seleniumabt\sample");
            //SeleniumActionManager am = new SeleniumActionManager(at, SeleniumActionManager.Browser.Chrome);

            //Script startScript = new Script(at.Parser.NewInstance);
            //startScript.FileName = "Script.xls";

            //at.Scripts.Push(startScript);
            //at.Start();






        }
    }
}

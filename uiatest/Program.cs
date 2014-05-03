using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using abt;
//using codeduiabt;
using seleniumabt;

namespace uiatest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Automation at = new Automation(new ExcelFileParser(), new ExcelReporter(), @"D:\codes\dotnetabt\codeduiabt\sample");
            //UIAActionManager am = new UIAActionManager(at);

            //Script startScript = new Script(at.Parser.NewInstance);
            //startScript.FileName = "Script.xls";

            //at.Scripts.Push(startScript);
            //at.Start();

            Automation at = new Automation(new ExcelFileParser(), new ExcelReporter(), @"D:\codes\dotnetabt\seleniumabt\sample");
            SeleniumActionManager am = new SeleniumActionManager(at, SeleniumActionManager.Browser.Chrome);

            Script startScript = new Script(at.Parser.NewInstance);
            startScript.FileName = "Script.xls";

            at.Scripts.Push(startScript);
            at.Start();






        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using abt;
using codeduiabt;
using codeduiabt.actions;

namespace uiatest
{
    class Program
    {
        static void Main(string[] args)
        {
            Automation at = new Automation(new ExcelFileParser(), @"C:\Users\ndthong\Desktop\DemoExcel\DemoExcel");
            UIAActionManager am = new UIAActionManager(at);

            Script startScript = new Script(at.Parser.NewInstance);
            startScript.FileName = "Script.xls";

            at.Scripts.Push(startScript);
            at.Run();

            //Interface inter = new Interface(new ExcelFileParser());
            //Script scr = new Script(new ExcelFileParser());

            //inter.Path = @"C:\Users\ndthong\Desktop\DemoExcel\DemoExcel\Interface\Interface.xls";
            //scr.Path = @"C:\Users\ndthong\Desktop\DemoExcel\DemoExcel\Script\Script.xls";
            int x = 0;

            x++;
        }
    }
}

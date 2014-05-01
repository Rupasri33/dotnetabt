using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using abt;

namespace codeduiabt
{
    public class UIAAutomation : Automation
    {
        /// <summary>
        /// default constructor
        /// </summary>
        /// <param name="workingDir">the working directory</param>
        public UIAAutomation(string workingDir)
            : base(new ExcelFileParser(), new ExcelReporter(), workingDir)
        {
        }
    }
}

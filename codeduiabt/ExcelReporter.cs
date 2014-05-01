using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using abt;

namespace codeduiabt
{
    class ExcelReporter : IReporter
    {
        public void BeginReport(string path)
        {
            throw new NotImplementedException();
        }

        public void EndReport()
        {
            throw new NotImplementedException();
        }

        public void BeginScript(string scriptName)
        {
            throw new NotImplementedException();
        }

        public void EndScript()
        {
            throw new NotImplementedException();
        }

        public void WriteLine()
        {
            throw new NotImplementedException();
        }

        public string WorkingDir { get; set; }

        public string FileExtension
        {
            get { return @".xls"; }
        }
    }
}

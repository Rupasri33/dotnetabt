using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUI_Test
{
    public interface IReporter
    {
        void BeginReport(string path);
        void EndReport();

        void BeginScript(string scriptName);
        void EndScript();

        void WriteLine();

        string WorkingDir { get; set; }

        string FileExtension { get; }

        IReporter NewInstance { get; }
    }
}

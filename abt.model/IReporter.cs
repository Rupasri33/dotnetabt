using System;
using System.Collections.Generic;

namespace abt.model
{
    public interface IReporter
    {
        void BeginReport(string path);
        void EndReport();

        void BeginDataRow(int id);
        void EndDataRow();

        void BeginScript(string scriptName);
        void EndScript();

        void WriteLine();

        string WorkingDir { get; set; }

        string FileExtension { get; }

        IReporter NewInstance { get; }
    }
}

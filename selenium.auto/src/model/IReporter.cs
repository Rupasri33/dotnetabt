﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace selenium_auto.model
{
    public interface IReporter
    {
        void BeginReport(string name);
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
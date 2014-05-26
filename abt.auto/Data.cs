using System;
using System.Collections.Generic;

using abt.model;

namespace abt.auto
{
    public class Data : SourceFile, IData
    {
        public Data(IFileParser parser)
            : base(parser)
        {
            Parser.WorkingDir = Parser.WorkingDir + Constants.Directory.ReportDir;

            TotalRowCount = 1;
            CurrentRowId = -1;
        }

        protected override void ProcessLoadedData()
        {
            base.ProcessLoadedData();
        }

        private int TotalRowCount { get; set; }

        public bool HasNextRow
        {
            get { return CurrentRowId < Lines.Count - 1; }
        }

        public bool MoveNext()
        {
            if (!HasNextRow)
                return false;

            CurrentRowId++;
            return true;
        }

        public string this[string variable]
        {
            get { return "btn1"; }
        }

        public int CurrentRowId { get; set; }
    }
}

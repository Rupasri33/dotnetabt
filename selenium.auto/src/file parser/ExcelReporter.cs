using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using selenium_auto.model;

namespace selenium_auto.file_parser
{
    public class ExcelReporter : IReporter
    {
        public void BeginReport(string path)
        {
            //throw new NotImplementedException();
        }

        public void EndReport()
        {
            //throw new NotImplementedException();
        }

        public void BeginScript(string scriptName)
        {
            //throw new NotImplementedException();
        }

        public void EndScript()
        {
            //throw new NotImplementedException();
        }

        public void WriteLine()
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// working directory of reporter
        /// </summary>
        public string WorkingDir { get; set; }

        /// <summary>
        /// default extension of report
        /// </summary>
        public string FileExtension
        {
            get { return @".xls"; }
        }

        /// <summary>
        /// new instance copied
        /// </summary>
        public IReporter NewInstance
        {
            get
            {
                IReporter newInt = new ExcelReporter();
                newInt.WorkingDir = WorkingDir;
                return newInt;
            }
        }


        public void BeginDataRow(int id)
        {
            throw new NotImplementedException();
        }

        public void EndDataRow()
        {
            throw new NotImplementedException();
        }
    }
}

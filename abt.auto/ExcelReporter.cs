using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using abt.model;

namespace abt.auto
{
    public class ExcelReporter : SourceFile, IReporter
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="parser">the file parser</param>
        public ExcelReporter(IFileParser parser)
            : base(parser)
        { }

        /// <summary>
        /// current indent of the report
        /// </summary>
        private int Indent { get; set; }

        /// <summary>
        /// create new report
        /// </summary>
        /// <param name="name">name of the report</param>
        /// <param name="datasetName">name of the dataset</param>
        public void BeginReport(string name, string datasetName)
        {
            Name = name;
            Parser.Create(@"Report - " + DateTime.Now.ToString("yyyy-MM-dd.hh-mm"));

            SourceLine line = new SourceLine();
            line.Columns.Add(@"REPORT");
            line.Columns.Add(name);

            Lines.Add(line);

            if (datasetName != null)
            {
                line = new SourceLine();
                line.Columns.Add(@"DATASET");
                line.Columns.Add(datasetName);
                Lines.Add(line);
            }
        }

        /// <summary>
        /// close current report and save to file
        /// </summary>
        public bool EndReport()
        {
            SourceLine line = new SourceLine();
            line.Columns.Add(@"END REPORT");
            line.Columns.Add(Name);

            Lines.Add(line);
            try
            {
                Parser.Save(Name);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// begin new section 'script' in current report
        /// </summary>
        /// <param name="scriptName">name of the script</param>
        public void BeginScript(string scriptName)
        {
            Indent++;

            SourceLine line = new SourceLine();
            for (int i=0; i<Indent; i++)
                line.Columns.Add(@"");

            line.Columns.Add(@"begin script");
            line.Columns.Add(scriptName);

            Lines.Add(line);
        }

        /// <summary>
        /// end current 'script' section
        /// </summary>
        /// <param name="scriptName">name of the script</param>
        public void EndScript(string scriptName)
        {
            Indent--;

            SourceLine line = new SourceLine();
            for (int i = 0; i < Indent; i++)
                line.Columns.Add(@"");

            line.Columns.Add(@"end script");
            line.Columns.Add(scriptName);

            Lines.Add(line);
        }

        /// <summary>
        /// write a line to the report
        /// </summary>
        /// <param name="actLine">information about the action</param>
        /// <param name="result">result of the action</param>
        public void WriteLine(ActionLine actLine, ActionResult result)
        {
            SourceLine line = new SourceLine();
            for (int i = 0; i < Indent + 1; i++)
                line.Columns.Add(@"");

            line.Columns.Add(actLine.ActionName);
            if (actLine.WindowName != null || actLine.ControlName != null)
            {
                line.Columns.Add(actLine.WindowName != null ? actLine.WindowName : @"");
                line.Columns.Add(actLine.ControlName != null ? actLine.ControlName : @"");
            }
            foreach (string key in actLine.Arguments.Keys)
                line.Columns.Add(key + @":" + actLine.Arguments[key]);
            line.Columns.Add(result != ActionResult.NORET ? result.ToString() : @"");

            Lines.Add(line);
        }

        /// <summary>
        /// write an error to the report
        /// </summary>
        /// <param name="actLine">the error action line</param>
        /// <param name="why">the reason</param>
        public void WriteError(ActionLine actLine, string why)
        {
            SourceLine line = new SourceLine();
            for (int i = 0; i < Indent + 1; i++)
                line.Columns.Add(@"");

            line.Columns.Add(actLine.ActionName);
            if (actLine.WindowName != null || actLine.ControlName != null)
            {
                line.Columns.Add(actLine.WindowName != null ? actLine.WindowName : @"");
                line.Columns.Add(actLine.ControlName != null ? actLine.ControlName : @"");
            }
            foreach (string key in actLine.Arguments.Keys)
                line.Columns.Add(key + @":" + actLine.Arguments[key]);
            line.Columns.Add(@"ERROR: " + why);

            Lines.Add(line);
        }

        /// <summary>
        /// new instance copied
        /// </summary>
        public IReporter NewInstance
        {
            get
            {
                return new ExcelReporter(Parser.NewInstance);
            }
        }

        /// <summary>
        /// begin new section 'data row' in current report
        /// </summary>
        /// <param name="id">row id</param>
        public void BeginDataRow(int id)
        {
            Indent++;

            SourceLine line = new SourceLine();
            for (int i = 0; i < Indent; i++)
                line.Columns.Add(@"");

            line.Columns.Add(@"DATA ROW");
            line.Columns.Add(id.ToString());

            Lines.Add(line);
        }

        /// <summary>
        /// end current 'data row' section
        /// </summary>
        /// <param name="id">row id</param>
        public void EndDataRow(int id)
        {
            Indent--;

            SourceLine line = new SourceLine();
            for (int i = 0; i < Indent; i++)
                line.Columns.Add(@"");

            line.Columns.Add(@"END DATA ROW");
            line.Columns.Add(id.ToString());

            Lines.Add(line);
        }

        /// <summary>
        /// default extension of the report file
        /// </summary>
        public string FileExtension
        {
            get { return Parser.FileExtension; }
        }

        /// <summary>
        /// the working directory
        /// </summary>
        public string WorkingDir
        {
            get { return Parser.WorkingDir; }
            set { Parser.WorkingDir = value + Constants.Directory.ReportDir; }
        }
    }
}

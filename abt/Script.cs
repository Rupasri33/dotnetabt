using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace abt
{
    public class Script : SourceFile
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="parser">the file parser</param>
        public Script(IFileParser parser)
            : base(parser)
        {
            CurrentLineNumber = 0;
            ActionLines = new List<ActionLine>();

            foreach (SourceLine line in Parser.Lines)
            {
                if (line.ColumnCount > 0)
                {
                    ActionLine actLine = new ActionLine();
                    actLine.ActionName = line.Columns[0];
                    for (int i = 1; i < line.ColumnCount; i++)
                    {
                        string[] pairs = line.Columns[i].Split(Constants.PropertyDelimeter.ToCharArray(), 2);
                        if (pairs.Length != 2)
                            throw new FormatException(Constants.Messsages.ScriptParsingError);
                        if (pairs[0] == Constants.KeywordWindow)
                            actLine.WindowName = pairs[1];
                        else if (pairs[0] == Constants.KeywordControl)
                            actLine.ControlName = pairs[1];
                        else
                            actLine.Arguments[pairs[0]] = pairs[1];
                    }
                    ActionLines.Add(actLine);
                }
            }
        }

        /// <summary>
        /// list of action lines
        /// </summary>
        private List<ActionLine> ActionLines { get; set; }

        /// <summary>
        /// check if there is any action lines are waiting for executing
        /// </summary>
        public bool HasNextLine
        {
            get { return CurrentLineNumber < ActionLines.Count; }
        }

        /// <summary>
        /// current executing line number
        /// </summary>
        public int CurrentLineNumber { get; private set; }

        /// <summary>
        /// go to next action line
        /// </summary>
        /// <returns>null - if no action line left</returns>
        public ActionLine Next()
        {
            if (CurrentLineNumber < ActionLines.Count)
            {
                return ActionLines[CurrentLineNumber++];
            }

            return null;
        }
    }
}

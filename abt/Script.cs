using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                            throw new FormatException("Interface file parsing error: invalid action line");
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
        public List<ActionLine> ActionLines { get; private set; }
    }
}

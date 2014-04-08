using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abt
{
    public class Interface : SourceFile
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="parser">the file parser</param>
        public Interface(IFileParser parser)
            : base(parser)
        {
            Properties = new Dictionary<string, string>();
            Controls = new Dictionary<string, Dictionary<string, string>>();

            foreach (SourceLine line in Parser.Lines)
            {
                if (line.ColumnCount > 0)
                {
                    if (line.Columns[0] == Constants.KeywordWindow)
                    {
                        this.Name = line.Columns[1];
                        for (int i = 2; i < line.ColumnCount; i++)
                        {
                            string[] pairs = line.Columns[i].Split(Constants.PropertyDelimeter.ToCharArray(), 2);
                            if (pairs.Length != 2)
                                throw new FormatException(Constants.Messsages.InterfaceParsingError_Window);
                            Properties[pairs[0]] = pairs[1];
                        }
                    }
                    else if (line.Columns[0] == Constants.KeywordControl)
                    {
                        string propName = line.Columns[1];
                        for (int i = 2; i < line.ColumnCount; i++)
                        {
                            string[] pairs = line.Columns[i].Split(Constants.PropertyDelimeter.ToCharArray(), 2);
                            if (pairs.Length != 2)
                                throw new FormatException(Constants.Messsages.InterfaceParsingError_Control);
                            Controls[propName] = new Dictionary<string, string>();
                            Controls[propName][pairs[0]] = pairs[1];
                        }
                    }
                }
            }
        }

        /// <summary>
        /// properties of the interface (window)
        /// </summary>
        public Dictionary<string, string> Properties { get; private set; }

        /// <summary>
        /// properties of a control within the window
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public Dictionary<string, Dictionary<string, string>> Controls { get; private set; }
    }
}

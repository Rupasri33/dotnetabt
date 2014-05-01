using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace abt
{
    public class SourceFile
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="parser"></param>
        public SourceFile(IFileParser parser)
        {
            Parser = parser;
            parser.FileParsed += ProcessData;
        }

        /// <summary>
        /// path to the source file
        /// </summary>
        public string FileName {
            get { return Parser.Name; }
            set
            {
                Parser.Name = value;
            }
        }

        /// <summary>
        /// name of the source file
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// lines of the source file
        /// </summary>
        protected List<SourceLine> Lines { get; private set; }

        /// <summary>
        /// the file parser
        /// </summary>
        public IFileParser Parser { get; private set; }

        /// <summary>
        /// process data from parser
        /// </summary>
        protected virtual void ProcessData()
        {
            Lines = Parser.Lines;
        }
    }
}

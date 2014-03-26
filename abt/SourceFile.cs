using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Lines = parser.Lines;
        }

        /// <summary>
        /// path to the source file
        /// </summary>
        public string Path {
            get { return Parser.Path; }
            set
            {
                Parser.Path = value;
                Lines = Parser.Lines;
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
    }
}

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
        public Interface(IFileParser parser) : base(parser) { }
    }
}

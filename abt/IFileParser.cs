using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abt
{
    public interface IFileParser
    {
        /// <summary>
        /// path to the parsing file
        /// </summary>
        string Path { get; set; }

        /// <summary>
        /// result lines of parsing
        /// </summary>
        List<SourceLine> Lines { get; }
    }
}

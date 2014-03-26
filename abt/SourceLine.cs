using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abt
{
    public sealed class SourceLine
    {
        /// <summary>
        /// number of column in the line
        /// </summary>
        public int ColumnCount { get; private set; }

        /// <summary>
        /// value of a column indicated by "index"
        /// </summary>
        /// <param name="index">the column zero-based index</param>
        /// <returns>the content of the column</returns>
        public List<string> Columns { get; set; }
    }
}

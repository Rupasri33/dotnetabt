using System;
using System.Collections.Generic;

namespace AUI_Test
{
    public interface IInterface : ISourceFile
    {
        /// <summary>
        /// properties of the interface (window)
        /// </summary>
        Dictionary<string, string> Properties { get; }

        /// <summary>
        /// properties of a control within the window
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        Dictionary<string, Dictionary<string, string>> Controls { get; }
    }
}

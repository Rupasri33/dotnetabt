using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selenium_auto.model
{
    public interface IData : ISourceFile
    {
        bool HasNextRow { get; }

        bool MoveNext();

        string this[string variable] { get; }

        int CurrentRowId { get; }
    }
}

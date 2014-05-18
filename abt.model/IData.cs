using System;
using System.Collections.Generic;

namespace abt.model
{
    public interface IData : ISourceFile
    {
        bool HasNextRow { get; }

        bool MoveNext();

        string this[string variable] { get; }

        int CurrentRowId { get; }
    }
}

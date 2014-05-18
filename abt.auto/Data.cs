using System;
using System.Collections.Generic;

using abt.model;

namespace abt.auto
{
    public class Data : SourceFile, IData
    {
        public Data() : base(null) { }

        public bool HasNextRow
        {
            get { throw new NotImplementedException(); }
        }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public string this[string variable]
        {
            get { throw new NotImplementedException(); }
        }

        public int CurrentRowId
        {
            get { throw new NotImplementedException(); }
        }
    }
}

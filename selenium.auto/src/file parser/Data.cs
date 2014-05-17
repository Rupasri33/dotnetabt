using System;
using System.Collections.Generic;

using selenium_auto.model;

namespace selenium_auto.file_parser
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

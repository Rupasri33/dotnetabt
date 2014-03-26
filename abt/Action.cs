using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abt
{
    public class Action
    {
        public string Name { get; protected set; }

        public bool IsValid()
        {
            return true;
        }

        public int Execute()
        {
            return 0;
        }
    }
}

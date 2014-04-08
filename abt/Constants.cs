using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace abt
{
    public class Constants
    {
        public const string PropertyDelimeter = @":";
        public const string KeywordWindow = @"window";
        public const string KeywordControl = @"control";

        public class Messsages
        {
            public const string ScriptParsingError = @"Script file parsing error: invalid action line";
            public const string InterfaceParsingError_Window = @"Interface file parsing error: invalid window line";
            public const string InterfaceParsingError_Control = @"Interface file parsing error: invalid control line";
        }
    }
}

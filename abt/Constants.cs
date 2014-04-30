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

        public const string KeywordInterface = @"interface";
        public const string KeywordScript = @"script";
        public const string ActionUseInterface = @"use interface";
        public const string ActionStartScript = @"start script";

        public class Messsages
        {
            public const string Error_Parsing_Script = @"Script file parsing error: invalid action line";
            public const string Error_Parsing_Interface_InvalidWindow = @"Interface file parsing error: invalid window line";
            public const string Error_Parsing_Interface_InvalidControl = @"Interface file parsing error: invalid control line";

            public const string Error_Matching_Window_NoDefinition = @"";
            public const string Error_Matching_Window_NotFound = @"";
            public const string Error_Matching_Window_NoUniqueWindow = @"";

            public const string Error_Matching_Control_NoDefinition = @"";
            public const string Error_Matching_Control_NotFound = @"";
            public const string Error_Matching_Control_NoUniqueWindow = @"";

            public const string Error_Executing_NoAction = @"";
        }

        public class ControlTypeNames
        {
            public const string ControlTypeButton = @"button";
            public const string ControlTypeTextBox = @"textbox";
        }
    }
}

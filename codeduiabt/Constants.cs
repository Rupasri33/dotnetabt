using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace codeduiabt
{
    class Constants : abt.Constants
    {
        public class PropertyNames
        {
            public const string ControlType = @"type";
            public const string AutomationId = @"automationid";
            public const string Text = @"text";
        }

        public new class Messages : abt.Constants.Messages
        {
            public const string Error_ExcelFileNotFound = @"File not found or invalid format.";
            public const string Error_ExcelFileNoWorkbook = @"No workbook";
            public const string Error_ExcelFileNoWorksheet = @"No worksheet";
        }
    }
}

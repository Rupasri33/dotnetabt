using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace seleniumabt
{
    class Constants : abt.Constants
    {
        public class PropertyNames
        {
            public const string Name = @"name";
            public const string Id = @"id";
            public const string Title = @"title";
            public const string ControlType = @"type";
            public const string Text = @"text";
            public const string XPath = @"xpath";
            public const string LinkText = @"link";
            public const string Css = @"css";
        }

        public new class Messages : abt.Constants.Messages
        {
            public const string Error_ExcelFileNotFound = @"File not found or invalid format.";
            public const string Error_ExcelFileNoWorkbook = @"No workbook";
            public const string Error_ExcelFileNoWorksheet = @"No worksheet";
        }
    }
}

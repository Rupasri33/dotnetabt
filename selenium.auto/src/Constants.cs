using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace selenium_auto
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

        public class Messages
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

            public const string Error_ExcelFileNotFound = @"File not found or invalid format.";
            public const string Error_ExcelFileNoWorkbook = @"No workbook";
            public const string Error_ExcelFileNoWorksheet = @"No worksheet";
        }

        public class ControlTypeNames
        {
            public const string ControlTypeButton = @"button";
            public const string ControlTypeTextBox = @"textbox";
        }

        public class Directory
        {
            public const string InterfaceDir = @"\Interface\";
            public const string ScriptDir = @"\Script\";
            public const string DataDir = @"\Data\";
            public const string ReportDir = @"\Report\";
        }

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

    }
}

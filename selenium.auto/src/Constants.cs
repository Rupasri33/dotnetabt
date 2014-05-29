using System;

namespace selenium_auto
{
    public class Constants : abt.auto.Constants
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

        public new class Messages : abt.auto.Constants.Messages
        {

        }

        public class WarningMessages
        {
            public const string Warning_NotSetControl = @"The control cannot be set.";
        }
    }
}

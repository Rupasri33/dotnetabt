using System;

namespace uia_auto
{
    class Constants : abt.auto.Constants
    {
        public class PropertyNames
        {
            public const string Name = @"name";
            public const string Id = @"id";
            public const string Title = @"title";
            public const string ControlType = @"type";
            public const string AutomationId = @"automationid";
            public const string Text = @"text";
            public const string Enabled = @"enabled";
            public const string Visible = @"visible";
            public const string Width = @"width";
            public const string Height = @"height";
        }

        public new class Messages : abt.auto.Constants.Messages
        {

        }
    }
}

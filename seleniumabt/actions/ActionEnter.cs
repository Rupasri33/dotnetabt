using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using abt;
using OpenQA.Selenium;

namespace seleniumabt.actions
{
    class ActionEnter : SeleniumAction
    {
        public ActionEnter(IWebDriver webDriver)
            : base(webDriver)
        {
            Name = @"enter";
        }

        public override Dictionary<string, string> Params
        {
            get
            {
                return base.Params;
            }
            set
            {
                base.Params = value;
                if (Params.Keys.Contains(@"text"))
                    Text = Params[@"text"];
            }
        }

        public override bool IsValid()
        {
            if (Text == null)
                return false;

            return true;
        }

        public string Text
        {
            get;
            set;
        }

        public override int Execute()
        {
            //throw new NotImplementedException();
            Control.SendKeys(Text);

            return 0;
        }

        public override void Reset()
        {
            base.Reset();

            Text = null;
        }
    }
}

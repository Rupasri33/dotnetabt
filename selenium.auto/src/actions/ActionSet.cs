using System;
using System.Collections.Generic;

using OpenQA.Selenium;

using abt.model;

namespace selenium_auto.actions
{
    class ActionSet : SeleniumAction
    {
        private bool Checked { get; set; }

        public ActionSet(IWebDriver webDriver)
            : base(webDriver)
        {
            Name = @"set";
            Checked = true;
        }

        /// <summary>
        /// set parameters to action
        /// </summary>
        public override Dictionary<string, string> Params
        {
            set
            {
                base.Params = value;
                if (Params.ContainsKey(@"checked"))
                    Checked = Params[@"checked"].Equals(@"true", StringComparison.CurrentCultureIgnoreCase);
            }
        }

        /// <summary>
        /// check if the parameters are valid
        /// </summary>
        /// <returns></returns>
        public override bool IsValid()
        {
            if (Control == null)
                throw new Exception(Constants.Messages.Error_Matching_Control_NotFound);

            return true;
        }

        /// <summary>
        /// do the click
        /// </summary>
        /// <returns>0 if sucessful</returns>
        public override int Execute()
        {
            string tag = Control.TagName;
            string type = Control.GetAttribute(@"type");
            if (tag.Equals(@"input", StringComparison.CurrentCultureIgnoreCase) &&
                type.Equals(@"checkbox", StringComparison.CurrentCultureIgnoreCase))
            {
                if (Control.Selected && Checked == false)
                    Control.Click();
                else if (!Control.Selected && Checked == true)
                    Control.Click();
            }
            else if (tag.Equals(@"option", StringComparison.CurrentCultureIgnoreCase))
                Control.Click();
            else
            {
                Result = ActionResult.WARNING;
                MoreDetailAboutResult = Constants.WarningMessages.Warning_NotSetControl;
            }

            return base.Execute();
        }

        /// <summary>
        /// reset action after executing
        /// </summary>
        public override void Reset()
        {
            base.Reset();
            Checked = true;
        }

    }
}

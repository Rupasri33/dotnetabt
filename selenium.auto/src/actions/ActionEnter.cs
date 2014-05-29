using System;
using System.Collections.Generic;

using OpenQA.Selenium;

namespace selenium_auto.actions
{
    class ActionEnter : SeleniumAction
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="webDriver">the web driver</param>
        public ActionEnter(IWebDriver webDriver)
            : base(webDriver)
        {
            Name = @"enter";
        }

        /// <summary>
        /// parameters of the action
        /// </summary>
        public override Dictionary<string, string> Params
        {
            get
            {
                return base.Params;
            }
            set
            {
                base.Params = value;
                if (Params.ContainsKey(@"text"))
                    Text = Params[@"text"];
            }
        }

        /// <summary>
        /// check if the parameters are valid
        /// </summary>
        /// <returns></returns>
        public override bool IsValid()
        {
            if (Text == null)
                return false;

            if (Control == null)
                throw new Exception(Constants.Messages.Error_Matching_Control_NotFound);

            return true;
        }

        /// <summary>
        /// text to be entered
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// do the click
        /// </summary>
        /// <returns>0 if sucessful</returns>
        public override int Execute()
        {
            Control.SendKeys(Text);

            return 0;
        }

        /// <summary>
        /// reset action after executing
        /// </summary>
        public override void Reset()
        {
            base.Reset();
            Text = null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenQA.Selenium;

namespace seleniumabt.actions
{
    internal class ActionOpenURL : SeleniumAction
    {
        /// <summary>
        /// the URL to be navigated
        /// </summary>
        private string URL { get; set; }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="webDriver">the web driver</param>
        public ActionOpenURL(IWebDriver webDriver)
            : base(webDriver)
        {
            Name = @"open url";
        }

        /// <summary>
        /// set parameters to action
        /// </summary>
        public override Dictionary<string, string> Params
        {
            set
            {
                base.Params = value;

                if (Params.ContainsKey(@"url"))
                    URL = Params[@"url"];
            }
        }

        /// <summary>
        /// check whether the parameters are valid
        /// </summary>
        /// <returns>true - if params are valid</returns>
        public override bool IsValid()
        {
            // check the program path is valid
            if (URL == null || URL.Length == 0)
                return false;

            // check the URL is valid
            if (URL.IndexOf("http://") != 0 && URL.IndexOf("https://") != 0)
                return false;

            return true;
        }

        /// <summary>
        /// executing the action
        /// </summary>
        /// <returns>true - if start program successfully</returns>
        public override int Execute()
        {
            WebDriver.Navigate().GoToUrl(URL);

            return 0;
        }

        /// <summary>
        /// override the reset from base class
        /// </summary>
        public override void Reset()
        {
            base.Reset();
            URL = null;
        }
    }
}

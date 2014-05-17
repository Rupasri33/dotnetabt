using System;

using OpenQA.Selenium;

namespace selenium_auto.actions
{
    internal class ActionRefresh : SeleniumAction
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="webDriver">the web driver</param>
        public ActionRefresh(IWebDriver webDriver)
            : base(webDriver)
        {
            Name = @"refresh";
        }

        /// <summary>
        /// executing the action
        /// </summary>
        /// <returns>true - if start program successfully</returns>
        public override int Execute()
        {
            WebDriver.Navigate().Refresh();

            return 0;
        }
    }
}

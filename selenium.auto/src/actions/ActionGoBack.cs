using System;

using OpenQA.Selenium;

namespace selenium_auto.actions
{
    internal class ActionGoBack : SeleniumAction
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="webDriver">the web driver</param>
        public ActionGoBack(IWebDriver webDriver)
            : base(webDriver)
        {
            Name = @"go back";
        }

        /// <summary>
        /// executing the action
        /// </summary>
        /// <returns>true - if start program successfully</returns>
        public override int Execute()
        {
            WebDriver.Navigate().Back();

            return 0;
        }
    }
}

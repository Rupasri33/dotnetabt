using System;

using OpenQA.Selenium;

namespace selenium_auto.actions
{
    /// <summary>
    /// represent action click using selenium library
    /// </summary>
    internal class ActionClick : SeleniumAction
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="webDriver">the web driver</param>
        public ActionClick(IWebDriver webDriver)
            : base(webDriver)
        {
            Name = @"click";
        }

        /// <summary>
        /// check if the parameters are valid
        /// </summary>
        /// <returns></returns>
        public override bool IsValid()
        {
            if (Control == null)
                throw new Exception(Constants.Messages.Error_Matching_Control_NotFound);

            return base.IsValid();
        }

        /// <summary>
        /// do the click
        /// </summary>
        /// <returns>0 if sucessful</returns>
        public override int Execute()
        {
            Control.Click();

            return base.Execute();
        }
    }
}

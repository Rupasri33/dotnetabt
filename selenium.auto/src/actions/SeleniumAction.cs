using System;
using System.Collections.Generic;

using Selenium;
using OpenQA.Selenium;

using abt.model;
using abt.auto;

namespace selenium_auto.actions
{
    public abstract class SeleniumAction : abt.auto.Action
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="webDriver"></param>
        public SeleniumAction(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }

        /// <summary>
        /// the web driver
        /// </summary>
        public IWebDriver WebDriver { get; private set; }

        /// <summary>
        /// the web control to be automated
        /// </summary>
        public IWebElement Control { get; set; }

        /// <summary>
        /// reset action after executing
        /// </summary>
        public override void Reset()
        {
            base.Reset();

            Control = null;
        }
    }
}

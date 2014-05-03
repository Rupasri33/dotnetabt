using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Selenium;
using OpenQA.Selenium;

namespace seleniumabt
{
    public abstract class SeleniumAction : abt.Action
    {
        /// <summary>
        /// default constructor
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
        /// reset action parameters after executing
        /// </summary>
        public override void Reset()
        {
            Control = null;
            base.Reset();
        }
    }
}

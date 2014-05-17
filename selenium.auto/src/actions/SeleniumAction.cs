using System;
using System.Collections.Generic;

using Selenium;
using OpenQA.Selenium;

using selenium_auto.model;

namespace selenium_auto.actions
{
    public abstract class SeleniumAction : IAction
    {
        Dictionary<string, string> m_Params;

        /// <summary>
        /// name of the action
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// parameters of the action
        /// </summary>
        public virtual Dictionary<string, string> Params
        {
            get { return m_Params; }
            set
            {
                foreach (string key in value.Keys)
                    Params.Add(key, value[key]);
            }
        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="webDriver"></param>
        public SeleniumAction(IWebDriver webDriver)
        {
            m_Params = new Dictionary<string, string>();
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
        /// check if the parameters are valid for executing
        /// derived class should re-implement this function
        /// </summary>
        /// <returns>true - if parameters are ready for executing</returns>
        public virtual bool IsValid()
        {
            return true;
        }

        /// <summary>
        /// execute the action
        /// derived class should re-implement this function for actual executing
        /// </summary>
        /// <returns>0 - if executing sucessfully</returns>
        public abstract int Execute();

        /// <summary>
        /// reset action after executing
        /// </summary>
        public virtual void Reset()
        {
            Params.Clear();

            Control = null;
        }
    }
}

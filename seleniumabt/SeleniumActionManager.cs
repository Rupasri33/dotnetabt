using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

using seleniumabt.actions;

namespace seleniumabt
{
    public class SeleniumActionManager : abt.ActionManager
    {
        /// <summary>
        /// supported browser
        /// </summary>
        public enum Browser
        {
            Chrome,
            FireFox,
            Safari,
            IE
        }

        /// <summary>
        /// the selenium web driver
        /// </summary>
        public IWebDriver WebDriver { get; private set; }

        /// <summary>
        /// construct a Selenium Action Manager with an Automation Engine
        /// </summary>
        /// <param name="automation">the Automation Engine</param>
        public SeleniumActionManager(abt.Automation automation, Browser browser)
            : base(automation)
        {
            switch (browser)
            {
                case Browser.Chrome:
                    {
                        OpenQA.Selenium.Chrome.ChromeDriverService service = OpenQA.Selenium.Chrome.ChromeDriverService.CreateDefaultService();
                        service.HideCommandPromptWindow = true;
                        WebDriver = new OpenQA.Selenium.Chrome.ChromeDriver(service, new OpenQA.Selenium.Chrome.ChromeOptions());
                        break;
                    }
                case Browser.FireFox:
                    WebDriver = new OpenQA.Selenium.Firefox.FirefoxDriver();
                    break;
                case Browser.Safari:
                    WebDriver = new OpenQA.Selenium.Safari.SafariDriver();
                    break;
                default:
                    WebDriver = new OpenQA.Selenium.IE.InternetExplorerDriver();
                    break;
            };

            RegisterAction(new ActionClick(WebDriver));
            RegisterAction(new ActionOpenURL(WebDriver));
            RegisterAction(new ActionRefresh(WebDriver));
            RegisterAction(new ActionGoBack(WebDriver));
        }

        /// <summary>
        /// search for the web element to be being automated
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IWebElement FindControl(Dictionary<string, string> criteria)
        {
            if (criteria.Count != 1)
                return null;

            foreach (string key in criteria.Keys)
            {
                ReadOnlyCollection<IWebElement> elements;
                string val = criteria[key];
                switch (key)
                {
                    case Constants.PropertyNames.Id:
                        elements = WebDriver.FindElements(By.Id(val));
                        if (elements.Count == 1)
                            return elements[0];
                        return null;

                    case Constants.PropertyNames.Name:
                        elements = WebDriver.FindElements(By.Name(val));
                        if (elements.Count == 1)
                            return elements[0];
                        return null;

                    case Constants.PropertyNames.XPath:
                        return WebDriver.FindElement(By.XPath(val));

                    case Constants.PropertyNames.Css:
                        return WebDriver.FindElement(By.CssSelector(val));

                    case Constants.PropertyNames.LinkText:
                        elements = WebDriver.FindElements(By.LinkText(val));
                        if (elements.Count == 1)
                            return elements[0];
                        return null;
                };
            }
            return null;
        }

        /// <summary>
        /// check whether current webpage is valid
        /// </summary>
        /// <param name="windowName">the window name (interface name) of the web page</param>
        /// <returns>true if valid</returns>
        bool CheckWindow(string windowName)
        {
            if (windowName == null || !Parent.Interfaces.ContainsKey(windowName) ||
                !Parent.Interfaces[windowName].Properties.ContainsKey(Constants.PropertyNames.Title))
                return false;

            if (WebDriver.Title != Parent.Interfaces[windowName].Properties[Constants.PropertyNames.Title])
                return false;

            return true;
        }

        /// <summary>
        /// get a Selenium Action for the line
        /// </summary>
        /// <param name="actLine">the action line</param>
        /// <returns>the Selenium Action</returns>
        public override abt.Action getAction(abt.ActionLine actLine)
        {
            IWebElement targetControl = null;

            if (!Actions.ContainsKey(actLine.ActionName))
                throw new Exception(abt.Constants.Messages.Error_Executing_NoAction);
            if (actLine.WindowName != null && !CheckWindow(actLine.WindowName))
                throw new Exception(abt.Constants.Messages.Error_Matching_Control_NoDefinition);
            if (actLine.ControlName != null && !Parent.Interfaces[actLine.WindowName].Controls.ContainsKey(actLine.ControlName))
                throw new Exception(abt.Constants.Messages.Error_Matching_Control_NoDefinition);

            if (actLine.WindowName != null && actLine.ControlName != null)
                targetControl = FindControl(Parent.Interfaces[actLine.WindowName].Controls[actLine.ControlName]);

            // prepare the action
            SeleniumAction action = Actions[actLine.ActionName] as SeleniumAction;
            action.Control = targetControl;
            action.Params = actLine.Arguments;

            return action;
        }
    }
}

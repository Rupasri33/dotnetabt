using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Selenium;
using OpenQA.Selenium;

namespace seleniumabt
{
   public class SeleniumActionManager : abt.ActionManager
    {
        /// <summary>
        /// construct a Selenium Action Manager with an Automation Engine
        /// </summary>
        /// <param name="automation">the Automation Engine</param>
        public SeleniumActionManager(abt.Automation automation)
            : base(automation)
        {
        }

        /// <summary>
        /// search for the web element to be being automated
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IWebElement FindControl(Dictionary<string, string> criteria)
        {
            return null;
        }

        /// <summary>
        /// get a Selenium Action for the line
        /// </summary>
        /// <param name="actLine">the action line</param>
        /// <returns>the Selenium Action</returns>
        public override abt.Action getAction(abt.ActionLine actLine)
        {
            IWebElement targetControl = null;

            if (Actions[actLine.ActionName] == null || !(Actions[actLine.ActionName] is SeleniumAction))
                throw new Exception(abt.Constants.Messages.Error_Executing_NoAction);
            if (actLine.WindowName == null || Parent.Interfaces[actLine.WindowName] == null || 
                actLine.ControlName == null || Parent.Interfaces[actLine.WindowName].Controls[actLine.ControlName] == null)
                throw new Exception(abt.Constants.Messages.Error_Matching_Control_NoDefinition);

            targetControl = FindControl(Parent.Interfaces[actLine.WindowName].Controls[actLine.ControlName]);
            if (targetControl == null)
                throw new Exception(abt.Constants.Messages.Error_Matching_Control_NotFound);

            // prepare the action
            SeleniumAction action = Actions[actLine.ActionName] as SeleniumAction;
            action.Control = targetControl;
            action.Params = actLine.Arguments;

            return action;
        }
    }
}

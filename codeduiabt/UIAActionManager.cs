using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;

namespace codeduiabt
{
    class UIAActionManager : abt.ActionManager
    {
        /// <summary>
        /// construct an ActionManager with an Automation engine
        /// </summary>
        /// <param name="automation">the Automation engine</param>
        public UIAActionManager(abt.Automation automation)
            : base(automation)
        {
        }

        /// <summary>
        /// check if a window is matched with given criteria
        /// </summary>
        /// <param name="window">the window to be checked</param>
        /// <param name="criteria">the criteria</param>
        /// <returns>true - if matched</returns>
        private bool MatchWindow(Window window, Dictionary<string, string> criteria)
        {
            return false;
        }

        /// <summary>
        /// find a window with given criteria
        /// </summary>
        /// <param name="criteria">the criteria to find</param>
        /// <returns>the found window</returns>
        private Window FindWindow(Dictionary<string, string> criteria)
        {
            List<Window> windows = WindowFactory.Desktop.DesktopWindows();
            List<Window> foundWindows = new List<Window>();

            // loop all windows on the desktop
            foreach (Window window in windows)
            {
                if (MatchWindow(window, criteria))
                    foundWindows.Add(window);
            }

            // check for error
            if (foundWindows.Count > 1)
                throw new Exception(abt.Constants.Messsages.Error_Matching_Window_NoUniqueWindow);
            else if (foundWindows.Count == 0)
                throw new Exception(abt.Constants.Messsages.Error_Matching_Window_NotFound);

            // found the window
            return foundWindows[0];
        }

        /// <summary>
        /// given a criteria, find a control within a window
        /// </summary>
        /// <param name="window">the containing window</param>
        /// <param name="criteria">the criteria to find the control</param>
        /// <returns>the found control. null - if not found</returns>
        private UIItem FindControl(Window window, Dictionary<string, string> criteria)
        {
            return null;
        }

        /// <summary>
        /// get an UIA action for the line
        /// </summary>
        /// <param name="actLine">the action line</param>
        /// <returns>the UIA action</returns>
        public override abt.Action getAction(abt.ActionLine actLine)
        {
            Window targetWindow = null;
            UIItem targetControl = null;

            if (Actions[actLine.ActionName] == null || !(Actions[actLine.ActionName] is UIAAction))
                throw new Exception(abt.Constants.Messsages.Error_Executing_NoAction);
            if (actLine.WindowName != null && Parent.Interfaces[actLine.WindowName] == null)
                throw new Exception(abt.Constants.Messsages.Error_Matching_Window_NoDefinition);

            // search for the target control
            if (actLine.WindowName != null)
                targetControl = targetWindow = FindWindow(Parent.Interfaces[actLine.WindowName].Properties);
            if (actLine.ControlName != null)
                targetControl = FindControl(targetWindow, Parent.Interfaces[actLine.WindowName].Controls[actLine.ControlName]);

            if (targetControl == null)
                throw new Exception(abt.Constants.Messsages.Error_Matching_Control_NotFound);

            // prepare the action
            UIAAction action = Actions[actLine.ActionName] as UIAAction;
            action.Control = targetControl;
            action.Params = actLine.Arguments;
            
            return action;
        }
    }
}

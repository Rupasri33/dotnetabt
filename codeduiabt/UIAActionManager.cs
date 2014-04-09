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
        public UIAActionManager(abt.Automation automation)
            : base(automation)
        {
        }

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

        private UIItem FindControl(Window window, Dictionary<string, string> criteria)
        {
            return null;
        }

        /// <summary>
        /// create an UIA action for the line
        /// </summary>
        /// <param name="actLine">the action line</param>
        /// <returns>the UIA action</returns>
        public override abt.Action createAction(abt.ActionLine actLine)
        {
            Window targetWindow = null;
            UIItem targetControl = null;

            if (Actions[actLine.ActionName] == null)
                throw new Exception(abt.Constants.Messsages.Error_Executing_NoAction);
            if (actLine.WindowName != null && Parent.Interfaces[actLine.WindowName] == null)
                throw new Exception(abt.Constants.Messsages.Error_Matching_Window_NoDefinition);

            // search for the target control
            if (actLine.WindowName != null)
                targetControl = targetWindow = FindWindow(Parent.Interfaces[actLine.WindowName].Properties);
            if (actLine.ControlName != null)
                targetControl = FindControl(targetWindow, Parent.Interfaces[actLine.WindowName].Controls[actLine.ControlName]);

            // prepare the action
            UIAAction action = Actions[actLine.ActionName] as UIAAction;
            action.Control = targetControl;
            foreach (string key in actLine.Arguments.Keys)
                action.Params[key] = actLine.Arguments[key];

            return action;
        }
    }
}

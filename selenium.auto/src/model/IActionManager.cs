using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selenium_auto.model
{
    public interface IActionManager
    {
        /// <summary>
        /// register an action to ActionManager
        /// </summary>
        /// <param name="action">the action to be registered</param>
        void RegisterAction(IAction action);

        /// <summary>
        /// create an action for the line
        /// </summary>
        /// <param name="actLine">the action line</param>
        /// <returns>the action</returns>
        IAction getAction(ActionLine actLine);
    }
}

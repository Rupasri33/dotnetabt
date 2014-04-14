using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace abt
{
    public class Automation
    {
        /// <summary>
        /// construct a default Automation engine
        /// </summary>
        public Automation()
        {
            Interfaces = new Dictionary<string, Interface>();
            Scripts = new Queue<Script>();
            ActionManagers = new List<ActionManager>();
        }

        /// <summary>
        /// construct an Automation Engine
        /// </summary>
        /// <param name="manager">the action manager</param>
        public Automation(ActionManager manager)
            : this()
        {
            ActionManagers.Add(manager);
        }

        /// <summary>
        /// get corresponding Action object from all Action Managers
        /// </summary>
        /// <param name="actLine">the action line</param>
        /// <returns>the found action</returns>
        private Action getAction(ActionLine actLine)
        {
            int i = 0;
            Action action = null;
            while (action == null && i < ActionManagers.Count)
                action = ActionManagers[i++].getAction(actLine);

            return action;
        }

        /// <summary>
        /// execute the script
        /// </summary>
        /// <returns></returns>
        public int Run()
        {
            while (Scripts.Count > 0)
            {
                CurrentScript = Scripts.Dequeue();

                while (CurrentScript.HasNextLine)
                {
                    ActionLine actLine = CurrentScript.Next();
                    Action action = getAction(actLine);
                    if (action == null)
                        throw new InvalidOperationException("No action named '" + actLine.ActionName + "'");

                    if (action.Name == "use interface")
                    {
                    }
                    else if (action.Name == "run script")
                    {
                    }
                    else if (action.IsValid())
                    {
                        action.Execute();
                        action.Reset();
                    }
                }
            }
            return 0;
        }

        /// <summary>
        /// executing script
        /// </summary>
        public Script CurrentScript { get; private set; }

        /// <summary>
        /// executing scripts queue
        /// </summary>
        public Queue<Script> Scripts { get; private set; }

        /// <summary>
        /// current data table
        /// </summary>
        public Data Data { get; set; }

        /// <summary>
        /// the action manager
        /// </summary>
        public List<ActionManager> ActionManagers { get; private set; }

        /// <summary>
        /// current list of loaded interfaces
        /// </summary>
        public Dictionary<string, Interface> Interfaces { get; private set; }
    }
}

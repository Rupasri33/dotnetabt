using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace abt
{
    public abstract class Automation
    {
        /// <summary>
        /// construct an Automation Engine
        /// </summary>
        /// <param name="manager">the action manager</param>
        public Automation(ActionManager manager)
        {
            Interfaces = new Dictionary<string, Interface>();
            Scripts = new Queue<Script>();
            ActionManager = manager;
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
                    Action action = ActionManager.createAction(actLine);
                    if (action == null)
                        throw new InvalidOperationException("No action named '" + actLine.ActionName + "'");

                    if (action.Name == "use interface")
                    {
                    }
                    else if (action.Name == "run script")
                    {
                    }
                    else if (action.IsValid())
                        action.Execute();
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
        public ActionManager ActionManager { get; private set; }

        /// <summary>
        /// current list of loaded interfaces
        /// </summary>
        public Dictionary<string, Interface> Interfaces { get; private set; }
    }
}

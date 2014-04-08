using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace abt
{
    public class Automation
    {
        /// <summary>
        /// constructor from a Script and a Data
        /// </summary>
        /// <param name="script">the executing script</param>
        /// <param name="data">the data-driven data set</param>
        public Automation(Script script = null, Data data = null)
        {
            Interfaces = new Dictionary<string, Interface>();
            ActionManager = new ActionManager();
            Scripts = new Queue<Script>();
            CurrentScript = script;
            Data = data;
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
                    else
                        action.Execute();
                }
            }
            return 0;
        }

        /// <summary>
        /// executing script
        /// </summary>
        public Script CurrentScript { get; protected set; }

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Script = script;
            Data = data;
        }

        /// <summary>
        /// execute the script
        /// </summary>
        /// <returns></returns>
        public int Run()
        {
            for (int i = 0; i < Script.ActionLines.Count; i++)
            {
                Action action = ActionManager.createAction(Script.ActionLines[i]);
                if (action == null)
                    throw new InvalidOperationException("No action named '" + Script.ActionLines[i].ActionName + "'");

                if (action.Name == "use interface")
                {
                }
                else
                    action.Execute();
            }

            return 0;
        }

        /// <summary>
        /// executing script
        /// </summary>
        public Script Script { get; set; }

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

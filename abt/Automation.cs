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
            Scripts = new Stack<Script>();
            ActionManagers = new List<ActionManager>();
        }

        /// <summary>
        /// construct an Automation Engine
        /// </summary>
        /// <param name="manager">the action manager</param>
        public Automation(ActionManager manager, IFileParser _parser)
            : this()
        {
            ActionManagers.Add(manager);
            Parser = _parser;
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
                CurrentScript = Scripts.Pop();

                while (CurrentScript.HasNextLine)
                {
                    ActionLine actLine = CurrentScript.Next();

                    if (actLine.ActionName == Constants.ActionUseInterface)
                    {
                        Interface newInterface = new Interface(Parser.NewInstance);
                        newInterface.Path = actLine.Arguments[Constants.KeywordInterface];
                        Interfaces.Add(newInterface.Name, newInterface);
                    }
                    else if (actLine.ActionName == Constants.ActionStartScript)
                    {
                        Script newScript = new Script(Parser.NewInstance);
                        newScript.Path = actLine.Arguments[Constants.KeywordScript];
                        Scripts.Push(CurrentScript);
                        CurrentScript = newScript;
                    }
                    else
                    {
                        Action action = getAction(actLine);
                        if (action == null)
                            throw new InvalidOperationException("No action named '" + actLine.ActionName + "'");
                        if (!action.IsValid())
                            throw new InvalidOperationException("Invalid arguments for action named '" + actLine.ActionName + "'");

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
        /// executing scripts stack
        /// </summary>
        public Stack<Script> Scripts { get; private set; }

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

        public IFileParser Parser { get; private set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace abt
{
    public delegate void StartedHandler(Automation at);
    public delegate void EndedHandler(Automation at);
    public delegate void InteruptedHandler(Automation at);
    public delegate void PausedHandler(Automation at);
    public delegate void ResumedHandler(Automation at);

    public class Automation
    {
        /// <summary>
        /// construct a default Automation engine
        /// </summary>
        /// <param name="workingDir">the working directory</param>
        public Automation(string workingDir = "")
        {
            Interfaces = new Dictionary<string, Interface>();
            Scripts = new Stack<Script>();
            ActionManagers = new List<ActionManager>();
            WorkingDir = workingDir;
        }

        /// <summary>
        /// construct an Automation Engine
        /// </summary>
        /// <param name="parser">the file parser</param>
        /// <param name="workingDir">the working directory</param>
        public Automation(IFileParser parser, IReporter reporter, string workingDir = "")
            : this(workingDir)
        {
            Parser = parser;
            Parser.WorkingDir = WorkingDir;

            Reporter = reporter;
            Reporter.WorkingDir = WorkingDir;
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
                        newInterface.FileName = actLine.Arguments[Constants.KeywordInterface] + Parser.FileExtension;
                        Interfaces.Add(newInterface.Name, newInterface);
                    }
                    else if (actLine.ActionName == Constants.ActionStartScript)
                    {
                        Script newScript = new Script(Parser.NewInstance);
                        newScript.FileName = actLine.Arguments[Constants.KeywordScript] + Parser.FileExtension;
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

        /// <summary>
        /// the file parser use for all source file
        /// </summary>
        public IFileParser Parser { get; private set; }

        /// <summary>
        /// the reporter of the automation
        /// </summary>
        public IReporter Reporter { get; private set; }

        /// <summary>
        /// the working directory
        /// </summary>
        public string WorkingDir { get; set; }

        /// <summary>
        /// the automation has just started
        /// </summary>
        public event StartedHandler Started;

        /// <summary>
        /// the automation has just ended
        /// </summary>
        public event EndedHandler Ended;

        /// <summary>
        /// the automation has just interupted
        /// </summary>
        public event InteruptedHandler Interupted;

        /// <summary>
        /// the automation has just paused
        /// </summary>
        public event PausedHandler Paused;

        /// <summary>
        /// the automation has just resumed
        /// </summary>
        public event ResolveEventHandler Resumed;

        public void Start()
        {
        }

        public void Interupt()
        {
        }

        public void Pause()
        {
        }

        public void Resume()
        {
        }
    }
}

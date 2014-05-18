using System;
using System.Collections.Generic;
using System.Threading;

using abt.model;

namespace abt.auto
{
    public class Automation : IAutomation
    {
        /// <summary>
        /// construct a default Automation engine
        /// </summary>
        /// <param name="workingDir">the working directory</param>
        public Automation(string workingDir = "")
        {
            Interfaces = new Dictionary<string, IInterface>();
            Scripts = new Stack<IScript>();
            ActionManagers = new List<IActionManager>();

            WorkingDir = workingDir;
            Speed = 10;
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
        private IAction getAction(ActionLine actLine)
        {
            int i = 0;
            IAction action = null;
            while (action == null && i < ActionManagers.Count)
                action = ActionManagers[i++].getAction(actLine);

            return action;
        }

        /// <summary>
        /// check if the automation is in 'paused' state
        /// </summary>
        private void CheckPaused()
        {
            if (IsPausing)
            {
                IsPausing = false;
                IsPaused = true;
                if (Paused != null)
                    Paused(this);
            }
            while (IsPaused)
                Thread.Sleep(100);

            CheckResumed();
        }

        /// <summary>
        /// check if the automation is being resumed
        /// </summary>
        private void CheckResumed()
        {
            if (IsResuming)
            {
                IsResuming = false;
                IsResumed = true;

                if (Resumed != null)
                    Resumed(this);
            }
        }

        /// <summary>
        /// check if the automation is in 'stopped' state
        /// </summary>
        private void CheckStopped()
        {
            if (IsStopping)
            {
                IsStopping = false;
                IsStopped = true;

                if (Interupted != null)
                    Interupted(this);
            }
        }

        /// <summary>
        /// run all automation
        /// </summary>
        private void RunAll()
        {
            if (Data != null)
            {
                // create new report
                IReporter reporter = Reporter.NewInstance;
                reporter.BeginReport(@"runName");

                while (Data.MoveNext())
                {
                    reporter.BeginDataRow(Data.CurrentRowId);

                    StartScript.Restart();
                    Scripts.Push(StartScript);
                    Run(reporter);

                    reporter.EndDataRow();
                }
            }
            else
            {
                // create new report
                IReporter reporter = Reporter.NewInstance;
                reporter.BeginReport(@"runName" + @" - No data set");
                reporter.BeginDataRow(0);

                StartScript.Restart();
                Scripts.Push(StartScript);
                Run(reporter);

                reporter.EndDataRow();
                reporter.EndReport();
            }

            if (Ended != null)
                Ended(this);
        }

        /// <summary>
        /// execute the script
        /// </summary>
        private void Run(IReporter reporter)
        {
            while (Scripts.Count > 0 && !IsStopping)
            {
                // if the automation is paused, just sleep
                CheckPaused();

                // pop a script from stack
                CurrentScript = Scripts.Pop();

                // begin new section in report
                if (CurrentScript.CurrentLineNumber == 0)
                    reporter.BeginScript(CurrentScript.Name);

                // loop for each line of current script
                while (CurrentScript.HasNextLine && !IsStopping)
                {
                    // if the automation is paused, just sleep
                    CheckPaused();

                    // get a action line from script
                    ActionLine actLine = CurrentScript.Next();

                    // the action is 'use interface'
                    if (actLine.ActionName == Constants.ActionUseInterface)
                    {
                        IInterface newInterface = new Interface(Parser.NewInstance);
                        newInterface.FileName = actLine.Arguments[Constants.KeywordInterface] + Parser.FileExtension;
                        Interfaces.Add(newInterface.Name, newInterface);
                    }
                    // the action is 'run script'
                    else if (actLine.ActionName == Constants.ActionStartScript)
                    {
                        Script newScript = new Script(Parser.NewInstance);
                        newScript.FileName = actLine.Arguments[Constants.KeywordScript] + Parser.FileExtension;

                        // push current script to stack and run new script
                        Scripts.Push(CurrentScript);
                        CurrentScript = newScript;

                        // begin new section in report
                        reporter.BeginScript(CurrentScript.Name);
                    }
                    else
                    {
                        IAction action = getAction(actLine);
                        if (action == null)
                            throw new InvalidOperationException("No action named '" + actLine.ActionName + "'");
                        if (!action.IsValid())
                            throw new InvalidOperationException("Invalid arguments for action named '" + actLine.ActionName + "'");

                        // execute the action
                        int ret = action.Execute();
                        action.Reset();

                        // write result of executing to report
                        reporter.WriteLine();
                    }

                    ProcessSpeed();
                }

                // check if user interupt the automation
                CheckStopped();

                // end section in report
                if (CurrentScript.CurrentLineNumber > 0)
                    reporter.EndScript();
            }

            // check if user interupt the automation
            CheckStopped();
        }

        /// <summary>
        /// process delaying based on the automation speed
        /// </summary>
        private void ProcessSpeed()
        {
            if (Speed < 0) Speed = 0;
            if (Speed > 10) Speed = 10;

            Thread.Sleep((10 - Speed) * 200);
        }

        /// <summary>
        /// start the automation
        /// </summary>
        public void Start()
        {
            if (CurrentThread != null && CurrentThread.IsAlive)
                return;

            CurrentThread = new Thread(RunAll);
            CurrentThread.Start();

            if (Started != null)
                Started(this);
        }

        /// <summary>
        /// interupt the automation
        /// </summary>
        public void Interupt()
        {
            IsStopped = true;
        }

        /// <summary>
        /// pause the automation
        /// </summary>
        public void Pause()
        {
            IsPaused = true;
        }

        /// <summary>
        /// resume the automation
        /// </summary>
        public void Resume()
        {
            IsPaused = false;
        }

        /// <summary>
        /// the starting script, used with data set
        /// </summary>
        public IScript StartScript { get; set; }

        /// <summary>
        /// executing script
        /// </summary>
        public IScript CurrentScript { get; private set; }

        /// <summary>
        /// executing scripts stack
        /// </summary>
        public Stack<IScript> Scripts { get; private set; }

        /// <summary>
        /// current data table
        /// </summary>
        public IData Data { get; set; }

        /// <summary>
        /// the action manager
        /// </summary>
        public List<IActionManager> ActionManagers { get; private set; }

        /// <summary>
        /// current list of loaded interfaces
        /// </summary>
        public Dictionary<string, IInterface> Interfaces { get; private set; }

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
        /// speed of running automation, from 1 to 10
        /// </summary>
        public int Speed { get; set; }

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
        public event ResumedHandler Resumed;

        /// <summary>
        /// current automation thread
        /// </summary>
        protected Thread CurrentThread { get; set; }

        /// <summary>
        /// the paused state of the automation
        /// </summary>
        private bool IsPaused { get; set; }

        /// <summary>
        /// the automation is being paused
        /// </summary>
        private bool IsPausing { get; set; }

        /// <summary>
        /// the resumed state of the automation
        /// </summary>
        private bool IsResumed { get; set; }

        /// <summary>
        /// the automation is being resumed
        /// </summary>
        private bool IsResuming { get; set; }

        /// <summary>
        /// the ended state of the automation
        /// </summary>
        private bool IsStopped { get; set; }

        /// <summary>
        /// the automation is being stopped
        /// </summary>
        private bool IsStopping { get; set; }
    }
}

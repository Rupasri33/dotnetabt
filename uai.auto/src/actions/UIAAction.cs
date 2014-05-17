using System;
using System.Collections.Generic;

using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems;

using uia_auto.model;

namespace uia_auto.actions
{
    public abstract class UIAAction : IAction
    {
        Dictionary<string, string> m_Params;

        /// <summary>
        /// name of the action
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// parameters of the action
        /// </summary>
        public virtual Dictionary<string, string> Params
        {
            get { return m_Params; }
            set
            {
                foreach (string key in value.Keys)
                    Params.Add(key, value[key]);
            }
        }

        /// <summary>
        /// constructor
        /// </summary>
        public UIAAction()
        {
            m_Params = new Dictionary<string, string>();
        }

        /// <summary>
        /// check if the parameters are valid for executing
        /// derived class should re-implement this function
        /// </summary>
        /// <returns>true - if parameters are ready for executing</returns>
        public virtual bool IsValid()
        {
            return true;
        }

        /// <summary>
        /// the UIA control to be automated
        /// </summary>
        public Window Window { get; set; }

        /// <summary>
        /// the UIA control to be automated
        /// </summary>
        public IUIItem Control { get; set; }

        /// <summary>
        /// execute the action
        /// derived class should re-implement this function for actual executing
        /// </summary>
        /// <returns>0 - if executing sucessfully</returns>
        public abstract int Execute();

        /// <summary>
        /// reset action after executing
        /// </summary>
        public virtual void Reset()
        {
            Params.Clear();

            Window = null;
            Control = null;
        }
    }
}

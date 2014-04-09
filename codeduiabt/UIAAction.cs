using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems;

namespace codeduiabt
{
    abstract class UIAAction : abt.Action
    {
        /// <summary>
        /// the UIA control to be automated
        /// </summary>
        public UIItem Control { get; set; }

        /// <summary>
        /// construct an UIA action
        /// </summary>
        /// <param name="control">the UIA control</param>
        /// <param name="_params">other action's paramaters</param>
        public UIAAction(UIItem control, Dictionary<string, string> _params)
        {
            Control = control;
            foreach (string key in _params.Keys)
                Params.Add(key, _params[key]);
        }

        /// <summary>
        /// reset action parameters after executing
        /// </summary>
        public override void Reset()
        {
            Control = null;
            base.Reset();
        }
    }
}

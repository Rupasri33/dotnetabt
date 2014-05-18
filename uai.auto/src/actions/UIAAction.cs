using System;
using System.Collections.Generic;

using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems;

using abt.model;
using abt.auto;

namespace uia_auto.actions
{
    public class UIAAction : abt.auto.Action
    {
        /// <summary>
        /// the UIA control to be automated
        /// </summary>
        public Window Window { get; set; }

        /// <summary>
        /// the UIA control to be automated
        /// </summary>
        public IUIItem Control { get; set; }

        /// <summary>
        /// reset action after executing
        /// </summary>
        public override void Reset()
        {
            base.Reset();

            Window = null;
            Control = null;
        }
    }
}

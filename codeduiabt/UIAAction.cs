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
        public Window Window { get; set; }

        /// <summary>
        /// the UIA control to be automated
        /// </summary>
        public IUIItem Control { get; set; }

        /// <summary>
        /// reset action parameters after executing
        /// </summary>
        public override void Reset()
        {
            Window = null;
            Control = null;
            base.Reset();
        }
    }
}

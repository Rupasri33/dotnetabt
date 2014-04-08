using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using abt;

namespace seleniumabt
{
    /// <summary>
    /// represent action click using selenium library
    /// </summary>
    public class ActionClick : SeleniumAction
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="line">the action line in raw text</param>
        public ActionClick(ActionLine line)
            : base(line)
        {
            Name = @"click";
        }

        /// <summary>
        /// check if the parameters are valid
        /// </summary>
        /// <returns></returns>
        public override bool IsValid()
        {
            
            return base.IsValid();
        }

        /// <summary>
        /// do the click
        /// </summary>
        /// <returns>0 if sucessful</returns>
        public override int Execute()
        {
            return 0;
        }
    }
}

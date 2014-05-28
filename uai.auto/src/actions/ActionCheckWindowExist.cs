using System;
using System.Collections.Generic;

using abt.model;

namespace uia_auto.actions
{
    class ActionCheckWindowExist : UIAAction
    {
        /// <summary>
        /// constructor
        /// </summary>
        public ActionCheckWindowExist()
        {
            Name = @"check window exist";
        }

        /// <summary>
        /// executing the action
        /// </summary>
        /// <returns>true - if click success</returns>
        public override int Execute()
        {
            Result = ActionResult.FAILED;

            if (Window != null)
                Result = ActionResult.PASSED;

            return 0;
        }
    }
}

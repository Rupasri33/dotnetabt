using System;
using System.Collections.Generic;

using abt.model;

namespace uia_auto.actions
{
    class ActionCheckControlExist : UIAAction
    {
        public ActionCheckControlExist()
        {
            Name = @"check control exist";
        }

        /// <summary>
        /// executing the action
        /// </summary>
        /// <returns>true - if click success</returns>
        public override int Execute()
        {
            Result = ActionResult.FAILED;

            if (Control != null)
                Result = ActionResult.PASSED;

            return 0;
        }
    }
}

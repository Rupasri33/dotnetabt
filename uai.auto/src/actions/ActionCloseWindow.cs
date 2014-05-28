using System;
using System.Collections.Generic;

namespace uia_auto.actions
{
    internal class ActionCloseWindow : UIAAction
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public ActionCloseWindow()
        {
            Name = @"close window";
        }

        /// <summary>
        /// check whether the parameters are valid
        /// </summary>
        /// <returns>true - if params are valid</returns>
        public override bool IsValid()
        {
            if (Window == null)
                throw new Exception(Constants.Messages.Error_Matching_Window_NotFound);

            return true;
        }

        /// <summary>
        /// executing the action
        /// </summary>
        /// <returns>true - if close window successfully</returns>
        public override int Execute()
        {
            Window.Close();

            return 0;
        }
    }
}

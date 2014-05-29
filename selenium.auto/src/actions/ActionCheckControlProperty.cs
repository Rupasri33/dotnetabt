using System;
using System.Collections.Generic;

using OpenQA.Selenium;

using abt.model;

namespace selenium_auto.actions
{
    class ActionCheckControlProperty : SeleniumAction
    {
        /// <summary>
        /// name of property to be checked
        /// </summary>
        private string PropertyName { get; set; }

        /// <summary>
        /// value of property to be checked
        /// </summary>
        private string PropertyValue { get; set; }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="webDriver"></param>
        public ActionCheckControlProperty(IWebDriver webDriver)
            : base(webDriver)
        {
            Name = @"check control property";
        }

        /// <summary>
        /// set parameters to action
        /// </summary>
        public override Dictionary<string, string> Params
        {
            set
            {
                base.Params = value;

                if (Params.ContainsKey(@"name"))
                    PropertyName = Params[@"name"];
                if (Params.ContainsKey(@"value"))
                    PropertyValue = Params[@"value"];
            }
        }

        /// <summary>
        /// check whether the parameters are valid
        /// </summary>
        /// <returns>true - if params are valid</returns>
        public override bool IsValid()
        {
            if (Control == null)
                throw new Exception(Constants.Messages.Error_Matching_Control_NotFound);

            // the coordinate is specified
            if (PropertyName == null || PropertyValue == null)
                return false;

            return true;
        }

        /// <summary>
        /// executing the action
        /// </summary>
        /// <returns>true - if click success</returns>
        public override int Execute()
        {
            Result = ActionResult.ERROR;

            if (Constants.PropertyNames.Text.Equals(PropertyName, StringComparison.CurrentCultureIgnoreCase))
                Result = Control.Text == PropertyValue ? ActionResult.PASSED : ActionResult.FAILED;
            else
            {
                string realValue = Control.GetAttribute(PropertyName);
                if (realValue != null && realValue == PropertyValue)
                    Result = ActionResult.PASSED;
                else
                    Result = ActionResult.FAILED;
            }

            return base.Execute();
        }

        /// <summary>
        /// reset action after executing
        /// </summary>
        public override void Reset()
        {
            base.Reset();
            PropertyName = PropertyValue = null;
        }
    }
}

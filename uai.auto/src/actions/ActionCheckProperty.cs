using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using abt.model;
using uia_auto;

namespace uia_auto.actions
{
    class ActionCheckProperty : UIAAction
    {
        /// <summary>
        /// name of property to be checked
        /// </summary>
        private string PropertyName { get; set; }

        /// <summary>
        /// value of property to be checked
        /// </summary>
        private string PropertyValue { get; set; }

        public ActionCheckProperty()
        {
            Name = @"check property";
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
            // the UIA control exists
            if (Control == null)
                return false;

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

            if (Constants.PropertyNames.AutomationId.Equals(PropertyName, StringComparison.CurrentCultureIgnoreCase))
                Result = Control.AutomationElement.Current.AutomationId == PropertyValue ? ActionResult.PASSED : ActionResult.FAILED;
            else if (Constants.PropertyNames.Id.Equals(PropertyName, StringComparison.CurrentCultureIgnoreCase))
                Result = Control.Id == PropertyValue ? ActionResult.PASSED : ActionResult.FAILED;
            else if (Constants.PropertyNames.Name.Equals(PropertyName, StringComparison.CurrentCultureIgnoreCase))
                Result = Control.Name == PropertyValue ? ActionResult.PASSED : ActionResult.FAILED;
            else if (Constants.PropertyNames.Text.Equals(PropertyName, StringComparison.CurrentCultureIgnoreCase))
                Result = Control.Name == PropertyValue ? ActionResult.PASSED : ActionResult.FAILED;
            else if (Constants.PropertyNames.Title.Equals(PropertyName, StringComparison.CurrentCultureIgnoreCase))
                Result = Control.Name == PropertyValue ? ActionResult.PASSED : ActionResult.FAILED;

            return 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.AccessControl;

using TestStack.White;

namespace codeduiabt.actions
{
    internal class ActionStartProgram : UIAAction
    {
        private string ProgramPath { get; set; }

        /// <summary>
        /// default constructor
        /// </summary>
        public ActionStartProgram()
        {
            Name = "start program";
        }

        /// <summary>
        /// set parameters to action
        /// </summary>
        public override Dictionary<string, string> Params
        {
            set
            {
                base.Params = value;

                if (Params.ContainsKey(@"path"))
                    ProgramPath = Params[@"path"];
            }
        }

        /// <summary>
        /// check whether the parameters are valid
        /// </summary>
        /// <returns>true - if params are valid</returns>
        public override bool IsValid()
        {
            if (ProgramPath == null || ProgramPath.Length == 0)
                return false;

            FileInfo file = new FileInfo(ProgramPath);
            if (!file.Exists)
                return false;
            
            return true;
        }

        /// <summary>
        /// executing the action
        /// </summary>
        /// <returns>true - if start program successfully</returns>
        public override int Execute()
        {
            Application.Launch(ProgramPath);

            return 0;
        }
    }
}

using System;
using System.Collections.Generic;

namespace abt.model
{
    public interface IReporter
    {
        /// <summary>
        /// create new report
        /// </summary>
        /// <param name="name">name of the report</param>
        /// <param name="datasetName">name of the dataset</param>
        void BeginReport(string name, string datasetName);

        /// <summary>
        /// close current report and save to file
        /// </summary>
        void EndReport();

        /// <summary>
        /// begin new section 'data row' in current report
        /// </summary>
        /// <param name="id">row id</param>
        void BeginDataRow(int id);

        /// <summary>
        /// end current 'data row' section
        /// </summary>
        /// <param name="id">row id</param>
        void EndDataRow(int id);

        /// <summary>
        /// begin new section 'script' in current report
        /// </summary>
        /// <param name="scriptName">name of the script</param>
        void BeginScript(string scriptName);

        /// <summary>
        /// end current 'script' section
        /// </summary>
        /// <param name="scriptName">name of the script</param>
        void EndScript(string scriptName);

        /// <summary>
        /// write a line to the report
        /// </summary>
        /// <param name="actLine">information about the action</param>
        /// <param name="result">result of the action</param>
        void WriteLine(ActionLine actLine, ActionResult result);

        /// <summary>
        /// write an error to the report
        /// </summary>
        /// <param name="actLine">the error action line</param>
        /// <param name="why">the reason</param>
        void WriteError(ActionLine actLine, string why);

        /// <summary>
        /// the working directory
        /// </summary>
        string WorkingDir { get; set; }

        /// <summary>
        /// default extension of the report file
        /// </summary>
        string FileExtension { get; }

        /// <summary>
        /// create new report instance
        /// </summary>
        IReporter NewInstance { get; }
    }
}

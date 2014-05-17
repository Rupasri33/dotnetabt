using System;
using System.Collections.Generic;

using uia_auto.model;

namespace uia_auto.file_parser
{
    public class SourceFile : ISourceFile
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="parser"></param>
        public SourceFile(IFileParser parser)
        {
            Parser = parser;
            parser.FileParsed += ProcessLoadedData;
        }

        /// <summary>
        /// path to the source file
        /// </summary>
        public string FileName {
            get { return Parser.FileName; }
            set
            {
                Parser.FileName = value;
            }
        }

        /// <summary>
        /// name of the source file
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// lines of the source file
        /// </summary>
        public List<SourceLine> Lines { get; private set; }

        /// <summary>
        /// the file parser
        /// </summary>
        public IFileParser Parser { get; private set; }

        /// <summary>
        /// process data from parser
        /// </summary>
        protected virtual void ProcessLoadedData()
        {
            Lines = Parser.Lines;
        }

        /// <summary>
        /// load data from file
        /// </summary>
        public void Load()
        {
        }

        /// <summary>
        /// save data back to file
        /// </summary>
        public void Save()
        {
        }
    }
}

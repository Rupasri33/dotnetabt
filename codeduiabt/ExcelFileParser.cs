using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using abt;

using ExcelLibrary.BinaryFileFormat;
using ExcelLibrary.CompoundDocumentFormat;
using ExcelLibrary.SpreadSheet;

namespace codeduiabt
{
    public class ExcelFileParser : IFileParser
    {
        private string m_Name;
        public ExcelFileParser()
        {
            Lines = new List<SourceLine>();
        }

        /// <summary>
        /// name of the file
        /// </summary>
        public string Name
        {
            get { return m_Name; }
            set
            {
                if (Parse(WorkingDir + value))
                    m_Name = value;
            }
        }

        /// <summary>
        /// parsed source line
        /// </summary>
        public List<SourceLine> Lines { get; private set; }

        /// <summary>
        /// new instance copied
        /// </summary>
        public IFileParser NewInstance
        {
            get
            { 
                IFileParser newInt = new ExcelFileParser();
                newInt.WorkingDir = WorkingDir;
                return newInt;
            }
        }

        private bool Parse(string path)
        {
            CompoundDocument doc = CompoundDocument.Load(path);
            if (doc == null)
                throw new InvalidOperationException(Constants.Messages.Error_ExcelFileNotFound);

            Lines.Clear();
            byte[] bookdata = doc.GetStreamData("Workbook");
            if (bookdata == null)
                throw new InvalidOperationException(Constants.Messages.Error_ExcelFileNoWorkbook);

            Workbook workbook = WorkbookDecoder.Decode(new MemoryStream(bookdata));
            if (workbook.Worksheets.Count == 0)
                throw new InvalidOperationException(Constants.Messages.Error_ExcelFileNoWorksheet);

            Worksheet sheet = workbook.Worksheets[0];
            for (int rowIndex = sheet.Cells.FirstRowIndex; rowIndex <= sheet.Cells.LastRowIndex; rowIndex++)
            {
                SourceLine line = new SourceLine();
                Row row = sheet.Cells.GetRow(rowIndex);
                for (int colIndex = row.FirstColIndex; colIndex <= row.LastColIndex; colIndex++)
                {
                    Cell cell = row.GetCell(colIndex);
                    line.Columns.Add(cell.StringValue);
                }
                Lines.Add(line);
            }

            doc.Close();
            if (this.FileParsed != null)
                this.FileParsed();

            return true;
        }

        /// <summary>
        /// file parsed successfully
        /// </summary>
        public event FileParsed FileParsed;

        /// <summary>
        /// the working dir of the parser
        /// </summary>
        public string WorkingDir { get; set; }


        public string FileExtension
        {
            get { return @".xls"; }
        }
    }
}

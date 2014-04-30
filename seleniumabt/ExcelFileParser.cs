using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using abt;

using ExcelLibrary.BinaryFileFormat;
using ExcelLibrary.CompoundDocumentFormat;
using ExcelLibrary.SpreadSheet;

namespace seleniumabt
{
    public class ExcelFileParser : IFileParser
    {
        private string m_Path;
        public ExcelFileParser()
        {
            Lines = new List<SourceLine>();
        }

        public string Path
        {
            get
            {
                return m_Path;
            }
            set
            {
                if (Parse(value))
                    m_Path = value;
            }
        }

        public List<SourceLine> Lines { get; private set; }

        public IFileParser NewInstance
        {
            get { return new ExcelFileParser(); }
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
            
            return false;
        }
    }
}

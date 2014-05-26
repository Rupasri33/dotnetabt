using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using abt.model;

using ExcelLibrary.BinaryFileFormat;
using ExcelLibrary.CompoundDocumentFormat;
using ExcelLibrary.SpreadSheet;

namespace abt.auto
{
    public class ExcelFileParser : IFileParser
    {
        private string m_FileName;
        private string m_WorksheetName;

        /// <summary>
        /// default constructor
        /// </summary>
        public ExcelFileParser()
        {
            Lines = new List<SourceLine>();
            m_WorksheetName = @"No name";
        }

        /// <summary>
        /// name of the file
        /// </summary>
        public string FileName
        {
            get { return m_FileName; }
            set
            {
                m_FileName = value;
                Parse(WorkingDir + value);
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

        /// <summary>
        /// parse the source file
        /// </summary>
        /// <param name="path">the file path</param>
        /// <returns>return true if parse successfully</returns>
        private bool Parse(string path)
        {
            try
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
                m_WorksheetName = sheet.Name;
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
                return true;
            }
            catch
            {
                Lines.Clear();
                throw;
            }
            finally
            {
                if (this.FileParsed != null)
                    this.FileParsed();
            }
        }

        /// <summary>
        /// file parsed successfully
        /// </summary>
        public event FileParsed FileParsed;

        /// <summary>
        /// the working dir of the parser
        /// </summary>
        public string WorkingDir { get; set; }

        /// <summary>
        /// default extension of the file parser
        /// </summary>
        public string FileExtension
        {
            get { return @".xls"; }
        }

        /// <summary>
        /// save data back to file
        /// </summary>
        public void Save(string worksheetName = null)
        {
            try
            {
                Workbook workbook = new Workbook();
                Worksheet worksheet = new Worksheet(worksheetName == null ? m_WorksheetName : worksheetName);

                for (int i = 0; i < Lines.Count; i++)
                {
                    for (int j = 0; j < Lines[i].ColumnCount; j++)
                        worksheet.Cells[i, j] = new Cell(Lines[i].Columns[j]);
                }

                int workaround = 100 - Lines.Count;
                for (int i = 0; i < workaround; i++)
                    worksheet.Cells[Lines.Count + i, 0] = new Cell(@"");

                workbook.Worksheets.Add(worksheet);
                workbook.Save(WorkingDir + FileName + FileExtension);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// create a new file
        /// </summary>
        /// <param name="fileName">the file name</param>
        public void Create(string fileName)
        {
            m_FileName = fileName;

            if (FileParsed != null)
                FileParsed();
        }
    }
}

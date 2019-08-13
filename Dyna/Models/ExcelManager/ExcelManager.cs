using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClosedXML.Excel;

namespace Dyna.Models.ExcelManager
{
    public class ExcelManager
    {
        //string _path;
        XLWorkbook workBook;
        IXLWorksheet workSheet;
        public IXLRangeRows Rows { get; set; }
        public ExcelManager()
        {
            workBook = new XLWorkbook();
            workSheet = workBook.Worksheets.Add("Report");
        }
        public ExcelManager(string path, int positionWorkSheet)
        {      
            workBook = new XLWorkbook(path);
            workSheet = workBook.Worksheet(positionWorkSheet);
        }
        public void ReadAll()
        {
            if (Rows == null)
            {
                Rows = workSheet.RangeUsed().RowsUsed();
            }
        }
        public void Dispose()
        {
            workBook.Dispose();
        }
    }
}
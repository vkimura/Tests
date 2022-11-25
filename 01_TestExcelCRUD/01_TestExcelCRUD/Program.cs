
using Microsoft.Office.Interop.Excel;
//using Microsoft.Office.Interop.Word;
using System;
using System.Runtime.InteropServices;

namespace OfficeInteropDemoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = @"C:\Users\vkimura\Documents\Projects\vcad\test-read-excel.xlsx";
            DisplayExcelCellValue(filename, 1, 1);
            Console.Read();
        }

        static void DisplayExcelCellValue(string filename,
        int row, int column)
        {
            Microsoft.Office.Interop.Excel.Application
            excelApplication = null;
            try
            {
                excelApplication = new
                Microsoft.Office.Interop.Excel.Application();
                Workbook excelWorkBook =
                excelApplication.Workbooks.Open(filename);
                string workbookName = excelWorkBook.Name;
                int worksheetcount = excelWorkBook.Worksheets.Count;

                if (worksheetcount > 0)
                {
                    Worksheet worksheet =
                   (Worksheet)excelWorkBook.Worksheets[1];
                    string firstworksheetname = worksheet.Name;
                    var data = ((Microsoft.Office.Interop.Excel.Range)
                    worksheet.Cells[row, column]).Value;
                    Console.WriteLine(data);
                }
                else
                {
                    Console.WriteLine("No worksheets available");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (excelApplication != null)
                {
                    excelApplication.Quit();
                    Marshal.FinalReleaseComObject(excelApplication);
                }
            }
        }
    }
}
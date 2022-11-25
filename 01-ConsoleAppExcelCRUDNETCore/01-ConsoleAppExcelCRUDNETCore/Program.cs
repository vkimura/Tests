using System;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace _01_ConsoleAppExcelCRUDNETCore
{
    class Program
    {
        public static string filePath = @"C:\_TEMP\test_Excel.xlsx";
        static void Main(string[] args)
        {
            CreateExcelFile();
            //Console.WriteLine("Hello World!");
        }

        private static void CreateExcelFile()
        {
            Excel.Application xlApp = new Excel.Application();

            if (xlApp == null)
            {
                Console.WriteLine("Excel is not installed in the system...");
                return;
            }

            object misValue = System.Reflection.Missing.Value;

            Excel.Workbook xlWorkBook = xlApp.Workbooks.Add(misValue);
            Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            xlWorkSheet.Cells[1, 1] = "ID";
            xlWorkSheet.Cells[1, 2] = "Name";
            xlWorkSheet.Cells[2, 1] = "1001";
            xlWorkSheet.Cells[2, 2] = "Ramakrishna";
            xlWorkSheet.Cells[3, 1] = "1002";
            xlWorkSheet.Cells[3, 2] = "Praveenkumar";

            xlWorkBook.SaveAs(filePath, Excel.XlFileFormat.xlOpenXMLWorkbook, misValue, misValue, misValue, misValue,
                Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);

            xlWorkBook.Close();
            xlApp.Quit();

            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Excel file created successfully...");
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }


}

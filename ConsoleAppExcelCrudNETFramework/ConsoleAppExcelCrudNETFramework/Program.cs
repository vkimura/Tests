using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using Excel = Microsoft.Office.Interop.Excel;


namespace ConsoleAppExcelCrudNETFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create COM Objects. Create a COM object for everything that is referenced
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"C:\Users\vkimura\source\repos\ConsoleAppExcelCrudNETFramework\test.xls");

            string strFileName = @"C:\Users\vkimura\source\repos\ConsoleAppExcelCrudNETFramework\test.xls";
            object missing = System.Reflection.Missing.Value;
            Excel.Application excel = new Excel.Application();
            Excel.Workbook workBook = excel.Application.Workbooks.Open(strFileName, missing, true, missing, missing, missing,
            missing, missing, missing, true, missing, missing, missing, missing, missing);
            Excel.Worksheet worksheet = (Excel.Worksheet)workBook.Sheets[1];

            // print cell[1,1]
            Console.WriteLine("test");
            Console.WriteLine(worksheet.Cells[1, 1].Value);

            //Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            //Excel.Range xlRange = xlWorksheet.UsedRange;

            //int rowCount = xlRange.Rows.Count;
            //int colCount = xlRange.Columns.Count;

            ////iterate over the rows and columns and print to the console as it appears in the file
            ////excel is not zero based!!
            //for (int i = 1; i <= rowCount; i++)
            //{
            //    for (int j = 1; j <= colCount; j++)
            //    {
            //        //new line
            //        if (j == 1)
            //            Console.Write("\r\n");

            //        //write the value to the console
            //        if (xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value2 != null)
            //            Console.Write(xlRange.Cells[i, j].Value2.ToString() + "\t");

            //        //add useful things here!   
            //    }
            //}

            //cleanup
            //GC.Collect();
            //GC.WaitForPendingFinalizers();

            ////rule of thumb for releasing com objects:
            ////  never use two dots, all COM objects must be referenced and released individually
            ////  ex: [somthing].[something].[something] is bad

            ////release com objects to fully kill excel process from running in the background
            //Marshal.ReleaseComObject(xlRange);
            //Marshal.ReleaseComObject(xlWorksheet);

            ////close and release
            //xlWorkbook.Close();
            //Marshal.ReleaseComObject(xlWorkbook);

            ////quit and release
            //xlApp.Quit();
            //Marshal.ReleaseComObject(xlApp);
        }

        private static void CreateExcelFile()
        {
            string fileName, Sampletext;
            Console.Write("Enter File Name :");
            fileName = Console.ReadLine();

            Console.Write("Enter text :");
            Sampletext = Console.ReadLine();

            //Create excel app object
            Excel.Application xlSamp = new Microsoft.Office.Interop.Excel.Application();

            if (xlSamp == null)
            {
                Console.WriteLine("Excel is not Insatalled");
                Console.ReadKey();
                return;
            }

            //Create a new excel book and sheet
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            //Then add a sample text into first cell
            xlWorkBook = xlSamp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            xlWorkSheet.Cells[1, 1] = Sampletext;

            string location = @"C:\Users\vkimura\source\repos\ConsoleAppExcelCrudNETFramework\" + fileName + ".xls";
            xlWorkBook.SaveAs(location, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlSamp.Quit();
        }
    }
}

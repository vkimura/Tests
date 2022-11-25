using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Diagnostics;

namespace _01_WindowsFormsAppExcelRead
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    lblHelloWorld.Text = "Hello World";
        //}
        private void button1_Click(object sender, EventArgs e)
        {
            //readExcel();
            //writeExcel();
            string path = "C:\\Users\\vkimura\\source\\repos\\01-WindowsFormsAppExcelRead\\test2.xlsx";
            excel_init(path);
            string curValue = excel_getValue("A2");
            MessageBox.Show("get value for A2",curValue);

            //test set new value
            excel_setValue("A2", "A2-new");
            curValue = excel_getValue("A2");
            MessageBox.Show("get new value for A2", curValue);
            excel_close();
        }

        private void readExcel()
        {
            string filePath = "C:\\Users\\vkimura\\source\\repos\\01-WindowsFormsAppExcelRead\\test2.xlsx";

            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            Workbook wb;
            Worksheet ws;

            wb = excel.Workbooks.Open(filePath);
            ws = wb.Worksheets[1];

            Microsoft.Office.Interop.Excel.Range cell = ws.Range["A1:A2"];
            foreach (string Result in cell.Value)
            {
                MessageBox.Show(Result);

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void writeExcel()
        {
            //string filePath = "C:\\Users\\vkimura\\source\\repos\\01-WindowsFormsAppExcelRead\\test3.xlsx";

            //Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            //Workbook wb;
            //Worksheet ws;

            //wb = excel.Workbooks.Open(filePath);
            //ws = wb.Worksheets[1];

            //Microsoft.Office.Interop.Excel.Range cellRange = ws.Range["C1:F1"];
            //string[] things = new[] { "Hamburger", "Cars", "Trees", "Motorcycle" };

            //wb.SaveAs("C:\\Users\\vkimura\\source\\repos\\01-WindowsFormsAppExcelRead\\test3.xlsx");
            //wb.Close();

            //Process.Start("C:\\Users\\vkimura\\source\\repos\\01-WindowsFormsAppExcelRead\\test3.xlsx");
            //private static Microsoft.Office.Interop.Excel.ApplicationClass appExcel;
            
        }

        //Microsoft.Office.Interop.Excel.Application appExcel = new Microsoft.Office.Interop.Excel.Application();
        private static Workbook newWorkbook = null;
        private static _Worksheet objsheet = null;

        //Method to initialize opening Excel
        static void excel_init(String path)
        {
            Microsoft.Office.Interop.Excel.Application appExcel = new Microsoft.Office.Interop.Excel.Application();
            appExcel.Visible = true;
            //path = "C:\\Users\\vkimura\\source\\repos\\01-WindowsFormsAppExcelRead\\test2.xlsx";

            if (System.IO.File.Exists(path))
            {
                // then go and load this into excel
                newWorkbook = appExcel.Workbooks.Open(path, true, false);
                newWorkbook.ReadOnlyRecommended = false;
                objsheet = (_Worksheet)appExcel.ActiveWorkbook.ActiveSheet;
                MessageBox.Show("file opened");
            }
            else
            {
                Console.WriteLine("Unable to open file!");
                System.Runtime.InteropServices.Marshal.ReleaseComObject(appExcel);
                appExcel = null;
            }

        }
        static void excel_setValue(string cellname, string value)
        {
            objsheet.get_Range(cellname).set_Value(Type.Missing, value);
            newWorkbook.Save();
            newWorkbook.Close();
            
        }

        //Method to get value; cellname is A1,A2, or B1,B2 etc...in excel.
        static string excel_getValue(string cellname)
        {
            string value = string.Empty;
            try
            {
                value = objsheet.get_Range(cellname).get_Value().ToString();
            }
            catch
            {
                value = "";
            }

            return value;
        }

        //Method to close excel connection
        static void excel_close()
        {
            Microsoft.Office.Interop.Excel.Application appExcel = new Microsoft.Office.Interop.Excel.Application();
            if (appExcel != null)
            {
                try
                {
                    newWorkbook.Close();

                    System.Runtime.InteropServices.Marshal.ReleaseComObject(appExcel.ActiveWorkbook.ActiveSheet);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(appExcel.ActiveWorkbook);

                    System.Runtime.InteropServices.Marshal.ReleaseComObject(appExcel);
                    appExcel.Quit();
                    appExcel = null;
                    objsheet = null;

                    Process[] excelProcs = Process.GetProcessesByName("EXCEL");
                    foreach (Process proc in excelProcs)
                    {
                        proc.Kill();
                    }
                }
                catch (Exception ex)
                {
                    appExcel = null;
                    Console.WriteLine("Unable to release the Object " + ex.ToString());
                }
                finally
                {
                    GC.Collect();
                }
            }
        }
    }

}

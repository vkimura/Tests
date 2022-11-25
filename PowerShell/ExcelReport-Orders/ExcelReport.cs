using System;
using System.Collections;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Newtonsoft;

//https://www.mssqltips.com/sqlservertip/6794/export-data-sql-server-to-excel-add-new-columns/

namespace CreateExcelReport
{
    class ExcelUILanguageHelper : IDisposable
    {
        private CultureInfo m_CurrentCulture;

        public ExcelUILanguageHelper()
        {
            // save current culture and set culture to en-US
            m_CurrentCulture = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
        }

        // return to normal culture
        public void Dispose() => Thread.CurrentThread.CurrentCulture = m_CurrentCulture;
    }

    class Program
    {
        //private const string sqlOrders =
        //    @"select 
        //        orders.OrderID,
        //        OrderDate,
        //        ShipCity,
        //        ShipCountry,
        //        ProductID,
        //        UnitPrice,
        //        Quantity
        //    from Orders join [Order Details] on orders.OrderID = [Order Details].OrderID
        //    order by orderid";

        private const string sqlOrders =
            @"SELECT [VariableID]
      ,[Value]
FROM [ReevesCollege].[dbo].[Variables] WHERE Value like '%/file%'";

        //private const string connectionString = "Server=TCP:192.168.0.7;Database=Northwind;Integrated Security=SSPI;Connect Timeout=30;";
        private const string connectionString = "Server=D117330\\MSSQLSERVER02;Database=CollegeCDI;Trusted_Connection=True;";

        static void Main(string[] args)
        {
            using (new ExcelUILanguageHelper())
            {
                //string fileName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + "ExcelReport-Orders.xlsx";
                string fileName = "C:\\Users\\vkimura\\Downloads\\6794_SampleCode-Data\\ExcelReport-Orders.xlsx";

                Excel.Application xlsApp;
                Excel.Workbook xlsWorkbook;
                Excel.Worksheet xlsItemOrder;
                object misValue = System.Reflection.Missing.Value;

                // Remove the old excel report file
                try
                {
                    FileInfo oldFile = new FileInfo(fileName);
                    if (oldFile.Exists)
                    {
                        File.SetAttributes(oldFile.FullName, FileAttributes.Normal);
                        oldFile.Delete();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error removing old Excel report: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                try
                {
                    // In case that database cannot be open, don't open Excel app
                    using SqlConnection conn = new SqlConnection(connectionString);
                    conn.Open();

                    xlsApp = new Excel.Application();
                    xlsWorkbook = xlsApp.Workbooks.Add(misValue);
                    xlsWorkbook.Sheets.Add(); // Add a second sheet

                    // Create the header for the first sheet
                    xlsItemOrder = (Excel.Worksheet)xlsWorkbook.Sheets[1];
                    xlsItemOrder.Name = "CollegeCDI";
                    xlsItemOrder.Cells[1, 1] = "Newsletters Table";
                    Excel.Range rangeItems = xlsItemOrder.get_Range("A1", "D1");
                    rangeItems.Merge(1);
                    rangeItems.Borders.Color = Color.Black.ToArgb();
                    rangeItems.Interior.Color = Color.Yellow.ToArgb();
                    rangeItems.Font.Name = "Courier New";
                    rangeItems.Font.Size = 14;
                    rangeItems.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenterAcrossSelection;

                    // Process orders
                    using SqlCommand cmd = new SqlCommand(sqlOrders, conn);
                    using SqlDataReader dr = cmd.ExecuteReader();

                    int i = 3;
                    if (dr.HasRows)
                    {
                        for (int j = 0; j < dr.FieldCount; ++j)
                        {
                            xlsItemOrder.Cells[i, j + 1] = dr.GetName(j);
                        }
                        xlsItemOrder.Cells[i, dr.FieldCount + 1] = "Line Total";
                        ++i;
                    }

                    /*
                     * We know we have less than 26 columns and we can use A+i to get the column name 
                     * which will be between A and Z. If we have more than 26 columns, 
                     * we can easily write a function which transforms a number into a column name
                     */
                    char col1 = (char)('A' + dr.FieldCount - 2);
                    char col2 = (char)('A' + dr.FieldCount - 1);
                    char coltotal = (char)('A' + dr.FieldCount);

                    while (dr.Read())
                    {
                        for (int j = 1; j <= dr.FieldCount; ++j)
                        {
                            //TODO: extract json object with image url from special fields like CDICollege.dbo.Newsletters.Contents
                            //if (j == 2) {
                            //    string jsonObjFromSqlTable = dr.GetValue(j).ToString();
                            //    var jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(jsonObjFromSqlTable);
                            //    var imgUrl = jsonObj.Contents[0].ContentImage;
                            //    xlsItemOrder.Cells[i, j] = imgUrl;
                            //} else
                            //{
                            //xlsItemOrder.Cells[i, j] = dr.GetValue(j - 1);
                            //}
                            xlsItemOrder.Cells[i, j] = dr.GetValue(j - 1);
                        }
                        //string jsonObjFromSqlTable = dr.GetValue(2).ToString();
                        //var jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(jsonObjFromSqlTable);
                        

                        string formula = "=" + col1 + i.ToString() + "*" + col2 + i.ToString();
                        xlsItemOrder.Cells[i, dr.FieldCount + 1].NumberFormat = "0.00";
                        xlsItemOrder.Cells[i, dr.FieldCount + 1] = formula;
                        ++i;
                    }

                    //xlsItemOrder.Cells[++i, 1] = "Total Sales";
                    Excel.Range rangeTotal = xlsItemOrder.get_Range("A" + i, "D" + i);
                    rangeTotal.Merge(1);
                    rangeTotal.Borders.Color = Color.Black.ToArgb();
                    rangeTotal.Interior.Color = Color.Yellow.ToArgb();
                    rangeTotal.Font.Name = "Courier New";
                    rangeTotal.Font.Size = 14;
                    rangeTotal.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenterAcrossSelection;
                    string sum = "=Sum(" + coltotal + 3.ToString() + ":" + coltotal + (i - 2).ToString() + ")";
                    xlsItemOrder.Cells[i, dr.FieldCount + 1].NumberFormat = "0.00";
                    xlsItemOrder.Cells[i, dr.FieldCount + 1] = sum;
                    dr.Close();

                    rangeItems = xlsItemOrder.get_Range("A2", coltotal + (i + 2).ToString());
                    rangeItems.Columns.AutoFit();

                    // Save the Excel file
                    xlsWorkbook.SaveAs(fileName, Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, misValue, misValue,
                        Excel.XlSaveAsAccessMode.xlExclusive, Excel.XlSaveConflictResolution.xlLocalSessionChanges, misValue, misValue, misValue, misValue);
                    xlsWorkbook.Close(true, misValue, misValue);
                    xlsApp.Quit();

                    ReleaseObject(xlsItemOrder);
                    ReleaseObject(xlsWorkbook);
                    ReleaseObject(xlsApp);

                    if (MessageBox.Show("Excel report has been created on your desktop\nWould you like to open it?", "Created Excel report",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        Process.Start(fileName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating Excel report: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        static private void ReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}

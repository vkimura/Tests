using System;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace _01_WinFormsControlLibraryExcelRead
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            readExcel();
        }

        private void readExcel()
        {
            string filePath = "C:\\Users\\vkimura\\source\\repos\\01-WinFormsControlLibraryExcelRead\\text.xlsx";

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
    }
}

//namespace System.IO
//{
//	public static class ExtendedMethod
//	{
//		public static void Rename(this FileInfo fileInfo, string newName)
//		{
//			fileInfo.MoveTo(fileInfo.Directory.FullName + "\\" + newName);
//		}
//	}
//}

//FileInfo file = new("C:\Users\vkimura\source\repos\01_Test_ConsoleFileRename\Test_ConsoleFileRename\test-rename.txt");
//file.Rename("test2.txt")

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace BatchRenamer
{
	class Program
	{
		static void Main(string[] args)
		{
			var dirname = Directory.GetDirectories(@"C:\Users\vkimura\source\repos\01_Test_ConsoleFileRename\Test_ConsoleFileRename\test_rename");

			int i = 0;

			try
			{
				foreach (var dir in dirname)
				{
					var fnames = Directory.GetFiles(dir, "*.txt").Select(Path.GetFileName);

					DirectoryInfo d = new DirectoryInfo(dir);
					FileInfo[] finfo = d.GetFiles("*.txt");

					foreach (var f in fnames)
					{
						i++;
						Console.WriteLine("The number of the file being renamed is: {0}", i);

						if (File.Exists(Path.Combine(dir, f.ToString())))
						{
							File.Move(Path.Combine(dir, f), Path.Combine(dir, f.ToString() + "-" + i));
						}
						else
						{
							Console.WriteLine("The file you are attempting to rename already exists! The file path is {0}.", dir);
							foreach (FileInfo fi in finfo)
							{
								Console.WriteLine("The file modify date is: {0} ", File.GetLastWriteTime(dir));
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			Console.Read();
		}

/*
* Read Excel file
*/
		public string ReadExcelFile() {
			//read excel file


			//return row one from excel file in array format
			
			//open excel file
			

			//read excel file
			//return row one from excel file in array format


			excelFile.Open();
			//get sheet
			var sheet = excelFile.Worksheet("Test_Details");
			//get row one
			var row = sheet.Row(1);
			//get cell one
			var cell = row.Cell(1);
			//get cell value
			var cellValue = cell.Value;
			//close excel file
			excelFile.Close();
			//return cell value
			return cellValue;			
		}

		public void UpdateExcelFile() {
			//update excel file	
			//open excel file
			var excelFile = new ExcelFile("C:\Users\vkimura\Documents\SEO\CollegeCDI.ca\CDICollege.ca-AgencyAnalytics-AGSVK_Inc._Test_Details.xlsm");
			excelFile.Open();
			//get sheet
			var sheet = excelFile.Worksheet("Test_Details");
			//get row one
			var row = sheet.Row(1);
			//update cell one
			row.Cell(1).Value = "Updated";
			//save excel file
			excelFile.Save();
			//close excel file
			excelFile.Close();

		}

		public void OpenExcelFile() {
			//open excel file
			var excelFile = new ExcelFile("C:\Users\vkimura\Documents\SEO\CollegeCDI.ca\CDICollege.ca-AgencyAnalytics-AGSVK_Inc._Test_Details.xlsm");
		}
	}
}

// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
	
using OfficeOpenXml;
using System;
using System.IO;

public class ExcelManager
{
    public static void AddJobApplication(string jobTitle, string company, string comments)
    {

        string dateSubmitted = DateTime.Now.ToString("yyyy-MM-dd");


        // Open the Excel file for writing
        using (var package = new ExcelPackage(new FileInfo("C:/Users/mjl82/Desktop/Jobs.xlsx")))
        {
            var worksheet = package.Workbook.Worksheets["JobApplications"];

            // Find the next available row (assuming no empty rows in the middle)
            int nextRow = worksheet.Dimension?.Rows ?? 1;

            // Add data to the next row
            worksheet.Cells[nextRow + 1, 1].Value = company;
            worksheet.Cells[nextRow + 1, 2].Value = jobTitle;
            worksheet.Cells[nextRow + 1, 3].Value = comments;
            worksheet.Cells[nextRow + 1, 4].Value = dateSubmitted;

            // Save the changes to the Excel file
            package.Save();
        }
    }
}

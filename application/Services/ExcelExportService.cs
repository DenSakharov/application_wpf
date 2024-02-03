using application.Models;
using OfficeOpenXml;
using System.Collections.ObjectModel;
using System.IO;

namespace application.Services
{
    public class ExcelExportService : IExportService
    {
        public void ExportToExcel(ObservableCollection<CombinedData> data, string filePath)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Страница");

                // Записываем заголовки
                worksheet.Cells[1, 1].Value = "Department Name";
                worksheet.Cells[1, 2].Value = "Employee ID";
                worksheet.Cells[1, 3].Value = "Employee Full Name";
                worksheet.Cells[1, 4].Value = "Employee Salary";
                worksheet.Cells[1, 5].Value = "City Name";
                worksheet.Cells[1, 6].Value = "Position Title";

                int row = 2;
                foreach (var item in data)
                {
                    worksheet.Cells[row, 1].Value = item.DepartmentName;
                    worksheet.Cells[row, 2].Value = item.EmployeeID;
                    worksheet.Cells[row, 3].Value = item.EmployeeFullName;
                    worksheet.Cells[row, 4].Value = item.EmployeeSalary;
                    worksheet.Cells[row, 5].Value = item.CityName;
                    worksheet.Cells[row, 6].Value = item.PositionTitle;
                    row++;
                }

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    package.SaveAs(stream);
                }
            }
        }
    }
}

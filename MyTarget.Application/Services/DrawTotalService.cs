using MyTarget.Application.Interfaces;
using MyTarget.Domain.Entities;
using OfficeOpenXml;
using OfficeOpenXml.Sorting;

namespace MyTarget.Application.Services
{
    public class DrawTotalService : IDrawTotalService
    {
        private readonly string _urlTemplate = @"analises\total_sorteado_{0}.xlsx";
        public void GenerateDrawTotal(List<ResultDrawEntity> results,
                                      List<StandardStructureEntity> standardStructure)
        {
            string _url = string.Format(_urlTemplate, DateTime.Now.ToString("ddMMyyyyHHmmss"));

            DrawnNumbers exists = new DrawnNumbers();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage excel = new ExcelPackage();

            var workSheet = excel.Workbook.Worksheets.Add("Total");
            workSheet.TabColor = System.Drawing.Color.Black;
            workSheet.DefaultRowHeight = 12;

            workSheet.Cells[1, 1].Value = "Dezena";
            workSheet.Cells[1, 2].Value = "Total";

            workSheet.Row(1).Height = 20;
            workSheet.Row(1).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            workSheet.Row(1).Style.Font.Bold = true;

            workSheet.Column(1).AutoFit();
            workSheet.Column(2).AutoFit();

            int row = 2;
            int total = 0;

            foreach (var number in standardStructure)
            {
                workSheet.Cells[row, 1].Value = number.standardNumber;
                total = 0;

                foreach (var result in results)
                {
                    exists = new DrawnNumbers();
                    exists = result.drawnNumbers.Find(x => x.drawnNumber == number.standardNumber);
                    if (exists != null) total++;
                }

                workSheet.Cells[row, 2].Value = total;
                row++;
            }

            workSheet.Cells.Sort(1, true);

            if (File.Exists(_url))
                File.Delete(_url);

            FileStream stream = File.Create(_url);
            stream.Close();

            File.WriteAllBytes(_url, excel.GetAsByteArray());

            excel.Dispose();
        }
    }
}

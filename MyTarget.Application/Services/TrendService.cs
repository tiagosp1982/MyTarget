using MyTarget.Application.Interfaces;
using MyTarget.Domain.Entities;
using OfficeOpenXml;

namespace MyTarget.Application.Services
{
    public class TrendService : ITrendService
    {
        private readonly string _urlTemplate = @"analises\tendencia_{0}.xlsx";
        private readonly string _urlTemplatePesoFrequencia = @"analises\tendencia_peso_frequencia_{0}.xlsx";
        public void GenerateTrend(List<ResultDrawEntity> results,
                                  List<StandardStructureEntity> standardStructure,
                                  bool frequency)
        {
            string _url = string.Format((frequency ? _urlTemplatePesoFrequencia : _urlTemplate), DateTime.Now.ToString("ddMMyyyyHHmmss"));

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage excel = new ExcelPackage();

            var workSheet = excel.Workbook.Worksheets.Add("Tendencia");
            workSheet.TabColor = System.Drawing.Color.Black;
            workSheet.DefaultRowHeight = 12;

            workSheet.Cells[1, 1].Value = "Concurso";

            workSheet.Row(1).Height = 20;
            workSheet.Row(1).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            workSheet.Row(1).Style.Font.Bold = true;

            int colStandardStructure = 2;
            DrawnNumbers exists = new DrawnNumbers();
            int colTrend = 2;
            int countFrequency = 0;

            workSheet.Cells[2, 1].Value = results[0].contestNumber + 1;

            foreach (var number in standardStructure)
            {
                workSheet.Cells[1, colStandardStructure].Value = number.standardNumber;
                workSheet.Column(colStandardStructure).AutoFit();
                
                int rowTrend = 3;
                countFrequency = 0;

                foreach (var result in results)
                {
                    exists = new DrawnNumbers();
                    workSheet.Cells[rowTrend, 1].Value = result.contestNumber;

                    exists = result.drawnNumbers.Find(x => x.drawnNumber == number.standardNumber);
                    if (exists != null)
                    {
                        countFrequency++;
                        workSheet.Cells[rowTrend, colTrend].Value = (frequency ? countFrequency : 1);
                    }
                    else
                    {
                        countFrequency = 0;
                        workSheet.Cells[rowTrend, colTrend].Value = countFrequency;
                    }

                    workSheet.Row(rowTrend).Style.Font.Italic = true;
                    rowTrend++;
                }

                //inclui formula de tendência
                int finalRow = workSheet.Dimension.End.Row;
                workSheet.Row(2).Style.Font.Bold = true;

                workSheet.Cells[2, colTrend].Formula = "TREND(" +
                    workSheet.Cells[3, colTrend].Address + ":" +
                    workSheet.Cells[finalRow, colTrend].Address + "," +
                    workSheet.Cells[3, 1].Address + ":" +
                    workSheet.Cells[finalRow, 1].Address + "," +
                    workSheet.Cells[2, 1].Address + ",0)";
                
                workSheet.Cells[2, colTrend].Calculate();

                colTrend++;
                colStandardStructure++;
            }

            if (File.Exists(_url))
                File.Delete(_url);

            FileStream stream = File.Create(_url);
            stream.Close();

            File.WriteAllBytes(_url, excel.GetAsByteArray());

            excel.Dispose();
        }

        private void DrawProgressBar(int progress, int total)
        {
            //draw empty progress bar
            Console.CursorLeft = 0;
            Console.Write("["); //start
            Console.CursorLeft = 32;
            Console.Write("]"); //end
            Console.CursorLeft = 1;
            float onechunk = 30.0f / total;

            //draw filled part
            int position = 1;
            for (int i = 0; i < onechunk * progress; i++)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.CursorLeft = position++;
                Console.Write(" ");
            }

            //draw unfilled part
            for (int i = position; i <= 31; i++)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.CursorLeft = position++;
                Console.Write(" ");
            }

            //draw totals
            Console.CursorLeft = 35;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(progress.ToString() + " de " + total.ToString() + "    "); //blanks at the end remove any excess
        }
    }
}

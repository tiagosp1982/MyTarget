using MyTarget.Application.Entities;
using MyTarget.Application.Interfaces;
using MyTarget.Domain.Entities;
using OfficeOpenXml;

namespace MyTarget.Application.Services
{
    public class AverageFrequencyRepetitionService : IAverageFrequencyRepetitionService
    {
        private readonly string _urlTemplate = @"analises\frequencia_media_repeticao_{0}.xlsx";
        public void GenerateAverageFrequency(List<ResultDrawEntity> results, 
                                             List<StandardStructureEntity> standardStructure)
        {
            string _url = string.Format(_urlTemplate, DateTime.Now.ToString("ddMMyyyyHHmmss"));

            List<AverageFrequencyRepetitionEntity> list = new List<AverageFrequencyRepetitionEntity>();
            AverageFrequencyRepetitionEntity averageFrequencyRepetitionEntity = new AverageFrequencyRepetitionEntity();
            RepetitionsNumbers repetition = new RepetitionsNumbers();
            DrawnNumbers exists = new DrawnNumbers();
            int countRepetition = 0;
            int row = 2;
            int biggestContest = 0;

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage excel = new ExcelPackage();

            var workSheet = excel.Workbook.Worksheets.Add("FreqMediaRpt");

            workSheet.TabColor = System.Drawing.Color.Black;
            workSheet.DefaultRowHeight = 12;

            workSheet.Cells[1, 1].Value = "Dezena";
            workSheet.Cells[1, 2].Value = "Freq. Média Repet.";
            workSheet.Cells[1, 3].Value = "Dezena - Último Concurso Repet.";
            workSheet.Cells[1, 4].Value = "Dezena - Última Qtd Repet.";
            workSheet.Cells[1, 5].Value = "Dezena - Última Aparição.";

            workSheet.Row(1).Height = 20;
            workSheet.Row(1).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            workSheet.Row(1).Style.Font.Bold = true;

            workSheet.Column(1).AutoFit();
            workSheet.Column(2).AutoFit();
            workSheet.Column(3).AutoFit();
            workSheet.Column(4).AutoFit();
            workSheet.Column(5).AutoFit();

            foreach (var number in standardStructure)
            {
                averageFrequencyRepetitionEntity = new AverageFrequencyRepetitionEntity();
                repetition = new RepetitionsNumbers();
                averageFrequencyRepetitionEntity.repetitionsNumbers = new List<RepetitionsNumbers>();

                averageFrequencyRepetitionEntity.standardNumber = number.standardNumber;
                countRepetition = 0;
                
                foreach (var result in results)
                {
                    exists = new DrawnNumbers();
                    exists = result.drawnNumbers.Find(x => x.drawnNumber == number.standardNumber);

                    if (exists != null)
                    {
                        countRepetition++;
                        if (countRepetition == 1)
                        {
                            biggestContest = result.contestNumber;
                            if (averageFrequencyRepetitionEntity.lastAppearance == 0)
                            {
                                averageFrequencyRepetitionEntity.lastAppearance = result.contestNumber;
                            }
                        }
                            
                        if (biggestContest > averageFrequencyRepetitionEntity.lastContestRepetition &&
                            countRepetition > 1
                           )
                            averageFrequencyRepetitionEntity.lastContestRepetition = biggestContest;
                    }
                    else
                    {
                        if (countRepetition > 1)
                        {
                            if (averageFrequencyRepetitionEntity.lastRepeatAmount == 0)
                            {
                                averageFrequencyRepetitionEntity.lastRepeatAmount = countRepetition;
                            }
                            repetition.repetitions = countRepetition;
                            averageFrequencyRepetitionEntity.repetitionsNumbers.Add(repetition);
                            repetition = new RepetitionsNumbers();
                        }
                        countRepetition = 0;
                        biggestContest = 0;
                    }
                }

                if (countRepetition > 1)
                {
                    repetition.repetitions = countRepetition;
                }

                if (repetition.repetitions > 0)
                    averageFrequencyRepetitionEntity.repetitionsNumbers.Add(repetition);

                int count = averageFrequencyRepetitionEntity.repetitionsNumbers.Count;
                int total = averageFrequencyRepetitionEntity.repetitionsNumbers.Sum(x => Convert.ToInt32(x.repetitions));
                averageFrequencyRepetitionEntity.averageRepetition = (count > 0 ? Math.Round(decimal.Divide(total, count), 2) : total);

                
                list.Add(averageFrequencyRepetitionEntity);
                workSheet.Cells[row, 1].Value = averageFrequencyRepetitionEntity.standardNumber;
                workSheet.Cells[row, 2].Value = averageFrequencyRepetitionEntity.averageRepetition;
                workSheet.Cells[row, 3].Value = averageFrequencyRepetitionEntity.lastContestRepetition;
                workSheet.Cells[row, 4].Value = averageFrequencyRepetitionEntity.lastRepeatAmount;
                workSheet.Cells[row, 5].Value = averageFrequencyRepetitionEntity.lastAppearance;
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

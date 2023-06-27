using MyTarget.Data.Context.Constants;
using MyTarget.Infra.Data.Context.Interfaces;
using OfficeOpenXml;

namespace MyTarget.Infra.Data.Context.Excel
{
    public class DataContext : IDataContext
    {
        private readonly string pathFile = @"base\database.xlsx";

        public ExcelPackage CreateNewFile()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage newFile = new ExcelPackage();
            return newFile;
        }

        public ExcelWorksheet? GetDataFile(int indexSheet)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var dataFile = new ExcelPackage(new FileInfo(pathFile));
            var sheet = dataFile.Workbook.Worksheets[indexSheet];
            return sheet;
        }

        public bool SaveFile(string path, ExcelPackage dataFile)
        {
            if (dataFile == null)
            {
                Console.WriteLine("Não existem dados para o arquivo");
                return false;
            }

            if (File.Exists(path))
                File.Delete(path);

            FileStream stream = File.Create(path);
            stream.Close();

            File.WriteAllBytes(path, dataFile.GetAsByteArray());
            dataFile.Dispose();

            return true;
        }
    }
}

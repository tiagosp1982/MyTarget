using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTarget.Infra.Data.Context.Interfaces
{
    public interface IDataContext
    {
        ExcelPackage CreateNewFile();
        ExcelWorksheet? GetDataFile(int indexSheet);
        bool SaveFile(string path, ExcelPackage dataFile);
    }
}

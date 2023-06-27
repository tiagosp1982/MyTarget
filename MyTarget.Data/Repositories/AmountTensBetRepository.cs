using MyTarget.Domain.Interfaces;
using MyTarget.Infra.Data.Context.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTarget.Infra.Data.Repositories
{
    public class AmountTensBetRepository : IAmountTensBetRepository
    {
        private readonly IDataContext _dataContext;

        public AmountTensBetRepository(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<int> GetAll()
        {
            List<int> list = new List<int>();

            var result = _dataContext.GetDataFile(3);

            if (result == null)
            {
                Console.WriteLine("Não existem dados na planilha base.");
                return list;
            }

            int rows = result.Dimension.Rows;
            for (int i = 1; i <= rows; i++)
            {
                int number = Convert.ToInt32(result.Cells[i, 1].Value.ToString());
                list.Add(number);
            }

            return list;
        }
    }
}

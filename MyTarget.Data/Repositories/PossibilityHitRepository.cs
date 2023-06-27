using MyTarget.Domain.Interfaces;
using MyTarget.Infra.Data.Context.Interfaces;

namespace MyTarget.Infra.Data.Repositories
{
    public class PossibilityHitRepository : IPossibilityHitRepository
    {
        private readonly IDataContext _dataContext;

        public PossibilityHitRepository(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<int> GetAll()
        {
            List<int> list = new List<int>();

            var result = _dataContext.GetDataFile(2);

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

using MyTarget.Infra.Data.Context.Interfaces;
using MyTarget.Domain.Entities;
using MyTarget.Domain.Interfaces;

namespace MyTarget.Infra.Data.Repositories
{
    public class ResultDrawRepository : IResultDrawRepository
    {
        private readonly IDataContext _dataContext;

        public ResultDrawRepository(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<ResultDrawEntity> GetAll()
        {
            List<ResultDrawEntity> list = new List<ResultDrawEntity>();

            var result = _dataContext.GetDataFile(0);

            if (result == null)
            {
                Console.WriteLine("Não existem dados na planilha base.");
                return list;
            }

            int rows = result.Dimension.Rows;
            int cols = result.Dimension.Columns;

            ResultDrawEntity obj;
            DrawnNumbers objNumber;

            for (int i = 1; i <= rows; i++)
            {
                obj = new ResultDrawEntity();
                obj.contestNumber = Convert.ToInt32(result.Cells[i, 1].Value.ToString());
                obj.contestDate = Convert.ToDateTime(result.Cells[i, 2].Value.ToString());
                obj.drawnNumbers = new List<DrawnNumbers>();
                for (int j = 3; j <= cols; j++)
                {
                    objNumber = new DrawnNumbers();
                    objNumber.drawnNumber = Convert.ToInt32(result.Cells[i, j].Value.ToString());
                    obj.drawnNumbers.Add(objNumber);
                }

                list.Add(obj);
            }

            return list;
        }
    }
}

using MyTarget.Domain.Entities;
using MyTarget.Domain.Interfaces;
using MyTarget.Infra.Data.Context.Interfaces;

namespace MyTarget.Infra.Data.Repositories
{
    public class StandardStructureRepository : IStandardStructureRepository
    {
        private readonly IDataContext _dataContext;

        public StandardStructureRepository(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<StandardStructureEntity> GetAll()
        {
            List<StandardStructureEntity> list = new List<StandardStructureEntity>();

            var result = _dataContext.GetDataFile(1);

            if (result == null)
            {
                Console.WriteLine("Não existem dados na planilha base.");
                return list;
            }

            int rows = result.Dimension.Rows;
            
            StandardStructureEntity obj;

            for (int i = 1; i <= rows; i++)
            {
                obj = new StandardStructureEntity();
                obj.standardNumber = Convert.ToInt32(result.Cells[i, 1].Value.ToString());
                
                list.Add(obj);
            }

            return list;
        }
    }
}

using MyTarget.Domain.Entities;

namespace MyTarget.Application.Interfaces
{
    public interface IDrawTotalService
    {
        void GenerateDrawTotal(List<ResultDrawEntity> results, List<StandardStructureEntity> standardStructure);
    }
}

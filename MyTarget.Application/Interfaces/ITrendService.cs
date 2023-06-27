using MyTarget.Application.Entities;
using MyTarget.Domain.Entities;

namespace MyTarget.Application.Interfaces
{
    public interface ITrendService
    {
        void GenerateTrend(List<ResultDrawEntity> results, List<StandardStructureEntity> standardStructure, bool frequency);
    }
}

using MyTarget.Domain.Entities;

namespace MyTarget.Application.Interfaces
{
    public interface IAverageFrequencyRepetitionService
    {
        void GenerateAverageFrequency(List<ResultDrawEntity> results, List<StandardStructureEntity> standardStructure);
    }
}

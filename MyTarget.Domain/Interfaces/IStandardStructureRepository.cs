using MyTarget.Domain.Entities;

namespace MyTarget.Domain.Interfaces
{
    public interface IStandardStructureRepository
    {
        List<StandardStructureEntity> GetAll();
    }
}

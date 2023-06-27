using MyTarget.Domain.Entities;

namespace MyTarget.Domain.Interfaces
{
    public interface IResultDrawRepository
    {
        List<ResultDrawEntity> GetAll();
    }
}

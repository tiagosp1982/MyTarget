using MyTarget.Application.Interfaces;
using MyTarget.Domain.Entities;
using MyTarget.Domain.Interfaces;

namespace MyTarget.Application.Services
{
    public class ResultDrawService : IResultDrawService
    {
        private readonly IResultDrawRepository _resultDrawRepository;

        public ResultDrawService(IResultDrawRepository resultDrawRepository)
        {
            _resultDrawRepository = resultDrawRepository;
        }

        public List<ResultDrawEntity> ResultDrawAll() => _resultDrawRepository.GetAll();
    }
}

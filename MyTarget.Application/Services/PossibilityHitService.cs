using MyTarget.Application.Interfaces;
using MyTarget.Domain.Entities;
using MyTarget.Domain.Interfaces;

namespace MyTarget.Application.Services
{
    public class PossibilityHitService : IPossibilityHitService
    {
        private readonly IPossibilityHitRepository _possibilityHitRepository;

        public PossibilityHitService(IPossibilityHitRepository possibilityHitRepository)
        {
            _possibilityHitRepository = possibilityHitRepository;
        }

        public List<int> PossibilityHitAll() => _possibilityHitRepository.GetAll();
    }
}

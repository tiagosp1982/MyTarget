using MyTarget.Application.Interfaces;
using MyTarget.Domain.Entities;
using MyTarget.Domain.Interfaces;

namespace MyTarget.Application.Services
{
    public class StandardStructureService : IStandardStructureService
    {
        private readonly IStandardStructureRepository _standardStructureRepository;

        public StandardStructureService(IStandardStructureRepository standardStructureRepository)
        {
            _standardStructureRepository = standardStructureRepository;
        }

        public List<StandardStructureEntity> StandardStructureAll() => _standardStructureRepository.GetAll();
    }
}

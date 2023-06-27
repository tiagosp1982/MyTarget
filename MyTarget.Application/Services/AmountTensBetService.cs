using MyTarget.Application.Interfaces;
using MyTarget.Domain.Interfaces;

namespace MyTarget.Application.Services
{
    public class AmountTensBetService : IAmountTensBetService
    {
        private readonly IAmountTensBetRepository _amountTensBetRepository;

        public AmountTensBetService(IAmountTensBetRepository amountTensBetRepository)
        {
            _amountTensBetRepository = amountTensBetRepository;
        }

        public List<int> AmountTensBetAll() => _amountTensBetRepository.GetAll();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTarget.Domain.Interfaces
{
    public interface IAmountTensBetRepository
    {
        List<int> GetAll();
    }
}

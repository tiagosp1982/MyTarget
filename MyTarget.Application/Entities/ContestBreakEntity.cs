using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTarget.Application.Entities
{
    public class ContestBreakEntity
    {
        public int initialContest { get; set; }
        public int finalContest { get; set; }
        public bool informedContests { get; set; }
    }
}

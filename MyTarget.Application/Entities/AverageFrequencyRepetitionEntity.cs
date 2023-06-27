using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTarget.Application.Entities
{
    public class AverageFrequencyRepetitionEntity
    {
        public int standardNumber { get; set; }

        public List<RepetitionsNumbers> repetitionsNumbers { get; set; }

        public int lastContestRepetition { get; set; }

        public int lastRepeatAmount { get; set; }

        public decimal averageRepetition { get; set; }

        public int lastAppearance { get; set; }
    }

    public class RepetitionsNumbers
    {
        public int repetitions { get; set; }
    }
}

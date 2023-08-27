using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weather.Entities
{
    internal class Condition
    {
        public ConditionType Type { get; set; }
        public decimal Threshold { get; set; }

        public Condition(ConditionType type, decimal threshold)
        {
            Type = type;
            Threshold = threshold;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statistics.Models
{
    public class Statistic
    {
        public int NumberOfLiveExperiences { get; set; }

        // a better name could be found saying what the "change" is calculated from
        public int ChangeInLiveExperiences { get; set; }
    }
}

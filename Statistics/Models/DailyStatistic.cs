using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statistics.Models
{
    public class DailyStatistic
    {
        public long Id { get; set; }
        public int NumberOfExperiences { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}

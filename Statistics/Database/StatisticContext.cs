using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Statistics.Models;

namespace Statistics.Database
{
    public class StatisticContext : DbContext
    {
        public StatisticContext(DbContextOptions<StatisticContext> options) : base(options)
        {
        }

        public virtual DbSet<DailyStatistic> DailyStatistics { get; set; }
    }
}

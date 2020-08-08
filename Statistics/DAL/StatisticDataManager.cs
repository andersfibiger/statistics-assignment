using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Statistics.Common;
using Statistics.Database;
using Statistics.Models;

namespace Statistics.DAL
{
    public interface IStatisticDataManager
    {
        Task<DailyStatistic> GetStatisticByDate(DateTime date);
        Task Create(DailyStatistic dailyStatistic);
    }

    public class StatisticDataManager : IStatisticDataManager
    {
        private readonly StatisticContext _context;

        public StatisticDataManager(StatisticContext context)
        {
            _context = context;
        }

        public Task Create(DailyStatistic dailyStatistic)
        {
            _context.DailyStatistics.Add(dailyStatistic);
            return _context.SaveChangesAsync();
        }

        public async Task<DailyStatistic> GetStatisticByDate(DateTime date)
        {
            try
            {
                return await _context.DailyStatistics
                    .FirstAsync(stat => stat.TimeStamp.Date.Equals(date.Date));
            }
            catch (Exception)
            {
                throw new StatisticException("No statistics found for the given date", 404);
            }
        }
    }
}

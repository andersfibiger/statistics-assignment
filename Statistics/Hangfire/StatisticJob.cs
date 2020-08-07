using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Statistics.BLL;
using Statistics.Database;
using Statistics.Models;
using Statistics.Services;

namespace Statistics.Hangfire
{
    public interface IStatisticJob
    {
        Task Run();
    }

    public class StatisticJob : IStatisticJob
    {
        private readonly IStatisticLogic _statisticLogic;
        private readonly StatisticContext _statisticContext;

        public StatisticJob(IStatisticLogic statisticLogic, StatisticContext statisticContext)
        {
            _statisticLogic = statisticLogic;
            _statisticContext = statisticContext;
        }

        public async Task Run()
        {
            var numberOfLiveExperience = await _statisticLogic.GetNumberOfLiveExperience();
            _statisticContext.DailyStatistics.Add(new DailyStatistic
            {
                NumberOfExperiences = numberOfLiveExperience,
                TimeStamp = DateTime.Now 
            });

            await _statisticContext.SaveChangesAsync();
        }
    }
}

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

        public StatisticJob(IStatisticLogic statisticLogic)
        {
            _statisticLogic = statisticLogic;
        }

        public Task Run()
        {
            return _statisticLogic.CreateStatistic();
        }
    }
}

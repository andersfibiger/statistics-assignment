using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Statistics.Database;
using Statistics.Models;
using Statistics.Services;

namespace Statistics.BLL
{
    public interface IStatisticLogic
    {
        Task<int> GetNumberOfLiveExperience();
        Task<int> GetChangeInExperiences(DateTime date);
    }

    public class StatisticLogic : IStatisticLogic
    {
        private readonly IProductService _productService;
        private readonly StatisticContext _statisticContext;

        public StatisticLogic(IProductService productService, StatisticContext statisticContext)
        {
            _productService = productService;
            _statisticContext = statisticContext;
        }

        public async Task<int> GetChangeInExperiences(DateTime date)
        {
            var statistic = await _statisticContext.DailyStatistics
                .SingleOrDefaultAsync(stat => stat.TimeStamp.Date.Equals(date.Date));

            var stat2 = await _statisticContext.DailyStatistics
                .SingleOrDefaultAsync(stat => stat.TimeStamp.Date.Equals(date.Date));

            return statistic.NumberOfExperiences - stat2.NumberOfExperiences;
        }

        public async Task<int> GetNumberOfLiveExperience()
        {
            var experiences = await _productService.GetLiveExperiences();

            return experiences.Count();
        }
    }
}

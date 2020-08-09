using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Statistics.DAL;
using Statistics.Database;
using Statistics.Models;
using Statistics.Services;

namespace Statistics.BLL
{
    public interface IStatisticLogic
    {
        Task<Statistic> GetStatistic(DateTime date);
        Task CreateStatistic();
    }

    public class StatisticLogic : IStatisticLogic
    {
        private readonly IProductService _productService;
        private readonly IStatisticDataManager _statisticDataManager;

        public StatisticLogic(IProductService productService, IStatisticDataManager statisticDataManager)
        {
            _productService = productService;
            _statisticDataManager = statisticDataManager;
        }

        public async Task<Statistic> GetStatistic(DateTime date)
        {
            // all logic for getting statistic will happen here. This means getting currently live experiences
            // and the change given the date. This will be returned as a statistic
            var statistic = new Statistic
            {
                NumberOfLiveExperiences = await GetNumberOfLiveExperience(),
                ChangeInLiveExperiences = await GetChangeInExperiencesFromDate(date)
            };

            return statistic;
        }

        private async Task<int> GetNumberOfLiveExperience()
        {
            var experiences = await _productService.GetLiveExperiences();

            return experiences.Count();
        }

        private async Task<int> GetChangeInExperiencesFromDate(DateTime date)
        {
            // We first fetch the statistic for the given day and the day before.
            // Then we calculate the difference by subtracting the statistics from each other.
            // If no statistic is found on the given date an exception is thrown which
            // is handled by the ExceptionHandlerFilter
            var statisticForDate = await _statisticDataManager.GetStatisticByDate(date);
            var statisticForDayBefore = await _statisticDataManager.GetStatisticByDate(date.AddDays(-1));

            return statisticForDate.NumberOfExperiences - statisticForDayBefore.NumberOfExperiences;
        }

        public async Task CreateStatistic()
        {
            var dailyStatistic = new DailyStatistic
            {
                NumberOfExperiences = await GetNumberOfLiveExperience(),
                TimeStamp = DateTime.UtcNow.AddDays(-1) // subtract one day since we are calculating the day before midnight
            };
            await _statisticDataManager.Create(dailyStatistic);
        }
    }
}

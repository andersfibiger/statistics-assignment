using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Statistics.BLL;
using Statistics.Models;

namespace Statistics.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatisticController
    {
        private readonly IStatisticLogic _statisticLogic;

        public StatisticController(IStatisticLogic statisticLogic)
        {
            _statisticLogic = statisticLogic;
        }

        [HttpGet]
        public async Task<Statistic> GetStatistics([Required] DateTime date)
        {
            var numberOfLiveExperiences = await _statisticLogic.GetNumberOfLiveExperience();

            var statistic = new Statistic
            {
                NumberOfLiveExperiences = numberOfLiveExperiences,
                ChangeInLiveExperiences = 1 // TODO
            };

            return statistic;
        }
    }
}

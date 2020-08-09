using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Statistics.BLL;
using Statistics.Common;
using Statistics.Models;

namespace Statistics.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatisticController : Controller
    {
        private readonly IStatisticLogic _statisticLogic;

        public StatisticController(IStatisticLogic statisticLogic)
        {
            _statisticLogic = statisticLogic;
        }

        [HttpGet]
        public async Task<ActionResult<Statistic>> GetStatistic([Required] DateTime date)
        {
            // Date is being validated by [required] annotation for being a valid date format
            // and by the following function to be a date that has ended.
            ValidateDate(date);
            var statistic = await _statisticLogic.GetStatistic(date);

            return Ok(statistic);
        }

        private void ValidateDate(DateTime date)
        {
            if (date.Date >= DateTime.Today.Date)
            {
                throw new StatisticException($"Given date has not passed yet: {date}", 400);
            }
        }
    }
}

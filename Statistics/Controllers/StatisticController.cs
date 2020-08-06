using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statistics.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatisticController
    {


        [HttpGet]
        public Task GetStatics()
        {
            return Task.CompletedTask;
        }
    }
}

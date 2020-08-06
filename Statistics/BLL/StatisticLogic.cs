using System;
using System.Linq;
using System.Threading.Tasks;
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

        public StatisticLogic(IProductService productService)
        {
            _productService = productService;
        }

        public Task<int> GetChangeInExperiences(DateTime date)
        {
            return Task.FromResult(4);
        }

        public async Task<int> GetNumberOfLiveExperience()
        {
            var experiences = await _productService.GetLiveExperiences();

            return experiences.Count();
        }
    }
}

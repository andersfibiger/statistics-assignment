using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Statistics.Models;

namespace Statistics.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Experience>> GetLiveExperiences();
    }

    public class ProductService : IProductService
    {
        private readonly HttpClient _client;

        public ProductService(HttpClient client)
        {
            client.BaseAddress = new Uri("http://api.truestory.com/v2/");

            _client = client;
        }

        public async Task<IEnumerable<Experience>> GetLiveExperiences()
        {
            var response = await _client.GetAsync("products?languageCode=da-dk&platform=duglemmerdetaldrig.dk");
            using var responseStream = await response.Content.ReadAsStreamAsync();

            return await JsonSerializer.DeserializeAsync<IEnumerable<Experience>>(responseStream);
        }


    }
}

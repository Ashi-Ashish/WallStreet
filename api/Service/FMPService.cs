using api.DTOs.Stock;
using api.Interfaces;
using api.Models;
using AutoMapper;
using Newtonsoft.Json;

namespace api.Service
{
    public class FMPService : IFMPService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        public FMPService(
            HttpClient httpClient,
            IConfiguration config,
            IMapper mapper
        )
        {
            _httpClient = httpClient;
            _config = config;
            _mapper = mapper;
        }
        public async Task<Stock> FindStockBySymbolAsync(string symbol)
        {
            try
            {
                var url = $"https://financialmodelingprep.com/stable/profile?symbol={symbol}&apikey={_config["FMP_API_KEY"]}";
                Console.WriteLine($"Test url: {url}");
                var result = await _httpClient.GetAsync(url);
                if (result.IsSuccessStatusCode)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    var tasks = JsonConvert.DeserializeObject<FMPStock[]>(content);
                    var stock = tasks[0];
                    if (stock != null)
                    {
                        return _mapper.Map<Stock>(stock);
                    }

                    return null;
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}
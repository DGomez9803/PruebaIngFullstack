using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Backend._Core.AppSetting;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Backend.Repositories
{
    public class JourneyRepository : IRepository
    {
        private readonly HttpClient _httpClient;
        private readonly ApiSettings _apiSettings;
        private readonly ILogger<JourneyRepository> _logger;

        public JourneyRepository(IOptions<ApiSettings> apiSettings, ILogger<JourneyRepository> logger)
        {
            _httpClient = new HttpClient();
            _apiSettings = apiSettings.Value;
            _logger = logger;

        }
        /// <summary>
        /// Retrieves information about available flights from API.
        /// </summary>
        /// <returns>A list of FlightDto objects.</returns>

        public async Task<List<FlightDto>> checkFlightInfo()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(_apiSettings.UrlApiRecruiting);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<FlightDto>>(content.ToString());
                }
                else
                {
                    return new List<FlightDto>();
                }
            }
            catch (Exception ex)
            {
                Random random = new Random();
                int id = random.Next();
                _logger.LogError("Error check flight id=" + id, ex);
                throw new Exception("Error check flight id=" + id);
            }
        }
    }
}

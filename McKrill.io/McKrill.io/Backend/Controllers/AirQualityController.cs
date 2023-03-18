using System;
using McKrill.io.Backend.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace McKrill.io.Backend.Controllers
{
    [ApiController]
    [Route("air")]
    public class AirQualityController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public AirQualityController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://15.222.250.19/");
        }

        [HttpGet]
        public async Task<IActionResult> GetAirQualityInformationAsync()
        {
            var response = await _httpClient.GetAsync("air");

            if (!response.IsSuccessStatusCode)
            {
                // handle error cases here
                return StatusCode((int)response.StatusCode);
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            var airQualityInformation = JsonConvert.DeserializeObject<AirQualityInformation>(responseContent);

            return Ok(airQualityInformation);
        }
    }
}


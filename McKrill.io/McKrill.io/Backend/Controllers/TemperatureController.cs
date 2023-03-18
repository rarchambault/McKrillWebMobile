using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using McKrill.io.Backend.Model;

namespace McKrill.io.Backend.Controllers
{
    [ApiController]
    [Route("temp")]
    public class TemperatureController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public TemperatureController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://15.222.250.19/");
        }

        [HttpGet]
        public async Task<IActionResult> GetTemperatureInformationAsync()
        {
            var response = await _httpClient.GetAsync("temp");

            if (!response.IsSuccessStatusCode)
            {
                // handle error cases here
                return StatusCode((int)response.StatusCode);
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            var temperatureInformation = JsonConvert.DeserializeObject<TemperatureInformation>(responseContent);

            return Ok(temperatureInformation);
        }
    }
}


using System;
using McKrill.io.Backend.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace McKrill.io.Backend.Controllers
{
    [ApiController]
    [Route("power")]
    public class PowerLevelController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public PowerLevelController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://15.222.250.19/");
        }

        [HttpGet]
        public async Task<IActionResult> GetPowerLevelInformationAsync()
        {
            var response = await _httpClient.GetAsync("power");

            if (!response.IsSuccessStatusCode)
            {
                // handle error cases here
                return StatusCode((int)response.StatusCode);
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            var powerLevelInformation = JsonConvert.DeserializeObject<PowerLevelInformation>(responseContent);

            return Ok(powerLevelInformation);
        }
    }
}


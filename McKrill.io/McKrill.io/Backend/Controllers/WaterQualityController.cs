using System;
using McKrill.io.Backend.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace McKrill.io.Backend.Controllers
{
    [ApiController]
    [Route("water")]
    public class WaterQualityController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public WaterQualityController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://15.222.250.19/");
        }

        [HttpGet]
        public async Task<IActionResult> GetWaterQualityInformationAsync()
        {
            var response = await _httpClient.GetAsync("water");

            if (!response.IsSuccessStatusCode)
            {
                // handle error cases here
                return StatusCode((int)response.StatusCode);
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            var waterQualityInformation = JsonConvert.DeserializeObject<WaterQualityInformation>(responseContent);

            return Ok(waterQualityInformation);
        }
    }
}


using System;
using McKrill.io.Backend.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace McKrill.io.Backend.Controllers
{
    [ApiController]
    [Route("transit")]
    public class TransitController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public TransitController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://15.222.250.19/");
        }

        [HttpGet]
        public async Task<IActionResult> GetTransitAsync()
        {
            var response = await _httpClient.GetAsync("transit");

            if (!response.IsSuccessStatusCode)
            {
                // handle error cases here
                return StatusCode((int)response.StatusCode);
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            var transitList = JsonConvert.DeserializeObject<List<Transit>>(responseContent);

            return Ok(transitList);
        }
    }
}


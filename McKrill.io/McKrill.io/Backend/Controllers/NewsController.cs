using System;
using McKrill.io.Backend.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace McKrill.io.Backend.Controllers
{
    [ApiController]
    [Route("news")]
    public class NewsController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public NewsController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://15.222.250.19/");
        }

        [HttpGet]
        public async Task<IActionResult> GetNewsAsync()
        {
            var response = await _httpClient.GetAsync("news");

            if (!response.IsSuccessStatusCode)
            {
                // handle error cases here
                return StatusCode((int)response.StatusCode);
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            var newsList = JsonConvert.DeserializeObject<List<News>>(responseContent);

            return Ok(newsList);
        }
    }
}


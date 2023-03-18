using McKrill.io.Backend.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace McKrill.io.Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SOSController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> SOS([FromBody] SOSSignal sosSignal)
        {
            try
            {
                // Create a new HttpClient instance
                using var httpClient = new HttpClient();

                // Set the request content
                var content = new StringContent(
                    JsonSerializer.Serialize(sosSignal),
                    Encoding.UTF8,
                    "application/json"
                );

                // Send the POST request to the specified URL
                var response = await httpClient.PostAsync("http://15.222.250.19/sos", content);

                // Ensure the request was successful
                response.EnsureSuccessStatusCode();

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}


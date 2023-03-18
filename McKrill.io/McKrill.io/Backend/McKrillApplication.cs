using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace McKrill.io.Backend
{
    class McKrillApplication
    {
        static async Task Main(string[] args)
        {
            // Create a new instance of our API client
            var client = new McKrillApiClient();

            // Call various API endpoints
            var temperature = await client.GetTemperatureInformationAsync();
            var airQuality = await client.GetAirQualityInformationAsync();
            var waterQuality = await client.GetInteriorWaterQualityInformationAsync();
            var powerLevel = await client.GetPowerLevelInformationAsync();
            var news = await client.GetNewsInformationAsync();
            var transit = await client.GetTransitInformationAsync();
            var sosResponse = await client.SendSOSAsync(new Model.SOSSignal("test", "location"));

            // Output the results to the console
            Console.WriteLine($"Temperature: {temperature}");
            Console.WriteLine($"Air quality: {airQuality}");
            Console.WriteLine($"Water quality: {waterQuality}");
            Console.WriteLine($"Power level: {powerLevel}");
            Console.WriteLine($"News: {news}");
            Console.WriteLine($"Transit: {transit}");
            Console.WriteLine($"SOS response: {sosResponse}");
        }
    }
}

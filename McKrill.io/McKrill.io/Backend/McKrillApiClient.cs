using System;
using System.Collections.ObjectModel;
using McKrill.io.Backend.Model;
using Newtonsoft.Json;

namespace McKrill.io.Backend
{
    public class McKrillApiClient
    {
        private readonly HttpClient _httpClient;

        public McKrillApiClient()
        {
            _httpClient = new HttpClient();
        }

        public async Task<TemperatureInformationWrapper> GetTemperatureInformationAsync()
        {
            var response = await _httpClient.GetAsync("http://15.222.250.19/temp");

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TemperatureInformationWrapper>(content);
        }

        public async Task<AirQualityInformationWrapper> GetAirQualityInformationAsync()
        {
            var response = await _httpClient.GetAsync("http://15.222.250.19/air");

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<AirQualityInformationWrapper>(content);
        }

        public async Task<WaterQualityInformation> GetInteriorWaterQualityInformationAsync()
        {
            var response = await _httpClient.GetAsync("http://15.222.250.19/water");

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<WaterQualityInformation>(content);
        }

        public async Task<PowerLevelInformationWrapper> GetPowerLevelInformationAsync()
        {
            var response = await _httpClient.GetAsync("http://15.222.250.19/power");

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<PowerLevelInformationWrapper>(content);
        }

        public async Task<News> GetNewsInformationAsync()
        {
            var response = await _httpClient.GetAsync("http://15.222.250.19/news");

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<News>(content);
        }

        public async Task<TransitInformationWrapper> GetTransitInformationAsync()
        {
            var response = await _httpClient.GetAsync("http://15.222.250.19/transit");

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TransitInformationWrapper>(content);
        }

        public async Task<string> SendSOSAsync(SOSSignal sosSignal)
        {
            var json = JsonConvert.SerializeObject(new { sos_signal = sosSignal });

            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("http://15.222.250.19/sos", content);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}


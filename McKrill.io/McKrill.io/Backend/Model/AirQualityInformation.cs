using System;
using Newtonsoft.Json;

namespace McKrill.io.Backend.Model
{
    public class AirQualityInformationWrapper
    {
        [JsonProperty("information")]
        public AirQualityInformation AirQualityInformation { get; set; }
    }

    public class AirQualityInformation
    {
        [JsonProperty("int_air_quality")]
        public int IntAirQuality { get; set; }
    }
}


using System;
using Newtonsoft.Json;

namespace McKrill.io.Backend.Model
{
    public class TemperatureInformationWrapper
    {
        [JsonProperty("information")]
        public TemperatureInformation TemperatureInformation { get; set; }
    }

    public class TemperatureInformation
    {
        [JsonProperty("ext_water_temp")]
        public float ExtWaterTemp { get; set; }

        [JsonProperty("int_temp")]
        public float IntTemp { get; set; }
    }
}


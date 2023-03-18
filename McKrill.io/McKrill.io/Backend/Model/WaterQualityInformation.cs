using System;
using Newtonsoft.Json;

namespace McKrill.io.Backend.Model
{
    public class WaterQualityInformation
    {
        [JsonProperty("int_water_quality")]
        public int IntWaterQuality { get; set; }
    }
}


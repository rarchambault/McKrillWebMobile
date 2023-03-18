using System;
using Newtonsoft.Json;

namespace McKrill.io.Backend.Model
{
    public class PowerLevelInformationWrapper
    {
        [JsonProperty("information")]
        public PowerLevelInformation PowerLevelInformation { get; set; }
    }

    public class PowerLevelInformation
    {
        [JsonProperty("power_levels")]
        public float PowerLevels { get; set; }
    }
}


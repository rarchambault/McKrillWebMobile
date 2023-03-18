using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace McKrill.io.Backend.Model
{

    public class TransitInformationWrapper
    {
        [JsonProperty("transit")]
        public ObservableCollection<Transit> TransitList { get; set; }
    }

    [JsonArray]
    public class Transit
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("frequency")]
        public int Frequency { get; set; }

        [JsonProperty("line")]
        public int Line { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("schedule")]
        public string Schedule { get; set; }
    }
}


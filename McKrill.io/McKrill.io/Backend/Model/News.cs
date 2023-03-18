using System;
using Newtonsoft.Json;

namespace McKrill.io.Backend.Model
{
    public class News
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("type")]
        public int Type { get; set; }
    }
}


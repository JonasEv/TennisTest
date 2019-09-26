using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TestTennis.Application.DTOs
{
    public class Data
    {
        [JsonProperty("rank")]
        public int Rank { get; set; }
        [JsonProperty("points")]
        public int Points { get; set; }
        [JsonProperty("weight")]
        public int Weight { get; set; }
        [JsonProperty("height")]
        public int Height { get; set; }
        [JsonProperty("age")]
        public int Age { get; set; }
        [JsonProperty("last")]
        public List<bool> Last { get; set; }
    }
}

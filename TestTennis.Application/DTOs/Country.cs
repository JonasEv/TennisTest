using System;
using Newtonsoft.Json;

namespace TestTennis.Application.DTOs
{
    public class Country
    {
        [JsonProperty("picture")]
        public string Picture { get; set; }
        [JsonProperty("code")]
        public string Code { get; set; }
    }
}

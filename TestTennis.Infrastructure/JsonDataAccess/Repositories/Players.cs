using System.Collections.Generic;
using Newtonsoft.Json;
using TestTennis.Application.DTOs;

namespace TestTennis.Infrastructure.JsonDataAccess.Repositories
{
    public class Players
    {
        [JsonProperty("players")]
        public List<Player> PlayerList { get; set; }
    }
}

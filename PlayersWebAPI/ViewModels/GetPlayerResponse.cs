using PlayersWebAPI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayersWebAPI.ViewModels
{
    public class GetPlayerResponse
    {
        [Newtonsoft.Json.JsonProperty("player", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Player Player { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static GetPlayerResponse FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<GetPlayerResponse>(data);
        }
    }
}

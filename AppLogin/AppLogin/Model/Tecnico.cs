using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogin.Model
{
    public class Tecnico
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("nome")]
        public string Nome { get; set; }
        [JsonProperty("token")]
        public string Token { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("lat")]
        public Double Lat { get; set; }
        [JsonProperty("lng")]
        public Double Lng { get; set; }

    }
}

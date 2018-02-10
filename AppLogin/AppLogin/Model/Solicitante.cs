using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogin.Model
{
    public class Solicitante
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("descricao")]
        public string Descricao { get; set; }
        [JsonProperty("prestadorid")]
        public int Prestadorid { get; set; }
        [JsonProperty("clientid")]
        public int Clientid { get; set; }
        [JsonProperty("lat")]
        public Double Lat { get; set; }
        [JsonProperty("lng")]
        public Double Lng { get; set; }
        [JsonProperty("inicio")]
        public DateTime Inicio { get; set; }
        [JsonProperty("final")]
        public DateTime Final { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
    }
}

using Newtonsoft.Json;

namespace clienteGrupoVision.Models
{
    public class pokemon
    {
        [JsonProperty("abilities")]
        public List<string> Abilities { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
   

}

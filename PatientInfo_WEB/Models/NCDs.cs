using Newtonsoft.Json;

namespace PatientInfo_WEB.Models
{
    public class NCDs
    {
        [JsonProperty("result")]
        public List<NDC> Ncd { get; set; }
    }
}

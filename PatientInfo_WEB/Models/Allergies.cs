using Newtonsoft.Json;

namespace PatientInfo_WEB.Models
{
    public class Allergies
    {
        [JsonProperty("result")]
        public List<Allergy> Allergy { get; set; }
    }
}

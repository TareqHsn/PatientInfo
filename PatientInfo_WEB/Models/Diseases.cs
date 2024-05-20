using Newtonsoft.Json;

namespace PatientInfo_WEB.Models
{
    public class Diseases
    {
        [JsonProperty("result")]
        public List<DiseaseInfo> DiseaseInformation { get; set; }
    }
}

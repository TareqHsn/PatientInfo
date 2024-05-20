using Newtonsoft.Json;

namespace PatientInfo_WEB.Models
{
    public class PatientDetails
    {
        [JsonProperty("result")]
        public List<Patient> PatientInformations { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace PatientInfo_API.Models
{
	public enum Epilepsy
	{
		None=0,
		Yes=1,
	}
	public class Patient
	{
        public int PatientId { get; set; }
		public string PatientName { get; set; }
		public Epilepsy Epilepsy { get; set; }
        [JsonIgnore]
        public ICollection<NDC_Detail> NDC_Details { get; set; }
        [JsonIgnore]
        public ICollection<Allergy_Detail>Allergy_Details { get; set; }
    }
}

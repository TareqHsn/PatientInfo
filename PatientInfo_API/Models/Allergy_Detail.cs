using System.Text.Json.Serialization;

namespace PatientInfo_API.Models
{
	public class Allergy_Detail
	{
		public int Allergy_DetailId { get; set; }
		public int? PatientId { get; set; }
		public int? AllergyId { get; set; }
		public virtual Patient Patient { get; set; }
        [JsonIgnore]
        public virtual Allergy Allergy { get; set; }

	}
}

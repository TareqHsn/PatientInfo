using System.Text.Json.Serialization;

namespace PatientInfo_API.Models
{
	public class NDC_Detail
	{
		public int NDC_DetailId { get; set; }
		public int? NDCId { get; set; }
		public int? PatientId { get; set; }
		public virtual NDC NDC { get; set; }
        [JsonIgnore]
        public virtual Patient Patient { get; set; }

	}
}

using System.Text.Json.Serialization;

namespace PatientInfo_API.Models
{
	public class NDC_Detail
	{
      
        public string Id { get; set; } = null!;

        public string PatientId { get; set; } = null!;

        public string Ncdid { get; set; } = null!;

        public DateTime CreationDate { get; set; }

        public DateTime ModifierDate { get; set; }

        public virtual NDC Ncd { get; set; } = null!;

        public virtual Patient Patient { get; set; } = null!;

    }
}

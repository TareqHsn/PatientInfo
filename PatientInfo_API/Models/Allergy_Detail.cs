using System.Text.Json.Serialization;

namespace PatientInfo_API.Models
{
	public class Allergy_Detail
	{
       

        public string Id { get; set; } = null!;

        public string PatientId { get; set; } = null!;

        public string AllergieId { get; set; } = null!;

        public DateTime CreationDate { get; set; }

        public DateTime ModifierDate { get; set; }

        public virtual Allergy Allergie { get; set; } = null!;

        public virtual Patient Patient { get; set; } = null!;

    }
}

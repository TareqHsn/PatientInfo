using System.Text.Json.Serialization;

namespace PatientInfo_WEB.Models
{
	public class Allergy_Detail
	{
        //public int Allergy_DetailId { get; set; }
        //public int? PatientId { get; set; }
        //public int? AllergyId { get; set; }
        //public virtual Patient Patient { get; set; }
        //[JsonIgnore]
        //public virtual Allergy Allergy { get; set; }

        public string Id { get; set; } = null!;

        public string PatientId { get; set; } = null!;

        public string AllergieId { get; set; } = null!;

        public DateTime CreationDate { get; set; }

        public DateTime ModifierDate { get; set; }

        public virtual Allergy Allergie { get; set; } = null!;

        public virtual Patient Patient { get; set; } = null!;

    }
}

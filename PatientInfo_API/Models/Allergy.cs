namespace PatientInfo_API.Models
{
	public class Allergy
	{
       
        public string Id { get; set; } = null!;

        public string Details { get; set; } = null!;

        public bool IsActive { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModifierDate { get; set; }

        public virtual ICollection<Allergy_Detail> AllergiesDetails { get; set; } = new List<Allergy_Detail>();
    }
}

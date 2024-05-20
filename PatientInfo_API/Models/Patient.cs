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
        
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

        public bool IsActve { get; set; }

        public string DiseaseId { get; set; } = null!;

        public bool Epliepsy { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModifierDate { get; set; }

        public virtual ICollection<Allergy_Detail> AllergiesDetails { get; set; } = new List<Allergy_Detail>();

        public virtual DiseaseInfo Disease { get; set; } = null!;

        public virtual ICollection<NDC_Detail> NcdDetails { get; set; } = new List<NDC_Detail>();
    }
}

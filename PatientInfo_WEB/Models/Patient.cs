using System.Text.Json.Serialization;

namespace PatientInfo_WEB.Models
{
	public enum Epilepsy
	{
		None=0,
		Yes=1,
	}
	public class Patient
	{
        //      public int PatientId { get; set; }
        //public string PatientName { get; set; }
        //public Epilepsy Epilepsy { get; set; }
        //      [JsonIgnore]
        //      public ICollection<NDC_Detail> NDC_Details { get; set; }
        //      [JsonIgnore]
        //      public ICollection<Allergy_Detail>Allergy_Details { get; set; }
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

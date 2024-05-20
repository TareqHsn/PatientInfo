namespace PatientInfo_API.Models
{
	public class NDC
	{
       
        public string Id { get; set; } = null!;

        public string Details { get; set; } = null!;

        public bool IsActive { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModifierDate { get; set; }

        public virtual ICollection<NDC_Detail> NcdDetails { get; set; } = new List<NDC_Detail>();
    }
}

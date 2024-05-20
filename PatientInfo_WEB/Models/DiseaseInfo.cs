﻿namespace PatientInfo_WEB.Models
{
	public class DiseaseInfo
	{
        public string Id { get; set; } = null!;

        public string Details { get; set; } = null!;

        public bool IsActive { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModifierDate { get; set; }
    }
}

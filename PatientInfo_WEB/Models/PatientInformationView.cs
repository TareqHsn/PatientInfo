namespace PatientInfo_WEB.Models
{
    public class PatientInformationView
    {
        public string Name { get; set; }
        public DiseaseInfo DiseaseInformation { get; set; }
        public List<DiseaseInfo> DiseaseInformations { get; set; }
        //public List<DiseaseInformation> SelectedDiseaseInformations { get; set; }
        public Epilepsy Epilepsy { get; set; }
        public NDC NCD { get; set; }
        public List<NDC> NCDs { get; set; }
        public List<NDC> SelectedNCDs { get; set; }
        public Allergy Allergy { get; set; }
        public List<Allergy> Allergies { get; set; }
        public List<Allergy> SelectedAllergies { get; set; } = new List<Allergy>();

        public List<Patient> PatientDetails { get; set; } = new List<Patient>();
    }
}

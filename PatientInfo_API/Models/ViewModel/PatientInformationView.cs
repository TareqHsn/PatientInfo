﻿using PatientInfo_API.Models.Enums;
using PatientInfo_API.Models.ViewModel;

namespace PatientInformationsAPI.Model
{
    public class PatientInformationView
    {
        public string Name { get; set; }
        public DiseaseInformationView DiseaseInformation { get; set; }
        public Epilepsy Epilepsy { get; set; }
        public List<NcdView> SelectedNCDs { get; set; }
        public List<AllergyView> SelectedAllergies { get; set; } = new List<AllergyView>();
    }
}

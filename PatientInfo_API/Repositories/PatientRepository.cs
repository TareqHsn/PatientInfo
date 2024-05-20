using Microsoft.EntityFrameworkCore;
using PatientInfo_API.Data;
using PatientInfo_API.Models;
using PatientInfo_API.Services;
using PatientInformationsAPI.Model;

namespace PatientInfo_API.Repositories
{

        public class PatientRepository : IPatientService
        {
        private readonly AppDbContext _patientInformationContext;

        public PatientRepository(AppDbContext patientInformationContext)
        {
            _patientInformationContext = patientInformationContext;
        }

        public async Task<List<Patient>> PatientInformationDetails()
        {
            var details = _patientInformationContext.PatientInformations.Include(x => x.Disease)
                .Include(x => x.NcdDetails).Include(x => x.AllergiesDetails).ToList();
            return details;
        }

        public async Task<string> PostPatientInformationDetails(PatientInformationView patientInformation)
        {
            Patient information = new Patient();
            information.Epliepsy = patientInformation.Epilepsy.HasFlag(Models.Enums.Epilepsy.Yes);
            information.DiseaseId = patientInformation.DiseaseInformation.Id;
            information.Name = patientInformation.Name;
            information.ModifierDate = DateTime.Now;
            information.CreationDate = DateTime.Now;
            information.IsActve = true;
            information.Id = Guid.NewGuid().ToString();
            _patientInformationContext.PatientInformations.Add(information);

            foreach (var item in patientInformation.SelectedNCDs)
            {
                _patientInformationContext.NcdDetails.Add(new NDC_Detail()
                {
                    Id = Guid.NewGuid().ToString(),
                    Ncdid = item.Id,
                    PatientId = information.Id,
                    CreationDate = DateTime.Now,
                    ModifierDate = DateTime.Now
                });
            }
            foreach (var item in patientInformation.SelectedAllergies)
            {
                _patientInformationContext.AllergiesDetails.Add(new Allergy_Detail()
                {
                    Id = Guid.NewGuid().ToString(),
                    AllergieId = item.Id,
                    PatientId = information.Id,
                    CreationDate = DateTime.Now,
                    ModifierDate = DateTime.Now
                });
            }
            _patientInformationContext.SaveChanges();

            return "Object created";
        }


    }
}

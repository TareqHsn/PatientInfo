using PatientInfo_API.Models;
using PatientInformationsAPI.Model;

namespace PatientInfo_API.Services
{
    public interface IPatientService
    {
        public Task<List<Patient>> PatientInformationDetails();
        public Task<string> PostPatientInformationDetails(PatientInformationView patientInformation);
        //Task<IEnumerable<Patient>> GetAllPatientsAsync();
        //Task<Patient> GetPatientByIdAsync(int id);
        //Task AddPatientAsync(Patient patient);
        //Task UpdatePatientAsync(Patient patient);
        //Task DeletePatientAsync(int id);
    }
}

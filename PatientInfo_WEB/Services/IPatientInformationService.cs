using PatientInfo_WEB.Models;

namespace PatientInfo_WEB.Services
{
    public interface IPatientInformationService
    {
        Task<List<Patient>> getAllPatientDetails();
        Task<List<DiseaseInfo>> getAllDiseases();
        Task<List<NDC>> getAllNCDs();
        Task<List<Allergy>> getAllAllergies();
        Task<string> postPatientInformation(PatientInformationView patientInformation);
    }
}

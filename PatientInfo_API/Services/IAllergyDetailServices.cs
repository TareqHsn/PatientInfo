using PatientInfo_API.Models;

namespace PatientInfo_API.Services
{
    public interface IAllergyDetailServices
    {
        Task<IEnumerable<Allergy_Detail>> GetAllergyDetailsByPatientIdAsync(int patientId);
        Task AddAllergyDetailAsync(Allergy_Detail allergyDetail);
        Task DeleteAllergyDetailAsync(int id);
    }
}

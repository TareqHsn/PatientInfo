using PatientInfo_API.Models;

namespace PatientInfo_API.Services
{
    public interface INCDDetailServices
    {
        Task<IEnumerable<NDC_Detail>> GetNCDDetailsByPatientIdAsync(int patientId);
        Task AddNCDDetailAsync(NDC_Detail ncdDetail);
        Task DeleteNCDDetailAsync(int id);
    }
}

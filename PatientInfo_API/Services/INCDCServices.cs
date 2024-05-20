using PatientInfo_API.Models;

namespace PatientInfo_API.Services
{
    public interface INCDCServices
    {
        public Task<List<NDC>> GetAllNcd();

        //Task<List<NDC>> GetNDCList();
        //Task<NDC> GetSingleNDC(int id);
        //Task<int> SaveNDC(NDC NDC);
        //Task<int> UpdateNDC(int id, NDC NDC);
        //Task<bool> DeleteNDC(int id);
    }
}

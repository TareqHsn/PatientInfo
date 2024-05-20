using PatientInfo_API.Models;

namespace PatientInfo_API.Services
{
    public interface IDiseaseInfoServices
    {
        //Task<List<DiseaseInfo>> GetDiseaseInfoList();
        //Task<DiseaseInfo> GetSingleDiseaseInfo(int id);
        //Task<int> SaveDiseaseInfo(DiseaseInfo DiseaseInfo);
        //Task<int> UpdateDiseaseInfo(int id, DiseaseInfo DiseaseInfo);
        //Task<bool> DeleteDiseaseInfo(int id);

        public Task<List<DiseaseInfo>> GetAllDiseaseInformations();
    }
}

using PatientInfo_API.Models;

namespace PatientInfo_API.Services
{
    public interface IAllergiesServices
    {
        //Task<List<Allergy>> GetAllergyList();
        //Task<Allergy> GetSingleAllergy(int id);
        //Task<int> SaveAllergy(Allergy allergy);
        //Task<int> UpdateAllergy(int id, Allergy allergy);
        //Task<bool> DeleteAllergy(int id);

        public Task<List<PatientInfo_API.Models.Allergy>> getAllAllergies();


    }
}

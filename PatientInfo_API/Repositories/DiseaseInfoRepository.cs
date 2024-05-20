using PatientInfo_API.Data;
using PatientInfo_API.Models;
using PatientInfo_API.Services;

namespace PatientInfo_API.Repositories
{
    public class DiseaseDetailsRepository : IDiseaseInfoServices
    {
        private readonly AppDbContext _context;

        public DiseaseDetailsRepository(AppDbContext patientInformationContext)
        {
            _context = patientInformationContext;
        }

        public async Task<List<DiseaseInfo>> GetAllDiseaseInformations()
        {
            var list = _context.DiseaseInformations.ToList();
            return list;
        }
    }
   
}

using Microsoft.EntityFrameworkCore;
using PatientInfo_API.Data;
using PatientInfo_API.Models;
using PatientInfo_API.Services;

namespace PatientInfo_API.Repositories
{
    public class NCDRepository : INCDCServices
    {
        private readonly AppDbContext _context;

        public NCDRepository(AppDbContext patientInformationContext)
        {
            _context = patientInformationContext;
        }

        public async Task<List<NDC>> GetAllNcd()
        {
            return _context.Ncds.ToList();
            
        }
    }
    
}

using Microsoft.EntityFrameworkCore;
using PatientInfo_API.Data;
using PatientInfo_API.Models;
using PatientInfo_API.Services;

namespace PatientInfo_API.Repositories
{
    public class DiseaseInfoRepository : IDiseaseInfoServices
    {
        private readonly AppDbContext _context;

        public DiseaseInfoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteDiseaseInfo(int id)
        {
            var existing = await _context.Diseases.FindAsync(id);

            if (existing == null)
            {
                return false;
            }

            _context.Diseases.Remove(existing);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<DiseaseInfo>> GetDiseaseInfoList()
        {
            var List = await _context.Diseases.ToListAsync();
            return List;
        }

        public async Task<DiseaseInfo> GetSingleDiseaseInfo(int id)
        {
            var singleAllergy = await _context.Diseases
            .Where(x => x.DiseaseInfoId == id).FirstOrDefaultAsync();
            return singleAllergy;
        }

        public async Task<int> SaveDiseaseInfo(DiseaseInfo DiseaseInfo)
        {
            await _context.AddAsync(DiseaseInfo);
            await _context.SaveChangesAsync();
            return 0;
        }

        public async Task<int> UpdateDiseaseInfo(int id, DiseaseInfo DiseaseInfo)
        {
            _context.Entry(DiseaseInfo).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

                if (!DiseaseExists(id))
                {
                    throw;
                }
            }
            return 0;
        }

        private bool DiseaseExists(int id)
        {
            return (_context.Diseases?.Any(x => x.DiseaseInfoId == id)).GetValueOrDefault();
        }
    }
}

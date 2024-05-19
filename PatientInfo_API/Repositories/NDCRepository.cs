using Microsoft.EntityFrameworkCore;
using PatientInfo_API.Data;
using PatientInfo_API.Models;
using PatientInfo_API.Services;

namespace PatientInfo_API.Repositories
{
    public class NDCRepository : INDCServices
    {
        private readonly AppDbContext _context;

        public NDCRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteNDC(int id)
        {
            var existing = await _context.NCDs.FindAsync(id);

            if (existing == null)
            {
                return false;
            }

            _context.NCDs.Remove(existing);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<NDC>> GetNDCList()
        {
            var List = await _context.NCDs.ToListAsync();
            return List;
        }

        public async Task<NDC> GetSingleNDC(int id)
        {
            var singleNdc = await _context.NCDs
            .Where(x => x.NDCId == id).FirstOrDefaultAsync();
            return singleNdc;
        }

        public async Task<int> SaveNDC(NDC NDC)
        {
            await _context.AddAsync(NDC);
            await _context.SaveChangesAsync();
            return 0;
        }

        public async Task<int> UpdateNDC(int id, NDC NDC)
        {
            _context.Entry(NDC).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

                if (!NDCsExists(id))
                {
                    throw;
                }
            }
            return 0;
        }

        private bool NDCsExists(int id)
        {
            return (_context.NCDs?.Any(x => x.NDCId == id)).GetValueOrDefault();
        }
    }
}

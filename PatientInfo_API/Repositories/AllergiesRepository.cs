using Microsoft.EntityFrameworkCore;
using PatientInfo_API.Data;
using PatientInfo_API.Models;
using PatientInfo_API.Services;

namespace PatientInfo_API.Repositories
{
    public class AllergiesRepository : IAllergiesServices
    {
        private readonly AppDbContext _context;

        public AllergiesRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> SaveAllergy(Allergy allergy)
        {
            await _context.AddAsync(allergy);
            await _context.SaveChangesAsync();
            return 0;
        }
        public async Task<List<Allergy>> GetAllergyList()
        {
            var allergyList = await _context.Allergies.ToListAsync();
            return allergyList;
        }
        public async Task<Allergy> GetSingleAllergy(int id)
        {
            var singleAllergy = await _context.Allergies             
              .Where(x => x.AllergyId == id).FirstOrDefaultAsync();
            return singleAllergy;
        }
        public async Task<int> UpdateAllergy(int id, Allergy allergy)
        {
            _context.Entry(allergy).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

                if (!AllergiesExists(id))
                {
                    throw;
                }
            }
            return 0;
        }

        private bool AllergiesExists(int id)
        {
            return (_context.Allergies?.Any(x => x.AllergyId == id)).GetValueOrDefault();
        }

       
        public async Task<bool> DeleteAllergy(int id)
        {
            var existing = await _context.Allergies.FindAsync(id);

            if (existing == null)
            {
                return false;
            }

            _context.Allergies.Remove(existing);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}

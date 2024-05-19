
using Microsoft.EntityFrameworkCore;
using PatientInfo_API.Data;
using PatientInfo_API.Models;
using PatientInfo_API.Services;

namespace PatientInfo_API.Repositories
{
    public class AllergyDetailRepository : IAllergyDetailServices
    {
        private readonly AppDbContext _context;
        public AllergyDetailRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Allergy_Detail>> GetAllergyDetailsByPatientIdAsync(int patientId)
        {
            return await _context.Allergy_Details.Where(a => a.PatientId == patientId).ToListAsync();
        }

        public async Task AddAllergyDetailAsync(Allergy_Detail allergyDetail)
        {
            _context.Allergy_Details.Add(allergyDetail);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAllergyDetailAsync(int id)
        {
            var allergyDetail = await _context.Allergy_Details.FindAsync(id);
            if (allergyDetail != null)
            {
                _context.Allergy_Details.Remove(allergyDetail);
                await _context.SaveChangesAsync();
            }
        }
    }
}

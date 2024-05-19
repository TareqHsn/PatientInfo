using Microsoft.EntityFrameworkCore;
using PatientInfo_API.Data;
using PatientInfo_API.Models;
using PatientInfo_API.Services;

namespace PatientInfo_API.Repositories
{
    public class PatientRepository : IPatientService
    {
        private readonly AppDbContext _context;

        public PatientRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Patient>> GetAllPatientsAsync()
        {
            return await _context.Patients
                .Include(p => p.NDC_Details)
                .Include(p => p.Allergy_Details)
                .ToListAsync();
        }

        public async Task<Patient> GetPatientByIdAsync(int id)
        {
            return await _context.Patients
                .Include(p => p.NDC_Details)
                .Include(p => p.Allergy_Details)
                .FirstOrDefaultAsync(p => p.PatientId == id);
        }

        public async Task AddPatientAsync(Patient patient)
        {
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePatientAsync(Patient patient)
        {
            _context.Patients.Update(patient);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePatientAsync(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient != null)
            {
                _context.Patients.Remove(patient);
                await _context.SaveChangesAsync();
            }
        }
    }
}

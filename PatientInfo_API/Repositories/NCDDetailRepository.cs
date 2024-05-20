//using Microsoft.EntityFrameworkCore;
//using PatientInfo_API.Data;
//using PatientInfo_API.Models;
//using PatientInfo_API.Services;

//namespace PatientInfo_API.Repositories
//{
//    public class NCDDetailRepository:INCDDetailServices
//    {
//        private readonly AppDbContext _context;

//        public NCDDetailRepository(AppDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<IEnumerable<NDC_Detail>> GetNCDDetailsByPatientIdAsync(int patientId)
//        {
//            return await _context.NCD_Details.Where(n => n.PatientId == patientId).ToListAsync();
//        }

//        public async Task AddNCDDetailAsync(NDC_Detail ncdDetail)
//        {
//            _context.NCD_Details.Add(ncdDetail);
//            await _context.SaveChangesAsync();
//        }

//        public async Task DeleteNCDDetailAsync(int id)
//        {
//            var ncdDetail = await _context.NCD_Details.FindAsync(id);
//            if (ncdDetail != null)
//            {
//                _context.NCD_Details.Remove(ncdDetail);
//                await _context.SaveChangesAsync();
//            }
//        }
//    }
//}

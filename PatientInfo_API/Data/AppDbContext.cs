using Microsoft.EntityFrameworkCore;
using PatientInfo_API.Models;

namespace PatientInfo_API.Data
{
	public class AppDbContext:DbContext
	{
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<DiseaseInfo> Diseases { get; set; }
        public DbSet<NDC> NCDs { get; set; }
        public DbSet<Allergy> Allergies { get; set; }
        public DbSet<NDC_Detail> NCD_Details { get; set; }
        public DbSet<Allergy_Detail> Allergy_Details { get; set; }
    }

   
}

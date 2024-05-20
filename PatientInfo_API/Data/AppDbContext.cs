using Microsoft.EntityFrameworkCore;
using PatientInfo_API.Models;

namespace PatientInfo_API.Data
{
	public partial class AppDbContext:DbContext
	{
       
        private readonly string _connectionString;

        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration config)
            : base(options)
        {
            _connectionString = config.GetSection("Api")["ConnectionString"];
        }

        public virtual DbSet<Allergy_Detail> AllergiesDetails { get; set; }
        public virtual DbSet<Allergy> Allergies { get; set; }
        public virtual DbSet<DiseaseInfo> DiseaseInformations { get; set; }
        public virtual DbSet<NDC> Ncds { get; set; }
        public virtual DbSet<NDC_Detail> NcdDetails { get; set; }
        public virtual DbSet<Patient> PatientInformations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Allergy_Detail>(entity =>
            {
                entity.ToTable("Allergies_Details");

                entity.Property(e => e.Id).HasMaxLength(50);
                entity.Property(e => e.AllergieId).HasMaxLength(50);
                entity.Property(e => e.CreationDate).HasColumnType("datetime");
                entity.Property(e => e.ModifierDate).HasColumnType("datetime");
                entity.Property(e => e.PatientId).HasMaxLength(50);

                entity.HasOne(d => d.Allergie).WithMany(p => p.AllergiesDetails)
                    .HasForeignKey(d => d.AllergieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Allergies_Details_Allergies");

                entity.HasOne(d => d.Patient).WithMany(p => p.AllergiesDetails)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Allergies_Details_PatientInformations");
            });

            modelBuilder.Entity<Allergy>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(50);
                entity.Property(e => e.CreationDate).HasColumnType("datetime");
                entity.Property(e => e.Details).HasMaxLength(50);
                entity.Property(e => e.ModifierDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<DiseaseInfo>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(50);
                entity.Property(e => e.CreationDate).HasColumnType("datetime");
                entity.Property(e => e.Details).HasMaxLength(50);
                entity.Property(e => e.ModifierDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<NDC>(entity =>
            {
                entity.ToTable("NCDs");

                entity.Property(e => e.Id).HasMaxLength(50);
                entity.Property(e => e.CreationDate).HasColumnType("datetime");
                entity.Property(e => e.Details).HasMaxLength(50);
                entity.Property(e => e.ModifierDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<NDC_Detail>(entity =>
            {
                entity.ToTable("NCD_Details");

                entity.Property(e => e.Id).HasMaxLength(50);
                entity.Property(e => e.CreationDate).HasColumnType("datetime");
                entity.Property(e => e.ModifierDate).HasColumnType("datetime");
                entity.Property(e => e.Ncdid)
                    .HasMaxLength(50)
                    .HasColumnName("NCDId");
                entity.Property(e => e.PatientId).HasMaxLength(50);

                entity.HasOne(d => d.Ncd).WithMany(p => p.NcdDetails)
                    .HasForeignKey(d => d.Ncdid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NCD_Details_NCDs");

                entity.HasOne(d => d.Patient).WithMany(p => p.NcdDetails)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NCD_Details_PatientInformations");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(50);
                entity.Property(e => e.CreationDate).HasColumnType("datetime");
                entity.Property(e => e.DiseaseId).HasMaxLength(50);
                entity.Property(e => e.ModifierDate).HasColumnType("datetime");
                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Disease).WithMany(p => p.PatientInformations)
                    .HasForeignKey(d => d.DiseaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PatientInformations_DiseaseInformations");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

   
}

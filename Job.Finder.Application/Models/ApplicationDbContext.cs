using Job.Finder.Application.Models.JobApplicationForm;
using Microsoft.EntityFrameworkCore;

namespace Job.Finder.Application.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Admin> Admin { get; set; }
        public DbSet<ApplicationForm> ApplicationForm { get; set; }
        public DbSet<EducationDetail> EducationDetail { get; set; }
        public DbSet<WorkExperience> WorkExperience { get; set; }
        public DbSet<KnownLanguage> KnownLanguage { get; set; }
        public DbSet<TechnicalExperience> TechnicalExperience { get; set; }
    }
}

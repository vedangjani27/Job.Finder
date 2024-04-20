using Job.Finder.Application.Models;
using Job.Finder.Application.Services.Interfaces;

namespace Job.Finder.Application.Services.Implements
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _db;
        public DbInitializer(ApplicationDbContext db) => _db = db;  
        public void Initialize()
        {
            _db.Database.EnsureCreated();

            // Check if there are any admins already
            if (!_db.Admin.Any())
            {
                // Create a default admin
                var admin = new Admin
                {
                    Username = "admin",
                    Password = "admin" 
                };
                _db.Admin.Add(admin);
                _db.SaveChanges();
            }
        }
    }
}

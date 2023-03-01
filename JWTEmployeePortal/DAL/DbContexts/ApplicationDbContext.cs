using JWTEmployeePortal.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace JWTEmployeePortal.DAL.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RegisterEmployee>();
        }

        public DbSet<RegisterEmployee> Employees { get; set; }
    }
}

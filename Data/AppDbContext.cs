using INVENTAR.IO.Models;
using Microsoft.EntityFrameworkCore;

namespace INVENTAR.IO.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected AppDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Departments>().HasKey(e => e.DepartmentId);
            modelBuilder.Entity<Departments>().Property(e =>  e.DepartmentId).ValueGeneratedOnAdd();
        }

        public virtual DbSet<Departments> Departments { get; set; }
    }
}

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
            modelBuilder.Entity<Colaborators>().HasKey(e => e.ColaboratorId);
            modelBuilder.Entity<Colaborators>().Property(e => e.ColaboratorId).ValueGeneratedOnAdd();
        }

        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<Colaborators> Colaborators { get; set; }
    }
}

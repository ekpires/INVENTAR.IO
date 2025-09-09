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

        public virtual DbSet<Departments> Departments { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;

namespace Waybill.Models.AppDbContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Computer> Computers { get; set; }
        public DbSet<Localisation> Localisations { get; set; }

    }
}

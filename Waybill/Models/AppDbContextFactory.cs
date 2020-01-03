using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Waybill.Models
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
        {
            public AppDbContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
                optionsBuilder.UseSqlServer("Server=(local)\\sqlexpress; Database=WaybillDb; Trusted_Connection=True; MultipleActiveResultSets=True");

                return new AppDbContext(optionsBuilder.Options);
            }
        }
    }

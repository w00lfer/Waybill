using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Waybill.Models;
using Waybill.Models.AppDbContext;
using Waybill.Repositories.Interfaces;

namespace Waybill.Repositories
{
    class ComputerRepository : GenericRepository<Computer>, IComputerRepository
    {
        public ComputerRepository(AppDbContext appDbContext)
        : base(appDbContext)
        { }

        public async Task<int> GetComputerPriceByModelNameAsync(string modelName) =>
            await GetAll().Where(c => c.ModelName == modelName).Select(c => c.Price).FirstOrDefaultAsync();

        public async Task<int> GetComputerWeightByModelNameAsync(string modelName) =>
            await GetAll().Where(c => c.ModelName == modelName).Select(c => c.Weight).FirstOrDefaultAsync();
    }
}

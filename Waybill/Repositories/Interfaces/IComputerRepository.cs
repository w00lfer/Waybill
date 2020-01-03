using System.Threading.Tasks;
using Waybill.Models;

namespace Waybill.Repositories.Interfaces
{
    public interface IComputerRepository : IGenericRepository<Computer>
    {
        public Task<int> GetComputerWeightByModelNameAsync(string modelName);
        public Task<int> GetComputerPriceByModelNameAsync(string modelName);
    }
}

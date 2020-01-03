using System.Collections.Generic;
using System.Threading.Tasks;
using Waybill.Models;

namespace Waybill.Services.Interfaces
{
    public interface IComputerService
    {
        public Task<List<Computer>> GetAllComputersAsync();
        public Task<Computer> GetComputerByIdAsync(int id);
        public Task<int> GetComputerWeightByModelNameAsync(string modelName);
        public Task<int> GetComputerPriceByModelNameAsync(string modelName);
        public Task AddComputerAsync(Computer computer);
        public Task EditComputerAsync(Computer computer);
        public Task DeleteComputerAsync(int id);

    }
}

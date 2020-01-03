using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Waybill.Models;
using Waybill.Repositories.Interfaces;
using Waybill.Services.Interfaces;

namespace Waybill.Services
{
    class ComputerService : IComputerService
    {
        IComputerRepository _computerRepository;

        public ComputerService(IComputerRepository computerRepository) => _computerRepository = computerRepository;

        public async Task AddComputerAsync(Computer computer) => await _computerRepository.CreateAsync(computer);

        public async Task DeleteComputerAsync(int id) => await _computerRepository.DeleteAsync(id);

        public async Task EditComputerAsync(Computer computer) => await _computerRepository.UpdateAsync(computer);

        public async Task<List<Computer>> GetAllComputersAsync() => await _computerRepository.GetAll().ToListAsync();

        public async Task<Computer> GetComputerByIdAsync(int id) => await _computerRepository.GetByIdAsync(id);

        public async Task<int> GetComputerPriceByModelNameAsync(string modelName) => await _computerRepository.GetComputerPriceByModelNameAsync(modelName);

        public async Task<int> GetComputerWeightByModelNameAsync(string modelName) => await _computerRepository.GetComputerWeightByModelNameAsync(modelName);
    }
}

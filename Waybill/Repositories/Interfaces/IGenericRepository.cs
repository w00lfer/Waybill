﻿using System.Linq;
using System.Threading.Tasks;
using Waybill.Models;

namespace Waybill.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity>
        where TEntity : BaseEntity
    {
        public IQueryable<TEntity> GetAll();
        public Task<TEntity> GetByIdAsync(int id);
        public Task CreateAsync(TEntity entity);
        public Task UpdateAsync(TEntity entity);
        public Task DeleteAsync(int id);
    }
}

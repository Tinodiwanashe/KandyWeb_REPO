using KandyWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KandyWeb.Infrastructure.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> AddAsync(T entity);
        Task<T> GetAsync(string Id);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(string Id);
        Task<IReadOnlyList<T>> GetAllAsync(string queryString);
    }
}

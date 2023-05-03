using _153505_Shmatov.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153505_Shmatov.Applications.Abstractions
{
    public interface IBaseService<T> where T : Entity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T item);
        Task UpdateAsync(T item);
        Task DeleteAsync(int id);
    }
}

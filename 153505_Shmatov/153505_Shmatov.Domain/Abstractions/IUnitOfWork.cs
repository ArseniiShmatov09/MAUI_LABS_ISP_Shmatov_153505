using _153505_Shmatov.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153505_Shmatov.Domain.Abstractions
{
    public interface IUnitOfWork
    {
        IRepository<Author> AuthorRepository { get; }
        IRepository<Book> BookRepository { get; }
        public Task RemoveDatbaseAsync();
        public Task CreateDatabaseAsync();
        public Task SaveAllAsync();
    }
}

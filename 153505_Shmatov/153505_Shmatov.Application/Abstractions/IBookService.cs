using _153505_Shmatov.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153505_Shmatov.Applications.Abstractions
{
    public interface IBookService : IBaseService<Book>
    {
        Task<IEnumerable<Book>> GetAllBooksByAuthorAsync(int id);
        Task AddBookToAuthorAsync(int authorId, Book book);
        Task MoveBookToAnotherAuthorAsync(int firstAuthorId, int secondAuthorId, Book book);
    }
}

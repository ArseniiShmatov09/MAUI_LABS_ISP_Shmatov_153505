using _153505_Shmatov.Domain.Abstractions;
using _153505_Shmatov.Domain.Entities;
using _153505_Shmatov.Persistense.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153505_Shmatov.Persistense.Repository
{
    public class FakeUnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly Lazy<IRepository<Author>> _authorRepository;
        private readonly Lazy<IRepository<Book>> _bookRepository;

        public FakeUnitOfWork(/*AppDbContext context*/)
        {
           // _context = context;
            _authorRepository = new Lazy<IRepository<Author>>(() =>
            new FakeAuthorRepository());
            _bookRepository = new Lazy<IRepository<Book>>(() =>
            new FakeBookRepository());
        }

        public IRepository<Author> AuthorRepository => _authorRepository.Value;

        public IRepository<Book> BookRepository => _bookRepository.Value;

        public async Task CreateDatabaseAsync()
        {
            await _context.Database.EnsureCreatedAsync();
        }
        public async Task RemoveDatbaseAsync()
        {
            await _context.Database.EnsureDeletedAsync();
        }
        public async Task SaveAllAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}

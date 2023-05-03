using _153505_Shmatov.Domain.Abstractions;
using _153505_Shmatov.Domain.Entities;
using System.Linq.Expressions;

namespace _153505_Shmatov.Persistense.Repository
{
    public class FakeAuthorRepository : IRepository<Author>
    {
        List<Author> _authors;

        public FakeAuthorRepository()
        {
            _authors = new List<Author>()

            {
                 new Author(){ Id = 1, Name = "J.K. Rowling", Age = 56, DateOfBirth = "31.07.1965", Books = new List<Book>()},
                 new Author(){ Id = 2, Name = "Stephen King", Age = 74, DateOfBirth = "21.09.1947", Books = new List<Book>()},
            };
        }

        public Task AddAsync(Author entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Author entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Author> FirstOrDefaultAsync(Expression<Func<Author, bool>> filter, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Author> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<Author, object>>[]? includesProperties)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Author>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            return await Task.Run(() => _authors);
        }

        public Task<IReadOnlyList<Author>> ListAsync(Expression<Func<Author, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<Author, object>>[]? includesProperties)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Author entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }

    public class FakeBookRepository : IRepository<Book>
    {
        List<Book> _list = new List<Book>();

        public FakeBookRepository()
        {
            Random rand = new Random();
            int k = 1;
            for (int i = 1; i <= 2; i++)
                for (int j = 0; j < 15; j++)
                    _list.Add(new Book()
                    {
                        Id = k,
                        AuthorId = i,
                        Name = $"Book {k++}",
                        Price = rand.Next() % 1000,
                        Rating = rand.NextDouble() * 10,
                        YearOfPublication = $"01.01.199{j%10}"
                    });
        }

        public Task AddAsync(Book entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Book entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Book> FirstOrDefaultAsync(Expression<Func<Book, bool>> filter, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Book> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<Book, object>>[]? includesProperties)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Book>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Book>> ListAsync(Expression<Func<Book, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<Book, object>>[]? includesProperties)
        {
            var data = _list.AsQueryable();
            return data.Where(filter).ToList();
        }

        public Task UpdateAsync(Book entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}

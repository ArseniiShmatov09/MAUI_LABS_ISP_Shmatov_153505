using _153505_Shmatov.Applications.Abstractions;
using _153505_Shmatov.Domain.Abstractions;
using _153505_Shmatov.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153505_Shmatov.Applications.Services
{
    public class BookService : IBookService
    {
        private IUnitOfWork _unitOfWork;

        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(Book item)
        {
            await _unitOfWork.BookRepository.AddAsync(item);
            await _unitOfWork.SaveAllAsync();

        }

        public Task DeleteAsync(int id)
        {
            return _unitOfWork.BookRepository.DeleteAsync(this.GetByIdAsync(id).Result);
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _unitOfWork.BookRepository.ListAllAsync();
        }

        public Task<Book> GetByIdAsync(int id)
        {
            return _unitOfWork.BookRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Book item)
        {
            _unitOfWork.BookRepository.UpdateAsync(item);

            await _unitOfWork.SaveAllAsync();
        }

        public async Task AddBookToAuthorAsync(int authorId, Book book)
        {
            var author = await _unitOfWork.AuthorRepository.GetByIdAsync(authorId);
            author?.Books?.Add(book);
        }

        public async Task<IEnumerable<Book>> GetAllBooksByAuthorAsync(int authorId)
        {
            return await _unitOfWork.BookRepository.ListAsync(el => el.AuthorId == authorId);

        }

        public async Task MoveBookToAnotherAuthorAsync(int firstAuthorId, int secondAuthorId, Book book)
        {
            var firstAauthor = await _unitOfWork.AuthorRepository.GetByIdAsync(firstAuthorId);
            firstAauthor?.Books?.Remove(book);
            var secondAauthor = await _unitOfWork.AuthorRepository.GetByIdAsync(firstAuthorId);
            secondAauthor?.Books?.Add(book);
        }

    }
}

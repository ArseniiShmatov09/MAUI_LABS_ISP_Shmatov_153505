using _153505_Shmatov.Applications.Abstractions;
using _153505_Shmatov.Domain.Abstractions;
using _153505_Shmatov.Domain.Entities;

namespace _153505_Shmatov.Applications.Services
{
    public class AuthorService : IAuthorService
    {
        private IUnitOfWork _unitOfWork;

        public AuthorService(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(Author item)
        {
            await _unitOfWork.AuthorRepository.AddAsync(item);
            await _unitOfWork.SaveAllAsync();

        }

        public Task DeleteAsync(int id)
        {
            return _unitOfWork.AuthorRepository.DeleteAsync(this.GetByIdAsync(id).Result);
        }

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            return await _unitOfWork.AuthorRepository.ListAllAsync();
        }

        public Task<Author> GetByIdAsync(int id)
        {
            return _unitOfWork.AuthorRepository.GetByIdAsync(id);
        }

        public Task UpdateAsync(Author item)
        {
            return _unitOfWork.AuthorRepository.UpdateAsync(item);
        }
    }
}

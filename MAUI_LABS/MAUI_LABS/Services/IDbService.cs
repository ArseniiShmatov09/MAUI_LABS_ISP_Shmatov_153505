using MAUI_LABS.Entities;

namespace MAUI_LABS.Services
{
    public interface IDbService
    {
        public IEnumerable<Author> GetAllAuthors();
        public IEnumerable<Book> GetAuthorBooks(int id);
        public void Init();
        void DeleteAllData();

    }
}

using MAUI_LABS.Entities;
using SQLite;

namespace MAUI_LABS.Services
{
    public class SQLiteService : IDbService
    {
        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MyApp3.db");
        private SQLiteConnection database;

        public SQLiteService()
        {
            database = new SQLiteConnection(path);                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               
            database.CreateTable<Author>();
            database.CreateTable<Book>();

        }
        public IEnumerable<Author> GetAllAuthors()
        {
            return database.Table<Author>().ToList();
        }

        public IEnumerable<Book> GetAuthorBooks(int id)
        {
            return database.Table<Book>().Where(t => t.AuthorId == id).ToList();
        }

        public void Init()
        {
            var authors = new List<Author>
            {
                new Author("J.K. Rowling", 56, "31.07.1965", 4.8f),
                new Author("J.R.R. Tolkien", 81, "03.01.1892", 4.5f),
                new Author("Agatha Christie", 85, "15.09.1890", 4.3f),
                new Author("Stephen King", 74, "21.09.1947", 4.1f),
                new Author("Leo Tolstoy", 82, "09.09.1828", 4.6f),
                new Author("Jane Austen", 41, "16.12.1775", 4.2f),
                new Author("Ernest Hemingway", 62, "21.07.1899", 4.0f),
                new Author("Mark Twain", 74, "30.11.1835", 4.4f),
                new Author("Fyodor Dostoevsky", 59, "11.11.1821", 4.7f),
                new Author("Haruki Murakami", 72, "12.01.1949", 4.5f)

            };

            database.InsertAll(authors);

            var books = new List<Book>
            {
                new Book("Harry Potter and the Philosopher's Stone", "1997", 10, authors[0].Id),
                new Book("Harry Potter and the Chamber of Secrets", "1998", 12, authors[0].Id),
                new Book("Harry Potter and the Prisoner of Azkaban", "1999", 15, authors[0].Id),

                new Book("The Hobbit", "1937", 10, authors[1].Id),
                new Book("The Lord of the Rings: The Fellowship of the Ring", "1954", 12, authors[1].Id),
                new Book("The Lord of the Rings: The Two Towers", "1954", 15, authors[1].Id),


                new Book("Murder on the Orient Express", "1934", 10, authors[2].Id),
                new Book("Death on the Nile", "1937", 12, authors[2].Id),
                new Book("And Then There Were None", "1939", 15, authors[2].Id),

                new Book("Carrie", "1974", 10, authors[3].Id),
                new Book("The Shining", "1977", 12, authors[3].Id),
                new Book("It", "1986", 15, authors[3].Id),

                new Book("War and Peace", "1869", 10, authors[4].Id),
                new Book("Anna Karenina", "1877", 12, authors[4].Id),
                new Book("The Death of Ivan Ilyich", "1886", 15, authors[4].Id),


                new Book("Pride and Prejudice", "1813", 10, authors[5].Id),
                new Book("Sense and Sensibility", "1811", 12, authors[5].Id),
                new Book("Emma", "1815", 15, authors[5].Id),

                new Book("The Sun Also Rises", "1926", 10, authors[6].Id),
                new Book("A Farewell to Arms", "1929", 12, authors[6].Id),
                new Book("For Whom the Bell Tolls", "1940", 15, authors[6].Id),

                new Book("The Adventures of Tom Sawyer", "1876", 10, authors[7].Id),
                new Book("Adventures of Huckleberry Finn", "1884", 12, authors[7].Id),
                new Book("A Connecticut Yankee in King Arthur's Court", "1889", 15, authors[7].Id),

                new Book("Crime and Punishment", "1866", 10, authors[8].Id),
                new Book("The Brothers Karamazov", "1880", 12, authors[8].Id),
                new Book("The Idiot", "1869", 8, authors[8].Id),

                new Book("Norwegian Wood", "1987", 15, authors[9].Id),
                new Book("Kafka on the Shore", "2002", 17, authors[9].Id),
                new Book("1Q84", "2009", 20, authors[9].Id),

            };

            database.InsertAll(books);
        }

        public void DeleteAllData()
        {
            database.DeleteAll<Author>();
            database.DeleteAll<Book>();
        }
    }
}

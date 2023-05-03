namespace _153505_Shmatov.Domain.Entities
{
    public class Author : Entity
    {
      //  public int AuthorId { get; set; }
       // public string? Name { get; set; }
        public int Age { get; set; }
        public string? DateOfBirth { get; set; }
        public List<Book>? Books { get; set; }

        public Author() { }

        public Author(int id, string name, int age, string dateOfBirth, List<Book> books)
        {
            Id = id;
            Name = name;
            Age = age;
            DateOfBirth = dateOfBirth;
            Books = books;
        }
    }
}
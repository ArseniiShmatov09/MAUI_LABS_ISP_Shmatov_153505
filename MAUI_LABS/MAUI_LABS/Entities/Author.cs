using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using SQLite;

namespace MAUI_LABS.Entities
{
    [Table("Authors")] 
    public class Author
    {
        [PrimaryKey, AutoIncrement, Indexed]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string DateOfBirth { get; set; }
        public float Rating { get; set; }

        public Author() { }

        public Author(string name, int age, string dateOfBirth, float rating)
        {
            Name = name;
            Age = age;
            DateOfBirth = dateOfBirth;
            Rating = rating;
        }
    }
}

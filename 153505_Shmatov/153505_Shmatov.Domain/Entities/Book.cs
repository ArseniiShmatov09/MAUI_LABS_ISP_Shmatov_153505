using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153505_Shmatov.Domain.Entities
{
    public class Book : Entity
    {
        public double Rating { get; set; }
        public string? YearOfPublication { get; set; }
        public int Price { get; set; }
        public int AuthorId { get; set; }
        public String imagePath { get; set; }

        public Book() { }

        public Book(int id, string name, double rating, string yearOfPublication, int price, int authorId)
        {
            Id = id;
            Name = name;
            Rating = rating;
            YearOfPublication = yearOfPublication;
            Price = price;
            AuthorId = authorId;

        }
    }
}

using _153505_Shmatov.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace _153505_Shmatov.Persistense.Data
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
    }

}
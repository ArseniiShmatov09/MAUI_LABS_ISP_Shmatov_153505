using _153505_Shmatov.Applications.Abstractions;
using _153505_Shmatov.Applications.Services;
using _153505_Shmatov.Domain.Abstractions;
using _153505_Shmatov.Domain.Entities;
using _153505_Shmatov.Persistense.Data;
using _153505_Shmatov.Persistense.Repository;
using _153505_ShmatovNEW.UI.Pages;
using _153505_ShmatovNEW.UI.ViewModels;
using CommunityToolkit.Maui;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace _153505_ShmatovNEW.UI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            string settingsStream = "_153505_ShmatovNEW.UI.appsettings.json";
            var builder = MauiApp.CreateBuilder();


            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });


            var a = Assembly.GetExecutingAssembly();
            using var stream = a.GetManifestResourceStream(settingsStream);
            builder.Configuration.AddJsonStream(stream);

            AddDbContext(builder);
            SetupServices(builder.Services);
            SeedData(builder.Services);
           

            return builder.Build();
        }

        private static void SetupServices(IServiceCollection services)
        {
            // Services
            services.AddSingleton<IUnitOfWork, EfUnitOfWork>();
            //services.AddSingleton<IUnitOfWork, FakeUnitOfWork>();
            services.AddSingleton<IAuthorService, AuthorService>();
            services.AddSingleton<IBookService, BookService>();

            //Pages
            services.AddSingleton<AuthorsManager>();
            services.AddTransient<BookDetails>();
            services.AddTransient<AddingAuthor>();
            services.AddTransient<AddingBook>();
            services.AddTransient<EditingBook>();

            //ViewModels
            services.AddSingleton<AuthorsViewModel>();
            services.AddTransient<BookDetailsViewModel>();
            services.AddTransient<BookEditViewModel>();
        }

        private static void AddDbContext(MauiAppBuilder builder)
        {
            var connStr = builder.Configuration
            .GetConnectionString("SqliteConnection");
            string dataDirectory = String.Empty;

#if ANDROID
            dataDirectory = FileSystem.AppDataDirectory+"/";
#endif

            connStr = String.Format(connStr, dataDirectory);

            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlite(connStr)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .Options;

            builder.Services.AddSingleton<AppDbContext>((s) => new AppDbContext(options));
        }

        public async static void SeedData(IServiceCollection services)
        {
            using var provider = services.BuildServiceProvider();
            var unitOfWork = provider.GetService<IUnitOfWork>();

            await unitOfWork.RemoveDatbaseAsync();
            await unitOfWork.CreateDatabaseAsync();

            // Add authors
            IReadOnlyList<Author> authors = new List<Author>()
            {
                new Author(){Name = "J.K. Rowling", Age = 56, DateOfBirth = "31.07.1965" },
                new Author(){Name = "J.R.R. Tolkien", Age = 81, DateOfBirth = "03.01.1892" },
               /* new Author(){Name = "Agatha Christie", Age = 85, DateOfBirth = "15.09.1890" },
                new Author(){Name = "Stephen King", Age = 74, DateOfBirth = "21.09.1947" },
                new Author(){Name = "Leo Tolstoy", Age = 82, DateOfBirth = "09.09.1828" },
                new Author(){Name = "Jane Austen", Age = 41, DateOfBirth = "16.12.1775" },
                new Author(){Name = "Ernest Hemingway", Age = 62, DateOfBirth = "21.07.1899" },
                new Author(){Name = "Mark Twain", Age = 74, DateOfBirth = "30.11.1835" },
                new Author(){Name = "Fyodor Dostoevsky", Age = 59, DateOfBirth = "11.11.1821" },*/
              
            };

            foreach (var author in authors)
                await unitOfWork.AuthorRepository.AddAsync(author);
            await unitOfWork.SaveAllAsync();

            //Add trainees
            
            Random rand = new Random();
            int k = 1;
           
            foreach (var author in authors)
                for (int j = 0; j < 10; j++)
                    await unitOfWork.BookRepository.AddAsync(new Book()
                    {
                        Name = $"Book {k++}",
                        Rating = Math.Round(rand.NextDouble(),3) * 10,
                        AuthorId = author.Id,
                        Price = rand.Next() % 1000,
                        YearOfPublication = $"01.01.199{j % 10}",
                        imagePath = $"picture{k - 1}.jpg"
                    });;

            await unitOfWork.SaveAllAsync();
        }
    }
}
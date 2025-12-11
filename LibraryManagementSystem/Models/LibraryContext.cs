using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Models
{
    public class LibraryContext:DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }
        // Seed initial data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookModel>().HasData(
                new BookModel
                {
                    BookId = 1,
                    Title = "Modern C# Programming Essentials",
                    Author = "Mark J. Price",
                    ISBN = "978-1803237807",
                    PublishedDate = new DateTime(2022, 4, 12),
                    IsAvailable = true
                },
                new BookModel
                {
                    BookId = 2,
                    Title = "Clean Architecture in .NET",
                    Author = "Jason Taylor",
                    ISBN = "978-0134494166",
                    PublishedDate = new DateTime(2023, 2, 5),
                    IsAvailable = true
                },
                new BookModel
                {
                    BookId = 3,
                    Title = "ASP.NET Core Web API Guide",
                    Author = "Adam Freeman",
                    ISBN = "978-1484279567",
                    PublishedDate = new DateTime(2021, 9, 18),
                    IsAvailable = true
                },
                new BookModel
                {
                    BookId = 4,
                    Title = "SQL Server Query Performance Tuning",
                    Author = "Grant Fritchey",
                    ISBN = "978-1484259620",
                    PublishedDate = new DateTime(2020, 6, 10),
                    IsAvailable = true
                },
                new BookModel
                {
                    BookId = 5,
                    Title = "Entity Framework Core in Action",
                    Author = "Jon P Smith",
                    ISBN = "978-1617294563",
                    PublishedDate = new DateTime(2019, 5, 20),
                    IsAvailable = false
                }
            );
        }
        public DbSet<BookModel> Books { get; set; }
        public DbSet<ReaderModel> ReaderRecords { get; set; }
    }
}


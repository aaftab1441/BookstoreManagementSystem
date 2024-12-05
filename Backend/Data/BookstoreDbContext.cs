using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class BookstoreDbContext : DbContext
    {
        public BookstoreDbContext(DbContextOptions<BookstoreDbContext> options) : base(options) { }

        public DbSet<BookDto> Books { get; set; }
        public DbSet<AuthorDto> Authors { get; set; }
    }
}

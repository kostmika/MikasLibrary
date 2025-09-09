using Microsoft.EntityFrameworkCore;
using MikasLibrary.Models;

namespace MikasLibrary.Utils
{
    public class LibraryDBContext : DbContext
    {
        public LibraryDBContext(DbContextOptions<LibraryDBContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; } = null!;

        public DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasOne(b => b.BorrowedByUser)
                .WithMany(u => u.BorrowedBooks)
                .HasForeignKey(b => b.BorrowedBy);
        }
    }
}

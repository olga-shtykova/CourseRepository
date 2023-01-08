using EFConsole.Models;
using Microsoft.EntityFrameworkCore;

namespace EFConsole
{
    public class AppContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<UserCredential> UserCredentials { get; set; }

        public DbSet<Topic> Topics { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Genre> Genres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = .\SQLEXPRESS;Database=EF;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Book>()
                .HasMany(book => book.Users)
                .WithMany(user => user.Books)
                .UsingEntity<Subscription>(
                   j => j
                    .HasOne(pt => pt.User)
                    .WithMany(t => t.Subscriptions)
                    .HasForeignKey(pt => pt.UserId),
                j => j
                    .HasOne(pt => pt.Book)
                    .WithMany(p => p.Subscriptions)
                    .HasForeignKey(pt => pt.BookId),
                j =>
                {
                    j.Property(pt => pt.StartDate).HasDefaultValueSql("GETDATE()");
                    j.Property(pt => pt.FinishDate).IsRequired(false);
                    j.HasKey(t => new { t.BookId, t.UserId });
                    j.ToTable("Subscriptions");
                });
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Twitter.Domain.Models;

namespace Twitter.Repository
{
    public class RepositoryContext : DbContext
    {
        public DbSet<Tweet> Tweets { get; set; }
        public DbSet<Media> Medias { get; set; }
        public DbSet<PollItem> PollItems { get; set; }
        public DbSet<Author> Authors { get; set; }

        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tweet>()
                .HasOne<Author>()
                .WithMany(a => a.Tweets)
                .HasForeignKey("AuthorId")
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}

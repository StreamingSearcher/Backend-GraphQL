using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDB.EntityFrameworkCore.Extensions;

namespace Infrastructure.Persistence
{
    public class MovieDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options) { }

        public static MovieDbContext Create(IMongoDatabase database) =>
            new(new DbContextOptionsBuilder<MovieDbContext>()
           .UseMongoDB(database.Client, database.DatabaseNamespace.DatabaseName)
        .Options);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.ToCollection("movies");
                entity.Property(e => e.ImdbId);
                entity.Property(e => e.Overview);
                entity.Property(e => e.Genres);
                entity.Property(e => e.ImageUrl);
                entity.Property(e => e.IsPlatformLoaded);
                entity.Property(e => e.Status);
                entity.Property(e => e.TitleType);
                entity.Property(e => e.Year);

            });

        }
    }
}

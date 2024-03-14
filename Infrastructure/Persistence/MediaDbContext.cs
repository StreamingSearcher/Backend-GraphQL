using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDB.EntityFrameworkCore.Extensions;

namespace Infrastructure.Persistence
{
    public class MediaDbContext : DbContext
    {
        public DbSet<Media> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Country> Countries { get; set; }

        public MediaDbContext(DbContextOptions<MediaDbContext> options) : base(options) { }

        public static MediaDbContext Create(IMongoDatabase database) =>
            new(new DbContextOptionsBuilder<MediaDbContext>()
           .UseMongoDB(database.Client, database.DatabaseNamespace.DatabaseName)
        .Options);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Media>(entity =>
            {
                entity.ToCollection("movies");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.ImdbId);
                entity.Property(e => e.Overview);
                entity.Property(e => e.Genres);
                entity.Property(e => e.ImageUrl);
                entity.Property(e => e.IsPlatformLoaded);
                entity.Property(e => e.Status);
                entity.Property(e => e.TitleType);
                entity.Property(e => e.Year);

            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToCollection("genres");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToCollection("countries");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

        }
    }
}

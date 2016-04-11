using Microsoft.Data.Entity;

namespace MindHypertrophy.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Card> Cards { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<CardTag> CardTags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = Startup.Configuration["Data:DefaultConnection:ConnectionString"];
            optionsBuilder.UseSqlServer(connectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //add composite key to CardsTags
            modelBuilder.Entity<CardTag>().HasKey(x => new { x.CardId, x.TagId });
        }
    }
}

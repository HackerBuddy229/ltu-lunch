using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.Internal.TypeHandlers.DateTimeHandlers;
using Npgsql.PostgresTypes;

namespace LtuLunch.Server.data
{
    public class LunchDbContext : DbContext
    {
        public LunchDbContext(DbContextOptions<LunchDbContext> dbContextOptions) : base(dbContextOptions) {}

        public DbSet<Resturant> Resturants { get; set; }
        public DbSet<Lunch> Lunches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resturant>().HasMany<Lunch>();
            modelBuilder.Entity<Resturant>().HasKey(r => r.Id);
            modelBuilder.Entity<Lunch>().HasOne<Resturant>();
            modelBuilder.Entity<Lunch>().HasKey(l => l.Id);
            
            var splitStringConverter = 
                new ValueConverter<IList<string>, string>(
                    v => string.Join(";", v), 
                    v => v.Split(new[] { ';' }));
            
            modelBuilder.Entity<Lunch>()
                .Property(nameof(Lunch.Tags))
                .HasConversion(splitStringConverter);

            modelBuilder.Entity<Lunch>()
                .Property(nameof(Lunch.When))
                .HasColumnType("date");
            
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Host=localhost:49153;Username=postgres;Password=test123;Database=ltulunch",
                o => o.UseNodaTime());
            base.OnConfiguring(optionsBuilder);
        }
    }
}


using LtuLunch.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace LtuLunch.Server.data;

public class LunchDbContext : DbContext
{
    public LunchDbContext(DbContextOptions<LunchDbContext> dbContextOptions) : base(dbContextOptions) {}

    public DbSet<Resturant> Resturants { get; set; }
    public DbSet<Lunch> Lunches { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Resturant>().HasMany<Lunch>();
        modelBuilder.Entity<Lunch>().HasOne<Resturant>();
        base.OnModelCreating(modelBuilder);
    }
}